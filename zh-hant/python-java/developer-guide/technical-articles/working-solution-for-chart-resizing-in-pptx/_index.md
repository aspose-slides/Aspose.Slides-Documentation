---
title: 在 PPTX 中圖表調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 嵌入 Excel OLE 物件時，修正 PPTX 中意外的圖表調整大小問題。設定固定圖表尺寸以保持圖表與 OLE 框尺寸一致。"
---
## **背景**

使用 Aspose 元件於 PowerPoint 簡報中以 OLE 物件嵌入的 Excel 圖表，在首次啟用後可能會改變大小。這會導致圖表在啟用前後的外觀出現明顯差異。本文說明產生調整大小的原因，並展示如何透過將固定圖表尺寸與 OLE 框匹配來防止此情況。

在[Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/zh-hant/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我們說明了如何使用 Aspose.Cells for Python via Java 建立 Excel 圖表，並使用 Aspose.Slides for Python via Java 將其嵌入 PowerPoint 簡報。為了解決[object preview issue](/slides/zh-hant/python-java/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表影像指派給圖表的 OLE 物件框。在輸出簡報中，當您雙擊顯示圖表影像的 OLE 物件框時，Excel 圖表會被啟用。使用者可以編輯嵌入的 Excel 活頁簿，然後點擊已啟用的活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會改變，且調整比例取決於 OLE 物件框和嵌入的 Excel 活頁簿的原始大小。

## **調整大小的原因**

嵌入的 Excel 活頁簿有自己的視窗尺寸，Excel 在物件首次啟用時會嘗試保留該尺寸。投影片上的 OLE 框則有其自行定義的尺寸。當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商物件的大小，以在嵌入過程中維持其比例。因此，活頁簿視窗與 OLE 框之間的差異可能會導致物件重新調整大小。

## **可行解決方案**

將圖表的大小與投影片上的 OLE 框相匹配，並使圖表尺寸獨立於活頁簿視窗。本解決方案適用於新簡報或既有範本。

此範例需要 Aspose.Cells for Python via Java 與 Aspose.Slides for Python via Java。它在活動的圖表工作表上建立簡單的柱狀圖，並以 XLS 格式嵌入活頁簿。未指派圖表預覽影像；圖表會在 PowerPoint 中啟用 OLE 物件時顯示。

此範例建立一個新的簡報，其中的 OLE 框尺寸為 9.5 × 4 英吋，且距左邊緣 0.5 英吋、距頂部 1 英吋。投影片座標與尺寸使用點作為單位（每英吋 72 點）。若使用既有簡報，請參閱[Use a Template](#use-a-template)。

## **設定固定圖表大小**

將[setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) 設為 false，使圖表尺寸獨立於活頁簿視窗。透過[setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) 與[setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height) 設定[getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) 的尺寸，並以每英吋 96 像素的比例將點轉換為像素：684 × 288 點的框對應於 912 × 384 像素的圖表。將[setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) 設為 [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/) 的 CUSTOM 值。範例使用[addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) 嵌入活頁簿，並儲存一個具 9.5 × 4 英吋 OLE 框的簡報。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # 投影片座標與尺寸以點為單位 (每英吋 72 點)。
        width = 684.0  # 9.5 英吋。
        height = 288.0  # 4 英吋。

        chart.setSizeWithWindow(False)
        # 用每英吋 96 像素將點轉換為圖表像素。
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```
## **使用範本**

對於既有簡報，大小設定邏輯相同。要調整範例：

1. 載入範本簡報，而非建立空白簡報。
1. 確認第一張投影片至少有三個圖形，然後將索引為 2 的圖形作為佔位元件使用。
1. 從該圖形取得框的寬度與高度，而非使用固定值 684 與 288。保持大小計算不變。
1. 在佔位元件的位置加入 OLE 框，而非使用固定座標 36 與 72。
1. 在儲存簡報前移除佔位元件。

## **常見問題**

**為何我的嵌入式 Excel 圖表在 PowerPoint 中啟用後會改變大小？**

這是因為 Excel 在首次啟用時會嘗試恢復原始視窗大小，而 PowerPoint 中的 OLE 物件框則有其自行的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致調整大小。

**如何保持圖表與 OLE 框的尺寸一致？**

設定與 OLE 框相匹配的固定圖表尺寸，並在嵌入活頁簿前使用自訂的圖表列印大小。上述範例展示了所需的設定與單位換算。

**僅匹配活頁簿視窗大小是否足夠？**

僅匹配活頁簿視窗大小無法可靠防止 OLE 框在啟用後改變尺寸。請使用範例中示範的固定圖表尺寸。

**此解決方案是否同時適用於基於範本的簡報與新簡報？**

是的。對於範本，使用佔位元件的尺寸與位置。對於新簡報，直接指定框的尺寸與位置。

**我能將此範例應用於其他試算表程式所建立的圖表嗎？**

此範例使用 Aspose.Cells 建立的 Excel 活頁簿，未示範其他試算表程式的啟用行為。

## **相關章節**

- [建立 Excel 圖表並以 OLE 物件嵌入簡報](/slides/zh-hant/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)