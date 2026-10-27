---
title: Add hyperlinks
description: Add web, email and internal-slide links to text and shapes.
type: docs
url: /features/hyperlinks/
weight: 830
feature_id: hyperlinks
feature_group: text
translationKey: slides-feature-hyperlinks
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-hyperlinks/
---

## **Overview**

Attach hyperlinks to text portions or shapes so readers can open a website, start an email or jump to another slide. You can inspect existing links, update their targets or remove them. Use internal links to build navigation within a larger presentation.

## **Usage example**

This C# example attaches a click link to a text portion and writes `hyperlinks.pptx` plus `hyperlinks.pdf`. The destination is the public example.org domain; no network request is required to generate either file. Open the output in a viewer that supports clickable links.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 100);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.AddTextFrame("Open the example website");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.HyperlinkClick = new Hyperlink("https://example.org/");
presentation.Save("hyperlinks.pdf", SaveFormat.Pdf);
presentation.Save("hyperlinks.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("hyperlinks.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can hyperlinks survive PDF export?**

Web, email and internal links can be written into the PDF. Hover actions are a separate presentation behavior and do not become PDF hover actions.

### **Can I link to another slide instead of a website?**

Yes. Create an internal-slide hyperlink using the destination slide object. Keep that destination in the saved presentation.

### **How can I remove a hyperlink without changing the text?**

Clear the portion’s or shape’s click hyperlink. Its text stays unchanged; hover hyperlinks, if present, are separate settings.

## **Guides**

- [Manage Presentation Hyperlinks in .NET](/slides/net/manage-hyperlinks/)

Related feature: [Export presentations to PDF](/slides/features/pdf-export/).
