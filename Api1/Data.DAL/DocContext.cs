using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api1.Data.DAL.Models;
using Api1.Models;

namespace Api1.Data.DAL.Models
{
    public class DocContext : DbContext
    {
        public DocContext(DbContextOptions<DocContext> options)
            : base(options){}
        //для файлов
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Api1.Models.Version> Versions { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
