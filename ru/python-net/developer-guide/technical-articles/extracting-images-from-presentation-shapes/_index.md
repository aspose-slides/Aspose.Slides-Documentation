---
title: Извлечение изображений из фигур презентации в Python
linktitle: Изображение из фигуры
type: docs
weight: 90
url: /ru/python-net/extracting-images-from-presentation-shapes/
keywords:
- извлечение изображения
- получение изображения
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Извлекайте изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET — быстрое, удобное решение."
---
## **Обзор**

Изображения в презентации могут появляться в нескольких типах фигур: в виде обычных рамок изображений, как заполнения картинками, применённые к фигурам, как изображения предварительного просмотра объектов OLE, как миниатюры видеоматериалов или аудио‑кадров, как изображения масштабирования или как изображения, вложенные в фигуры таблиц, диаграмм и SmartArt. Aspose.Slides хранит эти изображения в коллекции изображений презентации, доступной через объекты [ImageCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imagecollection/) и [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) .

Если вам нужно только экспортировать каждый ресурс изображения, встроенный в презентацию, пройдитесь по `presentation.images`. Эта статья посвящена другой задаче: обходу фигур для поиска мест использования изображений на слайдах, чтобы сохраняемые файлы могли сохранять полезный контекст, такой как номер слайда, положение фигуры и тип источника (рамка изображения, заполнение изображением, предварительный просмотр медиа, предварительный просмотр OLE или изображение масштабирования).

{{% alert title="Tip" color="primary" %}}
Используйте свойство `binary_data` объекта [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) чтобы сохранить оригинальные закодированные данные изображения и тип файла. Используйте свойство `image` с методом `save`, когда требуется нормализовать вывод в конкретный формат, например PNG.
{{% /alert %}}

## **Общие вспомогательные методы**

Ниже приведённые вспомогательные методы делают примеры короче. `save_original_image` записывает оригинальные встроенные байты, выбирает безопасное расширение из MIME‑типа и пропускает дублирующие бинарные данные изображения, используя хеш SHA‑256.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
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
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **Извлечение изображений из рамок изображений**

Используйте этот подход для изображений, вставленных как отдельные объекты. [PictureFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/pictureframe/) хранит своё изображение в `picture_format.picture.image`, который возвращает объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) .

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Извлечение изображений из фигур, заполненных картинкой**

Фигуры могут использовать картинку в качестве заливки. Сначала проверьте тип заливки фигуры: если он не [FillType.PICTURE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/), то из этой заливки нет картинки для извлечения. Пример ниже обрабатывает объекты [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) и сохраняет каждое изображение как PNG через свойство `image` объекта [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) .

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **Извлечение изображений предварительного просмотра из рамок объектов OLE**

[OleObjectFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/oleobjectframe/) может иметь заменяющую картинку, которую PowerPoint использует как предварительный просмотр объекта на слайде. Это изображение доступно через `substitute_picture_format.picture.image`. Извлечение этой картинки даёт изображение предварительного просмотра, а не содержимое вложенного OLE‑пакета.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Извлечение изображений предварительного просмотра из видеорамок**

[VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) также может хранить изображение предварительного просмотра в `picture_format.picture.image`. Это постер или миниатюра, отображаемая на слайде, а не кадр, декодированный из видеопотока.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Извлечение изображений предварительного просмотра из аудиорамок**

[AudioFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/) может хранить миниатюру в `picture_format.picture.image`. Это изображение, отображаемое для аудио‑объекта на слайде.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Извлечение изображений из объектов масштабирования**

[ZoomFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/zoomframe/) и [SectionZoomFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sectionzoomframe/) могут использовать пользовательские изображения. Читайте `zoom_image` из рамки масштабирования.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **Извлечение изображений из рамок суммарного масштабирования**

[SummaryZoomFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/summaryzoomframe/) также является фигурой. Элементы его разделов могут использовать пользовательские изображения, доступные через свойство `zoom_image` каждого раздела суммарного масштабирования.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **Извлечение изображений из фигур таблиц**

[Table](https://reference.aspose.com/slides/ru/python-net/aspose.slides/table/) — это фигура. Изображения в таблице обычно хранятся как заполнения картинкой в ячейках таблицы.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Извлечение изображений из фигур диаграмм**

[Chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/) — это фигура. Пример ниже извлекает изображение из заливки области диаграммы.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Извлечение изображений из фигур SmartArt**

[SmartArt](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartart/) — объект, являющийся фигурой. В зависимости от макета SmartArt изображения могут храниться в заполнениях маркеров узлов или в форматах заливки фигур узлов.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Включение изображений внутри сгруппированных фигур**

Сгруппированные фигуры содержат собственные коллекции фигур. Общий вспомогательный метод `enumerate_shapes` имеет параметр `include_grouped_shapes`. Установите его в `True`, когда нужно просматривать фигуры внутри объектов [GroupShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/groupshape/) . Пример ниже извлекает изображения из рамок изображений, фигур, заполненных картинкой, предварительных просмотров OLE‑объектов, миниатюр видеорамок и аудио‑рамок. Чтобы также включить изображения из таблиц, диаграмм, SmartArt и суммарных масштабов, повторно используйте специализированную логику извлечения из предыдущих разделов, сохраняя тот же рекурсивный обход фигур.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Пограничные случаи и практические заметки**

- **Duplicate images:** Несколько фигур могут ссылаться на одно и то же изображение или на разные изображения с идентичными байтами. Вычисляйте хеш свойства `binary_data` объекта [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) перед записью файлов, если нужен один выходной файл на каждый уникальный образ.
- **Original data vs. converted output:** Сохранение свойства `binary_data` объекта [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) сохраняет вложенные данные JPEG, PNG, GIF, SVG, EMF или WMF. Сохранение свойства `image` через `save` полезно, когда требуется единый формат вывода.
- **Unsupported fill types:** Типы заливки, не поддерживаемые: сплошная, градиентная, узорчатая и без заливки — не содержат картинку. Проверьте [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) перед чтением `picture_fill_format`.
- **Grouped shapes:** Сгруппированные фигуры: верхнеуровневая коллекция фигур слайда не разворачивает группы. Рекурсивно проверяйте [GroupShape.shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/groupshape/shapes/) когда важен содержимое групп.
- **OLE object previews:** Предпросмотры OLE‑объектов: [OleObjectFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/oleobjectframe/) может предоставлять изображение предварительного просмотра через `substitute_picture_format`, но это лишь превью слайда. Это не вложенный файл внутри OLE‑объекта.
- **Video frame thumbnails:** Миниатюры видеорамок: [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) может предоставлять изображение предварительного просмотра через `picture_format`, но это лишь постер, отображаемый на слайде. Оно не извлекается из видеопотока.
- **Audio frame thumbnails:** Миниатюры аудио‑рамок: [AudioFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/audioframe/) может предоставлять значок или миниатюру через `picture_format`; это не вложенные аудио‑данные.
- **Zoom images:** Изображения масштабирования: фигуры zoom, section zoom и summary zoom могут использовать пользовательские объекты [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) через `image`.
- **Nested shape models:** Вложенные модели фигур: объекты Table, Chart и SmartArt реализуют [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/), но их изображения часто хранятся во вложенных форматах ячеек таблицы, элементах диаграммы или узлах SmartArt.
- **Cropped or transformed pictures:** Обрезанные или трансформированные картинки: доступ к [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) дает хранимый ресурс изображения. Он не учитывает обрезку, прозрачность, перекрасску, вращение или другие визуальные эффекты, применённые фигурой.

## **FAQ**

**Can I extract the original image without cropping, effects, or shape transformations?**  
**Могу ли я извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?**  
Да. Получите объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) и запишите его свойство `binary_data` на диск. Это сохраняет оригинальное закодированное изображение, хранящееся в презентации, а не способ его отображения на слайде.

**Can I export every extracted image as PNG?**  
**Могу ли я экспортировать каждое извлечённое изображение как PNG?**  
Да. Используйте свойство `image` объекта [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) и затем вызовите `save` с [ImageFormat.PNG](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imageformat/). Это преобразует вывод и может не сохранять оригинальный тип файла или векторные данные.

**How do I avoid saving the same image more than once?**  
**Как избежать многократного сохранения одного и того же изображения?**  
Используйте хеш свойства `binary_data` объекта [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) и храните хеши в наборе. Если новое изображение имеет уже существующий хеш, пропустите его или запишите другую ссылку на существующий файл вывода.

**Why do some shapes not produce an image?**  
**Почему некоторые фигуры не дают изображение?**  
Рамки изображений, фигуры, заполненные картинкой, OLE‑рамки, медиа‑рамки, рамки масштабирования, таблицы, диаграммы и объекты SmartArt могут ссылаться на изображения. Некоторые типы фигур открывают изображения через вложенные объекты форматирования, поэтому простой проверка `picture_format` или `fill_format` фигуры не всегда достаточна.

**Can I extract the thumbnail shown for a video frame?**  
**Могу ли я извлечь миниатюру, отображаемую для видеорамки?**  
Да. Используйте [VideoFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/videoframe/) и читайте `picture_format.picture.image`. Это извлекает постер, хранящийся с видеорамкой, а не кадр, сгенерированный из видеофайла.

**How can I determine which shapes use a specific image from the presentation image collection?**  
**Как определить, какие фигуры используют конкретное изображение из коллекции изображений презентации?**  
Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) к фигурам. Постройте соответствие во время обхода: каждый раз, когда находите ссылку на изображение, записывайте номер слайда, путь к фигуре и хеш изображения или элемент коллекции.

**Can I extract images embedded inside OLE objects, such as attached documents?**  
**Могу ли я извлечь изображения, вложенные в OLE‑объекты, например прикреплённые документы?**  
Вы можете извлечь предварительный просмотр OLE‑объекта из свойства `substitute_picture_format` [OleObjectFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/oleobjectframe/). Однако этот предварительный просмотр не является самим вложенным документом. Чтобы извлечь изображения из вложенного файла, извлеките OLE‑данные и проанализируйте их с помощью инструментов для соответствующего типа файла.