---
title: Refresh the presentation's preview image
description: Refresh or preserve the preview image stored in a PPTX file.
type: docs
url: /features/refresh-preview/
weight: 1470
feature_id: refresh-preview
feature_group: metadata
translationKey: slides-feature-refresh-preview
feature_catalogue_version: 3
feature_guides:
- /slides/net/save-presentation/
---

## **Overview**

Choose whether saving a presentation should regenerate its stored preview image. Refresh it after visible slide edits when the file preview should reflect the changed presentation, or preserve the existing preview when that is the desired behavior.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Save an initial deck, change its visible text, then save a new copy with preview regeneration enabled. This controls the stored presentation preview, rather than supplying a custom image.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
presentation.Save("before.pptx", SaveFormat.Pptx);
shape.TextFrame.Text = "Updated preview";
var options = new PptxOptions { RefreshThumbnail = true };
presentation.Save("source.pptx", SaveFormat.Pptx, options);
```

## **FAQ**

### **Can I supply an arbitrary replacement preview through this setting?**

No. This setting controls regeneration or preservation. Use slide rendering separately when your application needs an image preview of its own.

### **When should I regenerate the stored preview?**

Regenerate it after visible edits when file-browser previews should reflect the current slide. Preserve it when the existing preview is intentional.

### **How does a stored preview differ from a separately rendered slide thumbnail?**

The stored preview travels inside the presentation package. A slide thumbnail is a separately rendered image your application can size and store independently.

## **Guides**

- [Save Presentations in .NET](/slides/net/save-presentation/)

Related feature: [Create slide thumbnails](/slides/features/slide-thumbnails/).
