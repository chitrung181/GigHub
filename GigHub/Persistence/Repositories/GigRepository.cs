﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Gig GetGigWithAttendees(int gigId)
        {
             return _context.Gigs
                 .Include(g => Enumerable.Select<Attendance, ApplicationUser>(g.Attendances, a => a.Attendee))
                 .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public IEnumerable<Gig> GetUpcomingGigsByArtist(string userId)
        {
            return _context.Gigs
                .Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && !g.IsCancel)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGig(int gigid)
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .SingleOrDefault(g => g.Id == gigid );
        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}