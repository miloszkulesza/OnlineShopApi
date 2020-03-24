using OnlineShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApi.DataAccess
{
    public interface IOrderPositionRepository
    {
        IQueryable<OrderPosition> OrderPositions { get; }
        void SaveOrderPosition(params OrderPosition[] orderPositions);
        OrderPosition DeleteOrderPosition(OrderPosition orderPosition);
    }
}
