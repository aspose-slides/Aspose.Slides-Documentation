---
title: Read legacy PowerPoint presentations
description: Open presentations saved in the older PowerPoint PPT format.
type: docs
url: /features/read-ppt/
weight: 20
feature_id: read-ppt
feature_group: formats
translationKey: slides-feature-read-ppt
feature_catalogue_version: 3
feature_guides:
- /slides/net/open-presentation/
---

## **Overview**

Read binary PowerPoint presentations and access their slides and content. This is useful when an archive or an existing application still uses PPT files. You can edit the loaded presentation, keep it in PPT format, or save a PPTX copy for newer workflows.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a reproducible legacy *input.ppt* containing *Hello* and speaker notes, then loads that binary file directly and prints its text. Creating the fixture is separate from reading it; no PPTX conversion is needed to read the PPT.

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
    source.Save("input.ppt", SaveFormat.Ppt);
}
var fileInfo = PresentationFactory.Instance.GetPresentationInfo("input.ppt");
Console.WriteLine($"Format: {fileInfo.LoadFormat}");
using var presentation = new Presentation("input.ppt");
var firstShape = (IAutoShape)presentation.Slides[0].Shapes[0];
Console.WriteLine(firstShape.TextFrame.Text);
```

## **FAQ**

### **Do I need to convert a PPT file before opening it?**

No. The library can open PPT directly. Conversion is a separate choice when you save the result.

### **How do I detect that a file is a binary PPT?**

Inspect the presentation format rather than trusting its filename extension. The sample reads format information before loading the file; see the [opening guide](/slides/net/open-presentation/).

### **Can I read speaker notes from a legacy PPT?**

Yes. After loading the PPT, check each slide for a notes slide and read its notes text, just as for a loaded PPTX.

## **Guides**

- [Open Presentations in .NET](/slides/net/open-presentation/)

Related feature: [Save presentations as legacy PPT](/slides/features/write-ppt/).

## Runnable .NET examples

- [Convert Presentation Formats](/slides/net/examples/conversion-rendering/presentation-formats/)
