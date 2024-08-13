﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SECSProcessor : IMESProcessor
    {
        public MesType MESType { get; private set; }

        public SECSProcessor(MesType mesType)
        {
            MESType = mesType;
        }
        public ResponseData ProcessRequest(RequestData requestData, RequestType requestType, ICustomerProcessor customerProcessor)
        {
            ResponseData responseData;

            switch (requestType)
            {
                case RequestType.CheckUser:
                    responseData = customerProcessor.ProcessCheckUser(requestData);
                    break;
                case RequestType.CheckProject:
                    responseData = customerProcessor.ProcessCheckProject(requestData);
                    break;
                case RequestType.CheckBarcode:
                    responseData = customerProcessor.ProcessCheckBarcode(requestData);
                    break;
                case RequestType.SendResult:
                    responseData = customerProcessor.ProcessSendResult(requestData);
                    break;
                default:
                    throw new NotSupportedException($"Request type {requestType} is not supported.");
            }

            return responseData;
        }
    }
}
