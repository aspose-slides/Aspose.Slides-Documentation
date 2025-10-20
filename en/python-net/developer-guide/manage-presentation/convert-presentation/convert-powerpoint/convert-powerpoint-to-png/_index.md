---
title: Convert PowerPoint Slides to PNG in Python
linktitle: Slide to PNG
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-png/
keywords:
- convert PowerPoint to PNG
- convert presentation to PNG
- convert slide to PNG
- convert PPT to PNG
- convert PPTX to PNG
- convert ODP to PNG
- PowerPoint to PNG
- presentation to PNG
- slide to PNG
- PPT to PNG
- PPTX to PNG
- ODP to PNG
- Python
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument presentations to high-quality PNG images quickly with Aspose.Slides for Python via .NET, ensuring precise, automated results."
---

## **Overview**

Aspose.Slides for Python via .NET makes it straightforward to convert PowerPoint presentations to PNG. You load a presentation, iterate through its slides, render each one to a raster image, and save the result as PNG files. This is ideal for generating slide previews, embedding slides in web pages, or producing static assets for downstream processing.

## **Convert Slides to PNG**

This section shows the simplest possible example of converting a PowerPoint presentation to PNG images using Aspose.Slides for Python via .NET.

Go through these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide from the `Presentation.slides` collection (see the [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) class).
1. Use the `Slide.get_image` method to generate a thumbnail of the slide.
1. Use the `Presentation.save` method to save the slide thumbnail in PNG format.

This Python code shows how to convert a PowerPoint presentation to PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Convert Slides to PNG with Custom Dimensions**

To export slides to PNG at a custom scale, call `Slide.get_image` with horizontal and vertical scale factors. These multipliers resize the output relative to the slide’s original dimensions—for example, `2.0` doubles both width and height. Use equal values for `scale_x` and `scale_y` to preserve the aspect ratio.

This Python code demonstrates the described operation:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Convert Slides to PNG with Custom Size**

If you want to generate PNG files at a specific size, pass your desired `width` and `height` values. The code below shows how to convert a PowerPoint to PNG while specifying the image size: 

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}

You may want to try Aspose’s free **PowerPoint-to-PNG converters**—[PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). They provide a live implementation of the process described on this page.

{{% /alert %}}

## **FAQ**

**How can I export only a specific shape (e.g., chart or picture) rather than the whole slide?**

Aspose.Slides supports [generating thumbnails for individual shapes](/slides/python-net/create-shape-thumbnails/); you can render a shape to a PNG image.

**Is parallel conversion supported on a server?**

Yes, but [don’t share](/slides/python-net/multithreading/) a single presentation instance across threads. Use a separate instance per thread or process.

**What are the trial-version limitations when exporting to PNG?**

The evaluation mode adds a watermark to output images and enforces [other restrictions](/slides/python-net/licensing/) until a license is applied.
