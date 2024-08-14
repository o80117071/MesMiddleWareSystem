using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CustomerProcessor
{
    public class CustomerAProcessor : ICustomerProcessor
    {
        public ResponseData ProcessCheckBarcode(RequestData requestData)
        {
            return new ResponseData();
        }
        public ResponseData ProcessCheckProject(RequestData requestData)
        {
            string value = CusFormSettings.GetSettingValue("txt_1");
            MainForm.Instance.AddLogMessage("Processing CheckProject for CustomerA");
            return new ResponseData()
            {
                Status = "PASS",
                UserName = "Kevin",
                Barcode = value,
            };
        }

        public ResponseData ProcessCheckUser(RequestData requestData)
        {
            return new ResponseData();
        }

        public ResponseData ProcessSendResult(RequestData requestData)
        {
            return new ResponseData();
        } 
    }
}
