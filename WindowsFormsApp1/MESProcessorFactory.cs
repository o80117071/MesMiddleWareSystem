using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class MESProcessorFactory
    {
        public static IMESProcessor CreateProcessor(MesType mesType)
        {
            switch (mesType)
            {
                case MesType.SFC:
                    return new SFCProcessor(mesType);
                case MesType.SECS:
                    return new SECSProcessor(mesType);
                case MesType.CFX:
                    return new CFXProcessor(mesType);
                default:
                    throw new NotSupportedException($"MES type {mesType} is not supported.");
            }
        }
    }
}
