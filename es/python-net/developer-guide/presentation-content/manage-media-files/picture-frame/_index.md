---
title: Gestionar marcos de imagen en presentaciones con Python
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/python-net/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
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
description: "Crear, formatear, vincular, recortar, extraer y comprimir marcos de imagen en presentaciones con Aspose.Slides para Python mediante .NET."
---
## **Visión general**

Un marco de imagen es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) posee recursos de imagen incrustados a través de su [ImageCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/), mientras que un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) controla la posición, el tamaño, el formato de línea, la rotación, el recorte, los efectos de imagen y otras configuraciones a nivel de marco.

Esta separación es útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) devuelto y utilice ese recurso de imagen al crear marcos de imagen.

Los marcos de imagen pueden contener imágenes raster como PNG o JPEG e imágenes vectoriales SVG. También pueden referirse a imágenes vinculadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo se debe almacenar la imagen antes de aplicar formato u optimización.

## **Añadir y Formatear una Imagen Insertada**

Para una imagen insertada, añada los datos de la imagen a la presentación y cree un marco de imagen con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_picture_frame/). La imagen pasa a ser parte del paquete de la presentación, de modo que la presentación permanece autocontenida cuando se traslada a otro equipo.

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

El marco de imagen controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones originales en píxeles almacenadas en el recurso de imagen insertado. Esta distinción se vuelve importante al recortar o comprimir una imagen más adelante.

## **Usar Escala Relativa**

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

La escala relativa cambia los ajustes de escala del marco; no vuelve a muestrear ni comprime la imagen insertada.

## **Imágenes Insertadas y Vinculadas**

Una imagen insertada almacena los datos de la imagen dentro de la presentación y, por lo tanto, es la opción más segura para la portabilidad y una renderización predecible. Una imagen vinculada almacena una ubicación externa a través de la ruta del enlace [Picture](https://reference.aspose.com/slides/es/python-net/aspose.slides/picture/) en lugar de incrustar los datos de la imagen de la misma manera.

Las imágenes vinculadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo vinculado debe permanecer accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen vinculada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo electrónico, archivarse o renderizarse en entornos aislados, las imágenes insertadas suelen ser más fiables.

### **Añadir una Imagen Vinculada**

El siguiente ejemplo crea un marco de imagen y lo apunta a un archivo de imagen local. Sólo trata el enlace de la imagen; el enlace de vídeo es un flujo de trabajo multimedia separado y deliberadamente no se mezcla en este ejemplo.

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

Utilice enlaces cuando la gestión de archivos externos sea intencional. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imagen rotas suele ser menos útil que una presentación mayor autocontenida.

## **Extraer Imágenes de Marcos de Imagen**

Antes de extraer una imagen de una presentación existente, compruebe que una forma sea realmente un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) y que contenga una imagen insertada. Los marcos de imagen vinculados pueden no contener bytes de imagen que puedan extraerse de la misma forma.

### **Extraer una Imagen Raster**

La API de imágenes moderna usa [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) directamente. El siguiente ejemplo encuentra la primera imagen raster insertada en una diapositiva y la guarda como PNG:

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

Guardar mediante [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo raster convertido, use la propiedad [PPImage.binary_data](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/binary_data/) en su lugar.

### **Extraer una Imagen SVG**

Para una imagen SVG, el [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) expone un objeto [SvgImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/). Esto le permite recuperar los datos SVG directamente en lugar de rasterizar la imagen primero.

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

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG obligatoriamente renderizan ese contenido vectorial a píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia byte a byte del SVG insertado original; utilice el [SvgImage.svg_data](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/svg_data/) incrustado cuando se requiera el recurso vectorial original.

## **Recortar una Imagen**

Recortar cambia qué parte de una imagen es visible dentro del marco. Los valores de recorte en [PictureFillFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/) son porcentajes de las dimensiones de la imagen fuente. Recortar no elimina inicialmente los píxeles ocultos de la imagen insertada; sólo cambia la región visible.

El siguiente ejemplo encuentra un marco de imagen de forma segura y aplica valores de recorte:

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

Dado que los datos de la imagen oculta siguen presentes, el recorte puede modificarse más tarde sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la siguiente sección.

## **Eliminar los Datos Recortados de la Imagen**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: después de guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de desrecorte posterior.

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

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también se usa en otros marcos de imagen, esos marcos siguen necesitando su recurso existente, por lo que eliminar áreas recortadas no reduce necesariamente el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir Imágenes Raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/compress_image/) reduce la resolución de la imagen raster en relación con el tamaño en el que se muestra la imagen. También puede eliminar regiones recortadas en la misma operación. El método devuelve `True` cuando la imagen se redimensionó o recortó y `False` cuando no fue necesario ningún cambio.

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

Se puede pasar un valor DPI positivo personalizado en lugar de un valor de enumeración cuando se requiere un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y de metarchivo no se reduce con este flujo de trabajo de compresión raster. También recuerde que la resolución inferior y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el mayor tamaño al que la imagen será realmente vista o exportada, en lugar de aplicar el DPI más bajo a nivel global.

## **Inspeccionar Efectos de Imagen**

Los efectos de imagen se almacenan en la imagen usada por el marco. La colección de transformaciones de la imagen puede contener efectos como modulación alfa fija para transparencia y luminancia para brillo y contraste. El ejemplo a continuación lee de forma segura ambos tipos de efectos del primer marco de imagen en una diapositiva:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/alphamodulatefixed/) y [Luminance](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/luminance/) cambian cómo se renderiza la imagen en el marco; no sobrescriben los bytes originales de la imagen insertada.

## **Bloquear la Geometría del Marco de Imagen**

Los ajustes de [PictureFrameLock](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframelock/) controlan qué operaciones de edición están deshabilitadas para un marco de imagen. Por ejemplo, la propiedad [aspect_ratio_locked](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) conserva las proporciones de la forma mientras se redimensiona.

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

El bloqueo se aplica a la forma del marco de imagen. No obliga a que la imagen fuente se vuelva a muestrear o se cambie permanentemente al mismo aspecto de proporción.

## **Ajustar los Valores StretchOffset**

Cuando el modo de relleno de imagen es estirado, los valores stretch‑offset en [PictureFillFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del marco de imagen. Los porcentajes positivos crean una inserción desde un borde, mientras que los negativos crean una expansión.

Esto es diferente al recorte. Los valores de recorte eligen qué parte de la imagen fuente es visible; los offsets de estiramiento cambian el rectángulo en el que el relleno de imagen visible se estira.

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

Utilice offsets de estiramiento para la ubicación del relleno. Use las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen fuente.

## **Consideraciones de Almacenamiento, Tamaño de Archivo y Exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del marco de imagen se tratan por separado:

- **Imágenes insertadas** hacen que la presentación sea autocontenida y son las más fiables para compartir y renderizar en servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes vinculadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos sigan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen insertados hasta que se eliminen explícitamente las áreas recortadas o se eliminen durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster sobredimensionadas, pero sacrifica la resolución fuente. Debe aplicarse después de conocer el tamaño final deseado en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial es importante. Extraiga el SVG insertado directamente cuando necesite el recurso vectorial en sí. Las exportaciones raster de diapositivas siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deben reutilizar un recurso [PPImage] existente cuando sea posible en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño real de visualización, elimine píxeles recortados solo cuando no se requiera edición posterior y evite enlaces externos salvo que la gestión de dependencias forme parte del diseño de despliegue.

## **Preguntas Frecuentes**

**¿Cuál es la diferencia entre un marco de imagen y un recurso de imagen?**

Un [PPImage] representa un recurso de imagen asociado a la presentación. Un [PictureFrame] es una forma en una diapositiva que muestra una imagen y almacena la geometría y el formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo insertar o vincular imágenes?**

Inserte imágenes cuando la presentación deba ser portátil, archivada o renderizada sin acceso a recursos externos. Vincule imágenes solo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí mismo. Los ajustes normales de recorte ocultan partes de la imagen fuente pero conservan los píxeles subyacentes. Use [PictureFillFormat.delete_picture_cropped_areas] o la compresión de imagen con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada y la eliminación de regiones recortadas descarta datos de imagen. Mantenga la imagen fuente original fuera de la presentación si más adelante puede necesitar una edición de alta resolución.

**¿Cómo deben manejarse las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea importante. El [SvgImage] insertado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de marcos de imagen. Utilizar `isinstance(shape, slides.PictureFrame)` evita conversiones inválidas y permite que el código gestione diapositivas que no contengan marcos de imagen.