using CAI.Enitty.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Enitty
{
    class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureBookEntity(modelBuilder);
        }
        private static void ConfigureBookEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>();
            modelBuilder.Entity<Province>();
            modelBuilder.Entity<Town>();
            modelBuilder.Entity<UpdateLog>();
        }
    }
}
