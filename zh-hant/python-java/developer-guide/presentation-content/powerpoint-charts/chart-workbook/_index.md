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
description: "探索適用於 Python via Java 的 Aspose.Slides：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，簡化您的簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它還涵蓋了將外部活頁簿作為圖表資料來源的使用方式。範例說明如何建立並指定外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

若活頁簿儲存格代表遺失的資料，請參閱[控制空白儲存格的顯示](/slides/zh-hant/python-java/chart-series/)，了解空儲存格與零值之間的差異，以及可用顯示模式的折線圖比較。

## **從隱藏的列與欄位納入資料**

使用[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly)來控制圖表是否僅繪製隱藏工作表列與欄位以外的資料。設定為 `True` 只繪製可見儲存格，設定為 `False` 則同時納入可見與隱藏儲存格。此設定僅影響圖表繪製；不會隱藏或取消隱藏工作表列或欄位。

[範例簡報](hidden-source-data.pptx)的第一張投影片第一個圖形是一個柱狀圖。內嵌工作表 `Sheet1` 包含來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍保有數值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook)存取來源儲存格，並讀取[ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden)以檢查其隱藏狀態。此方法只報告隱藏狀態，不會變更它。在本檔中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄位；範例分別輸出 `False`、`True`、`True`。

對於此範例，在變更繪製設定後請重新整理圖表資料：使用[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream)保留內嵌活頁簿，然後以[writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream)重新載入。若要納入所有儲存格，還需使用[setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange)恢復完整範圍（包括隱藏的二月類別）。僅切換旗標不足以刷新此範例的快取圖表資料與類別標籤。

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
                # 還原完整來源範圍，包含隱藏的類別。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

此範例會儲存兩個版本的簡報：一個僅包含可見的零售值 (10 與 20)，另一個則包含全部六個值。下圖說明兩種繪製模式。第 3 列與 C 欄在兩個內嵌活頁簿中皆保持隱藏。

| 僅可見儲存格 (`True`) | 所有儲存格 (`False`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

含有值的隱藏儲存格不同於空白儲存格。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) 控制遺失值的顯示方式，並不會包含或排除隱藏的來源資料。請參閱[控制空白儲存格的顯示](/slides/zh-hant/python-java/chart-series/#control-the-display-of-empty-cells)以取得範例。

## **取得圖表的資料範圍**

在更新現有簡報中的活頁簿資料之前，請先檢查來源範圍，以辨識每個圖表使用的工作表儲存格。[ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) 方法會回傳目前的資料範圍，格式為工作表限定的公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 為工作表名稱，`!` 與儲存格範圍分隔，`$A$1:$D$5` 表示包括 A1 到 D5 的儲存格。美元符號表示絕對列與欄參照。

此方法僅讀取目前範圍，不會更動圖表或其活頁簿。若圖表未使用活頁簿作為資料來源，會拋出 `InvalidOperationException`。更多資訊請參閱[ChartData API 參考](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)。

此範例會開啟簡報，直接檢查每張投影片上的圖形是否為圖表，並印出每個圖表的名稱與來源範圍。若圖表未使用活頁簿，會印出訊息並繼續處理下一個圖表。

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

Aspose.Slides for Python via Java 提供了[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) 與 [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) 方法，可讓您讀寫圖表活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意**，圖表資料必須以相同方式組織，或具備與來源相似的結構。

此範例使用第一張投影片第一個圖形的圖表。它會將內嵌活頁簿讀取為位元組陣列，清除現有系列與類別，然後再寫回相同的活頁簿。變更僅保留在記憶體中；範例不會儲存簡報。

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

### **在修改活頁簿後驗證圖表版面配置**

當您以修改過的活頁簿取代內嵌活頁簿時，圖表仍保留原始的系列與類別集合。此不一致可能導致[Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) 因索引超出範圍而失敗。寫回更新後的活頁簿之前，請先清除現有系列與類別。此範例使用第一張投影片第一個圖形的圖表。註解標示了活頁簿編輯會發生的地方；可執行的範例寫回原始活頁簿，並在記憶體中驗證版面配置。

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

        # 在此處修改活頁簿位元組，例如使用 Aspose.Cells。

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

清除集合可在寫回活頁簿前移除過時的資料參考。於使用圖表前，請針對更新後的活頁簿重新建構必要的系列與類別對應。

## **為活頁簿儲存格設定自訂數字格式**

使用[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) 來控制數值在圖表內嵌活頁簿中的顯示方式。例如，報表可能需要將轉換率以四位小數的百分比顯示，將係數以五位小數顯示。兩個值皆保持數值型別，以便進行計算與圖表繪製。

數字格式僅改變顯示，不會改變儲存的值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`，但不會將儲存的數字改為 `12.5`。同理，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，而不會四捨五入儲存值。若自訂格式為空字串 (`""`)，則會使用[getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) 回傳的格式。

下列範例建立一個柱狀圖，並透過[getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 存取儲存格。於工作表 0，B2 包含轉換率，C2 包含係數。兩個儲存格皆提供圖表數值。範例同時啟用連結至來源格式的數值標籤。

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

活頁簿儲存格格式與直接在圖表座標軸或資料標籤上設定的格式分離。在此範例中，由於[setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) 設為 `True`，每個標籤皆顯示其來源儲存格的值，且因[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) 為 `True`，遵循來源的數字格式。儲存並重新開啟簡報後，標籤分別顯示 `12.5000%` 與 `0.12346`，如下圖所示。垂直座標軸則使用[setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) 設為 `0.00`，且[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) 為 `False`。

若需獨立設定資料標籤，請將其來源連結旗標設為 `False`，並以[setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) 指定格式。此動作不會變更活頁簿儲存格的格式。例如，獨立的 `0.00` 格式會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱[圖表資料標籤](/slides/zh-hant/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) 以取得直接標籤格式化的說明。

以下圖片是重新開啟儲存後的簡報渲染結果：

![柱狀圖，來源連結標籤顯示 12.5000% 與 0.12346，且垂直座標軸以獨立格式顯示數字。](custom-cell-formats.png)

## **將活頁簿儲存格設為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例在現有簡報的第一張投影片加入一個預設資料的氣泡圖，使用工作表 0 的儲存格 A10:A12 作為第一系列前三個標籤，啟用來自儲存格的標籤，並儲存更新後的簡報。

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) 方法提供對圖表活頁簿中工作表的存取。此範例建立一個預設資料的圓餅圖，並將每個工作表名稱印出至主控台。

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

此範例建立一個預設資料的 3D 柱狀圖，並使用兩種不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 中的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) 列舉用來選擇每個名稱的來源。範例會儲存更新後系列名稱的簡報。

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

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援可嵌入於某些圖表的 Excel 二進位活頁簿（.xlsb）格式。您可以在 [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) 上使用 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) 列舉，偵測不支援的格式並跳過那些圖表。此範例檢查現有簡報第一張投影片上的圖形，跳過非圖表圖形，並為每個含有內嵌 .xlsb 活頁簿的圖表印出診斷訊息。

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

Aspose.Slides 支援使用外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) 與 [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) 將內嵌圖表活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立一個預設資料的圓餅圖，並匯出其活頁簿。檔案寫入完成後再指派外部活頁簿為圖表資料來源，最後儲存已連結的簡報。

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

使用[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) 方法，您可以將外部活頁簿指派給圖表作為資料來源。若外部活頁簿的路徑已變更，也可透過此方法更新。

雖然無法直接編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部活頁簿，其工作表 `Sheet1` 在 B1 含系列名稱、A2:A4 含類別名稱、B2:B4 含數值。範例建立圓餅圖、連結活頁簿，並使用[setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) 將 A1:B4 映射為一個系列與三個類別。最後儲存連結圖表的簡報。

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

* 當 `updateChartData` 為 `False` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，因此活頁簿可以不存在。
* 當 `updateChartData` 為 `True` 時，圖表資料會從目標活頁簿更新。

以下範例將佔位 URL 指派給 `updateChartData=False`。它保留圓餅圖的預設資料，且在未載入無法取得的活頁簿情況下仍儲存簡報。

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

若要辨識圖表連結的活頁簿，請先檢查圖表是否使用外部資料來源，然後取得其活頁簿路徑。

此範例檢查含有外部活頁簿連結的簡報第一張投影片的第一個圖形。若它是連結至外部活頁簿的圖表，範例會將 [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) 印至主控台，然後儲存簡報的副本。

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

您可以以與編輯內嵌活頁簿相同的方式編輯外部活頁簿的資料。若無法載入外部活頁簿，會拋出例外。

此範例使用第一張投影片第一個圖形的圖表，且已連結至可存取的外部活頁簿。它將第一系列第一資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始活頁簿，請先建立副本。

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

### **從圖表快取還原活頁簿**

若圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可以從簡報快取的資料重建圖表活頁簿。建立 [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/)，呼叫 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)，並在開啟簡報前將 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 設為 `True`。

以下 Python 範例針對第一張投影片第一個圖形的圖表（引用不可用的外部活頁簿）還原活頁簿資料。它透過 [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) 和 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 取得還原的資料：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

        # 在此讀取或修改還原的活頁簿資料。
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

若外部活頁簿不可用且未啟用還原，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為可接受的備援時才啟用還原，因為快取可能不包含外部活頁簿在最後一次更新簡報之後的變更。

## **常見問題集**

**我可以判斷特定圖表是連結至外部還是內嵌活頁簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType)與[外部活頁簿路徑](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)；若來源為外部活頁簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部活頁簿，且它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，搬移活頁簿時可能需要更新連結。

**我可以使用位於網路資源/共用資料夾的活頁簿嗎？**

可以，這類活頁簿可作為外部資料來源。然而，Aspose.Slides 不支援直接編輯遠端活頁簿——只能將其作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

簡報會儲存指向外部檔案的[連結](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)。編輯以儲存格為基礎的圖表資料亦可能更新連結的本機 XLSX 檔案。如需保留原始活頁簿，請使用副本。

**若外部檔案有密碼保護該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先解除保護，或先產生已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/python-java/)），再連結該副本。

**多個圖表能否參考同一個外部活頁簿？**

可以。每個圖表都會儲存自己的連結。如果它們指向相同檔案，更新該檔案後，下一次載入資料時所有圖表都會反映變更。