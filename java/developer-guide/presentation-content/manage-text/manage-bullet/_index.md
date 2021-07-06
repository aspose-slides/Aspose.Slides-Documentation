---
title: Manage Bullet
type: docs
weight: 60
url: /java/manage-bullet/
---

## **Create Bullet**
This topic is also the part of the topic series of managing text paragraphs. This page will illustrate how we can manage paragraph bullets. Bullets are more useful where something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see how developers can use this small yet powerful feature of Aspose.Slides for Java. Please follow the steps below to manage the paragraph bullets using Aspose.Slides for Java:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the desired slide in slide collection using [ISlide](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlide) object.
1. Add an [AutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IPresentationText) in selected slide.
1. Access the [TextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/TextFrame) of the added shape.
1. Remove the default paragraph in the TextFrame.
1. Create the first paragraph instance using [Paragraph](https://apireference.aspose.com/slides/java/com.aspose.slides/Paragraph) class.
1. Set the bullet type of the paragraph.
1. Set the bullet type to [Symbol](https://apireference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) and the set the bullet character.
1. Set the Paragraph Text.
1. Set the Paragraph Indent to set the bullet.
1. Set the Color of Bullet.
1. Set the Height of Bullets.
1. Add the created paragraph in TextFrame paragraph collection.
1. Add the second paragraph and repeat the process given in steps **7 to 13**.
1. Save the presentation.

The implementation of the above steps is given below.

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

## **Create Picture Bullet**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate how we can manage paragraph picture bullets. Picture bullets are more useful where something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see how developers can use this small yet powerful feature of Aspose.Slides for Java. Please follow the steps below to manage the paragraph picture bullets using Aspose.Slides for Java:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class
- Access the desired slide in slide collection using [ISlide](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlide) object
- Add an autoshape in selected slide
- Access the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) of the added shape
- Remove the default paragraph in the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame)
- Create the first paragraph instance using Paragraph class
- Load Image from disc in [IPPImage](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPPImage)
- Set the bullet type to Picture and the set the image
- Set the Paragraph Text
- Set the Paragraph Indent to set the bullet
- Set the Color of Bullet
- Set the Height of Bullets
- Add the created paragraph in [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) paragraph collection
- Add the second paragraph and repeat the process given in previous steps
- Save the presentation

The implementation of the above steps is given below.

```java
Presentation pres = new Presentation();
try {
    // Accessing the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantiate the image for bullets
    BufferedImage img = ImageIO.read(new File("asp1.jpg"));
    IPPImage imgx = pres.getImages().addImage(img);

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
    para.getParagraphFormat().getBullet().getPicture().setImage(imgx);

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

## **Create Multilevel Bullet**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate that how we can manage paragraphs with multilevel bullets. Please follow the steps below to manage the multilevel bullets using Aspose.Slides for Java:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the desired slide in slide collection using [ISlide](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlide) object.
- Add an autoshape in selected slide.
- Access the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) of the added shape.
- Remove the default paragraph in the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
- Create the first paragraph instance using Paragraph class and with depth set to 0.
- Create the second paragraph instance using Paragraph class and with depth set to 1.
- Create the third paragraph instance using Paragraph class and with depth set to 2.
- Create the fourth paragraph instance using Paragraph class and with depth set to 3.
- Add the created paragraphs in [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) paragraph collection.
- Save the presentation.

The implementation of the above steps is given below.

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

## **Create Custom Numbered List**
Aspose.Slides for Java provides a simple API to manage paragraphs with custom numbers formatting. For this purpose, [**setNumberedBulletStartWith**](https://apireference.aspose.com/slides/java/com.aspose.slides/IBulletFormat#setNumberedBulletStartWith-short-) method has been added to [**IBulletFormat**](https://apireference.aspose.com/slides/java/com.aspose.slides/IBulletFormat). To add a custom number list in a paragraph, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Access the desired slide in slide collection using [ISlide](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlide) object.
- Add an autoshape in selected slide.
- Access the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) of the added shape.
- Remove the default paragraph in the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
- Create the first paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 2
- Create the second paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 3
- Create the third paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 7
- Add the created paragraphs in [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) paragraph collection.
- Save the presentation.

The implementation of the above steps is given below.

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
