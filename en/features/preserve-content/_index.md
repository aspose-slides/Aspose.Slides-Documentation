---
title: Keep existing presentation content
description: Keep existing presentation content while making targeted changes.
type: docs
url: /features/preserve-content/
weight: 180
feature_id: preserve-content
feature_group: operations
translationKey: slides-feature-preserve-content
feature_catalogue_version: 3
feature_guides:
- /slides/net/save-presentation/
---

## **Overview**

Load a presentation, edit the parts you need and save it back to a presentation format. The library carries existing slide structures through the workflow, including content such as notes, transitions and hyperlinks. This helps applications update a deck without recreating every object.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It builds a small reproducible deck with a title, a picture, a chart and notes, then edits only the named title. It saves a separate *edited.pptx* and renders before/after previews so content preservation can be reviewed for this deck.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides.Charts;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var source = new Presentation())
{
    var slide = source.Slides[0];
    var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
    title.Name = "ReportTitle";
    title.TextFrame.Text = "Draft";
    using (var bitmap = new Bitmap(32, 32))
    {
        using var graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.Green);
        bitmap.Save("picture.png", System.Drawing.Imaging.ImageFormat.Png);
    }
    var pictureBytes = File.ReadAllBytes("picture.png");
    var picture = source.Images.AddImage(pictureBytes);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 130, 100, 100, picture);
    slide.Shapes.AddChart(ChartType.ClusteredColumn, 220, 130, 400, 300);
    var notes = slide.NotesSlideManager.AddNotesSlide();
    notes.NotesTextFrame.Text = "Notes";
    source.Save("input.pptx", SaveFormat.Pptx);
}
using var presentation = new Presentation("input.pptx");
using (var before = presentation.Slides[0].GetImage(1f, 1f))
    before.Save("before.png", ImageFormat.Png);
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape.Name == "ReportTitle" && shape is IAutoShape title)
        title.TextFrame.Text = "Final";
}
presentation.Save("edited.pptx", SaveFormat.Pptx);
using var after = presentation.Slides[0].GetImage(1f, 1f);
after.Save("after.png", ImageFormat.Png);
```

## **FAQ**

### **Does saving preserve the file byte for byte?**

No. Saving rewrites the presentation package. Preserving its document content is different from keeping the original bytes or internal part names.

### **What should I compare after loading and saving a deck?**

Check the objects your workflow depends on: slide and shape counts, chart data, embedded media, notes, links and rendered appearance. Saving successfully is not a substitute for checking important content.

### **How can I limit changes to a single shape?**

Find the intended shape by a stable identifier and change only its required properties. Save a copy and compare the untouched objects and representative renders with the source.

## **Guides**

- [Save Presentations in .NET](/slides/net/save-presentation/)

Related feature: [Open and edit presentations](/slides/features/edit-presentations/).
