using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog2.Models
{
    public class CreateProductModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public float Price { get; set; }
        public int Installment { get; set; }
        public IFormFile ImageURL { get; set; }



        public int CategoryId { get; set; }
    }
}
