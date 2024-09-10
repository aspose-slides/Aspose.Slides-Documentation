---
title: Manage PowerPoint Paragraph in Java
type: docs
weight: 40
url: /nodejs-java/manage-paragraph/
keywords: "Add PowerPoint paragraph, Manage paragraphs, Paragraph indent, Paragraph properties, HTML text, Export paragraph text, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Create and manage Paragraph, text, indent, and properties in PowerPoint presentations in Javascript"
---

Aspose.Slides provides all the interfaces and classes you need to work with PowerPoint texts, paragraphs, and portions in Java.

* Aspose.Slides provides the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) interface to allow you to add objects that represent a paragraph. An `ITextFame` object can have one or multiple paragraphs (each paragraph is created through a carriage return).
* Aspose.Slides provides the [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) interface to allow you to add objects that represent portions. An `IParagraph` object can have one or multiple portions (collection of iPortions objects).
* Aspose.Slides provides [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) interface to allow you to add objects that represent texts and their formatting properties.

An `IParagraph` object is capable of handling texts with different formatting properties through its underlying `IPortion` objects.

## **Add Multiple Paragraph Containing Multiple Portions**

These steps show you how to add a text frame containing 3 paragraphs and each paragraph containing 3 portions:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add a Rectangle [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Get the ITextFrame associated with the [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
5. Create two [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) objects and add them to the `IParagraphs` collection of the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
6. Create three [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) objects for each new `IParagraph` (two Portion objects for default Paragraph) and add each `IPortion` object to the IPortion collection of each `IParagraph`.
7. Set some text for each portion.
8. Apply your preferred formatting features to each portion using the formatting properties exposed by the `IPortion` object.
9. Save the modified presentation.

This Javascript code is an implementation of the steps for adding paragraphs containing portions:

```javascript
    // Instantiate a Presentation class that represents a PPTX file
    var pres = new  aspose.slides.Presentation();
    try {
        // Accessing first slide
        var slide = pres.getSlides().get_Item(0);
        // Add an AutoShape of Rectangle type
        var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
        // Access TextFrame of the AutoShape
        var tf = ashp.getTextFrame();
        // Create Paragraphs and Portions with different text formats
        var para0 = tf.getParagraphs().get_Item(0);
        var port01 = new  aspose.slides.Portion();
        var port02 = new  aspose.slides.Portion();
        para0.getPortions().add(port01);
        para0.getPortions().add(port02);
        var para1 = new  aspose.slides.Paragraph();
        tf.getParagraphs().add(para1);
        var port10 = new  aspose.slides.Portion();
        var port11 = new  aspose.slides.Portion();
        var port12 = new  aspose.slides.Portion();
        para1.getPortions().add(port10);
        para1.getPortions().add(port11);
        para1.getPortions().add(port12);
        var para2 = new  aspose.slides.Paragraph();
        tf.getParagraphs().add(para2);
        var port20 = new  aspose.slides.Portion();
        var port21 = new  aspose.slides.Portion();
        var port22 = new  aspose.slides.Portion();
        para2.getPortions().add(port20);
        para2.getPortions().add(port21);
        para2.getPortions().add(port22);
        for (var i = 0; i < 3; i++) {
            for (var j = 0; j < 3; j++) {
                var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
                portion.setText("Portion0" + j);
                if (j == 0) {
                    portion.getPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                    portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                    portion.getPortionFormat().setFontHeight(15);
                } else if (j == 1) {
                    portion.getPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
                    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                    portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                    portion.getPortionFormat().setFontHeight(18);
                }
            }
        }
        // Write PPTX to Disk
        pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Manage Paragraph Bullets**

Bullet lists help you to organize and present information quickly and efficiently. Bulleted paragraphs are always easier to read and understand.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add an [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) to the selected slide.
4. Access the autoshape's [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Create the first paragraph instance using the [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) class.
7. Set the bullet `Type` for the paragraph to `Symbol` and set the bullet character.
8. Set the paragraph `Text`.
9. Set the paragraph `Indent` for the bullet.
10. Set a color for the bullet.
11. Set a height of the bullet.
12. Add the new paragraph to the `TextFrame` paragraph collection.
13. Add the second paragraph and repeat the process given in steps 7 to 13.
14. Save the presentation.

This Javascript code shows you how to add a paragraph bullet:

```javascript
    // Instantiates a Presentation class that represents a PPTX file
    var pres = new  aspose.slides.Presentation();
    try {
        // Accesses the first slide
        var slide = pres.getSlides().get_Item(0);
        // Adds and accesses Autoshape
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // Accesses the autoshape text frame
        var txtFrm = aShp.getTextFrame();
        // Removes the default paragraph
        txtFrm.getParagraphs().removeAt(0);
        // Creates a paragraph
        var para = new  aspose.slides.Paragraph();
        // Sets a paragraph bullet style and symbol
        para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para.getParagraphFormat().getBullet().setChar(8226);
        // Sets a paragraph text
        para.setText("Welcome to Aspose.Slides");
        // Sets bullet indent
        para.getParagraphFormat().setIndent(25);
        // Sets bullet color
        para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// set IsBulletHardColor to true to use own bullet color
        // Sets Bullet Height
        para.getParagraphFormat().getBullet().setHeight(100);
        // Adds Paragraph to text frame
        txtFrm.getParagraphs().add(para);
        // Creates second paragraph
        var para2 = new  aspose.slides.Paragraph();
        // Sets paragraph bullet type and style
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
        para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
        // Adds paragraph text
        para2.setText("This is numbered bullet");
        // Sets bullet indent
        para2.getParagraphFormat().setIndent(25);
        para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
        para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// set IsBulletHardColor to true to use own bullet color
        // Sets Bullet Height
        para2.getParagraphFormat().getBullet().setHeight(100);
        // Adds Paragraph to text frame
        txtFrm.getParagraphs().add(para2);
        // Saves the modified presentation
        pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Manage Picture Bullets**

Bullet lists help you to organize and present information quickly and efficiently. Picture paragraphs are easy to read and understand.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add an [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Access the autoshape's [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Create the first paragraph instance using the [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) class.
7. Load the image in [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
8. Set the bullet type to [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) and set the image.
9. Set the Paragraph `Text`.
10. Set the Paragraph `Indent` for the bullet.
11. Set a color for the bullet.
12. Set a height for the bullet.
13. Add the new paragraph to the `TextFrame` paragraph collection.
14. Add the second paragraph and repeat the process based on the previous steps.
15. Save the modified presentation.

This Javascript code shows you how to add and manage picture bullets:

```javascript
    // Instantiates a Presentation class that represents a PPTX file
    var presentation = new  aspose.slides.Presentation();
    try {
        // Accesses the first slide
        var slide = presentation.getSlides().get_Item(0);
        // Instantiates the image for bullets
        var picture;
        var image = aspose.slides.Images.fromFile("bullets.png");
        try {
            picture = presentation.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        // Adds and accesses Autoshape
        var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // Accesses the autoshape textframe
        var textFrame = autoShape.getTextFrame();
        // Removes the default paragraph
        textFrame.getParagraphs().removeAt(0);
        // Creates a new paragraph
        var paragraph = new  aspose.slides.Paragraph();
        paragraph.setText("Welcome to Aspose.Slides");
        // Sets paragraph bullet style and image
        paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
        paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
        // Sets bullet Height
        paragraph.getParagraphFormat().getBullet().setHeight(100);
        // Adds paragraph to text frame
        textFrame.getParagraphs().add(paragraph);
        // Writes the presentation as a PPTX file
        presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
        // Writes the presentation as a PPT file
        presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
    } catch (e) {console.log(e);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```


## **Manage Multilevel Bullets**

Bullet lists help you to organize and present information quickly and efficiently. Multilevel bullets are easy to read and understand.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add an [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) in the new slide.
4. Access the autoshape's [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Create the first paragraph instance through the [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) class and set the depth to 0.
7. Create the second paragraph instance through the `Paragraph` class and set the depth set to 1.
8. Create the third paragraph instance through the `Paragraph` class and set the depth set to 2.
9. Create the fourth paragraph instance through the `Paragraph` class and set the depth set to 3.
10. Add the new paragraphs to the `TextFrame` paragraph collection.
11. Save the modified presentation.

This Javascript code shows you how to add and manage multilevel bullets:

```javascript
    // Instantiates a Presentation class that represents a PPTX file
    var pres = new  aspose.slides.Presentation();
    try {
        // Accesses the first slide
        var slide = pres.getSlides().get_Item(0);
        // Adds and accesses Autoshape
        var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // Accesses the text frame of created autoshape
        var text = aShp.addTextFrame("");
        // Clears the default paragraph
        text.getParagraphs().clear();
        // Adds the first paragraph
        var para1 = new  aspose.slides.Paragraph();
        para1.setText("Content");
        para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para1.getParagraphFormat().getBullet().setChar(8226);
        para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Sets the bullet level
        para1.getParagraphFormat().setDepth(0);
        // Adds the second paragraph
        var para2 = new  aspose.slides.Paragraph();
        para2.setText("Second Level");
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para2.getParagraphFormat().getBullet().setChar('-');
        para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Sets the bullet level
        para2.getParagraphFormat().setDepth(1);
        // Adds the third paragraph
        var para3 = new  aspose.slides.Paragraph();
        para3.setText("Third Level");
        para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para3.getParagraphFormat().getBullet().setChar(8226);
        para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Sets the bullet level
        para3.getParagraphFormat().setDepth(2);
        // Adds the fourth paragraph
        var para4 = new  aspose.slides.Paragraph();
        para4.setText("Fourth Level");
        para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para4.getParagraphFormat().getBullet().setChar('-');
        para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
        // Sets the bullet level
        para4.getParagraphFormat().setDepth(3);
        // Adds paragraphs to collection
        text.getParagraphs().add(para1);
        text.getParagraphs().add(para2);
        text.getParagraphs().add(para3);
        text.getParagraphs().add(para4);
        // Writes the presentation as a PPTX file
        pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Manage Paragraph with Custom Numbered List**

The [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) interface provides the [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) property and others that allow you to manage paragraphs with custom numbering or formatting.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Access the slide containing the paragraph.
3. Add an [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Access the autoshape [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `TextFrame`.
6. Create the first paragraph instance through the [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) class and set [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) to 2.
7. Create the second paragraph instance through the `Paragraph` class and set `NumberedBulletStartWith` to 3.
8. Create the third paragraph instance through the `Paragraph` class and set `NumberedBulletStartWith` to 7.
9. Add the new paragraphs to the `TextFrame` paragraph collection.
10. Save the modified presentation.

This Javascript code shows you how to add and manage paragraphs with custom numbering or formatting:

```javascript
    var presentation = new  aspose.slides.Presentation();
    try {
        var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
        // Accesses the text frame of created autoshape
        var textFrame = shape.getTextFrame();
        // Removes the default exisiting paragraph
        textFrame.getParagraphs().removeAt(0);
        // First list
        var paragraph1 = new  aspose.slides.Paragraph();
        paragraph1.setText("bullet 2");
        paragraph1.getParagraphFormat().setDepth(4);
        paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
        paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
        textFrame.getParagraphs().add(paragraph1);
        var paragraph2 = new  aspose.slides.Paragraph();
        paragraph2.setText("bullet 3");
        paragraph2.getParagraphFormat().setDepth(4);
        paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
        paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
        textFrame.getParagraphs().add(paragraph2);
        var paragraph5 = new  aspose.slides.Paragraph();
        paragraph5.setText("bullet 7");
        paragraph5.getParagraphFormat().setDepth(4);
        paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
        paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
        textFrame.getParagraphs().add(paragraph5);
        presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
```


## **Set Paragraph Indent**

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Access the relevant slide's reference through its index.
1. Add a rectangle [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) to the slide.
1. Add a [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) with three paragraphs to the rectangle autoshape.
1. Hide the rectangle lines.
1. Set the indent for each [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) through their BulletOffset property.
1. Write the modified presentation as a PPT file.

This Javascript code shows you how to set a paragraph indent:

```javascript
    // Instantiate Presentation Class
    var pres = new  aspose.slides.Presentation();
    try {
        // Get first slide
        var sld = pres.getSlides().get_Item(0);
        // Add a Rectangle Shape
        var rect = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 150);
        // Add TextFrame to the Rectangle
        var tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
        // Set the text to fit the shape
        tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
        // Hide the lines of the Rectangle
        rect.getLineFormat().getFillFormat().setFillType(aspose.slides.FillType.Solid);
        // Get first Paragraph in the TextFrame and set its Indent
        var para1 = tf.getParagraphs().get_Item(0);
        // Setting paragraph bullet style and symbol
        para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para1.getParagraphFormat().getBullet().setChar(8226);
        para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        para1.getParagraphFormat().setDepth(2);
        para1.getParagraphFormat().setIndent(30);
        // Get second Paragraph in the TextFrame and set its Indent
        var para2 = tf.getParagraphs().get_Item(1);
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para2.getParagraphFormat().getBullet().setChar(8226);
        para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        para2.getParagraphFormat().setDepth(2);
        para2.getParagraphFormat().setIndent(40);
        // Get third Paragraph in the TextFrame and set its Indent
        var para3 = tf.getParagraphs().get_Item(2);
        para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para3.getParagraphFormat().getBullet().setChar(8226);
        para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        para3.getParagraphFormat().setDepth(2);
        para3.getParagraphFormat().setIndent(50);
        // Write the Presentation to disk
        pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Set Hanging Indent for Paragraph**

This Javascript code shows you how to set the hanging indent for a paragraph:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 550, 150);
        var para1 = new  aspose.slides.Paragraph();
        para1.setText("Example");
        var para2 = new  aspose.slides.Paragraph();
        para2.setText("Set Hanging Indent for Paragraph");
        var para3 = new  aspose.slides.Paragraph();
        para3.setText("This C# code shows you how to set the hanging indent for a paragraph: ");
        para2.getParagraphFormat().setMarginLeft(10.0);
        para3.getParagraphFormat().setMarginLeft(20.0);
        autoShape.getTextFrame().getParagraphs().add(para1);
        autoShape.getTextFrame().getParagraphs().add(para2);
        autoShape.getTextFrame().getParagraphs().add(para3);
        pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Manage End Paragraph Run Properties for Paragraph**

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
1. Get the reference for the slide containing the paragraph through its position.
1. Add a rectangle [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) to the slide.
1. Add a [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) with two paragraphs to the Rectangle.
1. Set the `FontHeight` and Font type for the paragraphs.
1. Set the End properties for the paragraphs.
1. Write the modified presentation as a PPTX file.

This Javascript code shows you how to set the End properties for paragraphs in PowerPoint:

```javascript
    var pres = new  aspose.slides.Presentation();
    try {
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
        var para1 = new  aspose.slides.Paragraph();
        para1.getPortions().add(new  aspose.slides.Portion("Sample text"));
        var para2 = new  aspose.slides.Paragraph();
        para2.getPortions().add(new  aspose.slides.Portion("Sample text 2"));
        var portionFormat = new  aspose.slides.PortionFormat();
        portionFormat.setFontHeight(48);
        portionFormat.setLatinFont(new  aspose.slides.FontData("Times New Roman"));
        para2.setEndParagraphPortionFormat(portionFormat);
        shape.getTextFrame().getParagraphs().add(para1);
        shape.getTextFrame().getParagraphs().add(para2);
        pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Import HTML Text into Paragraphs**

Aspose.Slides provides enhanced support for importing HTML text into paragraphs.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class.
2. Access the relevant slide's reference through its index.
3. Add an [autoshape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) to the slide.
4. Add and access `autoshape` [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
5. Remove the default paragraph in the `ITextFrame`.
6. Read the source HTML file in a TextReader.
7. Create the first paragraph instance through the [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) class.
8. Add the HTML file content in the read TextReader to the TextFrame's [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/).
9. Save the modified presentation.

This Javascript code is an implementation of the steps for importing HTML texts in paragraphs:

```javascript
    // Create Empty presentation instance
    var pres = new  aspose.slides.Presentation();
    try {
        // Acesss the default first slide of presentation
        var slide = pres.getSlides().get_Item(0);
        // Adding the AutoShape to accomodate the HTML content
        var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
        ashape.getFillFormat().setFillType(aspose.slides.FillType.NoFill);
        // Adding text frame to the shape
        ashape.addTextFrame("");
        // Clearing all paragraphs in added text frame
        ashape.getTextFrame().getParagraphs().clear();
        // Loading the HTML file using stream reader
        var tr = java.newInstanceSync("StreamReader", "file.html");
        // Adding text from HTML stream reader in text frame
        ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
        // Saving Presentation
        pres.save("output_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Export Paragraphs Text to HTML**

Aspose.Slides provides enhanced support for exporting texts (contained in paragraphs) to HTML.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class and load the desired presentation.
2. Access the relevant slide's reference through its index.
3. Access the shape containing the text that will be exported to HTML.
4. Access the shape [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
5. Create an instance of `StreamWriter` and add the new HTML file.
6. Provide a starting index to StreamWriter and export your preferred paragraphs.

This Javascript code shows you how to export PowerPoint paragraph texts to HTML:

```javascript
    // Load the presentation file
    var pres = new  aspose.slides.Presentation("ExportingHTMLText.pptx");
    try {
        // Acesss the default first slide of presentation
        var slide = pres.getSlides().get_Item(0);
        // Desired index
        var index = 0;
        // Accessing the added shape
        var ashape = slide.getShapes().get_Item(index);
        // Creating output HTML file
        var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
        var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
        // Extracting first paragraph as HTML
        // Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
        writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
        writer.close();
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

 
