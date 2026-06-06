---
title: Mejorar el procesamiento de imágenes con la API Moderna
linktitle: API Moderna
type: docs
weight: 280
url: /es/python-net/modern-api/
keywords:
- API moderna
- dibujo
- miniatura de diapositiva
- diapositiva a imagen
- miniatura de forma
- forma a imagen
- miniatura de presentación
- presentación a imágenes
- añadir imagen
- añadir foto
- Python
- Aspose.Slides
description: "Moderniza el procesamiento de imágenes de diapositivas sustituyendo las API de imágenes obsoletas por la API Moderna de Python para una automatización fluida de PowerPoint y OpenDocument."
---
## **Introducción**

La API pública de Aspose.Slides para Python depende actualmente de los siguientes tipos `aspose.pydrawing`:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

A partir de la versión 24.4, esta API pública está **obsoleta** debido a [cambios](https://releases.aspose.com/slides/es/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) en la API pública de Aspose.Slides para Python.

Para eliminar `aspose.pydrawing` de la API pública, introdujimos la **API Moderna**. Los métodos que utilizan `aspose.pydrawing.Image` y `aspose.pydrawing.Bitmap` están obsoletos y deben reemplazarse por sus equivalentes de la API Moderna. Los métodos que utilizan `aspose.pydrawing.Graphics` están obsoletos y no tienen un reemplazo directo en la API Moderna.

En las versiones actuales, considere la API pública que depende de `aspose.pydrawing` como heredada/obsoleta. Use la API Moderna para código nuevo y al migrar flujos de trabajo de procesamiento de imágenes existentes.

## **API Moderna**

Se han añadido las siguientes clases y enumeraciones a la API pública:

- [aspose.slides.IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) - representa una imagen raster o vectorial.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/imageformat/) - representa un formato de archivo de imagen.
- [aspose.slides.Images](https://reference.aspose.com/slides/es/python-net/aspose.slides/images/) - proporciona métodos para crear y trabajar con [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/).

Utilice `get_image` para renderizar una sola diapositiva o forma. Utilice `get_images` para renderizar varias diapositivas de la presentación. Utilice los métodos de [Images](https://reference.aspose.com/slides/es/python-net/aspose.slides/images/) para cargar imágenes, `add_image` con [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) para añadirlas a una presentación, y `replace_image` con [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) para actualizar una imagen existente de la presentación.

Un escenario típico de uso de la nueva API se ve así:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Reemplazar el código antiguo con la API Moderna**

Para una transición más fácil, la nueva clase [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) refleja las APIs separadas de las clases `aspose.pydrawing.Image` y `aspose.pydrawing.Bitmap`. En la mayoría de los casos, solo necesita reemplazar las llamadas a los métodos que utilizan `aspose.pydrawing` por sus equivalentes de la API Moderna.

### **Obtener una miniatura de diapositiva**

**API obsoleta:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Obtener una miniatura de forma**

**API obsoleta:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Obtener una miniatura de presentación**

**API obsoleta:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**API Moderna:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Agregar una imagen a una presentación**

**API obsoleta:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**API Moderna:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Métodos y propiedades que se eliminarán y sus reemplazos Modernos**

### **Clase Presentation**

|Firma del método|Firma del método de reemplazo|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingsize)|
|save(fname, format, response, show_inline)|No Modern API replacement|
|save(fname, format, options, response, show_inline)|No Modern API replacement|
|print()|No Modern API replacement|
|print(printer_settings)|No Modern API replacement|
|print(printer_name)|No Modern API replacement|
|print(printer_settings, pres_name)|No Modern API replacement|

### **Clase Slide**

|Firma del método|Firma del método de reemplazo|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingssize)|
|render_to_graphics(options, graphics)|No Modern API replacement|
|render_to_graphics(options, graphics, scale_x, scale_y)|No Modern API replacement|
|render_to_graphics(options, graphics, rendering_size)|No Modern API replacement|

### **Clase Shape**

|Firma del método|Firma del método de reemplazo|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **Clase ImageCollection**

|Firma del método|Firma del método de reemplazo|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **Clase PPImage**

|Firma del método/propiedad|Firma del método/propiedad de reemplazo|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/image/)|

### **Clase ImageWrapperFactory**

|Firma del método|Firma del método de reemplazo|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **Clase PatternFormat**

|Firma del método|Firma del método de reemplazo|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/es/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/es/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **Clase IPatternFormatEffectiveData**

|Firma del método|Firma del método de reemplazo|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/es/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Clase Output**

|Firma del método|Firma del método de reemplazo|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Compatibilidad de la API con aspose.pydrawing.Graphics**

Los métodos que utilizan `aspose.pydrawing.Graphics` están obsoletos y no tienen un reemplazo directo en la API Moderna.

Utilice los métodos de renderizado de imágenes de la API Moderna en lugar de la API que renderiza a `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **Preguntas frecuentes**

**¿Por qué se eliminó `aspose.pydrawing.Graphics`?**

El soporte para `aspose.pydrawing.Graphics` está obsoleto en la API pública para unificar el trabajo con renderizado e imágenes, eliminar dependencias específicas de plataforma y pasar a un enfoque multiplataforma con [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/). Utilice `get_image` o `get_images` en lugar de renderizar a `aspose.pydrawing.Graphics`.

**¿Cuál es el beneficio práctico de [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) comparado con `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) unifica el trabajo con imágenes raster y vectoriales, simplifica el guardado en varios formatos mediante [ImageFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/imageformat/), reduce la dependencia de pydrawing y hace que el código sea más portable entre entornos.

**¿Afectará la API Moderna al rendimiento de la generación de miniaturas?**

Cambiar de `get_thumbnail` a `get_image` no empeora los escenarios: los nuevos métodos ofrecen las mismas capacidades para producir imágenes con opciones y tamaños, manteniendo el soporte para las opciones de renderizado. La ganancia o pérdida específica depende del caso, pero funcionalmente los reemplazos son equivalentes.