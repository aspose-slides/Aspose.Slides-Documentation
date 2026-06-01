---
title: Advanced Text Extraction from Presentations in C++
linktitle: Extract Text
type: docs
weight: 90
url: /cpp/extract-text-from-presentation/
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
- C++
- Aspose.Slides
description: "Quickly extract text from PowerPoint and OpenDocument presentations using Aspose.Slides for C++. Follow our simple, step-by-step guide to save time."
---

## **Overview**

Extracting text from presentations is a common yet essential task for developers working with slide content. Whether you're dealing with Microsoft PowerPoint files in PPT or PPTX format, or OpenDocument presentations (ODP), accessing and retrieving textual data can be critical for analysis, automation, indexing, or content migration purposes.

This article provides a comprehensive guide on how to efficiently extract text from various presentation formats, including PPT, PPTX, and ODP, using Aspose.Slides for C++. You'll learn how to systematically iterate through presentation elements to accurately retrieve the text content you need.

## **Extract Text from a Slide**

Aspose.Slides for C++ provides the [Aspose.Slides.Util](https://reference.aspose.com/slides/cpp/aspose.slides.util/) namespace, which includes the [SlideUtil](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/) class. This class exposes several overloaded static methods for extracting all text from a presentation or slide. To extract text from a slide in a presentation, use the [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextboxes/) method. This method accepts an object of type [IBaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/) as a parameter. When executed, the method scans the entire slide for text and returns an array of objects of type [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), preserving any text formatting.

The following code snippet extracts all the text from the first slide of the presentation:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Extract Text from a Presentation**

To scan text from the entire presentation, use the [GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/) static method exposed by the [SlideUtil](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/) class. It accepts two parameters:

1. First, an [IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) object representing a PowerPoint or OpenDocument presentation from which text will be extracted.
1. Second, a `Boolean` value indicating whether the master slides should be included when scanning text from the presentation.

The method returns an array of objects of type [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), including text formatting information. The code below scans the text and formatting details from a presentation, including the master slides.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Categorized and Fast Text Extraction**

The [PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/) class also provides methods for extracting all text from presentations:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/cpp/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode for organizing the text extraction result and can be set to the following values:
- `Unarranged` - The raw text without regard to its position on the slide.
- `Arranged` - The text is arranged in the same order as on the slide.

The unarranged mode can be used when speed is critical; it's faster than the arranged mode.

[IPresentationText](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationtext/) represents the raw text extracted from the presentation. Its `get_SlidesText()` method returns an array of objects of type [ISlideText](https://reference.aspose.com/slides/cpp/aspose.slides/islidetext/). Each object represents the text on the corresponding slide. The object of type [ISlideText](https://reference.aspose.com/slides/cpp/aspose.slides/islidetext/) has the following methods:

- `get_Text()` - The text within the slide's shapes.
- `get_MasterText()` - The text within the master slide's shapes associated with this slide.
- `get_LayoutText()` - The text within the layout slide's shapes associated with this slide.
- `get_NotesText()` - The text within the notes slide's shapes associated with this slide.
- `get_CommentsText()` - The text within comments associated with this slide.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**How fast does Aspose.Slides process large presentations during text extraction?**

Aspose.Slides is optimized for high performance and can process even [large presentations](/slides/cpp/open-presentation/), making it suitable for real-time or bulk processing scenarios.

**Can Aspose.Slides extract text from tables and charts within presentations?**

Yes. Aspose.Slides can extract text from many slide elements, including tables and chart-related objects, so you can access and analyze textual content in common presentation structures.

**Do I need a special Aspose.Slides license to extract text from presentations?**

You can extract text using the free trial version of Aspose.Slides, although it will have [certain limitations](/slides/cpp/licensing/), such as processing only a limited number of slides. For unrestricted use and to handle larger presentations, purchasing a full license is recommended.
