---
title: 使用 Python 在演示文稿中自定义图表图例
linktitle: 图表图例
type: docs
url: /zh/python-net/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 自定义图表图例，以针对性图例格式优化 PowerPoint 演示文稿。"
---
## **概述**

Aspose.Slides for Python via .NET 提供在 PowerPoint 演示文稿中自定义图表图例的选项。本指南展示如何定位和设置图例的大小、为整个图例设置字体大小、为单个图例条目设置格式，以及隐藏或恢复选定的条目。

FAQ 包括相关行为的说明，包括为图例预留空间、显示多行标签以及从演示文稿主题继承格式。

## **图例定位**

使用图例的 [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/)、[y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/)、[width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) 和 [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) 属性，以图表尺寸的百分比指定其位置和大小。

本示例创建一个演示文稿并在第一张幻灯片添加一个带默认数据的簇状柱形图。将所需的图例偏移量和尺寸除以图表的宽度和高度即可转换为相对值：图例相对于图表左上角偏移 50 点，并且大小为 100 × 100 点。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # 将图例的位置和大小相对于图表进行设置。
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **设置图例的字体大小**

使用图例的 [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) 访问其文本格式，并在 points 中设置 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)。

本示例创建一个带默认数据的图表并将图例文本设置为 20 点。它还禁用了垂直轴的自动边界，并将其范围设为 -5 到 10。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **设置单个图例条目的字体大小**

使用图例的 [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) 集合访问特定条目的格式。条目索引从零开始，因此索引 `1` 指第二个条目。

本示例创建一个默认数据包含至少两个系列的簇状柱形图。它将第二个图例条目格式化为加粗、斜体、20 点的蓝色文本。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **隐藏单个图例条目**

为了在保持数据可见的情况下从图例中排除辅助系列，请通过 [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/) 将 [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) 设置为 `True`。这仅隐藏所选的图例条目；并不会删除系列或其数据点。相反，将 [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) 设置为 `False` 会隐藏整个图例。

下面的示例创建一个使用默认数据的多个系列的簇状柱形图。它隐藏第二个系列的图例条目（索引 `1`），并保存演示文稿。随后通过将 [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) 设置为 `False` 恢复该条目，并保存第二个副本。两文件中的柱形均保持可见。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # 恢复相同的条目而不更改图表数据。
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

比较显示全部图例条目和隐藏第二系列图例条目的图表；所有柱形保持可见。

![比较显示全部图例条目和隐藏第二系列图例条目的图表；所有柱形保持可见。](hide-legend-entry.png)

在柱形图、条形图和折线图中，图例条目标识系列。对于饼图，它们标识单个数据点（切片），因此请对所选切片使用 [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/)。API 为 `PIE`、`PIE3D`、`EXPLODED_PIE`、`EXPLODED_PIE3D`、`PIE_OF_PIE` 和 `BAR_OF_PIE` 图表类型记录了此数据点属性。不要假设它适用于环形图，因为环形图不在该列表中。

## **常见问题**

**我可以让图表为图例预留空间而不是覆盖它吗？**

是的。将 [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) 设置为 `False`，即可为图例预留空间，而不是让它覆盖绘图区域。

**我可以创建多行图例标签吗？**

可以。当可用宽度不足时，长标签会自动换行。您也可以在系列名称中使用换行符来强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

保持图例的颜色、填充和字体未设置状态，使其能够继承主题格式。显式的格式设置会覆盖相应的主题设置。