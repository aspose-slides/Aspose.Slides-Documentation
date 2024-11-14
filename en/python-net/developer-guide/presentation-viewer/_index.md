---
title: Presentation Viewer
type: docs
weight: 50
url: /python-net/presentation-viewer/
keywords: 
- view presentation
- presentation viewer
- view PPT
- view PPTX
- view ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides for Python via .NET
description: "PowerPoint presentation viewer in Python"
---

Aspose.Slides for Python via .NET is used to create presentation files with slides. These slides can be viewed by opening presentations in Microsoft PowerPoint, for example. However, sometimes developers may need to view slides as images in their preferred image viewer or create their own presentation viewer. In such cases, Aspose.Slides allows you to export an individual slide as an image. This article describes how to do it.

## **Live Example**

You can try [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) free app to see what you can implement with Aspose.Slides API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Generate an SVG Image from a Slide**

To generate an SVG image from a presentation slide with Aspose.Slides, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Open a file stream.
1. Save the slide as an SVG image to the file stream.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Create a Slide Thumbnail Image**

Aspose.Slides helps you generate thumbnail images of slides. To generate a thumbnail of a slide using Aspose.Slides, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide at a defined scale.
1. Save the thumbnail image in any desired image format.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Create a Slide Thumbnail with User Defined Dimensions**

To create a slide thumbnail image with user defined dimensions, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide with the defined dimensions.
1. Save the thumbnail image in any desired image format.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Create a Slide Thumbnail with Speaker Notes**

To generate the thumbnail of a slide with speaker notes using Aspose.Slides, please follow the steps below:

1. Create an instance of the [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) class.
1. Use the `RenderingOptions.slides_layout_options` property to set the position of speaker notes.
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get the slide reference by its index.
1. Get the thumbnail image of the referenced slide with the rendering options.
1. Save the thumbnail image in any desired image format.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```
