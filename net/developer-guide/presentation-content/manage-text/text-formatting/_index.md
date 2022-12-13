---
title: Text Formatting
type: docs
weight: 50
url: /net/text-formatting/
keywords: "Highlight text, Regular expression, Align text paragraphs, Text transparency, Paragraph font properties, font family, text rotation, custom angle rotation, text frame, line spacing, Autofit property, text frame anchor, text tabulation, C#, Csharp, Aspose.Slides for .NET"
description: "Manage and manipulate text and text frame properties in C# or .NET"
---

## **Highlight Text**
New HighlightText method has been added to ITextFrame interface and TextFrame class.

It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // highlighting all words 'important'
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // highlighting all separate 'the' occurrences
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Aspose provides a simple, [free online PowerPoint editing service](https://products.aspose.app/slides/editor)

{{% /alert %}} 


## **Highlight Text using Regular Expression**
New HighlightRegex method has been added to ITextFrame interface and TextFrame class.

It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.


The code snippet below shows how to use this feature:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // highlighting all words with 10 symbols or longer
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```


## **Align Text Paragraphs**
Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for .NET supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for .NET :

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Obtain the reference of a slide by using its Index.
3. Access the Placeholder shapes present in the slide and typecast them as a AutoShape.
4. Get the Paragraph (that needs to be aligned) from the TextFrame exposed by AutoShape.
5. Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
6. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
// Instantiate a Presentation object that represents a PPTX file
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // Accessing first slide
    ISlide slide = pres.Slides[0];

    // Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Change the text in both placeholders
    tf1.Text = "Center Align by Aspose";
    tf2.Text = "Center Align by Aspose";

    // Getting the first paragraph of the placeholders
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Aligning the text paragraph to center
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    //Writing the presentation as a PPTX file
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```


## **Set Transparency for Text**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides for .NET. In order to set the transparency to text. Please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get the reference of a slide.
3. Set shadow color
4. Write the presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
using (Presentation pres = new Presentation("transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - transparency is: {((float)shadowColor.A / byte.MaxValue) * 100}");

    // set transparency to zero percent
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **Set Character Spacing for Text**

Aspose.Slides allows you to set the space between letters in a textbox. This way, you get to adjust the visual density of a line or block of text by expanding or condensing the spacing between characters.

This C# code shows you how to expand the spacing for one line of text and condense the spacing for another line:

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape) presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape) presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // expand
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // condense

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Manage Paragraph's Font Properties**

Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for .NET to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for .NET :

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the Placeholder shapes in the slide and typecast them to AutoShape.
1. Get the Paragraph from the TextFrame exposed by AutoShape.
1. Justify the paragraph.
1. Access a Paragraph's text Portion.
1. Define the font using FontData and set the Font of the text Portion accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the FillFormat exposed by the Portion object.
1. Write the modified presentation to a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.

```c#
// Instantiate a Presentation object that represents a PPTX file// Instantiate a Presentation object that represents a PPTX file
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // Accessing a slide using its slide position
    ISlide slide = pres.Slides[0];

    // Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // Accessing the first Paragraph
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // Accessing the first portion
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // Define new fonts
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // Assign new fonts to portion
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // Set font to Bold
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // Set font to Italic
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // Set font color
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    //Write the PPTX to disk
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```


## **Manage Font Family of Text**
A Portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for .NET to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Obtain the reference of a slide by using its index.
3. Add an AutoShape of the type Rectangle to the slide.
4. Remove the fill style associated with the AutoShape.
5. Access the AutoShape's TextFrame.
6. Add some text to the TextFrame.
7. Access the Portion object associated with the TextFrame.
8. Define the font to be used for the Portion.
9. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the Portion object.
10. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
// Instantiate Presentation
using (Presentation presentation = new Presentation())
{
   
    // Get first slide
    ISlide sld = presentation.Slides[0];

    // Add an AutoShape of Rectangle type
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // Remove any fill style associated with the AutoShape
    ashp.FillFormat.FillType = FillType.NoFill;

    // Access the TextFrame associated with the AutoShape
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "Aspose TextBox";

    // Access the Portion associated with the TextFrame
    IPortion port = tf.Paragraphs[0].Portions[0];

    // Set the Font for the Portion
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // Set Bold property of the Font
    port.PortionFormat.FontBold = NullableBool.True;

    // Set Italic property of the Font
    port.PortionFormat.FontItalic = NullableBool.True;

    // Set Underline property of the Font
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // Set the Height of the Font
    port.PortionFormat.FontHeight = 25;

    // Set the color of the Font
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Write the PPTX to disk 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```


## **Set Text Rotation**
Aspose.Slides for .NET allows developers to rotate the text. Text could be set to appear as Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical or WordArtVerticalRightToLeft. To rotate the text of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Access the first slide.
3. Add any Shape to the slide.
4. Access the TextFrame.
5. Rotate the text.
6. Save file to disk.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Get the first slide 
ISlide slide = presentation.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Add TextFrame to the Rectangle
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accessing the text frame
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

// Create the Paragraph object for text frame
IParagraph para = txtFrame.Paragraphs[0];

// Create Portion object for paragraph
IPortion portion = para.Portions[0];
portion.Text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Save Presentation
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```


## **Set Custom Rotation Angle for TextFrame**
Aspose.Slides for .NET now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new property RotationAngle has been added to IChartTextBlockFormat and ITextFrameFormat interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle property, Please follow the steps below:

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Add a chart on slide.
3. Set RotationAngle property.
4. Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

// Save Presentation
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```


## **Line Spacing of Paragraph**
Aspose.Slides provides properties under `ParagraphFormat`—`SpaceAfter`, `SpaceBefore` and `SpaceWithin`—that allow you to manage the line spacing for a paragraph. The three properties are used this way:

* To specify the line spacing for a paragraph in percentage, use a positive value. 
* To specify the line spacing for a paragraph in points, use a negative value.

For example, you can apply a 16pt line spacing for a paragraph by setting the `SpaceBefore` property to -16.

This is how you specify the line spacing for a specific paragraph:

1. Load a presentation containing an AutoShape with some text in it.
2. Get a slide's reference through its index.
3. Access the TextFrame.
4. Access the Paragraph.
5. Set the Paragraph properties.
6. Save the presentation.

This C# code shows you how to specify the line spacing for a paragraph:

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation("Fonts.pptx");

// Obtain a slide's reference by its index
ISlide sld = presentation.Slides[0];

// Access the TextFrame
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// Access the Paragraph
IParagraph para1 = tf1.Paragraphs[0];

// Set properties of Paragraph
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// Save Presentation
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```


## **Set the AutofitType Property for TextFrame**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for .NET allows developers to set AutofitType property of any text frame. AutofitType could be set to Normal or Shape. If set to Normal then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to shape, then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the TextFrame.
5. Set the AutofitType of the TextFrame.
6. Save file to disk.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Access the first slide 
ISlide slide = presentation.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Add TextFrame to the Rectangle
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accessing the text frame
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Create the Paragraph object for text frame
IParagraph para = txtFrame.Paragraphs[0];

// Create Portion object for paragraph
IPortion portion = para.Portions[0];
portion.Text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Save Presentation
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```


## **Set Anchor of TextFrame**
Aspose.Slides for .NET allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. TextAnchorType could be set to Top, Center, Bottom, Justified or Distributed. To set Anchor of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the TextFrame.
5. Set TextAnchorType of the TextFrame.
6. Save file to disk.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Get the first slide 
ISlide slide = presentation.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// Add TextFrame to the Rectangle
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// Accessing the text frame
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// Create the Paragraph object for text frame
IParagraph para = txtFrame.Paragraphs[0];

// Create Portion object for paragraph
IPortion portion = para.Portions[0];
portion.Text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Save Presentation
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **Set Text Tabulation**
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs)
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Helloworld!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".