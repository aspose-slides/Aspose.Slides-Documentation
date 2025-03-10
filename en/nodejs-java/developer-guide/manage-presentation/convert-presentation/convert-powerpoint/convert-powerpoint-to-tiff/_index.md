---
title: Convert PowerPoint to TIFF
type: docs
weight: 90
url: /nodejs-java/convert-powerpoint-to-tiff/
keywords: "Convert PowerPoint Presentation, PowerPoint to TIFF, PPT to TIFF, PPTX to TIFF, Java, Aspose.Slides"
description: "Convert PowerPoint presentation to TIFF in JavaScript"

---

**TIFF** (Tagged Image File Format) is a lossless raster and high-quality image format. Professionals use TIFF for their design, photography, and desktop publishing purposes. For example, if you want to preserve layers and settings in your design or image, you may want to save your work as a TIFF image file. 

Aspose.Slides allows you to convert the slides in PowerPoint directly to TIFF. 

{{% alert title="Tip" color="primary" %}}

You may want to check out Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convert PowerPoint to TIFF**

Using the [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) method exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the slides' default size.

This JavaScript code shows you how to convert PowerPoint to TIFF:

```javascript
// Instantiates a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Saves the presentation as TIFF
    pres.save("tiff-image.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Convert PowerPoint to Black-and-White TIFF**

In Aspose.Slides 23.10, Aspose.Slides added a new method ([setBwConversionMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-)) to the [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) class to allow you to specify the algorithm that is followed when a colored slide or image is converted to a black-and-white TIFF. Note that this setting is applied only when the [setCompressionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) method is called with `CCITT4` or `CCITT3` values.

This JavaScript code shows you how to convert a colored slide or image to black-and-white TIFF:

```javascript
var tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Convert PowerPoint to TIFF with Custom Size**

If you require a TIFF image with defined dimensions, you can define your preferred figures through the properties provided under [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/). Using the [setImagesSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) method, for example, you can set a size for the resulting image.

This JavaScript code shows you how to convert PowerPoint to TIFF images with custom size:

```javascript
// Instantiates a Presentation object that represents a Presentation file
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Instantiates the TiffOptions class
    var opts = new aspose.slides.TiffOptions();
    // Sets the compression type
    // Possible values are:
    // Default - Specifies the default compression scheme (LZW).
    // None - Specifies no compression.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    // Depth – depends on the compression type and cannot be set manually.
    // Sets the image DPI
    opts.setDpiX(200);
    opts.setDpiY(100);
    // Sets the Image Size
    opts.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));
    var options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Saves the presentation to TIFF with specified size
    pres.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, opts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Convert PowerPoint to TIFF with Custom Image Pixel Format**

Using the [setPixelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat-int-) method under the [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image.

This JavaScript code shows you how to convert PowerPoint to TIFF image with custom pixel format:

```javascript
// Instantiates a Presentation object that represents a Presentation file
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.TiffOptions();
    options.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /* ImagePixelFormat contains the following values (as stated in the documentation):
    Format1bppIndexed; // 1 bits per pixel, indexed.
    Format4bppIndexed; // 4 bits per pixel, indexed.
    Format8bppIndexed; // 8 bits per pixel, indexed.
    Format24bppRgb;    // 24 bits per pixel, RGB.
    Format32bppArgb;   // 32 bits per pixel, ARGB.
     */
    // Saves the presentation to TIFF with specified image size
    pres.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

