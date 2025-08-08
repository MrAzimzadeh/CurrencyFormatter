using Azimzada.CurrencyFormatter;
using System.Globalization;

// Demo program for Currency Formatter
Console.WriteLine("=== Azimzada.CurrencyFormatter Demo ===\n");

// Test amounts
decimal[] testAmounts = { 1234.56m, 1000000m, 1500000000m, 0.75m, 42m };

Console.WriteLine("1. Standard Currency Formatting:");
Console.WriteLine("================================");
foreach (var amount in testAmounts)
{
    Console.WriteLine($"Amount: {amount:N2}");
    Console.WriteLine($"  USD (en-US): {CurrencyFormatter.Format(amount, "USD", "en-US")}");
    Console.WriteLine($"  EUR (de-DE): {CurrencyFormatter.Format(amount, "EUR", "de-DE")}");
    Console.WriteLine($"  TRY (tr-TR): {CurrencyFormatter.Format(amount, "TRY", "tr-TR")}");
    Console.WriteLine($"  AZN (az-AZ): {CurrencyFormatter.Format(amount, "AZN", "az-AZ")}");
    Console.WriteLine($"  GBP (en-GB): {CurrencyFormatter.Format(amount, "GBP", "en-GB")}");
    Console.WriteLine();
}

Console.WriteLine("2. Compact Currency Formatting:");
Console.WriteLine("===============================");
foreach (var amount in testAmounts)
{
    Console.WriteLine($"Amount: {amount:N2}");
    Console.WriteLine($"  USD Compact: {CurrencyFormatter.ToCompactFormat(amount, "USD", "en-US")}");
    Console.WriteLine($"  EUR Compact: {CurrencyFormatter.ToCompactFormat(amount, "EUR", "de-DE")}");
    Console.WriteLine($"  TRY Compact: {CurrencyFormatter.ToCompactFormat(amount, "TRY", "tr-TR")}");
    Console.WriteLine();
}

Console.WriteLine("3. Extension Methods Usage:");
Console.WriteLine("===========================");
foreach (var amount in testAmounts)
{
    Console.WriteLine($"Amount: {amount:N2}");
    Console.WriteLine($"  Extension USD: {amount.ToCurrency("USD", "en-US")}");
    Console.WriteLine($"  Extension Compact: {amount.ToCompactCurrency("USD", "en-US")}");
    Console.WriteLine($"  With Minor Units: {amount.ToCurrencyWithMinorUnits("USD", "en-US")}");
    Console.WriteLine();
}

Console.WriteLine("4. Currency Database Info:");
Console.WriteLine("==========================");
var currencies = new[] { "USD", "EUR", "TRY", "AZN", "JPY", "GBP" };
foreach (var code in currencies)
{
    var info = CurrencyDatabase.GetCurrency(code);
    if (info != null)
    {
        Console.WriteLine($"{info.Code} - {info.Name}");
        Console.WriteLine($"  Symbol: {info.Symbol}");
        Console.WriteLine($"  Decimal Places: {info.DecimalPlaces}");
        Console.WriteLine($"  Countries: {string.Join(", ", info.Countries)}");
        Console.WriteLine($"  Minor Units: {string.Join(", ", info.MinorUnitNames.Select(kv => $"{kv.Key}:{kv.Value}"))}");
        Console.WriteLine();
    }
}

Console.WriteLine("5. Different Cultures with Same Currency:");
Console.WriteLine("=========================================");
var amount1234 = 1234.56m;
Console.WriteLine($"EUR in different cultures:");
Console.WriteLine($"  German (de-DE): {amount1234.ToCurrency("EUR", "de-DE")}");
Console.WriteLine($"  French (fr-FR): {amount1234.ToCurrency("EUR", "fr-FR")}");
Console.WriteLine($"  Italian (it-IT): {amount1234.ToCurrency("EUR", "it-IT")}");
Console.WriteLine($"  Spanish (es-ES): {amount1234.ToCurrency("EUR", "es-ES")}");
Console.WriteLine();

Console.WriteLine("6. Large Numbers with Compact Format:");
Console.WriteLine("=====================================");
var largeAmounts = new decimal[] { 1500m, 15000m, 1500000m, 1500000000m, 1500000000000m };
foreach (var amount in largeAmounts)
{
    Console.WriteLine($"  {amount:N0} → {amount.ToCompactCurrency("USD", "en-US")}");
}

Console.WriteLine("\n7. NEW: Detailed Currency Format (Your Request!):");
Console.WriteLine("=================================================");
var detailedTestAmounts = new decimal[] { 10123.23m, 1234567.89m, 5000000.45m, 123.56m, 50000m };
foreach (var amount in detailedTestAmounts)
{
    Console.WriteLine($"Amount: {amount:N2}");
    Console.WriteLine($"  AZN Detailed: {amount.ToDetailedCurrency("AZN", "az-AZ")}");
    Console.WriteLine($"  USD Detailed: {amount.ToDetailedCurrency("USD", "en-US")}");
    Console.WriteLine($"  TRY Detailed: {amount.ToDetailedCurrency("TRY", "tr-TR")}");
    Console.WriteLine($"  EUR Detailed: {amount.ToDetailedCurrency("EUR", "de-DE")}");
    Console.WriteLine();
}

Console.WriteLine("\nDemo completed!");
