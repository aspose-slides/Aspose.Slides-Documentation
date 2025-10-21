---
title: Advanced Text Extraction from PowerPoint Presentations in Python
linktitle: Extract Text
type: docs
weight: 90
url: /python-net/extract-text-from-presentation/
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
- Python
- Aspose.Slides
description: "Learn how to quickly and easily extract text from PowerPoint presentations using Aspose.Slides for Python via .NET. Follow our simple, step-by-step guide to save time and efficiently access slide content in your applications."
---

## **Overview**

Extracting text from presentations is a common yet essential task for developers working with slide content. Whether you're dealing with Microsoft PowerPoint files in PPT or PPTX format, or OpenDocument presentations (ODP), accessing and retrieving textual data can be critical for analysis, automation, indexing, or content migration purposes.

This article provides a comprehensive guide on how to efficiently extract text from various presentation formats, including PPT, PPTX, and ODP, using Aspose.Slides for Python. You'll learn how to systematically iterate through presentation elements to accurately retrieve the text content you need.

## **Extract Text from a Slide**

Aspose.Slides for Python provides the [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/) namespace, which includes the [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) class. This class exposes several overloaded static methods for extracting all text from a presentation or slide. To extract text from a slide in a presentation, use the [get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) method. This method accepts an object of type [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) as a parameter. When executed, the method scans the entire slide for text and returns an array of objects of type [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), preserving any text formatting.

The following code snippet extracts all the text from the first slide of the presentation:

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Get an array of TextFrame objects from all slides in the PPTX file.
    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)
    # Loop through the array of the text frames.
    for text_frame in text_frames:
        # Loop through paragraphs in the current text frame.
        for paragraph in text_frame.paragraphs:
            # Loop through text portions in the current paragraph.
            for portion in paragraph.portions:
                # Display the text in the current portion.
                print(portion.text)
                # Display the font height of the text.
                print(portion.portion_format.font_height)
                # Display the font name of the text.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```

## **Extract Text from a Presentation**

To scan text from the entire presentation, use the [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) static method exposed by the [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) class. It accepts two parameters:

1. A [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object representing a PowerPoint or OpenDocument presentation from which text will be extracted.
1. A `Boolean` value indicating whether the master slides should be included when scanning text from the presentation.

The method returns an array of objects of type [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), including text formatting information. The code below scans the text and formatting details from a presentation, including the master slides.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation("pres.pptx") as presentation:
    # Get an array of TextFrame objects from all slides in the PPTX file.
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, True)
    # Loop through the array of text frames.
    for text_frame in text_frames:
        # Loop through paragraphs in the current text frame.
        for paragraph in text_frame.paragraphs:
            # Loop through text portions in the current paragraph.
            for portion in paragraph.portions:
                # Display text in the current portion.
                print(portion.text)
                # Display the font height of the text.
                print(portion.portion_format.font_height)
                # Display the font name of the text.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```

## **Categorized and Fast Text Extraction**

The [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationfactory/) class also provides static methods for extracting all text from presentations:

```py
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode for organizing the text extraction result and can be set to the following values:
- `UNARRANGED` - The raw text without regard to its position on the slide.
- `ARRANGED` - The text is arranged in the same order as on the slide.

The `UNARRANGED` mode can be used when speed is critical; it's faster than the `ARRANGED` mode.

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) represents the raw text extracted from the presentation. It contains the `slides_text` property, which returns an array of objects of type [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/). Each object represents the text on the corresponding slide. The object of type [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) has the following properties:

- `text` - The text within the slide's shapes.
- `master_text` - The text within the master slide's shapes associated with this slide.
- `layout_text` - The text within the layout slide's shapes associated with this slide.
- `notes_text` - The text within the notes slide's shapes associated with this slide.
- `comments_text` - The text within comments associated with this slide.

```py
import aspose.slides as slides

arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory().get_presentation_text("sample.pptx", arranging_mode)
slide_text = presentation_text.slides_text[0]
print(slide_text.text)
print(slide_text.layout_text)
print(slide_text.master_text)
print(slide_text.notes_text)
```

## **FAQ**

**How fast does Aspose.Slides process large presentations during text extraction?**

Aspose.Slides is optimized for high performance and efficiently processes even [large presentations](/slides/python-net/open-presentation/), making it suitable for real-time or bulk processing scenarios.

**Can Aspose.Slides extract text from tables and charts within presentations?**

Yes, Aspose.Slides fully supports extracting text from tables, charts, and other complex slide elements, allowing you to access and analyze all textual content easily.

**Do I need a special Aspose.Slides license to extract text from presentations?**

You can extract text using the free trial version of Aspose.Slides, although it will have [certain limitations](/slides/python-net/licensing/), such as processing only a limited number of slides. For unrestricted use and to handle larger presentations, purchasing a full license is recommended.
