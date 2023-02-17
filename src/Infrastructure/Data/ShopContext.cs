﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext>options):base(options)
        {

        }
        public DbSet<Product> Categories => Set<Product>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Product> Products => Set<Product>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mevcut projedeki (Infrastructure) entity ayar dosyalarını bul ve uygula
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
     
    }
}
