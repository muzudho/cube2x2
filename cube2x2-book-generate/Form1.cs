namespace Grayscale.Cube2x2BookGenerate
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
    public partial class Cube2x2 : Form
    {
        /// <summary>
        /// 初期局面から何手目か。
        /// </summary>
        private int ply;

        /// <summary>
        /// 1つ前の盤面。
        /// </summary>
        private string previousBoardText;

        /// <summary>
        /// 定跡。
        /// </summary>
        private Dictionary<string, BookRecord> book;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cube2x2"/> class.
        /// </summary>
        public Cube2x2()
        {
            this.InitializeComponent();
            this.book = new Dictionary<string, BookRecord>();
            this.SetNewGame();

            // 定跡読込。
            this.ReadBook();

            this.timer1.Start();
        }

        /// <summary>
        /// ゲーム開始状態に戻します。
        /// </summary>
        public void SetNewGame()
        {
            this.ply = 0;
            this.developmentUserControl1.SetNewGame();
            this.previousBoardText = this.developmentUserControl1.GetBoardText();
        }

        /// <summary>
        /// 定跡読込。
        /// </summary>
        public void ReadBook()
        {
            this.book.Clear();
            if (File.Exists("./book.txt"))
            {
                foreach (var line in File.ReadAllLines("./book.txt"))
                {
                    var tokens = line.Split(' ');
                    this.book.Add(tokens[0], new BookRecord(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3])));
                }
            }
        }

        /// <summary>
        /// 定跡全文。
        /// </summary>
        /// <returns>定跡。</returns>
        public string ToBookText()
        {
            var builder = new StringBuilder();
            foreach (var record in this.book)
            {
                builder.AppendLine(string.Format(
                    CultureInfo.CurrentCulture,
                    "{0} {1}",
                    record.Key,
                    record.Value.ToText()));
            }

            return builder.ToString();
        }

        /// <summary>
        /// より短い手数が発見された。
        /// </summary>
        /// <param name="boardText">その盤面。</param>
        /// <param name="shortPly">最短手数。</param>
        private void UpdateBookRecord(string boardText, int shortPly)
        {
            foreach (var record in this.book)
            {
                if (record.Value.PreviousBoardText == boardText)
                {
                    // 念のため調べておくが、必ず短くなるはず。
                    if (shortPly < record.Value.Ply - 1)
                    {
                        record.Value.Ply = shortPly + 1;

                        // 処理が重くなるが、再帰的に全部調べる。
                        this.UpdateBookRecord(record.Key, record.Value.Ply);
                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var rand = new Random();

            // 0～11。
            var handle = rand.Next(12);
            this.developmentUserControl1.RotateOnly(handle);

            // 定跡作成。
            // 現盤面 前盤面 指し手 初期局面からの手数
            var currentBoardText = this.developmentUserControl1.GetBoardText();
            var bookRecord = new BookRecord(this.previousBoardText, handle, this.ply);

            bool newRecord = false;
            if (this.book.ContainsKey(currentBoardText))
            {
                var exists = this.book[currentBoardText];
                if (bookRecord.Ply < exists.Ply)
                {
                    // 短い手数が発見された。

                    // 上書き。
                    this.book[currentBoardText] = bookRecord;
                    newRecord = true;

                    // 他の手も 芋づる式に更新できるかもしれない。
                    this.UpdateBookRecord(currentBoardText, bookRecord.Ply);
                }
            }
            else
            {
                this.book.Add(currentBoardText, bookRecord);
                newRecord = true;
            }

            if (newRecord)
            {
                Trace.WriteLine(string.Format(
                    CultureInfo.CurrentCulture,
                    "Write: ./book.txt {0} {1} size({2})",
                    currentBoardText,
                    bookRecord.ToText(),
                    this.book.Count));

                // TODO ばんばん保存。
                File.WriteAllText("./book.txt", this.ToBookText());
            }

            this.ply++;
            this.previousBoardText = currentBoardText;

            // どんな局面からでも 14手 で戻せるらしい。
            // しかし それでは探索が広がらないので、99手まで続けることにする。
            if (this.ply > 99)
            {
                this.SetNewGame();
            }
        }
    }
}
