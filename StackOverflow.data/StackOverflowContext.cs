using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflowOsc.Domain.Entities;

namespace StackOverflow.data
{
    public class StackOverflowContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Question> Questions {get; set;}
        public DbSet<Answer> Answers { get; set; } 

    }
}
