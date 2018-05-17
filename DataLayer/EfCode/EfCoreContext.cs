// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataLayer.EfClasses;
using DataLayer.EfCode.Configurations;

namespace DataLayer.EfCode
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }  
        public DbSet<Author> Authors { get; set; }          
        public DbSet<PriceOffer> PriceOffers { get; set; }  
        public DbSet<Order> Orders { get; set; }            

        public EfCoreContext()
        {
        }

        public EfCoreContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookConfig());      
            modelBuilder.Configurations.Add(new BookAuthorConfig()); 
            modelBuilder.Configurations.Add(new PriceOfferConfig()); 
            modelBuilder.Configurations.Add(new LineItemConfig());

            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<LineItem>().ToTable("LineItem");
        }

    }
}


