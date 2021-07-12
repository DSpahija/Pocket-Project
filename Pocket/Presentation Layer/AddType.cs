using Pocket.BOL.Methods;
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
    public partial class AddType : Form
    {
        Insert insert = new Insert();
        Select select = new Select();

        public AddType()
        {
            InitializeComponent();
            RemoveTitleBar();
            GetTypes();
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

        private void Button_AddType_Click(object sender, EventArgs e)
        {
            InsertType();
            this.Close();
        }
        
        private void InsertType()
        {
            insert.InsertType(LoginPage.username, Dropdown_Types.selectedValue, TextBox_Name.Text);
        }

        private void GetTypes()
        {
            foreach (var item in select.GetCategories())
            {
                Dropdown_Types.AddItem(item.TypeCategory);
            }
        }
    }
}
