using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InterviewAPI.Models
{
    public class InterviewAPIContext : DbContext
    {
        public InterviewAPIContext (DbContextOptions<InterviewAPIContext> options)
            : base(options)
        {
        }

        public DbSet<InterviewAPI.Models.Student> Student { get; set; }
    }
}
