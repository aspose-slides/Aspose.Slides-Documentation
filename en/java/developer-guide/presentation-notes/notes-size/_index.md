---
title: Change Notes Page Size and Orientation in Java
linktitle: Notes Page Size
type: docs
weight: 10
url: /java/notes-size/
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
- Java
- Aspose.Slides
description: "Read and change notes page dimensions in Aspose.Slides for Java, switch orientation, verify saved sizes, and export notes or handouts to PDF and images."
---

## **Overview**

Use [Presentation.getNotesSize](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getNotesSize--) to access the presentation's notes page settings. It returns an [INotesSize](https://reference.aspose.com/slides/java/com.aspose.slides/inotessize/) object whose [setSize](https://reference.aspose.com/slides/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) method sets the page dimensions. Although the settings object itself cannot be replaced, you can assign new dimensions through this method.

Width and height are specified in **points**, with 72 points per inch. For example, 900 × 600 points is 12.5 × 8⅓ inches. These settings apply to the presentation, rather than to an individual slide's notes.

| Setting | Purpose |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getNotesSize--) | Controls notes page dimensions and the page dimensions used for handout export. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideSize--) | Controls regular presentation slide dimensions through [ISlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/). |

Changing either setting does not automatically change the other. Changing the notes page orientation also does not rotate the regular slides. See [Slide Size](/slides/java/slide-size/) to resize regular slides.

The examples below use an existing `sample.pptx`. For the export examples, use a presentation with at least one slide containing speaker notes. Each example can be run independently.

## **Read the Notes Page Size and Orientation**

Read the width and height and compare them to determine the orientation: a wider page is landscape, a taller page is portrait, and equal dimensions describe a square page. This example prints the actual dimensions in points, without assuming a standard paper size.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Switch to Landscape Without Changing the Paper Size**

To change only the orientation, swap the existing width and height. This preserves the lengths of both sides, including those of a custom paper size. The condition below prevents an already-landscape page from being switched back to portrait and leaves a square page unchanged.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

For portrait orientation, use the same assignment when `size.getWidth() > size.getHeight()`. Do not substitute A4 or Letter dimensions unless you also want to change the paper size.

## **Set and Verify a Custom Notes Page Size**

Assign both dimensions together, then use [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) to write the presentation. This example sets a 900 × 600-point landscape page, saves it as PPTX, and opens the saved file again to check the persisted values. The comparison allows a 0.01-point tolerance for floating-point values; it is not a guarantee of precision for every file format.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

The expected result is `900.0 x 600.0 points` and `Size preserved: true`. Checking a newly opened presentation verifies the saved file, rather than only the in-memory settings.

## **Export Notes and Handouts**

The page dimensions define the available area for notes or handout layouts. They do not enable those layouts by themselves: configure the export options as well. Regular slide export continues to use the slide dimensions.

### **Export Notes to PDF and PNG**

Assign [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) to [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) to include notes in the PDF. This example also renders the first slide with notes to PNG using [Slide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) and [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/).

The [BottomTruncated](https://reference.aspose.com/slides/java/com.aspose.slides/notespositions/) mode keeps the notes on one page; notes that do not fit can be truncated. The PDF uses 900 × 600-point pages. At the image scale of 1 × 1 used below, the PNG is 900 × 600 pixels. Points describe the page geometry; pixels describe the raster output, whose dimensions also depend on the rendering scale.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

For PDF export with long notes, [BottomFull](https://reference.aspose.com/slides/java/com.aspose.slides/notespositions/) allows additional pages as needed. Do not use that mode with the single-slide image call above, which does not support it. After resizing, inspect the output for clipped notes and the placement of existing notes-master objects; changing page dimensions alone should not be treated as a guarantee that all content will fit. See [Convert PowerPoint to PDF with Notes](/slides/java/convert-powerpoint-to-pdf-with-notes/) for more about notes export.

### **Export Handouts to PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/) for multiple slide thumbnails on one page. The following example sets a 900 × 600-point page and uses [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/java/com.aspose.slides/handouttype/) to arrange up to four slides per page. The horizontal preset controls slide ordering; the page orientation comes from its width and height.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Changing the page size changes the area available for the handout grid without changing the source slides' dimensions. For handout images, use [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) with the handout layout, rather than an individual slide's image method. In Aspose.Slides, presentation-level handout rendering uses the notes page dimensions, while the individual slide image call does not produce the handout page. See [Handout Mode](/slides/java/convert-powerpoint-in-handout-mode/) for layout options.

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
