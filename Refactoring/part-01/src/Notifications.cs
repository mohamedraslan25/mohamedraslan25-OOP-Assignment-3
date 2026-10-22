namespace RefactoringLab;


public interface INotificationChannel
{
    string Name { get; }
}

public class EmailNotificationChannel : INotificationChannel
{
    public string Name => "email";
}

public class SmsNotificationChannel : INotificationChannel
{
    public string Name => "sms";
}

// A new channel can be added without modifying existing classes.
public class PushNotificationChannel : INotificationChannel
{
    public string Name => "push";
}

public class NotificationOptions
{
    public bool IsUrgent { get; init; }
    public DateTime? SendAt { get; init; }
}

public class NotificationService
{
    private readonly INotificationChannel _channel;

    public NotificationService(INotificationChannel channel)
    {
        _channel = channel;
    }

    public void Send(
        string to,
        string message,
        NotificationOptions? options = null)
    {
        options ??= new NotificationOptions();

        var finalMessage = options.IsUrgent
            ? $"[URGENT] {message}"
            : message;

        if (options.SendAt.HasValue)
        {
            Console.WriteLine(
                $"[{_channel.Name} scheduled " +
                $"{options.SendAt.Value:g}] {to}: {finalMessage}");
        }
        else
        {
            Console.WriteLine(
                $"[{_channel.Name}] {to}: {finalMessage}");
        }
    }
}
