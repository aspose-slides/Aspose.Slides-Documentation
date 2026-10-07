---
title: 在 .NET 中管理簡報的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/net/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格中的影像
- 背景色彩
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 C# 中管理 PowerPoint 表格儲存格：辨識合併儲存格、移除邊框、拆分儲存格，以及使用 Aspose.Slides for .NET 設定背景色彩與影像。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中存取與修改表格儲存格。本文說明如何辨識合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色彩，以及在表格儲存格內加入影像。範例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用零基索引以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有簡報，將第一張投影片上的第一個圖形當作表格存取。它假設投影片與圖形皆存在且圖形為表格。接著遍歷所有列與欄，並使用 [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) 來辨識合併區域中的儲存格。對於每個符合的儲存格，會以 `row;column` 的順序印出座標、[RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)、[ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)，以及區域的起始座標，亦即 [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) 與 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **移除表格儲存格邊框**

建立一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 並使用 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 在其第一張投影片上加入表格。欄寬、列高以及表格位置皆以點 (point) 為單位指定。此範例將四個儲存格邊框全部設為 [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，使其不可見。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **合併表格儲存格**

使用 [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) 將矩形範圍的表格儲存格合併為單一儲存格。指定該範圍左上角與右下角的儲存格。最後一個參數控制合併是否可以包含指定範圍之外的儲存格；`false` 會將合併限制在該範圍內。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，然後合併位於 `(1, 1)` 到 `(2, 2)` 的四個中心儲存格。合併後的儲存格跨兩個欄與兩個列，而表格的底層格線仍保留四個欄與四個列。若要存取合併儲存格的內容或格式，請使用其左上位置：本例中的 `table[1, 1]`。合併範圍內的其他位置仍屬於表格格線，因此範圍外儲存格的索引不會改變。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **拆分表格儲存格**

在前一個範例中合併儲存格會保留表格的格線。拆分儲存格可能會產生新的格線欄，並變更其右側儲存格的欄索引。Aspose.Slides 依循 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，並對儲存格 `(1, 1)` 呼叫 [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/)。將該儲存格 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

拆分後，兩個半部可分別以 `table[1, 1]` 與 `table[2, 1]` 存取。表格格線現在有五個欄：原本在第 2 與第 3 欄的儲存格分別移至第 3 與第 4 欄。列索引保持不變。拆分後存取儲存格時請使用這些更新後的欄索引。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **依列或欄跨度拆分合併儲存格**

若要為資料填入準備合併的範本儲存格，可使用 [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) 依現有列邊界拆分，或使用 [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) 依欄邊界拆分。

`index` 參數計算分割上部的列或左部的欄；它相對於合併區域：

- 列拆分：`0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)。
- 欄拆分：`0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)。

此範例假設簡報的第一張投影片上第一個圖形為表格，且 `(1, 2)` 與 `(1, 3)` 垂直合併。從較低的位置開始，它使用 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) 與 [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) 取得起始點，並檢查兩個跨度。`SplitByRowSpan(1)` 接著分離第 2 與第 3 列的產品名稱。若為水平的兩欄合併，則改用 `SplitByColSpan(1)`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // 取得拆分後表格中產生的儲存格。
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

表格格線及周圍儲存格索引保持不變。可依其座標取得結果儲存格；此處兩者的跨度皆為 1，且 [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) 會回傳 `False`。較大的區域在一次拆分後仍可能部分保留合併狀態。

原始文字及其格式會保留在上方（或左側）儲存格；新儲存格則為空白，但會繼承儲存格的格式設定，如填色、邊框與邊距。拆分後請填入儲存格內容，並明確設定任何必要的文字格式。

儲存的簡報包含分別的「Product A」與「Product B」儲存格，且保留了範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/)。

## **變更表格儲存格背景色彩**

此範例建立一個欄寬 150 點、列高 50 點的表格。它將儲存格 `(2, 3)`（第 3 欄第 4 列）的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為 solid，並將 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) 設為紅色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **在表格儲存格內加入影像**

在執行此範例前，請將輸入影像放置於工作目錄中。它使用 [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) 載入影像，並透過 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) 加入簡報的影像集合。接著將影像指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填色。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) 會將影像伸展以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。載入的影像會在 using 陳述式結束時自動釋放。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細與樣式嗎？**

是的。儲存格的 [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) 邊框各有獨立的屬性，因此每一側的粗細與樣式可以不同。

**如果在將圖片設為儲存格背景後，調整欄/列大小，影像會發生什麼變化？**

行為取決於 [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)（stretch / tile）。使用 stretch 時，影像會依新儲存格調整尺寸；使用 tile 時，圖塊會重新計算。

**我可以將超連結指派給儲存格內的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/net/manage-hyperlinks/) 會設定於儲存格文字框內的文字（片段）層級，或整個表格/圖形層級。實務上，您可以將連結指派給某個片段或儲存格內的全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

是的。儲存格的文字框支援具有獨立格式的 [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/)（執行單元），包括字型族、樣式、大小與顏色。