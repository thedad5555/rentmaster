using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentMaster
{
    public class rentalType
    {
        public string rent_type_name { get; set; }
        public Int64 rent_type_id { get; set; }

        public override string ToString()
        {
            return rent_type_name;
        }
    }//end class
}
