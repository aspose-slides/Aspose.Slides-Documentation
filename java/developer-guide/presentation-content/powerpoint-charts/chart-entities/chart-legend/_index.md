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

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Get reference of the slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add a clustered column chart on the slide
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Set Legend Properties
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Write presentation to disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Font Size of Legend**
The Aspose.Slides for Java lets developers allow to set font size of legend. Please follow the steps below: 

- Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Creating the default chart.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Font Size of Individual Legend**
The Aspose.Slides for Java lets developers allow to set font size of individual legend entries. Please follow the steps below: 

- Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Creating the default chart.
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write presentation to disk.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

