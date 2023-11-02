using Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
   opt.AddPolicy("AllowedOrigins", builder =>
   {
       builder.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials();
   } );
});

builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowedOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// we've mapped our SignalR Hub to a specific path in the URL.
// So, a client is now able to register with the Hub by submitting an HTTP request to the {Base URL}/learningHub address.
// The initial request is made via the standard HTTP protocol.
app.MapHub<StronglyTypeHub>("/learningHub");

app.Run();
