namespace Grayscale.Cube2X2BookGenerate
{
    /// <summary>
    /// 指し手のユーティリティー。
    /// </summary>
    public static class MoveHelper
    {
        private static readonly int[] Reverses = new int[]
        {
            7, 6, 9, 8, 11, 10, 1, 0, 3, 2, 5, 4,
        };

        /// <summary>
        /// 反対方向のハンドルを取得。
        /// </summary>
        /// <param name="handle">ハンドル。</param>
        /// <returns>反対方向のハンドル。</returns>
        public static int GetReversedHandle(int handle)
        {
            return Reverses[handle];
        }
    }
}
