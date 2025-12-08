---
title: 在 Python 中自定义 Treemap 和 Sunburst 图表的数据点
linktitle: Treemap 和 Sunburst 图表中的数据点
type: docs
url: /zh/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap 图表
- sunburst 图表
- 数据点
- 标签颜色
- 分支颜色
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 treemap 和 sunburst 图表中管理数据点，兼容 PowerPoint 和 OpenDocument 格式。"
---

## **简介**

在 PowerPoint 的其它图表类型中，有两种层级图表——**Treemap** 和 **Sunburst**（也称为 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi-Level Pie Chart）。这些图表以树状结构展示层级数据——从叶子节点到分支顶部。叶子节点由系列数据点定义，每一级嵌套的分组由相应的类别定义。Aspose.Slides for Python via .NET 允许你在 Python 中格式化 Sunburst 图表和 Treemap 的数据点。

下面是一个 Sunburst 图表，Series1 列的数据定义叶子节点，其余列定义层级数据点：

![Sunburst 图表示例](sunburst_example.png)

让我们先向演示文稿中添加一个新的 Sunburst 图表：
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```


{{% alert color="primary" title="另请参阅" %}}
- [**创建 Sunburst 图表**](/slides/zh/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

如果需要格式化图表数据点，请使用以下 API：

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)，[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)，以及 [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) 属性。它们提供对 Treemap 和 Sunburst 图表中数据点的格式化访问。[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) 用于访问多层级类别；它表示一个包含 [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) 对象的容器。本质上它是 [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) 的包装器，并添加了特定于数据点的属性。[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) 类型暴露两个属性——[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) 和 [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/)——用于访问相应的设置。

## **显示数据点值**

本节展示如何在 Treemap 和 Sunburst 图表中显示单个数据点的值。你将看到如何为选定的点启用数值标签。

显示 “Leaf 4” 数据点的值：
```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```


![数据点值](data_point_value.png)

## **设置数据点的标签和颜色**

本节展示如何为 Treemap 和 Sunburst 图表中的单个数据点设置自定义标签和颜色。你将学习如何访问特定数据点、分配标签并应用实色填充以突出重要节点。

将 “Branch 1” 数据标签设置为显示系列名称（“Series1”）而不是类别名称，然后将文字颜色设为黄色：
```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```


![数据点的标签和颜色](data_point_color.png)

## **设置数据点的分支颜色**

使用分支颜色可以控制父子节点在 Treemap 和 Sunburst 图表中的视觉分组方式。本节展示如何为特定数据点设置自定义分支颜色，从而突出重要子树并提升图表可读性。

更改 “Stem 4” 分支的颜色：
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```


![分支颜色](branch_color.png)

## **常见问题**

**我能改变 Sunburst/Treemap 中各段的顺序（排序）吗？**

不能。PowerPoint 会自动对段进行排序（通常按降序、顺时针）。Aspose.Slides 复制了这一行为：无法直接更改顺序，只能通过预处理数据来实现。

**演示文稿的主题如何影响段和标签的颜色？**

图表颜色会继承演示文稿的 [theme/palette](/slides/zh/python-net/presentation-theme/)，除非你显式设置填充或字体。为获得一致的效果，请在所需层级上锁定实色填充和文字格式。

**导出为 PDF/PNG 时会保留自定义的分支颜色和标签设置吗？**

会。导出演示文稿时，图表的设置（填充、标签）会在输出格式中保留，因为 Aspose.Slides 在渲染时会应用图表的格式。

**我能计算标签/元素的实际坐标，以在图表上方放置自定义覆盖吗？**

可以。在图表布局验证后，`actual_x`/`actual_y` 会对元素可用（例如对 [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)），这有助于精确定位覆盖层。