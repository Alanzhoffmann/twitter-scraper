using Microsoft.EntityFrameworkCore;
using TwitterScraper.API.Entidades;

namespace TwitterScraper.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hashtag>(b =>
            {
                b.HasKey(h => h.Texto);
            });

            modelBuilder.Entity<Mensagem>(b =>
            {
                b.HasKey(m => m.Id);
                b.Property(m => m.Autor);
                b.Property(m => m.DataPublicacao);
                b.Property(m => m.Texto);

                b.HasMany(m => m.MensagemHashtags)
                    .WithOne(mh => mh.Mensagem);
            });

            modelBuilder.Entity<MensagemHashtag>(b =>
            {
                b.HasKey(mh => new { mh.MensagemId, mh.Hashtag });
                b.HasOne(mh => mh.Mensagem).WithMany(m => m.MensagemHashtags);
            });
        }
    }
}
