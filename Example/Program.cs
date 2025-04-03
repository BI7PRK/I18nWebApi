using AspNetCore.Grpc.LocalizerStore.Rpc;
using AspNetCore.Grpc.LocalizerStore.Service;
using I18nWebApi.Exceptions;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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

app.UsRequestLocalizatioStore();

app.UseRouting();
app.MapControllers();
app.UseCustomExceptionHandler();
app.Run();
