using System;

namespace TwitterScraper.API.Entidades
{
    public class MensagemHashtag
    {
        public MensagemHashtag(Mensagem mensagem, string hashtag)
        {
            Mensagem = mensagem;
            Hashtag = hashtag;
        }

        private MensagemHashtag()
        {
        }

        public Guid Id { get; set; }
        public Guid MensagemId { get; }
        public Mensagem Mensagem { get; }
        public string Hashtag { get; }
    }
}
