---
title: 在 Java 中自定义演示文稿图表的绘图区
linktitle: 绘图区
type: docs
url: /zh/java/chart-plot-area/
keywords:
- 图表
- 绘图区
- 绘图区宽度
- 绘图区高度
- 绘图区大小
- 布局模式
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: 了解如何使用 Aspose.Slides for Java 自定义 PowerPoint 演示文稿中的图表绘图区。轻松提升幻灯片视觉效果。
---

## **获取图表绘图区的宽度和高度**
Aspose.Slides for Java 为 . 提供了一个简单的 API。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加具有默认数据的图表。
1. 在获取实际值之前，调用方法 [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--)。
1. 获取图表元素相对于图表左上角的实际 X 位置（左）。
1. 获取图表元素相对于图表左上角的实际顶部位置。
1. 获取图表元素的实际宽度。
1. 获取图表元素的实际高度。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **设置图表绘图区的布局模式**
Aspose.Slides for Java 提供了一个简单的 API 用于设置图表绘图区的布局模式。已向 [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) 类和 [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea) 接口添加了方法 [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 和 [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--)。如果绘图区的布局手动定义，则此属性指定是按内部（不包括坐标轴和坐标轴标签）还是外部（包括坐标轴和坐标轴标签）进行布局。此枚举在 [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType) 中定义了两种可能的值。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - 指定绘图区的尺寸应决定绘图区的大小，不包括刻度线和坐标轴标签。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - 指定绘图区的尺寸应决定绘图区的大小、刻度线和坐标轴标签。

下面给出示例代码。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**实际的 x、实际的 y、实际宽度和实际高度以何种单位返回？**

以点为单位；1 英寸 = 72 点。这些是 Aspose.Slides 的坐标单位。

**绘图区在内容上如何区别于图表区？**

绘图区是数据绘制区域（系列、网格线、趋势线等）；图表区包括周围的元素（标题、图例等）。在 3D 图表中，绘图区还包括墙面/底面和坐标轴。

**当布局为手动时，绘图区的 x、y、宽度和高度如何解释？**

它们是图表整体尺寸的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例值。

**为何在添加/移动图例后绘图区位置会发生变化？**

图例位于图表区的绘图区之外，但会影响布局和可用空间，因此在自动定位生效时，绘图区可能会移动。（这是 PowerPoint 图表的标准行为。）