---
title: Estrai immagini dalle forme della presentazione in Python tramite Java
linktitle: Immagine da forma
type: docs
weight: 100
url: /it/python-java/extracting-images-from-presentation-shapes/
keywords:
- estrarre immagine
- recuperare immagine
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Estrai immagini dalle forme in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python tramite Java - soluzione rapida e facile da usare nel codice."
---
## **Panoramica**

Le immagini in una presentazione possono apparire in diversi tipi di forma: come cornici immagine ordinarie, come riempimenti immagine applicati alle forme, come anteprime di oggetti OLE, come miniature di fotogrammi video o audio, come immagini di zoom o come immagini annidate all'interno di tabelle, grafici e forme SmartArt. Aspose.Slides memorizza queste immagini nella collezione di immagini della presentazione, esposta attraverso [ImageCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/) e [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) objects.

Se è necessario esportare ogni risorsa immagine incorporata in una presentazione, iterare tramite [Presentation.getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages). Questo articolo si concentra su un compito diverso: attraversare le forme per trovare dove le immagini sono usate nelle diapositive, in modo che i file salvati possano conservare contesto utile come il numero della diapositiva, la posizione della forma e il tipo di origine (cornice immagine, immagine di riempimento, anteprima multimediale, anteprima OLE o immagine di zoom).

{{% alert title="Suggerimento" color="success" %}}

Utilizzare [PPImage.getBinaryData](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getBinaryData) per preservare i dati immagine codificati originali e il tipo di file. Utilizzare [PPImage.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getImage) con `save` quando si desidera normalizzare l'output in un formato specifico come PNG.

{{% /alert %}}

## **Funzioni di supporto condivise**

Salvare le funzioni di supporto condivise qui sotto in `image_helpers.py` accanto agli script di esempio. Mantengono gli esempi brevi. `save_original_image` scrive i byte originali incorporati, sceglie un’estensione sicura dal tipo MIME e salta i binari immagine duplicati tramite hash SHA-256.

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

## **Estrai immagini da cornici immagine**

Utilizzare questo approccio per le immagini inserite come oggetti autonomi. Un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) fornisce l'accesso alla sua immagine tramite [getPictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#getImage), che restituisce un oggetto [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/).

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

## **Estrai immagini da forme con riempimento immagine**

Le forme possono usare un'immagine come riempimento. Controllare prima il tipo di riempimento della forma: se non è [FillType.Picture](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/), non c’è alcuna immagine da estrarre da quel riempimento. L'esempio sotto gestisce gli oggetti [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) e salva ogni immagine come PNG tramite [PPImage.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getImage).

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

## **Estrai immagini anteprima da cornici oggetto OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) può avere un'immagine sostitutiva che PowerPoint usa come anteprima dell'oggetto nella diapositiva. Questa immagine è disponibile tramite [getSubstitutePictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#getImage). Estrarre questa immagine restituisce l'anteprima, non il contenuto del pacchetto OLE incorporato.

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

## **Estrai immagini anteprima da cornici video**

Un [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) può anche memorizzare un'immagine anteprima in [getPictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#getImage). Questa è la locandina o miniatura mostrata nella diapositiva, non un fotogramma decodificato dal flusso video.

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

## **Estrai immagini anteprima da cornici audio**

Un [AudioFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/) può memorizzare una miniatura in [getPictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#getImage). Questa è l'immagine mostrata per l'oggetto audio nella diapositiva.

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

## **Estrai immagini da oggetti Zoom**

Le forme [ZoomFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/zoomframe/) e [SectionZoomFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/sectionzoomframe/) possono usare immagini personalizzate. Leggere [getZoomImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/zoomobject/#getZoomImage) dalla cornice zoom.

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

## **Estrai immagini da cornici Summary Zoom**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/summaryzoomframe/) è anch'esso una forma. I suoi elementi di sezione possono usare immagini personalizzate, esposte tramite il metodo [getZoomImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/zoomobject/#getZoomImage) di ciascuna sezione zoom del sommario.

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

## **Estrai immagini da forme tabella**

Una [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/) è una forma. Le immagini in una tabella sono solitamente memorizzate come riempimenti immagine nelle celle della tabella.

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

## **Estrai immagini da forme grafico**

Un [Chart](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/) è una forma. L'esempio sotto estrae un'immagine dal riempimento immagine dell'area del grafico.

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

## **Estrai immagini da forme SmartArt**

Un oggetto [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/) è una forma. A seconda del layout SmartArt, le immagini possono essere memorizzate nei riempimenti dei punti elenco dei nodi o nei formati di riempimento delle forme dei nodi.

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

## **Includi immagini all'interno di forme raggruppate**

Le forme raggruppate contengono le proprie collezioni di forme. L'helper condiviso `enumerate_shapes` possiede un'opzione `include_grouped_shapes`. Impostarla su `True` quando si desidera ispezionare le forme all'interno di oggetti [GroupShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/groupshape/). L'esempio sotto estrae immagini da cornici immagine, forme con riempimento immagine, anteprime oggetti OLE, miniature cornici video e miniature cornici audio. Per includere anche immagini di tabelle, grafici, SmartArt e summary zoom, riutilizzare la logica di estrazione specializzata delle sezioni precedenti mantenendo lo stesso attraversamento ricorsivo delle forme.

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

## **Casi limite e note pratiche**

- **Immagini duplicate:** più forme possono fare riferimento alla stessa immagine o a immagini separate con byte identici. Eseguire l'hash di [PPImage.getBinaryData](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getBinaryData) prima di scrivere i file se si desidera un file di output per ogni immagine unica.
- **Dati originali vs. output convertito:** salvare [PPImage.getBinaryData](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getBinaryData) preserva i dati JPEG, PNG, GIF, SVG, EMF o WMF incorporati. Salvare [PPImage.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getImage) tramite `save` è utile quando si vuole un formato di output coerente.
- **Tipi di riempimento non supportati:** forme solide, gradiente, motivo e senza riempimento non contengono un riempimento immagine. Controllare [FillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) prima di leggere [getPictureFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Forme raggruppate:** la collezione di forme di livello superiore della diapositiva non appiattisce i gruppi. Ispezionare ricorsivamente [GroupShape.getShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/groupshape/#getShapes) quando il contenuto raggruppato è rilevante.
- **Anteprime oggetti OLE:** un [OleObjectFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/) può esporre un'immagine anteprima tramite [getSubstitutePictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), ma quell'immagine è solo l'anteprima della diapositiva. Non è il file incorporato all'interno dell'oggetto OLE.
- **Miniature cornici video:** un [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) può esporre un'immagine anteprima tramite [getPictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#getPictureFormat), ma quell'immagine è solo la locandina mostrata sulla diapositiva. Non è estratta dal flusso video.
- **Miniature cornici audio:** un [AudioFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/) può esporre un'icona o miniatura tramite [getPictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#getPictureFormat); non è il dato audio incorporato.
- **Immagini zoom:** le forme slide zoom, section zoom e summary zoom possono usare oggetti [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) personalizzati tramite [getZoomImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Modelli di forma annidati:** gli oggetti tabella, grafico e SmartArt implementano [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/), ma le loro immagini sono spesso memorizzate in oggetti di formattazione di celle di tabella, elementi di grafico o nodi SmartArt.
- **Immagini ritagliate o trasformate:** accedere a [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) restituisce la risorsa immagine memorizzata. Non renderizza ritagli, trasparenza, recolore, rotazione o altri effetti visivi applicati dalla forma.

## **FAQ**

**Posso estrarre l'immagine originale senza ritagli, effetti o trasformazioni della forma?**

Sì. Accedere all'oggetto [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) e scrivere [PPImage.getBinaryData](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getBinaryData) su disco. Questo preserva l'immagine codificata originale memorizzata nella presentazione, non il modo in cui l'immagine viene renderizzata sulla diapositiva.

**Posso esportare ogni immagine estratta come PNG?**

Sì. Utilizzare [PPImage.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getImage) per ottenere un oggetto immagine, quindi chiamare `save` con [ImageFormat.Png](https://reference.aspose.com/slides/it/python-java/aspose.slides/imageformat/). Questo converte l'output e può non preservare il tipo di file originale o i dati vettoriali.

**Come evito di salvare la stessa immagine più di una volta?**

Usare un hash di [PPImage.getBinaryData](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getBinaryData) e mantenere gli hash in un set. Se una nuova immagine ha un hash già presente, saltarla o registrare un altro riferimento al file di output esistente.

**Perché alcune forme non producono un'immagine?**

Cornici immagine, forme con riempimento immagine, cornici oggetto OLE, cornici multimediali, cornici zoom, tabelle, grafici e oggetti SmartArt possono fare riferimento a immagini. Alcuni tipi di forma espongono immagini tramite oggetti di formattazione annidati, quindi un semplice controllo di [getPictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#getPictureFormat) o di forma [getFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getFillFormat) non è sempre sufficiente.

**Posso estrarre la miniatura mostrata per una cornice video?**

Sì. Utilizzare [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) e leggere [getPictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#getImage). Questo estrae l'immagine locandina memorizzata con la cornice video, non un fotogramma generato dal file video.

**Come posso determinare quali forme usano un'immagine specifica dalla collezione immagini della presentazione?**

Aspose.Slides non memorizza collegamenti inversi da [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) a forme. Costruire una mappatura durante l'attraversamento: ogni volta che si trova un riferimento immagine, registrare il numero della diapositiva, il percorso della forma e l'hash o l'elemento della collezione.

**Posso estrarre le immagini incorporate dentro oggetti OLE, come documenti allegati?**

È possibile estrarre l'anteprima della diapositiva dell'oggetto OLE tramite [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Tuttavia, quell'anteprima non è il documento incorporato stesso. Per estrarre le immagini dall'interno del file incorporato, estrarre i dati OLE e ispezionarli con strumenti adatti a quel tipo di file.