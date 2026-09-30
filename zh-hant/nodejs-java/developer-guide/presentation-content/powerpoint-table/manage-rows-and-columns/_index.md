---
title: 使用 JavaScript 管理 PowerPoint 表格中的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/nodejs-java/manage-rows-and-columns/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及 Aspose.Slides for Node.js via Java 來管理 PowerPoint 表格的列與欄，並加速簡報的編輯與資料更新。"
---
## **簡介**

Aspose.Slides for Node.js via Java 讓您透過 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 類別來管理 PowerPoint 簡報中的表格結構與格式。您可以指定標題列、複製或刪除列與欄，並對整列或整欄套用文字格式。

本篇說明這些操作並提供 JavaScript 範例。也示範如何取得表格的樣式預設，以便重新使用。表格列與欄的索引是從 0 開始計算。

## **控制列高**

使用 [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) 以點數設定列的最小高度。它是下限，而非固定高度。[Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) 會回傳實際高度。可透過 [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--) 取得列。

範例會載入 [row-height-input.pptx](row-height-input.pptx)，此簡報在第一張投影片的第一個圖形上有一個表格。其第一列起始高度為 70 點。儲存格使用 18 點 Arial 文字、換行，且上下邊距為 6 點；第二欄較長的文字會換行成多行。範例將最小高度提升至 100 點，然後降至 20 點，並於每次變更後列印實際高度，最後儲存兩個結果。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

使用提供的簡報時，提升最小值會為列額外加空間。降低最小值會移除該額外空間，但實際高度仍大於 20 點，因為文字與儲存格邊距需要更多空間。僅僅降低最小值無法把列的高度降到內容所需空間以下。

影響實際高度的因素包括：

- **文字與字型大小：** 較長的文字、明確的換行或較大的字型會需要更多垂直空間。
- **換行與欄寬：** 啟用換行時，使用 [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) 調整欄寬會產生更多行。較寬的欄位則可減少垂直需求。
- **儲存格邊距：** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) 與 [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) 會增加垂直空間。[Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) 與 [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) 會減少文字可用寬度，造成額外換行。

對於此沒有合併儲存格的表格，需最多垂直空間的儲存格決定整列的內容下限。若要讓列變短，可能還需要縮短文字、減小字型或邊距，或是加寬欄位。

下方圖片顯示相同尺寸的表格。示例結果中，實際高度分別為 70、100 與 55.2 點：最終列仍高於 20 點的最小值。文字測量會因環境中字型不同而略有差異。下載儲存的結果：[increased minimum](row-height-increased.pptx) 與 [decreased minimum](row-height-decreased.pptx)。

| 原始：最小 70 pt，實際 70 pt | 增加：最小 100 pt，實際 100 pt | 減少：最小 20 pt，實際 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **將第一列設為標題列**

使用 [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) 方法將第一列標記為標題格式。其外觀取決於套用於表格的樣式。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 取得投影片上第一個圖形所存的表格。
4. 為其第一列啟用標題格式。
5. 儲存已修改的簡報。

此範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格。它為第一列啟用標題格式，並儲存為 `First_row_header.pptx`。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **複製表格的列或欄**

複製列或欄以重新使用其內容與格式。您可以將副本加入表格末端，或插入至特定位置。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 方法新增表格。
5. 複製所需的列。
6. 複製所需的欄。
7. 儲存已修改的簡報。

此範例需要 `Test.pptx`，且至少有一張投影片。它建立一個三欄五列的表格，尺寸以點數指定。範例將第一列與第一欄的副本加入表格末端，然後在索引 3（即第四個位置）插入第二列與第二欄的副本。最終表格為七列五欄。`false` 參數會停用對相鄰合併列或欄的複製；此表格未使用合併儲存格。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **從表格中移除列或欄**

移除表格中不再需要的列或欄。移除後，後續列或欄的索引會向前移動。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別建立簡報。
2. 取得第一張投影片。
3. 定義欄寬與列高。
4. 使用 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 方法新增表格。
5. 移除第二列與第二欄。
6. 儲存已修改的簡報。

此範例會建立一個三乘三的表格，並移除索引為 1 的列與欄，最終在 `TestTable_out.pptx` 中留下二乘二的表格。尺寸以點數表示。`false` 參數會停用對相鄰合併列或欄的移除；此表格未使用合併儲存格。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格列層級設定文字格式**

對整列設定文字格式，以保證儲存格的一致性。您可以設定字型屬性、段落格式與文字方向，而無需逐一格式化每個儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) 為第一列設定字型高度。
4. 使用 [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 與 [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) 為第一列設定對齊方式與右側段落邊距。
5. 使用 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 為第二列設定垂直文字方向。
6. 儲存已修改的簡報。

此範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格且至少有兩列。它為第一列套用 25 點文字、右對齊與 20 點右側段落邊距，然後為第二列設定垂直文字。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格欄層級設定文字格式**

對整欄設定文字格式，以保證儲存格的一致性。您可以設定字型屬性、段落格式與文字方向，而無需逐一格式化每個儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
2. 取得第一張投影片上的表格。
3. 使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) 為第一欄設定字型高度。
4. 使用 [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 與 [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) 為第一欄設定對齊方式與右側段落邊距。
5. 使用 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 為第二欄設定垂直文字方向。
6. 儲存已修改的簡報。

此範例需要 `table.pptx`，其第一張投影片的第一個圖形為表格且至少有兩欄。它為第一欄套用 25 點文字、右對齊與 20 點右側段落邊距，然後為第二欄設定垂直文字。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得表格樣式屬性**

使用 [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) 方法取得套用於表格的樣式預設，並可在其他表格上重新使用。此方法返回的是樣式預設本身，而非單一儲存格的覆寫格式。

範例建立一個表格，套用 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1)，然後讀回此預設。它會印出對應於 `DarkStyle1` 的整數值，並將表格儲存為 `table.pptx`。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以將 PowerPoint 主題/樣式套用到已建立的表格嗎？**

可以。表格會繼承投影片/版面/母片的主題，您仍可在此基礎上覆寫填色、邊框與文字顏色。

**我可以像 Excel 那樣排序表格列嗎？**

不能，Aspose.Slides 的表格沒有內建排序或篩選功能。請先在記憶體中排序資料，然後依排序後的順序重新填入表格列。

**我可以在保留特定儲存格自訂顏色的同時，使用條紋欄位嗎？**

可以。開啟條紋欄位後，對特定儲存格套用局部格式，儲存格層級的格式會優先於表格樣式。