---
title: 在 Python 中管理簡報的圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/python-java/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 系列名稱
- 資料點
- 工作簿儲存格
- 系列間隙
- 負值
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度與負值。"
---
## **概述**

圖表將其繪製的資料存儲在圖表資料工作簿中。[ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) 代表一組相關值，系列中的每個 [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) 參照一個或多個工作簿儲存格。[ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別和點值會連結至 [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) 物件，而不僅僅是以顯示文字儲存。

對於典型的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，其餘儲存格則用於系列值。傳遞給 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、列與欄索引皆為零基礎。此排版在建立使用預設資料的圖表時很有用，但不要假設每個已存在的圖表皆採用此配置。對於已載入的簡報，請在變更工作簿值之前先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，如 [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)，提供單一系列中所有點的預設外觀。
- 資料點層級設定，如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)，會覆寫該點所在系列的外觀。
- 群組設定套用於屬於同一個 [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) 的相容系列。當需要設定重疊或間隙寬度等選項時，請透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。

當未明確設定點或系列的填色時，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) 回報 2D 圖表中條形或柱形的重疊程度，範圍為 -100 至 100%。它是父系列群組設定的唯讀投影。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新該群組中所有相容系列。此選項適用於顯示分組條形或柱形的圖表類型；不會影響組合圖中不相關的系列群組。

以下範例設定包含第一個系列的群組的重疊：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # 新圖表包含範例系列、類別和數值。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) 設定整個系列的預設填色。如果某個點已明確設定填色，則其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) 設定會覆寫該系列的填色。

以下範例將第一個系列套用實心藍色填色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![系列顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示在圖例中。在預設建立的叢集柱形圖工作簿中，儲存格 B1 位於第 0 列第 1 欄，包含第一個系列的名稱。下列範例中的命名變數明確指出了這個結構：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

您也可以直接更新由 [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) 參照的儲存格。此方法避免假設既有圖表中具有特定的列與欄：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![系列名稱](series_name.png)

### **以多個儲存格建立具有名稱的系列**

當產品名稱與報告期間分別儲存在不同工作簿儲存格時，組合系列名稱會很有幫助。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 合併成單一系列名稱，同時讓兩個部分皆連結到其來源儲存格。

使用 [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) 取得名稱範圍，然後將該集合傳遞給 [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add)。`skipHiddenCells` 參數控制是否包含隱藏儲存格：`True` 會排除，`False` 會包含。此範例使用 `False` 以包含名稱範圍內的所有儲存格。

以下範例建立一個包含一個系列與兩個資料點的簡報。B1:C1 提供唯一的系列名稱；A2:A3 提供類別標籤；B2:B3 提供數值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # 這兩個儲存格提供系列名稱。
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # 獨立的儲存格提供類別和數值資料點。
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

產生的系列名稱為 `Product A 2026`，兩個儲存格值之間有一個空格。圖例會將其顯示為單一條目。下圖示範結果：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **取得自動系列填色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 會回傳根據系列索引與圖表樣式計算出的顏色。這是未明確定義系列填色時所使用的顏色。呼叫此方法僅會讀取計算出的顏色，並不會指派新的填色。

以下範例印出每個預設系列的自動顏色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

預設圖表樣式的範例輸出：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

實際顏色會依圖表樣式與佈景主題而異。

## **為圖表系列設定負值反轉填色**

對於條形、柱形與氣泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) 可以在負值時顯示不同的填色。先將常規系列填色設為實心，啟用反轉，並透過 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定負值的顏色。負數在工作簿中保持不變，僅改變其顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列儲存系列名稱，第 0 欄儲存類別名稱，第 1 欄儲存值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![反轉實心填色](inverted_solid_fill_color.png)

您也可以透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一點啟用反轉。以下範例在系列停用反轉，僅在選取的點上啟用，且為該點指定負值以便觀察效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **清除特定資料點的值**

若要使某一點變為空白但保留其他點，將其對應的工作簿儲存格設為 `None`。對於柱形圖，可透過 [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 取得繪製值。資料點仍保留在相同的類別位置，但圖表會根據空白值設定將其視為空白。

以下範例僅清除第一個系列的第二個點：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除您想移除的值所在的儲存格。若只想保留其他點，請勿呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear)，因為該方法會移除整個系列的所有資料點。

## **控制空儲存格的顯示方式**

隱藏的儲存格即使包含值，也與空儲存格屬於不同情況。若要包含或排除隱藏工作表列與欄位的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿儲存格代表遺失的資料；包含 `0` 的儲存格則代表已知的數值。呼叫 [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) 並傳入 `None` 可使儲存格變為空白。數值零即使在空白儲存格設定下仍保持為零。

使用 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，但不會將空儲存格填入零或插值。

以下獨立範例建立一個包含單一系列的折線圖，清除第 3 天的值，並以每種模式分別儲存同一圖表。此範例不需要輸入檔案。[ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) 使用第 0 工作表，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # 將第 3 天真正留空，同時保留其類別與資料點。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

每個輸出檔案在儲存前會使用對應的模式命名：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。若只需一個版本，可在儲存簡報前指定所需模式，而非迭代所有模式。

下方比較顯示三個檔案中相同的資料。第 3 天在工作簿中皆為空：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。折線圖可輕鬆比較所有三種模式。條形與柱形圖沒有連接線可跨過缺少的類別，因此 `Span` 無法產生上述的連接段落；缺少的柱形與高度為零的柱形在外觀上也可能相似。類似地，僅有標記的散佈圖亦無連接線。不要期望每種圖表類型都會產生三個明顯不同的結果；請檢查您使用的圖表類型之輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱形叢集之間的空間，表示為條形或柱形寬度的百分比。與重疊類似，它屬於父系列群組而非單一系列。對群組呼叫一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。較大的值會在叢集之間產生更多空間，較小的值則使叢集更緊密。

以下範例變更間隙寬度並僅儲存最終簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![間隙寬度](gap_width.png)

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 列舉的圖表類型皆使用圖表資料，但其系列的值結構或設定並不完全相同。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖可包含多個群組，因此透過某一系列取得的群組設定不一定會影響圖表中所有系列。

**新建立的圖表是否包含預設資料？**

是的。預設情況下，[ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) 會產生範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。亦可使用其他重載方法建立不包含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) 中的儲存格。變更被參照的儲存格會更新相對應的圖表元素。建立自訂資料時，請確保類別列與系列值列對齊，使每個點都正確繪製在預期的類別下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設為 `None`，即可保留該點的類別位置而將其設為空白。僅在需要移除該系列所有點時，才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear)。如果同時移除類別，請同步更新所有系列，使其值仍與類別集合對齊。

**空白點會如何顯示？**

結果取決於圖表類型以及透過 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 設定的值。支援的圖表可以將空白顯示為間隙、零值或連接相鄰點。請選擇與簡報中遺失資料意義相符的設定。完整範例與視覺比較請參考 [控制空儲存格的顯示方式](#control-the-display-of-empty-cells)。

**負值會如何格式化？**

對於支援的條形、柱形與氣泡系列，呼叫 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) 並設定由 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 回傳的顏色。您也可以透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一點覆寫此行為。這些方法僅影響格式，而不會改變儲存的數值。

**當系列與點同時被格式化時，哪個會生效？**

明確的資料點格式會優先於該點的系列格式。其他點仍會使用明確的系列格式，或在系列格式未定義時使用自動圖表樣式與佈景主題。群組設定（如重疊與間隙寬度）屬於佈局設定，並不會覆寫點層級的格式。

**圖表可以容納的系列數量有限制嗎？**

Aspose.Slides 本身沒有固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表可讀性都會決定實際可容納的系列數量。

**當欄位過於密集或過於稀疏時，該如何調整？**

對相應的父系列群組呼叫 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。增加數值可擴大叢集之間的間距，降低數值則使叢集更靠近。