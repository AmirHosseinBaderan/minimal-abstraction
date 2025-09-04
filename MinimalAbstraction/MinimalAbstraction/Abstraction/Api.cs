namespace Cloudito.Services.Common;

public record ApiModel(int Code, bool Status, string Message, object? Result);

public record ApiModel<TModel>(int Code, bool Status, string Message, TModel? Result);

public static class ApiResponse
{
    public static string Lang { get; set; } = "fa-ir";

    public static ApiModel Success(string message, object? result)
        => new(200, true, message, result);

    public static ApiModel ApiException(string message = "خطایی رخ داد مجدادا تلاش کنید")
            => new(500, false, message, new { });

    public static ApiModel Faild(int code, string message)
        => new(code, false, message, new { });

    public static ApiModel AccessDenied()
        => new(403, false, "شما به این بخش دسترسی ندارید", new { });

    public static ApiModel AppNotfound()
       => new(403, false, "اپلیکیشن یافت نشد", new { });
}