namespace employee_management_system
{
    partial class Message
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.icon = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2Panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.guna2Panel1.BackgroundImage = global::employee_management_system.Properties.Resources.bg;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.tableLayoutPanel1);
            this.guna2Panel1.Controls.Add(this.tableLayoutPanel2);
            this.guna2Panel1.Controls.Add(this.icon);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(396, 144);
            this.guna2Panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbTitle, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(383, 29);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbTitle.Location = new System.Drawing.Point(145, 4);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(92, 25);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "ERROR";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lbMessage, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 98);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(389, 43);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbMessage.AutoSize = true;
            this.lbMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbMessage.Location = new System.Drawing.Point(102, 7);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(184, 16);
            this.lbMessage.TabIndex = 2;
            this.lbMessage.Text = "Something Went Wrong !!!";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // icon
            // 
            this.icon.BackColor = System.Drawing.Color.Transparent;
            this.icon.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.icon.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.icon.Image = global::employee_management_system.Properties.Resources.success;
            this.icon.ImageOffset = new System.Drawing.Point(0, 0);
            this.icon.ImageRotate = 0F;
            this.icon.Location = new System.Drawing.Point(166, 38);
            this.icon.Name = "icon";
            this.icon.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.icon.Size = new System.Drawing.Size(64, 54);
            this.icon.TabIndex = 0;
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 141);
            this.Controls.Add(this.guna2Panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(412, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(412, 180);
            this.Name = "Message";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.guna2Panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2ImageButton icon;
    }
}