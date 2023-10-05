using E_Commerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpesification : BaseSpesification<Product>
    {
        public ProductsWithTypesAndBrandsSpesification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpesification(int id) : base(x=>x.id ==id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
