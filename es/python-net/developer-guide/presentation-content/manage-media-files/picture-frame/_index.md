---
title: "Añadir marcos de imagen a presentaciones con Python"
linktitle: "Marco de imagen"
type: docs
weight: 10
url: /es/python-net/picture-frame/
keywords:
  - marco de imagen
  - añadir marco de imagen
  - crear marco de imagen
  - añadir imagen
  - crear imagen
  - extraer imagen
  - imagen raster
  - imagen vectorial
  - recortar imagen
  - área recortada
  - propiedad StretchOff
  - formato de marco de imagen
  - propiedades del marco de imagen
  - escala relativa
  - efecto de imagen
  - relación de aspecto
  - transparencia de imagen
  - PowerPoint
  - OpenDocument
  - presentación
  - Python
  - Aspose.Slides
description: "Añade marcos de imagen a presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET. Optimiza tu flujo de trabajo y mejora el diseño de las diapositivas."
---
## **Introducción**

Los marcos de imagen en Aspose.Slides para Python le permiten colocar y gestionar imágenes raster y vectoriales como formas nativas de diapositiva. Puede insertar imágenes desde archivos o flujos, posicionarlas y redimensionarlas con coordenadas precisas, aplicar rotación, establecer transparencia y controlar el orden Z junto a otras formas. La API también admite recorte, mantenimiento de relaciones de aspecto, configuración de bordes y efectos, y reemplazo de la imagen subyacente sin reconstruir el diseño. Dado que los marcos de imagen se comportan como formas normales, puede añadir animaciones, hipervínculos y texto alternativo, facilitando la creación de presentaciones visualmente ricas y accesibles.

## **Crear marcos de imagen**

Esta sección muestra cómo insertar una imagen en una diapositiva creando un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) con Aspose.Slides para Python. Aprenderá a cargar la imagen, colocarla con precisión en la diapositiva y controlar su tamaño y formato.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Obtener una diapositiva por su índice.
3. Crear un [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) añadiendo la imagen a la [ImageCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/) de la presentación. Esta imagen se usará para rellenar la forma.
4. Especificar el ancho y alto del marco.
5. Crear un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) de ese tamaño mediante el método [add_picture_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Guardar la presentación como un archivo PPTX.

El siguiente código Python muestra cómo crear un marco de imagen:

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar un archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir la imagen a la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Añadir un marco de imagen con el tamaño de la imagen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Guardar la presentación como PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Los marcos de imagen le permiten crear rápidamente diapositivas de presentación a partir de imágenes. Cuando combina los marcos de imagen con las opciones de guardado de Aspose.Slides, puede controlar las operaciones de E/S para convertir imágenes de un formato a otro. Puede que le interesen estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/python-net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/es/python-net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/es/python-net/conversion/jpg-to-png/); convertir [PNG a JPG](https://products.aspose.com/slides/es/python-net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/es/python-net/conversion/png-to-svg/); convertir [SVG a PNG](https://products.aspose.com/slides/es/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Crear marcos de imagen con escala relativa**

Esta sección demuestra cómo colocar una imagen con un tamaño fijo y luego aplicar una escala basada en porcentajes de forma independiente a su ancho y alto. Dado que los porcentajes pueden diferir, la relación de aspecto puede cambiar. El escalado se realiza relativo a las dimensiones originales de la imagen.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Obtener una diapositiva por su índice.
3. Crear un [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) añadiendo la imagen a la [ImageCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/) de la presentación.
4. Añadir un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) a la diapositiva.
5. Establecer el ancho y alto relativos del marco de imagen.
6. Guardar la presentación como un archivo PPTX.

El siguiente código Python muestra cómo crear un marco de imagen con escala relativa:

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar un archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir la imagen a la colección de imágenes de la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Añadir un marco de imagen a la diapositiva.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Establecer la escala relativa de ancho y alto.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Guardar la presentación.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraer imágenes raster de marcos de imagen**

Puede extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación demuestra cómo extraer una imagen del documento “sample.pptx” y guardarla en formato PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Extraer imágenes SVG de marcos de imagen**

Cuando una presentación contiene gráficos SVG ubicados dentro de formas [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/), Aspose.Slides para Python mediante .NET le permite recuperar las imágenes vectoriales originales con plena fidelidad. Al recorrer la colección de formas de la diapositiva, puede identificar cada [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/), comprobar si el [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) subyacente contiene contenido SVG y luego guardar esa imagen en disco o en un flujo en su formato SVG nativo.

El siguiente ejemplo de código demuestra cómo extraer una imagen SVG de un marco de imagen:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Obtener la transparencia de la imagen**

Aspose.Slides le permite recuperar el efecto de transparencia aplicado a una imagen. Este código Python demuestra la operación:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Todos los efectos aplicados a las imágenes pueden encontrarse en [aspose.slides.effects](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Formato de marcos de imagen**

Aspose.Slides ofrece muchas opciones de formato que puede aplicar a un marco de imagen. Con estas opciones, puede ajustar un marco de imagen para cumplir requisitos específicos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Obtener una diapositiva por su índice.
3. Crear un [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) añadiendo la imagen a la [ImageCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/) de la presentación. Esta imagen se usará para rellenar la forma.
4. Especific