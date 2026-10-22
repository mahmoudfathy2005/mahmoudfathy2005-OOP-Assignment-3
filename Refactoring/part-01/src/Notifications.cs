namespace RefactoringLab;

public interface INotificationChannel
{
    void Send(string to, string message);
}

public class EmailChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[email] {to}: {message}");
    }
}

public class SmsChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[sms] {to}: {message}");
    }
}

public class PushNotificationChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[push] {to}: {message}");
    }
}

public class Notification
{
    private readonly INotificationChannel _channel;

    public bool IsUrgent { get; set; }

    public DateTime? SendAt { get; set; }

    public Notification(INotificationChannel channel)
    {
        _channel = channel;
    }

    public void Send(string to, string message)
    {
        if (IsUrgent)
        {
            message = $"[URGENT] {message}";
        }

        if (SendAt.HasValue)
        {
            Console.WriteLine(
                $"[{_channel.GetType().Name} scheduled {SendAt.Value:g}] "
                + $"{to}: {message}");

            return;
        }

        _channel.Send(to, message);
    }
}