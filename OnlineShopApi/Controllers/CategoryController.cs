using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShopApi.DataAccess;
using OnlineShopApi.Models;

namespace OnlineShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("getCategories")]
        public ApiResponse GetCategories()
        {
            var categories =  categoryRepository.Categories.ToArray();
            ApiResponse response;
            if (categories != null && categories.Length > 0)
            {
                response = new ApiResponse
                {
                    Content = JsonConvert.SerializeObject(categories),
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