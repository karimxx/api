using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class PoductsWithTypesAndBrandSpec : BaseISpecifications<Product>
    {
        public PoductsWithTypesAndBrandSpec(string sort ,int? brandId, int? typeId) 
            :base( x=> (!brandId.HasValue || x.ProductBrandId== brandId) &&
                    (!typeId.HasValue || x.ProductTypeId == typeId)

            ) 
        { 
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductTYPE);
        AddOrderBy(x => x.Name);
            
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
        }
        public PoductsWithTypesAndBrandSpec(int id) : base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductTYPE);
        }
    }
}
