using CallWebBackend.Common;
using CallWebBackend.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CallWebBackend.Service
{
    public class ProductService
    {
        private static ProductService _instance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ProductService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductService();
            }
            return _instance;
        }

        public ResultLog GetProducts()
        {
            ResultLog result = new ResultLog();
            try
            {
                ApiContext context = new ApiContext();
                //IQueryable<Product> products = context.Products.AsQueryable();

                var data = context.Products
                    .Include(i => i.ProductGroups)
                    .Where(i => i.Name == "Business Card")
                    .ToList();

                result.Message = "Product retrieved success";
                result.ReturnObject = data;
            }
            catch (Exception ex)
            {
                result.Code = (int)HttpStatusCode.InternalServerError;
                result.Message = Util.ExtractExceptionMessage(ex);
            }
            return result;
        }
    }
}
