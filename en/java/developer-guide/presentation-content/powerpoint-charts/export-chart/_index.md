---
title: Export Presentation Charts in Java
linktitle: Export Chart
type: docs
weight: 90
url: /java/export-chart/
keywords:
- chart
- chart to image
- chart as image
- extract chart image
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Learn how to export presentation charts with Aspose.Slides for Java, supporting PPT and PPTX formats, and streamline reporting into any workflow."
---

## **Get Chart Image**
Aspose.Slides for Java provides support for extracting image of specific chart. Below sample example is given. 

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```
