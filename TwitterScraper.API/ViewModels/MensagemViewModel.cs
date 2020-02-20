using System;

namespace TwitterScraper.API.ViewModels
{
    public class MensagemViewModel
    {
        public MensagemViewModel(string autor, DateTime dataPublicacao, string texto)
        {
            Autor = autor;
            DataPublicacao = dataPublicacao;
            Texto = texto;
        }

        public string Autor { get; }
        public DateTime DataPublicacao { get; }
        public string Texto { get; }
    }
}
