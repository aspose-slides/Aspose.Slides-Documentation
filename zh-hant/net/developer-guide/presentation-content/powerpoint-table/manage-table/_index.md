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
- 寬高比
- 文字對齊
- 文字格式設定
- 表格樣式
- PowerPoint
- 投影片
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 投影片中建立與編輯表格。探索簡單的 C# 程式碼範例，以簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是顯示與呈現資訊的有效方式。以行列排列的格子網格中的資訊直觀且易於理解。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/table/) 類別、[ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 介面、[Cell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/cell/) 類別、[ICell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icell/) 介面以及其他型別，讓您能夠在各種簡報中建立、更新與管理表格。

## **從頭建立表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 透過 [AddTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addtable/) 方法將 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件加入至投影片。  
6. 逐一遍歷每個 [ICell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icell/)，為上、下、左、右邊框套用格式。  
7. 合併表格第一行的前兩個儲存格。  
8. 取得 [ICell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icell/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframe/) 新增文字。  
10. 儲存已修改的簡報。

以下 C# 程式碼示範如何在簡報中建立表格：

```c#
// 建立一個代表 PPTX 檔案的 Presentation 類別實例
Presentation pres = new Presentation();

// Accesses the first slide
ISlide sld = pres.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Adds a table shape to the slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Sets the border format for each cell
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// 合併第 1 列的第 1 與第 2 個儲存格
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// 向合併的儲存格加入文字
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// 將簡報儲存至磁碟
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **標準表格中的編號**

在標準表格中，儲存格的編號方式相當直觀且採用從零開始的索引。表格中的第一個儲存格索引為 0,0（第 0 欄，第 0 列）。

例如，具有 4 欄 4 列的表格，其儲存格編號方式如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 C# 程式碼示範如何為表格中的儲存格指定編號：

```c#
// 建立一個代表 PPTX 檔案的 Presentation 類別實例
using (Presentation pres = new Presentation())
{

    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 定義欄寬與列高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 在投影片加入表格形狀
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 設定每個儲存格的邊框格式
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // 將簡報儲存至磁碟
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **存取現有表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得包含表格的投影片參照。  
3. 建立 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件，並將其設為 null。  
4. 逐一遍歷所有 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 物件，直到找到表格。

   若您判斷當前投影片僅包含單一表格，則可以直接檢查其所有形狀。當形狀被識別為表格時，您可以將其型別轉換為 [Table](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/table/) 物件。但若投影片中有多個表格，則建議透過其 [AlternativeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/alternativetext/) 來搜尋所需的表格。

5. 使用 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件操作表格。以下範例示範向表格新增一列。  
6. 儲存已修改的簡報。

以下 C# 程式碼示範如何存取並操作現有表格：

```c#
// 建立一個代表 PPTX 檔案的 Presentation 類別實例
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{
    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 將 TableEx 初始化為 null
    ITable tbl = null;

    // 遍歷形狀並設定對找到的表格的參照
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // 設定第二列第一欄的文字
    tbl[0, 1].TextFrame.Text = "New";

    // 將已修改的簡報儲存至磁碟
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **對齊表格文字**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 向投影片加入 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件。  
4. 從表格取得 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 物件。  
5. 取得 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 的 [IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/)。  
6. 垂直對齊文字。  
7. 儲存已修改的簡報。

以下 C# 程式碼示範如何對齊表格中的文字：

```c#
// 建立 Presentation 類別的實例
Presentation presentation = new Presentation();

// 取得第一張投影片
ISlide slide = presentation.Slides[0];

// 定義欄寬與列高
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// 在投影片加入表格形狀
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// 取得文字框
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// 為文字框建立 Paragraph 物件
IParagraph paragraph = txtFrame.Paragraphs[0];

// 為段落建立 Portion 物件
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 垂直對齊文字
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// 將簡報儲存至磁碟
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **在表格層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 從投影片取得 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件。  
4. 為文字設定 [FontHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/fontheight/)。  
5. 設定 [Alignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/alignment/) 與 [MarginRight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginright/)。  
6. 設定 [TextVerticalType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/textverticaltype/)。  
7. 儲存已修改的簡報。

以下 C# 程式碼示範如何在表格的文字上套用您偏好的格式設定：

```c#
// 建立 Presentation 類別的實例
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 假設第一張投影片的第一個形狀是表格

// 設定表格儲存格的字型高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// 一次呼叫設定表格儲存格的文字對齊方式與右邊距
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// 設定表格儲存格的文字垂直類型
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **取得表格樣式屬性**

Aspose.Slides 讓您可以取得表格的樣式屬性，以便將這些細節用於其他表格或其他位置。以下 C# 程式碼示範如何從表格預設樣式取得樣式屬性：

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 更改預設樣式預設主題
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **鎖定表格的寬高比**

幾何圖形的寬高比是指其在不同維度上的尺寸比例。Aspose.Slides 提供 `AspectRatioLocked` 屬性，讓您可以為表格及其他圖形鎖定寬高比設定。

以下 C# 程式碼示範如何鎖定表格的寬高比：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // 反轉

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**我可以為整個表格及其儲存格中的文字啟用從右至左 (RTL) 閱讀方向嗎？**

可以。表格提供 [RightToLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/table/righttoleft/) 屬性，而段落則具有 [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/paragraphformat/righttoleft/)。同時使用兩者即可確保儲存格內的文字以正確的 RTL 順序與呈現。

**我要如何防止使用者在最終檔案中移動或調整表格的大小？**

使用 [shape locks](/slides/zh-hant/net/applying-protection-to-presentation/) 來停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**支援在儲存格內插入影像作為背景嗎？**

支援。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillformat/)，影像會依照所選模式（拉伸或平鋪）覆蓋儲存格區域。