---
title: Rectangle
type: docs
weight: 80
url: /php-java/rectangle/
---

{{% alert color="primary" %}} 

Like previous topics, this one is also about adding a shape and this time the shape we will discuss about is **Rectangle**. In this topic, we have described that how developers can add simple or formatted rectangles to their slides using Aspose.Slides for PHP via Java.

{{% /alert %}} 

## **Add Rectangle to Slide**
To add a simple rectangle to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAutoShape) of Rectangle type using [addAutoShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/IShapeCollection) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a simple rectangle to the first slide of the presentation.

```php
  // Instantiate Prseetation class that represents the PPTX
  $pres = new Presentation();
  try {
    // Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    // Add AutoShape of ellipse type
    $shp = $sld->getShapes()->addAutoShape(ShapeType->Rectangle, 50, 150, 150, 50);
    // Write the PPTX file to disk
    $pres->save("RecShp1.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }

```

## **Add Formatted Rectangle to Slide**
To add a formatted rectangle to a slide, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/IAutoShape) of Rectangle type using [addAutoShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://reference.aspose.com/slides/php-java/com.aspose.slides/IShapeCollection) object.
- Set the [Fill Type](https://reference.aspose.com/slides/php-java/com.aspose.slides/FillType) of the Rectangle to Solid.
- Set the Color of the Rectangle using [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) method as exposed by [IFillFormat](https://reference.aspose.com/slides/php-java/com.aspose.slides/IFillFormat) object associated with the [IShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/IShape) object.
- Set the Color of the lines of the Rectangle.
- Set the Width of the lines of the Rectangle.
- Write the modified presentation as PPTX file.

The above steps are implemented in the example given below.

```php
  // Instantiate Prseetation class that represents the PPTX
  $pres = new Presentation();
  try {
    // Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    // Add AutoShape of ellipse type
    $shp = $sld->getShapes()->addAutoShape(ShapeType->Rectangle, 50, 150, 150, 50);
    // Apply some formatting to ellipse shape
    $shp->getFillFormat()->setFillType(FillType->Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    // Apply some formatting to the line of Ellipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType->Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    // Write the PPTX file to disk
    $pres->save("RecShp2.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }

```
