---
title: 使用 Python 自訂簡報圖表中的誤差棒
linktitle: 誤差棒
type: docs
url: /zh-hant/python-net/error-bar/
keywords:
- 誤差棒
- 自訂值
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在圖表中新增與自訂誤差棒，優化 PowerPoint 與 OpenDocument 簡報中的資料視覺呈現。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報圖表中使用誤差棒。它展示了如何將誤差棒新增至圖表系列、設定 X 與 Y 誤差棒的屬性，並套用不同的值類型，例如固定值、百分比及自訂值。

此外，本文還示範如何透過相應的資料點集合，為系列中的個別資料點指派自訂誤差棒值。另外，本文亦簡要說明誤差棒在匯出時的行為、與標記與資料標籤的相容性，以及在何處可以找到相關的 API 參考類別與列舉。

## **新增誤差棒**
Aspose.Slides for Python via .NET provides a simple API for managing error bar values. The sample code applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 在目標投影片上新增氣泡圖表。
1. 存取第一個圖表系列，並設定誤差棒 X 格式。
1. 存取第一個圖表系列，並設定誤差棒 Y 格式。
1. 設定棒的值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 建立空白簡報
with slides.Presentation() as presentation:
    # 建立氣泡圖表
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # 新增誤差棒並設定其格式
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # 儲存簡報
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```



## **新增自訂誤差棒值**
Aspose.Slides for Python via .NET provides a simple API for managing custom error bar values. The sample code applies when the **IErrorBarsFormat.ValueType** property is equal to **Custom**. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the **DataPoints** collection of series:

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別的實例。
1. 在目標投影片上新增氣泡圖表。
1. 存取第一個圖表系列，並設定誤差棒 X 格式。
1. 存取第一個圖表系列，並設定誤差棒 Y 格式。
1. 存取圖表系列的個別資料點，並為個別系列資料點設定誤差棒值。
1. 設定棒的值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 建立空白簡報
with slides.Presentation() as presentation:
    # 建立氣泡圖表
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # 新增自訂誤差棒並設定其格式
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # 存取圖表系列資料點並為個別點設定誤差棒值
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # 為圖表系列點設定誤差棒
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # 儲存簡報
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常見問題**

**將簡報匯出為 PDF 或圖像時，誤差棒會發生什麼情況？**

它們會作為圖表的一部分進行繪製，並在轉換過程中與其他圖表格式一起保留，前提是使用相容的版本或渲染器。

**誤差棒可以與標記和資料標籤結合使用嗎？**

可以。誤差棒是獨立的元素，且與標記和資料標籤相容；如果元素重疊，可能需要調整格式。

**在哪裡可以找到用於操作誤差棒的屬性與列舉清單？**

於 API 參考文件中： [ErrorBarsFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/errorbarsformat/) 類別以及相關的列舉 [ErrorBarType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/errorbartype/) 與 [ErrorBarValueType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/errorbarvaluetype/)。