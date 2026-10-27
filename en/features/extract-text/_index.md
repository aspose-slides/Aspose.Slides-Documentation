---
title: Extract text from presentations
description: Read slide and speaker-note text for search, indexing or reuse.
type: docs
url: /features/extract-text/
weight: 130
feature_id: extract-text
feature_group: formats
translationKey: slides-feature-extract-text
feature_catalogue_version: 3
feature_guides:
- /slides/net/extract-text-from-presentation/
---

## **Overview**

Extract text from a presentation by walking its slides, paragraphs and text portions. You can keep slide boundaries and read speaker notes separately, which is useful for search indexes, summaries and document processing that needs the words rather than rendered slide images.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates *input.pptx* with *Slide* on the slide and *Notes* in speaker notes. It reads the slide’s text shapes and its notes text separately, which lets an index retain their different meanings.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var source = new Presentation())
{
    var title = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.TextFrame.Text = "Slide";
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

### **Can I keep list levels in my extracted data?**

Yes. Read paragraph depth and bullet information while collecting the text, then store that structure in your application's chosen output format.

### **How do I distinguish slide text from notes text?**

Keep slide text and notes text in separate fields. Traverse slide shapes and the slide’s notes separately, as the example demonstrates.

### **Can I extract text without rendering slides?**

Yes. Text extraction reads document content without producing slide images. Use arranged extraction when positional reading order matters and review the result for complex layouts.

## **Guides**

- [Advanced Text Extraction from Presentations in .NET](/slides/net/extract-text-from-presentation/)

Related feature: [Export presentations to Markdown](/slides/features/markdown-export/).
