---
title: Save presentations as PPTX
description: Save new or edited presentations as editable PPTX files.
type: docs
url: /features/write-pptx/
weight: 50
feature_id: write-pptx
feature_group: formats
translationKey: slides-feature-write-pptx
feature_catalogue_version: 3
feature_guides:
- /slides/net/save-presentation/
---

## **Overview**

Write a presentation to the PowerPoint PPTX format after creating it or changing an existing file. The output keeps a presentation structure with slides and editable content, rather than flattening the deck into page images. Save to a new file when you want to keep the source unchanged.

## **Usage example**

This C# example uses Aspose.Slides for .NET and requires no input files. It adds *Hello* to the initial slide and saves the editable presentation as *hello.pptx*.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
title.Name = "Title";
title.TextFrame.Text = "Hello";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can I save speaker notes with the slides?**

Yes. Speaker notes are part of the saved PPTX presentation and can be read again when the file is reopened.

### **Can I write a PPTX to a memory stream?**

Yes. Save the presentation into a writable memory stream, then use its bytes or rewind it before another reader consumes it. See the [saving guide](/slides/net/save-presentation/).

### **How do I choose the output format independently of the filename?**

Select the output format explicitly when saving. The filename supplies a path; its extension alone does not convert the document.

## **Guides**

- [Save Presentations in .NET](/slides/net/save-presentation/)

Related feature: [Read PPTX presentations](/slides/features/powerpoint-files/).
