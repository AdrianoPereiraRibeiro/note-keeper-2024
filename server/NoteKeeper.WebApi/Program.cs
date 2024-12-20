
using Microsoft.EntityFrameworkCore;
using NoteKeeper.Aplicacao.ModuloCategoria;
using NoteKeeper.Aplicacao.ModuloNota;
using NoteKeeper.Dominio.Compartilhado;
using NoteKeeper.Dominio.ModuloCategoria;
using NoteKeeper.Dominio.ModuloNota;
using NoteKeeper.Infra.Orm.Compartilhado;
using NoteKeeper.Infra.Orm.ModuloCategoria;
using NoteKeeper.Infra.Orm.ModuloNota;
using NoteKeeper.WebApi.Config;
using NoteKeeper.WebApi.Config.Mapping;
using NoteKeeper.WebApi.Filters;
using Serilog;

namespace NoteKeeper.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

           
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("SqlServer");

            builder.Services.AddDbContext<IContextoPersistencia, NoteKeeperDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoriaOrm>();
            builder.Services.AddScoped<ServicoCategoria>();

            builder.Services.AddScoped<IRepositorioNota, RepositorioNotaOrm>();
            builder.Services.AddScoped<ServicoNota>();

            builder.Services.AddScoped<ConfigurarCategoriaMappingAction>();

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<CategoriaProfile>();
                config.AddProfile<NotaProfile>();
            });

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ResponseWrapperFilter>();
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.ConfigureSerilog(builder.Logging);

            //
            var app = builder.Build();

            app.UseGlobalExceptionHandler();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
               Log.Fatal("Ocorreu um erro que fechou a aplica��o.", ex);

               return;
            }
           
        }
    }
}
