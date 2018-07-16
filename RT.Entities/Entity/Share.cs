using RT.Entities.Interfaces;
using System;

namespace RT.Entities.Entity
{
    public class Share : IShareDbEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
    }
}
