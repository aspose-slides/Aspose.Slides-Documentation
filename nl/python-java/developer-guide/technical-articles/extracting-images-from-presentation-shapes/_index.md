---
title: Afbeeldingen extraheren uit presentatievormen in Python via Java
linktitle: Afbeelding van vorm
type: docs
weight: 100
url: /nl/python-java/extracting-images-from-presentation-shapes/
keywords:
- afbeelding extraheren
- afbeelding ophalen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Afbeeldingen extraheren uit vormen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java - snelle, code-vriendelijke oplossing."
---
## **Overzicht**

Afbeeldingen in een presentatie kunnen in verschillende vormtypen voorkomen: als gewone afbeeldingskaders, als afbeeldingvullingen toegepast op vormen, als voorbeeldafbeeldingen van OLE‑objecten, als miniaturen van video‑ of audiokaders, als zoomafbeeldingen, of als afbeeldingen genesteld in tabel‑, grafiek‑ en SmartArt‑vormen. Aspose.Slides slaat deze afbeeldingen op in de afbeeldingsverzameling van de presentatie, toegankelijk via de ImageCollection‑ en PPImage‑objecten.

Als u alleen elke in een presentatie ingesloten afbeeldingsbron wilt exporteren, doorloopt u Presentation.getImages. Dit artikel richt zich op een andere taak: vormen doorlopen om te vinden waar afbeeldingen op dia's worden gebruikt, zodat de opgeslagen bestanden nuttige context kunnen behouden, zoals het dia‑nummer, de positie van de vorm en het type bron (afbeeldingskader, vulafbeelding, mediavoorbeeld, OLE‑voorbeeld of zoomafbeelding).

{{% alert title="Tip" color="success" %}}
Gebruik PPImage.getBinaryData om de oorspronkelijke gecodeerde afbeeldingsgegevens en bestandstype te behouden. Gebruik PPImage.getImage met `save` wanneer u de output wilt normaliseren naar een specifiek formaat, zoals PNG.
{{% /alert %}}

## **Gedeelde hulpfuncties**

Sla de onderstaande gedeelde hulpfuncties op in `image_helpers.py` naast de voorbeeldscripts. Ze houden de voorbeelden kort. `save_original_image` schrijft de originele ingesloten bytes, kiest een veilige extensie op basis van het MIME‑type, en slaat dubbele afbeeldingsbinaire bestanden over op basis van een SHA‑256‑hash.

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

## **Afbeeldingen extraheren uit afbeeldingskaders**

Gebruik deze aanpak voor afbeeldingen die als zelfstandige objecten zijn ingevoegd. Een PictureFrame biedt toegang tot zijn afbeelding via getPictureFormat, getPicture en getImage, die een PPImage‑object teruggeeft.

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

## **Afbeeldingen extraheren uit vormen met afbeeldingvulling**

Vormen kunnen een afbeelding als vulling gebruiken. Controleer eerst het vultype van de vorm: als dit niet FillType.Picture is, is er geen afbeelding om uit die vulling te extraheren. Het voorbeeld hieronder behandelt AutoShape‑objecten en slaat elke afbeelding op als PNG via PPImage.getImage.

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

## **Voorbeeldafbeeldingen extraheren uit OLE‑objectkaders**

Een OleObjectFrame kan een vervangende afbeelding hebben die PowerPoint gebruikt als voorbeeld van het object op een dia. Deze afbeelding is beschikbaar via getSubstitutePictureFormat, getPicture en getImage. Het extraheren van deze afbeelding levert de voorbeeldafbeelding op, niet de ingebedde OLE‑pakketinhoud.

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

## **Voorbeeldafbeeldingen extraheren uit videokaders**

Een VideoFrame kan ook een voorbeeldafbeelding opslaan via getPictureFormat, getPicture en getImage. Dit is de poster‑ of miniatuurafbeelding die op de dia wordt getoond, niet een frame dat uit de videostream is gedecodeerd.

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

## **Voorbeeldafbeeldingen extraheren uit audiokaders**

Een AudioFrame kan een miniatuur opslaan via getPictureFormat, getPicture en getImage. Dit is de afbeelding die voor het audio‑object op de dia wordt weergegeven.

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

## **Afbeeldingen extraheren uit zoomobjecten**

ZoomFrame‑ en SectionZoomFrame‑vormen kunnen aangepaste afbeeldingen gebruiken. Lees getZoomImage van het zoom‑frame.

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

## **Afbeeldingen extraheren uit samenvattende zoomkaders**

Een SummaryZoomFrame is eveneens een vorm. De sectie‑items kunnen aangepaste afbeeldingen gebruiken, toegankelijk via de getZoomImage‑methode van elke samenvattende zoom‑sectie.

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

## **Afbeeldingen extraheren uit tabelvormen**

Een Table is een vorm. Afbeeldingen in een tabel worden meestal opgeslagen als afbeeldingvullingen in tabelcellen.

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

## **Afbeeldingen extraheren uit grafiekvormen**

Een Chart is een vorm. Het voorbeeld hieronder extrahert een afbeelding uit de afbeeldingvulling van het grafiekgebied.

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

## **Afbeeldingen extraheren uit SmartArt‑vormen**

Een SmartArt‑object is een vorm. Afhankelijk van de SmartArt‑lay-out kunnen afbeeldingen opgeslagen zijn in de bullet‑vullingen van knooppunten of in de vulformaten van knooppunt‑vormen.

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

## **Afbeeldingen opnemen binnen gegroepeerde vormen**

Gegroepeerde vormen bevatten hun eigen vormverzamelingen. De gedeelde hulpfunctie `enumerate_shapes` heeft een `include_grouped_shapes`‑optie. Zet deze op `True` wanneer u vormen binnen GroupShape‑objecten wilt inspecteren. Het voorbeeld hieronder extrahert afbeeldingen uit afbeeldingskaders, met afbeelding gevulde vormen, OLE‑objectvoorbeelden, videokader‑miniaturen en audiokader‑miniaturen. Om ook tabel-, grafiek‑, SmartArt‑ en samenvattende zoom‑afbeeldingen op te nemen, hergebruik de gespecialiseerde extractielogica uit de voorgaande secties terwijl u dezelfde recursieve vormtraversal behoudt.

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

## **Randgevallen en praktische opmerkingen**

- **Dupliceerde afbeeldingen:** Meerdere vormen kunnen naar dezelfde afbeelding verwijzen of naar afzonderlijke afbeeldingen met identieke bytes. Hash PPImage.getBinaryData voordat u bestanden schrijft als u één uitgangsbestand per unieke afbeelding wilt.
- **Originele gegevens vs. geconverteerde output:** Het opslaan van PPImage.getBinaryData behoudt de ingebedde JPEG-, PNG-, GIF-, SVG-, EMF- of WMF-gegevens. Het opslaan van PPImage.getImage via `save` is handig wanneer u een consistent uitvoerformaat wilt.
- **Niet‑ondersteunde vullingen:** Vormen met een effen, gradient, patroon of zonder vulling bevatten geen afbeeldingvulling. Controleer FillType voordat u getPictureFillFormat leest.
- **Gegroepeerde vormen:** De vormverzameling van het bovenste dia‑niveau flatten geen groepen. Inspecteer recursief GroupShape.getShapes wanneer gegroepeerde inhoud van belang is.
- **OLE‑objectvoorbeelden:** Een OleObjectFrame kan een voorbeeldafbeelding blootleggen via getSubstitutePictureFormat, maar die afbeelding is alleen het dia‑voorbeeld. Het is niet het ingebedde bestand binnen het OLE‑object.
- **Miniaturen van videokaders:** Een VideoFrame kan een voorbeeldafbeelding blootleggen via getPictureFormat, maar die afbeelding is alleen de poster die op de dia wordt getoond. Het wordt niet uit de videostream gehaald.
- **Miniaturen van audiokaders:** Een AudioFrame kan een pictogram of miniatuur blootleggen via getPictureFormat; het is niet de ingebedde audio‑data.
- **Zoom‑afbeeldingen:** Dia‑zoom, sectie‑zoom en samenvattende zoom‑vormen kunnen aangepaste PPImage‑objecten gebruiken via getZoomImage.
- **Geneste vormmodellen:** Tabel‑, grafiek‑ en SmartArt‑objecten implementeren Shape, maar hun afbeeldingen worden vaak opgeslagen in geneste tabelcellen, grafiekelementen of SmartArt‑knooppunt‑formatteerobjecten.
- **Bijsneden of getransformeerde afbeeldingen:** Toegang tot PPImage levert de opgeslagen afbeeldingsbron. Het rendert geen bijsnijden, transparantie, herkleuring, rotatie of andere visuele effecten die op de vorm worden toegepast.

## **Veelgestelde vragen**

**Kan ik de originele afbeelding extraheren zonder bijsnijden, effecten of vormtransformaties?**

Ja. Toegang tot het PPImage‑object en schrijf PPImage.getBinaryData naar schijf. Dit behoudt de originele gecodeerde afbeelding die in de presentatie is opgeslagen, en niet de manier waarop de afbeelding op de dia wordt gerenderd.

**Kan ik elke geëxtraheerde afbeelding exporteren als PNG?**

Ja. Gebruik PPImage.getImage om een afbeeldingsobject te verkrijgen, en roep vervolgens `save` aan met ImageFormat.Png. Dit converteert de output en behoudt mogelijk niet het oorspronkelijke bestandsformaat of vectorgegevens.

**Hoe voorkom ik dat dezelfde afbeelding meer dan eens wordt opgeslagen?**

Gebruik een hash van PPImage.getBinaryData en bewaar de hashes in een set. Als een nieuwe afbeelding een al bestaande hash heeft, sla deze dan over of registreer een andere verwijzing naar het bestaande uitvoerbestand.

**Waarom leveren sommige vormen geen afbeelding?**

Afbeeldingskaders, met afbeelding gevulde vormen, OLE‑objectkaders, mediakaders, zoomkaders, tabellen, grafieken en SmartArt‑objecten kunnen naar afbeeldingen verwijzen. Sommige vormtypen tonen afbeeldingen via geneste opmaakobjecten, zodat een eenvoudige controle met getPictureFormat of shape getFillFormat niet altijd voldoende is.

**Kan ik de miniatuur die wordt getoond voor een videokader extraheren?**

Ja. Gebruik VideoFrame en lees getPictureFormat, getPicture en getImage. Dit extrahert de poster‑afbeelding die bij het videokader is opgeslagen, en niet een frame dat uit het videobestand wordt gegenereerd.

**Hoe kan ik bepalen welke vormen een specifieke afbeelding uit de afbeeldingsverzameling van de presentatie gebruiken?**

Aspose.Slides slaat geen omgekeerde koppelingen op van PPImage naar vormen. Bouw tijdens de doorloop een mapping: wanneer u een afbeeldingsverwijzing tegenkomt, registreer dan het dia‑nummer, het vormpad en de afbeelding‑hash of collectie‑item.

**Kan ik afbeeldingen extraheren die zijn ingesloten in OLE‑objecten, bijvoorbeeld bijgevoegde documenten?**

U kunt het dia‑voorbeeld van het OLE‑object extraheren via OleObjectFrame.getSubstitutePictureFormat. Dat voorbeeld is echter niet het ingesloten document zelf. Om afbeeldingen uit het ingesloten bestand te halen, moet u de OLE‑data extraheren en deze inspecteren met tools die geschikt zijn voor dat bestandstype.