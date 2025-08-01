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
- imagen rasterizada
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
description: "Agregue marcos de imagen a las presentaciones de PowerPoint y OpenDocument con Aspose.Slides for Python via .NET. Agilice su flujo de trabajo y mejore el diseño de las diapositivas."
---

Un marco de imagen es una forma que contiene una imagen; es como una foto en un marco.

Puedes agregar una imagen a una diapositiva a través de un marco de imagen. De esta manera, puedes formatear la imagen formateando el marco de imagen.

{{% alert title="Consejo" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes.

{{% /alert %}} 

## **Crear Marco de Imagen**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) agregando una imagen a la colección [IImages](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) asociada con el objeto de presentación que se usará para llenar la forma.
4. Especifica el ancho y la altura de la imagen.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) basado en el ancho y la altura de la imagen a través del método `AddPictureFrame` expuesto por el objeto de forma asociado con la diapositiva referenciada.
6. Agrega un marco de imagen (que contiene la imagen) a la diapositiva.
7. Escribe la presentación modificada como un archivo PPTX.

Este código de Python te muestra cómo crear un marco de imagen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    # Instancia la clase ImageEx
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # Agrega un marco con la altura y el ancho equivalentes de la imagen
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # Aplica algún formato al PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # Escribe el archivo PPTX en disco
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}} 

Los marcos de imagen te permiten crear rápidamente diapositivas de presentación basadas en imágenes. Cuando combinas un marco de imagen con las opciones de guardado de Aspose.Slides, puedes manipular las operaciones de entrada/salida para convertir imágenes de un formato a otro. Tal vez quieras ver estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Crear Marco de Imagen con Escala Relativa**

Al alterar la escala relativa de una imagen, puedes crear un marco de imagen más complicado. 

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega una imagen a la colección de imágenes de la presentación.
4. Crea un objeto [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) agregando una imagen a la colección [IImages](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) asociada con el objeto de presentación que se usará para llenar la forma.
5. Especifica el ancho y la altura relativa de la imagen en el marco de imagen.
6. Escribe la presentación modificada como un archivo PPTX.

Este código de Python te muestra cómo crear un marco de imagen con escala relativa:

```py
import aspose.slides as slides

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as presentation:
    # Carga la imagen que se agregará a la colección de imágenes de la presentación
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # Agrega un marco de imagen a la diapositiva
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Establece la escala relativa de ancho y alto
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # Guarda la presentación
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraer Imagen del Marco de Imagen**

Puedes extraer imágenes de objetos [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) y guardarlas en formatos PNG, JPG y otros. El siguiente ejemplo de código demuestra cómo extraer una imagen del documento "sample.pptx" y guardarla en formato PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Obtener Transparencia de la Imagen**

Aspose.Slides te permite obtener la transparencia de una imagen. Este código de Python demuestra la operación: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    pictureFrame = presentation.slides[0].shapes[0]
    imageTransform = pictureFrame.picture_format.picture.image_transform
    for effect in imageTransform:
        if type(effect) is slides.AlphaModulateFixed:
            transparencyValue = 100 - effect.amount
            print("Transparencia de la imagen: " + str(transparencyValue))
```

## **Formateo del Marco de Imagen**

Aspose.Slides ofrece muchas opciones de formato que se pueden aplicar a un marco de imagen. Usando esas opciones, puedes alterar un marco de imagen para que se ajuste a requisitos específicos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) .
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage) agregando una imagen a la colección [IImages](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) asociada con el objeto de presentación que se usará para llenar la forma.
4. Especifica el ancho y la altura de la imagen.
5. Crea un `PictureFrame` basado en el ancho y la altura de la imagen a través del método [AddPictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) expuesto por el objeto [IShapes](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection) asociado con la diapositiva referenciada.
6. Agrega el marco de imagen (que contiene la imagen) a la diapositiva.
7. Establece el color de línea del marco de imagen.
8. Establece el ancho de línea del marco de imagen.
9. Rota el marco de imagen dándole un valor positivo o negativo.
   * Un valor positivo rota la imagen en el sentido de las agujas del reloj. 
   * Un valor negativo rota la imagen en sentido contrario a las agujas del reloj.
10. Agrega el marco de imagen (que contiene la imagen) a la diapositiva.
11. Escribe la presentación modificada como un archivo PPTX.

Este código de Python demuestra el proceso de formateo del marco de imagen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:
    # Obtiene la primera diapositiva
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

         # Agrega un marco de imagen con la altura y el ancho equivalentes de la imagen
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # Aplica algún formato al PictureFrameEx
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # Escribe el archivo PPTX en disco
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Consejo" color="primary" %}}

Aspose desarrolló recientemente un [Creador de Collages gratuito](https://products.aspose.app/slides/collage). Si alguna vez necesitas [fusionar JPG/JPEG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG, [crear cuadrículas de fotos](https://products.aspose.app/slides/collage/photo-grid), puedes usar este servicio. 

{{% /alert %}}

## **Agregar Imagen como Enlace**

Para evitar tamaños de presentación grandes, puedes agregar imágenes (o videos) a través de enlaces en lugar de incrustar los archivos directamente en las presentaciones. Este código de Python te muestra cómo agregar una imagen y un video en un marcador de posición:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapesToRemove = []

    for autoShape in presentation.slides[0].shapes:
        if autoShape.placeholder is None:
            continue
        
        if autoShape.placeholder.type == slides.PlaceholderType.PICTURE:
            pictureFrame = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE,
                    autoShape.x, autoShape.y, autoShape.width, autoShape.height, None)

            pictureFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapesToRemove.append(autoShape)

        elif autoShape.placeholder.type == slides.PlaceholderType.MEDIA:
            videoFrame = presentation.slides[0].shapes.add_video_frame(
                autoShape.X, autoShape.Y, autoShape.width, autoShape.height, "")

            videoFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            videoFrame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapesToRemove.append(autoShape)
        
    

    for shape in shapesToRemove:
        presentation.slides[0].shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Recortar Imagen**

Este código de Python te muestra cómo recortar una imagen existente en una diapositiva:

``` py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Crea un nuevo objeto de imagen
    newImage = presentation.images.add_image(slides.Images.from_file(imagePath))

    # Agrega un PictureFrame a una diapositiva
    picFrame = presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 100, 100, 420, 250, newImage)

    # Recorta la imagen (valores porcentuales)
    picFrame.picture_format.crop_left = 23.6
    picFrame.picture_format.crop_right = 21.5
    picFrame.picture_format.crop_top = 3
    picFrame.picture_format.crop_bottom = 31

    # Guarda el resultado
    presentation.save(outPptxFile, slides.export.SaveFormat.PPTX)
```

## **Eliminar Áreas Recortadas de la Imagen**

Si deseas eliminar las áreas recortadas de una imagen contenida en un marco, puedes usar el método [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/). Este método devuelve la imagen recortada o la imagen original si no es necesario recortar.

Este código de Python demuestra la operación:

```python
import aspose.slides as slides

with slides.Presentation(path + "PictureFrameCrop.pptx") as pres:
    slide = pres.slides[0]

    # Obtiene el PictureFrame de la primera diapositiva
    picture_frame = slides.shape[0]

    # Elimina las áreas recortadas de la imagen del PictureFrame y devuelve la imagen recortada
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Guarda el resultado
    pres.save(path + "PictureFrameDeleteCroppedAreas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTA" color="warning" %}} 

El método delete_picture_cropped_areas agrega la imagen recortada a la colección de imágenes de la presentación. Si la imagen se usa solo en el [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) procesado, esta configuración puede reducir el tamaño de la presentación. De lo contrario, el número de imágenes en la presentación resultante aumentará.

Este método convierte archivos metafiles WMF/EMF a imagen raster PNG en la operación de recorte. 

{{% /alert %}}

## **Bloquear Relación de Aspecto**

Si deseas que una forma que contiene una imagen mantenga su relación de aspecto incluso después de que cambies las dimensiones de la imagen, puedes usar la propiedad *aspect_ratio_locked* para establecer la configuración de *Bloquear Relación de Aspecto*. 

Este código de Python te muestra cómo bloquear la relación de aspecto de una forma: 

```python
from aspose.slides import SlideLayoutType, Presentation, ShapeType
from aspose.pydrawing import Image

with Presentation("pres.pptx") as pres:
    layout = pres.layout_slides.get_by_type(SlideLayoutType.CUSTOM)
    emptySlide = pres.slides.add_empty_slide(layout)
    image = Image.from_file("image.png")
    presImage = pres.images.add_image(image)

    pictureFrame = emptySlide.shapes.add_picture_frame(ShapeType.RECTANGLE, 50, 150, presImage.width, presImage.height, presImage)

    # establece la forma para preservar la relación de aspecto al redimensionar
    pictureFrame.picture_frame_lock.aspect_ratio_locked = True
```

{{% alert title="NOTA" color="warning" %}} 

Esta configuración de *Bloquear Relación de Aspecto* preserva solo la relación de aspecto de la forma y no de la imagen que contiene.

{{% /alert %}}

## **Usar Propiedad StretchOff**

Usando las propiedades `StretchOffsetLeft`, `StretchOffsetTop`, `StretchOffsetRight` y `StretchOffsetBottom` de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/), puedes especificar un rectángulo de relleno. 

Cuando se especifica estiramiento para una imagen, un rectángulo fuente se escala para ajustarse al rectángulo de relleno especificado. Cada borde del rectángulo de relleno se define mediante un desplazamiento porcentual desde el borde correspondiente de la caja delimitadora de la forma. Un porcentaje positivo especifica un inset mientras que un porcentaje negativo especifica un outset.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) .
2. Obtén la referencia de una diapositiva a través de su índice.
3. Agrega un rectángulo `AutoShape`. 
4. Crea una imagen.
5. Establece el tipo de relleno de la forma.
6. Establece el modo de relleno de imagen de la forma.
7. Agrega una imagen establecida para llenar la forma.
8. Especifica los desplazamientos de la imagen desde el borde correspondiente de la caja delimitadora de la forma.
9. Escribe la presentación modificada como un archivo PPTX.

Este código de Python demuestra un proceso en el que se usa una propiedad StretchOff:

```py
import aspose.slides as slides

# Instancia la clase Presentation que representa un archivo PPTX
with slides.Presentation() as pres:

    # Obtiene la primera diapositiva
    slide = pres.slides[0]

    # Instancia la clase ImageEx
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # Agrega un marco de imagen con la altura y el ancho equivalentes de la imagen
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # Establece el tipo de relleno de la forma
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # Establece el modo de relleno de imagen de la forma
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # Establece la imagen para llenar la forma
        shape.fill_format.picture_fill_format.picture.image = imgx

        # Especifica los desplazamientos de la imagen desde el borde correspondiente de la caja delimitadora de la forma
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # Escribe el archivo PPTX en disco
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```