---
title: Extract Text from Presentations
type: docs
weight: 60
url: /cpp/extracting-text-from-the-presentation/
keywords:
- extract text
- retrieve text
- slide
- text box
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn how to extract text from slides or entire presentations in Aspose.Slides for C++ and process content from PPT, PPTX and ODP programmatically."
---

{{% alert color="primary" %}} 

It's not uncommon that developers need to extract the text from a presentation. To do so, you need to extract text from all the shapes on all the slides in a presentation. This article explains how to extract text from Microsoft PowerPoint PPTX presentations using Aspose.Slides. Text can be extracted in following ways:

[Extracting text from one slide](/slides/cpp/extracting-text-from-the-presentation/)
[Extracting text using GetAllTextBoxes method](/slides/cpp/extracting-text-from-the-presentation/)
[Categorized and fast extraction of text](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **Extracting Text from a Slide**
Aspose.Slides for C++ provides the Aspose.Slides.Util namespace which includes the PresentationScanner class. This class exposes a number of overloaded static methods for extracting the entire text from a presentation or slide. To extract the text from a slide in a PPTX presentation, use the [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextboxes/) overloaded static method exposed by the PresentationScanner class. This method accepts the Slide object as a parameter.
Upon execution, the Slide method scans the entire text from the slide passed as parameter and returns an array of TextFrame objects. This means that any text formatting associated with the text is available. The following piece of code extracts all the text on the first slide of the presentation:

**C#**

``` cpp

 //Instatiate PresentationEx class that represents a PPTX file

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//Get an Array of TextFrameEx objects from the first slide

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//Loop through the Array of TextFrames

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //Loop through paragraphs in current TextFrame

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //Loop through portions in the current Paragraph

        foreach (Portion port in para.Portions)

        {

            //Display text in the current portion

            Console.WriteLine(port.Text);

            //Display font height of the text

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Display font name of the text

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```


## **Extracting Text from the Whole Presentation**
To scan the text from the whole presentation, use the [GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/) static method exposed by the PresentationScanner class. It takes two parameters:

1. First, a Presentation object that represents the PPTX presentation the text is being extracted from.
1. Second, a Boolean value determining whether the master slide is to be included when the text is scanned from the presentation.
   The method returns an array of TextFrame objects, complete with text formatting information. The code below scans the text and formatting information from a presentation, including the master slides.

**C#**

``` cpp

 //Instatiate Presentation class that represents a PPTX file

Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//Get an Array of ITextFrame objects from all slides in the PPTX

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//Loop through the Array of TextFrames

for (int i = 0; i < textFramesPPTX.Length; i++)

    //Loop through paragraphs in current ITextFrame

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //Loop through portions in the current IParagraph

        foreach (IPortion port in para.Portions)

        {

            //Display text in the current portion

            Console.WriteLine(port.Text);

            //Display font height of the text

            Console.WriteLine(port.PortionFormat.FontHeight);

            //Display font name of the text

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }


```


## **Categorized and fast extraction of text**
The new static method GetPresentationText has been added to Presentation class. There are two overloads for this method:

``` cpp

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

``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```
