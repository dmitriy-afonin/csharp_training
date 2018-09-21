using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("FN");
            contact.Middlename = "MN";
            contact.Lastname = "LN";
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
            app.Contacts.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";
            app.Contacts.Create(contact);
        }
    }
}

