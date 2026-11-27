---
title: 使用 Python 在演示文稿中格式化图表
linktitle: 图表格式化
type: docs
weight: 60
url: /zh/python-net/chart-formatting/
keywords:
- 格式化图表
- 图表格式化
- 图表实体
- 图表属性
- 图表设置
- 图表选项
- 字体属性
- 圆角边框
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解在 Aspose.Slides for Python via .NET 中的图表格式化，并通过自定义坐标轴、字体、数字格式和圆角图表边框提升您的 PowerPoint 演示文稿。"
---
## **概述**

本文解释如何使用 Aspose.Slides 在 PowerPoint 演示文稿中格式化图表。它展示了如何自定义关键图表元素，如坐标轴、网格线、标题、图例、绘图区域和墙面填充，以改进图表数据的外观和可读性。

它还演示了如何为图表文本设置字体属性、对图表数据应用预设数值格式，以及为图表区域启用圆角。通过这些示例，您可以控制演示文稿中图表的视觉样式和数据呈现方式。

有关上升和下降区间的独立填充和轮廓，请参阅[股票图表示例](/slides/zh/python-net/create-chart/#create-stock-charts)。

## **格式化图表实体**

使用[Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)来格式化图表标题、坐标轴、网格线、图例和绘图区域。此示例创建了一个带标记和默认数据的折线图，然后为其值轴和类别轴分别应用文本和线条样式。字体大小和线宽以磅为单位指定；类别标签旋转 45 度。

值轴使用[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)，独立于源单元格。其刻度范围为 -2 到 15，主间隔为 2，次间隔为 0.5。示例还将百分比格式与[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/)（设为千位）结合使用，请根据数据的含义和数量级进行相应调整。由于[overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/)被禁用，图例位于绘图区域之外。通过[back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/)和[floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/)配置背墙和地板填充，但这些表面仅在 3D 图表中可见。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **为图表设置字体属性**

通过[Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/)设置图表文本的默认字体大小。示例创建了一个簇状柱形图，使用 20 磅字体，并通过[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/)为第一系列启用数值标签。具有独立显式字体设置的文本元素可以覆盖图表默认设置。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **为图表图例复用文本框格式**

为了使图例与幻灯片标题匹配，在标题的第一个段落上通过[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)设置字体。对图例的[text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/)调用[copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/)，它会复制文本框设置、首段的格式以及该段的默认字体属性。直接应用于单独部分或后续段落的格式保持局部有效。

示例使用粗体、海军蓝、26 磅 Calibri 作为模板标题。对图例进行样式设置后，使用[copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/)将相同的格式应用于单独的说明文字。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

在保存的演示文稿中，图例和说明文字在大小、粗细和颜色上都与标题保持一致。图例仍显示系列名称，说明文字保留其自身文本。如果说明文字中的某个部分已经具有显式字体大小，则该大小优先于复制的段落默认值。

| 复制前 | 复制后 |
| --- | --- |
| ![季度销售图，带有常规黑色图例标签和黑色说明文字](legend-formatting-before.png) | ![相同的图表，带有更大、粗体海军蓝图例标签和匹配的说明文字](legend-formatting.png) |

## **设置数值格式**

使用[ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/)将内置数值格式应用于图表工作簿单元格。此示例创建了一个默认、基于单元格的数据的簇状柱形图，并对每个系列的值单元格应用格式索引 10 (`0.00%`)。这会改变工作簿中值的显示方式，而不改变底层数值；例如，0.25 将显示为 25.00%。坐标轴和数据标签的格式可以分别配置。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

下表列出了内置数值格式索引及其在美国英语区域的典型 Excel 格式。确切的格式字符串及其显示方式可能因应用程序和区域设置而异，尤其是货币和日期。一些 Excel 格式也与 OOXML 标准的默认值不同，详见[Microsoft 的数值格式实现说明](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)。

| 索引 | 格式 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **设置图表区域圆角边框**

启用[Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/)可将图表区域的角设为圆角。示例创建了一个簇状柱形图，并使用[line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/)将其轮廓设为实心灰色并采用单线样式，然后保存演示文稿。

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **编辑现有图表注释**

图表可以包含自定义形状，例如说明报告状态的文本注释。通过[Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/)访问这些形状。其[shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)集合包含图表拥有的形状。

放置在图表上方的普通文本框属于幻灯片，即使它看起来像图表的一部分。遍历[Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/)可以找到图表以及普通幻灯片形状，但不会枚举图表内部的各个形状。图表标题和数据标签是独立的图表元素，而不是此集合中的自定义注释。

下载[chart-annotations.pptx](chart-annotations.pptx)并将其放置在应用程序的工作目录中。其第一张幻灯片包含一个带有未分组注释“Preliminary results”、图表拥有的线条以及一个普通幻灯片文本框“Slide overlay”的图表。示例在该幻灯片上找到第一张图表，并在报告准备发布时将注释更改为“Final results”。它会检查集合是否为空，并仅编辑具有非 `None` 且包含预期文本的[text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/)的[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

线条和幻灯片文本框保持不变。以下图片展示了输入和保存后重新打开的结果：

| 编辑前 | 编辑后 |
| --- | --- |
| ![图表注释为 “Preliminary results”](chart-annotations-before.png) | ![图表注释为 “Final results”](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
示例仅检查顶层的图表拥有形状。如果注释位于[GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/)内部，需要同样检查该组的[shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)集合。对嵌套组递归执行此操作，对其子形状应用相同的文本检查。组本身是容器，不要将其视为文本框。
{{% /alert %}}

## **常见问题**

**我可以为柱形/区域设置半透明填充，同时保持边框不透明吗？**

是的。填充透明度和轮廓是分开配置的。这对于在密集可视化中提高网格和数据的可读性非常有用。

**当数据标签重叠时该怎么办？**

减小字体大小、禁用非必要的标签组件（例如类别）、调整标签位置、必要时仅为选定数据点显示标签，或将格式切换为“值 + 图例”。

**我可以对系列应用渐变或图案填充吗？**

可以。系列支持纯色、渐变和图案填充。实际使用时请适度使用渐变，并避免与网格和文本形成对比度低的组合。