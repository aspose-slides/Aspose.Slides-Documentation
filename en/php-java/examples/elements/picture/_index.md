---
title: Picture
type: docs
weight: 50
url: /php-java/examples/elements/picture/
keywords:
- picture
- picture frame
- add picture
- access picture
- code examples
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Work with pictures in PHP using Aspose.Slides: insert, replace, crop, compress, adjust transparency and effects, fill shapes, and export for PPT, PPTX and ODP."
---

Shows how to insert and access pictures using **Aspose.Slides for PHP via Java**. The examples below place an image on a slide, and then retrieve it.

## **Add a Picture**

This code and inserts an image as a picture frame on the first slide.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Add the image to the presentation resources.
        $ppImage = $presentation->getImages()->addImage($image);

        // Insert a picture frame showing the image on the first slide.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Picture**

This example ensures a slide contains a picture frame and then accesses the first one it finds.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Access the first PictureFrame on the slide.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```
