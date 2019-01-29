namespace Grayscale.Cube2x2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// 2x2のキューブ。
    /// </summary>
    public partial class Cube2x2 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cube2x2"/> class.
        /// </summary>
        public Cube2x2()
        {
            this.InitializeComponent();
            this.timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var rand = new Random();

            // 0～11
            this.developmentUserControl1.RotateOnly(rand.Next(12));
        }
    }
}
