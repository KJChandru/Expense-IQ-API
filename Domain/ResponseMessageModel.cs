﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ResponseMessageModel
    {
        public int Out { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }

}
