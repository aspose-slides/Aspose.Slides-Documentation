---
title: 在 Android 上的演示文稿中自定义气泡图
linktitle: 气泡图
type: docs
url: /zh/androidjava/bubble-chart/
keywords:
- 气泡图
- 气泡大小
- 大小缩放
- 大小表示
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 中创建并自定义功能强大的气泡图，轻松提升数据可视化效果。"
---

## **气泡图大小缩放**
Aspose.Slides for Android via Java 提供对气泡图大小缩放的支持。已在 Aspose.Slides for Android via Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) 和 [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) 方法中添加了此功能。下面给出示例。

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


## **将数据表示为气泡图大小**
在 [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries)、[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) 接口及相关类中添加了方法 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) 和 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--)。**BubbleSizeRepresentation** 指定气泡图中气泡大小值的表示方式。可能的取值有：[**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) 和 [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width)。相应地，已添加枚举 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) 用于指定将数据表示为气泡图大小的可能方式。下面给出示例代码。

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


## **FAQ**

**是否支持“带 3-D 效果的气泡图”，它与普通气泡图有什么区别？**

是的。提供单独的图表类型 “Bubble with 3-D”。该类型对气泡应用 3-D 样式，但不添加额外的坐标轴；数据仍保持 X‑Y‑S（大小）结构。此类型可在 [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 类中找到。

**气泡图的系列和数据点数量是否有限制？**

在 API 层面没有硬性限制；限制取决于性能和目标 PowerPoint 版本。建议保持数据点数量在合理范围内，以确保可读性和渲染速度。

**导出（PDF、图像）会如何影响气泡图的外观？**

导出为受支持的格式时会保留图表外观；渲染由 Aspose.Slides 引擎完成。对于光栅/矢量格式，遵循一般的图表渲染规则（分辨率、抗锯齿），因此请为打印选择足够的 DPI。