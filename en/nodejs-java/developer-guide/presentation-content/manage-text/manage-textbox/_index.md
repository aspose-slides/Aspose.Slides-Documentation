---
title: Manage Text Boxes in Presentations Using JavaScript
linktitle: Manage Text Box
type: docs
weight: 20
url: /nodejs-java/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Create, identify, format, and update text boxes in PowerPoint and OpenDocument presentations using Aspose.Slides for Node.js via Java."
---

## **Introduction**

In Aspose.Slides for Node.js via Java, slide text is stored in text frames that belong to shapes. The [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) class represents the most common text-bearing shape and exposes its text through the [AutoShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) method.

{{% alert color="info" title="Note" %}}

Every auto shape derives from [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), but not every shape is an auto shape or supports a text frame. When processing an existing presentation, check that a shape is an instance of [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) before accessing its text.

{{% /alert %}}

## **Create a Text Box on a Slide**

To create a text box, add an auto shape to a slide, add text to its text frame, and save the presentation. The following example creates a rectangular text box:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The coordinates and dimensions passed to [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) are measured in points. [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#addTextFrame) initializes the text frame with the supplied text.

## **Check for a Text Box Shape**

Use the [AutoShape.isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox) method to determine whether an auto shape is treated as a text box. This is useful when a presentation contains both text-bearing and purely graphical auto shapes.

![A text box and a shape](istextbox.png)

The following example inspects every auto shape in a presentation:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A newly added auto shape is not considered a text box until it contains non-empty text. You can supply that text through [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#addTextFrame) or [TextFrame.setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#setText). Adding or assigning an empty string leaves [AutoShape.isTextBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#isTextBox) returning `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

The first two calls print `true`; the last two print `false`.

## **Find the Shape That Owns a Text Frame**

Generic text-processing code may receive a [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) without knowing which presentation object contains it. Use the read-only [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape) method to navigate back to its owning [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/).

For a text frame owned by an auto shape or another text-bearing shape, [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape) returns the owner and [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell) returns `null`. Check the returned value before accessing it. To identify both shape and table-cell owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/nodejs-java/search-and-replace-text/).

## **Add Columns to a Text Box**

The [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setColumnCount) method divides the text frame into columns, while [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) sets the gap between columns in points. Both settings belong to [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/) and can be changed through the text frame of an existing text box. Text reflows between columns inside the same shape; it does not continue into another shape.

The following example creates a three-column text box with 10 points between columns, saves the presentation, and reads the stored settings back from the output file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extract Text from Individual Columns**

Use [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#splitTextByColumns) to retrieve the text assigned to each visual column in an existing text frame. The method returns one string for each column, in column-based reading order. A single-column text frame produces an array with one element, and an empty column is represented by an empty string. The strings contain plain text only; portion-level formatting is not preserved.

This is useful when you need to:

- Extract text while preserving its column-based reading order.
- Index or compare the content of multi-column slides.
- Export each column to a separate file, database field, or other destination.
- Inspect how text is redistributed after changing the column count with [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setColumnCount), the spacing with [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), the font, or the text-frame size.

The method reports the text distributed within the current [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/); it does not automatically flow text between separate shapes or text boxes. Column distribution can depend on available fonts and other text-layout settings, so make sure that the required fonts are available when consistent results are important.

The following example loads a presentation, finds the first multi-column auto shape with a text frame, reads its configured column count, and writes the text from every column to a separate file. Shapes that do not provide a text frame are skipped.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Update Text**

To update text throughout a presentation, iterate through the slides and shapes, select auto shapes, and then edit their text portions. Working at the portion level lets you change both text and character formatting.

The following example replaces every occurrence of `years` with `months` in auto-shape text and makes each affected portion bold:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

This traversal updates text only in auto shapes. Text stored in tables, charts, SmartArt, or grouped shapes requires traversal of those objects' own collections.

## **Add a Text Box with a Hyperlink**

A hyperlink can be assigned to a specific text portion, so only that text acts as the clickable link. Use [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) to associate the portion with an external URL.

The following example creates linked text and saves it to a presentation:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

A [placeholder](/slides/nodejs-java/manage-placeholder/) can inherit its position and formatting from a [master slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) or [layout slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/). A regular text box is an independent shape on the slide where it was created and does not acquire placeholder behavior when the layout changes.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Limit the traversal to shapes that are instances of [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), as shown in the Update Text example. Charts, tables, and SmartArt store text in their own object models, so they are not modified by that loop.
