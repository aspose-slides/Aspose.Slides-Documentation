---
title: Képek kinyerése a prezentáció alakzataiból Pythonon keresztül Java-val
linktitle: Kép az alakzatról
type: docs
weight: 100
url: /hu/python-java/extracting-images-from-presentation-shapes/
keywords:
- kép kinyerése
- kép lekérése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Képek kinyerése a PowerPoint és OpenDocument prezentációk alakzataiból az Aspose.Slides for Python via Java segítségével – gyors, kódközpontú megoldás."
---
## **Áttekintés**

A prezentációban a képek többféle alakzattípusban jelenhetnek meg: egyszerű képkeretként, alakzatokra alkalmazott képpel kitöltve, OLE‑objektum előnézeti képként, videó‑ vagy hangkeret bélyegképként, nagyítási képként, vagy táblázat, diagram és SmartArt alakzatokba ágyazott képként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amely a [ImageCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/) és a [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) objektumokon keresztül érhető el.

Ha csak az összes beágyazott képernyőforrásra van szükség, iteráljon a [Presentation.getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) segítségével. Ez a cikk egy másik feladatra összpontosít: a alakzatok bejárására, hogy megtalálja, hol használják a képeket a diákon, így a mentett fájlok megőrizhetik a hasznos kontextust, például a diaszámot, az alakzat pozícióját és a forrástípust (képkeret, kitöltő kép, médiaelőnézet, OLE‑előnézet vagy nagyítási kép).

{{% alert title="Tip" color="success" %}}
Használja a [PPImage.getBinaryData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getBinaryData) metódust az eredeti kódolt képadat és fájltípus megőrzéséhez. Használja a [PPImage.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getImage) metódust a `save` hívással, ha a kimenetet egy meghatározott formátumra (például PNG) szeretné normalizálni.
{{% /alert %}}

## **Megosztott Segédfüggvények**

Mentse el az alábbi megosztott segédfüggvényeket a `image_helpers.py` fájlba a példascriptek mellé. Rövidítik a példákat. A `save_original_image` függvény az eredeti beágyazott bájtokat írja, a MIME‑típus alapján biztonságos kiterjesztést választ, és a SHA‑256 hash alapján kihagyja a duplikált képbinary‑kat.

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

## **Képek kinyerése képkeretekből**

Ezt a megközelítést használja önálló objektumként beszúrt képekhez. A [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) a képet a [getPictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#getPictureFormat), a [getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#getPicture) és a [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#getImage) metódusokon keresztül biztosítja, amelyek egy [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) objektumot adnak vissza.

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

## **Képpel kitöltött alakzatokból képek kinyerése**

Az alakzatok képet használhatnak kitöltésként. Először ellenőrizze az alakzat kitöltéstípust: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/), nincs kép, amit a kitöltésből ki lehetne nyerni. Az alábbi példa a [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) objektumokat kezeli, és minden képet PNG‑ként ment a [PPImage.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getImage) segítségével.

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

## **Előnézeti képek kinyerése OLE‑objektum keretekből**

Egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) helyettesítő képpel rendelkezhet, amelyet a PowerPoint a diához tartozó előnézetként használ. Ez a kép a [getSubstitutePictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), a [getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#getPicture) és a [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#getImage) segítségével érhető el. Ennek a képrésznek a kinyerése az előnézeti képet adja, nem az OLE‑csomag beágyazott tartalmát.

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

## **Előnézeti képek kinyerése videókeretekből**

Egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) a [getPictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#getPictureFormat), a [getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#getPicture) és a [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#getImage) metódusok segítségével tárolhat előnézeti képet. Ez a poszter vagy bélyegkép, amely a dián látható, nem a videó adatfolyamból dekódolt képkocka.

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

## **Előnézeti képek kinyerése audio keretekből**

Egy [AudioFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/) a [getPictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#getPictureFormat), a [getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#getPicture) és a [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#getImage) segítségével tárolhat bélyegképet. Ez a kép jelenik meg az audio objektumhoz a dián.

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

## **Képek kinyerése zoom objektumokból**

A [ZoomFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zoomframe/) és a [SectionZoomFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sectionzoomframe/) alakzatok használhatnak egyedi képeket. Olvassa ki a [getZoomImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zoomobject/#getZoomImage) metódust a zoom keretből.

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

## **Képek kinyerése összegző zoom keretekből**

A [SummaryZoomFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/summaryzoomframe/) szintén egy alakzat. Szekcióelemei egyedi képeket használhatnak, amelyeket minden összegző zoom szekció [getZoomImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zoomobject/#getZoomImage) metódusa biztosít.

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

## **Képek kinyerése táblázat alakzatokból**

Egy [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) egy alakzat. A táblázatban lévő képek általában képpel kitöltött táblacellákban tárolódnak.

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

## **Képek kinyerése diagram alakzatokból**

Egy [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) egy alakzat. Az alábbi példa a diagramterület képpel kitöltéséből nyer ki egy képet.

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

## **Képek kinyerése SmartArt alakzatokból**

Egy [SmartArt](https://reference.aspose.com/slides/hu/python-java/aspose.slides/smartart/) objektum egy alakzat. A SmartArt elrendezésétől függően a képek a csomópont golyókitöltéseiben vagy a csomópont alakzatok kitöltési formátumaiban tárolódhatnak.

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

## **Képek belefoglalása csoportosított alakzatokba**

A csoportosított alakzatok saját alakzategységekkel rendelkeznek. A megosztott `enumerate_shapes` segédfüggvénynek van egy `include_grouped_shapes` opciója. Állítsa `True`‑ra, ha a [GroupShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/groupshape/) objektumok belső alakzatait is vizsgálni szeretné. Az alábbi példa képeket nyer ki képkeretekből, képpel kitöltött alakzatokból, OLE‑objektum előnézetekből, videókeret bélyegképekből és audio keret bélyegképekből. A táblázat, diagram, SmartArt és összegző zoom képek bevonásához használja újra a korábbi szakaszokban bemutatott speciális kinyerési logikát, miközben ugyanazt a rekurzív alakzat-bejárást alkalmazza.

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

## **Különleges esetek és gyakorlati megjegyzések**

- **Duplikált képek:** Több alakzat is hivatkozhat ugyanarra a képre, vagy különálló, azonos bájtokkal rendelkező képekre. Használja a [PPImage.getBinaryData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getBinaryData) hash‑elését a fájlok írása előtt, ha egy kimeneti fájlt szeretne minden egyedi képhez.
- **Eredeti adat vs. konvertált kimenet:** A [PPImage.getBinaryData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getBinaryData) mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatokat. A [PPImage.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getImage) `save`‑elése hasznos, ha egységes kimeneti formátumra van szükség.
- **Nem támogatott kitöltéstípusok:** Szilárd, színátmenetes, mintás és üres kitöltésű alakzatok nem tartalmaznak képpel kitöltést. Ellenőrizze a [FillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) értékét, mielőtt a [getPictureFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#getPictureFillFormat) metódust hívná.
- **Csoportosított alakzatok:** A felső szintű dia‑alakzategység nem laposítja a csoportokat. Rekurzívan vizsgálja meg a [GroupShape.getShapes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/groupshape/#getShapes) eredményét, ha a csoportos tartalom lényeges.
- **OLE‑objektum előnézete:** Egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/) a [getSubstitutePictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) metóduson keresztül adhat előnézeti képet, de ez csak a dia‑előnézet, nem az OLE‑objektumban beágyazott fájl.
- **Videókeret bélyegképek:** Egy [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) a [getPictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#getPictureFormat) metóduson keresztül adhat előnézeti képet, de ez csak a dián megjelenő poszter, nem a videó adatfolyamból származik.
- **Audio keret bélyegképek:** Egy [AudioFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/audioframe/) a [getPictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#getPictureFormat) metódussal mutathat ikont vagy bélyegképet; ez nem a beágyazott audio adat.
- **Nagyítási képek:** Diánagyítás, szekció‑nagyítás és összegző nagyítás alakzatok egyedi [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) objektumokat használhatnak a [getZoomImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zoomobject/#getZoomImage) segítségével.
- **Egymásba ágyazott alakzatmodellek:** A táblázat, diagram és SmartArt objektumok implementálják a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) interfészt, de képeik gyakran a beágyazott táblacellák, diagramelemek vagy SmartArt csomópont formázási objektumaiban tárolódnak.
- **Vágott vagy átalakított képek:** A [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) elérése csak a tárolt képernyőforrást adja vissza. Nem jeleníti meg a vágást, átlátszóságot, színezést, forgatást vagy egyéb vizuális effektusokat, amelyeket az alakzat alkalmaz.

## **GYIK**

**Kivonhatom az eredeti képet vágás, effektus vagy alakzatra vonatkozó átalakítás nélkül?**

Igen. Hozzáférhet a [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) objektumhoz, és a [PPImage.getBinaryData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getBinaryData) segítségével írhatja le a lemezen. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig a dián megjelenített változatot.

**Exportálhatom az összes kinyert képet PNG formátumban?**

Igen. Használja a [PPImage.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getImage) metódust egy képobjektum lekéréséhez, majd hívja a `save`‑t a [ImageFormat.Png](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imageformat/) paraméterrel. Ez átalakítja a kimenetet, és előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektoradatot.

**Hogyan kerülhetem el, hogy ugyanazt a képet többször mentsem?**

Használjon hash‑t a [PPImage.getBinaryData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#getBinaryData) eredményéből, és tárolja a hash‑eket egy halmazban. Ha egy új kép hash‑e már létezik, hagyja ki, vagy csak egy hivatkozást rögzítsen a már létező kimeneti fájlra.

**Miért nem ad ki néhány alakzat képet?**

Képkeretek, képpel kitöltött alakzatok, OLE‑objektum keretek, média‑keretek, nagyítási keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Némely alakzattípus a képeket beágyazott formázási objektumokon keresztül teszi elérhetővé, így egy egyszerű [getPictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#getPictureFormat) vagy alakzat [getFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getFillFormat) ellenőrzés nem mindig elegendő.

**Kinyerhetem a videókerethez tartozó bélyegképet?**

Igen. Használja a [VideoFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/videoframe/) objektumot, és olvassa a [getPictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#getPictureFormat), a [getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#getPicture) és a [getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#getImage) metódusokat. Ez a videókerethez tárolt poszterképet adja, nem a videófájl által generált képkockát.

**Hogyan határozhatom meg, mely alakzatok használnak egy adott képet a prezentáció képgyűjteményéből?**

Az Aspose.Slides nem tárol visszautalásokat a [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) és az alakzatok között. A bejárás során építsen fel egy leképezést: amikor képre hivatkozik, vegye fel a diaszámot, az alakzat útvonalát és a kép hash‑ét vagy a gyűjteményben elfoglalt helyét.

**Kinyerhetek képeket az OLE‑objektumokba ágyazott dokumentumokból?**

Kinyerheti az OLE‑objektum dia‑előnézetét a [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) segítségével. Azonban ez az előnézet nem a beágyazott dokumentum maga. A beágyazott fájlban lévő képek kinyeréséhez először ki kell nyerni az OLE‑adatait, majd a megfelelő eszközökkel megvizsgálni azt.