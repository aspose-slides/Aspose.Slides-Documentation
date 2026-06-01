---
title: Advanced Text Extraction from Presentations in PHP
linktitle: Extract Text
type: docs
weight: 90
url: /php-java/extract-text-from-presentation/
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
- PHP
- Aspose.Slides
description: "Quickly extract text from PowerPoint and OpenDocument presentations using Aspose.Slides for PHP via Java. Follow our simple, step-by-step guide to save time."
---

## **Overview**

Extracting text from presentations is a common yet essential task for developers working with slide content. Whether you're dealing with Microsoft PowerPoint files in PPT or PPTX format, or OpenDocument presentations (ODP), accessing and retrieving textual data can be critical for analysis, automation, indexing, or content migration purposes.

This article provides a comprehensive guide on how to efficiently extract text from various presentation formats, including PPT, PPTX, and ODP, using Aspose.Slides for PHP via Java. You'll learn how to systematically iterate through presentation elements to accurately retrieve the text content you need.

## **Extract Text from a Slide**

Aspose.Slides for PHP via Java provides the [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/) class. This class exposes several overloaded static methods for extracting all text from a presentation or slide. To extract text from a slide in a presentation, use the [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/#getAllTextBoxes) method. This method accepts an object of type [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) as a parameter. When executed, the method scans the entire slide for text and returns an array of objects of type [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), preserving any text formatting.

The following code snippet extracts all the text from the first slide of the presentation:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extract Text from a Presentation**

To scan text from the entire presentation, use the [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/#getAllTextFrames) static method exposed by the [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/) class. It accepts two parameters:

1. First, a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) object representing a PowerPoint or OpenDocument presentation from which text will be extracted.
1. Second, a `boolean` value indicating whether the master slides should be included when scanning text from the presentation.

The method returns an array of objects of type [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/), including text formatting information. The code below scans the text and formatting details from a presentation, including the master slides.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Categorized and Fast Text Extraction**

The [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) class also provides methods for extracting all text from presentations:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode for organizing the text extraction result and can be set to the following values:
- `Unarranged` - The raw text without regard to its position on the slide.
- `Arranged` - The text is arranged in the same order as on the slide.

The unarranged mode can be used when speed is critical; it's faster than the arranged mode.

[PresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/presentationtext/) represents the raw text extracted from the presentation. Its `getSlidesText` method returns an array of objects where each object represents the text on the corresponding slide. Each returned object has the following methods:

- `getText` - The text within the slide's shapes.
- `getMasterText` - The text within the master slide's shapes associated with this slide.
- `getLayoutText` - The text within the layout slide's shapes associated with this slide.
- `getNotesText` - The text within the notes slide's shapes associated with this slide.
- `getCommentsText` - The text within comments associated with this slide.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**How fast does Aspose.Slides process large presentations during text extraction?**

Aspose.Slides is optimized for high performance and can process even [large presentations](/slides/php-java/open-presentation/), making it suitable for real-time or bulk processing scenarios.

**Can Aspose.Slides extract text from tables and charts within presentations?**

Yes. Aspose.Slides can extract text from many slide elements, including tables and chart-related objects, so you can access and analyze textual content in common presentation structures.

**Do I need a special Aspose.Slides license to extract text from presentations?**

You can extract text using the free trial version of Aspose.Slides, although it will have [certain limitations](/slides/php-java/licensing/), such as processing only a limited number of slides. For unrestricted use and to handle larger presentations, purchasing a full license is recommended.
