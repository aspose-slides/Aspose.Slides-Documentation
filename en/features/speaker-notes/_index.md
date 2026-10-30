---
title: Read and edit speaker notes
description: Read, add, edit and remove speaker notes.
type: docs
url: /features/speaker-notes/
weight: 480
feature_id: speaker-notes
feature_group: slides
translationKey: slides-feature-speaker-notes
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-notes/
---

## **Overview**

Work with the notes attached to individual slides. Read existing notes for reuse or indexing, add notes to a slide that has none, or replace the text as part of a generated presentation. Notes remain separate from the content shown on the slide itself.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example creates notes for the first slide and writes a short speaking prompt. The PPTX stores the prompt on the notes slide, separately from the visible slide label.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 300, 80);
label.TextFrame.Text = "Quarterly results";
var notes = slide.NotesSlideManager.AddNotesSlide();
notes.NotesTextFrame.Text = "Discuss revenue before costs.";
presentation.Save("speaker-notes.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I include the notes in an exported document?**

Yes. Use a notes-aware export layout when producing a PDF or another output that should show slides and notes together.

### **How do I access the notes slide for a presentation slide?**

Access the slide’s notes-slide manager. Read its existing notes slide or create one if notes are absent, then work with the notes text frame.

### **How do I distinguish notes text from slide text when extracting content?**

Read normal shapes for visible slide text and the notes text frame for the speaking notes. Keep these sources separate in your extraction result so notes are not mistaken for slide content.

## **Guides**

- [Manage Presentation Notes in .NET](/slides/net/presentation-notes/)

Related feature: [Export slides with speaker notes](/slides/features/export-notes/).

## Runnable .NET examples

- [Prepare a Distribution Copy](/slides/net/examples/complete-workflows/distribution-copy/)
