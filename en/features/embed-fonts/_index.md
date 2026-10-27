---
title: Embed fonts in presentations
description: Store font data in a presentation for use with its text.
type: docs
url: /features/embed-fonts/
weight: 760
feature_id: embed-fonts
feature_group: text
translationKey: slides-feature-embed-fonts
feature_catalogue_version: 3
feature_guides:
- /slides/net/embedded-font/
---

## **Overview**

Embed font data in a presentation so the file can carry the fonts its text uses. Choose whether to embed the full character set or only the characters needed by the document. You can list embedded fonts later and remove them when appropriate.

## **Usage example**

This C# example uses the regular Arial font already installed on the host. It checks the font’s embedding flags, then embeds the full font only when outline embedding and editing are permitted. A successful run creates `embed-fonts.pptx`; the diagnostic branch creates no output. Review the font’s license as well as its technical flags before distributing a presentation.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 100);
shape.AddTextFrame("Embedded Arial text");
var font = new FontData("Arial");
shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = font;
var fontBytes = presentation.FontsManager.GetFontBytes(font, FontStyleType.Regular);
if (fontBytes == null)
{
    Console.WriteLine("Install Arial or select an available font before running this example.");
}
else
{
    var level = presentation.FontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
    var restricted = (level & EmbeddingLevel.Restricted) != 0;
    var previewOnly = (level & EmbeddingLevel.PreviewPrint) != 0 && (level & EmbeddingLevel.Editable) == 0;
    var bitmapOnly = (level & EmbeddingLevel.BitmapOnly) != 0;
    if (restricted || previewOnly || bitmapOnly)
    {
        Console.WriteLine("This font does not permit the editable outline embedding used here.");
    }
    else
    {
        presentation.FontsManager.AddEmbeddedFont(fontBytes, EmbedFontCharacters.All);
        presentation.Save("embed-fonts.pptx", SaveFormat.Pptx);
        Console.WriteLine("Saved embed-fonts.pptx with Arial embedded.");
    }
}
```

## **FAQ**

### **Should I consider the font's embedding permissions?**

Yes. Font files carry embedding permissions. Use those permissions when deciding which fonts your application may include in a presentation.

### **How do full-font and used-character embedding differ?**

Full-font embedding includes the font’s complete character set and supports later text edits. Used-character embedding includes the glyphs needed by current content and can reduce size. A no-subsetting flag requires full-font embedding.

### **How can I remove an embedded font that is no longer needed?**

Enumerate the presentation’s embedded fonts, select the family to remove and remove its embedded entry. Check the resulting presentation on a host without that font before distributing it.

## **Guides**

- [Embed Fonts in Presentations in .NET](/slides/net/embedded-font/)

Related feature: [List embedded fonts](/slides/features/list-embedded-fonts/).
