---
title: Render a Slide as an SVG Image in C#
linktitle: Render a Slide as an SVG Image
type: docs
weight: 50
url: /net/render-a-slide-as-an-svg-image/
description: This article explains how to convert PowerPoint Presentation to SVG format using C#. You can convert PPT, PPTX, ODP formats into SVG images.
keywords: C# Convert PowerPoint to SVG, C# PPT to SVG, C# PPTX to SVG
---

## Overview

This article explains how to **convert PowerPoint Presentation to SVG format using C#**. It covers the following topics.

_Format_: **PowerPoint**
- [C# PowerPoint to SVG](#csharp-powerpoint-to-svg)
- [C# Convert PowerPoint to SVG](#csharp-powerpoint-to-svg)
- [C# How to convert PowerPoint file to SVG](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT to SVG](#csharp-ppt-to-svg)
- [C# Convert PPT to SVG](#csharp-ppt-to-svg)
- [C# How to convert PPT file to SVG](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX to SVG](#csharp-pptx-to-svg)
- [C# Convert PPTX to SVG](#csharp-pptx-to-svg)
- [C# How to convert PPTX file to SVG](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP to SVG](#csharp-odp-to-svg)
- [C# Convert ODP to SVG](#csharp-odp-to-svg)
- [C# How to convert ODP file to SVG](#csharp-odp-to-svg)

_Format_: **Slide**
- [C# Convert PowerPoint Slide to SVG](#render-a-slide-as-an-svg-image)
- [C# Convert PPT Slide to SVG](#render-a-slide-as-an-svg-image)
- [C# Convert PPTX Slide to SVG](#render-a-slide-as-an-svg-image)
- [C# Convert ODP Slide to SVG](#render-a-slide-as-an-svg-image)

Other topics covered by this article.
- [See Also](#see-also)

## SVG Format
SVG—an acronym for Scalable Vector Graphics—is a standard graphics type or format used to render two-dimensional images. SVG stores images as vectors in XML with details that define their behavior or appearance. 

SVG is one of the few formats for images that meets very high standards in these terms: scalability, interactivity, performance, accessibility, programmability, and others. For these reasons, it is commonly used in web development. 

You may want to use SVG files when you need to

- **print your presentation in a *very large format*.** SVG images can scale up to any resolution or level. You get to resize SVG images as many times as necessary without sacrificing quality.
- **use charts and graphs from your slides in *different mediums or platforms**.* Most readers can interpret SVG files. 
- **use the *smallest possible sizes of images***. SVG files are generally smaller than their high-resolution equivalents in other formats, especially those formats based on bitmap (JPEG or PNG).

## Render a Slide as an SVG Image

Aspose.Slides for .NET allows you to export slides in your presentations as SVG images. Go through these steps to generate SVG images:

_Steps: PowerPoint to SVG Conversions in C#_

The following sample code explains these conversions using .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Steps: Convert PowerPoint to SVG in C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Steps: Convert PPT to SVG in C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Steps: Convert PPTX to SVG in C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Steps: Convert ODP to SVG in C#</strong></a>

_Code Steps:_

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
   * _.ppt_ extension to load **PPT** file inside _Presentation_ class.
   * _.pptx_ extension to load **PPTX** file inside _Presentation_ class.
   * _.odp_ extension to load **ODP** file inside _Presentation_ class.
   * _.pps_ extension to load **PPS** file inside _Presentation_ class.
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

_Format_: **PPT**
- [C# PPT to SVG Code](#csharp-ppt-to-svg)
- [C# PPT to SVG API](#csharp-ppt-to-svg)
- [C# PPT to SVG Programmatically](#csharp-ppt-to-svg)
- [C# PPT to SVG Library](#csharp-ppt-to-svg)
- [C# Save PPT as SVG](#csharp-ppt-to-svg)
- [C# Generate SVG from PPT](#csharp-ppt-to-svg)
- [C# Create SVG from PPT](#csharp-ppt-to-svg)
- [C# PPT to SVG Converter](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX to SVG Code](#csharp-pptx-to-svg)
- [C# PPTX to SVG API](#csharp-pptx-to-svg)
- [C# PPTX to SVG Programmatically](#csharp-pptx-to-svg)
- [C# PPTX to SVG Library](#csharp-pptx-to-svg)
- [C# Save PPTX as SVG](#csharp-pptx-to-svg)
- [C# Generate SVG from PPTX](#csharp-pptx-to-svg)
- [C# Create SVG from PPTX](#csharp-pptx-to-svg)
- [C# PPTX to SVG Converter](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP to SVG Code](#csharp-odp-to-svg)
- [C# ODP to SVG API](#csharp-odp-to-svg)
- [C# ODP to SVG Programmatically](#csharp-odp-to-svg)
- [C# ODP to SVG Library](#csharp-odp-to-svg)
- [C# Save ODP as SVG](#csharp-odp-to-svg)
- [C# Generate SVG from ODP](#csharp-odp-to-svg)
- [C# Create SVG from ODP](#csharp-odp-to-svg)
- [C# ODP to SVG Converter](#csharp-odp-to-svg)
