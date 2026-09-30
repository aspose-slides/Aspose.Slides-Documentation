---
title: 在 .NET 中管理 PowerPoint 表格的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/net/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 第一列
- 表格標題列
- 複製列
- 複製欄
- 拷貝列
- 拷貝欄
- 移除列
- 移除欄
- 列文字格式設定
- 欄文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 中管理表格的列與欄，並加速簡報編輯與資料更新。"
---
## **簡介**

Aspose.Slides for .NET 讓您能透過 [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) 類別和 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) 介面在 PowerPoint 簡報中管理表格結構與格式設定。您可以指定標題列、複製或移除列與欄，並對整列或整欄套用文字格式。

本文章使用 C# 範例說明這些操作。它亦示範如何取得表格的樣式預設，以便重複使用。表格列與欄的索引為零起始。

## **控制列高度**

使用 [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) 以點數設定列的最小高度。這是下限，而非固定高度。 [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) 會回傳實際高度，且為唯讀。透過 [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/) 取得列。

範例載入 [row-height-input.pptx](row-height-input.pptx)，該簡報的第一張投影片第一個圖形是一個表格。其第一列起始高度為 70 點。儲存格使用 18 點 Arial 文字、換行，且上、下邊距各為 6 點；第二欄較長的文字會換成多行。範例將最小高度提升至 100 點，然後降低至 20 點，在每次變更後列印實際高度，並儲存兩個結果。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

使用提供的簡報時，提升最小值會為列增加空間。降低最小值會移除額外空間，但實際高度仍大於 20 點，因為文字與儲存格邊距需要更多空間。僅僅降低最小值無法使列低於內容所需的空間。

實際高度受多種因素影響：

- **文字與字型大小：** 較長的文字、明確的換行或較大的字型都可能需要更多垂直空間。
- **換行與欄寬度：** 開啟換行時，較窄的 [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) 會產生更多行。較寬的欄位可減少垂直所需的空間。
- **儲存格邊距：** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) 與 [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) 會添加垂直空間。[ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) 與 [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) 會減少文字可用寬度，可能導致額外換行。

對於此不含合併儲存格的表格，最需要垂直空間的儲存格決定了整列的內容驅動下限。若要讓列變短，您可能還需縮短文字、減小字型或邊距，或是加寬欄位。

下方圖片顯示相同表格在相同比例下的結果。此執行的實際高度分別為 70、100 與 55.2 點：最後一列仍高於 20 點的最小值。文字測量會因環境中的字型而異。下載已儲存的結果：[increased minimum](row-height-increased.pptx) 與 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 pt，實際 70 pt | 提升：最小 100 pt，實際 100 pt | 降低：最小 20 pt，實際 55.2 pt |
| --- | --- | --- |
| ![原始表格，第一列為 70 點。](row-height-before.png) | ![將第一列最小值提升至 100 點後的表格。](row-height-increased.png) | ![將第一列最小值降低至 20 點後的表格；換行文字使列仍高於最小值。](row-height-decreased.png) |

## **將第一列設為標題列**

使用 [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) 屬性將第一列標記為標題格式。其外觀取決於套用於表格的樣式。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 取得投影片上第一個圖形即表格。
4. 為其第一列啟用標題格式。
5. 儲存修改後的簡報。

範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格。範例會為第一列啟用標題格式，並將結果儲存為 `First_row_header.pptx`。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **複製表格列或欄**

複製列或欄以重複使用其內容與格式設定。您可以將副本加入表格尾端，或插入至特定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法新增表格。
5. 複製所需的列。
6. 複製所需的欄。
7. 儲存修改後的簡報。

範例需要 `Test.pptx`，至少包含一張投影片。範例建立一個三欄五列的表格，尺寸以點數指定。它會在表格尾端加入第一列與第一欄的副本，然後在索引 3（即第四個位置）插入第二列與第二欄的副本。最終表格為七列五欄。`false` 參數會停用對相鄰合併列或欄的複製；此表格不含合併儲存格。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **從表格中移除列或欄**

移除表格中不再需要的列或欄。移除項目會導致其後的列或欄索引發生變化。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別建立簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) 方法新增表格。
5. 移除第二列與第二欄。
6. 儲存修改後的簡報。

此範例建立一個 3×3 的表格，並移除索引為 1 的列與欄，留下 2×2 的表格於 `TestTable_out.pptx`。尺寸以點數為單位。`false` 參數會停用對相鄰合併列或欄的移除；此表格不含合併儲存格。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **在表格列層級設定文字格式**

對整列套用文字格式，以保持其儲存格的一致性。您可以設定字型屬性、段落格式與文字方向，而不必逐一格式化每個儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 為第一列設定 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。
4. 為第一列設定 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 與 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。
5. 為第二列設定 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。
6. 儲存修改後的簡報。

範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格，且至少有兩列。範例會將第一列的文字設定為 25 點、右對齊、段落右邊距 20 點，然後將第二列的文字方向改為垂直。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **在表格欄層級設定文字格式**

對整欄套用文字格式，以保持其儲存格的一致性。您可以設定字型屬性、段落格式與文字方向，而不必逐一格式化每個儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 為第一欄設定 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。
4. 為第一欄設定 [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 與 [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/)。
5. 為第二欄設定 [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/)。
6. 儲存修改後的簡報。

範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格，且至少有兩欄。範例會將第一欄的文字設定為 25 點、右對齊、段落右邊距 20 點，然後將第二欄的文字方向改為垂直。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **取得表格樣式屬性**

使用 [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) 屬性取得套用於表格的預設樣式，並可將其重複使用於其他表格。此屬性會回傳樣式預設名稱，而非個別儲存格的格式覆寫。

範例建立一個表格，套用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/)，然後讀回該預設。它會列印 `DarkStyle1`，並將表格儲存為 `table.pptx`。

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **常見問題**

**我可以將 PowerPoint 主題/樣式套用到已建立的表格嗎？**

可以。表格會繼承投影片/版面/母片的主題，且您仍可在此基礎上覆寫填色、邊框與文字顏色。

**我可以像在 Excel 中那樣排序表格列嗎？**

不行，Aspose.Slides 的表格沒有內建排序或篩選功能。請先在記憶體中排序資料，然後依排序後的順序重新填入表格列。

**我可以在保持特定儲存格自訂顏色的同時，使用條紋（斑馬紋）欄位嗎？**

可以。開啟條紋欄位後，對特定儲存格套用本機格式；儲存格層級的格式會優先於表格樣式。