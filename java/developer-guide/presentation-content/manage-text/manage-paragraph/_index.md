---
title: Manage Paragraph
type: docs
weight: 30
url: /java/manage-paragraph/
---


## **Create TextFrame with Multiple Paragraphs and Portions**
{{% alert color="primary" %}} 

An [ITextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITextFrame) 
object can have one or more **Paragraphs** (every paragraph is created through a carriage return), 
that is a collection of 
[IParagraph](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IParagraph) objects. 
Furthermore, an 
[IParagraph](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IParagraph) object 
can have one or more **Portions** (a collection of 
[IPortion](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPortion) objects. 
An [IPortion](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPortion) object 
manages text and its formatting properties. So, it means that 
[IParagraph](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IParagraph) object 
has the capacity to handle text with different formatting properties through its underlying 
[IPortion](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPortion) objects.

{{% /alert %}} 

Please follow the steps below to add TextFrame having 3 paragraphs and 3 portions for each paragraph using Aspose.Slides for Java.

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add an [IAutoShape](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IAutoShape) of Rectangle type to the slide.
1. Access the [ITextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITextFrame) associated with the IAutoShape.
1. Create two [IParagraph](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IParagraph) objects and add it to the **IParagraphs** collection of the [ITextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITextFrame).
1. Create three [IPortion](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPortion) objects for each new [IParagraph](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IParagraph) (two Portion objects for default Paragraph) and add each IPortion object to the IPortions collection of each IParagraph.
1. Set some text for each Portion.
1. Apply the desired formatting features to each Portion using different formatting properties exposed by [IPortion](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IPortion) object.
1. Save the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingMultipleParagraphsHavingMultiplePortions-ManagingMultipleParagraphsHavingMultiplePortions.java" >}}

|![todo:image_alt_text](http://i.imgur.com/lTa19nC.png)|
| :- |
|**Figure: Text with different portions in paragraphs**|


## **Edit Paragraph Indent**
{{% alert color="primary" %}} 

This topic will illustrate that how we can manage paragraph indent.

{{% /alert %}} 

Please follow the steps below to manage the paragraph indent using Aspose.Slides for Java:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with three Paragraphs in the Rectangle.
1. Hide the Lines of the Rectangle.
1. Set indent of each Paragraph using its BulletOffset property.
1. Write the modified presentation as a PPT file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingParagraphIndent-ManagingParagraphIndent.java" >}}


Slide created through the above code snippet with indented paragraphs is shown below:

|![todo:image_alt_text](http://i.imgur.com/zvaHBUg.png)|
| :- |
## **Edit Paragraph Line Spacing**
{{% alert color="primary" %}} 

Aspose.Slides for Java lets developers to set the properties of [ParagraphFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/ParagraphFormat) to deal with line spacing of the paragraph. The properties **SpaceAfter**, **SpaceBefore** and **SpaceWithin** could be set for different line spacing. This article explains how to set these properties of [ParagraphFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/ParagraphFormat).

{{% /alert %}} 

Aspose.Slides for Java provides an API for setting properties of [ParagraphFormat](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/ParagraphFormat):

1. Load a [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) with an AutoShape having some text in it.
1. Obtain a slide's reference by its index.
1. Access the TextFrame.
1. Access the Paragraph.
1. Set properties of Paragraph.
1. Save the presentation to disk.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ManagingLineSpacingOfTheParagraph-ManagingLineSpacingOfTheParagraph.java" >}}

## **Edit Paragraph Alignment**
{{% alert color="primary" %}} 

Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for Java supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide.

{{% /alert %}} 

Please follow the steps below to align text paragraphs using Aspose.Slides for Java:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Access the Placeholder shapes present in the slide and typecast them as an AutoShape.
1. Get the Paragraph (that needs to be aligned) from the TextFrame exposed by AutoShape.
1. Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
1. Save the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-TextNew-ManagingParagraphsAlignment-.java" >}}

|![todo:image_alt_text](http://i.imgur.com/kLO54sg.jpg)|
| :- |
|**Figure: Paragraph alignment before executing the code snippet**|
The above code snippet aligns the text paragraph to the center as shown below:

|![todo:image_alt_text](http://i.imgur.com/J0zH959.png)|
| :- |
|**Figure: Centrally aligned paragraph**|

## **Edit Paragraph Run Properties**
This page will illustrate that how we can manage end paragraph run properties. We will see how developers can use this feature of Aspose.Slides for Java. Please follow the steps below to manage the End paragraph Run Properties using Aspose.Slides for Java:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with two Paragraphs in the Rectangle.
1. Set Font Height and Font type of paragraphs.
1. Set End properties of paragraphs.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-EndParaGraph-EndParaGraph.java" >}}

## **Import HTML Text to Paragraph**
1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Access the desired slide in slide collection using the [ISlide](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlide) object.
1. Add an autoshape to the selected slide.
1. Add and access the [ITextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITextFrame) of the added shape.
1. Remove the default paragraph in the [ITextFrame](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ITextFrame).
1. Read the source HTML file in a TextReader.
1. Create the first paragraph instance using the [Paragraph](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Paragraph) class.
1. Add the HTML file content in the read TextReader to the TextFrame's ParagraphCollection.
1. Save the presentation.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ImportingHTMLTextInParagraphs-ImportingHTMLTextInParagraphs.java" >}}


The above code snippets adds HTML text to paragraphs as shown in the screenshot.

|![todo:image_alt_text](http://i.imgur.com/1aDOu7J.png)|
| :- |
|**Figure: HTML text added to paragraphs**|
## **Export Paragraph Text to HTML**
Please follow the steps below to see how to export the paragraph text to HTML using Aspose.Slides for Java:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the desired presentation.
1. Access the desired slide into the slide collection using [ISlide](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/ISlide) object.
1. Access the desired shape for which text need to be exported to HTML.
1. Access the TextFrame of the accessed shape.
1. Create an instance of StreamWriter and add the new HTML file.
1. Export the desired number of paragraphs data by providing starting index to the StreamWriter.

The implementation of the above steps is given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Text-ExportingParagraphsTextToHTML-ExportingParagraphsTextToHTML.java" >}}


The above code snippet generates the HTML file from paragraph text as shown below:

|![todo:image_alt_text](http://i.imgur.com/40s2wL4.png)|
| :- |
|**Figure: HTML generated from paragraph text**|

