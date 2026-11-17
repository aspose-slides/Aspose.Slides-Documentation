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
- 分割儲存格
- 儲存格中的圖片
- 背景顏色
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 Java 中管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、分割儲存格，並設定背景顏色與圖片。"
---
## **概述**

Aspose.Slides 允許您在 PowerPoint 簡報中存取和修改表格儲存格。本文章說明如何辨識合併的儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格背景色，以及在表格儲存格內加入圖片。範例顯示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用零基索引，以 `(column, row)` 的順序存取表格儲存格。

## **辨識合併的表格儲存格**

範例開啟現有簡報，將第一張投影片的第一個圖形作為表格存取。它假設投影片與圖形皆存在且圖形為表格。接著遍歷所有列與欄，並使用 [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) 來辨識合併區域中的儲存格。對於每個符合的儲存格，會以 `row;column` 的順序列印儲存格座標、[getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)、[getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)，以及區域的起始座標，[getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) 和 [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--)。

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

建立一個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)，並使用 [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 在其第一張投影片加入表格。欄寬、列高以及表格位置皆以點為單位指定。範例將四個儲存格邊框全部設定為 [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)，使其不可見。

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

## **新增對角線儲存格邊框**

使用 [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) 在左上角到右下角畫線，使用 [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) 在左下角到右上角畫線。對角線可標示角落標題；兩條對角線組合則形成 X，表示該儲存格不適用。

每條對角線都是一個 [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/)。在其 [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) 中，使用 [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 選取 [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)，並透過 [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 設定顏色。再以 [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) 以點為單位設定線寬。

範例在同一列建立三個儲存格：一個紅色向下對角線、一個藍色向上對角線，以及同時具有兩條對角線的儲存格。上、下、左、右四側邊框保持不變。

```java
import com.aspose.slides.*;
import java.awt.Color;

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

對角線屬於格式屬性，而非儲存格分割。每個儲存格仍保留唯一的文字框，可透過 [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) 存取；對角線兩側的區域無法獨立編輯。

儲存的表格在 Microsoft PowerPoint 中的呈現：

![三個表格儲存格分別顯示左上至右下的紅色對角線、左下至右上的藍色對角線，以及形成 X 的兩條對角線。](diagonal-cell-borders.png)

*左至右：向下對角線（紅色，3 pt）、向上對角線（藍色，5 pt）以及兩條對角線。*

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) 將矩形範圍的表格儲存格合併成單一儲存格。指定範圍左上角與右下角的儲存格。最後一個參數控制合併是否可包含範圍外的儲存格；`false` 會將合併限制在該範圍內。

範例建立一個 4×4 的表格，欄寬與列高皆為 70 點，然後將中心的四個儲存格從 `(1, 1)` 合併至 `(2, 2)`。合併後的儲存格跨兩欄兩列，而底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，使用其左上角位置：本例中的 `table.get_Item(1, 1)`。合併範圍內其他位置仍屬於表格格線，因此範圍外的儲存格索引不會改變。

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

## **分割表格儲存格**

在前一個範例中合併儲存格不會改變表格的格線。分割儲存格可能會產生新格線欄，並改變其右側儲存格的欄索引。Aspose.Slides 依循 PowerPoint 的表格格線模型。

本例建立一個 4×4 的表格，欄寬與列高皆為 70 點，並在儲存格 `(1, 1)` 上呼叫 [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-)。傳入儲存格寬度的半數，以產生兩個等寬的儲存格。

分割後，可分別以 `table.get_Item(1, 1)` 與 `table.get_Item(2, 1)` 取用兩半。此時表格格線變為五欄：原本位於第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。分割後存取儲存格時，請使用更新後的欄索引。

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
[![未合併的 70 點儲存格分割成兩個 35 點儲存格，新增第五個格線欄並將右側索引向右移動。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*寬度分割影響儲存格 (1, 1)，使用零基 (欄, 列) 索引。其他列保留跨越兩個新欄位置的儲存格。*
<!-- visual-explanation:manage-cells:end -->

### **依列或欄跨距分割合併儲存格**

若要為資料填充做準備，請使用 [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) 沿現有列邊界分割，或使用 [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) 沿欄邊界分割。

`index` 參數計算分割上部的列數或左部的欄數，且相對於合併區域：

- 列分割：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--)。
- 欄分割：`0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--)。

範例假設簡報的第一張投影片第一個圖形為表格，且儲存格 `(1, 2)` 與 `(1, 3)` 垂直合併。從下方位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) 與 [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) 找到起點，並檢查兩個跨距。`splitByRowSpan(1)` 隨後分離第 2、3 列，以放置產品名稱。若為水平兩欄合併，則改為使用 `splitByColSpan(1)`。

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

        // 在分割後從表格中取得產生的儲存格。
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

表格格線與周圍儲存格索引保持不變。可依座標取得結果儲存格；此處兩個儲存格的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) 會回傳 `false`。較大的區域在一次分割後仍可部分保留合併狀態。

原始文字及其格式保留在上方（或左側）儲存格；新儲存格為空，但繼承儲存格的填充、邊框與邊距等格式。分割後請填入文字，並明確設定任何必要的文字格式。

儲存的簡報包含分別為「Product A」與「Product B」的儲存格，且保留了模板儲存格的格式。請參閱 [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) 以取得更多資訊。

### **在特定高度分割儲存格**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) 以點數指定上部的高度。[splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) 以格線列數指定上部的行數。若要將 40 點的儲存格置於右側欄的中間，先將儲存格實際高度減去 40 點，然後將剩餘空間平均分配於上下。

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

第一次分割會新增一個格線列，且在儲存格 `(1, 1)` 的下方留下 90 點。第二次分割將該儲存格再分為 40 點的中間儲存格與 50 點的底部儲存格。右側欄現在由上至下依序為 50、40、50 點的三個儲存格。左側儲存格跨越全部三列，保留原始的 140 點高度。

![左側儲存格跨越整個表格高度，旁邊有三個儲存格，其中中間儲存格位於中心。](split-by-height.png)

## **變更表格儲存格背景顏色**

此範例建立一個欄寬 150 點、列高 50 點的表格。使用 [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 選取實心填充，並將 [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 回傳的顏色設為紅色，以套用於儲存格 `(2, 3)`（第三欄、第四列）。

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

## **在表格儲存格內加入圖片**

在執行本範例前，請先將輸入圖片放置於工作目錄。程式使用 [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) 載入圖片，並以 [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-) 將其加入簡報的圖片集合。然後將該圖片指派給儲存格 `(0, 0)`（表格中的第一個儲存格）的圖片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) 會將圖片拉伸填滿儲存格，可能會改變其長寬比例。欄寬與列高皆以點為單位。載入的圖片會在加入簡報後於 `finally` 區塊中釋放。

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

**我可以為單一儲存格的不同邊設定不同的線條粗細和樣式嗎？**

可以。[top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)、[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)、[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)、[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) 四側邊框各自有獨立屬性，因而可設定不同的粗細與樣式。

**如果在設定圖片為儲存格背景後調整欄/列大小，圖片會怎樣？**

行為取決於 [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/)（stretch/tile）。使用拉伸時，圖片會依新儲存格尺寸自動調整；使用平鋪時，平鋪圖塊會重新計算。

**我可以將超連結指派給儲存格的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/java/manage-hyperlinks/) 是在儲存格文字框（文字片段）層級設定，或在整個表格/圖形層級設定。實務上，您會將連結指派給文字片段，或將全部文字設定為相同的連結。

**我可以在單一儲存格內使用不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/)（文字片段），每個片段可擁有獨立的字型、樣式、大小與顏色。