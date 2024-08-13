using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface ICustomerProcessor
    {
        ResponseData ProcessCheckUser(RequestData requestData);
        ResponseData ProcessCheckProject(RequestData requestData);
        ResponseData ProcessCheckBarcode(RequestData requestData);
        ResponseData ProcessSendResult(RequestData requestData);

    }
}
