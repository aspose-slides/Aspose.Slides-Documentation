---
title: Render a Slide as an SVG Image
type: docs
weight: 50
url: /pythonnet/render-a-slide-as-an-svg-image/
---

SVG—an acronym for Scalable Vector Graphics—is a standard graphics type or format used to render two-dimensional images. SVG stores images as vectors in XML with details that define their behavior or appearance. 

SVG is one of the few formats for images that meets very high standards in these terms: scalability, interactivity, performance, accessibility, programmability, and others. For these reasons, it is commonly used in web development. 

You may want to use SVG files when you need to

- **print your presentation in a *very large format*.** SVG images can scale up to any resolution or level. You get to resize SVG images as many times as necessary without sacrificing quality.
- **use charts and graphs from your slides in *different mediums or platforms**.* Most readers can interpret SVG files. 
- **use the *smallest possible sizes of images***. SVG files are generally smaller than their high-resolution equivalents in other formats, especially those formats based on bitmap (JPEG or PNG).

Aspose.Slides for Python via .NET allows you to export slides in your presentations as SVG images. Go through these steps to generate SVG images:

1. Create an instance of the Presentation class.
2. Iterate through all the slides in the presentation.
3. Write every slide to its own SVG file through FileStream.

{{% alert color="primary" %}} 

You may want to try out our [free web application](https://products.aspose.app/slides/conversion/ppt-to-svg) in which we implemented the PPT to SVG conversion function from Aspose.Slides for Python via .NET.

{{% /alert %}} 

This sample code in Python shows you how to convert PPT to SVG using Aspose.Slides:

```py
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

