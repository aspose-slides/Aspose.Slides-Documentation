---
title: 管理 Android 上簡報的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/androidjava/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格內圖片
- 背景色彩
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上管理 PowerPoint 表格儲存格：使用 Aspose.Slides for Android 透過 Java 識別合併儲存格、移除邊框、拆分儲存格，並設定背景色彩與圖片。"
---
## **概覽**

Aspose.Slides 允許您存取和修改 PowerPoint 簡報中的表格儲存格。本篇文章說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色彩，以及在表格儲存格內新增圖片。示例展示了如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用從零開始的索引，以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

範例開啟現有的簡報，並將第一張投影片上的第一個圖形作為表格存取。假設投影片與圖形皆存在且該圖形為表格。接著遍歷所有列與欄，並使用 [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) 來識別位於合併區域的儲存格。對於每個符合的儲存格，會以 `row;column` 的順序輸出其座標、[getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)，以及區域的起始座標、[getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) 與 [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--)。

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

建立一個 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)，並使用 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 在其第一張投影片上加入表格。欄寬、列高以及表格位置皆以點 (point) 為單位指定。範例將所有四個儲存格邊框設定為 [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) 使其不可見。

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

使用 [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) 來將矩形範圍的表格儲存格合併為單一儲存格。指定範圍的左上角與右下角儲存格。最後一個參數控制合併是否可能包含指定範圍之外的儲存格；`false` 會將合併限制在該範圍內。

範例建立一個 4×4、欄寬與列高皆為 70 點的表格，然後將位於 `(1, 1)` 至 `(2, 2)` 的四個中心儲存格合併。合併後的儲存格跨兩欄兩列，而表格的底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上角位置：此例中的 `table.get_Item(1, 1)`。合併範圍內的其他位置仍屬於表格格線，因此範圍外儲存格的索引不會改變。

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

在前一個範例中合併儲存格會保留表格的格線。拆分儲存格可能會產生新的格線欄，並改變其右側儲存格的欄索引。Aspose.Slides 依循 PowerPoint 的表格格線模型。

此範例建立一個 4×4、欄寬與列高皆為 70 點的表格，並對儲存格 `(1, 1)` 呼叫 [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-)。傳入其 70 點寬度的一半，以建立兩個等寬的儲存格。

拆分後，兩個半部可分別以 `table.get_Item(1, 1)` 與 `table.get_Item(2, 1)` 取得。表格格線現在變為五欄：原本位於第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。拆分後存取儲存格時請使用這些更新後的欄索引。

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

### **依列或欄跨距拆分合併儲存格**

為了在資料填入前處理合併的範本儲存格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) 依現有列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) 依欄邊界拆分。

`index` 參數計算分割上方的列數或左側的欄數；它相對於合併區域：

- 列拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)。
- 欄拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)。

此範例假設簡報的第一張投影片的第一個圖形是一個表格，且 `(1, 2)` 與 `(1, 3)` 之間垂直合併。從較低的位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) 與 [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) 取得起始點並檢查兩個跨距。接著 `splitByRowSpan(1)` 將第 2、3 列分開以放置產品名稱。若為水平的兩欄合併，則改用 `splitByColSpan(1)`。

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

        // 取得分割後表格中的儲存格。
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

表格格線與周圍儲存格的索引保持不變。可依座標取得產生的儲存格；此處兩者的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) 會回傳 `false`。較大的區域在一次拆分後仍可能保有部分合併。

原始文字及其格式保留在上方（或左側）儲存格；新儲存格為空白，但會繼承儲存格的格式，例如填色、邊框與邊距。拆分後請填入資料，並明確設定任何需要的文字格式。

儲存的簡報包含獨立的「Product A」與「Product B」儲存格，且保留了範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)。

## **變更表格儲存格背景色彩**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) 來選擇實心填色，並將 [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) 所回傳的顏色設定為紅色，套用於第 3 欄第 4 列的儲存格 `(2, 3)`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **在表格儲存格內加入圖片**

在執行此範例之前，請將輸入圖片放置於工作目錄中。程式會使用 [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) 載入圖片，並以 [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) 加入簡報的圖片集合。接著將該圖片指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) 會將圖片拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。載入的圖片會在加入簡報後於 `finally` 區塊中釋放。

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

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細與樣式嗎？**

可以。儲存格的 [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) 邊框各自有獨立屬性，因而可設定每一側的粗細與樣式不同。

**如果在將圖片設定為儲存格背景之後，變更欄或列的大小，圖片會發生什麼情況？**

其行為取決於 [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/)（stretch 或 tile）。使用 stretch 時，圖片會依新儲存格大小調整；使用 tile 時，圖磚會重新計算。

**我可以將超連結指派給儲存格的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/androidjava/manage-hyperlinks/) 會在儲存格文字框內的文字（段落）層級或整個表格/圖形層級設定。實務上，您可以將連結指派給文字的某個段落，或指派給儲存格內的全部文字。

**我可以在單一儲存格內設置不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)（文字段落）具有獨立的格式設定——字型、樣式、大小與顏色。