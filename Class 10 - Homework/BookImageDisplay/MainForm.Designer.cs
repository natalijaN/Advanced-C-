namespace BookImageDisplay
{
    partial class MainForm
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
            this.LbxAuthors = new System.Windows.Forms.ListBox();
            this.LbxBooks = new System.Windows.Forms.ListBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.lnkNovelPage = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LbxAuthors
            // 
            this.LbxAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbxAuthors.FormattingEnabled = true;
            this.LbxAuthors.ItemHeight = 23;
            this.LbxAuthors.Location = new System.Drawing.Point(12, 12);
            this.LbxAuthors.Name = "LbxAuthors";
            this.LbxAuthors.Size = new System.Drawing.Size(344, 395);
            this.LbxAuthors.TabIndex = 0;
            this.LbxAuthors.SelectedIndexChanged += new System.EventHandler(this.LbxAuthors_SelectedIndexChanged);
            // 
            // LbxBooks
            // 
            this.LbxBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbxBooks.FormattingEnabled = true;
            this.LbxBooks.ItemHeight = 23;
            this.LbxBooks.Location = new System.Drawing.Point(373, 12);
            this.LbxBooks.Name = "LbxBooks";
            this.LbxBooks.Size = new System.Drawing.Size(299, 395);
            this.LbxBooks.TabIndex = 1;
            this.LbxBooks.SelectedIndexChanged += new System.EventHandler(this.LbxBooks_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(756, 371);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 36);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Image as...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lnkNovelPage
            // 
            this.lnkNovelPage.AutoSize = true;
            this.lnkNovelPage.Location = new System.Drawing.Point(714, 345);
            this.lnkNovelPage.Name = "lnkNovelPage";
            this.lnkNovelPage.Size = new System.Drawing.Size(236, 23);
            this.lnkNovelPage.TabIndex = 3;
            this.lnkNovelPage.TabStop = true;
            this.lnkNovelPage.Text = "Click to open the novel\'s page";
            this.lnkNovelPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNovelPage_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 482);
            this.Controls.Add(this.lnkNovelPage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.LbxBooks);
            this.Controls.Add(this.LbxAuthors);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "Book Image Display";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LbxAuthors;
        private System.Windows.Forms.ListBox LbxBooks;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel lnkNovelPage;
    }
}

