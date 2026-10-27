---
title: List embedded fonts
description: List font families embedded in a presentation and access their data.
type: docs
url: /features/list-embedded-fonts/
weight: 1460
feature_id: list-embedded-fonts
feature_group: metadata
translationKey: slides-feature-list-embedded-fonts
feature_catalogue_version: 3
feature_guides:
- /slides/net/embedded-font/
---

## **Overview**

Inspect the fonts stored inside a presentation to understand what the file carries. You can obtain embedded font data and read embedding-permission information. This is useful when managing presentation assets or deciding which embedded fonts to retain.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Use the installed Arial font, whose embedding permissions must allow this operation. Embed it in a generated deck, reopen that file, then list its embedded family and write the regular font data to a local file. Respect font licensing when redistributing extracted data.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;
using System.Drawing;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var font = new FontData("Arial");
shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = font;
presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
presentation.Save("source.pptx", SaveFormat.Pptx);
using var opened = new Presentation("source.pptx");
foreach (var embedded in opened.FontsManager.GetEmbeddedFonts())
{
    var bytes = opened.FontsManager.GetFontBytes(embedded, FontStyleType.Regular);
    var permission = opened.FontsManager.GetFontEmbeddingLevel(bytes, embedded.FontName);
    Console.WriteLine(embedded.FontName + ": " + permission + ", bytes=" + bytes.Length);
    File.WriteAllBytes("embedded-regular.font", bytes);
}
```

## **FAQ**

### **Can I read a flag saying whether a font is fully embedded or subsetted?**

The read-side font listing does not provide that flag. Choosing full or used-character embedding is part of the font-writing workflow.

### **Can I inspect font embedding permissions?**

Yes. Inspect the font data's embedding-permission information and respect its license before writing or redistributing it.

### **How can I obtain the embedded font bytes?**

Obtain the regular or other available style data through the font manager using the embedded font identity. The returned data does not expose a full-versus-subset listing flag.

## **Guides**

- [Embed Fonts in Presentations in .NET](/slides/net/embedded-font/)

Related feature: [Embed fonts in presentations](/slides/features/embed-fonts/).
