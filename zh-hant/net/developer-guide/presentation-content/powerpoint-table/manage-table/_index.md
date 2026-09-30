---
title: 在 .NET 中管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/net/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比例
- 對齊文字
- 文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 投影片中建立與編輯表格。探索簡易的 C# 程式碼範例，以簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格將資訊以行與列組織，使閱讀與比較數值更為容易。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 類別、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 介面、[Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) 類別、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 介面，以及其他類型，讓您能在簡報中建立、更新與管理表格。

## **從頭建立表格**

透過指定位置、欄寬與列高來建立表格。將表格加入投影片後，您可以設定儲存格邊框、合併儲存格，以及插入文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參照。  
3. 定義以點為單位的欄寬陣列。  
4. 定義以點為單位的列高陣列。  
5. 透過 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法將 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 物件加入投影片。  
6. 遍歷每個 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) 以套用上、下、右、左邊框的格式。  
7. 合併表格第一列的前兩個儲存格。  
8. 透過其 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) 屬性存取合併後的儲存格。  
9. 為合併的儲存格設定文字。  
10. 儲存修改後的簡報。

以下範例在 (100, 50) 點的位置建立一個具有三欄五列的表格。它套用寬度為 5 點的紅色邊框，合併第一列的前兩個儲存格，並將結果儲存為 `table.pptx`。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **標準表格中的編號方式**

在標準表格中，儲存格索引是從零開始，且以 (欄, 列) 的順序表示。第一個儲存格的索引為 (0, 0)。

例如，具備 4 個欄與 4 個列的表格，其儲存格編號方式如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此範例建立上述 4 × 4 表格，欄寬與列高皆為 70 點，並套用寬度為 5 點的紅色儲存格邊框。座標說明了儲存格索引；範例保留儲存格內容為空，並將表格儲存為 `StandardTables_out.pptx`。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **存取現有表格**

表格儲存在投影片的形狀集合中。遍歷形狀以找到表格，然後使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 介面讀取或更新其儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報。  
2. 依索引取得包含表格的投影片參照。  
3. 遍歷 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 物件，當找到表格時即停止。如果投影片包含多個表格，請使用 [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) 以識別所需的那個。  
4. 更新目標儲存格的文字。  
5. 儲存修改後的簡報。

以下範例開啟 `UpdateExistingTable.pptx`，並在第一張投影片上找到第一個表格。它將第 0 欄第 1 列的儲存格設定為 `New`，並將結果儲存為 `table1_out.pptx`。輸入檔必須至少包含一張投影片，且該投影片上的第一個表格必須至少有一欄兩列。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

若要調整現有表格中列的大小，並了解其實際高度為何可能超過所請求的最小值，請參閱 [Control Row Height](/slides/zh-hant/net/manage-rows-and-columns/#control-row-height)。

## **找出擁有文字框的儲存格**

當一般文字處理程式碼從表格取得 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 時，請使用 [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) 屬性取得擁有該文字框的 [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)。對於表格儲存格的文字框，[ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) 會被設定，而 [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) 為 `null`，即使表格本身也是形狀。

儲存格座標可透過唯讀的 [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) 與 [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) 屬性取得。[ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) 也是唯讀的：它提供對所有者的導向，但不會更改所有權。使用前務必檢查回傳的儲存格是否為 `null`。

若要參考完整範例以辨識表格儲存格與形狀所有者（包括與 SmartArt 節點相關的形狀），請參閱 [Search and Replace Text](/slides/zh-hant/net/search-and-replace-text/)。

## **對齊表格中的文字**

您可以控制個別儲存格的垂直錨點與文字方向。本節的範例將第一個儲存格內的文字置中，並旋轉 270 度。

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得投影片的參照。  
3. 將 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 物件加入投影片。  
4. 從表格取得 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 物件。  
5. 取得第一個 [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) 並設定其文字與顏色。  
6. 設定儲存格的 [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) 與 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/)。  
7. 儲存修改後的簡報。

此範例建立一個 4 × 4 表格，欄寬為 120 點、列高為 100 點。它格式化儲存格 (0, 0) 內的文字，於第一列的其餘儲存格加入數值，並將結果儲存為 `Vertical_Align_Text_out.pptx`。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **在表格層級設定文字格式**

使用 [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) 可將文字格式套用至表格中的所有儲存格。其多載接受部分、段落與文字框格式，讓您無需遍歷個別儲存格即可設定這些屬性。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報。  
2. 依索引取得投影片的參照。  
3. 從投影片取得 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 物件。  
4. 設定文字的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。  
5. 設定 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 與 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。  
6. 設定 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。  
7. 儲存修改後的簡報。

以下範例開啟 `table.pptx`（必須至少有一張投影片，且第一個形狀為表格），將字體大小設定為 25 點，將段落右對齊並設定右邊距為 20 點，最後將文字設為垂直。格式化後的簡報儲存為 `result.pptx`。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **取得表格樣式屬性**

使用 [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) 可讀取或指派表格的預設樣式。此範例將 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) 套用於一個表格，印出其預設名稱，並將相同的預設指派給第二個表格。兩個表格皆儲存於 `table-style.pptx`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **鎖定表格的長寬比**

表格的長寬比是寬度與高度的比例。使用 [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) 可為表格鎖定此比例。

以下範例開啟 `pres.pptx`（必須至少有一張投影片，且第一個形狀為表格），印出目前的鎖定狀態，啟用長寬比鎖定，印出更新後的狀態（`True`），並將結果儲存為 `pres-out.pptx`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **常見問題**

**我可以為整個表格以及其儲存格中的文字啟用從右至左 (RTL) 讀取方向嗎？**

是的。表格提供了 [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) 屬性，段落則有 [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/)。同時使用兩者即可確保儲存格內的 RTL 順序與呈現正確。

**如何防止使用者在最終檔案中移動或調整表格的大小？**

使用 [shape locks](/slides/zh-hant/net/applying-protection-to-presentation/) 可停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入影像作為背景？**

支援。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/)，影像會依選擇的模式（拉伸或平鋪）覆蓋儲存格區域。