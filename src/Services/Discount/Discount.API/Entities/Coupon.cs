using SqlSugar;

namespace Discount.API.Entities
{
    [SugarTable("coupon", "优惠卷", IsDisabledUpdateAll = true)]
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}
