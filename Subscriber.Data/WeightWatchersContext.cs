using Microsoft.EntityFrameworkCore;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data
{
    public class WeightWatchersContext : DbContext
    {
        public WeightWatchersContext(DbContextOptions<WeightWatchersContext> options) : base(options)
        {

        }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<Card> Cards { get;set;}
    }              
}
