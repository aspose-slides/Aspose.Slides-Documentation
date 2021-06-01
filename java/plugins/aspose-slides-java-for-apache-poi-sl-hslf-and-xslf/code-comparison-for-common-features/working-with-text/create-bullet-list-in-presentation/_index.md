---
title: Create Bullet List in Presentation using Apache POI and Aspose.Slides
type: docs
weight: 10
url: /java/slides-poi/create-bullet-list-in-presentation/
---

## **Aspose.Slides - Create Bullet List in Presentation**
Bullets are more useful where the something is to be described in steps. Moreover, text looks well organised with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see that how developers can use this small yet powerful feature of Aspose.Slides for Java.

```java
//Creating a paragraph
Paragraph para = new Paragraph();

//Setting paragraph bullet style and symbol
para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
para.getParagraphFormat().getBullet().setChar((char) 8226);

//Setting paragraph text
para.setText("Welcome to Aspose.Slides");

//Setting bullet indent
para.getParagraphFormat().setIndent(25);

//Setting bullet color
para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);

// set IsBulletHardColor to true to use own bullet color
para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);

//Setting Bullet Height
para.getParagraphFormat().getBullet().setHeight(100);
```

## **Apache POI SL - HSLF XSLF - Create Bullet List in Presentation**
RichTextRun.setBullet is used make bulleted list using Apache POI SL - HSLF XSLF

```java
TextBox shape = new TextBox();

RichTextRun rt = shape.getTextRun().getRichTextRuns()[0];

shape.setText(
        "January\r" +
        "February\r" +
        "March\r" +
        "April");

rt.setFontSize(42);
rt.setBullet(true);
rt.setBulletOffset(0);  //bullet offset
rt.setTextOffset(50);   //text offset (should be greater than bullet offset)
rt.setBulletChar('\u263A'); //bullet character

slide.addShape(shape);

shape.setAnchor(new java.awt.Rectangle(50, 50, 500, 300));  //position of the text box in the slide

slide.addShape(shape);
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/slides/createbulletedlists)

{{% alert color="primary" %}} 

For more details, visit [Managing Paragraph Bullets in PPTX](https://docs.aspose.com/slides/java/manage-paragraph/#paragraph-bullets-in-pptx).

{{% /alert %}}
