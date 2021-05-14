---
title: Manage Paragraph
type: docs
weight: 30
url: /java/manage-paragraph/
---


## **Multiple Paragraphs having Multiple Portions**
An ITextFame object can have one or more Paragraphs (every paragraph is created through a carriage return), that is a collection of IParagraph objects. Furthermore, an IParagraph object can have one or more Portions (a collection of IPortion objects. An IPortion object manages text and its formatting properties. So, it means that IParagraph object has capacity to handle text with different formatting properties through its underlying IPortion objects.
Please follow the steps below to add TextFrame having 3 paragraphs and 3 portions for each paragraph using Aspose.Slides for Java:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) of Rectangle type to the slide.
- Access the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) associated with the [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- Create two [IParagraph](https://apireference.aspose.com/slides/java/com.aspose.slides/IParagraph) objects and add it to the [IParagraphs](https://apireference.aspose.com/slides/java/com.aspose.slides/IParagraph) collection of the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- Create three [IPortion](https://apireference.aspose.com/slides/java/com.aspose.slides/IPortion) objects for each new [IParagraph](https://apireference.aspose.com/slides/java/com.aspose.slides/IParagraph) (two Portion objects for default Paragraph) and add each [IPortion](https://apireference.aspose.com/slides/java/com.aspose.slides/IPortion) object to the [IPortions](https://apireference.aspose.com/slides/java/com.aspose.slides/IPortion) collection of each [IParagraph](https://apireference.aspose.com/slides/java/com.aspose.slides/IParagraph).
- Set some text for each [Portion](https://apireference.aspose.com/slides/java/com.aspose.slides/Portion).
- Apply the desired formatting features to each [Portion](https://apireference.aspose.com/slides/java/com.aspose.slides/Portion) using different formatting properties exposed by [IPortion](https://apireference.aspose.com/slides/java/com.aspose.slides/IPortion) object.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```java
// Instantiate a Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accessing first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Access TextFrame of the AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Create Paragraphs and Portions with different text formats
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //Write PPTX to Disk
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Paragraph Bullets in PPTX**
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

## **Paragraph Picture Bullets in PPTX**
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

## **Multilevel Bullets**
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

## **Paragraph with Custom Numbered List**
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

## **Paragraph Indent**
This page will illustrate how we can manage paragraph indent. We will see how developers can use this feature of Aspose.Slides for Java. Please follow the steps below to manage the paragraph indent using Aspose.Slides for Java:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) with three Paragraphs in the Rectangle.
1. Hide the Lines of the Rectangle.
1. Set indent of each [IParagraph](https://apireference.aspose.com/slides/java/com.aspose.slides/IParagraph) using its BulletOffset property.
1. Write the modified presentation as a PPT file.

The implementation of the above steps is given below.

```java
// Instantiate Presentation Class
Presentation pres = new Presentation();
try {
    // Get first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add a Rectangle Shape
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Add TextFrame to the Rectangle
    ITextFrame tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    
    // Set the text to fit the shape
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Hide the lines of the Rectangle
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Get first Paragraph in the TextFrame and set its Indent
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Setting paragraph bullet style and symbol
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Get second Paragraph in the TextFrame and set its Indent
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Get third Paragraph in the TextFrame and set its Indent
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    //Write the Presentation to disk
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **End Paragraph Run Properties for Paragraph**
This page will illustrate how we can manage end paragraph run properties. We will see how developers can use this feature of Aspose.Slides for Java. Please follow the steps below to manage the End paragraph Run Properties using Aspose.Slides for Java:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a [TextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/TextFrame) with two Paragraphs in the Rectangle.
1. Set Font Height and Font type of paragraphs.
1. Set End properties of paragraphs.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Import HTML Text in Paragraphs**
This topic is also part of a series of topics about managing text paragraphs. Aspose.Slides for Java has enhanced support for adding HTML text or saving paragraphs text to HTML. This article shows how to manage paragraphs to use HTML data and shows how developers can use this small yet powerful feature. To manage paragraph bullets using Aspose.Slides for Java:

- Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Access the desired slide in slide collection using the [ISlide](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide) object.
- Add an autoshape to the selected slide.
- Add and access the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) of the added shape.
- Remove the default paragraph in the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame).
- Read the source HTML file in a TextReader.
- Create the first paragraph instance using the [Paragraph](https://apireference.aspose.com/slides/java/com.aspose.slides/Paragraph) class.
- Add the HTML file content in the read TextReader to the TextFrame's ParagraphCollection.
- Save the presentation.

The implementation of the above steps is given below.

```java
// Create Empty presentation instance
Presentation pres = new Presentation();
try {
    // Acesss the default first slide of presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Adding the AutoShape to accomodate the HTML content
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Adding text frame to the shape
    ashape.addTextFrame("");

    // Clearing all paragraphs in added text frame
    ashape.getTextFrame().getParagraphs().clear();

    // Loading the HTML file using stream reader
    TextReader tr = new StreamReader("file.html");

    // Adding text from HTML stream reader in text frame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Saving Presentation
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Export Paragraphs Text to HTML**
Please follow the steps below to see how to export the paragraph text to HTML using Aspose.Slides for Java:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class and load the desired presentation.
- Access the desired slide into the slide collection using [ISlide](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide) object.
- Access the desired shape for which text need to be exported to HTML.
- Access the [TextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/TextFrame) of the accessed shape.
- Create an instance of StreamWriter and add the new HTML file.
- Export the desired number of paragraphs data by providing starting index to the StreamWriter.
  
The implementation of the above steps is given below.

```java
// Load the presentation file
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Acesss the default first slide of presentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Desired index
    int index = 0;

    // Accessing the added shape
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Creating output HTML file
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extracting first paragraph as HTML
    // Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

