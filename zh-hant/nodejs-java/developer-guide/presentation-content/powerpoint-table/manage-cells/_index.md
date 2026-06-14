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
- 儲存格中的影像
- 背景顏色
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 於 PowerPoint 中管理表格儲存格。快速掌握存取、修改與樣式設定，實現順暢的投影片自動化。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中存取和修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格背景色，以及在表格儲存格內加入影像。範例示範如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

## **識別合併的表格儲存格**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 從第一張投影片取得表格。
3. 逐行與逐列遍歷表格以尋找合併的儲存格。
4. 當發現合併的儲存格時輸出訊息。

以下 JavaScript 程式碼示範如何在簡報中識別合併的表格儲存格：

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// 假設 Slide#0.Shape#0 是一個表格
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **移除表格儲存格邊框**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 定義具有寬度的欄位陣列。
4. 定義具有高度的列陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 方法將表格加入投影片。
6. 逐一遍歷每個儲存格，以清除上、下、右、左邊框。
7. 將修改後的簡報儲存為 PPTX 檔案。

以下 JavaScript 程式碼示範如何移除表格儲存格的邊框：

```javascript
// 建立代表 PPTX 檔案的 Presentation 類別實例
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // 在投影片上加入表格形狀
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // 為每個儲存格設定邊框格式
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // 將 PPTX 寫入磁碟
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **合併儲存格的編號**
如果我們合併兩對儲存格 (1, 1) x (2, 1) 與 (1, 2) x (2, 2)，產生的表格會被編號。以下 JavaScript 程式碼示範此過程：

```javascript
// 建立代表 PPTX 檔案的 Presentation 類別實例
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 在投影片上加入表格形狀
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
    // 合併儲存格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // 合併儲存格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

接著再將儲存格 (1, 1) 與 (1, 2) 合併。結果是一個在中心有大型合併儲存格的表格：

```javascript
// 建立代表 PPTX 檔案的 Presentation 類別實例
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 在投影片上加入表格形狀
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
    // 合併儲存格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // 合併儲存格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // 合併儲存格 (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // 將 PPTX 檔案寫入磁碟
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **拆分儲存格的編號**
在先前的範例中，當表格儲存格合併時，其他儲存格的編號系統不會改變。

這次，我們使用一般表格（未合併儲存格的表格），然後嘗試將儲存格 (1,1) 拆分，以取得特殊表格。您可能需要留意此表格的編號，雖然看起來可能很奇怪，但這正是 Microsoft PowerPoint 為表格儲存格編號的方式，Aspose.Slides 亦同樣處理。

以下 JavaScript 程式碼示範我們描述的過程：

```javascript
// 建立代表 PPTX 檔案的 Presentation 類別實例
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // 在投影片上加入表格形狀
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
    // 合併儲存格 (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // 合併儲存格 (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // 拆分儲存格 (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // 將 PPTX 檔案寫入磁碟
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更表格儲存格背景色**

以下 JavaScript 程式碼示範如何變更表格儲存格的背景色：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // 建立新表格
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // 設定儲存格的背景顏色
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **在表格儲存格內加入影像**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 定義具有寬度的欄位陣列。
4. 定義具有高度的列陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 方法將表格加入投影片。
6. 建立 `Images` 物件以保存影像檔案。
7. 將 `IImage` 影像加入 `PPImage` 物件。
8. 將表格儲存格的 `FillFormat` 設為 `Picture`。
9. 將影像加入表格的第一個儲存格。
10. 將修改後的簡報儲存為 PPTX 檔案

以下 JavaScript 程式碼示範在建立表格時如何將影像放置於表格儲存格內：

```javascript
// 建立代表 PPTX 檔案的 Presentation 類別實例
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var islide = pres.getSlides().get_Item(0);
    // 定義欄寬與列高
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // 在投影片上加入表格形狀
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // 使用影像檔案建立 PPImage 物件
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 將影像加入第一個表格儲存格
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // 將 PPTX 檔案儲存到磁碟
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細與樣式嗎？**

是的。[top](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cellformat/getborderright/) 邊框各自有獨立的屬性，因此每一側的粗細與樣式可以不同。這與本文中示範的儲存格各側邊框控制邏輯相符。

**如果在將圖片設定為儲存格背景後，調整欄或列的大小，影像會發生什麼變化？**

其行為取決於 [fill mode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillmode/)（stretch/​tile）。若為 stretch，影像會依新儲存格調整大小；若為 tile，則會重新計算鋪貼的圖塊。本文已說明儲存格內影像的顯示模式。

**我能將超連結指派給儲存格內的全部內容嗎？**

[Hyperlinks](/slides/zh-hant/nodejs-java/manage-hyperlinks/) 可在儲存格文字框內的文字（部分）層級設定，或在整個表格/形狀層級設定。實際上，您可以將連結指派給文字的部分，或指派給儲存格內的全部文字。

**我可以在同一儲存格內設定不同的字型嗎？**

可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portion/)（文字執行）具備獨立的格式設定——字型、樣式、大小與顏色。