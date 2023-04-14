using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
	options.ConfigureEndpointDefaults(lo => lo.Protocols = HttpProtocols.Http2);
});

builder.Services.AddControllers().AddMvcOptions(options =>
{
	options.OutputFormatters.Clear();
	options.OutputFormatters.Add(
		new MessagePackOutputFormatter(new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)));
	options.InputFormatters.Clear();
	options.InputFormatters.Add(
		new MessagePackInputFormatter(new MessagePackSerializerOptions(ContractlessStandardResolver.Instance)));
});
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.MapControllers();
app.Run();