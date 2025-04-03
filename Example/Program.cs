using AspNetCore.Grpc.LocalizerStore.Rpc;
using AspNetCore.Grpc.LocalizerStore.Service;
using I18nWebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressMapClientErrors = true;
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers(o => {
    o.Filters.Add<ValidateModelAttribute>();
});

builder.Services.AddLocalizerChannel(opt =>
{
    opt.Url = "http://localhost:50001";
});
builder.Services.AddCultureLocalizerService();
builder.Services.AddStringLocalizerStore();

var app = builder.Build();

app.UseRequestLocalizatioStore();

app.UseRouting();
app.MapControllers();
app.UseCustomExceptionHandler();
app.Run();
