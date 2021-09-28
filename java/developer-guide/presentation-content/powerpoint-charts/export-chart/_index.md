---
title: Export Chart
type: docs
weight: 90
url: /java/export-chart/
---

## **Get Chart Image**
Aspose.Slides for .NET provides support for extracting image of specific chart. Below sample example is given. 

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    BufferedImage img = chart.getThumbnail();
    
    ImageIO.write(img, "PNG", new java.io.File("image.png"));
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
