using System;
using System.Collections.Generic;
using System.Text;
using RT.Entities.Interfaces;

namespace RT.Entities.Entity
{
    public class Menu : IMenuDbEntity
    {
        public int Id { get; set; }
        public int? ActionId { get; set; }
        public virtual Share Action { get; set; }
        public DateTime Time { get; set; }
        public virtual ICollection<FoodMenu> FoodMenus { get; set; }
        public virtual ICollection<BarMenu> BarMenus { get; set; }
        public virtual ICollection<HookahMenu> HookahMenus { get; set; }
        public virtual ICollection<SecondaryServicesMenu> SecondaryServicesMenus { get; set; }

        public Menu()
        {
            FoodMenus = new List<FoodMenu>();
            BarMenus = new List<BarMenu>();
            HookahMenus = new List<HookahMenu>();
            SecondaryServicesMenus = new List<SecondaryServicesMenu>();
        }
    }
}
