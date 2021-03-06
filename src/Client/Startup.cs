using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NoteToSelf.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");

            //StaticFileOptions options = new StaticFileOptions();
            //FileExtensionContentTypeProvider contentTypeProvider = (FileExtensionContentTypeProvider)options.ContentTypeProvider ??
            //    new FileExtensionContentTypeProvider();
            //contentTypeProvider.Mappings.Add(".unityweb", "application/octet-stream");
            //options.ContentTypeProvider = contentTypeProvider;
            //app.UseStaticFiles(options);
        }
    }
}
