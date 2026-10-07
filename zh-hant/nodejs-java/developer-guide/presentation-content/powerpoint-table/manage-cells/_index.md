---
title: 使用 JavaScript 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/nodejs-java/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格內的影像
- 背景顏色
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 管理 PowerPoint 表格儲存格：識別合併的儲存格、移除邊框、拆分儲存格，並透過 Aspose.Slides for Node.js 以 Java 設定背景顏色和影像。"
---
## **概覽**

Aspose.Slides 允許您在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景顏色，以及在表格儲存格內加入影像。範例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

Aspose.Slides 使用零基索引以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有的簡報，並將第一張投影片上的第一個圖形視為表格。它假設投影片與圖形皆存在且該圖形為表格。接著遍歷所有列與欄，並使用 [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) 來識別合併區域中的儲存格。對於每個匹配項，會以 `row;column` 的順序輸出儲存格座標、[getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)，以及區域的起始座標，[getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) 與 [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/)。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **移除表格儲存格邊框**

建立一個 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 並使用 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) 在其第一張投影片上加入表格。欄寬、列高與表格位置皆以點 (point) 為單位指定。此範例將四條儲存格邊框全部設定為 [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)，使其不可見。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) 可將矩形範圍的表格儲存格合併為單一儲存格。指定範圍左上角與右下角的儲存格。最後一個參數控制合併是否可包含指定範圍之外的儲存格；`false` 會將合併限制在該範圍內。

此範例建立一個 4x4 的表格，欄與列均為 70 點，然後合併位於 `(1, 1)` 到 `(2, 2)` 的四個中心儲存格。合併後的儲存格跨越兩欄兩列，而表格的底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上角的位置：在本範例中為 `table.get_Item(1, 1)`。合併範圍內的其他位置仍屬於表格格線，因此範圍外的儲存格索引不會改變。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **拆分表格儲存格**

在前述例子中合併儲存格會保留表格的格線。拆分儲存格可能會引入新的一欄，並更改其右側儲存格的欄索引。Aspose.Slides 採用 PowerPoint 的表格格線模型。

此範例建立一個 4x4 的表格，欄與列皆為 70 點，並對儲存格 `(1, 1)` 呼叫 [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/)。將該儲存格 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

拆分後，兩個半部可分別以 `table.get_Item(1, 1)` 與 `table.get_Item(2, 1)` 取用。表格格線現在變為五欄：原本位於第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。拆分後存取儲存格時，請使用這些更新後的欄索引。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **按列或欄跨距拆分合併儲存格**

若要為資料填入準備已合併的範本儲存格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) 依現有列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) 依欄邊界拆分。

`index` 參數計算拆分上方的列數或左側的欄數；它相對於合併區域：

- 列拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)。

- 欄拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)。

此範例假設簡報的第一張投影片的第一個圖形是一個表格，且 `(1, 2)` 與 `(1, 3)` 以垂直方式合併。從較低的位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) 與 [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) 定位起始點，並檢查兩個跨距。`splitByRowSpan(1)` 隨後分離第 2、3 列以放置產品名稱。若為水平的兩欄合併，則改用 `splitByColSpan(1)`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // 從拆分後的表格中取得產生的儲存格。
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

表格格線與周圍儲存格的索引保持不變。可依座標取得結果儲存格；此處兩者的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) 會回傳 `false`。較大的區域在一次拆分後仍可能部分保持合併。

原始文字與其格式保留在上方（或左側）儲存格；新建立的儲存格為空，但會繼承儲存格的格式設定，例如填充、邊框與邊距。拆分後請為儲存格填入資料，並明確設定任何需要的文字格式。

儲存的簡報中包含獨立的「Product A」與「Product B」儲存格，且保留了範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)。

## **變更表格儲存格背景顏色**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) 選擇實心填充，並將 [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) 回傳的顏色設定為紅色，套用於儲存格 `(2, 3)`（第 3 欄第 4 列）。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在表格儲存格內加入影像**

在執行此範例前，請將輸入影像放置於工作目錄中。程式使用 [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) 載入影像，並以 [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) 加入簡報的影像集合。接著將影像指定為儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填充。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) 會將影像拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。載入的影像在加入簡報後於 `finally` 區塊中釋放。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細和樣式嗎？**

可以。儲存格的 [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)、[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)、[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)、[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) 邊框各有獨立的屬性，因此每一側的粗細與樣式可以不同。

**如果在將圖片設為儲存格背景後，變更欄/列尺寸，影像會怎樣？**

其行為取決於 [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)（stretch/​tile）。使用 stretch 時，影像會依新儲存格調整；使用 tile 時，瓦片會重新計算。

**我可以將超連結指派給儲存格的所有內容嗎？**

[Hyperlinks](/slides/zh-hant/nodejs-java/manage-hyperlinks/) 會設定在儲存格文字框內的文字（段落）層級，或在整個表格/圖形層級。實作上，您可以將連結指派給某段文字或指派給儲存格內的全部文字。

**我可以在單一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)（執行序）且可獨立設定格式—字型、樣式、大小與顏色。