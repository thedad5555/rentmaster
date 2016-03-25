using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentMaster
{
    class Rental
    {
        public Int64 rental_id { get; set; }
        //change this to rentalType
        public rentalType rental_type_id;
        public string rental_name { get; set; }
        //use our guest object
        //public Int64 guest_id { get; set; }
        public Guest rentalGuest; 
        public DateTime rental_check_in_time { get; set; }
        public DateTime rental_expiration_time { get; set; }
        public bool rental_inout { get; set; }
        public string rental_notes { get; set; }
        public DateTime rental_check_out_time { get; set; }

        public Rental()
        {
            this.rental_type_id = new rentalType();
            this.rentalGuest = new Guest();
        }

    }
}
