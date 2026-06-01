---
title: Advanced Text Extraction from Presentations in Python
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
description: "Quickly extract text from PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET. Follow our simple, step-by-step guide to save time."
---

## **Overview**

Extracting text from presentations is a common yet essential task for developers working with slide content. Whether you're dealing with Microsoft PowerPoint files in PPT or PPTX format, or OpenDocument presentations (ODP), accessing and retrieving textual data can be critical for analysis, automation, indexing, or content migration purposes.

This article provides a comprehensive guide on how to efficiently extract text from various presentation formats, including PPT, PPTX, and ODP, using Aspose.Slides for Python via .NET. You'll learn how to systematically iterate through presentation elements to accurately retrieve the text content you need.

## **Extract Text from a Slide**

Aspose.Slides for Python via .NET provides the [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/) namespace, which includes the [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) class. This class exposes several overloaded static methods for extracting all text from a presentation or slide. To extract text from a slide in a presentation, use the [get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) method. This method accepts an object of type [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) as a parameter. When executed, the method scans the entire slide for text and returns an array of objects of type [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), preserving any text formatting.

The following code snippet extracts all the text from the first slide of the presentation:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Extract Text from a Presentation**

To scan text from the entire presentation, use the [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) static method exposed by the [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) class. It accepts two parameters:

1. First, a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object representing a PowerPoint or OpenDocument presentation from which text will be extracted.
1. Second, a `Boolean` value indicating whether the master slides should be included when scanning text from the presentation.

The method returns an array of objects of type [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), including text formatting information. The code below scans the text and formatting details from a presentation, including the master slides.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Categorized and Fast Text Extraction**

The [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/) class also provides methods for extracting all text from presentations:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode for organizing the text extraction result and can be set to the following values:
- `UNARRANGED` - The raw text without regard to its position on the slide.
- `ARRANGED` - The text is arranged in the same order as on the slide.

The `UNARRANGED` mode can be used when speed is critical; it's faster than the `ARRANGED` mode.

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) represents the raw text extracted from the presentation. Its `slides_text` property returns an array of slide text objects. Each object represents the text on the corresponding slide and has the following properties:

- `text` - The text within the slide's shapes.
- `master_text` - The text within the master slide's shapes associated with this slide.
- `layout_text` - The text within the layout slide's shapes associated with this slide.
- `notes_text` - The text within the notes slide's shapes associated with this slide.
- `comments_text` - The text within comments associated with this slide.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **FAQ**

**How fast does Aspose.Slides process large presentations during text extraction?**

Aspose.Slides is optimized for high performance and can process even [large presentations](/slides/python-net/open-presentation/), making it suitable for real-time or bulk processing scenarios.

**Can Aspose.Slides extract text from tables and charts within presentations?**

Yes. Aspose.Slides can extract text from many slide elements, including tables and chart-related objects, so you can access and analyze textual content in common presentation structures.

**Do I need a special Aspose.Slides license to extract text from presentations?**

You can extract text using the free trial version of Aspose.Slides, although it will have [certain limitations](/slides/python-net/licensing/), such as processing only a limited number of slides. For unrestricted use and to handle larger presentations, purchasing a full license is recommended.
