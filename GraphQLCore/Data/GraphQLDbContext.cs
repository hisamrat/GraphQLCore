﻿using GraphQLCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCore.Data
{
    public class GraphQLDbContext: DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
