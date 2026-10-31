---
title: Sign and Verify Presentations
type: docs
weight: 30
url: /net/examples/protection-signatures/digital-signatures/
description: "Sign a synthetic presentation with a disposable test certificate, then detect a changed signed copy."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Sign a synthetic presentation with a disposable test certificate, then detect a changed signed copy.

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Input and prerequisites

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

All presentation input is created by the code from original synthetic data.

[Download the complete project](example.zip), including code, solution, project and required helpers. Normal package restore is supported.

## Example

The program creates an RSA key and short-lived self-signed certificate in memory. No private key or PFX is written. It signs the original deck, verifies the saved signature, changes a slide XML part in a separate copy while retaining its signature, and checks that the changed copy is invalid.

```csharp
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
        context.BeginAction("protection-signatures/digital-signatures/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("protection-signatures/digital-signatures/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
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
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation -- --mode evaluation
```

The code writes "original.pptx", "signed.pptx", "tampered.pptx", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

The certificate is disposable test data and is deliberately untrusted. IsValid checks the signature against the presentation content; it does not establish the trust chain, revocation status, expected signer identity or a trusted timestamp. Check the expected signature count as well as validity. Production signing must use protected keys and the trust policy of your application.

Read the [detailed guide](/slides/net/digital-signature-in-powerpoint/) for the full API and platform requirements.
