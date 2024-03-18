using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SecondApi.Dtos
{
    public class ProductToReturn
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public string Description { get; set; }
     
        public decimal Price { get; set; }
      
        public string PictureURL { get; set; }
      
        public string ProductTYPE { get; set; }
   
        public string ProductBrand { get; set; }
       
       
    }
}
