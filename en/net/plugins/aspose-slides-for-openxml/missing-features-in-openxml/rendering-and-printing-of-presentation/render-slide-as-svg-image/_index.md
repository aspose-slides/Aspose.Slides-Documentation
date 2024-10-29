---
title: Render Slide As SVG Image
type: docs
weight: 50
url: /net/render-slide-as-svg-image/
---

SVG—an acronym for Scalable Vector Graphics—is a standard graphics type or format used to render two-dimensional images. SVG stores images as vectors in XML with details that define their behavior or appearance. 

SVG is one of the few formats for images that meets very high standards in these terms: scalability, interactivity, performance, accessibility, programmability, and others. For these reasons, it is commonly used in web development. 

You may want to use SVG files in these scenarios:

- when you plan to print your presentation in a very large format. SVG images can scale up to any resolution or level. You get to resize SVG images as many times as necessary without sacrificing quality.
- when you intend to use charts and graphs from your slides in different mediums or platforms. Most readers can interpret SVG files. 
- when you need to use the smallest possible sizes of images. SVG files are generally smaller than their high-resolution equivalents in other formats, especially those formats based on bitmap (JPEG or PNG).

Aspose.Slides for .NET allows you to export slides in your presentations as **SVG** images. To generate an SVG image from any, do this:

- Create an instance of the Presentation class.
- Iterate through all the slides in the presentation.
- Write every slide to its own SVG file through FileStream.

{{% alert color="primary" %}} 

You may want to try out our [free web application](https://products.aspose.app/slides/conversion/ppt-to-svg) in which we implemented the PPT to SVG conversion function from Aspose.Slides for .NET.

{{% /alert %}} 

This sample code in C# shows you how to convert PPT to SVG using Aspose.Slides:

``` csharp
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

