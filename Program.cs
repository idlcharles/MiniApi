using MiniApi.Data;
using MiniApi.Models;
using MiniApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("v1/apis", (AppDbContext context) => {
var apis = context.Apis.ToList();
return Results.Ok(apis);
}).Produces<Api>();

app.MapPost("v1/apis", (
    AppDbContext context,
    CreateApiViewModel model) => {

        var api = model.MapApi();
        if (!model.IsValid)
            return Results.BadRequest(model.Notifications);

        context.Apis.Add(api);
        context.SaveChanges();

        return Results.Created($"/v1/apis/{api.Id}", api);
    });

app.Run();
