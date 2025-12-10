---
title: 使用 Java 自定义树形图和旭日图中的数据点
linktitle: 树形图和旭日图中的数据点
type: docs
url: /zh/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- 树形图
- 旭日图
- 数据点
- 标签颜色
- 分支颜色
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 管理树形图和旭日图中的数据点，兼容 PowerPoint 格式。"
---

在 PowerPoint 的各种图表类型中，有两种“层级”图表——**Treemap**（树形图）和**Sunburst**（旭日图），也称为 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart。这些图表以树形结构显示层级数据——从叶子节点到分支的顶部。叶子由系列数据点定义，每个后续的嵌套分组层级由相应的类别定义。Aspose.Slides for Java 允许在 Java 中对旭日图和树形图的数据点进行格式化。

下面是一个旭日图，其中 Series1 列的数据定义了叶子节点，其他列定义了层级数据点：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

让我们从向演示文稿中添加一个新的旭日图开始：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="另请参阅" %}} 
- [**创建旭日图**](/slides/zh/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

如果需要对图表的数据点进行格式化，应该使用以下内容：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager)、[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) 类以及 [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) 方法提供对 Treemap 和旭日图数据点的格式化访问。[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 用于访问多层级类别——它是 [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) 对象的容器。本质上它是针对数据点添加了特定属性的 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) 的包装器。[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) 类提供两个方法：[**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) 和 [**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--)，用于访问相应的设置。

## **显示数据点值**
显示 “Leaf 4” 数据点的值：
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **设置数据点标签和颜色**
将 “Branch 1” 的数据标签设置为显示系列名称（“Series1”），而不是类别名称。然后将文字颜色设置为黄色：
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **设置数据点分支颜色**
更改 “Steam 4” 分支的颜色：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **常见问题**

**我可以更改旭日图/树形图中分段的顺序（排序）吗？**

不可以。PowerPoint 会自动对分段进行排序（通常按降序、顺时针）。Aspose.Slides 也遵循此行为：无法直接更改顺序，只能通过预处理数据来实现。

**演示文稿主题如何影响分段和标签的颜色？**

图表颜色会继承演示文稿的 [theme/palette](/slides/zh/java/presentation-theme/)，除非显式设置填充/字体。为了获得一致的效果，请在所需层级上锁定实色填充和文字格式。

**导出为 PDF/PNG 时会保留自定义的分支颜色和标签设置吗？**

会。导出演示文稿时，图表的设置（填充、标签）会在输出格式中保留，因为 Aspose.Slides 会按图表的格式渲染。

**我能计算标签/元素的实际坐标，以便在图表上方进行自定义覆盖吗？**

可以。在图表布局验证完成后，元素会提供实际的 *x* 和 *y* 坐标（例如 [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)），这有助于精确定位覆盖物。