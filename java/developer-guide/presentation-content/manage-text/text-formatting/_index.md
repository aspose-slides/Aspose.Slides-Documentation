---
title: Text Formatting
type: docs
weight: 40
url: /java/text-formatting/
---


## **Highlight Text**
New highlightText method has been added to ITextFrame interface and TextFrame class.

It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-HighlightText-HighlightText.java" >}}

## **Highlight Text using Regular Expression**
 New highlightRegex method has been added to ITextFrame interface and TextFrame class.

It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-HighlightTextUsingRegx-HighlightTextUsingRegx.java" >}}

## **Text Transparency**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides for Java. In order to set the transparency to text. Please follow the steps below:

- Create an instance of Presentation class.
- Get reference of a slide.
- Set shadow color
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.java" >}}

## **Text Autofit**
Aspose.Slides for Java allows developers to set **AutofitType** property of any text frame. **AutofitType** could be set to **Normal** or **Shape**. If set to **Normal** then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If **AutofitType** is set to **Shape**, then shape will be modified such that only required text is contained in it. To set the **AutofitType** property of a text frame, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the first slide.
1. Add any shape to the slide.
1. Access the TextFrame.
1. Set the **AutofitType** of the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-SetTheAutofitTypePropertyOfTextFrame-SetTheAutofitTypePropertyOfTextFrame.java" >}}

## **Rotate Text**
Aspose.Slides for Java allows developers to rotate the text. Text could be set to appear as **Horizontal**, **Vertical**, **Vertical270**, **WordArtVertical**, **EastAsianVertical**, **MongolianVertical** or **WordArtVerticalRightToLeft**. To rotate the text of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the first slide.
1. Add any Shape to the slide.
1. Access the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Rotate the text.
1. Save file to disk

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-RotatingTheText-RotatingTheText.java" >}}

## **Text Rotation Angle**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports Setting custom rotation angle for TextFrame. In this topic, we will see with example how to use the **setRotationAngle** method in Aspose.Slides.

{{% /alert %}} 

The new method **setRotationAngle** has been added to [IChartTextBlockFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IChartTextBlockFormat) and [ITextFrameFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITextFrameFormat) interfaces, allows to set the custom rotation angle for TextFrame. In order to set the RotationAngle, Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Add a chart on slide.
1. Set RotationAngle.
1. Write the presentation as a PPTX file.

In the example given below, we have set the RotationAngle.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-SettingCustomRotationAngleForTextframe-SettingCustomRotationAngleForTextframe.java" >}}

## **Set Anchor to Text**
Aspose.Slides for Java allows developers to set Anchor of any TextFrame. [TextAnchorType](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/TextAnchorType) specifies that where is that text placed in the shape. [TextAnchorType](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/TextAnchorType) could be set to **Top**, **Center**, **Bottom**, **Justified** or **Distributed**. To set Anchor of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the first slide.
1. Add any shape to the slide.
1. Access the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Set **TextAnchorType** of the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-SetTheAnchorOfTextFrame-SetTheAnchorOfTextFrame.java" >}}

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
