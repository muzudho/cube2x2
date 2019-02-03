namespace Grayscale.Cube2X2BookGenerate
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>
    /// 指し手生成。
    /// </summary>
    public static class MovePicker
    {
        /// <summary>
        /// 指し手の作成。
        /// </summary>
        /// <returns>ハンドル。0～11。</returns>
        public static int MakeMove()
        {
            var rand = new Random();

            // 0～11。
            int handle;

            while (true)
            {
                handle = rand.Next(12);

                // 3手続けて同じ個所を回すのは、逆回りに1回回すのと同じなので、そのような手は除外する。
                if (Record.Ply > 2 && handle == Record.GetMove(Record.Ply - 1) && handle == Record.GetMove(Record.Ply - 2))
                {
                    Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Info: 3連続同じ手は除外。"));

                    // リトライ。
                    continue;
                }

                // １つ前の手を、すぐ元に戻してしまう手は除外する。
                if (Record.Ply > 0 && handle == MoveHelper.GetReversedHandle(Record.GetMove(Record.Ply - 1)))
                {
                    Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Info: 戻す手は除外。"));

                    // リトライ。
                    continue;
                }

                // 正常終了。
                break;
            }

            return handle;
        }
    }
}
