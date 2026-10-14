---
title: Convert PowerPoint Slides to PNG in Python
linktitle: PowerPoint to PNG
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

This article explains how to convert presentation slides to PNG images using Aspose.Slides for Python via .NET. You can load presentations in formats such as PPT, PPTX, and ODP, render each slide, and save it as a separate PNG image.

The examples below demonstrate rendering at the default scale, increasing the scale, specifying the output dimensions in pixels, and choosing a gradient rendering style.

## **Convert PowerPoint to PNG**

Load a presentation with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and access its slides through the [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collection. The example renders every slide with [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) without parameters to create a thumbnail. It then calls [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) with [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) to save each rendered slide as a PNG image.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}

The parameterless [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) overload renders at a scale of 0.2. For example, a slide measuring 720 × 540 points produces a 144 × 108 pixel thumbnail. To control the output dimensions, use the overloads with scale factors or an explicit image size shown below.

{{% /alert %}}

## **Convert PowerPoint to PNG With Custom Dimensions**

Pass horizontal and vertical scale factors to [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) to control the rendered dimensions. In this example, both factors are 2, so a slide measuring 720 × 540 points produces a 1440 × 1080 pixel image. Equal scale factors preserve the slide's aspect ratio. Each image is saved in PNG format with [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Convert PowerPoint to PNG With Custom Size**

To specify output dimensions in pixels, pass a size to [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) instead of scale factors. This example renders every slide at 960 × 720 pixels and saves the result with [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Choose dimensions that match the slide's aspect ratio to avoid stretching the image.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Choose a Gradient Rendering Style**

Suppose a slide contains gradient fills, but the transitions in the exported PNG look lighter or otherwise different from what you see in PowerPoint. You can use the [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) property of [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) to choose how the gradients are rendered.

Download [gradient-styles.pptx](gradient-styles.pptx) and place it in the application's working directory. Its first slide contains two linear gradients: cyan to orange at the top and blue to yellow at the bottom. Each gradient has two stops, at 0% and 100%.

The following example loads this presentation and renders the same first slide in both modes with [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

The images below show the output from the same slide, with both gradients in each image:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

In this example, `DEFAULT` produces lighter intermediate colors, while `POWER_POINT_UI` produces darker intermediate colors. The difference depends on the colors and stops in the gradient.

Choose `DEFAULT` when the standard Aspose.Slides output suits your needs. Try `POWER_POINT_UI` when your priority is matching the appearance in PowerPoint. Compare both outputs with your intended result; neither mode is universally preferable.

## **FAQ**

**How can I export a specific shape, such as a chart or picture, instead of the entire slide?**

Aspose.Slides supports [generating thumbnails for individual shapes](/slides/python-net/create-shape-thumbnails/), allowing you to render a shape as a PNG image.

**Is parallel conversion supported on a server?**

Yes. Use a separate presentation instance for each thread or process; [do not share a single instance across threads](/slides/python-net/multithreading/).

**What are the evaluation limitations when exporting to PNG?**

Evaluation mode adds a watermark to output images and applies [other restrictions](/slides/python-net/licensing/) until a license is applied.
