---
title: Extraer imágenes de formas de presentación en Python mediante Java
linktitle: Imagen desde forma
type: docs
weight: 100
url: /es/python-java/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Extrae imágenes de las formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python mediante Java: solución rápida y fácil de usar."
---
## **Visión general**

Las imágenes en una presentación pueden aparecer en varios tipos de forma: como marcos de imagen ordinarios, como rellenos de imagen aplicados a formas, como imágenes de vista previa de objetos OLE, como miniaturas de fotogramas de vídeo o audio, como imágenes de zoom, o como imágenes anidadas dentro de formas de tabla, gráfico y SmartArt. Aspose.Slides almacena esas imágenes en la colección de imágenes de la presentación, expuesta a través de [ImageCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/) y [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) objetos.

Si solo necesita exportar cada recurso de imagen incrustado en una presentación, recorra [Presentation.getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages). Este artículo se centra en una tarea diferente: recorrer las formas para encontrar dónde se usan imágenes en las diapositivas, de modo que los archivos guardados puedan conservar contexto útil como el número de diapositiva, la posición de la forma y el tipo de origen (marco de imagen, imagen de relleno, vista previa de medios, vista previa OLE o imagen de zoom).

{{% alert title="Consejo" color="success" %}}

Utilice [PPImage.getBinaryData](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getBinaryData) para conservar los datos de imagen codificados originales y el tipo de archivo. Utilice [PPImage.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getImage) con `save` cuando desee normalizar la salida a un formato específico como PNG.

{{% /alert %}}

## **Funciones auxiliares compartidas**

Guarde las funciones auxiliares compartidas a continuación en `image_helpers.py` junto a los scripts de ejemplo. Mantienen los ejemplos breves. `save_original_image` escribe los bytes incrustados originales, elige una extensión segura a partir del tipo MIME y omite binarios de imagen duplicados mediante el hash SHA-256.

```python
from pathlib import Path
import hashlib
import re

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GroupShape, ImageFormat


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.getBinaryData())
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False
    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.getContentType())
    output_file = Path(output_directory) / f"{file_name_base}.{extension}"
    output_file.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    output_file = Path(output_directory) / f"{file_name_base}.png"
    output_image = image.getImage()
    try:
        output_image.save(str(output_file), ImageFormat.Png)
    finally:
        output_image.dispose()


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.getFillType() != FillType.Picture:
        return None
    return fill_format.getPictureFillFormat().getPicture().getImage()


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    shape_references = []
    for shape_index in range(shapes.size()):
        shape = shapes.get_Item(shape_index)
        shape_name_part = f"{prefix}_shape_{shape_index + 1}"
        shape_references.append((shape, shape_name_part))
        if include_grouped_shapes and isinstance(shape, GroupShape):
            child_shapes = shape.getShapes()
            child_references = enumerate_shapes(child_shapes, shape_name_part, include_grouped_shapes)
            shape_references.extend(child_references)
    return shape_references


def get_extension_from_content_type(content_type):
    if content_type is None or not str(content_type).strip():
        return "bin"
    media_type = str(content_type).split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }
    if media_type in extensions:
        return extensions[media_type]
    if media_type.startswith("image/"):
        return re.sub(r"[^A-Za-z0-9._-]", "_", media_type[len("image/"):])
    return "bin"
```

## **Extraer imágenes de marcos de imagen**

Utilice este enfoque para imágenes insertadas como objetos independientes. Un [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) proporciona acceso a su imagen mediante [getPictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#getPicture) y [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#getImage), que devuelve un objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/).

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraer imágenes de formas con relleno de imagen**

Las formas pueden usar una imagen como su relleno. Compruebe primero el tipo de relleno de la forma: si no es [FillType.Picture](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/), no hay imagen para extraer de ese relleno. El ejemplo a continuación maneja objetos [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) y guarda cada imagen como PNG mediante [PPImage.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getImage).

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
finally:
    presentation.dispose()
```

## **Extraer imágenes de vista previa de marcos de objeto OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) puede tener una imagen sustituta que PowerPoint usa como vista previa del objeto en una diapositiva. Esta imagen está disponible mediante [getSubstitutePictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#getPicture) y [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#getImage). Extraer esta imagen le proporciona la vista previa, no el contenido incrustado del paquete OLE.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, OleObjectFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraer imágenes de vista previa de marcos de vídeo**

Un [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) también puede almacenar una imagen de vista previa en [getPictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#getPicture) y [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#getImage). Esta es la póster o miniatura que se muestra en la diapositiva, no un fotograma decodificado del flujo de vídeo.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraer imágenes de vista previa de marcos de audio**

Un [AudioFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/) puede almacenar una miniatura en [getPictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#getPicture) y [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#getImage). Esta es la imagen mostrada para el objeto de audio en la diapositiva.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraer imágenes de objetos de zoom**

Los objetos [ZoomFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomframe/) y [SectionZoomFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/sectionzoomframe/) pueden usar imágenes personalizadas. Lea [getZoomImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomobject/#getZoomImage) del marco de zoom.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SectionZoomFrame, ZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, ZoomFrame):
                zoom_frame = shape
                image = zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
            if isinstance(shape, SectionZoomFrame):
                section_zoom_frame = shape
                image = section_zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_section_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
finally:
    presentation.dispose()
```

## **Extraer imágenes de marcos de zoom de resumen**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/summaryzoomframe/) también es una forma. Sus elementos de sección pueden usar imágenes personalizadas, expuestas a través del método [getZoomImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomobject/#getZoomImage) de cada sección de zoom de resumen.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SummaryZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, SummaryZoomFrame):
                summary_zoom_frame = shape
                section_count = summary_zoom_frame.getSummaryZoomCollection().size()
                for section_index in range(section_count):
                    section = summary_zoom_frame.getSummaryZoomCollection().get_Item(section_index)
                    image = section.getZoomImage()
                    if image is not None:
                        display_index = section_index + 1
                        file_name_base = name_part + "_summary_zoom_" + str(display_index)
                        save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraer imágenes de formas de tabla**

Una [Table](https://reference.aspose.com/slides/es/python-java/aspose.slides/table/) es una forma. Las imágenes en una tabla suelen almacenarse como rellenos de imagen en celdas de tabla.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Table):
                table = shape
                row_count = table.getRows().size()
                column_count = table.getColumns().size()
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = table.get_Item(column_index, row_index)
                        fill_format = cell.getCellFormat().getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_row = row_index + 1
                            display_column = column_index + 1
                            file_name_base = name_part + "_cell_" + str(display_row) + "_" + str(display_column)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraer imágenes de formas de gráfico**

Un [Chart](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/) es una forma. El ejemplo a continuación extrae una imagen del relleno de imagen del área del gráfico.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Chart):
                chart = shape
                fill_format = chart.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = name_part + "_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extraer imágenes de formas SmartArt**

Un objeto [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) es una forma. Según el diseño de SmartArt, las imágenes pueden almacenarse en los rellenos de viñeta de los nodos o en los formatos de relleno de las formas de los nodos.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, SmartArt):
                smart_art = shape
                node_count = smart_art.getAllNodes().size()
                for node_index in range(node_count):
                    node = smart_art.getAllNodes().get_Item(node_index)
                    bullet_fill_format = node.getBulletFillFormat()
                    bullet_image = get_picture_fill_image(bullet_fill_format)
                    if bullet_image is not None:
                        display_node = node_index + 1
                        file_name_base = name_part + "_smartart_node_" + str(display_node) + "_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)
                    node_shape_count = node.getShapes().size()
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.getShapes().get_Item(node_shape_index)
                        fill_format = node_shape.getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_node = node_index + 1
                            display_node_shape = node_shape_index + 1
                            file_name_base = name_part + "_smartart_node_" + str(display_node) + "_shape_" + str(display_node_shape)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Incluir imágenes dentro de formas agrupadas**

Las formas agrupadas contienen sus propias colecciones de formas. El ayudante compartido `enumerate_shapes` tiene una opción `include_grouped_shapes`. Establézcala en `True` cuando desee inspeccionar las formas dentro de objetos [GroupShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/groupshape/). El ejemplo a continuación extrae imágenes de marcos de imagen, formas con relleno de imagen, vistas previas de objetos OLE, miniaturas de fotogramas de vídeo y miniaturas de fotogramas de audio. Para incluir también imágenes de tabla, gráfico, SmartArt y zoom de resumen, reutilice la lógica de extracción especializada de las secciones anteriores manteniendo el mismo recorrido recursivo de formas.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame, AutoShape, OleObjectFrame, PictureFrame, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Casos límite y notas prácticas**

- **Imágenes duplicadas:** Varias formas pueden referenciar la misma imagen o imágenes distintas con bytes idénticos. Genere un hash con [PPImage.getBinaryData](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getBinaryData) antes de escribir los archivos si desea un archivo de salida por cada imagen única.
- **Datos originales vs. salida convertida:** Guardar [PPImage.getBinaryData](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getBinaryData) preserva los datos incrustados JPEG, PNG, GIF, SVG, EMF o WMF. Guardar [PPImage.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getImage) mediante `save` resulta útil cuando se necesita un formato de salida consistente.
- **Tipos de relleno no admitidos:** Las formas de relleno sólido, degradado, patrón y sin relleno no contienen un relleno de imagen. Consulte [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) antes de leer [getPictureFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Formas agrupadas:** La colección de formas de nivel superior de la diapositiva no aplana los grupos. Inspeccione recursivamente [GroupShape.getShapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/groupshape/#getShapes) cuando el contenido agrupado sea relevante.
- **Vistas previas de objetos OLE:** Un [OleObjectFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/) puede exponer una imagen de vista previa mediante [getSubstitutePictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), pero esa imagen es solo la vista previa de la diapositiva. No es el archivo incrustado dentro del objeto OLE.
- **Miniaturas de fotogramas de vídeo:** Un [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) puede exponer una imagen de vista previa mediante [getPictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#getPictureFormat), pero esa imagen es solo el póster que se muestra en la diapositiva. No se extrae del flujo de vídeo.
- **Miniaturas de fotogramas de audio:** Un [AudioFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/audioframe/) puede exponer un icono o miniatura mediante [getPictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#getPictureFormat); no es el audio incrustado.
- **Imágenes de zoom:** Las formas de zoom de diapositiva, zoom de sección y zoom de resumen pueden usar objetos [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) personalizados mediante [getZoomImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Modelos de forma anidados:** Los objetos de tabla, gráfico y SmartArt implementan [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/), pero sus imágenes suelen almacenarse en objetos de formato anidados de celdas de tabla, elementos de gráfico o nodos de SmartArt.
- **Imágenes recortadas o transformadas:** Acceder a [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) le devuelve el recurso de imagen almacenado. No representa recortes, transparencias, recolores, rotaciones u otros efectos visuales aplicados por la forma.

## **FAQ**

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de la forma?**

Sí. Acceda al objeto [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) y escriba [PPImage.getBinaryData](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getBinaryData) en disco. Esto preserva la imagen codificada original almacenada en la presentación, no la forma en que la imagen se renderiza en la diapositiva.

**¿Puedo exportar cada imagen extraída como PNG?**

Sí. Utilice [PPImage.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getImage) para obtener un objeto de imagen y luego llame a `save` con [ImageFormat.Png](https://reference.aspose.com/slides/es/python-java/aspose.slides/imageformat/). Esto convierte la salida y puede no preservar el tipo de archivo original ni los datos vectoriales.

**¿Cómo evito guardar la misma imagen más de una vez?**

Use un hash de [PPImage.getBinaryData](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#getBinaryData) y mantenga los hashes en un conjunto. Si una nueva imagen tiene un hash que ya existe, omítala o registre otra referencia al archivo de salida existente.

**¿Por qué algunas formas no generan una imagen?**

Los marcos de imagen, las formas con relleno de imagen, los marcos de objeto OLE, los marcos de medios, los marcos de zoom, las tablas, los gráficos y los objetos SmartArt pueden referenciar imágenes. Algunos tipos de forma exponen imágenes a través de objetos de formato anidados, por lo que una simple comprobación de [getPictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#getPictureFormat) o [getFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getFillFormat) no siempre es suficiente.

**¿Puedo extraer la miniatura mostrada para un marco de vídeo?**

Sí. Utilice [VideoFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/videoframe/) y lea [getPictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#getPicture) y [getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#getImage). Esto extrae la imagen póster almacenada con el marco de vídeo, no un fotograma generado a partir del archivo de vídeo.

**¿Cómo puedo determinar qué formas usan una imagen específica de la colección de imágenes de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) a las formas. Construya un mapeo durante el recorrido: siempre que encuentre una referencia a una imagen, registre el número de diapositiva, la ruta de la forma y el hash de la imagen o el elemento de la colección.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

Puede extraer la vista previa del objeto OLE desde [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Sin embargo, esa vista previa no es el documento incrustado propiamente dicho. Para extraer imágenes del interior del archivo incrustado, extraiga los datos OLE y examínelos con herramientas apropiadas para ese tipo de archivo.