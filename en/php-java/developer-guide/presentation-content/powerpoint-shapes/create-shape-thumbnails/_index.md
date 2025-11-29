---
title: Create Thumbnails of Presentation Shapes in PHP
linktitle: Shape Thumbnails
type: docs
weight: 70
url: /php-java/create-shape-thumbnails/
keywords:
- shape thumbnail
- shape image
- render shape
- shape rendering
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Generate high-quality shape thumbnails from PowerPoint slides with Aspose.Slides for PHP via Java – easily create and export presentation thumbnails."
---


## **Overview**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java can be used to create presentation files in which each page corresponds to a slide. The slides can be viewed by opening the presentation files using Microsoft PowerPoint. However, developers sometimes need to view the images of the shapes separately in an image viewer. In such cases, Aspose.Slides for PHP via Java helps them generate thumbnail images of the slide shapes.

{{% /alert %}} 

In this topic, we will show how to generate slide thumbnails in different situations:

- Generating a shape thumbnail inside a slide.
- Generating a shape thumbnail for a slide shape with user-defined dimensions.
- Generating a shape thumbnail in the bounds of a shape's appearance.

## **Generating Shape Thumbnails from Slides**
To generate a shape thumbnail from any slide using Aspose.Slides for PHP via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) of the referenced slide on default scale.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail from a slide:

```php
  # Instantiate a Presentation class that represents the presentation file
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Create a full scale image
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Save the image to disk in PNG format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generating Shape Thumbnails with User-Defined Scaling Factor**
To generate the shape thumbnail of a slide using Aspose.Slides for PHP via Java, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. [Get the shape thumbnail image](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) of the referenced slide with user-defined dimensions.
1. Save the thumbnail image in your preferred image format.

This sample code shows you how to generate a shape thumbnail based on a defined scaling factor:

```php
  # Instantiate a Presentation class that represents the presentation file
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Create a full scale image
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Save the image to disk in PNG format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Generating Shape Thumbnail of Bounds**
This method of creating thumbnails of shapes allows developers to generate a thumbnail in the bounds of the shape's appearance. It takes into account all the shape effects. The generated shape thumbnail is restricted by the slide bounds. To generate a thumbnail of a slide shape in the bound of its appearance, do this:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. Obtain the reference of any slide using its ID or index.
1. Get the thumbnail image of the referenced slide with shape bounds as appearance.
1. Save the thumbnail image in your preferred image format.

This sample code is based on the steps above:

```php
  # Instantiate a Presentation class that represents the presentation file
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Create a full scale image
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Save the image to disk in PNG format
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
