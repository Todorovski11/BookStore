﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payment
{
    public class StripeSettings
    {
        public string? SecretKey { get; set; }
        public string? PublicKey { get; set; }
    }
}