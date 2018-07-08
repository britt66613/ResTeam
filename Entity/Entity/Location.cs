using RT.Entity.Interfaces;

namespace Entity.Entity
{
    public class Location : IEntity<int>
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}
