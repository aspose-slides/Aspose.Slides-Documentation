---
title: 在 JavaScript 中管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/nodejs-java/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比
- 對齊文字
- 文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 在 PowerPoint 投影片中建立與編輯表格。探索簡單的程式碼範例，以簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格將資訊組織成列和欄，讓閱讀和比較數值變得更容易。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 類別、[Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) 類別以及其他類型，讓您能在簡報中建立、更新和管理表格。

## **從頭建立表格**

透過指定位置、欄寬與列高來建立表格。將其加入投影片後，您可以設定儲存格邊框、合併儲存格，並插入文字。

1. 建立 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 定義以點為單位的欄寬陣列。
4. 定義以點為單位的列高陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) 方法將 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 物件新增至投影片。
6. 遍歷每個 [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) 以套用上、下、右、左邊框的格式設定。
7. 合併表格第一列的前兩個儲存格。
8. 透過其 [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) 方法存取合併後的儲存格。
9. 設定合併儲存格中的文字。
10. 儲存已修改的簡報。

下列範例在 (100, 50) 點處建立具有三欄五列的表格。它套用寬度為 5 點的紅色邊框，合併第一列的前兩個儲存格，並將結果儲存為 `table.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **標準表格的編號方式**

在標準表格中，儲存格索引採用零基且以 (欄, 列) 的順序。第一個儲存格的索引為 (0, 0)。

例如，具有 4 欄 4 列的表格之儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此範例建立上述 4 × 4 表格，欄寬與列高皆為 70 點，並使用寬度為 5 點的紅色儲存格邊框。座標用於說明儲存格索引；範例保留儲存格為空，並將表格儲存為 `StandardTables_out.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **存取現有表格**

表格儲存在投影片的圖形集合中。遍歷圖形以找到表格，然後使用 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 類別讀取或更新其儲存格。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
2. 依索引取得包含表格的投影片參考。
3. 遍歷 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 物件並在找到表格時停止。若投影片包含多個表格，請使用 [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) 以識別所需的表格。
4. 更新目標儲存格中的文字。
5. 儲存已修改的簡報。

下列範例開啟 `UpdateExistingTable.pptx`，並在第一張投影片上找到第一個表格。它將第 0 欄第 1 列的儲存格設定為 `New`，並將結果儲存為 `table1_out.pptx`。輸入檔必須至少包含一張投影片，且該投影片的第一個表格必須至少有一欄兩列。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

若要調整現有表格中列的大小並了解為何其實際高度可能超過請求的最小值，請參閱 [Control Row Height](/slides/zh-hant/nodejs-java/manage-rows-and-columns/#control-row-height)。

## **尋找擁有文字框的儲存格**

當一般文字處理程式碼從表格取得 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 時，請使用 [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) 方法取得擁有的 [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)。對於表格儲存格的文字框，[TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) 會回傳擁有者，而 [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) 會回傳 `null`，即使表格本身也是圖形。

儲存格座標可透過唯讀的 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) 與 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) 方法取得。[TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) 也提供唯讀的導覽：它回傳擁有者但不會變更所有權。在使用之前，務必檢查回傳的儲存格是否為 `null`。

欲取得完整範例以辨識表格儲存格與圖形的擁有者（包括與 SmartArt 節點相關的圖形），請參閱 [Search and Replace Text](/slides/zh-hant/nodejs-java/search-and-replace-text/)。

## **對齊表格內文字**

您可以控制單一表格儲存格的垂直錨點與文字方向。本節範例將文字置中於第一個儲存格，並旋轉 270 度。

1. 建立 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片參考。
3. 將 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 物件新增至投影片。
4. 從表格取得 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) 物件。
5. 取得第一個 [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) 並設定其文字與顏色。
6. 使用 [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) 和 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) 設定儲存格的垂直錨點與文字方向。
7. 儲存已修改的簡報。

此範例建立 4 × 4 表格，欄寬為 120 點，列高為 100 點。它格式化儲存格 (0, 0) 的文字，於第一列的其餘儲存格加入值，並將結果儲存為 `Vertical_Align_Text_out.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格層級設定文字格式**

使用 [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) 將文字格式套用至表格中的所有儲存格。其多載接受部分、段落與文字框的格式設定，讓您無需遍歷個別儲存格即可設定這些屬性。

1. 使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
2. 依索引取得投影片參考。
3. 從投影片取得 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) 物件。
4. 使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) 設定文字的字型大小。
5. 使用 [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 與 [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) 設定段落對齊方式與右邊距。
6. 使用 [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 設定文字方向。
7. 儲存已修改的簡報。

下列範例開啟 `table.pptx`（該檔案必須至少包含一張投影片，且第一個圖形為表格）。它將字型大小設定為 25 點，將段落右對齊且右邊距為 20 點，並將文字設為垂直。格式化後的簡報儲存為 `result.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得表格樣式屬性**

使用 [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) 讀取表格的預設樣式，並使用 [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) 指定它。本範例將 [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) 套用於第一個表格，列印預設值，並將相同的預設套用於第二個表格。兩個表格皆儲存於 `table-style.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **鎖定表格的長寬比**

表格的長寬比是其寬度與高度的比例。使用 [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) 可鎖定此比例。

下列範例開啟 `pres.pptx`（該檔案必須至少包含一張投影片，且第一個圖形為表格）。它列印目前的鎖定狀態，啟用長寬比鎖定，列印更新後的狀態（`true`），並將結果儲存為 `pres-out.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以為整個表格以及其中儲存格的文字啟用從右至左 (RTL) 讀取方向嗎？**

可以。表格提供 [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) 方法，段落則有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-)。同時使用兩者即可確保儲存格內文字的正確 RTL 順序與呈現。

**如何防止使用者在最終檔案中移動或調整表格大小？**

使用 [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) 可停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入影像作為背景？**

可以。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/)，影像會依所選模式（拉伸或平鋪）覆蓋整個儲存格區域。