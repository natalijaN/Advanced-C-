namespace WorldCup
{
    partial class WorldCupForm
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
            this.cbxTeams = new System.Windows.Forms.ComboBox();
            this.lblSelectedTeam = new System.Windows.Forms.Label();
            this.pboxBadge = new System.Windows.Forms.PictureBox();
            this.pboxTeam = new System.Windows.Forms.PictureBox();
            this.picturePanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBadge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxTeams
            // 
            this.cbxTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTeams.FormattingEnabled = true;
            this.cbxTeams.Location = new System.Drawing.Point(24, 23);
            this.cbxTeams.Margin = new System.Windows.Forms.Padding(6);
            this.cbxTeams.Name = "cbxTeams";
            this.cbxTeams.Size = new System.Drawing.Size(238, 33);
            this.cbxTeams.TabIndex = 0;
            this.cbxTeams.SelectedIndexChanged += new System.EventHandler(this.cbxTeams_SelectedIndexChanged);
            // 
            // lblSelectedTeam
            // 
            this.lblSelectedTeam.AutoSize = true;
            this.lblSelectedTeam.Location = new System.Drawing.Point(274, 26);
            this.lblSelectedTeam.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSelectedTeam.Name = "lblSelectedTeam";
            this.lblSelectedTeam.Size = new System.Drawing.Size(0, 25);
            this.lblSelectedTeam.TabIndex = 1;
            // 
            // pboxBadge
            // 
            this.pboxBadge.Location = new System.Drawing.Point(24, 76);
            this.pboxBadge.Name = "pboxBadge";
            this.pboxBadge.Size = new System.Drawing.Size(296, 302);
            this.pboxBadge.TabIndex = 2;
            this.pboxBadge.TabStop = false;
            // 
            // pboxTeam
            // 
            this.pboxTeam.Location = new System.Drawing.Point(326, 76);
            this.pboxTeam.Name = "pboxTeam";
            this.pboxTeam.Size = new System.Drawing.Size(472, 302);
            this.pboxTeam.TabIndex = 3;
            this.pboxTeam.TabStop = false;
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.AutoScroll = true;
            this.picturePanel.Location = new System.Drawing.Point(24, 384);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(931, 165);
            this.picturePanel.TabIndex = 4;
            // 
            // WorldCupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.pboxTeam);
            this.Controls.Add(this.pboxBadge);
            this.Controls.Add(this.lblSelectedTeam);
            this.Controls.Add(this.cbxTeams);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(5, 5);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "WorldCupForm";
            this.Text = "World Cup Images";
            this.Load += new System.EventHandler(this.WorldCupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBadge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTeam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTeams;
        private System.Windows.Forms.Label lblSelectedTeam;
        private System.Windows.Forms.PictureBox pboxBadge;
        private System.Windows.Forms.PictureBox pboxTeam;
        private System.Windows.Forms.FlowLayoutPanel picturePanel;
    }
}

