---
title: 使用 Python 对演示文稿中的图表进行格式化
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
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过 Aspose.Slides for Python via .NET 学习图表格式化，并使用专业、醒目的样式提升您的 PowerPoint 或 OpenDocument 演示文稿。"
---

## **概述**

本指南展示了如何使用 Aspose.Slides for Python 对 PowerPoint 图表进行格式化。它逐步讲解了对核心图表实体——如类别轴和数值轴、网格线、标签、标题、图例以及次要轴——的自定义，并演示了如何通过简洁、可运行的代码示例控制字体、数字格式、填充、轮廓、绘图区和背墙颜色，以及圆角图表的设置。通过遵循这些步骤示例，您将创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)，添加并配置图表，并以 PPTX 格式保存结果，同时应用精确的视觉和排版设置。

## **格式化图表元素**

Aspose.Slides for Python 允许开发者从头向幻灯片添加自定义图表。本节说明如何格式化各种图表元素，包括类别轴和数值轴。

Aspose.Slides 提供了简洁的 API 来管理图表元素并应用自定义格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 使用所需类型的默认数据添加图表（本例中为 `ChartType.LINE_WITH_MARKERS`）。  
1. 访问图表的数值轴并设置以下内容：  
   1. 为数值轴主网格线设置 **线条格式**。  
   1. 为数值轴次网格线设置 **线条格式**。  
   1. 为数值轴设置 **数字格式**。  
   1. 为数值轴设置 **最小值、最大值、主单位和次单位**。  
   1. 为数值轴标签设置 **文本属性**。  
   1. 为数值轴设置 **标题**。  
   1. 为数值轴设置 **线条格式**。  
1. 访问图表的类别轴并设置以下内容：  
   1. 为类别轴主网格线设置 **线条格式**。  
   1. 为类别轴次网格线设置 **线条格式**。  
   1. 为类别轴标签设置 **文本属性**。  
   1. 为类别轴设置 **标题**。  
   1. 为类别轴设置 **标签定位**。  
   1. 为类别轴标签设置 **旋转角度**。  
1. 访问图表图例并设置其 **文本属性**。  
1. 显示图表图例且不与图表重叠。  
1. 访问图表的 **次要数值轴** 并设置以下内容：  
   1. 启用次要 **数值轴**。  
   1. 为次要数值轴设置 **线条格式**。  
   1. 为次要数值轴设置 **数字格式**。  
   1. 为次要数值轴设置 **最小值、最大值、主单位和次单位**。  
1. 将第一个图表系列绘制在次要数值轴上。  
1. 设置图表背墙填充颜色。  
1. 设置图表绘图区填充颜色。  
1. 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation 类。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加示例图表。
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # 设置图表标题。
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # 为数值轴设置主网格线格式。
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # 为数值轴设置次网格线格式。
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # 设置数值轴数字格式。
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # 设置数值轴最大值、最小值、主单位和次单位。
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # 设置数值轴文本属性。
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # 设置数值轴标题。
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # 为类别轴设置主网格线格式。
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # 为类别轴设置次网格线格式。
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # 设置类别轴文本属性。
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # 设置类别轴标题。
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # 设置类别轴标签位置。
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # 设置类别轴标签旋转角度。
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # 设置图例文本属性。
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # 显示图表图例且不覆盖图表。
    chart.legend.overlay = True
                
    # 设置图表背墙颜色。
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # 设置绘图区颜色。
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # 保存演示文稿。
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **设置图表字体属性**

Aspose.Slides for Python 支持为图表设置与字体相关的属性。请按照以下步骤配置图表字体属性：

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象。  
1. 向幻灯片添加图表。  
1. 设置字体高度。  
1. 保存修改后的演示文稿。

下面提供了示例代码。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **设置数字格式**

Aspose.Slides for Python 提供了简易的 API 来管理图表数据格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加带有默认数据的任意类型图表。  
1. 从可用的预设值中设置预设数字格式。  
1. 遍历每个系列的图表数据单元格并设置数字格式。  
1. 保存演示文稿。  
1. 设置自定义数字格式。  
1. 再次遍历每个系列的图表数据单元格并设置不同的数字格式。  
1. 保存演示文稿。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation() as presentation:
    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加默认的簇状柱形图。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # 设置预设数字格式。
    # 遍历每个图表系列。
    for series in chart.chart_data.series:
        # 遍历系列中的每个数据点。
        for cell in series.data_points:
            # 设置数字格式。
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # 保存演示文稿。
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

可用的预设数字格式及其对应索引如下所示。

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **为图表区域设置圆角边框**

Aspose.Slides for Python 支持通过 `Chart.has_rounded_corners` 属性配置图表区域的圆角。

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 对象。  
2. 向幻灯片添加图表。  
3. 设置图表的填充类型和填充颜色。  
4. 将圆角属性设为 `True`。  
5. 保存修改后的演示文稿。

以下提供了示例代码。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我可以为柱形/区域设置半透明填充，同时保持边框不透明吗？**

可以。填充透明度与轮廓是分开配置的。这有助于在数据密集的可视化中提升网格和数据的可读性。

**当数据标签重叠时该怎么办？**

可降低字体大小，禁用非必要的标签组件（例如类别），设置标签偏移/位置，必要时仅为选定的数据点显示标签，或改为 “数值 + 图例” 的格式。

**我可以为系列应用渐变或图案填充吗？**

可以。通常同时提供纯色、渐变和图案填充。实际使用时请适度使用渐变，并避免与网格和文字形成对比度不足的组合。