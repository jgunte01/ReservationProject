using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.DATA.EF//.Metadata
{
   public class LocationsMetaData
    {
        public int LocationID { get; set; }

        [Display(Name = "Location Name")]
        [StringLength(50, ErrorMessage = "* Field can not be more than 50 characters")]
        public string LocationName { get; set; }
        [StringLength(100, ErrorMessage = "* Field can not be more than 100 characters")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "* Field can not be more than 50 characters")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "* Field can not be more than 2 characters")]
        public string State { get; set; }

        [StringLength(2, ErrorMessage = "* Field can not be more than 2 characters")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set;}
        [Display(Name = "Reservation Max")]
        public byte ReservationMax { get; set; }

    }
    [MetadataType(typeof(LocationsMetaData))]
    public partial class Location
    {

    }
}
