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

## **Download and run**

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## **Input and prerequisites**

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

All presentation input is created by the code from original synthetic data.

## **Example**

The program creates its own unencrypted input, encrypts a separate copy, and verifies that missing or incorrect passwords are rejected. It then opens the encrypted file with the known password, removes encryption, and saves a new copy. The password shown is only for the synthetic fixture.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

This self-contained program creates a plain input, encrypts a separate copy, tries missing and wrong passwords, and saves a decrypted copy. `reader-demo` is a demonstration password; replace it for real documents.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        const string demoPassword = "reader-demo";
        const string plainPath = "example-output/original.pptx";
        const string encryptedPath = "example-output/encrypted.pptx";
        const string decryptedPath = "example-output/decrypted.pptx";
        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Private example");
            original.Save(plainPath, SaveFormat.Pptx);
        }

        using (var presentation = new Presentation(plainPath))
        {
            presentation.ProtectionManager.Encrypt(demoPassword);
            presentation.Save(encryptedPath, SaveFormat.Pptx);
        }

        Console.WriteLine($"Missing password rejected: {IsPasswordRejected(encryptedPath, null)}");
        Console.WriteLine($"Wrong password rejected: {IsPasswordRejected(encryptedPath, "incorrect-demo-password")}");
        var loadOptions = new LoadOptions
        {
            Password = demoPassword
        };
        using (var authorized = new Presentation(encryptedPath, loadOptions))
        {
            authorized.ProtectionManager.RemoveEncryption();
            authorized.Save(decryptedPath, SaveFormat.Pptx);
        }

        using var decrypted = new Presentation(decryptedPath);
        Console.WriteLine($"Decrypted copy opens without credentials: {decrypted.Slides.Count} slide(s).");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }

    private static bool IsPasswordRejected(string path, string? password)
    {
        try
        {
            using var unexpected = new Presentation(path, new LoadOptions { Password = password });
            return false;
        }
        catch (InvalidPasswordException)
        {
            return true;
        }
    }
}
```

## **Run and inspect the result**

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "original.pptx", "encrypted.pptx", "decrypted.pptx", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## **Practical limits**

Only process presentations you are authorized to open. Keep real passwords outside source and logs. Opening a protected file and removing encryption are separate operations; changing a file extension does not decrypt it.

Read the [detailed guide](/slides/net/password-protected-presentation/) for the full API and platform requirements.
