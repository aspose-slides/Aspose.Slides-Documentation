---
title: Change Notes Page Size and Orientation in PHP
linktitle: Notes Page Size
type: docs
weight: 10
url: /php-java/notes-size/
keywords:
- notes page size
- notes orientation
- landscape notes
- portrait notes
- handout size
- PowerPoint
- presentation
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Read and change notes page dimensions in Aspose.Slides for PHP via Java, switch orientation, verify saved sizes, and export notes or handouts to PDF and images."
---

## **Overview**

Use [Presentation::getNotesSize](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getnotessize/) to access the presentation's notes page settings. It returns a [NotesSize](https://reference.aspose.com/slides/php-java/aspose.slides/notessize/) object whose [setSize](https://reference.aspose.com/slides/php-java/aspose.slides/notessize/setsize/) method sets the page dimensions. Although the settings object itself cannot be replaced, you can assign new dimensions through this method.

Width and height are specified in **points**, with 72 points per inch. For example, 900 × 600 points is 12.5 × 8⅓ inches. These settings apply to the presentation, rather than to an individual slide's notes.

| Setting | Purpose |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getnotessize/) | Controls notes page dimensions and the page dimensions used for handout export. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) | Controls regular presentation slide dimensions through [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/). |

Changing either setting does not automatically change the other. Changing the notes page orientation also does not rotate the regular slides. See [Slide Size](/slides/php-java/slide-size/) to resize regular slides.

The examples below use an existing `sample.pptx`. For the export examples, use a presentation with at least one slide containing speaker notes. Each example can be run independently after loading the PHP/Java Bridge and the Aspose.Slides PHP wrapper. Numeric values returned by Java are converted to PHP values with `java_values` before comparison or calculation.

## **Read the Notes Page Size and Orientation**

Read the width and height and compare them to determine the orientation: a wider page is landscape, a taller page is portrait, and equal dimensions describe a square page. This example prints the actual dimensions in points, without assuming a standard paper size.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Switch to Landscape Without Changing the Paper Size**

To change only the orientation, swap the existing width and height. This preserves the lengths of both sides, including those of a custom paper size. The condition below prevents an already-landscape page from being switched back to portrait and leaves a square page unchanged.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

For portrait orientation, use the same assignment when `java_values($size->getWidth()) > java_values($size->getHeight())`. Do not substitute A4 or Letter dimensions unless you also want to change the paper size.

## **Set and Verify a Custom Notes Page Size**

Assign both dimensions together, then use [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) to write the presentation. This example sets a 900 × 600-point landscape page, saves it as PPTX, and opens the saved file again to check the persisted values. The comparison allows a 0.01-point tolerance for floating-point values; it is not a guarantee of precision for every file format.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

The expected result is `900 x 600 points` and `Size preserved: true`. Checking a newly opened presentation verifies the saved file, rather than only the in-memory settings.

## **Export Notes and Handouts**

The page dimensions define the available area for notes or handout layouts. They do not enable those layouts by themselves: configure the export options as well. Regular slide export continues to use the slide dimensions.

### **Export Notes to PDF and PNG**

Assign [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) to [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) to include notes in the PDF. This example also renders the first slide with notes to PNG using [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) and [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/).

The [BottomTruncated](https://reference.aspose.com/slides/php-java/aspose.slides/notespositions/) mode keeps the notes on one page; notes that do not fit can be truncated. The PDF uses 900 × 600-point pages. At the image scale of 1 × 1 used below, the PNG is 900 × 600 pixels. Points describe the page geometry; pixels describe the raster output, whose dimensions also depend on the rendering scale.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

For PDF export with long notes, [BottomFull](https://reference.aspose.com/slides/php-java/aspose.slides/notespositions/) allows additional pages as needed. Do not use that mode with the single-slide image call above, which does not support it. After resizing, inspect the output for clipped notes and the placement of existing notes-master objects; changing page dimensions alone should not be treated as a guarantee that all content will fit. See [Convert PowerPoint to PDF with Notes](/slides/php-java/convert-powerpoint-to-pdf-with-notes/) for more about notes export.

### **Export Handouts to PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/handoutlayoutingoptions/) for multiple slide thumbnails on one page. The following example sets a 900 × 600-point page and uses [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) to arrange up to four slides per page. The horizontal preset controls slide ordering; the page orientation comes from its width and height.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Changing the page size changes the area available for the handout grid without changing the source slides' dimensions. For handout images, use [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) with the handout layout, rather than an individual slide's image method. In Aspose.Slides, presentation-level handout rendering uses the notes page dimensions, while the individual slide image call does not produce the handout page. See [Handout Mode](/slides/php-java/convert-powerpoint-in-handout-mode/) for layout options.

## **Page Size in Viewers, Export, and Printing**

Keep the stored presentation size, the exported page size, and the printed paper size distinct:

- **Presentation viewers:** A viewer can display or print notes using its own layout rules. If another application saves the file, reopen it and check the dimensions again; that application's format conversion may normalize them.
- **Export formats:** The notes and handout PDF examples above use the configured page dimensions. Raster images use integer pixel dimensions and a rendering scale, so fractional point values can be rounded in the image output. Exporting regular slides does not apply the notes page size.
- **Printer drivers:** Paper selection, automatic rotation, and fit-to-page settings can change the physical output without changing the dimensions stored in the presentation or PDF. For a specific paper size, match the printer settings and inspect the print preview.

## **FAQ**

**Can I set the notes size for just one slide?**

The notes page size is a presentation-level setting. Individual slides can have different notes content, but this property does not provide a separate page size for each slide.

**Why did changing notes orientation not change my slides?**

Notes pages and regular slides have independent dimensions. Use the regular slide size settings when you want to resize the slides themselves.

**Why does my saved or printed result have a different size?**

First reopen the saved presentation and compare its notes dimensions. If those changed, check whether saving or converting the file in another application changed the page settings. If they did not, check the export layout, image scale, viewer settings, and printer paper selection.
