---
title: Convert PPT and PPTX to JPG in Python
linktitle: PowerPoint to JPG
type: docs
weight: 60
url: /python-java/convert-powerpoint-to-jpg/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- PowerPoint to JPG
- PPT to JPG
- PPTX to JPG
- save slide as JPG
- export PPT to JPG
- export PPTX to JPG
- Python
- Java
- Aspose.Slides
description: "Convert PowerPoint (PPT, PPTX) slides to JPG images in Python via Java. Set custom image dimensions and render notes and comments with Aspose.Slides."
---

## **Introduction**

Aspose.Slides for Python via Java lets you convert PowerPoint and OpenDocument presentations (PPT, PPTX, and ODP) into JPEG images. You can export every slide or a selected slide to create thumbnails, build a presentation viewer, or embed slide previews in a website or application.

## **Convert PowerPoint PPT/PPTX to JPG**

1. Load the presentation with [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Retrieve the slides using [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides).
3. Call [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) with horizontal and vertical scale factors to render each slide.
4. Save each rendered image as JPEG using [ImageFormat.Jpeg](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Jpeg), then release the image resources.

{{% alert color="info" title="Note" %}}

Exporting to JPG creates a separate image for each slide. Save the rendered image rather than saving the presentation directly to an image format.

{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convert PowerPoint PPT/PPTX to JPG with Customized Dimensions**

Calculate horizontal and vertical scale factors from the desired pixel dimensions and the original slide size, then pass them to [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage). The following example targets a 1200 × 800 image for each slide.

Using different scale factors can stretch the slide. To preserve its aspect ratio, use the same scale factor for both axes; the resulting width and height will then follow the original slide proportions.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Render Comments When Saving Slides as Images**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) to configure notes and comments, and apply the layout through [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). This example places notes at the bottom, truncating notes that do not fit, and displays comments on the right in a 200-pixel-wide area. It saves each rendered slide as a JPG image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Can I convert multiple slides or presentations to JPG?**

Yes. The examples loop through all slides and save one JPG per slide. To process multiple presentations, repeat the conversion for each input file and use separate output folders or unique file names to avoid overwriting images.

**Are charts, SmartArt, tables, and shapes included in the images?**

These objects are rendered as part of the slide. Make the fonts used by the presentation available in the conversion environment to reduce differences caused by font substitution.

**How can I reduce memory usage when exporting large presentations?**

Process images one at a time, release each image after saving it, and avoid unnecessarily large output dimensions. Memory requirements depend on the slide content and image size.

## **See Also**

- [Convert PowerPoint to PNG](/slides/python-java/convert-powerpoint-to-png/).
- [Render a slide as an SVG image](/slides/python-java/render-a-slide-as-an-svg-image/).
