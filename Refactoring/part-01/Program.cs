```csharp
using RefactoringLab;



Console.WriteLine("=== Shipping Cost Calculator ===");

var shipping = new ShippingCostCalculator(
    new AramexShippingCostCalculator());

Console.WriteLine($"Aramex 2kg  -> {shipping.Calculate(2):C}");

shipping.SetStrategy(new FedExShippingCostCalculator());
Console.WriteLine($"FedEx 2kg   -> {shipping.Calculate(2):C}");

shipping.SetStrategy(new DHLShippingCostCalculator());
Console.WriteLine($"DHL 2kg     -> {shipping.Calculate(2):C}");

Console.WriteLine();




Console.WriteLine("=== Order Processing ===");

var repository = new SqlOrderRepository();
var emailSender = new SmtpEmailSender();

var processor = new OrderProcessor(repository, emailSender);

processor.Process(1001, "customer@example.com");

Console.WriteLine();



Console.WriteLine("=== Notifications ===");


var emailNotification = new Notification(new EmailChannel());
emailNotification.Send(
    "customer@example.com",
    "Your order has been confirmed");


var smsNotification = new Notification(new SmsChannel())
{
    IsUrgent = true
};

smsNotification.Send(
    "+201000000000",
    "Your OTP is 4821");


var scheduledEmail = new Notification(new EmailChannel())
{
    SendAt = DateTime.Today.AddHours(18)
};

scheduledEmail.Send(
    "customer@example.com",
    "Your order ships tomorrow");


var urgentScheduledEmail = new Notification(new EmailChannel())
{
    IsUrgent = true,
    SendAt = DateTime.Today.AddHours(18)
};

urgentScheduledEmail.Send(
    "customer@example.com",
    "Your order ships tomorrow");


var pushNotification = new Notification(new PushNotificationChannel());

pushNotification.Send(
    "user-1001",
    "You have a new notification");
```
