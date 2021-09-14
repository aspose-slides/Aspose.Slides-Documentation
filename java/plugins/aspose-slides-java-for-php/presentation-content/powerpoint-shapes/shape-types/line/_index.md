---
title: Line
type: docs
weight: 10
url: /java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides for Java supports adding different kinds of shapes to the slides. In this topic, we will start working with shapes by adding lines to the slides. Using Aspose.Slides for Java, developers can not only create simple lines, but some fancy lines can also be drawn on the slides.

{{% /alert %}} 

## **Create Plain Line**

To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [addAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object.
- Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```php
// Instantiate PresentationEx class that represents the PPTX file
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Get the first slide
    $sld = $pres->getSlides()->get_Item(0);
    
    // Add an AutoShape of type line
    $sld->getShapes()->addAutoShape(Java("com.aspose.slides.ShapeType")->Line, 50, 150, 300, 0);
    
    // Write the PPTX to Disk
    $pres->save("LineShape.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Create Arrow Shaped Line**

Aspose.Slides for Java also allows developers to configure some properties of the line to make it look more appealing. Let's try to configure few properties of a line to make it look like an arrow. Please follow the steps below to do so:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Line type using [addAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) method exposed by [IShapeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object.
- Set the [Line Style](https://apireference.aspose.com/slides/java/com.aspose.slides/LineStyle) to one of the styles as offered by Aspose.Slides for Java.
- Set the Width of the line.
- Set the [Dash Style](https://apireference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) of the line to one of the styles offered by Aspose.Slides for Java.
- Set the [Arrow Head Style](https://apireference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) and [Length](https://apireference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) of the start point of the line.
- Set the [Arrow Head Style](https://apireference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) and [Length](https://apireference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) of the end point of the line.
- Write the modified presentation as a PPTX file.

```php
// Instantiate PresentationEx class that represents the PPTX file
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Get the first slide
    $sld = $pres->getSlides()->get_Item(0);

    // Add an AutoShape of type line
    $shp = $sld->getShapes()->addAutoShape(Java("com.aspose.slides.ShapeType")->Line, 50, 150, 300, 0);

    // Apply some formatting on the line
    $shp->getLineFormat()->setStyle(Java("com.aspose.slides.LineStyle")->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);

    $shp->getLineFormat()->setDashStyle(Java("com.aspose.slides.LineDashStyle")->DashDot);

    $shp->getLineFormat()->setBeginArrowheadLength(Java("com.aspose.slides.LineArrowheadLength")->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(Java("com.aspose.slides.LineArrowheadStyle")->Oval);

    $shp->getLineFormat()->setEndArrowheadLength(Java("com.aspose.slides.LineArrowheadLength")->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(Java("com.aspose.slides.LineArrowheadStyle")->Triangle);

    $shp->getLineFormat()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", Java("com.aspose.slides.PresetColor")->Maroon));

    // Write the PPTX to Disk
    $pres->save("LineShape.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```