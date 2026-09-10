---
title: 在 Python 簡報中管理圖表資料系列
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
- 系列間距
- 負值
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度以及負值。"
---
## **概觀**

圖表會將其繪製的資料儲存在圖表資料工作簿中。A [ChartSeries](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/) 代表一組相關的值，且該系列中的每個 [ChartDataPoint](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/) 會對應一或多個工作簿儲存格。[ChartCategory](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別以及點值皆與 [ChartDataCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/) 物件連結，而非僅儲存為顯示文字。

對於一般的類別圖表，預設工作簿使用第 0 列存放系列名稱，第 0 欄存放類別名稱，其餘儲存格則存放系列值。傳遞給 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、列與欄索引皆為零基礎。此佈局在建立使用預設資料的圖表時很有用，但不要假設每個既有圖表都採用此方式。對於已載入的簡報，請在變更工作簿值之前先檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getFormat)，提供該系列所有點的預設外觀。
- 資料點層級設定，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getFormat)，會覆寫單一點的系列外觀。
- 群組設定套用於同屬於 [ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/) 的相容系列。需要設定如重疊或間隙寬度等選項時，請透過 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 取得群組。

當未明確設定點或系列填色時，圖表樣式與佈景主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getOverlap) 回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100 到 100 百分比。它是父系列群組設定的唯讀投射。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setOverlap) 可以更新該群組中所有相容系列。此選項僅適用於顯示群組長條或柱狀的圖表類型，對組合圖中不相關的系列群組不產生影響。

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

    # 新增的圖表包含範例系列、類別和數值。
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

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getFormat) 為整個系列設定預設填色。如果某個點已具有明確的填色，其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getFormat) 設定會覆寫該點的系列填色。

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常顯示於圖例。在為叢集柱狀圖建立的預設工作簿中，儲存格 B1 位於第 0 列第 1 欄，內含第一個系列的名稱。以下範例中的具名變數說明了此結構：

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

您也可以直接更新 [ChartSeries.getName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getName) 已參照的儲存格。此作法避免在既有圖表中假設特定的列與欄：

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

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 會回傳根據系列索引與圖表樣式計算出的顏色。此顏色用於系列填色未明確定義時。呼叫此方法只會讀取計算出的顏色，並不會指派新的填色。

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

## **為圖表系列設定負向倒置填色**

對於長條、柱狀與氣泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#setInvertIfNegative) 可在負值時使用不同的填色。先將系列填色設定為實心，啟用倒置，並透過 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定負值的顏色。工作簿中的負數值本身不會改變，只有其顯示顏色會變更。

以下範例以單一系列取代預設圖表資料。工作表第 0 列放系列名稱，第 0 欄放類別名稱，第 1 欄放數值：

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

您也可以透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一點啟用倒置。下列範例中，系列已停用倒置，僅為選取的點啟用，且該點亦被指派負值以便觀察效果：

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

若要使某點變為空白而不移除其他點，將其對應的工作簿儲存格設為 `None`。以柱狀圖為例，可透過 [ChartDataPoint.getValue](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getValue) 取得繪製值。資料點仍保留於相同類別位置，但圖表會依照空白值設定將其視為空白。

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除代表欲移除值的儲存格即可。若想保留其他點，請勿呼叫 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapointcollection/#clear)；該方法會移除整個集合中的所有資料點。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀叢集之間的空間，以長條或柱狀寬度的百分比表示。與重疊相同，它屬於父系列群組而非單一系列。對該群組呼叫一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。較大的值會在叢集間產生更多空間，較小的值則使叢集更緊密。

以下範例變更間隙寬度，並僅儲存最終的簡報：

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

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/) 列舉表示的圖表類型都使用圖表資料，但它們的系列並非皆具有相同的值結構或設定。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外使用氣泡大小。請使用與系列類型相符的資料點建立方法。像是重疊與間隙寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/) 包含共享群組層級繪製設定的相容系列。組合圖可包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表會包含預設資料嗎？**

會。預設情況下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addChart) 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也有方法可建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 [ChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/) 中的儲存格。變更已參照的儲存格會更新對應的圖表元素。建立自訂資料時，請確保類別列與系列值列保持對齊，讓每個點都繪製在預期的類別下。

**如何只清除一個點而不是整個系列？**

將相關的值儲存格設為 `None`，即可保留該點的類別位置作為空白點。只有在要移除該系列所有點時才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapointcollection/#clear)。若您同時移除類別，請更新每個系列，使其值仍與類別集合保持對齊。

**空白點會如何顯示？**

顯示方式取決於圖表類型以及透過 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setDisplayBlanksAs) 設定的值。受支援的圖表可以將空白顯示為間隙、零值，或連接相鄰點。請選擇最符合簡報中缺失資料意義的設定。

**負值會如何格式化？**

對受支援的長條、柱狀與氣泡系列，呼叫 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#setInvertIfNegative) 並設定 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 回傳的顏色。您也可以透過 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 為單一資料點覆寫此行為。這些方法僅影響格式，而不會改變儲存的數值。

**當系列與點同時設定格式時，哪一個會生效？**

明確的資料點格式會優先於系列格式，僅套用於該點。其他點仍會使用明確的系列格式，或在系列格式未定義時使用自動圖表樣式與佈景主題。群組設定（如重疊與間隙寬度）僅控制版面配置，並不會覆寫點層級的格式。

**圖表可以容納多少系列？有沒有上限？**

Aspose.Slides 並未針對系列數量設定固定上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表的可讀性會決定實際可容納的上限。

**當柱狀圖的欄位過於接近或過於分散時，我該如何調整？**

對相應的父系列群組呼叫 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。增加數值會擴大叢集之間的間距，減少數值則會使叢集更靠近。