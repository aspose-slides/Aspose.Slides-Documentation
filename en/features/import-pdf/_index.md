---
title: Import PDF pages into a presentation
description: Bring PDF pages into a presentation as slide content.
type: docs
url: /features/import-pdf/
weight: 40
feature_id: import-pdf
feature_group: formats
translationKey: slides-feature-import-pdf
feature_catalogue_version: 3
feature_guides:
- /slides/net/import-presentation/
---

## **Overview**

Import PDF pages into a presentation and save the result as a PowerPoint file. Imported text can become editable slide objects, which helps when you need to reuse content from a PDF rather than insert a picture of each page.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates a two-page *input.pdf*, removes the destination presentation’s initial blank slide, and imports the PDF pages. The result is *imported.pptx* with two slides labeled *Alpha* and *Bravo*; PDF import does not reconstruct every original document structure.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (var source = new Presentation())
{
    for (var i = 0; i < 2; i++)
    {
        var slide = i == 0 ? source.Slides[0] : source.Slides.AddEmptySlide(source.Slides[0].LayoutSlide);
        var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
        title.TextFrame.Text = i == 0 ? "Alpha" : "Bravo";
    }
    source.Save("input.pdf", SaveFormat.Pdf);
}
using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);
presentation.Slides.AddFromPdf("input.pdf");
presentation.Save("imported.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Will a PDF table become a PowerPoint table?**

Table text may arrive as separate text boxes. Do not rely on the import to reconstruct an editable table; create a table separately when that structure matters.

### **Does each PDF page become a separate slide?**

Yes. Each imported PDF page is added as a slide. Remove the destination’s initial blank slide first if you want only the imported pages.

### **How can I add imported pages to an existing deck?**

Load the destination presentation and import the PDF into its slide collection. Keep its existing slides and review the imported pages alongside the destination design.

## **Guides**

- [Import Presentations from PDF or HTML in .NET](/slides/net/import-presentation/)

Related feature: [Create tables on slides](/slides/features/create-tables/).
