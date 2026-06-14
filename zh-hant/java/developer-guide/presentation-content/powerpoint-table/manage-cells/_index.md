---
title: 使用 Java 在簡報中管理表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/java/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格內影像
- 背景顏色
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Java 在 PowerPoint 中管理表格儲存格。快速掌握存取、修改與樣式設定，實現無縫的投影片自動化。"
---
## **概述**

Aspose.Slides 讓您能在 PowerPoint 簡報中存取與修改表格儲存格。本篇文章說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、更改儲存格的背景色，以及在表格儲存格內加入影像。示例展示了如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

## **識別合併的表格儲存格**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 從第一張投影片取得表格。
3. 遍歷表格的列與欄，以找出合併的儲存格。
4. 找到合併的儲存格時列印訊息。

以下 Java 程式碼示範如何在簡報中識別合併的表格儲存格：

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // 假設 Slide#0.Shape#0 是一個表格
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **移除表格儲存格邊框**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 定義具有寬度的欄位陣列。
4. 定義具有高度的列陣列。
5. 使用 [addTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法將表格新增至投影片。
6. 遍歷每個儲存格，清除其上、下、右、左邊框。
7. 將修改後的簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範如何移除表格儲存格的邊框：

```java
// 實例化表示 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // 定義具有寬度的欄位及具有高度的列
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 將表格形狀新增至投影片
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 設定每個儲存格的邊框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // 將 PPTX 寫入磁碟
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **合併儲存格中的編號**
如果我們合併兩對儲存格 (1, 1) x (2, 1) 與 (1, 2) x (2, 2)，結果表格會有編號。以下 Java 程式碼演示此過程：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義具有寬度的欄位與具有高度的列
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 將表格形狀新增至投影片
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 設定每個儲存格的邊框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // 合併儲存格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // 合併儲存格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

接著我們再合併儲存格 (1, 1) 與 (1, 2)。結果是表格在中心有一個大型合併儲存格：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義具有寬度的欄位與具有高度的列
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 將表格形狀新增至投影片
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 設定每個儲存格的邊框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // 合併儲存格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // 合併儲存格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // 合併儲存格 (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// 將 PPTX 檔案寫入磁碟
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **分割儲存格中的編號**
在先前的範例中，當表格儲存格被合併時，其他儲存格的編號系統不會改變。

這次，我們使用一般表格（未合併儲存格的表格），然後嘗試分割儲存格 (1,1) 以得到特殊的表格。您可能需要留意此表格的編號，可能會顯得奇怪。然而，這正是 Microsoft PowerPoint 為表格儲存格編號的方式，Aspose.Slides 也採用相同的行為。

以下 Java 程式碼示範我們描述的過程：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義具有寬度的欄位與具有高度的列
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 將表格形狀新增至投影片
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 設定每個儲存格的邊框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // 合併儲存格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // 合併儲存格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // 拆分儲存格 (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // 將 PPTX 檔案寫入磁碟
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **變更表格儲存格背景色**

以下 Java 程式碼示範如何變更表格儲存格的背景色：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // 建立新表格
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 設定儲存格的背景顏色
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **在表格儲存格內加入影像**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 定義具有寬度的欄位陣列。
4. 定義具有高度的列陣列。
5. 使用 [AddTable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法將表格新增至投影片。
6. 建立一個 `Images` 物件以保存影像檔案。
7. 將 `IImage` 影像加入 `IPPImage` 物件。
8. 將表格儲存格的 `FillFormat` 設定為 `Picture`。
9. 將影像加入表格的第一個儲存格。
10. 將修改後的簡報儲存為 PPTX 檔案

以下 Java 程式碼示範在建立表格時，如何將影像放入表格儲存格內：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide islide = pres.getSlides().get_Item(0);

    // 定義具有寬度的欄位與具有高度的列
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // 將表格形狀新增至投影片
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 使用影像檔建立 IPPImage 物件
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 將影像加入表格的第一個儲存格
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 儲存 PPTX 檔案至磁碟
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以為單一儲存格的不同邊設置不同的線條粗細和樣式嗎？**

可以。[top](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/cellformat/#getBorderRight--) 邊框皆有各自的屬性，因此每一側的粗細和樣式可以不同。這與本文示範的儲存格每側邊框控制相符。

**如果在將圖片設定為儲存格背景後，變更欄/列大小，影像會發生什麼情況？**

此行為取決於 [fill mode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/picturefillmode/)（stretch/tile）。若為 stretch，影像會依新儲存格大小調整；若為 tile，會重新計算拼貼。文章中提及了儲存格內的影像顯示模式。

**我可以將超連結指派給儲存格內的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/java/manage-hyperlinks/) 會在儲存格文字框的文字（portion）層級或整個表格/形狀層級設定。實務上，您可將連結指派給文字的一部分或儲存格內的全部文字。

**我可以在單一儲存格內設定不同的字體嗎？**

可以。儲存格的文字框支援具有獨立格式（字體、樣式、大小與顏色）的 [portions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/)（執行序）。