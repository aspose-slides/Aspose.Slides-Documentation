---
title: Add Rectangles to Presentations in PHP
linktitle: Rectangle
type: docs
weight: 80
url: /php-java/rectangle/
keywords:
- add rectangle
- create rectangle
- rectangle shape
- simple rectangle
- formatted rectangle
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Boost your PowerPoint presentations by adding rectangles with Aspose.Slides for PHP via Java — easily design and modify shapes programmatically."
---

{{% alert color="primary" %}} 

Like previous topics, this one is also about adding a shape and this time the shape we will discuss about is **Rectangle**. In this topic, we have described that how developers can add simple or formatted rectangles to their slides using Aspose.Slides for PHP via Java.

{{% /alert %}} 

## **Add a Rectangle to a Slide**
To add a simple rectangle to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) of Rectangle type using [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a simple rectangle to the first slide of the presentation.

```php
  # Instantiate Prseetation class that represents the PPTX
  $pres = new Presentation();
  try {
    # Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Add AutoShape of ellipse type
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Write the PPTX file to disk
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add a Formatted Rectangle to a Slide**
To add a formatted rectangle to a slide, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) of Rectangle type using [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) object.
- Set the [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) of the Rectangle to Solid.
- Set the Color of the Rectangle using [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) method as exposed by [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) object associated with the [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) object.
- Set the Color of the lines of the Rectangle.
- Set the Width of the lines of the Rectangle.
- Write the modified presentation as PPTX file.

The above steps are implemented in the example given below.

```php
  # Instantiate Prseetation class that represents the PPTX
  $pres = new Presentation();
  try {
    # Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Add AutoShape of ellipse type
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Apply some formatting to ellipse shape
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Apply some formatting to the line of Ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Write the PPTX file to disk
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**How do I add a rectangle with rounded corners?**

Use the rounded-corner [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) and adjust the corner radius in the shape’s properties; rounding can also be applied per corner via geometry adjustments.

**How do I fill a rectangle with an image (texture)?**

Select the picture [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), provide the image source, and configure [stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/).

**Can a rectangle have shadow and glow?**

Yes. [Outer/inner shadow, glow, and soft edges](/slides/php-java/shape-effect/) are available with adjustable parameters.

**Can I turn a rectangle into a button with a hyperlink?**

Yes. [Assign a hyperlink](/slides/php-java/manage-hyperlinks/) to the shape click (jump to a slide, file, web address, or e-mail).

**How can I protect a rectangle from moving and changes?**

[Use shape locks](/slides/php-java/applying-protection-to-presentation/): you can forbid moving, resizing, selection, or text editing to preserve the layout.

**Can I convert a rectangle to a raster image or SVG?**

Yes. You can [render the shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) to an image with a specified size/scale or [export it as SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) for vector use.

**How do I quickly get the actual (effective) properties of a rectangle considering theme and inheritance?**

[Use the shape’s effective properties](/slides/php-java/shape-effective-properties/): the API returns computed values that account for theme styles, layout, and local settings, simplifying formatting analysis.
