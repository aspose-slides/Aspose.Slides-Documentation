---
title: 使用 Python 管理簡報中的圖表資料標籤
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
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中新增與格式化圖表資料標籤，以打造更具吸引力的投影片。"
---
## **簡介**

資料標籤會顯示圖表系列與個別資料點的資訊，協助讀者辨識數值並了解圖表。本篇說明如何格式化數值、顯示百分比、讀取標籤文字、控制超過軸上限的標籤、調整類別軸標籤間距，以及設定圓餅圖標籤的位置。

## **在圖表資料標籤中設定數值精度**

使用[setNumberFormatOfValues](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#setNumberFormatOfValues)格式化系列值。此範例建立一個使用預設資料的折線圖，顯示資料表，並為第一個系列啟用值標籤。格式`#,##0.00`會顯示千分位分隔符與兩位小數，而不會改變底層值。

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

## **以百分比作為標籤顯示**

對於堆疊柱狀圖，將每個值計算為其類別總和的百分比，並將文字指派給[ getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#getTextFrameForOverriding)回傳的文字框。此範例使用預設圖表資料，並以 8 點字型顯示兩位小數的百分比。總和為零的類別會被略過，以避免除以零。若圖表資料變更，請重新計算自訂標籤文字。

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

## **使用圖表資料標籤設定百分號**

當值以分數儲存時，使用[setNumberFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#setNumberFormat)顯示百分比。將`False`傳遞給[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource)以使標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊柱狀圖，四個類別各有紅色與藍色系列。每對值的總和為 1。標籤格式`0.0%`會將 0.30 顯示為 30.0%，而垂直軸使用兩位小數。兩個系列皆使用白色、10 點字型的標籤文字。

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

使用[getActualLabelText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#getActualLabelText)取得資料標籤設定產生的文字。這在擷取標籤以供報告、搜尋簡報內容或驗證產生的圖表時很有用。以下範例中，預設的[data label format](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/)會結合每個類別名稱、系列名稱與值。某個點將其值格式化為百分比，另一個則使用[getTextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#getTextFrameForOverriding)回傳的自訂文字。

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

即使標籤顯示`75%`並附加類別與系列名稱，資料點中儲存的數字仍為`0.75`。自訂文字會取代產生的標籤文字。無論哪種情況，[getActualLabelText](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#getActualLabelText)都會回傳最終的標籤字串。請如上例分別檢查[isVisible](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#isVisible)，以在只需要擷取可見標籤時使用。

## **控制超過軸上限的資料標籤**

當手動限制軸範圍時，某些資料點可能會超過其最大值。使用[setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum)控制是否顯示它們的資料標籤。此設定會變更標籤可見性；不會變更軸範圍或底層資料值。

以下範例建立一個 2D 群組柱狀圖，值為 60 與 120。對垂直軸呼叫[setAutomaticMaxValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#setAutomaticMaxValue)傳 `False`，並以[setMaxValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#setMaxValue)將最大值設為 100。第一張投影片允許超過最大值的標籤顯示；複本則關閉此功能。兩張投影片皆儲存於`DataLabelsOverMaximum.pptx`。

使用[setShowValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#setShowValue)啟用值標籤。圖表層級的設定本身不會啟用值顯示，也不會覆寫個別標籤已停用的值顯示。此範例為整個系列啟用值，並使用[setPosition](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/#setPosition)將標籤放置於每個柱狀的外側端點。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下影像顯示 Microsoft PowerPoint 渲染的儲存投影片。設定為`True`時，標籤**120**會在上邊界可見；設定為`False`時則隱藏。標籤**60**仍保持可見，軸最大值仍為**100**，第二個資料點在兩種情況下皆為**120**。

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint 圖表顯示值標籤 120，軸最大值為 100](data-labels-over-maximum-true.png) | ![PowerPoint 圖表隱藏值標籤 120，軸最大值為 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此範例使用具有數值軸的 2D 柱狀圖。沒有數值軸的圖表（例如圓餅圖與環形圖）無法以此方式限制軸上限。
{{% /alert %}}

## **設定標籤與軸的距離**

使用[setLabelOffset](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/axis/#setLabelOffset)控制類別軸標籤與軸之間的距離。值為軸標籤最大字型大小的百分比。此範例建立一個群組柱狀圖，並將水平軸標籤偏移設定為 500。此設定影響類別軸標籤，而非附加於單一資料點的標籤。

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

此範例顯示第一個資料點的值，將其標籤放置於切片外側，並使用[setX](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#setX)與[setY](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabel/#setY)調整水平與垂直偏移。這些偏移分別相對於圖表寬度與高度。

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

**如何防止在密集圖表上出現資料標籤重疊？**

結合自動標籤放置、引線與縮小字型大小；必要時隱藏某些欄位（例如類別），或僅對極值或關鍵點顯示標籤。

**如何僅對零值、負值或空值停用標籤？**

在啟用標籤前先篩選資料點，並依據規則關閉 0、負值或缺失值的顯示。

**如何在匯出為 PDF／影像時保持一致的標籤樣式？**

明確設定字型系列與大小，並確保渲染環境中已安裝該字型，以避免回退。