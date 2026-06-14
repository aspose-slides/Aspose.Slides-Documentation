---
title: 文字方塊
type: docs
weight: 40
url: /zh-hant/nodejs-java/examples/elements/text-box/
keywords:
- 程式碼範例
- 文字方塊
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中使用文字方塊：使用 JavaScript 為 PPT、PPTX 和 ODP 簡報新增、格式化、對齊、換行、自動調整大小並設定樣式。"
---
在 Aspose.Slides 中，**文字方塊** 由 `AutoShape` 代表。幾乎所有形狀皆可包含文字，但典型的文字方塊沒有填充或邊框，僅顯示文字。

本指南說明如何以程式方式新增、存取和移除文字方塊。

## **新增文字方塊**

文字方塊只是沒有填充或邊框且包含格式化文字的 `AutoShape`。以下說明如何建立它：

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 建立矩形形狀（預設為填充且帶邊框，且無文字）。
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // 移除填充和邊框，使其看起來像典型的文字方塊。
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // 設定文字格式。
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // 指定實際的文字內容。
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意:** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以作為文字方塊使用。

## **存取文字方塊**

從投影片中取得第一個文字方塊。

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // 只有 AutoShape 可以包含可編輯的文字。
        }
    } finally {
        presentation.dispose();
    }
}
```

## **依內容移除文字方塊**

此範例會尋找並刪除第一張投影片中包含特定關鍵字的所有文字方塊：

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **技巧:** 在迭代期間修改時，請務必先建立形狀集合的副本，以避免集合修改錯誤。