using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RT.Entities.Interfaces
{
    public interface IEntity<T> 
    {
        [Key]
        T Id { get; set; }
    }
}
