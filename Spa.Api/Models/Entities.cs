namespace Spa.Api.Models;

public class Client { public int Id {get;set;} public string Name {get;set;}=""; public string Phone {get;set;}=""; public string Email {get;set;}=""; }
public class ServiceItem { public int Id {get;set;} public string Name {get;set;}=""; public int DurationMinutes {get;set;} public decimal Price {get;set;} public bool Active {get;set;}=true; }
public class Professional { public int Id {get;set;} public string Name {get;set;}=""; public string Phone {get;set;}=""; public bool Active {get;set;}=true; }
public enum BookingStatus { Pending, Confirmed, Attended, Cancelled, NoShow }
public class Booking {
    public int Id {get;set;}
    public int ClientId {get;set;} public Client? Client {get;set;}
    public int ServiceItemId {get;set;} public ServiceItem? Service {get;set;}
    public int ProfessionalId {get;set;} public Professional? Professional {get;set;}
    public DateTime Start {get;set;} public DateTime End {get;set;}
    public BookingStatus Status {get;set;}=BookingStatus.Pending;
    public string Notes {get;set;}="";
}
public enum PaymentStatus { Pending, Paid, Rejected }
public class Payment {
    public int Id {get;set;} public int BookingId {get;set;}
    public decimal Amount {get;set;} public string Method {get;set;}="Yape";
    public string Reference {get;set;}=""; public PaymentStatus Status {get;set;}=PaymentStatus.Pending;
    public DateTime CreatedAt {get;set;}=DateTime.UtcNow;
}
