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
            ContactData contact = new ContactData("FFF", "LLL");
            contact.Middlename = "MMM";

            ContactData newData = new ContactData("Firstname", "Lastname");
            newData.Middlename = "Middlename";

            app.Navigator.OpenHomePage();

            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
                app.Navigator.OpenHomePage();
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(contact, 0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactModifed in newContacts)
            {
                if (contactModifed.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contactModifed.Firstname);
                }
            }
        }
    }
}
