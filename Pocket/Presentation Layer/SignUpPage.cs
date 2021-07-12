using Pocket.BOL.Methods;
using Pocket.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pocket.Presentation_Layer
{
    public partial class SignUpPage : Form
    {
        Multilanguage multilanguage = new Multilanguage();

        Insert insert = new Insert();
        Select select = new Select();

        public SignUpPage()
        {
            InitializeComponent();
            RemoveTitleBar();
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void RemoveTitleBar()
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void InsertUser()
        {
            if (select.UserVerificationDuplicate(Textbox_Username.Text) == true)
            {
                MessageBox.Show("This username already exists.");
            }
            else
            {
                ChangeLanguage();
                if (Textbox_Password.Text == Textbox_RepeatPassword.Text)
                {
                    insert.InsertUser(Textbox_Fullname.Text,
                        Textbox_Username.Text,
                        Textbox_Email.Text,
                        Textbox_Password.Text,
                        multilanguage.language);

                    LoginPage.username = Textbox_Fullname.Text;

                    HomePage homepage = new HomePage();
                    homepage.FormClosed += Homepage_FormClosed; ;
                    homepage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Passwords don't match with each other!");
                }
            }
        }

        private void label_Login_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.FormClosed += LoginPage_FormClosed;
            loginPage.Show();
            this.Hide();
        }

        private void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Button_SignUp_Click(object sender, EventArgs e)
        {
            InsertUser();
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        
        private void Label_Language_Click(object sender, EventArgs e)
        {
            ChangeLanguage();
        }

        private void ChangeLanguage()
        {
            multilanguage.ChangeLanguage(true, Label_Language.Text);
            Label_Fullname.Text = multilanguage.fullname;
            Label_Username.Text = multilanguage.username;
            Label_Email.Text = multilanguage.email;
            Label_Password.Text = multilanguage.password;
            Label_RepeatPassword.Text = multilanguage.repeatpassword;
            Button_SignUp.Text = multilanguage.signup;
            label_Login.Text = multilanguage.longsignin;
            Label_Language.Text = multilanguage.language;
            Label_Help.Text = multilanguage.help;
        }
    }
}
