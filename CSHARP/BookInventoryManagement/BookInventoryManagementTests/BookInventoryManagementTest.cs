using BookInventoryManagement;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BookInventoryManagementTests
{
    [TestFixture]
    public class Tests
    {
        List<Book> books;

        [OneTimeSetUp]
        public void Setup()
        {
            books = new List<Book>
            {
                    new Book("不思議の国","アニメ",2,500),
                    new Book("異世界転生もの","アニメ",1,300),
                    new Book("辛いプログラミング本","プログラミング",2,600),
                    new Book("戦国無双","歴史",1,300),
                    new Book("C#の基本","プログラミング",1,700),
                    new Book("日本の歴史","歴史",2,500),
            };
        }

        static IEnumerable<Book> AddNewBookTestCase()
        {
            yield return new Book("不思議の国", "アニメ", 2, 500);
            yield return new Book("異世界転生もの", "アニメ", 1, 300);
            yield return new Book("辛いプログラミング本", "プログラミング", 2, 600);
            yield return new Book("戦国無双", "歴史", 1, 300);
            yield return new Book("C#の基本", "プログラミング", 1, 700);
            yield return new Book("日本の歴史", "歴史", 2, 500);
        }

        static IEnumerable<object[]> GetFavoriteBookTestCase()
        {
            var favoriteBooks = new List<Book>
            {
                    new Book("不思議の国","アニメ",2,500),
                    new Book("異世界転生もの","アニメ",1,300),
                    new Book("辛いプログラミング本","プログラミング",2,600),
                    new Book("戦国無双","歴史",1,300),
                    new Book("C#の基本","プログラミング",1,700),
                    new Book("日本の歴史","歴史",2,500),
            };

            yield return new object[] { "アニメ", favoriteBooks, "異世界転生もの" };
            yield return new object[] { "歴史", favoriteBooks, "戦国無双" };
            yield return new object[] { "プログラミング", favoriteBooks, "C#の基本" };
        }

        [Test]
        public void AddNewBookTest01()
        {
            var book = new Book("世界の終わり", "歴史", 3, 100);
            var expected = OperationBooks.AddNewBook(new List<Book>(), book);
            var actual = new List<Book> { book };

            Assert.That(actual.First().Title, Is.EqualTo(expected.First().Title));
            Assert.That(actual.First().Category, Is.EqualTo(expected.First().Category));
            Assert.That(actual.First().Rank, Is.EqualTo(expected.First().Rank));
            Assert.That(actual.First().Price, Is.EqualTo(expected.First().Price));
        }

        [TestCase("世界の終わり", "歴史", 3, 100)]
        [TestCase("難しいC言語", "プログラミング", 3, 700)]
        public void AddNewBookTest02(string title, string category, int rank, int price)
        {
            var book = new Book(title, category, rank, price);
            var expected = OperationBooks.AddNewBook(new List<Book>(), book);
            var actual = new List<Book> { book };

            Assert.That(actual.First().Title, Is.EqualTo(expected.First().Title));
            Assert.That(actual.First().Category, Is.EqualTo(expected.First().Category));
            Assert.That(actual.First().Rank, Is.EqualTo(expected.First().Rank));
            Assert.That(actual.First().Price, Is.EqualTo(expected.First().Price));
        }

        [TestCase("世界の終わり", "歴史", 3, 100, ExpectedResult = "世界の終わり")]
        public string AddNewBookTest03(string title, string category, int rank, int price)
        {
            var book = new Book(title, category, rank, price);
            var expected = OperationBooks.AddNewBook(new List<Book>(), book);

            return expected.First().Title;
        }

        [TestCaseSource(nameof(AddNewBookTestCase))]
        public void AddNewBookTest04(Book book) 
        {
            var expected = OperationBooks.AddNewBook(new List<Book>(), book);

            Assert.That(book.Title, Is.EqualTo(expected.First().Title));
            Assert.That(book.Category, Is.EqualTo(expected.First().Category));
            Assert.That(book.Rank, Is.EqualTo(expected.First().Rank));
            Assert.That(book.Price, Is.EqualTo(expected.First().Price));
        }

        [Test]
        public void GetTotalPriceTest()
        {
            var actual = books.Sum(book => book.Price);

            Assert.That(actual,Is.EqualTo(OperationBooks.GetTotalPrice(books)));
        }

        [TestCaseSource(nameof(GetFavoriteBookTestCase))]
        public void GetFavoriteBookTest(string category, IList<Book> books, string actual) 
        {
            Assert.That(actual, Is.EqualTo(OperationBooks.GetFavoriteBook(category, books)));
        }
    }
}