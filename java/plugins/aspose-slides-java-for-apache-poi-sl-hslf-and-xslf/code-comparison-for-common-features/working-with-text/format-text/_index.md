---
title: Format Text using Apache POI and Aspose.Slides
type: docs
weight: 20
url: /java/slides-poi/format-text/
---

## **Aspose.Slides - Format Text**
Presentations usually contain both text and images. The text can be formatted in various way, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content.

```java
//Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("unformatted.pptx");

//Accessing a slide using its slide position
ISlide slide = pres.getSlides().get_Item(0);

//Accessing the first and second placeholder in the slide and typecasting it as AutoShape
ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

//Accessing the first Paragraph
IParagraph para1 = tf1.getParagraphs().get_Item(0);
IParagraph para2 = tf2.getParagraphs().get_Item(0);

//Accessing the first portion
IPortion port1 = para1.getPortions().get_Item(0);
IPortion port2 = para2.getPortions().get_Item(0);

//Define new fonts
FontData fd1 = new FontData("Elephant");
FontData fd2 = new FontData("Castellar");

//Assign new fonts to portion
port1.getPortionFormat().setLatinFont(fd1);
port2.getPortionFormat().setLatinFont(fd2);

//Set font to Bold
port1.getPortionFormat().setFontBold(NullableBool.True);
port2.getPortionFormat().setFontBold(NullableBool.True);

//Set font to Italic
port1.getPortionFormat().setFontItalic(NullableBool.True);
port2.getPortionFormat().setFontItalic(NullableBool.True);

//Set font color
port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
```

## **Apache POI SL - HSLF XSLF - Format Text**
XSLFTextRun provides font releated properties to format text using Apache POI SL - HSLF XSLF

```java
XMLSlideShow ppt = new XMLSlideShow();

XSLFSlide slide = ppt.createSlide();

XSLFTextBox shape = slide.createTextBox();

XSLFTextParagraph p = shape.addNewTextParagraph();

XSLFTextRun r1 = p.addNewTextRun();
r1.setText("The");
r1.setFontColor(Color.blue);
r1.setFontSize(24);

XSLFTextRun r2 = p.addNewTextRun();
r2.setText(" quick");
r2.setFontColor(Color.red);
r2.setBold(true);

XSLFTextRun r3 = p.addNewTextRun();
r3.setText(" brown");
r3.setFontSize(12);
r3.setItalic(true);
r3.setStrikethrough(true);

XSLFTextRun r4 = p.addNewTextRun();
r4.setText(" fox");
r4.setUnderline(true);
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/text/formattext)

{{% alert color="primary" %}} 

For more details, visit [Managing Font Related Properties](https://docs.aspose.com/slides/java/text-formatting/).

{{% /alert %}}
