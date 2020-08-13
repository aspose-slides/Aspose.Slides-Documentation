---
title: Text Formatting
type: docs
weight: 40
url: /java/text-formatting/
---

## **Applying Shadow Effects on Slide Text**
{{% alert color="primary" %}} 

Aspose.Slides for Java provides [IOuterShadow](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IOuterShadow) and [IInnerShadow](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IInnerShadow) classes in order to apply shadow effects on the text carried by [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame). These classes are available in the **Aspose.Slides.Effects** namespace and provides a number of properties for handling the shadow effects.

{{% /alert %}} 
### **Applying Outer Shadow Effects**
Please follow the steps below to apply shadow effects on the text in a PPTX presentation using Aspose.Slides for Java.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Rectangle type to the slide.
1. Access the TextFrame associated with the AutoShape.
1. Set the FillType of the AutoShape to NoFill.
1. Instantiate [OuterShadow](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/OuterShadow) class.
1. Set the BlurRadius of the shadow.
1. Set the Direction of the shadow.
1. Set the Distance of the shadow.
1. Set the RectanglelAlign to TopLeft.
1. Set the PresetColor of the shadow to Black.
1. Write the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ApplyingOuterShadowEffects-ApplyingOuterShadowEffects.java" >}}
### **Applying Inner Shadow**
In order to apply inner shadow. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Get reference of a slide.
1. Add an AutoShape of Rectangle type.
1. Add inner shadow and set all necessary parameters.
1. Write the presentation as a PPTX file.

In the example given below, we have added a inner shadow.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ApplyingInnerShadow-ApplyingInnerShadow.java" >}}
### **Set Transparency Property For Text**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides for Java. In order to set the transparency to text. Please follow the steps below:

- Create an instance of Presentation class.
- Get reference of a slide.
- Set shadow color
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.java" >}}


## **Managing Text Autofit and Rotation**
{{% alert color="primary" %}} 

In this topic, we will explore the different formatting properties of text frame.

{{% /alert %}} 
### **Setting the AutofitType property of text frame**
Aspose.Slides for Java allows developers to set **AutofitType** property of any text frame. **AutofitType** could be set to **Normal** or **Shape**. If set to **Normal** then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If **AutofitType** is set to **Shape**, then shape will be modified such that only required text is contained in it. To set the **AutofitType** property of a text frame, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the first slide.
1. Add any shape to the slide.
1. Access the TextFrame.
1. Set the **AutofitType** of the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-SettingTheAutofitTypePropertyOfTextFrame-SettingTheAutofitTypePropertyOfTextFrame.java" >}}
### **Setting the anchor of TextFrame**
Aspose.Slides for Java allows developers to set Anchor of any TextFrame. [TextAnchorType](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/TextAnchorType) specifies that where is that text placed in the shape. [TextAnchorType](http://www.aspose.com/api/java/slides/com.aspose.slides/constants/TextAnchorType) could be set to **Top**, **Center**, **Bottom**, **Justified** or **Distributed**. To set Anchor of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the first slide.
1. Add any shape to the slide.
1. Access the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Set **TextAnchorType** of the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Save file to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-SettingTheAnchorOfTextFrame-SettingTheAnchorOfTextFrame.java" >}}
### **Rotating the text**
Aspose.Slides for Java allows developers to rotate the text. Text could be set to appear as **Horizontal**, **Vertical**, **Vertical270**, **WordArtVertical**, **EastAsianVertical**, **MongolianVertical** or **WordArtVerticalRightToLeft**. To rotate the text of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the first slide.
1. Add any Shape to the slide.
1. Access the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Rotate the text.
1. Save file to disk

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-RotatingTheText-RotatingTheText.java" >}}
## **Managing WordArt Properties**
{{% alert color="primary" %}} 

Aspose.Slides for Java could be used to apply WordArt Effects on Text. Every WordArt effect has a scheme, for example Accent1, Accent3. In this topic, we will see with examples for how to work with WordArt in Aspose.Slides.

{{% /alert %}} 
### **Applying Outer Shadow**
In order to apply the scheme of any WordArt. Please follow the steps below:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Get reference of a slide.
1. Add an AutoShape of Rectangle type.
1. Enable InnerShadowEffect.
1. Set all necessary parameters.
1. Set ColorType as Scheme.
1. Set Scheme Color.
1. Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingWordArtProperties-ManagingWordArtProperties.java" >}}
## **Managing Super Script and Sub Script Text**
You can add super script and sub script text inside any paragraph portion. For adding Superscript or Subscript text in Aspose.Slides text frame one must use **Escapement** properties of PortionFormat class.

This property returns or sets the superscript or subscript text (value from -100% (subscript) to 100% (superscript). For example :

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type to the slide.
- Access the ITextFrame associated with the IAutoShape.
- Clear existing Paragraphs
- Create a new paragraph object for holding super script text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for portion between 0 to 100 for adding super script. (0 mean no super script)
- Set some text for Portion and then add that in portion collection of paragraph.
- Create a new paragraph object for holding sub script text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for portion between 0 to -100 for adding super script. (0 mean no sub script)
- Set some text for Portion and then add that in portion collection of paragraph.
- Save the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-AddingSuperscriptAndSubscriptText-AddingSuperscriptAndSubscriptText.java" >}}
## **Setting custom rotation angle for TextFrame**
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
## **Support to get effects by text-box paragraphs**
Aspose.Slides for Java provides support for getting all animation effects applied to paragraphs of text frame (shape). Below is the sample code given.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-EffectTextBoxParagraph-EffectTextBoxParagraph.java" >}}
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

