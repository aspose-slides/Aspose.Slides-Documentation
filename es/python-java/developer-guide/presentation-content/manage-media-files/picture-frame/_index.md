---
title: Gestionar marcos de imagen en presentaciones usando Python
linktitle: Marco de imagen
type: docs
weight: 10
url: /es/python-java/picture-frame/
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
- Java
- Aspose.Slides
description: "Crear, formatear, vincular, recortar, extraer y comprimir marcos de imagen en presentaciones con Aspose.Slides para Python mediante Java."
---
## **Descripción general**

Un marco de imagen es una forma de diapositiva que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) posee recursos de imagen incrustados a través de su [ImageCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/), mientras que un [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) controla la posición, el tamaño, el formato de línea, la rotación, el recorte, los efectos de imagen y otras configuraciones a nivel de marco.

Esta separación es útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) devuelto y utilice ese recurso de imagen al crear marcos de imagen.

Los marcos de imagen pueden contener imágenes raster como PNG o JPEG e imágenes vectoriales SVG. También pueden referirse a imágenes vinculadas en lugar de almacenar los bytes de la imagen en la presentación. La elección influye en la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo debe almacenarse la imagen antes de aplicar formato u optimización.

## **Agregar y formatear una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un marco de imagen con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addPictureFrame). La imagen pasa a formar parte del paquete de la presentación, de modo que la presentación permanece autocontenida cuando se traslada a otro ordenador.

El siguiente ejemplo añade una imagen JPEG, crea un marco con las dimensiones nativas de la imagen y aplica formato de línea y rotación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El marco de imagen controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones originales en píxeles almacenadas en el recurso de imagen incrustado. Esta distinción se vuelve importante al recortar o comprimir una imagen más adelante.

## **Usar escala relativa**

[PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) expone el escalado relativo de anchura y altura para el marco a través de [setRelativeScaleWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) y [setRelativeScaleHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita preservar una relación con el tamaño de la imagen fuente en lugar de calcular las dimensiones finales manualmente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El escalado relativo modifica la configuración de escala del marco; no vuelve a muestrear ni comprime la imagen incrustada.

## **Imágenes incrustadas y vinculadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por tanto, es la opción más segura para la portabilidad y la renderización predecible. Una imagen vinculada almacena una ubicación externa mediante el método [Picture.setLinkPathLong](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#setLinkPathLong) en lugar de incrustar los datos de la imagen de la misma manera.

Las imágenes vinculadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo vinculado debe seguir siendo accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen vinculada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo electrónico, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Agregar una imagen vinculada**

El siguiente ejemplo crea un marco de imagen y lo apunta a un archivo de imagen local. Solo trata el vínculo de imágenes; el vínculo de vídeos es un flujo de trabajo multimedia aparte y se deja fuera de este ejemplo a propósito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Use vínculos cuando la gestión de archivos externos sea intencional. No los utilice simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imagen rotas suele ser menos útil que una presentación más grande y autocontenida.

## **Extraer imágenes de marcos de imagen**

Antes de extraer una imagen de una presentación existente, verifique que una forma sea realmente un [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) y que contenga una imagen incrustada. Los marcos de imagen vinculados pueden no contener bytes de imagen que puedan extraerse de la misma manera.

### **Extraer una imagen raster**

La API moderna de imágenes trabaja directamente con imágenes raster y no requiere el contenedor de imágenes Java anterior. El siguiente ejemplo encuentra la primera imagen raster incrustada en una diapositiva y la guarda como PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Guardar la imagen raster convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo raster convertido, utilice los datos binarios del recurso de imagen.

### **Extraer una imagen SVG**

Para una imagen SVG, el [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) expone un objeto [SvgImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/). Esto le permite obtener los datos SVG directamente en lugar de rasterizar la imagen primero.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG deben renderizar ese contenido vectorial a píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, de modo que los gráficos exportados no deben considerarse una copia byte a byte del SVG incrustado original; use los datos de [SvgImage.getSvgData](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/#getSvgData) cuando se requiera el recurso vectorial original.

## **Recortar una imagen**

El recorte cambia la parte de la imagen que es visible dentro del marco. Los valores de recorte en [PictureFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/) son porcentajes de las dimensiones de la imagen fuente. El recorte no elimina inicialmente los píxeles ocultos de la imagen incrustada; solo cambia la región visible.

El siguiente ejemplo encuentra un marco de imagen de forma segura y aplica valores de recorte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Como los datos de la imagen oculta siguen presentes, el recorte puede modificarse más tarde sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la sección siguiente.

## **Eliminar datos de imagen recortados**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: después de guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de desrecorte posterior.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también es usada por otros marcos de imagen, esos marcos siguen necesitando su recurso existente, por lo que eliminar áreas recortadas no necesariamente reduce el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir imágenes raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#compressImage) reduce la resolución de la imagen raster en relación con el tamaño en que se muestra la imagen. También puede eliminar regiones recortadas en la misma operación. El método devuelve `True` cuando la imagen se redimensionó o recortó y `False` cuando no fue necesario ningún cambio.

Utilice un valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturescompression/) cuando una resolución objetivo estándar sea suficiente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En su lugar, puede pasarse un valor DPI positivo personalizado cuando se requiera un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y de metarchivo no se reduce con este flujo de compresión raster. También recuerde que la menor resolución y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo basada en el tamaño máximo al que la imagen será realmente vista o exportada, en lugar de aplicar el DPI más bajo a nivel global.

## **Gestionar efectos de transformación de imagen**

Para un flujo de trabajo completo que cubra brillo, contraste, transformaciones de color, desenfoque, efectos alfa, cadenas ordenadas, inspección, eliminación y verificación de ida y vuelta, consulte [Image Transform Effects](/slides/es/python-java/image-transform-effects/).

## **Bloquear la geometría del marco de imagen**

Los ajustes de [PictureFrameLock](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframelock/) controlan qué operaciones de edición están deshabilitadas para un marco de imagen. Por ejemplo, [setAspectRatioLocked](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) preserva las proporciones de la forma mientras se redimensiona.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El bloqueo se aplica a la forma del marco de imagen. No obliga a que la imagen fuente sea remuestreada o cambiada permanentemente al mismo aspecto de relación.

## **Ajustar los valores StretchOffset**

Cuando el modo de relleno de imagen es estirado, los valores de offset de estiramiento en [PictureFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del marco de imagen. Los porcentajes positivos crean una inserción desde un borde, mientras que los porcentajes negativos crean una expansión.

Esto difiere del recorte. Los valores de recorte seleccionan qué parte de la imagen fuente es visible; los offsets de estiramiento cambian el rectángulo en el que se estira el relleno de imagen visible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Use los offsets de estiramiento para la colocación del relleno. Use las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen fuente.

## **Consideraciones de almacenamiento, tamaño de archivo y exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del marco de imagen se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autocontenida y son las más fiables para compartir y renderizar en servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes vinculadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos permanezcan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que se eliminen explícitamente las áreas recortadas o se eliminen durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster sobredimensionadas, pero sacrifica la resolución fuente. Debe aplicarse después de conocer el tamaño final en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial sea importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial mismo. Las exportaciones raster de diapositivas siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deberían reutilizar un recurso [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) existente cuando sea posible en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño real de visualización, elimine píxeles recortados solo cuando no se requiera edición posterior y evite enlaces externos a menos que la gestión de dependencias forme parte del diseño de la implementación.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un marco de imagen y un recurso de imagen?**

Un [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) representa un recurso de imagen asociado a la presentación. Un [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) es una forma en una diapositiva que muestra una imagen y almacena geometría y formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo incrustar o vincular las imágenes?**

Incruste las imágenes cuando la presentación deba ser portátil, archivada o renderizada sin acceso a recursos externos. Vincule las imágenes solo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí solo. Los ajustes normales de recorte ocultan partes de la imagen fuente pero conservan los píxeles subyacentes. Utilice [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) o la compresión de imágenes con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada y la eliminación de regiones recortadas descarta datos de imagen. Mantenga la imagen fuente original fuera de la presentación si posteriormente se requiere una edición de alta resolución.

**¿Cómo deben manejarse las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea importante. El [SvgImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de marcos de imagen. Una comprobación `isinstance` contra [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) evita conversiones inválidas y permite al código manejar diapositivas que no contengan marcos de imagen.