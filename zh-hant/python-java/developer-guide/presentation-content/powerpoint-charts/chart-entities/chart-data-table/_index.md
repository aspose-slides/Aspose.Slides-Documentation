---
title: 使用 Python 自訂簡報中的圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/python-java/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字型屬性
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中自訂圖表資料表的字型、邊框和圖例鍵。"
---
## **概覽**

Aspose.Slides for Python via Java 允許您顯示圖表的資料表並自訂其文字格式、邊框和圖例鍵。本文說明如何啟用資料表、格式化文字、控制每種邊框類型，以及顯示或隱藏圖例鍵。範例會將設定好的圖表儲存為 PPTX 檔。

## **設定字型屬性**

若要顯示圖表的資料表，請將 `True` 傳遞給 [setDataTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setDataTable)。使用 [getChartDataTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#getChartDataTable) 取得資料表並設定其文字格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入簡報。
1. 在第一張投影片上新增叢集柱狀圖。
1. 啟用圖表的資料表。
1. 使用 [setFontBold](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setFontBold) 啟用粗體，並將 `20` 傳遞給 [setFontHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/baseportionformat/#setFontHeight) 設定為 20 點文字。
1. 儲存已修改的簡報。

以下範例需要工作目錄中有至少一張投影片的 `test.pptx`。它會在位置 (50, 50) 添加一個使用預設資料的圖表，寬度為 600 點，高度為 400 點。儲存的 `output.pptx` 會包含已啟用資料表且套用指定字型設定的圖表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **自訂資料表邊框**

使用 [Chart.setDataTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setDataTable) 啟用資料表，並透過 [Chart.getChartDataTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#getChartDataTable) 取得。您可以獨立控制三種邊框類型：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datatable/#setBorderHorizontal) 控制水平儲存格邊框。
- [setBorderVertical](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datatable/#setBorderVertical) 控制垂直儲存格邊框。
- [setBorderOutline](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datatable/#setBorderOutline) 控制資料表的外框。

將 `True` 傳遞給每個方法即可顯示其邊框，傳遞 `False` 則隱藏。以下範例建立一個使用預設資料的叢集柱狀圖，顯示水平邊框與外框，且隱藏垂直邊框。此範例不需要輸入檔案。圖表的位置與尺寸以點為單位指定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下比較在四種情況下皆使用相同的圖表資料與圖例鍵設定。從全部啟用邊框開始，每個後續變體僅停用一種邊框設定。左下角的變體與範例中的邊框設定相同。

![所有邊框已啟用、未顯示水平邊框、未顯示垂直邊框、未顯示外框的圖表資料表](data-table-borders.png)

## **顯示或隱藏圖例鍵**

圖例鍵是資料表中系列名稱旁的小型彩色標記。它們可協助讀者將每列對應到圖表的系列。將 `True` 傳遞給 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datatable/#setShowLegendKey) 以顯示這些標記，或傳遞 `False` 隱藏它們。

圖表的獨立圖例由 [Chart.setLegend](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setLegend) 控制。這兩項設定彼此獨立：隱藏獨立圖例不會影響資料表內的鍵，隱藏資料表的鍵亦不會隱藏獨立圖例。

以下範例建立一個使用預設資料的圖表，啟用其資料表，並在顯示圖例鍵的同時隱藏獨立圖例。所有資料表邊框皆明確啟用。此範例不需要輸入簡報。若僅要隱藏資料表的鍵，請將 `False` 傳遞給 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datatable/#setShowLegendKey)。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下比較展示同一資料表在圖例鍵啟用與停用的情況。所有邊框仍保持啟用，且獨立圖例在兩種情況下皆被隱藏。

![左側顯示圖例鍵、右側隱藏圖例鍵的圖表資料表](data-table-legend-keys.png)

## **常見問題**

**我可以在圖表的資料表中顯示圖例鍵嗎？**

可以。將 `True` 傳遞給 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datatable/#setShowLegendKey) 以顯示圖例鍵，或傳遞 `False` 隱藏。

**匯出簡報為 PDF、HTML 或圖片時，資料表會被保留嗎？**

會。Aspose.Slides 會在匯出至 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)、或 [images](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 時，將圖表及其顯示的資料表作為投影片的一部份進行渲染。

**我可以在從範本載入的圖表中使用資料表嗎？**

可以。對於從既有簡報或範本中載入的圖表，請使用 [hasDataTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#hasDataTable) 與 [setDataTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#setDataTable) 來檢查或變更其資料表是否顯示。

**我該如何找出已啟用資料表的圖表？**

遍歷每張投影片上的形狀，辨識出圖表，然後呼叫其 [hasDataTable](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#hasDataTable) 方法。返回 `True` 表示該圖表已啟用資料表。