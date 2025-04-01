using ConsoleApp2;
using Moq;
using Xunit;

namespace TestProject
{
    /// <summary>
    /// UserService sınıfını test etmek için kullanılan test sınıfı.
    /// </summary>
    public class UserServiceTests
    {

        /// <summary>
        /// Kullanıcı kayıt olduğunda, Hoş Geldiniz e-postasının gönderildiğini test eder.
        /// </summary>
        [Fact]
        public void Register_ShouldSendWelcomeEmail()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var userService = new UserService(mockEmailService.Object);
            string email = "test@example.com";

            // Act
            userService.Register(email);

            // Assert Doğrulamak
            mockEmailService.Verify(
                x => x.Send(
                    email,
                    "Hoş Geldiniz"),
                Times.Once);
        }
        [Fact]
        /// <summary>
        /// Moq'un kullanımını gösteren bir test. Bu test, Moq'un nasıl kullanıldığını göstermektedir.
        /// </summary>
        public void Moq_Usage_Demo()
        {
            // Mock nesnesi oluşturma
            var mock = new Mock<ICalculator>();

            // Beklenen davranışı ayarlıyoruz
            // Setup: Mock nesnesine hangi metotların hangi değerleri döndüreceklerini söyleriz.
            // Returns: Beklenen dönüş değerini belirtir.
            mock.Setup(m => m.Add(2, 3)).Returns(5);

            // mock nesnesi üzerinden çağırıyoruz
            // Object: Mock nesnesinin kendisi. Interface, abstract class ya da sealed class olabilir.
            var result = mock.Object.Add(2, 3);

            // test ediyoruz
            Assert.Equal(5, result);

            // Birden fazla argüman almaya çalışıyoruz
            mock.Setup(m => m.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(100);

            // mock nesnesi üzerinden çağırıyoruz
            mock.Object.Add(2, 3);

            // times once verify
            // Verify: Mock nesnesinin hangi metotlarının hangi değerlerle çağrıldığını test eder.
            // Times: Mock nesnesinin hangi metotlarının kaç kez çağrıldığını test eder.
            // Hata fırlatmaya çalışıyoruz iki defa Cagırıldı
            mock.Verify(m => m.Add(2, 3), Times.Once());

            // callback ile sonuc de eriyoruz
            int sonuc = 0;

            // Callback: Mock nesnesinin hangi metotlarının hangi değerlerle çağrıldığını test eder.
            mock.Setup(m => m.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Callback<int, int>((x, y) => sonuc = x + y)
                .Returns(() => sonuc);

            // mock nesnesi üzerinden çağırıyoruz
            mock.Object.Add(2, 3);

            // Sonucu test ediyoruz
            Assert.Equal(5, sonuc);

            // Hata fırlatmaya çalışıyoruz
            mock.Setup(m => m.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new InvalidOperationException("Hata"));

            // mock nesnesi üzerinden çağırıyoruz
            Assert.Throws<InvalidOperationException>(() => mock.Object.Add(2, 3));
        }
        [Fact]
        public void RealLifeScenario()
        {
            var emailMock = new Mock<IEmailService>();
            var orderManager = new OrderManager(emailMock.Object);

            orderManager.CompleteOrder("test@example.com");

            emailMock.Verify(x => x.Send("test@example.com", It.IsAny<string>()), Times.Once);

        }
    }
}