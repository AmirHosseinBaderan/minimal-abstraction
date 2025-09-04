using System.Reflection;

namespace Cloudito.Services.Common;

public class AppVersion
{
    public static string? GetVersion() => Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString();
}
