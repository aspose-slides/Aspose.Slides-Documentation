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

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks. The copied code runs in evaluation mode. For licensed output, apply your license before creating a presentation, as described in the [licensing guide](/slides/net/licensing/).

## **Download and run**

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Notes Slide**

Create a notes slide and assign text to it.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var notesSlide = slide.NotesSlideManager.AddNotesSlide();
notesSlide.NotesTextFrame.Text = "Note";

presentation.Save("note-01.pptx", SaveFormat.Pptx);
```

## **Access a Notes Slide**

Create known notes, then retrieve them through the slide’s notes manager.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var notesSlide = slide.NotesSlideManager.AddNotesSlide();

notesSlide.NotesTextFrame.Text = "Note";
// Retrieve the seeded notes through the slide manager.
var existingNotes = slide.NotesSlideManager.NotesSlide;
var notes = existingNotes.NotesTextFrame.Text;
Console.WriteLine(notes);

presentation.Save("note-02.pptx", SaveFormat.Pptx);
```

## **Remove a Notes Slide**

Remove the notes slide associated with a slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

presentation.Save("note-03.pptx", SaveFormat.Pptx);
```

## **Update Notes Text**

Change the text of a notes slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var notesSlide = slide.NotesSlideManager.AddNotesSlide();

notesSlide.NotesTextFrame.Text = "Old";
notesSlide.NotesTextFrame.Text = "New";

presentation.Save("note-04.pptx", SaveFormat.Pptx);
```
