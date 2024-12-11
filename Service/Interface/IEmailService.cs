﻿using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage allMails);
    }
}
