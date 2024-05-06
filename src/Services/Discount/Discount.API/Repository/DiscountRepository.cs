using Discount.API.Entities;
using SqlSugar;

namespace Discount.API.Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ISqlSugarClient _sqlSugarClient;

        public DiscountRepository(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }


        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            return await _sqlSugarClient.Insertable(coupon).ExecuteCommandAsync() > 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            return await _sqlSugarClient.Deleteable<Coupon>().Where(c => c.ProductName == productName).ExecuteCommandAsync() > 0;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            return await _sqlSugarClient.Queryable<Coupon>().FirstAsync(c => c.ProductName == productName);
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            return await _sqlSugarClient.Updateable(coupon).ExecuteCommandAsync() > 0;
        }
    }
}
