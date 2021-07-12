using Bunifu.Framework.UI;
using Pocket.BLL.Models;
using Pocket.BOL.Methods;
using Pocket.DAL.Database;
using Pocket.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pocket.Presentation_Layer
{
    public partial class HomePage : Form
    {
        DateTime dateTime = DateTime.Now;
        public static ResourceManager rm;

        Insert insert = new Insert();
        Select select = new Select();

        string incomeLng, loansLng, budgetLng, language;

        public HomePage()
        {
            InitializeComponent();
            RemoveTitleBar();
            flatButton_Home.Normalcolor = Color.DarkGoldenrod;
            ChangeLanguage();
            AddItemsTypes();
            FillExpensesChart();
            TodaysDate();
        }
        
        private void GetExpensesChartDates()
        {   
           Label_ChosenDate.Text = select.GetMonthExpenses(LoginPage.username, ChooseMonth.fromDate, ChooseMonth.toDate) + " €";
           Chart_Expenses.DataSource = select.GetExpensesByDate(LoginPage.username, ChooseMonth.fromDate, ChooseMonth.toDate);
           Chart_Expenses.DataBind();
            foreach (DataPoint p in Chart_Expenses.Series["Expenses"].Points)
            {
                p.Label = select.GetExpensesName(Int32.Parse(p.XValue.ToString())) + "\n#PERCENT";
            }
        }

        private void FillExpensesChart()
        {
            Chart_Expenses.DataSource = select.GetExpenses(LoginPage.username);
            Chart_Expenses.DataBind();
            foreach (DataPoint p in Chart_Expenses.Series["Expenses"].Points)
            {
                p.Label = select.GetExpensesName(Int32.Parse(p.XValue.ToString())) + "\n#PERCENT";
            }

        }

        private void Label_Incomes_Click(object sender, EventArgs e)
        {
            using (AddIncome addIncome = new AddIncome())
            {
                addIncome.ShowDialog();
                Label_TotalIncome.Text = incomeLng + addIncome.GetMyResult();
            }
        }

        private void Label_ChooseMonth_Click(object sender, EventArgs e)
        {
            using (ChooseMonth choosemonth = new ChooseMonth())
            {
                choosemonth.ShowDialog();
                GetExpensesChartDates();
                Label_ChosenDate.Text = choosemonth.GetMyResult() + "\n" + Label_ChosenDate.Text;
            }
        }

        private void Label_UpdateLoans_Click(object sender, EventArgs e)
        {
            using (UpdateLoans updateLoans = new UpdateLoans())
            {
                updateLoans.ShowDialog();
                Label_TotalLoans.Text = loansLng + updateLoans.GetMyResult();
            }
        }

        string date;
        private void SaveExpenseHomeCare()
        {
            date = Datepicker_Date1.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Home care" , Dropdrown_Types1.selectedValue, date, 
                Dropdown_Payment1.selectedValue, Convert.ToDouble(Textbox_Cost1.Text), Textbox_Notes1.Text);
            FillExpensesChart();
        }

        private void SaveExpenseUtilities()
        {
            date = Datepicker_Date2.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Utilities", Dropdown_Types2.selectedValue, date,
                Dropdown_Payment2.selectedValue, Convert.ToDouble(Textbox_Cost2.Text), Textbox_Notes2.Text);
            FillExpensesChart();
        }

        private void SaveExpenseWardrobe()
        {
            date = Datepicker_Date3.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Wardrobe", Dropdown_Types3.selectedValue, date,
                Dropdown_Payment3.selectedValue, Convert.ToDouble(Textbox_Cost3.Text), Textbox_Notes3.Text);
            FillExpensesChart();
        }

        private void SaveExpenseHolidays()
        {
            date = Datepicker_Date4.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Holidays", Dropdown_Types4.selectedValue, date,
                Dropdown_Payment4.selectedValue, Convert.ToDouble(Textbox_Cost4.Text), Textbox_Notes4.Text);
            FillExpensesChart();
        }

        private void SaveExpenseMedical()
        {
            date = Datepicker_Date5.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Medical", Dropdown_Types5.selectedValue, date,
                Dropdown_Payment5.selectedValue, Convert.ToDouble(Textbox_Cost5.Text), Textbox_Notes5.Text);
            FillExpensesChart();
        }

        private void SaveExpenseLoans()
        {
            date = Datepicker_Date6.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Loans", Dropdown_Types6.selectedValue, date,
                Dropdown_Payment6.selectedValue, Convert.ToDouble(Textbox_Cost6.Text), Textbox_Notes6.Text);
            FillExpensesChart();
        }

        private void SaveExpenseSavings()
        {
            date = Datepicker_Date7.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Savings", Dropdown_Types7.selectedValue, date,
                Dropdown_Payment7.selectedValue, Convert.ToDouble(Textbox_Cost7.Text), Textbox_Notes7.Text);
            FillExpensesChart();
        }

        private void SaveExpenseEmergency()
        {
            date = Datepicker_Date8.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Emergency", Dropdown_Types8.selectedValue, date,
                Dropdown_Payment8.selectedValue, Convert.ToDouble(Textbox_Cost8.Text), Textbox_Notes8.Text);
            FillExpensesChart();
        }

        private void SaveExpenseExtra()
        {
            date = Datepicker_Date9.Value.ToString("MM/dd/yyyy");
            insert.InsertExpense(LoginPage.username, "Extra", Dropdown_TypesExtra.selectedValue, date,
                Dropdown_Payment9.selectedValue, Convert.ToDouble(Textbox_Cost9.Text), Textbox_Notes9.Text);
            FillExpensesChart();
        }

        private void Button_Add1_Click(object sender, EventArgs e)
        {
            //Add Home Care Expenses
            SaveExpenseHomeCare();
            ClearText(this);
            FillExpensesChart();
        }

        private void Button_Add2_Click(object sender, EventArgs e)
        {
            //Add Utilities Expenses
            SaveExpenseUtilities();
            ClearText(this);
            FillExpensesChart();
        }

        private void Button_Add3_Click(object sender, EventArgs e)
        {
            //Add Wardrobe Expenses
            SaveExpenseWardrobe();
            ClearText(this);
            FillExpensesChart();
        }

        private void Button_Add4_Click(object sender, EventArgs e)
        {
            //Add Holidays Expenses
            SaveExpenseHolidays();
            ClearText(this);
            FillExpensesChart();
        }

        private void Button_Add5_Click(object sender, EventArgs e)
        {
            //Add Medical Expenses
            SaveExpenseMedical();
            ClearText(this);
            FillExpensesChart();
        }

        private void Button_Add6_Click(object sender, EventArgs e)
        {
            //Add Loans Expenses
            SaveExpenseLoans();
            ClearText(this);
            FillExpensesChart();
        }

        private void Button_Add7_Click(object sender, EventArgs e)
        {
            //Add Savings Expenses
            SaveExpenseSavings();
            ClearText(this);
            FillExpensesChart();
        }

        private void Button_Add8_Click(object sender, EventArgs e)
        {
            //Add Emergency Expenses
            SaveExpenseEmergency();
            ClearText(this);
            FillExpensesChart();
        }

        private void Button_Add9_Click(object sender, EventArgs e)
        {
            //Add Extra Expenses
            SaveExpenseExtra();
            ClearText(this);
            FillExpensesChart();
        }

        private void AddItemsTypes()
        {
            foreach (var item in select.GetTypesHomecare(LoginPage.username))
            {
                Dropdrown_Types1.AddItem(item.ToString());
            }
            
            foreach (var item in select.GetTypesUtilities(LoginPage.username))
            {
                Dropdown_Types2.AddItem(item.ToString());
            }

            foreach (var item in select.GetTypesWardrobe(LoginPage.username))
            {
                Dropdown_Types3.AddItem(item.ToString());
            }

            foreach (var item in select.GetTypesHolidays(LoginPage.username))
            {
                Dropdown_Types4.AddItem(item.ToString());
            }

            foreach (var item in select.GetTypesMedical(LoginPage.username))
            {
                Dropdown_Types5.AddItem(item.ToString());
            }

            foreach (var item in select.GetTypesLoans(LoginPage.username))
            {
                Dropdown_Types6.AddItem(item.ToString());
            }

            foreach (var item in select.GetTypesSavings(LoginPage.username))
            {
                Dropdown_Types7.AddItem(item.ToString());
            }

            foreach (var item in select.GetTypesEmergency(LoginPage.username))
            {
                Dropdown_Types8.AddItem(item.ToString());
            }

            foreach (var item in select.GetTypesExtra(LoginPage.username))
            {
                Dropdown_TypesExtra.AddItem(item.ToString());
            } 
        }

        private void TodaysDate()
        {
            Label_ChosenDate.Text = "Expenses until now: "+ "\n" + select.GetAllExpenses(LoginPage.username);
            Datepicker_Date1.Value = DateTime.Now;
            Datepicker_Date3.Value = DateTime.Now;
            Datepicker_Date2.Value = DateTime.Now;
            Datepicker_Date4.Value = DateTime.Now;
            Datepicker_Date5.Value = DateTime.Now;
            Datepicker_Date6.Value = DateTime.Now;
            Datepicker_Date7.Value = DateTime.Now;
            Datepicker_Date8.Value = DateTime.Now;
            Datepicker_Date9.Value = DateTime.Now;
        }
        private void imageButton_NavigationBar_Click(object sender, EventArgs e)
        {
            if (Panel_NavigationBar.Width == 50)
            {
                Panel_NavigationBar.Width = 220;
                CheckPanelSize();
                Panel_Animator.ShowSync(Panel_NavigationBar);
                Animator_Logo.ShowSync(pictureBox_LogoText);
                Animator_Logo.ShowSync(label_Pocket);
            }
            else
            {
                Panel_Animator.ShowSync(Panel_NavigationBar);
                Panel_Animator.ShowSync(label_Pocket);
                Animator_Logo.Hide(pictureBox_LogoText);
                Panel_NavigationBar.Width = 50;
                CheckPanelSize();
            }
        }

        private void CheckPanelSize()
        {
            if(Panel_NavigationBar.Width == 50)
            {
                Panel_Home.Size = new Size(860, 501);
                Panel_Home.Location = new Point(70, 66);
                Panel_HomeCare.Location = new Point(160, 66);
                Panel_Utilities.Location = new Point(160, 66);
                Panel_Wardrobe.Location = new Point(160, 66);
                Panel_Holidays.Location = new Point(160, 66);
                Panel_Medical.Location = new Point(160, 66);
                Panel_Loans.Location = new Point(160, 66);
                Panel_Savings.Location = new Point(160, 66);
                Panel_Emergency.Location = new Point(160, 66);
                Panel_Extra.Location = new Point(160, 66);
            }
            else
            {
                Panel_Home.Size = new Size(698, 501);
                Panel_Home.Location = new Point(230, 66);
                Panel_HomeCare.Location = new Point(253, 66);
                Panel_Utilities.Location = new Point(253, 66);
                Panel_Wardrobe.Location = new Point(253, 66);
                Panel_Holidays.Location = new Point(253, 66);
                Panel_Medical.Location = new Point(253, 66);
                Panel_Loans.Location = new Point(253, 66);
                Panel_Savings.Location = new Point(253, 66);
                Panel_Emergency.Location = new Point(253, 66);
                Panel_Extra.Location = new Point(253, 66);
            }
        }

        Multilanguage multilanguage = new Multilanguage();
        private bool clicked = false;

        public void ChangeLanguage()
        {
            multilanguage.ChangeLanguage(clicked, Label_Language.Text);
            flatButton_Home.Text = multilanguage.homebtn;
            flatButton_HomeCare.Text = multilanguage.homecarebtn;
            flatButton_Utilities.Text = multilanguage.utilitiesbtn;
            flatButton_Wardrobe.Text = multilanguage.wardrobebtn;
            flatButton_Holidays.Text = multilanguage.holidaysbtn;
            flatButton_Medical.Text = multilanguage.medicalbtn;
            flatButton_Loans.Text = multilanguage.loansbtn;
            flatButton_Savings.Text = multilanguage.savingsbtn;
            flatButton_Emergency.Text = multilanguage.emergencybtn;
            flatButton_Extra.Text = multilanguage.extrabtn;

            Label_Home.Text = multilanguage.welcome + select.GetFullName(LoginPage.username);
            Label_HomeCare.Text = multilanguage.homecare;
            Label_Utilities.Text = multilanguage.utilities;
            Label_Wardrobe.Text = multilanguage.wardrobe;
            Label_Holidays.Text = multilanguage.holidays;
            Label_Medical.Text = multilanguage.medical;
            Label_Loans.Text = multilanguage.loans;
            Label_Savings.Text = multilanguage.savings;
            Label_Emergency.Text = multilanguage.emergency;
            Label_Extra.Text = multilanguage.extra;
            Label_TotalIncome.Text = multilanguage.totalincome + select.GetIncome(LoginPage.username);
            incomeLng = multilanguage.totalincome;
            loansLng = multilanguage.totalloans;
            budgetLng = multilanguage.budget;
            Label_TotalLoans.Text = multilanguage.totalloans + select.GetLoans(LoginPage.username);
            DateTime dateTimeDayOne = DateTime.Now.AddDays(-30);  
            Label_Budget.Text = multilanguage.budget + select.GetBudgetNoLoans(LoginPage.username, DateTime.Now.ToString("MM/dd/yyyy"), dateTimeDayOne.ToString("MM/dd/yyyy"));
            Label_Reports.Text = multilanguage.reports;
            Label_Logout.Text = multilanguage.logout;
            Label_Help.Text = multilanguage.help;
            Label_Language.Text =  multilanguage.language;

            PanelLanguage(this);
        }

        private void PanelLanguage(Control ctrlContainer)
        {
            string type = "Label_Types", 
                cost = "Label_Cost", 
                date= "Label_Date", 
                notes="Label_Notes",
                paymethod="Label_Payment",
                add = "Button_Add";

            foreach (Control ctrl in ctrlContainer.Controls)
            {
                if (ctrl.GetType() == typeof(Label) || ctrl.GetType() == typeof(BunifuFlatButton))
                {
                    for (int i = 1; i < 10; i++)
                    {
                        if (ctrl.Name.Equals(type + i))
                        {
                            ctrl.Text = multilanguage.typename;
                        }
                        if(ctrl.Name.Equals(cost + i))
                        {
                            ctrl.Text = multilanguage.costexpenses;
                        }
                        if(ctrl.Name.Equals(date + i))
                        {
                            ctrl.Text = multilanguage.transactiondate;
                        }
                        if (ctrl.Name.Equals(notes + i))
                        {
                            ctrl.Text = multilanguage.notes;
                        }
                        if (ctrl.Name.Equals(paymethod + i))
                        {
                            ctrl.Text = multilanguage.paymentmethod;
                        }
                        if (ctrl.Name.Equals(add + i))
                        {
                            ctrl.Text = multilanguage.add;
                        }
                    }
                }

                if (ctrl.HasChildren)
                    PanelLanguage(ctrl);
            }
        }

        private void Label_Language_Click(object sender, EventArgs e)
        {
            clicked = true;
            ChangeLanguage();
        }

        private void Panel_NavigationBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label_LogOut_Click(object sender, EventArgs e)
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
            using (AddType addType = new AddType())
            {
                addType.ShowDialog();
            }
        }

        private void Button_AddHomeCare_Click(object sender, EventArgs e)
        {
            if (Label_Language.Text == "English")
            {
                MessageBox.Show("Shpenzimi u shtua me sukses!");
            }
            else
            {
                MessageBox.Show("Cost was added succesfully!");
            }
        }

        private void flatButton_Home_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = true;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.DarkGoldenrod;
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Savings.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_HomeCare_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = true;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_HomeCare.Normalcolor = Color.DarkGoldenrod;
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Savings.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_Utilities_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = true;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Utilities.Normalcolor = Color.DarkGoldenrod;
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Savings.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_Wardrobe_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = true;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37,46,59);
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.DarkGoldenrod;
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Savings.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_Holidays_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = true;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.DarkGoldenrod;
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_Medical_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = true;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.DarkGoldenrod;
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Savings.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_Loans_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = true;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.DarkGoldenrod;
            flatButton_Savings.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_Savings_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = true;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Savings.Normalcolor = Color.DarkGoldenrod;
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_Emergency_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = true;
            Panel_Extra.Visible = false;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Savings.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.DarkGoldenrod;
            flatButton_Extra.Normalcolor = Color.FromArgb(37, 46, 59);
        }

        private void flatButton_Extra_Click(object sender, EventArgs e)
        {
            //PANELS
            Panel_Home.Visible = false;
            Panel_HomeCare.Visible = false;
            Panel_Utilities.Visible = false;
            Panel_Wardrobe.Visible = false;
            Panel_Holidays.Visible = false;
            Panel_Medical.Visible = false;
            Panel_Loans.Visible = false;
            Panel_Savings.Visible = false;
            Panel_Emergency.Visible = false;
            Panel_Extra.Visible = true;

            //COLORS
            flatButton_Home.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_HomeCare.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Utilities.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Wardrobe.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Holidays.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Medical.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Loans.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Savings.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Emergency.Normalcolor = Color.FromArgb(37, 46, 59);
            flatButton_Extra.Normalcolor = Color.DarkGoldenrod;
        }

        private void ClearText(Control ctrlContainer)
        {
            TodaysDate();
            
            Textbox_Notes1.Text = "";
            Textbox_Notes2.Text = "";
            Textbox_Notes3.Text = "";
            Textbox_Notes4.Text = "";
            Textbox_Notes5.Text = "";
            Textbox_Notes6.Text = "";
            Textbox_Notes7.Text = "";
            Textbox_Notes8.Text = "";
            Textbox_Notes9.Text = "";

            Textbox_Cost1.Text = "";
            Textbox_Cost2.Text = "";
            Textbox_Cost3.Text = "";
            Textbox_Cost4.Text = "";
            Textbox_Cost5.Text = "";
            Textbox_Cost6.Text = "";
            Textbox_Cost7.Text = "";
            Textbox_Cost8.Text = "";
            Textbox_Cost9.Text = "";

        }

        private void Textbox_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void Label_Reports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void Label_Help_Click_1(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Help/Help_PocketApplication.chm");
            Help.ShowHelp(this, path);
        }
        

        private void Panel_Home_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
