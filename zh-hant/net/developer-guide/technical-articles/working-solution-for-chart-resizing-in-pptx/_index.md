---
title: PPTX 中圖表尺寸變更的可行解決方案
type: docs
weight: 60
url: /zh-hant/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表尺寸變更
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 嵌入 Excel OLE 物件時，修正 PPTX 中圖表意外變更尺寸的問題。設定固定圖表尺寸，以保持圖表與 OLE 框尺寸一致。"
---
## **背景**

在 PowerPoint 簡報中以 Aspose 元件嵌入為 OLE 物件的 Excel 圖表，在第一次啟用後可能會改變大小。這會導致圖表在啟用前後的外觀出現明顯差異。本文說明為什麼會發生尺寸變更，並示範透過將固定圖表尺寸與 OLE 框匹配來防止此問題。

在[在簡報中建立 Excel 圖表並嵌入為 OLE 物件](/slides/zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我們說明了如何使用 Aspose.Cells for .NET 建立 Excel 圖表，並使用 Aspose.Slides for .NET 將其嵌入 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表影像指派給圖表的 OLE 物件框。於輸出簡報中，當您雙擊顯示圖表影像的 OLE 物件框時，Excel 圖表會被啟用。使用者可以編輯嵌入的 Excel 活頁簿，然後點擊工作簿外部返回投影片。使用者返回投影片時，OLE 物件框的大小會發生變化，且縮放比例取決於 OLE 物件框與嵌入的 Excel 活頁簿的原始大小。

## **尺寸變更的原因**

嵌入的 Excel 活頁簿有其自身的視窗尺寸，Excel 會在物件首次啟用時嘗試保留該尺寸。投影片上的 OLE 框則有獨立定義的尺寸。當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商物件的大小，以在嵌入過程中維持其比例。因此，活頁簿視窗與 OLE 框之間的差異會導致物件重新調整大小。

## **可行的解決方案**

將圖表尺寸與投影片上的 OLE 框匹配，並使圖表尺寸獨立於活頁簿視窗。此解決方案可用於新簡報或現有範本。

此範例需要 Aspose.Cells for .NET 與 Aspose.Slides for .NET。它會在活動圖表工作表上建立簡單的柱狀圖，並以 XLS 格式嵌入活頁簿。未指派圖表預覽影像；圖表會在 PowerPoint 中啟用 OLE 物件時顯示。

範例會建立一個新的簡報，內含 9.5 × 4 吋的 OLE 框，該框距左側 0.5 吋、距上方 1 吋。投影片座標與尺寸以點為單位（每吋 72 點）。如需在現有簡報中使用，請參閱[使用範本](#use-a-template)。

## **設定固定圖表尺寸**

將[SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) 設為 false，使圖表尺寸獨立於活頁簿視窗。透過[Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) 與[Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/) 設定[ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) 的尺寸，並以每吋 96 像素將點轉換為像素：684 × 288 點的框相當於 912 × 384 像素的圖表。將[PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) 設為[PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/) 的 Custom 值。範例使用[AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) 嵌入活頁簿，並以 9.5 × 4 吋的 OLE 框儲存簡報。

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// 投影片座標與尺寸以點為單位（每吋 72 點）。
var width = 684f; // 9.5 英吋。
var height = 288f; // 4 英吋。

chart.SizeWithWindow = false;
// 以每吋 96 像素將點轉換為圖表像素。
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **使用範本**

現有簡報的尺寸邏輯相同。調整範例如下：

1. 載入範本簡報，而非建立空白簡報。
1. 確認第一張投影片至少有三個圖形，然後使用索引 2 的圖形作為佔位元。
1. 從該圖形取得框的寬度與高度，而非使用固定值 684 與 288。保持尺寸計算不變。
1. 將 OLE 框加入佔位元的位置，而非使用固定座標 36 與 72。
1. 儲存簡報前移除佔位元。

## **常見問題**

**為什麼嵌入的 Excel 圖表在 PowerPoint 中啟用後會改變大小？**

因為 Excel 會在首次啟用時嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致重新調整大小。

**如何保持圖表與 OLE 框的尺寸一致？**

設定與 OLE 框匹配的固定圖表尺寸，並在嵌入活頁簿前使用自訂圖表列印尺寸。上面的範例展示了所需的設定與單位換算。

**僅匹配活頁簿視窗尺寸是否足夠？**

僅匹配活頁簿視窗尺寸無法可靠防止 OLE 框在啟用後改變大小。請使用如範例所示的固定圖表尺寸。

**此解決方案是否同時適用於基於範本的簡報與新簡報？**

是。對於範本，使用佔位元的尺寸與位置。對於新簡報，直接指定框的尺寸與位置。

**我可以將此範例用於其他試算表程式所建立的圖表嗎？**

此範例使用 Aspose.Cells 建立的 Excel 活頁簿。它未示範其他試算表程式的啟用行為。

## **相關章節**

- [在簡報中建立 Excel 圖表並嵌入為 OLE 物件](/slides/zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [使用 PowerPoint 外掛程式自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)