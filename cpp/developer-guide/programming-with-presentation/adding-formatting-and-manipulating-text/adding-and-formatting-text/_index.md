---
title: Adding and Formatting Text
type: docs
weight: 10
url: /cpp/adding-and-formatting-text/
---

## **Replacing Text in a Placeholder**
Using Aspose.Slides for C++, developers can also find and modify a specific Placeholder present in a slide. In this topic, we are going to demonstrate with the help of an example that how the text contained inside a Placeholder can be replaced or modified using Aspose.Slides for C++. The following two steps will be used to modify text in Placeholder.

Step 1: Create a Slide Containing a Placeholder

First of all, create a presentation file with a slide containing a Placeholder. You can create this presentation either MS PowerPoint. This is just the demonstration of replacing text in a Placeholder, so, you can create this presentation by yourself. This presentation will be used in the next step and the text in its Placeholder will be replaced.

Step 2: Replace Text of the Placeholder

To replace the text of a Placeholder, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Iterate through the Shapes and find the Placeholder shapes.
- Typecast the Placeholder shape to AutoShape and change the text using the TextFrame associated with the AutoShape.
- Write the modified presentation as a PPTX file.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ReplacingText-ReplacingText.cpp" >}}
## **Set Prompt Text in a Placeholder**
As we know that Standard and pre-built layouts contain placeholders with default text like **Click to add a title** or **Click to add subtitle**. Using Aspose.Slides you can add prompt text manually by accessing the default placeholders.

The code snippet below shows how to use this feature:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddCustomPromptText-AddCustomPromptText.cpp" >}}
## **Creating a TextBox on Slide**
Using Aspose.Slides for C++, developers can create TextBox on a Slide in the Presentation. All you have to do is to add an AutoShape of Rectangle type and call the AddTextFrame method exposed by AutoShapeEX object. Please follow the steps below to create TextBox by using Aspose.Slides for C++ API:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of the first slide in the presentation which is created on the instantiation of Presentation.
- Add an IAutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added IAutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Finally, write the PPTX file using the Presentation object.

The implementation of above steps is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}


## **Add Column In TextBoxes**
Using Aspose.Slides for C++, developers can add column in text boxes on a Slide in the Presentation, property ColumnCount and ColumnSpacing has been added to ITextFrameFormat interface and TextFrameFormat class respectively. These properties specify the number of columns in the textbox and set an amount of spacing in points between columns.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColumnInTexBoxes-AddColumnInTexBoxes.cpp" >}}


## **Add Columns In Text Frames**
Using Aspose.Slides for C++, developers can add columns in text frames on a Slide in the Presentation. **ColumnCount** property has been added to **ITextFrameFormat** interface. This property specifies the number of columns in the text frame.

The implementation is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColumnsinTextFrame-AddColumnsinTextFrame.cpp" >}}
## **Change Language for Presentation and shape's Text**
- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Add some text to the TextFrame.
- Setting Language Id to text.
- Write the presentation as a PPTX file.

The implementation of the above steps is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}


## **Creating TextBox with Hyperlink**
In this topic, we will create a TextBox with a Hyperlink. You will have to instantiate IHyperlinkManager class and assign it to the desired portion of the TextFrame associated with the TextBox. Please follow the steps below to create a TextBox with Hyperlink by using Aspose.Slides for C++ API:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added AutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Instantiate the IHyperlinkManager class.
- Assign the IHyperlinkManager object to the HLinkClick property associated with the desired portion of the TextFrame.
- Finally, write the PPTX file using the Presentation object.

The implementation of the above steps is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxHyperlink-TextBoxHyperlink.cpp" >}}
## **Applying Shadow Effects on Slide Text**
Aspose.Slides for C++ provides IOuterShadow and InnerShadow classes in order to apply shadow effects on the text carried by TextFrame. These classes are available in the Aspose.Slides.Effects namespace and provides a number of properties for handling the shadow effects.
### **Applying Outer Shadow**
Please follow the steps below to apply shadow effects on the text in a PPTX presentation using Aspose.Slides for C++ :

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an AutoShape of Rectangle type to the slide.
- Access the TextFrame associated with the AutoShape.
- Set the FillType of the AutoShape to NoFill.
- Instantiate OuterShadow class
- Set the BlurRadius of the shadow.
- Set the Direction of the shadow
- Set the Distance of the shadow.
- Set the RectanglelAlign to TopLeft.
- Set the PresetColor of the shadow to Black.
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyOuterShadow-ApplyOuterShadow.cpp" >}}
### **Applying Outer Shadow Effects**
Aspose.Slides for C++ could be used to apply WordArt Effects on Text. Every WordArt effect has a scheme, for example Accent1, Accent3. In this topic, we will see with examples for how to work with WordArt in Aspose.Slides. In order to apply the scheme of any WordArt. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Get reference of a slide.
- Add an AutoShape of Rectangle type.
- Enable InnerShadowEffect.
- Set all necessary parameters.
- Set ColorType as Scheme.
- Set Scheme Color.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyOuterShadow-ApplyOuterShadow.cpp" >}}
### **Applying Inner Shadow**
In order to apply inner shadow. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Get reference of a slide.
- Add an AutoShape of Rectangle type.
- Add inner shadow and set all necessary parameters.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyInnerShadow-ApplyInnerShadow.cpp" >}}
### **Aligning Text Paragraphs**
Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for C++ supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for C++ :

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access the Placeholder shapes present in the slide and typecast them as an AutoShape.
- Get the Paragraph (that needs to be aligned) from the TextFrame exposed by AutoShape.
- Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}
### **Set Transparency Property for Text**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides. In order to set the transparency to text. Please follow the steps below:

- Create an instance of Presentation class.
- Get reference of a slide.
- Set shadow color
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **Managing a Paragraph's Font Properties**
Presentations usually contain both text and images. The text can be formatted in a various way, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for C++ to configure the font properties of paragraphs of text on slides. To manage the font properties of a paragraph using Aspose.Slides for C++ :

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
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
### **Managing Font Family of Text**
As mentioned in [Managing Font Related Properties](), a Portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for C++ to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

- Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
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

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}
### **Managing Multiple Paragraphs having Multiple Portions**
An ITextFame object can have one or more Paragraphs (every paragraph is created through a carriage return), that is a collection of IParagraph objects. Furthermore, an IParagraph object can have one or more Portions (a collection of IPortion objects. An IPortion object manages text and its formatting properties. So, it means that IParagraph object has the capacity to handle text with different formatting properties through its underlying IPortion objects.
Please follow the steps below to add TextFrame having 3 paragraphs and 3 portions for each paragraph using Aspose.Slides for C++ :

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type to the slide.
- Access the ITextFrame associated with the IAutoShape.
- Create two IParagraph objects and add it to the IParagraphs collection of the ITextFrame.
- Create three IPortion objects for each new IParagraph (two Portion objects for default Paragraph) and add each IPortion object to the IPortions collection of each IParagraph.
- Set some text for each Portion.
- Apply the desired formatting features to each Portion using different formatting properties exposed by IPortion object.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-MultipleParagraphs-MultipleParagraphs.cpp" >}}
### **Managing Super Script and Sub Script Text**
You can add super script and sub script text inside any paragraph portion. For adding Superscript or Subscript text in Aspose.Slides text frame one must use **Escapement** properties of PortionFormat class.

This property returns or sets the superscript or subscript text (value from -100% (subscript) to 100% (superscript). For example :

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Add an IAutoShape of Rectangle type to the slide.
- Access the ITextFrame associated with the IAutoShape.
- Clear existing Paragraphs
- Create a new paragraph object for holding super script text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for the portion between 0 to 100 for adding super script. (0 mean no super script)
- Set some text for Portion and then add that in portion collection of paragraph.
- Create a new paragraph object for holding sub script text and add it to the IParagraphs collection of the ITextFrame.
- Create a new portion object
- Set Escapement property for portion between 0 to -100 for adding super script. (0 mean no sub script)
- Set some text for Portion and then add that in portion collection of paragraph.
- Save the presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}
### **Managing Paragraph Bullets in PPTX**
This topic is also the part of the topic series of managing text paragraphs. This page will illustrate that how we can manage paragraph bullets. Bullets are more useful where the something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see that how developers can use this small yet powerful feature of Aspose.Slides for C++. Please follow the steps below to manage the paragraph bullets using Aspose.Slides for C++:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class.
- Set the bullet type of the paragraph.
- Set the bullet type to Symbol and the set the bullet character.
- Set the Paragraph Text.
- Set the Paragraph Indent to set the bullet.
- Set the Color of Bullet.
- Set the Height of Bullets.
- Add the created paragraph in TextFrame paragraph collection.
- Add the second paragraph and repeat the process given in steps 7 to 13.
- Save the presentation.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphBullets-ParagraphBullets.cpp" >}}
### **Managing Paragraph Picture Bullets in PPTX**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate that how we can manage paragraph picture bullets. Picture bullets are more useful where the something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see that how developers can use this small yet powerful feature of Aspose.Slides for C++. Please follow the steps below to manage the paragraph picture bullets using Aspose.Slides for C++:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class.
- Load Image from disc in IPPImage.
- Set the bullet type to Picture and the set the image.
- Set the Paragraph Text.
- Set the Paragraph Indent to set the bullet.
- Set the Color of Bullet.
- Set the Height of Bullets.
- Add the created paragraph in TextFrame paragraph collection.
- Add the second paragraph and repeat the process given in previous steps.
- Save the presentation.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ManageParagraphPictureBulletsInPPT-ManageParagraphPictureBulletsInPPT.cpp" >}}
### **Managing Multilevel Bullets**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate that how we can manage paragraphs with multilevel bullets. Please follow the steps below to manage the multilevel bullets using Aspose.Slides for C++:

- Create an instance of Presentation class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class and with depth set to 0.
- Create the second paragraph instance using Paragraph class and with depth set to 1.
- Create the third paragraph instance using Paragraph class and with depth set to 2.
- Create the fourth paragraph instance using Paragraph class and with depth set to 3.
- Add the created paragraphs in TextFrame paragraph collection.
- Save the presentation.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-MutilevelBullets-MutilevelBullets.cpp" >}}
### **Managing Paragraph with Custom Numbered List**
Aspose.Slides for C++ provides a simple API to manage paragraphs with custom numbers formatting. For this purpose, **NumberedBulletStartWith** property has been added to **IBulletFormat.** To add a custom number list in a paragraph, please follow the steps below:

- Create an instance of Presentation class.
- Access the desired slide in slide collection using ISlide object.
- Add an autoshape in selected slide.
- Access the TextFrame of the added shape.
- Remove the default paragraph in the TextFrame.
- Create the first paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 2
- Create the second paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 3
- Create the third paragraph instance using Paragraph class and set **NumberedBulletStartWith** to 7
- Add the created paragraphs in TextFrame paragraph collection.
- Save the presentation.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetCustomBulletsNumber-SetCustomBulletsNumber.cpp" >}}
### **Managing Paragraph Indent**
This page will illustrate that how we can manage paragraph indent. We will see how developers can use this feature of Aspose.Slides for C++. Please follow the steps below to manage the paragraph indent using Aspose.Slides for C++:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with three Paragraphs in the Rectangle.
1. Hide the Lines of the Rectangle.
1. Set indent of each Paragraph using its BulletOffset property.
1. Write the modified presentation as a PPT file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}
### **Implementing End Paragraph Run Properties for Paragraph**
This page will illustrate that how we can manage end paragraph run properties. We will see how developers can use this feature of Aspose.Slides for C++. Please follow the steps below to manage the End paragraph Run Properties using Aspose.Slides for C++:

1. Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with two Paragraphs in the Rectangle.
1. Set Font Height and Font type of paragraphs.
1. Set End properties of paragraphs.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-EndParaGraphProperties-EndParaGraphProperties.cpp" >}}


### **Highlight Text**
New HighlightText method has been added to ITextFrame and TextFrame classes. It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}
### **Highlight Text using Regular Expression**
New HighlightRegex method has been added to ITextFrame and TextFrame classes. It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}
## **Add Animation Effect on Paragraph**
The **AddEffect()** method has been added to the **Sequence** and **ISequence** classes. It allows to add a new animation effect for a single paragraph. The following example shows how to add animation effect for a single paragraph.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AnimationEffectInParagraph-AnimationEffectinParagraph.cpp" >}}
