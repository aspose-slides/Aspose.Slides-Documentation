---
title: 使用 Python 管理演示文稿图表中的标注
linktitle: 标注
type: docs
url: /zh/python-net/callout/
keywords:
- 图表 标注
- 使用 标注
- 数据 标签
- 标签 格式
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python .NET 创建和样式化标注，提供简洁的代码示例，兼容 PPT、PPTX 和 ODP，自动化演示工作流。"
---

## **使用标注**
已向 **DataLabelFormat** 类和 **IDataLabelFormat** 接口添加了新属性 **ShowLabelAsDataCallout**，该属性决定指定图表的数据标签是显示为数据标注还是显示为数据标签。在下面的示例中，我们已设置标注。
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```


## **为环形图设置标注**
Aspose.Slides for Python via .NET 提供了为环形图设置系列数据标签标注形状的支持。下面给出示例。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**将演示文稿转换为 PDF、HTML5、SVG 或图像时，标注会被保留吗？**

是的。标注是图表渲染的一部分，因此在导出为 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh/python-net/export-to-html5/)、[SVG](/slides/zh/python-net/render-a-slide-as-an-svg-image/) 或 [光栅图像](/slides/zh/python-net/convert-powerpoint-to-png/) 时，它们会与幻灯片的格式一起被保留。

**自定义字体在标注中能使用吗？导出时能保留其外观吗？**

是的。Aspose.Slides 支持将 [嵌入字体](/slides/zh/python-net/embedded-font/)嵌入到演示文稿中，并在导出（如 [PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)）时控制字体嵌入，确保标注在不同系统上保持相同的外观。