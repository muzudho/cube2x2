namespace Grayscale.Cube2X2BookGenerate
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    /// <summary>
    /// 定跡。
    /// </summary>
    public static class Book
    {
        /// <summary>
        /// 定跡。
        /// </summary>
        private static Dictionary<string, BookRow> rows;

        static Book()
        {
            rows = new Dictionary<string, BookRow>();
        }

        /// <summary>
        /// Gets ファイルパス。
        /// </summary>
        public static string FilePath
        {
            get
            {
                return "./book.txt";
            }
        }

        /// <summary>
        /// Gets バックアップ用ファイルパス。
        /// </summary>
        public static string DupulicatedFilePath
        {
            get
            {
                return "./book(dupulicated).txt";
            }
        }

        /// <summary>
        /// Gets 行数。
        /// </summary>
        public static int Count
        {
            get
            {
                return rows.Count;
            }
        }

        /// <summary>
        /// Gets 行。ランダム。
        /// </summary>
        public static (string, BookRow) RandomRow
        {
            get
            {
                var rand = new Random();
                var max = rand.Next(Book.Count);

                var cur = 0;
                foreach (var record in rows)
                {
                    if (cur == max)
                    {
                        return (record.Key, record.Value);
                    }

                    cur++;
                }

                // エラー。
                return (string.Empty, null);
            }
        }

        /// <summary>
        /// 定跡読込。
        /// </summary>
        public static void Read()
        {
            Book.Clear();
            if (File.Exists("./book.txt"))
            {
                foreach (var line in File.ReadAllLines("./book.txt"))
                {
                    var tokens = line.Split(' ');

                    // 次の一手。
                    var move = int.Parse(tokens[2], CultureInfo.CurrentCulture);

                    // 手数。
                    var ply = int.Parse(tokens[3], CultureInfo.CurrentCulture);

                    // 既に追加されているやつがあれば、手数を比較する。
                    if (Book.ContainsKey(tokens[0]))
                    {
                        if (ply < Book.GetValue(tokens[0]).Ply)
                        {
                            // 短くなっていれば更新する。
                            Book.SetValue(tokens[0], new BookRow(tokens[1], move, ply));
                        }
                    }
                    else
                    {
                        Book.AddValue(tokens[0], new BookRow(tokens[1], move, ply));
                    }
                }
            }
        }

        /// <summary>
        /// クリアー。
        /// </summary>
        public static void Clear()
        {
            rows.Clear();
        }

        /// <summary>
        /// キーの有無確認。
        /// </summary>
        /// <param name="key">キー。</param>
        /// <returns>有る。</returns>
        public static bool ContainsKey(string key)
        {
            return rows.ContainsKey(key);
        }

        /// <summary>
        /// 値取得。
        /// </summary>
        /// <param name="key">キー。</param>
        /// <returns>値。</returns>
        public static BookRow GetValue(string key)
        {
            return rows[key];
        }

        /// <summary>
        /// 値セット。
        /// </summary>
        /// <param name="key">キー。</param>
        /// <param name="value">値。</param>
        public static void SetValue(string key, BookRow value)
        {
            rows[key] = value;
        }

        /// <summary>
        /// 値追加。
        /// </summary>
        /// <param name="key">キー。</param>
        /// <param name="value">値。</param>
        public static void AddValue(string key, BookRow value)
        {
            rows.Add(key, value);
        }

        /// <summary>
        /// ファイルに保存。
        /// </summary>
        /// <param name="contents">ファイルの内容。</param>
        public static void Save(string contents)
        {
            // 保存中の破損を考慮して、ファイル２つに保存する。
            File.WriteAllText(FilePath, contents);
            File.WriteAllText(DupulicatedFilePath, contents);
        }

        /// <summary>
        /// 定跡全文。
        /// </summary>
        /// <returns>定跡。</returns>
        public static string ToText()
        {
            var builder = new StringBuilder();
            foreach (var record in rows)
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
        /// <param name="shortestPly">最短手数。</param>
        public static void UpdateBookRecord(string boardText, int shortestPly)
        {
            foreach (var record in rows)
            {
                if (record.Value.PreviousBoardText == boardText)
                {
                    // 念のため調べておくが、必ず短くなるはず。
                    if (shortestPly < record.Value.Ply - 1)
                    {
                        record.Value.Ply = shortestPly + 1;

                        // 処理が重くなるが、再帰的に全部調べる。
                        UpdateBookRecord(record.Key, record.Value.Ply);
                    }
                }
            }
        }

        /// <summary>
        /// 行を削除。
        /// </summary>
        /// <param name="key">キー。</param>
        /// <returns>成功。</returns>
        public static bool Remove(string key)
        {
            return rows.Remove(key);
        }
    }
}
