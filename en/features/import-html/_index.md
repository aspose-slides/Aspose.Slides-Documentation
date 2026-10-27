---
title: Add HTML content to slides
description: Import HTML content into presentation slides or text.
type: docs
url: /features/import-html/
weight: 1500
feature_id: import-html
feature_group: generation
translationKey: slides-feature-import-html
feature_catalogue_version: 3
feature_guides:
- /slides/net/import-presentation/
---

## **Overview**

Bring HTML content into a presentation when your application already has formatted text or a fragment to reuse. The slide-level import can create slide objects for content such as text, lists, links, tables and pictures. Choose the import level that matches the fragment.

## **Usage example**

This C# example imports a self-contained HTML fragment containing a heading and bold text through slide-level HTML import. It removes the initial blank slide, then saves `import-html.pptx` and a PNG preview of the imported slide. No website or external resource is fetched.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var html = "<html><body><h1>Quarterly report</h1><p>Revenue is <b>growing</b>.</p></body></html>";
presentation.Slides.RemoveAt(0);
presentation.Slides.AddFromHtml(html);
presentation.Save("import-html.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("import-html.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Which import path should I use for an HTML table?**

Use slide-level HTML import when you need a table object. Paragraph-level import handles text and can flatten table cells into paragraphs.

### **Can I import an HTML fragment rather than a whole website?**

Yes. Supply a self-contained HTML string or stream. Pick slide-level import when the fragment should become slide objects; text-frame import is useful for formatted text inside an existing shape.

### **What should I do with linked images or stylesheets?**

Make resource locations resolvable through the import’s base URI and resource resolver, or supply self-contained content. Check the imported output rather than assuming browser layout or every web feature is preserved.

## **Guides**

- [Import Presentations from PDF or HTML in .NET](/slides/net/import-presentation/)

Related feature: [Create tables on slides](/slides/features/create-tables/).
