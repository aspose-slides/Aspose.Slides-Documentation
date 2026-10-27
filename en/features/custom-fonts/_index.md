---
title: Load fonts from a folder
description: Use font files from application-managed folders.
type: docs
url: /features/custom-fonts/
weight: 780
feature_id: custom-fonts
feature_group: text
translationKey: slides-feature-custom-fonts
feature_catalogue_version: 3
feature_guides:
- /slides/net/custom-font/
---

## **Overview**

Load fonts from a custom directory instead of relying only on fonts installed on the host. This is useful for containers, servers and applications that ship their own font set. Font data can also be supplied directly for workflows that already hold it in memory.

## **Usage example**

Place [CustomFonts.ttf](https://github.com/aspose-slides/Aspose.Slides-for-.NET/raw/master/Examples/Data/Text/CustomFonts.ttf) in a `fonts` subfolder of the working directory. This existing example font contains Open Sans Semibold Italic. The C# example loads that folder before creating the presentation, renders `custom-fonts.png` and saves `custom-fonts.pptx`. It does not embed or redistribute the font in the presentation.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

FontsLoader.LoadExternalFonts(new[] { "fonts" });
using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 540, 120);
shape.AddTextFrame("Text from an application font folder");
var format = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
format.LatinFont = new FontData("Open Sans Semibold");
format.FontItalic = NullableBool.True;
format.FontHeight = 28;
presentation.Save("custom-fonts.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("custom-fonts.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Must I install these fonts system-wide?**

No. Custom font loading lets the library use application-provided fonts for presentation processing.

### **How can I load a font from bytes instead of a folder?**

Load the font file into a byte array and pass it to the external-font byte-loading operation before processing the presentation.

### **When should I load custom fonts in a server process?**

Load the required fonts before opening or creating presentations that use them. Coordinate font-cache changes at application level; avoid clearing a shared font cache while other work is using it.

## **Guides**

- [Customize PowerPoint Fonts in .NET](/slides/net/custom-font/)

Related feature: [Configure font fallback](/slides/features/font-fallback/).
