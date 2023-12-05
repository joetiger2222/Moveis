using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDBContext:IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var readerGuid = "376be536-4dd7-4a46-9b3a-062548c8acd8";
            var writerGuid = "552b36f8-3fb4-461d-8a62-a2f430e29330";
            var roles = new List<IdentityRole>{
                new IdentityRole
                {
                    Id=readerGuid,
                    ConcurrencyStamp=readerGuid,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id=writerGuid,
                    ConcurrencyStamp=writerGuid,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m=>m.Movie).WithMany(am=>am.Actors_Movies).HasForeignKey(m=>m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am=>am.Actors_Movies).HasForeignKey(m => m.ActorId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor>Actors { get; set; }
        public DbSet<Movie>Movies{ get; set; }
        public DbSet<Actor_Movie>Actors_Movies{ get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema>Cinemas{ get; set; }
    }
}
