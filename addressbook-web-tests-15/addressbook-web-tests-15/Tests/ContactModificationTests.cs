using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("FFF");
            contact.Middlename = "MMM";
            contact.Lastname = "LLL";

            ContactData newData = new ContactData("Firstname");
            newData.Middlename = "Middlename";
            newData.Lastname = "Lastname";

            app.Contacts.Modify(contact, 1, newData);
        }
    }
}
