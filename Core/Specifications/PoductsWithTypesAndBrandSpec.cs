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
        public PoductsWithTypesAndBrandSpec(ProductSpecParams productParams)
         : base(P =>
                 
                  (!productParams.BrandId.HasValue || P.ProductBrandId == productParams.BrandId.Value) &&
                  (!productParams.TypeId.HasValue || P.ProductTypeId == productParams.TypeId.Value)

               )
        {
            // Add Includes To Query
            AddProductIncludes();

            ApplyingPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            // Add OrderBy To Query
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
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

        // This Ctor Is Using To Get Specific Product
        public PoductsWithTypesAndBrandSpec(int Id) : base(P => P.Id == Id)
        {
            AddProductIncludes();
        }


        private void AddProductIncludes()
        {

            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductTYPE);

        }
    }
}
