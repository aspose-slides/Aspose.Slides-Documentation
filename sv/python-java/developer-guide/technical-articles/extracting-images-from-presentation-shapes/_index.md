---
title: Extrahera bilder från presentationsformer i Python via Java
linktitle: Bild från form
type: docs
weight: 100
url: /sv/python-java/extracting-images-from-presentation-shapes/
keywords:
- extrahera bild
- hämta bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Extrahera bilder från former i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java – snabb, kodvänlig lösning."
---
## **Översikt**

Bilder i en presentation kan visas i flera former: som vanliga bildramar, som bildfyllningar som tillämpas på former, som förhandsgranskningsbilder för OLE‑objekt, som miniatyrbilder för video‑ eller ljudramar, som zoom‑bilder eller som bilder inbäddade i tabell‑, diagram‑ och SmartArt‑former. Aspose.Slides lagrar dessa bilder i presentationens bildsamling, som exponeras via [ImageCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imagecollection/) och [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)‑objekt.

Om du bara behöver exportera alla bildresurser som är inbäddade i en presentation, iterera genom [Presentation.getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages). Den här artikeln fokuserar på en annan uppgift: att gå igenom former för att hitta var bilder används på bilderna, så att de sparade filerna kan behålla användbar kontext som bildnumret, formens position och källtypen (bildram, fyllningsbild, medieförhandsgranskning, OLE‑förhandsgranskning eller zoom‑bild).

{{% alert title="Tip" color="success" %}}
Använd [PPImage.getBinaryData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getBinaryData) för att bevara originalkodad bilddata och filtyp. Använd [PPImage.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getImage) med `save` när du vill normalisera utdata till ett specifikt format såsom PNG.
{{% /alert %}}

## **Delade hjälpfunktioner**

Spara de delade hjälpfunktionerna nedan i `image_helpers.py` bredvid exempel‑skripten. De gör exemplen korta. `save_original_image` skriver de ursprungliga inbäddade bytena, väljer en säker filändelse baserat på MIME‑typen och hoppar över dubbletter av bildbinärer via SHA‑256‑hash.

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

## **Extrahera bilder från bildramar**

Använd detta tillvägagångssätt för bilder som infogats som fristående objekt. En [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) ger åtkomst till sin bild via [getPictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#getPicture) och [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/#getImage), vilket returnerar ett [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)‑objekt.

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

## **Extrahera bilder från bildfyllda former**

Former kan använda en bild som fyllning. Kontrollera först formens fyllningstyp: om den inte är [FillType.Picture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/), finns det ingen bild att extrahera från den fyllningen. Exemplet nedan hanterar [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/)‑objekt och sparar varje bild som PNG via [PPImage.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getImage).

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

## **Extrahera förhandsgranskningsbilder från OLE‑objektramar**

En [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) kan ha en ersättningsbild som PowerPoint använder som objektets förhandsgranskning på en bild. Denna bild är tillgänglig via [getSubstitutePictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#getPicture) och [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/#getImage). Att extrahera denna bild ger dig förhandsgranskningsbilden, inte innehållet i det inbäddade OLE‑paketet.

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

## **Extrahera förhandsgranskningsbilder från videoram**

En [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/) kan också lagra en förhandsgranskningsbild i [getPictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#getPicture) och [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/#getImage). Detta är affischen eller miniatyrbilden som visas på bilden, inte en bild avkodad från videoströmmen.

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

## **Extrahera förhandsgranskningsbilder från ljudramar**

En [AudioFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/) kan lagra en miniatyrbild i [getPictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#getPicture) och [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/#getImage). Detta är bilden som visas för ljudobjektet på bilden.

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

## **Extrahera bilder från zoom‑objekt**

[ZoomFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomframe/) och [SectionZoomFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectionzoomframe/) former kan använda anpassade bilder. Läs [getZoomImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomobject/#getZoomImage) från zoom‑ramen.

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

## **Extrahera bilder från sammanfattnings‑zoom‑ramar**

En [SummaryZoomFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/summaryzoomframe/) är också en form. Dess avsnittselement kan använda anpassade bilder, som exponeras genom varje sammanfattnings‑zoom‑avsnitts [getZoomImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomobject/#getZoomImage)‑metod.

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

## **Extrahera bilder från tabellformer**

En [Table](https://reference.aspose.com/slides/sv/python-java/aspose.slides/table/) är en form. Bilder i en tabell lagras vanligtvis som bildfyllningar i tabellceller.

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

## **Extrahera bilder från diagramformer**

Ett [Chart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/) är en form. Exemplet nedan extraherar en bild från diagramområdets bildfyllning.

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

## **Extrahera bilder från SmartArt‑former**

Ett [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑objekt är en form. Beroende på SmartArt‑layouten kan bilder lagras i nodens punktlistfyllningar eller i fyllningsformaten för nodformer.

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

## **Inkludera bilder i grupperade former**

Grupperade former innehåller sina egna formkollektioner. Den delade hjälpfunktionen `enumerate_shapes` har ett alternativ `include_grouped_shapes`. Sätt det till `True` när du vill inspektera former inom [GroupShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/groupshape/)‑objekt. Exemplet nedan extraherar bilder från bildramar, bildfyllda former, OLE‑objektförhandsgranskningar, videoraminminiatyrer och ljudramminiatyrer. För att även inkludera tabell-, diagram-, SmartArt‑ och sammanfattnings‑zoom‑bilder, återanvänd den specialiserade extraktionslogiken från föregående avsnitt medan du behåller samma rekursiva formgenomsökning.

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

## **Särskilda fall och praktiska noteringar**

- **Duplicerade bilder:** Flera former kan referera till samma bild eller separata bilder med identiska byte. Hasha [PPImage.getBinaryData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getBinaryData) innan du skriver filer om du vill ha en utdatafil per unik bild.
- **Original data vs. konverterad utdata:** Att spara [PPImage.getBinaryData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getBinaryData) bevarar den inbäddade JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ eller WMF‑datat. Att spara [PPImage.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getImage) via `save` är användbart när du vill ha ett enhetligt utdataformat.
- **Ej stödda fyllning‑typer:** Fyllda former med solid, gradient, mönster eller ingen fyllning innehåller ingen bildfyllning. Kontrollera [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) innan du läser [getPictureFillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Grupperade former:** Den översta bildens formsamling plattar inte ut grupper. Inspektera rekursivt [GroupShape.getShapes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/groupshape/#getShapes) när grupperat innehåll är viktigt.
- **OLE‑objektförhandsgranskningar:** Ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) kan exponera en förhandsgranskningsbild via [getSubstitutePictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), men den bilden är bara bildens förhandsgranskning på sliden. Det är inte den inbäddade filen i OLE‑objektet.
- **Videoramin miniatyrer:** En [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/) kan exponera en förhandsgranskningsbild via [getPictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#getPictureFormat), men den bilden är bara affischen som visas på bilden. Den är inte extraherad från videoströmmen.
- **Ljudram miniatyrer:** En [AudioFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/audioframe/) kan exponera en ikon eller miniatyr via [getPictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#getPictureFormat); den är inte den inbäddade ljuddata.
- **Zoom‑bilder:** Slide‑zoom‑, avsnitt‑zoom‑ och sammanfattnings‑zoom‑former kan använda anpassade [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)‑objekt via [getZoomImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Nästlade formmodeller:** Table‑, diagram‑ och SmartArt‑objekt implementerar [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/), men deras bilder lagras ofta i inbäddade tabellceller, diagram‑element eller SmartArt‑nodformat‑objekt.
- **Beskurna eller transformerade bilder:** Att komma åt [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/) ger dig den lagrade bildresursen. Det renderar inte beskärning, transparens, omfärgning, rotation eller andra visuella effekter som formen har applicerat.

## **FAQ**

**Kan jag extrahera originalbilden utan beskärning, effekter eller formtransformationer?**

Ja. Åtkomst till [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)‑objektet och skriv [PPImage.getBinaryData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getBinaryData) till disk. Detta bevarar den ursprungligt kodade bilden som lagras i presentationen, inte hur bilden renderas på sliden.

**Kan jag exportera varje extraherad bild som PNG?**

Ja. Använd [PPImage.getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getImage) för att få ett bildobjekt, och anropa sedan `save` med [ImageFormat.Png](https://reference.aspose.com/slides/sv/python-java/aspose.slides/imageformat/). Detta konverterar utdata och kan missa att bevara den ursprungliga filtypen eller vektordata.

**Hur undviker jag att spara samma bild mer än en gång?**

Använd en hash av [PPImage.getBinaryData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/#getBinaryData) och håll hasharna i en uppsättning. Om en ny bild har en hash som redan finns, hoppa över den eller registrera en annan referens till den befintliga utdatafilen.

**Varför producerar vissa former ingen bild?**

Bildramar, bildfyllda former, OLE‑objektramar, mediaramar, zoomramar, tabeller, diagram och SmartArt‑objekt kan referera till bilder. Vissa formtyper exponerar bilder via inbäddade formateringsobjekt, så en enkel kontroll av [getPictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#getPictureFormat) eller formens [getFillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getFillFormat) är inte alltid tillräcklig.

**Kan jag extrahera miniatyrbilden som visas för en videoram?**

Ja. Använd [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/) och läs [getPictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#getPicture) och [getImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picture/#getImage). Detta extraherar affischbilden som lagras med videoramen, inte en bild genererad från videofilen.

**Hur kan jag avgöra vilka former som använder en specifik bild från presentationens bildsamling?**

Aspose.Slides lagrar inga omvända länkar från [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/) till former. Bygg en mappning under genomsökning: när du hittar en bildreferens, registrera bildens slidnummer, formväg och bildens hash eller samlingsobjekt.

**Kan jag extrahera bilder som är inbäddade i OLE‑objekt, såsom bifogade dokument?**

Du kan extrahera OLE‑objektets förhandsgranskning på sliden via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Men den förhandsgranskningen är inte det inbäddade dokumentet. För att extrahera bilder från den inbäddade filen, extrahera OLE‑data och inspektera den med verktyg för den filtypen.