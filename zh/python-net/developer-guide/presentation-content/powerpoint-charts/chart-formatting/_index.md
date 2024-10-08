---
title: 图表格式
type: docs
weight: 60
url: /zh/python-net/chart-formatting/
keywords: "图表实体, 图表属性, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中格式化PowerPoint演示文稿中的图表实体"
---

## **格式化图表实体**
Aspose.Slides for Python via .NET 让开发人员能够从头开始向幻灯片添加自定义图表。本文解释了如何格式化不同的图表实体，包括图表类别和数值轴。

Aspose.Slides for Python via .NET 提供了一个简单的API，用于管理不同的图表实体并使用自定义值对其进行格式化：

1. 创建一个 **Presentation** 类的实例。
1. 根据索引获取幻灯片的引用。
1. 添加一个具有默认数据的图表以及所需的类型（在此示例中我们将使用 ChartType.LineWithMarkers）。
1. 访问图表的数值轴并设置以下属性：
   1. 为数值轴主要网格线设置 **线条格式**
   1. 为数值轴次要网格线设置 **线条格式**
   1. 为数值轴设置 **数字格式**
   1. 为数值轴设置 **最小值, 最大值, 主要单位和次要单位**
   1. 为数值轴数据设置 **文本属性**
   1. 为数值轴设置 **标题**
   1. 为数值轴设置 **线条格式**
1. 访问图表的类别轴并设置以下属性：
   1. 为类别轴主要网格线设置 **线条格式**
   1. 为类别轴次要网格线设置 **线条格式**
   1. 为类别轴数据设置 **文本属性**
   1. 为类别轴设置 **标题**
   1. 为类别轴设置 **标签定位**
   1. 为类别轴标签设置 **旋转角度**
1. 访问图表的图例并为其设置 **文本属性**
1. 设置图表图例显示，无重叠图表
1. 访问图表的 **次要数值轴** 并设置以下属性：
   1. 启用次要 **数值轴**
   1. 为次要数值轴设置 **线条格式**
   1. 为次要数值轴设置 **数字格式**
   1. 为次要数值轴设置 **最小值, 最大值, 主要单位和次要单位**
1. 现在在次要数值轴上绘制第一个图表系列
1. 设置图表的后墙填充颜色
1. 设置图表绘图区域填充颜色
1. 将修改后的演示文稿写入PPTX文件

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化演示文稿
with slides.Presentation() as pres:

    # 访问第一张幻灯片
    slide = pres.slides[0]

    # 添加示例图表
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # 设置图表标题
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chartTitle = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chartTitle.text = "示例图表"
    chartTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chartTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chartTitle.portion_format.font_height = 20
    chartTitle.portion_format.font_bold = 1
    chartTitle.portion_format.font_italic = 1

    # 为数值轴设置主要网格线格式
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # 为数值轴设置次要网格线格式
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # 设置数值轴数字格式
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # 设置图表最大、最小值
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # 设置数值轴文本属性
    txtVal = chart.axes.vertical_axis.text_format.portion_format
    txtVal.font_bold = 1
    txtVal.font_height = 16
    txtVal.font_italic = 1
    txtVal.fill_format.fill_type = slides.FillType.SOLID 
    txtVal.fill_format.solid_fill_color.color = draw.Color.dark_green
    txtVal.latin_font = slides.FontData("Times New Roman")

    # 设置数值轴标题
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    valtitle = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    valtitle.text = "主轴"
    valtitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    valtitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    valtitle.portion_format.font_height = 20
    valtitle.portion_format.font_bold = 1
    valtitle.portion_format.font_italic = 1

    # 为类别轴设置主要网格线格式
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # 为类别轴设置次要网格线格式
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # 设置类别轴文本属性
    txtCat = chart.axes.horizontal_axis.text_format.portion_format
    txtCat.font_bold = 1
    txtCat.font_height = 16
    txtCat.font_italic = 1
    txtCat.fill_format.fill_type = slides.FillType.SOLID 
    txtCat.fill_format.solid_fill_color.color = draw.Color.blue
    txtCat.latin_font = slides.FontData("Arial")

    # 设置类别标题
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    catTitle = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    catTitle.text = "示例类别"
    catTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    catTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    catTitle.portion_format.font_height = 20
    catTitle.portion_format.font_bold = 1
    catTitle.portion_format.font_italic = 1

    # 设置类别轴标签位置
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # 设置类别轴标签旋转角度
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # 设置图例文本属性
    txtleg = chart.legend.text_format.portion_format
    txtleg.font_bold = 1
    txtleg.font_height = 16
    txtleg.font_italic = 1
    txtleg.fill_format.fill_type = slides.FillType.SOLID 
    txtleg.fill_format.solid_fill_color.color = draw.Color.dark_red

    # 设置图表图例显示，无重叠图表

    chart.legend.overlay = True
                
    # 设置图表后墙颜色
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red
    # 设置绘图区域颜色
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # 保存演示文稿
    pres.save("FormattedChart_out.pptx", slides.export.SaveFormat.PPTX)
```



## **设置图表的字体属性**
Aspose.Slides for Python via .NET 支持为图表设置与字体相关的属性。请按照以下步骤设置图表的字体属性。

- 实例化 Presentation 类对象。
- 在幻灯片上添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

下面是一个示例。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    pres.save("FontPropertiesForChart.pptx", slides.export.SaveFormat.PPTX)
```




## **设置数字格式**
Aspose.Slides for Python via .NET 提供了一个简单的API，用于管理图表数据格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 根据索引获取幻灯片的引用。
1. 添加一个具有默认数据的图表以及所需的类型（该示例使用 **ChartType.ClusteredColumn**）。
1. 从可用的预设值中设置预设数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置图表数据的数字格式。
1. 保存演示文稿。
1. 设置自定义数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置不同的图表数据数字格式。
1. 保存演示文稿。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 实例化演示文稿
with slides.Presentation() as pres:
    # 访问第一张演示文稿幻灯片
    slide = pres.slides[0]

    # 添加默认的聚类柱形图
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # 访问图表系列集合
    series = chart.chart_data.series

    # 设置预设数字格式
    # 遍历每个图表系列
    for ser in series:
        # 遍历系列中的每个数据单元格
        for cell in ser.data_points:
            # 设置数字格式
            cell.value.as_cell.preset_number_format = 10 #0.00%

    # 保存演示文稿
    pres.save("PresetNumberFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

可以使用的预设数字格式值及其预设索引如下所示：

|**0**|一般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;红色$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;红色$-#,##0.00|
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
|**38**|#,##0;红色-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;红色-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **设置图表区域的圆角边框**
Aspose.Slides for Python via .NET 提供对设置图表区域的支持。**IChart.HasRoundedCorners** 和 **Chart.HasRoundedCorners** 属性已在Aspose.Slides中添加。

1. 实例化 `Presentation` 类对象。
1. 在幻灯片上添加图表。
1. 设置图表的填充类型和填充颜色
1. 将圆角属性设置为True。
1. 保存修改后的演示文稿。

以下是一个示例：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("out.pptx", slides.export.SaveFormat.PPTX)
```