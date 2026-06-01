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
description: "Learn how to create and format bulleted, picture, multilevel, and numbered lists in PowerPoint and OpenDocument presentations using Aspose.Slides for Android via Java."
---

## **Overview**

Aspose.Slides for Android via Java lets you create and format bulleted and numbered lists in PowerPoint and OpenDocument presentations. A list item is a paragraph whose bullet settings are controlled through its paragraph format.

Use the [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) method to access paragraph-level list settings. The main entry point is [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), which returns an [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) object. With this object, you can set the bullet type, symbol, picture, color, size, numbering style, and starting number.

This article shows how to:

- create a bulleted list with a custom symbol
- create a numbered list
- create a picture bullet
- create a multilevel list by setting paragraph depth
- inspect and change list formatting in an existing presentation

## **Create a Bulleted List**

To create a bulleted list, add paragraphs to an [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) and set [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) to [BulletType.Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/). You can then set [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getColor--), and [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) to control the bullet appearance.

The following Java example creates a simple bulleted list:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 520, 180);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Review quarterly revenue");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar('*');
    firstParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    firstParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    firstParagraph.getParagraphFormat().getBullet().setHeight(100);
    firstParagraph.getParagraphFormat().setMarginLeft(30);
    firstParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Prepare product roadmap");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('*');
    secondParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    secondParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    secondParagraph.getParagraphFormat().getBullet().setHeight(100);
    secondParagraph.getParagraphFormat().setMarginLeft(30);
    secondParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Confirm launch milestones");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar('*');
    thirdParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    thirdParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    thirdParagraph.getParagraphFormat().getBullet().setHeight(100);
    thirdParagraph.getParagraphFormat().setMarginLeft(30);
    thirdParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("bulleted-list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Create a Numbered List**

Use numbered lists when the order of items matters. Set [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) to [BulletType.Numbered](https://reference.aspose.com/slides/androidjava/com.aspose.slides/bullettype/) and choose a numbering format with [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-short-). You can also set [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) when the list should start from a value other than 1.

The following Java example creates a numbered list:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 520, 180);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Open the source presentation");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletArabicPeriod);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    firstParagraph.getParagraphFormat().setMarginLeft(30);
    firstParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Update the slide content");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletArabicPeriod);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    secondParagraph.getParagraphFormat().setMarginLeft(30);
    secondParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Save the modified presentation");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletArabicPeriod);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    thirdParagraph.getParagraphFormat().setMarginLeft(30);
    thirdParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("numbered-list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Create a Picture Bullet**

Aspose.Slides allows you to replace a regular bullet symbol with an image. Picture bullets work best with simple images that remain readable at a small size, such as icons or small transparent PNG files.

To create a picture bullet, add an image to [Presentation.getImages](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getImages--) and assign the returned [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) object to [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--).

The following Java example creates a list that uses an image as the bullet:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 520, 180);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage;
    IImage image = Images.fromFile("image.png");
    try {
        bulletImage = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Analyze customer feedback");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    firstParagraph.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    firstParagraph.getParagraphFormat().getBullet().setHeight(100);
    firstParagraph.getParagraphFormat().setMarginLeft(30);
    firstParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Prioritize product improvements");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    secondParagraph.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    secondParagraph.getParagraphFormat().getBullet().setHeight(100);
    secondParagraph.getParagraphFormat().setMarginLeft(30);
    secondParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("picture-bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Create a Multilevel List**

Use [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) to place list items on different levels. Level 0 is the top level, level 1 is nested below it, and so on.

The following Java example creates a multilevel bulleted list:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 520, 240);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Product launch");
    firstParagraph.getParagraphFormat().setDepth((short) 0);
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 8226);
    firstParagraph.getParagraphFormat().setMarginLeft(30);
    firstParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Finalize positioning");
    secondParagraph.getParagraphFormat().setDepth((short) 1);
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Publish release materials");
    thirdParagraph.getParagraphFormat().setDepth((short) 1);
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar('-');
    thirdParagraph.getParagraphFormat().setMarginLeft(60);
    thirdParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(thirdParagraph);

    Paragraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Measure launch results");
    fourthParagraph.getParagraphFormat().setDepth((short) 0);
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar((char) 8226);
    fourthParagraph.getParagraphFormat().setMarginLeft(30);
    fourthParagraph.getParagraphFormat().setIndent(-20);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel-list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Change an Existing List**

To change list formatting in an existing presentation, access the target paragraph and update its [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) settings. The same methods used to create lists can be used to inspect or modify lists loaded from a PPT, PPTX, or ODP file.

The following Java example changes the first paragraph in a text frame to use a numbered list style:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated-list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Can bulleted and numbered lists be exported to PDF or images?**

Yes. Aspose.Slides preserves list formatting when the target format supports the corresponding text layout and bullet features.

**Can I edit lists in existing presentations?**

Yes. Load the presentation, access the target paragraph, inspect or update its [IParagraphFormat.getBullet](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) settings, and save the presentation.

**Can lists contain non-Latin text?**

Yes. List item text can contain Unicode characters, so you can create lists in multilingual presentations. Make sure the fonts used in the presentation support the characters you need.
