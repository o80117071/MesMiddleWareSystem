using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public interface IMESProcessor
    {
        MesType MESType { get; }
        ResponseData ProcessRequest(RequestData requestData, RequestType requestType, ICustomerProcessor customerProcessor);
    }
}
