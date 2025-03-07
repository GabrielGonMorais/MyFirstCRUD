﻿using Microsoft.EntityFrameworkCore;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<SuperHero> SuperHeroes { get; set; }

    public DbSet<Comic> Comics { get; set; }
}


