namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    // Email servisi arayüzü

    public class UserService
    {
        private readonly IEmailService _emailService;

        public UserService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Register(string email)
        {
            // kullanıcı verisi kaydedilir...
            _emailService.Send(email, "Hoş Geldiniz");
        }


    }
    public interface ICalculator
    {
        int Add(int x, int y);
    }
    public interface IEmailService
    {
        void Send(string to, string message);
    }

    public class OrderManager
    {
        private readonly IEmailService _email;

        public OrderManager(IEmailService email)
        {
            _email = email;
        }

        public void CompleteOrder(string userEmail)
        {
            // siparişi tamamla...
            _email.Send(userEmail, "Siparişiniz başarıyla tamamlandı.");
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}