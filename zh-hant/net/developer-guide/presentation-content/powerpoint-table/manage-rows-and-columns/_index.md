---
title: 在 .NET 中管理 PowerPoint 表格的列與行
linktitle: 列與行
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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 中管理表格列與欄，並加速簡報編輯與資料更新。"
---
## **簡介**

為了讓您在 PowerPoint 簡報中管理表格的行與欄，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/table/) 類別、[ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 介面，以及許多其他類型。

## **將第一列設定為標題列**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例並載入簡報。  
2. 透過索引取得投影片的參考。  
3. 建立 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件，並將其設為 null。  
4. 遍歷所有 [IShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/) 物件以尋找相關的表格。  
5. 將表格的第一列設定為其標題列。  

以下 C# 程式碼示範如何將表格的第一列設定為標題列：

```c#
// 建立 Presentation 類別的實例
Presentation pres = new Presentation("table.pptx");

// 取得第一張投影片
ISlide sld = pres.Slides[0];

// 初始化 null TableEx
ITable tbl = null;

// 遍歷所有形狀並設定對表格的參考
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// 將表格的第一列設定為標題列
tbl.FirstRow = true;

// 將簡報儲存至磁碟
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **複製表格列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例並載入簡報，  
2. 透過索引取得投影片的參考。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 透過 [AddTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addtable/) 方法將 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件新增至投影片。  
6. 複製表格列。  
7. 複製表格欄。  
8. 儲存已修改的簡報。  

以下 C# 程式碼示範如何複製 PowerPoint 表格的列或欄：

```c#
 // 建立 Presentation 類別的實例
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // 取得第一張投影片
    ISlide sld = presentation.Slides[0];

    // 定義欄寬與列高
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 在投影片上新增表格形狀
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 在第 1 列第 1 格加入文字
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // 在第 1 列第 2 格加入文字
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // 在表格末端複製第 1 列
    table.Rows.AddClone(table.Rows[0], false);

    // 在第 2 列第 1 格加入文字
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // 在第 2 列第 2 格加入文字
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // 複製第 2 列為表格的第 4 列
    table.Rows.InsertClone(3,table.Rows[1], false);

    // 在表格末端複製第一欄
    table.Columns.AddClone(table.Columns[0], false);

    // 在第 4 個欄位索引處複製第 2 欄
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // 將簡報儲存至磁碟 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **從表格中移除列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例並載入簡報，  
2. 透過索引取得投影片的參考。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 透過 [AddTable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addtable/) 方法將 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件新增至投影片。  
6. 移除表格列。  
7. 移除表格欄。  
8. 儲存已修改的簡報。  

以下 C# 程式碼示範如何從表格中移除列或欄：

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **在表格列層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例並載入簡報，  
2. 透過索引取得投影片的參考。  
3. 從投影片存取相關的 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件。  
4. 設定第一列儲存格的 [FontHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/fontheight/)。  
5. 設定第一列儲存格的 [Alignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/alignment/) 與 [MarginRight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginright/)。  
6. 設定第二列儲存格的 [TextVerticalType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/textverticaltype/)。  
7. 儲存已修改的簡報。  

以下 C# 程式碼展示此操作。

```c#
// 建立 Presentation 類別的實例
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // 假設第一張投影片的第一個形狀是一個表格

// 設定第一列儲存格的字型高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// 設定第一列儲存格的文字對齊方式與右邊距
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// 設定第二列儲存格的文字垂直類型
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// 將簡報儲存至磁碟
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **在表格欄層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例並載入簡報，  
2. 透過索引取得投影片的參考。  
3. 從投影片存取相關的 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/) 物件。  
4. 設定第一欄儲存格的 [FontHeight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/baseportionformat/fontheight/)。  
5. 設定第一欄儲存格的 [Alignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/alignment/) 與 [MarginRight](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/marginright/)。  
6. 設定第二欄儲存格的 [TextVerticalType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textframeformat/textverticaltype/)。  
7. 儲存已修改的簡報。  

以下 C# 程式碼展示此操作：

```c#
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // 假設第一張投影片的第一個形狀是一個表格

// 設定第一欄儲存格的字型高度
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// 在一次呼叫中設定第一欄儲存格的文字對齊方式與右邊距
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// 設定第二欄儲存格的文字垂直類型
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// 將簡報儲存至磁碟
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **取得表格樣式屬性**

Aspose.Slides 允許您取得表格的樣式屬性，以便將這些資訊用於其他表格或其他地方。以下 C# 程式碼示範如何從表格的預設樣式取得樣式屬性：

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // 變更預設樣式預設主題
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**我可以將 PowerPoint 主題/樣式套用到已建立的表格嗎？**

可以。表格會繼承投影片/版面/母片的主題，且您仍可在此基礎上覆寫填滿、邊框與文字顏色。

**我可以像在 Excel 中那樣對表格列排序嗎？**

不行，Aspose.Slides 的表格沒有內建排序或篩選功能。請先在記憶體中對資料排序，然後依該順序重新填入表格列。

**我可以在使用分段（條紋）欄的同時，保留特定儲存格的自訂顏色嗎？**

可以。先啟用分段欄，然後以本地格式覆寫特定儲存格；儲存格層級的格式會優先於表格樣式。