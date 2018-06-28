using System;
using Microsoft.EntityFrameworkCore;
namespace ULLCost.Models
{
    public class MvcMovieContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options) 
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }
    }
}
