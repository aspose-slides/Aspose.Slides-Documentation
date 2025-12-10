---
title: "在 .NET 中自定义 Treemap 和 Sunburst 图表的数据点"
linktitle: "Treemap 和 Sunburst 图表的数据点"
type: docs
url: /zh/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap 图表
- sunburst 图表
- 数据点
- 标签颜色
- 分支颜色
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 管理 treemap 和 sunburst 图表中的数据点，兼容 PowerPoint 格式。"
---

在 PowerPoint 图表的其他类型中，有两种“层级”类型——**Treemap** 和 **Sunburst** 图表（也称为 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。这些图表以树形结构显示层级数据——从叶子节点到分支的顶部。叶子节点由系列数据点定义，每个后续的嵌套分组层级由相应的类别定义。Aspose.Slides for .NET 允许在 C# 中格式化 Sunburst 图表和 Treemap 的数据点。

下面是一个 Sunburst 图表，其中 Series1 列的数据定义叶子节点，而其他列定义层级数据点：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

让我们开始向演示文稿添加一个新的 Sunburst 图表：
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

如果需要对图表的数据点进行格式化，我们应使用以下内容：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)、[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) 类以及 [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) 属性提供对 Treemap 和 Sunburst 图表数据点的格式化访问。  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 用于访问多层类别——它表示包含 [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) 对象的容器。  
基本上它是对 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) 的包装，并添加了针对数据点的特定属性。  
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) 类有两个属性： [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) 和 [**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) ，提供对相应设置的访问。

## **显示数据点值**
显示 “Leaf 4” 数据点的值：
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **设置数据点标签和颜色**
将 “Branch 1” 的数据标签设置为显示系列名称 (“Series1”) 而非类别名称。然后将文字颜色设置为黄色：
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


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AEf6JMOLavWpvqA6SzOCA6_)

## **常见问题**

**我可以更改 Sunburst/Treemap 中段的顺序（排序）吗？**

不可以。PowerPoint 会自动对段进行排序（通常按值降序、顺时针）。Aspose.Slides 复制了此行为：不能直接更改顺序，只能通过预处理数据来实现。

**演示文稿主题如何影响段落和标签的颜色？**

图表颜色会继承演示文稿的[主题/调色板](/slides/zh/net/presentation-theme/)，除非显式设置填充或字体。若需统一结果，请在所需层级上锁定实色填充和文本格式。

**导出为 PDF/PNG 时会保留自定义分支颜色和标签设置吗？**

会。导出演示文稿时，图表的设置（填充、标签等）会保留在输出的 PDF/PNG 中，因为 Aspose.Slides 在渲染时会应用图表的格式化。

**我可以计算标签/元素的实际坐标，以便在图表上方放置自定义覆盖层吗？**

可以。在图表布局验证后，元素（例如 [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)）的 `ActualX`/`ActualY` 坐标可用，这有助于精确定位覆盖层。