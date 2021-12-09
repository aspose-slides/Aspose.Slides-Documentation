---
title: Default Font
type: docs
weight: 30
url: /pythonnet/default-font/
keywords: "Fonts, default fonts, render presentation PowerPoint presentation Python, Aspose.Slides for Python via .NET"
description: "PowerPoint default fonts in Python"
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
import aspose.pydrawing as draw
import aspose.slides as slides

# Use load options to define the default regualr and asian fonts# Use load options to define the default regualr and asian fonts
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Load the presentation
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Generate slide thumbnail
    pptx.slides[0].get_thumbnail(1, 1).save("output_out.png", draw.imaging.ImageFormat.png)

    # Generate PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Generate XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

