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

It’s common for developers to need to extract text from a presentation. To do this, you must pull text from every shape on every slide. This article explains how to extract text from Microsoft PowerPoint (PPTX) presentations using Aspose.Slides. Text can be extracted in the following ways:

- Extracting text from a slide
- Extracting text from a presentation
- Categorized and fast text extraction
 
## **Extract Text from a Slide**

Aspose.Slides for Python via .NET provides the [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/) namespace, which includes the [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) class. [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) exposes several overloaded static methods for extracting text from an entire presentation or a single slide. To extract text from a slide in a PPTX, use the `get_all_text_boxes` method. It takes a [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) object, scans the slide for text, and returns an array of [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) objects—so the text and its formatting are preserved. The code below extracts all text from the first slide of the presentation:

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

To extract text from an entire presentation, use the `get_all_text_frames` static method of the [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) class. It takes two parameters:

1. A [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object representing the PPTX to extract from.
1. A `Boolean` indicating whether to include the master slides.

The method returns an array of [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) objects with their formatting. The example below scans the text and formatting from a presentation, including the master slides.

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

The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class provides a static method, `get_presentation_text`, with these overloads:

```py
Presentation.get_presentation_text(stream, mode)
Presentation.get_presentation_text(file, mode)
Presentation.get_presentation_text(stream, mode, options)
```

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) argument controls how the extracted text is organized:

- `UNARRANGED` — raw text with no regard to on-slide position.
- `ARRANGED` — text appears in the same order as on the slide.

Use `UNARRANGED` when speed is critical; it is faster than `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) represents the raw text extracted from a presentation. It exposes the `slides_text` property, which returns an array of `SlideText` objects—each corresponding to a slide. A `SlideText` object has the following properties:

- `SlideText.text` — text from the slide’s shapes
- `SlideText.master_text` — text from the master page’s shapes for that slide
- `SlideText.layout_text` — text from the layout page’s shapes for that slide
- `SlideText.notes_text` — text from the notes page’s shapes for that slide

Here’s how to use the API:

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
