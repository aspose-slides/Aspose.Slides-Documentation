---
title: 使用 Python 在簡報中管理圖表活頁簿
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
description: "探索透過 .NET 的 Aspose.Slides for Python：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表活頁簿，簡化簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、將活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外，也說明如何使用外部活頁簿作為圖表資料來源。範例示範了如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

## **從活頁簿讀寫圖表資料**

Aspose.Slides 提供了讀寫圖表資料活頁簿（該活頁簿包含使用 Aspose.Cells 編輯的圖表資料）的方法。**注意:** 圖表資料必須以相同方式組織，或具有類似於來源的結構。

以下 Python 程式碼示範一個範例操作：

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

## **將工作簿儲存格設定為圖表資料標籤**

有時候您需要直接從底層資料活頁簿的儲存格取得圖表標籤。Aspose.Slides 允許您將資料標籤繫結至特定的活頁簿儲存格，使標籤文字始終反映該儲存格的值。以下範例顯示如何啟用從儲存格取得值的標籤，並將選取的標籤指向圖表活頁簿中的自訂儲存格。

1. 建立 [Presentation](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 加入帶有範例資料的氣泡圖。  
4. 存取圖表系列。  
5. 使用工作簿儲存格作為資料標籤。  
6. 儲存簡報。

以下 Python 程式碼顯示如何將工作簿儲存格設定為圖表資料標籤：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# 實例化代表簡報檔案的 Presentation 類別。
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

以下 Python 程式碼示範如何使用 `worksheets` 屬性來存取工作表集合：

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

以下 Python 程式碼顯示如何指定資料來源類型：

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

Aspose.Slides 不支援可嵌入於某些圖表中的 Excel 二進位活頁簿 (.xlsb) 格式。您可以將 `embedded_workbook_type` 屬性與 [ChartData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/) 以及 [WorkbookType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/workbooktype/) 列舉一起使用，以偵測不支援的格式並跳過那些圖表。

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
            # 內嵌的活頁簿為 .xlsb 格式，尚不支援。
            continue

        # 在此讀取或修改圖表活頁簿資料。
```

## **外部活頁簿**

Aspose.Slides 支援使用外部活頁簿作為圖表的資料來源。

### **設定外部活頁簿**

透過使用 [ChartData.set_external_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以將外部活頁簿指派給圖表作為其資料來源。若外部活頁簿已移動，此方法也能更新其路徑。

雖然無法編輯儲存在遠端位置或資源上的活頁簿資料，但仍可將這些活頁簿作為外部資料來源使用。若您為外部活頁簿提供相對路徑，系統會自動將其轉換為完整路徑。

以下 Python 程式碼顯示如何設定外部活頁簿：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`update_chart_data` 參數指定是否載入 Excel 活頁簿。

- 當 `update_chart_data` 設為 `False` 時，僅更新活頁簿路徑；圖表資料不會從目標活頁簿載入或重新整理。當目標活頁簿不存在或無法取得時請使用此設定。  
- 當 `update_chart_data` 設為 `True` 時，圖表資料會從目標活頁簿載入並更新。

### **建立外部活頁簿**

透過使用 [read_workbook_stream](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 與 [set_external_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以從頭建立外部活頁簿，或將內部活頁簿轉換為外部活頁簿。

此 Python 程式碼示範外部活頁簿的建立過程：

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

### **取得圖表的外部資料來源活頁簿路徑**

有時圖表的資料是連結至外部 Excel 活頁簿，而非簡報內嵌的資料。使用 Aspose.Slides，您可以檢查圖表的資料來源，若為外部活頁簿，則讀取其完整路徑。

1. 建立 [Presentation](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/) 類別的實例。  
2. 依其索引取得投影片的參考。  
3. 取得圖表形狀的參考。  
4. 取得代表圖表資料來源的來源 ( [ChartDataSourceType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatasourcetype/) )。  
5. 檢查來源類型是否與外部活頁簿資料來源類型相符。

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

您可以像編輯內部活頁簿資料一樣編輯外部活頁簿的資料。若無法載入外部活頁簿，將拋出例外。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **從圖表快取復原活頁簿**

如果圖表使用的外部活頁簿缺失或無法取得，Aspose.Slides 可從簡報快取的資料中重建圖表活頁簿。請建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/)，然後在開啟簡報前，透過 [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/loadoptions/spreadsheet_options/) 啟用 [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)。

以下 Python 範例開啟一個圖表參考了無法取得的外部活頁簿的簡報，並透過 [Chart.chart_data](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chart/chart_data/) 與 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) 存取復原的資料：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # 在此讀取或修改復原的活頁簿資料。
```

如果外部活頁簿無法取得且已停用復原功能，Aspose.Slides 會拋出例外。僅在使用快取的圖表資料作為可接受的備援方案時才啟用復原，因為快取可能不包含最後一次更新簡報後對外部活頁簿所做的變更。

## **常見問題**

**我能判斷特定圖表是連結至外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/data_source_type/) 與 [外部活頁簿路徑](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/external_workbook_path/)，若來源是外部活頁簿，則可讀取完整路徑以確認使用的是外部檔案。

**是否支援外部活頁簿的相對路徑，且其儲存方式為何？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很方便；但請注意，簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享中的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源使用。然而，Aspose.Slides 不支援直接編輯遠端活頁簿——只能將其用作來源。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 檔案嗎？**

不會。簡報僅儲存 [外部檔案的連結](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/external_workbook_path/)，並於讀取資料時使用它。儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼做？**

Aspose.Slides 在建立連結時不接受密碼。常見做法是事先移除保護或準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/python-net/)），然後連結至該副本。

**多個圖表可以參照同一個外部活頁簿嗎？**

可以。每個圖表都會儲存自己的連結。若全部指向同一檔案，更新該檔案後，在下次載入資料時，所有圖表皆會反映該變更。