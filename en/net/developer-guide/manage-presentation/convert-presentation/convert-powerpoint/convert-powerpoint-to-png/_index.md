---
title: Convert PowerPoint Slides to PNG in .NET
linktitle: PowerPoint to PNG
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
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
- .NET
- C#
- Aspose.Slides
description: "Convert PowerPoint presentations to high-quality PNG images quickly with Aspose.Slides for .NET, ensuring precise, automated results."
---

## **Overview**

This article explains how to convert presentation slides to PNG images using Aspose.Slides for .NET. You can load presentations in formats such as PPT, PPTX, and ODP, render each slide, and save it as a separate PNG image.

The examples below demonstrate rendering thumbnails, setting scale factors, specifying the output dimensions in pixels, and choosing a gradient rendering style.

## **Convert PowerPoint to PNG**

Load a presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class and access its slides through the [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection. The example renders every slide with [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) without parameters to create a thumbnail. It then calls [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) with [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) to save each rendered slide as a PNG image.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}

The parameterless [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) overload renders at a scale of 0.2. For example, a slide measuring 720 × 540 points produces a 144 × 108 pixel thumbnail. To control the output dimensions, use the overloads with scale factors or an explicit image size shown below.

{{% /alert %}}

## **Convert PowerPoint to PNG With Custom Dimensions**

Pass horizontal and vertical scale factors to [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) to control the rendered dimensions. In this example, both factors are 2, so a slide measuring 720 × 540 points produces a 1440 × 1080 pixel image. Equal scale factors preserve the slide's aspect ratio. Each image is saved in PNG format with [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Convert PowerPoint to PNG With Custom Size**

To specify output dimensions in pixels, pass a size to [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) instead of scale factors. This example renders every slide at 960 × 720 pixels and saves the result with [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Choose dimensions that match the slide's aspect ratio to avoid stretching the image.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Choose a Gradient Rendering Style**

Suppose a slide contains gradient fills, but the transitions in the exported PNG look lighter or otherwise different from what you see in PowerPoint. You can use the [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) property of [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) to choose how the gradients are rendered.

Download [gradient-styles.pptx](gradient-styles.pptx) and place it in the application's working directory. Its first slide contains two linear gradients: cyan to orange at the top and blue to yellow at the bottom. Each gradient has two stops, at 0% and 100%.

The following example loads this presentation and renders the same first slide in both modes with [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

The images below show the output from the same slide, with both gradients in each image:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

In this example, `Default` produces lighter intermediate colors, while `PowerPointUI` produces darker intermediate colors. The difference depends on the colors and stops in the gradient.

Choose `Default` when the standard Aspose.Slides output suits your needs. Try `PowerPointUI` when your priority is matching the appearance in PowerPoint. Compare both outputs with your intended result; neither mode is universally preferable.

## **FAQ**

**How can I export a specific shape, such as a chart or picture, instead of the entire slide?**

Aspose.Slides supports [generating thumbnails for individual shapes](/slides/net/create-shape-thumbnails/), allowing you to render a shape as a PNG image.

**Is parallel conversion supported on a server?**

Yes. Use a separate presentation instance for each thread or process; [do not share a single instance across threads](/slides/net/multithreading/).

**What are the evaluation limitations when exporting to PNG?**

Evaluation mode adds a watermark to output images and applies [other restrictions](/slides/net/licensing/) until a license is applied.
