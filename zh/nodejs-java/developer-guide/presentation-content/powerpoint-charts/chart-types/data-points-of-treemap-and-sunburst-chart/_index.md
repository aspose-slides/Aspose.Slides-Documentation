---
title: 使用 JavaScript 自定义 Treemap 和 Sunburst 图表的数据点
linktitle: Treemap 和 Sunburst 图表中的数据点
type: docs
url: /zh/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 图表
- Sunburst 图表
- 数据点
- 标签颜色
- 分支颜色
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 和 Aspose.Slides for Node.js via Java 管理 Treemap 和 Sunburst 图表中的数据点，兼容 PowerPoint 格式。"
---

在其他 PowerPoint 图表类型之外，有两种“层级”图表——**Treemap** 和 **Sunburst** 图表（也称为 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。这些图表以树形结构展示层级数据——从叶子节点到分支顶部。叶子节点由系列数据点定义，随后的每个嵌套分组层级由相应的类别定义。Aspose.Slides for Node.js via Java 允许在 JavaScript 中格式化 Sunburst 图表和 Treemap 的数据点。

下面是一个 Sunburst 图表，其中 Series1 列的数据定义叶子节点，其余列定义层级数据点：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // （此处省略）
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="See also" %}} 
- [**在 JavaScript 中创建或更新 PowerPoint 演示文稿图表**](/slides/zh/nodejs-java/create-chart/)
{{% /alert %}}

如果需要格式化图表的数据点，应使用以下内容：

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager)、[ChartDataPointLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) 类以及 [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) 方法提供对 Treemap 和 Sunburst 图表数据点的格式化访问。

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevelsManager) 用于访问多层级类别——它代表了 [**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) 对象的容器。基本上它是对 [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartCategoryLevelsManager) 的包装，添加了针对数据点的特定属性。

[**ChartDataPointLevel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel) 类提供两个方法： [**getFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) 和 [**getDataLabel**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--)，用于访问相应的设置。

## **显示数据点值**
显示 “Leaf 4” 数据点的值：

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **设置数据点标签和颜色**
将 “Branch 1” 数据标签设置为显示系列名称（“Series1”），而不是类别名称。然后将文字颜色设为黄色：

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **设置数据点分支颜色**
更改 “Steam 4” 分支的颜色：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **常见问题**

**我可以更改 Sunburst/Treemap 中段的顺序（排序）吗？**

不能。PowerPoint 会自动对段进行排序（通常按数值降序、顺时针方向）。Aspose.Slides 采用相同的行为：无法直接更改顺序，只能通过预处理数据实现。

**演示文稿主题如何影响段和标签的颜色？**

图表颜色会继承演示文稿的 [theme/palette](/slides/zh/nodejs-java/presentation-theme/)，除非显式设置填充或字体。为获得一致效果，请在所需层级锁定实色填充和文字格式。

**导出为 PDF/PNG 时会保留自定义分支颜色和标签设置吗？**

会。导出演示文稿时，图表的设置（填充、标签）会在输出格式中保留，因为 Aspose.Slides 会按照图表的格式进行渲染。

**我能计算标签/元素的实际坐标以在图表上方进行自定义覆盖吗？**

可以。在图表布局验证后，可获取元素的实际 X 和实际 Y（例如 [DataLabel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/)），这有助于精确定位覆盖层。