---
title: Manage Fonts - PowerPoint Java API
linktitle: Manage Fonts
type: docs
weight: 10
url: /java/manage-fonts/
description: Presentations usually contain both text and images. This article shows how to use PowerPoint Java API to configure the font properties of paragraphs of text on slides.
---

## **Manage Font Related Properties**
{{% alert color="primary" %}} 

Presentations usually contain both text and images. The text can be formatted in a various way, either to highlight specific sections and words or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Java to configure the font properties of paragraphs of text on slides.

{{% /alert %}} 

To manage font properties of a paragraph using Aspose.Slides for Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the [Placeholder](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Placeholder) shapes in the slide and typecast them to [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Get the [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph) from the [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame) exposed by [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Justify the paragraph.
1. Access a [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Paragraph)'s text [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Define the font using [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FontData) and set the **Font** of the text [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/classes/FillFormat) exposed by the [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) object.
1. Save the modified presentation to a PPTX file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides. The screenshots that follow show the input file and how the code snippets change it. The code changes the font, the color, and the font style.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: The text in the input file**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: The same text with updated formatting**|

```javascript
    // Instantiate a Presentation object that represents a PPTX file
    var pres = new  com.aspose.slides.Presentation("FontProperties.pptx");
    try {
        // Accessing a slide using its slide position
        var slide = pres.getSlides().get_Item(0);
        // Accessing the first and second placeholder in the slide and typecasting it as AutoShape
        var tf1 = slide.getShapes().get_Item(0).getTextFrame();
        var tf2 = slide.getShapes().get_Item(1).getTextFrame();
        // Accessing the first Paragraph
        var para1 = tf1.getParagraphs().get_Item(0);
        var para2 = tf2.getParagraphs().get_Item(0);
        // Justify the paragraph
        para2.getParagraphFormat().setAlignment(com.aspose.slides.TextAlignment.JustifyLow);
        // Accessing the first portion
        var port1 = para1.getPortions().get_Item(0);
        var port2 = para2.getPortions().get_Item(0);
        // Define new fonts
        var fd1 = new  com.aspose.slides.FontData("Elephant");
        var fd2 = new  com.aspose.slides.FontData("Castellar");
        // Assign new fonts to portion
        port1.getPortionFormat().setLatinFont(fd1);
        port2.getPortionFormat().setLatinFont(fd2);
        // Set font to Bold
        port1.getPortionFormat().setFontBold(com.aspose.slides.NullableBool.True);
        port2.getPortionFormat().setFontBold(com.aspose.slides.NullableBool.True);
        // Set font to Italic
        port1.getPortionFormat().setFontItalic(com.aspose.slides.NullableBool.True);
        port2.getPortionFormat().setFontItalic(com.aspose.slides.NullableBool.True);
        // Set font color
        port1.getPortionFormat().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
        port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        port2.getPortionFormat().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
        port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
        // Save the PPTX to disk
        pres.save("WelcomeFont.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Set Text Font Properties**
{{% alert color="primary" %}} 

As mentioned in **Managing Font Related Properties**, a [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Java to create a textbox with some text and then define a particular font, and various other properties of the font family category.

{{% /alert %}} 

To create a textbox and set font properties of the text in it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape) of the type **Rectangle** to the slide.
1. Remove the fill style associated with the [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape).
1. Access the of the [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/classes/AutoShape)'s [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Add some text to the [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Access the [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) object associated with the [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/classes/TextFrame).
1. Define the font to be used for the [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion).
1. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the [Portion](https://reference.aspose.com/slides/java/com.aspose.slides/classes/Portion) object.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Text with some font properties set by Aspose.Slides for Java**|

```javascript
    // Instantiate a Presentation object that represents a PPTX file
    var pres = new  com.aspose.slides.Presentation();
    try {
        // Get first slide
        var sld = pres.getSlides().get_Item(0);
        // Add an AutoShape of Rectangle type
        var ashp = sld.getShapes().addAutoShape(com.aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
        // Remove any fill style associated with the AutoShape
        ashp.getFillFormat().setFillType(com.aspose.slides.FillType.NoFill);
        // Access the TextFrame associated with the AutoShape
        var tf = ashp.getTextFrame();
        tf.setText("Aspose TextBox");
        // Access the Portion associated with the TextFrame
        var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
        // Set the Font for the Portion
        port.getPortionFormat().setLatinFont(new  com.aspose.slides.FontData("Times New Roman"));
        // Set Bold property of the Font
        port.getPortionFormat().setFontBold(com.aspose.slides.NullableBool.True);
        // Set Italic property of the Font
        port.getPortionFormat().setFontItalic(com.aspose.slides.NullableBool.True);
        // Set Underline property of the Font
        port.getPortionFormat().setFontUnderline(com.aspose.slides.TextUnderlineType.Single);
        // Set the Height of the Font
        port.getPortionFormat().setFontHeight(25);
        // Set the color of the Font
        port.getPortionFormat().getFillFormat().setFillType(com.aspose.slides.FillType.Solid);
        port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        // Save the presentation to disk
        pres.save("pptxFont.pptx", com.aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```




