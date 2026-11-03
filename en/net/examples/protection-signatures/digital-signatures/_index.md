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

The program creates an RSA key and short-lived self-signed certificate in memory. No private key or PFX is written. It signs the original deck, verifies the saved signature, changes a slide XML part in a separate copy while retaining its signature, and checks that the changed copy is invalid.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

No certificate file is required: this demonstration creates a two-day, self-signed certificate in memory. The signature integrity verdict and the machine’s certificate trust verdict are separate. A production signer needs a suitable trusted certificate.

```csharp
using System;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
        // Create an ephemeral test certificate; no private key is written to disk.
        using var signingKey = RSA.Create(2048);
        var certificateRequest = new CertificateRequest("CN=Disposable presentation example", signingKey, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        certificateRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, false));
        using var certificate = certificateRequest.CreateSelfSigned(DateTimeOffset.UtcNow.AddMinutes(-5), DateTimeOffset.UtcNow.AddDays(2));
        if (!certificate.HasPrivateKey)
        {
            Console.Error.WriteLine("The signing certificate has no private key.");
            return;
        }

        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Signed example");
            original.Save("example-output/original.pptx", SaveFormat.Pptx);
        }

        using (var presentation = new Presentation("example-output/original.pptx"))
        {
            var signature = new DigitalSignature(certificate)
            {
                Comments = "Disposable example signature"
            };
            presentation.DigitalSignatures.Add(signature);
            presentation.Save("example-output/signed.pptx", SaveFormat.Pptx);
        }

        using (var signed = new Presentation("example-output/signed.pptx"))
            Console.WriteLine($"Signed copy integrity: {signed.DigitalSignatures[0].IsValid}");
        // Deliberately alter only the copy, without re-signing its package.
        File.Copy("example-output/signed.pptx", "example-output/tampered.pptx", true);
        using (var archive = ZipFile.Open("example-output/tampered.pptx", ZipArchiveMode.Update))
        {
            var slidePart = archive.GetEntry("ppt/slides/slide1.xml");
            if (slidePart == null)
            {
                Console.Error.WriteLine("The expected slide part is missing.");
                return;
            }

            string slideXml;
            using (var reader = new StreamReader(slidePart.Open()))
                slideXml = reader.ReadToEnd();
            if (!slideXml.Contains("Signed example", StringComparison.Ordinal))
            {
                Console.Error.WriteLine("The expected fixture text is missing.");
                return;
            }

            slidePart.Delete();
            using var writer = new StreamWriter(archive.CreateEntry("ppt/slides/slide1.xml").Open(), new UTF8Encoding(false));
            writer.Write(slideXml.Replace("Signed example", "Changed example", StringComparison.Ordinal));
        }

        using (var tampered = new Presentation("example-output/tampered.pptx"))
            Console.WriteLine($"Tampered copy integrity: {tampered.DigitalSignatures[0].IsValid}");
        using var trustChain = new X509Chain();
        trustChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        Console.WriteLine($"Certificate trusted by this machine: {trustChain.Build(certificate)}");
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

The code writes "original.pptx", "signed.pptx", "tampered.pptx", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## **Practical limits**

The certificate is disposable test data and is deliberately untrusted. IsValid checks the signature against the presentation content; it does not establish the trust chain, revocation status, expected signer identity or a trusted timestamp. Check the expected signature count as well as validity. Production signing must use protected keys and the trust policy of your application.

Read the [detailed guide](/slides/net/digital-signature-in-powerpoint/) for the full API and platform requirements.
