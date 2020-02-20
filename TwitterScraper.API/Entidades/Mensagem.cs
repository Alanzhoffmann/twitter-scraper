using System;
using System.Collections.Generic;
using System.Linq;

namespace TwitterScraper.API.Entidades
{
    public class Mensagem
    {
        public Mensagem(string autor, DateTime dataPublicacao, string texto, IEnumerable<string> hashtags)
        {
            Autor = autor;
            DataPublicacao = dataPublicacao;
            Texto = texto;
            MensagemHashtags = hashtags.Select(hashtag => new MensagemHashtag(this, hashtag)).ToList();
        }

        private Mensagem()
        {
        }

        public Guid Id { get; }
        public string Autor { get; }
        public DateTime DataPublicacao { get; }
        public string Texto { get; }

        public ICollection<MensagemHashtag> MensagemHashtags { get; }
    }
}
