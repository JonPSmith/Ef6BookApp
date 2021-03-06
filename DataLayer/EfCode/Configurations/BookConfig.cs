﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Data.Entity.ModelConfiguration;
using DataLayer.EfClasses;

namespace DataLayer.EfCode.Configurations
{
    public class BookConfig : EntityTypeConfiguration<Book>
    {
        public BookConfig()
        {
            Property(p => p.PublishedOn)
                .HasColumnType("date");

            Property(x => x.Price).HasPrecision(9,2);

            Property(x => x.ImageUrl) 
                .IsUnicode(false);

            HasIndex(x => x.PublishedOn);

            HasMany(x => x.Reviews).WithRequired().HasForeignKey(x => x.BookId);
            HasOptional(x => x.Promotion).WithRequired().WillCascadeOnDelete(true);
        }
    }
}