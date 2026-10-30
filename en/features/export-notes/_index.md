---
title: Export slides with speaker notes
description: Include speaker notes alongside slides in exported documents.
type: docs
url: /features/export-notes/
weight: 1190
feature_id: export-notes
feature_group: rendering
translationKey: slides-feature-export-notes
feature_catalogue_version: 3
feature_guides:
- /slides/net/convert-powerpoint-to-pdf-with-notes/
---

## **Overview**

Export a presentation using a notes layout so readers can see each slide with its speaker notes. Choose the notes position and layout options appropriate to the output. This is useful for review copies or handouts that need more context than the slide alone provides.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Add a distinct speaker-note marker and export it below the slide. The resulting PDF includes the slide and its note on one page.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var notes = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
notes.NotesTextFrame.Text = "Speaker note marker";
var layout = new NotesCommentsLayoutingOptions { NotesPosition = NotesPositions.BottomFull };
var options = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("output.pdf", SaveFormat.Pdf, options);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I control how much space notes occupy?**

Yes. The notes-layout options provide different arrangements, including full or truncated notes below the slide.

### **Can I export notes for a selected range of slides?**

Yes. Use a save overload that accepts slide positions together with the notes-layout options. Slide positions for that overload start at 1.

### **What happens when a slide has no speaker notes?**

The slide still exports; it has no speaker-note text to display. The chosen layout controls the page arrangement.

## **Guides**

- [Convert PowerPoint Presentations to PDF with Notes in .NET](/slides/net/convert-powerpoint-to-pdf-with-notes/)

Related feature: [Read and edit speaker notes](/slides/features/speaker-notes/).

## Runnable .NET examples

- [Export Notes and Handouts](/slides/net/examples/conversion-rendering/notes-handouts/)
