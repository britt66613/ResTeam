using RT.Entities.Interfaces;

namespace Entities.Entity
{
    public class Location : ILocationDbEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
    }
}
