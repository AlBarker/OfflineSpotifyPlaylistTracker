﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfflineSpotifyPlaylistTracker.Domain;

#nullable disable

namespace OfflineSpotifyPlaylistTracker.Domain.Migrations
{
    [DbContext(typeof(SpotifyPlaylistTrackerContext))]
    [Migration("20220122055845_AddUserToTrack")]
    partial class AddUserToTrack
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OfflineSpotifyPlaylistTracker.Domain.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlbumArt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("OfflineSpotifyPlaylistTracker.Domain.Models.TrackPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("TrackPositions");
                });

            modelBuilder.Entity("OfflineSpotifyPlaylistTracker.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "karnage11i",
                            DisplayName = "Alex Karney",
                            ImageName = "ak"
                        },
                        new
                        {
                            Id = "magsatire",
                            DisplayName = "Jack McGrath",
                            ImageName = "jm"
                        },
                        new
                        {
                            Id = "1232101260",
                            DisplayName = "Chris Quigley",
                            ImageName = "cq"
                        },
                        new
                        {
                            Id = "1238290776",
                            DisplayName = "Joshua Landy",
                            ImageName = "jl"
                        },
                        new
                        {
                            Id = "1233033915",
                            DisplayName = "Alex Barker",
                            ImageName = "ab"
                        },
                        new
                        {
                            Id = "1244598275",
                            DisplayName = "Daniel Hornblower",
                            ImageName = "db"
                        },
                        new
                        {
                            Id = "genjamon1234",
                            DisplayName = "Josh Anderson",
                            ImageName = "ja"
                        },
                        new
                        {
                            Id = "braeden.wilson",
                            DisplayName = "Braeden Wilson",
                            ImageName = "bw"
                        },
                        new
                        {
                            Id = "1278556031",
                            DisplayName = "Matt Knightbridge",
                            ImageName = "mk"
                        },
                        new
                        {
                            Id = "griffkyn22",
                            DisplayName = "Griffyn Heels",
                            ImageName = "gh"
                        });
                });

            modelBuilder.Entity("OfflineSpotifyPlaylistTracker.Domain.Models.Track", b =>
                {
                    b.HasOne("OfflineSpotifyPlaylistTracker.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OfflineSpotifyPlaylistTracker.Domain.Models.TrackPosition", b =>
                {
                    b.HasOne("OfflineSpotifyPlaylistTracker.Domain.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });
#pragma warning restore 612, 618
        }
    }
}
