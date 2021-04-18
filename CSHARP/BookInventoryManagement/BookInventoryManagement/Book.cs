namespace BookInventoryManagement
{
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book
    {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// カテゴリー
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// ランク(順位)
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// 価格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="title">コンストラクタ</param>
        /// <param name="category">カテゴリー</param>
        /// <param name="rank">ランク(順位)</param>
        /// <param name="price">価格</param>
        public Book(string title, string category, int rank, int price)
        {
            this.Title = title;
            this.Category = category;
            this.Rank = rank;
            this.Price = price;
        }
    }
}
