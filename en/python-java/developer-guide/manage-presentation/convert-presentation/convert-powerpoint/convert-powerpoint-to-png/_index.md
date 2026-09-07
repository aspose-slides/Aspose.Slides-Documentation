---
title: Convert PowerPoint Slides to PNG in Python
linktitle: PowerPoint to PNG
type: docs
weight: 30
url: /python-java/convert-powerpoint-to-png/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to PNG
- presentation to PNG
- slide to PNG
- PPT to PNG
- PPTX to PNG
- save PPT as PNG
- save PPTX as PNG
- export PPT to PNG
- export PPTX to PNG
- Python
- Java
- Aspose.Slides
description: "Convert PowerPoint slides to PNG images in Python via Java. Export PPT, PPTX, and ODP presentations with custom scales or exact image dimensions."
---

## **Overview**

This article explains how to convert PowerPoint presentations to PNG images using Aspose.Slides for Python via Java. You can load PPT, PPTX, and ODP files, render each slide, and save it as a separate PNG image.

The examples also show how to control the output dimensions with scale factors or an exact width and height. Each example starts the Java virtual machine if needed and releases presentation and image resources after use.

## **Convert PowerPoint to PNG**

1. Load the input file with the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
2. Retrieve the slides using [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides).
3. Render each slide using [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).
4. Save each rendered image with [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png), then release its resources.

The following Python example exports all slides at their default size:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convert PowerPoint to PNG with a Custom Scale**

Pass horizontal and vertical scale factors to [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) to increase or decrease the output dimensions. For example, a 720 × 540-point slide rendered with a scale factor of 2 on both axes produces a 1440 × 1080-pixel image.

Use equal scale factors to preserve the slide's aspect ratio. Different factors stretch the slide horizontally or vertically.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convert PowerPoint to PNG with a Custom Size**

To specify exact pixel dimensions, pass a Java `Dimension` object with the desired width and height to [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage). Choose dimensions with the same aspect ratio as the source slide to avoid distortion.

The following example saves each slide as a 960 × 720-pixel PNG image:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Can I export an individual shape, such as a chart or picture, instead of the whole slide?**

Yes. Aspose.Slides supports [generating thumbnails for individual shapes](/slides/python-java/create-shape-thumbnails/), which you can save as PNG images.

**Can I convert presentations in parallel on a server?**

Use a separate presentation instance for each thread or process, and use unique output paths to prevent files from being overwritten. Do not share a presentation instance between threads. See [Multithreading](/slides/python-java/multithreading/).

**What are the trial-version limitations when exporting to PNG?**

Evaluation mode adds a watermark to output images and applies [other restrictions](/slides/python-java/licensing/). Apply a license to remove these limitations.
