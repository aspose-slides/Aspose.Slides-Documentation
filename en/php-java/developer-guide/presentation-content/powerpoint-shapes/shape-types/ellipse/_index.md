---
title: Add Ellipses to Presentations in PHP
linktitle: Ellipse
type: docs
weight: 30
url: /php-java/ellipse/
keywords:
- ellipse
- shape
- add ellipse
- create ellipse
- draw ellipse
- formatted ellipse
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn how to create, format, and manipulate ellipse shapes in Aspose.Slides for PHP via Java across PPT and PPTX presentations — code examples included."
---


{{% alert color="primary" %}} 

In this topic, we will introduce developers about adding ellipse shapes to their slides using Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java provides an easier set of APIs to draw different kinds of shapes with just a few lines of code.

{{% /alert %}} 

## **Create an Ellipse**
To add a simple ellipse to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Ellipse type using [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added an ellipse to the first slide

```php
  # Instantiate Presentation class that represents the PPTX
  $pres = new Presentation();
  try {
    # Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Add AutoShape of ellipse type
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Write the PPTX file to disk
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Create a Formatted Ellipse**
To add a better formatted ellipse to a slide, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Ellipse type using [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) object.
- Set the Fill Type of the Ellipse to Solid.
- Set the Color of the Ellipse using SolidFillColor.Color property as exposed by [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) object associated with the [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) object.
- Set the Color of the lines of the Ellipse.
- Set the Width of the lines of the Ellipse.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a formatted ellipse to the first slide of the presentation.

```php
  # Instantiate Presentation class that represents the PPTX
  $pres = new Presentation();
  try {
    # Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Add AutoShape of ellipse type
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Apply some formatting to ellipse shape
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Apply some formatting to the line of Ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Write the PPTX file to disk
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**How do I set the exact position and size of an ellipse with respect to the slide's units?**

Coordinates and sizes are typically specified **in points**. For predictable results, base your calculations on the slide size and convert required millimeters or inches to points before assigning values.

**How can I place an ellipse above or below other objects (control stacking order)?**

Adjust the drawing order of the object by bringing it to front or sending it to back. This lets the ellipse overlap other objects or reveal those beneath it.

**How do I animate the appearance or emphasis of an ellipse?**

[Apply](/slides/php-java/shape-animation/) entrance, emphasis, or exit effects to the shape, and configure triggers and timing to orchestrate when and how the animation plays.
