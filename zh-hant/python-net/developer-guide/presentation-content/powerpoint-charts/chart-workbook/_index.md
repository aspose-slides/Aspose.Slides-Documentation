---
title: 使用 Python 管理簡報中的圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/python-net/chart-workbook/
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
- Aspose.Slides
description: "透過 .NET 的 Aspose.Slides for Python，輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表活頁簿，以簡化簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

同時也涵蓋了以外部活頁簿作為圖表資料來源的操作。範例展示了如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

## **從活頁簿讀寫圖表資料**

Aspose.Slides 提供讀寫圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）的相關方法。**注意：** 圖表資料必須以相同方式組織，或具備與來源相似的結構。

以下 Python 程式碼示範了一個範例操作：

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **在活頁簿變更後驗證圖表布局**

當您以已修改的活頁簿取代內嵌活頁簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致 [IChart.validate_chart_layout](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/ichart/validate_chart_layout/) 因索引超出範圍而失敗。請在將更新後的活頁簿寫回圖表之前，先清除既有的系列與類別。

```python
# 在修改活頁簿串流後（例如使用 Aspose.Cells）
updated_workbook = chart_data.read_workbook_stream()

# 清除現有資料參照。
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

清除這些集合可確保圖表資料結構與新活頁簿一致，使 `validate_chart_layout` 能在無錯誤的情況下完成。

## **將活頁簿儲存格設為圖表資料標籤**

有時需要直接從基礎資料活頁簿的儲存格取得圖表標籤。Aspose.Slides 允許將資料標籤繫結至特定活頁簿儲存格，讓標籤文字始終反映儲存格的值。下例說明如何啟用「值自儲存格」標籤，並將選取的標籤指向圖表活頁簿中的自訂儲存格。

1. 建立 [Presentation](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參照。
1. 新增一個帶有範例資料的氣泡圖。
1. 取得圖表系列。
1. 使用活頁簿儲存格作為資料標籤。
1. 儲存簡報。

以下 Python 程式碼示範如何將活頁簿儲存格設為圖表資料標籤：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# 實例化表示簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **管理工作表**

以下 Python 程式碼示範如何使用 `worksheets` 屬性存取工作表集合：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **指定資料來源類型**

以下 Python 程式碼示範如何指定資料來源類型：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援可於部分圖表內嵌的 Excel 二進位活頁簿（.xlsb）格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/) 上使用 `embedded_workbook_type` 屬性，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/workbooktype/) 列舉，偵測不支援的格式並略過該圖表。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # 內嵌活頁簿為 .xlsb 格式，該格式不受支援。
            continue

        # 在此讀取或修改圖表活頁簿資料。
```

## **外部活頁簿**

Aspose.Slides 支援將外部活頁簿作為圖表的資料來源。

### **設定外部活頁簿**

透過 [ChartData.set_external_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法亦可在外部活頁簿搬移後更新其路徑。

雖然無法編輯位於遠端位置或資源上的活頁簿，但仍可將這些活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

以下 Python 程式碼示範如何設定外部活頁簿：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # 傳遞 False 只會儲存路徑：目標活頁簿尚未必須存在。
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` 方法的 `update_chart_data` 參數決定是否載入 Excel 活頁簿。

- 當 `update_chart_data` 設為 `False` 時，僅更新活頁簿路徑；圖表資料不會從目標活頁簿載入或重新整理。此設定適用於目標活頁簿不存在或無法取得的情況。
- 當 `update_chart_data` 設為 `True`（預設值）時，圖表資料會自目標活頁簿載入並更新。如果無法開啟該活頁簿，將拋出訊息為「External workbook is not available」的例外。

### **建立外部活頁簿**

透過 [read_workbook_stream](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 和 [set_external_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以從頭建立外部活頁簿，或將內部活頁簿轉換為外部活頁簿。

以下 Python 程式碼示範外部活頁簿的建立流程：

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **取得圖表之外部資料來源活頁簿路徑**

有時圖表的資料會連結到外部 Excel 活頁簿，而非簡報內嵌的資料。使用 Aspose.Slides，您可以檢查圖表的資料來源，若為外部活頁簿，則讀取完整的活頁簿路徑。

1. 建立 [Presentation](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參照。
1. 取得圖表形狀的參照。
1. 取得代表圖表資料來源的來源類型（[ChartDataSourceType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatasourcetype/)）。
1. 檢查來源類型是否為外部活頁簿資料來源類型。

以下 Python 程式碼示範此操作：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **編輯圖表資料**

您可以以與編輯內部活頁簿相同的方式編輯外部活頁簿的資料。如果無法載入外部活頁簿，將拋出例外。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **從圖表快取中復原活頁簿**

如果圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 能從簡報中快取的資料重建圖表活頁簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/)，然後在開啟簡報前透過 `LoadOptions.spreadsheet_options` 啟用 [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/)。

以下 Python 範例開啟一個圖表參考不可用外部活頁簿的簡報，並透過 [Chart.chart_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/chart_data/) 與 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) 取得復原的資料：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # 在此讀取或修改復原的活頁簿資料。
```

若外部活頁簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受以快取資料作為後備方案時才啟用復原，因為快取可能不包含外部活頁簿在簡報最後一次更新後所做的變更。

## **常見問答**

**我能判斷特定圖表是連結到外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有 [data source type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/data_source_type/) 與 [path to an external workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。若來源為外部活頁簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部活頁簿，且它們是如何儲存的？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很方便；但請注意簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/分享上的活頁簿嗎？**

可以，這類活頁簿可作為外部資料來源。但 Aspose.Slides 不支援直接編輯遠端活頁簿——只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

只有在您編輯了圖表資料時才會。簡報會儲存指向外部檔案的連結，並在讀取資料時使用該連結。因此，開啟並儲存簡報本身不會改動外部活頁簿。但透過圖表資料變更的值（參見上方 **編輯圖表資料**）會在儲存簡報時寫回外部活頁簿——若原始檔案必須保持不變，請先在副本上操作。

**如果外部檔案受密碼保護，我該怎麼做？**

Aspose.Slides 在連結時不接受密碼。一般的作法是事先移除保護，或先產生一個已解密的副本（例如使用 [Aspose.Cells](/cells/python-net/)），再連結至該副本。

**多個圖表可以參考同一個外部活頁簿嗎？**

可以。每個圖表都儲存自己的連結。如果它們指向相同檔案，更新該檔案後，下次載入資料時所有圖表都會反映變更。