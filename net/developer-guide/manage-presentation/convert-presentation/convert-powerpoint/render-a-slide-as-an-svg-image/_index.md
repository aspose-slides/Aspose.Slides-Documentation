---
title: Render a Slide as an SVG Image in C#
linktitle: Render a Slide as an SVG Image
type: docs
weight: 50
url: /net/render-a-slide-as-an-svg-image/
description: This article explains how to convert PowerPoint Presentation to SVG format using C#.
keywords: C# Convert PowerPoint to SVG, C# PPT to SVG, C# PPTX to SVG
---

## **Overview**

This article explains how to convert PowerPoint Presentation to SVG format using C#. It covers the following topics.

- [C# Convert PowerPoint to SVG](#csharp-powerpoint-to-svg)
- [C# Convert PPT to SVG](#csharp-ppt-to-svg)
- [C# Convert PPTX to SVG](#csharp-pptx-to-svg)
- [C# Convert ODP to SVG](#csharp-odp-to-svg)
- [C# Convert PowerPoint Slide to SVG](#render-a-slide-as-an-svg-image)


## **SVG Format**
SVG—an acronym for Scalable Vector Graphics—is a standard graphics type or format used to render two-dimensional images. SVG stores images as vectors in XML with details that define their behavior or appearance. 

SVG is one of the few formats for images that meets very high standards in these terms: scalability, interactivity, performance, accessibility, programmability, and others. For these reasons, it is commonly used in web development. 

You may want to use SVG files when you need to

- **print your presentation in a *very large format*.** SVG images can scale up to any resolution or level. You get to resize SVG images as many times as necessary without sacrificing quality.
- **use charts and graphs from your slides in *different mediums or platforms**.* Most readers can interpret SVG files. 
- **use the *smallest possible sizes of images***. SVG files are generally smaller than their high-resolution equivalents in other formats, especially those formats based on bitmap (JPEG or PNG).

## **Render a Slide as an SVG Image**

Aspose.Slides for .NET allows you to export slides in your presentations as SVG images. Go through these steps to generate SVG images:

<a name="csharp-powerpoint-to-svg"><strong>Steps: Convert PowerPoint to SVG in C#</strong></a> | <a name="csharp-ppt-to-svg"><strong>Steps: Convert PPT to SVG in C#</strong></a> | <a name="csharp-pptx-to-svg"><strong>Steps: Convert PPTX to SVG in C#</strong></a> | <a name="csharp-odp-to-svg"><strong>Steps: Convert ODP to SVG in C#</strong></a>


1. Create an instance of the Presentation class.
2. Iterate through all the slides in the presentation.
3. Write every slide to its own SVG file through FileStream.

{{% alert color="primary" %}} 

You may want to try out our [free web application](https://products.aspose.app/slides/conversion/ppt-to-svg) in which we implemented the PPT to SVG conversion function from Aspose.Slides for .NET.

{{% /alert %}} 

This sample code in C# shows you how to convert PowerPoint to SVG using Aspose.Slides: 

``` csharp
// Presentation object can load PowerPoint formats like PPT, PPTX, ODP etc.
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

## See Also 

This article also covers these topics. The codes are same as above.

_Format_: **PowerPoint**
- [C# PowerPoint to SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Library](#csharp-powerpoint-to-svg)
- [C# Save PowerPoint as SVG](#csharp-powerpoint-to-svg)
- [C# Generate SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# Create SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Converter](#csharp-powerpoint-to-svg)

