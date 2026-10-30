---
title: Read PPTX presentations
description: Open PPTX files and work with their slides, shapes, text, tables and notes.
type: docs
url: /features/powerpoint-files/
weight: 10
feature_id: powerpoint-files
feature_group: formats
translationKey: slides-feature-powerpoint-files
feature_catalogue_version: 3
feature_guides:
- /slides/net/open-presentation/
---

## **Overview**

Load a PowerPoint presentation to inspect its content or make changes. Slides, text, tables and speaker notes are accessible through the presentation model, so you can work with individual items instead of treating each slide as an image.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It first creates *input.pptx* with a title and speaker notes, then opens that file directly and prints slide and notes text. The source labels are *Hello* and *Notes*; evaluation mode may add a watermark.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var source = new Presentation())
{
    var title = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.TextFrame.Text = "Hello";
    var notes = source.Slides[0].NotesSlideManager.AddNotesSlide();
    notes.NotesTextFrame.Text = "Notes";
    source.Save("input.pptx", SaveFormat.Pptx);
}
using var presentation = new Presentation("input.pptx");
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape textShape)
            Console.WriteLine($"Slide: {textShape.TextFrame.Text}");
    }
    var notes = slide.NotesSlideManager.NotesSlide;
    if (notes != null)
        Console.WriteLine($"Notes: {notes.NotesTextFrame.Text}");
}
```

## **FAQ**

### **Can I save my changes to another file?**

Yes. Save the edited presentation under a new name to keep the original. Use the separate PPTX saving guide for output options.

### **Can I open a PPTX from a stream?**

Yes. Open a readable stream containing the PPTX data. Keep the stream available for as long as the selected loading and BLOB settings require; see the [opening guide](/slides/net/open-presentation/).

### **How do I read speaker notes after loading?**

Read the notes belonging to each loaded slide, check that a notes slide exists, and then read its notes text. The example keeps notes separate from slide text.

## **Guides**

- [Open Presentations in .NET](/slides/net/open-presentation/)

Related feature: [Save presentations as PPTX](/slides/features/write-pptx/).

## Runnable .NET examples

- [Work with Presentation Streams](/slides/net/examples/presentations/streams/)
