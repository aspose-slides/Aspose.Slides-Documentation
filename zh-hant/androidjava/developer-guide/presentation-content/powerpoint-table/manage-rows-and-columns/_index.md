---
title: 在 Android 上管理 PowerPoint 表格的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/androidjava/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 首列
- 表格標頭
- 克隆列
- 克隆欄
- 拷貝列
- 拷貝欄
- 移除列
- 移除欄
- 列文字格式化
- 欄文字格式化
- 表格樣式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 管理 PowerPoint 表格的列與欄，並加快簡報編輯與資料更新的速度。"
---
## **簡介**

Aspose.Slides for Android via Java 讓您透過 [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) 類別與 [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) 介面，管理 PowerPoint 簡報中的表格結構與格式。您可以指定標題列、複製或刪除列與欄，並為整列或整欄套用文字格式。

本文以 Java 範例說明這些操作，還示範如何取得表格的樣式預設，以便重新使用。表格列與欄的索引採零基制。

## **控制列高度**

使用 [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) 以點數設定列的最小高度。這只是下限，非固定高度。[IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) 會回傳實際高度。透過 [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--) 取得列。

範例載入 [row-height-input.pptx](row-height-input.pptx)，此檔在第一張投影片的第一個圖形中包含一個表格。其第一列起始於 70 點。儲存格使用 18 點 Arial 文字、換行，且上下邊距為 6 點；第二欄較長的文字會換行成多行。範例將最小高度提升至 100 點，然後降低至 20 點，並在每次變更後列印實際高度，最後將兩個結果儲存。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

使用提供的簡報時，提升最小高度會為列增加空間。降低最小高度會移除該額外空間，但實際高度仍大於 20 點，因為文字與儲存格邊距需要更多空間。僅僅降低最小值無法將列的高度壓低於其內容所需的空間。

影響實際高度的因素包括：

- **文字與字型大小：**較長的文字、明確的換行或較大的字型會需要更多垂直空間。
- **換行與欄寬：**啟用換行後，使用 [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) 縮小欄寬會產生更多行。較寬的欄則可減少垂直所需空間。
- **儲存格邊距：**[ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) 與 [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) 會增加垂直空間。[ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) 與 [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) 會減少文字可用寬度，可能導致額外換行。

對於此未合併儲存格的表格而言，需要最多垂直空間的儲存格會決定整列的內容驅動下限。若要讓列變矮，您可能也需要縮短文字、減小字型或邊距，或是加寬欄。

以下影像展示了相同表格在相同比例下的結果。示例中的實際高度分別為 70、100 與 55.2 點：最終列仍高於 20 點的最小值。文字測量會因環境中可用字型不同而有所差異。下載儲存的結果：[increased minimum](row-height-increased.pptx) 與 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 pt，實際 70 pt | 增加後：最小 100 pt，實際 100 pt | 減少後：最小 20 pt，實際 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **將第一列設為標題列**

使用 [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) 方法將第一列標記為標題格式。其外觀取決於套用於表格的樣式。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 取得投影片上作為第一個圖形的表格。
4. 為其第一列啟用標題格式。
5. 儲存已修改的簡報。

此範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格。範例為第一列啟用標題格式，並將結果儲存為 `First_row_header.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **複製表格列或欄**

複製列或欄以重複使用其內容與格式。您可以將副本附加於表格末端，或插入至特定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法新增表格。
5. 複製所需的列。
6. 複製所需的欄。
7. 儲存已修改的簡報。

此範例需要 `Test.pptx`，其中至少包含一張投影片。範例建立一個三欄五列的表格，尺寸以點數指定。它將第一列與第一欄的副本附加至表格末端，然後在索引 3（第四個位置）插入第二列與第二欄的副本。最終表格擁有七列與五欄。`false` 參數會停用對相鄰合併列或欄的複製；此表格沒有合併儲存格。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **從表格中移除列或欄**

移除表格中不再需要的列或欄。移除項目會使其後面的列或欄索引向前移動。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別建立簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法新增表格。
5. 移除第二列與第二欄。
6. 儲存已修改的簡報。

本範例建立一個 3×3 表格，並移除索引為 1 的列與欄，留下 `TestTable_out.pptx` 中的 2×2 表格。尺寸以點數為單位。`false` 參數會停用移除相鄰合併列或欄；此表格沒有合併儲存格。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格列層級設定文字格式**

對整列套用文字格式，可確保其儲存格保持一致。您可以設定字型屬性、段落格式與文字方向，而不必逐一格式化儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 為第一列使用 [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)。
4. 為第一列使用 [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 與 [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。
5. 為第二列使用 [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。
6. 儲存已修改的簡報。

此範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格且至少有兩列。範例將第一列的文字設為 25 點、右對齊，並將段落右邊距設為 20 點，接著將第二列的文字設定為垂直方向。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格欄層級設定文字格式**

對整欄套用文字格式，可確保其儲存格保持一致。您可以設定字型屬性、段落格式與文字方向，而不必逐一格式化儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 為第一欄使用 [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)。
4. 為第一欄使用 [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 與 [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。
5. 為第二欄使用 [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。
6. 儲存已修改的簡報。

此範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格且至少有兩欄。範例將第一欄的文字設為 25 點、右對齊，並將段落右邊距設為 20 點，接著將第二欄的文字設定為垂直方向。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得表格樣式屬性**

使用 [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) 方法取得套用於表格的預設樣式，並在其他表格上重新使用。此方法會返回樣式預設本身，而非個別儲存格的格式覆寫。

範例建立一個表格，套用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1)，然後讀回該預設。它會列印對應於 `DarkStyle1` 的整數值，並將表格儲存於 `table.pptx`。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題集**

**我可以對已建立的表格套用 PowerPoint 主題/樣式嗎？**

可以。表格會繼承投影片/版面/母片的主題，且您仍然可以在此基礎上覆寫填充、邊框與文字顏色。

**我能像 Excel 那樣對表格列排序嗎？**

不能，Aspose.Slides 的表格沒有內建排序或篩選功能。請先在記憶體中排序資料，然後依排序後的順序重新填入表格列。

**我能在保留特定儲存格自訂顏色的同時使用條紋欄嗎？**

可以。開啟條紋欄後，對特定儲存格套用本機格式；儲存格層級的格式會優先於表格樣式。