---
title: Default Fonts
type: docs
weight: 30
url: /java/default-font/
---


## **Using Default Fonts for Rendering Presentation**
Aspose.Slides lets you set the default font fore rendering the presentation to PDF, XPS or thumbnails. This article shows how to define DefaultRegular
Font and DefaultAsian Font for use as default fonts. Please follow the steps below to loading fonts from external directories by using Aspose.Slides for Java API:

1. Create an instance of [LoadOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://apireference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) to your desired font. In the following example, I have used Wingdings.
1. [Set the DefaultAsianFont](https://apireference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) to your desired font. I have used Wingdings in following sample.
1. Load the presentation using Presentation and setting the load options.
1. Now, generate the slide thumbnail, PDF and XPS to verify the results.

The implementation of the above is given below.

```java
// Use load options to define the default regualr and asian fonts
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Load the presentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Generate slide thumbnail
    BufferedImage image = pres.getSlides().get_Item(0).getThumbnail(1, 1);
    ImageIO.write(image, "png", new File("output.png"));

    // Generate PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Generate XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

