---
title: 使用 Java 在演示文稿中自定义气泡图
linktitle: 气泡图
type: docs
url: /zh/java/bubble-chart/
keywords:
- 气泡图
- 气泡大小
- 尺寸缩放
- 尺寸表示
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 中轻松创建和自定义强大的气泡图，以增强数据可视化。"
---

## **泡泡图尺寸缩放**
Aspose.Slides for Java 提供对泡泡图尺寸缩放的支持。在 Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) 和 [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) 方法已添加。以下提供示例代码。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将数据表示为泡泡图尺寸**
已在 [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries) 和 [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup) 接口以及相关类中添加了方法 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) 和 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--)。**BubbleSizeRepresentation** 指定了在泡泡图中如何表示泡泡尺寸值。可能的取值为 [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Area) 和 [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Width)。因此已添加了枚举 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType) 用于指定将数据表示为泡泡图尺寸的可能方式。下面给出示例代码。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**是否支持“带 3-D 效果的泡泡图”，它与普通泡泡图有何区别？**

是的。有一种独立的图表类型 “Bubble with 3-D”。它对泡泡应用 3-D 样式，但不额外添加坐标轴；数据仍保持 X‑Y‑S（尺寸）结构。该类型位于 [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 类中。

**泡泡图对系列和数据点的数量有限制吗？**

在 API 层面没有硬性限制，实际约束由性能和目标 PowerPoint 版本决定。建议保持数据点数量在可读性和渲染速度可接受的范围内。

**导出（PDF、图片等）会如何影响泡泡图的外观？**

导出到受支持的格式时会保持图表的外观；渲染由 Aspose.Slides 引擎完成。对于光栅或矢量格式，遵循一般的图表渲染规则（分辨率、抗锯齿），因此在打印时请选择足够的 DPI。