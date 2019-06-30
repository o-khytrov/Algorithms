namespace BTS
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btn_bft = new System.Windows.Forms.Button();
            this.btn_dft = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_dfs_nr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(21, 32);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1196, 578);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btn_bft
            // 
            this.btn_bft.Location = new System.Drawing.Point(21, 3);
            this.btn_bft.Name = "btn_bft";
            this.btn_bft.Size = new System.Drawing.Size(92, 23);
            this.btn_bft.TabIndex = 1;
            this.btn_bft.Text = "Breadth first";
            this.btn_bft.UseVisualStyleBackColor = true;
            this.btn_bft.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_dft
            // 
            this.btn_dft.Location = new System.Drawing.Point(120, 3);
            this.btn_dft.Name = "btn_dft";
            this.btn_dft.Size = new System.Drawing.Size(75, 23);
            this.btn_dft.TabIndex = 2;
            this.btn_dft.Text = "Depth first ";
            this.btn_dft.UseVisualStyleBackColor = true;
            this.btn_dft.Click += new System.EventHandler(this.btn_dft_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(335, 3);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_dfs_nr
            // 
            this.btn_dfs_nr.Location = new System.Drawing.Point(201, 3);
            this.btn_dfs_nr.Name = "btn_dfs_nr";
            this.btn_dfs_nr.Size = new System.Drawing.Size(128, 23);
            this.btn_dfs_nr.TabIndex = 4;
            this.btn_dfs_nr.Text = "Depth First non rec";
            this.btn_dfs_nr.UseVisualStyleBackColor = true;
            this.btn_dfs_nr.Click += new System.EventHandler(this.btn_dfs_nr_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 635);
            this.Controls.Add(this.btn_dfs_nr);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_dft);
            this.Controls.Add(this.btn_bft);
            this.Controls.Add(this.pictureBox);
            this.Name = "Main";
            this.Text = "Main";
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btn_bft;
        private System.Windows.Forms.Button btn_dft;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_dfs_nr;
    }
}