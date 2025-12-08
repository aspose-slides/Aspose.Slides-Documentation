---
title: Advanced Text Extraction from Presentations in .NET
linktitle: Extract Text
type: docs
weight: 90
url: /net/extract-text-from-presentation/
keywords:
- extract text
- extract text from slide
- extract text from presentation
- extract text from PowerPoint
- extract text from OpenDocument
- extract text from PPT
- extract text from PPTX
- extract text from ODP
- retrieve text
- retrieve text from slide
- retrieve text from presentation
- retrieve text from PowerPoint
- retrieve text from OpenDocument
- retrieve text from PPT
- retrieve text from PPTX
- retrieve text from ODP
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Quickly extract text from PowerPoint and OpenDocument presentations using Aspose.Slides for .NET. Follow our simple, step-by-step guide to save time."
---

## **Overview**

Extracting text from presentations is a common yet essential task for developers working with slide content. Whether you're dealing with Microsoft PowerPoint files in PPT or PPTX format, or OpenDocument presentations (ODP), accessing and retrieving textual data can be critical for analysis, automation, indexing, or content migration purposes.

This article provides a comprehensive guide on how to efficiently extract text from various presentation formats, including PPT, PPTX, and ODP, using Aspose.Slides for .NET. You'll learn how to systematically iterate through presentation elements to accurately retrieve the text content you need.

## **Extract Text from a Slide**

Aspose.Slides for .NET provides the [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) namespace, which includes the [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) class. This class exposes several overloaded static methods for extracting all text from a presentation or slide. To extract text from a slide in a presentation, use the [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/) method. This method accepts an object of type [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) as a parameter. When executed, the method scans the entire slide for text and returns an array of objects of type [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), preserving any text formatting.

The following code snippet extracts all the text from the first slide of the presentation:

```cs
int slideIndex = 0;

// Instatiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
using Presentation presentation = new Presentation("demo.pptx");

// Get a reference to the slide.
ISlide slide = presentation.Slides[slideIndex];

// Get an array of text frames from the slide.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// Loop through the array of the text frames.
for (int i = 0; i < textFrames.Length; i++)
{
    // Loop through paragraphs in the current text frame.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Loop through text portions in the current paragraph.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Display text in the current text portion.
            Console.WriteLine(portion.Text);

            // Display the font height of the text.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Display the font name of the text.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```

## **Extract Text from a Presentation**

To scan text from the entire presentation, use the [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) static method exposed by the [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) class. It accepts two parameters:

1. First, a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object representing a PowerPoint or OpenDocument presentation from which text will be extracted.
1. Second, a `Boolean` value indicating whether the master slides should be included when scanning text from the presentation.

The method returns an array of objects of type [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), including text formatting information. The code below scans the text and formatting details from a presentation, including the master slides.

```cs
// Instatiate the Presentation class that represents a presentation file (PPT, PPTX, ODP, etc.).
using Presentation presentation = new Presentation("demo.pptx");

// Get an array of text frames from all slides in the presentation.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// Loop through the array of the text frames.
for (int i = 0; i < textFrames.Length; i++)
{
    // Loop through paragraphs in the current text frame.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // Loop through text portions in the current paragraph.
        foreach (IPortion portion in paragraph.Portions)
        {
            // Display text in the current text portion.
            Console.WriteLine(portion.Text);

            // Display the font height of the text.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // Display the font name of the text.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```

## **Categorized and Fast Text Extraction**

The [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) class also provides static methods for extracting all text from presentations:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode for organizing the text extraction result and can be set to the following values:
- `Unarranged` - The raw text without regard to its position on the slide.
- `Arranged` - The text is arranged in the same order as on the slide.

The unarranged mode can be used when speed is critical; it's faster than the arranged mode.

[IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) represents the raw text extracted from the presentation. It contains the [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) property from the [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) namespace, which returns an array of objects of type [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/). Each object represents the text on the corresponding slide. The object of type [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) has the following properties:

- `Text` - The text within the slide's shapes.
- `MasterText` - The text within the master slide's shapes associated with this slide.
- `LayoutText` - The text within the layout slide's shapes associated with this slide.
- `NotesText` - The text within the notes slide's shapes associated with this slide.
- `CommentsText` - The text within comments associated with this slide.

```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```

## **FAQ**

**How fast does Aspose.Slides process large presentations during text extraction?**

Aspose.Slides is optimized for high performance and efficiently processes even large presentations, making it suitable for real-time or bulk processing scenarios.

**Can Aspose.Slides extract text from tables and charts within presentations?**

Yes, Aspose.Slides fully supports extracting text from tables, charts, and other complex slide elements, allowing you to access and analyze all textual content easily.

**Do I need a special Aspose.Slides license to extract text from presentations?**

You can extract text using the free trial version of Aspose.Slides, although it will have certain limitations, such as processing only a limited number of slides. For unrestricted use and to handle larger presentations, purchasing a full license is recommended.
