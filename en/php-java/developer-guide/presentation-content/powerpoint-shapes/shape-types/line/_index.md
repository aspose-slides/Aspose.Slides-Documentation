---
title: Add Line Shapes to Presentations in PHP
linktitle: Line
type: docs
weight: 50
url: /php-java/Line/
keywords:
- line
- create line
- add line
- plain line
- configure line
- customize line
- dash style
- arrow head
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn to manipulate line formatting in PowerPoint presentations with Aspose.Slides for PHP via Java. Discover properties, methods, and examples."
---


{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides for PHP via Java, developers can not only create simple lines, but some fancy lines can also be drawn on the slides.

{{% /alert %}} 

## **Create a Plain Line**

To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) method exposed by [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```php
  # Instantiate PresentationEx class that represents the PPTX file
  $pres = new Presentation();
  try {
    # Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Add an AutoShape of type line
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Write the PPTX to Disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Create an Arrow-Shaped Line**

Aspose.Slides for PHP via Java also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) method exposed by [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) object.
- Set the [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) to one of the styles as offered by Aspose.Slides for PHP via Java.
- Set the Width of the line.
- Set the [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) of the line to one of the styles offered by Aspose.Slides for PHP via Java.
- Set the [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) and [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) of the start point of the line.
- Set the [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) and [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) of the end point of the line.
- Write the modified presentation as a PPTX file.

```php
  # Instantiate PresentationEx class that represents the PPTX file
  $pres = new Presentation();
  try {
    # Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    # Add an AutoShape of type line
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Apply some formatting on the line
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Write the PPTX to Disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) type and the [corresponding APIs](/slides/php-java/connector/) for connections.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Read the effective properties](/slides/php-java/shape-effective-properties/) through the `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—these already account for inheritance and theme styles.

**Can I lock a line against editing (moving, resizing)?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/) that let you disallow editing operations.
