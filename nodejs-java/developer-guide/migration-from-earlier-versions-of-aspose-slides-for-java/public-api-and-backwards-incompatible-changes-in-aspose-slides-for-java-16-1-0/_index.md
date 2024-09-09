---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) or [removed](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) classes, methods, properties and so on, and other changes introduced with the Aspose.Slides for Java 16.1.0 API.

{{% /alert %}} 
## **Public API Changes**


#### **Methods getRotationAngle() and setRotationAngle() have been added to IChartTextBlockFormat and ITextFrameFormat interfaces**
Methods getRotationAngle() and setRotationAngle() have been added to interfaces com.aspose.slides.IChartTextBlockFormat and com.aspose.slides.ITextFrameFormat.
They provide access to the custom rotation that is being applied to the text within the bounding box.

```javascript
    var pres = new  com.aspose.slides.Presentation();
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(com.aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getTextBlockFormat().setRotationAngle(65);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);
    pres.save("out.pptx", com.aspose.slides.SaveFormat.Pptx);
```
