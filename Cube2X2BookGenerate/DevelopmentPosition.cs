namespace Grayscale.Cube2X2BookGenerate
{
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    /// <summary>
    /// 展開図用の局面インターフェース。
    /// </summary>
    public class DevelopmentPosition : AbstractPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevelopmentPosition"/> class.
        /// </summary>
        /// <param name="tileArray">タイルの配列。</param>
        public DevelopmentPosition(Panel[] tileArray)
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
        public override int GetTileColor(int tile)
        {
            return ColorHelper.GetColor(this.TileArray[tile].BackColor);
        }

        /// <summary>
        /// タイルの色を設定します。
        /// </summary>
        /// <param name="tile">タイル番号。</param>
        /// <param name="color">色。</param>
        public override void SetTileColor(int tile, int color)
        {
            this.TileArray[tile].BackColor = ColorHelper.GetColor(color);
        }
    }
}
