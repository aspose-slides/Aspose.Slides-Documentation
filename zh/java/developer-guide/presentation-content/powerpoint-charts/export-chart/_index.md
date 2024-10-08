---
title: 导出图表
type: docs
weight: 90
url: /zh/java/export-chart/
---

## **获取图表图像**
Aspose.Slides for Java 提供对提取特定图表图像的支持。以下是示例代码。

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