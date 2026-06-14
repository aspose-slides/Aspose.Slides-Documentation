---
title: 使用 Python 在簡報中管理圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/python-net/chart-workbook/
keywords:
- 圖表工作簿
- 圖表資料
- 工作簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部工作簿
- 外部資料
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "探索適用於 .NET 的 Python 版 Aspose.Slides：輕鬆管理 PowerPoint 與 OpenDocument 格式中的圖表工作簿，以簡化您的簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及如何為圖表值指定資料來源類型。

此外，本文還涵蓋了使用外部工作簿作為圖表資料來源的方式。範例說明了如何建立並指派外部工作簿、取得連結到圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**

Aspose.Slides 提供了讀寫圖表資料工作簿（包含使用 Aspose.Cells 編輯的圖表資料）的方法。**注意:** 圖表資料必須以相同方式組織，或具備與來源相似的結構。

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

## **將 WorkBook 儲存格設為圖表資料標籤**

有時需要直接從底層資料工作簿的儲存格取得圖表標籤。Aspose.Slides 允許將資料標籤繫結至特定工作簿儲存格，使標籤文字始終反映儲存格的值。以下範例顯示如何啟用「來自儲存格的值」標籤，並將所選標籤指向圖表工作簿中的自訂儲存格。

1. 建立 [Presentation](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片參考。  
1. 新增帶有範例資料的氣泡圖表。  
1. 取得圖表系列。  
1. 使用工作簿儲存格作為資料標籤。  
1. 儲存簡報。

以下 Python 程式碼示範如何將工作簿儲存格設為圖表資料標籤：

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

## **偵測不支援的嵌入式工作簿格式**

Aspose.Slides 不支援可在某些圖表中嵌入的 Excel 二進位工作簿 (.xlsb) 格式。您可以使用 [ChartData](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/) 上的 `embedded_workbook_type` 屬性，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/workbooktype/) 列舉，來偵測不支援的格式並跳過這些圖表。

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
            # 嵌入式工作簿為 .xlsb 格式，不受支援。
            continue

        # 在此讀取或修改圖表工作簿資料。
```

## **外部工作簿**

Aspose.Slides 支援使用外部工作簿作為圖表的資料來源。

### **設定外部工作簿**

透過 [ChartData.set_external_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以將外部工作簿指派給圖表作為資料來源。若外部工作簿已移動，此方法亦可更新其路徑。

雖然無法編輯儲存在遠端位置或資源上的工作簿資料，但仍可將這些工作簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

以下 Python 程式碼示範如何設定外部工作簿：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` 方法的 `update_chart_data` 參數決定是否載入 Excel 工作簿。

- 當 `update_chart_data` 設為 `False` 時，僅更新工作簿路徑；圖表資料不會從目標工作簿載入或重新整理。此設定適用於目標工作簿不存在或無法取得的情況。  
- 當 `update_chart_data` 設為 `True` 時，圖表資料會從目標工作簿載入並更新。

### **建立外部工作簿**

透過 [read_workbook_stream](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 與 [set_external_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以從頭建立外部工作簿，或將內部工作簿轉換為外部工作簿。

以下 Python 程式碼示範外部工作簿的建立流程：

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

### **取得圖表的外部資料來源工作簿路徑**

有時圖表的資料連結到外部 Excel 工作簿，而非簡報內嵌的資料。使用 Aspose.Slides，您可檢查圖表的資料來源，若為外部工作簿，便能讀取完整的工作簿路徑。

1. 建立 [Presentation](https://docs.aspose.com/slides/zh-hant/python-net/api-reference/aspose.slides/presentation/) 類別的實例。  
1. 依索引取得投影片參考。  
1. 取得圖表形狀的參考。  
1. 取得代表圖表資料來源的來源 ([ChartDataSourceType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatasourcetype/))。  
1. 檢查來源類型是否為外部工作簿資料來源類型。

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

您可以像編輯內部工作簿資料一樣編輯外部工作簿資料。若無法載入外部工作簿，將拋出例外。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**我可以判斷特定圖表是連結到外部工作簿還是嵌入式工作簿嗎？**

可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/data_source_type/) 與 [外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdata/external_workbook_path/); 若來源為外部工作簿，您可讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很方便；但請注意，簡報會將絕對路徑寫入 PPTX 檔案中。

**我可以使用位於網路資源/共享上的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端工作簿——只能將其用作來源。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

不會。簡報只會儲存一個「指向外部檔案」的連結，並於讀取資料時使用該連結。儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼做？**

Aspose.Slides 在建立連結時不接受密碼。常見做法是事先解除保護，或先產生已解密的副本（例如使用 [Aspose.Cells](/cells/python-net/)），再連結該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們指向同一個檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。