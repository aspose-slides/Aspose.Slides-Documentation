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
    private static void Main()
    {
        ApplyLicense();
        using var rsa = RSA.Create(2048);
        var request = new CertificateRequest("CN=Disposable presentation example", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, false));
        using var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow.AddMinutes(-5), DateTimeOffset.UtcNow.AddDays(2));
        Require(certificate.HasPrivateKey, "Certificate has no signing key.");
        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Signed example");
            original.Save("original.pptx", SaveFormat.Pptx);
        }
        string originalHash = Hash("original.pptx");
        using (var sign = new Presentation("original.pptx"))
        {
            sign.DigitalSignatures.Add(new DigitalSignature(certificate) { Comments = "Disposable example signature" });
            sign.Save("signed.pptx", SaveFormat.Pptx);
        }
        using (var signed = new Presentation("signed.pptx"))
        {
            Require(signed.DigitalSignatures.Count == 1 && signed.DigitalSignatures[0].IsValid, "Saved signature is invalid.");
            Require(signed.DigitalSignatures[0].Certificate.Thumbprint == certificate.Thumbprint, "Unexpected signer.");
        }
        File.Copy("signed.pptx", "tampered.pptx", true);
        using (var archive = ZipFile.Open("tampered.pptx", ZipArchiveMode.Update))
        {
            var slide = archive.GetEntry("ppt/slides/slide1.xml") ?? throw new InvalidOperationException("Slide XML missing.");
            string xml;
            using (var reader = new StreamReader(slide.Open())) xml = reader.ReadToEnd();
            Require(xml.Contains("Signed example", StringComparison.Ordinal), "Fixture marker missing.");
            slide.Delete();
            using var writer = new StreamWriter(archive.CreateEntry("ppt/slides/slide1.xml").Open(), new UTF8Encoding(false));
            writer.Write(xml.Replace("Signed example", "Changed example", StringComparison.Ordinal));
        }
        using (var tampered = new Presentation("tampered.pptx"))
            Require(tampered.DigitalSignatures.Count == 1 && !tampered.DigitalSignatures[0].IsValid, "Tampering was accepted.");
        using var chain = new X509Chain();
        chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        bool trusted = chain.Build(certificate);
        Require(!trusted, "Disposable self-signed certificate unexpectedly trusted.");
        Require(DateTime.UtcNow >= certificate.NotBefore.ToUniversalTime() && DateTime.UtcNow < certificate.NotAfter.ToUniversalTime(), "Test certificate expired.");
        Require(Hash("original.pptx") == originalHash, "Original changed.");
        Report(new { signature_count = 1, signed_valid = true, tamper_invalid = true, self_signed_untrusted = true, certificate_not_expired = true, private_key_written = false, original_unchanged = true });
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
