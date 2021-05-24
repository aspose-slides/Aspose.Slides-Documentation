---
title: Text Formatting
type: docs
weight: 40
url: /net/text-formatting/
---

## **Highlight Text**
New HighlightText method has been added to ITextFrame interface and TextFrame class.

It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();
Presentation presentation = new Presentation(dataDir +"SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // highlighting all words 'important'
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // highlighting all separate 'the' occurrences
presentation.Save(dataDir+ "SomePresentation-out2.pptx", SaveFormat.Pptx);
```




## **Highlight Text using Regular Expression**
New HighlightRegex method has been added to ITextFrame interface and TextFrame class.

It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.


The code snippet below shows how to use this feature:

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();
Presentation presentation = new Presentation(dataDir + "SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // highlighting all words with 10 symbols or longer
presentation.Save(dataDir+ "SomePresentation-out.pptx", SaveFormat.Pptx);
```




## **Align Text Paragraphs**
Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for .NET supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for .NET :

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access the Placeholder shapes present in the slide and typecast them as a AutoShape.
- Get the Paragraph (that needs to be aligned) from the TextFrame exposed by AutoShape.
- Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Instantiate a Presentation object that represents a PPTX file
using (Presentation pres = new Presentation(dataDir + "ParagraphsAlignment.pptx"))
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
    pres.Save(dataDir + "Centeralign_out.pptx", SaveFormat.Pptx);
}
```


## **Set Transparency for Text**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides for .NET. In order to set the transparency to text. Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Get the reference of a slide.
- Set shadow color
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();
using (Presentation pres = new Presentation(dataDir+ "transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - transparency is: {((float)shadowColor.A / byte.MaxValue) * 100}");

    // set transparency to zero percent
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save(dataDir+"transparency-2.pptx", SaveFormat.Pptx);
}
```




## **Manage Paragraph's Font Properties**
Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for .NET to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for .NET :

1. Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the Placeholder shapes in the slide and typecast them to AutoShape.
1. Get the Paragraph from the TextFrame exposed by AutoShape.
1. Justify the paragraph.
1. Access a Paragraph's text Portion.
1. Define the font using FontData and set the Font of the text Portion accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the FillFormat exposed by the Portion object.
1. Write the modified presentation to a [PPTX](https://wiki.fileformat.com/presentation/pptx/) file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Instantiate a Presentation object that represents a PPTX file// Instantiate a Presentation object that represents a PPTX file
using (Presentation pres = new Presentation(dataDir + "FontProperties.pptx"))
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
    pres.Save(dataDir + "WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```


## **Manage Font Family of Text**
As mentioned in Managing Font Related Properties a Portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for .NET to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

- Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its index.
- Add an AutoShape of the type Rectangle to the slide.
- Remove the fill style associated with the AutoShape.
- Access the AutoShape's TextFrame.
- Add some text to the TextFrame.
- Access the Portion object associated with the TextFrame.
- Define the font to be used for the Portion.
- Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the Portion object.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

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
    presentation.Save(dataDir + "SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```




## **Set Text Rotation**
Aspose.Slides for .NET allows developers to rotate the text. Text could be set to appear as Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical or WordArtVerticalRightToLeft. To rotate the text of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Access the first slide.
- Add any Shape to the slide.
- Access the TextFrame.
- Rotate the text.
- Save file to disk.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

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
presentation.Save(dataDir + "RotateText_out.pptx", SaveFormat.Pptx);
```


## **Set Custom Rotation Angle for TextFrame**
Aspose.Slides for .NET now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new property RotationAngle has been added to IChartTextBlockFormat and ITextFrameFormat interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle property, Please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Add a chart on slide.
- Set RotationAngle property.
- Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Create an instance of Presentation class
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

// Save Presentation
presentation.Save(dataDir + "textframe-rotation_out.pptx", SaveFormat.Pptx);
```


## **Line Spacing of Paragraph**
Aspose.Slides for .NET lets developers to set the properties of ParagraphFormat to deal with line spacing of the paragraph. The properties SpaceAfter, SpaceBefore and SpaceWithin could be set for different line spacing. This article explains how to set these properties of ParagraphFormat. Aspose.Slides for .NET provides a simple API for setting properties of ParagraphFormat:

- Load a presentation with an AutoShape having some text in it.
- Obtain a slide's reference by its index.
- Access the TextFrame.
- Access the Paragraph.
- Set properties of Paragraph.
- Save the presentation to disk.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

// Create an instance of Presentation class
Presentation presentation = new Presentation(dataDir + "Fonts.pptx");

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
presentation.Save(dataDir + "LineSpacing_out.pptx", SaveFormat.Pptx);
```




## **Set the AutofitType Property for TextFrame**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for .NET allows developers to set AutofitType property of any text frame. AutofitType could be set to Normal or Shape. If set to Normal then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to shape, then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Access the first slide.
- Add any shape to the slide.
- Access the TextFrame.
- Set the AutofitType of the TextFrame.
- Save file to disk.

```
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

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
presentation.Save(dataDir + "formatText_out.pptx", SaveFormat.Pptx); 
```


## **Set Anchor of TextFrame**
Aspose.Slides for .NET allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. TextAnchorType could be set to Top, Center, Bottom, Justified or Distributed. To set Anchor of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Access the first slide.
- Add any shape to the slide.
- Access the TextFrame.
- Set TextAnchorType of the TextFrame.
- Save file to disk.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Text();

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
presentation.Save(dataDir + "AnchorText_out.pptx", SaveFormat.Pptx);
```



## **Set Text Tabulation**
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs)
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Helloworld!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".