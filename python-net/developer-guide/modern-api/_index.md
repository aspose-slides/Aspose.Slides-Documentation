---
title: Modern API
type: docs
weight: 280
url: /python-net/modern-api/
keywords: "Modern API, Drawing"
description: "Modern API"
---

## Introduction

Currently, the Aspose.Slides for Python via .NET library has dependencies in its public API on the following classes from `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

As of version 24.4, this public API is declared deprecated due to [changes](https://releases.aspose.com/slides/net/release-notes/2024/aspose-slides-for-net-24-4-release-notes/#introducing-a-new-modern-api) in the Aspose.Slides for .NET public API.

In order to get rid of dependencies on `aspose.pydrawing` in the public API, we added the so-called "Modern API". Methods with `aspose.pydrawing.Image` and `aspose.pydrawing.Bitmap` are declared deprecated and will be replaced with the corresponding methods from the Modern API. Methods with `aspose.pydrawing.Graphics` are declared deprecated and their support will be removed from the public API.

Removal of the deprecated public API with dependencies on `aspose.pydrawing` will be in release 24.8.

## Modern API

Added the following classes and enums to the public API:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage) - represents the raster or vector image.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat) - represents the file format of the image.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images) - methods to instantiate and work with the `IImage` interface.

A typical scenario of using the new API may look as follows:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
    slide_image = pres.slides[0].get_image(drawing.Size(1920, 1080))
    slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## Replacing old code with Modern API

For ease of transition, the interface of the new `IImage` repeats the separate signatures of the `Image` and `Bitmap` classes. In general, you will just need to replace the call to the old method using `aspose.pydrawing` with the new one.

### Getting a slide thumbnail

Code using a deprecated API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].get_thumbnail().save("slide1.png")
```

Modern API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].get_image().save("slide1.png")
```

### Getting a shape thumbnail

Code using a deprecated API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].shapes[0].get_thumbnail().save("shape.png")
```

Modern API:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].shapes[0].get_image().save("shape.png")
```

### Getting a presentation thumbnail

Code using a deprecated API:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", drawing.imaging.ImageFormat.png)
```

Modern API:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", slides.ImageFormat.PNG)
```

### Adding a picture to a presentation

Code using a deprecated API:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = drawing.Image.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

Modern API:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

## Methods/properties to be removed and their replacement in Modern API

### Presentation Class
|Method Signature|Replacement Method Signature|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Will be deleted completely|
|save(fname, format, options, response, show_inline)|Will be deleted completely|
|print()|Will be deleted completely|
|print(printer_settings)|Will be deleted completely|
|print(printer_name)|Will be deleted completely|
|print(printer_settings, pres_name)|Will be deleted completely|

### Slide Class
|Method Signature|Replacement Method Signature|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Will be deleted completely|
|render_to_graphics(options, graphics, scale_x, scale_y)|Will be deleted completely|
|render_to_graphics(options, graphics, rendering_size)|Will be deleted completely|

### Shape Class
|Method Signature|Replacement Method Signature|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### ImageCollection Class
|Method Signature|Replacement Method Signature|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### PPImage Class
|Method/Property Signature|Replacement Method/Property Signature|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### ImageWrapperFactory Class
|Method Signature|Replacement Method Signature|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### PatternFormat Class
|Method Signature|Replacement Method Signature|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### IPatternFormatEffectiveData Class
|Method Signature|Replacement Method Signature|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### Output Class
|Method Signature|Replacement Method Signature|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## API support for `aspose.pydrawing.Graphics` will be discontinued

Methods with `aspose.pydrawing.Graphics` are declared deprecated and their support will be removed from the public API.

The part of the API that uses it will be removed:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`
