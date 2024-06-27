using System;

namespace LegacyApp
{
    public class User
    {
        public Client Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public User(Client client, DateTime dateOfBirth, String emailAddress, String firstName, String lastName)
        {
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            CheckClientType();
        }

        private void CheckClientType()
        {
            switch (Client.Type)
            {
                case "VeryImportantClient":
                    HasCreditLimit = false;
                    break;
                case "ImportantClient":
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                        creditLimit = creditLimit * 2;
                        CreditLimit = creditLimit;
                    }
                    break;
                default:
                    HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        int creditLimit = userCreditService.GetCreditLimit(LastName, DateOfBirth);
                        CreditLimit = creditLimit;
                    }
                    break;
            }
        }
        
    }
}