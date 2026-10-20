---
title: PPTX 圖表尺寸調整的可行解決方案
type: docs
weight: 60
url: /zh-hant/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表尺寸調整
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- Python via .NET
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 嵌入的 Excel OLE 物件時，修復 PPTX 中意外的圖表尺寸調整。設定固定圖表尺寸，以確保圖表與 OLE 框的大小保持一致。"
---
## **概述**

使用 Aspose 元件將 Excel 圖表作為 OLE 物件嵌入 PowerPoint 簡報時，圖表在首次啟用後可能會改變大小。這會導致圖表在啟用前後外觀出現明顯差異。本文說明為何會發生重新調整大小，以及如何透過使固定圖表尺寸與 OLE 框匹配來防止此問題。

在[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我們說明了如何使用 Aspose.Cells for Python via .NET 建立 Excel 圖表，並使用 Aspose.Slides for Python via .NET 將其嵌入 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/python-net/object-preview-issue-when-adding-oleobjectframe/) ，我們將圖表影像指派給圖表的 OLE 物件框。在輸出簡報中，當您雙擊顯示圖表影像的 OLE 物件框時，Excel 圖表會被啟用。使用者可以編輯嵌入的 Excel 活頁簿，然後透過點擊已啟用活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會改變，且重新調整比例會因 OLE 物件框與嵌入的 Excel 活頁簿的原始尺寸而異。

## **大小變更的原因**

嵌入的 Excel 活頁簿具有自己的視窗尺寸，Excel 在物件首次啟用時會嘗試保留此尺寸。簡報上的 OLE 框則有自行定義的尺寸。當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商物件的大小，以在嵌入過程中維持其比例。因此，活頁簿視窗與 OLE 框之間的差異可能導致物件重新調整大小。

## **可行的解決方案**

將圖表尺寸與投影片上的 OLE 框相匹配，並使圖表尺寸獨立於活頁簿視窗。此解決方案適用於新簡報或已有範本。

此範例需要 Aspose.Cells for Python via .NET 與 Aspose.Slides for Python via .NET。它在活動的圖表工作表上建立簡單的柱狀圖，並將活頁簿以 XLS 格式嵌入。未指派圖表預覽影像；圖表會在 PowerPoint 中啟用 OLE 物件時顯示。

此範例建立一個新的簡報，於投影片上放置一個 9.5 × 4 吋的 OLE 框，框左側距離 0.5 吋，頂部距離 1 吋。投影片的坐標與尺寸以點為單位（每英吋 72 點）。如需在現有簡報中使用，請參閱[使用範本](#use-a-template)。

## **設定固定圖表大小**

將[size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) 設為 false，使圖表尺寸獨立於活頁簿視窗。透過[width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) 與[height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/) 設定[chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) 的尺寸，並以每英吋 96 像素將點轉換為像素：寬 684 × 高 288 點的框相當於寬 912 × 高 384 像素的圖表。將[print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) 設為[PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/) 的 CUSTOM 值。範例使用[add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) 嵌入活頁簿，並以 9.5 × 4 吋的 OLE 框儲存簡報。

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 投影片座標與尺寸以點為單位（每英吋 72 點）。
    width = 684.0  # 9.5 吋。
    height = 288.0  # 4 吋。

    chart.size_with_window = False
    # 以每英吋 96 像素將點轉換為圖表像素。
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **使用範本**

現有簡報的尺寸邏輯相同。要套用此範例：

1. 載入範本簡報，而不是建立空白簡報。
2. 確認第一張投影片至少包含三個圖形，然後使用索引為 2 的圖形作為佔位元。
3. 從該圖形取得框的寬度與高度，而不是使用固定值 684 與 288。保持尺寸計算不變。
4. 在佔位元的位置加入 OLE 框，而不是使用固定座標 36 與 72。
5. 儲存簡報前移除佔位元。

## **常見問題**

**為何我的嵌入式 Excel 圖表在 PowerPoint 中啟用後會改變大小？**

這是因為 Excel 在首次啟用時會嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框有其自身的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致重新調整大小。

**如何讓圖表與 OLE 框的尺寸保持一致？**

設定與 OLE 框相匹配的固定圖表尺寸，並在嵌入活頁簿前使用自訂圖表列印大小。上方範例展示了所需的設定與單位換算。

**僅匹配活頁簿視窗大小是否足夠？**

僅匹配活頁簿視窗大小並無法可靠防止 OLE 框在啟用後變更大小。請如範例所示使用固定圖表尺寸。

**此解決方案是否同時適用於基於範本的簡報和全新簡報？**

是的。對於範本，使用佔位元的尺寸與位置。對於新簡報，直接指定框的尺寸與位置。

**我可以將此範例用於其他試算表程式所建立的圖表嗎？**

此範例使用 Aspose.Cells 建立的 Excel 活頁簿。未示範其他試算表程式的啟用行為。

## **相關章節**

- [在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [使用 PowerPoint 加載項自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)