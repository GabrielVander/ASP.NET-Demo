using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cahe = MemoryCache.Default;
        List<ProductCategory> productCategories; 

        public ProductCategoryRepository()
        {
            productCategories = cahe["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cahe["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory ProductCategory)
        {
            productCategories.Add(ProductCategory);
        }

        public void Update(ProductCategory ProductCategory)
        {
            ProductCategory ProductCategoryToUpdate = productCategories.Find(p => p.Id == ProductCategory.Id);

            if (ProductCategoryToUpdate != null)
            {
                ProductCategoryToUpdate = ProductCategory;

            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory ProductCategory = productCategories.Find(p => p.Id == Id);

            if (ProductCategory != null)
            {
                return ProductCategory;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory ProductCategoryToDelete = productCategories.Find(p => p.Id == Id);

            if (ProductCategoryToDelete != null)
            {
                productCategories.Remove(ProductCategoryToDelete);
            }
            else
            {
                throw new Exception("ProductCategory not found");
            }
        }
    }
}
