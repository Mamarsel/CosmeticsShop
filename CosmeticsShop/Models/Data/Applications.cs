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
    
    public partial class Applications
    {
        public int Id { get; set; }
        public System.DateTime DateOfThe { get; set; }
        public int CityObjectID { get; set; }
        public string EventName { get; set; }
        public string TypeOfEvent { get; set; }
    
        public virtual CityObject CityObject { get; set; }
    }
}
