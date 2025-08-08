using System.Globalization;

namespace Azimzada.CurrencyFormatter;

/// <summary>
/// Advanced currency formatter that supports all currencies, cultures, and compact formatting.
/// </summary>
public class CurrencyFormatter
{
    /// <summary>
    /// Formats an amount according to the specified culture and currency.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code (e.g., "USD", "EUR", "TRY")</param>
    /// <param name="cultureName">Culture name (e.g., "en-US", "tr-TR", "de-DE"). If null, uses current culture.</param>
    /// <returns>Formatted currency string</returns>
    public static string Format(decimal amount, string currencyCode, string? cultureName = null)
    {
        try
        {
            var culture = GetCulture(cultureName);
            var region = GetRegionInfoByCurrency(currencyCode, culture);
            
            var numberFormat = (NumberFormatInfo)culture.NumberFormat.Clone();
            numberFormat.CurrencySymbol = region.CurrencySymbol;
            
            return amount.ToString("C", numberFormat);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Invalid currency code '{currencyCode}' or culture '{cultureName}'", ex);
        }
    }

    /// <summary>
    /// Formats an amount in compact format (K for thousands, M for millions, B for billions).
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <param name="precision">Number of decimal places for compact notation (default: 1)</param>
    /// <returns>Compact formatted currency string</returns>
    public static string ToCompactFormat(decimal amount, string currencyCode, string? cultureName = null, int precision = 1)
    {
        try
        {
            var culture = GetCulture(cultureName);
            var region = GetRegionInfoByCurrency(currencyCode, culture);
            
            var (compactValue, suffix) = GetCompactNotation(amount);
            
            var numberFormat = (NumberFormatInfo)culture.NumberFormat.Clone();
            numberFormat.CurrencySymbol = region.CurrencySymbol;
            
            var formatString = $"C{precision}";
            var formattedValue = compactValue.ToString(formatString, numberFormat);
            
            return formattedValue + suffix;
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Invalid currency code '{currencyCode}' or culture '{cultureName}'", ex);
        }
    }

    /// <summary>
    /// Formats an amount with minor currency units (cents, kuruş, qəpik, etc.).
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <param name="showMinorUnits">Whether to show minor units separately</param>
    /// <returns>Formatted currency string with minor units</returns>
    public static string FormatWithMinorUnits(decimal amount, string currencyCode, string? cultureName = null, bool showMinorUnits = true)
    {
        try
        {
            var culture = GetCulture(cultureName);
            var region = GetRegionInfoByCurrency(currencyCode, culture);
            
            if (!showMinorUnits)
            {
                return Format(amount, currencyCode, cultureName);
            }

            var majorAmount = Math.Floor(amount);
            var minorAmount = (amount - majorAmount) * 100;
            
            var numberFormat = (NumberFormatInfo)culture.NumberFormat.Clone();
            numberFormat.CurrencySymbol = region.CurrencySymbol;
            
            var majorFormatted = majorAmount.ToString("C0", numberFormat);
            
            if (minorAmount > 0)
            {
                var minorUnitName = GetMinorUnitName(currencyCode, culture);
                return $"{majorFormatted} {minorAmount:00} {minorUnitName}";
            }
            
            return majorFormatted;
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Invalid currency code '{currencyCode}' or culture '{cultureName}'", ex);
        }
    }

    /// <summary>
    /// Formats an amount with detailed currency units in a verbose format (e.g., "10 min 123 manat 23 qəpik").
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <returns>Detailed formatted currency string</returns>
    public static string FormatWithDetailedUnits(decimal amount, string currencyCode, string? cultureName = null)
    {
        try
        {
            var culture = GetCulture(cultureName);
            var currencyInfo = CurrencyDatabase.GetCurrency(currencyCode);
            
            var majorAmount = Math.Floor(Math.Abs(amount));
            var minorAmount = Math.Round((Math.Abs(amount) - majorAmount) * 100, 0);
            
            var result = new List<string>();
            
            // Add negative sign if needed
            if (amount < 0)
            {
                var negativeWord = GetLocalizedWord("negative", culture);
                result.Add(negativeWord);
            }
            
            // Major currency units
            if (majorAmount > 0)
            {
                var majorUnitName = GetMajorUnitName(currencyCode, culture);
                
                // Split major amount into groups (millions, thousands, etc.)
                if (majorAmount >= 1000000)
                {
                    var millions = (long)(majorAmount / 1000000);
                    var remainder = majorAmount % 1000000;
                    
                    var millionWord = GetLocalizedWord("million", culture);
                    result.Add($"{millions} {millionWord}");
                    
                    if (remainder >= 1000)
                    {
                        var thousands = (long)(remainder / 1000);
                        remainder = remainder % 1000;
                        var thousandWord = GetLocalizedWord("thousand", culture);
                        result.Add($"{thousands} {thousandWord}");
                    }
                    
                    if (remainder > 0)
                    {
                        result.Add($"{remainder} {majorUnitName}");
                    }
                    else if (millions > 0 || majorAmount >= 1000000)
                    {
                        result.Add(majorUnitName);
                    }
                }
                else if (majorAmount >= 1000)
                {
                    var thousands = (long)(majorAmount / 1000);
                    var remainder = majorAmount % 1000;
                    
                    var thousandWord = GetLocalizedWord("thousand", culture);
                    result.Add($"{thousands} {thousandWord}");
                    
                    if (remainder > 0)
                    {
                        result.Add($"{remainder} {majorUnitName}");
                    }
                    else
                    {
                        result.Add(majorUnitName);
                    }
                }
                else
                {
                    result.Add($"{majorAmount} {majorUnitName}");
                }
            }
            
            // Minor currency units
            if (minorAmount > 0)
            {
                var minorUnitName = GetMinorUnitName(currencyCode, culture);
                result.Add($"{minorAmount} {minorUnitName}");
            }
            
            return result.Count > 0 ? string.Join(" ", result) : $"0 {GetMajorUnitName(currencyCode, culture)}";
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Invalid currency code '{currencyCode}' or culture '{cultureName}'", ex);
        }
    }

    private static CultureInfo GetCulture(string? cultureName)
    {
        return cultureName != null ? new CultureInfo(cultureName) : CultureInfo.CurrentCulture;
    }

    private static RegionInfo GetRegionInfoByCurrency(string currencyCode, CultureInfo culture)
    {
        // First try to find a region that uses this currency
        var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Where(c => !c.IsNeutralCulture)
            .Select(c => new RegionInfo(c.Name))
            .Where(r => r.ISOCurrencySymbol.Equals(currencyCode, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (regions.Any())
        {
            // Prefer the region that matches the current culture's country
            var preferredRegion = regions.FirstOrDefault(r => 
                r.Name.Equals(culture.Name.Split('-').LastOrDefault(), StringComparison.OrdinalIgnoreCase));
            
            return preferredRegion ?? regions.First();
        }

        // If no specific region found, create a custom one
        try
        {
            return new RegionInfo(culture.Name);
        }
        catch
        {
            return new RegionInfo("US"); // Fallback
        }
    }

    private static (decimal value, string suffix) GetCompactNotation(decimal amount)
    {
        var absAmount = Math.Abs(amount);
        
        if (absAmount >= 1_000_000_000_000m) // Trillions
            return (amount / 1_000_000_000_000m, "T");
        
        if (absAmount >= 1_000_000_000m) // Billions
            return (amount / 1_000_000_000m, "B");
        
        if (absAmount >= 1_000_000m) // Millions
            return (amount / 1_000_000m, "M");
        
        if (absAmount >= 1_000m) // Thousands
            return (amount / 1_000m, "K");
        
        return (amount, "");
    }

    private static string GetMinorUnitName(string currencyCode, CultureInfo culture)
    {
        var currencyInfo = CurrencyDatabase.GetCurrency(currencyCode);
        if (currencyInfo != null)
        {
            var languageCode = culture.TwoLetterISOLanguageName;
            if (currencyInfo.MinorUnitNames.TryGetValue(languageCode, out var unit))
                return unit;
            
            // Fallback to English
            if (currencyInfo.MinorUnitNames.TryGetValue("en", out var englishUnit))
                return englishUnit;
        }

        return "cents"; // Default fallback
    }

    private static string GetMajorUnitName(string currencyCode, CultureInfo culture)
    {
        var currencyInfo = CurrencyDatabase.GetCurrency(currencyCode);
        if (currencyInfo != null)
        {
            var languageCode = culture.TwoLetterISOLanguageName;
            if (currencyInfo.MajorUnitNames.TryGetValue(languageCode, out var unit))
                return unit;
            
            // Fallback to English
            if (currencyInfo.MajorUnitNames.TryGetValue("en", out var englishUnit))
                return englishUnit;
        }

        // Default fallback based on currency code
        return currencyCode.ToLower() switch
        {
            "usd" => "dollars",
            "eur" => "euros", 
            "try" => "lira",
            "azn" => "manat",
            "gbp" => "pounds",
            "jpy" => "yen",
            _ => currencyCode.ToLower()
        };
    }

    private static string GetLocalizedWord(string word, CultureInfo culture)
    {
        var languageCode = culture.TwoLetterISOLanguageName;
        
        var localizations = new Dictionary<string, Dictionary<string, string>>
        {
            ["negative"] = new()
            {
                ["en"] = "negative",
                ["tr"] = "eksi",
                ["az"] = "mənfi",
                ["de"] = "negativ",
                ["fr"] = "négatif",
                ["es"] = "negativo",
                ["it"] = "negativo",
                ["ru"] = "отрицательный"
            },
            ["million"] = new()
            {
                ["en"] = "million",
                ["tr"] = "milyon",
                ["az"] = "milyon",
                ["de"] = "Million",
                ["fr"] = "million",
                ["es"] = "millón",
                ["it"] = "milione",
                ["ru"] = "миллион"
            },
            ["thousand"] = new()
            {
                ["en"] = "thousand",
                ["tr"] = "bin",
                ["az"] = "min",
                ["de"] = "Tausend",
                ["fr"] = "mille",
                ["es"] = "mil",
                ["it"] = "mila",
                ["ru"] = "тысяча"
            }
        };

        if (localizations.TryGetValue(word, out var translations))
        {
            if (translations.TryGetValue(languageCode, out var translation))
                return translation;
            
            // Fallback to English
            if (translations.TryGetValue("en", out var englishTranslation))
                return englishTranslation;
        }

        return word; // Ultimate fallback
    }
}
