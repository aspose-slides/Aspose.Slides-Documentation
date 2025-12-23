---
title: Convert PPT and PPTX to JPG in PHP
linktitle: PowerPoint to JPG
type: docs
weight: 60
url: /php-java/convert-powerpoint-to-jpg/
keywords: 
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to JPG
- presentation to JPG
- slide to JPG
- PPT to JPG
- PPTX to JPG
- save PowerPoint as JPG
- save presentation as JPG
- save slide as JPG
- save PPT as JPG
- save PPTX as JPG
- export PPT to JPG
- export PPTX to JPG
- PHP
- Aspose.Slides
description: "Convert PowerPoint (PPT, PPTX) slides to high-quality JPG images in PHP with Aspose.Slides for PHP using fast, reliable code examples."
---


## **About PowerPoint to JPG Conversion**
With [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/) you can convert PowerPoint PPT or PPTX presentation to JPG image. It is also possible to convert PPT/PPTX to JPEG, PNG or SVG. With this features it's easy to implement your own presentation viewer, create  the thumbnail for every slide. This may be useful if you want to protect presentation slides from copywriting, demonstrate presentation in read-only mode. Aspose.Slides allows to convert the whole presentation or a certain slide into image formats. 

{{% alert color="primary" %}} 

To see how Aspose.Slides converts PowerPoint to JPG images, you may want to try these free online converters: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) and [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **Convert PowerPoint PPT/PPTX to JPG**
Here are the steps to convert PPT/PPTX to JPG:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) type.
2. Get the slide object of [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) type from [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) collection.
3. Create the thumbnail of each slide and then convert it into JPG. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) method is used to get a thumbnail of a slide, it returns [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) object as a result. [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) method has to be called from the needed slide of [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) type, the scales of the resulting thumbnail are passed into the method.
4. After you get the slide thumbnail, call [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) method from the thumbnail object. Pass the resulting file name and the image format into it. 

{{% alert color="primary" %}}

**Note**: PPT/PPTX to JPG conversion differs from the conversion to other types in Aspose.Slides API. For other types, you usually use [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method, but here you need [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) method.

{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Creates a full scale image
      $slideImage = $sld->getImage(1.0, 1.0);
      # Saves the image to disk in JPEG format
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert PowerPoint PPT/PPTX to JPG with Customized Dimensions**
To change the dimension of the resulting thumbnail and JPG image, you can set the *ScaleX* and *ScaleY* values by passing them into the [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) methods:

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Defines dimensions
    $desiredX = 1200;
    $desiredY = 800;
    # Gets scaled values of X and Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Creates a full scale image
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Saves the image to disk in JPEG format
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Render Comments When Saving Slides as Images**
Aspose.Slides for PHP via Java provides a facility that allows you to render comments in a presentation's slides when you are converting those slides into images. This PHP code demonstrates the operation:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

Using the same principles described in this article, you can convert images from one format to another. For more information, see these pages: convert [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Does this method support batch conversion?**

Yes, Aspose.Slides allows batch conversion of multiple slides to JPG in a single operation.

**Does the conversion support SmartArt, charts, and other complex objects?**

Yes, Aspose.Slides renders all content, including SmartArt, charts, tables, shapes, and more. However, the rendering accuracy may vary slightly compared to PowerPoint, especially when using custom or missing fonts.

**Are there any limitations on the number of slides that can be processed?**

Aspose.Slides itself does not impose any strict limits on the number of slides you can process. However, you may encounter out-of-memory error when working with large presentations or high-resolution images.

## **See Also**

See other options to convert PPT/PPTX into image like:

- [PPT/PPTX to SVG conversion](/slides/php-java/render-a-slide-as-an-svg-image/).