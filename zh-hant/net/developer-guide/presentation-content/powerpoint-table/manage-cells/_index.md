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
- 儲存格內的影像
- 背景顏色
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中管理 PowerPoint 表格儲存格：辨識合併儲存格、移除邊框、拆分儲存格，並設定背景顏色和影像。"
---
## **概觀**

Aspose.Slides 允許您存取並修改 PowerPoint 簡報中的表格儲存格。本文說明如何辨識合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格背景色，以及在表格儲存格內加入影像。範例示範如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 以零起始索引以 `(column, row)` 的順序存取表格儲存格。

## **辨識合併的表格儲存格**

此範例開啟既有簡報，將第一張投影片的第一個圖形當作表格。它假設投影片與圖形皆存在且圖形為表格。接著遍歷所有列與欄，使用 [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) 辨識合併區域中的儲存格。對於每個符合的儲存格，會以 `row;column` 的順序輸出其座標、[RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)、[ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)，以及區域的起始座標 [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) 與 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/)。

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

建立一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，並使用 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 在其第一張投影片加入表格。欄寬、列高與表格位置皆以點為單位指定。範例將四個儲存格邊框全部設定為 [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，使其不可見。

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

## **加入對角線儲存格邊框**

使用 [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) 繪製從左上角至右下角的線，使用 [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) 繪製從左下角至右上角的線。對角線可標示角落標題；兩條對角線組成 X 時可表示儲存格不適用。

每條對角線皆為一個 [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/)。在其 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) 中，將 [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為 [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 並選擇 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/)。再以點為單位設定線條的 [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/)。

範例在同一列建立三個儲存格：一個紅色向下對角線、一個藍色向上對角線，以及同時具備兩條對角線的儲存格。其上、下、左、右四側邊框保持不變。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

對角線屬於格式屬性，並非儲存格拆分。每個儲存格僅保有單一 [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/)，對角線兩側的區域無法獨立編輯。

已儲存的表格於 Microsoft PowerPoint 中的呈現：

![三個表格儲存格分別顯示左上至右下的紅色對角線、左下至右上的藍色對角線，以及形成 X 的兩條對角線。](diagonal-cell-borders.png)

*從左至右：向下對角線（紅，3 pt）、向上對角線（藍，5 pt）以及兩條對角線組成的 X。*

## **合併表格儲存格**

使用 [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) 可將矩形範圍的表格儲存格合併成單一儲存格。指定範圍左上與右下角的儲存格。最後一個參數控制合併是否可包含範圍外的儲存格；`false` 會將合併限制在該範圍內。

範例建立一個 4×4 的表格，欄與列皆為 70 點，然後合併位於 `(1, 1)` 至 `(2, 2)` 的四個中央儲存格。結果儲存格跨兩欄兩列，而底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上位置：本例中的 `table[1, 1]`。合併範圍內的其他位置仍屬於表格格線，因此範圍外儲存格的索引不會變動。

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

前一個範例的合併會保留表格格線。拆分儲存格可能會產生新列，並改變其右側儲存格的欄索引。Aspose.Slides 採用 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格，欄與列皆為 70 點，然後對儲存格 `(1, 1)` 呼叫 [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/)。將儲存格 70 點寬度的一半傳入，以產生兩個等寬儲存格。

拆分後，兩半分別以 `table[1, 1]` 與 `table[2, 1]` 存取。表格格線現在有五欄：原本在第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。拆分後存取儲存格時請使用更新後的欄索引。

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

### **依列或欄跨距拆分合併儲存格**

若要在資料填入前拆解合併的範本儲存格，可使用 [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) 沿既有列邊界拆分，或使用 [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) 沿欄邊界拆分。

`index` 參數計算的是拆分上方的列或左側的欄，且相對於合併區域：

- 列拆分：`0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/)。
- 欄拆分：`0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/)。

本範例假設簡報的第一張投影片第一個圖形為表格，且 `(1, 2)` 與 `(1, 3)` 兩個儲存格垂直合併。從較低的位置開始，使用 [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) 與 [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) 找到起點，並檢查兩個跨距。`SplitByRowSpan(1)` 會分離第 2、3 列，以放入產品名稱。若為水平的雙欄合併，則改用 `SplitByColSpan(1)`。

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

    // 從表格中取得拆分後的結果儲存格。
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

表格格線及其周圍儲存格索引保持不變。可依座標取得結果儲存格；此處兩者皆跨 1，且 [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) 會回傳 `False`。更大的區域在一次拆分後仍可能保留部分合併。

原始文字與格式保留在上方（或左側）儲存格；新儲存格為空，但會繼承填色、邊框、邊距等儲存格格式。拆分後再填入內容，並明確設定任何必要的文字格式。

已儲存的簡報包含「Product A」與「Product B」兩個分離的儲存格，且保留了範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/)。

<!-- visual-explanation:manage-cells:start -->
[![合併的儲存格位於第 1 欄第 2、3 列，拆分後形成「Product A」與「Product B」且格線索引不變。](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*列跨度拆分使用既有邊界。Product A 與 Product B 分別佔據 (1, 2) 與 (1, 3)。*
<!-- visual-explanation:manage-cells:end -->

### **依特定高度拆分儲存格**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) 接受上半部的高度（單位為點）。[SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) 接受上半部的格線列數。若要將 40 點高的儲存格置於右欄中置中，可先從儲存格實際高度減去 40 點，然後將剩餘空間平均分配於上下兩側。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

第一次拆分會新增一列格線，使下方 90 點保留於 `[1, 1]`。第二次拆分針對該儲存格，再在其下方新增一列。右欄現在包含 `[1, 0]`（50 點，`margin`）、`[1, 1]`（40 點）以及 `[1, 2]`（50 點，`margin`）。左側儲存格跨越所有三列，保持原始高度 140 點。

![左側儲存格跨整個表格高度，右側則有三個儲存格，中間的儲存格為 Middle。](split-by-height.png)

## **變更表格儲存格背景色**

此範例建立一個欄寬 150 點、列高 50 點的表格。將第 `(2, 3)` 個儲存格的 [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為實色，並將 [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) 設為紅色，該儲存格位於第 3 欄第 4 列。

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

在執行此範例前，請將輸入影像放置於工作目錄。範例使用 [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) 載入影像，並以 [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) 加入簡報的影像集合。然後將影像指定為儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) 會將影像拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高皆以點為單位。載入的影像會在 using 陳述式結束時自動釋放。

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

**我可以為單一儲存格的不同邊設定不同的線寬與樣式嗎？**

可以。[top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)、[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)、[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)、[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) 邊框皆有獨立屬性，因而可以分別設定厚度與樣式。

**如果在將圖片設定為儲存格背景後，變更欄或列的大小，圖片會發生什麼變化？**

行為取決於 [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)（stretch / tile）。若使用拉伸，圖片會隨新儲存格尺寸調整；若使用平鋪，平鋪的圖塊會重新計算。

**我可以將超連結指派給儲存格的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/net/manage-hyperlinks/) 是在儲存格文字框的文字（段落）層級或整個表格/圖形層級設定。實務上，您可以將連結指派給文字框中的某段文字，或指派給儲存格內的全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/)（文字段落），每個段落可擁有獨立的字型、樣式、大小與顏色。