using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CustomerProcessor
{
    public class CustomerBProcessor : ICustomerProcessor
    {
        public ResponseData ProcessCheckBarcode(RequestData requestData)
        {
            return new ResponseData();
        }

        public ResponseData ProcessCheckProject(RequestData requestData)
        {
            return new ResponseData();
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
