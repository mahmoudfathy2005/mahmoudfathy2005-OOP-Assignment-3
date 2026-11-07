namespace RefactoringLab;



    
    public interface IShippingCostCalculator
    {
        string Carrier { get; }
        decimal Calculate(decimal weightKg);
    }

    
    public class AramexShippingCostCalculator : IShippingCostCalculator
    {
        public string Carrier => "Aramex";
        public decimal Calculate(decimal weightKg) => weightKg * 12m;
    }

    public class FedExShippingCostCalculator : IShippingCostCalculator
    {
        public string Carrier => "FedEx";
        public decimal Calculate(decimal weightKg) => weightKg * 15m;
    }

    public class DHLShippingCostCalculator : IShippingCostCalculator
    {
        public string Carrier => "DHL";
        public decimal Calculate(decimal weightKg) => weightKg * 18m;
    }

   
    public class ShippingCostCalculator
    {
        private IShippingCostCalculator _shippingCostCalculator;

        public ShippingCostCalculator(IShippingCostCalculator shippingCostCalculator = null)
        {
            _shippingCostCalculator = shippingCostCalculator;
        }

       
        public void SetStrategy(IShippingCostCalculator shippingCostCalculator)
        {
            _shippingCostCalculator = shippingCostCalculator;
        }

        public decimal Calculate(decimal weightKg)
        {
            if (_shippingCostCalculator == null)
            {
                Console.WriteLine("Please select a Shipping Cost Calculator first.");
                return 0m;
            }

            return _shippingCostCalculator.Calculate(weightKg);
        }
    }
