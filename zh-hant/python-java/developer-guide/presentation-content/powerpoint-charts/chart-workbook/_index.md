---
title: 使用 Python via Java 管理簡報中的圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/python-java/chart-workbook/
keywords:
- 圖表活頁簿
- 圖表資料
- 活頁簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部活頁簿
- 外部資料
- 圖表快取
- 活頁簿復原
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Python via Java：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，簡化簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、將活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

同時也說明如何使用外部活頁簿作為圖表資料來源。範例示範如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

對於代表缺失資料的活頁簿儲存格，請參閱 [Control the Display of Empty Cells](/slides/zh-hant/python-java/chart-series/) 了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用 [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) 來控制圖表是否僅繪製來自可見工作表列與欄的資料。將其設為 `True` 只繪製可見儲存格，或設為 `False` 同時包含可見與隱藏儲存格。此設定僅影響圖表繪製，不會隱藏或取消隱藏工作表的列與欄。

[範例簡報](hidden-source-data.pptx) 的第一張投影片第一個圖形是一個柱狀圖。內嵌工作表 `Sheet1` 含有來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍保有數值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 取得來源儲存格，並讀取 [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) 以檢查其隱藏狀態。此方法僅回報隱藏狀態而不改變它。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別印出 `False`、`True`、`True`。

對此範例，在變更繪圖設定後請重新整理圖表資料：使用 [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) 取得內嵌活頁簿，然後以 [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) 重新載入。若要包含所有儲存格，亦須使用 [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) 以復原完整範圍（包含隱藏的二月類別）。僅變更旗標不足以重新整理此範例的快取圖表資料與類別標籤。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # 從內嵌活頁簿重新整理圖表資料。
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # 復原完整來源範圍，包含隱藏的類別。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

此範例儲存兩個版本的簡報：一個僅包含可見的零售值（10 與 20），另一個則包含全部六個值。下方圖片說明兩種繪圖模式。第 3 列與 C 欄在兩個內嵌活頁簿中皆保持隱藏。

| 只顯示可見儲存格 (`True`) | 顯示全部儲存格 (`False`) |
| --- | --- |
| ![只顯示可見儲存格：一月與三月的零售值 10 及 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月、三月的零售與批發值。](hidden_cells_False.png) |

含值的隱藏儲存格不同於空儲存格。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 控制缺失值的顯示方式；它不會加入或排除隱藏的來源資料。請參閱 [Control the Display of Empty Cells](/slides/zh-hant/python-java/chart-series/#control-the-display-of-empty-cells) 取得範例。

## **取得圖表的資料範圍**

在更新現有簡報中的活頁簿資料之前，先檢查來源範圍，以了解每個圖表使用哪些工作表儲存格。[ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) 會回傳目前的資料範圍（為工作表限定的公式），例如 `Sheet1!$A$1:$D$5`。此處 `Sheet1` 為工作表名稱，`!` 將名稱與儲存格範圍分開，`$A$1:$D$5` 表示包含 A1 到 D5 的儲存格（含起訖）。美元符號表示絕對列與欄參照。

此方法僅讀取目前範圍而不改變圖表或其活頁簿。若圖表未使用活頁簿作為資料來源，會拋出 `InvalidOperationException`。更多資訊請參閱 [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)。

本範例開啟簡報，直接檢查每張投影片上的圖形是否為圖表，並印出每個圖表的名稱與來源範圍。若圖表未使用活頁簿，會印出訊息並繼續處理下一個圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **從活頁簿讀寫圖表資料**

Aspose.Slides for Python via Java 提供 [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) 與 [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) 方法，讓您能讀寫圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或具備類似的結構。

本範例使用第一張投影片第一個圖形的圖表。它將內嵌活頁簿讀取為位元組陣列，清除現有的系列與類別，然後寫回相同的活頁簿。變更僅保留在記憶體中，範例不會儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **驗證活頁簿變更後的圖表版面配置**

當您以修改過的活頁簿取代內嵌活頁簿時，圖表仍保留原本的系列與類別集合。此不匹配可能導致 [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) 因索引超出範圍而失敗。請在寫回更動過的活頁簿之前先清除現有的系列與類別。本範例使用第一張投影片第一個圖形的圖表。註解標示了活頁簿編輯的位置；可執行的範例寫回原始活頁簿並在記憶體中驗證版面配置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # 在此修改活頁簿位元組，例如使用 Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

清除集合可在寫回活頁簿前移除過期的資料參照。於使用圖表前，請重新建立任何必要的系列與類別對應。

## **選擇類別標籤的儲存方式**

在加入標籤之前，先於空的類別集合上呼叫 [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorycollection/#setUseCells)。當標籤參照活頁簿資料或需要階層結構（例如以年度分組的季）時，使用工作表儲存格；若只是單層且不需要儲存格參照，則使用字串常量。此設定僅套用於類別。下方兩個圖表皆使用工作表儲存格作為其數值系列。

範例建立兩個柱狀圖，先印出儲存模式，然後分別印出 `Q1 Q2 Q3 Q4`。對於工作表支援的標籤，[ChartCategory.getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getAsCell) 取得底層儲存格，而 [ChartDataCell.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getValue) 讀取其標籤。對於字面標籤，[ChartCategory.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getValue) 直接回傳字串。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    for use_cells in (True, False):
        x = 20 if use_cells else 360
        chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250)
        chart_data = chart.getChartData()
        chart_data.getSeries().clear()
        categories = chart_data.getCategories()
        categories.clear()
        categories.setUseCells(use_cells)

        workbook = chart_data.getChartDataWorkbook()
        series_name = workbook.getCell(0, 0, 1, "Sales")
        series = chart_data.getSeries().add(series_name, chart.getType())
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.getCell(0, row, 0, label)
                categories.add(label_cell)
            else:
                categories.add(label)

            value_cell = workbook.getCell(0, row, 1, jpype.JInt(row * 10))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        stored_in_cells = categories.getUseCells()
        labels = []
        for category in categories:
            value = category.getAsCell().getValue() if stored_in_cells else category.getValue()
            labels.append(str(value))
        print(f"UseCells = {stored_in_cells}:", *labels)

    presentation.save("category-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **為活頁簿儲存格設定自訂數字格式**

使用 [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) 來控制數值在圖表內嵌活頁簿中的顯示方式。例如，報表可能需要將轉換率顯示為保留四位小數的百分比，將係數顯示為保留五位小數的數值。請確保兩個值皆為數值，以便於計算與圖表繪製。

數字格式只改變顯示，不會改變實際儲存的值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`，但不會將儲存的數字改為 `12.5`。同理，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，而不會對儲存值進行四捨五入。若自訂格式為空字串 (`""`)，則使用由 [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) 回傳的預設格式。

以下範例建立一個柱狀圖，並透過 [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 存取其儲存格。於工作表 0，B2 為轉換率，C2 為係數，兩者皆提供圖表值。範例亦啟用與來源格式連結的數值標籤。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

活頁簿儲存格的格式與直接設定在圖表軸或資料標籤上的格式是分開的。在本例中，每個標籤皆因 [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) 設為 `True` 而顯示來源儲存格的值，並因 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) 設為 `True` 而遵循來源的數字格式。儲存並重新開啟簡報後，標籤分別顯示 `12.5000%` 與 `0.12346`，如下圖所示。垂直軸則使用自行設定的數字格式，透過 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) 設為 `0.00`，且 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) 為 `False`。

若想獨立格式化資料標籤，請將其來源連結旗標設為 `False`，再以 [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) 指定格式。此操作不會改變活頁簿儲存格的格式。例如，獨立的 `0.00` 格式會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱 [Chart Data Labels](/slides/zh-hant/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) 以取得直接標籤格式化的範例。

以下圖片為重新開啟儲存後的簡報所渲染的結果：

![來源連結標籤顯示 12.5000% 與 0.12346，且數值軸使用獨立格式化的柱狀圖。](custom-cell-formats.png)

## **將活頁簿儲存格設為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例在既有簡報的第一張投影片加入一個預設資料的氣泡圖，使用工作表 0 的儲存格 A10:A12 作為第一系列的前三個標籤，啟用來自儲存格的標籤，並儲存更新後的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **管理工作表**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) 方法提供對圖表活頁簿中工作表的存取。本範例建立一個預設資料的圓餅圖，並將每個工作表名稱印至主控台。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **指定資料來源類型**

系列點的數值也可以直接以數字常量儲存。請參閱 [Set Series Values Using Numeric Literals](/slides/zh-hant/python-java/chart-series/#set-series-values-using-numeric-literals) 取得完整範例（儲存與讀取）。點值的來源類型與圖表的內部或外部活頁簿設定是分開的；使用數字常量本身並不會移除內嵌活頁簿。

此範例建立一個預設資料的 3D 柱狀圖，並以不同的資料來源設定兩個系列名稱。第一個名稱使用字串常量；第二個名稱使用工作表 0 的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) 列舉用來為每個名稱選取來源。範例儲存了更新了系列名稱的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **偵測不受支援的內嵌活頁簿格式**

Aspose.Slides 不支援可嵌入於某些圖表中的 Excel 二進位活頁簿 (.xlsb) 格式。您可以在 [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) 上使用 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) 列舉來偵測不受支援的格式，並跳過那些圖表。此範例檢查現有簡報第一張投影片的圖形，跳過非圖表圖形，並為每個含有 .xlsb 內嵌活頁簿的圖表印出診斷訊息。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # 在此讀取或修改受支援的圖表活頁簿資料。
finally:
    presentation.dispose()
```

## **外部活頁簿**

Aspose.Slides 支援將外部活頁簿用作圖表的資料來源。

### **建立外部活頁簿**

使用 [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) 與 [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) 將內嵌圖表活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立一個預設資料的圓餅圖，並匯出其活頁簿。檔案寫入完成後，將外部活頁簿指派為圖表資料來源，最後儲存已連結的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **設定外部活頁簿**

透過 [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法亦可用來更新外部活頁簿的路徑（若檔案已搬移）。

雖然無法編輯儲存於遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿用作外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部活頁簿，其工作表 `Sheet1` 包含 B1 的系列名稱、A2:A4 的類別名稱，以及 B2:B4 的數值。範例建立圓餅圖、連結活頁簿，並使用 [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) 將 A1:B4 對應至一個系列與三個類別。最後儲存帶有連結圖表的簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) 的 `updateChartData` 參數決定是否載入活頁簿。

* 當 `updateChartData` 為 `False` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，活頁簿可為不可用狀態。
* 當 `updateChartData` 為 `True` 時，圖表資料會從目標活頁簿更新。

以下範例將佔位 URL 指派給 `updateChartData` 為 `False`。此情況保留圓餅圖的預設資料，且在未載入不可用活頁簿的情況下儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **取得圖表的外部資料來源活頁簿路徑**

若要識別連結至圖表的活頁簿，請檢查圖表是否使用外部資料來源，並取得其活頁簿路徑。

此範例檢查簡報第一張投影片的第一個圖形，若該圖形為連結至外部活頁簿的圖表，則印出 [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) 至主控台，並儲存簡報的副本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **編輯圖表資料**

您可以像編輯內部活頁簿一樣編輯外部活頁簿的資料。若外部活頁簿無法載入，會拋出例外。

此範例使用第一張投影片第一個圖形的圖表，且該圖表已連結至可存取的外部活頁簿。它將第一系列第一資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始活頁簿，請使用其副本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **從圖表快取復原活頁簿**

若圖表使用的外部活頁簿遺失或不可用，Aspose.Slides 可以從簡報中的快取資料重建圖表活頁簿。建立 [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/)，呼叫 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)，並在開啟簡報前將 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 設為 `True`。

以下 Python 範例復原第一張投影片第一個圖形的圖表資料（該圖表參照不可用的外部活頁簿），並透過 [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) 以及 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 存取復原的資料：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # 在此讀取或修改已復原的活頁簿資料。
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

若外部活頁簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為備援時才啟用復原，因為快取可能不包含外部活頁簿在簡報最後一次更新後所做的變更。

## **常見問題 (FAQ)**

**我能否判斷特定圖表是連結至外部活頁簿還是內嵌活頁簿？**

可以。圖表具備 [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) 以及 [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)；若來源為外部活頁簿，您即可讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部活頁簿，且它們如何儲存？**

支援。若您提供相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，搬移活頁簿時可能需要更新連結。

**我可以使用位於網路資源/共享中的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源。但 Aspose.Slides 不支援直接編輯遠端活頁簿——它們只能作為來源使用。

**儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 檔案嗎？**

簡報僅儲存指向外部檔案的 [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)。編輯以儲存格為基礎的圖表資料亦會更新已連結的本機 XLSX 檔案。若原始檔案必須保持不變，請使用該活頁簿的副本。

**若外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護，或先產生已解密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/python-java/)），再連結至該副本。

**多個圖表可以參照相同的外部活頁簿嗎？**

可以。每個圖表皆儲存自己的連結。若它們皆指向同一檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。