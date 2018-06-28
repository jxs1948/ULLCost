using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ULLCost.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new ULLCostContext(
                    serviceProvider.GetRequiredService<DbContextOptions<ULLCostContext>>()))
                {
                    // Look for any movies.
                    if (context.Movie.Any())
                    {
                        return;   // DB has been seeded
                    }

                    context.Movie.AddRange(
                         new Movie
                         {
                            Term = "Spring 2018",
                            Level = "Graduate",
                            State = "Resident",
                            Status = "International",
                            Credits = 2,
                            Fees = 2234
                         },

                         new Movie
                         {
                        Term = "Spring 2018",
                             Level = "Graduate",
                             State = "Resident",
                             Status = "International",
                             Credits = 2,
                             Fees = 2234
                         },

                         new Movie
                         {
                        Term = "Spring 2018",
                             Level = "Graduate",
                             State = "Resident",
                             Status = "International",
                             Credits = 2,
                             Fees = 2234
                         },

                       new Movie
                       {
                        Term = "Spring 2018",
                           Level = "Graduate",
                           State = "Resident",
                           Status = "International",
                           Credits = 2,
                           Fees = 2234
                       }
                    );
                    context.SaveChanges();
                }
            }
        }
    }