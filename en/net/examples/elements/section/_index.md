---
title: Section
type: docs
weight: 90
url: /net/examples/elements/section/
keywords:
- section
- slide section
- add section
- access section
- remove section
- rename section
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Manage slide sections in Aspose.Slides for .NET: create, rename, reorder, and group slides with C# examples for PPT, PPTX, and ODP."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Section**

Create a section that starts at a specific slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Specify the slide that marks the beginning of the section.
        presentation.Sections.AddSection("New Section", slide);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Sections.Count == 1 && p.Sections[0].Name == "New Section", "AddSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-001", "AddSection", "save-reopen-structure");
    }
}
```

## **Access a Section**

Read section information from a presentation.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        presentation.Sections.AddSection("My Section", slide);

        // Access a section by index.
        var section = presentation.Sections[0];
        var sectionName = section.Name;

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Sections.Count == 1 && p.Sections[0].Name == "My Section", "AccessSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-002", "AccessSection", "save-reopen-structure");
    }
}
```

## **Remove a Section**

Delete a previously added section.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var section = presentation.Sections.AddSection("Temporary Section", slide);

        // Remove the first section.
        presentation.Sections.RemoveSection(section);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Sections.Count == 0, "RemoveSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-003", "RemoveSection", "save-reopen-structure");
    }
}
```

## **Rename a Section**

Change the name of an existing section.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        presentation.Sections.AddSection("Old Name", slide);

        var section = presentation.Sections[0];
        section.Name = "New Name";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Sections[0].Name == "New Name", "RenameSection: semantic check 1 failed.");
        });
        Context.Pass("elements/section/block-004", "RenameSection", "save-reopen-structure");
    }
}
```
