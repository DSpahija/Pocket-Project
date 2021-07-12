namespace Pocket.Presentation_Layer
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            this.Textbox_Username = new System.Windows.Forms.TextBox();
            this.Textbox_Password = new System.Windows.Forms.TextBox();
            this.Label_Username = new System.Windows.Forms.Label();
            this.Label_Password = new System.Windows.Forms.Label();
            this.Label_SignUp = new System.Windows.Forms.Label();
            this.Label_Pocket = new System.Windows.Forms.Label();
            this.Picturebox_Logo = new System.Windows.Forms.PictureBox();
            this.panel_TitleBar = new System.Windows.Forms.Panel();
            this.Label_Language = new System.Windows.Forms.Label();
            this.Button_Minimized = new System.Windows.Forms.Button();
            this.Label_Help = new System.Windows.Forms.Label();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Button_Login = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.Picturebox_Logo)).BeginInit();
            this.panel_TitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Textbox_Username
            // 
            this.Textbox_Username.Location = new System.Drawing.Point(81, 260);
            this.Textbox_Username.Name = "Textbox_Username";
            this.Textbox_Username.Size = new System.Drawing.Size(180, 20);
            this.Textbox_Username.TabIndex = 5;
            // 
            // Textbox_Password
            // 
            this.Textbox_Password.Location = new System.Drawing.Point(81, 307);
            this.Textbox_Password.Name = "Textbox_Password";
            this.Textbox_Password.PasswordChar = '*';
            this.Textbox_Password.Size = new System.Drawing.Size(180, 20);
            this.Textbox_Password.TabIndex = 7;
            // 
            // Label_Username
            // 
            this.Label_Username.AutoSize = true;
            this.Label_Username.BackColor = System.Drawing.Color.Transparent;
            this.Label_Username.ForeColor = System.Drawing.Color.White;
            this.Label_Username.Location = new System.Drawing.Point(78, 244);
            this.Label_Username.Name = "Label_Username";
            this.Label_Username.Size = new System.Drawing.Size(55, 13);
            this.Label_Username.TabIndex = 4;
            this.Label_Username.Text = "Username";
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.BackColor = System.Drawing.Color.Transparent;
            this.Label_Password.ForeColor = System.Drawing.Color.White;
            this.Label_Password.Location = new System.Drawing.Point(79, 291);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(53, 13);
            this.Label_Password.TabIndex = 6;
            this.Label_Password.Text = "Password";
            // 
            // Label_SignUp
            // 
            this.Label_SignUp.AutoSize = true;
            this.Label_SignUp.BackColor = System.Drawing.Color.Transparent;
            this.Label_SignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_SignUp.ForeColor = System.Drawing.Color.White;
            this.Label_SignUp.Location = new System.Drawing.Point(89, 384);
            this.Label_SignUp.Name = "Label_SignUp";
            this.Label_SignUp.Size = new System.Drawing.Size(164, 13);
            this.Label_SignUp.TabIndex = 9;
            this.Label_SignUp.Text = "Don\'t have an account? Sign up.";
            this.Label_SignUp.Click += new System.EventHandler(this.label_SignUp_Click);
            // 
            // Label_Pocket
            // 
            this.Label_Pocket.AutoSize = true;
            this.Label_Pocket.Font = new System.Drawing.Font("Lucida Sans", 20F);
            this.Label_Pocket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Label_Pocket.Location = new System.Drawing.Point(121, 196);
            this.Label_Pocket.Name = "Label_Pocket";
            this.Label_Pocket.Size = new System.Drawing.Size(101, 32);
            this.Label_Pocket.TabIndex = 3;
            this.Label_Pocket.Text = "Pocket";
            // 
            // Picturebox_Logo
            // 
            this.Picturebox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("Picturebox_Logo.Image")));
            this.Picturebox_Logo.Location = new System.Drawing.Point(76, 46);
            this.Picturebox_Logo.Name = "Picturebox_Logo";
            this.Picturebox_Logo.Size = new System.Drawing.Size(191, 168);
            this.Picturebox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picturebox_Logo.TabIndex = 0;
            this.Picturebox_Logo.TabStop = false;
            // 
            // panel_TitleBar
            // 
            this.panel_TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel_TitleBar.Controls.Add(this.Label_Language);
            this.panel_TitleBar.Controls.Add(this.Button_Minimized);
            this.panel_TitleBar.Controls.Add(this.Label_Help);
            this.panel_TitleBar.Controls.Add(this.Button_Exit);
            this.panel_TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_TitleBar.Location = new System.Drawing.Point(0, 0);
            this.panel_TitleBar.Name = "panel_TitleBar";
            this.panel_TitleBar.Size = new System.Drawing.Size(344, 32);
            this.panel_TitleBar.TabIndex = 10;
            // 
            // Label_Language
            // 
            this.Label_Language.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Language.AutoSize = true;
            this.Label_Language.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Label_Language.ForeColor = System.Drawing.Color.Gainsboro;
            this.Label_Language.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Language.Location = new System.Drawing.Point(7, 9);
            this.Label_Language.Name = "Label_Language";
            this.Label_Language.Size = new System.Drawing.Size(43, 16);
            this.Label_Language.TabIndex = 0;
            this.Label_Language.Text = "Shqip";
            this.Label_Language.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Label_Language.Click += new System.EventHandler(this.Label_Language_Click);
            // 
            // Button_Minimized
            // 
            this.Button_Minimized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.Button_Minimized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Minimized.FlatAppearance.BorderSize = 0;
            this.Button_Minimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Minimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Minimized.Location = new System.Drawing.Point(277, 0);
            this.Button_Minimized.Name = "Button_Minimized";
            this.Button_Minimized.Size = new System.Drawing.Size(30, 32);
            this.Button_Minimized.TabIndex = 2;
            this.Button_Minimized.Text = "-";
            this.Button_Minimized.UseVisualStyleBackColor = false;
            this.Button_Minimized.Click += new System.EventHandler(this.Button_Minimized_Click);
            // 
            // Label_Help
            // 
            this.Label_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Help.AutoSize = true;
            this.Label_Help.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Label_Help.ForeColor = System.Drawing.Color.Gainsboro;
            this.Label_Help.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Help.Location = new System.Drawing.Point(61, 9);
            this.Label_Help.Name = "Label_Help";
            this.Label_Help.Size = new System.Drawing.Size(37, 16);
            this.Label_Help.TabIndex = 1;
            this.Label_Help.Text = "Help";
            this.Label_Help.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Button_Exit
            // 
            this.Button_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.Button_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Exit.FlatAppearance.BorderSize = 0;
            this.Button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Exit.Location = new System.Drawing.Point(307, 0);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(30, 32);
            this.Button_Exit.TabIndex = 3;
            this.Button_Exit.Text = "x";
            this.Button_Exit.UseVisualStyleBackColor = false;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 395);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(338, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(6, 395);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(6, 421);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 6);
            this.panel3.TabIndex = 1;
            // 
            // Button_Login
            // 
            this.Button_Login.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.Button_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.Button_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_Login.BorderRadius = 7;
            this.Button_Login.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Button_Login.ButtonText = "Login";
            this.Button_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button_Login.DisabledColor = System.Drawing.Color.Gray;
            this.Button_Login.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Login.Iconcolor = System.Drawing.Color.Transparent;
            this.Button_Login.Iconimage = null;
            this.Button_Login.Iconimage_right = null;
            this.Button_Login.Iconimage_right_Selected = null;
            this.Button_Login.Iconimage_Selected = null;
            this.Button_Login.IconMarginLeft = 0;
            this.Button_Login.IconMarginRight = 0;
            this.Button_Login.IconRightVisible = true;
            this.Button_Login.IconRightZoom = 0D;
            this.Button_Login.IconVisible = true;
            this.Button_Login.IconZoom = 90D;
            this.Button_Login.IsTab = false;
            this.Button_Login.Location = new System.Drawing.Point(110, 345);
            this.Button_Login.Margin = new System.Windows.Forms.Padding(5);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.Button_Login.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.Button_Login.OnHoverTextColor = System.Drawing.Color.White;
            this.Button_Login.selected = false;
            this.Button_Login.Size = new System.Drawing.Size(123, 33);
            this.Button_Login.TabIndex = 8;
            this.Button_Login.Text = "Login";
            this.Button_Login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button_Login.Textcolor = System.Drawing.Color.White;
            this.Button_Login.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            this.Button_Login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_Login_KeyDown);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(344, 427);
            this.Controls.Add(this.Button_Login);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_TitleBar);
            this.Controls.Add(this.Label_Pocket);
            this.Controls.Add(this.Label_SignUp);
            this.Controls.Add(this.Label_Password);
            this.Controls.Add(this.Label_Username);
            this.Controls.Add(this.Textbox_Password);
            this.Controls.Add(this.Textbox_Username);
            this.Controls.Add(this.Picturebox_Logo);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Picturebox_Logo)).EndInit();
            this.panel_TitleBar.ResumeLayout(false);
            this.panel_TitleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Textbox_Username;
        private System.Windows.Forms.TextBox Textbox_Password;
        private System.Windows.Forms.Label Label_Username;
        private System.Windows.Forms.Label Label_Password;
        private System.Windows.Forms.Label Label_SignUp;
        private System.Windows.Forms.Label Label_Pocket;
        private System.Windows.Forms.PictureBox Picturebox_Logo;
        private System.Windows.Forms.Panel panel_TitleBar;
        private System.Windows.Forms.Button Button_Minimized;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Label_Language;
        private System.Windows.Forms.Label Label_Help;
        private Bunifu.Framework.UI.BunifuFlatButton Button_Login;
    }
}