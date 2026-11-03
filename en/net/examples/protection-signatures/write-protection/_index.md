---
title: Set Editing Protection
type: docs
weight: 20
url: /net/examples/protection-signatures/write-protection/
description: "Set and remove edit-password protection and read-only recommendations while distinguishing them from encryption."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Set and remove edit-password protection and read-only recommendations while distinguishing them from encryption.

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

The program sets an edit password on one copy and read-only recommendation on another. Both files are opened without an opening password, demonstrating that these controls are different from encryption. It checks the edit password before removing the protection.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

Editing protection and the read-only recommendation do not encrypt presentation content. Every output opens without an open password. `edit-demo` is only a demonstration editing password.

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
        const string demoEditPassword = "edit-demo";
        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Editing example");
            original.Save("example-output/original.pptx", SaveFormat.Pptx);
        }

        using (var editableSource = new Presentation("example-output/original.pptx"))
        {
            editableSource.ProtectionManager.SetWriteProtection(demoEditPassword);
            editableSource.Save("example-output/edit-protected.pptx", SaveFormat.Pptx);
        }

        using (var protectedCopy = new Presentation("example-output/edit-protected.pptx"))
        {
            Console.WriteLine($"Write protected: {protectedCopy.ProtectionManager.IsWriteProtected}");
            Console.WriteLine($"Correct edit password: {protectedCopy.ProtectionManager.CheckWriteProtection(demoEditPassword)}");
            Console.WriteLine($"Wrong edit password: {protectedCopy.ProtectionManager.CheckWriteProtection("wrong-demo")}");
            Console.WriteLine($"Content encrypted: {protectedCopy.ProtectionManager.IsEncrypted}");
            protectedCopy.ProtectionManager.RemoveWriteProtection();
            protectedCopy.ProtectionManager.ReadOnlyRecommended = false;
            protectedCopy.Save("example-output/unprotected.pptx", SaveFormat.Pptx);
        }

        using (var readOnlyCopy = new Presentation("example-output/original.pptx"))
        {
            readOnlyCopy.ProtectionManager.ReadOnlyRecommended = true;
            readOnlyCopy.Save("example-output/read-only.pptx", SaveFormat.Pptx);
        }

        using var readOnly = new Presentation("example-output/read-only.pptx");
        using var cleared = new Presentation("example-output/unprotected.pptx");
        Console.WriteLine($"Read-only recommendation: {readOnly.ProtectionManager.ReadOnlyRecommended}");
        Console.WriteLine($"Cleared copy write protected: {cleared.ProtectionManager.IsWriteProtected}");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }
}
```

## **Run and inspect the result**

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "original.pptx", "edit-protected.pptx", "read-only.pptx", "unprotected.pptx", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## **Practical limits**

An editing restriction or read-only recommendation does not encrypt the file. Application behavior varies: a reader may offer a password prompt, an editable copy, or allow programmatic editing. Shape locks control individual objects and are a separate feature.

Read the [detailed guide](/slides/net/write-protected-presentation/) for the full API and platform requirements.
