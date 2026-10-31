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

The program sets an edit password on one copy and read-only recommendation on another. Both files are opened without an opening password, demonstrating that these controls are different from encryption. It checks the edit password before removing the protection.

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
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation -- --mode evaluation
```

The code writes "original.pptx", "edit-protected.pptx", "read-only.pptx", "unprotected.pptx", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

An editing restriction or read-only recommendation does not encrypt the file. Application behavior varies: a reader may offer a password prompt, an editable copy, or allow programmatic editing. Shape locks control individual objects and are a separate feature.

Read the [detailed guide](/slides/net/write-protected-presentation/) for the full API and platform requirements.
