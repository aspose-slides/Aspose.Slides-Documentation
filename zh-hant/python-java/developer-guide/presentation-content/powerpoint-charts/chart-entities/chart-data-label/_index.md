---
title: 管理簡報中的圖表資料標籤（使用 Python）
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
description: "學習如何在 PowerPoint 簡報中使用 Aspose.Slides for Python via Java 加入並格式化圖表資料標籤，打造更具吸引力的投影片。"
---
## **簡介**

資料標籤會顯示圖表系列與個別資料點的資訊，協助讀者辨識數值並了解圖表。本篇說明如何格式化數值、顯示百分比、讀取標籤文字、調整類別軸標籤間距，以及設定圓餅圖標籤的位置。

## **設定圖表資料標籤的數值精度**

使用[setNumberFormatOfValues](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#setNumberFormatOfValues)來格式化系列值。此範例建立一個使用預設資料的折線圖，顯示其資料表，並為第一個系列啟用值標籤。格式 `#,##0.00` 會顯示千分位分隔符與兩位小數，卻不會改變底層的數值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **將百分比顯示為標籤**

對於堆疊直條圖，將每個值計算為其類別總和的百分比，並將文字指派給[ getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) 回傳的文字框。此範例使用預設圖表資料，並以 8 點字型顯示兩位小數的百分比。當類別總和為零時會跳過，以避免除以零。若圖表資料變更，請重新計算自訂標籤文字。

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
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **使用圖表資料標籤設定百分比符號**

當數值以分數方式儲存時，使用[setNumberFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#setNumberFormat)來顯示百分比。將`False`傳遞給[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource)以使標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊直條圖，四個類別各有紅色與藍色系列。每對數值加總為 1。標籤格式 `0.0%` 會將 0.30 顯示為 30.0%，而縱軸使用兩位小數。兩個系列皆使用白色、10 點的標籤文字。

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
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **讀取資料標籤的實際文字**

使用[getActualLabelText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#getActualLabelText)取得資料標籤設定產生的文字。此功能在擷取標籤以製作報表、搜尋簡報內容或驗證產生的圖表時很有用。在下例中，預設的[資料標籤格式](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/)會結合每個類別名稱、系列名稱與數值。某一點將其數值格式化為百分比，另一點則使用[ getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) 取得的自訂文字。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

即使標籤顯示 `75%` 並附加類別與系列名稱，資料點中儲存的數值仍為 `0.75`。自訂文字會取代產生的標籤文字。無論哪種情況，[getActualLabelText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#getActualLabelText) 都會回傳最終的標籤字串。若只想擷取可見標籤，請如上例分別檢查[isVisible](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#isVisible)。

## **設定標籤與軸的距離**

使用[setLabelOffset](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#setLabelOffset)控制類別軸標籤與軸之間的距離。此值是軸標籤最大字型大小的百分比。此範例建立一個群組直條圖，並將水平軸標籤偏移設定為 500。此設定會影響類別軸標籤，而非附加於單一資料點的標籤。

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

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **調整標籤位置**

在圓餅圖上，調整資料標籤的位置以改善間距並為引線留出空間。

此範例顯示第一個資料點的數值，將其標籤放置於切片外側，並使用[setX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#setX)與[setY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#setY)調整水平與垂直偏移。這些偏移量分別相對於圖表的寬度與高度。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![調整過資料標籤位置的圓餅圖](pie-chart-adjusted-label.png)

## **常見問題**

**如何防止資料標籤在密集圖表中重疊？**

結合自動標籤排列、引線與縮小字型大小；必要時可隱藏某些欄位（例如類別），或僅為極端值或關鍵點顯示標籤。

**如何僅對零值、負值或空值停用標籤？**

在啟用標籤前先篩選資料點，並依設定的規則關閉對 0、負值或遺漏值的顯示。

**如何確保匯出為 PDF/影像時標籤樣式一致？**

明確設定字型族與字型大小，並確認渲染環境中已安裝該字型，以避免使用備用字型。