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
    
    public partial class AttendanceObject
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Attendance { get; set; }
        public int CityObjectID { get; set; }
    
        public virtual CityObject CityObject { get; set; }
    }
}
