---
title: 使用 JavaScript 在簡報中管理文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/nodejs-java/manage-textbox/
keywords:
- 文字方塊
- 文字框
- 新增文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 新增文字欄位
- 新增超連結
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js 讓您能輕鬆在 PowerPoint 與 OpenDocument 檔案中建立、編輯與複製文字方塊，提升簡報自動化效能。"
---
## **簡介**

投影片上的文字通常存在於文字方塊或圖形中。因此，要在投影片上加入文字，您必須先新增文字方塊，然後在文字方塊內放入文字。Aspose.Slides for Node.js via Java 提供了 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 類別，允許您新增包含文字的圖形。

{{% alert title="資訊" color="info" %}}

Aspose.Slides 也提供了 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape) 類別，允許您將圖形新增至投影片中。然而，透過 `Shape` 類別新增的並非所有圖形都能容納文字。但透過 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 類別新增的圖形可能包含文字。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

因此，當處理想要加入文字的圖形時，您可能需要檢查並確認它是透過 `AutoShape` 類別轉型的。只有這樣，您才能使用 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame)（`AutoShape` 的屬性）。請參閱本頁面的 [Update Text](https://docs.aspose.com/slides/zh-hant/nodejs-java/manage-textbox/#update-text) 章節。

{{% /alert %}}

## **在投影片上建立文字方塊**

要在投影片上建立文字方塊，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參考。  
3. 在投影片的指定位置新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 物件，並將 [ShapeType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) 設為 `Rectangle`，取得新新增的 `AutoShape` 物件的參考。  
4. 將 `TextFrame` 屬性新增至 `AutoShape` 物件，以容納文字。在下例中，我們加入了這段文字：*Aspose TextBox*  
5. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。  

以下 JavaScript 程式碼——上述步驟的實作——示範如何在投影片中加入文字：

```javascript
// 實例化 Presentation
var pres = new aspose.slides.Presentation();
try {
    // 取得簡報中的第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增一個型別設定為 Rectangle 的 AutoShape
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // 在 Rectangle 中加入 TextFrame
    ashp.addTextFrame(" ");
    // 存取文字框
    var txtFrame = ashp.getTextFrame();
    // 為文字框建立 Paragraph 物件
    var para = txtFrame.getParagraphs().get_Item(0);
    // 為段落建立 Portion 物件
    var portion = para.getPortions().get_Item(0);
    // 設定文字
    portion.setText("Aspose TextBox");
    // 將簡報儲存至磁碟
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **檢查文字方塊圖形**

Aspose.Slides 提供了來自 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 類別的 `isTextBox` 方法，讓您可以檢查圖形並識別文字方塊。

![文字方塊與圖形](istextbox.png)

此 JavaScript 程式碼示範如何檢查圖形是否以文字方塊建立：

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

請注意，如果僅使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/) 類別的 `addAutoShape` 方法新增自動圖形，該自動圖形的 `isTextBox` 方法將回傳 `false`。然而，當您使用 `addTextFrame` 方法或 `setText` 方法為自動圖形加入文字後，`isTextBox` 屬性會回傳 `true`。

```javascript
var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() 返回 false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() 返回 true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() 返回 false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() 返回 true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() 返回 false
shape3.addTextFrame("");
// shape3.isTextBox() 返回 false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() 返回 false
shape4.getTextFrame().setText("");
// shape4.isTextBox() 返回 false
```

## **在文字方塊中新增欄位**

Aspose.Slides 提供了來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat) 類別的 [setColumnCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) 與 [setColumnSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) 方法，讓您能在文字方塊中新增欄位。您可以指定文字方塊的欄位數量，並設定欄與欄之間以點為單位的間距。

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 取得簡報中的第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增一個型別設定為 Rectangle 的 AutoShape
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // 在 Rectangle 中加入 TextFrame
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // 取得 TextFrame 的文字格式
    var format = aShape.getTextFrame().getTextFrameFormat();
    // 指定 TextFrame 中的欄位數量
    format.setColumnCount(3);
    // 指定欄位之間的間距
    format.setColumnSpacing(10);
    // 儲存簡報
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在文字框中新增欄位**

Aspose.Slides for Node.js via Java 提供了 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat) 類別的 [setColumnCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) 方法，讓您能在文字框中新增欄位。透過此屬性，您可以指定文字框中想要的欄位數。

```javascript
var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **更新文字**

Aspose.Slides 允許您變更或更新文字方塊中的文字，或簡報中所有文字的內容。

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // 檢查形狀是否支援文字框 (IAutoShape)。
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // 迭代文字框中的段落
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // 迭代段落中的每個 Portion
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// 更改文字
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// 更改格式
                    }
                }
            }
        }
    }
    // 儲存已修改的簡報
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **新增含超連結的文字方塊**

您可以在文字方塊內插入連結。當點擊文字方塊時，使用者會被導向開啟該連結。

要新增包含連結的文字方塊，請遵循以下步驟：

1. 建立 `Presentation` 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參考。  
3. 在投影片的指定位置新增一個 `AutoShape` 物件，將 `ShapeType` 設為 `Rectangle`，取得新新增的 AutoShape 物件的參考。  
4. 在 `AutoShape` 物件中加入 `TextFrame`，其預設文字為 *Aspose TextBox*。  
5. 實例化 `HyperlinkManager` 類別。  
6. 將 `HyperlinkManager` 物件指派給與您在 `TextFrame` 中偏好的部分相關聯的 [HyperlinkClick](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) 屬性。  
7. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。  

以下 JavaScript 程式碼——上述步驟的實作——示範如何在投影片中新增含超連結的文字方塊：

```javascript
// 實例化表示 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得簡報中的第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增型別設定為 Rectangle 的 AutoShape 物件
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // 將形狀轉型為 AutoShape
    var pptxAutoShape = shape;
    // 存取與 AutoShape 相關聯的 ITextFrame 屬性
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // 向框架加入一些文字
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // 為 Portion 文字設定超連結
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // 儲存 PPTX 簡報
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**文字方塊與文字佔位符在使用母版投影片時有何差異？**

佔位符會從 [master](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/) 繼承樣式/位置，且可在 [layouts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/) 上覆寫，而普通的文字方塊則是特定投影片上的獨立物件，切換版面配置時不會變動。

**如何在不修改圖表、表格與 SmartArt 內文字的情況下，對簡報執行大量文字取代？**

將迭代範圍限制於具有文字框的自動圖形，並排除嵌入式物件（[charts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartart/)），可分別遍歷其集合或直接跳過這些物件類型。