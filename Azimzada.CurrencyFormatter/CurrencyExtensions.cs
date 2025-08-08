namespace Azimzada.CurrencyFormatter;

/// <summary>
/// Extension methods for decimal and double types to enable fluent currency formatting.
/// </summary>
public static class CurrencyExtensions
{
    /// <summary>
    /// Formats the decimal value as currency.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code (e.g., "USD", "EUR", "TRY")</param>
    /// <param name="cultureName">Culture name (e.g., "en-US", "tr-TR", "de-DE"). If null, uses current culture.</param>
    /// <returns>Formatted currency string</returns>
    /// <example>
    /// <code>
    /// var formatted = 1234.56m.ToCurrency("USD", "en-US");
    /// // Result: "$1,234.56"
    /// </code>
    /// </example>
    public static string ToCurrency(this decimal amount, string currencyCode, string? cultureName = null)
    {
        return CurrencyFormatter.Format(amount, currencyCode, cultureName);
    }

    /// <summary>
    /// Formats the double value as currency.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <returns>Formatted currency string</returns>
    public static string ToCurrency(this double amount, string currencyCode, string? cultureName = null)
    {
        return CurrencyFormatter.Format((decimal)amount, currencyCode, cultureName);
    }

    /// <summary>
    /// Formats the int value as currency.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <returns>Formatted currency string</returns>
    public static string ToCurrency(this int amount, string currencyCode, string? cultureName = null)
    {
        return CurrencyFormatter.Format(amount, currencyCode, cultureName);
    }

    /// <summary>
    /// Formats the decimal value as compact currency (K, M, B notation).
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <param name="precision">Number of decimal places for compact notation (default: 1)</param>
    /// <returns>Compact formatted currency string</returns>
    /// <example>
    /// <code>
    /// var formatted = 1234567m.ToCompactCurrency("USD", "en-US");
    /// // Result: "$1.2M"
    /// </code>
    /// </example>
    public static string ToCompactCurrency(this decimal amount, string currencyCode, string? cultureName = null, int precision = 1)
    {
        return CurrencyFormatter.ToCompactFormat(amount, currencyCode, cultureName, precision);
    }

    /// <summary>
    /// Formats the double value as compact currency (K, M, B notation).
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <param name="precision">Number of decimal places for compact notation (default: 1)</param>
    /// <returns>Compact formatted currency string</returns>
    public static string ToCompactCurrency(this double amount, string currencyCode, string? cultureName = null, int precision = 1)
    {
        return CurrencyFormatter.ToCompactFormat((decimal)amount, currencyCode, cultureName, precision);
    }

    /// <summary>
    /// Formats the int value as compact currency (K, M, B notation).
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <param name="precision">Number of decimal places for compact notation (default: 1)</param>
    /// <returns>Compact formatted currency string</returns>
    public static string ToCompactCurrency(this int amount, string currencyCode, string? cultureName = null, int precision = 1)
    {
        return CurrencyFormatter.ToCompactFormat(amount, currencyCode, cultureName, precision);
    }

    /// <summary>
    /// Formats the decimal value as currency with minor units displayed separately.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <param name="showMinorUnits">Whether to show minor units separately</param>
    /// <returns>Formatted currency string with minor units</returns>
    /// <example>
    /// <code>
    /// var formatted = 1234.56m.ToCurrencyWithMinorUnits("USD", "en-US");
    /// // Result: "$1,234 56 cents"
    /// </code>
    /// </example>
    public static string ToCurrencyWithMinorUnits(this decimal amount, string currencyCode, string? cultureName = null, bool showMinorUnits = true)
    {
        return CurrencyFormatter.FormatWithMinorUnits(amount, currencyCode, cultureName, showMinorUnits);
    }

    /// <summary>
    /// Formats the double value as currency with minor units displayed separately.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <param name="showMinorUnits">Whether to show minor units separately</param>
    /// <returns>Formatted currency string with minor units</returns>
    public static string ToCurrencyWithMinorUnits(this double amount, string currencyCode, string? cultureName = null, bool showMinorUnits = true)
    {
        return CurrencyFormatter.FormatWithMinorUnits((decimal)amount, currencyCode, cultureName, showMinorUnits);
    }

    /// <summary>
    /// Formats the int value as currency with minor units displayed separately.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <param name="showMinorUnits">Whether to show minor units separately</param>
    /// <returns>Formatted currency string with minor units</returns>
    public static string ToCurrencyWithMinorUnits(this int amount, string currencyCode, string? cultureName = null, bool showMinorUnits = true)
    {
        return CurrencyFormatter.FormatWithMinorUnits(amount, currencyCode, cultureName, showMinorUnits);
    }

    /// <summary>
    /// Formats the decimal value as detailed currency units (e.g., "10 min 123 manat 23 qəpik").
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <returns>Detailed formatted currency string</returns>
    /// <example>
    /// <code>
    /// var formatted = 10123.23m.ToDetailedCurrency("AZN", "az-AZ");
    /// // Result: "10 min 123 manat 23 qəpik"
    /// </code>
    /// </example>
    public static string ToDetailedCurrency(this decimal amount, string currencyCode, string? cultureName = null)
    {
        return CurrencyFormatter.FormatWithDetailedUnits(amount, currencyCode, cultureName);
    }

    /// <summary>
    /// Formats the double value as detailed currency units.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <returns>Detailed formatted currency string</returns>
    public static string ToDetailedCurrency(this double amount, string currencyCode, string? cultureName = null)
    {
        return CurrencyFormatter.FormatWithDetailedUnits((decimal)amount, currencyCode, cultureName);
    }

    /// <summary>
    /// Formats the int value as detailed currency units.
    /// </summary>
    /// <param name="amount">The amount to format</param>
    /// <param name="currencyCode">ISO 4217 currency code</param>
    /// <param name="cultureName">Culture name. If null, uses current culture.</param>
    /// <returns>Detailed formatted currency string</returns>
    public static string ToDetailedCurrency(this int amount, string currencyCode, string? cultureName = null)
    {
        return CurrencyFormatter.FormatWithDetailedUnits(amount, currencyCode, cultureName);
    }
}
