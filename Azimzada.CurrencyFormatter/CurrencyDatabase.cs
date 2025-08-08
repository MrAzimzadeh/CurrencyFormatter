namespace Azimzada.CurrencyFormatter;

/// <summary>
/// Contains information about a currency including its code, symbol, and minor unit details.
/// </summary>
public class CurrencyInfo
{
    /// <summary>
    /// ISO 4217 currency code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Currency symbol
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Currency name in English
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Number of decimal places typically used
    /// </summary>
    public int DecimalPlaces { get; set; } = 2;

    /// <summary>
    /// Minor unit name in different languages
    /// </summary>
    public Dictionary<string, string> MinorUnitNames { get; set; } = new();

    /// <summary>
    /// Major unit name in different languages
    /// </summary>
    public Dictionary<string, string> MajorUnitNames { get; set; } = new();

    /// <summary>
    /// Countries that use this currency
    /// </summary>
    public List<string> Countries { get; set; } = new();
}

/// <summary>
/// Provides comprehensive currency information and lookup capabilities.
/// </summary>
public static class CurrencyDatabase
{
    private static readonly Dictionary<string, CurrencyInfo> _currencies = new()
    {
        ["USD"] = new()
        {
            Code = "USD",
            Symbol = "$",
            Name = "US Dollar",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "cents", 
                ["tr"] = "sent", 
                ["az"] = "sent",
                ["es"] = "centavos",
                ["fr"] = "cents"
            },
            MajorUnitNames = new()
            {
                ["en"] = "dollars",
                ["tr"] = "dolar",
                ["az"] = "dollar",
                ["es"] = "dólares",
                ["fr"] = "dollars"
            },
            Countries = new() { "US", "EC", "SV", "ZW", "BZ", "TC", "PW", "MH", "FM", "GU", "AS", "VI", "PR", "MP" }
        },
        ["EUR"] = new()
        {
            Code = "EUR",
            Symbol = "€",
            Name = "Euro",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "cents", 
                ["tr"] = "sent", 
                ["de"] = "Cent", 
                ["fr"] = "centimes", 
                ["az"] = "sent",
                ["es"] = "céntimos",
                ["it"] = "centesimi"
            },
            MajorUnitNames = new()
            {
                ["en"] = "euros",
                ["tr"] = "euro",
                ["de"] = "Euro",
                ["fr"] = "euros",
                ["az"] = "avro",
                ["es"] = "euros",
                ["it"] = "euro"
            },
            Countries = new() { "AT", "BE", "CY", "EE", "FI", "FR", "DE", "GR", "IE", "IT", "LV", "LT", "LU", "MT", "NL", "PT", "SK", "SI", "ES" }
        },
        ["TRY"] = new()
        {
            Code = "TRY",
            Symbol = "₺",
            Name = "Turkish Lira",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "kuruş", 
                ["tr"] = "kuruş", 
                ["az"] = "quruş" 
            },
            MajorUnitNames = new()
            {
                ["en"] = "lira",
                ["tr"] = "lira",
                ["az"] = "lirə"
            },
            Countries = new() { "TR" }
        },
        ["AZN"] = new()
        {
            Code = "AZN",
            Symbol = "₼",
            Name = "Azerbaijani Manat",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "qəpik", 
                ["tr"] = "qəpik", 
                ["az"] = "qəpik" 
            },
            MajorUnitNames = new()
            {
                ["en"] = "manat",
                ["tr"] = "manat",
                ["az"] = "manat"
            },
            Countries = new() { "AZ" }
        },
        ["GBP"] = new()
        {
            Code = "GBP",
            Symbol = "£",
            Name = "British Pound Sterling",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "pence", 
                ["tr"] = "peni", 
                ["az"] = "pens" 
            },
            MajorUnitNames = new()
            {
                ["en"] = "pounds",
                ["tr"] = "sterlin",
                ["az"] = "funt"
            },
            Countries = new() { "GB", "IM", "JE", "GG" }
        },
        ["JPY"] = new()
        {
            Code = "JPY",
            Symbol = "¥",
            Name = "Japanese Yen",
            DecimalPlaces = 0,
            MinorUnitNames = new() 
            { 
                ["en"] = "sen", 
                ["tr"] = "sen", 
                ["az"] = "sen",
                ["ja"] = "銭"
            },
            MajorUnitNames = new()
            {
                ["en"] = "yen",
                ["tr"] = "yen",
                ["az"] = "yen",
                ["ja"] = "円"
            },
            Countries = new() { "JP" }
        },
        ["CNY"] = new()
        {
            Code = "CNY",
            Symbol = "¥",
            Name = "Chinese Yuan",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "fen", 
                ["tr"] = "fen", 
                ["az"] = "fen",
                ["zh"] = "分"
            },
            Countries = new() { "CN" }
        },
        ["RUB"] = new()
        {
            Code = "RUB",
            Symbol = "₽",
            Name = "Russian Ruble",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "kopecks", 
                ["tr"] = "kopek", 
                ["ru"] = "копейки", 
                ["az"] = "kopek" 
            },
            Countries = new() { "RU" }
        },
        ["CAD"] = new()
        {
            Code = "CAD",
            Symbol = "C$",
            Name = "Canadian Dollar",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "cents", 
                ["fr"] = "cents",
                ["tr"] = "sent", 
                ["az"] = "sent"
            },
            Countries = new() { "CA" }
        },
        ["AUD"] = new()
        {
            Code = "AUD",
            Symbol = "A$",
            Name = "Australian Dollar",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "cents", 
                ["tr"] = "sent", 
                ["az"] = "sent"
            },
            Countries = new() { "AU", "CX", "CC", "HM", "KI", "NR", "NF", "TV" }
        },
        ["CHF"] = new()
        {
            Code = "CHF",
            Symbol = "CHF",
            Name = "Swiss Franc",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "rappen", 
                ["de"] = "Rappen",
                ["fr"] = "centimes",
                ["it"] = "centesimi",
                ["tr"] = "rapen", 
                ["az"] = "rapen"
            },
            Countries = new() { "CH", "LI" }
        },
        ["SEK"] = new()
        {
            Code = "SEK",
            Symbol = "kr",
            Name = "Swedish Krona",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "öre", 
                ["sv"] = "öre",
                ["tr"] = "öre", 
                ["az"] = "öre"
            },
            Countries = new() { "SE" }
        },
        ["NOK"] = new()
        {
            Code = "NOK",
            Symbol = "kr",
            Name = "Norwegian Krone",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "øre", 
                ["no"] = "øre",
                ["tr"] = "øre", 
                ["az"] = "øre"
            },
            Countries = new() { "NO", "SJ", "BV" }
        },
        ["DKK"] = new()
        {
            Code = "DKK",
            Symbol = "kr",
            Name = "Danish Krone",
            DecimalPlaces = 2,
            MinorUnitNames = new() 
            { 
                ["en"] = "øre", 
                ["da"] = "øre",
                ["tr"] = "øre", 
                ["az"] = "øre"
            },
            Countries = new() { "DK", "FO", "GL" }
        }
    };

    /// <summary>
    /// Gets currency information by currency code.
    /// </summary>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <returns>Currency information or null if not found</returns>
    public static CurrencyInfo? GetCurrency(string currencyCode)
    {
        return _currencies.TryGetValue(currencyCode.ToUpper(), out var currency) ? currency : null;
    }

    /// <summary>
    /// Gets all supported currencies.
    /// </summary>
    /// <returns>Dictionary of all supported currencies</returns>
    public static IReadOnlyDictionary<string, CurrencyInfo> GetAllCurrencies()
    {
        return _currencies;
    }

    /// <summary>
    /// Checks if a currency code is supported.
    /// </summary>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <returns>True if supported, false otherwise</returns>
    public static bool IsSupported(string currencyCode)
    {
        return _currencies.ContainsKey(currencyCode.ToUpper());
    }

    /// <summary>
    /// Gets currencies used in a specific country.
    /// </summary>
    /// <param name="countryCode">ISO 3166-1 alpha-2 country code</param>
    /// <returns>List of currencies used in the country</returns>
    public static List<CurrencyInfo> GetCurrenciesByCountry(string countryCode)
    {
        return _currencies.Values
            .Where(c => c.Countries.Contains(countryCode.ToUpper()))
            .ToList();
    }
}
