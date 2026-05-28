using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System.Data.Entity;

namespace SQLGameDatabase
{
    public class AppDbContext : DbContext
    {
        public DbSet<SavedGame> Games { get; set; }

        public AppDbContext()
            : base("GameDatabase")
        {
        }
    }
}