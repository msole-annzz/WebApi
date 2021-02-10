﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Logger
{
    public class LoggerModel
    {
         public string Path { get; set; }
         public string QueryString { get; set; }
         public string Method { get; set; }
         public string RequestBody { get; set; } = string.Empty;
         public string Response { get; set; }
         public string ResponseCode { get; set; }
        // public DateTime RequestedOn { get; set; }
        public DateTimeOffset RequestedOn { get; set; }//структура
        public DateTimeOffset RespondedOn { get; set; }
    }
}
