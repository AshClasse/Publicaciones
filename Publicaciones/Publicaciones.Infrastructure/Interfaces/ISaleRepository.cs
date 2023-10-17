﻿using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Sale GetSaleByID(int storeID, string ordNum, int titleID);
        List<Sale> GetSaleByStore(int storeID);
        List<Sale> GetSaleByTitle(int titleID);
        List<Sale> GetSaleByOrdNum(string ordNum);
    }
}
