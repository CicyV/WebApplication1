////using WebApplication1.Hubs;

////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.

////builder.Services.AddControllers();
////// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseAuthorization();

////app.MapControllers();

////app.Run();



//using WebApplication1.Hubs;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddSignalR(); // Add SignalR service

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//// Map the SignalR hub
//app.MapHub<NotificationHub>("/notificationHub");

//app.Run();
/////==========================================================================
///

//using WebApplication1.Hubs;

//var builder = WebApplication.CreateBuilder(args);

//// Add CORS policy to allow Vue.js app to connect
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowVueApp", policy =>
//    {
//        policy.WithOrigins("http://localhost:8080") // Your Vue.js app URL
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials(); // Allow cookies and credentials
//    });
//});

//builder.Services.AddSignalR();

//var app = builder.Build();

//// Enable CORS
//app.UseCors("AllowVueApp");

//app.MapHub<NotificationHub>("/hubs/notifications");
//app.MapControllers();

//app.Run();

using WebApplication1.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy to allow Vue.js app to connect
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:8080") // Your Vue.js app URLhttp://localhost:8080
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Allow cookies and credentials
    });
});

builder.Services.AddControllers();
builder.Services.AddSignalR(); // Add SignalR service

var app = builder.Build();

// Enable CORS for Vue.js app
app.UseCors("AllowVueApp");

app.MapControllers();

// Map the SignalR hub
app.MapHub<NotificationHub>("/hubs/notifications");

app.Run();


