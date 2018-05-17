// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace ServiceLayer.BookServices
{
    public class BookListCombinedDto
    {
        public BookListCombinedDto() { }

        public BookListCombinedDto(SortFilterPageOptions sortFilterPageData, IEnumerable<BookListDto> booksList)
        {
            SortFilterPageData = sortFilterPageData;
            BooksList = booksList;
        }

        public SortFilterPageOptions SortFilterPageData { get; set; }

        public IEnumerable<BookListDto> BooksList { get; set; }
    }
}