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

This article explains how to convert presentation slides to PNG images using Aspose.Slides for Python via Java. You can load presentations in formats such as PPT, PPTX, and ODP, render each slide, and save it as a separate PNG image.

The examples below demonstrate rendering at the default scale, increasing the scale, specifying the output dimensions in pixels, and choosing a gradient rendering style.

## **Convert PowerPoint to PNG**

Load a presentation with the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class and access its slides through the [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) collection. The example renders every slide with [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) without parameters to create a thumbnail. It then calls [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) with [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) to save each rendered slide as a PNG image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

The parameterless [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) overload renders at a scale of 0.2. For example, a slide measuring 720 × 540 points produces a 144 × 108 pixel thumbnail. To control the output dimensions, use the overloads with scale factors or an explicit image size shown below.

{{% /alert %}}

## **Convert PowerPoint to PNG With Custom Dimensions**

Pass horizontal and vertical scale factors to [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) to control the rendered dimensions. In this example, both factors are 2, so a slide measuring 720 × 540 points produces a 1440 × 1080 pixel image. Equal scale factors preserve the slide's aspect ratio. Each rendered image is saved in PNG format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Convert PowerPoint to PNG With Custom Size**

To specify output dimensions in pixels, pass a size to [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) instead of scale factors. This example renders every slide at 960 × 720 pixels and saves the result in PNG format. Choose dimensions that match the slide's aspect ratio to avoid stretching the image.

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

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Choose a Gradient Rendering Style**

Suppose a slide contains gradient fills, but the transitions in the exported PNG look lighter or otherwise different from what you see in PowerPoint. You can use the [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) method inherited by [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) to choose how the gradients are rendered.

Download [gradient-styles.pptx](gradient-styles.pptx) and place it in the application's working directory. Its first slide contains two linear gradients: cyan to orange at the top and blue to yellow at the bottom. Each gradient has two stops, at 0% and 100%.

The following example loads this presentation and renders the same first slide in both modes with [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

The images below show the output from the same slide, with both gradients in each image:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

In this example, `Default` produces lighter intermediate colors, while `PowerPointUI` produces darker intermediate colors. The difference depends on the colors and stops in the gradient.

Choose `Default` when the standard Aspose.Slides output suits your needs. Try `PowerPointUI` when your priority is matching the appearance in PowerPoint. Compare both outputs with your intended result; neither mode is universally preferable.

## **FAQ**

**How can I export a specific shape, such as a chart or picture, instead of the entire slide?**

Aspose.Slides supports [generating thumbnails for individual shapes](/slides/python-java/create-shape-thumbnails/), allowing you to render a shape as a PNG image.

**Is parallel conversion supported on a server?**

Yes. Use a separate presentation instance for each thread or process; [do not share a single instance across threads](/slides/python-java/multithreading/).

**What are the evaluation limitations when exporting to PNG?**

Evaluation mode adds a watermark to output images and applies [other restrictions](/slides/python-java/licensing/) until a license is applied.
