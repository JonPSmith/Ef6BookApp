// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Data.Entity.ModelConfiguration;
using DataLayer.EfClasses;

namespace DataLayer.EfCode.Configurations
{
    public class LineItemConfig : EntityTypeConfiguration<LineItem>
    {
        public LineItemConfig()
        {

            HasRequired(x => x.ChosenBook)
                .WithMany()
                .WillCascadeOnDelete(false);

            Property(x => x.BookPrice).HasPrecision(18,2);
        }
    }
}