---
title: Open and Encrypt Presentations
type: docs
weight: 10
url: /net/examples/protection-signatures/passwords/
description: "Open an encrypted presentation with a known password and save encrypted or unencrypted copies."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Open an encrypted presentation with a known password and save encrypted or unencrypted copies.

## Input and prerequisites

Use .NET SDK 8.0.427 and Aspose.Slides for .NET 26.10.0 with the supplied pinned project. Set **ASPOSE_LICENSE_PATH** to your own valid license file; no license file is distributed. This complete fixture stops clearly when no license has been applied.

All presentation input is created by the code from original synthetic data.

[Download the complete project](example.zip), including code, project and package lock. It was executed on Windows.

## Example

The program creates its own unencrypted input, encrypts a separate copy, and verifies that missing or incorrect passwords are rejected. It then opens the encrypted file with the known password, removes encryption, and saves a new copy. The password shown is only for the synthetic fixture.

```csharp
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
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.csproj --locked-mode
dotnet run --project Example.csproj --configuration Release --no-restore
```

The code writes "original.pptx", "encrypted.pptx", "decrypted.pptx", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

Only process presentations you are authorized to open. Keep real passwords outside source and logs. Opening a protected file and removing encryption are separate operations; changing a file extension does not decrypt it.

Read the [detailed guide](/slides/net/password-protected-presentation/) for the full API and platform requirements.
