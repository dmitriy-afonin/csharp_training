using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("FN", "LN");
            contact.Middlename = "MN";
            contact.Title = "TT";
            contact.Company = "Com";
            contact.Address = "Addr";
            contact.Home = "HH";
            contact.Mobile = "MM";
            contact.Work = "WW";
            contact.Fax = "FF";
            contact.Email = "E1";
            contact.Email2 = "E2";
            contact.Email3 = "E3";
            contact.Homepage = "HP";
            contact.Byear = "BB";
            contact.Ayear = "AA";
            contact.Address2 = "Addr2";
            contact.Phone2 = "Ph2";
            contact.Notes = "NN";
            
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Middlename = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

