/**
 * Author: Manikandan M
 */

namespace CSharpOOPS_Concept_Programs
{
    public class Company
    {
        public static string GetCompanyName()
        {
            return "ABC";
        }

        public virtual string getOfficeTiming()
        {
            return "9.00 AM - 05.30 PM";
        }

        public string GetCompanyPolicy()
        {
            return "We're committed to an Open Internet........."
                + "We respect our customers privacy................";
        }
    }
    public class HeadOffice: Company
    {
        public static string HeadOfficeAddress()
        {
            return "US";
        }

        public override string getOfficeTiming()
        {
            return "11.00 AM - 08.00 PM";
        }
    }
    public class BranchOffice1: HeadOffice
    {
        public static string BranchOfficeAddress()
        {
            return "Pune";
        }
        public override string getOfficeTiming()
        {
            return "10.00 AM - 06.30 PM";
        }
    }
    public class BranchOffice2: HeadOffice
    {
        public static string BranchOfficeAddress()
        {
            return "Chennai";
        }
        public override string getOfficeTiming()
        {
            return "09.30 AM - 06.00 PM";
        }
        public static string getInChargeDetail()
        {
            return "Ravi Varman";
        }
        public static string getInChargeDetail(string inchargeName)
        {
            return inchargeName;
        }
    }
    public class BranchOffice3: HeadOffice
    {
        public static string BranchOfficeAddress()
        {
            return "Trichy";
        }
        public override string getOfficeTiming()
        {
            return "09.30 AM - 06.00 PM";
        }
    }
}
