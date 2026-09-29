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
description: "了解如何在簡報中使用 Aspose.Slides for Python via Java 管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度與負值。"
---
## **概觀**

圖表將其繪製的資料儲存在圖表資料工作簿中。 [ChartSeries](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/) 代表一組相關的值，而此系列中的每個 [ChartDataPoint](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/) 都對應到一個或多個工作簿儲存格。 [ChartCategory](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartcategory/) 物件提供系列共用的標籤或分組值。系列名稱、類別以及資料點值因此連結至 [ChartDataCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/) 物件，而非僅以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列作為系列名稱，第 0 欄作為類別名稱，其餘儲存格則放置系列值。傳遞給 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、列與欄索引皆為零基。此佈局在建立使用預設資料的圖表時很有用，但不要假設所有現有圖表皆採用此布局。對於已載入的簡報，請在變更工作簿值之前檢查系列、類別與資料點所參照的儲存格。

圖表設定有三個不同的範圍：

- 系列層級設定，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getFormat)，提供整個系列中所有點的預設外觀。
- 資料點層級設定，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getFormat)，會覆寫該點的系列外觀。
- 群組設定套用於屬於同一個 [ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/) 的相容系列。當需要設定重疊或間隙寬度等選項時，請透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 存取群組。

當未明確設定點或系列的填色時，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列的重疊度**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getOverlap) 報告 2D 圖表中條形或柱形的重疊比例，範圍從 -100 到 100%。它是父系列群組設定的唯讀投影。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新該群組中所有相容系列。此選項只套用於顯示分組條形或柱形的圖表類型；不會影響組合圖中不相關的系列群組。

以下範例將第一個系列所在群組的重疊度設為指定值：

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

    # 此新圖表包含範例系列、類別和數值。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![The series overlap](series_overlap.png)

## **變更系列填色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getFormat) 來設定整個系列的預設填色。如果某個點已經有明確的填色，則其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getFormat) 設定會覆寫該點的系列填色。

以下範例將第一個系列套用純藍色填色：

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示在圖例內。於預設為叢集柱形圖所建立的工作簿中，B1 儲存格位於第 0 列第 1 欄，內含第一個系列的名稱。下列範例使用具名變數明確表示此結構：

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

您也可以直接更新由 [ChartSeries.getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getName) 參照的儲存格。此做法避免在既有圖表中假設特定的列與欄：

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

![The series name](series_name.png)

## **取得自動系列填色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 會根據系列索引與圖表樣式計算顏色。這是系列未明確定義填色時所使用的顏色。呼叫此方法僅會讀取計算出的顏色，不會指派新填色。

以下範例列印每個預設系列的自動顏色：

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

實際顏色取決於圖表樣式與佈景主題。

## **為圖表系列設定反轉填色**

對於條形、柱形與氣泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#setInvertIfNegative) 可在負值時使用不同的填色。請將系列的常規填色設為實心，啟用反轉，並透過 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定負值的顏色。工作簿中的負數值本身不會改變，僅會改變其顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列放置系列名稱，第 0 欄放置類別名稱，第 1 欄放置數值：

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

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一點啟用反轉。以下範例在系列整體停用反轉，僅對選取的點啟用，同時將該點設定為負值以顯示效果：

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

若要讓某一資料點變為空白而不移除其他點，請將其對應的工作簿儲存格設為 `None`。對於柱形圖而言，繪製的數值可透過 [ChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getValue) 取得。資料點仍保留在相同的類別位置，但圖表會依照空白值設定將其視為空白。

以下範例僅清除第一個系列中的第二個點：

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用尺寸儲存格。請僅清除您想移除的值所對應的儲存格。若想保留其他點，請不要呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapointcollection/#clear)，因為該方法會移除整個集合中的所有資料點。

## **控制空儲存格的顯示方式**

隱藏且含有值的儲存格屬於與空儲存格不同的情況。若要在隱藏的工作表列與欄中包含或排除資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿儲存格代表遺失的資料；包含 `0` 的儲存格代表已知的數值。使用 [ChartDataCell.setValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#setValue) 並傳入 `None` 可使儲存格變為空白。數值零即使在空儲存格設定下仍保留為零。

使用 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setDisplayBlanksAs) 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會以零或插值填滿空的工作簿儲存格。

以下完整範例建立一個包含單一系列的折線圖，清除第 3 天的值，並以每種模式分別儲存同一圖表。此範例不需要輸入檔案。[ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/) 使用工作表 0，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列保留系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

    # 將第 3 天真正保持為空，同時保留其類別與資料點。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

每個輸出檔案會在儲存前記錄所使用的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只想產生單一版本，請先指定所需模式，然後只儲存一次簡報，而非對每個模式迭代。

以下比較圖顯示三個檔案中相同的資料。第 3 天在工作簿中皆為空白：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。折線圖最易比較三種模式；條形與柱形圖沒有連線可跨過缺失的類別，因此 `Span` 無法產生上圖所示的連接段落，缺失的柱形與零高度柱形在外觀上也可能相似。同樣地，僅有標記的散佈圖亦無連線。請勿期待每種圖表類型皆產生三種明顯不同的結果，請自行檢查您使用的圖表類型的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱形叢集之間的空白，表示為條形或柱形寬度的百分比。與重疊度類似，它屬於父系列群組而非單一系列。請對該群組呼叫一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。較大的數值會在叢集之間產生更多空間，較小的數值則使其更緊密。

以下範例變更間隙寬度，並僅儲存最終簡報：

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

![The gap width](gap_width.png)

## **常見問題**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列的結構或設定並不完全相同。例如，類別圖使用類別與數值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊度與間隙寬度等選項僅套用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/) 包含相容的系列，這些系列共享群組層級的繪圖設定。組合圖可能包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中所有系列。

**新建立的圖表是否會包含預設資料？**

是。預設情況下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addChart) 會建立範例系列、類別與數值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也有重載方法可在不建立預設資料的情況下建立圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點數值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/) 中的儲存格。變更被參照的儲存格會更新對應的圖表元素。自行建立自訂資料時，請確保類別列與系列值列保持對齊，以便每個點正確繪製於預期的類別下。

**如何只清除單一資料點而不是整個系列？**

將相關的數值儲存格設為 `None`，即可保留該點的類別位置作為空白點。僅在需要移除該系列所有點時，才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapointcollection/#clear)。若同時移除類別，請同步更新所有系列，使其數值仍與類別集合保持對齊。

**空白點會如何顯示？**

顯示結果取決於圖表類型以及透過 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setDisplayBlanksAs) 設定的方式。支援的圖表可以將空白顯示為間隙、零值或連接相鄰點。請依據簡報中遺失資料的意義選擇相應設定。完整範例與視覺比較請參閱 [Control the Display of Empty Cells](#control-the-display-of-empty-cells)。

**負值的格式化方式為何？**

對於支援的條形、柱形與氣泡系列，請呼叫 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#setInvertIfNegative) 並設定 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 回傳的顏色。亦可透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一點覆寫此行為。這些方法僅影響格式化，不會更改儲存的數值。

**當系列與資料點同時設定格式時，哪一個會生效？**

明確的資料點格式會優先套用於該點。其他點則繼續使用明確的系列格式，若系列格式未定義，則使用自動的圖表樣式與佈景主題。群組設定（如重疊度與間隙寬度）屬於版面配置，並非點層級的格式覆寫。

**圖表可以包含多少個系列？是否有上限？**

Aspose.Slides 本身未設定固定的系列上限。實務上，簡報檔案大小、可用記憶體、渲染時間與圖表可讀性會決定實際可容納的系列數量。

**當柱形圖過於密集或過於稀疏時，應如何調整？**

對相應的父系列群組呼叫 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。將數值調高可擴大叢集之間的間距，調低則可使叢集更靠近。