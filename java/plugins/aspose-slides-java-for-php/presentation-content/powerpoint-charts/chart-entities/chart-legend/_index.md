---
title: Chart Legend
type: docs
url: /java/chart-legend/
---

## **Legend Positioning**
In order to set the legend properties. Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Get reference of the slide.
- Adding a chart on slide.
- Setting the properties of legend.
- Write the presentation as a PPTX file.

In the example given below, we have set the position and size for Chart legend.

```php
// Create an instance of Presentation class
$pres = new Java("com.aspose.slides.Presentation");
try {
    // Get reference of the slide
    $slide = $pres->getSlides()->get_Item(0);
    
    // Add a clustered column chart on the slide
    $chart = $slide->getShapes()->addChart(Java("com.aspose.slides.ChartType")->ClusteredColumn, 50, 50, 500, 500);
    
    // Set Legend Properties
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    
    // Write presentation to disk
    $pres->save("Legend_out.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Set Font Size of Legend**
The Aspose.Slides for Java lets developers allow to set font size of legend. Please follow the steps below: 

- Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Creating the default $chart->
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```php
// Create an instance of Presentation class
$pres = new Java("com.aspose.slides.Presentation");
try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(Java("com.aspose.slides.ChartType")->ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $pres->save("output.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```

## **Set Font Size of Individual Legend**
The Aspose.Slides for Java lets developers allow to set font size of individual legend entries. Please follow the steps below: 

- Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Creating the default $chart->
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```php
// Create an instance of Presentation class
$pres = new Java("com.aspose.slides.Presentation");
try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(Java("com.aspose.slides.ChartType")->ClusteredColumn, 50, 50, 600, 400);

    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $tf->getPortionFormat()->setFontBold(Java("com.aspose.slides.NullableBool")->True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(Java("com.aspose.slides.NullableBool")->True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(Java("com.aspose.slides.FillType")->Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(Java("java.awt.Color")->BLUE);
    
    $pres->save("output.pptx", Java("com.aspose.slides.SaveFormat")->Pptx);
} finally {
    if ($pres != null) $pres->dispose();
}
```
