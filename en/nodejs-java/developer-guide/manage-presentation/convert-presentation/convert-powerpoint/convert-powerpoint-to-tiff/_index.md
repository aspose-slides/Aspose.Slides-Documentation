---
title: Convert PowerPoint to TIFF in JavaScript
titlelink: PowerPoint to TIFF
type: docs
weight: 90
url: /nodejs-java/convert-powerpoint-to-tiff/
keywords:
- convert PowerPoint
- convert OpenDocument
- convert presentation
- convert slide
- PowerPoint to TIFF
- OpenDocument to TIFF
- presentation to TIFF
- slide to TIFF
- PPT to TIFF
- PPTX to TIFF
- ODP to TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to easily convert PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations to high-quality TIFF images using Aspose.Slides for Node.js via Java. Step-by-step guide with code examples included."
---

## **Overview**

TIFF (**Tagged Image File Format**) is a widely-used, lossless raster image format known for its exceptional quality and detailed preservation of graphics. Designers, photographers, and desktop publishers often choose TIFF to maintain layers, color accuracy, and original settings in their images.

Using Aspose.Slides, you can effortlessly convert your PowerPoint slides (PPT, PPTX) and OpenDocument slides (ODP) directly into high-quality TIFF images, ensuring your presentations retain maximum visual fidelity.

## **Convert a Presentation to TIFF**

Using the [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) method provided by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

This JavaScript code demonstrates how to convert a PowerPoint presentation to TIFF:

```js
// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Save the presentation as TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Convert a Presentation to Black-and-White TIFF**

The method [setBwConversionMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in the [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) class allows you to specify the algorithm used when converting a colored slide or image to a black-and-white TIFF. Note that this setting applies only when the [setCompressionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) method is set to `CCITT4` or `CCITT3`.

Let's say we have a "sample.pptx" file with the following slide:

![A presentation slide](slide_black_and_white.png)

This JavaScript code demonstrates how to convert the colored slide to a black-and-white TIFF:

```js
var tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

The result:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Convert a Presentation to TIFF with Custom Size**

If you require a TIFF image with specific dimensions, you can set your desired values using methods available in [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/). For instance, the [setImageSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setImageSize) method allows you to define the size of the resulting image.

This JavaScript code demonstrates how to convert a PowerPoint presentation to TIFF images with a custom size:

```js
// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var tiffOptions = new aspose.slides.TiffOptions();

    // Set the compression type.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // The depth depends on the compression type and cannot be set manually.

    // Set the image DPI.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Set the image size.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    var notesOptions = new asposeaspose.slidesSlides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Save the presentation as TIFF with the specified size.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Convert a Presentation to TIFF with Custom Image Pixel Format**

Using the [setPixelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) method from the [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image.

This JavaScript code demonstrates how to convert a PowerPoint presentation to a TIFF image with a custom pixel format:

```js
// Instantiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat contains the following values (as stated in the documentation):
        Format1bppIndexed - 1 bit per pixel, indexed.
        Format4bppIndexed - 4 bits per pixel, indexed.
        Format8bppIndexed - 8 bits per pixel, indexed.
        Format24bppRgb    - 24 bits per pixel, RGB.
        Format32bppArgb   - 32 bits per pixel, ARGB.
    */

    /// Save the presentation as TIFF with the specified image size.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Check out Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQs**

**1. Can I convert an individual slide instead of entire PowerPoint presentation to TIFF?**

Yes. Aspose.Slides allows you to convert individual slides from PowerPoint and OpenDocument presentations into TIFF images separately.

**2. Is there any limit to the number of slides when converting a presentation to TIFF?**

No, Aspose.Slides does not impose any restrictions on the number of slides. You can convert presentations of any size into TIFF format.

**3. Are PowerPoint animations and transition effects preserved when converting slides to TIFF?**

No, TIFF is a static image format. Therefore, animations and transition effects are not preserved; only static snapshots of slides are exported.
