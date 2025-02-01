using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Business;
using POS.Validation;
using Members.Business;
using Members.Validation;
using System.IO;

namespace FinalProject.GUI
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void tabUser_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            // MIS MANAGER 
            //-------------
            listViewEmployee.FullRowSelect = true;
            listViewUser.FullRowSelect = true;

            comboBoxIdentifier.Items.Add("MIS Manager");
            comboBoxIdentifier.Items.Add("Sales Manager");
            comboBoxIdentifier.Items.Add("Inventory Controller");
            comboBoxIdentifier.Items.Add("Order Clerks");

            comboBoxIdentifierUser.Items.Add("MIS Manager");
            comboBoxIdentifierUser.Items.Add("Sales Manager");
            comboBoxIdentifierUser.Items.Add("Inventory Controller");
            comboBoxIdentifierUser.Items.Add("Order Clerks");

            // adding items in combobox (search option)
            comboBoxSearchOption.Items.Add("Employee ID");
            comboBoxSearchOption.Items.Add("First Name");
            comboBoxSearchOption.Items.Add("Last Name");

            //MIS Manager & User Tab
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDeleteUser.Enabled = false;
            buttonUpdateUser.Enabled = false;

            //Other Users ... enabled for MIS manager in loginform.cs
            //buttonUpdateClient.Enabled = false;
            //buttonDeleteClient.Enabled = false;
            //buttonDeleteUser.Enabled = false;
            //buttonUpdateUser.Enabled = false;
            //buttonSearchUser.Enabled = false;
            //buttonListAllUser.Enabled = false;
            //buttonSaveUser.Enabled = false;
            //textBoxUserId.Enabled = false;
            //textBoxPasswordUser.Enabled = false;
            //comboBoxIdentifierUser.Enabled = false;
            //textBoxInputUser.Enabled = false;

            // SALES
            //------
            // Make List Clickable
            listViewClients.FullRowSelect = true;

            // adding items in combobox (search option)
            comboBoxSearchOptionClient.Items.Add("Name");
            comboBoxSearchOptionClient.Items.Add("Street");
            comboBoxSearchOptionClient.Items.Add("City");
            comboBoxSearchOptionClient.Items.Add("Postal Code");
            comboBoxSearchOptionClient.Items.Add("Type");
            // adding items in combobox (type)
            comboBoxTypeClient.Items.Add("University");
            comboBoxTypeClient.Items.Add("College");

            // INVENTORY 
            //-----------
            // Make List Clickable
            listViewInventory.FullRowSelect = true;
            listViewInventory.AllowColumnReorder = true;

            // add items in list
            int index = comboBoxProductType.SelectedIndex;
            switch (index)
            {
                case 0:// software
                    ListViewColumnSoftware();
                    break;
                case 1: // book 
                    ListViewColumnBook();
                        break;
                default:
                    break;
            }

            // adding items in combobox (Product Type)
            comboBoxProductType.Items.Add("Software");
            comboBoxProductType.Items.Add("Book");

            // hide all labels books
            labelISBN.Hide();
            labelSupplier.Hide();
            labelAuthorId.Hide();
            labelLNAuthor.Hide();
            labelFNAuthor.Hide();
            labelYearP.Hide();
            labelQuantity.Hide();
            //hide all textbox books
            textBoxISBN.Hide();
            textBoxSupplier.Hide();
            textBoxAuthorId.Hide();
            textBoxFirstNameAuthor.Hide();
            textBoxLastNameAuthor.Hide();
            textBoxQuantity.Hide();
            textBoxYearPublished.Hide();

            //hide all labels software
            labelVersionSoftware.Hide();
            labelStatus.Hide();
            labelOS.Hide();
            //hide all textbox/combo software
            textBoxSoftwareVersion.Hide();
            comboBoxStatus.Hide();
            comboBoxOS.Hide();
            comboBoxInputSearch.Hide();

            //disable Product Textboxes (until type was chosen -> combobox type handler)
            textBoxProductId.Enabled = false;
            textBoxProductName.Enabled = false;
            textBoxPriceInventory.Enabled = false;
            buttonSearchInventory.Enabled = false;
            buttonSaveInventory.Enabled = false;
            buttonDeleteInventory.Enabled = false;
            buttonUpdateInventory.Enabled = false;

            // hide list view columns
            listViewInventory.Clear();

            // ORDER CLERK
            //------------
            // Make List Clickable
            listViewOrders.FullRowSelect = true;
            listViewOrders.AllowColumnReorder = true;

            // disable text/combo boxes
            textBoxClientPostalC.Enabled = false;
            textBoxClientName.Enabled = false;
            textBoxPriceOrders.Enabled = false;
            textBoxOrderId.Enabled = false;
            maskedTextBoxDateOrders.Enabled = false;
            textBoxProductId.Enabled = false;
            comboBoxStatusOrder.Enabled = false;
            textBoxProductIdOrders.Enabled = false;

            // disable buttons
            buttonVerifyProd.Enabled = false;
            buttonVerifyClientO.Enabled = false;
            buttonSearchOrders.Enabled = false;
            buttonOrder.Enabled = false;

            // fill combobox 
            comboBoxSearchOptionOrder.Items.Add("Order ID");
            comboBoxSearchOptionOrder.Items.Add("Product ID");
            comboBoxSearchOptionOrder.Items.Add("Status");
            comboBoxSearchOptionOrder.Items.Add("Product Type");
            comboBoxSearchOptionOrder.Items.Add("Postal Code");
            comboBoxSearchOptionOrder.Items.Add("Client Name");

            comboBoxTypeOrders.Items.Add("Software");
            comboBoxTypeOrders.Items.Add("Book");

            comboBoxStatusOrder.Items.Add("Processing");
            comboBoxStatusOrder.Items.Add("Cancelled");


            User u = new User();
            List<User> ListU = u.FindEmployeeUser(Convert.ToInt32(labelProfileEmployeeId.Text));

            foreach (User empTemp in ListU)
            {
                textBoxUserId.Text = Convert.ToString(empTemp.Employeeid);
                comboBoxIdentifierUser.SelectedIndex = u.IndexCBIdentify(empTemp.Employeeid);
                textBoxPasswordUser.Text = empTemp.Password;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSearchBy_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

        }

        private void buttonListAll_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmployee_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSearchOption_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxSearchOption.SelectedIndex;
            switch (selectedIndex)
            {
                case 0: // search employee by employee ID
                    labelInfo.Text = "Enter employee ID";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;

                case 1: // search employee by first name
                    labelInfo.Text = "Enter First Name";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;

                case 2: // search employee by last name
                    labelInfo.Text = "Enter Last Name";
                    textBoxInput.Clear();
                    textBoxInput.Focus();
                    break;

                default:
                    MessageBox.Show("You forgot to select an option.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            };
            


        }

        // MIS MANAGER - Search
        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            int searchIndex = comboBoxSearchOption.SelectedIndex;
            
            switch (searchIndex)
            {
                case 0: // search by employee id
                    if (!Validator.IsValidId(Convert.ToString(textBoxInput.Text), 4))
                    {
                        MessageBox.Show("Please re-enter a 4-digit number.", "Invalid");
                        textBoxEmployeeId.Clear();
                        textBoxEmployeeId.Focus();
                        return;
                    }
                    else
                    {
                        User emp = new User();
                        List<User> listEmp = emp.SearchEmployeeById(Convert.ToInt32(textBoxInput.Text));

                        if (listEmp != null)
                        {
                            listViewEmployee.Items.Clear();
                            foreach (User empTemp in listEmp)
                            {
                                ListViewItem item = new ListViewItem(empTemp.Employeeid.ToString());
                                item.SubItems.Add(empTemp.Identifier);
                                item.SubItems.Add(empTemp.FirstName);
                                item.SubItems.Add(empTemp.LastName);
                                item.SubItems.Add(empTemp.PhoneNumber.ToString());
                                item.SubItems.Add(empTemp.Email);
                                listViewEmployee.Items.Add(item); // adds shows all of the above data into the list view

                                textBoxEmployeeId.Text = Convert.ToString(empTemp.Employeeid);
                                comboBoxIdentifier.SelectedIndex = empTemp.ComboIndentifierIndex(empTemp.Employeeid); // needs to return index
                                textBoxFirstName.Text = empTemp.FirstName;
                                textBoxLastName.Text = empTemp.LastName;
                                maskedTextBoxPhoneNumber.Text = empTemp.PhoneNumber;
                                textBoxEmail.Text = empTemp.Email;

                                buttonDelete.Enabled = true;
                                buttonUpdate.Enabled = true;

                            }
                        }
                    }
                    

                    break;

                case 1: // search by firstname

                    if (!Validator.IsValidName(textBoxInput.Text))
                    {
                        MessageBox.Show("Please enter a valid name.", "Nope");
                        textBoxNameClient.Clear();
                        textBoxNameClient.Focus();
                        return;
                    }
                    else
                    {
                        Employee emp1 = new Employee();
                        List<Employee> listEmp1 = emp1.SearchEmployeeByName(textBoxInput.Text.Trim());

                        if (listEmp1 != null)
                        {
                            listViewEmployee.Items.Clear();
                            foreach (Employee empTemp in listEmp1)
                            {
                                ListViewItem item = new ListViewItem(empTemp.Employeeid.ToString());
                                item.SubItems.Add(empTemp.Identifier);
                                item.SubItems.Add(empTemp.FirstName);
                                item.SubItems.Add(empTemp.LastName);
                                item.SubItems.Add(empTemp.PhoneNumber.ToString());
                                item.SubItems.Add(empTemp.Email);
                                listViewEmployee.Items.Add(item);

                                buttonDelete.Enabled = true;
                                buttonUpdate.Enabled = true;
                            }
                        }
                    }
                    
                    break;

                case 2: // search by last name 
                    if (!Validator.IsValidName(textBoxInput.Text))
                    {
                        MessageBox.Show("Please enter a valid name.", "Invalid");
                        textBoxNameClient.Clear();
                        textBoxNameClient.Focus();
                        return;
                    }
                    else
                    {
                        Employee emp2 = new Employee();
                        List<Employee> listEmp2 = emp2.SearchEmployeeByLast(textBoxInput.Text.Trim());

                        if (listEmp2 != null)
                        {
                            listViewEmployee.Items.Clear();
                            foreach (Employee empTemp in listEmp2)
                            {
                                ListViewItem item = new ListViewItem(empTemp.Employeeid.ToString());
                                item.SubItems.Add(empTemp.Identifier);
                                item.SubItems.Add(empTemp.FirstName);
                                item.SubItems.Add(empTemp.LastName);
                                item.SubItems.Add(empTemp.PhoneNumber.ToString());
                                item.SubItems.Add(empTemp.Email);
                                listViewEmployee.Items.Add(item);

                                buttonDelete.Enabled = true;
                                buttonUpdate.Enabled = true;
                            }
                        }
                    }
                    
                    break;

                default:
                    MessageBox.Show("Oops! Your forgot select an option.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            //comboBoxSearchOption.SelectedIndex = -1;
            //textBoxInput.Clear();
        }

        // MIS MANAGER - Delete Button
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            DialogResult ans = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                emp.EmployeeDelete(Convert.ToInt32(textBoxInput.Text));
                MessageBox.Show("Employee record has been successfully deleted.", "Confirmation");
                listViewEmployee.Items.Clear();
            }
        }

        // MIS MANAGER - Update Button
        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            if (!Validator.IsValidId(Convert.ToString(textBoxEmployeeId.Text), 4))
            {
                MessageBox.Show("Invalid ID! Please re-enter a 4-digit number", "Invalid");
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }

            User emp = new User();
            emp.Employeeid = Convert.ToInt32(textBoxEmployeeId.Text);
            emp.FirstName = textBoxFirstName.Text;
            emp.LastName = textBoxLastName.Text;
            emp.PhoneNumber = maskedTextBoxPhoneNumber.Text;
            emp.Email = textBoxEmail.Text;

            DialogResult ans = MessageBox.Show("Are you sure you want to update this employee?", "Confirm",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                emp.EmployeeUpdate(emp); // found in userDA
                MessageBox.Show("Employee record has been successfully Updated.", "Confirmation");
            }
        }

        // MIS MANAGER - List All
        private void buttonListAll_Click_1(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listE = emp.GetListEmployee();
            emp.ListAll(listViewEmployee, listE);
        }

        // MIS MANAGER - Save Employee
        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            // Employee Already Exists ?
            if (Validator.AlreadyExists(textBoxEmployeeId.Text))
            {
                MessageBox.Show("Employee ID already exits.", "Already Exits");
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }

            // ID Validation
            if (!Validator.IsValidId(Convert.ToString(textBoxEmployeeId.Text), 4))
            {
                MessageBox.Show("Invalid ID! Please re-enter a 4-digit number", "Invalid");
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }

            // Phone Number Validation
            if (!Validator.IsValidNumber(Convert.ToString(maskedTextBoxPhoneNumber.Text), 10))
            {
                MessageBox.Show("Phone number is invalid!", "Invalid");
                maskedTextBoxPhoneNumber.Clear();
                maskedTextBoxPhoneNumber.Focus();
                return;
            }

            // Email Validation
            if (!Validator.IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("Invalid Email! Please re-enter a valid email(example@hotmail.com)", "Invalid");
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }

            User emp = new User();
            emp.Employeeid = Convert.ToInt32(textBoxEmployeeId.Text);
            emp.Identifier = emp.IdentifyComboBox(comboBoxIdentifier.SelectedItem);// convert it to manager,sales,etc...
            emp.FirstName = textBoxFirstName.Text;
            emp.LastName = textBoxLastName.Text;
            emp.PhoneNumber = maskedTextBoxPhoneNumber.Text;
            emp.Email = textBoxEmail.Text;

            emp.Save(emp);
            ClearAll();
        }

        // EMPLOYEE FORM - Clear all Textbox Text in MIS MANAGER Tab
        private void ClearAll()
        {
            textBoxEmployeeId.Clear();
            comboBoxIdentifier.SelectedIndex = -1;
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            maskedTextBoxPhoneNumber.Clear();
            textBoxEmail.Clear();
            textBoxEmployeeId.Focus();
        }

        // MIS MANAGER - User Tab - Clear Textboxes
        private void ClearAllUser()
        {
            textBoxUserId.Clear();
            comboBoxIdentifier.SelectedIndex = -1;
            textBoxPasswordUser.Clear();
            textBoxUserId.Focus();
        }

        // SALES MANAGER - Clear Textbox Textboxes
        private void ClearAllClient()
        {
            textBoxNameClient.Clear();
            comboBoxTypeClient.SelectedIndex = -1;
            textBoxStreet.Clear();
            textBoxCity.Clear();
            textBoxPostalCodeClient.Clear();
            maskedTextBoxPhoneNumberClient.Clear();
            maskedTextBoxFaxNumberClient.Clear();
            textBoxCreditLimitClient.Clear();
            textBoxNameClient.Focus();
        }

        // EMPLOYEE FORM - Exit Button
        private void buttonExit_Click_1(object sender, EventArgs e)
        {

            DialogResult ans = MessageBox.Show("Are you sure you want to exit the application?", "Confirm",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPasswordUser_TextChanged(object sender, EventArgs e)
        {



        }

        private void listViewEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxIdentifierUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // MIS MANAGER - User Tab - Search User
        private void button4_Click(object sender, EventArgs e)
        {
            User emp = new User();
            User user = new User();
            List<User> listEmp = user.FindEmployeeUser(Convert.ToInt32(textBoxInputUser.Text));

            if (listEmp != null)
            {
                listViewUser.Items.Clear();
                foreach (User empTemp in listEmp)
                {
                    ListViewItem item = new ListViewItem(empTemp.Employeeid.ToString());
                    item.SubItems.Add(empTemp.Identifier);
                    item.SubItems.Add(empTemp.Password);
                    listViewUser.Items.Add(item); // adds shows all of the above data into the list view

                    textBoxUserId.Text = Convert.ToString(empTemp.Employeeid);
                    comboBoxIdentifierUser.SelectedIndex = empTemp.ComboIndentifierIndex(empTemp.Employeeid); // needs to return index
                    textBoxPasswordUser.Text = empTemp.Password;

                    buttonDeleteUser.Enabled = true;
                    buttonUpdateUser.Enabled = true;

                }
            }

        }

        // MIS MANAGER - User Tab - Save button (new password/userid/identifier)
        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            if (Validator.AlreadyExists(textBoxUserId.Text))
            {
                MessageBox.Show("Employee ID already exits.", "Already Exits");
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }
            if (!Validator.IsValidId(Convert.ToString(textBoxUserId.Text), 4))
            {
                MessageBox.Show("Invalid ID! Please re-enter a 4-digit number", "Invalid");
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }
            if (!Validator.IsValidPassword(Convert.ToString(textBoxPasswordUser.Text), 6))
            {
                MessageBox.Show("Password has to be 6 characters(a-z, A-Z, 1-9)", "Invalid");
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }

            User empp = new User();
            User emp = new User();
            emp.Employeeid = Convert.ToInt32(textBoxUserId.Text);
            emp.Identifier = empp.IdentifyComboBox(comboBoxIdentifierUser.SelectedItem);// convert it to manager,sales,etc...
            emp.Password = textBoxPasswordUser.Text;

            emp.Save(emp);
            ClearAllUser();
        }

        private void maskedTextBoxPhoneNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        // USER TAB - List All
        private void buttonListAllUser_Click(object sender, EventArgs e)
        {
            User user = new User();
            List<User> listU = user.GetListUser();
            user.ListAll(listViewUser, listU);
        }

        // EMPLOYEE FORM - close this form
        public void CloseThisForm()
        {
            this.Hide();
        }

        // EMPLOYEE FORM - switch user button
        private void buttonSwitchUser_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Are you sure you want to log out?", "Confirm",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                using (LogInForm logIn = new LogInForm())
                {
                    this.Hide();
                    logIn.ShowDialog();
                    
                }
            }
            
        }

        private void labelFaxNumberClient_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFaxNumberClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPostalCode_Click(object sender, EventArgs e)
        {

        }

        // SALES MANAGER TAB - Save Client
        private void buttonSaveClient_Click(object sender, EventArgs e)
        {
            // if anything is empty
            if (comboBoxTypeClient.SelectedIndex == -1)
            {
                MessageBox.Show("Type field needs a selection.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxTypeClient.Focus();
            }

            // Phone Number Validation
            if (!Validator.IsValidNumber(Convert.ToString(maskedTextBoxPhoneNumberClient.Text), 10))
            {
                MessageBox.Show("Please enter a valid phone number.", "Invalid");
                maskedTextBoxPhoneNumber.Clear();
                maskedTextBoxPhoneNumber.Focus();
                return;
            }

            //Fax Number Validation
            if (!Validator.IsValidNumber(Convert.ToString(maskedTextBoxFaxNumberClient.Text), 10))
            {
                MessageBox.Show("Please enter a valid fax number.", "Invalid");
                maskedTextBoxFaxNumberClient.Clear();
                maskedTextBoxFaxNumberClient.Focus();
                return;
            }

            // Postal Code
            if (!ValidatorPOS.IsValidPostalCode(textBoxPostalCodeClient.Text))
            {
                MessageBox.Show("Please enter a valid postal code. Make sure all letters are capital.", "Invalid");
                textBoxPostalCodeClient.Clear();
                textBoxPostalCodeClient.Focus();
                return;
            }

            // Credit Limit
            if (!ValidatorPOS.IsValidMoney(textBoxCreditLimitClient.Text))
            {
                MessageBox.Show("Please enter a valid amount for credit limit.", "Invalid");
                textBoxCreditLimitClient.Clear();
                textBoxCreditLimitClient.Focus();
                return;
            }

            // Name, Street, City
            if (!Validator.IsValidName(textBoxNameClient.Text))
            {
                MessageBox.Show("Please enter a valid name.", "Invalid");
                textBoxNameClient.Clear();
                textBoxNameClient.Focus();
                return;
            }
            if (!Validator.IsValidName(textBoxStreet.Text))
            {
                MessageBox.Show("Please enter a valid street name.", "Invalid");
                textBoxStreet.Clear();
                textBoxStreet.Focus();
                return;
            }
            if (!Validator.IsValidName(textBoxCity.Text))
            {
                MessageBox.Show("Please enter a valid city name.", "Invalid");
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }
            if (ValidatorPOS.ClientAlreadyExists(textBoxPostalCodeClient.Text, textBoxNameClient.Text))
            {
                MessageBox.Show("Client already exits!", "Already Exists");
                textBoxNameClient.Clear();
                textBoxPostalCodeClient.Clear();
                textBoxCity.Focus();
                return;
            }

            //if valid, fill 
            Client aClient = new Client();
            aClient.Type = Convert.ToString(comboBoxTypeClient.SelectedItem).ToLower();
            aClient.Name = textBoxNameClient.Text.Trim();
            aClient.Street = textBoxStreet.Text.Trim();
            aClient.City = textBoxCity.Text.Trim();
            aClient.PostalCode = textBoxPostalCodeClient.Text.Trim();
            aClient.PhoneNumber = maskedTextBoxPhoneNumberClient.Text;
            aClient.FaxNumber = maskedTextBoxFaxNumberClient.Text;
            aClient.CreditLimit = Convert.ToDecimal(textBoxCreditLimitClient.Text);
            aClient.SaveClient(aClient);
            ClearAllClient();
        }

        // SALES MANAGER TAB - Search button
        private void buttonSearchClient_Click(object sender, EventArgs e)
        {
            // input data validation first
            int searchIndex = comboBoxSearchOptionClient.SelectedIndex;

            switch (searchIndex)
            {
                case 0: //search by name
                    string clientName = textBoxInputClient.Text;

                    // If name is not valid, let user know.
                    if (!Validator.IsValidName(clientName))
                    {
                        MessageBox.Show("Please enter a valid name.", "Invalid");
                        textBoxInputClient.Clear();
                        textBoxInputClient.Focus();
                        return;
                    }
                    // If it is valid, do the following
                    else
                    {
                        Client aclient = new Client();
                        List<Client> listC = aclient.SearchClientName(textBoxInputClient.Text);
                        if (listC != null)
                        {
                            listViewClients.Items.Clear();
                            foreach (Client clientTemp in listC)
                            {
                                // Create list view object and add each item inside one by one.
                                ListViewItem item = new ListViewItem(clientTemp.Type);
                                item.SubItems.Add(clientTemp.Name);
                                item.SubItems.Add(clientTemp.Street);
                                item.SubItems.Add(clientTemp.City);
                                item.SubItems.Add(clientTemp.PostalCode);
                                item.SubItems.Add(clientTemp.PhoneNumber);
                                item.SubItems.Add(clientTemp.FaxNumber);
                                item.SubItems.Add(clientTemp.CreditLimit.ToString());
                                listViewClients.Items.Add(item);

                                //Fill in textboxes with client information
                                comboBoxTypeClient.SelectedIndex = aclient.IdentifyType(clientTemp.Type); // pass name and return type 
                                textBoxNameClient.Text = clientTemp.Name;
                                textBoxStreet.Text = clientTemp.Street;
                                textBoxCity.Text = clientTemp.City;
                                textBoxPostalCodeClient.Text = clientTemp.PostalCode;
                                maskedTextBoxPhoneNumberClient.Text = clientTemp.PhoneNumber;
                                maskedTextBoxFaxNumberClient.Text = Convert.ToString(clientTemp.FaxNumber);
                                textBoxCreditLimitClient.Text = Convert.ToString(clientTemp.CreditLimit);

                                // Enable buttons to update/delete client
                                buttonDeleteClient.Enabled = true;
                                buttonUpdateClient.Enabled = true;

                            }

                        }
                    }

                    break;

                case 1: // search by street
                    string clientStreet = textBoxInputClient.Text;
                    
                    if (!Validator.IsValidName(clientStreet))
                    {
                        MessageBox.Show("Please enter a valid street name.", "Invalid");
                        textBoxInputClient.Clear();
                        textBoxInputClient.Focus();
                        return;
                    }
                    else
                    {
                        Client aClient2 = new Client();
                        List<Client> listC = listC = aClient2.SearchClientStreet(clientStreet);

                        if (listC != null)
                        {
                            listViewClients.Items.Clear();
                            foreach (Client clientTemp in listC)
                            {
                                ListViewItem item = new ListViewItem(clientTemp.Type);
                                item.SubItems.Add(clientTemp.Name);
                                item.SubItems.Add(clientTemp.Street);
                                item.SubItems.Add(clientTemp.City);
                                item.SubItems.Add(clientTemp.PostalCode);
                                item.SubItems.Add(clientTemp.PhoneNumber);
                                item.SubItems.Add(clientTemp.FaxNumber);
                                item.SubItems.Add(clientTemp.CreditLimit.ToString());
                                listViewClients.Items.Add(item);

                                buttonDeleteClient.Enabled = true;
                                buttonUpdateClient.Enabled = true;

                            }

                        }
                    }

                    break;

                case 2: // search by city
                    
                    if (!Validator.IsValidName(textBoxInputClient.Text))
                    {
                        MessageBox.Show("Please enter a valid city name.", "Invalid");
                        textBoxInputClient.Clear();
                        textBoxInputClient.Focus();
                        return;
                    }
                    else
                    {
                        Client aClient3 = new Client();
                        List<Client> listC = aClient3.SearchClientCity(textBoxInputClient.Text);
                        if (listC != null)
                        {
                            listViewClients.Items.Clear();
                            foreach (Client clientTemp in listC)
                            {
                                ListViewItem item = new ListViewItem(clientTemp.Type);
                                item.SubItems.Add(clientTemp.Name);
                                item.SubItems.Add(clientTemp.Street);
                                item.SubItems.Add(clientTemp.City);
                                item.SubItems.Add(clientTemp.PostalCode);
                                item.SubItems.Add(clientTemp.PhoneNumber);
                                item.SubItems.Add(clientTemp.FaxNumber);
                                item.SubItems.Add(clientTemp.CreditLimit.ToString());
                                listViewClients.Items.Add(item);

                                buttonDeleteClient.Enabled = true;
                                buttonUpdateClient.Enabled = true;

                            }

                        }
                    }

                    break;

                case 3: // search by postal code
                    if (!ValidatorPOS.IsValidPostalCode(textBoxInputClient.Text))
                    {
                        MessageBox.Show("Please enter a valid postal code.", "Invalid");
                        textBoxInputClient.Clear();
                        textBoxInputClient.Focus();
                        return;
                    }
                    else
                    {
                        Client aClient4 = new Client();
                        List<Client> listC = aClient4.SearchClientPostalCode(textBoxInputClient.Text);
                        if (listC != null)
                        {
                            listViewClients.Items.Clear();
                            foreach (Client clientTemp in listC)
                            {
                                ListViewItem item = new ListViewItem(clientTemp.Type);
                                item.SubItems.Add(clientTemp.Name);
                                item.SubItems.Add(clientTemp.Street);
                                item.SubItems.Add(clientTemp.City);
                                item.SubItems.Add(clientTemp.PostalCode);
                                item.SubItems.Add(clientTemp.PhoneNumber);
                                item.SubItems.Add(clientTemp.FaxNumber);
                                item.SubItems.Add(clientTemp.CreditLimit.ToString());
                                listViewClients.Items.Add(item);

                                comboBoxTypeClient.SelectedIndex = aClient4.IdentifyType(clientTemp.Type); // pass name and return type 
                                textBoxNameClient.Text = clientTemp.Name;
                                textBoxStreet.Text = clientTemp.Street;
                                textBoxCity.Text = clientTemp.City;
                                maskedTextBoxPhoneNumberClient.Text = clientTemp.PhoneNumber;
                                textBoxPostalCodeClient.Text = clientTemp.PostalCode;
                                maskedTextBoxFaxNumberClient.Text = Convert.ToString(clientTemp.FaxNumber);
                                textBoxCreditLimitClient.Text = Convert.ToString(clientTemp.CreditLimit);


                                buttonDeleteClient.Enabled = true;
                                buttonUpdateClient.Enabled = true;

                            }

                        }
                    }

                    break;

                case 4: // search by type
                    if (!ValidatorPOS.IsValidType(textBoxInputClient.Text))
                    {
                        MessageBox.Show("Please enter a valid postal code.", "Invalid");
                        textBoxInputClient.Clear();
                        textBoxInputClient.Focus();
                        return;
                    }
                    else
                    {
                        Client aClientType = new Client();
                        List<Client> listC = aClientType.SearchClientType(textBoxInputClient.Text);

                        if (listC != null)
                        {
                            listViewClients.Items.Clear();
                            foreach (Client clientTemp in listC)
                            {
                                ListViewItem item = new ListViewItem(clientTemp.Type);
                                item.SubItems.Add(clientTemp.Name);
                                item.SubItems.Add(clientTemp.Street);
                                item.SubItems.Add(clientTemp.City);
                                item.SubItems.Add(clientTemp.PostalCode);
                                item.SubItems.Add(clientTemp.PhoneNumber);
                                item.SubItems.Add(clientTemp.FaxNumber);
                                item.SubItems.Add(clientTemp.CreditLimit.ToString());
                                listViewClients.Items.Add(item);

                                buttonDeleteClient.Enabled = true;
                                buttonUpdateClient.Enabled = true;

                            }

                        }
                    }

                    break;

                default:
                    break;
            }
        }

        // SALES MANAGER TAB - Update Button
        private void buttonUpdateClient_Click(object sender, EventArgs e)
        {
            // Phone Number Validation
            if (!Validator.IsValidNumber(Convert.ToString(maskedTextBoxPhoneNumberClient.Text), 10))
            {
                MessageBox.Show("Please enter a valid phone number.", "Invalid");
                maskedTextBoxPhoneNumber.Clear();
                maskedTextBoxPhoneNumber.Focus();
                return;
            }

            //Fax Number Validation
            if (!Validator.IsValidNumber(Convert.ToString(maskedTextBoxFaxNumberClient.Text), 10))
            {
                MessageBox.Show("Please enter a valid fax number.", "Invalid");
                maskedTextBoxFaxNumberClient.Clear();
                maskedTextBoxFaxNumberClient.Focus();
                return;
            }

            // Postal Code
            if (!ValidatorPOS.IsValidPostalCode(textBoxPostalCodeClient.Text))
            {
                MessageBox.Show("Please enter a valid postal code. Make sure all letters are capital.", "Invalid");
                textBoxPostalCodeClient.Clear();
                textBoxPostalCodeClient.Focus();
                return;
            }

            // Credit Limit
            if (!ValidatorPOS.IsValidMoney(textBoxCreditLimitClient.Text))
            {
                MessageBox.Show("Please enter a valid amount for credit limit.", "Invalid");
                textBoxCreditLimitClient.Clear();
                textBoxCreditLimitClient.Focus();
                return;
            }

            // Name, Street, City
            if (!ValidatorPOS.IsValidName(textBoxNameClient.Text))
            {
                MessageBox.Show("Please enter a valid name.", "Invalid");
                textBoxNameClient.Clear();
                textBoxNameClient.Focus();
                return;
            }
            if (!ValidatorPOS.IsValidName(textBoxStreet.Text))
            {
                MessageBox.Show("Please enter a valid street name.", "Invalid");
                textBoxStreet.Clear();
                textBoxStreet.Focus();
                return;
            }
            if (!ValidatorPOS.IsValidName(textBoxCity.Text))
            {
                MessageBox.Show("Please enter a valid city name.", "Invalid");
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }
            if (!ValidatorPOS.ClientAlreadyExists(textBoxPostalCodeClient.Text, textBoxNameClient.Text))
            {
                MessageBox.Show("Client already exits!", "Already Exists");
                textBoxCity.Clear();
                textBoxCity.Focus();
                return;
            }

            Client aClient = new Client();
            aClient.Type = Convert.ToString(comboBoxTypeClient.SelectedItem).ToLower();
            aClient.Name = textBoxNameClient.Text.Trim();
            aClient.Street = textBoxStreet.Text.Trim();
            aClient.City = textBoxCity.Text.Trim();
            aClient.PostalCode = textBoxPostalCodeClient.Text.Trim();
            aClient.PhoneNumber = maskedTextBoxPhoneNumberClient.Text;
            aClient.FaxNumber = maskedTextBoxFaxNumberClient.Text;
            aClient.CreditLimit = Convert.ToDecimal(textBoxCreditLimitClient.Text);

            DialogResult ans = MessageBox.Show("Are you sure you want to update this client?", "Confirm",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                aClient.UpdateClient(aClient); // found in userDA
                MessageBox.Show("Client record has been successfully updated.", "Confirmation");
            }
        }

        // SALES MANAGER TAB - Delete Client
        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            Client c = new Client();

            DialogResult ans = MessageBox.Show("Are you sure you want to delete this client??", "Confirm",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                c.DeleteClient(textBoxPostalCodeClient.Text);
                MessageBox.Show("Client record has been successfully deleted.", "Confirmation");
                listViewClients.Items.Clear();
            }
        }

        // SALES MANAGER TAB - List All Clients
        private void buttonListAllClient_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            List<Client> listC = c.ListAllClients();
            c.ListAll(listViewClients, listC);
        }

        private void comboBoxTypeClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            tabControl.TabPages[0].Show();
            tabControl.TabPages[1].Show();
            tabControl.TabPages[2].Show();
            tabControl.TabPages[3].Show();
            tabControl.TabPages[4].Show();
        }

        private void buttonUpdateUser_Click(object sender, EventArgs e)
        {
            // validation for if the password is the same as the old one.
            if (!Validator.IsValidPassword(Convert.ToString(textBoxPasswordUser.Text), 6))
            {
                MessageBox.Show("Password has to be 6 characters(a-z, A-Z, 1-9)", "Invalid");
                textBoxUserId.Clear();
                textBoxUserId.Focus();
                return;
            }
            if (!Validator.IsValidId(Convert.ToString(textBoxUserId.Text), 4))
            {
                MessageBox.Show("Invalid ID! Please re-enter a 4-digit number", "Invalid");
                textBoxPasswordUser.Clear();
                textBoxPasswordUser.Focus();
                return;
            }

            User u = new User();
            DialogResult ans = MessageBox.Show("Are you sure you want to update this employee?", "Confirm",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                u.UpdateUser(u.FindEmployeeToUpdate(Convert.ToInt32(textBoxUserId.Text))); // found in userDA
                MessageBox.Show("Employee record has been successfully Updated.", "Confirmation");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void labelOS_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxProductType.SelectedIndex;

            switch (index) // if user selects Software - display options for softwares
                           // if user selects Book     - display options for books
            {
                case 0: // Software
                    //clear all
                    textBoxProductName.Clear();
                    textBoxProductId.Clear();
                    textBoxSoftwareVersion.Clear();
                    comboBoxStatus.SelectedIndex = -1;
                    comboBoxOS.SelectedIndex = -1;
                    textBoxPriceInventory.Clear();

                    // Add List View Columns
                    ListViewColumnSoftware();

                    // Changee text for label
                    labelProduct.Text = "Software";

                    // Display combobox options to search for Software
                    comboBoxInventory.Items.Clear();
                    comboBoxInventory.Items.Add("Product ID");
                    comboBoxInventory.Items.Add("Title");
                    comboBoxInventory.Items.Add("Operating System");

                    comboBoxInventory.Items.Add("Status");
                    comboBoxStatus.Items.Add("Active");
                    comboBoxStatus.Items.Add("Inactive");

                    comboBoxOS.Items.Clear();
                    comboBoxOS.Items.Add("macOS");
                    comboBoxOS.Items.Add("Microsoft Windows");
                    comboBoxOS.Items.Add("Windows 10");
                    comboBoxOS.Items.Add("Windows 8");
                    comboBoxOS.Items.Add("Windows 7");
                    comboBoxOS.Items.Add("Windows Vista");
                    comboBoxOS.Items.Add("Windows XP");
                    comboBoxOS.Items.Add("Windows 2000");
                    comboBoxOS.Items.Add("Linux");
                    comboBoxOS.Items.Add("Linux Kernal");
                    comboBoxOS.Items.Add("Unix");
                    comboBoxOS.Items.Add("CentOS");
                    comboBoxOS.Items.Add("Chrome OS");

                    // Show all labels software
                    labelVersionSoftware.Show();
                    labelStatus.Show();
                    labelOS.Show();
                    // Show all textbox software
                    textBoxSoftwareVersion.Show();
                    comboBoxStatus.Show();
                    comboBoxOS.Show();

                    // Hide other Textboxes and labels for books
                    labelISBN.Hide();
                    labelSupplier.Hide();
                    labelAuthorId.Hide();
                    labelLNAuthor.Hide();
                    labelFNAuthor.Hide();
                    labelYearP.Hide();
                    labelQuantity.Hide();
                    textBoxISBN.Hide();
                    textBoxSupplier.Hide();
                    textBoxAuthorId.Hide();
                    textBoxFirstNameAuthor.Hide();
                    textBoxLastNameAuthor.Hide();
                    textBoxQuantity.Hide();
                    textBoxYearPublished.Hide();

                    // Enable Product Textboxes / buttons
                    textBoxProductId.Enabled = true;
                    textBoxProductName.Enabled = true;
                    textBoxPriceInventory.Enabled = true;
                    buttonSearchInventory.Enabled = true;
                    buttonSaveInventory.Enabled = true;
                    buttonDeleteInventory.Enabled = true;
                    buttonUpdateInventory.Enabled = true;

                    // Change location of textoxes
                    this.textBoxSoftwareVersion.Location = new Point(
                    47, this.textBoxSoftwareVersion.Location.Y
                    );
                    this.comboBoxStatus.Location = new Point(
                    47, this.comboBoxStatus.Location.Y
                    );
                    this.comboBoxOS.Location = new Point(
                    47, this.comboBoxOS.Location.Y
                    );

                    this.labelVersionSoftware.Location = new Point(
                    44, this.labelVersionSoftware.Location.Y
                    );
                    this.labelStatus.Location = new Point(
                    44, this.labelStatus.Location.Y
                    );
                    this.labelOS.Location = new Point(
                    44, this.labelOS.Location.Y
                    );

                    break;
                case 1:
                    // clear all
                    textBoxProductName.Clear();
                    textBoxProductId.Clear();
                    textBoxSupplier.Clear();
                    textBoxISBN.Clear();
                    textBoxYearPublished.Clear();
                    textBoxPriceInventory.Clear();
                    textBoxAuthorId.Clear();
                    textBoxFirstNameAuthor.Clear();
                    textBoxLastNameAuthor.Clear();

                    // Book// Add Columns to ListView
                    ListViewColumnBook();

                    // Changee text for label
                    labelProduct.Text = "Book";
                    labelPriceInventory.Text = "Price (per unit)";

                    // Display combobox options to search for Books
                    comboBoxInventory.Items.Clear();
                    comboBoxInventory.Items.Add("Product ID");
                    comboBoxInventory.Items.Add("Title");
                    comboBoxInventory.Items.Add("Year Published");
                    comboBoxInventory.Items.Add("Author ID");

                    // Show Textboxes and labels for books
                    labelISBN.Show();
                    labelSupplier.Show();
                    labelAuthorId.Show();
                    labelLNAuthor.Show();
                    labelFNAuthor.Show();
                    labelYearP.Show();
                    labelQuantity.Show();
                    textBoxISBN.Show();
                    textBoxSupplier.Show();
                    textBoxAuthorId.Show();
                    textBoxFirstNameAuthor.Show();
                    textBoxLastNameAuthor.Show();
                    textBoxQuantity.Show();
                    textBoxYearPublished.Show();

                    // Hide all labels software
                    labelVersionSoftware.Hide();
                    labelStatus.Hide();
                    labelOS.Hide();
                    // Hide all textbox software
                    textBoxSoftwareVersion.Hide();
                    comboBoxStatus.Hide();
                    comboBoxOS.Hide();

                    // Enable Product Textboxes / Buttons
                    textBoxProductId.Enabled = true;
                    textBoxProductName.Enabled = true;
                    textBoxPriceInventory.Enabled = true;
                    buttonSearchInventory.Enabled = true;
                    buttonSaveInventory.Enabled = true;
                    buttonDeleteInventory.Enabled = true;
                    buttonUpdateInventory.Enabled = true;

                    break;
                default:
                    break;
            }
        }

        // INVENTORY TAB - ComboBox Search
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxInventory.SelectedIndex;

            switch (index)
            {
                case 0:
                    labelInfoInventory.Text = "Enter ID";
                    textBoxInputInventory.Show();
                    comboBoxInputSearch.Hide();
                    break;
                case 1:
                    labelInfoInventory.Text = "Enter Title";
                    textBoxInputInventory.Show();
                    comboBoxInputSearch.Hide();
                    break;
                case 2:
                    labelInfoInventory.Text = "Enter O.S.";
                    textBoxInputInventory.Hide();
                    comboBoxInputSearch.Show();
                    this.comboBoxInputSearch.Location = new Point(
                    484, this.comboBoxInputSearch.Location.Y
                    );

                    comboBoxInputSearch.Items.Clear();
                    comboBoxInputSearch.Items.Add("macOS");
                    comboBoxInputSearch.Items.Add("Microsoft Windows");
                    comboBoxInputSearch.Items.Add("Windows 10");
                    comboBoxInputSearch.Items.Add("Windows 8");
                    comboBoxInputSearch.Items.Add("Windows 7");
                    comboBoxInputSearch.Items.Add("Windows Vista");
                    comboBoxInputSearch.Items.Add("Windows XP");
                    comboBoxInputSearch.Items.Add("Windows 2000");
                    comboBoxInputSearch.Items.Add("Linux");
                    comboBoxInputSearch.Items.Add("Linux Kernal");
                    comboBoxInputSearch.Items.Add("Unix");
                    comboBoxInputSearch.Items.Add("CentOS");
                    comboBoxInputSearch.Items.Add("Chrome OS");
                    break;
                case 3:
                    labelInfoInventory.Text = "Enter Status";
                    textBoxInputInventory.Hide();
                    comboBoxInputSearch.Show();
                    this.comboBoxInputSearch.Location = new Point(
                    484, this.comboBoxInputSearch.Location.Y
                    );
                    comboBoxInputSearch.Items.Clear();
                    comboBoxInputSearch.Items.Add("Active");
                    comboBoxInputSearch.Items.Add("Inactive");
                    break;
                default:
                    break;
            }
        }

        private void tabInventory_Click(object sender, EventArgs e)
        {

        }

        // INVENTORY TAB - Search Button - search by....
        private void buttonSearchInventory_Click(object sender, EventArgs e)
        {
            int searchIndex = comboBoxInventory.SelectedIndex;
            int typeIndex = comboBoxProductType.SelectedIndex;
            Software s = new Software();

            if (typeIndex == 0) // If Selected Item is Software
            {
                switch (searchIndex)
                {
                    case 0: // search by Product ID

                        ClearAllSoftware();

                        if (!Validator.IsValidId(Convert.ToString(textBoxInputInventory.Text), 6))
                        {
                            labelInfoInventory.Text = "Invalid (6-digits)";
                            labelInfoInventory.ForeColor = Color.FromArgb(222, 30, 40);
                            textBoxInputInventory.Clear();
                            textBoxInputInventory.Focus();
                            return;
                        }
                        else
                        {
                            labelInfoInventory.Text = "Enter ID";
                            labelInfoInventory.ForeColor = Color.FromArgb(0, 0, 0);
                            Software softW = new Software();
                            softW = softW.SearchSoftId(Convert.ToInt32(textBoxInputInventory.Text));
                            //soft.ListSoftwares = soft.SearchSoftIdList(Convert.ToInt32(textBoxInputInventory.Text));
                            listViewInventory.Items.Clear();

                            if (softW != null)
                            {
                                ListViewItem item = new ListViewItem(softW.ProductType);
                                item.SubItems.Add(Convert.ToString(softW.ProductNumber));
                                item.SubItems.Add(Convert.ToString(softW.Price));
                                item.SubItems.Add(softW.ProductName);
                                item.SubItems.Add(softW.Version);
                                item.SubItems.Add(softW.Status);
                                item.SubItems.Add(softW.Os);
                                listViewInventory.Items.Add(item);

                                comboBoxProductType.SelectedItem = softW.ProductType;
                                textBoxProductId.Text = Convert.ToString(softW.ProductNumber); // needs to return index
                                textBoxProductName.Text = softW.ProductName;
                                textBoxPriceInventory.Text = softW.Price.ToString();
                                textBoxSoftwareVersion.Text = softW.Version;
                                comboBoxStatus.Text = softW.Status;
                                comboBoxOS.Text = softW.Os;

                                buttonDelete.Enabled = true;
                                buttonUpdate.Enabled = true;
                               
                            }
                        }
                        break;

                    case 1: // search by Product Title

                        ClearAllSoftware();

                        if (!ValidatorPOS.IsValidName(textBoxInputInventory.Text))
                        {
                            //MessageBox.Show("Please enter a valid name.", "Nope");
                            labelInfoInventory.Text = "Not a valid title.";
                            labelInfoInventory.ForeColor = Color.FromArgb(222, 30, 40);
                            textBoxInputInventory.Clear();
                            textBoxInputInventory.Focus();
                            return;
                        }
                        else
                        {
                            // reset label input
                            labelInfoInventory.Text = "Enter title";
                            labelInfoInventory.ForeColor = Color.FromArgb(0, 0, 0);
                            
                            Software softW = new Software();
                            softW.ListSoftwares = softW.SearchSoftByTitle(textBoxInputInventory.Text);

                            if (softW.ListSoftwares != null)
                            {
                                listViewInventory.Items.Clear();
                                foreach (Software sw in softW.ListSoftwares)
                                {
                                    ListViewItem item = new ListViewItem(sw.ProductType);
                                    item.SubItems.Add(Convert.ToString(sw.ProductNumber));
                                    item.SubItems.Add(Convert.ToString(sw.Price));
                                    item.SubItems.Add(sw.ProductName);
                                    item.SubItems.Add(sw.Version);
                                    item.SubItems.Add(sw.Status);
                                    item.SubItems.Add(sw.Os);
                                    listViewInventory.Items.Add(item);
                                }
                            }
                        }

                        break;

                    case 2: // Operating System
                        ClearAllSoftware();

                        Software soft = new Software();
                        soft.ListSoftwares = soft.SearchSoftByOs(Convert.ToString(comboBoxInputSearch.SelectedItem));

                        if (soft.ListSoftwares != null)
                        {
                            listViewInventory.Items.Clear();
                            foreach (Software sw in soft.ListSoftwares)
                            {
                                ListViewItem item = new ListViewItem(sw.ProductType);
                                item.SubItems.Add(Convert.ToString(sw.ProductNumber));
                                item.SubItems.Add(Convert.ToString(sw.Price));
                                item.SubItems.Add(sw.ProductName);
                                item.SubItems.Add(sw.Version);
                                item.SubItems.Add(sw.Status);
                                item.SubItems.Add(sw.Os);
                                listViewInventory.Items.Add(item);
                            }
                        }
                        break;
                    case 3: // Search by Status
                        ClearAllSoftware();

                        Software softw = new Software();
                        softw.ListSoftwares = softw.SearchByStatus(Convert.ToString(comboBoxInputSearch.SelectedItem));

                        if (softw.ListSoftwares != null)
                        {
                            listViewInventory.Items.Clear();
                            foreach (Software sw in softw.ListSoftwares)
                            {
                                ListViewItem item = new ListViewItem(sw.ProductType);
                                item.SubItems.Add(Convert.ToString(sw.ProductNumber));
                                item.SubItems.Add(Convert.ToString(sw.Price));
                                item.SubItems.Add(sw.ProductName);
                                item.SubItems.Add(sw.Version);
                                item.SubItems.Add(sw.Status);
                                item.SubItems.Add(sw.Os);
                                listViewInventory.Items.Add(item);
                            }
                        }
                        break;

                    default:
                        MessageBox.Show("Oops! Your forgot select an option.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            if (typeIndex == 1) // If Selected Item is Book
            {
                Book b = new Book();
                switch (searchIndex)
                {
                    case 0:
                        ClearAllBook();

                        if (!Validator.IsValidId(Convert.ToString(textBoxInputInventory.Text), 6))
                        {
                            labelInfoInventory.Text = "Invalid (6-digits)";
                            labelInfoInventory.ForeColor = Color.FromArgb(222, 30, 40);
                            textBoxInputInventory.Clear();
                            textBoxInputInventory.Focus();
                            return;
                        }
                        else
                        {
                            labelInfoInventory.Text = "Enter ID";
                            labelInfoInventory.ForeColor = Color.FromArgb(0, 0, 0);
                            
                            b = b.SearchById(Convert.ToInt32(textBoxInputInventory.Text));
                            listViewInventory.Items.Clear();

                            if (b != null)
                            {
                                ListViewItem item = new ListViewItem(b.ProductType);
                                item.SubItems.Add(b.ProductNumber.ToString());
                                item.SubItems.Add(b.UnitPrice.ToString());
                                item.SubItems.Add(b.ProductName);
                                item.SubItems.Add(b.Isbn);
                                item.SubItems.Add(b.Supplier);
                                item.SubItems.Add(b.PublishedYear.ToString());
                                item.SubItems.Add(b.AuthorId.ToString());
                                item.SubItems.Add(b.FirstName);
                                item.SubItems.Add(b.LastName);
                                item.SubItems.Add(b.Quantity.ToString());
                                listViewInventory.Items.Add(item);

                                comboBoxProductType.SelectedItem =  b.ProductType;
                                textBoxProductId.Text =             b.ProductNumber.ToString(); ; // needs to return index
                                textBoxProductName.Text =           b.ProductName;
                                textBoxPriceInventory.Text =        b.UnitPrice.ToString();
                                textBoxISBN.Text =                  b.Isbn;
                                textBoxSupplier.Text =              b.Supplier;
                                textBoxYearPublished.Text =         b.PublishedYear.ToString();
                                textBoxAuthorId.Text =              b.AuthorId.ToString();
                                textBoxFirstNameAuthor.Text =       b.FirstName;
                                textBoxLastNameAuthor.Text =        b.LastName;
                                textBoxQuantity.Text =              b.Quantity.ToString();

                                buttonDelete.Enabled = true;
                                buttonUpdate.Enabled = true;

                            }
                        }
                        break;
                    case 1: // search by title
                        ClearAllBook();

                        if (!ValidatorPOS.IsValidTitle(textBoxInputInventory.Text))
                        {
                            labelInfoInventory.Text = "Invalid title";
                            labelInfoInventory.ForeColor = Color.FromArgb(222, 30, 40);
                            textBoxInputInventory.Clear();
                            textBoxInputInventory.Focus();
                            return;
                        }
                        else
                        {
                            labelInfoInventory.Text = "Enter title";
                            labelInfoInventory.ForeColor = Color.FromArgb(0, 0, 0);

                            b.ListBooks = b.SearchByTitle(textBoxInputInventory.Text);
                            listViewInventory.Items.Clear();

                            if (b.ListBooks != null)
                            {
                                foreach (Book book in b.ListBooks)
                                {
                                    ListViewItem item = new ListViewItem(b.ProductType);
                                    item.SubItems.Add(book.ProductNumber.ToString());
                                    item.SubItems.Add(book.UnitPrice.ToString());
                                    item.SubItems.Add(book.ProductName);
                                    item.SubItems.Add(book.Isbn);
                                    item.SubItems.Add(book.Supplier);
                                    item.SubItems.Add(book.PublishedYear.ToString());
                                    item.SubItems.Add(book.AuthorId.ToString());
                                    item.SubItems.Add(book.FirstName);
                                    item.SubItems.Add(book.LastName);
                                    item.SubItems.Add(book.Quantity.ToString());
                                    listViewInventory.Items.Add(item);
                                }
                                buttonDelete.Enabled = true;
                                buttonUpdate.Enabled = true;
                            }
                        }
                        break;
                    case 2: // search by Year Published
                        ClearAllBook();

                        if (!ValidatorPOS.IsValidYear(textBoxInputInventory.Text))
                        {
                            labelInfoInventory.Text = "Invalid year";
                            labelInfoInventory.ForeColor = Color.FromArgb(222, 30, 40);
                            textBoxInputInventory.Clear();
                            textBoxInputInventory.Focus();
                            return;
                        }
                        else
                        {
                            labelInfoInventory.Text = "Enter Year";
                            labelInfoInventory.ForeColor = Color.FromArgb(0, 0, 0);

                            b.ListBooks = b.SearchByYear(Convert.ToInt32(textBoxInputInventory.Text));
                            listViewInventory.Items.Clear();

                            if (b.ListBooks != null)
                            {
                                listViewInventory.Items.Clear();
                                foreach (Book book in b.ListBooks)
                                {
                                    ListViewItem item = new ListViewItem(b.ProductType);
                                    item.SubItems.Add(book.ProductNumber.ToString());
                                    item.SubItems.Add(book.UnitPrice.ToString());
                                    item.SubItems.Add(book.ProductName);
                                    item.SubItems.Add(book.Isbn);
                                    item.SubItems.Add(book.Supplier);
                                    item.SubItems.Add(book.PublishedYear.ToString());
                                    item.SubItems.Add(book.AuthorId.ToString());
                                    item.SubItems.Add(book.FirstName);
                                    item.SubItems.Add(book.LastName);
                                    item.SubItems.Add(book.Quantity.ToString());
                                    listViewInventory.Items.Add(item);
                                }
                                buttonDelete.Enabled = true;
                                buttonUpdate.Enabled = true;
                            }
                        }
                        break;
                    case 3: // Search by Author ID
                        ClearAllBook();

                        if (!ValidatorPOS.IsValidId(textBoxInputInventory.Text, 6))
                        {
                            labelInfoInventory.Text = "Invalid ID (6-digits)";
                            labelInfoInventory.ForeColor = Color.FromArgb(222, 30, 40);
                            textBoxInputInventory.Clear();
                            textBoxInputInventory.Focus();
                            return;
                        }
                        else
                        {
                            labelInfoInventory.Text = "Enter Author ID";
                            labelInfoInventory.ForeColor = Color.FromArgb(0, 0, 0);

                            b.ListBooks = b.SearchByAuthorId(Convert.ToInt32(textBoxInputInventory.Text));
                            listViewInventory.Items.Clear();

                            if (b.ListBooks != null)
                            {
                                listViewInventory.Items.Clear();
                                foreach (Book book in b.ListBooks)
                                {
                                    ListViewItem item = new ListViewItem(b.ProductType);
                                    item.SubItems.Add(book.ProductNumber.ToString());
                                    item.SubItems.Add(book.UnitPrice.ToString());
                                    item.SubItems.Add(book.ProductName);
                                    item.SubItems.Add(book.Isbn);
                                    item.SubItems.Add(book.Supplier);
                                    item.SubItems.Add(book.PublishedYear.ToString());
                                    item.SubItems.Add(book.AuthorId.ToString());
                                    item.SubItems.Add(book.FirstName);
                                    item.SubItems.Add(book.LastName);
                                    item.SubItems.Add(book.Quantity.ToString());
                                    listViewInventory.Items.Add(item);
                                }

                                buttonDelete.Enabled = true;
                                buttonUpdate.Enabled = true;

                            }
                        }
                        break;
                    default:
                        MessageBox.Show("Oops! Your forgot select an option.", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

            }
            
        }

        // INVENTORY TAB - Save Button (save product)
        private void buttonSaveInventory_Click(object sender, EventArgs e)
        {
            int index = comboBoxProductType.SelectedIndex;
            
            switch (index)
            {
                case 0: // Software
                    Software s = new Software();

                    // If textboxes / comboboxes are empty
                    if (string.IsNullOrEmpty(textBoxProductId.Text)) // id
                    {
                        MessageBox.Show("You must enter product ID.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductName.Text)) // name
                    {
                        MessageBox.Show("You must enter product name.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductName.Clear();
                        textBoxProductName.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxSoftwareVersion.Text)) // version
                    {
                        MessageBox.Show("You must enter software version.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSoftwareVersion.Clear();
                        textBoxSoftwareVersion.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxPriceInventory.Text))
                    {
                        MessageBox.Show("You must enter price.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPriceInventory.Clear();
                        textBoxPriceInventory.Focus();
                        return;
                    }
                    if (comboBoxStatus.SelectedIndex == -1) // Status
                    {
                        MessageBox.Show("You must enter select a status.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSoftwareVersion.Clear();
                        textBoxSoftwareVersion.Focus();
                        return;
                    }
                    if (comboBoxOS.SelectedIndex == -1) // Operating System
                    {
                        MessageBox.Show("You must enter select a status.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSoftwareVersion.Clear();
                        textBoxSoftwareVersion.Focus();
                        return;
                    }

                    // Input Validation
                    if (!ValidatorPOS.IsValidId(textBoxProductId.Text, 6))
                    {
                        MessageBox.Show("ID has to be 6-digits.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (ValidatorPOS.SoftwareAlreadyExists(textBoxProductId.Text))
                    {
                        MessageBox.Show("Software ID already exists.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidVersion(textBoxSoftwareVersion.Text))
                    {
                        MessageBox.Show("Version does not seem to be valid.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSoftwareVersion.Clear();
                        textBoxSoftwareVersion.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidName(textBoxProductName.Text))
                    {
                        MessageBox.Show("Please enter a valid product name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductName.Clear();
                        textBoxProductName.Focus();
                        return;
                    }
                    

                    // Fill Information in object of type Software
                    s.ProductName = textBoxProductName.Text.ToLower();
                    s.ProductNumber = Convert.ToInt32(textBoxProductId.Text);
                    s.ProductType = Convert.ToString(comboBoxProductType.SelectedItem).ToLower();
                    s.Price = textBoxPriceInventory.Text; // !!!!!! change var to decimal in pos
                    s.Version = textBoxSoftwareVersion.Text;
                    s.Status = comboBoxStatus.Text.ToLower();
                    s.Os = comboBoxOS.Text.Trim().ToLower();

                    // Save to file, then clear all 
                    s.SaveSoftware(s);
                    ClearAllSoftware();

                    break;
                case 1: // Book
                    Book b = new Book();

                    if (string.IsNullOrEmpty(textBoxProductId.Text)) // id
                    {
                        MessageBox.Show("You must enter product ID.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductName.Text)) // name
                    {
                        MessageBox.Show("You must enter product name.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductName.Clear();
                        textBoxProductName.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxPriceInventory.Text)) // price
                    {
                        MessageBox.Show("You must enter price.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPriceInventory.Clear();
                        textBoxPriceInventory.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxISBN.Text)) // ISBN
                    {
                        MessageBox.Show("You must enter ISBN number.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxISBN.Clear();
                        textBoxISBN.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxSupplier.Text)) // Supplier
                    {
                        MessageBox.Show("You must enter a supplier.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSupplier.Clear();
                        textBoxSupplier.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxYearPublished.Text)) // year published
                    {
                        MessageBox.Show("You must enter a year.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxYearPublished.Clear();
                        textBoxYearPublished.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxAuthorId.Text) || string.IsNullOrEmpty(textBoxFirstNameAuthor.Text) || string.IsNullOrEmpty(textBoxLastNameAuthor.Text)) // Author id
                    {
                        MessageBox.Show("You must complete Author's information.", "You forgot something!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxAuthorId.Clear();
                        textBoxAuthorId.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxQuantity.Text)) // year published
                    {
                        MessageBox.Show("You must enter a quantity.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxQuantity.Clear();
                        textBoxQuantity.Focus();
                        return;
                    }

                    if (!ValidatorPOS.IsValidId(textBoxProductId.Text, 6)) // id
                    {
                        MessageBox.Show("ID has to be 6-digits.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (ValidatorPOS.BookAlreadyExists(textBoxProductId.Text))
                    {
                        MessageBox.Show("Book ID already exists.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidTitle(textBoxProductName.Text)) // title
                    {
                        MessageBox.Show("Title does not seem to be valid.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductName.Clear();
                        textBoxProductName.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidMoney(textBoxPriceInventory.Text)) // author l name
                    {
                        MessageBox.Show("Please enter a valid price.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPriceInventory.Clear();
                        textBoxPriceInventory.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidTitle(textBoxSupplier.Text)) // supplier
                    {
                        MessageBox.Show("Please enter a valid supplier name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSupplier.Clear();
                        textBoxSupplier.Focus();
                        return;
                    }       
                    if (!ValidatorPOS.IsValidYear(textBoxYearPublished.Text)) // year 
                    {
                        MessageBox.Show("Please enter a valid year.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxYearPublished.Clear();
                        textBoxYearPublished.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidId(textBoxAuthorId.Text, 6)) // author id
                    {
                        MessageBox.Show("Please enter a valid author ID.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxAuthorId.Clear();
                        textBoxAuthorId.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidName(textBoxFirstNameAuthor.Text)) // author name
                    {
                        MessageBox.Show("Please enter a valid author name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxFirstNameAuthor.Clear();
                        textBoxFirstNameAuthor.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidName(textBoxLastNameAuthor.Text)) // author f name
                    {
                        MessageBox.Show("Please enter a valid author name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxLastNameAuthor.Clear();
                        textBoxLastNameAuthor.Focus();
                        return;
                    }
                    

                    // Fill Information in object of type Software
                    b.ProductName = textBoxProductName.Text.ToLower();
                    b.ProductNumber = Convert.ToInt32(textBoxProductId.Text);
                    b.ProductType = Convert.ToString(comboBoxProductType.SelectedItem).ToLower();
                    b.Supplier = textBoxSupplier.Text;
                    b.Isbn = textBoxISBN.Text;
                    b.PublishedYear = Convert.ToInt32(textBoxYearPublished.Text);
                    b.UnitPrice = Convert.ToDecimal(textBoxPriceInventory.Text);
                    b.AuthorId = Convert.ToInt32(textBoxAuthorId.Text);
                    b.FirstName = textBoxFirstNameAuthor.Text;
                    b.LastName = textBoxLastNameAuthor.Text;

                    // Save to file, then clear all 
                    b.SaveBook(b);
                    ClearAllBook();
                    break;
                default:
                    break;
            }
            
        }

        // INVENTORY - Clear Software Textboxes/Comboboxes
        public void ClearAllSoftware()
        {
            textBoxProductName.Clear();
            textBoxProductId.Clear();
            textBoxSoftwareVersion.Clear();
            comboBoxStatus.SelectedIndex = -1;
            comboBoxOS.SelectedIndex = -1;
            textBoxPriceInventory.Clear();
        }

        // INVENTORY - Clear Book textboxes/comboboxes
        public void ClearAllBook()
        {
            textBoxProductName.Clear();
            textBoxProductId.Clear();
            textBoxSupplier.Clear();
            textBoxISBN.Clear();
            textBoxYearPublished.Clear();
            textBoxPriceInventory.Clear();
            textBoxAuthorId.Clear();
            textBoxFirstNameAuthor.Clear();
            textBoxLastNameAuthor.Clear();
        }

        // INVENTORY TAB - List all 
        private void buttonListAllInventory_Click(object sender, EventArgs e)
        {
            int index = comboBoxProductType.SelectedIndex;

            // If user selects software/book, list either softwares or books
            switch (index)
            {
                case 0: // Software
                    Software aSoftware = new Software();
                    aSoftware.ListSoftwares = aSoftware.ListAllSoftwares();

                    // Clear items Before listing
                    listViewInventory.Items.Clear();

                    // List values
                    foreach (Software sw in aSoftware.ListSoftwares)
                    {
                        ListViewItem item = new ListViewItem(sw.ProductType);
                        item.SubItems.Add(Convert.ToString(sw.ProductNumber));
                        item.SubItems.Add(Convert.ToString(sw.Price));
                        item.SubItems.Add(sw.ProductName);
                        item.SubItems.Add(sw.Version);
                        item.SubItems.Add(sw.Status);
                        item.SubItems.Add(sw.Os);

                        listViewInventory.Items.Add(item);

                    }
                    break;
                case 1: // Book
                    Book aBook = new Book();
                    aBook.ListBooks = aBook.ListAllBooks();

                    // Clear items Before listing
                    listViewInventory.Items.Clear();

                    // List values
                    foreach (Book sw in aBook.ListBooks)
                    {
                        ListViewItem item = new ListViewItem(sw.ProductType);
                        item.SubItems.Add(Convert.ToString(sw.ProductNumber));
                        item.SubItems.Add(Convert.ToString(sw.UnitPrice));
                        item.SubItems.Add(sw.ProductName);
                        item.SubItems.Add(sw.Isbn);
                        item.SubItems.Add(sw.Supplier);
                        item.SubItems.Add(Convert.ToString(sw.PublishedYear));
                        item.SubItems.Add(Convert.ToString(sw.AuthorId));
                        item.SubItems.Add(sw.FirstName);
                        item.SubItems.Add(sw.LastName);
                        item.SubItems.Add(Convert.ToString(sw.Quantity));

                        listViewInventory.Items.Add(item);

                    }
                    break;
                default:
                    MessageBox.Show("Type not selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            
        }

        private void listViewInventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // INVENTORY - Add columns to the ListView(software)
        public void ListViewColumnSoftware()
        {
            listViewInventory.Columns.Clear();
            listViewInventory.Columns.Add("Type", 60);
            listViewInventory.Columns.Add("ID", 60);
            listViewInventory.Columns.Add("Price", 60);
            listViewInventory.Columns.Add("Title", 80);
            listViewInventory.Columns.Add("Version", 60);
            listViewInventory.Columns.Add("Status", 60);
            listViewInventory.Columns.Add("OS(Operating System)", 80);
        }
        // INVENTORY - Add columns to the ListView(book)
        public void ListViewColumnBook()
        {
            listViewInventory.Columns.Clear();
            listViewInventory.Columns.Add("Type", 60);
            listViewInventory.Columns.Add("ID", 60);
            listViewInventory.Columns.Add("Price", 60);
            listViewInventory.Columns.Add("Title", 60);
            listViewInventory.Columns.Add("ISBN", 60);
            listViewInventory.Columns.Add("Supplier", 60);
            listViewInventory.Columns.Add("Year Published", 40);
            listViewInventory.Columns.Add("Author ID", 40);
            listViewInventory.Columns.Add("Author First Name", 80);
            listViewInventory.Columns.Add("Author Last Name", 80);
            listViewInventory.Columns.Add("Quantity", 30);
        }

        private void listViewEmployee_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void buttonUpdateInventory_Click(object sender, EventArgs e)
        {
            int index = comboBoxProductType.SelectedIndex;

            switch (index)
            {
                case 0: // Software 
                    textBoxProductId.Enabled = false;
                    Software s = new Software();

                    // If textboxes / comboboxes are empty
                    if (string.IsNullOrEmpty(textBoxProductId.Text)) // id
                    {
                        MessageBox.Show("You must enter product ID.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductName.Text)) // name
                    {
                        MessageBox.Show("You must enter product name.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductName.Clear();
                        textBoxProductName.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxSoftwareVersion.Text)) // version
                    {
                        MessageBox.Show("You must enter software version.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSoftwareVersion.Clear();
                        textBoxSoftwareVersion.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxPriceInventory.Text))
                    {
                        MessageBox.Show("You must enter price.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPriceInventory.Clear();
                        textBoxPriceInventory.Focus();
                        return;
                    }
                    if (comboBoxStatus.SelectedIndex == -1) // Status
                    {
                        MessageBox.Show("You must enter select a status.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSoftwareVersion.Clear();
                        textBoxSoftwareVersion.Focus();
                        return;
                    }
                    if (comboBoxOS.SelectedIndex == -1) // Operating System
                    {
                        MessageBox.Show("You must enter select a status.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSoftwareVersion.Clear();
                        textBoxSoftwareVersion.Focus();
                        return;
                    }

                    // Input Validation
                    if (!ValidatorPOS.IsValidId(textBoxProductId.Text, 6))
                    {
                        MessageBox.Show("ID has to be 6-digits.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidVersion(textBoxSoftwareVersion.Text))
                    {
                        MessageBox.Show("Version does not seem to be valid.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSoftwareVersion.Clear();
                        textBoxSoftwareVersion.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidName(textBoxProductName.Text))
                    {
                        MessageBox.Show("Please enter a valid product name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductName.Clear();
                        textBoxProductName.Focus();
                        return;
                    }

                    //Assign textbox/ combobox data to object of type Software
                    s.ProductType = Convert.ToString(comboBoxProductType.SelectedItem).ToLower();
                    s.ProductNumber = Convert.ToInt32(textBoxProductId.Text);
                    s.ProductName = textBoxProductName.Text;
                    s.Status = Convert.ToString(comboBoxStatus.SelectedItem);
                    s.Price = textBoxPriceInventory.Text;
                    s.Version = textBoxSoftwareVersion.Text;
                    s.Os = Convert.ToString(comboBoxOS.SelectedItem).ToLower();
                    s.UpdateSoftware(s.ProductNumber, s);
                    listViewInventory.Items.Clear();
                    buttonListAllInventory_Click(sender, e);
                    break;
                case 1: // Book
                    textBoxProductId.Enabled = false;

                    Book b = new Book();

                    //Is empty
                    if (string.IsNullOrEmpty(textBoxProductId.Text)) // id
                    {
                        MessageBox.Show("You must enter product ID.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductName.Text)) // name
                    {
                        MessageBox.Show("You must enter product name.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductName.Clear();
                        textBoxProductName.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxPriceInventory.Text)) // price
                    {
                        MessageBox.Show("You must enter price.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPriceInventory.Clear();
                        textBoxPriceInventory.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxISBN.Text)) // ISBN
                    {
                        MessageBox.Show("You must enter ISBN number.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxISBN.Clear();
                        textBoxISBN.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxSupplier.Text)) // Supplier
                    {
                        MessageBox.Show("You must enter a supplier.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSupplier.Clear();
                        textBoxSupplier.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxYearPublished.Text)) // year published
                    {
                        MessageBox.Show("You must enter a year.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxYearPublished.Clear();
                        textBoxYearPublished.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxAuthorId.Text) || string.IsNullOrEmpty(textBoxFirstNameAuthor.Text) || string.IsNullOrEmpty(textBoxLastNameAuthor.Text)) // Author id
                    {
                        MessageBox.Show("You must complete Author's information.", "You forgot something!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxAuthorId.Clear();
                        textBoxAuthorId.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxQuantity.Text)) // year published
                    {
                        MessageBox.Show("You must enter a quantity.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxQuantity.Clear();
                        textBoxQuantity.Focus();
                        return;
                    }

                    //Validation
                    if (!ValidatorPOS.IsValidId(textBoxProductId.Text, 6)) // id
                    {
                        MessageBox.Show("ID has to be 6-digits.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductId.Clear();
                        textBoxProductId.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidTitle(textBoxProductName.Text)) // title
                    {
                        MessageBox.Show("Title does not seem to be valid.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductName.Clear();
                        textBoxProductName.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidMoney(textBoxPriceInventory.Text)) // author l name
                    {
                        MessageBox.Show("Please enter a valid price.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPriceInventory.Clear();
                        textBoxPriceInventory.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidTitle(textBoxSupplier.Text)) // supplier
                    {
                        MessageBox.Show("Please enter a valid supplier name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxSupplier.Clear();
                        textBoxSupplier.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidYear(textBoxYearPublished.Text)) // year 
                    {
                        MessageBox.Show("Please enter a valid year.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxYearPublished.Clear();
                        textBoxYearPublished.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidId(textBoxAuthorId.Text, 6)) // author id
                    {
                        MessageBox.Show("Please enter a valid author ID.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxAuthorId.Clear();
                        textBoxAuthorId.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidName(textBoxFirstNameAuthor.Text)) // author name
                    {
                        MessageBox.Show("Please enter a valid author name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxFirstNameAuthor.Clear();
                        textBoxFirstNameAuthor.Focus();
                        return;
                    }
                    if (!ValidatorPOS.IsValidName(textBoxLastNameAuthor.Text)) // author f name
                    {
                        MessageBox.Show("Please enter a valid author name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxLastNameAuthor.Clear();
                        textBoxLastNameAuthor.Focus();
                        return;
                    }

                    // Assign textbox/combobox data to object of type Book
                    b.ProductName = textBoxProductName.Text.ToLower();
                    b.ProductNumber = Convert.ToInt32(textBoxProductId.Text);
                    b.ProductType = Convert.ToString(comboBoxProductType.SelectedItem).ToLower();
                    b.Supplier = textBoxSupplier.Text;
                    b.Isbn = textBoxISBN.Text;
                    b.PublishedYear = Convert.ToInt32(textBoxYearPublished.Text);
                    b.UnitPrice = Convert.ToDecimal(textBoxPriceInventory.Text);
                    b.AuthorId = Convert.ToInt32(textBoxAuthorId.Text);
                    b.FirstName = textBoxFirstNameAuthor.Text;
                    b.LastName = textBoxLastNameAuthor.Text;
                    b.UpdateBook(b.ProductNumber, b);
                    listViewInventory.Items.Clear();
                    buttonListAllInventory_Click(sender, e);
                    break;
                default:
                    MessageBox.Show("Please select a type", "Error", MessageBoxButtons.OK);
                    break;
            }
        }

        private void textBoxSoftwareVersion_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelIdentifier_Click(object sender, EventArgs e)
        {

        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelProfileEmployeeId_Click(object sender, EventArgs e)
        {

        }

        private void labelProlifeId_Click(object sender, EventArgs e)
        {

        }

        private void labelProfileManager_Click(object sender, EventArgs e)
        {

        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }

        private void textBoxInput_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void labelSearchBy_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelEmployeeId_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmployeeId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelFirstName_Click(object sender, EventArgs e)
        {

        }

        private void labelLastName_Click(object sender, EventArgs e)
        {

        }

        private void tabSales_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBoxFaxNumberClient_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelCLients_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCreditLimitClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelCreditLimitClient_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelType_Click(object sender, EventArgs e)
        {

        }

        private void labelCityClient_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBoxPhoneNumberClient_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelPhoneNumberClient_Click(object sender, EventArgs e)
        {

        }

        private void labelProfileSalesId_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void labelProfileSales_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBoxInputClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void listViewClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSearchOptionClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPostalCodeClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNameClient_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxStreet_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelStreetClient_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxOS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPriceInventory_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelPriceInventory_Click(object sender, EventArgs e)
        {

        }

        private void labelProduct_Click(object sender, EventArgs e)
        {

        }

        private void labelVersionSoftware_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLastNameAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelLNAuthor_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFirstNameAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelFNAuthor_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAuthorId_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelAuthorId_Click(object sender, EventArgs e)
        {

        }

        private void textBoxYearPublished_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelYearP_Click(object sender, EventArgs e)
        {

        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSupplier_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelProductType_Click(object sender, EventArgs e)
        {

        }

        private void labelSupplier_Click(object sender, EventArgs e)
        {

        }

        private void labelQuantity_Click(object sender, EventArgs e)
        {

        }

        private void labelProfileInventoryId_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteInventory_Click(object sender, EventArgs e)
        {
            int index = comboBoxProductType.SelectedIndex;
            switch (index)
            {
                case 0: // software
                    Software s = new Software();

                    DialogResult ans = MessageBox.Show("Are you sure you want to delete this software?", "Confirm",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans == DialogResult.Yes)
                    {
                        s.DeleteSoftware(Convert.ToInt32(textBoxProductId.Text)) ;
                        MessageBox.Show("Software has been successfully deleted.", "Confirmation");
                        listViewClients.Items.Clear();
                    }
                    listViewInventory.Items.Clear();
                    buttonListAllInventory_Click(sender, e);
                    break;
                case 1: // book
                    Book b = new Book();

                    DialogResult ans2 = MessageBox.Show("Are you sure you want to delete this book?", "Confirm",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ans2 == DialogResult.Yes)
                    {
                        b.DeleteBook(Convert.ToInt32(textBoxProductId.Text));
                        MessageBox.Show("Book has been successfully deleted.", "Confirmation");
                        listViewClients.Items.Clear();
                    }
                    listViewInventory.Items.Clear();
                    buttonListAllInventory_Click(sender, e);
                    break;
                default:
                    break;
            }
            
        }

        private void textBoxInputInventory_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBoxProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelProductId_Click(object sender, EventArgs e)
        {

        }

        private void textBoxProductId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxISBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelProductName_Click(object sender, EventArgs e)
        {

        }

        private void labelISBN_Click(object sender, EventArgs e)
        {

        }

        private void tabOrders_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        // ORDER CLERK - Type Combobox
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTypeOrders.SelectedIndex;

            // if type was selected ...
            switch (index)
            {
                case 0:
                    labelProdType.Text = "Order for Software";

                    // Enable Textboxes/Combobox
                    textBoxOrderId.Enabled = true;
                    comboBoxStatusOrder.Enabled = true;
                    maskedTextBoxDateOrders.Enabled = true;
                    textBoxProductIdOrders.Enabled = true;

                    // Enable Buttons
                    buttonVerifyProd.Enabled = true;
                    buttonSearchOrders.Enabled = true;
                    break;

                    // get list of all produuct id's

                    //foreach (var item in collection) // for reach product id in List, add item
                    //{

                    //}

                case 1:
                    labelProdType.Text = "Order for Book";
                    labelPriceOrders.Text = "Price (Per Unit)";

                    // Enable Textboxes/Combobox
                    textBoxOrderId.Enabled =        true;
                    comboBoxStatusOrder.Enabled =   true;
                    maskedTextBoxDateOrders.Enabled = true;
                    textBoxProductIdOrders.Enabled = true;

                    // Enable Buttons
                    buttonVerifyProd.Enabled =      true;
                    buttonSearchOrders.Enabled =    true;
                    break;

                default:
                    break;
            }

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void labelOrdersId_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        // ORDER CLERK - Cancel Button 
        private void button11_Click(object sender, EventArgs e)
        {
            int index = comboBoxTypeOrders.SelectedIndex;

            switch (index)
            {
                case 0:
                    // If Textboxes/Comboboxes are null or empty, do not cancel.
                    if (string.IsNullOrEmpty(textBoxPriceOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Price empty.", "Empty");
                        textBoxPriceOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Order ID empty.", "Empty");
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    if (comboBoxStatusOrder.SelectedIndex == -1)
                    {
                        MessageBox.Show("Looks like you left the field for Status empty.", "Empty");
                        comboBoxStatusOrder.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(maskedTextBoxDateOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Order Date empty.", "Empty");
                        maskedTextBoxDateOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Product ID empty.", "Empty");
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxClientPostalC.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Postal Code empty.", "Empty");
                        textBoxClientPostalC.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxClientName.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Name empty.", "Empty");
                        textBoxClientName.Focus();
                        return;
                    }

                    // Cancel Order
                    Order anOrder = new Order();
                    anOrder.ProductType = Convert.ToString(comboBoxTypeOrders.SelectedItem).ToLower();
                    anOrder.OrderId = Convert.ToInt32(textBoxOrderId.Text);
                    anOrder.Price = Convert.ToDecimal(textBoxPriceOrders.Text);
                    anOrder.Status = Convert.ToString(comboBoxStatusOrder.SelectedItem);
                    anOrder.OrderDate = Convert.ToString(maskedTextBoxDateOrders.Text);
                    anOrder.ProductNumber = Convert.ToInt32(textBoxProductIdOrders.Text);
                    anOrder.Name = textBoxClientName.Text;
                    anOrder.PostalCode = textBoxClientPostalC.Text;

                    DialogResult ans = MessageBox.Show("Are you sure you want to cancel this order?", "Confirm",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (ans == DialogResult.Yes)
                    {
                        anOrder.CancelOrderSoftware(anOrder);
                        MessageBox.Show("Order has been cancelled.", "Confirmation");
                    }
                    listViewOrders.Items.Clear();
                    button15_Click(sender, e);
                    break;
                case 1:
                    // If Textboxes/Comboboxes are null or empty, do not cancel.
                    if (string.IsNullOrEmpty(textBoxPriceOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Price empty.", "Empty");
                        textBoxPriceOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Order ID empty.", "Empty");
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    if (comboBoxStatusOrder.SelectedIndex == -1)
                    {
                        MessageBox.Show("Looks like you left the field for Status empty.", "Empty");
                        comboBoxStatusOrder.Focus();
                        return;
                    }
                    if (comboBoxTypeOrders.SelectedIndex == -1)
                    {
                        MessageBox.Show("Looks like you left the field for Type empty.", "Empty");
                        comboBoxStatusOrder.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(maskedTextBoxDateOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Order Date empty.", "Empty");
                        maskedTextBoxDateOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Product ID empty.", "Empty");
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxClientPostalC.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Postal Code empty.", "Empty");
                        textBoxClientPostalC.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxClientName.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Name empty.", "Empty");
                        textBoxClientName.Focus();
                        return;
                    }

                    // Cancel Order
                    Order anOrder1 = new Order();
                    DialogResult ans1 = MessageBox.Show("Are you sure you want to cancel this order?", "Confirm",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (ans1 == DialogResult.Yes)
                    {
                        anOrder1.CancelOrderBook(anOrder1);
                        MessageBox.Show("Order has been cancelled.", "Confirmation");
                    }
                    listViewOrders.Items.Clear();
                    button15_Click(sender, e);
                    break;
                default:
                    break;
            }

            
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ORDER CLERK - Update Button
        private void button12_Click(object sender, EventArgs e)
        {
            Order anOrder = new Order();

            // If Textboxes/Comboboxes are null or empty, do not update.
            if (string.IsNullOrEmpty(textBoxPriceOrders.Text))
            {
                MessageBox.Show("Looks like you left the field for Price empty.", "Empty");
                textBoxPriceOrders.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
            {
                MessageBox.Show("Looks like you left the field for Order ID empty.", "Empty");
                textBoxProductIdOrders.Focus();
                return;
            }
            if (comboBoxStatusOrder.SelectedIndex == -1)
            {
                MessageBox.Show("Looks like you left the field for Status empty.", "Empty");
                comboBoxStatusOrder.Focus();
                return;
            }
            if (string.IsNullOrEmpty(maskedTextBoxDateOrders.Text))
            {
                MessageBox.Show("Looks like you left the field for Order Date empty.", "Empty");
                maskedTextBoxDateOrders.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
            {
                MessageBox.Show("Looks like you left the field for Product ID empty.", "Empty");
                textBoxProductIdOrders.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxClientPostalC.Text))
            {
                MessageBox.Show("Looks like you left the field for Postal Code empty.", "Empty");
                textBoxClientPostalC.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxClientName.Text))
            {
                MessageBox.Show("Looks like you left the field for Name empty.", "Empty");
                textBoxClientName.Focus();
                return;
            }

            // Validation
            if (!ValidatorPOS.IsValidId(textBoxOrderId.Text, 5))
            {
                MessageBox.Show("Invalid Order ID. Needs to be 5-digits.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }
            if (ValidatorPOS.OrderAlreadyExists(textBoxOrderId.Text))
            {
                MessageBox.Show("Order ID already exists, please choose a different one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }
            if (!ValidatorPOS.IsValidId(textBoxProductIdOrders.Text, 6))
            {
                MessageBox.Show("Invalid Product ID. Needs to be 6-digits.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProductIdOrders.Clear();
                textBoxProductIdOrders.Focus();
                return;
            }
            if (!ValidatorPOS.IsValidDate(maskedTextBoxDateOrders.Text))
            {
                MessageBox.Show("Invalid Date.(DD/MM/YYYY)", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxDateOrders.Clear();
                maskedTextBoxDateOrders.Focus();
                return;
            }
            if (!ValidatorPOS.IsValidName(textBoxClientName.Text))
            {
                MessageBox.Show("Invalid name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientName.Clear();
                textBoxClientName.Focus();
                return;
            }
            if (!ValidatorPOS.IsValidPostalCode(textBoxClientPostalC.Text.ToUpper()))
            {
                MessageBox.Show("Invalid postal code.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientPostalC.Clear();
                textBoxClientPostalC.Focus();
                return;
            }

            int index = comboBoxTypeOrders.SelectedIndex;

            switch (index)
            {
                case 0: // software
                    //Update
                    anOrder.ProductType = Convert.ToString(comboBoxTypeOrders.SelectedItem).ToLower();
                    anOrder.OrderId = Convert.ToInt32(textBoxOrderId.Text);
                    anOrder.Price = Convert.ToDecimal(textBoxPriceOrders.Text);
                    anOrder.Status = Convert.ToString(comboBoxStatusOrder.SelectedItem);
                    anOrder.OrderDate = Convert.ToString(maskedTextBoxDateOrders.Text);
                    anOrder.ProductNumber = Convert.ToInt32(textBoxProductIdOrders.Text);
                    anOrder.Name = textBoxClientName.Text;
                    anOrder.PostalCode = textBoxClientPostalC.Text;

                    DialogResult ans = MessageBox.Show("Are you sure you want to update this order?", "Confirm",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (ans == DialogResult.Yes)
                    {
                        anOrder.UpdateOrderSoftware(anOrder);
                        MessageBox.Show("Order has been successfully updated.", "Confirmation");
                    }

                    listViewOrders.Items.Clear();
                    button15_Click(sender, e);
                    break;
                case 1: // book
                    //Update
                    anOrder.ProductType = Convert.ToString(comboBoxTypeOrders.SelectedItem).ToLower();
                    anOrder.OrderId = Convert.ToInt32(textBoxOrderId.Text);
                    anOrder.Price = Convert.ToDecimal(textBoxPriceOrders.Text);
                    anOrder.Status = Convert.ToString(comboBoxStatusOrder.SelectedItem);
                    anOrder.OrderDate = Convert.ToString(maskedTextBoxDateOrders.Text);
                    anOrder.ProductNumber = Convert.ToInt32(textBoxProductIdOrders.Text);
                    anOrder.Name = textBoxClientName.Text;
                    anOrder.PostalCode = textBoxClientPostalC.Text;

                    DialogResult ans1 = MessageBox.Show("Are you sure you want to update this order?", "Confirm",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (ans1 == DialogResult.Yes)
                    {
                        anOrder.UpdateOrderBook(anOrder);
                        MessageBox.Show("Order has been successfully updated.", "Confirmation");
                    }

                    listViewOrders.Items.Clear();
                    button15_Click(sender, e);

                    break;
                default:
                    break;
            }

            

        }

        // ORDER CLERK - Order Button
        private void button13_Click(object sender, EventArgs e)
        {
            int index = comboBoxTypeOrders.SelectedIndex;

            Order o = new Order();

            switch (index)
            {
                case 0: // Software
                    // Check if box is empty
                    if (string.IsNullOrEmpty(textBoxPriceOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Price empty.", "Empty");
                        textBoxPriceOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Order ID empty.", "Empty");
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    if (comboBoxStatusOrder.SelectedIndex == -1)
                    {
                        MessageBox.Show("Looks like you left the field for Status empty.", "Empty");
                        comboBoxStatusOrder.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(maskedTextBoxDateOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Order Date empty.", "Empty");
                        maskedTextBoxDateOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Product ID empty.", "Empty");
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxClientPostalC.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Postal Code empty.", "Empty");
                        textBoxClientPostalC.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxClientName.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Name empty.", "Empty");
                        textBoxClientName.Focus();
                        return;
                    }

                    if (ValidatorPOS.OrderAlreadyExists(textBoxOrderId.Text))
                    {
                        MessageBox.Show("Order ID already exists, please choose a different one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxOrderId.Clear();
                        textBoxOrderId.Focus();
                        return;
                    }

                    Order anOrderS = new Order();
                    anOrderS.ProductType = Convert.ToString(comboBoxTypeOrders.SelectedItem);
                    anOrderS.ProductNumber = Convert.ToInt32(textBoxProductIdOrders.Text);
                    anOrderS.OrderId = Convert.ToInt32(textBoxOrderId.Text);
                    anOrderS.OrderDate = maskedTextBoxDateOrders.Text;
                    anOrderS.Status = Convert.ToString(comboBoxStatusOrder.SelectedItem);
                    anOrderS.PostalCode = textBoxClientPostalC.Text;
                    anOrderS.Name = textBoxClientName.Text;
                    anOrderS.Price = Convert.ToDecimal(textBoxPriceOrders.Text);

                    anOrderS.SaveOrderSoftware(anOrderS);
                    ClearAllOrders();
                    break;
                case 1: // Book
                    if (string.IsNullOrEmpty(textBoxPriceOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Price empty.", "Empty");
                        textBoxPriceOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Order ID empty.", "Empty");
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    if (comboBoxStatusOrder.SelectedIndex == -1)
                    {
                        MessageBox.Show("Looks like you left the field for Status empty.", "Empty");
                        comboBoxStatusOrder.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(maskedTextBoxDateOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Order Date empty.", "Empty");
                        maskedTextBoxDateOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Product ID empty.", "Empty");
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxClientPostalC.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Postal Code empty.", "Empty");
                        textBoxClientPostalC.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(textBoxClientName.Text))
                    {
                        MessageBox.Show("Looks like you left the field for Name empty.", "Empty");
                        textBoxClientName.Focus();
                        return;
                    }

                    // validation here
                    if (ValidatorPOS.OrderAlreadyExists(textBoxOrderId.Text))
                    {
                        MessageBox.Show("Order ID already exists, please choose a different one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxOrderId.Clear();
                        textBoxOrderId.Focus();
                        return;
                    }

                    Order anOrderB = new Order();
                    anOrderB.ProductType = Convert.ToString(comboBoxTypeOrders.SelectedItem);
                    anOrderB.ProductNumber = Convert.ToInt32(textBoxProductIdOrders.Text);
                    anOrderB.OrderId = Convert.ToInt32(textBoxOrderId.Text);
                    anOrderB.OrderDate = maskedTextBoxDateOrders.Text;
                    anOrderB.Status = Convert.ToString(comboBoxStatusOrder.SelectedItem);
                    anOrderB.PostalCode = textBoxClientPostalC.Text;
                    anOrderB.Name = textBoxClientName.Text;
                    anOrderB.Price = Convert.ToDecimal(textBoxPriceOrders.Text);
                    anOrderB.SaveOrderBook(anOrderB);
                    ClearAllOrders();

                    break;
                default:
                    break;
            }


            
        }

        // ORDER CLERK - Clear all boxes
        private void ClearAllOrders()
        {
            comboBoxTypeOrders.SelectedIndex = -1;
            textBoxProductIdOrders.Clear();
            textBoxOrderId.Clear();
            maskedTextBoxDateOrders.Clear();
            comboBoxStatusOrder.SelectedIndex = -1;
            textBoxClientPostalC.Clear();
            textBoxClientName.Clear();
            textBoxPriceOrders.Clear();
        }

        //ORDER CLERK - Search Button
        private void button14_Click(object sender, EventArgs e)
        {
            int index = comboBoxSearchOptionOrder.SelectedIndex;

            // validation here 

            List<Order> listO = new List<Order>();
            Order o = new Order();
            switch (index)
            {
                case 0: // order id
                    labelInputOrder.Text = "Enter ID";

                    listO = o.ListByOrderId(textBoxInputOrder.Text);
                    if (listO != null)
                    {
                        listViewOrders.Items.Clear();
                        foreach (Order oTemp in listO)
                        {
                            ListViewItem item = new ListViewItem(oTemp.ProductType);
                            item.SubItems.Add(oTemp.OrderId.ToString());
                            item.SubItems.Add(oTemp.Price.ToString());
                            item.SubItems.Add(oTemp.Status);
                            item.SubItems.Add(oTemp.OrderDate);
                            item.SubItems.Add(oTemp.ProductNumber.ToString());
                            item.SubItems.Add(oTemp.ProductName);
                            item.SubItems.Add(oTemp.Name);
                            item.SubItems.Add(oTemp.PhoneNumber);
                            item.SubItems.Add(oTemp.FaxNumber);
                            item.SubItems.Add(oTemp.PostalCode);

                            listViewOrders.Items.Add(item);

                        }
                    }
                    break;
                case 1: // product id
                    labelInputOrder.Text = "Product ID";

                    listO = o.ListByProductId(textBoxInputOrder.Text);
                    if (listO != null)
                    {
                        listViewOrders.Items.Clear();
                        foreach (Order oTemp in listO)
                        {
                            ListViewItem item = new ListViewItem(oTemp.ProductType);
                            item.SubItems.Add(oTemp.OrderId.ToString());
                            item.SubItems.Add(oTemp.Price.ToString());
                            item.SubItems.Add(oTemp.Status);
                            item.SubItems.Add(oTemp.OrderDate);
                            item.SubItems.Add(oTemp.ProductNumber.ToString());
                            item.SubItems.Add(oTemp.ProductName);
                            item.SubItems.Add(oTemp.Name);
                            item.SubItems.Add(oTemp.PhoneNumber);
                            item.SubItems.Add(oTemp.FaxNumber);
                            item.SubItems.Add(oTemp.PostalCode);

                            listViewOrders.Items.Add(item);

                        }
                    }
                    break;
                case 2: // status
                    labelInputOrder.Text = "Enter Status";

                    listO = o.ListByStatus(textBoxInputOrder.Text);
                    if (listO != null)
                    {
                        listViewOrders.Items.Clear();
                        foreach (Order oTemp in listO)
                        {
                            ListViewItem item = new ListViewItem(oTemp.ProductType);
                            item.SubItems.Add(oTemp.OrderId.ToString());
                            item.SubItems.Add(oTemp.Price.ToString());
                            item.SubItems.Add(oTemp.Status);
                            item.SubItems.Add(oTemp.OrderDate);
                            item.SubItems.Add(oTemp.ProductNumber.ToString());
                            item.SubItems.Add(oTemp.ProductName);
                            item.SubItems.Add(oTemp.Name);
                            item.SubItems.Add(oTemp.PhoneNumber);
                            item.SubItems.Add(oTemp.FaxNumber);
                            item.SubItems.Add(oTemp.PostalCode);

                            listViewOrders.Items.Add(item);

                        }
                    }
                    break;
                case 3: // product type
                    labelInputOrder.Text = "Select Type";

                    listO = o.ListByProductType(textBoxInputOrder.Text);

                    if (listO != null)
                    {
                        listViewOrders.Items.Clear();
                        foreach (Order oTemp in listO)
                        {
                            ListViewItem item = new ListViewItem(oTemp.ProductType);
                            item.SubItems.Add(oTemp.OrderId.ToString());
                            item.SubItems.Add(oTemp.Price.ToString());
                            item.SubItems.Add(oTemp.Status);
                            item.SubItems.Add(oTemp.OrderDate);
                            item.SubItems.Add(oTemp.ProductNumber.ToString());
                            item.SubItems.Add(oTemp.ProductName);
                            item.SubItems.Add(oTemp.Name);
                            item.SubItems.Add(oTemp.PhoneNumber);
                            item.SubItems.Add(oTemp.FaxNumber);
                            item.SubItems.Add(oTemp.PostalCode);

                            listViewOrders.Items.Add(item);

                        }
                    }
                    break;
                case 4: // postal code
                    labelInputOrder.Text = "Postal Code";

                    listO = o.ListByPostalC(textBoxInputOrder.Text);
                    if (listO != null)
                    {
                        listViewOrders.Items.Clear();
                        foreach (Order oTemp in listO)
                        {
                            ListViewItem item = new ListViewItem(oTemp.ProductType);
                            item.SubItems.Add(oTemp.OrderId.ToString());
                            item.SubItems.Add(oTemp.Price.ToString());
                            item.SubItems.Add(oTemp.Status);
                            item.SubItems.Add(oTemp.OrderDate);
                            item.SubItems.Add(oTemp.ProductNumber.ToString());
                            item.SubItems.Add(oTemp.ProductName);
                            item.SubItems.Add(oTemp.Name);
                            item.SubItems.Add(oTemp.PhoneNumber);
                            item.SubItems.Add(oTemp.FaxNumber);
                            item.SubItems.Add(oTemp.PostalCode);

                            listViewOrders.Items.Add(item);

                        }
                    }
                    break;
                case 5: // client name 
                    labelInputOrder.Text = "Enter Name";

                    listO = o.ListByName(textBoxInputOrder.Text);
                    if (listO != null)
                    {
                        listViewOrders.Items.Clear();
                        foreach (Order oTemp in listO)
                        {
                            ListViewItem item = new ListViewItem(oTemp.ProductType);
                            item.SubItems.Add(oTemp.OrderId.ToString());
                            item.SubItems.Add(oTemp.Price.ToString());
                            item.SubItems.Add(oTemp.Status);
                            item.SubItems.Add(oTemp.OrderDate);
                            item.SubItems.Add(oTemp.ProductNumber.ToString());
                            item.SubItems.Add(oTemp.ProductName);
                            item.SubItems.Add(oTemp.Name);
                            item.SubItems.Add(oTemp.PhoneNumber);
                            item.SubItems.Add(oTemp.FaxNumber);
                            item.SubItems.Add(oTemp.PostalCode);

                            listViewOrders.Items.Add(item);

                        }
                    }
                    break;
                default:
                    break;
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            List<Order> listO = o.ListAllOrders();
            o.ListViewAllOrder(listViewOrders, listO);
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void textBoxInputUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelIdentifierUser_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPasswordUser_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void labelPasswordUser_Click(object sender, EventArgs e)
        {

        }

        private void labelUserId_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabManager_Click(object sender, EventArgs e)
        {

        }

        // ORDER CLERK - Verify Button
        private void buttonVerifyProd_Click(object sender, EventArgs e)
        {
            Order o = new Order();

            int index = comboBoxTypeOrders.SelectedIndex;

            // Verify if anything is empty
            if (string.IsNullOrEmpty(textBoxOrderId.Text))
            {
                MessageBox.Show("Looks like you left the field for order ID empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Focus();
                return;
            }
            if (comboBoxStatusOrder.SelectedIndex == -1)
            {
                MessageBox.Show("Looks like you left the field for Status empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProductIdOrders.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxProductIdOrders.Text))
            {
                MessageBox.Show("Looks like you left the field for product ID empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProductIdOrders.Focus();
                return;
            }

            // ID validation
            if (!ValidatorPOS.IsValidId(textBoxOrderId.Text, 5))
            {
                MessageBox.Show("Invalid Order ID. Needs to be 5-digits.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }
            if (ValidatorPOS.OrderAlreadyExists(textBoxOrderId.Text))
            {
                MessageBox.Show("Order ID already exists, please choose a different one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
                return;
            }
            if (o.OrderExists(textBoxOrderId.Text))
            {
                MessageBox.Show("Order ID already exists!", "Exists");
                textBoxOrderId.Clear();
                textBoxOrderId.Focus();
            }
            if (!ValidatorPOS.IsValidId(textBoxProductIdOrders.Text, 6))
            {
                MessageBox.Show("Invalid Product ID. Needs to be 6-digits.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxProductIdOrders.Clear();
                textBoxProductIdOrders.Focus();
                return;
            }
            if (!ValidatorPOS.IsValidDate(maskedTextBoxDateOrders.Text))
            {
                MessageBox.Show("Invalid Date.(DD/MM/YYYY)", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxDateOrders.Clear();
                maskedTextBoxDateOrders.Focus();
                return;
            }


            switch (index)
            {
                case 0:
                    // if nothing is empty, verify software
                    if (o.VerifySoftware(Convert.ToInt32(textBoxProductIdOrders.Text)))
                    {
                        buttonVerifyProd.Text = "Verified";
                        textBoxPriceOrders.Text = o.SearchPrice(Convert.ToInt32(textBoxProductIdOrders.Text));
                        textBoxClientPostalC.Enabled = true;
                        textBoxClientName.Enabled = true;
                        buttonVerifyClientO.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Make sure the product type matches the product type of the product ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductIdOrders.Clear();
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    break;
                case 1:
                    // if nothing is empty, cverify software
                    if (o.VerifyBook(Convert.ToInt32(textBoxProductIdOrders.Text)))
                    {
                        buttonVerifyProd.Text = "Verified";
                        textBoxPriceOrders.Text = o.SearchPrice(Convert.ToInt32(textBoxProductIdOrders.Text));
                        textBoxClientPostalC.Enabled = true;
                        textBoxClientName.Enabled = true;
                        buttonVerifyClientO.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Make sure the product type matches the product type of the product ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxProductIdOrders.Clear();
                        textBoxProductIdOrders.Focus();
                        return;
                    }
                    break;
                default:
                    break;
            }

            

            
        }

        // ORDER CLERK - verify button - client
        private void buttonVerifyClientO_Click(object sender, EventArgs e)
        {
            Order o = new Order();

            // If empty
            if (string.IsNullOrEmpty(textBoxClientPostalC.Text))
            {
                MessageBox.Show("Looks like you left the field for order ID empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientPostalC.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxClientName.Text))
            {
                MessageBox.Show("Looks like you left the field for order ID empty.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientName.Focus();
                return;
            }

            // Valiidation
            if (!ValidatorPOS.IsValidName(textBoxClientName.Text))
            {
                MessageBox.Show("Invalid Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNameClient.Clear();
                textBoxNameClient.Focus();
                return;
            }
            if (!ValidatorPOS.IsValidPostalCode(textBoxClientPostalC.Text.ToUpper()))
            {
                MessageBox.Show("Invalid Postal Code.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientPostalC.Clear();
                textBoxClientPostalC.Focus();
                return;
            }

            // if nothing is empty or invalid, verify client
            if (o.VerifyClient(textBoxClientPostalC.Text, textBoxClientName.Text))
            {
                buttonVerifyClientO.Text =      "Verified";
                //textBoxPriceOrders.Enabled =    true;
                buttonOrder.Enabled =           true;

            }
            else
            {
                MessageBox.Show("I couldn't find this client. Verify that there are no spelling mistakes and try again.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientPostalC.Clear();
                textBoxClientName.Clear();
                textBoxClientPostalC.Focus();
                return;
            }
        }

        private void comboBoxInputSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxStatusOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // button refresh
        private void button1_Click(object sender, EventArgs e)
        {
            ClearAllOrders();
        }

        // ORDER CLERK - product id combobox
        private void comboBoxProductIdOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listViewEmployee_ColumnClick(object sender, ColumnClickEventArgs e)
        {
        }

        private void listViewEmployee_MouseClick(object sender, MouseEventArgs e)
        {
            String empId = listViewEmployee.SelectedItems[0].SubItems[0].Text;
            String identifier = listViewEmployee.SelectedItems[0].SubItems[1].Text;
            String lastName = listViewEmployee.SelectedItems[0].SubItems[2].Text;
            String firstName = listViewEmployee.SelectedItems[0].SubItems[3].Text;
            String phoneNumber = listViewEmployee.SelectedItems[0].SubItems[4].Text;
            String email = listViewEmployee.SelectedItems[0].SubItems[5].Text;

            textBoxEmployeeId.Text = empId;
            if (identifier == "Manager")
            {
                comboBoxIdentifier.SelectedIndex = 0;
            }
            if (identifier == "Sales")
            {
                comboBoxIdentifier.SelectedIndex = 1;
            }
            if (identifier == "Inventory")
            {
                comboBoxIdentifier.SelectedIndex = 2;
            }
            if (identifier == "Orders")
            {
                comboBoxIdentifier.SelectedIndex = 3;
            }
            comboBoxIdentifier.Text = identifier;
            textBoxLastName.Text = lastName;
            textBoxFirstName.Text = firstName;
            maskedTextBoxPhoneNumber.Text = phoneNumber;
            textBoxEmail.Text = email;

            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;

        }

        private void listViewClients_MouseClick(object sender, MouseEventArgs e)
        {
            String type = listViewClients.SelectedItems[0].SubItems[0].Text;
            String name = listViewClients.SelectedItems[0].SubItems[1].Text;
            String street = listViewClients.SelectedItems[0].SubItems[2].Text;
            String city = listViewClients.SelectedItems[0].SubItems[3].Text;
            String postalcode = listViewClients.SelectedItems[0].SubItems[4].Text;
            String phoneN = listViewClients.SelectedItems[0].SubItems[5].Text;
            String faxN = listViewClients.SelectedItems[0].SubItems[6].Text;
            String creditL = listViewClients.SelectedItems[0].SubItems[7].Text;

            if (type == "university".ToLower())
            {
                comboBoxTypeClient.SelectedIndex = 0;
            }
            if (type == "college".ToLower())
            {
                comboBoxTypeClient.SelectedIndex = 1;
            }

            textBoxNameClient.Text = name;
            textBoxStreet.Text = street;
            textBoxCity.Text = city;
            textBoxPostalCodeClient.Text = postalcode;
            maskedTextBoxPhoneNumberClient.Text = phoneN;
            maskedTextBoxFaxNumberClient.Text = faxN;
            textBoxCreditLimitClient.Text = creditL;

            buttonUpdateClient.Enabled = true;
            buttonDeleteClient.Enabled = true;

        }

        private void listViewInventory_MouseClick(object sender, MouseEventArgs e)
        {
            int index = comboBoxProductType.SelectedIndex;

            switch (index)
            {
                case 0:
                    String type = listViewInventory.SelectedItems[0].SubItems[0].Text;
                    String pId = listViewInventory.SelectedItems[0].SubItems[1].Text;
                    String price = listViewInventory.SelectedItems[0].SubItems[2].Text;
                    String title = listViewInventory.SelectedItems[0].SubItems[3].Text;
                    String version = listViewInventory.SelectedItems[0].SubItems[4].Text;
                    String status = listViewInventory.SelectedItems[0].SubItems[5].Text;
                    String os = listViewInventory.SelectedItems[0].SubItems[6].Text;

                    if (type.ToLower() == "software")
                    {
                        comboBoxProductType.SelectedIndex = 0;
                    }
                    if (type.ToLower() == "book")
                    {
                        comboBoxProductType.SelectedIndex = 1;
                    }
                    
                    textBoxProductId.Text = pId;
                    textBoxPriceInventory.Text = price;
                    textBoxProductName.Text = title;
                    textBoxSoftwareVersion.Text = version;

                    if (status.ToLower() == "active")
                    {
                        comboBoxStatus.SelectedIndex = 0;
                    }
                    if (status.ToLower() == "inactive")
                    {
                        comboBoxStatus.SelectedIndex = 0;
                    }

                    if (os.ToLower() == "macos")
                    {
                        comboBoxOS.SelectedIndex = 0;
                    }
                    if (os.ToLower() == "microsoft windows")
                    {
                        comboBoxOS.SelectedIndex = 1;
                    }
                    if (os.ToLower() == "windows 10")
                    {
                        comboBoxOS.SelectedIndex = 2;
                    }
                    if (os.ToLower() == "windows 8")
                    {
                        comboBoxOS.SelectedIndex = 3;
                    }
                    if (os.ToLower() == "windows 7")
                    {
                        comboBoxOS.SelectedIndex = 4;
                    }
                    if (os.ToLower() == "windows vista")
                    {
                        comboBoxOS.SelectedIndex = 5;
                    }
                    if (os.ToLower() == "windows xp")
                    {
                        comboBoxOS.SelectedIndex = 6;
                    }
                    if (os.ToLower() == "windows 2000")
                    {
                        comboBoxOS.SelectedIndex = 7;
                    }
                    if (os.ToLower() == "linux")
                    {
                        comboBoxOS.SelectedIndex = 8;
                    }
                    if (os.ToLower() == "linux kernal")
                    {
                        comboBoxOS.SelectedIndex = 9;
                    }
                    if (os.ToLower() == "unix")
                    {
                        comboBoxOS.SelectedIndex = 10;
                    }
                    if (os.ToLower() == "centos")
                    {
                        comboBoxOS.SelectedIndex = 11;
                    }
                    if (os.ToLower() == "chrome")
                    {
                        comboBoxOS.SelectedIndex = 12;
                    }
                    else
                    {
                        comboBoxOS.SelectedIndex = -1;
                    }

                    buttonUpdateInventory.Enabled = true;
                    buttonDeleteInventory.Enabled = true;

                    break;
                case 1:

                    String type1 =  listViewInventory.SelectedItems[0].SubItems[0].Text;
                    String pId1 =   listViewInventory.SelectedItems[0].SubItems[1].Text;
                    String price1 = listViewInventory.SelectedItems[0].SubItems[2].Text;
                    String title1 = listViewInventory.SelectedItems[0].SubItems[3].Text;
                    String isbn =   listViewInventory.SelectedItems[0].SubItems[4].Text;
                    String supplier = listViewInventory.SelectedItems[0].SubItems[5].Text;
                    String yearP =  listViewInventory.SelectedItems[0].SubItems[6].Text;
                    String authId = listViewInventory.SelectedItems[0].SubItems[7].Text;
                    String authFN = listViewInventory.SelectedItems[0].SubItems[8].Text;
                    String authLN = listViewInventory.SelectedItems[0].SubItems[9].Text;
                    string quant = listViewInventory.SelectedItems[0].SubItems[10].Text;

                    if (type1.ToLower() == "software")
                    {
                        comboBoxProductType.SelectedIndex = 0;
                    }
                    if (type1.ToLower() == "book")
                    {
                        comboBoxProductType.SelectedIndex = 1;
                    }
                    
                    textBoxProductId.Text = pId1;
                    textBoxPriceInventory.Text = price1;
                    textBoxYearPublished.Text = yearP;
                    textBoxSupplier.Text = supplier;
                    textBoxAuthorId.Text = authId;
                    textBoxFirstNameAuthor.Text = authFN;
                    textBoxISBN.Text = isbn;
                    textBoxProductName.Text = title1;
                    textBoxQuantity.Text = quant;
                    textBoxLastNameAuthor.Text = authLN;

                    buttonUpdateInventory.Enabled = true;
                    buttonDeleteInventory.Enabled = true;
                    break;
                default:
                    break;
            }

        }

        private void listViewOrders_MouseClick(object sender, MouseEventArgs e)
        {
            String type = listViewOrders.SelectedItems[0].SubItems[0].Text;
            String oId = listViewOrders.SelectedItems[0].SubItems[1].Text;
            String price = listViewOrders.SelectedItems[0].SubItems[2].Text;
            String status = listViewOrders.SelectedItems[0].SubItems[3].Text;
            String dateorder = listViewOrders.SelectedItems[0].SubItems[4].Text;
            String prodId = listViewOrders.SelectedItems[0].SubItems[5].Text;
            String cName = listViewOrders.SelectedItems[0].SubItems[7].Text;
            String postalC = listViewOrders.SelectedItems[0].SubItems[10].Text;

            if (type.ToLower() == "software")
            {
                comboBoxTypeOrders.SelectedIndex = 0;
            }
            if (type.ToLower() == "book")
            {
                comboBoxTypeOrders.SelectedIndex = 1;
            }

            textBoxOrderId.Text = oId;
            textBoxPriceOrders.Text = price;

            if (status.ToLower() == "processing")
            {
                comboBoxStatusOrder.SelectedIndex = 0;
            }
            if (status.ToLower() == "cancelled")
            {
                comboBoxStatusOrder.SelectedIndex = 1;
            }
            //else
            //{
            //    comboBoxStatusOrder.SelectedIndex = -1;
            //}

            maskedTextBoxDateOrders.Text = dateorder;
            textBoxProductIdOrders.Text = prodId;
            textBoxClientPostalC.Text = postalC;
            textBoxClientName.Text = cName;
            textBoxClientPostalC.Text = postalC;

            buttonUpdateOrder.Enabled = true;
            buttonCancel.Enabled = true;

        }

        private void listViewUser_MouseClick(object sender, MouseEventArgs e)
        {
            String uId = listViewUser.SelectedItems[0].SubItems[0].Text;
            String ident = listViewUser.SelectedItems[0].SubItems[1].Text;
            String pass = listViewUser.SelectedItems[0].SubItems[2].Text;

            textBoxUserId.Text = uId;
            if (ident.ToLower() == "manager")
            {
                comboBoxIdentifierUser.SelectedIndex = 0;
            }
            if (ident.ToLower() == "sales")
            {
                comboBoxIdentifierUser.SelectedIndex = 1;
            }
            if (ident.ToLower() == "inventory")
            {
                comboBoxIdentifierUser.SelectedIndex = 2;
            }
            if (ident.ToLower() == "orders")
            {
                comboBoxIdentifierUser.SelectedIndex = 3;
            }
            textBoxPasswordUser.Text = pass;

            buttonUpdateUser.Enabled = true;
            buttonDeleteUser.Enabled = true;


        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            // Delete Order
            Order anOrder = new Order();
            DialogResult ans = MessageBox.Show("Are you sure you want to delete this order?", "Confirm",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                anOrder.DeleteOrder(textBoxOrderId.Text);
                MessageBox.Show("Order has been deleted.", "Confirmation");
            }
            listViewOrders.Items.Clear();
            button15_Click(sender, e);
        }
    }
}
