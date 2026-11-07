namespace RefactoringLab;


    public interface IOrderRepository
    {
        void Save(int orderId, DateTime processedAt);
    }

    public interface ISmtpSender
    {
        void Send(string to, string body);
    }

    
    public class SqlOrderRepository : IOrderRepository
    {
        public void Save(int orderId, DateTime processedAt) =>
            Console.WriteLine($"[SQL] Save order {orderId} @ {processedAt:O}");
    }

    public class SmtpEmailSender : ISmtpSender
    {
        public void Send(string to, string body) =>
            Console.WriteLine($"[SMTP] To={to} | Body={body}");
    }

    
    public class OrderProcessor
    {
        private readonly IOrderRepository _repository;
        private readonly ISmtpSender _smtpEmailSender; 

        public OrderProcessor(IOrderRepository repository, ISmtpSender smtpEmailSender)
        {
            _repository = repository;
            _smtpEmailSender = smtpEmailSender;
        }

        public void Process(int orderId, string customerEmail)
        {
            DateTime now = DateTime.Now;

            _repository.Save(orderId, now);
            _smtpEmailSender.Send(customerEmail, $"Order {orderId} confirmed at {now}");
        }
    }
