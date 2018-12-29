using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCMovie.Models
{
    public class MVCMovieContext : DbContext
    {
        public MVCMovieContext (DbContextOptions<MVCMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MVCMovie.Models.Movie> Movie { get; set; }
    }
}
