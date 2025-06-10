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

