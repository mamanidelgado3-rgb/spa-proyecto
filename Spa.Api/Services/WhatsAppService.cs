using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace Spa.Api.Services;

public class WhatsAppOptions { public bool Enabled {get;set;} public string PhoneNumberId {get;set;}=""; public string AccessToken {get;set;}=""; public string StaffPhone {get;set;}=""; }

public class WhatsAppService(IHttpClientFactory factory, IOptions<WhatsAppOptions> options)
{
    private readonly WhatsAppOptions cfg=options.Value;

    public async Task SendBookingAsync(string text)
    {
        if (!cfg.Enabled) return; // modo desarrollo
        if (string.IsNullOrWhiteSpace(cfg.PhoneNumberId) || string.IsNullOrWhiteSpace(cfg.AccessToken)) return;

        var client=factory.CreateClient();
        client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",cfg.AccessToken);
        var url=$"https://graph.facebook.com/v23.0/{cfg.PhoneNumberId}/messages";
        var body=new {
            messaging_product="whatsapp",
            to=cfg.StaffPhone,
            type="text",
            text=new { body=text }
        };
        await client.PostAsJsonAsync(url,body);
    }
}
