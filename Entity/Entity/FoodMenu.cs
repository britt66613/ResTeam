using RT.Entity.Enum;

namespace RT.Entity.Entity
{
    public class FoodMenu : BaseMenuItem
    {
        public string Ingridients { get; set; }
        public Temperature? Temperature { get; set; }
        public int Weight { get; set; }
    }
}
