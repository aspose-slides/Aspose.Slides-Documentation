---
title: Extract Text from Presentation
type: docs
weight: 80
url: /net/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

It's not uncommon that developers need to extract the text from a presentation. To do so, you need to extract text from all the shapes on all the slides in a presentation. This article explains how to extract text from Microsoft PowerPoint PPTX presentations using Aspose.Slides. Text can be extracted in following ways:

- [Extracting text from one slide](/slides/net/extracting-text-from-the-presentation/)
- [Extracting text using GetAllTextBoxes method](/slides/net/extracting-text-from-the-presentation/)
- [Categorized and fast extraction of text](/slides/net/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extract Text from Slide**
Aspose.Slides for .NET provides the Aspose.Slides.Util namespace which includes the SlideUtil class. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation, 
use the [GetAllTextBoxes](https://apireference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextboxes) overloaded static method exposed by the SlideUtil class. This method accepts the Slide object as a parameter.
Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of TextFrame objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Text-ExtractTextFromSlide-ExtractTextFromSlide.cs" >}}




## **Extract Text from Presentation**
To scan the text from the whole presentation, use the
 [GetAllTextFrames](https://apireference.aspose.com/slides/net/aspose.slides.util/slideutil/methods/getalltextframes) static method exposed by the SlideUtil class. It takes two parameters:

1. First, a Presentation object that represents the PPTX presentation the text is being extracted from.
1. Second, a Boolean value determining whether the master slide is to be included when the text is scanned from the presentation.
   The method returns an array of TextFrame objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Text-ExtractTextFromPresentation-ExtractTextFromPresentation.cs" >}}




## **Categorized and Fast Text Extraction**
The new static method GetPresentationText has been added to Presentation class. There are two overloads for this method:

``` csharp
PresentationText GetPresentationText(Stream stream)
PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
``` 

The ExtractionMode enum argument indicates the mode to organize the output of text result and can be set to the following values:
Unarranged - The raw text with no respect to position on the slide
Arranged - The text is positioned in the same order as on the slide

Unarranged mode can be used when speed is critical, it's faster than Arranged mode.

PresentationText represents the raw text extracted from the presentation. It contains a SlidesText property from Aspose.Slides.Util namespace which returns an array of ISlideText objects. Every object represent the text on the corresponding slide. ISlideText object have the following properties:

ISlideText.Text - The text on the slide's shapes
ISlideText.MasterText - The text on the master page's shapes for this slide
ISlideText.LayoutText - The text on the layout page's shapes for this slide
ISlideText.NotesText - The text on the notes page's shapes for this slide

There is also a SlideText class which implements the ISlideText interface.

The new API can be used like this:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Text-ExtractText-ExtractText.cs" >}}




