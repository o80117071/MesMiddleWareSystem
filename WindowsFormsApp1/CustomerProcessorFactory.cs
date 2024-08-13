using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CustomerProcessor
{
    public static class CustomerProcessorFactory
    {
        public static ICustomerProcessor CreateProcessor()
        {
            switch (Configuration.CustomerName)
            {
                case "CustomerA":
                    return new CustomerAProcessor();
                case "CustomerB":
                    return new CustomerBProcessor();
                default:
                    throw new NotSupportedException($"Customer {Configuration.CustomerName} is not supported.");
            }
        }
    }
}
