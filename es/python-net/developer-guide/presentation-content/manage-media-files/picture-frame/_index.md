---
title: Agregar marcos de imagen a presentaciones con Python
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/python-net/picture-frame/
keywords:
- marco de imagen
- agregar marco de imagen
- crear marco de imagen
- agregar imagen
- crear imagen
- extraer imagen
- imagen raster
- imagen vectorial
- recortar imagen
- área recortada
- propiedad StretchOff
- formateo de marco de imagen
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
description: "Agregue marcos de imagen a presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET. Optimice su flujo de trabajo y mejore el diseño de diapositivas."
---

## **Visión general**

Los marcos de imagen en Aspose.Slides para Python le permiten colocar y administrar imágenes raster y vectoriales como formas nativas de diapositiva. Puede insertar imágenes desde archivos o flujos, posicionarlas y redimensionarlas con coordenadas precisas, aplicar rotación, establecer transparencia y controlar el orden Z junto a otras formas. La API también admite recorte, mantenimiento de relaciones de aspecto, configuración de bordes y efectos, y sustitución de la imagen subyacente sin reconstruir el diseño. Dado que los marcos de imagen se comportan como formas normales, puede agregar animaciones, hipervínculos y texto alternativo, lo que facilita la creación de presentaciones visualmente ricas y accesibles.

## **Crear marcos de imagen**

Esta sección muestra cómo insertar una imagen en una diapositiva creando un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) con Aspose.Slides para Python. Aprenderá a cargar la imagen, colocarla con precisión en la diapositiva y controlar su tamaño y formato.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una diapositiva por su índice.
3. Crear un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) agregando la imagen a la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la presentación. Esta imagen se usará para rellenar la forma.
4. Especificar el ancho y alto del marco.
5. Crear un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) de ese tamaño usando el método [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Guardar la presentación como archivo PPTX.

El siguiente código Python muestra cómo crear un marco de imagen:

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar un archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar la imagen a la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Agregar un marco de imagen con el tamaño de la imagen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Guardar la presentación como PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Los marcos de imagen le permiten crear rápidamente diapositivas de presentación a partir de imágenes. Cuando combina los marcos de imagen con las opciones de guardado de Aspose.Slides, puede controlar las operaciones de E/S para convertir imágenes de un formato a otro. Puede que desee visitar estas páginas: convertir [image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); convertir [PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); convertir [SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Crear marcos de imagen con escala relativa**

Esta sección demuestra cómo colocar una imagen con un tamaño fijo y luego aplicar un escalado basado en porcentajes de forma independiente para su ancho y alto. Como los porcentajes pueden diferir, la relación de aspecto puede cambiar. El escalado se realiza en relación con las dimensiones originales de la imagen.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una diapositiva por su índice.
3. Crear un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) agregando la imagen a la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la presentación.
4. Agregar un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) a la diapositiva.
5. Establecer el ancho y alto relativos del marco de imagen.
6. Guardar la presentación como archivo PPTX.

El siguiente código Python muestra cómo crear un marco de imagen con escala relativa:

```py
import aspose.slides as slides

# Instanciar la clase Presentation para representar un archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar la imagen a la colección de imágenes de la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Agregar un marco de imagen a la diapositiva.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Establecer la escala relativa de ancho y alto.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Guardar la presentación.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraer imágenes raster de marcos de imagen**

Puede extraer imágenes raster de objetos [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) y guardarlas en PNG, JPG y otros formatos. El ejemplo de código a continuación muestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

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

Cuando una presentación contiene gráficos SVG colocados dentro de formas [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), Aspose.Slides para Python mediante .NET le permite recuperar las imágenes vectoriales originales con total fidelidad. Al recorrer la colección de formas de la diapositiva, puede identificar cada [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), verificar si la [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) subyacente contiene contenido SVG y luego guardar esa imagen en disco o en un flujo en su formato SVG nativo.

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

Aspose.Slides le permite recuperar el efecto de transparencia aplicado a una imagen. Este código Python muestra la operación:

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
Todos los efectos aplicados a imágenes pueden encontrarse en [aspose.slides.effects](https://reference.aspose.com/slides/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Formateo de marcos de imagen**

Aspose.Slides proporciona muchas opciones de formateo que puede aplicar a un marco de imagen. Con estas opciones, puede ajustar un marco de imagen para cumplir requisitos específicos.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una diapositiva por su índice.
3. Crear un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) agregando la imagen a la [ImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) de la presentación. Esta imagen se usará para rellenar la forma.
4. Especificar el ancho y alto del marco.
5. Crear un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) de ese tamaño usando el método [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) de la diapositiva.
6. Establecer el color de línea del marco de imagen.
7. Establecer el ancho de línea del marco de imagen.
8. Rotar el marco de imagen proporcionando un valor positivo (sentido horario) o negativo (sentido antihorario).
9. Guardar la presentación modificada como archivo PPTX.

El siguiente código Python demuestra el proceso de formateo del marco de imagen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation para representar un archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar la imagen a la colección de imágenes de la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Agregar un marco de imagen con el tamaño de la imagen.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Aplicar formateo al marco de imagen.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Guardar la presentación como PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose ha desarrollado un creador de collages gratuito ([Collage Maker](https://products.aspose.app/slides/collage)). Si necesita [combinar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, o [crear cuadrículas de fotos](https://products.aspose.app/slides/collage/photo-grid), puede usar este servicio.
{{% /alert %}}

## **Agregar imágenes como enlaces**

Para mantener los archivos de presentación pequeños, puede agregar imágenes o videos mediante enlaces en lugar de incrustar los archivos directamente en las presentaciones. El siguiente código Python muestra cómo insertar una imagen y un video en un marcador de posición:

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

En esta sección aprenderá cómo recortar el área visible de una imagen dentro de un marco de imagen sin alterar el archivo original. También aprenderá el método básico para aplicar márgenes de recorte y crear una composición limpia y enfocada directamente en la diapositiva.

El siguiente código Python muestra cómo recortar una imagen en una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar la imagen a la colección de imágenes de la presentación.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Agregar un marco de imagen a la diapositiva.
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

Si desea eliminar las áreas recortadas de una imagen en un marco, use el método [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Este método devuelve la imagen recortada, o la imagen original si no se necesita recorte.

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
El método [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen se utiliza solo en el [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) procesado, esto puede reducir el tamaño de la presentación; de lo contrario, el número de imágenes en la presentación resultante podría aumentar.

Durante el recorte, este método convierte metarchivos WMF/EMF a una imagen PNG raster.
{{% /alert %}}

## **Bloquear la relación de aspecto**

Si desea que una forma que contiene una imagen mantenga su relación de aspecto después de cambiar las dimensiones de la imagen, establezca la propiedad [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) en `True`.

El siguiente código Python muestra cómo bloquear la relación de aspecto de una forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Bloquear la relación de aspecto al redimensionar.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Esta configuración *Bloquear relación de aspecto* conserva solo la relación de aspecto de la forma, no la relación de aspecto de la imagen que contiene.
{{% /alert %}}

## **Usar propiedades de desplazamiento de estiramiento**

Usando las propiedades `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` y `stretch_offset_bottom` de la clase [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/), puede definir un rectángulo de relleno.

Cuando se especifica el estiramiento para una imagen, el rectángulo de origen se escala para ajustarse al rectángulo de relleno. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual desde el borde correspondiente del cuadro delimitador de la forma. Un porcentaje positivo indica una inserción, mientras que un porcentaje negativo indica una salida.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva por su índice.
3. Agregar una [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) rectangular.
4. Establecer el tipo de relleno de la forma.
5. Establecer el modo de relleno de imagen de la forma.
6. Cargar una imagen.
7. Asignar la imagen para rellenar la forma.
8. Especificar los desplazamientos de la imagen desde los bordes correspondientes del cuadro delimitador de la forma.
9. Guardar la presentación como archivo PPTX.

El siguiente código Python muestra cómo usar las propiedades de desplazamiento de estiramiento:

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:
    # Obtener la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar una AutoShape rectangular.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Establecer el tipo de relleno de la forma.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Establecer el modo de relleno de imagen de la forma.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Cargar la imagen y agregarla a la presentación.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Asignar la imagen para rellenar la forma.
    shape.fill_format.picture_fill_format.picture.image = image

    # Especificar los desplazamientos de la imagen desde los bordes correspondientes del cuadro delimitador de la forma.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Guardar el archivo PPTX en disco.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que le permiten crear rápidamente presentaciones a partir de imágenes.
{{% /alert %}}

## **FAQ**

**¿Cómo puedo averiguar qué formatos de imagen son compatibles con PictureFrame?**

Aspose.Slides admite tanto imágenes raster (PNG, JPEG, BMP, GIF, etc.) como imágenes vectoriales (por ejemplo, SVG) a través del objeto de imagen asignado a un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). La lista de formatos compatibles generalmente se superpone con las capacidades del motor de conversión de diapositivas e imágenes.

**¿Cómo afecta la incorporación de docenas de imágenes grandes al tamaño y rendimiento del PPTX?**

Incrustar imágenes grandes incrementa el tamaño del archivo y el uso de memoria; enlazar imágenes ayuda a mantener bajo el tamaño de la presentación pero requiere que los archivos externos permanezcan accesibles. Aspose.Slides permite agregar imágenes mediante enlaces para reducir el tamaño del archivo.

**¿Cómo puedo bloquear un objeto de imagen para que no se mueva o redimensione accidentalmente?**

Utilice los [bloqueos de forma](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/picture_frame_lock/) para un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) (por ejemplo, desactivar el movimiento o el redimensionamiento). El mecanismo de bloqueo se describe para formas en un artículo de protección separado (/slides/es/python-net/applying-protection-to-presentation/) y es compatible con varios tipos de forma, incluido [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).

**¿Se conserva la fidelidad vectorial SVG al exportar una presentación a PDF/imágenes?**

Aspose.Slides permite extraer un SVG de un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) como el vector original. Al [exportar a PDF](/slides/es/python-net/convert-powerpoint-to-pdf/) o a [formatos raster](/slides/es/python-net/convert-powerpoint-to-png/), el resultado puede rasterizarse según la configuración de exportación; el hecho de que el SVG original se almacene como vector se confirma mediante el comportamiento de extracción.