using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumII.Models
{
    public class MainDbCotext : DbContext
    {
        public MainDbCotext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbCotext()
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate).IsRequired();

                a.HasData(
                    new Album { IdAlbum = 1, AlbumName = "F8", PublishDate = DateTime.Parse("2020-02-28"), IdMusicLabel = 1 },
                    new Album { IdAlbum = 2, AlbumName = "And Justice for None", PublishDate = DateTime.Parse("2018-05-18"), IdMusicLabel = 1 },
                    new Album { IdAlbum = 3, AlbumName = "Got your Six", PublishDate = DateTime.Parse("2015-09-04"), IdMusicLabel = 1 }
                );
            });

            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.Nickname).HasMaxLength(20);

                m.HasData(
                    new Musician { IdMusician = 1, FirstName  = "Five Finger", LastName = " Death Punch", Nickname = "FiveFingerDeathPunch" }
                    /*new Musician{ IdMusician = 2, AlbumName = "And Justice for None", PublishDate = DateTime.Parse("2018-05-18"), IdMusicLabel = 1 },
                    new Musician { IdAlbum = 3, AlbumName = "Got your Six", PublishDate = DateTime.Parse("2015-09-04"), IdMusicLabel = 1 } */
                );
            });

            modelBuilder.Entity<Musician_Track>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.HasKey(e => e.IdTrack);
                m.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician);
                m.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack);

                m.HasData(
                    new Musician_Track { IdMusician = 1, IdTrack = 1 },
                    new Musician_Track { IdMusician = 1, IdTrack = 2 }
                );
            });

            modelBuilder.Entity<MusicLabel>(m =>
            {
                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name).IsRequired().HasMaxLength(50);

                m.HasData(
                    new MusicLabel {  IdMusicLabel = 1, Name = "Napalm Records" }
                );
            });

            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();

                t.HasData(
                    new Track { IdTrack = 1, TrackName = "Wrong Side of Heaven", Duration = 2.58f, IdAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "I Apologize", Duration = 3.50f, IdAlbum = 2 }
                );
            });
        }
    }

    
}
