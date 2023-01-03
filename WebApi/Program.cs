using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddMvc();

builder.Services.AddEndpointsApiExplorer();

// ���Swagger����
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "ToDoList API",
        Version = "V1",
        Description = ".NET7ʹ��MongoDB����ToDoListϵͳ",
        Contact = new OpenApiContact
        {
            Name = "GitHubԴ���ַ",
            Url = new Uri("https://github.com/YSGStudyHards/YyFlight.ToDoList")
        }
    });

    //// ��ȡxml�ļ���
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //// ��ȡxml�ļ�·��
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //// ��ӿ�������ע�ͣ�true��ʾ��ʾ������ע��
    //options.IncludeXmlComments(xmlPath, true);
    ////c.IncludeXmlComments(path, true); // true : ��ʾ��������ע��
    //options.OrderActionsBy(o => o.RelativePath); // ��action�����ƽ�����������ж�����Ϳ��Կ���Ч���ˡ�

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();


// Configure the HTTP request pipeline.


// ���Swagger����м��
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseStaticFiles();


app.Run();
