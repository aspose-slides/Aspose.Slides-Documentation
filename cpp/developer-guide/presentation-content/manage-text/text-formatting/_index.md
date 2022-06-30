---
title: Text Formatting
type: docs
weight: 50
url: /cpp/text-formatting/
---



## **Highlight Text**
New HighlightText method has been added to ITextFrame and TextFrame classes. It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Aspose provides a simple, [free online PowerPoint editing service](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Highlight Text using Regular Expression**
New HighlightRegex method has been added to ITextFrame and TextFrame classes. It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}



## **Align Text Paragraph**
Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for C++ supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for C++ :

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Obtain the reference of a slide by using its Index.
3. Access the Placeholder shapes present in the slide and typecast them as an AutoShape.
4. Get the Paragraph (that needs to be aligned) from the TextFrame exposed by AutoShape.
5. Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
6. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **Set Transparency for Text**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides. In order to set the transparency to text. Please follow the steps below:

1. Create an instance of Presentation class.
2. Get reference of a slide.
3. Set shadow color
4. Write the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}


## **Manage Paragraph's Font Properties**
Presentations usually contain both text and images. The text can be formatted in a various way, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for C++ to configure the font properties of paragraphs of text on slides. To manage the font properties of a paragraph using Aspose.Slides for C++ :

1. Create an instance of the `Presentation` class.
1. Obtain a slide's reference by using its index.
1. Access the Placeholder shapes in the slide and typecast them to AutoShape.
1. Get the Paragraph from the TextFrame exposed by AutoShape.
1. Justify the paragraph.
1. Access a Paragraph's text Portion.
1. Define the font using FontData and set the Font of the text Portion accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the FillFormat exposed by the Portion object.
1. Write the modified presentation to a PPTX file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}


## **Manage Font Family of Text**
A portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for C++ to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

1. Create an instance of the `Presentation` class.
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

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}


## **Set Text Rotation**
Aspose.Slides for C++ allows developers to rotate the text. Text could be set to appear as Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical or WordArtVerticalRightToLeft. To rotate the text of any TextFrame, please follow the steps below:

1. Create an instance of `Presentation` class.
2. Access the first slide.
3. Add any Shape to the slide.
4. Access the TextFrame.
5. Rotate the text.
6. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}


## **Tabs and EffectiveTabs in Presentation**
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs)
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Helloworld!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".

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

This C++ code shows you how to specify the line spacing for a paragraph:

``` cpp
// The path to the documents directory.
System::String dataDir = GetDataPath();

// Create an instance of Presentation class
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// Obtain a slide's reference by its index
auto sld = presentation->get_Slides()->idx_get(0);

// Access the TextFrame
auto tf1 = (System::DynamicCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Access the Paragraph
auto para = tf1->get_Paragraphs()->idx_get(0);

// Set properties of Paragraph
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// Save Presentation
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **Set AutofitType Property of Text Frame**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for C++ allows developers to set AutofitType property of any text frame. AutofitType could be set to Normal or Shape. If set to Normal then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to shape, then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

1. Create an instance of Presentation class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the TextFrame.
5. Set the AutofitType of the TextFrame.
6. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}


## **Set Anchor of TextFrame**
Aspose.Slides for C++ allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. TextAnchorType could be set to Top, Center, Bottom, Justified or Distributed. To set Anchor of any TextFrame, please follow the steps below:

1. Create an instance of `Presentation` class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the TextFrame.
5. Set TextAnchorType of the TextFrame.
6. Save file to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}


## **Set Custom Rotation Angle for TextFrame**
Aspose.Slides for C++ now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new property RotationAngle has been added to IChartTextBlockFormat and ITextFrameFormat interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle property, Please follow the steps below:

1. Create an instance of Presentation class.
2. Add a chart on slide.
3. Set RotationAngle property.
4. Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}