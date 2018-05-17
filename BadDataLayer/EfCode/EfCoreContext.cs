// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Data.Entity;
using DataLayer.EfClasses;
using DataLayer.EfCode.Configurations;
using DataLayer.EfCode.Configurations;

namespace DataLayer.EfCode
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }              //#A
        public DbSet<Author> Authors { get; set; }          //#A
        public DbSet<PriceOffer> PriceOffers { get; set; }  //#A
        public DbSet<Order> Orders { get; set; }            //#A

        public EfCoreContext()
        {
        }

        public EfCoreContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookAuthorConfig());

            modelBuilder.Configurations.Add(new BookConfig());      
            modelBuilder.Configurations.Add(new BookAuthorConfig()); 
            modelBuilder.Configurations.Add(new PriceOfferConfig()); 
            modelBuilder.Configurations.Add(new OrderConfig());   
        }

    }
}


