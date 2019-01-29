namespace Grayscale.Cube2x2BookGenerate
{
    /// <summary>
    /// 2x2のキューブ。
    /// </summary>
    partial class Cube2x2
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.developmentUserControl1 = new Grayscale.Cube2x2BookGenerate.DevelopmentUserControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // developmentUserControl1
            // 
            this.developmentUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.developmentUserControl1.Location = new System.Drawing.Point(0, 0);
            this.developmentUserControl1.Name = "developmentUserControl1";
            this.developmentUserControl1.Size = new System.Drawing.Size(800, 450);
            this.developmentUserControl1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Cube2x2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.developmentUserControl1);
            this.Name = "Cube2x2";
            this.Text = "2x2キューブ";
            this.ResumeLayout(false);

        }

        #endregion

        private DevelopmentUserControl developmentUserControl1;
        private System.Windows.Forms.Timer timer1;
    }
}

