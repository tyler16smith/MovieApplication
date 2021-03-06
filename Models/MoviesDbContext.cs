using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Models
{
    public class MoviesDbContext: DbContext
    {
        // the "REAL" database - updates with each new entry
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        { }

        // create new "Movie" table
        public DbSet<Movie> Movies { get; set; }
    }
}
