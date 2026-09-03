---
title: Manage Text Boxes in Presentations on Android
linktitle: Manage Text Box
type: docs
weight: 20
url: /androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Create, identify, format, and update text boxes in PowerPoint and OpenDocument presentations using Aspose.Slides for Android via Java."
---

## **Introduction**

In Aspose.Slides for Android via Java, slide text is stored in text frames that belong to shapes. The [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) interface represents the most common text-bearing shape and exposes its text through the [IAutoShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) method.

{{% alert color="info" title="Note" %}}

Every auto shape implements [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), but not every shape is an auto shape or supports a text frame. When processing an existing presentation, check that a shape implements [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) before accessing its text.

{{% /alert %}}

## **Create a Text Box on a Slide**

To create a text box, add an auto shape to a slide, add text to its text frame, and save the presentation. The following example creates a rectangular text box:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The coordinates and dimensions passed to [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) are measured in points. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) initializes the text frame with the supplied text.

## **Check for a Text Box Shape**

Use the [IAutoShape.isTextBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#isTextBox--) method to determine whether an auto shape is treated as a text box. This is useful when a presentation contains both text-bearing and purely graphical auto shapes.

![A text box and a shape](istextbox.png)

The following example inspects every auto shape in a presentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A newly added auto shape is not considered a text box until it contains non-empty text. You can supply that text through [IAutoShape.addTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) or [ITextFrame.setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-). Adding or assigning an empty string leaves [IAutoShape.isTextBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#isTextBox--) returning `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

The first two calls print `true`; the last two print `false`.

## **Find the Shape That Owns a Text Frame**

Generic text-processing code may receive an [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) without knowing which presentation object contains it. Use the read-only [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) method to navigate back to its owning [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/).

For a text frame owned by an auto shape or another text-bearing shape, [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) returns the owner and [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) returns `null`. Check the returned value before accessing it. To identify both shape and table-cell owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/androidjava/search-and-replace-text/).

## **Add Columns to a Text Box**

The [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-) method divides the text frame into columns, while [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) sets the gap between columns in points. Both settings belong to [ITextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/) and can be changed through the text frame of an existing text box. Text reflows between columns inside the same shape; it does not continue into another shape.

The following example creates a three-column text box with 10 points between columns, saves the presentation, and reads the stored settings back from the output file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extract Text from Individual Columns**

Use [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#splitTextByColumns--) to retrieve the text assigned to each visual column in an existing text frame. The method returns one string for each column, in column-based reading order. A single-column text frame produces an array with one element, and an empty column is represented by an empty string. The strings contain plain text only; portion-level formatting is not preserved.

This is useful when you need to:

- Extract text while preserving its column-based reading order.
- Index or compare the content of multi-column slides.
- Export each column to a separate file, database field, or other destination.
- Inspect how text is redistributed after changing the column count with [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setColumnCount-int-), the spacing with [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), the font, or the text-frame size.

The method reports the text distributed within the current [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/); it does not automatically flow text between separate shapes or text boxes. Column distribution can depend on available fonts and other text-layout settings, so make sure that the required fonts are available when consistent results are important.

The following example loads a presentation, finds the first multi-column auto shape with a text frame, reads its configured column count, and writes the text from every column to a separate file. Shapes that do not provide a text frame are skipped.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            String outputPath = "Column-" + columnNumber + ".txt";
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try (FileOutputStream outputStream = new FileOutputStream(outputPath)) {
                outputStream.write(textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
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

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

This traversal updates text only in auto shapes. Text stored in tables, charts, SmartArt, or grouped shapes requires traversal of those objects' own collections.

## **Add a Text Box with a Hyperlink**

A hyperlink can be assigned to a specific text portion, so only that text acts as the clickable link. Use [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) to associate the portion with an external URL.

The following example creates linked text and saves it to a presentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

A [placeholder](/slides/androidjava/manage-placeholder/) can inherit its position and formatting from a [master slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) or [layout slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/). A regular text box is an independent shape on the slide where it was created and does not acquire placeholder behavior when the layout changes.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Limit the traversal to shapes that implement [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), as shown in the Update Text example. Charts, tables, and SmartArt store text in their own object models, so they are not modified by that loop.
