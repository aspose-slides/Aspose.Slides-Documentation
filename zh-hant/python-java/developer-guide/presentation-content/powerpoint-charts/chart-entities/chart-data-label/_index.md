---
title: 使用 Python 在簡報中管理圖表資料標籤
linktitle: 資料標籤
type: docs
url: /zh-hant/python-java/chart-data-label/
keywords:
- 圖表
- 資料標籤
- 資料精度
- 百分比
- 標籤距離
- 標籤位置
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中新增與格式化圖表資料標籤，打造更具吸引力的投影片。"
---
## **簡介**

圖表上的資料標籤會顯示圖表資料系列或個別資料點的詳細資訊。它們讓讀者能快速辨識資料系列，並使圖表更易於理解。

## **設定圖表資料標籤的資料精度**

以下 Python 程式碼示範如何在圖表資料標籤中設定資料精度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **以百分比作為標籤顯示**
Aspose.Slides for Python via Java 允許您在顯示的圖表上設定百分比標籤。以下 Python 程式碼示範此操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)
    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在圖表資料標籤中設定百分比符號**
以下 Python 程式碼示範如何為圖表資料標籤設定百分比符號：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")
    chart.getChartData().getSeries().clear()
    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # 新增紅色系列。
    series_cell = workbook.getCell(worksheet_index, 0, 1, "Reds")
    red_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.30, 0.50, 0.80, 0.65], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 1, jpype.JDouble(value))
        red_series.getDataPoints().addDataPointForBarSeries(data_cell)

    red_series.getFormat().getFill().setFillType(FillType.Solid)
    red_series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    red_label_format = red_series.getLabels().getDefaultDataLabelFormat()
    red_label_format.setShowValue(True)
    red_label_format.setNumberFormatLinkedToSource(False)
    red_label_format.setNumberFormat("0.0%")
    red_portion_format = red_label_format.getTextFormat().getPortionFormat()
    red_portion_format.setFontHeight(10)
    red_portion_format.getFillFormat().setFillType(FillType.Solid)
    red_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    # 新增藍色系列。
    series_cell = workbook.getCell(worksheet_index, 0, 2, "Blues")
    blue_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.70, 0.50, 0.20, 0.35], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 2, jpype.JDouble(value))
        blue_series.getDataPoints().addDataPointForBarSeries(data_cell)

    blue_series.getFormat().getFill().setFillType(FillType.Solid)
    blue_series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)
    blue_label_format = blue_series.getLabels().getDefaultDataLabelFormat()
    blue_label_format.setShowValue(True)
    blue_label_format.setNumberFormatLinkedToSource(False)
    blue_label_format.setNumberFormat("0.0%")
    blue_portion_format = blue_label_format.getTextFormat().getPortionFormat()
    blue_portion_format.setFontHeight(10)
    blue_portion_format.getFillFormat().setFillType(FillType.Solid)
    blue_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定標籤與座標軸的距離**
以下 Python 程式碼示範當圖表以座標軸繪製時，如何設定標籤與類別座標軸的距離：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **調整標籤位置**

當您建立不依賴任何座標軸的圖表（例如圓餅圖）時，圖表的資料標籤可能會過於靠近邊緣。此時，必須調整資料標籤的位置，使指示線能清晰顯示。

以下 Python 程式碼示範如何在圓餅圖上調整標籤位置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **常見問題**

**如何防止在密集圖表上資料標籤重疊？**

結合自動標籤放置、指示線與縮小字型；必要時可隱藏某些欄位（例如類別），或僅為極端/關鍵點顯示標籤。

**如何僅對零、負值或空值停用標籤？**

在啟用標籤之前先過濾資料點，根據定義的規則對值為 0、負值或缺失的資料點關閉顯示。

**如何在匯出為 PDF/圖像時確保標籤樣式一致？**

明確設定字型（字族、大小），並確認渲染端已安裝該字型，以避免回退。