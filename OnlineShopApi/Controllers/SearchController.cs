using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopApi.DataAccess;
using OnlineShopApi.Models;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private IProductRepository productRepository;

        public SearchController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost]
        public ApiResponse Search()
        {
            var keyword = new StreamContent(Request.Body).ReadAsStringAsync().Result;
            var products = productRepository.Products.Where(product => product.Name.ToLower().Contains(keyword.ToLower())).ToArray();
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
    }
}