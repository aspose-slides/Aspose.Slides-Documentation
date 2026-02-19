---
title: 文本框
type: docs
weight: 40
url: /zh/nodejs-java/examples/elements/text-box/
keywords:
- 代码示例
- 文本框
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中使用文本框：使用 JavaScript 为 PPT、PPTX 和 ODP 演示文稿添加、格式化、对齐、换行、自动适应和样式化文本。"
---
在 Aspose.Slides 中，**文本框** 由 `AutoShape` 表示。几乎任何形状都可以包含文本，但典型的文本框没有填充或边框，仅显示文本。

本指南说明如何以编程方式添加、访问和删除文本框。

## **添加文本框**

文本框仅是一个没有填充或边框且包含某些格式化文本的 `AutoShape`。以下演示如何创建一个：

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 创建一个矩形形状（默认填充且有边框且没有文本）。
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // 移除填充和边框，使其看起来像典型的文本框。
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // 设置文本格式。
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // 设置实际的文本内容。
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注意：** 任何包含非空 `TextFrame` 的 `AutoShape` 都可以作为文本框使用。

## **访问文本框**

检索幻灯片中的第一个文本框。

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // 只有 AutoShape 可以包含可编辑的文本。
        }
    } finally {
        presentation.dispose();
    }
}
```

## **按内容删除文本框**

此示例查找并删除首张幻灯片中包含特定关键字的所有文本框：

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

> 💡 **提示：** 在迭代期间修改形状集合之前，请始终先创建该集合的副本，以避免集合修改错误。