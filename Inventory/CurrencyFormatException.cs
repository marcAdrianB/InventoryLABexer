﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class CurrencyFormatException: Exception
    {
        public CurrencyFormatException(string var): base(var) { }
    }
}
