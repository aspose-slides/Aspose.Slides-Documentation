---
title: Convert Presentation Slides to Images in Node.js via .NET
linktitle: Slide to Image
type: docs
weight: 40
url: /nodejs-net/convert-slide/
keywords:
- convert slide
- slide to image
- slide to PNG
- save slide as image
- render slide
- slide thumbnail
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Render slides from PPTX, PPT, and ODP presentations as PNG images in JavaScript with Aspose.Slides for Node.js via .NET, at a scale factor or at an exact size in pixels."
---

## **Overview**

Aspose.Slides for Node.js via .NET renders slides from PowerPoint and OpenDocument presentations as images, for example to show slide previews on a web page. This article shows two ways to choose the image size: a scale factor relative to the slide size, and an exact size in pixels. Both examples save PNG files.

The examples expect a presentation named `sample.pptx` in the project folder that you set up in [Installation](/slides/nodejs-net/installation/). Any PowerPoint presentation will do. Save each example as a `.js` file in the project folder and run it from that folder with `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET has no API reference of its own. It mirrors the Aspose.Slides for .NET API with camelCase names, so the API links in this article lead to the matching classes and members in the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

To convert a slide to an image, follow these steps:

1. Open the presentation with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor.
1. Get a slide from the [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection with `get(index)`. Indexes start at 0.
1. Render the slide with `getImageWithScale` or `getImageWithImageSize`. In the .NET API reference, both are overloads of [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). They return an image object that corresponds to [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).
1. Save the image with its [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) method and an [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) value, and then call its `dispose` method.

## **Convert Every Slide to a PNG Image**

`getImageWithScale` takes a horizontal and a vertical scale factor. At a scale of 1, one point of the slide becomes one pixel of the image. The following example renders every slide at a scale of 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// A scale of 1 renders one pixel per point; 2 doubles the width and the height.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

The script writes one file per slide, `slide_1.png`, `slide_2.png`, and so on, numbered from 1. For a 16:9 presentation with slides of 960 × 540 points, each image is 1920 × 1080 pixels. Hidden slides are rendered too; to skip them, check the slide's [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) property. Each image is disposed in its own `finally` block, which releases it before the next slide is rendered. Without a license, the images also show an evaluation watermark; see [Licensing](/slides/nodejs-net/licensing/).

## **Convert a Slide to an Image of a Given Size**

`getImageWithImageSize` takes an object with `width` and `height` in pixels. The following example renders the first slide 1280 pixels wide and calculates the height from the slide size, so that the image keeps the slide's aspect ratio:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

The [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) property returns the slide width and height in points. For a 16:9 presentation, the script prints `Saved a 1280 x 720 image` and writes `slide_1_1280px.png`; for a 4:3 presentation, the image is 1280 × 960 pixels.

## **FAQ**

**Why is the image from `getImage` without arguments so small?**

Without arguments, `getImage` renders the slide at 20% of its size in points, so a 960 × 540 point slide becomes a 192 × 108 pixel image. Use `getImageWithScale` or `getImageWithImageSize` to choose the size.

**How do I save JPEG or other image formats?**

Pass another `ImageFormat` value to the image's `save` method, for example `image.save("slide_1.jpg", ImageFormat.Jpeg)`. The format comes from the `ImageFormat` value, not from the file extension, so keep the two consistent.

**Why does the text in the images look different on Linux?**

Aspose.Slides can only use fonts that are installed on the machine that renders the slides. When a presentation uses a font that is missing, such as Calibri on a typical Linux server, Aspose.Slides uses an installed font in its place, which can change the look of the text and where lines break. Install the fonts that your presentations use to get the same images as on Windows.

**Why does `getThumbnailWithImageSize` fail with a TypeError?**

The package README uses `getThumbnailWithImageSize`, but the package has no `getThumbnail` methods. Use `getImageWithImageSize` instead; it takes the same `{ width, height }` argument.
