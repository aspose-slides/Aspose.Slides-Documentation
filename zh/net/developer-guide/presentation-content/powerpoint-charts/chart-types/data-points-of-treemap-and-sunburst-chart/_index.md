---
title: 树状图和旭日图的数据点
type: docs
url: /zh/net/data-points-of-treemap-and-sunburst-chart/
keywords: "旭日图, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 PowerPoint 演示文稿中使用 C# 或 .NET 添加旭日图"
---

在 PowerPoint 图表的其他类型中，有两种“层级”类型——**Treemap**（树状图）和**Sunburst**（旭日图）图表（亦称 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。这些图表以树状结构展示层级数据——从叶子节点到分支顶端。叶子节点由系列数据点定义，每个后续的嵌套分组层级由相应的分类定义。Aspose.Slides for .NET 允许在 C# 中对 Sunburst 图表和 Treemap 的数据点进行格式化。

下面是一个 Sunburst 图表，其中 Series1 列的数据定义了叶子节点，其他列定义了层级数据点：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

让我们从向演示文稿添加一个新的 Sunburst 图表开始：
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="另请参阅" %}} 
- [**创建 Sunburst 图表**](/slides/zh/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

如果需要对图表的数据点进行格式化，应使用以下内容：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)、[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) 类以及 [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) 属性提供了对 Treemap 和 Sunburst 图表数据点进行格式化的访问方式。  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 用于访问多层级分类——它表示 [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) 对象的容器。  
基本上它是对 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) 的包装，并为数据点添加了特定的属性。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) 类拥有两个属性： [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) 和 [**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) ，它们提供对相应设置的访问。

## **显示数据点值**
显示 “Leaf 4” 数据点的值：
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **设置数据点标签和颜色**
将 “Branch 1” 的数据标签设置为显示系列名称（“Series1”），而不是分类名称。随后将文字颜色设置为黄色：
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **设置数据点分支颜色**

更改 “Stem 4” 分支的颜色：
```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**我可以更改 Sunburst/Treemap 中各分段的顺序（排序）吗？**

不能。PowerPoint 会自动对分段进行排序（通常按降序值、顺时针方向）。Aspose.Slides 复制了这种行为：无法直接更改顺序，只能通过预处理数据来实现。

**演示文稿的主题如何影响分段和标签的颜色？**

图表颜色会继承演示文稿的[主题/调色板](/slides/zh/net/presentation-theme/)，除非显式设置填充或字体。为获得一致的效果，请在所需层级上锁定纯色填充和文字格式。

**导出为 PDF/PNG 时会保留自定义的分支颜色和标签设置吗？**

会。导出演示文稿时，图表的设置（填充、标签）会在输出格式中保留下来，因为 Aspose.Slides 会使用已应用的图表格式进行渲染。

**我能计算标签/元素的实际坐标，以便在图表上方放置自定义遮罩吗？**

可以。图表布局验证后，`ActualX`/`ActualY` 可用于元素（例如 [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)），这有助于精确定位覆盖层。