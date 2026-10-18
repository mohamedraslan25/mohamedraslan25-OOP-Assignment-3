
namespace RefactoringLab;

public interface IShippingCarrier
{
    string Name { get; }
    decimal Calculate(decimal weightKg);
}


public class BostaCarrier : IShippingCarrier
{
    public string Name => "Bosta";

    public decimal Calculate(decimal weightKg) => weightKg * 10m;
}


public class AramexCarrier : IShippingCarrier
{
    public string Name => "Aramex";

    public decimal Calculate(decimal weightKg) => weightKg * 12m;
}

public class FedExCarrier : IShippingCarrier
{
    public string Name => "FedEx";

    public decimal Calculate(decimal weightKg) => weightKg * 15m;
}

public class DhlCarrier : IShippingCarrier
{
    public string Name => "DHL";

    public decimal Calculate(decimal weightKg) => weightKg * 18m;
}

public class ShippingCostCalculator
{
    private readonly IReadOnlyDictionary<string, IShippingCarrier> _carriers;

    public ShippingCostCalculator(IEnumerable<IShippingCarrier> carriers)
    {
        _carriers = carriers.ToDictionary(
            carrier => carrier.Name,
            StringComparer.OrdinalIgnoreCase);
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        if (!_carriers.TryGetValue(carrier, out var shippingCarrier))
        {
            throw new ArgumentException($"Unknown carrier: {carrier}");
        }

        return shippingCarrier.Calculate(weightKg);
    }
}
