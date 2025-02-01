using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FinalProject.GUI;
using Members.Business;

namespace FinalProject
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        public void LoginSuccess()
        {
            this.Hide();
        }

        private void comboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Are you sure you want to exit the application?", "Confirm",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                Application.Exit();
            }

            
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            User aUser = new User();
            aUser.UserId = Convert.ToInt32(textBoxUserId.Text);
            aUser.Password = maskedTextBoxPassword.Text.Trim();
            string identifier = aUser.SearchEmployeeL(Convert.ToInt32(textBoxUserId.Text), maskedTextBoxPassword.Text);

            switch (identifier)
            {
                case ("Manager"):
                    //MessageBox.Show(identifier);

                    LoginSuccess();
                    using (EmployeeForm form = new EmployeeForm())
                    {
                        //Enable Update/Delete buttons User
                        form.buttonUpdateUser.Enabled = true;
                        form.buttonDeleteUser.Enabled = true;

                        // Setting 'Profile ID' on the form to their ID
                        form.labelProfileEmployeeId.Text = textBoxUserId.Text;

                        // Removing useless tabs for this employee
                        form.tabControl.TabPages.Remove(form.tabSales);
                        form.tabControl.TabPages.Remove(form.tabInventory);
                        form.tabControl.TabPages.Remove(form.tabOrders);

                        form.ShowDialog();
                    }
                    break;
                case ("Sales"):
                    //MessageBox.Show(identifier);
                    LoginSuccess();
                    using (EmployeeForm form = new EmployeeForm())
                    {
                        // Setting 'Profile ID' on the form to their ID
                        form.labelProfileSalesId.Text = textBoxUserId.Text;

                        // Removing tabs useless to this employee
                        form.tabControl.TabPages.Remove(form.tabManager);
                        form.tabControl.TabPages.Remove(form.tabInventory);
                        form.tabControl.TabPages.Remove(form.tabOrders);

                        // Disabling buttons to update/delete client
                        form.buttonDeleteClient.Enabled = false;  
                        form.buttonUpdateClient.Enabled = false;
                        // Disabling buttons on User tab.
                        form.buttonDeleteUser.Enabled = false;
                        form.buttonUpdateUser.Enabled = false;
                        form.buttonSearchUser.Enabled = false;
                        form.buttonListAllUser.Enabled =false;
                        form.buttonSaveUser.Enabled = false;
                        form.textBoxUserId.Enabled = false;
                        form.textBoxPasswordUser.Enabled = false;
                        form.comboBoxIdentifierUser.Enabled = false;
                        form.textBoxInputUser.Enabled = false;

                        form.comboBoxIdentifierUser.Items.Add("MIS Manager");
                        form.comboBoxIdentifierUser.Items.Add("Sales Manager");
                        form.comboBoxIdentifierUser.Items.Add("Inventory Controller");
                        form.comboBoxIdentifierUser.Items.Add("Order Clerks");

                        User u = new User();
                        List<User> ListU = u.FindEmployeeUser(Convert.ToInt32(textBoxUserId.Text));

                        foreach (User empTemp in ListU)
                        {
                            form.textBoxUserId.Text = Convert.ToString(empTemp.Employeeid);
                            form.comboBoxIdentifierUser.SelectedItem = empTemp.IndexCBIdentify(empTemp.Employeeid);
                            form.textBoxPasswordUser.Text = empTemp.Password;

                        }

                        form.ShowDialog();
                    }
                    break;
                case ("Inventory"):
                    LoginSuccess();
                    using (EmployeeForm form = new EmployeeForm())
                    {
                        // Setting 'Profile ID' on the form to their ID
                        form.labelProfileInventoryId.Text = textBoxUserId.Text;

                        // Removing tabs useless to this employee
                        form.tabControl.TabPages.Remove(form.tabSales);
                        form.tabControl.TabPages.Remove(form.tabManager);
                        form.tabControl.TabPages.Remove(form.tabOrders);

                        // Disabling buttons on User tab.
                        form.buttonDeleteUser.Enabled = false;
                        form.buttonUpdateUser.Enabled = false;
                        form.buttonSearchUser.Enabled = false;
                        form.buttonListAllUser.Enabled = false;
                        form.buttonSaveUser.Enabled = false;
                        form.textBoxUserId.Enabled = false;
                        form.textBoxPasswordUser.Enabled = false;
                        form.comboBoxIdentifierUser.Enabled = false;
                        form.textBoxInputUser.Enabled = false;

                        form.comboBoxIdentifierUser.Items.Add("MIS Manager");
                        form.comboBoxIdentifierUser.Items.Add("Sales Manager");
                        form.comboBoxIdentifierUser.Items.Add("Inventory Controller");
                        form.comboBoxIdentifierUser.Items.Add("Order Clerks");

                        User u = new User();
                        List<User> ListU = u.FindEmployeeUser(Convert.ToInt32(textBoxUserId.Text));

                        foreach (User empTemp in ListU)
                        {
                            form.textBoxUserId.Text = Convert.ToString(empTemp.Employeeid);
                            form.comboBoxIdentifierUser.SelectedIndex = empTemp.IndexCBIdentify(empTemp.Employeeid);
                            form.textBoxPasswordUser.Text = empTemp.Password;

                        }
                        form.ShowDialog();
                    }
                    break;
                case ("Orders"):
                    //MessageBox.Show(identifier);
                    LoginSuccess();
                    using (EmployeeForm form = new EmployeeForm())
                    {
                        // Setting 'Profile ID' on the form to their ID
                        form.labelOrdersId.Text = textBoxUserId.Text;

                        // Removing tabs useless to this employee
                        form.tabControl.TabPages.Remove(form.tabSales);
                        form.tabControl.TabPages.Remove(form.tabInventory);
                        form.tabControl.TabPages.Remove(form.tabManager);

                        // Disabling buttons on User tab.
                        form.buttonDeleteUser.Enabled = false;
                        form.buttonUpdateUser.Enabled = false;
                        form.buttonSearchUser.Enabled = false;
                        form.buttonListAllUser.Enabled = false;
                        form.buttonSaveUser.Enabled = false;
                        form.textBoxUserId.Enabled = false;
                        form.textBoxPasswordUser.Enabled = false;
                        form.comboBoxIdentifierUser.Enabled = false;
                        form.textBoxInputUser.Enabled = false;

                        form.comboBoxIdentifierUser.Items.Add("MIS Manager");
                        form.comboBoxIdentifierUser.Items.Add("Sales Manager");
                        form.comboBoxIdentifierUser.Items.Add("Inventory Controller");
                        form.comboBoxIdentifierUser.Items.Add("Order Clerks");

                        User u = new User();
                        List<User> ListU = u.FindEmployeeUser(Convert.ToInt32(textBoxUserId.Text));

                        foreach (User empTemp in ListU)
                        {
                            form.textBoxUserId.Text = Convert.ToString(empTemp.Employeeid);
                            form.comboBoxIdentifierUser.SelectedIndex = empTemp.IndexCBIdentify(empTemp.Employeeid);
                            form.textBoxPasswordUser.Text = empTemp.Password;

                        }

                        form.ShowDialog();
                    }
                    break;
                default:
                    //MessageBox.Show(identifier);
                    MessageBox.Show("User ID or password incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxUserId.Clear();
                    maskedTextBoxPassword.Clear();
                    textBoxUserId.Focus();
                    break;
            }



        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            textBoxUserId.Focus();
        }
    }
}
