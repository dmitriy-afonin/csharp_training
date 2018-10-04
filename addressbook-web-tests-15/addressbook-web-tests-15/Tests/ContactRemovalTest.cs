using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("FFF", "LLL");
            contact.Middlename = "MMM";

            app.Navigator.OpenHomePage();

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
                app.Navigator.OpenHomePage();
            }

            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Remove(contact, 0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactRemoved in newContacts)
            {
                Assert.AreNotEqual(contactRemoved.Id, toBeRemoved.Id);
            }
        }
    }
}
