﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataBase.Models.Achievement", b =>
                {
                    b.Property<int>("AchievementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AchievementId"));

                    b.Property<DateTime>("AchievementDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AchievementId");

                    b.HasIndex("UserId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("DataBase.Models.ActivityLog", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LogId");

                    b.HasIndex("UserId");

                    b.ToTable("ActivityLogs");
                });

            modelBuilder.Entity("DataBase.Models.Community", b =>
                {
                    b.Property<int>("CommunityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommunityId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CommunityId");

                    b.ToTable("Communities");
                });

            modelBuilder.Entity("DataBase.Models.GameReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameReviews");
                });

            modelBuilder.Entity("DataBase.Models.Journal", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("DataBase.Models.JournalComment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JournalId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("JournalId");

                    b.HasIndex("UserId");

                    b.ToTable("JournalComments");
                });

            modelBuilder.Entity("DataBase.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DataBase.Models.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DataBase.Models.TherapeuticG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TherapeuticGames");
                });

            modelBuilder.Entity("DataBase.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CommunityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommunityId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataBase.Models.Achievement", b =>
                {
                    b.HasOne("DataBase.Models.User", "User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataBase.Models.ActivityLog", b =>
                {
                    b.HasOne("DataBase.Models.User", "User")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataBase.Models.GameReview", b =>
                {
                    b.HasOne("DataBase.Models.TherapeuticG", "TherapeuticGame")
                        .WithMany("GameReviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataBase.Models.User", "User")
                        .WithMany("GameReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TherapeuticGame");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataBase.Models.Journal", b =>
                {
                    b.HasOne("DataBase.Models.User", "User")
                        .WithMany("Journals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataBase.Models.JournalComment", b =>
                {
                    b.HasOne("DataBase.Models.Journal", "Journal")
                        .WithMany()
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.User", "User")
                        .WithMany("JournalComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Journal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataBase.Models.Notification", b =>
                {
                    b.HasOne("DataBase.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataBase.Models.User", b =>
                {
                    b.HasOne("DataBase.Models.Community", null)
                        .WithMany("Members")
                        .HasForeignKey("CommunityId");
                });

            modelBuilder.Entity("DataBase.Models.Community", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("DataBase.Models.TherapeuticG", b =>
                {
                    b.Navigation("GameReviews");
                });

            modelBuilder.Entity("DataBase.Models.User", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("ActivityLogs");

                    b.Navigation("GameReviews");

                    b.Navigation("JournalComments");

                    b.Navigation("Journals");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
