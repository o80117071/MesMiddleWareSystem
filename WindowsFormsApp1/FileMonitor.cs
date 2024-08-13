using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace WindowsFormsApp1
{
    public enum RequestType
    {
        CheckUser,
        CheckProject,
        CheckBarcode,
        SendResult,
        Unknown
    }
    public enum MesType
    {
        SFC,
        SECS,
        CFX,
        Unknown
    }
    public class FileMonitor
    {
        private string pathToMonitor;
        private int pollingInterval;
        private Thread monitoringThread;
        private bool stopMonitoring;
        private string customerName;

        public FileMonitor(string path, string customerName, int interval = 1000)
        {
            pathToMonitor = path;
            this.customerName = customerName;
            pollingInterval = interval;
            stopMonitoring = false;
        }

        public void StartMonitoring()
        {
            monitoringThread = new Thread(MonitorDirectory);
            monitoringThread.Start();
        }

        public void StopMonitoring()
        {
            stopMonitoring = true;
            monitoringThread?.Join();
        }

        private void MonitorDirectory()
        {
            while (!stopMonitoring)
            {
                string[] filesToCheck = { "CheckUser.xml", "CheckProject.xml", "CheckBarcode.xml", "SendResult.xml" };
                foreach (var fileName in filesToCheck)
                {
                    string filePath = Path.Combine(pathToMonitor, fileName);

                    if (File.Exists(filePath))
                    {
                        RequestType requestType = DetermineRequestType(filePath);
                        ProcessFile(filePath, requestType);

                        string newFileName = "bak-" + fileName;
                        string newFilePath = Path.Combine(pathToMonitor, newFileName);
                        File.Move(filePath, newFilePath);
                    }
                }
                Thread.Sleep(pollingInterval);
            }
        }

        private RequestType DetermineRequestType(string filePath)
        {
            if (filePath.Contains("CheckUser")) return RequestType.CheckUser;
            if (filePath.Contains("CheckProject")) return RequestType.CheckProject;
            if (filePath.Contains("CheckBarcode")) return RequestType.CheckBarcode;
            if (filePath.Contains("SendResult")) return RequestType.SendResult;         
            return RequestType.Unknown;
        }

        private void ProcessFile(string filePath, RequestType requestType)
        {
            RequestData requestData = ParseFile(filePath);
            MesType mesType = DetermineMESType(filePath);

            // Create RequestProcessor 處理請求
            RequestProcessor processor = new RequestProcessor(mesType);
            processor.ProcessRequest(requestData, requestType);
        }
        private MesType DetermineMESType(string filePath)
        {
            if (filePath.Contains("SFC")) return MesType.SFC;
            if (filePath.Contains("SECS")) return MesType.SECS;
            if (filePath.Contains("CFX")) return MesType.CFX;
            return MesType.Unknown;
        }

        private RequestData ParseFile(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);

            RequestData requestData = new RequestData
            {
                UserName = doc.Root.Element("UserName")?.Value,
                Barcode = doc.Root.Element("Barcode")?.Value,
                ProjectName = doc.Root.Element("ProjectName")?.Value,
                Result = doc.Root.Element("Result")?.Value
            };

            return requestData;
        }
    }
}
