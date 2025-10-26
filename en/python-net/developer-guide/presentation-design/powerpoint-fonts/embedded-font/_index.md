---
title: Embed Fonts in Presentations with Python
linktitle: Embedding Font
type: docs
weight: 40
url: /python-net/embedded-font/
keywords:
- add font
- embed font
- font embedding
- get embedded font
- add embedded font
- remove embedded font
- compress embedded font
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Embed TrueType fonts in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET, ensuring accurate rendering across all platforms."
---

## **Overview**

**Embedding fonts in PowerPoint** ensures your presentation maintains its intended appearance across different systems. Whether using unique fonts for creativity or standard ones, embedding fonts prevents text and layout disruption.

If you used a third-party or non-standard font because you got creative with your work, then you have even more reasons to embed your font. Otherwise (without embedded fonts), the texts or numbers on your slides, the layout, styling, etc. may change or turn into confusing rectangles. 

Utilize the [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), and [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) classes to manage embedded fonts.

## **Get and Remove Embedded Fonts**

Retrieve or remove embedded fonts from a presentation effortlessly with the [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) and [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/) methods.

This Python code shows you how to get and remove embedded fonts from a presentation:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Render the slide containing a text frame that uses the embedded 'FunSized' font.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Get all embedded fonts.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Find the 'Calibri' font.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Remove the 'Calibri' font.
    fonts_manager.remove_embedded_font(font_data)

    # Render the slide; the 'Calibri' font will be replaced with an existing one.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Save the presentation without the embedded 'Calibri' font to disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Add Embedded Fonts**

Using the [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) enum and two overloads of the [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/) method, you can select your preferred (embedding) rule to embed the fonts in a presentation. This Python code shows you how to embed and add fonts to a presentation:

```python
import aspose.slides as slides

# Load a presentation.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Save the presentation to disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Compress Embedded Fonts**

Optimize file size by compressing embedded fonts using [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Example code for compression:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**How can I tell that a specific font in the presentation will still be substituted during rendering despite embedding?**

Check the [substitution information](/slides/python-net/font-substitution/) in the font manager and the [fallback/substitution rules](/slides/python-net/fallback-font/): if the font is unavailable or restricted, a fallback will be used.

**Is it worth embedding "system" fonts like Arial/Calibri?**

Usually no—they are almost always available. But for full portability in "thin" environments (Docker, a Linux server without preinstalled fonts), embedding system fonts can eliminate the risk of unexpected substitutions.
