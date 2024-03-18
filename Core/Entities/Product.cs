using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
    
        public string Name { get; set; }
     
        public string Description { get; set; }
      
        public decimal  Price { get; set; }
     
        public string  PictureURL { get; set;}
      
        public ProductType ProductTYPE { get; set; }
  
        public int ProductTypeId { get; set; }
     
        public ProductBrand ProductBrand { get; set; }
     
        public int ProductBrandId { get; set; }  
    }
}
