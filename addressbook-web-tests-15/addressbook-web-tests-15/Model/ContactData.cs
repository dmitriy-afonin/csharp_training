using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string allPhones;
        private string allEmails;
        private string contactInformationDetails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData()
        {
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if ((Firstname.Equals(other.Firstname)) && Lastname.Equals(other.Lastname))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + "\nlastname=" + Lastname + "\naddress=" + Address +
                "\nmemail= " + Email + "\nhemail2= " + Email2 + "\nwemail3= " + Email3 +
                "\nmphone= " + MobilePhone + "\nhphone= " + HomePhone + "\nwphone= " + WorkPhone;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondaryPhone)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanUpEmails(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }

        public string Homepage { get; set; }

        public string Byear { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string SecondaryPhone { get; set; }

        public string Notes { get; set; }

        public string Id { get; set; }

        public string ContactInformationDetails
        {
            get
            {
                if (contactInformationDetails != null)
                {
                    return contactInformationDetails;
                }
                else
                {
                    return (
                        EndStringInsert(EndStringInsert(ContactInfoList(Firstname, Lastname, Address)))
                        + EndStringInsert(EndStringInsert(GetPhoneList(HomePhone, MobilePhone, WorkPhone)))
                        + EndStringInsert(EndStringInsert(GetEmailList(Email, Email2, Email3)))).Trim();
                }
            }
            set
            {
                contactInformationDetails = value;
            }
        }

        private string EndStringInsert(string entry)
        {
            if (entry == null || entry == "")
            {
                return "";
            }
            return entry + "\r\n";
        }

        private string GetNameFull(string firstname, string lastname)
        {
            string bufer = "";
            if (firstname != null && firstname != "")
            {
                bufer = bufer + Firstname + " ";
            }
            if (lastname != null && lastname != "")
            {
                bufer = bufer + Lastname + " ";
            }
            return bufer.Trim();
        }

        private string GetPhoneList(string homePhone, string mobilePhone, string workPhone)
        {
            string bufer = "";
            if (homePhone != null && homePhone != "")
            {
                bufer = bufer + "H: " + EndStringInsert(HomePhone);
            }
            if (mobilePhone != null && mobilePhone != "")
            {
                bufer = bufer + "M: " + EndStringInsert(MobilePhone);
            }
            if (workPhone != null && workPhone != "")
            {
                bufer = bufer + "W: " + EndStringInsert(WorkPhone);
            }
            return bufer.Trim();
        }

        private string GetEmailList(string email, string email2, string email3)
        {
            string bufer = "";
            if (email != null && email != "")
            {
                bufer = bufer + EndStringInsert(email);
            }
            if (email2 != null && email2 != "")
            {
                bufer = bufer + EndStringInsert(email2);
            }
            if (email3 != null && email3 != "")
            {
                bufer = bufer + EndStringInsert(email3);
            }
            return bufer.Trim();
        }

        private string ContactInfoList(string firstname, string lastname, string address)
        {
            return EndStringInsert(GetNameFull(firstname, lastname))
                + EndStringInsert(address).Trim();
        }
    }
}
