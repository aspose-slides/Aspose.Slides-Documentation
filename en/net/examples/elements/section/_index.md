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

Each printed `CaseNN.cs` file is compiled verbatim. The download checks each case in `CaseVerification.cs` before saving and after reopening the result.

## **Add a Section**

Create a section that starts at a specific slide.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Specify the slide that marks the beginning of the section.
        presentation.Sections.AddSection("New Section", slide);

        VerifyCase01(presentation);
    }
}
```

## **Access a Section**

Read section information from a presentation.

```csharp
using Aspose.Slides;

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

        VerifyCase02(presentation);
    }
}
```

## **Remove a Section**

Delete a previously added section.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var section = presentation.Sections.AddSection("Temporary Section", slide);

        // Remove the first section.
        presentation.Sections.RemoveSection(section);

        VerifyCase03(presentation);
    }
}
```

## **Rename a Section**

Change the name of an existing section.

```csharp
using Aspose.Slides;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        presentation.Sections.AddSection("Old Name", slide);

        var section = presentation.Sections[0];
        section.Name = "New Name";

        VerifyCase04(presentation);
    }
}
```
