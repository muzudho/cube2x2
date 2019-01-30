namespace Grayscale.Cube2X2BookGenerate
{
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    /// <summary>
    /// 展開図。
    /// </summary>
    public class DevelopmentTiles
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevelopmentTiles"/> class.
        /// </summary>
        /// <param name="tileArray">タイルの配列。</param>
        public DevelopmentTiles(Panel[] tileArray)
        {
            this.TileArray = tileArray;
        }

        /// <summary>
        /// Gets or sets タイルの配列。
        /// </summary>
        public Panel[] TileArray { get; set; }

        /// <summary>
        /// タイルの色を返します。
        /// </summary>
        /// <param name="tile">タイル番号。</param>
        /// <returns>タイルの色。</returns>
        public Color GetTileColor(int tile)
        {
            return this.TileArray[tile].BackColor;
        }

        /// <summary>
        /// タイルの色を設定します。
        /// </summary>
        /// <param name="tile">タイル番号。</param>
        /// <param name="color">色。</param>
        public void SetTileColor(int tile, Color color)
        {
            this.TileArray[tile].BackColor = color;
        }

        /// <summary>
        /// 盤面を、文字列で返す。
        /// </summary>
        /// <returns>局面</returns>
        public string GetBoardText()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0}{1}{2}{3}/{4}{5}{6}{7}/{8}{9}{10}{11}/{12}{13}{14}{15}/{16}{17}{18}{19}/{20}{21}{22}{23}",
                ColorHelper.GetShort(this.GetTileColor(0)),
                ColorHelper.GetShort(this.GetTileColor(1)),
                ColorHelper.GetShort(this.GetTileColor(2)),
                ColorHelper.GetShort(this.GetTileColor(3)),
                ColorHelper.GetShort(this.GetTileColor(4)),
                ColorHelper.GetShort(this.GetTileColor(5)),
                ColorHelper.GetShort(this.GetTileColor(6)),
                ColorHelper.GetShort(this.GetTileColor(7)),
                ColorHelper.GetShort(this.GetTileColor(8)),
                ColorHelper.GetShort(this.GetTileColor(9)),
                ColorHelper.GetShort(this.GetTileColor(10)),
                ColorHelper.GetShort(this.GetTileColor(11)),
                ColorHelper.GetShort(this.GetTileColor(12)),
                ColorHelper.GetShort(this.GetTileColor(13)),
                ColorHelper.GetShort(this.GetTileColor(14)),
                ColorHelper.GetShort(this.GetTileColor(15)),
                ColorHelper.GetShort(this.GetTileColor(16)),
                ColorHelper.GetShort(this.GetTileColor(17)),
                ColorHelper.GetShort(this.GetTileColor(18)),
                ColorHelper.GetShort(this.GetTileColor(19)),
                ColorHelper.GetShort(this.GetTileColor(20)),
                ColorHelper.GetShort(this.GetTileColor(21)),
                ColorHelper.GetShort(this.GetTileColor(22)),
                ColorHelper.GetShort(this.GetTileColor(23)));
        }
    }
}
