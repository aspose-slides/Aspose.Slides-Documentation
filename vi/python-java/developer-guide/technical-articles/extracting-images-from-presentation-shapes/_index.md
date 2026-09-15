---
title: Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu bằng Python thông qua Java
linktitle: Hình ảnh từ Hình dạng
type: docs
weight: 100
url: /vi/python-java/extracting-images-from-presentation-shapes/
keywords:
- trích xuất hình ảnh
- lấy lại hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu PowerPoint và OpenDocument với Aspose.Slides cho Python thông qua Java - giải pháp nhanh, thân thiện với mã."
---
## **Tổng quan**

Hình ảnh trong một bản trình bày có thể xuất hiện dưới nhiều kiểu hình dạng: như khung hình ảnh thông thường, như hình nền được áp dụng cho các hình dạng, như ảnh xem trước của đối tượng OLE, như hình thu nhỏ của khung video hoặc âm thanh, như hình thu phóng, hoặc như hình ảnh lồng trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu trữ những hình ảnh này trong bộ sưu tập hình ảnh của bản trình bày, được truy cập qua các đối tượng [ImageCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/) và [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/).

Nếu bạn chỉ cần xuất mọi tài nguyên hình ảnh nhúng trong bản trình bày, hãy lặp qua [Presentation.getImages](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getImages). Bài viết này tập trung vào một nhiệm vụ khác: duyệt các hình dạng để tìm nơi hình ảnh được sử dụng trên các slide, để các tệp đã lưu có thể giữ ngữ cảnh hữu ích như số slide, vị trí hình dạng và kiểu nguồn (khung hình ảnh, hình nền, xem trước đa phương tiện, xem trước OLE, hoặc hình thu phóng).

{{% alert title="Tip" color="success" %}}
Sử dụng [PPImage.getBinaryData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getBinaryData) để bảo toàn dữ liệu hình ảnh đã mã hoá gốc và loại tệp. Sử dụng [PPImage.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getImage) kết hợp với `save` khi bạn muốn chuẩn hoá đầu ra thành định dạng cụ thể như PNG.
{{% /alert %}}

## **Các hàm trợ giúp chung**

Lưu các hàm trợ giúp chung dưới đây vào tệp `image_helpers.py` cùng với các script ví dụ. Chúng giúp các ví dụ ngắn gọn hơn. `save_original_image` ghi các byte nhúng gốc, chọn phần mở rộng an toàn từ MIME type, và bỏ qua các nhị phân hình ảnh trùng lặp bằng hàm băm SHA‑256.

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

## **Trích xuất hình ảnh từ Khung Hình Ảnh**

Sử dụng cách tiếp cận này cho hình ảnh được chèn dưới dạng đối tượng độc lập. Một [PictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/) cung cấp quyền truy cập vào hình ảnh của nó thông qua [getPictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#getPicture) và [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#getImage), trả về một đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/).

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

## **Trích xuất hình ảnh từ các hình dạng được tô bằng hình ảnh**

Các hình dạng có thể sử dụng một bức ảnh làm nền. Kiểm tra loại nền của hình dạng trước: nếu không phải là [FillType.Picture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/), thì không có hình ảnh nào để trích xuất từ nền đó. Ví dụ dưới đây xử lý các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/autoshape/) và lưu mỗi hình ảnh dưới dạng PNG qua [PPImage.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getImage).

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

## **Trích xuất hình ảnh xem trước từ Khung Đối tượng OLE**

Một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) có thể có một bức ảnh thay thế mà PowerPoint dùng làm xem trước của đối tượng trên slide. Hình ảnh này có sẵn qua [getSubstitutePictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#getPicture) và [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#getImage). Trích xuất bức ảnh này sẽ cho bạn ảnh xem trước, không phải nội dung gói OLE nhúng.

```python
from pathlib import Path
import jpime
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

## **Trích xuất hình ảnh xem trước từ Khung Video**

Một [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) cũng có thể lưu trữ ảnh xem trước trong [getPictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#getPicture) và [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#getImage). Đây là poster hoặc thumbnail hiển thị trên slide, không phải một khung video được giải mã từ luồng video.

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

## **Trích xuất hình ảnh xem trước từ Khung Âm thanh**

Một [AudioFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/) có thể lưu trữ một thumbnail trong [getPictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#getPicture) và [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#getImage). Đây là hình ảnh hiển thị cho đối tượng âm thanh trên slide.

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

## **Trích xuất hình ảnh từ Đối tượng Zoom**

Các hình dạng [ZoomFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zoomframe/) và [SectionZoomFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/sectionzoomframe/) có thể sử dụng hình ảnh tùy chỉnh. Đọc [getZoomImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zoomobject/#getZoomImage) từ khung zoom.

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

## **Trích xuất hình ảnh từ Khung Zoom Tổng quan**

Một [SummaryZoomFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/summaryzoomframe/) cũng là một hình dạng. Các mục phần của nó có thể sử dụng hình ảnh tùy chỉnh, được mở ra qua phương thức [getZoomImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zoomobject/#getZoomImage) của mỗi phần zoom tổng quan.

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

## **Trích xuất hình ảnh từ Hình dạng Bảng**

Một [Table](https://reference.aspose.com/slides/vi/python-java/aspose.slides/table/) là một hình dạng. Hình ảnh trong bảng thường được lưu dưới dạng nền hình ảnh trong các ô bảng.

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

## **Trích xuất hình ảnh từ Hình dạng Biểu đồ**

Một [Chart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/chart/) là một hình dạng. Ví dụ dưới đây trích xuất hình ảnh từ nền hình ảnh của khu vực biểu đồ.

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

## **Trích xuất hình ảnh từ Hình dạng SmartArt**

Một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) là một hình dạng. Tùy thuộc vào bố cục SmartArt, hình ảnh có thể được lưu trong nền bullet của nút hoặc trong định dạng nền của các hình dạng nút.

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

## **Bao gồm hình ảnh bên trong các Hình dạng Nhóm**

Các hình dạng nhóm chứa bộ sưu tập hình dạng riêng của chúng. Hàm trợ giúp `enumerate_shapes` chung có tùy chọn `include_grouped_shapes`. Đặt thành `True` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [GroupShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/groupshape/). Ví dụ dưới đây trích xuất hình ảnh từ khung hình ảnh, các hình dạng được tô bằng hình ảnh, xem trước OLE, thumbnail khung video và thumbnail khung âm thanh. Để bao gồm cả hình ảnh bảng, biểu đồ, SmartArt và zoom tổng quan, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước trong khi giữ cùng cách duyệt hình dạng đệ quy.

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

## **Các trường hợp đặc biệt và Ghi chú thực tiễn**

- **Hình ảnh trùng lặp:** Nhiều hình dạng có thể tham chiếu cùng một hình ảnh hoặc các hình ảnh riêng biệt có byte giống hệt nhau. Hãy băm [PPImage.getBinaryData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getBinaryData) trước khi ghi tệp nếu bạn muốn một tệp đầu ra cho mỗi hình ảnh duy nhất.
- **Dữ liệu gốc vs. đầu ra đã chuyển đổi:** Lưu [PPImage.getBinaryData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getBinaryData) giữ nguyên dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF được nhúng. Lưu [PPImage.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getImage) qua `save` hữu ích khi bạn muốn một định dạng đầu ra nhất quán.
- **Các loại nền không được hỗ trợ:** Các hình dạng đặc, gradient, pattern và không nền không chứa hình ảnh nền. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/filltype/) trước khi đọc [getPictureFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Hình dạng nhóm:** Bộ sưu tập hình dạng cấp cao nhất của slide không làm phẳng các nhóm. Kiểm tra đệ quy [GroupShape.getShapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/groupshape/#getShapes) khi nội dung nhóm quan trọng.
- **Xem trước OLE:** Một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) có thể cung cấp ảnh xem trước qua [getSubstitutePictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), nhưng ảnh này chỉ là preview trên slide, không phải tệp được nhúng trong đối tượng OLE.
- **Thumbnail khung video:** Một [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) có thể cung cấp ảnh xem trước qua [getPictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#getPictureFormat), nhưng ảnh này chỉ là poster hiển thị trên slide, không được trích xuất từ luồng video.
- **Thumbnail khung âm thanh:** Một [AudioFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audioframe/) có thể cung cấp một biểu tượng hoặc thumbnail qua [getPictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#getPictureFormat); nó không phải là dữ liệu âm thanh được nhúng.
- **Hình ảnh Zoom:** Các hình dạng Zoom slide, section zoom và summary zoom có thể sử dụng các đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) tùy chỉnh qua [getZoomImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Mô hình hình dạng lồng nhau:** Các đối tượng bảng, biểu đồ và SmartArt triển khai [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/), nhưng hình ảnh của chúng thường được lưu trong ô bảng, phần tử biểu đồ hoặc đối tượng định dạng nút SmartArt lồng nhau.
- **Hình ảnh đã cắt hoặc biến đổi:** Truy cập [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) chỉ cho bạn tài nguyên hình ảnh đã lưu. Nó không thực hiện việc cắt, trong suốt, thay đổi màu, xoay hoặc các hiệu ứng trực quan khác được áp dụng bởi hình dạng.

## **Câu hỏi thường gặp**

**Tôi có thể trích xuất hình ảnh gốc mà không bị cắt, hiệu ứng hoặc biến đổi hình dạng không?**

Có. Truy cập đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) và ghi [PPImage.getBinaryData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getBinaryData) ra đĩa. Điều này bảo toàn hình ảnh đã mã hoá gốc được lưu trong bản trình bày, không phải cách hình ảnh được hiển thị trên slide.

**Tôi có thể xuất mọi hình ảnh đã trích xuất dưới dạng PNG không?**

Có. Sử dụng [PPImage.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getImage) để lấy đối tượng hình ảnh, sau đó gọi `save` với [ImageFormat.Png](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imageformat/). Điều này sẽ chuyển đổi đầu ra và có thể không giữ lại loại tệp gốc hoặc dữ liệu vector.

**Làm sao để tránh lưu cùng một hình ảnh nhiều lần?**

Dùng hàm băm của [PPImage.getBinaryData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/#getBinaryData) và lưu các hàm băm trong một tập hợp. Nếu một hình ảnh mới có hàm băm đã tồn tại, bỏ qua nó hoặc ghi lại một tham chiếu khác tới tệp đầu ra đã có.

**Tại sao một số hình dạng không tạo ra hình ảnh?**

Khung hình ảnh, các hình dạng được tô bằng hình ảnh, khung OLE, khung đa phương tiện, khung zoom, bảng, biểu đồ và đối tượng SmartArt có thể tham chiếu hình ảnh. Một số kiểu hình dạng mở ra hình ảnh thông qua các đối tượng định dạng lồng nhau, vì vậy một kiểm tra đơn giản [getPictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#getPictureFormat) hoặc [getFillFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getFillFormat) của hình dạng không luôn đủ.

**Tôi có thể trích xuất thumbnail hiển thị cho khung video không?**

Có. Sử dụng [VideoFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/videoframe/) và đọc [getPictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picturefillformat/#getPicture) và [getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/picture/#getImage). Điều này trích xuất ảnh poster được lưu cùng với khung video, không phải một khung được tạo ra từ tệp video.

**Làm sao xác định hình dạng nào sử dụng một hình ảnh cụ thể từ bộ sưu tập hình ảnh của bản trình bày?**

Aspose.Slides không lưu liên kết ngược từ [PPImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/ppimage/) tới các hình dạng. Hãy xây dựng một bản đồ trong quá trình duyệt: mỗi khi bạn tìm thấy một tham chiếu hình ảnh, ghi lại số slide, đường dẫn hình dạng và hàm băm hoặc mục trong bộ sưu tập.

**Tôi có thể trích xuất hình ảnh nhúng trong các đối tượng OLE, chẳng hạn tài liệu đính kèm, không?**

Bạn có thể trích xuất ảnh xem trước của đối tượng OLE từ [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Tuy nhiên, preview này không phải là tài liệu được nhúng thực tế. Để trích xuất hình ảnh bên trong tệp nhúng, hãy trích xuất dữ liệu OLE và kiểm tra nó bằng các công cụ phù hợp với loại tệp đó.