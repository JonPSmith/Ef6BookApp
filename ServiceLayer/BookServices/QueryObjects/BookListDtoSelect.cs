// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Linq;
using DataLayer.EfClasses;

namespace ServiceLayer.BookServices.QueryObjects
{
    public static class BookListDtoSelect
    {
        public static IQueryable<BookListDto>             
            MapBookToDto(this IQueryable<Book> books)     
        {
            return books.Select(p => new BookListDto
            {
                BookId = p.BookId,                        
                Title = p.Title,                          
                Price = p.Price,                          
                PublishedOn = p.PublishedOn,              
                ActualPrice = p.Promotion == null         
                        ? p.Price                             
                        : p.Promotion.NewPrice,               
                PromotionPromotionalText =                
                        p.Promotion == null                   
                          ? null                              
                          : p.Promotion.PromotionalText,
                //AuthorsOrdered = string.Join(", ",        
                //        p.AuthorsLink                         
                //        .OrderBy(q => q.Order)                
                //        .Select(q => q.Author.Name)),  
                AuthorNames = p.AuthorsLink
                        .OrderBy(q => q.Order)
                        .Select(q => q.Author.Name).ToList(),
                ReviewsCount = p.Reviews.Count,           
                ReviewsAverageVotes =                  
                    p.Reviews.Select(y =>              
                        (double?)y.NumStars).Average() 

            });
        }
        /*********************************************************
        #A This method takes in IQueryable<Book> and returns IQueryable<BookListDto>
        #B These are simple copies of existing columns in the Books table
        #C This calculates the selling price, which is the normal price, or the promotion price if that relationship exists 
        #D The PromotionalText depends on whether a PriceOffer exists for this book
        #E This obtains an array of Authors' names, in the right order. We are using a Client vs. Server evaluation as we want the author's names combined into one string
        #F We need to calculate how many reviews there are
        #G To get EF Core to turn the LINQ average into the SQL AVG command I need to cast the NumStars to (double?)
        * *******************************************************/

    }
}