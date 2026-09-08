---
title: Manage Picture Frames in Presentations Using Python
linktitle: Picture Frame
type: docs
weight: 10
url: /python-java/picture-frame/
keywords:
- picture frame
- add picture frame
- create picture frame
- embedded image
- linked image
- extract image
- raster image
- SVG image
- crop image
- delete cropped areas
- compress image
- StretchOffset
- picture frame formatting
- relative scale
- image effect
- aspect ratio
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Create, format, link, crop, extract, and compress picture frames in presentations with Aspose.Slides for Python via Java."
---

## **Overview**

A picture frame is a slide shape that displays an image. In Aspose.Slides, the image resource and the shape that displays it are separate objects: a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) owns embedded image resources through its [ImageCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/), while a [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) controls the image's position, size, line formatting, rotation, cropping, picture effects, and other frame-level settings.

This separation is useful when the same image is shown more than once. Add the image to the presentation once, keep the returned [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/), and use that image resource when creating picture frames.

Picture frames can contain raster images such as PNG or JPEG and vector SVG images. They can also refer to linked images instead of storing the image bytes in the presentation. The choice affects portability, file size, extraction, and export behavior, so it is useful to decide how the image should be stored before applying formatting or optimization.

## **Add and Format an Embedded Image**

For an embedded image, add the image data to the presentation and create a picture frame with [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame). The image becomes part of the presentation package, so the presentation remains self-contained when it is moved to another computer.

The following example adds a JPEG image, creates a frame at the image's native dimensions, and applies line formatting and rotation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The picture frame controls the displayed geometry; changing the frame size does not change the original pixel dimensions stored in the embedded image resource. This distinction becomes important when cropping or compressing an image later.

## **Use Relative Scale**

[PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) exposes relative width and height scaling for the frame through [setRelativeScaleWidth](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) and [setRelativeScaleHeight](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). A value of `1.0` corresponds to 100% of the original picture size. Relative scale is useful when a workflow needs to preserve a relationship to the source image size instead of calculating final dimensions manually.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Relative scale changes the frame's scale settings; it does not resample or compress the embedded image.

## **Embedded and Linked Images**

An embedded picture stores image data inside the presentation and is therefore the safest choice for portability and predictable rendering. A linked picture stores an external location through the [Picture.setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setLinkPathLong) method instead of embedding the image data in the same way.

Linked images can reduce the amount of image data stored in the PPTX, but they introduce an external dependency. The linked file must remain accessible to the application that opens or renders the presentation. If the path changes, the file is moved, or the resource is unavailable, the linked picture may not be displayed as expected. For presentations that must be emailed, archived, or rendered in isolated environments, embedded images are usually more reliable.

### **Add a Linked Image**

The following example creates a picture frame and points it to a local image file. It deals only with image linking; video linking is a separate media workflow and is intentionally not mixed into this example.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Use links when external file management is intentional. Do not use them merely as a replacement for compression: a small PPTX with broken image dependencies is usually less useful than a larger self-contained presentation.

## **Extract Images from Picture Frames**

Before extracting an image from an existing presentation, check that a shape is actually a [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) and that it contains an embedded image. Linked picture frames may not contain image bytes that can be extracted in the same way.

### **Extract a Raster Image**

The modern image API works with raster images directly and does not require the older Java image wrapper. The following example finds the first embedded raster picture on a slide and saves it as PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Saving the raster image converts the extracted image to the requested output format. If you need the encoded bytes stored in the presentation rather than a converted raster file, use the image resource's binary data instead.

### **Extract an SVG Image**

For an SVG picture, the [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) exposes a [SvgImage](https://reference.aspose.com/slides/python-java/aspose.slides/svgimage/) object. This lets you retrieve the SVG data directly instead of rasterizing the picture first.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Keeping SVG content as SVG preserves the vector source inside the presentation. Raster exports such as PNG or JPEG necessarily render that vector content to pixels. PDF or SVG slide export is also a rendering operation, so the exported graphics should not be treated as a byte-for-byte copy of the original embedded SVG; use the embedded [SvgImage.getSvgData](https://reference.aspose.com/slides/python-java/aspose.slides/svgimage/#getSvgData) data when the original vector resource itself is required.

## **Crop an Image**

Cropping changes which part of an image is visible inside the frame. The crop values on [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) are percentages of the source image dimensions. Cropping does not initially delete the hidden pixels from the embedded image; it only changes the visible region.

The following example finds a picture frame safely and applies crop values:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Because the hidden image data is still present, the crop can be changed later without losing the original pixels. If file size matters more than reversibility, the cropped regions can be physically removed as described in the next section.

## **Remove Cropped Image Data**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) removes image data outside the current crop rectangle and returns the resulting image resource. This can reduce file size, but it is a destructive optimization: after the presentation is saved, the removed pixels are no longer available for a later uncrop operation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The method may add a new image resource to the presentation. If the original image is also used by other picture frames, those frames still need their existing resource, so deleting cropped areas does not necessarily reduce the total number of images. Cropping WMF or EMF content with this method rasterizes the cropped result to PNG.

## **Compress Raster Images**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#compressImage) reduces raster image resolution relative to the size at which the picture is displayed. It can also remove cropped regions in the same operation. The method returns `True` when the image was resized or cropped and `False` when no change was necessary.

Use a predefined [PicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/picturescompression/) value when a standard target resolution is sufficient:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A custom positive DPI value can be passed instead of a predefined value when a specific target is required.

Compression is intended for raster images. SVG and metafile content is not reduced by this raster compression workflow. Also remember that lower resolution and deleted cropped regions cannot be recovered from the optimized presentation. Choose a target resolution based on the largest size at which the image will actually be viewed or exported rather than applying the lowest DPI globally.

## **Manage Image Transform Effects**

For a complete workflow covering brightness, contrast, color transformations, blur, alpha effects, ordered chains, inspection, removal, and round-trip verification, see [Image Transform Effects](/slides/python-java/image-transform-effects/).

## **Lock Picture Frame Geometry**

The [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) settings control which editing operations are disabled for a picture frame. For example, [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) preserves the shape's proportions while it is resized.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The lock applies to the picture frame shape. It does not force the source image to be resampled or permanently changed to the same aspect ratio.

## **Adjust the StretchOffset Values**

When the picture fill mode is stretch, the stretch-offset values on [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) define the fill rectangle relative to the picture frame's bounding box. Positive percentages create an inset from an edge, while negative percentages create an outset.

This is different from cropping. Crop values select which part of the source image is visible; stretch offsets change the rectangle into which the visible picture fill is stretched.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Use stretch offsets for fill placement. Use crop properties when the goal is to hide source-image edges.

## **Storage, File Size, and Export Considerations**

The main tradeoffs are easier to manage when image storage and picture-frame formatting are treated separately:

- **Embedded images** make the presentation self-contained and are the most reliable for sharing and server-side rendering, but large raster images increase PPTX size and memory use.
- **Linked images** can keep the package smaller, but the presentation depends on external files remaining available at the stored paths or locations.
- **Cropping** is initially non-destructive. The hidden pixels remain embedded until cropped areas are explicitly deleted or removed during compression.
- **Compression** can reduce file size substantially for oversized raster images, but it trades away source resolution. It should be applied after the intended on-slide size is known.
- **SVG images** should remain as SVG when vector preservation is important. Extract the embedded SVG directly when you need the vector resource itself. Raster slide exports always convert the rendered slide to pixels.
- **Repeated images** should reuse an existing [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) resource when possible instead of repeatedly loading the same file into the presentation workflow.

For large presentations, image optimization is usually most effective when performed selectively: keep logos and diagrams as vector content, compress photographs according to their real display size, remove cropped pixels only when later editing is not required, and avoid external links unless dependency management is part of the deployment design.

## **FAQ**

**What is the difference between a picture frame and an image resource?**

A [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) represents an image resource associated with the presentation. A [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) is a shape on a slide that displays an image and stores frame-level geometry and formatting such as size, rotation, crop values, effects, and locks.

**Should I embed or link images?**

Embed images when the presentation must be portable, archived, or rendered without access to external resources. Link images only when keeping image files outside the PPTX is intentional and the external locations can be maintained reliably.

**Does cropping reduce PPTX file size?**

Not by itself. Normal crop settings hide parts of the source image but keep the underlying pixels. Use [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) or image compression with cropped-area removal when those pixels can be discarded permanently.

**Can I restore image quality after compression?**

No. Compression can reduce stored raster resolution, and removing cropped regions discards image data. Keep the original source image outside the presentation if later high-resolution editing may be required.

**How should SVG images be handled?**

Keep SVG content as SVG when vector fidelity matters. The embedded [SvgImage](https://reference.aspose.com/slides/python-java/aspose.slides/svgimage/) can be extracted directly. Rendering a slide to a raster format such as PNG or JPEG rasterizes the SVG as part of the slide image.

**How can I avoid unsafe casts when reading existing slides?**

Check the shape type before using picture-frame-specific members. An `isinstance` check against [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) avoids invalid casts and lets the code handle slides that do not contain picture frames.
