---
title: Embedded Font
type: docs
weight: 40
url: /python-net/embedded-font/
keywords: "Fonts, embedded fonts, add fonts, PowerPoint presentation Python, Aspose.Slides for Python via .NET"
description: "PowerPoint embedded fonts in Python"
---

## **Get or Remove Embedded Fonts from Presentation**
Now, you can also work with embedded fonts. FontsManger class now offer, GetEmbeddedFonts() method that returns a list of embedded fonts inside the presentation. You can also remove any embedded font inside presentation if that is required by using RemoveEmbeddedFont() method exposed by FontsManager class. The implementation of the above steps is given below.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # render a slide that contains a text frame that uses embedded "FunSized"
    presentation.slides[0].get_thumbnail(draw.Size(960, 720)).save("picture1_out.png", draw.imaging.ImageFormat.png)

    fontsManager = presentation.fonts_manager

    # get all embedded fonts
    embeddedFonts = fontsManager.get_embedded_fonts()

    # find "Calibri" font
    
    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # remove "Calibri" font
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # render the presentation removed "Calibri" font is replaced to an existing one
    presentation.slides[0].get_thumbnail(draw.Size(960, 720)).save("picture2_out.png", draw.imaging.ImageFormat.png)

    # save the presentation without embedded "Calibri" font
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **Add Embedded Fonts to Presentation**
A new property of embedding fonts has been added. To allow embedding fonts into Presentation the new EmbedFontCharacters enum and two overloads of AddEmbeddedFont method have been added. Using these methods and choosing the desired embedding rule (represented by EmbedFontCharacters enum), all fonts used in the Presentation can be embedded. The implementation of the above steps is given below.

```py
import aspose.slides as slides

# Load presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Load source font to be replaced
    sourceFont = slides.FontData("Arial")


    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Save the presentation
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Compress Embedded Fonts**

To allow you to compress the fonts embedded in a presentation and reduce its file size, Aspose.Slides provides the `compress_embedded_fonts` method exposed by the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class.

This Python code shows you how to compress embedded PowerPoint fonts:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

