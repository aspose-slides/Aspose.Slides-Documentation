---
title: Bilder aus Präsentationsformen in Python via Java extrahieren
linktitle: Bild aus Form
type: docs
weight: 100
url: /de/python-java/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java extrahieren - schnelle, code-freundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in mehreren Formtypen auftreten: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als OLE‑Objekt‑Vorschaubilder, als Video‑ oder Audio‑Miniaturansichten, als Zoom‑Bilder oder als in Tabellen‑, Diagramm‑ und SmartArt‑Formen eingebettete Bilder. Aspose.Slides speichert diese Bilder in der Präsentations‑Bildsammlung, die über die [ImageCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/imagecollection/) und [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) Objekte bereitgestellt wird.

Wenn Sie nur alle in einer Präsentation eingebetteten Bildressourcen exportieren müssen, iterieren Sie über [Presentation.getImages](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getImages). Dieser Artikel behandelt eine andere Aufgabe: das Durchlaufen von Formen, um herauszufinden, wo Bilder auf Folien verwendet werden, sodass die gespeicherten Dateien nützlichen Kontext wie Foliennummer, Position der Form und Quelltyp (Bildrahmen, Bildfüllung, Medien‑Vorschau, OLE‑Vorschau oder Zoom‑Bild) beibehalten können.

{{% alert title="Tip" color="success" %}}
Verwenden Sie [PPImage.getBinaryData](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getBinaryData), um die ursprünglich codierten Bilddaten und den Dateityp zu erhalten. Verwenden Sie [PPImage.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getImage) mit `save`, wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren wollen.
{{% /alert %}}

## **Gemeinsame Hilfsfunktionen**

Speichern Sie die untenstehenden gemeinsamen Hilfsfunktionen in `image_helpers.py` neben den Beispiel‑Scripts. Sie halten die Beispiele kompakt. `save_original_image` schreibt die ursprünglichen eingebetteten Bytes, wählt eine sichere Erweiterung aus dem MIME‑Typ und überspringt Duplikate anhand des SHA‑256‑Hashes.

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

## **Bilder aus Bildrahmen extrahieren**

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [PictureFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/) bietet über [getPictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#getPicture) und [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#getImage) Zugriff auf das Bild, das ein [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) Objekt zurückgibt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zuerst den Fülltyp der Form: Wenn er nicht [FillType.Picture](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/) ist, gibt es kein Bild zum Extrahieren. Das untenstehende Beispiel verarbeitet [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) Objekte und speichert jedes Bild als PNG über [PPImage.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getImage).

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

## **Vorschaubilder aus OLE‑Objekt‑Frames extrahieren**

Ein [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) kann ein Ersatzbild besitzen, das PowerPoint als Vorschau des Objekts auf einer Folie nutzt. Dieses Bild ist über [getSubstitutePictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#getPicture) und [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#getImage) verfügbar. Das Extrahieren dieses Bildes liefert das Vorschaubild, nicht den eingebetteten OLE‑Paketinhalt.

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

## **Vorschaubilder aus Video‑Frames extrahieren**

Ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/) kann ebenfalls ein Vorschaubild in [getPictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#getPicture) und [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#getImage) speichern. Dies ist das Poster oder die Miniatur, die auf der Folie angezeigt wird, nicht ein aus dem Videostrom dekodierter Frame.

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

## **Vorschaubilder aus Audio‑Frames extrahieren**

Ein [AudioFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/) kann ein Miniaturbild in [getPictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#getPicture) und [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#getImage) speichern. Dies ist das Bild, das für das Audio‑Objekt auf der Folie angezeigt wird.

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

## **Bilder aus Zoom‑Objekten extrahieren**

[ZoomFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomframe/) und [SectionZoomFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectionzoomframe/) Formen können benutzerdefinierte Bilder verwenden. Lesen Sie [getZoomImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomobject/#getZoomImage) vom Zoom‑Frame.

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

## **Bilder aus Summary‑Zoom‑Frames extrahieren**

Ein [SummaryZoomFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/summaryzoomframe/) ist ebenfalls eine Form. Seine Abschnittselemente können benutzerdefinierte Bilder besitzen, die über die [getZoomImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomobject/#getZoomImage) Methode jedes Summary‑Zoom‑Abschnitts bereitgestellt werden.

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

## **Bilder aus Tabellenformen extrahieren**

Eine [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/) ist eine Form. Bilder in einer Tabelle werden meist als Bildfüllungen in Tabellzellen gespeichert.

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

## **Bilder aus Diagrammformen extrahieren**

Ein [Chart](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/) ist eine Form. Das untenstehende Beispiel extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

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

## **Bilder aus SmartArt‑Formen extrahieren**

Ein [SmartArt](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartart/) Objekt ist eine Form. Je nach SmartArt‑Layout können Bilder in Knoten‑Aufzählungs‑Füllungen oder in den Füllformaten von Knotenformen gespeichert sein.

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

## **Bilder in Gruppenformen einbeziehen**

Gruppierte Formen enthalten eigene Formsammlungen. Der gemeinsam genutzte `enumerate_shapes`‑Hilfsfunktion bietet die Option `include_grouped_shapes`. Setzen Sie sie auf `True`, wenn Sie Formen innerhalb von [GroupShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/groupshape/) Objekten prüfen wollen. Das untenstehende Beispiel extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE‑Objekt‑Vorschauen, Video‑Frame‑Miniaturansichten und Audio‑Frame‑Miniaturansichten. Um auch Bilder aus Tabellen, Diagrammen, SmartArt und Summary‑Zoom‑Bildern einzubeziehen, nutzen Sie die spezialisierte Extraktionslogik aus den vorherigen Abschnitten bei gleichzeitigem rekursivem Durchlauf der Formen.

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

## **Randfälle und praktische Hinweise**

- **Doppelte Bilder:** Mehrere Formen können dasselbe Bild referenzieren oder verschiedene Bilder mit identischen Bytes besitzen. Hashen Sie [PPImage.getBinaryData](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getBinaryData) bevor Sie Dateien schreiben, wenn Sie pro einzigartigem Bild nur eine Ausgabedatei wünschen.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern von [PPImage.getBinaryData](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getBinaryData) bewahrt die eingebetteten JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ oder WMF‑Daten. Das Speichern von [PPImage.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getImage) über `save` ist nützlich, wenn Sie ein einheitliches Ausgabeformat benötigen.
- **Nicht unterstützte Fülltypen:** Solide, Gradient‑, Muster‑ und keine‑Füll‑Formen enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/) bevor Sie [getPictureFillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/#getPictureFillFormat) auslesen.
- **Gruppierte Formen:** Die oberste Formsammlung einer Folie flacht Gruppen nicht ab. Durchsuchen Sie rekursiv [GroupShape.getShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/groupshape/#getShapes), wenn gruppierter Inhalt relevant ist.
- **OLE‑Objekt‑Vorschauen:** Ein [OleObjectFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/) kann ein Vorschaubild über [getSubstitutePictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) bereitstellen, aber dieses Bild ist nur die Folien‑Vorschau. Es ist nicht die eingebettete Datei im OLE‑Objekt.
- **Video‑Frame‑Miniaturansichten:** Ein [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/) kann ein Vorschaubild über [getPictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#getPictureFormat) bereitstellen, aber dieses Bild ist nur das Poster, das auf der Folie angezeigt wird. Es wird nicht aus dem Videostrom extrahiert.
- **Audio‑Frame‑Miniaturansichten:** Ein [AudioFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/audioframe/) kann ein Symbol oder eine Miniatur über [getPictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#getPictureFormat) bereitstellen; es ist nicht das eingebettete Audiodaten‑File.
- **Zoom‑Bilder:** Slide‑Zoom, Section‑Zoom und Summary‑Zoom Formen können benutzerdefinierte [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) Objekte über [getZoomImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/zoomobject/#getZoomImage) nutzen.
- **Verschachtelte Formmodelle:** Tabellen-, Diagramm‑ und SmartArt‑Objekte implementieren [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/), aber ihre Bilder werden oft in verschachtelten Zellen, Diagrammelementen oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Beschnittene oder transformierte Bilder:** Der Zugriff auf [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) liefert die gespeicherte Bildressource. Es werden keine Beschnitte, Transparenzen, Nachfärbungen, Drehungen oder andere visuelle Effekte, die von der Form angewendet wurden, gerendert.

## **FAQ**

**Kann ich das Originalbild ohne Beschnitt, Effekte oder Formtransformationen extrahieren?**

Ja. Greifen Sie auf das [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) Objekt zu und schreiben Sie [PPImage.getBinaryData](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getBinaryData) auf die Festplatte. Damit bleibt das original codierte Bild erhalten, nicht die Art, wie das Bild auf der Folie gerendert wird.

**Kann ich jedes extrahierte Bild als PNG exportieren?**

Ja. Verwenden Sie [PPImage.getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getImage), um ein Bildobjekt zu erhalten, und rufen Sie dann `save` mit [ImageFormat.Png](https://reference.aspose.com/slides/de/python-java/aspose.slides/imageformat/) auf. Dies konvertiert die Ausgabe und kann den ursprünglichen Dateityp oder Vektordaten nicht beibehalten.

**Wie vermeide ich, dasselbe Bild mehrmals zu speichern?**

Verwenden Sie einen Hash von [PPImage.getBinaryData](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/#getBinaryData) und führen Sie die Hash‑Werte in einer Menge. Wenn ein neues Bild einen bereits vorhandenen Hash hat, überspringen Sie es oder verweisen Sie auf die bereits vorhandene Ausgabedatei.

**Warum erzeugen einige Formen kein Bild?**

Bildrahmen, bildgefüllte Formen, OLE‑Objekt‑Frames, Medien‑Frames, Zoom‑Frames, Tabellen, Diagramme und SmartArt‑Objekte können Bilder referenzieren. Manche Formtypen stellen Bilder über verschachtelte Formatierungsobjekte bereit, sodass ein einfacher Aufruf von [getPictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#getPictureFormat) oder [getFillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getFillFormat) nicht ausreicht.

**Kann ich das Thumbnail eines Video‑Frames extrahieren?**

Ja. Verwenden Sie [VideoFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/videoframe/) und lesen Sie [getPictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/#getPicture) und [getImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/picture/#getImage). Damit wird das Poster‑Bild extrahiert, das mit dem Video‑Frame gespeichert ist, nicht ein Frame, der aus der Videodatei generiert wurde.

**Wie kann ich feststellen, welche Formen ein bestimmtes Bild aus der Präsentations‑Bildsammlung verwenden?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/) zu Formen. Erstellen Sie während des Durchlaufs eine Zuordnung: Wann immer Sie eine Bildreferenz finden, protokollieren Sie die Foliennummer, den Formpfad und den Bild‑Hash bzw. das Sammlungs‑Item.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Sie können die Folien‑Vorschau des OLE‑Objekts über [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) extrahieren. Diese Vorschau ist jedoch nicht das eigentliche eingebettete Dokument. Um Bilder aus der eingebetteten Datei zu erhalten, extrahieren Sie die OLE‑Daten und untersuchen Sie diese mit passenden Werkzeugen für den jeweiligen Dateityp.