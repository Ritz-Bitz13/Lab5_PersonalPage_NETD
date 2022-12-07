using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_PersonalPage.Controllers
{
    public class ComputerParts
    {
        // Sets ID as the PK
        [Key]
        public int ID { get; set; }

        public string computerBrand { get; set; }

        public string computerPart { get; set; }

        public int computerCreatedYear { get; set; }

        public double computerPartPrice { get; set; }

        public ICollection<SellerInformation> Seller { get; set; }
    }
}
