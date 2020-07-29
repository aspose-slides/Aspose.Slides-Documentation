---
title: Manipulating Text
type: docs
weight: 40
url: /net/manipulating-text/
---

## **Manipulating Text**
### **Importing HTML Text in Paragraphs**
This topic is also part of a series of topics about managing text paragraphs. Aspose.Slides for .NET has enhanced support for adding HTML text or saving paragraphs text to HTML. This article shows how to manage paragraphs to use HTML data and shows how developers can use this small yet powerful feature. To manage paragraph bullets using Aspose.Slides for .NET:

- Create an instance of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Access the desired slide in slide collection using the ISlide object.
- Add an autoshape to the selected slide.
- Add and access the ITextFrame of the added shape.
- Remove the default paragraph in the ITextFrame.
- Read the source HTML file in a TextReader.
- Create the first paragraph instance using the Paragraph class.
- Add the HTML file content in the read TextReader to the TextFrame's ParagraphCollection.
- Save the presentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ImportingHTMLText-ImportingHTMLText.cs" >}}
### **Exporting Paragraphs Text to HTML**
Please follow the steps below to see how to export the paragraph text to HTML using Aspose.Slides for .NET:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class and load the desired presentation.
- Access the desired slide into the slide collection using ISlide object.
- Access the desired shape for which text need to be exported to HTML.
- Access the TextFrame of the accessed shape.
- Create an instance of StreamWriter and add the new HTML file.
- Export the desired number of paragraphs data by providing starting index to the StreamWriter.
  The implementation of the above steps is given below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-ExportingHTMLText-ExportingHTMLText.cs" >}}
### **Tabs and EffectiveTabs in Presentation**
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs)
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Helloworld!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".
### **Setting the AutofitType property of text frame**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for .NET allows developers to set AutofitType property of any text frame. AutofitType could be set to Normal or Shape. If set to Normal then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to shape, then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Access the first slide.
- Add any shape to the slide.
- Access the TextFrame.
- Set the AutofitType of the TextFrame.
- Save file to disk.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-SetAutofitOftextframe-SetAutofitOftextframe.cs" >}}
### **Setting the anchor of TextFrame**
Aspose.Slides for .NET allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. TextAnchorType could be set to Top, Center, Bottom, Justified or Distributed. To set Anchor of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Access the first slide.
- Add any shape to the slide.
- Access the TextFrame.
- Set TextAnchorType of the TextFrame.
- Save file to disk.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cs" >}}
### **Setting text Rotation**
Aspose.Slides for .NET allows developers to rotate the text. Text could be set to appear as Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical or WordArtVerticalRightToLeft. To rotate the text of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class.
- Access the first slide.
- Add any Shape to the slide.
- Access the TextFrame.
- Rotate the text.
- Save file to disk.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-RotatingText-RotatingText.cs" >}}
### **Setting custom rotation angle for textframe**
Aspose.Slides for .NET now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new property RotationAngle has been added to IChartTextBlockFormat and ITextFrameFormat interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle property, Please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class.
- Add a chart on slide.
- Set RotationAngle property.
- Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cs" >}}
### **Line Spacing of a paragraph**
Aspose.Slides for .NET lets developers to set the properties of ParagraphFormat to deal with line spacing of the paragraph. The properties SpaceAfter, SpaceBefore and SpaceWithin could be set for different line spacing. This article explains how to set these properties of ParagraphFormat. Aspose.Slides for .NET provides a simple API for setting properties of ParagraphFormat:

- Load a presentation with an AutoShape having some text in it.
- Obtain a slide's reference by its index.
- Access the TextFrame.
- Access the Paragraph.
- Set properties of Paragraph.
- Save the presentation to disk.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Text-LineSpacing-LineSpacing.cs" >}}
