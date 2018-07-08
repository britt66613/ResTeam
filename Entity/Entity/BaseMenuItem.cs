using System;
using System.Collections.Generic;
using System.Text;
using RT.Entity.Interfaces;

namespace RT.Entity.Entity
{
    public class BaseMenuItem : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
