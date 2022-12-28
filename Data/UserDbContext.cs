﻿using Microsoft.EntityFrameworkCore;
using UserAPI.Data.Models;

namespace UserAPI.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
   
        

        //SEEDING => ADDING INITIAL DATA TO THE DABLE
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<InventoryUser>().HasData(
        //        new InventoryUser() { Id = 1, Firstname = "Kachi", LastName = "Newman", Email = "kachi@gmail.com", UserName = "kachi@gmail.com" });    

        //}
    }
}
