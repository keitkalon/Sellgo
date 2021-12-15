﻿using El_Proyecte_Grande.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace El_Proyecte_Grande
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client_Deal>().HasKey(clientDeal => new
            {
                clientDeal.ClientId,
                clientDeal.DealId,
            });

            modelBuilder.Entity<Client_Deal>().HasOne(client => client.Client)
                .WithMany(clientDeal => clientDeal.Deals).HasForeignKey(clientDeal => clientDeal.DealId);

            modelBuilder.Entity<Client_Deal>().HasOne(client => client.Deal)
               .WithMany(clientDeal => clientDeal.Clients).HasForeignKey(clientDeal => clientDeal.ClientId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Client_Deal> Client_Deals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Interception> Interceptions { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<PersonalApproach> PersonalApproaches { get; set; }
        public DbSet<ProfessionalApproach> ProfessionalApproaches { get; set; }

    }
}
