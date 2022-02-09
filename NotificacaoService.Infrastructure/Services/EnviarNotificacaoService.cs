using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.IO;
using NotificacaoService.Common;
using System.Reflection;
using NotificacaoService.Domain.Templates;

namespace NotificacaolService.Infrastructure.Services
{
    public class EnviarNotificacaoService
    {
        private readonly AppSettings _appSettings;
        private readonly ITemplateRepository repository;

        public EnviarNotificacaoService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task Enviar(string templateNome, string nomeProjeto, string emailDestinatario, string assunto, IDictionary<string, string> parametros = null)
        {
            string body = "";

            var template = await repository.GetAsyncBy(a => a.Nome == templateNome && a.NomeProjeto == nomeProjeto);
            if (template == null) throw new Exception("Template não cadastrado.");

            try
            {
                body = BuscarTemplateEConverterParaString(template);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (parametros == null)
                parametros = new Dictionary<string, string>();

            var html = AdicionarParametros(body, parametros);
            Enviar(emailDestinatario, assunto, html, template.RemetenteEmail);
        }

        private void Enviar(string emailDestinatario, string assunto, string html, string emailRemetente)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailRemetente));
            email.To.Add(MailboxAddress.Parse(emailDestinatario));
            email.Subject = assunto;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_appSettings.SmtpHost, Convert.ToInt32(_appSettings.SmtpPort), SecureSocketOptions.StartTls);
                smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        private string BuscarTemplateEConverterParaString(Template template)
        {
            string body = null;
            using (Stream stream = typeof(EnviarNotificacaoService).Assembly.GetManifestResourceStream(template.ConteudoCaminho))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    body = reader.ReadToEnd();
                }
            }

            return body;
        }

        private string AdicionarParametros(string body, IDictionary<string, string> parametros)
        {
            if (string.IsNullOrWhiteSpace(body)) throw new ArgumentNullException("EnviarNotificacaoService.AdicionarParametros", nameof(body));
            if (parametros == null) throw new ArgumentNullException("EnviarNotificacaoService.AdicionarParametros", nameof(parametros));

            return string.Format(body, parametros); ;
        }
    }
}