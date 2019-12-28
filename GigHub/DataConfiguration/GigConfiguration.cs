﻿using GigHub.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.DataConfiguration
{
    public static class GigConfiguration
    {
        public static void Configure(EntityTypeConfiguration<Gig> modelBuilder)
        {
            modelBuilder.ToTable("Gigs");

            modelBuilder.Property(e => e.Venue).IsRequired().HasMaxLength(255);

            modelBuilder.Property(e => e.ArtistId).IsRequired();
        }
    }
}