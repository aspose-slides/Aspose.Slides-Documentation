---
title: 在 Android 上的簡報中管理表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/androidjava/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格內影像
- 背景色彩
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Android 搭配 Java 在 PowerPoint 中管理表格儲存格。快速掌握存取、修改與樣式設定，實現順暢的投影片自動化。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、更改儲存格的背景色，以及在表格儲存格內加入影像。範例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

## **識別合併的表格儲存格**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 從第一張投影片取得表格。
3. 迭代表格的列與欄以尋找合併的儲存格。
4. 發現合併儲存格時列印訊息。

此 Java 程式碼示範如何在簡報中識別合併的表格儲存格：

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // 假設 Slide#0.Shape#0 是表格
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
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 依索引取得投影片的參照。
3. 定義具有寬度的欄陣列。
4. 定義具有高度的列陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法將表格加入投影片。
6. 迭代每個儲存格以清除上、下、右、左邊框。
7. 將修改後的簡報儲存為 PPTX 檔案。

此 Java 程式碼示範如何移除表格儲存格的邊框：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // 定義具有寬度的欄與具有高度的列
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 將表格形狀加入投影片
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

## **合併儲存格的編號**
若我們合併兩對儲存格 (1, 1) x (2, 1) 與 (1, 2) x (2, 2)，得到的表格將會有編號。此 Java 程式碼示範此過程：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義具有寬度的欄與具有高度的列
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 將表格形狀加入投影片
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

接著我們再將儲存格 (1, 1) 與 (1, 2) 合併。結果是一個在中心具有大型合併儲存格的表格：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義具有寬度的欄與具有高度的列
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 將表格形狀加入投影片
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

## **拆分儲存格的編號**
在先前的範例中，當表格儲存格被合併時，其他儲存格的編號或編號系統不會變動。

這次，我們使用一個普通表格（沒有合併儲存格的表格），然後嘗試將儲存格 (1,1) 拆分，以產生特殊的表格。您可能會注意到此表格的編號看起來有點奇怪。但這正是 Microsoft PowerPoint 為表格儲存格編號的方式，Aspose.Slides 也遵循相同的行為。

此 Java 程式碼示範我們所描述的過程：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義具有寬度的欄與具有高度的列
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 將表格形狀加入投影片
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

## **變更表格儲存格背景色彩**

此 Java 程式碼示範如何變更表格儲存格的背景色彩：

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
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 依索引取得投影片的參照。
3. 定義具有寬度的欄陣列。
4. 定義具有高度的列陣列。
5. 透過 [AddTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法將表格加入投影片。
6. 建立 `Images` 物件以保存影像檔案。
7. 將 `IImage` 影像加入 `IPPImage` 物件。
8. 設定表格儲存格的 `FillFormat` 為 `Picture`。
9. 將影像加入表格的第一個儲存格。
10. 將修改後的簡報儲存為 PPTX 檔案

此 Java 程式碼示範在建立表格時如何將影像放入表格儲存格內：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide islide = pres.getSlides().get_Item(0);

    // 定義具有寬度的欄與具有高度的列
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // 將表格形狀加入投影片
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // 使用影像檔案建立 IPPImage 物件
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 將影像加入第一個表格儲存格
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 將 PPTX 檔案儲存至磁碟
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細和樣式嗎？**

是的。[上](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[下](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[左](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[右](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/cellformat/#getBorderRight--) 邊框各自有獨立的屬性，因此每一側的粗細與樣式可以不同。這與本文示範的儲存格逐側邊框控制邏輯相符。

**如果在將圖片設為儲存格背景後，調整欄或列的大小，影像會發生什麼變化？**

其行為取決於 [填充模式](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/picturefillmode/)（伸展/平鋪）。若使用伸展，影像會自動調整以符合新儲存格；若使用平鋪，平鋪圖塊會重新計算。本文中亦提及儲存格內影像的顯示模式。

**我可以將超連結指派給儲存格內的全部內容嗎？**

[超連結](/slides/zh-hant/androidjava/manage-hyperlinks/) 會設定在儲存格文字框內的文字（段落）層級，或是在整個表格/圖形層級。實際上，您可以將連結指派給文字的某個段落或整個儲存格的全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

是的。儲存格的文字框支援具有獨立格式設定（字型、樣式、大小與顏色）的 [文字段落](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/)（runs）。