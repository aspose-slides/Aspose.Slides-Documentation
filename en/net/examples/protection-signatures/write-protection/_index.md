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

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## Input and prerequisites

Use a supported .NET SDK with the supplied project. Evaluation mode runs without a license; licensed mode requires your own authorized license covering this release. No license is distributed.

All presentation input is created by the code from original synthetic data.

[Download the complete project](example.zip), including code, solution, project and required helpers. Normal package restore is supported.

## Example

The program sets an edit password on one copy and read-only recommendation on another. Both files are opened without an opening password, demonstrating that these controls are different from encryption. It checks the edit password before removing the protection.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

```csharp
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using Aspose.Slides;

internal static class Program
{
    private static Task<int> Main() => RunChecked();

    private static void ManageWriteProtection()
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

    private static IAutoShape Label(IBaseSlide slide, string text, float y = 50)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, y, 560, 90);
        shape.TextFrame.Text = text;
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        return shape;
    }

    private static ExampleContext Context = null!;

    private static Task<int> RunChecked() => ExampleBootstrap.RunAsync(async context =>
    {
        Context = context;
        ManageWriteProtection();
        await Task.CompletedTask;
    });

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
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

internal static class ExampleBootstrap
{
    public static async Task<int> RunAsync(Func<ExampleContext, Task> run)
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        string start = Environment.CurrentDirectory;
        string output = Directory.CreateDirectory(Path.Combine(start, "example-output")).FullName;
        try
        {
            Environment.CurrentDirectory = output;
            await run(new ExampleContext(output, !string.IsNullOrWhiteSpace(licensePath)));
            Console.WriteLine("Output: " + output);
            return 0;
        }
        finally
        {
            Environment.CurrentDirectory = start;
        }
    }
}

internal sealed record ExampleContext(string OutputRoot, bool IsLicensed);
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "original.pptx", "edit-protected.pptx", "read-only.pptx", "unprotected.pptx", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

An editing restriction or read-only recommendation does not encrypt the file. Application behavior varies: a reader may offer a password prompt, an editable copy, or allow programmatic editing. Shape locks control individual objects and are a separate feature.

Read the [detailed guide](/slides/net/write-protected-presentation/) for the full API and platform requirements.
