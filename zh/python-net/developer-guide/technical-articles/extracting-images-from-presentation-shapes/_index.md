---
title: 在 Python 中从演示文稿形状提取图像
linktitle: 形状中的图像
type: docs
weight: 90
url: /zh/python-net/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 - 快速、易于编写代码的解决方案。"
---
## **概述**

演示文稿中的图像可以出现在多种形状类型中：普通图片框、应用于形状的图片填充、OLE 对象预览图像、视频或音频帧缩略图、缩放图像，或嵌套在表格、图表和 SmartArt 形状中的图像。Aspose.Slides 将这些图像存储在演示文稿的图像集合中，可通过 [ImageCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imagecollection/) 和 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 对象访问。

如果您只需要导出演示文稿中嵌入的每个图像资源，只需遍历 `presentation.images`。本文关注的是另一项任务：遍历形状以查找幻灯片中使用图像的位置，从而在保存的文件中保留有用的上下文信息，例如幻灯片编号、形状位置和来源类型（图片框、填充图像、媒体预览、OLE 预览或缩放图像）。

{{% alert title="Tip" color="primary" %}}
使用 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 的 `binary_data` 属性来保留原始编码的图像数据和文件类型。当您想将输出规范化为特定格式（如 PNG）时，使用 `image` 属性配合 `save`。
{{% /alert %}}

## **共享帮助方法**

下面的帮助方法使示例保持简短。`save_original_image` 写入原始嵌入字节，根据 MIME 类型选择安全的扩展名，并通过 SHA-256 哈希跳过重复的图像二进制文件。

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

## **从图片框提取图像**

对于作为独立对象插入的图片，请使用此方法。[PictureFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/pictureframe/) 将其图片存储在 `picture_format.picture.image` 中，返回一个 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 对象。

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

## **从填充图片的形状提取图像**

形状可以使用图片作为填充。首先检查形状的填充类型：如果不是 [FillType.PICTURE](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/)，则该填充中没有可提取的图片。下面的示例处理 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 对象，并通过 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 的 `image` 属性将每个图像保存为 PNG。

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

## **从 OLE 对象框提取预览图像**

[OleObjectFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/oleobjectframe/) 可以拥有 PowerPoint 用作对象在幻灯片上预览的替代图片。该图像可通过 `substitute_picture_format.picture.image` 获取。提取此图片得到的是预览图像，而不是嵌入的 OLE 包内容。

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

## **从视频帧提取预览图像**

[VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 也可以在 `picture_format.picture.image` 中存储预览图像。它是显示在幻灯片上的海报或缩略图，而不是从视频流解码的帧。

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

## **从音频帧提取预览图像**

[AudioFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/) 可以在 `picture_format.picture.image` 中存储缩略图。它是幻灯片上音频对象显示的图像。

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

## **从缩放对象提取图像**

[ZoomFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/zoomframe/) 和 [SectionZoomFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectionzoomframe/) 形状可以使用自定义图像。请从缩放框中读取 `zoom_image`。

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

## **从摘要缩放框提取图像**

[SummaryZoomFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/summaryzoomframe/) 也是一种形状。其章节项可以使用自定义图像，可通过每个摘要缩放章节的 `zoom_image` 属性获取。

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

## **从表格形状提取图像**

[Table](https://reference.aspose.com/slides/zh/python-net/aspose.slides/table/) 是一种形状。表格中的图像通常以图片填充的形式存储在单元格中。

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

## **从图表形状提取图像**

[Chart](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/) 是一种形状。下面的示例从图表区域的图片填充中提取图像。

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

## **从 SmartArt 形状提取图像**

[SmartArt](https://reference.aspose.com/slides/zh/python-net/aspose.slides.smartart/smartart/) 对象是一种形状。根据 SmartArt 布局，图像可能存储在节点项目符号填充中或节点形状的填充格式中。

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

## **包含分组形状内的图像**

分组形状包含其自己的形状集合。共享的 `enumerate_shapes` 帮助方法具有 `include_grouped_shapes` 选项。当您想检查 [GroupShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/groupshape/) 对象内部的形状时，请将其设为 `True`。下面的示例从图片框、填充图片的形状、OLE 对象预览、视频帧缩略图和音频帧缩略图中提取图像。若还要包括表格、图表、SmartArt 和摘要缩放图像，请重复使用前面章节中的专用提取逻辑，同时保持相同的递归形状遍历。

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

## **边缘情况和实用说明**

- **重复图像：** 多个形状可能引用相同的图像，或不同的图像具有相同的字节。在写入文件之前对 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 的 `binary_data` 属性进行哈希，如果您希望每个唯一图像只产出一个文件。
- **原始数据与转换后输出：** 保存 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 的 `binary_data` 属性可保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 数据。通过 `save` 保存 `image` 属性在您希望得到统一输出格式时很有用。
- **不支持的填充类型：** 实心、渐变、图案和无填充的形状不包含图片填充。在读取 `picture_fill_format` 之前请检查 [FillType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/)。
- **分组形状：** 幻灯片顶层形状集合不会展开分组。当分组内容重要时，请递归检查 [GroupShape.shapes](https://reference.aspose.com/slides/zh/python-net/aspose.slides/groupshape/shapes/)。
- **OLE 对象预览：** [OleObjectFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/oleobjectframe/) 可能通过 `substitute_picture_format` 暴露预览图像，但该图像仅为幻灯片预览，并非 OLE 对象内部的嵌入文件。
- **视频帧缩略图：** [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 可能通过 `picture_format` 暴露预览图像，但该图像仅为幻灯片上显示的海报，并非从视频流中提取。
- **音频帧缩略图：** [AudioFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/audioframe/) 可能通过 `picture_format` 暴露图标或缩略图；这并非嵌入的音频数据。
- **缩放图像：** 幻灯片缩放、章节缩放和摘要缩放形状可能通过 `image` 使用自定义的 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 对象。
- **嵌套形状模型：** 表格、图表和 SmartArt 对象实现了 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/)，但它们的图像通常存储在嵌套的表格单元格、图表元素或 SmartArt 节点格式对象中。
- **裁剪或变换的图片：** 访问 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 可获得存储的图像资源。它不会渲染形状所应用的裁剪、透明度、重新着色、旋转或其他视觉效果。

## **常见问题**

**我能提取未裁剪、未应用效果或形状变换的原始图像吗？**

可以。访问 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 对象并将其 `binary_data` 属性写入磁盘。这会保留演示文稿中存储的原始编码图像，而不是图像在幻灯片上的渲染方式。

**我能将所有提取的图像导出为 PNG 吗？**

可以。使用 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 的 `image` 属性获取图像对象，然后使用 [ImageFormat.PNG](https://reference.aspose.com/slides/zh/python-net/aspose.slides/imageformat/) 调用 `save`。这会转换输出，但可能不保留原始文件类型或矢量数据。

**我如何避免多次保存相同的图像？**

对 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 的 `binary_data` 属性进行哈希，并将哈希值保存在集合中。如果新图像的哈希已经存在，则跳过或记录对已有输出文件的另一个引用。

**为什么某些形状不产生图像？**

图片框、填充图片的形状、OLE 对象框、媒体框、缩放框、表格、图表和 SmartArt 对象可以引用图像。某些形状类型通过嵌套的格式对象暴露图像，因此仅检查 `picture_format` 或形状的 `fill_format` 并不总是足够。

**我能提取视频帧显示的缩略图吗？**

可以。使用 [VideoFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/videoframe/) 并读取 `picture_format.picture.image`。这会提取随视频帧存储的海报图像，而不是从视频文件生成的帧。

**我如何确定演示文稿图像集合中哪些形状使用了特定图像？**

Aspose.Slides 不会存储从 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 到形状的反向链接。在遍历过程中构建映射：每当找到图像引用时，记录幻灯片编号、形状路径以及图像哈希或集合项。

**我能提取嵌入在 OLE 对象内部的图像，例如附加文档中的图像吗？**

您可以从 [OleObjectFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/oleobjectframe/) 的 `substitute_picture_format` 属性提取 OLE 对象的幻灯片预览。但该预览并非嵌入的文档本身。若要提取嵌入文件内部的图像，需要提取 OLE 数据并使用该文件类型的工具进行检查。