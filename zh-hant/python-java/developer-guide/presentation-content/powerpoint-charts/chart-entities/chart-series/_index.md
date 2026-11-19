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
## **概覽**

圖表可以將繪製的值儲存在工作簿儲存格中，或直接作為數值常量。 [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) 代表一組相關的值，而每個 [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) 代表該系列中的一個點。[ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) 物件提供系列共享的標籤或分組值。在使用預設資料建立的圖表中，系列名稱、類別和點值使用來自圖表工作簿的 [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) 物件。

對於一般的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 行儲存類別名稱，剩餘儲存格儲存系列值。傳遞給 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、列與欄索引是從零開始。此佈局在建立使用預設資料的圖表時很有用，但不要假設每個現有圖表都採用此佈局。對於已載入的簡報，請在變更工作簿值之前先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)，提供單一系列中所有點的預設外觀。
- 資料點層級設定，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)，會覆寫該系列中單一點的外觀。
- 群組設定套用於屬於相同 [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) 的相容系列。需要設定重疊或間距寬度等選項時，請透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。

當未明確設定點或系列的填色時，圖表樣式與主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![圖表系列 PowerPoint](chart-series-powerpoint.png)

對於叢集圓柱圖，請參考 [變更 3D 系列類型或條形形狀](/slides/zh-hant/python-java/3d-chart/#change-the-3d-series-type-and-bar-shape) 如何影響第一個系列。

## **使用數值常量設定系列值**

當系列值來自應用程式資料或計算且不需要工作表儲存格參照時，請使用數值常量。呼叫 [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) 並傳入 [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) 後，再使用 [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) 為每個點的 [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 結果指派常量。

集合設定會控制該系列所有點值的來源類型。每個點值的 [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) 方法會回報所選類型；可透過集合設定變更。使用 `Worksheet` 時，請使用 [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) 取得參照的儲存格。使用 `DoubleLiterals` 時，請使用 [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) 或 `setAsLiteralDouble` 直接讀寫數值。

以下範例建立一個具有預設系列與類別的柱狀圖，然後將計算後的 10、20 等值指派給其第一個系列的現有點。它會儲存簡報、重新開啟，並列印儲存的值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

點值來源類型與 [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) 不同，後者辨識圖表的內部或外部工作簿設定。使用數值常量本身不會移除內嵌工作簿；在此範例中，工作簿仍保留供類別標籤、系列名稱與其他系列使用。請參考 [圖表工作簿](/slides/zh-hant/python-java/chart-workbook/) 瞭解工作簿管理。

對於散佈圖與氣泡圖，請使用 [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) 與 [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) 分別選擇 [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) 與 [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) 的來源。氣泡圖亦使用 [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) 為 [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) 設定來源。於指派數字前，先將每個相關來源設為 `DoubleLiterals`，然後使用該值的 `setAsLiteralDouble` 方法。

## **設定圖表系列的重疊度**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) 回報 2D 圖表中條形或柱狀的重疊百分比，範圍從 -100% 到 100%。它是父系列群組設定的唯讀投影。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新該群組中所有相容系列。此選項適用於顯示分組條形或柱狀的圖表類型；不會影響組合圖中不相關的系列群組。

以下範例設定包含第一個系列之群組的重疊度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpreflc.startJVM()

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

![系列重疊度](series_overlap.png)

## **變更系列填色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) 為整個系列設定預設填色。如果某個點已明確設定填色，其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) 會覆寫該系列的填色。

以下範例為第一個系列套用純藍色實心填色：

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

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例。對於預設建立的叢集柱狀圖，儲存格 B1（第 0 列第 1 欄）即為第一個系列的名稱。以下範例中的命名變數明確表示此結構：

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

您也可以直接更新由 [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) 參照的儲存格。此作法避免對現有圖表假設特定的列與欄：

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

### **從多個儲存格建立系列名稱**

當產品名稱與報告期間分別儲存在不同工作簿儲存格時，組合系列名稱相當有用。例如，您可以將 B1 的 `Product A` 與 C1 的 `2026` 結合為單一系列名稱，同時保留兩者與來源儲存格的連結。

使用 [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) 取得名稱範圍，然後將該集合傳遞給 [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add)。`skipHiddenCells` 參數決定是否排除隱藏儲存格：`True` 為排除，`False` 為包含。本範例使用 `False` 以包含名稱範圍內的所有儲存格。

以下範例建立一個含一個系列與兩個資料點的簡報。儲存格 B1:C1 只提供系列名稱；A2:A3 提供類別標籤，B2:B3 提供數值。

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

    # 分別的儲存格提供類別和數值資料點。
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

產生的系列名稱為 `Product A 2026`，兩個儲存格值之間會自動加入空格。圖例中會將其顯示為單一項目。以下圖示說明結果：

![含北部與南部數值且圖例中顯示合成系列名稱 Product A 2026 的柱狀圖](composite_series_name.png)

## **取得自動系列填色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 會回傳依系列索引與圖表樣式計算出的顏色。這是未明確定義系列填色時所使用的顏色。呼叫此方法僅會讀取計算後的顏色，不會指派新填色。

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

實際顏色取決於圖表樣式與主題。

## **為圖表系列設定負值反轉填色**

對於條形、柱狀與氣泡系列，可使用 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) 於負值時顯示不同的填色。先將系列填色設定為實心，啟用反轉，並透過 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定負值的顏色。負數在工作簿中仍維持原值，僅變更顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列為系列名稱，第 0 欄為類別名稱，第 1 欄為數值：

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

您也可以對單一點啟用反轉，方法是呼叫 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)。以下範例在系列層面停用反轉，僅為選取的點啟用，且將該點指派負值以便觀察效果：

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

若要讓某個點變為空白而不移除其他點，請將其對應的工作簿儲存格設定為 `None`。對於柱狀圖，可透過 [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 取得繪製值。資料點仍保留於相同類別位置，但圖表會根據其空白值設定將其視為空白。

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除代表欲移除之值的儲存格。若想保留其他點，請勿呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear)，因為該方法會移除整個系列的所有資料點。

## **控制空白儲存格的顯示方式**

隱藏的儲存格即使包含值，也屬於不同於空白儲存格的情況。若要包含或排除隱藏列與欄的資料，請參考 [從隱藏列與欄中包含資料](/slides/zh-hant/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空白工作簿儲存格代表缺失資料；儲存格內的 `0` 代表已知的數值。呼叫 [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) 並傳入 `None`，即可將儲存格設為空白。數值零始終保持為零，與空白儲存格設定無關。

使用 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 可選擇圖表如何顯示空白儲存格。此設定套用於整個圖表，會改變空白點的繪製方式，而不會將空白工作簿儲存格填入零或插值。

以下自包含範例建立一條折線圖，該圖僅有一個系列，並清除第 3 天的值，然後以每種模式分別儲存同一圖表。此範例不需要輸入檔案。[ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) 使用工作表 0，第 0 欄為類別標籤，第 1 欄為值；第 0 列儲存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

    # 將第 3 天真正留空，同時保留其類別和資料點。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

每個輸出檔案在儲存前會設定相應模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只需一個版本，請在儲存簡報前指定所需模式，然後只儲存一次。

以下比較圖示三個檔案的相同資料。第 3 天在所有工作簿中皆為空白：

![折線圖使用相同資料：Gap 在第 3 天斷線，Zero 下降至零，Span 連接第 2 天與第 4 天。](display_blanks_as.png)

可見效果取決於圖表類型。折線圖能清楚展示三種模式的差異。條形與柱狀圖因缺少連接線，`Span` 無法產生如上所示的連接段；缺失的柱形與零高度柱形也可能看起來相似。類似地，僅有標記的散佈圖也不會有連接線。請不要期望每種圖表類型都會產生三個明顯不同的結果；請檢查您使用的圖表類型的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱狀叢集之間的空間，表達為條形或柱狀寬度的百分比。與重疊度相同，它屬於父系列群組而非單一系列。對群組呼叫一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。較大的值會在叢集間產生更多空間，較小的值則使其更緊密。

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

![間隙寬度](gap_width.png)

## **顯示或隱藏系列線條**

系列線條在圖表中視覺上連接相關的部份。使用 [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSeriesLines) 可在支援的堆疊條形與堆疊圓餅圖中顯示或隱藏它們。在二維堆疊條形與柱狀圖中，系列線條會跨類別連接相對的堆疊邊界。在「圓餅的圓餅」與「條形的圓餅」圖表中，則連接主圖與次圖。此設定不適用於其他圖表類型的通用連接線。

請透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。設定會套用至該群組中的每個系列。[ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#hasSeriesLines) 為唯讀屬性，會反映父群組的設定；請呼叫群組的 setter 以更新。

以下範例建立一個預設資料的 [PieOfPie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#PieOfPie) 圖表，分別以啟用與停用系列線條儲存兩個簡報以供比較。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400)
    series = chart.getChartData().getSeries().get_Item(0)
    series_group = series.getParentSeriesGroup()

    series_group.setSeriesLines(True)
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx)

    series_group.setSeriesLines(False)
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 系列線條已啟用 | 系列線條已停用 |
| --- | --- |
| ![啟用系列線條的圓餅圖](series_lines_enabled.png) | ![停用系列線條的圓餅圖](series_lines_disabled.png) |
| 兩條線條連接主圓餅與次圓餅。 | 兩個圓餅仍可見，但連接線條被隱藏。 |

系列線條不同於資料標籤指示線（連接標籤與資料點）、格線（標示坐標軸間隔）以及折線圖中的線條（代表資料值）。此設定不會控制上述元素。

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 列舉的圖表類型皆使用圖表資料，但其系列的值結構與設定並不完全相同。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用與系列類型相符的資料點建立方法。重疊度與間隙寬度等選項僅適用於相容的條形或柱狀群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖表可能含有多個群組，因而透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是的。預設情況下，[ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。亦可使用其他參數建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) 中的儲存格。變更參照的儲存格會更新相對應的圖表元素。建立自訂資料時，請確保類別列與系列值列對齊，使每個點都繪製在預期的類別下。

**如何只清除單一點而非整個系列？**

將相關的值儲存格設定為 `None`，即可保留點的類別位置而將其設為空白。僅在需要移除整個系列的所有點時，才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear)。

**空白點會如何顯示？**

顯示結果取決於圖表類型與透過 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 設定的值。支援的圖表可以將空白顯示為間隙、零值或連接相鄰點。請選擇與簡報中缺失資料意義相符的設定。完整範例與視覺比較請參考 [控制空白儲存格的顯示方式](#control-the-display-of-empty-cells)。

**負值的格式如何設定？**

對於支援的條形、柱狀與氣泡系列，呼叫 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) 並設定由 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 回傳的顏色。您亦可使用 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為個別點覆寫此行為。這些方法影響格式，而非儲存的數值。

**當系列與點同時設定格式時，哪個會優先？**

明確的資料點格式會優先套用於該點。其他點會繼續使用明確的系列格式，若系列格式未定義，則採用自動圖表樣式與主題。群組設定（如重疊與間隙寬度）僅影響版面配置，並非點層級的格式覆寫。

**圖表的系列數量有上限嗎？**

Aspose.Slides 並未設定固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表可讀性會決定實際可用的上限。

**當欄位過於靠近或過於分散時，應如何調整？**

對相應的父系列群組呼叫 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大數值會擴大叢集之間的間距，減小則使叢集更緊密。