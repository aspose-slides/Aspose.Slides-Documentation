---
title: 在 Python 中自定义演示文稿中的图表数据表
linktitle: 数据表
type: docs
url: /zh/python-net/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中自定义图表数据表的字体、边框和图例键。"
---
## **概述**

Aspose.Slides for Python via .NET 允许您显示图表的数据表并自定义其文本格式、边框和图例键。本文说明如何启用数据表、格式化文本、控制每种边框以及显示或隐藏图例键。示例将配置好的图表保存为 PPTX 文件。

## **设置字体属性**

要显示图表的数据表，将 [has_data_table](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/has_data_table/) 设置为 `True`。使用 [chart_data_table](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/chart_data_table/) 访问表并配置其文本格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类加载演示文稿。
2. 在第一张幻灯片中添加一个簇状柱形图。
3. 启用图表的数据表。
4. 使用 [font_bold](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/font_bold/) 启用粗体文本，并将 [font_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/font_height/) 设置为 `20`，以使用 20 磅的文字。
5. 保存修改后的演示文稿。

下面的示例需要工作目录中存在至少包含一张幻灯片的 `test.pptx`。它在位置 (50, 50) 添加一个默认数据的图表，宽度为 600 点，高度为 400 点。保存的 `output.pptx` 包含已启用数据表且已应用指定字体设置的图表。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **自定义数据表边框**

使用 [Chart.has_data_table](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/has_data_table/) 启用表格，并通过 [Chart.chart_data_table](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/chart_data_table/) 访问它。您可以独立控制三种边框类型：

- [has_border_horizontal](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datatable/has_border_horizontal/) 控制水平单元格边框。
- [has_border_vertical](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datatable/has_border_vertical/) 控制垂直单元格边框。
- [has_border_outline](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datatable/has_border_outline/) 控制表格的外部边框。

将每个属性设置为 `True` 以显示相应边框，或设置为 `False` 以隐藏它们。下面的示例创建一个带默认数据的簇状柱形图，显示水平边框和外边框，并隐藏垂直边框。该示例不需要输入文件。图表的位置和大小以点为单位指定。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

下图的比较在四种情况下使用相同的图表数据和图例键设置。先启用所有边框，然后每个后续变体仅关闭一种边框属性。左下角的变体与示例中的边框设置相匹配。

![所有边框已启用、无水平边框、无垂直边框、无外边框的数据表图表](data-table-borders.png)

## **显示或隐藏图例键**

图例键是数据表中系列名称旁边的小彩色标记。它们帮助读者将每行表格对应到图表系列。将 [show_legend_key](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datatable/show_legend_key/) 设置为 `True` 可显示这些标记，设置为 `False` 可隐藏它们。

图表的单独图例由 [Chart.has_legend](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/has_legend/) 控制。这些设置相互独立：隐藏单独图例不会隐藏数据表中的键，隐藏数据表中的键也不会隐藏单独图例。

下面的示例创建一个带默认数据的图表，启用其数据表，并在隐藏单独图例的同时显示其中的图例键。所有表格边框均显式启用。该示例不需要输入演示文稿。若仅隐藏表格的键，请将 `data_table.show_legend_key` 改为 `False`。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

下图的比较显示了同一表格在显示和隐藏图例键两种情况下的效果。所有边框保持启用，单独的图表图例在两种情况下均被隐藏。

![左侧显示图例键、右侧隐藏图例键的数据表图表](data-table-legend-keys.png)

## **常见问题**

**我可以在图表的数据表中显示图例键吗？**

是的。将 [show_legend_key](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/datatable/show_legend_key/) 设置为 `True` 可显示图例键，或设置为 `False` 可隐藏它们。

**在将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

是的。Aspose.Slides 在导出为 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/python-net/convert-powerpoint-to-html/) 或 [images](/slides/zh/python-net/convert-powerpoint-to-png/) 时，会将图表及其显示的数据表作为幻灯片的一部分进行渲染。

**我可以在从模板加载的图表中使用数据表吗？**

是的。对于从现有演示文稿或模板加载的图表，可使用 [has_data_table](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/has_data_table/) 检查或更改其数据表是否显示。

**我如何查找已启用数据表的图表？**

遍历每张幻灯片上的形状，识别出图表，并检查其 [has_data_table](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/has_data_table/) 属性。属性值为 `True` 表示数据表已启用。