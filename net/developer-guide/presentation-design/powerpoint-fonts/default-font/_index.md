---
title: Default Font - PowerPoint C# API
linktitle: Default Font
type: docs
weight: 30
url: /net/default-font/
keywords: "Fonts, default fonts, render presentation PowerPoint presentation C#, Csharp, Aspose.Slides for .NET"
description: PowerPoint C# API lets you set the default font for rendering the presentation to PDF, XPS or thumbnails
---

## **Using Default Fonts for Rendering Presentation**
Aspose.Slides lets you set the default font for rendering the presentation to PDF, XPS or thumbnails. This article shows how to define DefaultRegular
Font and DefaultAsian Font for use as default fonts. Please follow the steps below to loading fonts from external directories by using Aspose.Slides for .NET API:

1. Create an instance of LoadOptions.
1. Set the DefaultRegularFont to your desired font. In the following example, I have used Wingdings.
1. Set the DefaultAsianFont to your desired font. I have used Wingdings in following sample.
1. Load the presentation using Presentation and setting the load options.
1. Now, generate the slide thumbnail, PDF and XPS to verify the results.

The implementation of the above is given below.

```c#
// Use load options to define the default regualr and asian fonts// Use load options to define the default regualr and asian fonts
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

// Load the presentation
using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    // Generate slide thumbnail
    pptx.Slides[0].GetThumbnail(1, 1).Save("output_out.png", ImageFormat.Png);

    // Generate PDF
    pptx.Save("output_out.pdf", SaveFormat.Pdf);

    // Generate XPS
    pptx.Save("output_out.xps", SaveFormat.Xps);
}
```

