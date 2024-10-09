var builder = WebApplication.CreateBuilder(args);

// add services to the container.
builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();

// configure the HTTP request pipeline.
app.MapCarter();
app.Run();
