using Catalog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Catalog.Entities.Concrete
{
    public class Category  : IEntity
    {

        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }


        public ICollection<Product> Products { set; get; }

    }
}
