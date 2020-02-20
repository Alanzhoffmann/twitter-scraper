using System;
using System.Collections.Generic;

namespace TwitterScraper.API.Entidades
{
    public class Hashtag : IEquatable<Hashtag>, IEquatable<string>
    {
        public Hashtag(string texto)
        {
            Texto = texto;
        }

        public string Texto { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Hashtag);
        }

        public bool Equals(Hashtag other)
        {
            return other != null &&
                   Texto == other.Texto;
        }

        public bool Equals(string other)
        {
            return other != null &&
                   Texto == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Texto);
        }

        public static bool operator ==(Hashtag left, Hashtag right)
        {
            return EqualityComparer<Hashtag>.Default.Equals(left, right);
        }

        public static bool operator !=(Hashtag left, Hashtag right)
        {
            return !(left == right);
        }
    }
}
