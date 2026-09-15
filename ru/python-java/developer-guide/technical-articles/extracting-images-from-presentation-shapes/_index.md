---
title: Извлечение изображений из фигур презентации на Python через Java
linktitle: Изображение из фигуры
type: docs
weight: 100
url: /ru/python-java/extracting-images-from-presentation-shapes/
keywords:
- извлечь изображение
- получить изображение
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Извлеките изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java — быстрое, удобное для кода решение."
---
## **Обзор**

Изображения в презентации могут появляться в нескольких типах фигур: как обычные рамки изображений, как заполнения изображениями, применённые к фигурам, как изображения‑превью OLE‑объектов, как миниатюры видеокадров или аудиофреймов, как изображения увеличения, или как изображения, вложенные в таблицы, диаграммы и фигуры SmartArt. Aspose.Slides хранит эти изображения в коллекции изображений презентации, доступной через объекты [ImageCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imagecollection/) и [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/).

Если вам нужно экспортировать каждый встроенный в презентацию ресурс изображения, пройдите по [Presentation.getImages](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getImages). Эта статья посвящена иной задаче: обходу фигур, чтобы найти, где изображения используются на слайдах, чтобы сохранённые файлы могли сохранять полезный контекст, такой как номер слайда, позиция фигуры и тип источника (рамка изображения, заполнение изображением, превью мультимедиа, превью OLE или изображение увеличения).

{{% alert title="Tip" color="success" %}}
Используйте [PPImage.getBinaryData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getBinaryData), чтобы сохранить исходные закодированные данные изображения и тип файла. Используйте [PPImage.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getImage) с `save`, когда требуется нормализовать вывод в конкретный формат, например PNG.
{{% /alert %}}

## **Общие вспомогательные функции**

Сохраните общие вспомогательные функции ниже в файле `image_helpers.py` рядом с примерами скриптов. Они делают примеры короче. `save_original_image` записывает оригинальные встроенные байты, выбирает безопасное расширение из MIME‑типа и пропускает дублирующие бинарные изображения по хэшу SHA‑256.

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

## **Извлечение изображений из рамок изображений**

Используйте этот подход для изображений, вставленных как отдельные объекты. Объект [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) предоставляет доступ к своему изображению через [getPictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#getPicture) и [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/#getImage), который возвращает объект [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/).

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

## **Извлечение изображений из фигур, заполненных изображениями**

Фигуры могут использовать изображение в качестве заполнения. Сначала проверьте тип заполнения фигуры: если это не [FillType.Picture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/), изображение извлекать не нужно. Пример ниже обрабатывает объекты [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) и сохраняет каждое изображение в формате PNG через [PPImage.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getImage).

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

## **Извлечение изображений‑превью из рамок OLE‑объектов**

[OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) может иметь заменяющую картинку, которую PowerPoint использует как превью объекта на слайде. Это изображение доступно через [getSubstitutePictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#getPicture) и [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/#getImage). Извлечение этой картинки даёт вам превью‑изображение, а не содержимое вложенного OLE‑пакета.

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

## **Извлечение изображений‑превью из видеокадров**

[VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) также может хранить превью‑изображение в [getPictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#getPicture) и [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/#getImage). Это постер или миниатюра, показываемая на слайде, а не кадр, декодированный из видеопотока.

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

## **Извлечение изображений‑превью из аудиокадров**

[AudioFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/) может хранить миниатюру в [getPictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#getPicture) и [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/#getImage). Это изображение, отображаемое для аудио‑объекта на слайде.

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

## **Извлечение изображений из объектов Zoom**

[ZoomFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomframe/) и [SectionZoomFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/sectionzoomframe/) могут использовать пользовательские изображения. Читайте [getZoomImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomobject/#getZoomImage) из рамки zoom.

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

## **Извлечение изображений из рамок Summary Zoom**

[SummaryZoomFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/summaryzoomframe/) тоже является фигурой. Его элементы разделов могут использовать пользовательские изображения, доступные через метод [getZoomImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomobject/#getZoomImage) каждого раздела summary zoom.

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

## **Извлечение изображений из фигур таблиц**

[Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) — это фигура. Изображения в таблице обычно хранятся как заполнения изображениями в ячейках таблицы.

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

## **Извлечение изображений из фигур диаграмм**

[Chart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/) — это фигура. Пример ниже извлекает изображение из заполнения картинки области диаграммы.

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

## **Извлечение изображений из фигур SmartArt**

[SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/) — объект-фигура. В зависимости от расположения SmartArt изображения могут храниться в заполнениях буллетов узлов или в форматах заполнения фигур узлов.

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

## **Включение изображений внутри сгруппированных фигур**

Сгруппированные фигуры содержат свои собственные коллекции фигур. Общий вспомогательный метод `enumerate_shapes` имеет параметр `include_grouped_shapes`. Установите его в `True`, когда нужно проверять фигуры внутри объектов [GroupShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/groupshape/). Пример ниже извлекает изображения из рамок изображений, фигур, заполненных изображениями, превью OLE‑объектов, миниатюр видеокадров и миниатюр аудиокадров. Чтобы также включить изображения таблиц, диаграмм, SmartArt и summary zoom, повторно используйте специализированную логику извлечения из предыдущих разделов, сохраняя тот же рекурсивный обход фигур.

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

## **Пограничные случаи и практические замечания**

- **Дублирующие изображения:** Несколько фигур могут ссылаться на одно и то же изображение или на разные изображения с идентичными байтами. Хешируйте [PPImage.getBinaryData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getBinaryData) перед записью файлов, если нужен один файл‑вывод на уникальное изображение.
- **Исходные данные vs. преобразованный вывод:** Сохранение [PPImage.getBinaryData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getBinaryData) сохраняет встроенный JPEG, PNG, GIF, SVG, EMF или WMF. Сохранение [PPImage.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getImage) через `save` полезно, когда нужен единый формат вывода.
- **Неподдерживаемые типы заполнения:** Сплошные, градиентные, узорные и без‑заполнения фигуры не содержат изображения заполнения. Проверьте [FillType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/) перед чтением [getPictureFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Сгруппированные фигуры:** Коллекция фигур верхнего уровня слайда не «расплющивает» группы. Рекурсивно проверяйте [GroupShape.getShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/groupshape/#getShapes), когда важен контент внутри групп.
- **Превью OLE‑объектов:** [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) может предоставлять превью‑изображение через [getSubstitutePictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), но это лишь превью на слайде, а не встроенный файл внутри OLE‑объекта.
- **Миниатюры видеокадров:** [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) может предоставлять превью‑изображение через [getPictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#getPictureFormat), однако это лишь постер, показываемый на слайде, а не кадр, извлечённый из видеопотока.
- **Миниатюры аудиокадров:** [AudioFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/audioframe/) может показывать иконку или миниатюру через [getPictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#getPictureFormat); это не встроенные аудиоданные.
- **Изображения Zoom:** Фигуры Slide Zoom, Section Zoom и Summary Zoom могут использовать пользовательские объекты [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) через [getZoomImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Вложенные модели фигур:** Объекты Table, Chart и SmartArt реализуют [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), но их изображения часто хранятся в вложенных объектах форматирования ячеек таблицы, элементов диаграммы или узлов SmartArt.
- **Обрезанные или трансформированные изображения:** Доступ к [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) даёт храненный ресурс изображения. Он не учитывает обрезку, прозрачность, перекраску, вращение или другие визуальные эффекты, применяемые фигурой.

## **FAQ**

**Можно ли извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?**

Да. Обратитесь к объекту [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) и запишите [PPImage.getBinaryData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getBinaryData) на диск. Это сохраняет оригинальное закодированное изображение, хранящееся в презентации, а не способ его отображения на слайде.

**Можно ли экспортировать каждое извлечённое изображение в формате PNG?**

Да. Используйте [PPImage.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getImage), чтобы получить объект изображения, затем вызовите `save` с [ImageFormat.Png](https://reference.aspose.com/slides/ru/python-java/aspose.slides/imageformat/). Это преобразует вывод и может не сохранять оригинальный тип файла или векторные данные.

**Как избежать многократного сохранения одного и того же изображения?**

Вычисляйте хеш [PPImage.getBinaryData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/#getBinaryData) и храните хеши в наборе. Если новое изображение имеет уже существующий хеш, пропустите его или запишите дополнительную ссылку на уже существующий файл вывода.

**Почему некоторые фигуры не дают изображение?**

Рамки изображений, фигуры, заполненные изображениями, рамки OLE‑объектов, мультимедийные рамки, рамки Zoom, таблицы, диаграммы и объекты SmartArt могут ссылаться на изображения. Некоторые типы фигур раскрывают изображения через вложенные объекты форматирования, поэтому простой проверка [getPictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#getPictureFormat) или [getFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getFillFormat) может быть недостаточной.

**Можно ли извлечь миниатюру, отображаемую для видеокадра?**

Да. Используйте [VideoFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/videoframe/) и читайте [getPictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#getPicture) и [getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/#getImage). Это извлекает постер‑изображение, хранящееся вместе с видеокадром, а не кадр, сгенерированный из видеофайла.

**Как определить, какие фигуры используют конкретное изображение из коллекции изображений презентации?**

Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/) к фигуркам. Постройте отображение во время обхода: каждый раз, когда находите ссылку на изображение, фиксируйте номер слайда, путь к фигуре и хеш или номер элемента коллекции.

**Можно ли извлечь изображения, встроенные в OLE‑объекты, например вложенные документы?**

Вы можете извлечь превью OLE‑объекта со слайда через [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Однако это превью не является самим вложенным документом. Чтобы извлечь изображения изнутри вложенного файла, экспортируйте данные OLE и проанализируйте их с помощью соответствующих инструментов.