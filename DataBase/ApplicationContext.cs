using DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<GameReview> GameReviews { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalComment> JournalComments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TherapeuticG> TherapeuticGames { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MentalBapp;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Journal>()
                .HasOne(j => j.User)
                .WithMany(u => u.Journals)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActivityLog>()
                .HasOne(a => a.User)
                .WithMany(u => u.ActivityLogs)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameReview>()
                .HasOne(gr => gr.User)
                .WithMany(u => u.GameReviews)
                .HasForeignKey(gr => gr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameReview>()
                .HasOne(gr => gr.TherapeuticGame)
                .WithMany(tg => tg.GameReviews)
                .HasForeignKey(gr => gr.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Achievement>()
                .HasOne(a => a.User)
                .WithMany(u => u.Achievements)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JournalComment>()
                .HasOne(jc => jc.User)
                .WithMany(u => u.JournalComments)
                .HasForeignKey(jc => jc.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
