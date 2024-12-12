using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Malmoinl5
{
    public partial class ContactForm : Form
    {
        public Customer? CustomerData { get; private set; }

        public ContactForm()
        {
            InitializeComponent();
            btnContactOK.DialogResult = DialogResult.OK;
            button1.DialogResult = DialogResult.Cancel;

            // Populate countries ComboBox with example values
            cmbBoxCountries.Items.AddRange(new string[] {
                "Sweden", "Albania", "Andorra", "Austria", "Australia", "Belarus", "Belgium",
                "Bosnia and Herzegovina", "Bulgaria", "Canada", "Croatia", "Cyprus",
                "Czechia (Czech Republic)", "Denmark", "Estonia", "Finland", "France",
                "Germany", "Greece", "Hungary", "Iceland", "Ireland", "Italy", "Latvia",
                "Lithuania", "Luxembourg", "Malta", "Moldova", "Monaco", "Montenegro",
                "Netherlands", "North Macedonia", "Norway", "Poland", "Portugal",
                "Romania", "San Marino", "Serbia", "Slovakia", "Slovenia", "Spain",
                "Switzerland", "Ukraine", "United Kingdom", "United States"
            });
        }

        public ContactForm(Customer customer) : this()
        {
            CustomerData = customer ?? throw new ArgumentNullException(nameof(customer));

            // Populate the form fields with existing customer data
            txtBoxFirstName.Text = customer.ContactDetails.FirstName;
            txtBoxLastName.Text = customer.ContactDetails.LastName;
            txtBoxHomePhone.Text = customer.ContactDetails.Phone.HomePhone;
            txtBoxCellPhone.Text = customer.ContactDetails.Phone.CellPhone;
            txtBoxEmailBusiness.Text = customer.ContactDetails.Email.BusinessEmail;
            txtBoxEmailPrivate.Text = customer.ContactDetails.Email.PrivateEmail;
            txtBoxStreet.Text = customer.ContactDetails.Address.Street;
            txtBoxCity.Text = customer.ContactDetails.Address.City;
            TxtBoxZipCode.Text = customer.ContactDetails.Address.ZipCode;
            cmbBoxCountries.SelectedItem = customer.ContactDetails.Address.Country;
        }

        public Customer GetCustomerData()
        {
            if (string.IsNullOrWhiteSpace(txtBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxLastName.Text) ||
                string.IsNullOrWhiteSpace(txtBoxCity.Text) ||
                string.IsNullOrWhiteSpace(cmbBoxCountries.Text))
            {
                MessageBox.Show("Please fill out all required fields (First Name, Last Name, City, Country).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None; // Prevent form from closing
                return null!;
            }

            // Update existing CustomerData or create a new instance
            if (CustomerData == null)
            {
                CustomerData = new Customer
                {
                    ID = Guid.NewGuid().ToString(),
                    ContactDetails = new Contact()
                };
            }

            // Populate CustomerData with updated information from form fields
            CustomerData.ContactDetails.FirstName = txtBoxFirstName.Text;
            CustomerData.ContactDetails.LastName = txtBoxLastName.Text;
            CustomerData.ContactDetails.Phone.HomePhone = txtBoxHomePhone.Text;
            CustomerData.ContactDetails.Phone.CellPhone = txtBoxCellPhone.Text;
            CustomerData.ContactDetails.Email.BusinessEmail = txtBoxEmailBusiness.Text;
            CustomerData.ContactDetails.Email.PrivateEmail = txtBoxEmailPrivate.Text;
            CustomerData.ContactDetails.Address.Street = txtBoxStreet.Text;
            CustomerData.ContactDetails.Address.City = txtBoxCity.Text;
            CustomerData.ContactDetails.Address.ZipCode = TxtBoxZipCode.Text;
            CustomerData.ContactDetails.Address.Country = cmbBoxCountries.Text;

            return CustomerData;
        }
    }
}

