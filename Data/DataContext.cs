﻿using Microsoft.EntityFrameworkCore;
using DemoWebAPI.Models;
namespace DemoWebAPI.Data
{
    public class DataContext:DbContext
    {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

            }
            public DbSet<Product> Products { get; set; }
     
    }

}
