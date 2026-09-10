---
title: 使用 Python via Java 在簡報中自訂圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/python-java/pie-chart/
keywords:
- 圓餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python via Java 中建立並自訂圓餅圖，並可匯出至 PowerPoint，讓您在數秒內提升資料敘事效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示如何為 Pie of Pie 與 Bar of Pie 圖表設定第二圖層選項，以及如何為標準圓餅圖啟用自動切片著色。

範例側重於實用的圖表自訂步驟，例如將圖表加入投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圖表的第二圖層選項**

Aspose.Slides for Python via Java 支援 Pie of Pie 與 Bar of Pie 圖表的第二圖層選項。本節說明如何使用 Aspose.Slides 指定這些選項。請依照以下步驟：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 物件。
1. 將圖表新增至投影片。
1. 指定圖表的第二圖層選項。
1. 將簡報寫入磁碟。

以下範例設定 Pie of Pie 圖表的不同屬性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    # 將圖表新增至投影片。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # 設定不同的屬性。
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # 將簡報寫入磁碟。
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **設定自動圓餅圖切片顏色**

Aspose.Slides for Python via Java 提供簡易的 API 來設定自動圓餅圖切片顏色。以下範例示範如何套用這些設定。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的實例。
1. 存取第一張投影片。
1. 新增一個帶有預設資料的圖表。
1. 設定圖表標題。
1. 設定圖表資料工作表的索引。
1. 取得圖表資料工作簿。
1. 刪除預設的系列與類別。
1. 新增類別。
1. 新增系列。
1. 設定新系列顯示數值。

將已修改的簡報寫入 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    # 使用預設資料新增圖表。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # 設定圖表標題。
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # 設定圖表資料工作表的索引。
    default_worksheet_index = 0

    # 取得圖表資料工作簿。
    workbook = chart.getChartData().getChartDataWorkbook()

    # 刪除預設的系列與類別。
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # 新增類別。
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # 新增系列。
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # 填入系列資料。
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # 設定新系列顯示數值。
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**是否支援 'Pie of Pie' 與 'Bar of Pie' 變體？**

是的，程式庫[支援](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/charttype/) 圓餅圖的第二圖層，包括 'Pie of Pie' 與 'Bar of Pie' 類型。

**我可以僅將圖表匯出為影像（例如 PNG）嗎？**

是的，您可以[將圖表本身匯出為影像](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage)（例如 PNG），而無需匯出整個簡報。