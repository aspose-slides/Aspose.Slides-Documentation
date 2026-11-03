---
title: "Prepare a Distribution Copy"
type: docs
weight: 40
url: /net/examples/complete-workflows/distribution-copy/
description: "Complete runnable C# project to prepare a distribution copy using Aspose.Slides for .NET."
---

Prepare a separate distribution copy with an explicit removal list: speaker notes, comments, author/custom metadata and the VBA project. Add a visual watermark and a password-protected PDF. The synthetic original stays unchanged. This is not forensic sanitization: hyperlinks, embedded files, hidden objects and other properties require their own review.

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
        using (var input = Deck("Quarterly update", "Public summary"))
        {
            input.DocumentProperties.Author = "Example internal author"; input.DocumentProperties.SetCustomPropertyValue("ReviewStatus", "Draft");
            input.Slides[0].NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "Private example note";
            var author = input.CommentAuthors.AddAuthor("Example reviewer", "ER");
            author.Comments.AddComment("Example review", input.Slides[0], new PointF(10, 10), DateTime.UtcNow);
            input.VbaProject = new VbaProject();
            input.VbaProject.Modules.AddEmptyModule("SampleModule").SourceCode = "Sub Example()\nEnd Sub";
            input.Save("original.pptm", SaveFormat.Pptm);
        }
        string original = Hash("original.pptm");
        using var copy = new Presentation("original.pptm");
        foreach (var slide in copy.Slides)
        {
            if (slide.NotesSlideManager.NotesSlide != null) slide.NotesSlideManager.RemoveNotesSlide();
            Label(slide, "DISTRIBUTION COPY", "DistributionWatermark", 520, 450, 400, 55);
        }
        foreach (var reviewer in copy.CommentAuthors) reviewer.Comments.Clear();
        copy.CommentAuthors.Clear(); copy.VbaProject = null;
        copy.DocumentProperties.Author = ""; copy.DocumentProperties.ClearCustomProperties();
        copy.Save("distribution.pptx", SaveFormat.Pptx);
        string password = Environment.GetEnvironmentVariable("OUTPUT_PDF_PASSWORD") ?? "demonstration-only";
        copy.Save("distribution.pdf", SaveFormat.Pdf, new PdfOptions { Password = password });
        using var reopened = new Presentation("distribution.pptx");
        Require(reopened.VbaProject == null && reopened.CommentAuthors.Count == 0 && reopened.DocumentProperties.CountOfCustomProperties == 0, "Selected removals failed.");
        Require(reopened.Slides.All(s => s.NotesSlideManager.NotesSlide == null), "Notes remain.");
        Require(Hash("original.pptm") == original, "Original was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { notes_removed = true, comments_removed = true, macros_removed = true, custom_properties_removed = true, input_preserved = true });
    }
}
```

## Expected outputs

The project writes distribution.pptx, distribution.pdf, preview.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
