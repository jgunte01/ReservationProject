//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReservationProject.DATA.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class OwnerAssest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OwnerAssest()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int OwnerAssetID { get; set; }
        public string AssetName { get; set; }
        public string OwnerID { get; set; }
        public string AssetPhoto { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateAdded { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
