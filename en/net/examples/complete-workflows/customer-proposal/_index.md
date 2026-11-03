---
title: "Assemble a Customer Proposal"
type: docs
weight: 20
url: /net/examples/complete-workflows/customer-proposal/
description: "Complete runnable C# project to assemble a customer proposal using Aspose.Slides for .NET."
---

Assemble a customer proposal from a synthetic product catalog and a JSON selection. The complete project creates a cover, copies the chosen product slides in request order, and saves an editable deck and a PDF. The original catalog remains unchanged.

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Inputs and execution

[Download the complete project](example.zip), including its original inputs, all source and pinned dependencies. The project uses bundled Noto Sans and the flexible SDK policy described in the setup guide. Set `ASPOSE_LICENSE_PATH` to your license file; unrestricted content checks require a valid license. See [licensing](/slides/net/licensing/). No PowerPoint installation is required.

```text
dotnet run --project Example.csproj --configuration Release
```

The program generates its own original presentation/template fixture. JSON inputs, when present, are included in the download. All output files are separate from those inputs.

## Complete project source

The code below shows the main operation. The runnable download includes [ExampleSupport.cs](ExampleSupport.cs) with the entry point and supporting code.

```csharp
using System.IO.Compression;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    private static void RunExample()
    {
        var request = JsonDocument.Parse(File.ReadAllText("customer.json")).RootElement;
        string customer = request.GetProperty("customer").GetString()!;
        int[] selected = request.GetProperty("product_indices").EnumerateArray().Select(v => v.GetInt32()).ToArray();
        using (var catalog = Deck("Analytics", "Planning", "Reporting")) catalog.Save("catalog.pptx", SaveFormat.Pptx);
        string original = Hash("catalog.pptx");
        using var source = new Presentation("catalog.pptx");
        Require(selected.All(i => i >= 0 && i < source.Slides.Count), "Unknown product selection.");
        using var proposal = Deck("Proposal for " + customer);
        foreach (int i in selected) proposal.Slides.AddClone(source.Slides[i]);
        proposal.Save("proposal.pptx", SaveFormat.Pptx); proposal.Save("proposal.pdf", SaveFormat.Pdf);
        using var reopened = new Presentation("proposal.pptx");
        Require(reopened.Slides.Count == selected.Length + 1 && Text(reopened.Slides[0]) == Context.ExpectedText("Proposal for " + customer), "Proposal identity or count is wrong.");
        string[] expectedOrder = selected.Select(i => Text(source.Slides[i])).ToArray();
        for (int i = 0; i < expectedOrder.Length; i++)
            Require(Text(reopened.Slides[i + 1]) == expectedOrder[i], "Product order changed.");
        Require(SavedText("proposal.pptx").Contains("Proposal for " + customer), "Persisted customer identity differs.");
        Require(Hash("catalog.pptx") == original, "Catalog was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { customer, product_order = string.Join(",", expectedOrder), slides = reopened.Slides.Count, input_preserved = true });
    }
}
```

## Expected outputs

The project writes proposal.pptx, proposal.pdf, preview.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
