namespace Grayscale.Cube2X2BookGenerate
{
    /// <summary>
    /// 棋譜。
    /// </summary>
    public static class Record
    {
        /// <summary>
        /// 棋譜。
        /// </summary>
        private static readonly int[] Moves;

        static Record()
        {
            Moves = new int[100];
        }

        /// <summary>
        /// Gets 初期局面から何手目か。
        /// </summary>
        public static int Ply { get; private set; }

        /// <summary>
        /// ゲーム開始状態に戻します。
        /// </summary>
        public static void SetNewGame()
        {
            Ply = 0;
        }

        /// <summary>
        /// 指し手を取得。
        /// </summary>
        /// <param name="ply">手数。</param>
        /// <returns>ハンドル。</returns>
        public static int GetMove(int ply)
        {
            return Moves[ply];
        }

        /// <summary>
        /// 指し手をセット。
        /// </summary>
        /// <param name="handle">ハンドル。</param>
        public static void AddMove(int handle)
        {
            Moves[Record.Ply] = handle;
            Record.Ply++;
        }
    }
}
