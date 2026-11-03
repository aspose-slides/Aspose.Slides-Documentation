---
title: Find and Replace Text Across a Deck
type: docs
weight: 10
url: /net/examples/fonts-text/find-replace/
description: "Replace literal and regular-expression matches across slides, groups, tables, masters and notes."
keywords:
- C# example
- .NET
- presentation
- Aspose.Slides
---

Replace literal and regular-expression matches across slides, groups, tables, masters and notes.

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

An application-owned traversal selects the text frames to process. Replacement operates on each full frame, so a literal match can span text runs. This fixture includes a run-spanning match, grouped shape, table cell, master text, speaker notes and unrelated styled text. Notes are explicitly included.

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

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static IEnumerable<ITextFrame> Frames(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            if (shape is IAutoShape auto && auto.TextFrame != null) yield return auto.TextFrame;
            if (shape is IGroupShape group)
                foreach (var frame in Frames(group.Shapes)) yield return frame;
            if (shape is ITable table)
                for (int row = 0; row < table.Rows.Count; row++)
                    for (int column = 0; column < table.Columns.Count; column++) yield return table[column, row].TextFrame;
        }
    }

    private static IEnumerable<ITextFrame> AllFrames(Presentation p)
    {
        foreach (var slide in p.Slides)
        {
            foreach (var frame in Frames(slide.Shapes)) yield return frame;
            if (slide.NotesSlideManager.NotesSlide?.NotesTextFrame is ITextFrame notes) yield return notes;
        }
        foreach (var master in p.Masters)
            foreach (var frame in Frames(master.Shapes)) yield return frame;
    }

    private static void ReplacePresentationText()
    {
        CreateInput();
        string originalHash = Hash("input.pptx");
        using (var editable = new Presentation("input.pptx"))
        {
            var options = new TextSearchOptions { CaseSensitive = true };
            foreach (var frame in AllFrames(editable))
            {
                frame.ReplaceText("OLD", "NEW", options, null);
                frame.ReplaceRegex(new Regex(@"\b2025\b"), "2026", null);
            }
            Require(AllFrames(editable).Count(f => f.Text == Context.ExpectedText("NEW 2026")) == 5, "A target location was missed.");
            string beforeNoMatch = string.Join("|", AllFrames(editable).Select(f => f.Text));
            foreach (var frame in AllFrames(editable)) frame.ReplaceText("NO-SUCH-MARKER", "ignored", options, null);
            Require(beforeNoMatch == string.Join("|", AllFrames(editable).Select(f => f.Text)), "No-match replacement changed text.");
            editable.Save("output.pptx", SaveFormat.Pptx);
        }
        VerifyOutput(originalHash);
    }
}
```

## Run and inspect the result

Extract the download into an empty directory and run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release --no-restore -- --mode evaluation
```

The code writes "input.pptx", "output.pptx", "preview.png", plus "result.json". Checks stop execution on an unexpected result; inspect visual outputs as well as the recorded data.

## Practical limits

The traversal below covers the demonstrated shapes, groups, tables, masters and notes. Additional object types such as SmartArt require their own text traversal. Choose note/master participation deliberately. A match spanning differently formatted runs may inherit formatting from part of the original; inspect the result when formatting boundaries matter.

Read the [detailed guide](/slides/net/search-and-replace-text/) for the full API and platform requirements.
