# Azimzada.CurrencyFormatter

[![.NET 6.0](https://img.shields.io/badge/.NET-6.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/6.0)
[![NuGet](https://img.shields.io/nuget/v/Azimzada.CurrencyFormatter.svg)](https://www.nuget.org/packages/Azimzada.CurrencyFormatter/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Advanced currency formatting library that supports all currencies and cultures with compact formatting (K, M, B), detailed currency units, and minor currency units (cents, kuruş, qəpik).

## 🌟 Features

- ✅ **All Currencies Supported**: USD, EUR, TRY, AZN, GBP, JPY and many more
- ✅ **Multi-Cultural Support**: Formatting according to different language and region settings
- ✅ **Compact Format**: Shortening numbers with K (thousand), M (million), B (billion)
- ✅ **Minor Currency Units**: Supports small units like cents, kuruş, qəpik
- ✅ **Detailed Currency Format**: Verbose format like "10 min 123 manat 23 qəpik"
- ✅ **Extension Methods**: Easy usage with fluent API
- ✅ **Thread-Safe**: Safe multi-threading support
- ✅ **High Performance**: Minimum memory usage

## 📦 Installation

### NuGet Package Manager
```bash
Install-Package Azimzada.CurrencyFormatter
```

### .NET CLI
```bash
dotnet add package Azimzada.CurrencyFormatter
```

### PackageReference
```xml
<PackageReference Include="Azimzada.CurrencyFormatter" Version="1.0.0" />
```

## 🚀 Usage

### 1. Basic Usage

```csharp
using Azimzada.CurrencyFormatter;

// Using static method
string formatted = CurrencyFormatter.Format(1234.56m, "USD", "en-US");
// Result: $1,234.56

string formatted2 = CurrencyFormatter.Format(1234.56m, "TRY", "tr-TR");
// Result: ₺1.234,56
```

### 2. Fluent API with Extension Methods

```csharp
using Azimzada.CurrencyFormatter;

decimal amount = 1234.56m;

// Basic formatting
string usd = amount.ToCurrency("USD", "en-US");         // $1,234.56
string eur = amount.ToCurrency("EUR", "de-DE");         // 1.234,56 €
string try = amount.ToCurrency("TRY", "tr-TR");         // ₺1.234,56
string azn = amount.ToCurrency("AZN", "az-AZ");         // ₼1.234,56

// Compact formatting
string compact = amount.ToCompactCurrency("USD");       // $1.2K
string bigNumber = 1500000m.ToCompactCurrency("EUR");   // €1.5M
string huge = 2500000000m.ToCompactCurrency("TRY");     // ₺2.5B
```

### 3. Compact Formatting

```csharp
// Different sized numbers
1500m.ToCompactCurrency("USD");           // $1.5K
1500000m.ToCompactCurrency("EUR");        // €1.5M  
1500000000m.ToCompactCurrency("TRY");     // ₺1.5B
1500000000000m.ToCompactCurrency("GBP");  // £1.5T

// Precision adjustment
decimal amount = 1234567m;
amount.ToCompactCurrency("USD", "en-US", 0);  // $1M
amount.ToCompactCurrency("USD", "en-US", 1);  // $1.2M
amount.ToCompactCurrency("USD", "en-US", 2);  // $1.23M
```

### 4. Detailed Currency Formatting (NEW!)

```csharp
decimal amount = 10123.23m;

// Detailed format - your requested feature!
string detailed1 = amount.ToDetailedCurrency("AZN", "az-AZ");
// Result: "10 min 123 manat 23 qəpik"

string detailed2 = amount.ToDetailedCurrency("USD", "en-US");
// Result: "10 min 123 dollars 23 cents"

string detailed3 = 1234567.89m.ToDetailedCurrency("TRY", "tr-TR");
// Result: "1 milyon 234 min 567 lira 89 kuruş"

// Static method usage
string detailed4 = CurrencyFormatter.FormatWithDetailedUnits(5000000.45m, "EUR", "de-DE");
// Result: "5 milyon Euro 45 Cent"
```

### 5. Minor Currency Units Formatting

```csharp
decimal amount = 1234.56m;

// Different languages for minor currency unit names
string withMinor1 = amount.ToCurrencyWithMinorUnits("USD", "en-US");
// Result: $1,234 56 cents

string withMinor2 = amount.ToCurrencyWithMinorUnits("TRY", "tr-TR");
// Result: ₺1.234 56 kuruş

string withMinor3 = amount.ToCurrencyWithMinorUnits("AZN", "az-AZ");
// Result: ₼1.234 56 qəpik

string withMinor4 = amount.ToCurrencyWithMinorUnits("EUR", "de-DE");
// Result: 1.234 € 56 Cent
```

### 6. Different Data Types Usage

```csharp
// decimal, double and int are supported
decimal decimalAmount = 1234.56m;
double doubleAmount = 1234.56;
int intAmount = 1234;

string result1 = decimalAmount.ToCurrency("USD");
string result2 = doubleAmount.ToCurrency("EUR");
string result3 = intAmount.ToCurrency("TRY");

// Compact format works the same way
string compact1 = decimalAmount.ToCompactCurrency("USD");
string compact2 = doubleAmount.ToCompactCurrency("EUR");
string compact3 = intAmount.ToCompactCurrency("TRY");

// Detailed format also supports all types
string detailed1 = decimalAmount.ToDetailedCurrency("AZN");
string detailed2 = doubleAmount.ToDetailedCurrency("USD");
string detailed3 = intAmount.ToDetailedCurrency("TRY");
```

### 7. Currency Database Usage

```csharp
// Getting currency information
var usdInfo = CurrencyDatabase.GetCurrency("USD");
Console.WriteLine($"Name: {usdInfo.Name}");           // US Dollar
Console.WriteLine($"Symbol: {usdInfo.Symbol}");       // $
Console.WriteLine($"Code: {usdInfo.Code}");           // USD

// Listing all supported currencies
var allCurrencies = CurrencyDatabase.GetAllCurrencies();
foreach (var currency in allCurrencies)
{
    Console.WriteLine($"{currency.Key}: {currency.Value.Name}");
}

// Finding currency by country
var usCurrencies = CurrencyDatabase.GetCurrenciesByCountry("US");
var turkishCurrencies = CurrencyDatabase.GetCurrenciesByCountry("TR");

// Checking if currency is supported
bool isSupported = CurrencyDatabase.IsSupported("USD"); // true
bool isSupported2 = CurrencyDatabase.IsSupported("XYZ"); // false
```

## 🌍 Supported Currencies

| Currency | Code | Symbol | Countries | Minor Unit |
|----------|------|--------|-----------|------------|
| US Dollar | USD | $ | US, EC, SV, ZW... | cents |
| Euro | EUR | € | AT, BE, DE, FR... | cents/centimes |
| Turkish Lira | TRY | ₺ | TR | kuruş |
| Azerbaijani Manat | AZN | ₼ | AZ | qəpik |
| British Pound | GBP | £ | GB, IM, JE, GG | pence |
| Japanese Yen | JPY | ¥ | JP | sen |
| Chinese Yuan | CNY | ¥ | CN | fen |
| Russian Ruble | RUB | ₽ | RU | kopecks |
| Canadian Dollar | CAD | C$ | CA | cents |
| Australian Dollar | AUD | A$ | AU, CX, CC... | cents |
| Swiss Franc | CHF | CHF | CH, LI | rappen |
| Swedish Krona | SEK | kr | SE | öre |
| Norwegian Krone | NOK | kr | NO, SJ, BV | øre |
| Danish Krone | DKK | kr | DK, FO, GL | øre |

## 🌐 Supported Cultures

The library supports all .NET cultures:
- `en-US` - English (United States)
- `tr-TR` - Turkish (Turkey)  
- `az-AZ` - Azerbaijani (Azerbaijan)
- `de-DE` - German (Germany)
- `fr-FR` - French (France)
- `es-ES` - Spanish (Spain)
- `it-IT` - Italian (Italy)
- `ru-RU` - Russian (Russia)
- `ja-JP` - Japanese (Japan)
- `zh-CN` - Chinese (China)
- And many more...

## 📋 Examples

### Same Currency, Different Cultures

```csharp
decimal amount = 1234.56m;

// EUR in different countries
string german = amount.ToCurrency("EUR", "de-DE");    // 1.234,56 €
string french = amount.ToCurrency("EUR", "fr-FR");    // 1 234,56 €
string italian = amount.ToCurrency("EUR", "it-IT");   // € 1.234,56
string spanish = amount.ToCurrency("EUR", "es-ES");   // 1.234,56 €
```

### Detailed Currency Format Examples

```csharp
// Different amounts with detailed formatting
10123.23m.ToDetailedCurrency("AZN", "az-AZ");
// Result: "10 min 123 manat 23 qəpik"

1234567.89m.ToDetailedCurrency("USD", "en-US");
// Result: "1 milyon 234 min 567 dollars 89 cents"

5000000.45m.ToDetailedCurrency("TRY", "tr-TR");
// Result: "5 milyon lira 45 kuruş"

50000m.ToDetailedCurrency("EUR", "de-DE");
// Result: "50 min Euro"

123.56m.ToDetailedCurrency("GBP", "en-GB");
// Result: "123 pounds 56 pence"
```

### E-commerce Application Example

```csharp
public class Product
{
    public decimal Price { get; set; }
    public string CurrencyCode { get; set; }
}

public class ProductService
{
    public string GetFormattedPrice(Product product, string userCulture)
    {
        return product.Price.ToCurrency(product.CurrencyCode, userCulture);
    }
    
    public string GetCompactPrice(Product product, string userCulture)
    {
        return product.Price.ToCompactCurrency(product.CurrencyCode, userCulture);
    }
    
    public string GetDetailedPrice(Product product, string userCulture)
    {
        return product.Price.ToDetailedCurrency(product.CurrencyCode, userCulture);
    }
}

// Usage
var product = new Product { Price = 299.99m, CurrencyCode = "USD" };
var service = new ProductService();

string priceForUS = service.GetFormattedPrice(product, "en-US"); // $299.99
string priceForTR = service.GetFormattedPrice(product, "tr-TR"); // $299,99
string priceForDE = service.GetFormattedPrice(product, "de-DE"); // 299,99 $
string detailedPrice = service.GetDetailedPrice(product, "en-US"); // 299 dollars 99 cents
```

### Web API Usage

```csharp
[ApiController]
[Route("[controller]")]
public class PricesController : ControllerBase
{
    [HttpGet("{amount}/{currency}")]
    public IActionResult GetFormattedPrice(decimal amount, string currency, 
                                         [FromQuery] string? culture = null,
                                         [FromQuery] bool compact = false,
                                         [FromQuery] bool detailed = false)
    {
        try
        {
            string formatted;
            if (detailed)
                formatted = amount.ToDetailedCurrency(currency, culture);
            else if (compact)
                formatted = amount.ToCompactCurrency(currency, culture);
            else
                formatted = amount.ToCurrency(currency, culture);
                
            return Ok(new { 
                amount, 
                currency, 
                culture, 
                formatted,
                compact,
                detailed
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
```

## ⚡ Performance

- **Memory**: Minimum heap allocation
- **Speed**: Optimized formatting algorithms
- **Cache**: Culture information is automatically cached
- **Thread Safety**: Safe multi-threading support

## 🛠️ Development and Testing

```bash
# Clone the repository
git clone https://github.com/MrAzimzadeh/CurrencyFormatter.git

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run tests (run demo)
dotnet run
```

## 🤝 Contributing

1. Fork it
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Create a Pull Request

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## 👤 Author

**Mahammad Azimzada**
- GitHub: [@MrAzimzadeh](https://github.com/MrAzimzadeh)
- Website: [azimzada.com](https://azimzada.com)

## ⭐ Support

If you like this project, don't forget to give it a ⭐!

---

💡 **Tip**: Visit the [GitHub repository](https://github.com/MrAzimzadeh/CurrencyFormatter) for more examples and up-to-date documentation.
