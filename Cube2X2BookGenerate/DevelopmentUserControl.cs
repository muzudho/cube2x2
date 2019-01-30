namespace Grayscale.Cube2X2BookGenerate
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// 展開図コントロール。
    /// </summary>
    public partial class DevelopmentUserControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevelopmentUserControl"/> class.
        /// </summary>
        public DevelopmentUserControl()
        {
            this.InitializeComponent();
            this.DevelopmentTiles = new DevelopmentTiles(new Panel[]
            {
                this.tile0,
                this.tile1,
                this.tile2,
                this.tile3,
                this.tile4,
                this.tile5,
                this.tile6,
                this.tile7,
                this.tile8,
                this.tile9,
                this.tile10,
                this.tile11,
                this.tile12,
                this.tile13,
                this.tile14,
                this.tile15,
                this.tile16,
                this.tile17,
                this.tile18,
                this.tile19,
                this.tile20,
                this.tile21,
                this.tile22,
                this.tile23,
            });
        }

        /// <summary>
        /// Gets or sets 展開図ユーザーコントロール。
        /// </summary>
        public DevelopmentTiles DevelopmentTiles { get; set; }

        /// <summary>
        /// ゲーム開始状態に戻します。
        /// </summary>
        public void SetNewGame()
        {
            this.DevelopmentTiles.SetTileColor(0, Color.Orange);
            this.DevelopmentTiles.SetTileColor(1, Color.Orange);
            this.DevelopmentTiles.SetTileColor(2, Color.Orange);
            this.DevelopmentTiles.SetTileColor(3, Color.Orange);
            this.DevelopmentTiles.SetTileColor(4, Color.Violet);
            this.DevelopmentTiles.SetTileColor(5, Color.Violet);
            this.DevelopmentTiles.SetTileColor(6, Color.Violet);
            this.DevelopmentTiles.SetTileColor(7, Color.Violet);
            this.DevelopmentTiles.SetTileColor(8, Color.Pink);
            this.DevelopmentTiles.SetTileColor(9, Color.Pink);
            this.DevelopmentTiles.SetTileColor(10, Color.Pink);
            this.DevelopmentTiles.SetTileColor(11, Color.Pink);
            this.DevelopmentTiles.SetTileColor(12, Color.SkyBlue);
            this.DevelopmentTiles.SetTileColor(13, Color.SkyBlue);
            this.DevelopmentTiles.SetTileColor(14, Color.SkyBlue);
            this.DevelopmentTiles.SetTileColor(15, Color.SkyBlue);
            this.DevelopmentTiles.SetTileColor(16, Color.LightGray);
            this.DevelopmentTiles.SetTileColor(17, Color.LightGray);
            this.DevelopmentTiles.SetTileColor(18, Color.LightGray);
            this.DevelopmentTiles.SetTileColor(19, Color.LightGray);
            this.DevelopmentTiles.SetTileColor(20, Color.Lime);
            this.DevelopmentTiles.SetTileColor(21, Color.Lime);
            this.DevelopmentTiles.SetTileColor(22, Color.Lime);
            this.DevelopmentTiles.SetTileColor(23, Color.Lime);
        }

        /// <summary>
        /// 90度回転。4つのタイルを、１つずらします。
        /// </summary>
        /// <param name="a">タイル1。</param>
        /// <param name="b">タイル2。</param>
        /// <param name="c">タイル3。</param>
        /// <param name="d">タイル4。</param>
        public void Shift4(int a, int b, int c, int d)
        {
            // 展開図
            var temp = this.DevelopmentTiles.GetTileColor(d);
            this.DevelopmentTiles.SetTileColor(d, this.DevelopmentTiles.GetTileColor(c));
            this.DevelopmentTiles.SetTileColor(c, this.DevelopmentTiles.GetTileColor(b));
            this.DevelopmentTiles.SetTileColor(b, this.DevelopmentTiles.GetTileColor(a));
            this.DevelopmentTiles.SetTileColor(a, temp);
        }

        /// <summary>
        /// キューブを 90° ひねります。
        /// </summary>
        /// <param name="handle">回転箇所。</param>
        public void RotateOnly(int handle)
        {
            switch (handle)
            {
                case 0:
                    this.Shift4(8, 0, 19, 20);
                    this.Shift4(10, 2, 17, 22);
                    this.Shift4(5, 4, 6, 7);
                    break;
                case 1:
                    this.Shift4(9, 1, 18, 21);
                    this.Shift4(11, 3, 16, 23);
                    this.Shift4(12, 13, 15, 14);
                    break;
                case 2:
                    this.Shift4(12, 2, 7, 21);
                    this.Shift4(14, 3, 5, 20);
                    this.Shift4(9, 8, 10, 11);
                    break;
                case 3:
                    this.Shift4(13, 0, 6, 23);
                    this.Shift4(15, 1, 4, 22);
                    this.Shift4(16, 17, 19, 18);
                    break;
                case 4:
                    this.Shift4(9, 13, 17, 5);
                    this.Shift4(8, 12, 16, 4);
                    this.Shift4(3, 1, 0, 2);
                    break;
                case 5:
                    this.Shift4(11, 15, 19, 7);
                    this.Shift4(10, 14, 18, 6);
                    this.Shift4(21, 23, 22, 20);
                    break;
                case 6:
                    this.Shift4(21, 18, 1, 9);
                    this.Shift4(23, 16, 3, 11);
                    this.Shift4(14, 15, 13, 12);
                    break;
                case 7:
                    this.Shift4(20, 19, 0, 8);
                    this.Shift4(22, 17, 2, 10);
                    this.Shift4(7, 6, 4, 5);
                    break;
                case 8:
                    this.Shift4(23, 6, 0, 13);
                    this.Shift4(22, 4, 1, 15);
                    this.Shift4(18, 19, 17, 16);
                    break;
                case 9:
                    this.Shift4(21, 7, 2, 12);
                    this.Shift4(20, 5, 3, 14);
                    this.Shift4(11, 10, 8, 9);
                    break;
                case 10:
                    this.Shift4(7, 19, 15, 11);
                    this.Shift4(6, 18, 14, 10);
                    this.Shift4(20, 22, 23, 21);
                    break;
                case 11:
                    this.Shift4(5, 17, 13, 9);
                    this.Shift4(4, 16, 12, 8);
                    this.Shift4(2, 0, 1, 3);
                    break;
            }
        }

        /// <summary>
        /// 盤面を、文字列で返す。
        /// </summary>
        /// <returns>局面</returns>
        public string GetBoardText()
        {
            return this.DevelopmentTiles.GetBoardText();
        }
    }
}
