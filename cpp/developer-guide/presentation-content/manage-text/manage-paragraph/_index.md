---
title: Manage Paragraph
type: docs
weight: 30
url: /cpp/manage-paragraph/
---



## **Multiple Paragraphs having Multiple Portions**
An ITextFame object can have one or more Paragraphs (every paragraph is created through a carriage return), that is a collection of IParagraph objects. Furthermore, an IParagraph object can have one or more Portions (a collection of IPortion objects. An IPortion object manages text and its formatting properties. So, it means that IParagraph object has the capacity to handle text with different formatting properties through its underlying IPortion objects.
Please follow the steps below to add TextFrame having 3 paragraphs and 3 portions for each paragraph using Aspose.Slides for C++ :

- Create an instance of [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class.
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


## **Paragraph Bullets in PPTX**
This topic is also the part of the topic series of managing text paragraphs. This page will illustrate that how we can manage paragraph bullets. Bullets are more useful where the something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see that how developers can use this small yet powerful feature of Aspose.Slides for C++. Please follow the steps below to manage the paragraph bullets using Aspose.Slides for C++:

- Create an instance of `Presentation` class.
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

## **Paragraph Picture Bullets in PPTX**
This topic is also the part of the topic series of managing text in paragraphs. This page will illustrate that how we can manage paragraph picture bullets. Picture bullets are more useful where the something is to be described in steps. Moreover, text looks well organized with the use of bullets. Bulleted paragraphs are always easier to read and understand. We will see that how developers can use this small yet powerful feature of Aspose.Slides for C++. Please follow the steps below to manage the paragraph picture bullets using Aspose.Slides for C++:

- Create an instance of `Presentation` class.
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
## **Multilevel Bullets**
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
## **Paragraph with Custom Numbered List**
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


## **Get Effects by TextBox Paragraphs**
Aspose.Slides for C++ provides support for getting all animation effects applied to paragraphs of text frame (shape). Below is the sample code given.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetEffectsByTextParagraph-GetEffectsByTextParagraph.cpp" >}}



## **Edit Paragraph Indent**
This page will illustrate that how we can manage paragraph indent. We will see how developers can use this feature of Aspose.Slides for C++. Please follow the steps below to manage the paragraph indent using Aspose.Slides for C++:

1. Create an instance of `Presentation` class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with three Paragraphs in the Rectangle.
1. Hide the Lines of the Rectangle.
1. Set indent of each Paragraph using its BulletOffset property.
1. Write the modified presentation as a PPT file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}


## **Edit Paragraph Line Spacing**
Aspose.Slides for C++ lets developers to set the properties of ParagraphFormat to deal with line spacing of the paragraph. The properties SpaceAfter, SpaceBefore and SpaceWithin could be set for different line spacing. This article explains how to set these properties of ParagraphFormat. Aspose.Slides for C++ provides a simple API for setting properties of ParagraphFormat:

- Load a presentation with an AutoShape having some text in it.
- Obtain a slide's reference by its index.
- Access the TextFrame.
- Access the Paragraph.
- Set properties of Paragraph.
- Save the presentation to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-LineSpacing-LineSpacing.cpp" >}}


## **Edit Paragraph Run Properties**
This page will illustrate that how we can manage end paragraph run properties. We will see how developers can use this feature of Aspose.Slides for C++. Please follow the steps below to manage the End paragraph Run Properties using Aspose.Slides for C++:

1. Create an instance of `Presentation` class.
1. Obtain the reference of a slide by using its Position.
1. Add a Rectangle shape in the slide.
1. Add a TextFrame with two Paragraphs in the Rectangle.
1. Set Font Height and Font type of paragraphs.
1. Set End properties of paragraphs.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-EndParaGraphProperties-EndParaGraphProperties.cpp" >}}




## **Import HTML Text in Paragraph**
This topic is also part of a series of topics about managing text paragraphs. Aspose.Slides for C++ has enhanced support for adding HTML text or saving paragraphs text to HTML. This article shows how to manage paragraphs to use HTML data and shows how developers can use this small yet powerful feature. To manage paragraph bullets using Aspose.Slides for C++:

- Create an instance of the `Presentation` class.
- Access the desired slide in slide collection using the ISlide object.
- Add an autoshape to the selected slide.
- Add and access the ITextFrame of the added shape.
- Remove the default paragraph in the ITextFrame.
- Read the source HTML file in a TextReader.
- Create the first paragraph instance using the Paragraph class.
- Add the HTML file content in the read TextReader to the TextFrame's ParagraphCollection.
- Save the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ImportingHTMLText-ImportingHTMLText.cpp" >}}

## **Export Paragraphs Text to HTML**
Please follow the steps below to see how to export the paragraph text to HTML using Aspose.Slides for C++:

- Create an instance of `Presentation` class and load the desired presentation.
- Access the desired slide into the slide collection using ISlide object.
- Access the desired shape for which text need to be exported to HTML.
- Access the TextFrame of the accessed shape.
- Create an instance of StreamWriter and add the new HTML file.
- Export the desired number of paragraphs data by providing starting index to the StreamWriter.
  The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExportingHTMLText-ExportingHTMLText.cpp" >}}

