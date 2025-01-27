---
title: Manage Bullet
type: docs
weight: 60
url: /nodejs-java/manage-bullet/
keywords: "Bullets, Bullet lists, Numbers, Numbered lists, Picture bullets, multilevel bullets, PowerPoint Presentation, Java, Aspose.Slides for Node.js via Java"
description: "Create bullet and numbered lists in PowerPoint presentation in JavaScript"
---

In **Microsoft PowerPoint**, you can create bullet and numbered lists the same way you do in Word and other text editors. **Aspose.Slides for Node.js via Java** also allows you to use bullets and numbers in slides in your presentations.

## Why Use Bullet Lists?

Bullet lists help you to organize and present information quickly and efficiently. 

**Bullet List Example**

In most cases, a bullet list serves these three main functions:

- draws your readers or viewers attention to important information
- allows your readers or viewers to scan for key points easily
- communicates and delivers important details efficiently.

## Why Use Numbered Lists?

Numbered lists also help in organizing and presenting information. Ideally, you should use numbers (in place of bullets) when the order of the entries (for example, *step 1, step 2*, etc.) is important or when an entry has to be referenced (for example, *see step 3*).

**Numbered List Example**

This is a summary of the steps (step 1 to step 15) in the **Creating Bullets** procedure below:

1. Create an instance of the presentation class. 
2. Perform several tasks (step 3 to step 14).
3. Save the presentation. 

## Creating Bullets
This topic is also the part of the topic series of managing text paragraphs. This page will illustrate how we can manage paragraph bullets. Bullets are more useful where something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see how developers can use this small yet powerful feature of Aspose.Slides for Node.js via Java. Please follow the steps below to manage the paragraph bullets using Aspose.Slides for Node.js via Java:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Access the desired slide in slide collection using [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) object.
1. Add an [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) in selected slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) of the added shape.
1. Remove the default paragraph in the TextFrame.
1. Create the first paragraph instance using [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph) class.
1. Set the bullet type of the paragraph.
1. Set the bullet type to [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) and the set the bullet character.
1. Set the Paragraph Text.
1. Set the Paragraph Indent to set the bullet.
1. Set the Color of Bullet.
1. Set the Height of Bullets.
1. Add the created paragraph in TextFrame paragraph collection.
1. Add the second paragraph and repeat the process given in steps **7 to 13**.
1. Save the presentation.

This sample code in Java—an implementation of the steps above—shows you to create a bullet list in a slide:

```javascript
// Instantiate a Presentation class that represents a PPTX file
var pres = new aspose.slides.Presentation();
try {
    // Accessing first slide
    var slide = pres.getSlides().get_Item(0);
    // Adding and accessing Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accessing the text frame of created autoshape
    var txtFrm = aShp.getTextFrame();
    // Removing the default exisiting paragraph
    txtFrm.getParagraphs().removeAt(0);
    // Creating a paragraph
    var para = new aspose.slides.Paragraph();
    // Setting paragraph bullet style and symbol
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Setting paragraph text
    para.setText("Welcome to Aspose.Slides");
    // Setting bullet indent
    para.getParagraphFormat().setIndent(25);
    // Setting bullet color
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // set IsBulletHardColor to true to use own bullet color
    para.getParagraphFormat().getBullet().isBulletHardColor();
    // Setting Bullet Height
    para.getParagraphFormat().getBullet().setHeight(100);
    // Adding Paragraph to text frame
    txtFrm.getParagraphs().add(para);
    // saving the presentation as a PPTX file
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Creating Picture Bullets

Aspose.Slides for Node.js via Java allows you to change the bullets on bullet lists. You get to replace the bullets with custom symbols or images. If you want to add visual interest to a list or draw even more attention to entries on a list, you can use your own image as the bullet.

{{% alert color="primary" %}} 

Ideally, if you intend to replace the regular bullet symbol with a picture, you may want to select a simple graphics image with a transparent background. Such images work best as custom bullet symbols. 

In any case, the image you choose will be reduced to a very small size, so we strongly recommend you select an image that looks good (as a replacement for the bullet symbol) in a list. 

{{% /alert %}} 

To create a picture bullet, go through these steps:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class
1. Access the desired slide in slide collection using [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) object
1. Add an autoshape in selected slide
1. Access the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) of the added shape
1. Remove the default paragraph in the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe)
1. Create the first paragraph instance using Paragraph class
1. Load Image from disc in [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/PPImage)
1. Set the bullet type to Picture and the set the image
1. Set the Paragraph Text
1. Set the Paragraph Indent to set the bullet
1. Set the Color of Bullet
1. Set the Height of Bullets
1. Add the created paragraph in [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) paragraph collection
1. Add the second paragraph and repeat the process given in previous steps
1. Save the presentation

This JavaScript code shows you to create a picture bullet in a slide:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accessing the first slide
    var slide = pres.getSlides().get_Item(0);
    // Instantiate the image for bullets
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adding and accessing Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accessing the text frame of created autoshape
    var txtFrm = aShp.getTextFrame();
    // Removing the default exisiting paragraph
    txtFrm.getParagraphs().removeAt(0);
    // Creating new paragraph
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // Setting paragraph bullet style and image
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Setting Bullet Height
    para.getParagraphFormat().getBullet().setHeight(100);
    // Adding Paragraph to text frame
    txtFrm.getParagraphs().add(para);
    // Writing the presentation as a PPTX file
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## Creating Multilevel Bullets

To create a bullet list that contains items on different levels—additional lists under the main bullet list—go through these steps:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Access the desired slide in slide collection using [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) object.
1. Add an autoshape in selected slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) of the added shape.
1. Remove the default paragraph in the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Create the first paragraph instance using Paragraph class and with depth set to 0.
1. Create the second paragraph instance using Paragraph class and with depth set to 1.
1. Create the third paragraph instance using Paragraph class and with depth set to 2.
1. Create the fourth paragraph instance using Paragraph class and with depth set to 3.
1. Add the created paragraphs in [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) paragraph collection.
1. Save the presentation.

This code, which is an implementation of the steps above, shows you how to create a multilevel bullet list in JavaScript:

```javascript
// Instantiate a Presentation class that represents a PPTX file
var pres = new aspose.slides.Presentation();
try {
    // Accessing first slide
    var slide = pres.getSlides().get_Item(0);
    // Adding and accessing Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accessing the text frame of created autoshape
    var txtFrm = aShp.addTextFrame("");
    // Removing the default exisiting paragraph
    txtFrm.getParagraphs().clear();
    // Creating first paragraph
    var para1 = new aspose.slides.Paragraph();
    // Setting paragraph bullet style and symbol
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Setting bullet level
    para1.getParagraphFormat().setDepth(0);
    // Creating second paragraph
    var para2 = new aspose.slides.Paragraph();
    // Setting paragraph bullet style and symbol
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Setting bullet level
    para2.getParagraphFormat().setDepth(1);
    // Creating third paragraph
    var para3 = new aspose.slides.Paragraph();
    // Setting paragraph bullet style and symbol
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Setting bullet level
    para3.getParagraphFormat().setDepth(2);
    // Creating fourth paragraph
    var para4 = new aspose.slides.Paragraph();
    // Setting paragraph bullet style and symbol
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Setting bullet level
    para4.getParagraphFormat().setDepth(3);
    // Adding Paragraph to text frame
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    // saving the presentation as a PPTX file
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## Create Custom Numbered List
Aspose.Slides for Node.js via Java provides a simple API to manage paragraphs with custom numbers formatting. To add a custom number list in a paragraph, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Access the desired slide in slide collection using [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide) object.
1. Add an autoshape in selected slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) of the added shape.
1. Remove the default paragraph in the [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe).
1. Create the first paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 2
1. Create the second paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 3
1. Create the third paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 7
1. Add the created paragraphs in [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) paragraph collection.
1. Save the presentation.

This JavaScript code shows you how to create a numbered list in a slide:

```javascript
// Instantiate a Presentation class that represents a PPTX file
var pres = new aspose.slides.Presentation();
try {
    // Accessing first slide
    var slide = pres.getSlides().get_Item(0);
    // Adding and accessing Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accessing the text frame of created autoshape
    var txtFrm = aShp.addTextFrame("");
    // Removing the default exisiting paragraph
    txtFrm.getParagraphs().clear();
    // First list
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);
    // Second list
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(5);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);
    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
