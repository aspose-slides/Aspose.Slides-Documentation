---
title: 使用 Java 定制 Treemap 和 Sunburst 图表中的数据点
linktitle: Treemap 和 Sunburst 图表中的数据点
type: docs
url: /zh/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 图表
- Sunburst 图表
- 数据点
- 标签颜色
- 分支颜色
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 管理 Treemap 和 Sunburst 图表中的数据点，兼容 PowerPoint 格式。"
---

在其他 PowerPoint 图表类型之外，还有两种“层级”类型——**Treemap** 和 **Sunburst** 图表（亦称为 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。这些图表显示以树形结构组织的层级数据——从叶子节点到分支的顶部。叶子由系列数据点定义，每个后续的嵌套分组层级由相应的分类定义。Aspose.Slides for Java 允许在 Java 中格式化 Sunburst 图表和 Treemap 的数据点。

以下是一个 Sunburst 图表，其中 Series1 列中的数据定义叶子节点，其他列定义层级数据点：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

让我们从向演示文稿添加一个新的 Sunburst 图表开始：
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // …
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="另请参阅" %}} 
- [**在 Java 中创建或更新 PowerPoint 演示文稿图表**](/slides/zh/java/create-chart/)
{{% /alert %}}

如果需要对图表的数据点进行格式化，我们应使用以下内容：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager)、[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) 类以及 [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) 方法提供对 Treemap 和 Sunburst 图表数据点的格式化访问。

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 用于访问多层级分类——它表示 [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) 对象的容器。基本上它是 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) 的包装器，并为数据点添加了特定的属性。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) 类有两个方法： [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) 和 [**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--)，它们提供对相应设置的访问。

## **显示数据点值**
显示 “Leaf 4” 数据点的数值：
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **设置数据点标签和颜色**
将 “Branch 1” 数据标签设置为显示系列名称（“Series1”）而非分类名称。随后将文字颜色设为黄色：
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

**我可以更改 Sunburst/Treemap 中段的顺序（排序）吗？**

不能。PowerPoint 会自动对段进行排序（通常按值降序，顺时针）。Aspose.Slides 复制了此行为：无法直接更改顺序；只能通过预处理数据来实现。

**演示文稿主题如何影响段和标签的颜色？**

除非显式设置填充/字体，否则图表颜色会继承演示文稿的[主题/调色板](/slides/zh/java/presentation-theme/)。为获得一致的效果，请在所需层级锁定纯色填充和文本格式。

**导出为 PDF/PNG 时会保留自定义的分支颜色和标签设置吗？**

会。导出演示文稿时，图表的设置（填充、标签）会在输出格式中保留，因为 Aspose.Slides 会按图表的格式进行渲染。

**我可以计算标签/元素的实际坐标，以便在图表上方放置自定义覆盖吗？**

可以。在图表布局验证后，元素（例如 [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)）的实际 *x* 和 *y* 坐标即可获取，这有助于精确定位覆盖层。