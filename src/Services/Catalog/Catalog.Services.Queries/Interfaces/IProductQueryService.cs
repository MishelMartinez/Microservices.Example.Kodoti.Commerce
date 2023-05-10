using Catalog.Services.Queries.DTOs;
using Services.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.Queries.Interfaces
{
    public  interface IProductQueryService
    {
        Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);

        Task<ProductDto> GetAsync(int id);
    }
}
