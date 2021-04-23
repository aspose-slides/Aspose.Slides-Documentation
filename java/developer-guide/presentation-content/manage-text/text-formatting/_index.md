---
title: Text Formatting
type: docs
weight: 40
url: /java/text-formatting/
---


## **Highlight Text**
Method [highlightText](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) has been added to [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) interface and [TextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/TextFrame) class.

It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions textHighlightingOptions = new TextHighlightingOptions();
    textHighlightingOptions.setWholeWordsOnly(true);
    
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("title", Color.BLUE); // highlighting all words 'important'
    ((AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightText("to", Color.MAGENTA, textHighlightingOptions);// highlighting all separate 'the' occurrences
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Highlight Text using Regular Expression**
Method [highlightRegex](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) has been added to [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) interface and [TextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/TextFrame) class.

It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    TextHighlightingOptions options = new TextHighlightingOptions();
    
    ((AutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0)).getTextFrame().highlightRegex("\\b[^\\s]{4}\\b", java.awt.Color.YELLOW, options); // highlighting all words with 10 symbols or longer
    
    pres.save("OutputPresentation-highlight.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Align Text Paragraphs**
Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for Java supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for Java:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Access the Placeholder shapes present in the slide and typecast them as a [AutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/AutoShape).
- Get the Paragraph (that needs to be aligned) from the [TextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape#getTextFrame--) exposed by [AutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/AutoShape).
- Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```java
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("ParagraphsAlignment.pptx");
try {
    // Accessing first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Change the text in both placeholders
    tf1.setText("Center Align by Aspose");
    tf2.setText("Center Align by Aspose");

    // Getting the first paragraph of the placeholders
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Aligning the text paragraph to center
    para1.getParagraphFormat().setAlignment(TextAlignment.Center);
    para2.getParagraphFormat().setAlignment(TextAlignment.Center);

    //Writing the presentation as a PPTX file
    pres.save("Centeralign_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Transparency for Text**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides for Java. In order to set the transparency to text. Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Get the reference of a slide.
- Set shadow color
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.

```java
Presentation pres = new Presentation("transparency.pptx");
try {
    IAutoShape shape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IEffectFormat effects = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getEffectFormat();

    IOuterShadow outerShadowEffect = effects.getOuterShadowEffect();

    Color shadowColor = outerShadowEffect.getShadowColor().getColor();
    System.out.println(shadowColor.toString() + " - transparency is: "+ (shadowColor.getAlpha() / 255f) * 100);

    // set transparency to zero percent
    outerShadowEffect.getShadowColor().setColor(new Color(shadowColor.getRed(), shadowColor.getGreen(), shadowColor.getBlue(), 255));

    pres.save("transparency-2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Paragraph's Font Properties**
Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Java to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for Java:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the Placeholder shapes in the slide and typecast them to [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Get the [Paragraph](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) from the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrame) exposed by [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
1. Justify the paragraph.
1. Access a Paragraph's text Portion.
1. Define the font using FontData and set the Font of the text Portion accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [getFillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IBasePortionFormat#getFillFormat--) exposed by the [Portion](https://apireference.aspose.com/slides/java/com.aspose.slides/IPortion) object.
1. Write the modified presentation to a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.

```java
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("FontProperties.pptx");
try {
    // Accessing a slide using its slide position
    ISlide slide = pres.getSlides().get_Item(0);

    // Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.getShapes().get_Item(0)).getTextFrame();
    ITextFrame tf2 = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame();

    // Accessing the first Paragraph
    IParagraph para1 = tf1.getParagraphs().get_Item(0);
    IParagraph para2 = tf2.getParagraphs().get_Item(0);

    // Accessing the first portion
    IPortion port1 = para1.getPortions().get_Item(0);
    IPortion port2 = para2.getPortions().get_Item(0);

    // Define new fonts
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Assign new fonts to portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);

    // Set font to Bold
    port1.getPortionFormat().setFontBold(NullableBool.True);
    port2.getPortionFormat().setFontBold(NullableBool.True);

    // Set font to Italic
    port1.getPortionFormat().setFontItalic(NullableBool.True);
    port2.getPortionFormat().setFontItalic(NullableBool.True);

    // Set font color
    port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    //Write the PPTX to disk
    pres.save("WelcomeFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Font Family of Text**
As mentioned in Managing Font Related Properties a Portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Java to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

- Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its index.
- Add an [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape) of the type [Rectangle](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle) to the slide.
- Remove the fill style associated with the [IAutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- Access the AutoShape's TextFrame.
- Add some text to the TextFrame.
- Access the Portion object associated with the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- Define the font to be used for the [Portion](https://apireference.aspose.com/slides/java/com.aspose.slides/IPortion).
- Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the Portion object.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```java
// Instantiate Presentation
Presentation pres = new Presentation();
try {

    // Get first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Remove any fill style associated with the AutoShape
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Access the TextFrame associated with the AutoShape
    ITextFrame tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");

    // Access the Portion associated with the TextFrame
    IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);

    // Set the Font for the Portion
    port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));

    // Set Bold property of the Font
    port.getPortionFormat().setFontBold(NullableBool.True);

    // Set Italic property of the Font
    port.getPortionFormat().setFontItalic(NullableBool.True);

    // Set Underline property of the Font
    port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);

    // Set the Height of the Font
    port.getPortionFormat().setFontHeight(25);

    // Set the color of the Font
    port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Write the PPTX to disk 
    pres.save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Set Text Rotation**
Aspose.Slides for Java allows developers to rotate the text. Text could be set to appear as [Horizontal](https://apireference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Horizontal), [Vertical](https://apireference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical), [Vertical270](https://apireference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#Vertical270), [WordArtVertical](https://apireference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVertical), [EastAsianVertical](https://apireference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#EastAsianVertical), [MongolianVertical](https://apireference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#MongolianVertical) or [WordArtVerticalRightToLeft](https://apireference.aspose.com/slides/java/com.aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). To rotate the text of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Access the first slide.
- Add any Shape to the slide.
- Access the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- [Rotate the text](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
- Save file to disk.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Get the first slide 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accessing the text frame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);
    
    // Create the Paragraph object for text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Create Portion object for paragraph
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Save Presentation
    pres.save("RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Custom Rotation Angle for TextFrame**
Aspose.Slides for Java now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new methods [setRotationAngle](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) and [getRotationAngle](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#getRotationAngle--) have been added to [IChartTextBlockFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartTextBlockFormat) and [ITextFrameFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat) interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle, Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Add a chart on slide.
- [Set RotationAngle property](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-).
- Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accessing the text frame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setRotationAngle(25);

    // Create the Paragraph object for text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Create Portion object for paragraph
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Text rotation example.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Save Presentation
    pres.save(resourcesOutputPath+"RotateText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Line Spacing of Paragraph**
Aspose.Slides for Java lets developers to set the properties of ParagraphFormat to deal with line spacing of the paragraph. The properties SpaceAfter, SpaceBefore and SpaceWithin could be set for different line spacing. This article explains how to set these properties of [ParagraphFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IParagraphFormat). Aspose.Slides for Java provides a simple API for setting properties of ParagraphFormat:

- Load a presentation with an AutoShape having some text in it.
- Obtain a slide's reference by its index.
- Access the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- Access the Paragraph.
- Set properties of [Paragraph](https://apireference.aspose.com/slides/java/com.aspose.slides/IParagraph).
- Save the presentation to disk.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Obtain a slide's reference by its index
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Access the TextFrame
    ITextFrame tf1 = ((IAutoShape)sld.getShapes().get_Item(0)).getTextFrame();
    
    // Access the Paragraph
    IParagraph para = tf1.getParagraphs().get_Item(0);
    
    // Set properties of Paragraph
    para.getParagraphFormat().setSpaceWithin(80);
    para.getParagraphFormat().setSpaceBefore(40);
    para.getParagraphFormat().setSpaceAfter(40);
    
    // Save Presentation
    pres.save("LineSpacing_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the AutofitType Property for TextFrame**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for Java allows developers to set AutofitType property of any text frame. AutofitType could be set to [Normal](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) or [Shape](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape). If set to [Normal](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Normal) then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to [Shape](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAutofitType#Shape), then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation)class.
- Access the first slide.
- Add any shape to the slide.
- Access the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- [Set the AutofitType](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) of the TextFrame.
- Save file to disk.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Access the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 150);

    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Accessing the text frame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    // Create the Paragraph object for text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Create Portion object for paragraph
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Save Presentation
    pres.save(resourcesOutputPath + "formatText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Anchor of TextFrame**
Aspose.Slides for Java allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. AnchorType could be set to [Top](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Top), [Center](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Center), [Bottom](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Bottom), [Justified](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Justified) or [Distributed](https://apireference.aspose.com/slides/java/com.aspose.slides/TextAnchorType#Distributed). To set Anchor of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Access the first slide.
- Add any shape to the slide.
- Access the [ITextFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IAutoShape).
- [Set TextAnchorType](https://apireference.aspose.com/slides/java/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) of the TextFrame.
- Save file to disk.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Get the first slide 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add an AutoShape of Rectangle type
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);
    
    // Add TextFrame to the Rectangle
    ashp.addTextFrame("");
    ashp.getFillFormat().setFillType(FillType.NoFill);
    
    // Accessing the text frame
    ITextFrame txtFrame = ashp.getTextFrame();
    txtFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);
    
    // Create the Paragraph object for text frame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);
    
    // Create Portion object for paragraph
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Save Presentation
    pres.save("AnchorText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
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
