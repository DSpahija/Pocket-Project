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
    public partial class LoginPage : Form
    {
        public static string username;

        Multilanguage multilanguage = new Multilanguage();
        Select select = new Select();


        public LoginPage()
        {
            InitializeComponent();
            RemoveTitleBar();
        }

        private void Button_Login_Click(object sender, EventArgs e)
        {
            UserVerification();
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void label_SignUp_Click(object sender, EventArgs e)
        {
            SignUpPage signup = new SignUpPage();
            signup.FormClosed += Signup_FormClosed;
            signup.Show();
            this.Hide();
        }

        private void Signup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void RemoveTitleBar()
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Minimized_Click(object sender, EventArgs e)
        { 
            WindowState = FormWindowState.Minimized;
        }
        
        private void Label_Language_Click(object sender, EventArgs e)
        {
            ChangeLanguage();
        }

        public void ChangeLanguage()
        {
            multilanguage.ChangeLanguage(true, Label_Language.Text);
            Label_Username.Text = multilanguage.username;
            Label_Password.Text = multilanguage.password;
            Button_Login.Text = multilanguage.login;
            Label_Help.Text = multilanguage.help;
            Label_SignUp.Text = multilanguage.longsignup;
            Label_Language.Text = multilanguage.language;
        }

        private void Button_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserVerification();
            }
        }

        public void UserVerification()
        {
            if (select.UserLogin(Textbox_Username.Text, Textbox_Password.Text) == true)
            {
                username = Textbox_Username.Text;

                HomePage homepage = new HomePage();
                homepage.FormClosed += Homepage_FormClosed; ;
                homepage.Show();
                this.Hide();
            }
        }
    }
}