using Microsoft.Extensions.Options;

namespace Spa.Api.Services;

public class PaymentOptions { public string Provider {get;set;}="ManualQr"; public string YapeNumber {get;set;}=""; }

public class PaymentService(IOptions<PaymentOptions> options)
{
    private readonly PaymentOptions cfg=options.Value;
    public object GetInstructions(decimal amount) => new {
        method = "Yape",
        phone = cfg.YapeNumber,
        amount,
        status = "pending",
        note = "La confirmación automática requiere integrar un proveedor de pagos. En modo inicial, el personal valida el pago."
    };
}
