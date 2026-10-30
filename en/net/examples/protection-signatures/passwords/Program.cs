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
    private static bool Rejected(string path, string? password)
    {
        try
        {
            using var unexpected = new Presentation(path, new LoadOptions { Password = password });
            return false;
        }
        catch (InvalidPasswordException) { return true; }
    }

    private static void Main()
    {
        ApplyLicense();
        const string password = "reader-demo";
        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Private example");
            original.Save("original.pptx", SaveFormat.Pptx);
        }
        string originalHash = Hash("original.pptx");
        using (var encrypt = new Presentation("original.pptx"))
        {
            encrypt.ProtectionManager.Encrypt(password);
            encrypt.Save("encrypted.pptx", SaveFormat.Pptx);
        }
        Require(PresentationFactory.Instance.GetPresentationInfo("encrypted.pptx").IsEncrypted, "Output is not encrypted.");
        bool missingRejected = Rejected("encrypted.pptx", null);
        bool wrongRejected = Rejected("encrypted.pptx", "incorrect-demo-password");
        Require(missingRejected && wrongRejected, "Incorrect credentials were accepted.");
        using (var authorized = new Presentation("encrypted.pptx", new LoadOptions { Password = password }))
        {
            Require(authorized.Slides[0].Shapes.OfType<IAutoShape>().Single().TextFrame.Text == "Private example", "Content changed.");
            authorized.ProtectionManager.RemoveEncryption();
            authorized.Save("decrypted.pptx", SaveFormat.Pptx);
        }
        Require(!PresentationFactory.Instance.GetPresentationInfo("decrypted.pptx").IsEncrypted, "Encryption remains.");
        using (var plain = new Presentation("decrypted.pptx")) Require(plain.Slides.Count == 1, "Decrypted copy is unreadable.");
        Require(Hash("original.pptx") == originalHash, "Original was changed.");
        Report(new { encrypted = true, correct_password = true, wrong_rejected = wrongRejected, missing_rejected = missingRejected, encryption_removed = true, original_unchanged = true });
    }


    private static void ApplyLicense()
    {
        var license = new Aspose.Slides.License();
        string? path = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(path)) license.SetLicense(path);
        if (!license.IsLicensed()) throw new InvalidOperationException("Set ASPOSE_LICENSE_PATH to a valid license file.");
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
