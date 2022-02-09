using System;

namespace NotificacaoService.Domain.Templates
{
    public class Template
    {
        public Template()
        {
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Linguagem { get; set; }
        public string RemetenteNome { get; set; }
        public string RemetenteEmail { get; set; }
        public string Assunto { get; set; }
        public string ConteudoCaminho { get; set; }
        public string NomeProjeto { get; set; }
    }
}

