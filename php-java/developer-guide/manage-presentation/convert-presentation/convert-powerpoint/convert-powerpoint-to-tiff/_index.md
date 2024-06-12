---
title: Convert PowerPoint to TIFF
type: docs
weight: 90
url: /php-java/convert-powerpoint-to-tiff/
keywords: "Convert PowerPoint Presentation, PowerPoint to TIFF, PPT to TIFF, PPTX to TIFF, Java, Aspose.Slides"
description: "Convert PowerPoint presentation to TIFF in Java"

---

**TIFF** (Tagged Image File Format) is a lossless raster and high-quality image format. Professionals use TIFF for their design, photography, and desktop publishing purposes. For example, if you want to preserve layers and settings in your design or image, you may want to save your work as a TIFF image file. 

Aspose.Slides allows you to convert the slides in PowerPoint directly to TIFF. 

{{% alert title="Tip" color="primary" %}}

You may want to check out Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convert PowerPoint to TIFF**

Using the [Save](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/#save-java.lang.String-int-) method exposed by the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the slides' default size.

This Java code shows you how to convert PowerPoint to TIFF:

```php
// Instantiates a Presentation object that represents a presentation file
  $pres = new Presentation("presentation.pptx");
  try {
    // Saves the presentation as TIFF
    $pres->save("tiff-image.tiff", SaveFormat::Tiff);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }
```

## **Convert PowerPoint to Black-and-White TIFF**

In Aspose.Slides 23.10, Aspose.Slides added a new property ([BwConversionMode](https://reference.aspose.com/slides/php-java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) to the [TiffOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/tiffoptions/) class to allow you to specify the algorithm that is followed when a colored slide or image is converted to a black-and-white TIFF. Note that this setting is applied only when the [CompressionType](https://reference.aspose.com/slides/php-java/com.aspose.slides/tiffoptions/#setCompressionType-int-) property is set to `CCITT4` or `CCITT3`.

This Java code shows you how to convert a colored slide or image to black-and-white TIFF:

```php
  $tiffOptions = new TiffOptions();
  $tiffOptions->setCompressionType(TiffCompressionTypes.CCITT4);
  $tiffOptions->setBwConversionMode(BlackWhiteConversionMode.Dithering);
  $presentation = new Presentation("sample.pptx");
  try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
  } finally {
    if ($presentation != null) {
      $presentation->dispose();
    }
  }
```

## **Convert PowerPoint to TIFF with Custom Size**

If you require a TIFF image with defined dimensions, you can define your preferred figures through the properties provided under [TiffOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/tiffoptions/). Using the [ImageSize](https://reference.aspose.com/slides/php-java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) property, for example, you can set a size for the resulting image.

This Java code shows you how to convert PowerPoint to TIFF images with custom size:

```php
// Instantiates a Presentation object that represents a Presentation file
  $pres = new Presentation("presentation.pptx");
  try {
    // Instantiates the TiffOptions class
    $opts = new TiffOptions();
    // Sets the compression type
    // Possible values are:
    // Default - Specifies the default compression scheme (LZW).
    // None - Specifies no compression.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    $opts->setCompressionType(TiffCompressionTypes.Default);
    // Depth – depends on the compression type and cannot be set manually.
    // Sets the image DPI
    $opts->setDpiX(200);
    $opts->setDpiY(100);
    // Sets the Image Size
    $opts->setImageSize(new Dimension(1728, 1078));
    $options = $opts->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions.BottomFull);
    // Saves the presentation to TIFF with specified size
    $pres->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }
```


## **Convert PowerPoint to TIFF with Custom Image Pixel Format**

Using the [PixelFormat](https://reference.aspose.com/slides/php-java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) property under the [TiffOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image.

This Java code shows you how to convert PowerPoint to TIFF image with custom pixel format:

```php
// Instantiates a Presentation object that represents a Presentation file
  $pres = new Presentation("presentation.pptx");
  try {
    $options = new TiffOptions();
    $options->setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /* ImagePixelFormat contains the following values (as stated in the documentation):
    Format1bppIndexed; // 1 bits per pixel, indexed.
    Format4bppIndexed; // 4 bits per pixel, indexed.
    Format8bppIndexed; // 8 bits per pixel, indexed.
    Format24bppRgb;    // 24 bits per pixel, RGB.
    Format32bppArgb;   // 32 bits per pixel, ARGB.
     */
    // Saves the presentation to TIFF with specified image size
    $pres->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $options);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }
```

