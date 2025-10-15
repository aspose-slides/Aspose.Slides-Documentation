---
title: Text Box
type: docs
weight: 40
url: /androidjava/examples/elements/textbox/
keywords:
- code example
- textbox
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Work with text boxes in Aspose.Slides for Android: add, format, align, wrap, autofit, and style text using Java for PPT, PPTX, and ODP presentations."
---

In Aspose.Slides, a **text box** is represented by an `AutoShape`. Nearly any shape can contain text, but a typical text box has no fill or border and displays only text.

This guide explains how to add, access, and remove text boxes programmatically.

## **Add a Text Box**

A text box is simply an `AutoShape` with no fill or border and some formatted text. Here's how to create one:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Create a rectangle shape (defaults to filled with border and no text).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Remove fill and border to make it look like a typical text box.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Set text formatting.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Assign the actual text content.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note:** Any `AutoShape` that contains a non-empty `TextFrame` can function as a text box.

## **Access Text Boxes by Content**

To find all text boxes containing a specific keyword (e.g. "Slide"), iterate through the shapes and check their text:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Only AutoShapes can contain editable text.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Do something with the matching text box.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove Text Boxes by Content**

This example finds and deletes all text boxes on the first slide that contain a specific keyword:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Tip:** Always create a copy of the shape collection before modifying it during iteration to avoid collection modification errors.
