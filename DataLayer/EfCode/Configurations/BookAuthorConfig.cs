﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Data.Entity.ModelConfiguration;
using DataLayer.EfClasses;


namespace DataLayer.EfCode.Configurations
{
    public class BookAuthorConfig : EntityTypeConfiguration<BookAuthor>
    {
        public BookAuthorConfig()
        {
            HasKey(p => new { p.BookId, p.AuthorId });
            ToTable("BookAuthor");
        }
    }
}