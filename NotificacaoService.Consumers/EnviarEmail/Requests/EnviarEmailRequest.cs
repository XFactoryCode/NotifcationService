using NotificacaoService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificacaoService.Consumers.EnviarEmail.Requests
{
    internal class EnviarEmailRequest
    {
        public string TemplateNome { get; set; }
        public string NomeProjeto { get; set; }
        public TipoNotificacao TipoNotificacao { get; set; }
        public string MyProperty { get; set; }
    }
}
