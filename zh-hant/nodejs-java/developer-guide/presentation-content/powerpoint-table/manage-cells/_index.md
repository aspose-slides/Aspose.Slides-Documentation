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
- 儲存格內影像
- 背景顏色
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 管理 PowerPoint 表格儲存格：識別合併儲存格、移除邊框、拆分儲存格，並使用 Aspose.Slides for Node.js 以 Java 設定背景顏色和影像。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何辨識合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景顏色，以及在表格儲存格內加入影像。範例展示如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔。

Aspose.Slides 使用零基索引以 `(column, row)` 的順序存取表格儲存格。

## **識別合併的表格儲存格**

此範例開啟現有簡報，並將第一張投影片上的第一個形狀當作表格存取。它假設投影片與形狀皆存在且該形狀為表格。接著遍歷所有列與欄，並使用 [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) 來辨識合併區域中的儲存格。對於每個符合的儲存格，會以 `row;column` 的順序輸出儲存格座標、[getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)、[getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)，以及區域的起始座標，包含 [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) 與 [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/)。

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

建立一個 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)，並使用 [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/) 在其第一張投影片上加入表格。欄寬、列高與表格位置皆以點 (point) 為單位指定。此範例將四條儲存格邊框皆設定為 [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)，使其不可見。

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

## **加入對角線儲存格邊框**

使用 [getBorderDiagonalDown](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonaldown/) 從左上角畫到右下角，並使用 [getBorderDiagonalUp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderdiagonalup/) 從左下角畫到右上角。對角線可用於標示角落標題；同時使用兩條對角線可形成 X，將儲存格標示為不適用。

每條對角線都是一個 [LineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/)。在其 [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) 中，使用 [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) 選取 [FillType.Solid](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/)，並透過 [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) 取得顏色。使用 [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) 以點為單位設定線條寬度。

此範例在同一列建立三個儲存格：一個有向下紅色對角線、一個有向上藍色對角線，以及同時具備兩條對角線的儲存格。其上、下、左、右四邊框保持不變。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [210, 210, 210]);
    const rowHeights = java.newArray("double", [160]);
    const table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    const downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    downwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    downwardBorder.setWidth(3);

    const upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    upwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    upwardBorder.setWidth(5);

    const crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    crossDownwardBorder.setWidth(3);

    const crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對角線是一種格式屬性，而非儲存格分割。每個儲存格僅保留單一文字框，可透過 [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/gettextframe/) 存取；對角線兩側的區域無法獨立編輯。

The saved table, rendered in Microsoft PowerPoint:

![三個表格儲存格顯示左上至右下的紅色對角線、左下至右上的藍色對角線，以及兩條對角線形成 X。](diagonal-cell-borders.png)

*由左至右：向下對角線（紅色，3 pt）、向上對角線（藍色，5 pt），以及兩條對角線。*

## **合併表格儲存格**

使用 [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) 可將矩形範圍的表格儲存格合併為單一儲存格。指定範圍左上角與右下角的儲存格。最後一個參數控制合併是否允許包含範圍外的儲存格；`false` 會將合併限制在該範圍內。

此範例建立一個 4x4 的表格，欄寬與列高皆為 70 點，然後合併位於 `(1, 1)` 到 `(2, 2)` 的四個中心儲存格。合併後的儲存格跨兩欄兩列，而表格的底層格線仍保留四欄四列。若要存取合併儲存格的內容或格式，請使用其左上位置：本例中為 `table.get_Item(1, 1)`。合併範圍內其他位置仍屬於表格格線，因此範圍外儲存格的索引不會變更。

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

在前一個範例中合併儲存格會保留表格的格線。拆分儲存格可能會產生新的格線欄，並改變其右側儲存格的欄索引。Aspose.Slides 遵循 PowerPoint 的表格格線模型。

此範例建立一個 4x4 的表格，欄寬與列高皆為 70 點，並對儲存格 `(1, 1)` 呼叫 [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/)。將該儲存格 70 點寬度的一半傳入，以建立兩個等寬的儲存格。

拆分後，兩半儲存格分別可透過 `table.get_Item(1, 1)` 與 `table.get_Item(2, 1)` 存取。表格格線現在有五欄：原本在第 2、3 欄的儲存格分別移至第 3、4 欄。列索引保持不變。拆分後存取儲存格時請使用這些更新後的欄索引。

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

<!-- visual-explanation:manage-cells:start -->
[![未合併的 70 點儲存格拆分為兩個 35 點儲存格，新增第五個格線欄，並將右側的索引向右移動。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*寬度拆分影響儲存格 (1, 1)，使用零基 (column, row) 索引。其他列保留跨越兩個新欄位位置的儲存格。*
<!-- visual-explanation:manage-cells:end -->

### **依列或欄跨距拆分合併的儲存格**

為了在匯入資料前準備已合併的範本儲存格，可使用 [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) 依現有列邊界拆分，或使用 [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) 依欄邊界拆分。

`index` 參數計算拆分上部的列數或左部的欄數；其值相對於合併區域：

- 列拆分：`0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/)。
- 欄拆分：`0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/)。

此範例假設簡報的第一張投影片的第一個形狀為表格，且 `(1, 2)` 與 `(1, 3)` 以垂直方式合併。從較低位置開始，使用 [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) 與 [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) 找到起點，並檢查兩個跨距。接著以 `splitByRowSpan(1)` 拆分第 2、3 列以放置產品名稱。若是水平兩欄合併，則改用 `splitByColSpan(1)`。

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

        // 在拆分後從表格中取得產生的儲存格。
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

表格格線與相鄰儲存格索引保持不變。可依座標取得產生的儲存格；此處兩者的跨距皆為 1，且 [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) 輸出 `false`。較大的區域在一次拆分後仍可部分保留合併狀態。

原始文字與格式保留在上方（或左側）儲存格；新儲存格則為空白，但會繼承儲存格的格式，如填色、邊框與邊距。拆分後請填入內容，並明確設定任何所需的文字格式。

儲存的簡報包含獨立的「Product A」與「Product B」儲存格，且保留了範本的儲存格格式。詳情請參閱 [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/)。

### **依特定高度拆分儲存格**

[splitByHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyheight/) 以點為單位接受上部的高度。 [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) 以格線列數接受上部的高度。若要在右側欄位中置中一個 40 點高的儲存格，先從儲存格實際高度減去 40，然後將剩餘空間平均分配到上方與下方。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [160, 160]);
    const rowHeights = java.newArray("double", [140]);

    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    const height = table.get_Item(1, 0).getHeight();
    const margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

第一次拆分會新增一條格線列，且將儲存格 `(1, 1)` 的下方保留 90 點。第二次拆分會將該儲存格分為一個 40 點的中間儲存格與一個 50 點的底部儲存格。右側欄位現在由三個儲存格組成，從上到下的高度分別為 50、40、50 點。左側儲存格跨越全部三列，且保持原始高度 140 點。

![左側儲存格跨整個表格高度，右側有三個儲存格，中央為 Middle。](split-by-height.png)

## **變更表格儲存格背景顏色**

此範例建立一個欄寬 150 點、列高 50 點的表格。它使用 [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) 選取實心填色，並將 [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) 取得的顏色設為紅色，套用於位於第 3 欄第 4 列的儲存格 `(2, 3)`。

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

在執行此範例前，先將輸入影像放置於工作目錄。程式會使用 [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) 載入影像，並以 [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/) 加入簡報的影像集合。接著將該影像指派給儲存格 `(0, 0)`（表格的第一個儲存格）的圖片填色。

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) 會將影像拉伸以填滿儲存格，可能會改變其長寬比。欄寬與列高以點為單位。載入的影像於加入簡報後於 `finally` 區塊中釋放。

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

**我可以為單一儲存格的不同邊設定不同的線條粗細與樣式嗎？**

是的。[top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) 邊框各自有獨立的屬性，因此每一側的粗細與樣式皆可不同。

**如果在將圖片設定為儲存格背景後，變更欄/列大小，影像會發生什麼情況？**

行為取決於 [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/)。以 stretch 為例，影像會依新儲存格調整；以 tile 為例，圖磚將重新計算。

**我可以為儲存格的所有內容指派超連結嗎？**

[Hyperlinks](/slides/zh-hant/nodejs-java/manage-hyperlinks/) 可以在儲存格文字框內的文字（段落）層級，或在整個表格/形狀層級設定。實務上，您會將連結指派給某段文字或整個儲存格的文字。

**我可以在單一儲存格內設定不同的字體嗎？**

是的。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)（文字片段），可獨立設定格式——字型、樣式、大小與顏色。