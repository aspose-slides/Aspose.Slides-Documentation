---
title: 建立 Excel 圖表並以 OLE 物件嵌入簡報中
type: docs
weight: 50
url: /zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Cells for .NET 建立 Excel 圖表，並將活頁簿嵌入至使用 Aspose.Slides 的 PowerPoint 簡報中，並包含圖表預覽。"
---
## **概觀**

本文說明如何使用 Aspose.Cells for .NET 建立 Excel 柱狀圖，並將其活頁簿嵌入至使用 Aspose.Slides for .NET 的 PowerPoint 簡報中。嵌入的活頁簿同時包含來源資料與圖表。單獨的 PNG 預覽會在 OLE 物件啟用之前於投影片上顯示圖表。

結果是一個嵌入的 Excel 物件，而非本機 PowerPoint 圖表。透過 OLE 編輯活頁簿需要支援 OLE 啟動且安裝相容 Excel 的桌面應用程式。

## **先決條件**

在 C# 專案中加入 Aspose.Cells for .NET 與 Aspose.Slides for .NET 的參考。此範例使用頂層陳述式，需 C# 9 或更高版本。產生簡報時不需要安裝 Microsoft Office。

不需要任何輸入檔案：範例在記憶體中建立資料與圖表，然後將 `OutputChart.pptx` 寫入目前工作目錄。於非評估模式執行時需為兩個產品套用授權。

## **嵌入運作方式**

1. 建立包含資料工作表與圖表工作表的活頁簿。
2. 將圖表工作表設為使用中，使活頁簿開啟時直接顯示圖表。
3. 設定活頁簿的 OLE 顯示範圍，並將圖表渲染成 PNG。
4. 將活頁簿以 XLSX 格式儲存於記憶體，並將其位元組嵌入投影片中。
5. 將 PNG 指派為 OLE 物件的預覽，並將簡報儲存為 PPTX。

活頁簿顯示範圍與投影片框架的角色不同。[SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) 使用零基礎的起始/結束列和欄索引。[ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) 則使用上方列、左側欄、下方列與右側欄。範例使用第 55 列與第 25 欄作為右下邊界；這些數值屬於版面配置的選擇，而非資料列或欄的數量。

投影片框架使用點（points）為單位。範例將其調整至投影片內並置中，同時保留 PNG 的長寬比，而不是將預覽圖拉伸以填滿投影片。

## **建立與嵌入圖表**

下列完整範例為 `DataSheet` 填入四列五欄的數值。每一列會成為圖表的一個系列。`ChartSheet` 於活頁簿儲存前被選為使用中工作表。

活頁簿明確儲存為 XLSX，與傳遞給 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) 的 `xlsx` 副檔名相符。PNG 直接從其串流載入，未經中介的 bitmap 轉換。透過 [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) 指派即會取代預設的 OLE 佔位符。

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// 渲染圖表預覽，並分別序列化可編輯的活頁簿。
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// 將預覽圖適配於投影片內，保持長寬比不變。
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **預期結果**

`OutputChart.pptx` 包含一張投影片，內有嵌入的 Excel 活頁簿與圖表預覽。活頁簿包含原始資料與四個系列的柱狀圖。預覽圖置中於投影片上，且保持其比例。

![Excel 柱狀圖作為嵌入活頁簿的預覽](excel-chart-ole-preview.png)

在具備 Excel 的相容桌面 PowerPoint 環境中，雙擊物件即可啟用並編輯嵌入的活頁簿。啟用與編輯取決於主機應用程式的 OLE 支援與安全性設定。

## **常見問題**

**為什麼需要預覽圖片？**

嵌入的活頁簿與投影片預覽屬於分離的內容。提供圖表圖片，使投影片顯示圖表而非預設的「EMBEDDED OLE OBJECT」佔位符。請參閱 [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/)。

**當我在程式碼中變更活頁簿時，預覽會自動更新嗎？**

將預覽視為快照。當以程式方式更新活頁簿資料時，須重新產生圖表圖像，並同時取代預覽與嵌入的活頁簿資料。

**我可以使用 XLS 而非 XLSX 嗎？**

可以。將活頁簿儲存為 XLS 格式，並使用 `xls` 作為嵌入資料的副檔名。副檔名必須與實際活頁簿格式相符，僅變更副檔名並不會轉換資料。

**為什麼物件在啟動後會改變大小？**

主機應用程式在啟動活頁簿時可能會更新 OLE 物件的呈現。活頁簿的 OLE 顯示範圍與投影片框架尺寸皆會影響。請參閱 [PPTX 中圖表調整大小的可行解決方案](/slides/zh-hant/net/working-solution-for-chart-resizing-in-pptx/)。

## **相關章節**

- [PPTX 中圖表調整大小的可行解決方案](/slides/zh-hant/net/working-solution-for-chart-resizing-in-pptx/)
- [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/)
- [使用 PowerPoint 外掛自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)