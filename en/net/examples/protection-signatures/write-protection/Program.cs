using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("protection-signatures/write-protection/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("protection-signatures/write-protection/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
        const string editPassword = "edit-demo";
        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Editing example");
            original.Save("original.pptx", SaveFormat.Pptx);
        }
        string originalHash = Hash("original.pptx");
        using (var protect = new Presentation("original.pptx"))
        {
            protect.ProtectionManager.SetWriteProtection(editPassword);
            protect.Save("edit-protected.pptx", SaveFormat.Pptx);
        }
        using (var readOnly = new Presentation("original.pptx"))
        {
            readOnly.ProtectionManager.ReadOnlyRecommended = true;
            readOnly.Save("read-only.pptx", SaveFormat.Pptx);
        }
        using (var protectedCopy = new Presentation("edit-protected.pptx"))
        {
            Require(protectedCopy.ProtectionManager.IsWriteProtected, "Write protection missing.");
            Require(protectedCopy.ProtectionManager.CheckWriteProtection(editPassword), "Known edit password not accepted.");
            Require(!protectedCopy.ProtectionManager.CheckWriteProtection("wrong-demo"), "Wrong edit password accepted.");
            Require(!protectedCopy.ProtectionManager.IsEncrypted, "Write protection was confused with encryption.");
            protectedCopy.ProtectionManager.RemoveWriteProtection();
            protectedCopy.ProtectionManager.ReadOnlyRecommended = false;
            protectedCopy.Save("unprotected.pptx", SaveFormat.Pptx);
        }
        using (var recommended = new Presentation("read-only.pptx"))
            Require(recommended.ProtectionManager.ReadOnlyRecommended && !recommended.ProtectionManager.IsEncrypted, "Read-only flag was not retained.");
        using (var unprotected = new Presentation("unprotected.pptx"))
            Require(!unprotected.ProtectionManager.IsWriteProtected && !unprotected.ProtectionManager.ReadOnlyRecommended, "Protection remains.");
        Require(Hash("original.pptx") == originalHash, "Original changed.");
        Report(new { edit_protected = true, correct_edit_password = true, wrong_edit_password_rejected = true, read_only_recommended = true, opens_without_open_password = true, removed = true, original_unchanged = true });
    }


    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }
    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))).ToLowerInvariant();
    private static void Report(object checks)
    {
        string json = JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
    private static void Render(ISlide slide, string output)
    {
        using var image = slide.GetImage(new Size(640, 360));
        image.Save(output, Aspose.Slides.ImageFormat.Png);
    }
}
