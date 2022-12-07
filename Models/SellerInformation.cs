using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_PersonalPage.Controllers
{
    public class SellerInformation
    {
        // Sets SellerID as the PK
        [Key]
        public int SellerID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string City_Location { get; set; }
        public int Year_Joined { get; set; }
        public int Selling_Computer_Part { get; set; }
        public string Part_Condition { get; set; }

        public ComputerParts PartNumber { get; set; }
    }
}
