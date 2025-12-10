---
title: Specify Default Presentation Fonts in С++
linktitle: Default Font
type: docs
weight: 30
url: /cpp/default-font/
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
- С++
- Aspose.Slides
description: "Set default fonts in Aspose.Slides for С++ to ensure proper PowerPoint (PPT, PPTX) and OpenDocument (ODP) conversion to PDF, XPS and images."
---

## **Set a Default Font**
Using Aspose.Slides for C++ you can set the default font in PowerPoint presentations. A new method [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) has been added to [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) class. It allows to set the default font used instead of all missing fonts during saving presentations to different formats without reloading the presentations .

The code snippet below demonstrates saving presentation to [HTML](https://docs.fileformat.com/web/html/) and [PDF](https://docs.fileformat.com/pdf/) with different default regular font.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **Use Default Fonts for Rendering a Presentation**
Aspose.Slides lets you set the default font fore rendering the presentation to PDF, XPS or thumbnails. This article shows how to define DefaultRegular
Font and DefaultAsian Font for use as default fonts. Please follow the steps below to loading fonts from external directories by using Aspose.Slides for C++ API:

1. Create an instance of LoadOptions.
1. Set the DefaultRegularFont to your desired font. In the following example, I have used Wingdings.
1. Set the DefaultAsianFont to your desired font. I have used Wingdings in following sample.
1. Load the presentation using Presentation and setting the load options.
1. Now, generate the slide thumbnail, PDF and XPS to verify the results.

The implementation of the above is given below.

```cpp
// Use the load options to specify default regular and Asian fonts
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**What exactly do DefaultRegularFont and DefaultAsianFont affect—only export, or also thumbnails, PDF, XPS, HTML, and SVG?**

They participate in the rendering pipeline for all supported outputs. This includes slide thumbnails, [PDF](/slides/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/cpp/convert-powerpoint-to-xps/), [raster images](/slides/cpp/convert-powerpoint-to-png/), [HTML](/slides/cpp/convert-powerpoint-to-html/), and [SVG](/slides/cpp/render-a-slide-as-an-svg-image/), because Aspose.Slides uses the same layout and glyph resolution logic across these targets.

**Are default fonts applied when simply reading and saving a PPTX without any rendering?**

No. Default fonts matter when text must be measured and drawn. A straight open–save of a presentation does not change stored font runs or the file’s structure. Default fonts come into play during operations that render or reflow text.

**If I add my own font folders or supply fonts from memory, will they be considered when choosing default fonts?**

Yes. [Custom font sources](/slides/cpp/custom-font/) expand the catalog of available families and glyphs that the engine can use. Default fonts and any [fallback rules](/slides/cpp/fallback-font/) will resolve against those sources first, yielding more reliable coverage on servers and in containers.

**Will default fonts affect text metrics (kerning, advances) and therefore line breaks and wrapping?**

Yes. Changing the font changes glyph metrics and can alter line breaks, wrapping, and pagination during rendering. For layout stability, [embed the original fonts](/slides/cpp/embedded-font/) or select metrically compatible default and fallback families.

**Is there any point in setting default fonts if all fonts used in the presentation are embedded?**

Often it’s not necessary, because [embedded fonts](/slides/cpp/embedded-font/) already ensure consistent appearance. Default fonts still help as a safety net for characters not covered by the embedded subset or when a file mixes embedded and non-embedded text.
