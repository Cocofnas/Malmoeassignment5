namespace Malmoinl5
{
    public class Contact
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Phone Phone { get; set; } = new Phone { HomePhone = "HomePhonePlaceholder", CellPhone = "CellPhonePlaceholder" };
        public Email Email { get; set; } = new Email { BusinessEmail = "BusinessEmailPlaceholder", PrivateEmail = "PrivateEmailPlaceholder" };
        public Address Address { get; set; } = new Address();
    }
}
