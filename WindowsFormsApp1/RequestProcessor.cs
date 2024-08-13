using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WindowsFormsApp1.CustomerProcessor;

namespace WindowsFormsApp1
{
    public class RequestProcessor
    {
        private readonly ICustomerProcessor _customerProcessor;
        private readonly IMESProcessor _mesProcessor;

        public RequestProcessor(MesType mesType)
        {
            _customerProcessor = CustomerProcessorFactory.CreateProcessor();
            _mesProcessor = MESProcessorFactory.CreateProcessor(mesType);
        }

        public void ProcessRequest(RequestData requestData, RequestType requestType)
        {
            ResponseData responseData;

            // 根據requestType處理請求
            switch (requestType)
            {
                case RequestType.CheckUser:
                    responseData = _mesProcessor.ProcessRequest(requestData, RequestType.CheckUser, _customerProcessor);
                    break;

                case RequestType.CheckProject:
                    responseData = _mesProcessor.ProcessRequest(requestData, RequestType.CheckProject, _customerProcessor);
                    break;

                case RequestType.CheckBarcode:
                    responseData = _mesProcessor.ProcessRequest(requestData, RequestType.CheckBarcode, _customerProcessor);
                    break;

                case RequestType.SendResult:
                    responseData = _mesProcessor.ProcessRequest(requestData, RequestType.SendResult, _customerProcessor);
                    break;

                default:
                    throw new NotSupportedException($"Request type {requestType} is not supported.");
            }

            string responseFilePath = GetResponseFilePath(_mesProcessor.MESType, requestType);
            WriteResponseToXml(responseData, responseFilePath);
        }

        private string GetResponseFilePath(MesType mesType, RequestType requestType)
        {
            return $@"MESPolling\{mesType}\res-{requestType}.xml";
        }

        private void WriteResponseToXml(ResponseData responseData, string outputPath)
        {
            var xml = new XElement("Response",
                new XElement("Status", responseData.Status),
                new XElement($"Barcode", responseData.Barcode),
                new XElement($"UserName", responseData.UserName),
                new XElement("Message", responseData.Message),
                new XElement("ProjectName", responseData.ProjectName),
                new XElement("Result", responseData.Result)
            );

            xml.Save(outputPath);
            Console.WriteLine($"Response XML written to: {outputPath}");
        }
    }
}
