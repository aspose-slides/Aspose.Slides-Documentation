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
description: "使用 JavaScript 及 Aspose.Slides for Node.js 在 PowerPoint 投影片中建立與編輯表格。探索簡易程式碼範例以簡化表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是一種有效顯示與呈現資訊的方式。以列與欄排列的儲存格網格中的資訊直觀且易於理解。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 類別、[Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/) 類別以及其他類型，讓您能在各種簡報中建立、更新與管理表格。

## **從頭建立表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 使用 [addTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件新增至投影片。  
6. 遍歷每個 [Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/)，為上、下、左、右邊框套用格式。  
7. 將表格左上角的四個儲存格（前兩列的前兩欄）合併為單一儲存格。  
8. 取得 [Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 新增文字。  
10. 儲存已修改的簡報。

以下 JavaScript 程式碼示範如何在簡報中建立表格：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化表示 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 將表格形狀加入投影片
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 為每個儲存格設定邊框格式
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // 合併左上角 2x2 區塊的儲存格為一個儲存格
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // 在合併後的儲存格加入文字
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // 將簡報儲存至磁碟
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **標準表格中的編號**

在標準表格中，儲存格的編號方式簡單且採用零起始。表格的第一個儲存格索引為 0,0（第 0 欄，第 0 列）。

例如，具有 4 欄 4 列的表格，其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 JavaScript 程式碼示範如何為表格中的儲存格指定編號：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化表示 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 將表格形狀加入投影片
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 為每個儲存格設定邊框格式
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // 將簡報儲存至磁碟
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **存取現有表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得包含表格的投影片參考。  
3. 建立 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件並將其設為 null。  
4. 遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 物件，直至找到表格。  

   如果您懷疑目標投影片只含單一表格，只需檢查其所有形狀。當形狀被辨識為表格時，可將其型別轉換為 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件。但若投影片包含多個表格，則建議透過其 [setAlternativeText(String value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) 來搜尋所需的表格。  
5. 使用 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件操作表格。以下範例會設定表格中某個儲存格的文字。  
6. 儲存已修改的簡報。

以下 JavaScript 程式碼示範如何存取並操作現有表格：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化表示 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 將 TableEx 初始化為 null
    var tbl = null;
    // 遍歷形狀並設定找到的表格參考
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // 設定第二列第一欄的文字
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // 將已修改的簡報儲存至磁碟
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **尋找擁有 TextFrame 的儲存格**

當通用文字處理程式碼從表格取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 時，請使用 [TextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentCell--) 方法取得擁有的 [Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/)。對於表格儲存格的文字框，[TextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentCell--) 會回傳擁有者，而 [TextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentShape--) 則回傳 `null`，即使表格本身也是一個形狀。

儲存格座標可透過唯讀的 [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) 與 [Cell.getFirstRowIndex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) 方法取得。[TextFrame.getParentCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentCell--) 亦提供唯讀的導覽：它回傳擁有者但不會變更所有權。使用前務必檢查回傳的儲存格是否為 `null`。

欲取得完整範例，說明如何辨識表格儲存格與形狀擁有者（含 SmartArt 節點相關形狀），請參閱 [Search and Replace Text](/slides/zh-hant/nodejs-java/search-and-replace-text/)。

## **對齊表格中的文字**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件新增至投影片。  
4. 從表格取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 物件。  
5. 取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 的 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/)。  
6. 將文字垂直對齊。  
7. 儲存已修改的簡報。

以下 JavaScript 程式碼示範如何對齊表格中的文字：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // 將表格形狀加入投影片
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // 取得文字框
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // 為文字框建立 Paragraph 物件
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // 為段落建立 Portion 物件
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // 垂直對齊文字
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // 將簡報儲存至磁碟
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在表格層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 從投影片取得 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件。  
4. 設定文字的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 設定 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 與 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)。  
6. 設定 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 儲存已修改的簡報。  

以下 JavaScript 程式碼示範如何將所選格式套用至表格中的文字：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // 假設第一張投影片上的第一個形狀是一個表格
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 設定表格儲存格的字型高度
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // 一次呼叫設定表格儲存格的文字對齊與右邊距
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // 設定表格儲存格的文字垂直類型
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定表格樣式預設**

Aspose.Slides 以 [TableStylePreset](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tablestylepreset/) 列舉提供內建的 PowerPoint 表格樣式，您可以將相同外觀套用至任意表格。以下 JavaScript 程式碼示範如何將表格的預設樣式取代為預設樣式：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// 更改預設樣式預設主題
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **鎖定表格的長寬比**

幾何形狀的長寬比是其在不同維度上的尺寸比例。Aspose.Slides 提供的 [**setAspectRatioLocked**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) 屬性，可讓您鎖定表格及其他形狀的長寬比設定。

以下 JavaScript 程式碼示範如何為表格鎖定長寬比：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以為整個表格及其儲存格內的文字啟用由右至左 (RTL) 閱讀方向嗎？**

可以。表格提供 [setRightToLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/setrighttoleft/) 方法，段落則有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/)。同時使用可確保儲存格內文字的正確 RTL 順序與呈現。

**如何防止使用者在最終檔案中移動或調整表格大小？**

使用形狀鎖定功能即可停用移動、調整大小、選取等操作，這些鎖定同樣適用於表格。

**是否支援在儲存格內插入圖像作為背景？**

支援。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/)，圖像會依所選模式（拉伸或鋪排）覆蓋儲存格區域。