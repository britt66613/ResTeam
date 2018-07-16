using Entities.Entity;
using RT.DataAccess.Db;
using RT.Entities.Entity;
using RT.Entities.Enum;
using RT.Services;
using RT.Utils.ModelError;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.ModelBinding;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {            
            using (ApplicationContext db = new ApplicationContext())
            {
                Restaurant restaurant = new Restaurant
                {
                    Name = "Mister Cat",
                    Status = Status.Open,
                    Time = DateTime.Today,
                    CategoryList = "",
                    Location = new Location { Address = "Prospekt pobedy 154"}
                };

                Menu  menu = new Menu()
                {
                    Time = DateTime.Today,                    
                };
                menu.BarMenus.Add(
                    new BarMenu
                    {
                        Menu = menu,
                        Category = "Alchohol",
                        Description = "60%",
                        Ingridients = "Tomato, vodka, olive",
                        Name = "Bloody Marry",
                        Price = 120,
                        Temperature = Temperature.Cold,
                        Amount = 220
                    });
                menu.FoodMenus.Add(
                    new FoodMenu()
                    {
                        Menu = menu,
                        Category = "Pizza",
                        Description = "Spicy",
                        Ingridients = "Pastta tomato, sausage ...",
                        Name = "Pizza Stalone",
                        Price = 340.0,
                        Temperature = Temperature.Hot,
                        Weight = 1120
                    });
                menu.HookahMenus.Add(
                    new HookahMenu()
                    {
                        Menu = menu,
                        Category = "Spicy",
                        Description = "Very hard, not recomended for begginers",
                        Ingridients = "Trava, oduvanchik, govno verbluda",
                        Name = "Hard Table",
                        Price = 500,
                    });

                restaurant.Menu = menu;
                var service = new GenericRestaurantService<Restaurant>(new ModelStateWrapper(new ModelStateDictionary()));

                var resultA = service.Create(restaurant);


                Expression<Func<int, bool>> isTeenAgerExpr = s => s > 12 && s < 20;

                //compile Expression using Compile method to invoke it as Delegate
                Func<int, bool> isTeenAger = isTeenAgerExpr.Compile();

                //Invoke
                bool result = isTeenAger(15);
                                             
                foreach (var item in db.Restaurants.ToList())
                {
                    Console.WriteLine($"Restaurant name: {item.Name} \n" +
                                      $"Restaurant id: {item.Id} \n" +
                                      $"Restaurant address: {item.Location.Address} \n" +
                                      $"Restaurants creation time: {item.Time} \n" +
                                      $"Restaurant status: {item.Status.ToString()} \n {string.Format("-", 10)} \n" +
                                      $" Restaurant Menu \n" +
                                      $"Bar Menu: \n" +
                                      $"Name - {item.Menu.BarMenus.FirstOrDefault().Name} \n" +
                                      $"Description - {item.Menu.BarMenus.FirstOrDefault().Description} \n" +
                                      $"Price - {item.Menu.BarMenus.FirstOrDefault().Price} \n" +
                                      $"Amount - {item.Menu.BarMenus.FirstOrDefault().Amount} \n" +
                                      $"Ingridients - {item.Menu.BarMenus.FirstOrDefault().Ingridients} \n" +
                                      $"Temperature - {item.Menu.BarMenus.FirstOrDefault().Temperature} \n" +
                                      $"Category - {item.Menu.BarMenus.FirstOrDefault().Category} \n" + Environment.NewLine);
                }
                
                var time1 = DateTime.Now;
                Create(db);
                var time2 = DateTime.Now;
                Console.WriteLine(time1);
                Console.WriteLine(time2);
                Console.ReadKey();
            }
        }

        public static void Create(ApplicationContext db)
        {
            foreach (var item in db.Restaurants.ToList())
            {
                Console.WriteLine($"Restaurant name: {item.Name} \n" +
                                  $"Restaurant id: {item.Id} \n" +
                                  $"Restaurant address: {item.Location.Address} \n" +
                                  $"Restaurants creation time: {item.Time} \n" +
                                  $"Restaurant status: {item.Status.ToString()} \n {string.Format("-", 10)} \n" +
                                  $" Restaurant Menu \n" +
                                  $"Bar Menu: \n" +
                                  $"Name - {item.Menu.BarMenus.FirstOrDefault().Name} \n" +
                                  $"Description - {item.Menu.BarMenus.FirstOrDefault().Description} \n" +
                                  $"Price - {item.Menu.BarMenus.FirstOrDefault().Price} \n" +
                                  $"Amount - {item.Menu.BarMenus.FirstOrDefault().Amount} \n" +
                                  $"Ingridients - {item.Menu.BarMenus.FirstOrDefault().Ingridients} \n" +
                                  $"Temperature - {item.Menu.BarMenus.FirstOrDefault().Temperature} \n" +
                                  $"Category - {item.Menu.BarMenus.FirstOrDefault().Category} \n" + Environment.NewLine);
            }
        }
    }
}
