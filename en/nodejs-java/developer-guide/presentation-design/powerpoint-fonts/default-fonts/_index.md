---
title: Specify Default Presentation Fonts in JavaScript
linktitle: Default Font
type: docs
weight: 30
url: /nodejs-java/default-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Set default fonts in Aspose.Slides for Node.js via Java to ensure proper PowerPoint (PPT, PPTX) and OpenDocument (ODP) conversion to PDF, XPS and images."
---


## **Using Default Fonts for Rendering Presentation**
Aspose.Slides lets you set the default font fore rendering the presentation to PDF, XPS or thumbnails. This article shows how to define DefaultRegular
Font and DefaultAsian Font for use as default fonts. Please follow the steps below to loading fonts from external directories by using Aspose.Slides for Node.js via Java API:

1. Create an instance of [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) to your desired font. In the following example, I have used Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) to your desired font. I have used Wingdings in following sample.
1. Load the presentation using Presentation and setting the load options.
1. Now, generate the slide thumbnail, PDF and XPS to verify the results.

The implementation of the above is given below.

```javascript
// Use load options to define the default regualr and asian fonts
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Load the presentation
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generate slide thumbnail
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // save the image on the disk.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Generate PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Generate XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**What exactly do DefaultRegularFont and DefaultAsianFont affect—only export, or also thumbnails, PDF, XPS, HTML, and SVG?**

They participate in the rendering pipeline for all supported outputs. This includes slide thumbnails, [PDF](/slides/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/nodejs-java/convert-powerpoint-to-xps/), [raster images](/slides/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/nodejs-java/convert-powerpoint-to-html/), and [SVG](/slides/nodejs-java/render-a-slide-as-an-svg-image/), because Aspose.Slides uses the same layout and glyph resolution logic across these targets.

**Are default fonts applied when simply reading and saving a PPTX without any rendering?**

No. Default fonts matter when text must be measured and drawn. A straight open–save of a presentation does not change stored font runs or the file’s structure. Default fonts come into play during operations that render or reflow text.

**If I add my own font folders or supply fonts from memory, will they be considered when choosing default fonts?**

Yes. [Custom font sources](/slides/nodejs-java/custom-font/) expand the catalog of available families and glyphs that the engine can use. Default fonts and any [fallback rules](/slides/nodejs-java/fallback-font/) will resolve against those sources first, yielding more reliable coverage on servers and in containers.

**Will default fonts affect text metrics (kerning, advances) and therefore line breaks and wrapping?**

Yes. Changing the font changes glyph metrics and can alter line breaks, wrapping, and pagination during rendering. For layout stability, [embed the original fonts](/slides/nodejs-java/embedded-font/) or select metrically compatible default and fallback families.

**Is there any point in setting default fonts if all fonts used in the presentation are embedded?**

Often it’s not necessary, because [embedded fonts](/slides/nodejs-java/embedded-font/) already ensure consistent appearance. Default fonts still help as a safety net for characters not covered by the embedded subset or when a file mixes embedded and non-embedded text.
