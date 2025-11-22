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

## **Set Default Font**
Using Aspose.Slides for C++ you can set the default font in PowerPoint presentations. A new method [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) has been added to [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) class. It allows to set the default font used instead of all missing fonts during saving presentations to different formats without reloading the presentations .

The code snippet below demonstrates saving presentation to [HTML](https://docs.fileformat.com/web/html/) and [PDF](https://docs.fileformat.com/pdf/) with different default regular font.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **Use Default Fonts for Rendering Presentation**
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
