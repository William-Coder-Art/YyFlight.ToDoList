using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ����Swagger����
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

    // ��ȡxml�ļ���
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // ��ȡxml�ļ�·��
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // ���ӿ�������ע�ͣ�true��ʾ��ʾ������ע��
    options.IncludeXmlComments(xmlPath, true);
    // ��action�����ƽ�����������ж�����Ϳ��Կ���Ч����
    options.OrderActionsBy(o => o.RelativePath); 
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//ʹ�м���ܹ������ɵ�Swagger����JSON�˵�.
//app.UseSwagger();
app.UseSwagger(c => { c.RouteTemplate = "swagger/{documentName}/swagger.json"; });
//�����м��ΪSwagger UI��HTML��JS��CSS�ȣ��ṩ����ָ��swagger JSON�˵�.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.MapControllers();


app.Run();