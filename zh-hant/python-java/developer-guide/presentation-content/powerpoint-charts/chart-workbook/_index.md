---
title: 使用 Java 版 Python 管理簡報中的圖表工作簿
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
description: "探索適用於 Java 的 Python 版 Aspose.Slides：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表工作簿，簡化您的簡報資料。"
---
## **總覽**

本篇說明如何在 Aspose.Slides 中使用圖表工作簿。內容包括透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

同時也討論如何以外部工作簿作為圖表資料來源。範例示範如何建立並指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**

Aspose.Slides 提供 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#readWorkbookStream) 與 [writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#writeWorkbookStream) 方法，讓您讀寫含有使用 Aspose.Cells 編輯之圖表資料的工作簿。**注意** 圖表資料必須以相同方式組織，或具備與來源相似的結構。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **驗證工作簿修改後的圖表版面配置**

當您以修改過的工作簿取代內嵌工作簿時，圖表仍保留原本的系列與類別集合。此不一致可能導致 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#validateChartLayout) 拋出 `ArgumentOutOfRangeException`（參數：index）。為避免例外發生，請在將更新後的工作簿寫回圖表之前 **先** 清除現有的系列與類別。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

    # 在修改後（例如使用 Aspose.Cells）讀取工作簿。
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # 清除現有的資料參考。
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

清除集合可確保圖表資料結構與新工作簿對齊，使 [validateChartLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#validateChartLayout) 能順利完成而不產生錯誤。

## **設定工作簿儲存格為圖表資料標籤**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增一個氣泡圖，並加入一些資料。  
4. 取得圖表系列。  
5. 設定工作簿儲存格為資料標籤。  
6. 儲存投影片。

此 Python 程式碼示範如何設定工作簿儲存格為圖表資料標籤：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

此 Python 程式碼示範使用 [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdataworkbook/#getWorksheets) 方法存取工作表集合的操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **指定資料來源類型**

此 Python 程式碼示範如何為資料來源指定類型：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **偵測不支援的嵌入式工作簿格式**

Aspose.Slides 不支援可嵌入於某些圖表中的 Excel 二進位工作簿（.xlsb）格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/) 上使用 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/workbooktype/) 列舉，偵測不支援的格式並略過該圖表。

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # 嵌入式工作簿為 .xlsb 格式，尚未支援。
            continue
        # 在此讀取或修改圖表工作簿資料。
finally:
    presentation.dispose()
```

### **建立外部工作簿**

使用 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#readWorkbookStream) 與 [setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setExternalWorkbook) 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

此 Python 程式碼示範外部工作簿的建立過程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **設定外部工作簿**

使用 [setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setExternalWorkbook) 方法，您可以將外部工作簿指派給圖表作為資料來源。此方法亦可用於更新外部工作簿的路徑（若該檔案已搬移）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。若提供相對路徑，系統會自動轉換為完整路徑。

此 Python 程式碼示範如何設定外部工作簿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#setExternalWorkbook) 方法的第二個 (`bool`) 參數用於指定是否載入 Excel 工作簿。

* 當其值設為 `False` 時，僅會更新工作簿路徑 —— 圖表資料不會從目標工作簿載入或更新。若目標工作簿不存在或無法取得，可使用此設定。  
* 當其值設為 `True` 時，圖表資料將從目標工作簿更新。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **取得圖表外部資料來源工作簿路徑**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 建立圖表形狀的物件。  
4. 建立代表圖表資料來源的 [ChartDataSourceType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatasourcetype/) 物件。  
5. 依據來源類型與外部工作簿資料來源類型相同，指定相關條件。

此 Python 程式碼示範上述操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **編輯圖表資料**

您可以以與編輯內部工作簿相同的方式編輯外部工作簿中的資料。若無法載入外部工作簿，將拋出例外。

此 Python 程式碼實作上述流程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **從圖表快取中復原工作簿**

如果圖表使用的外部工作簿缺失或不可用，Aspose.Slides 可從投影片緩存的資料重建圖表工作簿。請建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/loadoptions/)，以 [SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/spreadsheetoptions/) 進行設定，並在開啟投影片前呼叫 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 並傳入 `True`。

以下 Python 範例開啟一個圖表參照不可用外部工作簿的投影片，並透過 [Chart.getChartData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#getChartData) 與 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 取得復原的資料：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # 在此讀取或修改已復原的工作簿資料。
finally:
    presentation.dispose()
```

若外部工作簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用緩存圖表資料作為可接受的備援時才啟用復原，因為緩存可能不包含外部工作簿在最後一次更新投影片後的變更。

## **常見問題**

**我可以判斷特定圖表是連結到外部工作簿還是嵌入式工作簿嗎？**

可以。圖表具有 [data source type](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getDataSourceType) 與 [path to an external workbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)；若來源為外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何被儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很有幫助；但請留意投影片會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。但直接從 Aspose.Slides 編輯遠端工作簿並未支援——只能作為來源使用。

**Aspose.Slides 會在儲存投影片時覆寫外部 XLSX 嗎？**

不會。投影片會儲存指向外部檔案的 [link to the external file](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)，並在讀取資料時使用該連結。儲存投影片時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼做？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護，或先產生已解密的副本（例如使用 [Aspose.Cells](/cells/python-java/)），再連結至該副本。

**多個圖表可以參考相同的外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結；若它們指向同一檔案，更新該檔案後，下一次載入資料時每個圖表皆會顯示最新變更。