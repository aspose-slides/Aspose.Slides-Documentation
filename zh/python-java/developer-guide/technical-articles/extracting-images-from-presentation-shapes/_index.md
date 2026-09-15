---
title: 通过 Java 的 Python 从演示文稿形状中提取图像
linktitle: 形状中的图像
type: docs
weight: 100
url: /zh/python-java/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 - 快速、代码友好的解决方案。"
---
## **概述**

演示文稿中的图像可以以多种形状出现：普通图片框、作为形状填充的图片、OLE 对象预览图像、视频或音频帧缩略图、缩放图像，或嵌套在表格、图表和 SmartArt 形状中的图像。Aspose.Slides 将这些图像存储在演示文稿的图像集合中，可通过 [ImageCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imagecollection/) 和 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 对象访问。

如果只需要导出演示文稿中嵌入的每个图像资源，请遍历 [Presentation.getImages](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getImages)。本文关注的是另一项任务：遍历形状以查找幻灯片中使用图像的位置，从而在保存文件时保留有用的上下文信息，例如幻灯片编号、形状位置和来源类型（图片框、填充图像、媒体预览、OLE 预览或缩放图像）。

{{% alert title="Tip" color="success" %}}
使用 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getBinaryData) 可保留原始编码的图像数据和文件类型。需要将输出统一为特定格式（如 PNG）时，请使用 `save` 的方式调用 [PPImage.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getImage)。
{{% /alert %}}

## **共享助手函数**

将下面的共享助手函数保存为 `image_helpers.py`，与示例脚本放在同一目录下。它们使示例保持简短。`save_original_image` 写入原始嵌入字节，根据 MIME 类型选择安全的扩展名，并通过 SHA-256 哈希跳过重复的图像二进制。

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

## **从图片框提取图像**

对以独立对象插入的图片使用此方法。[PictureFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/) 通过 [getPictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#getPicture) 和 [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picture/#getImage) 提供对其图片的访问，返回一个 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 对象。

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

## **从填充图片的形状提取图像**

形状可以使用图片作为填充。首先检查形状的填充类型：如果不是 [FillType.Picture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/) 则没有可提取的图片。下面的示例处理 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 对象，并通过 [PPImage.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getImage) 将每个图像保存为 PNG。

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

## **从 OLE 对象框提取预览图像**

[OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 可以拥有 PowerPoint 用作对象在幻灯片上预览的替代图片。该图像可通过 [getSubstitutePictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)、[getPicture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#getPicture) 和 [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picture/#getImage) 获取。提取此图片可得到预览图像，而不是嵌入的 OLE 包内容。

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

## **从视频帧提取预览图像**

[VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 也可以在 [getPictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#getPicture) 和 [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picture/#getImage) 中存储预览图像。这是幻灯片上显示的海报或缩略图，而不是从视频流解码的帧。

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

## **从音频帧提取预览图像**

[AudioFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/) 可以在 [getPictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#getPicture) 和 [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picture/#getImage) 中存储缩略图。这是幻灯片上音频对象显示的图像。

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

## **从缩放对象提取图像**

[ZoomFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/zoomframe/) 和 [SectionZoomFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sectionzoomframe/) 形状可以使用自定义图像。请读取缩放框的 [getZoomImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/zoomobject/#getZoomImage)。

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

## **从摘要缩放框提取图像**

[SummaryZoomFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/summaryzoomframe/) 也是一种形状。其章节项可以使用自定义图像，通过每个摘要缩放章节的 [getZoomImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/zoomobject/#getZoomImage) 方法获取。

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

## **从表格形状提取图像**

[Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/) 是一种形状。表格中的图像通常存储为表格单元格的图片填充。

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

## **从图表形状提取图像**

[Chart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/) 是一种形状。下面的示例从图表区域的图片填充中提取图像。

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

## **从 SmartArt 形状提取图像**

[SmartArt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/smartart/) 对象是一种形状。根据 SmartArt 布局，图像可能存储在节点项目符号填充或节点形状的填充格式中。

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

## **在组合形状中包含图像**

组合形状拥有自己的形状集合。共享的 `enumerate_shapes` 帮助函数提供 `include_grouped_shapes` 选项。需要检查 [GroupShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/groupshape/) 对象内部形状时，请将其设为 `True`。下面的示例从图片框、填充图片的形状、OLE 对象预览、视频帧缩略图以及音频帧缩略图中提取图像。若还想包含表格、图表、SmartArt 和摘要缩放图像，可在保持相同递归形状遍历的前提下，复用前面章节的专用提取逻辑。

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

## **边缘情况和实用说明**

- **重复图像：** 多个形状可能引用相同的图像，或不同图像却拥有相同的字节。若希望对每个唯一图像只输出一次文件，请在写入前对 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getBinaryData) 进行哈希。
- **原始数据 vs. 转换后输出：** 保存 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getBinaryData) 可保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 数据。通过 `save` 使用 [PPImage.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getImage) 可在需要统一输出格式时使用。
- **不受支持的填充类型：** 实线、渐变、图案和无填充形状不包含图片填充。读取 [getPictureFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/#getPictureFillFormat) 前请先检查 [FillType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/)。
- **组合形状：** 顶层幻灯片形状集合不会自动展开组。若组内容重要，请递归检查 [GroupShape.getShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/groupshape/#getShapes)。
- **OLE 对象预览：** [OleObjectFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/) 可能通过 [getSubstitutePictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 暴露预览图像，但该图像仅为幻灯片预览，并非 OLE 对象内部嵌入的文件。
- **视频帧缩略图：** [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 可能通过 [getPictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#getPictureFormat) 暴露预览图像，该图像仅为幻灯片上显示的海报，并非从视频流中提取的帧。
- **音频帧缩略图：** [AudioFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/audioframe/) 可能通过 [getPictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#getPictureFormat) 暴露图标或缩略图；这并不是嵌入的音频数据本身。
- **缩放图像：** 幻灯片缩放、章节缩放和摘要缩放形状可能通过 [getZoomImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/zoomobject/#getZoomImage) 使用自定义的 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 对象。
- **嵌套形状模型：** 表格、图表和 SmartArt 对象实现了 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/)，但它们的图像通常存储在嵌套的表格单元格、图表元素或 SmartArt 节点的格式对象中。
- **裁剪或变换后的图片：** 访问 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 可获得存储的图像资源。它不包括形状应用的裁剪、透明度、重新着色、旋转或其他视觉效果。

## **常见问题**

**是否可以在不裁剪、特效或形状变换的情况下提取原始图像？**

可以。访问 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 对象并将 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getBinaryData) 写入磁盘，即可保留演示文稿中存储的原始编码图像，而不是在幻灯片上渲染后的效果。

**是否可以将所有提取的图像导出为 PNG？**

可以。使用 [PPImage.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getImage) 获取图像对象，然后使用 `save` 并传入 [ImageFormat.Png](https://reference.aspose.com/slides/zh/python-java/aspose.slides/imageformat/)。这会将输出转换为 PNG，可能不会保留原始文件类型或矢量数据。

**如何避免多次保存同一图像？**

对 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/#getBinaryData) 计算哈希并在集合中保存哈希值。若新图像的哈希已存在，则跳过或记录对已有输出文件的另一个引用。

**为什么有些形状不会产生图像？**

图片框、填充图片的形状、OLE 对象框、媒体帧、缩放帧、表格、图表和 SmartArt 对象可以引用图像。某些形状类型通过嵌套的格式对象暴露图像，仅使用简单的 [getPictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#getPictureFormat) 或形状的 [getFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getFillFormat) 检查并不总是足够。

**是否可以提取视频帧显示的缩略图？**

可以。使用 [VideoFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/videoframe/) 并读取 [getPictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillformat/#getPicture) 和 [getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picture/#getImage)。这会提取随视频帧存储的海报图像，而不是从视频文件生成的帧。

**如何确定哪些形状使用了演示文稿图像集合中的特定图像？**

Aspose.Slides 不会为 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 到形状建立反向链接。遍历时构建映射：每当发现图像引用时，记录幻灯片编号、形状路径以及图像哈希或集合项。

**是否可以提取嵌入在 OLE 对象内部的图像，例如附件文档？**

可以提取 OLE 对象在幻灯片上的预览图像，方法是调用 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)。但是该预览图像并不是嵌入的文档本身。若要提取嵌入文件内部的图像，需要先提取 OLE 数据并使用相应文件类型的工具进行检查。