---
title: 使用 Python 在簡報中自訂圖表資料表
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
description: "使用 Python 透過 Java 的 Aspose.Slides 來自訂 PPT 與 PPTX 的圖表資料表，以提升簡報的效率與吸引力。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表資料表。它展示了如何為圖表顯示資料表，並透過設定字型屬性（例如粗體樣式和字型高度）來自訂文字格式。範例示範了建立簡報、加入圖表、啟用圖表資料表、套用字型設定，並儲存更新後的簡報。

此外，本文還提供了關於在圖表資料表中顯示圖例鍵、匯出時是否保留資料表、處理從現有簡報或範本載入的圖表以及辨識已啟用資料表的圖表等常見問題的簡要回答。

## **為圖表資料表設定字型屬性**

Aspose.Slides for Python via Java 允許您顯示圖表的資料表並變更其文字的字型屬性。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別。
1. 將圖表新增至投影片。
1. 顯示圖表的資料表。
1. 設定資料表文字的粗體樣式與字型高度。
1. 儲存已修改的簡報。

以下範例示範這些步驟。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# 建立空白簡報。
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**我可以在圖表資料表的值旁顯示小的圖例鍵嗎？**

可以。資料表支援 [legend keys](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datatable/#setShowLegendKey)，您可以開啟或關閉它們。

**匯出簡報為 PDF、HTML 或影像時，資料表會保留嗎？**

會。Aspose.Slides 會將圖表渲染為投影片的一部分，因此匯出的 [PDF](/slides/zh-hant/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)/[image](/slides/zh-hant/python-java/convert-powerpoint-to-png/) 皆包含帶有資料表的圖表。

**從範本檔案載入的圖表是否支援資料表？**

會。對於任何從現有簡報或範本載入的圖表，您都可以使用圖表的屬性檢查並變更資料表是否[是否顯示](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#hasDataTable)。

**我該如何快速找出檔案中哪些圖表已啟用資料表？**

檢查每個圖表的屬性，看其資料表是否[是否顯示](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/#hasDataTable)，然後遍歷投影片以找出已啟用資料表的圖表。