namespace Grayscale.Cube2x2BookGenerate
{
    using System.Drawing;

    /// <summary>
    /// 色に関するユーティリティー。
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// 色をアルファベットに変換します。
        /// </summary>
        /// <param name="color">色。</param>
        /// <returns>アルファベット。</returns>
        public static string GetShort(Color color)
        {
            if (color == Color.Pink)
            {
                return "r";
            }
            else if (color == Color.Lime)
            {
                return "g";
            }
            else if (color == Color.SkyBlue)
            {
                return "b";
            }
            else if (color == Color.Orange)
            {
                return "y";
            }
            else if (color == Color.Violet)
            {
                return "v";
            }
            else if (color == Color.LightGray)
            {
                return "g";
            }

            return "?";
        }
    }
}
