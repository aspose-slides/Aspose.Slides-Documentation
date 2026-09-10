---
title: 使用 Python 管理簡報圖表的呼叫線
linktitle: 呼叫線
type: docs
url: /zh-hant/python-java/callout/
keywords:
- 圖表 呼叫線
- 使用 呼叫線
- 資料 標籤
- 標籤 格式
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中建立與樣式化呼叫線，提供簡潔的程式碼範例，支援 PPT 與 PPTX，以自動化簡報工作流程。"
---
## **概述**

本文說明了如何在 Aspose.Slides 中使用圖表資料標籤的呼叫線。它展示了如何使用 [setShowLabelAsDataCallout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) 方法將標籤顯示為呼叫線，如何為環形圖設定與呼叫線相關的標籤設定，以及指出在將簡報匯出為 PDF、HTML5、SVG 和點陣圖像格式時，呼叫線及其外觀會被保留。

## **使用呼叫線**

[DataLabelFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/) 類別的 [getShowLabelAsDataCallout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) 與 [setShowLabelAsDataCallout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) 方法決定圖表資料標籤是以呼叫線還是普通資料標籤顯示。

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

## **為環形圖設定呼叫線**

Aspose.Slides for Python via Java 支援為環形圖設定系列資料標籤的呼叫線形狀。以下範例示範了此功能。

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

## **常見問答**

**將簡報轉換為 PDF、HTML5、SVG 或圖像時，呼叫線會被保留嗎？**

是。呼叫線是圖表渲染的一部份，因此當您匯出至 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh-hant/python-java/export-to-html5/)、[SVG](/slides/zh-hant/python-java/render-a-slide-as-an-svg-image/) 或 [raster images](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 時，它們會與投影片的格式一併保留。

**自訂字型在呼叫線中能使用嗎？在匯出時其外觀能被保留嗎？**

是。Aspose.Slides 支援將[嵌入字型](/slides/zh-hant/python-java/embedded-font/)加入簡報，並在如 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/) 等匯出過程中控制字型嵌入，確保呼叫線在不同系統上顯示一致。