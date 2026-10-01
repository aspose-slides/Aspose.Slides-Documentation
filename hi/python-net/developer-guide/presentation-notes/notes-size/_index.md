---
title: Python में नोट्स पेज का आकार और अभिविन्यास बदलें
linktitle: नोट्स पेज आकार
type: docs
weight: 10
url: /hi/python-net/notes-size/
keywords:
- नोट्स पेज आकार
- नोट्स अभिविन्यास
- लैंडस्केप नोट्स
- पोर्ट्रेट नोट्स
- हैंडआउट आकार
- PowerPoint
- प्रस्तुति
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Aspose.Slides for Python (.NET के माध्यम से) में नोट्स पेज के आयाम पढ़ें और बदलें, अभिविन्यास बदलें, सहेजे गए आकारों की जाँच करें, और नोट्स या हैंडआउट को PDF और छवियों में निर्यात करें।"
---
## **Overview**

Use [Presentation.notes_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/notes_size/) to access the presentation's notes page settings. It returns a [NotesSize](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notessize/) object whose [size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notessize/size/) property is writable. Although the settings object itself is read-only, you can assign new dimensions to its size property.

Width and height are specified in **points**, with 72 points per inch. For example, 900 × 600 points is 12.5 × 8⅓ inches. These settings apply to the presentation, rather than to an individual slide's notes.

| सेटिंग | उद्देश्य |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/notes_size/) | नोट्स पेज के आयामों और हैंडआउट निर्यात के लिए उपयोग किए जाने वाले पेज आयामों को नियंत्रित करता है। |
| [Presentation.slide_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slide_size/) | नियमित प्रस्तुति स्लाइड के आयामों को [SlideSize](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/) के माध्यम से नियंत्रित करता है। |

Changing either setting does not automatically change the other. Changing the notes page orientation also does not rotate the regular slides. See [Slide Size](/slides/hi/python-net/slide-size/) to resize regular slides.

The examples below use an existing `sample.pptx`. For the export examples, use a presentation with at least one slide containing speaker notes. Each example can be run independently.

## **Read the Notes Page Size and Orientation**

Read the width and height and compare them to determine the orientation: a wider page is landscape, a taller page is portrait, and equal dimensions describe a square page. This example prints the actual dimensions in points, without assuming a standard paper size.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Switch to Landscape Without Changing the Paper Size**

To change only the orientation, swap the existing width and height. This preserves the lengths of both sides, including those of a custom paper size. The condition below prevents an already-landscape page from being switched back to portrait and leaves a square page unchanged.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

For portrait orientation, use the same assignment when `size.width > size.height`. Do not substitute A4 or Letter dimensions unless you also want to change the paper size.

## **Set and Verify a Custom Notes Page Size**

Assign both dimensions together, then use [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) to write the presentation. This example sets a 900 × 600-point landscape page, saves it as PPTX, and opens the saved file again to check the persisted values. The comparison allows a 0.01-point tolerance for floating-point values; it is not a guarantee of precision for every file format.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

The expected result is `900 x 600 points` and `Size preserved: True`. Checking a newly opened presentation verifies the saved file, rather than only the in-memory settings.

## **Export Notes and Handouts**

The page dimensions define the available area for notes or handout layouts. They do not enable those layouts by themselves: configure the export options as well. Regular slide export continues to use the slide dimensions.

### **Export Notes to PDF and PNG**

Assign [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/) to [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) to include notes in the PDF. This example also renders the first slide with notes to PNG using [Slide.get_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/) and [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/).

The [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notespositions/) mode keeps the notes on one page; notes that do not fit can be truncated. The PDF uses 900 × 600-point pages. At the image scale of 1 × 1 used below, the PNG is 900 × 600 pixels. Points describe the page geometry; pixels describe the raster output, whose dimensions also depend on the rendering scale.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

For PDF export with long notes, [BOTTOM_FULL](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notespositions/) allows additional pages as needed. Do not use that mode with the single-slide image call above, which does not support it. After resizing, inspect the output for clipped notes and the placement of existing notes-master objects; changing page dimensions alone should not be treated as a guarantee that all content will fit. See [Convert PowerPoint to PDF with Notes](/slides/hi/python-net/convert-powerpoint-to-pdf-with-notes/) for more about notes export.

### **Export Handouts to PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handoutlayoutingoptions/) for multiple slide thumbnails on one page. The following example sets a 900 × 600-point page and uses [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/handouttype/) to arrange up to four slides per page. The horizontal preset controls slide ordering; the page orientation comes from its width and height.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Changing the page size changes the area available for the handout grid without changing the source slides' dimensions. For handout images, use [Presentation.get_images](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/get_images/) with the handout layout, rather than an individual slide's image method. In Aspose.Slides, presentation-level handout rendering uses the notes page dimensions, while the individual slide image call does not produce the handout page. See [Handout Mode](/slides/hi/python-net/convert-powerpoint-in-handout-mode/) for layout options.

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