﻿using OnlineShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApi.DataAccess
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(string productId);
    }
}
