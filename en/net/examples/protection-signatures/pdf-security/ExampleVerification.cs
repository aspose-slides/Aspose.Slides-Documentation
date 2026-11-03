using System.Threading.Tasks;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;

internal static partial class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> RunChecked(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("protection-signatures/pdf-security/block-001");
        SaveProtectedPdf();
        await Task.CompletedTask;
        context.Pass("protection-signatures/pdf-security/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });
    private static void Require(bool condition, string message)
    {
        if (!condition)
            throw new InvalidOperationException(message);
    }

    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
}
