using System;
using System.Collections.Generic;
using System.Data.Entity;

using CAI.Config;
using CAI.Enitty.Entities;
using SQLite.CodeFirst;

namespace CAI.Enitty
{
    public class CAIDbContext : DbContext
    {
        public CAIDbContext() : base(Configs.DefaultDbConnectStrName)
        {
            //初始化模型
            //Database.SetInitializer(new CAIDbInit());

            //Database.SetInitializer(new DropCreateDatabaseAlways<CAIDbContext>());

            //Database.Initialize(true);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var init = new SqliteDropCreateDatabaseAlways<CAIDbContext>(modelBuilder);
            Database.SetInitializer(init);
        }

        public DbSet<City> City { get; set; }

        public DbSet<Province> Province { get; set; }

        public DbSet<Town> Town { get; set; }

        public DbSet<UpdateLog> UpdateLog { get; set; }

    }
}
