namespace Grayscale.Cube2X2BookGenerate
{
    using System.IO;

    /// <summary>
    /// 定跡。
    /// </summary>
    public static class Book
    {
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
        /// ファイルに保存。
        /// </summary>
        /// <param name="contents">ファイルの内容。</param>
        public static void Save(string contents)
        {
            // 保存中の破損を考慮して、ファイル２つに保存する。
            File.WriteAllText(FilePath, contents);
            File.WriteAllText(DupulicatedFilePath, contents);
        }
    }
}
