using Entity.Entity;
using RT.Entity.Enum;
using RT.Entity.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RT.Entity.Entity
{
    public class Restaurant: IRestaurantDbEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(Status.Open)]
        public Status Status { get; set; }
        public string CategoryList { get; set; }
        public DateTime Time { get; set; }
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int? MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
