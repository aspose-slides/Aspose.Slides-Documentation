---
title: Advanced Text Extraction from Presentations in JavaScript
linktitle: Extract Text
type: docs
weight: 90
url: /nodejs-java/extract-text-from-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Quickly extract text from PowerPoint and OpenDocument presentations using Aspose.Slides for Node.js via Java. Follow our simple, step-by-step guide to save time."
---

## **Overview**

Extracting text from presentations is a common yet essential task for developers working with slide content. Whether you're dealing with Microsoft PowerPoint files in PPT or PPTX format, or OpenDocument presentations (ODP), accessing and retrieving textual data can be critical for analysis, automation, indexing, or content migration purposes.

This article provides a comprehensive guide on how to efficiently extract text from various presentation formats, including PPT, PPTX, and ODP, using Aspose.Slides for Node.js via Java. You'll learn how to systematically iterate through presentation elements to accurately retrieve the text content you need.

## **Extract Text from a Slide**

Aspose.Slides for Node.js via Java provides the [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideutil/) class. This class exposes several overloaded static methods for extracting all text from a presentation or slide. To extract text from a slide in a presentation, use the [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) method. This method accepts a slide object as a parameter. When executed, the method scans the entire slide for text and returns an array of [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) objects, preserving any text formatting.

The following code snippet extracts all the text from the first slide of the presentation:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extract Text from a Presentation**

To scan text from the entire presentation, use the [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) static method exposed by the [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideutil/) class. It accepts two parameters:

1. First, a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) object representing a PowerPoint or OpenDocument presentation from which text will be extracted.
1. Second, a `boolean` value indicating whether the master slides should be included when scanning text from the presentation.

The method returns an array of [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) objects, including text formatting information. The code below scans the text and formatting details from a presentation, including the master slides.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Categorized and Fast Text Extraction**

The [PresentationFactory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/) class also provides methods for extracting all text from presentations:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode for organizing the text extraction result and can be set to the following values:
- `Unarranged` - The raw text without regard to its position on the slide.
- `Arranged` - The text is arranged in the same order as on the slide.

The unarranged mode can be used when speed is critical; it's faster than the arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationtext/) represents the raw text extracted from the presentation. Its `getSlidesText` method returns an array of objects, each representing the text on the corresponding slide. Each slide text object has the following methods:

- Its `getText` method returns the text within the slide's shapes.
- Its `getMasterText` method returns the text within the master slide's shapes associated with this slide.
- Its `getLayoutText` method returns the text within the layout slide's shapes associated with this slide.
- Its `getNotesText` method returns the text within the notes slide's shapes associated with this slide.
- Its `getCommentsText` method returns the text within comments associated with this slide.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **FAQ**

**How fast does Aspose.Slides process large presentations during text extraction?**

Aspose.Slides is optimized for high performance and can process even [large presentations](/slides/nodejs-java/open-presentation/), making it suitable for real-time or bulk processing scenarios.

**Can Aspose.Slides extract text from tables and charts within presentations?**

Yes. Aspose.Slides can extract text from many slide elements, including tables and chart-related objects, so you can access and analyze textual content in common presentation structures.

**Do I need a special Aspose.Slides license to extract text from presentations?**

You can extract text using the free trial version of Aspose.Slides, although it will have [certain limitations](/slides/nodejs-java/licensing/), such as processing only a limited number of slides. For unrestricted use and to handle larger presentations, purchasing a full license is recommended.
