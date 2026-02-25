using ProjetoLoja2dsA.Repositorio;

// HABILITA CACHE EM MEMÓRIA, USADO PELA SESSION
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddControllersWithViews();

// 👇 NOVO
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



// CONFIGURA A SESSION (TEMPO, COOKIE ETC.)
builder.Services.AddSession(options =>
{
    // quanto tempo a sessão fica ativa sem uso (30 minutos aqui)
    options.IdleTimeout = TimeSpan.FromMinutes(30);

    // por segurança, cookie só acessível via HTTP (não JS)
    options.Cookie.HttpOnly = true;

    // marca o cookie como essencial (sempre grava)
    options.Cookie.IsEssential = true;
});


//ADICIONANDO A ENJEÇÃO DE DEPENDENCIA
builder.Services.AddScoped<UsuarioRepositorio>();
//repositorio do usuario
builder.Services.AddScoped<ProdutoRepositorio>();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();           // 👈 LINHA IMPORTANTE

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
// ATIVA A SESSION EM TODAS AS REQUISIÇÕES
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
