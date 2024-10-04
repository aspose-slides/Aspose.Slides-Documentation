---
title: API Moderna
type: docs
weight: 280
url: /python-net/modern-api/
keywords: "API Moderna, Dibujo"
description: "API Moderna"
---

## Introducción

Actualmente, la biblioteca Aspose.Slides para Python a través de .NET tiene dependencias en su API pública en las siguientes clases de `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

A partir de la versión 24.4, esta API pública se declara obsoleta debido a [cambios](https://releases.aspose.com/slides/net/release-notes/2024/aspose-slides-for-net-24-4-release-notes/#introducing-a-new-modern-api) en la API pública de Aspose.Slides para .NET.

Con el fin de deshacerse de las dependencias en `aspose.pydrawing` en la API pública, añadimos la llamada "API Moderna". Los métodos con `aspose.pydrawing.Image` y `aspose.pydrawing.Bitmap` se declaran obsoletos y serán reemplazados por los métodos correspondientes de la API Moderna. Los métodos con `aspose.pydrawing.Graphics` se declaran obsoletos y su soporte será eliminado de la API pública.

La eliminación de la API pública obsoleta con dependencias en `aspose.pydrawing` se realizará en la versión 24.8.

## API Moderna

Se añadieron las siguientes clases y enums a la API pública:

- [`aspose.slides.IImage`](https://reference.aspose.com/slides/python-net/aspose.slides/iimage) - representa la imagen raster o vectorial.
- [`aspose.slides.ImageFormat`](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat) - representa el formato de archivo de la imagen.
- [`aspose.slides.Images`](https://reference.aspose.com/slides/python-net/aspose.slides/images) - métodos para instanciar y trabajar con la interfaz `IImage`.

Un escenario típico de uso de la nueva API puede verse así:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
    with pres.slides[0].get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## Reemplazando el código antiguo con la API Moderna

Para facilitar la transición, la interfaz del nuevo `IImage` repite las firmas separadas de las clases `Image` y `Bitmap`. En general, solo necesitarás reemplazar la llamada al antiguo método utilizando `aspose.pydrawing` con el nuevo.

### Obtener una miniatura de diapositiva

Código usando una API obsoleta:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].get_thumbnail().save("slide1.png")
```

API Moderna:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].get_image() as image:
        image.save("slide1.png")
```

### Obtener una miniatura de forma

Código usando una API obsoleta:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    pres.slides[0].shapes[0].get_thumbnail().save("shape.png")
```

API Moderna:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with pres.slides[0].shapes[0].get_image() as image:
        image.save("shape.png")
```

### Obtener una miniatura de presentación

Código usando una API obsoleta:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", drawing.imaging.ImageFormat.png)
```

API Moderna:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    thumbnails = pres.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for idx, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{idx}.png", slides.ImageFormat.PNG)
```

### Agregar una imagen a una presentación

Código usando una API obsoleta:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as pres:
    image = drawing.Image.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

API Moderna:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = slides.Images.from_file("image.png")
    pp_image = pres.images.add_image(image)
    pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10.0, 10.0, 100.0, 100.0, pp_image)
```

## Métodos/propiadades que se eliminarán y su reemplazo en la API Moderna

### Clase Presentation
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|Será eliminado completamente|
|save(fname, format, options, response, show_inline)|Será eliminado completamente|
|print()|Será eliminado completamente|
|print(printer_settings)|Será eliminado completamente|
|print(printer_name)|Será eliminado completamente|
|print(printer_settings, pres_name)|Será eliminado completamente|

### Clase Slide
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOotions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Será eliminado completamente|
|render_to_graphics(options, graphics, scale_x, scale_y)|Será eliminado completamente|
|render_to_graphics(options, graphics, rendering_size)|Será eliminado completamente|

### Clase Shape
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### Clase ImageCollection
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### Clase PPImage
|Firma del Método/Propiedad|Firma del Método/Propiedad de Reemplazo|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/image/)|

### Clase ImageWrapperFactory
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### Clase PatternFormat
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### Clase IPatternFormatEffectiveData
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### Clase Output
|Firma del Método|Firma del Método de Reemplazo|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## El soporte de la API para `aspose.pydrawing.Graphics` será descontinuado

Los métodos con `aspose.pydrawing.Graphics` se declaran obsoletos y su soporte será eliminado de la API pública.

La parte de la API que los utiliza será eliminada:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`