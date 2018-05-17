// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Data.Entity.ModelConfiguration;
using DataLayer.EfClasses;

namespace DataLayer.EfCode.Configurations
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            HasMany(x => x.LineItems)
                .WithRequired()
                .HasForeignKey(x => x.OrderId)
                .WillCascadeOnDelete(false);
        }
    }
}