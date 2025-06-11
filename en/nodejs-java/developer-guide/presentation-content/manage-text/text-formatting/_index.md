---
title: Format PowerPoint Text in JavaScript
linktitle: Text Formatting
type: docs
weight: 50
url: /nodejs-java/text-formatting/
keywords:
- highlight text
- regular expression
- align paragraph
- text style
- text background
- text transparency
- character spacing
- font properties
- font family
- text rotation
- rotation angle
- text frame
- line spacing
- autofit property
- text frame anchor
- text tabulation
- default language
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to format and style text in PowerPoint and OpenDocument presentations using Aspose.Slides for Node.js via Java. Customize fonts, colors, alignment, and more with powerful JavaScript code examples."
---

## **Highlight Text**
Method [highlightText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightText-java.lang.String-java.awt.Color-) has been added to [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class and [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class.

It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var textHighlightingOptions = new aspose.slides.TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("title", java.getStaticFieldValue("java.awt.Color", "BLUE"));// highlighting all words 'important'
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), textHighlightingOptions);// highlighting all separate 'the' occurrences
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

Aspose provides a simple, [free online PowerPoint editing service](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Highlight Text using Regular Expression**

Method [highlightRegex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#highlightRegex-java.lang.String-java.awt.Color-aspose.slides.ITextHighlightingOptions-) has been added to [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class and [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) class.

It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var options = new aspose.slides.TextHighlightingOptions();
    pres.getSlides().get_Item(0).getShapes().get_Item(0).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.getStaticFieldValue("java.awt.Color", "YELLOW"), options);// highlighting all words with 10 symbols or longer
    pres.save("OutputPresentation-highlight.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Text Background Color**

Aspose.Slides allows you to specify your preferred color for the background of a text.

This JavaScript code shows you how to set the background color for an entire text:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
const pres = new aspose.slides.Presentation("text.pptx");
try {
    const slide = pres.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    if (autoShape.getTextFrame() != null) {
        const paragraphs = autoShape.getTextFrame().getParagraphs();
        const paragraphCount = paragraphs.size();
        for (let i = 0; i < paragraphCount; i++) {
            const portions = paragraphs.get_Item(i).getPortions();
            const portionCount = portions.size();
            for (let j = 0; j < portionCount; j++) {
                const portion = portions.get_Item(j);
                portion.getPortionFormat().getHighlightColor().setColor(Color.BLUE);
            }
        }
    }
    pres.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

This JavaScript code shows you how to set the background color for only a portion of a text:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.getTextFrame().getParagraphs().clear();
    var para = new aspose.slides.Paragraph();
    var portion1 = new aspose.slides.Portion("Black");
    portion1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    var portion2 = new aspose.slides.Portion(" Red ");
    var portion3 = new aspose.slides.Portion("Black");
    portion3.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    para.getPortions().add(portion1);
    para.getPortions().add(portion2);
    para.getPortions().add(portion3);
    autoShape.getTextFrame().getParagraphs().add(para);
    pres.save("text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
var presentation = new aspose.slides.Presentation("text.pptx");
try {
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var redPortion = java.callStaticMethodSync("StreamSupport", "stream", autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().spliterator(), false).filter(p -> p.getText().contains("Red")).findFirst();
    if (redPortion.isPresent()) {
        redPortion.get().getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    presentation.save("text-red.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Align Text Paragraphs**

Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for Node.js via Java supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for Node.js via Java:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Obtain the reference of a slide by using its Index.
3. Access the Placeholder shapes present in the slide and typecast them as a [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
4. Get the Paragraph (that needs to be aligned) from the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#getTextFrame--) exposed by [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
6. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```javascript
// Instantiate a Presentation object that represents a PPTX file
var pres = new aspose.slides.Presentation("ParagraphsAlignment.pptx");
try {
    // Accessing first slide
    var slide = pres.getSlides().get_Item(0);
    // Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Change the text in both placeholders
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");
    // Getting the first paragraph of the placeholders
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Aligning the text paragraph to center
    para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);
    // Writing the presentation as a PPTX file
    pres.save("Centeralign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Transparency for Text**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides for Node.js via Java. In order to set the transparency to text. Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Get the reference of a slide.
3. Set shadow color
4. Write the presentation as a PPTX file.

The implementation of the above steps is given below.

```javascript
var pres = new aspose.slides.Presentation("transparency.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();
    var outerShadowEffect = effects.getOuterShadowEffect();
    var shadowColor = outerShadowEffect.getShadowColor().getColor();
    console.log((shadowColor.toString() + " - transparency is: ") + ((shadowColor.getAlpha() / 255.0) * 100));
    // set transparency to zero percent
    outerShadowEffect.getShadowColor().setColor(java.newInstanceSync("java.awt.Color", shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));
    pres.save("transparency-2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Character Spacing for Text**

Aspose.Slides allows you to set the space between letters in a textbox. This way, you get to adjust the visual density of a line or block of text by expanding or condensing the spacing between characters.

This JavaScript code shows you how to expand the spacing for one line of text and condense the spacing for another line:

```javascript
var presentation = new aspose.slides.Presentation("in.pptx");
var textBox1 = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var textBox2 = presentation.getSlides().get_Item(0).getShapes().get_Item(1);
textBox1.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(20);// expand
textBox2.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setSpacing(-2);// condense
presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Manage Paragraph's Font Properties**

Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Node.js via Java to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for Node.js via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the Placeholder shapes in the slide and typecast them to [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Get the [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) from the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) exposed by [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
1. Justify the paragraph.
1. Access a Paragraph's text Portion.
1. Define the font using FontData and set the Font of the text Portion accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BasePortionFormat#getFillFormat--) exposed by the [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion) object.
1. Write the modified presentation to a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.

```javascript
// Instantiate a Presentation object that represents a PPTX file
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Accessing a slide using its slide position
    var slide = pres.getSlides().get_Item(0);
    // Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Accessing the first Paragraph
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Accessing the first portion
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Define new fonts
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Assign new fonts to portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Set font to Bold
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Set font to Italic
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Set font color
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Write the PPTX to disk
    pres.save("WelcomeFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Manage Font Family of Text**
A portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Node.js via Java to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Obtain the reference of a slide by using its index.
3. Add an [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) of the type [Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType#Rectangle) to the slide.
4. Remove the fill style associated with the [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Access the AutoShape's TextFrame.
6. Add some text to the TextFrame.
7. Access the Portion object associated with the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
8. Define the font to be used for the [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion).
9. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the Portion object.
10. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```javascript
// Instantiate Presentation
var pres = new aspose.slides.Presentation();
try {
    // Get first slide
    var sld = pres.getSlides().get_Item(0);
    // Add an AutoShape of Rectangle type
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Remove any fill style associated with the AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Access the TextFrame associated with the AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Access the Portion associated with the TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Set the Font for the Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Set Bold property of the Font
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Set Italic property of the Font
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Set Underline property of the Font
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Set the Height of the Font
    port.getPortionFormat().setFontHeight(25);
    // Set the color of the Font
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Write the PPTX to disk
    pres.save("SetTextFontProperties_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Font Size for Text**

Aspose.Slides allows you to choose your preferred font size for existing text in a paragraph and other texts that may be added to the paragraph later.

This JavaScript code shows you how to set the font size for texts contained in a paragraph:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // Gets the first shape, for example.
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        var autoShape = shape;
        // Gets the first paragraph, for example.
        var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
        // Sets the default font size to 20 pt for all text portions in the paragraph.
        paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
        // Sets the font size to 20 pt for current text portions in the paragraph.
        for (let i = 0; i < paragraph.getPortions().getCount(); i++) {
            let portion = paragraph.getPortions().get_Item(i);
            portion.getPortionFormat().setFontHeight(20);
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Set Text Rotation**

Aspose.Slides for Node.js via Java allows developers to rotate the text. Text could be set to appear as [Horizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Horizontal), [Vertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical), [Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#MongolianVertical) or [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). To rotate the text of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Access the first slide.
3. Add any Shape to the slide.
4. Access the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setTextVerticalType-byte-).
6. Save file to disk.

```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var slide = pres.getSlides().get_Item(0);
    // Add an AutoShape of Rectangle type
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accessing the text frame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Create the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Create Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Save Presentation
    pres.save("RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Custom Rotation Angle for TextFrame**
Aspose.Slides for Node.js via Java now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new methods [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-) and [getRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#getRotationAngle--) have been added to [ChartTextBlockFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartTextBlockFormat) and [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) classs, allows to set the custom rotation angle for textframe. In order to set the RotationAngle, Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Add a chart on slide.
3. [Set RotationAngle property](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setRotationAngle-float-).
4. Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.

```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var slide = pres.getSlides().get_Item(0);
    // Add an AutoShape of Rectangle type
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accessing the text frame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);
    // Create the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Create Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Save Presentation
    pres.save(resourcesOutputPath + "RotateText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Line Spacing of Paragraph**
Aspose.Slides provides properties under [`ParagraphFormat`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ParagraphFormat)—`SpaceAfter`, `SpaceBefore` and `SpaceWithin`—that allow you to manage the line spacing for a paragraph. The three properties are used this way:

* To specify the line spacing for a paragraph in percentage, use a positive value. 
* To specify the line spacing for a paragraph in points, use a negative value.

For example, you can apply a 16pt line spacing for a paragraph by setting the `SpaceBefore` property to -16.

This is how you specify the line spacing for a specific paragraph:

1. Load a presentation containing an AutoShape with some text in it.
2. Get a slide's reference through its index.
3. Access the TextFrame.
4. Access the Paragraph.
5. Set the Paragraph properties.
6. Save the presentation.

This JavaScript code shows you how to specify the line spacing for a paragraph:

```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Obtain a slide's reference by its index
    var sld = pres.getSlides().get_Item(0);
    // Access the TextFrame
    var tf1 = sld.getShapes().get_Item(0).getTextFrame();
    // Access the Paragraph
    var para = tf1.getParagraphs().get_Item(0);
    // Set properties of Paragraph
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    // Save Presentation
    pres.save("LineSpacing_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set the AutofitType Property for TextFrame**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for Node.js via Java allows developers to set AutofitType property of any text frame. AutofitType could be set to [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) or [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape). If set to [Normal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Normal) then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAutofitType#Shape), then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType-byte-) of the TextFrame.
6. Save file to disk.

```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Access the first slide
    var slide = pres.getSlides().get_Item(0);
    // Add an AutoShape of Rectangle type
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 150);
    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accessing the text frame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
    // Create the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Create Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Save Presentation
    pres.save(resourcesOutputPath + "formatText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Anchor of TextFrame**
Aspose.Slides for Node.js via Java allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. AnchorType could be set to [Top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Top), [Center](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Center), [Bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Bottom), [Justified](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Justified) or [Distributed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextAnchorType#Distributed). To set Anchor of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAnchoringType-byte-) of the TextFrame.
6. Save file to disk.

```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Get the first slide
    var slide = pres.getSlides().get_Item(0);
    // Add an AutoShape of Rectangle type
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 350, 350);
    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accessing the text frame
    var txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(aspose.slides.TextAnchorType.Bottom);
    // Create the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Create Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Save Presentation
    pres.save("AnchorText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tabs and EffectiveTabs in Presentation**
All text tabulations are given in pixels.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**Figure: 2 Explicit Tabs and 2 Default Tabs**|
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs).
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Hello World!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".

## **Set Default Text Style**

If you need to apply the same default text formatting to all text elements of a presentation at once, then you can use the `getDefaultTextStyle` method from the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class and set the preferred formatting. The code example below shows how to set the default bold font (14 pt) for the text on all slides in a new presentation.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Get the top level paragraph format.
    var paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);
    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    }
    presentation.save("DefaultTextStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extract Text with the All-Caps Effect**

In PowerPoint, applying the **All Caps** font effect makes text appear in uppercase on the slide even when it was originally typed in lowercase. When you retrieve such a text portion with Aspose.Slides, the library returns the text exactly as it was entered. To handle this, check [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/)—if it indicates `All`, simply convert the returned string to uppercase so that your output matches what users see on the slide.

Let’s say we have the following text box on the first slide of the sample2.pptx file.

![The All Caps effect](all_caps_effect.png)

 The code example below shows how to extract the text with the **All Caps** effect aplyied:

```js
var presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var autoShape = slide.getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    var textPortion = paragraph.getPortions().get_Item(0);

    console.log("Original text:", textPortion.getText());

    var textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == aspose.slides.TextCapType.All) {
        var text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect:", text);
    }
} finally {
    presentation.dispose();
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```
