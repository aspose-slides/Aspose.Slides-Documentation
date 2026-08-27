---
title: 使用 JavaScript 管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/nodejs-java/manage-textbox/
keywords:
- 文字方塊
- 文字框
- 加入文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 加入文字欄
- 加入超連結
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js 使在 PowerPoint 與 OpenDocument 檔案中建立、編輯、複製文字方塊變得簡單，提升您的簡報自動化。"
---
## **簡介**

投影片上的文字通常存在於文字方塊或圖案中。因此，要在投影片上加入文字，必須先新增文字方塊，然後在文字方塊內放入文字。Aspose.Slides for Node.js via Java 提供了[AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape)類別，允許您新增包含文字的圖案。

{{% alert title="資訊" color="info" %}}

Aspose.Slides 也提供了[Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape)類別，可讓您將圖案加入投影片。然而，透過 `Shape` 類別新增的圖案未必能容納文字。透過[AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape)類別新增的圖案則可能包含文字。

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

因此，當處理想要加入文字的圖案時，您應先確認該圖案是以 `AutoShape` 類別轉型的。只有這樣才可以使用 `AutoShape` 下的[TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame)屬性。請參閱本頁面的[Update Text](https://docs.aspose.com/slides/zh-hant/nodejs-java/manage-textbox/#update-text)章節。

{{% /alert %}}

## **在投影片上建立文字方塊**

建立投影片上的文字方塊請依照以下步驟：

1. 建立一個[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation)類別的實例。  
2. 取得新建立的簡報中第一張投影片的參考。  
3. 在投影片的指定位置加入一個 `ShapeType` 設為 `Rectangle` 的[AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape)物件，並取得新加入的 `AutoShape` 物件參考。  
4. 為 `AutoShape` 物件加入 `TextFrame` 屬性以容納文字。以下範例中，我們加入的文字為 *Aspose TextBox*。  
5. 最後透過 `Presentation` 物件寫入 PPTX 檔案。  

以下 JavaScript 程式碼—上述步驟的實作範例—示範如何在投影片中加入文字：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantiates Presentation
var pres = new aspose.slides.Presentation();
try {
    // 取得簡報中的第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增一個類型設定為 Rectangle 的 AutoShape
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // 在 Rectangle 中新增 TextFrame
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

## **檢查文字方塊形狀**

Aspose.Slides 從[AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)類別提供了[isTextBox](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/#isTextBox)方法，讓您可以檢查圖案並辨識文字方塊。

![文字方塊與形狀](istextbox.png)

以下 JavaScript 程式碼示範如何檢查圖案是否以文字方塊建立：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

請注意，如果僅使用[ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/)類別的 `addAutoShape` 方法新增自動圖案，該自動圖案的 `isTextBox` 方法會回傳 `false`。但在使用 `addTextFrame` 方法或 `setText` 方法為自動圖案加入文字後，`isTextBox` 屬性會回傳 `true`。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() 回傳 false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() 回傳 true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() 回傳 false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() 回傳 true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() 回傳 false
shape3.addTextFrame("");
// shape3.isTextBox() 回傳 false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() 回傳 false
shape4.getTextFrame().setText("");
// shape4.isTextBox() 回傳 false
```

## **尋找擁有文字框的形狀**

在一般文字處理程式碼中，您可能會取得一個[TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)，卻不知道它屬於哪個簡報物件。請使用[TextFrame.getParentShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getParentShape--)方法返回擁有它的[Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/)。

對於屬於[AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)或其他包含文字的圖案的文字框，`TextFrame.getParentShape` 會回傳擁有者，而 `TextFrame.getParentCell` 會回傳 `null`。兩個方法皆提供唯讀的導向，呼叫它們不會改變所有權。存取圖案前請先檢查返回值是否為 `null`。

欲取得同時辨識圖案與表格儲存格擁有者（包括與 SmartArt 節點關聯的圖案）的完整範例，請參閱[搜尋與取代文字](/slides/zh-hant/nodejs-java/search-and-replace-text/)。

## **在文字方塊中加入欄**

Aspose.Slides 提供了[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat)類別的[setColumnCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-)與[setColumnSpacing](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-)方法，允許您在文字方塊中加入欄位。您可以指定文字方塊的欄數，並設定欄與欄之間的點數間距。

以下 JavaScript 程式碼示範上述操作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // 取得簡報中的第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增一個類型設定為 Rectangle 的 AutoShape
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // 在 Rectangle 中新增 TextFrame
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!"));
    // 取得 TextFrame 的文字格式
    var format = aShape.getTextFrame().getTextFrameFormat();
    // 指定 TextFrame 中的欄數
    format.setColumnCount(3);
    // 指定欄之間的間距
    format.setColumnSpacing(10);
    // 儲存簡報
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在文字框中加入欄**

Aspose.Slides for Node.js via Java 提供了[TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat)類別的[setColumnCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-)方法，允許您在文字框中加入欄位。透過此屬性，您可以指定文字框中想要的欄數。

以下 JavaScript 程式碼示範如何在文字框內加入欄：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // 欄位間距從未設定，因此報告為 NaN。
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
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
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
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

Aspose.Slides 允許您變更或更新文字方塊中的文字，或整份簡報中所有的文字。

以下 JavaScript 程式碼示範一次更新簡報中所有文字的操作：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // 檢查形狀是否支援文字框 (IAutoShape)。
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // 逐一遍歷文字框中的段落
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // 逐一遍歷段落中的每個 Portion
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// 變更文字
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// 變更格式
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

## **加入帶超連結的文字方塊** 

您可以在文字方塊內插入超連結。當使用者點選該文字方塊時，會開啟對應的連結。

要新增包含連結的文字方塊，請依照以下步驟：

1. 建立一個 `Presentation` 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參考。  
3. 在投影片的指定位置加入 `ShapeType` 設為 `Rectangle` 的 `AutoShape` 物件，並取得新加入的 AutoShape 物件參考。  
4. 為 `AutoShape` 物件加入 `TextFrame`，並設定其第一個段落的文字。以下範例使用的文字為 *Aspose.Slides*。  
5. 透過該段落的 `PortionFormat` 取得 `HyperlinkManager`。  
6. 呼叫 `setExternalHyperlinkClick` 將連結附加到段落。  
7. 最後透過 `Presentation` 物件寫入 PPTX 檔案。  

以下 JavaScript 程式碼—上述步驟的實作範例—示範如何在投影片中加入帶超連結的文字方塊：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化表示 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得簡報中的第一張投影片
    var slide = pres.getSlides().get_Item(0);
    // 新增一個類型設定為 Rectangle 的 AutoShape 物件
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // 將形狀轉型為 AutoShape
    var pptxAutoShape = shape;
    // 存取與 AutoShape 相關聯的 ITextFrame 屬性
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // 在框架中加入一些文字
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // 設定該 Portion 文字的超連結
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

## **FAQ**

**在使用母片時，文字方塊與文字佔位符有何不同？**

[佔位符](/slides/zh-hant/nodejs-java/manage-placeholder/)會從[母片](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/masterslide/)繼承樣式/位置，且可以在[版面配置](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/)上覆寫；相對地，普通的文字方塊是特定投影片上的獨立物件，切換版面配置時不會改變。

**如何在不影響圖表、表格與 SmartArt 內文字的前提下，對整份簡報執行大量文字取代？**

將遍歷範圍限制在具有文字框的自動圖案，並排除嵌入式物件（如[圖表](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/)、[表格](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartart/)），可以分別遍歷它們的集合或跳過這些物件類型。