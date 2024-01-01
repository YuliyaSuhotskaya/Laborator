using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laborator.Entities;

    public class List : DbContext
    {
        public List (DbContextOptions<List> options)
            : base(options)
        {
        }

        public DbSet<Laborator.Entities.Jewelry> Jewelry { get; set; } = default!;
    }
