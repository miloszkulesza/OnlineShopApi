using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopApi.DataAccess;
using OnlineShopApi.Models;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("getProducts")]
        public ApiResponse GetProducts(string categoryId)
        {
            Product[] products;
            if(string.IsNullOrEmpty(categoryId) || categoryId == "all")
            {
                products = productRepository.Products.Where(x => x.Quantity > 0 && !x.IsHidden).ToArray();
            }
            else
            {
                products = productRepository.Products.Where(x => x.Quantity > 0 && !x.IsHidden && x.CategoryId == categoryId).ToArray();
            }
            ApiResponse response;
            if (products != null && products.Length > 0)
            {
                response = new ApiResponse
                {
                    Content = JsonConvert.SerializeObject(products),
                    IsSuccessStatusCode = true,
                    StatusCode = HttpStatusCode.OK
                };
            }
            else
                response = new ApiResponse
                {
                    IsSuccessStatusCode = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ReasonPhrase = "Content not found"
                };
            return response;
        }

        [HttpGet]
        [Route("getProduct")]
        public ApiResponse GetProduct(string productId)
        {
            var product = productRepository.Products.FirstOrDefault(x => x.Id.Equals(productId));
            ApiResponse response;
            if (product != null)
            {
                response = new ApiResponse
                {
                    Content = JsonConvert.SerializeObject(product),
                    IsSuccessStatusCode = true,
                    StatusCode = HttpStatusCode.OK
                };
            }
            else
                response = new ApiResponse
                {
                    IsSuccessStatusCode = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ReasonPhrase = "Content not found"
                };
            return response;
        }
    }
}