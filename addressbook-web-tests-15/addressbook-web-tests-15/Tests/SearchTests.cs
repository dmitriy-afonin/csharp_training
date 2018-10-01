using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void SearchTest()
        {
            app.Navigator.OpenHomePage();
            int fromNumberOfResults = app.Contacts.GetNumberOfSearchResults();
            app.Contacts.FillSearchField("Lastname");
            int fromTable = app.Contacts.GetContactCount();

            // verification
            Assert.AreEqual(fromNumberOfResults, fromTable);
        }
    }
}
