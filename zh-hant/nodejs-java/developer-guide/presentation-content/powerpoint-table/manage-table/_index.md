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
description: "使用 JavaScript 及 Node.js 版 Aspose.Slides 在 PowerPoint 投影片中建立與編輯表格。探索簡單的程式碼範例，簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是顯示和呈現資訊的高效方法。以格子（按行列排列）的網格形式呈現的資訊直觀且易於理解。

Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 類別、[Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/) 類別以及其他類型，讓您能在各種簡報中建立、更新和管理表格。

## **從頭建立表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 使用 [addTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件新增至投影片。  
6. 遍歷每個 [Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/) ，對上、下、右、左邊框套用格式設定。  
7. 合併表格第一列的前兩個儲存格。  
8. 存取 [Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/ ) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。  
9. 在 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 中加入一些文字。  
10. 儲存已修改的簡報。

以下 JavaScript 程式碼示範如何在簡報中建立表格：

```javascript
// 實例化一個代表 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 存取第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 將表格形狀新增至投影片
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
    // 合併第 1 列的第 1 與第 2 個儲存格
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // 在合併的儲存格中加入文字
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // 將簡報儲存至磁碟
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **標準表格的編號方式**

在標準表格中，儲存格的編號方式簡單且以 0 為起始。表格的第一個儲存格編號為 0,0（第 0 欄，第 0 列）。

例如，具有 4 列 4 行的表格，其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 JavaScript 程式碼示範如何為表格中的儲存格指定編號：

```javascript
// 實例化代表 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 存取第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 將表格形狀新增至投影片
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

## **存取既有表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得包含該表格的投影片參考。  
3. 建立 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件，並將其設為 null。  
4. 遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 物件，直至找到表格。  

   如果您懷疑該投影片僅包含單一表格，只需檢查其所有形狀。當形狀被識別為表格時，您可以將其型別轉換為 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件。但如果該投影片包含多個表格，則最好透過其 [setAlternativeText(String value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-) 來搜尋需要的表格。  
5. 使用 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件操作表格。以下範例中，我們為表格新增了一列。  
6. 儲存已修改的簡報。

以下 JavaScript 程式碼示範如何存取並操作既有表格：

```javascript
// 實例化代表 PPTX 檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // 存取第一張投影片
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

## **對齊表格文字**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件新增至投影片。  
4. 從表格取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 物件。  
5. 取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 中的 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/)。  
6. 將文字垂直對齊。  
7. 儲存已修改的簡報。

以下 JavaScript 程式碼示範如何在表格中對齊文字：

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // 將表格形狀新增至投影片
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // 存取文字框
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
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // 將簡報儲存至磁碟
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定表格層級的文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 從投影片取得 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件。  
4. 設定文字的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 設定 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 與 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)。  
6. 設定 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 儲存已修改的簡報。  

以下 JavaScript 程式碼示範如何對表格文字套用您偏好的格式設定：

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // 假設第一張投影片上的第一個形狀是表格
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 設定表格儲存格的字型高度
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // 一次呼叫設定表格儲存格的文字對齊方式與右側邊距
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // 設定表格儲存格的文字垂直類型
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **取得表格樣式屬性**

Aspose.Slides 允許您取得表格的樣式屬性，以便將這些細節用於其他表格或其他地方。以下 JavaScript 程式碼示範如何從表格預設樣式取得樣式屬性：

```javascript
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

幾何圖形的長寬比是其在不同維度上的尺寸比例。Aspose.Slides 提供了 [**setAspectRatioLocked**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) 屬性，以便您能鎖定表格及其他形狀的長寬比設定。

以下 JavaScript 程式碼示範如何鎖定表格的長寬比：

```javascript
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

## **FAQ**

**我可以為整個表格及其儲存格內的文字啟用從右至左 (RTL) 讀取方向嗎？**

是的。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/setrighttoleft/) 方法，段落則有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/)。同時使用兩者即可確保儲存格內的 RTL 順序與渲染正確。

**如何防止使用者在最終檔案中移動或調整表格大小？**

使用形狀鎖定可停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入圖片作為背景？**

是的。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillformat/)，圖片會根據選擇的模式（拉伸或平鋪）覆蓋儲存格區域。