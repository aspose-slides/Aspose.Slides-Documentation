---
title: Wyodrębnianie obrazów z kształtów prezentacji w Pythonie za pośrednictwem Java
linktitle: Obraz z kształtu
type: docs
weight: 100
url: /pl/python-java/extracting-images-from-presentation-shapes/
keywords:
- wyodrębnić obraz
- pobrać obraz
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Wyodrębnij obrazy z kształtów w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona za pośrednictwem Java – szybkie, przyjazne dla kodu rozwiązanie."
---
## **Przegląd**

Obrazy w prezentacji mogą pojawiać się w kilku typach kształtów: jako zwykłe ramki obrazu, jako wypełnienia obrazem zastosowane do kształtów, jako obrazy podglądu obiektów OLE, jako miniatury klatek wideo lub audio, jako obrazy powiększenia lub jako obrazy osadzone w tabelach, wykresach i kształtach SmartArt. Aspose.Slides przechowuje te obrazy w kolekcji obrazów prezentacji, udostępnianej poprzez obiekty [ImageCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imagecollection/) i [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/).

Jeśli potrzebujesz jedynie wyeksportować wszystkie zasoby obrazów osadzone w prezentacji, przeiteruj [Presentation.getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages). Ten artykuł skupia się na innym zadaniu: przeglądaniu kształtów w celu znalezienia, gdzie obrazy są używane na slajdach, aby zapisane pliki mogły zachować przydatny kontekst, taki jak numer slajdu, pozycja kształtu i typ źródła (ramka obrazu, wypełnienie obrazu, podgląd mediów, podgląd OLE lub obraz powiększenia).

{{% alert title="Tip" color="success" %}}

Użyj [PPImage.getBinaryData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getBinaryData), aby zachować oryginalne zakodowane dane obrazu i typ pliku. Użyj [PPImage.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getImage) z `save`, gdy chcesz znormalizować wyjście do określonego formatu, takiego jak PNG.

{{% /alert %}}

## **Wspólne funkcje pomocnicze**

Zapisz poniższe współdzielone funkcje pomocnicze w pliku `image_helpers.py` obok przykładów skryptów. Utrzymują one przykłady krótkie. `save_original_image` zapisuje oryginalne bajty osadzone, wybiera bezpieczne rozszerzenie na podstawie typu MIME i pomija zduplikowane binaria obrazu na podstawie hasha SHA‑256.

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

## **Wyodrębnianie obrazów z ramek obrazu**

Użyj tego podejścia dla obrazów wstawionych jako samodzielne obiekty. [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) udostępnia dostęp do swojego obrazu poprzez [getPictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#getPicture) i [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picture/#getImage), które zwracają obiekt [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/).

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

## **Wyodrębnianie obrazów z kształtów wypełnionych obrazem**

Kształty mogą używać obrazu jako swojego wypełnienia. Najpierw sprawdź typ wypełnienia kształtu: jeśli nie jest to [FillType.Picture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/), nie ma obrazu do wyodrębnienia z tego wypełnienia. Poniższy przykład obsługuje obiekty [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) i zapisuje każdy obraz jako PNG przy użyciu [PPImage.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getImage).

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

## **Wyodrębnianie obrazów podglądu z ramek obiektów OLE**

[OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) może mieć zamienny obraz, którego PowerPoint używa jako podglądu obiektu na slajdzie. Ten obraz jest dostępny poprzez [getSubstitutePictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#getPicture) i [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picture/#getImage). Wyodrębnienie tego obrazu daje podgląd, a nie zawartość osadzonego pakietu OLE.

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

## **Wyodrębnianie obrazów podglądu z ramek wideo**

[VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) może także przechowywać obraz podglądu w [getPictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#getPicture) i [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picture/#getImage). To jest plakat lub miniatura wyświetlana na slajdzie, a nie klatka zdekodowana z strumienia wideo.

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

## **Wyodrębnianie obrazów podglądu z ramek audio**

[AudioFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/) może przechowywać miniaturę w [getPictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#getPicture) i [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picture/#getImage). To jest obraz wyświetlany dla obiektu audio na slajdzie.

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

## **Wyodrębnianie obrazów z obiektów Zoom**

[ZoomFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomframe/) i [SectionZoomFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectionzoomframe/) mogą używać własnych obrazów. Odczytaj [getZoomImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomobject/#getZoomImage) z ramki zoom.

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

## **Wyodrębnianie obrazów z ramek podsumowujących Zoom**

[SummaryZoomFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/summaryzoomframe/) jest również kształtem. Jego elementy sekcji mogą używać własnych obrazów, udostępnianych poprzez metodę [getZoomImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomobject/#getZoomImage) każdego podsumowującego elementu zoom.

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

## **Wyodrębnianie obrazów z kształtów tabeli**

[Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) jest kształtem. Obrazy w tabeli są zwykle przechowywane jako wypełnienia obrazem w komórkach tabeli.

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

## **Wyodrębnianie obrazów z kształtów wykresu**

[Chart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/) jest kształtem. Poniższy przykład wyodrębnia obraz z wypełnienia obrazu obszaru wykresu.

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

## **Wyodrębnianie obrazów z kształtów SmartArt**

[SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/) jest obiektem‑kształtem. W zależności od układu SmartArt obrazy mogą być przechowywane w wypełnieniach punktów węzła lub w formatach wypełnienia kształtów węzła.

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

## **Dołączanie obrazów wewnątrz grupowanych kształtów**

Grupowane kształty zawierają własne kolekcje kształtów. Współdzielona funkcja pomocnicza `enumerate_shapes` ma opcję `include_grouped_shapes`. Ustaw ją na `True`, gdy chcesz sprawdzić kształty wewnątrz obiektów [GroupShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/groupshape/). Poniższy przykład wyodrębnia obrazy z ramek obrazu, kształtów wypełnionych obrazem, podglądów obiektów OLE, miniatur wideo i audio. Aby dołączyć obrazy tabel, wykresów, SmartArt i podsumowujących zoom, ponownie użyj specjalistycznej logiki wyodrębniania z poprzednich sekcji, zachowując tę samą rekurencyjną iterację kształtów.

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

## **Przypadki brzegowe i praktyczne uwagi**

- **Duplikaty obrazów:** Wiele kształtów może odwoływać się do tego samego obrazu lub do oddzielnych obrazów o identycznych bajtach. Haszuj [PPImage.getBinaryData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getBinaryData) przed zapisywaniem plików, jeśli chcesz uzyskać jeden plik wyjściowy na każdy unikalny obraz.
- **Dane oryginalne vs. wyjściowy konwertowany:** Zapisywanie [PPImage.getBinaryData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getBinaryData) zachowuje osadzony JPEG, PNG, GIF, SVG, EMF lub WMF. Zapisywanie [PPImage.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getImage) przy użyciu `save` jest przydatne, gdy potrzebny jest spójny format wyjściowy.
- **Nieobsługiwane typy wypełnienia:** Kształty wypełnione kolorem stałym, gradientem, wzorem lub bez wypełnienia nie zawierają obrazu wypełnienia. Sprawdź [FillType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/) przed odczytem [getPictureFillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Grupowane kształty:** Górna kolekcja kształtów slajdu nie spłaszcza grup. Rekurencyjnie sprawdzaj [GroupShape.getShapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/groupshape/#getShapes), gdy zawartość grup ma znaczenie.
- **Podglądy obiektów OLE:** [OleObjectFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/) może udostępniać obraz podglądu przez [getSubstitutePictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), ale ten obraz jest jedynie podglądem slajdu. Nie jest to osadzony plik wewnątrz obiektu OLE.
- **Miniatury klatek wideo:** [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) może udostępniać obraz podglądu przez [getPictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#getPictureFormat), ale ten obraz jest jedynie plakatem wyświetlanym na slajdzie. Nie jest wyodrębniany ze strumienia wideo.
- **Miniatury klatek audio:** [AudioFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audioframe/) może udostępniać ikonę lub miniaturę przez [getPictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#getPictureFormat); nie jest to osadzona zawartość audio.
- **Obrazy Zoom:** Kształty slide‑zoom, section‑zoom i summary‑zoom mogą używać własnych obiektów [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) poprzez [getZoomImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Zagnieżdżone modele kształtów:** Obiekty tabel, wykresów i SmartArt implementują [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/), ale ich obrazy często są przechowywane w zagnieżdżonych obiektach formatowania komórek tabeli, elementów wykresu lub węzłów SmartArt.
- **Obcięte lub przekształcone obrazy:** Dostęp do [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) daje Ci zasób obrazu przechowywany w pliku. Nie renderuje on przycinania, przezroczystości, przebarwień, rotacji ani innych efektów wizualnych zastosowanych przez kształt.

## **FAQ**

**Czy mogę wyodrębnić oryginalny obraz bez przycinania, efektów ani przekształceń kształtu?**

Tak. Uzyskaj dostęp do obiektu [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) i zapisz [PPImage.getBinaryData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getBinaryData) na dysk. Zachowuje to oryginalnie zakodowany obraz przechowywany w prezentacji, a nie sposób, w jaki obraz jest renderowany na slajdzie.

**Czy mogę wyeksportować każdy wyodrębniony obraz jako PNG?**

Tak. Użyj [PPImage.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getImage), aby uzyskać obiekt obrazu, a następnie wywołaj `save` z [ImageFormat.Png](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imageformat/). To konwertuje wyjście i może nie zachować oryginalnego typu pliku ani danych wektorowych.

**Jak uniknąć zapisywania tego samego obrazu więcej niż raz?**

Użyj hashu [PPImage.getBinaryData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/#getBinaryData) i przechowuj hashe w zbiorze. Jeśli nowy obraz ma hash, który już istnieje, pomiń go lub zanotuj dodatkowe odniesienie do istniejącego pliku wyjściowego.

**Dlaczego niektóre kształty nie generują obrazu?**

Ramki obrazu, kształty wypełnione obrazem, ramki obiektów OLE, ramki mediów, ramki zoom, tabele, wykresy i obiekty SmartArt mogą odwoływać się do obrazów. Niektóre typy kształtów udostępniają obrazy przez zagnieżdżone obiekty formatowania, więc proste sprawdzenie [getPictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#getPictureFormat) lub [getFillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getFillFormat) nie zawsze wystarczy.

**Czy mogę wyodrębnić miniaturę wyświetlaną dla ramki wideo?**

Tak. Użyj [VideoFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/videoframe/) i odczytaj [getPictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#getPicture) oraz [getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picture/#getImage). To wyodrębnia obraz plakatu przechowywany z ramką wideo, a nie klatkę wygenerowaną z pliku wideo.

**Jak mogę określić, które kształty używają konkretnego obrazu z kolekcji obrazów prezentacji?**

Aspose.Slides nie przechowuje odwróconych powiązań od [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/) do kształtów. Zbuduj mapowanie podczas iteracji: za każdym razem, gdy znajdziesz odwołanie do obrazu, zanotuj numer slajdu, ścieżkę kształtu i hash obrazu lub element kolekcji.

**Czy mogę wyodrębnić obrazy osadzone w obiektach OLE, takich jak załączone dokumenty?**

Możesz wyodrębnić podgląd slajdu obiektu OLE przez [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Jednak ten podgląd nie jest osadzonym dokumentem. Aby wyodrębnić obrazy z wewnątrz pliku OLE, wyodrębnij dane OLE i przeanalizuj je narzędziami odpowiednimi dla tego typu pliku.