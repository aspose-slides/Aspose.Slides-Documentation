---
title: 在 Android 上管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/androidjava/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比
- 文字對齊
- 文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 PowerPoint 投影片中建立與編輯表格。探索簡單的 Java 程式碼範例，以精簡您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格將資訊以行與列的方式組織，使閱讀與比較數值更為容易。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) 類別、[ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 介面、[Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) 類別、[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) 介面以及其他類型，讓您能在簡報中建立、更新與管理表格。

## **從頭建立表格**

透過指定位置、欄寬與列高來建立表格。將其加入投影片後，您可以設定儲存格邊框、合併儲存格以及插入文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參照。
3. 定義以點為單位的欄寬陣列。
4. 定義以點為單位的列高陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法將 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 物件新增至投影片。
6. 遍歷每個 [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) ，對上、下、右、左邊框套用格式設定。
7. 合併表格第一列的前兩個儲存格。
8. 透過其 [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) 方法存取合併的儲存格。
9. 設定合併儲存格中的文字。
10. 儲存已修改的簡報。

以下範例在 (100, 50) 點位置建立一個具有三欄五列的表格。它套用寬度為 5 點的紅色邊框，合併第一列的前兩個儲存格，並將結果儲存為 `table.pptx`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **標準表格的編號方式**

在標準表格中，儲存格索引採用零基且以（欄, 列）的順序表示。第一個儲存格的索引為 (0, 0)。

例如，具有 4 欄 4 列的表格之儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此例建立上圖所示的 4 × 4 表格，欄寬與列高均為 70 點，並套用寬度為 5 點的紅色儲存格邊框。座標說明了儲存格索引；範例保持儲存格內容為空，並將表格儲存為 `StandardTables_out.pptx`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **存取現有表格**

表格儲存在投影片的圖形集合中。遍歷圖形以找到表格，然後使用 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 介面讀取或更新其儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
2. 依索引取得包含表格的投影片參照。
3. 遍歷 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 物件，找到表格時停止。如果投影片包含多個表格，使用 [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) 來辨識所需的表格。
4. 更新目標儲存格的文字。
5. 儲存已修改的簡報。

以下範例開啟 `UpdateExistingTable.pptx` 並在第一張投影片上找到第一個表格。它將第 0 欄第 1 列的儲存格設為 `New`，並將結果儲存為 `table1_out.pptx`。輸入檔案必須至少包含一張投影片，且該投影片上的第一個表格必須至少有一欄且兩列。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

若要調整現有表格的列高並了解為何實際高度可能超過請求的最小值，請參閱 [控制列高度](/slides/zh-hant/androidjava/manage-rows-and-columns/#control-row-height)。

## **找出擁有文字框的儲存格**

當通用文字處理程式碼從表格取得 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 時，使用 [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) 方法取得擁有的 [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)。對於表格儲存格的文字框，[ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) 會回傳擁有者，而 [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) 則會回傳 `null`，即使表格本身也是一個圖形。

可以透過唯讀的 [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) 與 [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) 方法取得儲存格座標。[ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) 亦提供唯讀的導覽：它回傳擁有者但不變更所有權。使用前務必檢查回傳的儲存格是否為 `null`。

欲取得完整範例（包括辨識表格儲存格與圖形所有者，以及與 SmartArt 節點相關的圖形），請參閱 [搜尋與取代文字](/slides/zh-hant/androidjava/search-and-replace-text/)。

## **對齊表格文字**

您可以控制單一表格儲存格的垂直錨點與文字方向。本節範例將第一個儲存格的文字置中，並旋轉 270 度。

1. 建立 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參照。
3. 將 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 物件新增至投影片。
4. 從表格取得 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 物件。
5. 取得第一個 [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) 並設定其文字與顏色。
6. 使用 [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) 與 [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) 設定儲存格的垂直錨點與文字方向。
7. 儲存已修改的簡報。

此範例建立一個 4 × 4 的表格，欄寬為 120 點、列高為 100 點。它設定儲存格 (0, 0) 內的文字格式，並為第一列的其餘儲存格加入值，最後將結果儲存為 `Vertical_Align_Text_out.pptx`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格層級設定文字格式**

使用 [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) 為表格中的所有儲存格套用文字格式。其多載接受段落、文字片段與文字框的格式設定，讓您無需逐一遍歷儲存格即可設定這些屬性。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
2. 依索引取得投影片的參照。
3. 從投影片取得 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 物件。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) 設定文字的字型大小。
5. 使用 [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 與 [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) 設定段落對齊方式與右邊距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) 設定文字方向。
7. 儲存已修改的簡報。

以下範例開啟 `table.pptx`（該檔案必須至少包含一張投影片，且第一個圖形為表格）。它將字型大小設定為 25 點，段落右對齊且右邊距為 20 點，並將文字設定為垂直。格式化後的簡報儲存為 `result.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得表格樣式屬性**

使用 [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) 讀取表格的預設樣式，並使用 [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) 指定樣式。本範例將 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) 套用於一個表格，列印預設值，然後將相同的預設套用至第二個表格。兩個表格皆儲存於 `table-style.pptx` 中。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **鎖定表格的長寬比**

表格的長寬比是其寬度與高度的比例。使用 [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) 可鎖定表格的長寬比。

以下範例開啟 `pres.pptx`（該檔案必須至少包含一張投影片，且第一個圖形為表格）。它列印目前的鎖定狀態，啟用長寬比鎖定，列印更新後的狀態 (`true`)，並將結果儲存為 `pres-out.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以為整個表格及其儲存格內的文字啟用從右至左 (RTL) 讀取方向嗎？**

是的。表格提供 [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) 方法，段落則有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-)。同時使用兩者可確保儲存格內的文字以正確的 RTL 順序與呈現方式顯示。

**我如何防止使用者在最終檔案中移動或調整表格的大小？**

使用 [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) 可停用移動、調整大小、選取等功能。此鎖定也適用於表格。

**是否支援在儲存格內插入影像作為背景？**

是的。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/)；影像會依所選的模式（拉伸或平鋪）覆蓋整個儲存格區域。