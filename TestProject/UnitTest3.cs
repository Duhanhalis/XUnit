using ConsoleApp2;
using FluentAssertions;

namespace TestProject
{
    public class TestProject1
    {

        [Fact]
        public void Test1()
        {
            // Bir tamsayının beklenen değere eşit olup olmadığını kontrol eder
            int actual = 5;
            actual.Should().Be(5);

            // Bir string'in belirli bir metinle başlayıp bittiğini ve belirli uzunlukta olduğunu kontrol eder
            string name = "duhan";
            name.Should().StartWith("du").And.EndWith("an").And.HaveLength(5);

            // Bir dizi tanımlanır ve çeşitli özellikleri kontrol edilir
            var list = new[] { "apple", "banana", "cherry" };

            // Dizinin belirli bir elemanı içerdiğini kontrol eder
            list.Should().Contain("banana");
            // Dizinin eleman sayısını kontrol eder
            list.Should().HaveCount(3);
            // Dizinin sadece benzersiz elemanlar içerdiğini kontrol eder
            list.Should().OnlyHaveUniqueItems();

            // İki nesnenin eşdeğer olup olmadığını kontrol etmek için örnek nesneler oluşturulur
            var expected = new Person { Name = "Ali", Age = 30 };
            var actual2 = new Person { Name = "Ali", Age = 30 };

            // İki nesnenin içerik olarak eşdeğer olup olmadığını kontrol eder
            actual2.Should().BeEquivalentTo(expected);

            // Bir kod bloğunun belirli bir hata fırlatıp fırlatmadığını kontrol eder
            Action act = () => throw new InvalidOperationException("Hata");

            // Belirli bir exception türünün ve mesajının kontrol edilmesi
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Hata");

            // Bir değişkenin null olup olmadığını kontrol eder
            string? s = null;
            s.Should().BeNull();

            // Bir string'in boş olup olmadığını kontrol eder
            string s2 = "";
            s2.Should().BeEmpty();

            // Tarih karşılaştırmaları için bir DateTime nesnesi oluşturulur
            DateTime date = new DateTime(2024, 1, 1);
            // Bir tarihin başka bir tarihten sonra olup olmadığını kontrol eder
            date.Should().BeAfter(new DateTime(2023, 12, 31));

            // Sözlük doğrulamaları
            var dict = new Dictionary<string, int> { { "one", 1 }, { "two", 2 } };
            dict.Should().ContainKey("one")
                .And.ContainValue(2)
                .And.HaveCount(2);

            // Koleksiyon sıralaması
            var numbers = new[] { 1, 2, 3, 4, 5 };
            numbers.Should().BeInAscendingOrder()
                .And.StartWith(1)
                .And.EndWith(5);

            // Ondalık sayılar için yaklaşık eşitlik
            double pi = 3.14159;
            pi.Should().BeApproximately(3.14, 0.01);

            // Tip kontrolü
            var obj = "test";
            obj.Should().BeOfType<string>();

            // And ile çoklu koşullar
            var text = "Hello World";
            text.Should()
                .StartWith("H")
                .And.Contain("World")
                .And.HaveLength(11)
                .And.MatchRegex("Hello.*");

            // Koleksiyonda sıralı içerik kontrolü
            var fruits = new[] { "apple", "banana", "orange" };
            fruits.Should().ContainInOrder("apple", "banana");

            // Nesne özelliği doğrulama
            var person = new Person { Name = "John", Age = 25 };
            person.Should().Match<Person>(p => p.Name == "John" && p.Age == 25);

        }
    }
}