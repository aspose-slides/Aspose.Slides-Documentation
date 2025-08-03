---
title: 在 Python 中自定义树状图和旭日图中的数据点
linktitle: 树状图和旭日图中的数据点
type: docs
url: /zh/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- 树状图
- 旭日图
- 数据点
- 标签颜色
- 分支颜色
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 来管理树状图和旭日图中的数据点，兼容 PowerPoint 和 OpenDocument 格式。"
---

在其他类型的 PowerPoint 图表中，有两种“层次结构”类型 - **Treemap** 和 **Sunburst** 图表（也称为 Sunburst 图、Sunburst 图示、径向图、径向图或多层饼图）。这些图表显示层次结构数据，按照树的形式组织 - 从叶子到树枝的顶部。叶子由系列数据点定义，每个后续的嵌套分组级别由相应的类别定义。Aspose.Slides for Python via .NET 允许在 Python 中格式化 Sunburst 图表和 Treemap 的数据点。

这是一个 Sunburst 图表，其中 Series1 列中的数据定义了叶子节点，而其他列定义了层次结构数据点：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

让我们开始在演示文稿中添加一个新的 Sunburst 图表：

```py
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
```

{{% alert color="primary" title="另请参阅" %}} 
- [**创建 Sunburst 图表**](/slides/zh/python-net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

如果需要格式化图表的数据点，我们应该使用以下内容：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/)，
[IChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) 类
和 [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/) 属性
提供对 Treemap 和 Sunburst 图表的数据点格式化的访问。
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/) 
用于访问多层类别 - 它表示
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) 对象的容器。
基本上，它是
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartCategoryLevelsManager/) 的封装，
并增加了针对数据点的特定属性。
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) 类有
两个属性：[**Format**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) 和
[**DataLabel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/)，
提供对相应设置的访问。
## **显示数据点值**
显示“叶子 4”数据点的值：

```py
    dataPoints = chart.chart_data.series[0].data_points
    dataPoints[3].data_point_levels[0].label.data_label_format.show_value = True
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **设置数据点标签和颜色**
将“分支 1”数据标签设置为显示系列名称（“Series1”）而不是类别名称。然后将文本颜色设置为黄色：

```py
    branch1Label = dataPoints[0].data_point_levels[2].label
    branch1Label.data_label_format.show_category_name = False
    branch1Label.data_label_format.show_series_name = True

    branch1Label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    branch1Label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **设置数据点分支颜色**

更改“茎 4”分支的颜色：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
    dataPoints = chart.chart_data.series[0].data_points

    stem4branch = dataPoints[9].data_point_levels[1]
    
    stem4branch.format.fill.fill_type = slides.FillType.SOLID
    stem4branch.format.fill.solid_fill_color.color = draw.Color.red
      
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)