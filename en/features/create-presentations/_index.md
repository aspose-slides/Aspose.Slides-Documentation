---
title: Create presentations
description: Build presentations from slides, shapes, text, images, charts and tables.
type: docs
url: /features/create-presentations/
weight: 160
feature_id: create-presentations
feature_group: operations
translationKey: slides-feature-create-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/create-presentation/
---

## **Overview**

Start with a new presentation and add the content your application needs. You can create slides, fill them with text and graphics, and add editable charts or tables. Save the result as a presentation or export it to a viewing format.

## **Usage example**

This C# example uses Aspose.Slides for .NET and needs no template. A new presentation already has one slide; the example adds *Hello* to that slide and saves *created.pptx*.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
title.Name = "Title";
title.TextFrame.Text = "Hello";
presentation.Save("created.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Do I need an existing template to begin?**

No. You can build a presentation from scratch. Use a template when you want to reuse a particular layout or design.

### **Does a new presentation already contain a slide?**

Yes. A new presentation has an initial slide. Reuse it, as above, or remove it when constructing a different slide sequence.

### **How can I create a slide using a particular layout?**

Choose a layout from the presentation’s masters or layouts and add an empty slide based on it. Fill its placeholders or add shapes as described in the [creation guide](/slides/net/create-presentation/).

## **Guides**

- [Create Presentations in .NET](/slides/net/create-presentation/)

Related feature: [Work with slide layouts](/slides/features/slide-layouts/).

## Runnable .NET examples

- [Create, Open, and Save Presentations](/slides/net/examples/presentations/create-open-save/)
