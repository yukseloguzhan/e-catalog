using Catalog.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(8)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public float Price { get; set; }
        public int Installment { get; set; }
        public string ImageURL { get; set; }



        public int CategoryId { get; set; }
        public virtual Category Category { set; get; }


    }
}
