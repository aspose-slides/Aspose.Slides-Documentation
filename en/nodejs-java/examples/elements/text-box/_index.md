---
title: Text Box
type: docs
weight: 40
url: /nodejs-java/examples/elements/text-box/
keywords:
- code example
- textbox
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Work with text boxes in Aspose.Slides for Node.js: add, format, align, wrap, autofit, and style text using JavaScript for PPT, PPTX, and ODP presentations."
---

In Aspose.Slides, a **text box** is represented by an `AutoShape`. Nearly any shape can contain text, but a typical text box has no fill or border and displays only text.

This guide explains how to add, access, and remove text boxes programmatically.

## **Add a Text Box**

A text box is simply an `AutoShape` with no fill or border and some formatted text. Here's how to create one:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Create a rectangle shape (defaults to filled with border and no text).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Remove fill and border to make it look like a typical text box.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Set text formatting.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Assign the actual text content.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note:** Any `AutoShape` that contains a non-empty `TextFrame` can function as a text box.

## **Access a Text Box**

Retrieve the first text box from the slide.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Only AutoShapes can contain editable text.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Text Boxes by Content**

This example finds and deletes all text boxes on the first slide that contain a specific keyword:

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

> 💡 **Tip:** Always create a copy of the shape collection before modifying it during iteration to avoid collection modification errors.
