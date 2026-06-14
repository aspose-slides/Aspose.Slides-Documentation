---
title: 使用 JavaScript 管理 PowerPoint 表格中的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/nodejs-java/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 首列
- 表格標題列
- 複製列
- 複製欄
- 複製列
- 複製欄
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
description: "使用 JavaScript 以及 Aspose.Slides for Node.js（透過 Java）在 PowerPoint 中管理表格的列與欄，加速簡報編輯與資料更新。"
---
## **簡介**

為了讓您在 PowerPoint 簡報中管理表格的列與欄，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/) 類別以及其他類型。

## **將首列設為標題列**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例並載入簡報。
2. 透過索引取得投影片的參考。 
3. 建立 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件並將其設為 null。
4. 遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/) 物件以尋找相關的表格。
5. 將表格的首列設為標題列。 

此 JavaScript 程式碼示範如何將表格的首列設為標題列：

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 初始化 null TableEx
    var tbl = null;
    // 遍歷形狀並設定表格的參照
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // 將表格的首列設定為標題列
            tbl.setFirstRow(true);
        }
    }
    // 將簡報儲存至磁碟
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **複製表格的列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例並載入簡報,
2. 透過索引取得投影片的參考。 
3. 定義 `columnWidth` 陣列。
4. 定義 `rowHeight` 陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件新增至投影片。
6. 複製表格列。
7. 複製表格欄。
8. 儲存已修改的簡報。

此 JavaScript 程式碼示範如何複製 PowerPoint 表格的列或欄：

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 在投影片中新增表格圖形
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 在第 1 列第 1 個儲存格加入文字
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // 在第 1 列第 2 個儲存格加入文字
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // 在表格末端複製第 1 列
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // 在第 2 列第 1 個儲存格加入文字
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // 在第 2 列第 2 個儲存格加入文字
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // 將第 2 列複製為表格的第 4 列
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // 在末端複製第一欄
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // 在第 4 欄位置複製第 2 欄
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // 將簡報儲存至磁碟
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **從表格中移除列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例並載入簡報,
2. 透過索引取得投影片的參考。 
3. 定義 `columnWidth` 陣列。
4. 定義 `rowHeight` 陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件新增至投影片。
6. 移除表格列。
7. 移除表格欄。
8. 儲存已修改的簡報。 

此 JavaScript 程式碼示範如何從表格中移除列或欄：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在表格列層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例並載入簡報,
2. 透過索引取得投影片的參考。 
3. 從投影片存取相關的 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件。
4. 設定首列儲存格的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)。
5. 設定首列儲存格的 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 與 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)。
6. 設定次列儲存格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。
7. 儲存已修改的簡報。

此 JavaScript 程式碼示範此操作。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 假設第一張投影片上的第一個形狀是表格
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // 設定首列儲存格的字型高度
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // 設定首列儲存格的文字對齊方式與右邊距
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // 設定次列儲存格的文字垂直類型
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // 將簡報儲存至磁碟
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在表格欄層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例並載入簡報,
2. 透過索引取得投影片的參考。 
3. 從投影片存取相關的 [Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Table) 物件。
4. 設定首欄儲存格的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-)。
5. 設定首欄儲存格的 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) 與 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)。
6. 設定次欄儲存格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)。
7. 儲存已修改的簡報。 

此 JavaScript 程式碼示範此操作：

```javascript
    // 建立 Presentation 類別的實例
    var pres = new aspose.slides.Presentation();
    try {
        // 假設第一張投影片上的第一個形狀是表格
        var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        // 設定第一欄儲存格的字型高度
        var portionFormat = new aspose.slides.PortionFormat();
        portionFormat.setFontHeight(25);
        someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
        // 一次設定第一欄儲存格的文字對齊方式與右邊距
        var paragraphFormat = new aspose.slides.ParagraphFormat();
        paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
        paragraphFormat.setMarginRight(20);
        someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
        // 設定第二欄儲存格的文字垂直類型
        var textFrameFormat = new aspose.slides.TextFrameFormat();
        textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
        someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
        pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **取得表格樣式屬性**

Aspose.Slides 允許您取得表格的樣式屬性，以便將這些資訊用於其他表格或其他地方。以下 JavaScript 程式碼示範如何從表格預設樣式取得樣式屬性：

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

## **常見問題**

**我可以將 PowerPoint 主題/樣式套用到已建立的表格嗎？**

是的。表格會繼承投影片/版面/母片的主題，且您仍然可以在此主題之上覆寫填色、邊框和文字顏色。

**我可以像在 Excel 中那樣對表格列進行排序嗎？**

不，Aspose.Slides 表格沒有內建的排序或篩選功能。請先在記憶體中排序資料，然後依該順序重新填入表格列。

**我可以在保留特定儲存格自訂顏色的同時，使用分段（條紋）欄嗎？**

是的。啟用分段欄後，您可以對特定儲存格套用本地格式；儲存格層級的格式會優先於表格樣式。