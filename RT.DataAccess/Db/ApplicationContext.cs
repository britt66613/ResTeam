using RT.Entities.Entity;
using System.Data.Entity;
using Entities.Entity;

namespace RT.DataAccess.Db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=AppContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationContext>());
        }

        public IDbSet<Restaurant> Restaurants { get; set; }
        public IDbSet<Menu> Menus { get; set; }
        public IDbSet<SecondaryServicesMenu> SecondaryServicesMenus { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<HookahMenu> HookahMenus { get; set; }
        public IDbSet<FoodMenu> FoodMenus { get; set; }
        public IDbSet<BarMenu> BarMenus { get; set; }
        public IDbSet<Share> Shares { get; set; }
    }
}
