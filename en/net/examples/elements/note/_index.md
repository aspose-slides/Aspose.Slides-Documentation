---
title: Note
type: docs
weight: 240
url: /net/examples/elements/note/
aliases:
  - /net/examples/elements/elements/note/
keywords:
- note
- add notes slide
- access notes slide
- remove notes slide
- update notes text
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with slide notes in Aspose.Slides for .NET: add, read, edit, and export speaker notes in PPT, PPTX, and ODP using clear C# examples."
---

This article demonstrates how to add, read, remove, and update notes slides using **Aspose.Slides for .NET**.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Notes Slide**

Create a notes slide and assign text to it.

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

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();
        slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Note";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "Note", "AddNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-001", "AddNote", "save-reopen-structure");
    }
}
```

## **Access a Notes Slide**

Read text from an existing notes slide.

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

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();

        notesSlide.NotesTextFrame.Text = "Note";
        var notes = notesSlide.NotesTextFrame.Text;
        Context.Require(notes == "Note", "Accessed expected notes text.");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "Note", "AccessNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-002", "AccessNote", "save-reopen-structure");
    }
}
```

## **Remove a Notes Slide**

Remove the notes slide associated with a slide.

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

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();

        slide.NotesSlideManager.RemoveNotesSlide();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide == null, "RemoveNote: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-003", "RemoveNote", "save-reopen-structure");
    }
}
```

## **Update Notes Text**

Change the text of a notes slide.

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

        var notesSlide = slide.NotesSlideManager.AddNotesSlide();

        slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
        slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "New";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].NotesSlideManager.NotesSlide.NotesTextFrame.Text.Trim() == "New", "UpdateNoteText: semantic check 1 failed.");
        });
        Context.Pass("elements/note/block-004", "UpdateNoteText", "save-reopen-structure");
    }
}
```
