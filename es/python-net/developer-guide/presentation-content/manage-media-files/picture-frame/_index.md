---
title: Gestionar marcos de imágenes en presentaciones con Python
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/python-net/picture-frame/
keywords:
- marco de imagen
- agregar marco de imagen
- crear marco de imagen
- imagen incrustada
- imagen vinculada
- extraer imagen
- imagen raster
- imagen SVG
- recortar imagen
- eliminar áreas recortadas
- comprimir imagen
- StretchOffset
- formato de marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Crear, formatear, vincular, recortar, extraer y comprimir marcos de imágenes en presentaciones con Aspose.Slides para Python a través de .NET."
---
## **Visión general**

Un *picture frame* es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) posee recursos de imagen incrustados a través de su [ImageCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/), mientras que un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) controla la posición, tamaño, formato de línea, rotación, recorte, efectos de imagen y otras configuraciones a nivel de marco.

Esta separación es útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, mantenga el [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) devuelto y use ese recurso de imagen al crear *picture frames*.

Los *picture frames* pueden contener imágenes raster como PNG o JPEG e imágenes vectoriales SVG. También pueden referirse a imágenes vinculadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo se debe almacenar la imagen antes de aplicar formato u optimización.

## **Agregar y formatear una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un *picture frame* con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_picture_frame/). La imagen pasa a formar parte del paquete de la presentación, de modo que la presentación sigue siendo autónoma cuando se traslada a otro equipo.

El siguiente ejemplo añade una imagen JPEG, crea un marco con las dimensiones nativas de la imagen y aplica formato de línea y rotación:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

El *picture frame* controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones de píxel originales almacenadas en el recurso de imagen incrustada. Esta distinción se vuelve importante al recortar o comprimir una imagen más adelante.

## **Usar escala relativa**

[PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) expone [relative_scale_width](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/relative_scale_width/) y [relative_scale_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/relative_scale_height/) para el marco. Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita preservar una relación con el tamaño de la imagen fuente en lugar de calcular manualmente las dimensiones finales.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

La escala relativa cambia la configuración de escala del marco; no vuelve a muestrear ni comprime la imagen incrustada.

## **Imágenes incrustadas y vinculadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por lo tanto, es la opción más segura para la portabilidad y una representación predecible. Una imagen vinculada almacena una ruta externa mediante el enlace [Picture](https://reference.aspose.com/slides/es/python-net/aspose.slides/picture/) en lugar de incrustar los datos de la imagen de la misma manera.

Las imágenes vinculadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo vinculado debe permanecer accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen vinculada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Agregar una imagen vinculada**

El siguiente ejemplo crea un *picture frame* y lo enlaza a un archivo de imagen local. Sólo trata el enlace de imágenes; el enlace de vídeo es un flujo de trabajo de medios separado y deliberadamente no se mezcla en este ejemplo.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Utilice enlaces cuando la gestión de archivos externos sea intencional. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imágenes rotas suele ser menos útil que una presentación más grande y autónoma.

## **Extraer imágenes de *picture frames***

Antes de extraer una imagen de una presentación existente, compruebe que una forma es realmente un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) y que contiene una imagen incrustada. Los *picture frames* vinculados pueden no contener bytes de imagen que puedan extraerse de la misma forma.

### **Extraer una imagen raster**

La API de imágenes moderna usa [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) directamente. El siguiente ejemplo encuentra la primera imagen raster incrustada en una diapositiva y la guarda como PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Guardar mediante [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo raster convertido, utilice la propiedad [PPImage.binary_data](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/binary_data/) en su lugar.

### **Extraer una imagen SVG**

Para una imagen SVG, el [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) expone un objeto [SvgImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/). Esto le permite obtener los datos SVG directamente en vez de rasterizar la imagen primero.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG necesariamente renderizan ese contenido vectorial a píxeles. La exportación a PDF o a diapositivas SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia idéntica a nivel de bytes del SVG incrustado original; use el [SvgImage.svg_data](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/svg_data/) incrustado cuando se requiera el recurso vectorial original.

## **Recortar una imagen**

El recorte cambia la parte de la imagen que es visible dentro del marco. Los valores de recorte en [PictureFillFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/) son porcentajes de las dimensiones de la imagen fuente. El recorte no elimina inicialmente los píxeles ocultos de la imagen incrustada; sólo modifica la región visible.

El siguiente ejemplo encuentra de forma segura un *picture frame* y aplica valores de recorte:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Dado que los datos de la imagen oculta siguen presentes, el recorte puede modificarse más tarde sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la sección siguiente.

## **Eliminar datos de imagen recortados**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: después de guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de *uncrop* posterior.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también se usa en otros *picture frames*, esos marcos siguen necesitando su recurso existente, por lo que eliminar áreas recortadas no reduce necesariamente el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir imágenes raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/compress_image/) reduce la resolución de la imagen raster en relación con el tamaño al que se muestra la imagen. También puede eliminar regiones recortadas en la misma operación. El método devuelve `True` cuando la imagen se redimensionó o recortó y `False` cuando no fue necesario ningún cambio.

Utilice un valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/picturescompression/) cuando una resolución objetivo estándar sea suficiente:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

En su lugar puede pasarse un valor DPI positivo personalizado cuando se requiera un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y los metarchivos no se reducen con este flujo de compresión raster. Además, recuerde que una resolución más baja y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el tamaño máximo al que la imagen será vista o exportada, en lugar de aplicar el DPI más bajo de forma global.

## **Gestionar efectos de transformación de imagen**

Para un flujo de trabajo completo que cubra brillo, contraste, transformaciones de color, desenfoque, efectos alfa, cadenas ordenadas, inspección, eliminación y verificación de ida y vuelta, consulte [Image Transform Effects](/slides/es/python-net/image-transform-effects/).

## **Bloquear la geometría del *picture frame***

Los ajustes de [PictureFrameLock](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframelock/) controlan qué operaciones de edición están deshabilitadas para un *picture frame*. Por ejemplo, la propiedad [aspect_ratio_locked](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) conserva las proporciones de la forma mientras se redimensiona.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

El bloqueo se aplica a la forma del *picture frame*. No obliga a que la imagen fuente sea muestreada nuevamente ni cambiada permanentemente al mismo ratio de aspecto.

## **Ajustar los valores de StretchOffset**

Cuando el modo de relleno de imagen es *stretch*, los valores de *stretch‑offset* en [PictureFillFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del *picture frame*. Los porcentajes positivos crean una inserción desde un borde, mientras que los porcentajes negativos crean una protrusión.

Esto es diferente al recorte. Los valores de recorte seleccionan qué parte de la imagen fuente es visible; los *stretch offsets* cambian el rectángulo en el que se estira el relleno de la imagen visible.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Utilice *stretch offsets* para la ubicación del relleno. Use las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen fuente.

## **Consideraciones de almacenamiento, tamaño de archivo y exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del *picture frame* se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autónoma y son la opción más fiable para compartir y renderizar en el servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes vinculadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos permanezcan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que las áreas recortadas se eliminen explícitamente o se retiren durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster demasiado grandes, pero sacrifica la resolución original. Debe aplicarse después de conocer el tamaño final en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial es importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial en sí. Las exportaciones raster de diapositivas siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deben reutilizar un recurso [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) existente cuando sea posible, en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño real de visualización, elimine píxeles recortados sólo cuando no se requieran ediciones posteriores y evite enlaces externos salvo que la gestión de dependencias forme parte del diseño del despliegue.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un *picture frame* y un recurso de imagen?**

Un [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) representa un recurso de imagen asociado a la presentación. Un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) es una forma en una diapositiva que muestra una imagen y almacena la geometría y el formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo incrustar o vincular imágenes?**

Incruste imágenes cuando la presentación deba ser portátil, archivada o renderizada sin acceso a recursos externos. Vincule imágenes solo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí mismo. La configuración de recorte normal oculta partes de la imagen fuente pero conserva los píxeles subyacentes. Use [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) o compresión de imágenes con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada, y la eliminación de regiones recortadas descarta datos de imagen. Mantenga la imagen fuente original fuera de la presentación si más adelante se requieren ediciones de alta resolución.

**¿Cómo deben manejarse las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea importante. El [SvgImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de *picture frame*. Utilizar `isinstance(shape, slides.PictureFrame)` evita conversiones inválidas y permite que el código maneje diapositivas que no contengan *picture frames*.