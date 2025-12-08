---
title: Manage Bulleted and Numbered Lists in Presentations on Android
linktitle: Manage Lists
type: docs
weight: 60
url: /androidjava/manage-bullet/
keywords:
- bullet
- bulleted list
- numbered list
- symbol bullet
- picture bullet
- custom bullet
- multilevel list
- create bullet
- add bullet
- add list
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn how to manage bulleted and numbered lists in PowerPoint and OpenDocument presentations using Aspose.Slides for Android via Java. Step-by-step guide."
---

In **Microsoft PowerPoint**, you can create bullet and numbered lists the same way you do in Word and other text editors. **Aspose.Slides for Android via Java** also allows you to use bullets and numbers in slides in your presentations.

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
This topic is also the part of the topic series of managing text paragraphs. This page will illustrate how we can manage paragraph bullets. Bullets are more useful where something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see how developers can use this small yet powerful feature of Aspose.Slides for Android via Java. Please follow the steps below to manage the paragraph bullets using Aspose.Slides for Android via Java:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Access the desired slide in slide collection using [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object.
1. Add an [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) in selected slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) of the added shape.
1. Remove the default paragraph in the TextFrame.
1. Create the first paragraph instance using [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) class.
1. Set the bullet type of the paragraph.
1. Set the bullet type to [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) and the set the bullet character.
1. Set the Paragraph Text.
1. Set the Paragraph Indent to set the bullet.
1. Set the Color of Bullet.
1. Set the Height of Bullets.
1. Add the created paragraph in TextFrame paragraph collection.
1. Add the second paragraph and repeat the process given in steps **7 to 13**.
1. Save the presentation.

This sample code in Java—an implementation of the steps above—shows you to create a bullet list in a slide:

```java
// Instantiate a Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accessing first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adding and accessing Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accessing the text frame of created autoshape
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Removing the default exisiting paragraph
    txtFrm.getParagraphs().removeAt(0);
    
    // Creating a paragraph
    Paragraph para = new Paragraph();
    
    // Setting paragraph bullet style and symbol
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Setting paragraph text
    para.setText("Welcome to Aspose.Slides");
    
    // Setting bullet indent
    para.getParagraphFormat().setIndent(25);
    
    // Setting bullet color
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // set IsBulletHardColor to true to use own bullet color
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Setting Bullet Height
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Adding Paragraph to text frame
    txtFrm.getParagraphs().add(para);
    
    // saving the presentation as a PPTX file
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Creating Picture Bullets

Aspose.Slides for Android via Java allows you to change the bullets on bullet lists. You get to replace the bullets with custom symbols or images. If you want to add visual interest to a list or draw even more attention to entries on a list, you can use your own image as the bullet.

{{% alert color="primary" %}} 

Ideally, if you intend to replace the regular bullet symbol with a picture, you may want to select a simple graphics image with a transparent background. Such images work best as custom bullet symbols. 

In any case, the image you choose will be reduced to a very small size, so we strongly recommend you select an image that looks good (as a replacement for the bullet symbol) in a list. 

{{% /alert %}} 

To create a picture bullet, go through these steps:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class
1. Access the desired slide in slide collection using [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object
1. Add an autoshape in selected slide
1. Access the [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) of the added shape
1. Remove the default paragraph in the [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. Create the first paragraph instance using Paragraph class
1. Load Image from disc in [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage)
1. Set the bullet type to Picture and the set the image
1. Set the Paragraph Text
1. Set the Paragraph Indent to set the bullet
1. Set the Color of Bullet
1. Set the Height of Bullets
1. Add the created paragraph in [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) paragraph collection
1. Add the second paragraph and repeat the process given in previous steps
1. Save the presentation

This Java code shows you to create a picture bullet in a slide:

```java
Presentation pres = new Presentation();
try {
    // Accessing the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantiate the image for bullets
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adding and accessing Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accessing the text frame of created autoshape
    ITextFrame txtFrm = aShp.getTextFrame();
    // Removing the default exisiting paragraph
    txtFrm.getParagraphs().removeAt(0);

    // Creating new paragraph
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // Setting paragraph bullet style and image
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Setting Bullet Height
    para.getParagraphFormat().getBullet().setHeight(100);

    // Adding Paragraph to text frame
    txtFrm.getParagraphs().add(para);

    // Writing the presentation as a PPTX file
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Creating Multilevel Bullets

To create a bullet list that contains items on different levels—additional lists under the main bullet list—go through these steps:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Access the desired slide in slide collection using [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object.
1. Add an autoshape in selected slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) of the added shape.
1. Remove the default paragraph in the [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Create the first paragraph instance using Paragraph class and with depth set to 0.
1. Create the second paragraph instance using Paragraph class and with depth set to 1.
1. Create the third paragraph instance using Paragraph class and with depth set to 2.
1. Create the fourth paragraph instance using Paragraph class and with depth set to 3.
1. Add the created paragraphs in [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) paragraph collection.
1. Save the presentation.

This code, which is an implementation of the steps above, shows you how to create a multilevel bullet list in Java:

```java
// Instantiate a Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accessing first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adding and accessing Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accessing the text frame of created autoshape
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Removing the default exisiting paragraph
    txtFrm.getParagraphs().clear();
    
    // Creating first paragraph
    Paragraph para1 = new Paragraph();
    // Setting paragraph bullet style and symbol
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Setting bullet level
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Creating second paragraph
    Paragraph para2 = new Paragraph();
    // Setting paragraph bullet style and symbol
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Setting bullet level
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Creating third paragraph
    Paragraph para3 = new Paragraph();
    // Setting paragraph bullet style and symbol
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Setting bullet level
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Creating fourth paragraph
    Paragraph para4 = new Paragraph();
    // Setting paragraph bullet style and symbol
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Setting bullet level
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Adding Paragraph to text frame
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // saving the presentation as a PPTX file
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Create Custom Numbered List
Aspose.Slides for Android via Java provides a simple API to manage paragraphs with custom numbers formatting. To add a custom number list in a paragraph, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Access the desired slide in slide collection using [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object.
1. Add an autoshape in selected slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) of the added shape.
1. Remove the default paragraph in the [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Create the first paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 2
1. Create the second paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 3
1. Create the third paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 7
1. Add the created paragraphs in [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) paragraph collection.
1. Save the presentation.

This Java code shows you how to create a numbered list in a slide:

```java
// Instantiate a Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accessing first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adding and accessing Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accessing the text frame of created autoshape
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Removing the default exisiting paragraph
    txtFrm.getParagraphs().clear();

    // First list
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Second list
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
