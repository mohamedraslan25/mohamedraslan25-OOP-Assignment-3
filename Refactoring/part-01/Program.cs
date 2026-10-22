
using RefactoringLab;

// Shipping
var carriers = new IShippingCarrier[]
{
    new AramexCarrier(),
    new FedExCarrier(),
    new DhlCarrier(),
    new BostaCarrier()
};

var shipping = new ShippingCostCalculator(carriers);

Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"Bosta 2kg  → {shipping.Calculate("Bosta", 2)}");
Console.WriteLine();

// Orders
var processor = new OrderProcessor(
    new SqlOrderRepository(),
    new SmtpEmailSender());

processor.Process(1001, "customer@example.com");
Console.WriteLine();

// Notifications
var scheduledTime = DateTime.Today.AddHours(18);

var email = new NotificationService(
    new EmailNotificationChannel());

email.Send(
    "customer@example.com",
    "Your order ships tomorrow",
    new NotificationOptions
    {
        IsUrgent = true,
        SendAt = scheduledTime
    });

var sms = new NotificationService(
    new SmsNotificationChannel());

sms.Send(
    "+201000000000",
    "OTP 4821",
    new NotificationOptions { IsUrgent = true });

// New channel
var push = new NotificationService(
    new PushNotificationChannel());

push.Send(
    "user-1001",
    "You have a new update",
    new NotificationOptions
    {
        IsUrgent = true,
        SendAt = scheduledTime
    });
