---
title: Enhance Image Processing with the Modern API in Python
linktitle: Modern API
type: docs
weight: 237
url: /python-java/modern-api/
keywords:
- modern API
- drawing
- slide thumbnail
- slide to image
- shape thumbnail
- shape to image
- presentation thumbnail
- presentation to images
- add image
- add picture
- Python
- Java
- Aspose.Slides
description: "Modernize image processing in Python via Java: render slides and shapes, add pictures, and migrate deprecated imaging calls to the Aspose.Slides Modern API."
---

## **Introduction**

Aspose.Slides for Python via Java accesses the Java library through JPype. Its legacy image-processing API used [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) and [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) from `java.awt`.

The Java library deprecated these imaging APIs starting with version 24.4. The Modern API uses [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/) to load, render, and save images. Use it for new Python code and when migrating existing image-processing workflows.

{{% alert color="info" title="Note" %}}

The old method names below are migration references. They are no longer available in current releases. The executable examples use the Modern API.

This change does not eliminate every `java.awt` type: image-size and pattern-color overloads still accept [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) and [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

{{% /alert %}}

## **Modern API**

The main image-processing types are:

- [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/) — represents a raster or vector image.
- [ImageFormat](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/) — provides image file format constants.
- [Images](https://reference.aspose.com/slides/python-java/aspose.slides/images/) — creates images, for example with [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile).

Use [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) or [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) to render one slide or shape. Use [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) with rendering options to render multiple slides. The overload with no arguments returns the presentation's image collection instead.

Load an image with [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), add it with [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage), or update an existing presentation image with [PPImage.replaceImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/#replaceImage). Both image-collection operations accept [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/).

Release each image you load or render by calling its `dispose` method in a `finally` block. Release the presentation with [Presentation.dispose](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#dispose).

### **Prepare the Python Environment**

Install the packages as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running. The examples leave the JVM running so it can be reused. See [Limitations and API Differences](/slides/python-java/limitations-and-api-differences/#import-the-library) for notebook and JVM lifecycle guidance.

Examples that open `pres.pptx` require a presentation in the working directory. Examples that load `image.png` require an existing image file.

### **Load a Picture and Render a Slide**

This example adds a picture to the first slide and saves the slide as a JPEG image. [IImage.save](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/#save) writes the rendered image in the specified format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Replacing Old Code with Modern API**

Replace legacy thumbnail calls with methods that return [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/), then save the result with [IImage.save](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/#save). This removes the need to pass rendered images to [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Render a Slide at a Specified Size**

Replace the legacy `slide.getThumbnail(image_size)` call with [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) using the same image size.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Getting a Slide Thumbnail**

Replace the legacy `slide.getThumbnail()` call with [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) without arguments.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Getting a Shape Thumbnail**

Replace the legacy `shape.getThumbnail()` call with [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage). Check that the slide contains a shape before accessing it.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Getting a Presentation Thumbnail**

Replace the legacy `presentation.getThumbnails(options, image_size)` call with [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages). Use [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) to configure rendering.

Iterate over the returned array directly with Python's `enumerate`. Dispose of every returned image in a `finally` block so that a save failure does not leave the remaining images undisposed.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Adding a Picture to a Presentation**

Replace loading through [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) with [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), then pass the resulting image to [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Add the picture to the slide and save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Deprecated Methods and Their Replacement in Modern API**

The tables use Python call notation. Names in the legacy column identify removed APIs; use the linked replacement methods. The modern image-rendering methods return [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/) objects instead of Java buffered images.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) returns an array of rendered images when called with rendering options.

| Legacy call | Modern replacement |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) with `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) with `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) with `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) with `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) with `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) with `options, image_size` |

Here, `slides` is a Java `int[]` of one-based slide numbers; create it with `jpype.JArray(jpype.JInt)([1, 3])` to select slides 1 and 3. `image_size` is a [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Legacy call | Modern replacement |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) with no arguments |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) with `bounds, scale_x, scale_y` |

### **Slide**

| Legacy call | Modern replacement |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) with no arguments |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) with `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) with `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) with `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) with `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) with `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) with `image_size` |
| `slide.renderToGraphics(options, graphics)` | No direct replacement; render to an image instead |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | No direct replacement; render to an image instead |
| `slide.renderToGraphics(options, graphics, image_size)` | No direct replacement; render to an image instead |

Here, `options` is [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/), and `tiff_options` is [TiffOptions](https://reference.aspose.com/slides/python-java/aspose.slides/tiffoptions/).

### **Output**

| Legacy call | Modern replacement |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/python-java/aspose.slides/output/#add) with `path, image`, where `image` is [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Legacy call | Modern replacement |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) with an [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/) |

### **PPImage**

| Legacy call | Modern replacement |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/#getImage) |

To replace the contents of an existing presentation image, use [PPImage.replaceImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/#replaceImage) with an [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Legacy call | Modern replacement |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getTile) with `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getTile) with `background, foreground` |

The color arguments remain Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) objects.

### **PatternFormatEffectiveData**

For effective pattern data returned by the Java API through JPype, the replacement method retains the name `getTileIImage`.

| Legacy call | Modern replacement |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, returning [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/) |

## **API Support for Graphics2D**

The legacy `renderToGraphics` overloads drew into a caller-supplied [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) context. The Modern API has no direct replacement that draws into that context.

Use [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) to render a slide or [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) to render several slides, then save the returned images with [IImage.save](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/#save). Applications that combined slide rendering with custom Java drawing need to adapt their compositing step.

## **FAQ**

**Why was the old Java imaging API replaced?**

The Modern API moves image loading, rendering, and saving to [IImage](https://reference.aspose.com/slides/python-java/aspose.slides/iimage/). This gives these workflows a common image abstraction instead of exposing Java buffered images or a Java graphics context.

**Do I still need Java and JPype?**

Yes. Aspose.Slides for Python via Java still runs on the JVM. The Modern API changes image-processing calls, not the runtime requirements. See [System Requirements](/slides/python-java/system-requirements/).

**How do I release images in Python?**

Call `dispose` on each image you load or render in a `finally` block. If you render several slides, release every image in the returned array. Dispose of the presentation separately with [Presentation.dispose](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#dispose).

**Does switching to the Modern API guarantee faster thumbnail generation?**

No performance improvement is guaranteed. The replacements support rendering options, scaling, and image sizes; measure performance with your presentations and output settings.

**Why does the image getter sometimes return a collection?**

[Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) without arguments returns embedded presentation images. Its overloads with rendering options return rendered slide images.

