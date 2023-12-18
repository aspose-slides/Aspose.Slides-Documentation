---
title: Embedded Font
type: docs
weight: 40
url: /python-net/embedded-font/
keywords: "Fonts, embedded fonts, add fonts, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Use embedded fonts in PowerPoint presentation in Python"
---

**Embedded fonts in PowerPoint** are useful when you want your presentation to appear correctly when opened on any system or device. If you used a third-party or non-standard font because you got creative with your work, then you have even more reasons to embed your font. Otherwise (without embedded fonts), the texts or numbers on your slides, the layout, styling, etc. may change or turn into confusing rectangles. 

The [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) class, [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class, and their interfaces contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations. 

## **Get or Remove Embedded Fonts from Presentation**

Aspose.Slides provides the `get_embedded_fonts()` method (exposed by the [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) class) to allow you to get (or find out) the fonts embedded in a presentation. To remove fonts, the `remove_embedded_font(font_data)` method (exposed by the same class) is used.

This Python code shows you how to get and remove embedded fonts from a presentation:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # Renders a slide containing a text frame that uses embedded "FunSized"
    presentation.slides[0].get_thumbnail(draw.Size(960, 720)).save("picture1_out.png", draw.imaging.ImageFormat.png)

    fontsManager = presentation.fonts_manager

    # Gets all embedded fonts
    embeddedFonts = fontsManager.get_embedded_fonts()

    # Finds the "Calibri" font
    
    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # Removes "Calibri" font
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # Renders the presentation; "Calibri" font is replaced with an existing one
    presentation.slides[0].get_thumbnail(draw.Size(960, 720)).save("picture2_out.png", draw.imaging.ImageFormat.png)

    # Saves the presentation without embedded "Calibri" font to disk
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **Add Embedded Fonts to Presentation**

Using the [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) enum and two overloads of the `add_embedded_font(font_data, embed_font_rule)` method, you can select your preferred (embedding) rule to embed the fonts in a presentation. This Python code shows you how to embed and add fonts to a presentation:

```python
import aspose.slides as slides

# Loads the presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font to be replaced
    sourceFont = slides.FontData("Arial")


    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Saves the presentation to disk
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Compress Embedded Fonts**

To allow you to compress the fonts embedded in a presentation and reduce its file size, Aspose.Slides provides the  `compress_embedded_fonts`  method (exposed by the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class).

This Python code shows you how to compress embedded PowerPoint fonts:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

