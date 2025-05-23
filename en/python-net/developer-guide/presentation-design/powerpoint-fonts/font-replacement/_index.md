---
title: Streamline Font Replacement in Presentations Using Python
linktitle: Font Replacement
type: docs
weight: 60
url: /python-net/font-replacement/
keywords:
- font
- replace font
- font replacement
- change font
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Seamlessly replace fonts in Aspose.Slides Python via .NET to ensure consistent typography in PowerPoint and OpenDocument presentations."
---

If you change your mind about using a font, you can replace that font with another font. All instances of the old font will be replaced by the new font. 

Aspose.Slides allows you to replace a font this way:

1. Load the relevant presentation. 
2. Load the font that will be replaced.
3. Load the new font. 
4. Replace the font. 
5. Write the modified presentation as a PPTX file.

This Python code demonstrates font replacement:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("Arial")

    # Loads the new font
    destFont = slides.FontData("Times New Roman")

    # Replaces the fonts
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Saves the presentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

To set rules that determine what happens in certain conditions (if a font cannot be accessed, for example), see [**Font Substitution**](/slides/python-net/font-substitution/). 

{{% /alert %}}
