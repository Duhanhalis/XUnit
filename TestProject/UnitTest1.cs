using ConsoleApp; // ConsoleApp isimli projeden sınıfları kullanmak için
using static ConsoleApp.Program; // Program sınıfındaki statik üyeleri doğrudan kullanmak için

namespace TestProject; // TestProject isimli bir ad alanı
public class CalculatorTests // Calculator sınıfı için testleri içeren sınıf
{
    private readonly Calculator _calculator; // Calculator sınıfının bir örneği

    public CalculatorTests() // Constructor
    {
        _calculator = new Calculator(); // Yeni bir Calculator nesnesi oluşturuluyor
    }

    [Fact] // Test metodu
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum() // İki pozitif sayının toplamını test eden metod
    {
        // Arrange
        int a = 5, b = 3; // Test için sayılar

        // Act
        var result = _calculator.Add(a, b); // Toplama işlemi

        // Assert
        Assert.Equal(8, result); // Sonucun beklenen değerle karşılaştırılması
    }   
    [Theory] // Birden fazla veri ile test
    [InlineData(5, 3, 8)] // Test verileri
    [InlineData(-2, -3, -5)]
    [InlineData(-2, 3, 1)]
    public void Add_VariousInputs_ReturnsExpectedResult(int a, int b, int expected) // Farklı girişlerle toplamayı test eden metod
    {
        var result = _calculator.Add(a, b); // Toplama işlemi
        Assert.Equal(expected, result); // Sonucun beklenen değerle karşılaştırılması

        Assert.NotEqual(a, b);
    }

    [Fact] // Test metodu
    public void Divide_DivideByNonZero_ReturnsQuotient() // Sıfır olmayan bir sayıya bölmeyi test eden metod
    {
        int result = _calculator.Divide(10, 2); // Bölme işlemi
        Assert.Equal(5, result); // Sonucun beklenen değerle karşılaştırılması
    }

    [Fact] // Test metodu
    public void Divide_DivideByZero_ThrowsDivideByZeroException() // Sıfıra bölme durumunu test eden metod
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0)); // Sıfıra bölme durumunda istisna fırlatılmasını kontrol etme
    }
}
