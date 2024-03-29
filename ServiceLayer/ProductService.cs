﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using RepositoryLayer;

namespace ServiceLayer
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        private IRepository<Image> imageRepository;

        public ProductService( IRepository<Product> _productRepository,
            IRepository<Image> _imageRepository
           )
        {
            productRepository = _productRepository;
            imageRepository = _imageRepository;
        }

        public void AddImage(Image image)
        {
            imageRepository.Insert(image);
        }

        public void AddProduct(Product product)
        {
            productRepository.Insert(product);
        }

        public IEnumerable<Product> filterProducts(double min, double max)
        {
            var productList = productRepository.GetAll();
            List<Product> products = new List<Product>();
            foreach(var item in productList)
            {
                if (item.Price >= min && item.Price <= max)
                    products.Add(item);
            }
            return products;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public async Task<Product> GetProduct(Guid ProductID)
        {
            Product product=await productRepository.Get(ProductID);
            
            return product;
        }

        public List<Image> GetProductImages(Guid productId)
        {
            var images = imageRepository.GetAll();
            List<Image> productImages = new List<Image>();
            foreach(var item in images)
            {
                if (item.ProductId == productId)
                    productImages.Add(item);
            }
            return productImages;
        }

        public async Task<bool> ProductIsAvailable(Guid ProductId)
        {
            Product product =await productRepository.Get(ProductId);
            if (product != null && product.Quantity > 0)
                return true;
            else
                return false;
        }

        public void updateProduct(Product product)
        {
            productRepository.Update(product);
        }
    }
}
