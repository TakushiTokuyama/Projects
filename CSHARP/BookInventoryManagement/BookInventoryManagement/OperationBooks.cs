using System.Collections.Generic;
using System.Linq;

namespace BookInventoryManagement
{
    /// <summary>
    /// 書籍を操作するクラス
    /// </summary>
    public static class OperationBooks
    {
        public static int GetTotalPrice(IList<Book> Books)
        {
            return Books.Sum(book => book.Price);
        }

        public static string GetFavoriteBook(string Category, IList<Book> Books)
        {
            return Books.OrderBy(book => book.Rank).FirstOrDefault(book => book.Category == Category).Title;
        }

        public static IList<Book> AddNewBook(IList<Book> Books, Book book)
        {
            Books.Add(book);
            return Books;
        }
    }
}
