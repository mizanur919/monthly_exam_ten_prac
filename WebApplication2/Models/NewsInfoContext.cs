using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class NewsInfoContext:DbContext
    {
        public NewsInfoContext(DbContextOptions<NewsInfoContext> options):base(options)
        {}
        public DbSet<NewsInfo> NewsInfos { get; set; }
    }
}
