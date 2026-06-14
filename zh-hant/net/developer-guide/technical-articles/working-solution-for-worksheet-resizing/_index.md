---
title: 工作表調整尺寸的可行解決方案
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
description: "修復簡報中 Excel 工作表 OLE 調整大小的問題：提供兩種方法保持物件框一致——縮放框架或工作表——支援 PPT 與 PPTX 格式。"
---
{{% alert color="primary" %}} 
我們觀察到，透過 Aspose 元件在 PowerPoint 簡報中嵌入為 OLE 物件的 Excel 工作表，在首次啟用後會被調整為未指明的比例。此行為在 OLE 物件的啟用前後狀態之間造成明顯的視覺差異。我們已深入研究此問題並提供了解決方案，詳見本文。 
{{% /alert %}} 

## **背景**

在文章[管理 OLE](/slides/zh-hant/net/manage-ole/)中，我們說明了如何使用 Aspose.Slides for .NET 將 OLE 框新增至 PowerPoint 簡報。為了解決[物件預覽問題](/slides/zh-hant/net/object-preview-issue-when-adding-oleobjectframe/)，我們將選取的工作表區域影像指派給 OLE 物件框。產出的簡報中，當您雙擊顯示工作表影像的 OLE 物件框時，Excel 活頁簿會被啟用。最終使用者可以對實際的 Excel 活頁簿進行任何想要的更改，然後點擊已啟用的 Excel 活頁簿之外的區域返回投影片。使用者回到投影片時，OLE 物件框的大小會發生變化。調整比例會根據 OLE 物件框與嵌入的 Excel 活頁簿的大小而有所不同。

## **導致調整大小的原因**

由於 Excel 活頁簿有其自身的視窗大小，它會嘗試在首次啟用時保留原始大小。另一方面，OLE 物件框也有自己的尺寸。根據 Microsoft 的說明，當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商尺寸，以確保在嵌入過程中維持正確的比例。調整大小的發生是基於 Excel 視窗大小與 OLE 物件框的大小與位置之間的差異。

## **可行的解決方案**

有兩種可能的解決方案可避免調整大小的效應。

- 將 PowerPoint 簡報中的 OLE 框大小調整為與 OLE 框中所需的行列數的高度和寬度相匹配。
- 保持 OLE 框大小固定，並調整參與的行列尺寸以適應選定的 OLE 框大小。

### **縮放 OLE 框大小**

在此方法中，我們將學習如何將嵌入的 Excel 活頁簿的 OLE 框大小設定為與工作表中參與行列的累計大小相匹配。

假設我們有一個範本 Excel 工作表，並希望將其作為 OLE 框新增至簡報。於此情況下，OLE 物件框的大小將首先根據活頁簿中參與行列的累計行高與列寬計算。然後，我們會將 OLE 框的大小設定為此計算值。為了避免 PowerPoint 中 OLE 框顯示紅色的「EMBEDDED OLE OBJECT」訊息，我們還會擷取活頁簿中所需行列的影像，並將其設定為 OLE 框的影像。

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 設定當工作簿檔案作為 PowerPoint 中的 OLE 物件使用時的顯示大小。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// 取得 OLE 圖像的寬度與高度（單位為點）。
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// 我們需要使用已修改的工作簿。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// 將 OLE 圖像加入簡報資源。
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// 建立 OLE 物件框。
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

### **縮放儲存格範圍大小**

在此方法中，我們將學習如何將參與行的高度與參與列的寬度縮放，以符合自訂的 OLE 框大小。

假設我們有一個範本 Excel 工作表，並希望將其作為 OLE 框新增至簡報。於此情況下，我們會設定 OLE 框的大小，並將參與 OLE 框區域的行與列的大小縮放以符合該框。接著，我們會將活頁簿儲存至串流，以套用變更，並轉換為位元組陣列以加入 OLE 框。為了避免 PowerPoint 中 OLE 框顯示紅色的「EMBEDDED OLE OBJECT」訊息，我們還會擷取活頁簿中所需行列的影像，並將其設定為 OLE 框的影像。

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// 設定當工作簿檔案作為 PowerPoint 中的 OLE 物件使用時的顯示大小。
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

// 將 OLE 圖像加入簡報資源。
var oleImage = presentation.Images.AddImage(imageStream);

// 建立 OLE 物件框。
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">儲存格範圍的預期寬度（單位為點）。</param>
/// <param name="height">儲存格範圍的預期高度（單位為點）。</param>
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

{{% alert color="primary" %}}
有兩種方法可解決工作表調整大小的問題。選擇哪種方法取決於具體需求與使用情境。無論簡報是從範本還是從頭建立，兩種方法的運作方式皆相同。此外，此解決方案對 OLE 物件框的大小沒有任何限制。
{{% /alert %}}

## **常見問題**

**為什麼在 PowerPoint 中首次啟用時嵌入的 Excel 工作表會改變大小？**  
這是因為 Excel 在啟用時會嘗試維持原始視窗大小，而 PowerPoint 中的 OLE 物件框有自己的尺寸。PowerPoint 與 Excel 會協商尺寸以維持長寬比，從而導致大小調整。

**是否可以完全防止此調整大小問題？**  
可以。透過將 OLE 框縮放至符合 Excel 儲存格範圍大小，或將儲存格範圍縮放至符合目標 OLE 框大小，即可避免不必要的調整。

**應該使用哪種縮放方法，OLE 框縮放還是儲存格範圍縮放？**  
若希望保留原始 Excel 行列大小，請選擇 **OLE 框縮放**。若希望在簡報中使用固定大小的 OLE 框，請選擇 **儲存格範圍縮放**。

**如果我的簡報是基於範本建立的，這些解決方案仍然適用嗎？**  
是的。兩種解決方案皆適用於由範本或全新建立的簡報。

**使用這些方法時 OLE 框的大小是否有限制？**  
沒有。只要適當設定縮放比例，OLE 物件框可以任意大小。

**有沒有辦法避免 PowerPoint 中顯示「EMBEDDED OLE OBJECT」的佔位文字？**  
有。透過擷取目標 Excel 儲存格範圍的快照，並將其設定為 OLE 框的佔位影像，即可顯示自訂的預覽圖像，取代預設佔位文字。

## **相關文章**

[在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 外掛程式自動更新 OLE 物件](/slides/zh-hant/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)