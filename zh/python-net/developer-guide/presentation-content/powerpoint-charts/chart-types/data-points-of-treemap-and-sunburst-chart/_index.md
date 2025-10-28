---
title: 在 Python 中自定义树形图和旭日图的数据点
linktitle: 树形图和旭日图中的数据点
type: docs
url: /zh/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- 树形图
- 旭日图
- 数据点
- 标签颜色
- 分支颜色
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 格式中管理树形图和旭日图的数据点。"
---

## **简介**

在其他 PowerPoint 图表类型中，有两种层次结构图表——**Treemap** 和 **Sunburst**（也称为 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi-Level Pie Chart）。这些图表以树形结构展示层次化数据——从叶子节点到分支顶部。叶子节点由系列数据点定义，每个后续的嵌套分组层级由相应的类别定义。Aspose.Slides for Python via .NET 使您能够在 Python 中格式化旭日图和树形图的数据点。

以下是一个旭日图示例，其中 Series1 列的数据定义了叶子节点，其余列定义了层次化数据点：

![旭日图示例](sunburst_example.png)

让我们从向演示文稿添加一个新的旭日图开始：

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="另请参见" %}}
- [**创建旭日图**](/slides/zh/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

如果您需要格式化图表的数据点，请使用以下 API：

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)、[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) 和 [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) 属性。它们提供对树形图和旭日图中数据点的格式化访问。[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) 用于访问多级类别；它代表一个包含 [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) 对象的容器。本质上它是对 [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) 的包装，并具备针对数据点的额外属性。[ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) 类型公开两个属性——[format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) 和 [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/)——用于访问相应的设置。

## **显示数据点值**

本节展示如何在树形图和旭日图中显示单个数据点的数值。您将看到如何为选定的点启用数值标签。

显示 “Leaf 4” 数据点的值：

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![数据点数值](data_point_value.png)

## **为数据点设置标签和颜色**

本节展示如何为树形图和旭日图中的单个数据点设置自定义标签和颜色。您将学习如何访问特定数据点、分配标签以及应用实心填充以突出重要节点。

将 “Branch 1” 数据标签设置为显示系列名称 (“Series1”) 而不是类别名称，然后将文本颜色设为黄色：

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![数据点的标签和颜色](data_point_color.png)

## **为数据点设置分支颜色**

使用分支颜色可以控制树形图和旭日图中父子节点的视觉分组方式。本节展示如何为特定数据点设置自定义分支颜色，以突出重要子树并提升图表可读性。

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

**我可以更改旭日图/树形图中段的顺序（排序）吗？**

不能。PowerPoint 会自动对段进行排序（通常按降序值、顺时针方向）。Aspose.Slides 体现了相同的行为：无法直接更改顺序；只能通过预处理数据实现。

**演示文稿主题如何影响段和标签的颜色？**

图表颜色会继承演示文稿的[主题/调色板](/slides/zh/python-net/presentation-theme/)，除非您明确设置填充或字体。为获得一致效果，请在所需层级锁定实心填充和文本格式。

**导出为 PDF/PNG 时会保留自定义分支颜色和标签设置吗？**

会。导出演示文稿时，图表的设置（填充、标签）会在输出格式中保留，因为 Aspose.Slides 会使用已应用的图表格式进行渲染。

**我可以计算标签/元素的实际坐标，以便在图表上方进行自定义覆盖吗？**

可以。在图表布局验证后，`actual_x`/`actual_y` 可用于元素（例如[DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)），这有助于精确定位覆盖物。