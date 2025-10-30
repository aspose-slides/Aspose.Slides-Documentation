---
title: Customize Default Fonts in Presentations with Python
linktitle: Default Font
type: docs
weight: 30
url: /python-net/default-font/
keywords:
- default font
- regular font
- normal font
- asian font
- PDF export
- XPS export
- image export
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Set default fonts in Aspose.Slides for Python to ensure proper PowerPoint (PPT, PPTX) and OpenDocument (ODP) conversion to PDF, XPS and images."
---

## **Using Default Fonts for Rendering Presentation**
Aspose.Slides lets you set the default font fore rendering the presentation to PDF, XPS or thumbnails. This article shows how to define DefaultRegular
Font and DefaultAsian Font for use as default fonts. Please follow the steps below to loading fonts from external directories by using Aspose.Slides for Python via .NET API:

1. Create an instance of LoadOptions.
1. Set the DefaultRegularFont to your desired font. In the following example, I have used Wingdings.
1. Set the DefaultAsianFont to your desired font. I have used Wingdings in following sample.
1. Load the presentation using Presentation and setting the load options.
1. Now, generate the slide thumbnail, PDF and XPS to verify the results.

The implementation of the above is given below.

```py
import aspose.slides as slides

# Use load options to define the default regualr and asian fonts# Use load options to define the default regualr and asian fonts
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Load the presentation
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Generate slide thumbnail
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Generate PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Generate XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**What exactly do default_regular_font and default_asian_font affect—only export, or also thumbnails, PDF, XPS, HTML, and SVG?**

They participate in the rendering pipeline for all supported outputs. This includes slide thumbnails, [PDF](/slides/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/python-net/convert-powerpoint-to-xps/), [raster images](/slides/python-net/convert-powerpoint-to-png/), [HTML](/slides/python-net/convert-powerpoint-to-html/), and [SVG](/slides/python-net/render-a-slide-as-an-svg-image/), because Aspose.Slides uses the same layout and glyph resolution logic across these targets.

**Are default fonts applied when simply reading and saving a PPTX without any rendering?**

No. Default fonts matter when text must be measured and drawn. A straight open–save of a presentation does not change stored font runs or the file’s structure. Default fonts come into play during operations that render or reflow text.

**If I add my own font folders or supply fonts from memory, will they be considered when choosing default fonts?**

Yes. [Custom font sources](/slides/python-net/custom-font/) expand the catalog of available families and glyphs that the engine can use. Default fonts and any [fallback rules](/slides/python-net/fallback-font/) will resolve against those sources first, yielding more reliable coverage on servers and in containers.

**Will default fonts affect text metrics (kerning, advances) and therefore line breaks and wrapping?**

Yes. Changing the font changes glyph metrics and can alter line breaks, wrapping, and pagination during rendering. For layout stability, [embed the original fonts](/slides/python-net/embedded-font/) or select metrically compatible default and fallback families.

**Is there any point in setting default fonts if all fonts used in the presentation are embedded?**

Often it’s not necessary, because [embedded fonts](/slides/python-net/embedded-font/) already ensure consistent appearance. Default fonts still help as a safety net for characters not covered by the embedded subset or when a file mixes embedded and non-embedded text.
