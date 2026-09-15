---
title: PPTX 中圖表調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 嵌入 Excel OLE 物件時，修復 PPTX 中意外的圖表調整大小問題。了解兩種方法並配合程式碼，保持尺寸一致。"
---
## **背景**

已觀察到，透過 Aspose 元件將 Excel 圖表作為 OLE 物件嵌入 PowerPoint 簡報後，圖表在首次啟動後會被調整為未指定的比例。此行為會造成圖表在啟動前後的視覺差異。Aspose 團隊已詳細調查此問題並找到了解決方案。本文說明問題的原因以及相應的修復方法。

在[previous article](/slides/zh-hant/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我們說明了如何使用 Aspose.Cells for Python via Java 建立 Excel 圖表，並使用 Aspose.Slides for Python via Java 將其嵌入 PowerPoint 簡報。為了解決[object preview issue](/slides/zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表圖像指派給圖表的 OLE 物件框架。在輸出簡報中，雙擊顯示圖表圖像的 OLE 物件框架會啟動 Excel 圖表。最終使用者可以在底層 Excel 活頁簿中進行任何變更，然後點擊已啟動的活頁簿之外的區域返回相應的投影片。使用者返回投影片時，OLE 物件框架的大小會發生變化，且調整比例會依據 OLE 物件框架與嵌入的 Excel 活頁簿的原始大小而異。

## **調整大小的原因**

由於 Excel 活頁簿有自己的視窗大小，它會嘗試在首次啟動時保留原始大小。而 OLE 物件框架則有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，並在嵌入過程中保持正確的比例。根據 Excel 視窗大小與 OLE 物件框架的大小或位置之差異，會發生調整。

## **可行的解決方案**

使用 Aspose.Slides for Python via Java 建立 PowerPoint 簡報有兩種可能的情境。

**情境 1：**基於現有範本建立簡報。

**情境 2：**從頭建立簡報。

此處提供的解決方案同時適用於兩種情境。所有解決方案的核心相同：**嵌入的 OLE 物件的視窗大小應與 PowerPoint 投影片中的 OLE 物件框架相匹配**。以下將討論兩種實作方式。

## **第一種做法**

在此做法中，我們將學習如何設定嵌入 Excel 活頁簿的視窗大小，使其與 PowerPoint 投影片中 OLE 物件框架的大小相同。

**情境 1**

假設我們已定義範本，並希望基於該範本建立簡報。假設範本的第 2 個索引處有一個形狀，我們想在此放置包含嵌入 Excel 活頁簿的 OLE 框架。此情境下，OLE 物件框架的大小是預先定義的——與第 2 個索引的形狀大小相同。我們只需要將活頁簿的視窗大小設定為該形狀的大小。以下程式碼片段即為用途：

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 載入包含圖表的 Excel 活頁簿。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # 設定活頁簿視窗尺寸（單位為英吋），PowerPoint 每英吋使用 72 點。
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # 將活頁簿儲存至記憶體串流。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 建立包含嵌入 Excel 資料的 OLE 物件框架。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**情境 2**

假設我們想從頭建立簡報，並在其中加入任意大小、內嵌 Excel 活頁簿的 OLE 物件框架。以下程式碼片段在投影片上於 x = 0.5 吋、y = 1 吋的位置建立一個高度 4 吋、寬度 9.5 吋的 OLE 物件框架，然後將 Excel 活頁簿視窗設為同樣的尺寸——高度 4 吋、寬度 9.5 吋。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 載入包含圖表的 Excel 活頁簿。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 英吋 (4 * 72).
    desired_width = 684  # 9.5 英吋 (9.5 * 72).

    # 使用視窗定義圖表大小。
    chart.setSizeWithWindow(True)

    # 設定活頁簿視窗尺寸（單位為英吋），PowerPoint 每英吋使用 72 點。
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # 將活頁簿儲存至記憶體串流。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 建立包含嵌入 Excel 資料的 OLE 物件框架。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **第二種做法**

在此做法中，我們將學習如何設定嵌入 Excel 活頁簿中圖表的大小，使其與 PowerPoint 投影片中 OLE 物件框架的大小相同。當圖表大小事先已知且不會變更時，此做法特別有用。

**情境 1**

假設我們已定義範本，並希望基於該範本建立簡報。假設範本的第 2 個索引處有一個形狀，我們打算在此放置包含嵌入 Excel 活頁簿的 OLE 框架。此情境下，OLE 框架的大小是預先定義的——與第 2 個索引的形狀大小相同。我們只需要將活頁簿中圖表的大小設定為該形狀的大小。以下程式碼片段即為用途：

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpime.JClass("java.io.ByteArrayOutputStream")

# 載入包含圖表的 Excel 活頁簿。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # 定義不使用視窗的圖表大小。
    chart.setSizeWithWindow(False)

    # 以像素設定圖表大小（Excel 每英吋 96 像素）。
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # 定義圖表列印尺寸。
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # 將活頁簿儲存至記憶體串流。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 建立包含嵌入 Excel 資料的 OLE 物件框架。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**情境 2**：

假設我們想從頭建立簡報，並在其中加入任意大小、內嵌 Excel 活頁簿的 OLE 物件框架。以下程式碼片段在投影片上於 x = 0.5 吋、y = 1 吋的位置建立一個高度 4 吋、寬度 9.5 吋的 OLE 物件框架，並將相應的圖表大小設為同樣的尺寸：高度 4 吋、寬度 9.5 吋。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# 載入包含圖表的 Excel 活頁簿。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 英吋 (4 * 72).
    desired_width = 684  # 9.5 英吋 (9.5 * 72).

    # 定義不使用視窗的圖表大小。
    chart.setSizeWithWindow(False)

    # 以像素設定圖表大小（Excel 每英吋 96 像素）。
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # 將活頁簿儲存至記憶體串流。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 建立包含嵌入 Excel 資料的 OLE 物件框架。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **結論**

修正圖表調整大小問題有兩種做法。選擇哪種做法取決於需求與使用情境。無論是從範本建立還是從頭建立簡報，兩種做法的運作方式相同。此外，此解決方案對 OLE 物件框架的大小沒有任何限制。

## **常見問題**

**為什麼嵌入的 Excel 圖表在 PowerPoint 中啟動後會變更大小？**

這是因為 Excel 在首次啟動時會嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框架則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以保持比例，從而導致調整。

**是否可以完全防止此調整問題？**

可以。透過在嵌入前將 Excel 活頁簿視窗大小或圖表大小與 OLE 物件框架大小對齊，即可保持圖表大小一致。

**我該選擇設定活頁簿視窗大小還是設定圖表大小？**

若希望保留活頁簿的長寬比例且可能之後需要調整，請使用 **Approach 1 (window size)**。若圖表尺寸固定且嵌入後不會變更，請使用 **Approach 2 (chart size)**。

**這些方法是否同時適用於基於範本的簡報與全新簡報？**

是的。兩種做法對於從範本建立以及從頭建立的簡報均適用。

**OLE 物件框架的大小有上限嗎？**

沒有。只要框架尺寸與活頁簿或圖表尺寸相匹配，即可設定任意大小。

**我可以將這些方法用於其他試算表程式所建立的圖表嗎？**

範例針對使用 Aspose.Cells 建立的 Excel 圖表，但原則同樣適用於其他支援 OLE 且提供相似尺寸設定選項的試算表程式。

## **相關章節**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/zh-hant/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)