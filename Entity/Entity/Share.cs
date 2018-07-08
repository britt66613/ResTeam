using RT.Entity.Interfaces;
using System;

namespace RT.Entity.Entity
{
    public class Share : IEntity<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
    }
}
