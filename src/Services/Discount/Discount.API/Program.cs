using Discount.API.Entities;
using Discount.API.Repository;
using SqlSugar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

var sql = new SqlSugarScope(new ConnectionConfig
{
    ConnectionString = builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"),
    ConfigId = 0,
    DbType = DbType.PostgreSQL,
    IsAutoCloseConnection = true,
});

sql.DbMaintenance.CreateDatabase();
sql.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(Coupon));

builder.Services.AddSingleton<ISqlSugarClient>(sql);

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();