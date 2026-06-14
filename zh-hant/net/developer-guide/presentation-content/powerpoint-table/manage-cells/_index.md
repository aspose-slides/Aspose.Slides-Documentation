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
- 儲存格內圖片
- 背景顏色
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，輕鬆在 PowerPoint 中管理表格儲存格。快速掌握存取、修改與樣式設定，實現無縫投影片自動化。"
---
## **概述**

Aspose.Slides 允許您在 PowerPoint 簡報中存取與修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色彩，以及在表格儲存格內加入圖片。範例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報另存為 PPTX 檔案。

## **識別合併的表格儲存格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
2. 從第一張投影片取得表格。  
3. 遍歷表格的列與欄以找出合併的儲存格。  
4. 在找到合併儲存格時輸出訊息。

以下 C# 程式碼示範如何在簡報中識別合併的表格儲存格：

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // 假設 Slide#0.Shape#0 是表格
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **移除表格儲存格邊框**

1. 建立 `Presentation` 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 定義具有寬度的欄陣列。  
4. 定義具有高度的列陣列。  
5. 使用 `AddTable` 方法將表格新增至投影片。  
6. 遍歷每個儲存格以清除上、下、右、左邊框。  
7. 將修改後的簡報另存為 PPTX 檔案。

以下 C# 程式碼示範如何移除表格儲存格的邊框：

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
using (Presentation pres = new Presentation())
{
   // 存取第一張投影片
    Slide sld = (Slide)pres.Slides[0];

    // 定義具有寬度的欄位和具有高度的列
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 將表格形狀加入投影片
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 為每個儲存格設定邊框格式
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // 將 PPTX 檔案寫入磁碟
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **合併儲存格中的編號**

如果我們合併兩對儲存格 (1, 1) x (2, 1) 與 (1, 2) x (2, 2)，結果的表格將會有編號。以下 C# 程式碼示範此過程：

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片
    ISlide sld = presentation.Slides[0];

    // 定義具有寬度的欄位與具有高度的列
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 將表格形狀新增至投影片
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 為每個儲存格設定邊框格式
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

    // 合併儲存格 (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // 合併儲存格 (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

接著我們再將 (1, 1) 與 (1, 2) 合併。結果是一個在中心擁有大型合併儲存格的表格：

```c#
 // 建立代表 PPTX 檔案的 Presentation 類別實例
 using (Presentation presentation = new Presentation())
 {
     // 取得第一張投影片
     ISlide slide = presentation.Slides[0];

     // 定義具有寬度的欄位與具有高度的列
     double[] dblCols = { 70, 70, 70, 70 };
     double[] dblRows = { 70, 70, 70, 70 };

     // 將表格形狀加入投影片
     ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

     // 為每個儲存格設定邊框格式
     foreach (IRow row in table.Rows)
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

     // 合併儲存格 (1, 1) x (2, 1)
     table.MergeCells(table[1, 1], table[2, 1], false);

     // 合併儲存格 (1, 2) x (2, 2)
     table.MergeCells(table[1, 2], table[2, 2], false);

     // 合併儲存格 (1, 2) x (2, 2)
     table.MergeCells(table[1, 1], table[1, 2], true);

     // 將 PPTX 檔案寫入磁碟
     presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
 }
```

## **拆分儲存格中的編號**

在先前的範例中，當表格儲存格被合併時，其他儲存格的編號系統不會變化。  
這次，我們取一個普通表格（即未合併儲存格的表格），然後嘗試拆分儲存格 (1,1) 以得到特殊的表格。您可能需要注意此表格的編號，可能會顯得奇怪。然而，這正是 Microsoft PowerPoint 為表格儲存格編號的方式，Aspose.Slides 亦同樣如此。  

以下 C# 程式碼示範我們所描述的過程：

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
using (Presentation presentation = new Presentation())
{
    // 存取第一張投影片
    ISlide slide = presentation.Slides[0];

    // 定義具有寬度的欄位與具有高度的列
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 將表格形狀加入投影片
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 為每個儲存格設定邊框格式
    foreach (IRow row in table.Rows)
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

    // 合併儲存格 (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // 合併儲存格 (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // 拆分儲存格 (1, 1)。 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // 將 PPTX 檔案寫入磁碟
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **變更表格儲存格背景色彩**

以下 C# 程式碼示範如何變更表格儲存格的背景色彩：

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 建立新表格
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // 設定儲存格的背景顏色 
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **在表格儲存格內加入圖片**

1. 建立 `Presentation` 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 定義具有寬度的欄陣列。  
4. 定義具有高度的列陣列。  
5. 使用 `AddTable` 方法將表格新增至投影片。  
6. 建立 `Bitmap` 物件以存放圖片檔案。  
7. 將 bitmap 圖片加入 `IPPImage` 物件。  
8. 將表格儲存格的 `FillFormat` 設為 `Picture`。  
9. 將圖片加入表格的第一個儲存格。  
10. 將修改後的簡報另存為 PPTX 檔案  

以下 C# 程式碼示範在建立表格時如何將圖片放入表格儲存格內：

```c#
// 建立代表 PPTX 檔案的 Presentation 類別實例
using (Presentation presentation = new Presentation())
{
    // 取得第一張投影片
    ISlide slide = presentation.Slides[0];

    // 定義具有寬度的欄位與具有高度的列
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // 將表格形狀加入投影片
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // 從檔案載入圖片並將其加入簡報資源
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // 將圖片加入第一個表格儲存格
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // 將 PPTX 檔案寫入磁碟
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細與樣式嗎？**

可以。[上邊框](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/cellformat/bordertop/)/[下邊框](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/cellformat/borderbottom/)/[左邊框](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/cellformat/borderleft/)/[右邊框](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/cellformat/borderright/) 各自有獨立的屬性，因此每一側的粗細與樣式可以不同。這與本文示範的儲存格每側邊框控制一致。

**如果在將圖片設為儲存格背景後，變更欄/列的大小，圖片會發生什麼變化？**

其行為取決於 [填充模式](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillmode/)（伸展/平鋪）。使用伸展時，圖片會依新儲存格調整尺寸；使用平鋪時，平鋪圖案會重新計算。本文已說明儲存格中圖片的顯示模式。

**我能為儲存格的全部內容設定超連結嗎？**

[超連結](/slides/zh-hant/net/manage-hyperlinks/) 可設定於儲存格文字框內的文字（段落）層級，或於整個表格/圖形層級。實務上，您可以將連結指派給文字片段或整個儲存格的全部文字。

**我能在單一儲存格內使用不同的字型嗎？**

可以。儲存格的文字框支援 [文字片段](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/portion/)（run），可各自設定字體、樣式、大小與顏色等格式。