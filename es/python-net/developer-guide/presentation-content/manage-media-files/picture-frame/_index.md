---
title: Añadir marcos de imagen a presentaciones con Python
linktitle: Marco de imagen
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
description: "Añade marcos de imagen a presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET. Optimiza tu flujo de trabajo y mejora el diseño de las diapositivas."
---
## **Introducción**

Los marcos de imagen en Aspose.Slides para Python le permiten colocar y administrar imágenes raster y vectoriales como formas nativas de diapositiva. Puede insertar imágenes desde archivos o flujos, posicionarlas y redimensionarlas con coordenadas precisas, aplicar rotación, establecer transparencia y controlar el orden Z junto a otras formas. La API también admite recorte, mantenimiento de proporciones, establecimiento de bordes y efectos, y la sustitución de la imagen subyacente sin reconstruir el diseño. Dado que los marcos de imagen se comportan como formas habituales, puede añadir animaciones, hipervínculos y texto alternativo, lo que facilita crear presentaciones visualmente ricas y accesibles.

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
Los marcos de imagen le permiten crear rápidamente diapositivas de presentación a partir de imágenes. Cuando combina los marcos de imagen con las opciones de guardado de Aspose.Slides, puede controlar las operaciones de E/S para convertir imágenes de un formato a otro. Puede que le interese consultar las siguientes páginas: convertir [image to JPG](https://products.aspose.com/slides/es/python-net/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/es/python-net/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/es/python-net/conversion/jpg-to-png/); convertir [PNG to JPG](https://products.aspose.com/slides/es/python-net/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/es/python-net/conversion/png-to-svg/); convertir [SVG to PNG](https://products.aspose.com/slides/es/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Crear marcos de imagen con escala relativa**

Esta sección demuestra cómo colocar una imagen con un tamaño fijo y, a continuación, aplicar una escala basada en porcentajes de forma independiente al ancho y al alto. Como los porcentajes pueden diferir, la relación de aspecto puede cambiar. La escala se realiza en relación con las dimensiones originales de la imagen.

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

Cuando una presentación contiene gráficos SVG ubicados dentro de formas [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/), Aspose.Slides para Python mediante .NET le permite recuperar las imágenes vectoriales originales con plena fidelidad. Al recorrer la colección de formas de la diapositiva, puede identificar cada [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/), comprobar si el [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) subyacente contiene contenido SVG y, a continuación, guardar esa imagen en disco o en un flujo en su formato SVG nativo.

El siguiente ejemplo de código muestra cómo extraer una imagen SVG de un marco de imagen:

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
Todos los efectos aplicados a imágenes se pueden encontrar en [aspose.slides.effects](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Obtener brillo y contraste de una imagen**

Aspose.Slides le permite recuperar el efecto de brillo y contraste aplicado a una imagen. La clase [Luminance](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/luminance/) representa este efecto de transformación de imagen.

Este código Python demuestra cómo obtener los ajustes de brillo y contraste de un marco de imagen:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Formato de marcos de imagen**

Aspose.Slides ofrece muchas opciones de formato que puede aplicar a un marco de imagen. Con estas opciones, puede ajustar un marco de imagen para cumplir requisitos específicos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Obtener una diapositiva por su índice.
3. Crear un [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) añadiendo la imagen a la [ImageCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/) de la presentación. Esta imagen se usará para rellenar la forma.
4. Especificar el ancho y alto del marco.
5. Crear un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) de ese tamaño mediante el método [add_picture_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_picture_frame/) de la diapositiva.
6. Establecer el color de línea del marco de imagen.
7. Establecer el ancho de línea del marco de imagen.
8. Rotar el marco de imagen proporcionando un valor positivo (horario) o negativo ( antihorario).
9. Guardar la presentación modificada como un archivo PPTX.

El siguiente código Python demuestra el proceso de formato del marco de imagen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation para representar un archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir la imagen a la colección de imágenes de la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Añadir un marco de imagen con el tamaño de la imagen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Aplicar formato al marco de imagen.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Guardar la presentación como PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose ha desarrollado una herramienta gratuita [Collage Maker](https://products.aspose.app/slides/es/collage). Si necesita [fusionar JPG/JPEG](https://products.aspose.app/slides/es/collage/jpg) o imágenes PNG, o [crear cuadrículas de fotos](https://products.aspose.app/slides/es/collage/photo-grid), puede usar este servicio.
{{% /alert %}}

## **Añadir imágenes como enlaces**

Para reducir el tamaño de los archivos de presentación, puede añadir imágenes o videos mediante enlaces en lugar de incrustar los archivos directamente en la presentación. El siguiente código Python muestra cómo insertar una imagen y un video en un marcador de posición:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Recortar imágenes**

En esta sección aprenderá a recortar el área visible de una imagen dentro de un marco de imagen sin modificar el archivo fuente. También aprenderá el método básico para aplicar márgenes de recorte y crear una composición limpia y enfocada directamente en la diapositiva.

El siguiente código Python muestra cómo recortar una imagen en una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Añadir la imagen a la colección de imágenes de la presentación.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Añadir un marco de imagen a la diapositiva.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Recortar la imagen (valores en porcentaje).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Guardar el resultado.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar áreas recortadas de imágenes**

Si desea eliminar las áreas recortadas de una imagen en un marco, use el método [delete_picture_cropped_areas](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Este método devuelve la imagen recortada, o la imagen original si no se necesita recorte.

El siguiente código Python demuestra la operación:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Obtener el PictureFrame de la primera diapositiva.
    picture_frame = slides.shape[0]

    # Obtener el PictureFrame de la primera diapositiva.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Guardar el resultado.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
El método [delete_picture_cropped_areas](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) añade la imagen recortada a la colección de imágenes de la presentación. Si la imagen se usa solo en el [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) procesado, esto puede reducir el tamaño de la presentación; de lo contrario, el número de imágenes en la presentación resultante puede aumentar.

Durante el recorte, este método convierte los metarchivos WMF/EMF a una imagen raster PNG.
{{% /alert %}}

## **Comprimir imágenes**

Puede comprimir una imagen en una presentación mediante el método [PictureFillFormat.compress_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/compress_image/).
Este método comprime una imagen reduciendo su tamaño en función del tamaño de la forma y la resolución especificada, con la opción de eliminar áreas recortadas.

Ajusta el tamaño y la resolución de la imagen de forma similar a la función **Formato de imagen → Comprimir imágenes → Resolución** de PowerPoint.

Los siguientes ejemplos Python demuestran cómo comprimir una imagen en una presentación especificando una resolución objetivo y, opcionalmente, eliminando áreas recortadas:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Comprimir la imagen con una resolución objetivo de 150 DPI (resolución web) y eliminar las áreas recortadas.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Comprobar el resultado de la compresión.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

O usando directamente un valor DPI personalizado:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Comprimir la imagen a 150 DPI (resolución web), eliminando las áreas recortadas.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
El método convierte la imagen a una resolución inferior en función del tamaño de la forma y el DPI proporcionado. Las regiones recortadas también pueden eliminarse para optimizar el tamaño del archivo.
Si la imagen es un metarchivo (WMF/EMF) o SVG, no se aplicará compresión. Además, la calidad JPEG se conserva o se reduce ligeramente según la resolución, de forma similar a cómo PowerPoint maneja los JPEG de alta resolución.
{{% /alert %}}

## **Bloquear la relación de aspecto**

Si desea que una forma que contiene una imagen mantenga su relación de aspecto después de cambiar las dimensiones de la imagen, establezca la propiedad [aspect_ratio_locked](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) en `True`.

El siguiente código Python muestra cómo bloquear la relación de aspecto de una forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Bloquear la relación de aspecto al cambiar el tamaño.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Esta configuración *Bloquear relación de aspecto* conserva solo la relación de aspecto de la forma, no la relación de aspecto de la imagen que contiene.
{{% /alert %}}

## **Usar propiedades de desplazamiento de estiramiento**

Utilizando las propiedades `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` y `stretch_offset_bottom` de la clase [PictureFillFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/), puede definir un rectángulo de relleno.

Cuando se especifica estiramiento para una imagen, el rectángulo fuente se escala para ajustarse al rectángulo de relleno. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual respecto al borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción, mientras que un porcentaje negativo indica una salida.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva por su índice.
3. Añadir una [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) rectangular.
4. Establecer el tipo de relleno de la forma.
5. Establecer el modo de relleno de imagen de la forma.
6. Cargar una imagen.
7. Asignar la imagen para rellenar la forma.
8. Especificar los desplazamientos de la imagen respecto a los bordes correspondientes del cuadro delimitador de la forma.
9. Guardar la presentación como un archivo PPTX.

El siguiente código Python demuestra cómo usar las propiedades de desplazamiento de estiramiento:

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir una AutoShape rectangular.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Establecer el tipo de relleno de la forma.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Establecer el modo de relleno de imagen de la forma.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Cargar la imagen y añadirla a la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Asignar la imagen para rellenar la forma.
    shape.fill_format.picture_fill_format.picture.image = image

    # Especificar los desplazamientos de la imagen respecto a los bordes correspondientes del cuadro delimitador de la forma.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Guardar el archivo PPTX en disco.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que le permiten crear rápidamente presentaciones a partir de imágenes.
{{% /alert %}}

## **FAQ**

**¿Cómo puedo averiguar qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides admite tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) a través del objeto de imagen asignado a un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/). La lista de formatos compatibles generalmente se superpone con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afectará la incorporación de docenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes aumenta el tamaño del archivo y el consumo de memoria; enlazar imágenes ayuda a mantener reducido el tamaño de la presentación, pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides permite añadir imágenes mediante enlace para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para que no se mueva o redimensione accidentalmente?**

Utilice los [shape locks](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/picture_frame_lock/) para un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) (por ejemplo, desactivar el movimiento o el redimensionado). El mecanismo de bloqueo se describe para formas en un artículo separado de [protección](/slides/es/python-net/applying-protection-to-presentation/) y es compatible con varios tipos de forma, incluido [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial del SVG al exportar una presentación a PDF/imagenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/python-net/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/python-net/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.