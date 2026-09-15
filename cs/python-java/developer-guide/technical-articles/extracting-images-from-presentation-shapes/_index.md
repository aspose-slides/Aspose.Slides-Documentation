---
title: Extrahování obrázků z tvarů prezentace v Pythonu přes Java
linktitle: Obrázek ze tvaru
type: docs
weight: 100
url: /cs/python-java/extracting-images-from-presentation-shapes/
keywords:
- extrahovat obrázek
- získat obrázek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Extrahujte obrázky z tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java – rychlé a programátorsky přívětivé řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou objevit v několika typech tvarů: jako běžné rámečky obrázků, jako výplně obrázkem aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury video‑ nebo audio‑snímků, jako zoom obrázky nebo jako obrázky vložené v tabulce, grafu a tvarech SmartArt. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, přístupné přes [ImageCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imagecollection/) a [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) objekty.

Pokud potřebujete exportovat každý obrázkový zdroj vložený v prezentaci, projděte [Presentation.getImages](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getImages). Tento článek se soustředí na jiný úkol: procházet tvary a najít, kde jsou na snímcích použity obrázky, aby uložené soubory mohly zachovat užitečný kontext, jako je číslo snímku, pozice tvaru a typ zdroje (rámeček obrázku, výplň obrázkem, náhled média, OLE náhled nebo zoom obrázek).

{{% alert title="Tip" color="success" %}}

Použijte [PPImage.getBinaryData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getBinaryData) k zachování původních zakódovaných dat obrázku a typu souboru. Použijte [PPImage.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getImage) s metodou `save`, pokud chcete normalizovat výstup na konkrétní formát, například PNG.

{{% /alert %}}

## **Sdílené pomocné funkce**

Uložte níže uvedené sdílené pomocné funkce do souboru `image_helpers.py` vedle ukázkových skriptů. Zkracují příklady. `save_original_image` zapisuje původní vložené bajty, vybírá bezpečnou příponu podle MIME typu a přeskočí duplicitní binární obrázky podle SHA‑256 hash.

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

## **Extrahování obrázků z rámečků obrázků**

Použijte tento přístup pro obrázky vložené jako samostatné objekty. [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) poskytuje přístup ke svému obrázku přes [getPictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#getPicture) a [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#getImage), které vrací objekt [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/).

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

## **Extrahování obrázků z tvarů vyplněných obrázkem**

Tvary mohou používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud to není [FillType.Picture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/), neexistuje obrázek, který by se z této výplně mohl extrahovat. Níže uvedený příklad pracuje s objekty [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) a ukládá každý obrázek jako PNG pomocí [PPImage.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getImage).

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

## **Extrahování náhledových obrázků z OLE objektových rámců**

[OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný přes [getSubstitutePictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#getPicture) a [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#getImage). Extrahování tohoto obrázku vám poskytne náhled, nikoli vložený obsah OLE balíčku.

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

## **Extrahování náhledových obrázků z video rámců**

[VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) může také uložit náhledový obrázek v [getPictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#getPicture) a [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#getImage). Jedná se o plakát nebo miniaturu zobrazovanou na snímku, nikoli o snímek dekódovaný z video streamu.

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

## **Extrahování náhledových obrázků z audio rámců**

[AudioFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/) může uložit miniaturu v [getPictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#getPicture) a [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#getImage). Jedná se o obrázek zobrazovaný pro audio objekt na snímku.

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

## **Extrahování obrázků ze Zoom objektů**

[ZoomFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomframe/) a [SectionZoomFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sectionzoomframe/) mohou používat vlastní obrázky. Přečtěte [getZoomImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomobject/#getZoomImage) ze Zoom rámce.

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

## **Extrahování obrázků ze souhrnných Zoom rámců**

[SummaryZoomFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/summaryzoomframe/) je také tvarem. Jeho položky sekcí mohou používat vlastní obrázky, které jsou vystaveny metodou [getZoomImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomobject/#getZoomImage) každé sekce souhrnného Zoomu.

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

## **Extrahování obrázků z tvarů tabulky**

[Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/) je tvarem. Obrázky v tabulce jsou obvykle ukládány jako výplně obrázkem v buňkách tabulky.

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

## **Extrahování obrázků z tvarů grafu**

[Chart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/) je tvarem. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblasti grafu.

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

## **Extrahování obrázků z tvarů SmartArt**

[SmartArt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/smartart/) je objekt tvarem. V závislosti na rozložení SmartArt mohou být obrázky uloženy ve výplních odrážek uzlů nebo ve výplňových formátech uzlových tvarů.

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

## **Zahrnutí obrázků uvnitř seskupených tvarů**

Seskupené tvary obsahují své vlastní kolekce tvarů. Sdílený pomocník `enumerate_shapes` má volbu `include_grouped_shapes`. Nastavte ji na `True`, když chcete prozkoumat tvary uvnitř objektů [GroupShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/groupshape/). Níže uvedený příklad extrahuje obrázky z rámečků obrázků, tvarů vyplněných obrázkem, náhledů OLE objektů, miniatur video rámců a miniatur audio rámců. Pro zahrnutí obrázků z tabulek, grafů, SmartArt a souhrnných zoomů také využijte specializovanou logiku extrakce z předchozích sekcí při zachování stejného rekurzivního procházení tvarů.

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

## **Hraniční případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky se stejnými bajty. Hashujte [PPImage.getBinaryData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getBinaryData) před zápisem souborů, pokud chcete jeden výstupní soubor na jedinečný obrázek.
- **Originální data vs. konvertovaný výstup:** Ukládání [PPImage.getBinaryData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getBinaryData) zachovává vložená data JPEG, PNG, GIF, SVG, EMF nebo WMF. Ukládání [PPImage.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getImage) přes `save` je užitečné, když potřebujete jednotný výstupní formát.
- **Nevyhovující typy výplní:** Plné, gradientní, vzorové a žádné výplně neobsahují obrázkovou výplň. Zkontrolujte [FillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/) před čtením [getPictureFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku nevyhlazuje seskupení. Rekurzivně prohlédněte [GroupShape.getShapes](https://reference.aspose.com/slides/cs/python-java/aspose.slides/groupshape/#getShapes), když je důležitý seskupený obsah.
- **Náhledy OLE objektů:** [OleObjectFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/) může zveřejnit náhledový obrázek přes [getSubstitutePictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), ale tento obrázek je jen náhled na snímku. Není to vložený soubor uvnitř OLE objektu.
- **Miniatury video rámců:** [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) může zveřejnit náhledový obrázek přes [getPictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#getPictureFormat), ale tento obrázek je jen plakát zobrazený na snímku. Není extrahován z video streamu.
- **Miniatury audio rámců:** [AudioFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/audioframe/) může zveřejnit ikonu nebo miniaturu přes [getPictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#getPictureFormat); není to vložený audio soubor.
- **Zoom obrázky:** Tvary slide zoom, section zoom a summary zoom mohou používat vlastní [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) objekty přes [getZoomImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Vnořené modely tvarů:** Tabulky, grafy a SmartArt objekty implementují [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/), ale jejich obrázky jsou často uloženy ve vnořených buňkách tabulky, elementech grafu nebo formátovacích objektech uzlů SmartArt.
- **Oříznuté nebo transformované obrázky:** Přístup k [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) vám dává uložený obrázkový zdroj. Neprovádí ořez, transparentnost, změnu barvy, rotaci ani jiné vizuální efekty aplikované tvarem.

## **Často kladené otázky**

**Mohu extrahovat původní obrázek bez ořezů, efektů nebo transformací tvaru?**

Ano. Přistupte k objektu [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) a zapište [PPImage.getBinaryData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getBinaryData) na disk. Tím se zachová původní zakódovaný obrázek uložený v prezentaci, ne to, jak je obrázek vykreslen na snímku.

**Mohu exportovat každý extrahovaný obrázek jako PNG?**

Ano. Použijte [PPImage.getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getImage) k získání objektu obrázku a pak zavolejte `save` s [ImageFormat.Png](https://reference.aspose.com/slides/cs/python-java/aspose.slides/imageformat/). Tento převod může neuchovat původní typ souboru nebo vektorová data.

**Jak zabránit uložení stejných obrázků vícekrát?**

Použijte hash [PPImage.getBinaryData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/#getBinaryData) a udržujte hash v množině. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

**Proč některé tvary neprodukují obrázek?**

Rámečky obrázků, tvary vyplněné obrázkem, OLE objektové rámce, multimediální rámečky, zoom rámečky, tabulky, grafy a SmartArt objekty mohou odkazovat na obrázky. Některé typy tvarů exposují obrázky přes vnořené formátovací objekty, takže jednoduchá kontrola [getPictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#getPictureFormat) nebo [getFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getFillFormat) není vždy dostačující.

**Mohu extrahovat miniaturu zobrazenou pro video rámec?**

Ano. Použijte [VideoFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/videoframe/) a přečtěte [getPictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picturefillformat/#getPicture) a [getImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/picture/#getImage). Tím získáte plakátový obrázek uložený s video rámcem, ne snímek generovaný z video souboru.

**Jak zjistit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?**

Aspose.Slides neukládá reverzní odkazy z [PPImage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/ppimage/) na tvary. Vytvořte mapování během procházení: kdykoliv najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a hash nebo položku kolekce.

**Mohu extrahovat obrázky vložené uvnitř OLE objektů, například připojené dokumenty?**

Můžete extrahovat náhled OLE objektu pomocí [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Tento náhled však není samotný vložený dokument. Pro extrakci obrázků z vnitřního souboru nejprve extrahujte OLE data a prozkoumejte je nástroji určenými pro daný typ souboru.