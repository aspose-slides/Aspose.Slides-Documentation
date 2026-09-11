---
title: Specify Default Presentation Fonts in Python via Java
linktitle: Default Font
type: docs
weight: 30
url: /python-java/default-font/
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
- Java
- Aspose.Slides
description: "Set default fonts in Aspose.Slides for Python via Java to ensure proper PowerPoint (PPT, PPTX) and OpenDocument (ODP) conversion to PDF, XPS and images."
---

## **Overview**

Aspose.Slides allows you to specify default fonts that are used when a presentation is rendered. This is useful when generating slide thumbnails or exporting a presentation to formats such as PDF and XPS. Default fonts are configured through [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) before the presentation is loaded.

The [setDefaultRegularFont](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) method defines the default font for regular text, while [setDefaultAsianFont](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) defines the default font for Asian text. After these options are set, the presentation can be loaded and rendered using the specified fonts.

## **Use Default Fonts for Rendering a Presentation**

Aspose.Slides lets you set default fonts for rendering a presentation to PDF, XPS, or thumbnails. This section shows how to define default fonts for regular and Asian text using Aspose.Slides for Python via Java:

1. Create an instance of [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/).
1. Use [setDefaultRegularFont](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) to specify your desired font. The following example uses Wingdings.
1. Use [setDefaultAsianFont](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) to specify your desired font. The following example also uses Wingdings.
1. Load the presentation using [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) with the load options.
1. Generate the slide thumbnail, PDF, and XPS to verify the results.

The following example implements these steps:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Use load options to define the default regular and Asian fonts.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Load the presentation.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Generate a slide thumbnail.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Save the image to disk.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Generate a PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Generate an XPS document.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**What exactly do the default regular and Asian fonts affect—only export, or also thumbnails, PDF, XPS, HTML, and SVG?**

They participate in the rendering pipeline for all supported outputs. This includes slide thumbnails, [PDF](/slides/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/python-java/convert-powerpoint-to-xps/), [raster images](/slides/python-java/convert-powerpoint-to-png/), [HTML](/slides/python-java/convert-powerpoint-to-html/), and [SVG](/slides/python-java/render-a-slide-as-an-svg-image/), because Aspose.Slides uses the same layout and glyph resolution logic across these targets.

**Are default fonts applied when simply reading and saving a PPTX without any rendering?**

No. Default fonts matter when text must be measured and drawn. A straight open–save of a presentation does not change stored font runs or the file’s structure. Default fonts come into play during operations that render or reflow text.

**If I add my own font folders or supply fonts from memory, will they be considered when choosing default fonts?**

Yes. [Custom font sources](/slides/python-java/custom-font/) expand the catalog of available families and glyphs that the engine can use. Default fonts and any [fallback rules](/slides/python-java/fallback-font/) will resolve against those sources first, yielding more reliable coverage on servers and in containers.

**Will default fonts affect text metrics (kerning, advances) and therefore line breaks and wrapping?**

Yes. Changing the font changes glyph metrics and can alter line breaks, wrapping, and pagination during rendering. For layout stability, [embed the original fonts](/slides/python-java/embedded-font/) or select metrically compatible default and fallback families.

**Is there any point in setting default fonts if all fonts used in the presentation are embedded?**

Often it’s not necessary, because [embedded fonts](/slides/python-java/embedded-font/) already ensure consistent appearance. Default fonts still help as a safety net for characters not covered by the embedded subset or when a file mixes embedded and non-embedded text.
