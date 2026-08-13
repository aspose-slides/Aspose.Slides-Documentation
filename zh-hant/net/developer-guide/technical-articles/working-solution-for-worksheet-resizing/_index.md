---
title: 工作表尺寸調整的可行解決方案
type: docs
weight: 40
url: /zh-hant/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 預覽圖像
- 圖像調整大小
- Excel
- 工作表
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "修復簡報中 Excel 工作表 OLE 縮放問題：提供兩種方法保持物件框架一致——縮放框架或縮放工作表——適用於 PPT 與 PPTX 格式。"
---
{{% alert color="info" %}} 

已觀察到，透過 Aspose 元件將 Excel 工作表以 OLE 物件嵌入 PowerPoint 簡報後，在第一次啟用時會被調整為未知的比例。此行為導致 OLE 物件在啟用前後的簡報外觀產生明顯差異。我們已詳細調查此問題並提供了解決方案，相關內容收錄於本文。

{{% /alert %}} 

## **背景**

在文章 [Manage OLE](/slides/zh-hant/net/manage-ole/) 中，我們說明了如何使用 Aspose.Slides for .NET 為 PowerPoint 簡報新增 OLE 框架。為了解決 [object preview issue](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/) ，我們將選取的工作表區域的影像指派給 OLE 物件框架。於輸出簡報中，當您雙擊顯示工作表影像的 OLE 物件框架時，Excel 活頁簿會被啟用。最終使用者可以對實際的 Excel 活頁簿進行任意變更，然後點擊已啟用的 Excel 活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框架的大小會發生變化。調整比例會依據 OLE 物件框架與嵌入的 Excel 活頁簿的大小而異。

## **調整大小的原因**

由於 Excel 活頁簿擁有自己的視窗大小，它會在首次啟用時嘗試保留原始尺寸。另一方面，OLE 物件框架也有自己的大小。根據 Microsoft 的說法，當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中保持正確的比例。尺寸調整是根據 Excel 視窗大小與 OLE 物件框架的大小與位置之差異而產生的。

## **可行解決方案**

有兩種可能的解決方案可避免尺寸變更的現象。

- 將 PowerPoint 簡報中 OLE 框架的大小調整為與 OLE 框架中所需的列與欄數的高度和寬度相匹配。
- 保持 OLE 框架大小不變，並調整參與的列與欄的大小，使其符合選定的 OLE 框架尺寸。

### **調整 OLE 框架大小**

在本方法中，我們將學習如何設定嵌入的 Excel 活頁簿的 OLE 框架大小，使其符合 Excel 工作表中參與列與欄的累計大小。

假設我們有一個範本 Excel 工作表，並希望將其作為 OLE 框架加入簡報。在此情況下，OLE 物件框架的大小將先根據工作簿中參與列的累計列高與欄的累計欄寬計算。然後，我們會將 OLE 框架的大小設定為此計算值。為避免 PowerPoint 中 OLE 框架出現紅色的「EMBEDDED OLE OBJECT」訊息，我們還會擷取工作簿中所需列與欄的影像，並設定為 OLE 框架的佔位圖像。

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

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

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

### **調整儲存格範圍大小**

在本方法中，我們將學習如何調整參與列的高度與參與欄的寬度，使其符合自訂的 OLE 框架尺寸。

假設我們有一個範本 Excel 工作表，並希望將其作為 OLE 框架加入簡報。在此情況下，我們會設定 OLE 框架的大小，並調整參與 OLE 框架區域的列與欄的尺寸。接著，我們會將工作簿儲存至串流以套用變更，並轉換成位元組陣列以加入 OLE 框架。為避免 PowerPoint 中 OLE 框架出現紅色的「EMBEDDED OLE OBJECT」訊息，我們亦會擷取工作簿中所需列與欄的影像，並設定為 OLE 框架的佔位圖像。

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

// 設定工作簿檔案作為 PowerPoint 中 OLE 物件時的顯示大小。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// 將儲存格範圍縮放以符合框架大小。
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// 我們需要使用已修改的工作簿。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// 將 OLE 影像添加至簡報資源中。
var oleImage = presentation.Images.AddImage(imageStream);

// 建立 OLE 物件框架。
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">預期儲存格範圍的寬度（單位：點）.</param>
/// <param name="height">預期儲存格範圍的高度（單位：點）.</param>
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

{{% alert color="info" %}}

有兩種方法可修正工作表尺寸變更的問題。選擇適當的方法取決於具體需求與使用情境。無論簡報是從範本還是從頭建立，兩種方法的運作方式均相同。此外，此解決方案對 OLE 物件框架的大小沒有任何限制。

{{% /alert %}}

## **常見問題**

### 為什麼嵌入的 Excel 工作表在 PowerPoint 中首次啟用時會改變大小？

這是因為 Excel 在啟用時會嘗試保持原始視窗大小，而 PowerPoint 中的 OLE 物件框架則具有自己的尺寸。PowerPoint 與 Excel 會協商大小以保持長寬比，從而造成尺寸調整。

### 是否能完全防止此尺寸變更問題？

可以。透過將 OLE 框架調整為符合 Excel 儲存格範圍的大小，或將儲存格範圍調整為符合所需的 OLE 框架大小，即可防止不必要的尺寸變更。

### 我應該使用哪種縮放方法，OLE 框架縮放還是儲存格範圍縮放？

若希望保留原始的 Excel 列與欄大小，請選擇 **OLE 框架縮放**。若希望簡報中的 OLE 框架具有固定大小，請選擇 **儲存格範圍縮放**。

### 如果我的簡報是以範本為基礎，這些解決方案仍然適用嗎？

會。兩種解決方案均可用於從範本或從頭建立的簡報。

### 使用這些方法時，OLE 框架的大小是否有限制？

沒有。只要適當設定縮放比例，OLE 物件框架的大小皆可自行決定。

### 有沒有方法可以避免 PowerPoint 中顯示「EMBEDDED OLE OBJECT」佔位文字？

有。將目標 Excel 儲存格範圍的快照設為 OLE 框架的佔位圖像，即可在預設佔位文字位置顯示自訂的預覽影像。

## **相關文章**

[在簡報中建立 Excel 圖表並以 OLE 物件嵌入](/slides/zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 外掛程式自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)