---
title: 工作表調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 影像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "修復簡報中 Excel 工作表的 OLE 調整大小問題：提供兩種方法保持物件框一致——縮放框架或縮放工作表——適用於 PPT 與 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

Excel 工作表作為 OLE 物件嵌入 PowerPoint 簡報時，使用 Aspose 元件可能在首次啟動後意外調整大小。此行為會在 OLE 物件啟動前後產生明顯的視覺差異。本文說明此問題並描述兩種解決方式。

{{% /alert %}} 

## **背景**

在文章 [Manage OLE](/slides/zh-hant/net/manage-ole/) 中，我們說明了如何使用 Aspose.Slides for .NET 為 PowerPoint 簡報加入 OLE 框。為了解決 [object preview issue](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/)，我們將所選工作表區域的圖像指派給 OLE 物件框。於輸出簡報中，當您雙擊顯示工作表圖像的 OLE 物件框時，Excel 活頁簿即會被啟動。最終使用者可以對實際的 Excel 活頁簿進行任何所需的變更，然後點擊啟動的 Excel 活頁簿外部返回投影片。使用者返回投影片時，OLE 物件框的大小將會改變。調整比例會根據 OLE 物件框的大小與嵌入的 Excel 活頁簿的大小而有所不同。

## **調整大小的原因**

由於 Excel 活頁簿有自己的視窗大小，它在首次啟動時會嘗試保留原始大小。另一方面，OLE 物件框也有自己的尺寸。根據 Microsoft 的說法，當 Excel 活頁簿被啟動時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中維持正確的比例。調整大小發生於 Excel 視窗尺寸與 OLE 物件框的尺寸與位置之差異上。

## **可行解決方案**

有兩種可能的解決方案可避免此調整效果。

- 將 PowerPoint 簡報中的 OLE 框縮放，以符合所選列與欄的總高度與寬度。
- 保持 OLE 框尺寸不變，並將所選列與欄縮放以適應框體。

### **縮放 OLE 框大小**

此方法將 OLE 框大小設為與嵌入的 Excel 工作表中所選列與欄的總高度與寬度相匹配。

範例載入現有的 Excel 活頁簿，並使用從零開始的索引選取其第一個工作表的前 10 列與 13 欄。[WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) 定義顯示的範圍。預覽以 96 DPI 產生，並使用每英吋 72 點的比例將像素尺寸轉換為點。[ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) 以這些尺寸將修改後的活頁簿嵌入框中。預覽透過 [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) 指派，以取代已保存簡報中的「EMBEDDED OLE OBJECT」佔位符。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件使用時的顯示尺寸。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// 取得 OLE 影像的寬度與高度（以點為單位）。
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// 我們需要使用已修改的工作簿。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// 將 OLE 影像加入簡報資源。
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// 建立 OLE 物件框。
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

預覽協助程式將 [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) 設為選取範圍，並移除邊界、頁首與頁尾。啟用 [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) 後，[SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) 會將該範圍渲染為 PNG 圖像。協助程式在返回圖像串流前會倒回串流位置，以供簡報使用。

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **縮放儲存格範圍大小**

此方法將所選列的高度與所選欄的寬度縮放，以符合自訂的 OLE 框大小。

範例載入現有的 Excel 活頁簿，並使用從零開始的索引選取其第一個工作表的前 10 列與 13 欄。[WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) 定義顯示範圍，以下協助程式將該範圍縮放以適應寬度 400 點、高度 100 點的框體。將修改後的活頁簿保存至串流後，[ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) 會以指定尺寸將其嵌入。以 96 DPI 渲染的預覽透過 [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) 指派，使已保存的簡報顯示所選儲存格而非預設佔位符。

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件使用時的顯示尺寸。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 縮放儲存格範圍以符合框架大小。
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// 我們需要使用已修改的工作簿。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// 將 OLE 圖像加入簡報資源。
var oleImage = presentation.Images.AddImage(imageStream);

// 建立 OLE 物件框。
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

縮放協助程式為選取的範圍計算寬度與高度比例，保留其欄的相對寬度與列的相對高度。它先將計算出的尺寸從點轉換為英吋，然後使用 [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) 與 [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) 套用。所選範圍的寬度與高度必須非零。

```cs
/// <param name="width">預期的儲存格範圍寬度（點）。</param>
/// <param name="height">預期的儲存格範圍高度（點）。</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

此預覽協助程式使用 [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) 渲染已調整大小的範圍。它將 [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) 限定於該範圍，移除邊界、頁首與頁尾，並返回定位於開頭的 PNG 串流。

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **結論**

{{% alert color="info" title="Note" %}}

有兩種方法可以解決工作表調整大小的問題。請選擇最符合需求與使用情境的方法。兩種方法在從範本或從頭建立簡報時皆以相同方式運作。此外，此解決方案對 OLE 物件框的大小沒有任何限制。

{{% /alert %}}

## **常見問題**

**為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟動時會改變大小？**

這是因為 Excel 在啟動時會嘗試維持原始視窗大小，而 PowerPoint 中的 OLE 物件框則有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致調整大小。

**是否可以完全防止此調整大小問題？**

可以。透過將 OLE 框縮放以符合 Excel 儲存格範圍大小，或將儲存格範圍縮放以符合目標 OLE 框大小，皆可防止不必要的調整。

**我應該使用哪種縮放方式，OLE 框縮放還是儲存格範圍縮放？**

如果您想保留原始 Excel 列與欄的大小，請選擇 **OLE 框縮放**。如果您希望簡報中的 OLE 框具有固定大小，請選擇 **儲存格範圍縮放**。

**這些解決方案在基於範本的簡報中也有效嗎？**

有效。兩種解決方案皆適用於由範本或全新建立的簡報。

**使用這些方法時，OLE 框的大小是否有上限？**

沒有。只要適當設定縮放比例，OLE 物件框可以任意大小。

**是否有方法避免 PowerPoint 中的「EMBEDDED OLE OBJECT」佔位文字？**

有。透過快照目標 Excel 儲存格範圍，並將其設定為 OLE 框的佔位圖像，即可在預設佔位符位置顯示自訂預覽圖像。

## **相關文章**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)