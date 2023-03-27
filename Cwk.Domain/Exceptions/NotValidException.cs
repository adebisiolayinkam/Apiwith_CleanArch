﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwk.Domain.Exceptions
{
    public class NotValidException : Exception
    {
        internal NotValidException()
        {
            ValidationErrors = new List<string>();
        }

        internal NotValidException(string message) : base(message)
        {
            ValidationErrors = new List<string>();
        }

        internal NotValidException(string message, Exception inner) : base(message, inner)
        {
            ValidationErrors = new List<string>();
        }
        public List<string> ValidationErrors { get;}
    }
}
