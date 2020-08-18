---
title: Extracting Text from the Presentation
type: docs
weight: 50
url: /java/extracting-text-from-the-presentation/
---

{{% alert color="primary" %}} 

It's not uncommon that developers need to extract the text from a presentation. To do so, you need to extract text from all the shapes on all the slides in a presentation. This article explains how to extract text from Microsoft PowerPoint PPTX presentations using Aspose.Slides. Text can be extracted in following ways:

[Extracting text from one slide](/slides/java/extracting-text-from-the-presentation/)
[Extracting text using GetAllTextBoxes method](/slides/java/extracting-text-from-the-presentation/)
[Categorized and fast extraction of text](/slides/java/extracting-text-from-the-presentation/)

{{% /alert %}} 
#### **Extracting Text from a Slide**
Aspose.Slides for Java provides the SlidesUtil class to extract the text from a slide in presentation. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation, use the GetAllTextBoxes overloaded static method exposed by the PresentationScanner class. This method accepts the Slide object as a parameter.
Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of TextFrame objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-ExtractTextFromSlide-ExtractTextFromSlide.java" >}}


#### **Extracting Text from the Whole Presentation**
To scan the text from the whole presentation, use the **GetAllTextFrames** static method exposed by the PresentationScanner class. It takes two parameters:

1. First, a Presentation object that represents the PPTX presentation the text is being extracted from.
1. Second, a Boolean value determining whether the master slide is to be included when the text is scanned from the presentation.
   The method returns an array of TextFrame objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-ExtractTextFromPresentation-ExtractTextFromPresentation.java" >}}


#### **Categorized and fast extraction of text**
The new static method getPresentationText has been added to Presentation class.
PresentationText getPresentationText(InputStream stream, int mode)

The ExtractionMode enum argument indicates the mode to organize the output of text result and can be set to the following values:
Unarranged - The raw text with no respect to position on the slide
Arranged - The text is positioned in the same order as on the slide
Unarranged mode can be used when speed is critical, it's faster than Arranged mode.

PresentationText represents the raw text extracted from the presentation. It contains a getSlidesText() property which returns an array of ISlideText objects. Every object represent the text on the corresponding slide. ISlideText object have the following properties:

ISlideText.getText() - The text on the slide's shapes
ISlideText.getMasterText() - The text on the master page's shapes for this slide
ISlideText.getLayoutText() - The text on the layout page's shapes for this slide
ISlideText.getNotesText() - The text on the notes page's shapes for this slide

There's also a SlideText class which implements the ISlideText interface.

The new API can be used like this:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-ExtractText-ExtractText.java" >}}




