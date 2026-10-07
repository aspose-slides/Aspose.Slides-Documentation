---
title: 使用 Java 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/java/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格中的影像
- 背景顏色
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Java 管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並使用 Aspose.Slides for Java 設定背景顏色和影像。"
---
## **概述**

Aspose.Slides 允許您存取和修改 PowerPoint 簡報中的表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色，以及在表格儲存格內加入影像。示例示範如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用零基索引以 `(column, row)` 方式存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有簡報，並將第一張投影片上的第一個圖形作為表格存取。假設投影片與圖形均存在且該圖形為表格。接著遍歷所有列與行，並使用 [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) 來識別合併區域中的儲存格。對於每個匹配項，會以 `row;column` 順序輸出儲存格座標、[getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--) 以及區域的起始座標，[getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--)。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **移除表格儲存格邊框**

建立一個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)，並使用 [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 在其第一張投影片上加入表格。欄寬、列高以及表格位置均以點為單位指定。此範例將四個儲存格邊框全部設為 [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)，使其變為不可見。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) 將矩形範圍的表格儲存格合併為單一儲存格。指定範圍左上角與右下角的儲存格。最後的參數控制合併是否可包含範圍外的儲存格；`false` 會將合併限制在該範圍內。

此範例建立一個 4×4 的表格，欄寬與列高均為 70 點，然後將位於 `(1, 1)` 到 `(2, 2)` 的四個中心儲存格合併。合併後的儲存格跨越兩個欄和兩個列，而表格的底層格線仍保有四個欄與四個列。若要存取合併儲存格的內容或格式，請使用其左上位置：此範例中的 `table.get_Item(1, 1)`。合併範圍內其他位置仍屬於表格格線，因此範圍外儲存格的索引不會變更。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **拆分表格儲存格**

在前一個範例中合併儲存格會保留表格的格線。拆分儲存格可能會產生新的格線欄，並更改其右側儲存格的欄索引。Aspose.Slides 遵循 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，並對儲存格 `(1, 1)` 呼叫 [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-)。將該儲存格 70 點寬度的一半傳入，以產生兩個等寬儲存格。

拆分後，兩個子儲存格可分別透過 `table.get_Item(1, 1)` 與 `table.get_Item(2, 1)` 存取。表格格線現在有五個欄：原本在第 2 與第 3 欄的儲存格分別移至第 3 與第 4 欄。列索引保持不變。拆分後存取儲存格時，請使用這些更新後的欄索引。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **依列或欄跨度拆分合併儲存格**

為了在資料填入時處理合併的範本儲存格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) 依現有列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) 依欄邊界拆分。

`index` 參數計算分割上半部的列或左半部的欄；其相對於合併區域：

- 列拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- 欄拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

此範例假設簡報的第一張投影片的第一個圖形為表格，且 `(1, 2)` 與 `(1, 3)` 垂直合併。從較低的位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) 與 [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) 找到起始位置，並檢查兩個跨度。接著以 `splitByRowSpan(1)` 將第 2 與第 3 列分開以放置產品名稱。若為水平的兩欄合併，則改用 `splitByColSpan(1)`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // 取得拆分後表格中的儲存格。
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

表格格線及其周圍儲存格的索引保持不變。可依座標取得產生的儲存格；此處兩者的跨度皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) 會回傳 `false`。較大的區域在一次拆分後仍可能保留部分合併。

原始文字與其格式保留在上方（或左側）儲存格；新儲存格則為空，但會繼承儲存格的格式，例如填充、邊框與邊距。拆分後請自行為儲存格填入資料，並明確設定任何所需的文字格式。

已儲存的簡報將包含分開的「Product A」與「Product B」儲存格，且保留範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/)。

## **變更表格儲存格背景色**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 選取純色填充，並將 [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 所回傳的顏色設為紅色，套用於儲存格 `(2, 3)`（第三欄、第四列）。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格儲存格內加入影像**

在執行此範例前，請將輸入影像放置於工作目錄。程式會使用 [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) 載入影像，並以 [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) 將其加入簡報的影像集合。接著將該影像指定為儲存格 `(0, 0)`（表格第一個儲存格）的圖片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) 會將影像拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高均以點為單位。影像在加入簡報後於 `finally` 區塊中釋放。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**我可以為單一儲存格的不同邊設定不同的線條粗細和樣式嗎？**

可以。[top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) 邊框具有獨立的屬性，因此每一側的粗細與樣式可以不同。

**如果在將圖片設為儲存格背景後，變更欄/列大小，影像會怎樣？**

行為取決於 [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)（stretch/tile）。使用 stretch 時，影像會依新儲存格調整；使用 tile 時，瓦片會重新計算。

**我可以為儲存格的全部內容指派超連結嗎？**

[Hyperlinks](/slides/zh-hant/java/manage-hyperlinks/) 會設定在儲存格文字框內的文字（portion）層級，或整個表格/圖形層級。實務上，您可以將連結指派給文字的一部分或整個儲存格的文字。

**我可以在單一儲存格內使用不同的字型嗎？**

可以。儲存格的文字框支援具有獨立格式的 [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)（runs）——字型族、樣式、大小與顏色皆可分別設定。