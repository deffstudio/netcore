using ITfoxtec.Identity.Saml2;
using ITfoxtec.Identity.Saml2.Schemas.Metadata;
using ITfoxtec.Identity.Saml2.MvcCore.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<Saml2Configuration>(configuration.GetSection("Saml2"));
builder.Services.Configure<Saml2Configuration>(saml2Configuration =>
{
    saml2Configuration.AllowedAudienceUris.Add(saml2Configuration.Issuer);
    string? rootDirectory = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
    var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(rootDirectory + "\\NETCORE ENTRA SAML.cer");
    saml2Configuration.SignatureValidationCertificates.Add(cert);
    var entityDescriptor = new EntityDescriptor();
    entityDescriptor.ReadIdPSsoDescriptorFromUrl(new Uri(configuration["Saml2:IdPMetadata"]));

    if (entityDescriptor.IdPSsoDescriptor != null)
    {
        saml2Configuration.SingleSignOnDestination = entityDescriptor.IdPSsoDescriptor.SingleSignOnServices.First().Location;

    }
    else
    {
        throw new Exception("IdPSsoDecriptor not loaded from metadata.");
    }

}
);

builder.Services.AddSaml2();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => { 
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
