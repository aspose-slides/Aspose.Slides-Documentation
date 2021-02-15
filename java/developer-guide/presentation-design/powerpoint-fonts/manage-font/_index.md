---
title: Manage Fonts
type: docs
weight: 10
url: /java/manage-fonts/
---

## **Manage Font Related Properties**
{{% alert color="primary" %}} 

Presentations usually contain both text and images. The text can be formatted in a various way, either to highlight specific sections and words or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Java to configure the font properties of paragraphs of text on slides.

{{% /alert %}} 

To manage font properties of a paragraph using Aspose.Slides for Java:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the [Placeholder](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Placeholder) shapes in the slide and typecast them to [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape).
1. Get the [Paragraph](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Paragraph) from the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame) exposed by [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape).
1. Justify the paragraph.
1. Access a [Paragraph](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Paragraph)'s text [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion).
1. Define the font using [FontData](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FontData) and set the **Font** of the text [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [FillFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/FillFormat) exposed by the [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) object.
1. Save the modified presentation to a PPTX file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides. The screenshots that follow show the input file and how the code snippets change it. The code changes the font, the color, and the font style.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: The text in the input file**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: The same text with updated formatting**|
{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingFontRelatedProperties-ManagingFontRelatedProperties.java" >}}



## **Set Text Font Properties**
{{% alert color="primary" %}} 

As mentioned in **Managing Font Related Properties**, a [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Java to create a textbox with some text and then define a particular font, and various other properties of the font family category.

{{% /alert %}} 

To create a textbox and set font properties of the text in it:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its index.
1. Add an [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape) of the type **Rectangle** to the slide.
1. Remove the fill style associated with the [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape).
1. Access the of the [AutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/AutoShape)'s [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Add some text to the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Access the [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) object associated with the [TextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/TextFrame).
1. Define the font to be used for the [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion).
1. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the [Portion](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Portion) object.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Text with some font properties set by Aspose.Slides for Java**|
{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingFontFamilyOfText-ManagingFontFamilyOfText.java" >}}




