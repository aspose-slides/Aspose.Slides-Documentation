---
title: 使用 Python 管理演示文稿图表中的标注
linktitle: 标注
type: docs
url: /zh/python-java/callout/
keywords:
- 图表标注
- 使用标注
- 数据标签
- 标签格式
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用简洁的代码示例在 Aspose.Slides for Python via Java 中创建和样式化标注，兼容 PPT 和 PPTX，帮助自动化演示文稿工作流。"
---
## **概述**

本文介绍了在 Aspose.Slides 中如何使用图表数据标签的标注。它展示了如何使用 [setShowLabelAsDataCallout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) 方法将标签显示为标注，如何为环形图配置与标注相关的标签设置，并指出在将演示文稿导出为 PDF、HTML5、SVG 和栅格图像格式时，标注及其外观都会被保留。

## **使用标注**

[DataLabelFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/) 类的 [getShowLabelAsDataCallout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) 和 [setShowLabelAsDataCallout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) 方法决定图表数据标签是以标注形式显示，还是以普通数据标签显示。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **为环形图设置标注**

Aspose.Slides for Python via Java 支持为环形图设置系列数据标签的标注形状。下面的示例演示了这一点。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**将演示文稿转换为 PDF、HTML5、SVG 或图像时，标注会被保留吗？**

是的。标注是图表渲染的一部分，因此当您导出为 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh/python-java/export-to-html5/)、[SVG](/slides/zh/python-java/render-a-slide-as-an-svg-image/)，或 [raster images](/slides/zh/python-java/convert-powerpoint-to-png/)，它们会与幻灯片的格式一起被保留。

**自定义字体在标注中是否可用，导出时其外观能否保留？**

是的。Aspose.Slides 支持将字体嵌入演示文稿，并在导出为 [PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/) 等格式时控制字体嵌入，确保标注在不同系统上保持相同的外观。