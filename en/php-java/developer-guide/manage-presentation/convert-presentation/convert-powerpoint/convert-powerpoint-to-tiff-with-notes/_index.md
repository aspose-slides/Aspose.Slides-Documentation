---
title: Convert PowerPoint Presentations to TIFF with Notes in PHP
linktitle: PowerPoint to TIFF with Notes
type: docs
weight: 100
url: /php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to TIFF
- presentation to TIFF
- slide to TIFF
- PPT to TIFF
- PPTX to TIFF
- save PPT as TIFF
- save PPTX as TIFF
- export PPT to TIFF
- export PPTX to TIFF
- PowerPoint with notes
- presentation with notes
- slide with notes
- PPT with notes
- PPTX with notes
- TIFF with notes
- PHP
- Aspose.Slides
description: "Convert PowerPoint presentations to TIFF with notes using Aspose.Slides for PHP via Java. Learn how to export slides with speaker notes efficiently."
---

## **Overview**

Aspose.Slides for PHP via Java provides a simple solution for converting PowerPoint and OpenDocument presentations (PPT, PPTX, and ODP) with notes to the TIFF format. This format is widely used for high-quality image storage, printing, and document archiving. With Aspose.Slides, you can not only export entire presentations with speaker notes but also generate slide thumbnails in the Notes Slide view. The conversion process is simple and efficient, utilizing the `save` method of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class to transform the entire presentation into a series of TIFF images while preserving the notes and layout.

## **Convert a Presentation to TIFF with Notes**

Saving a PowerPoint or OpenDocument presentation to TIFF with notes using Aspose.Slides for PHP via Java involves the following steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class: Load a PowerPoint or OpenDocument file.
1. Configure the output layout options: Use the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) class to specify how notes and comments should be displayed.
1. Save the presentation to TIFF: Pass the configured options to the [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) method.

Let's say we have a "speaker_notes.pptx" file with the following slide:

![The presentation slide with speaker notes](slide_with_notes.png)

The code snippet below demonstrates how to convert the presentation to a TIFF image in Notes Slide view using the [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) method.

```php
// Instantiate the Presentation class that represents a presentation file.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Display the notes below the slide.

    // Configure the TIFF options with Notes layouting.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Save the presentation to TIFF with the speaker notes.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

The result:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Check out Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Can I control the position of the notes area in the resulting TIFF?**

Yes. Use the [notes layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) to choose among options like `None`, `BottomTruncated`, or `BottomFull`, which respectively hide notes, fit them into a single page, or allow them to flow onto additional pages.

**How can I reduce the size of a TIFF file with notes without visible loss of quality?**

Pick an [efficient compression](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setcompressiontype/) (e.g., `LZW` or `RLE`), set a reasonable DPI, and, if acceptable, use a lower [pixel format](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setpixelformat/) (such as 8 bpp or 1 bpp for monochrome). Slightly reducing the [image dimensions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setimagesize/) can also help without noticeably hurting readability.

**Does the font in the notes affect the result if the original fonts are missing from the system?**

Yes. Missing fonts trigger [substitution](/slides/php-java/font-selection-sequence/), which can change text metrics and appearance. To avoid this, [supply the required fonts](/slides/php-java/custom-font/) or set a default [fallback font](/slides/php-java/fallback-font/) so the intended typefaces are used.
