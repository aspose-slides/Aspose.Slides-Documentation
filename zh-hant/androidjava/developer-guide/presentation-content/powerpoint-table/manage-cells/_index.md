---
title: 在 Android 上管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/androidjava/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格內的圖像
- 背景顏色
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並使用 Aspose.Slides for Android 透過 Java 設定背景顏色與圖像。"
---
## **概觀**

Aspose.Slides 允許您存取和修改 PowerPoint 簡報中的表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格背景色彩，以及在表格儲存格內加入圖片。示例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將已修改的簡報另存為 PPTX 檔案。

Aspose.Slides 使用從零開始的索引，以 `(column, row)`（欄, 列）的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有的簡報，並將第一張投影片上的第一個圖形當作表格存取。它假設投影片和圖形皆存在且該圖形為表格。接著遍歷所有列與欄，並使用 [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) 來識別合併區域中的儲存格。對於每個符合的儲存格，會以 `row;column`（列;欄）的順序列印儲存格座標、[getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--)，以及區域的起始座標、[getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--)。

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

建立一個 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 並使用 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 在其第一張投影片加入表格。欄寬、列高以及表格位置皆以點為單位指定。此範例將四個儲存格邊框全部設為 [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)，使其不可見。

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

## **加入對角線儲存格邊框**

使用 [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) 從左上角畫線至右下角，使用 [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) 從左下角畫線至右上角。對角線可用於標示角落標頭；兩條對角線同時出現時可形成 X，表示該儲存格不適用。

每條對角線皆為一個 [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/)。在其 [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) 中，使用 [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) 選擇 [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)，並透過 [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) 取得顏色。使用 [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) 以點數設定線寬。

此範例在同一列建立三個儲存格：一個帶紅色向下對角線、一個帶藍色向上對角線，以及同時帶兩條對角線的儲存格。其上下左右的儲存格邊框保持不變。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對角線是一種格式屬性，而非儲存格分割。每個儲存格僅保留一個文字框，可透過 [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) 取得；對角線兩側的區域無法獨立編輯。

已儲存的表格，在 Microsoft PowerPoint 中呈現如下：

![三個表格儲存格分別顯示左上至右下的紅色對角線、左下至右上的藍色對角線，以及兩條對角線形成的 X。](diagonal-cell-borders.png)

*左至右：向下對角線（紅色，3 點）、向上對角線（藍色，5 點）以及兩條對角線。*

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) 將矩形範圍的表格儲存格合併為單一儲存格。指定範圍左上角和右下角的儲存格。最後一個參數控制合併是否可以包含範圍外的儲存格；`false` 會將合併限制在該範圍內。

此範例建立一個 4×4 的表格，欄寬與列高均為 70 點，然後合併位於 `(1, 1)` 到 `(2, 2)` 的四個中心儲存格。合併後的儲存格跨兩欄兩列，而表格底層的格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上位置：本範例中的 `table.get_Item(1, 1)`。合併範圍內的其他位置仍屬於表格格線，因此範圍外儲存格的索引不會變動。

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

在前一個範例中合併儲存格仍保留表格格線。拆分儲存格可能會新增一個格線欄位，並改變其右側儲存格的欄索引。Aspose.Slides 採用 PowerPoint 的表格格線模型。

此範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，並對儲存格 `(1, 1)` 呼叫 [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-)。將該儲存格 70 點寬度的一半傳入，以產生兩個等寬的儲存格。

拆分後，兩個子儲存格可分別以 `table.get_Item(1, 1)` 與 `table.get_Item(2, 1)` 取得。表格格線現在變為五欄：原本屬於第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。拆分後存取儲存格時請使用更新後的欄索引。

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

<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*寬度拆分影響儲存格 (1, 1)，使用從零開始的 (column, row) 索引。其他列的儲存格仍跨越兩個新的欄位位置。*
<!-- visual-explanation:manage-cells:end -->

### **按列或欄跨距拆分合併儲存格**

若要為資料填入做好合併樣板儲存格的準備，可使用 [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) 沿既有列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) 沿欄邊界拆分。

`index` 參數計算拆分上部的列數或左側的欄數；它是相對於合併區域的：

- 列拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- 欄拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

此範例假設簡報的第一張投影片第一個圖形為表格，且 `(1, 2)` 與 `(1, 3)` 以垂直方式合併。從較低的位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) 與 [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) 取得起點，並檢查兩個跨距。接著呼叫 `splitByRowSpan(1)` 將第 2、3 列分離以放置產品名稱。若為水平的兩欄合併，則改為使用 `splitByColSpan(1)`。

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

        // 從拆分後的表格中取得結果儲存格。
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

表格格線及其周圍的儲存格索引保持不變。可依座標取得結果儲存格；此處兩者的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) 輸出 `false`。較大的區域在一次拆分後仍可能保留部分合併。

原始文字與其格式保留在上方（或左側）儲存格；新建立的儲存格為空，但會繼承儲存格的格式設定，如填滿、邊框與邊距。拆分後請填入儲存格內容，並明確設定任何所需的文字格式。

已儲存的簡報包含分別為「Product A」與「Product B」的儲存格，且保留了樣板的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/)。

### **在特定高度拆分儲存格**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) 以點數指定上部的高度。 [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) 以上部所佔的現有格線列數為參數。若要將 40 點的儲存格置於右欄居中，先從儲存格實際高度減去 40，然後將剩餘空間等分於上方與下方。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

第一次拆分會新增一列格線，且在儲存格 `(1, 1)` 留下下方 90 點。第二次拆分將該儲存格分為一個 40 點的中間儲存格與一個 50 點的底部儲存格。右欄現在由上至下共有三個儲存格，高度分別為 50、40、50 點。左側儲存格跨越所有三列，且仍保留原始的 140 點高度。

![左側儲存格跨越整個表格高度，旁邊有三個儲存格，中間的為 Middle。](split-by-height.png)

## **變更表格儲存格背景色彩**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) 選擇實心填滿，並將 [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) 取得的顏色設為紅色，套用於第 3 欄第 4 列的儲存格 `(2, 3)`。

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

在執行此範例前，請將輸入圖片置於工作目錄中。程式使用 [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) 載入圖片，並以 [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) 加入簡報的圖片集合。接著將圖片指定為儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填滿。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) 會將圖片伸展以填滿儲存格，可能會改變長寬比。欄寬與列高以點為單位。載入的圖片於加入簡報後於 `finally` 區塊中釋放。

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

**是否可以為單一儲存格的不同邊設定不同的線條粗細與樣式？**

可以。[top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) 邊框各有獨立屬性，因而每一側的粗細與樣式可以不同。

**如果在將圖片設定為儲存格背景後變更欄/列大小，圖片會發生什麼情況？**

行為取決於 [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/)（stretch/tile）。使用伸展時，圖片會依新儲存格調整；使用平鋪時，平鋪圖塊會重新計算。

**是否可以將超連結指派給儲存格的全部內容？**

[Hyperlinks](/slides/zh-hant/androidjava/manage-hyperlinks/) 於儲存格的文字框內的文字（區段）層級或整個表格/圖形層級設定。實務上，您可以將連結指派給某個區段或儲存格內的全部文字。

**是否可以在單一儲存格內設定不同的字體？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/)（文字段落），可獨立設定字型、樣式、大小與顏色。