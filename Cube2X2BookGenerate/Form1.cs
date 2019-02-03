namespace Grayscale.Cube2X2BookGenerate
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// 2x2のキューブ。
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 1つ前の盤面。
        /// </summary>
        private string previousBoardText;

        /// <summary>
        /// 0: 定跡生成フェーズ。
        /// 1: 検査フェーズ。
        /// </summary>
        private int phase;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.SetNewGame();

            // 定跡読込。
            Book.Read();

            this.timer1.Start();
        }

        /// <summary>
        /// ゲーム開始状態に戻します。
        /// </summary>
        public void SetNewGame()
        {
            Record.SetNewGame();
            this.developmentUserControl1.SetNewGame();
            this.previousBoardText = this.developmentUserControl1.BoardText;
        }

        /// <summary>
        /// 定跡生成フェーズ。
        /// </summary>
        private void GenerateBookRow()
        {
            // 0～11。
            int handle = MovePicker.MakeMove();

            // キューブをひねる。
            this.developmentUserControl1.RotateOnly(handle);

            // 正規化した局面を作成。
            // var normalizedPosition = NormalizedPosition.Build(this.developmentUserControl1.DevelopmentTiles);

            // 展開図を正規化する。
            // normalizedPosition.Normalize(this.developmentUserControl1.DevelopmentTiles);

            // 定跡作成。
            // 現盤面 前盤面 指し手 初期局面からの手数
            var currentBoardText = this.developmentUserControl1.BoardText;
            var bookRecord = new BookRow(this.previousBoardText, handle, Record.Ply);

            bool newRecord = false;
            if (Book.ContainsKey(currentBoardText))
            {
                var exists = Book.GetValue(currentBoardText);
                if (bookRecord.Ply < exists.Ply)
                {
                    // 短い手数が発見された。

                    // 上書き。
                    Book.SetValue(currentBoardText, bookRecord);
                    newRecord = true;

                    // 他の手も 芋づる式に更新できるかもしれない。
                    Book.UpdateBookRecord(currentBoardText, bookRecord.Ply);
                }
            }
            else
            {
                Book.AddValue(currentBoardText, bookRecord);
                newRecord = true;
            }

            if (newRecord)
            {
                // 新しいレコードを出力。
                Trace.WriteLine(string.Format(
                    CultureInfo.CurrentCulture,
                    "Write: ./book.txt {0} {1} size({2})",
                    currentBoardText,
                    bookRecord.ToText(),
                    Book.Count));

                // TODO ファイル アクセスの回数を減らしたい☆（＾～＾）
                Book.Save(Book.ToText());
            }

            Record.AddMove(handle);
            this.previousBoardText = currentBoardText;

            // どんな局面からでも 14手 で戻せるらしい。
            // しかし それでは探索が広がらないので、99手まで続けることにする。
            if (Record.Ply > 99)
            {
                this.SetNewGame();
                this.phase = 1;
            }
        }

        /// <summary>
        /// 検査フェーズ。
        /// </summary>
        private void Inspector()
        {
            // 定跡を適当に選ぶ。
            (var curPos, var bookRow) = Book.RandomRow;

            // ハンドルと、局面の前後　が有っているか確認する。
            var position = Position.Parse(curPos);
            position.RotateOnly(MoveHelper.GetReversedHandle(bookRow.Handle));
            if (bookRow.PreviousBoardText != position.BoardText)
            {
                // エラー。
                Trace.WriteLine("検査: 行削除。ハンドルと、局面の前後が不一致。");

                // データを消す。
                Book.Remove(curPos);
            }

            this.phase = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var rand = new Random();

            if (this.phase == 0)
            {
                // 生成フェーズ。
                this.GenerateBookRow();
            }
            else
            {
                // 検査フェーズ。
                this.Inspector();
            }
        }
    }
}
