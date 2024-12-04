using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoShowroom.Models;

namespace AutoShowroom.Data
{
    public class AutoShowroomContext : DbContext
    {
        public AutoShowroomContext (DbContextOptions<AutoShowroomContext> options)
            : base(options)
        {
        }

        public DbSet<AutoShowroom.Models.Car> Car { get; set; } = default!;
    }
}
