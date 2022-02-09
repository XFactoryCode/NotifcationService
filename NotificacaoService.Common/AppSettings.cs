using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotificacaoService.Common
{
    public class AppSettings
    {
        public string SmtpHost { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpPass { get; set; }
    }
}