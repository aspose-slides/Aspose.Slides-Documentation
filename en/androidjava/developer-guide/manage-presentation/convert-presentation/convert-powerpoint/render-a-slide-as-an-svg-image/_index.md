---
title: Render Presentation Slides as SVG Images on Android
linktitle: Slide to SVG
type: docs
weight: 50
url: /androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint to SVG
- presentation to SVG
- slide to SVG
- PPT to SVG
- PPTX to SVG
- save PPT as SVG
- save PPTX as SVG
- export PPT to SVG
- export PPTX to SVG
- render slide
- convert slide
- export slide
- vector image
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn how to render PowerPoint slides as SVG images using Aspose.Slides for Android. High-quality visuals with simple Java code examples."
---

## **SVG Format**

SVG—an acronym for Scalable Vector Graphics—is a standard graphics type or format used to render two-dimensional images. SVG stores images as vectors in XML with details that define their behavior or appearance. 

SVG is one of the few formats for images that meets very high standards in these terms: scalability, interactivity, performance, accessibility, programmability, and others. For these reasons, it is commonly used in web development. 

You may want to use SVG files when you need to

- **print your presentation in a *very large format*.** SVG images can scale up to any resolution or level. You get to resize SVG images as many times as necessary without sacrificing quality.
- **use charts and graphs from your slides in *different mediums or platforms**.* Most readers can interpret SVG files. 
- **use the *smallest possible sizes of images***. SVG files are generally smaller than their high-resolution equivalents in other formats, especially those formats based on bitmap (JPEG or PNG).

## **Render a Slide as an SVG Image**

Aspose.Slides for Android via Java allows you to export slides in your presentations as SVG images. Go through these steps to generate SVG images:

1. Create an instance of the Presentation class.
2. Iterate through all the slides in the presentation.
3. Write every slide to its own SVG file through FileOutputStream.

{{% alert color="primary" %}} 

You may want to try out our [free web application](https://products.aspose.app/slides/conversion/ppt-to-svg) in which we implemented the PPT to SVG conversion function from Aspose.Slides for Android via Java.

{{% /alert %}} 

This sample code in Java shows you how to convert PPT to SVG using Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Why might the resulting SVG look different across browsers?**

Support for specific SVG features is implemented differently by browser engines. [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) parameters help smooth out incompatibilities.

**Is it possible to export not only slides but also individual shapes to SVG?**

Yes. Any [shape can be saved as a separate SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), which is convenient for icons, pictograms, and reusing graphics.

**Can multiple slides be combined into a single SVG (strip/document)?**

The standard scenario is one slide → one SVG. Combining several slides into a single SVG canvas is a post-processing step performed at the application level.
