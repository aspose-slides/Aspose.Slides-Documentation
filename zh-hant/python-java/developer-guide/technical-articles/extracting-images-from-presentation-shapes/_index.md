---
title: 透過 Java 的 Python 從簡報形狀擷取影像
linktitle: 形狀中的影像
type: docs
weight: 100
url: /zh-hant/python-java/extracting-images-from-presentation-shapes/
keywords:
- 擷取影像
- 取得影像
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 從 PowerPoint 與 OpenDocument 簡報的形狀中擷取影像 - 快速、程式友善的解決方案。"
---
## **概述**

簡報中的影像可能以多種形狀類型出現：普通的圖片框、套用到形狀的圖片填充、OLE 物件的預覽圖、影片或音訊框的縮圖、Zoom 圖片，或是嵌入在表格、圖表與 SmartArt 形狀內的圖片。Aspose.Slides 會將這些影像存放在簡報的影像集合中，透過 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagecollection/) 與 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 物件公開。

如果只需要匯出簡報中嵌入的每個影像資源，可遍歷 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getImages)。本文聚焦於另一項任務：遍歷形狀以找出投影片上使用影像的地方，讓儲存的檔案能保留有用的上下文資訊，如投影片編號、形狀位置與來源類型（圖片框、填充影像、媒體預覽、OLE 預覽或 Zoom 影像）。

{{% alert title="提示" color="success" %}}
使用 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getBinaryData) 可保留原始編碼的影像資料與檔案類型。若想將輸出正規化為特定格式（如 PNG），可使用 [PPImage.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getImage) 搭配 `save`。
{{% /alert %}}

## **共用輔助函式**

將下列共用輔助函式儲存於 `image_helpers.py`，與範例腳本放在同一目錄下。這可讓範例保持簡潔。`save_original_image` 會寫入原始嵌入位元組、依 MIME 型別選擇安全的副檔名，並透過 SHA-256 雜湊跳過重複的影像位元組。

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

## **從圖片框擷取影像**

使用此方法擷取以獨立物件插入的圖片。[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 可透過 [getPictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#getPicture) 與 [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/#getImage) 取得其圖片，回傳的物件為 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/)。

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

## **從填充圖片的形狀擷取影像**

形狀可以使用圖片作為填充。先檢查形狀的填充類型：如果不是 [FillType.Picture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/)，就沒有可擷取的圖片。以下範例處理 [AutoShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/autoshape/) 物件，並透過 [PPImage.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getImage) 以 PNG 格式儲存每張圖片。

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

## **從 OLE 物件框擷取預覽影像**

[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 可以有 PowerPoint 用於投影片預覽的代用圖片。此影像可透過 [getSubstitutePictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)、[getPicture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#getPicture) 與 [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/#getImage) 取得。擷取此圖片會得到預覽影像，而非嵌入的 OLE 套件內容。

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

## **從影片框擷取預覽影像**

[VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 也可以在 [getPictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#getPicture) 與 [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/#getImage) 中儲存預覽圖。這是投影片上顯示的海報或縮圖，並非從影片串流解碼的畫格。

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

## **從音訊框擷取預覽影像**

[AudioFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/) 可以在 [getPictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#getPicture) 與 [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/#getImage) 中儲存縮圖。這是在投影片上為音訊物件顯示的圖示。

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

## **從 Zoom 物件擷取影像**

[ZoomFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zoomframe/) 與 [SectionZoomFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sectionzoomframe/) 形狀可以使用自訂影像。請從 Zoom 框讀取 [getZoomImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zoomobject/#getZoomImage)。

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

## **從摘要 Zoom 框擷取影像**

[SummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/summaryzoomframe/) 同樣是一種形狀。其各節項目可使用自訂影像，透過每個摘要 Zoom 節的 [getZoomImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zoomobject/#getZoomImage) 方法取得。

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

## **從表格形狀擷取影像**

[Table](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/table/) 是一種形狀。表格中的影像通常以圖片填充的方式儲存在表格儲存格中。

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

## **從圖表形狀擷取影像**

[Chart](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chart/) 是一種形狀。下列範例從圖表區域的圖片填充中擷取影像。

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

## **從 SmartArt 形狀擷取影像**

[SmartArt](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/smartart/) 物件是一種形狀。依據 SmartArt 版面配置，影像可能儲存在節點項目的子彈填充或節點形狀的填充格式中。

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

## **包含群組形狀內的影像**

群組形狀擁有自己的形狀集合。共用的 `enumerate_shapes` 輔助函式提供 `include_grouped_shapes` 參數。當需要檢查 [GroupShape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/groupshape/) 內的形狀時，將其設為 `True`。下列範例從圖片框、填充圖片的形狀、OLE 物件預覽、影片框縮圖與音訊框縮圖中擷取影像。若要同時包含表格、圖表、SmartArt 與摘要 Zoom 的影像，可在相同的遞迴形狀遍歷中重複使用前述各段的專門擷取邏輯。

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

## **邊緣情況與實務說明**

- **重複影像：** 多個形狀可能參考同一影像，或是不同影像卻具有相同的位元組。若希望每個唯一影像只產生一個輸出檔案，請在寫檔前對 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getBinaryData) 計算雜湊。
- **原始資料 vs 轉換輸出：** 儲存 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getBinaryData) 會保留 JPEG、PNG、GIF、SVG、EMF 或 WMF 等嵌入的原始資料。透過 `save` 儲存 [PPImage.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getImage) 則適合需要統一輸出格式的情況。
- **不支援的填充類型：** 實心、漸層、圖樣及無填充的形狀不含圖片填充。讀取前請先檢查 [FillType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/filltype/)。
- **群組形狀：** 投影片的頂層形狀集合不會自動展平群組。當群組內容重要時，請遞迴檢查 [GroupShape.getShapes](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/groupshape/#getShapes)。
- **OLE 物件預覽：** [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/) 可能透過 [getSubstitutePictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 暴露預覽影像，但該影像僅為投影片預覽，並非 OLE 物件內嵌的檔案本身。
- **影片框縮圖：** [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 可能透過 [getPictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#getPictureFormat) 暴露預覽影像，該影像僅為投影片上顯示的海報，並非從影片串流解碼的畫格。
- **音訊框縮圖：** [AudioFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/audioframe/) 可能透過 [getPictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#getPictureFormat) 暴露圖示或縮圖；這並非嵌入的音訊資料本身。
- **Zoom 影像：** 投影片 Zoom、節段 Zoom 與摘要 Zoom 形狀可透過 [getZoomImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zoomobject/#getZoomImage) 取得自訂的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 物件。
- **巢狀形狀模型：** 表格、圖表與 SmartArt 物件皆實作 [Shape](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/)，但其影像常存於巢狀的儲存格、圖表元素或 SmartArt 節點格式物件中。
- **裁剪或變形的圖片：** 取得 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 只會得到儲存的影像資源，並不會套用形狀所做的裁剪、透明度、重新著色、旋轉或其他視覺效果。

## **常見問題**

**我能否在不裁剪、套用效果或形狀變形的情況下擷取原始影像？**  
可以。存取 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 物件，並將 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getBinaryData) 寫入磁碟，即可保留簡報中儲存的原始編碼影像，而非投影片上呈現的樣子。

**我能否將所有擷取的影像匯出為 PNG？**  
可以。使用 [PPImage.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getImage) 取得影像物件，然後以 `save` 搭配 [ImageFormat.Png](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imageformat/) 儲存。這會將輸出轉換為 PNG，可能不會保留原始檔案類型或向量資料。

**如何避免重複儲存同一影像？**  
對 [PPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/#getBinaryData) 計算雜湊，將雜湊值保存在集合中。若新影像的雜湊已存在，則跳過儲存或記錄為同一輸出檔案的另一個參考。

**為什麼有些形狀不會產生影像？**  
圖片框、填充圖片的形狀、OLE 物件框、媒體框、Zoom 框、表格、圖表與 SmartArt 物件都可能參考影像。某些形狀類型會透過巢狀的格式物件暴露影像，因此僅檢查 [getPictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#getPictureFormat) 或形狀的 [getFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getFillFormat) 並不足以抓到所有情況。

**我能否擷取影片框顯示的縮圖？**  
可以。使用 [VideoFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/videoframe/) 讀取 [getPictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#getPictureFormat)、[getPicture](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#getPicture) 與 [getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/#getImage)。此操作會擷取隨影片框儲存的海報影像，而非從影片檔案中產生的畫格。

**我要如何判斷哪些形狀使用了簡報影像集合中的特定影像？**  
Aspose.Slides 不會從 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 反向追蹤至形狀。遍歷時建立映射：每當發現影像參考時，記錄投影片編號、形狀路徑以及影像的雜湊或集合項目。

**我能否擷取嵌入在 OLE 物件內的影像，例如附加的文件？**  
您可以從 [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 取得 OLE 物件的投影片預覽圖。但該預覽圖並非嵌入的文件本身。若要擷取內嵌檔案中的影像，需要先抽出 OLE 資料，然後使用該檔案類型的工具進一步檢查。