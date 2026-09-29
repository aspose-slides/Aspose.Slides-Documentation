---
title: 使用 Python via Java 管理簡報中的圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/python-java/chart-workbook/
keywords:
- 圖表工作簿
- 圖表資料
- 工作簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部工作簿
- 外部資料
- 圖表快取
- 工作簿復原
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Python via Java：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表工作簿，以簡化簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

它亦說明如何使用外部工作簿作為圖表資料來源。範例示範了如何建立並指定外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

對於代表遺失資料的工作簿儲存格，請參閱[控制空儲存格的顯示](/slides/zh-hant/python-java/chart-series/) ，了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly)來控制圖表是否僅繪製來自隱藏工作表列與欄的資料。將其設為 `True` 則僅繪製可見儲存格，設為 `False` 則同時包含可見與隱藏儲存格。此設定僅影響圖表繪製，並不會隱藏或顯示工作表的列或欄。

下載[hidden-source-data.pptx](hidden-source-data.pptx)並放置於工作目錄中。其第一張投影片的第一個圖形為直條圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍保有值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getChartDataWorkbook)存取來源儲存格，並讀取[ChartDataCell.isHidden](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatacell/#isHidden)以檢查其隱藏狀態。此方法僅回報隱藏狀態，並不會變更它。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別輸出 `False`、`True`、`True`。

在此範例中，變更繪圖設定後需重新整理圖表資料：使用[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#readWorkbookStream)保留內嵌工作簿，並以[writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#writeWorkbookStream)重新載入。若要包含所有儲存格，還需使用[setRange](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setRange)復原完整範圍，包含隱藏的二月類別。僅更改旗標不足以刷新此範例的快取圖表資料與類別標籤。

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

            # 從內嵌工作簿重新整理圖表資料。
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # 還原完整來源範圍，包括隱藏的類別。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

此範例將僅含可見零售值 (10 與 20) 的檔案儲存為 `hidden_cells_True.pptx`，將全部六個值儲存為 `hidden_cells_False.pptx`。下方圖片說明了兩種繪圖模式。第 3 列與 C 欄在兩個內嵌工作簿中皆保持隱藏。

| 僅可見儲存格 (`True`) | 全部儲存格 (`False`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![全部儲存格：一月、二月與三月的零售與批發值。](hidden_cells_False.png) |

含有值的隱藏儲存格不同於空儲存格。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setDisplayBlanksAs) 控制遺失值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/python-java/chart-series/#control-the-display-of-empty-cells)以了解範例。

## **從工作簿讀寫圖表資料**

Aspose.Slides for Python via Java 提供[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#readWorkbookStream)與[writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#writeWorkbookStream)方法，使您能讀寫圖表資料工作簿（其中的圖表資料可由 Aspose.Cells 編輯）。**注意**圖表資料必須以相同方式組織，或具類似於來源的結構。

此範例開啟 `chart.pptx`（須在第一張投影片的第一個圖形為圖表）。它將內嵌工作簿讀入位元組陣列，清除現有的系列與類別，並將相同的工作簿寫回。變更僅保留於記憶體中；此範例不會儲存簡報。

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

### **修改工作簿後驗證圖表版面配置**

當您以已修改的工作簿取代內嵌工作簿時，圖表仍保留原本的系列與類別集合。此不匹配可能導致[Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#validateChartLayout)因索引超出範圍而失敗。寫回更新後的工作簿前，請先清除現有的系列與類別。此範例需要 `chart.pptx`，其第一張投影片的第一個圖形為圖表。註解標示了工作簿編輯的位置；可執行的範例將原始工作簿寫回並在記憶體中驗證版面配置。

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

        # 在此修改工作簿位元組，例如使用 Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

清除集合可在寫回工作簿前移除過期的資料參考。在使用圖表前，請為已更新的工作簿重新建立所需的系列與類別對應。

## **將工作簿儲存格設定為圖表資料標籤**

您可以使用工作簿儲存格中的文字作為圖表資料標籤。以下步驟說明如何將氣泡圖的標籤連結至其資料工作簿中的儲存格。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 透過零基索引存取第一張投影片。
3. 新增一個使用預設資料的氣泡圖。
4. 存取圖表的系列。
5. 將工作簿儲存格設定為資料標籤。
6. 儲存簡報。

此範例開啟 `chart2.pptx`（必須至少有一張投影片），並新增一個使用預設資料的氣泡圖。它使用工作表 0 上的儲存格 A10:A12 作為第一系列前三個標籤，啟用來自儲存格的標籤，並將結果儲存為 `resultchart.pptx`。

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#getWorksheets) 方法可取得圖表工作簿中的工作表。此範例建立一個使用預設資料的圓餅圖，並將每個工作表名稱印至主控台。

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

此範例建立一個使用預設資料的 3D 直條圖，並以不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 上的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datasourcetype/) 列舉用來選擇每個名稱的來源。結果儲存為 `pres.pptx`。

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

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援某些圖表可內嵌的 Excel 二進位工作簿 (.xlsb) 格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/) 上使用 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/workbooktype/) 列舉，以偵測不支援的格式並跳過那些圖表。此範例檢查 `sample.pptx` 第一張投影片的圖形，跳過非圖表圖形，並為每個內嵌 .xlsb 工作簿的圖表輸出診斷訊息。

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
        # 在此讀取或修改受支援的圖表工作簿資料。
finally:
    presentation.dispose()
```

## **外部工作簿**

Aspose.Slides 支援將外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#readWorkbookStream)與[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setExternalWorkbook)將內嵌圖表工作簿匯出為檔案，並將圖表連結至該外部工作簿。

此範例建立一個使用預設資料的圓餅圖，將其工作簿寫入 `externalWorkbook1.xlsx`，並在指定該檔案為圖表資料來源之前完成寫入。它將已連結的簡報儲存為 `externalWorkbook.pptx`。

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

### **設定外部工作簿**

透過[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setExternalWorkbook)方法，您可以將外部工作簿指定為圖表的資料來源。此方法亦可用於更新外部工作簿的路徑（若檔案已移動）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例需要工作目錄中有 `externalWorkbook.xlsx`。其名稱為 `Sheet1` 的工作表必須在 B1 包含系列名稱、在 A2:A4 包含類別名稱，且在 B2:B4 含數值。範例建立圓餅圖、連結工作簿，並使用[setRange](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setRange)將 A1:B4 對應為一個系列與三個類別。結果儲存為 `Presentation_with_externalWorkbook.pptx`。

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

[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setExternalWorkbook) 的 `updateChartData` 參數控制是否載入工作簿。

* 當 `updateChartData` 為 `False` 時，僅更新工作簿路徑。圖表資料不會從目標工作簿載入或更新，因此工作簿可以不存在。
* 當 `updateChartData` 為 `True` 時，圖表資料會從目標工作簿更新。

以下範例將佔位 URL 指派給 `updateChartData` 為 `False`。它保留圓餅圖的預設資料，並在未載入不存在的工作簿情況下儲存簡報。

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

### **取得圖表外部資料來源工作簿的路徑**

若要辨識圖表連結的工作簿，首先檢查圖表是否使用外部資料來源。若是，您可依照以下步驟取得工作簿路徑。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
2. 透過零基索引存取第一張投影片。
3. 確認第一個圖形為圖表。
4. 讀取圖表的資料來源類型。
5. 若來源為外部工作簿，讀取其路徑。

此範例開啟先前範例已建立的 `externalWorkbook.pptx`，並檢查第一張投影片的第一個圖形。若該圖形為連結至外部工作簿的圖表，範例會在主控台印出 [getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)。之後將簡報的副本儲存為 `Result.pptx`。

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

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。若無法載入外部工作簿，將拋出例外。

此範例需要 `presentation.pptx`，其第一張投影片的第一個圖形為圖表，且有可存取的外部工作簿。它將第一系列第一個資料點的儲存格值設為 100，並將簡報儲存為 `presentation_out.pptx`。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始工作簿，請使用副本。

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

### **從圖表快取復原工作簿**

若圖表使用的外部工作簿缺失或無法取得，Aspose.Slides 可從簡報中快取的資料重建圖表工作簿。開啟簡報前，建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/)，呼叫 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)，並將 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 設為 `True`。

以下 Python 範例開啟 `presentation.pptx`（其第一張投影片的第一個圖形必須是參考不可取得的外部工作簿的圖表），並透過 [Chart.getChartData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#getChartData) 與 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 取得復原的資料：

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

        # 在此讀取或修改已復原的工作簿資料。
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

若外部工作簿不可取得且未啟用復原，Aspose.Slides 會拋出例外。僅在使用快取的圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含簡報最後一次更新後對外部工作簿所做的變更。

## **常見問題**

**我可以判斷特定圖表是連結至外部工作簿還是內嵌工作簿嗎？**

是的。圖表具有[資料來源類型](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getDataSourceType)和[外部工作簿的路徑](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)；若來源為外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何被儲存？**

是的。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，若移動工作簿則可能需要更新連結。

**我可以使用位於網路資源/共享上的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。然而，Aspose.Slides 不支援直接編輯遠端工作簿——只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

簡報會儲存[外部檔案的連結](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)。編輯以儲存格為基礎的圖表資料亦可能會更新連結的本機 XLSX 檔案。若必須保持原始工作簿不變，請使用副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。一般的做法是事先解除保護，或先製作已解密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/python-java/)），再連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們皆指向同一檔案，更新該檔案後，下次載入資料時，所有圖表都會反映此變更。