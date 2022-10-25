//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CosmeticsShop.Models.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CityObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CityObject()
        {
            this.Applications = new HashSet<Applications>();
            this.AttendanceObject = new HashSet<AttendanceObject>();
        }
    
        public int Id { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public Nullable<int> NumberOfSeats { get; set; }
        public int OwnerID { get; set; }
        public Nullable<System.DateTime> DateOpening { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }

        public string ActualText
        {
            get
            {
                return (Available) ? "Доступно" : "Закрыто";
            }
        }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applications> Applications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceObject> AttendanceObject { get; set; }
        public virtual Owner Owner { get; set; }
    }
}