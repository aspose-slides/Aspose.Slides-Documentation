---
title: 使用 Python 在簡報圖表中自訂誤差線
linktitle: 誤差線
type: docs
url: /zh-hant/python-java/error-bar/
keywords:
- 誤差線
- 自訂值
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在圖表中新增和自訂誤差線——優化 PowerPoint 簡報中的資料視覺效果。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報圖表中處理誤差線。它展示了如何將誤差線新增至圖表系列、設定 X 和 Y 誤差線的屬性，並套用固定值、百分比以及自訂值等不同類型。

同時也示範了如何使用對應的資料點集合，為系列中的個別資料點指派自訂誤差線值。此外，本文還簡要說明了誤差線在匯出時的行為、它們與標記和資料標籤的相容性，以及在哪裡可以找到相關的 API 參考類別與列舉。

## **新增誤差線**

Aspose.Slides for Python via Java 提供了簡易的 API 來管理誤差線值。以下範例程式碼使用了固定值和百分比值類型。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的執行個體。
1. 在目標投影片上新增氣泡圖。
1. 存取第一個圖表系列，並設定 X 誤差線格式。
1. 存取第一個圖表系列，並設定 Y 誤差線格式。
1. 設定誤差線的值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    # 建立氣泡圖。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # 新增誤差線並設定其格式。
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # 儲存簡報。
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **新增自訂誤差線值**

Aspose.Slides for Python via Java 提供了簡易的 API 來管理自訂誤差線值。以下範例程式碼適用於當 [getValueType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/errorbarsformat/#getValueType) 回傳 [ErrorBarValueType.Custom](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/errorbarvaluetype/#Custom) 時。若要指定值，請對由系列方法 [getDataPoints](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#getDataPoints) 所回傳集合中的特定資料點使用 [getErrorBarsCustomValues](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues)。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別的執行個體。
1. 在目標投影片上新增氣泡圖。
1. 存取第一個圖表系列，並設定 X 誤差線格式。
1. 存取第一個圖表系列，並設定 Y 誤差線格式。
1. 存取圖表系列中的個別資料點，並設定它們的誤差線值。
1. 設定誤差線的值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# 建立 Presentation 類別的實例。
presentation = Presentation()
try:
    # 建立氣泡圖。
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # 新增自訂誤差線並設定其格式。
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # 存取圖表系列的資料點並設定其誤差線值來源。
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # 為圖表系列的資料點設定誤差線值。
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # 儲存簡報。
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**將簡報匯出為 PDF 或影像時，誤差線會發生什麼情況？**

它們會作為圖表的一部分進行渲染，並在轉換過程中與圖表的其他格式一起保留，前提是使用相容的版本或渲染器。

**誤差線可以與標記和資料標籤結合使用嗎？**

可以。誤差線是獨立的元素，與標記與資料標籤相容；如果元素重疊，可能需要調整格式。

**在哪裡可以找到用於操作誤差線之 API 的屬性與類別清單？**

於 API 參考文件中：[ErrorBarsFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/errorbarsformat/) 類別以及相關的 [ErrorBarType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/errorbartype/) 與 [ErrorBarValueType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/errorbarvaluetype/) 類別。