﻿using Catalog.Persistence.Database;
using Catalog.Services.Queries.DTOs;
using Catalog.Services.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Common.Collection;
using Services.Common.Mapping;
using Services.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.Queries
{
    public class ProductQueryService: IProductQueryService
    {
        private readonly ApplicationDbContext _context;
        public ProductQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products =null)
        {
            var collection = await _context.Products 
                .Where(x=> products == null || products.Contains(x.ProductId))
                .OrderByDescending(x=>x.ProductId)
                .GetPageAsync(page,take);

            return collection.MapTo<DataCollection<ProductDto>>();

        }

        public async Task<ProductDto> GetAsync(int id)
        {
            return (await _context.Products.SingleAsync(x=>x.ProductId == id)).MapTo<ProductDto>();
        }
    }
}
