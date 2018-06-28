using System;
using Microsoft.EntityFrameworkCore;
namespace ULLCost.Models
{
    public class ULLCostContext : DbContext
    {
       public ULLCostContext(DbContextOptions<ULLCostContext> options)
            : base(options)
        {
        }

        public DbSet<ULLCost.Models.Movie> Movie { get; set; }

    }
   
}

