---
title: Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu bằng Python
linktitle: Hình ảnh từ Hình dạng
type: docs
weight: 90
url: /vi/python-net/extracting-images-from-presentation-shapes/
keywords:
- trích xuất hình ảnh
- lấy lại hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET - giải pháp nhanh, thân thiện với mã."
---
## **Tổng quan**

Hình ảnh trong một bản trình bày có thể xuất hiện ở một số loại hình dạng: dưới dạng khung ảnh thông thường, dưới dạng hình ảnh được áp dụng làm nền cho các hình dạng, dưới dạng ảnh xem trước của đối tượng OLE, dưới dạng ảnh thu nhỏ của khung video hoặc âm thanh, dưới dạng ảnh phóng to, hoặc dưới dạng hình ảnh lồng trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu trữ những hình ảnh đó trong bộ sưu tập ảnh của bản trình bày, được cung cấp thông qua các đối tượng [ImageCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imagecollection/) và [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) .

Nếu bạn chỉ cần xuất mọi tài nguyên ảnh được nhúng trong một bản trình bày, hãy lặp qua `presentation.images`. Bài viết này tập trung vào một nhiệm vụ khác: duyệt qua các hình dạng để tìm vị trí sử dụng ảnh trên các slide, để các tệp đã lưu có thể giữ ngữ cảnh hữu ích như số slide, vị trí hình dạng và loại nguồn (khung ảnh, ảnh nền, xem trước đa phương tiện, xem trước OLE, hoặc ảnh phóng to).

{{% alert title="Tip" color="primary" %}}
Sử dụng thuộc tính `binary_data` của [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) để giữ nguyên dữ liệu ảnh đã mã hoá và loại tệp gốc. Sử dụng thuộc tính `image` cùng với `save` khi bạn muốn chuẩn hoá đầu ra sang một định dạng cụ thể như PNG.
{{% /alert %}}

## **Phương thức Trợ giúp Chung**

Phương thức trợ giúp dưới đây giúp các ví dụ ngắn gọn. `save_original_image` ghi các byte nhúng gốc, chọn phần mở rộng an toàn dựa trên MIME type, và bỏ qua các ảnh trùng lặp bằng hàm băm SHA-256.
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

## **Trích xuất Hình ảnh từ Khung Ảnh**

Sử dụng phương pháp này cho các ảnh được chèn dưới dạng đối tượng độc lập. Một [PictureFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pictureframe/) lưu trữ ảnh của mình trong `picture_format.picture.image`, trả về một đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) .
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

## **Trích xuất Hình ảnh từ Các Hình dạng được Điền Ảnh**

Các hình dạng có thể sử dụng ảnh làm nền. Đầu tiên kiểm tra loại nền của hình dạng: nếu không phải là [FillType.PICTURE](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/), thì không có ảnh để trích xuất từ nền đó. Ví dụ dưới đây xử lý các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/autoshape/) và lưu mỗi ảnh dưới dạng PNG thông qua thuộc tính `image` của [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) .
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

## **Trích xuất Ảnh Xem Trước từ Khung Đối tượng OLE**

Một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/oleobjectframe/) có thể có một ảnh thay thế mà PowerPoint sử dụng làm xem trước cho đối tượng trên slide. Ảnh này có sẵn qua `substitute_picture_format.picture.image`. Việc trích xuất ảnh này sẽ cho bạn ảnh xem trước, không phải nội dung gói OLE đã nhúng.
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

## **Trích xuất Ảnh Xem Trước từ Khung Video**

Một [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) cũng có thể lưu trữ ảnh xem trước trong `picture_format.picture.image`. Đây là ảnh bìa hoặc thu nhỏ hiển thị trên slide, không phải một khung được giải mã từ luồng video.
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

## **Trích xuất Ảnh Xem Trước từ Khung Âm Thanh**

Một [AudioFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/audioframe/) có thể lưu trữ một ảnh thu nhỏ trong `picture_format.picture.image`. Đây là ảnh hiển thị cho đối tượng âm thanh trên slide.
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

## **Trích xuất Hình ảnh từ Đối tượng Zoom**

Các hình dạng [ZoomFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/zoomframe/) và [SectionZoomFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sectionzoomframe/) có thể sử dụng ảnh tùy chỉnh. Đọc `zoom_image` từ khung zoom.
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

## **Trích xuất Hình ảnh từ Khung Zoom Tổng hợp**

Một [SummaryZoomFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/summaryzoomframe/) cũng là một hình dạng. Các mục phần của nó có thể sử dụng ảnh tùy chỉnh, được truy cập thông qua thuộc tính `zoom_image` của mỗi phần zoom tổng hợp.
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

## **Trích xuất Hình ảnh từ Hình dạng Bảng**

Một [Table](https://reference.aspose.com/slides/vi/python-net/aspose.slides/table/) là một hình dạng. Các hình ảnh trong bảng thường được lưu dưới dạng nền ảnh trong các ô bảng.
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

## **Trích xuất Hình ảnh từ Hình dạng Biểu đồ**

Một [Chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chart/) là một hình dạng. Ví dụ dưới đây trích xuất một ảnh từ nền ảnh của khu vực biểu đồ.
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

## **Trích xuất Hình ảnh từ Hình dạng SmartArt**

Một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/) là một hình dạng. Tùy thuộc vào bố cục SmartArt, các hình ảnh có thể được lưu trong nền điểm đánh dấu của nút hoặc trong định dạng nền của các hình dạng nút.
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

## **Bao gồm Hình ảnh trong Các Hình dạng Nhóm**

Các hình dạng được nhóm chứa bộ sưu tập hình dạng riêng của chúng. Trợ giúp `enumerate_shapes` chung có tùy chọn `include_grouped_shapes`. Đặt thành `True` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [GroupShape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/) . Ví dụ dưới đây trích xuất hình ảnh từ khung ảnh, hình dạng được điền ảnh, xem trước đối tượng OLE, ảnh thu nhỏ khung video và ảnh thu nhỏ khung âm thanh. Để bao gồm cả hình ảnh bảng, biểu đồ, SmartArt và zoom tổng hợp, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước đồng thời giữ cùng quá trình duyệt hình dạng đệ quy.
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

## **Các Trường hợp Cực đoan và Lưu ý Thực tiễn**

- **Ảnh trùng lặp:** Nhiều hình dạng có thể tham chiếu cùng một ảnh hoặc các ảnh riêng biệt có byte giống nhau. Tạo hàm băm thuộc tính `binary_data` của [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) trước khi ghi file nếu bạn muốn một file đầu ra cho mỗi ảnh duy nhất.
- **Dữ liệu gốc vs. đầu ra đã chuyển đổi:** Lưu thuộc tính `binary_data` của [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) bảo toàn dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF đã nhúng. Lưu thuộc tính `image` qua `save` hữu ích khi bạn muốn một định dạng đầu ra đồng nhất.
- **Các loại nền không được hỗ trợ:** Các hình dạng đặc, gradient, mẫu và không nền không chứa nền ảnh. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/filltype/) trước khi đọc `picture_fill_format`.
- **Hình dạng nhóm:** Bộ sưu tập hình dạng slide cấp cao không làm phẳng các nhóm. Kiểm tra đệ quy [GroupShape.shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/groupshape/shapes/) khi nội dung nhóm quan trọng.
- **Xem trước đối tượng OLE:** Một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/oleobjectframe/) có thể hiển thị ảnh xem trước qua `substitute_picture_format`, nhưng ảnh này chỉ là xem trước trên slide. Nó không phải là tệp được nhúng bên trong đối tượng OLE.
- **Ảnh thu nhỏ khung video:** Một [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) có thể hiển thị ảnh xem trước qua `picture_format`, nhưng ảnh này chỉ là bìa hiển thị trên slide. Nó không được trích xuất từ luồng video.
- **Ảnh thu nhỏ khung âm thanh:** Một [AudioFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/audioframe/) có thể hiển thị biểu tượng hoặc ảnh thu nhỏ qua `picture_format`; nó không phải là dữ liệu âm thanh được nhúng.
- **Ảnh zoom:** Các hình dạng zoom slide, zoom phần và zoom tổng hợp có thể sử dụng các đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) tùy chỉnh qua `image`.
- **Mô hình hình dạng lồng nhau:** Các đối tượng bảng, biểu đồ và SmartArt thực thi [Shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/), nhưng các ảnh của chúng thường được lưu trong ô bảng, phần tử biểu đồ hoặc đối tượng định dạng nút SmartArt lồng nhau.
- **Ảnh đã cắt hoặc biến đổi:** Truy cập [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) cung cấp tài nguyên ảnh đã lưu. Nó không thực hiện cắt, trong suốt, đổi màu, xoay hoặc các hiệu ứng hình ảnh khác được áp dụng bởi hình dạng.

## **Câu hỏi thường gặp**

**Tôi có thể trích xuất ảnh gốc mà không cắt, hiệu ứng hoặc biến đổi hình dạng không?**

Đúng. Truy cập đối tượng [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/), sau đó ghi thuộc tính `binary_data` của nó ra đĩa. Điều này bảo toàn ảnh đã mã hoá gốc được lưu trong bản trình bày, không phải cách ảnh được hiển thị trên slide.

**Tôi có thể xuất mọi ảnh đã trích xuất dưới dạng PNG không?**

Đúng. Sử dụng thuộc tính `image` của [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) để lấy đối tượng ảnh, sau đó gọi `save` với [ImageFormat.PNG](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imageformat/). Điều này chuyển đổi đầu ra và có thể không bảo toàn loại tệp gốc hoặc dữ liệu vector.

**Làm sao để tránh lưu cùng một ảnh hơn một lần?**

Sử dụng hàm băm của thuộc tính `binary_data` của [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) và lưu các hàm băm trong một tập hợp. Nếu một ảnh mới có hàm băm đã tồn tại, bỏ qua nó hoặc ghi lại một tham chiếu khác tới file đầu ra đã có.

**Tại sao một số hình dạng không tạo ra ảnh?**

Khung ảnh, hình dạng được điền ảnh, khung đối tượng OLE, khung phương tiện, khung zoom, bảng, biểu đồ và đối tượng SmartArt có thể tham chiếu đến ảnh. Một số loại hình dạng hiển thị ảnh thông qua các đối tượng định dạng lồng nhau, vì vậy việc kiểm tra đơn giản `picture_format` hoặc `fill_format` của hình dạng không luôn đủ.

**Tôi có thể trích xuất ảnh thu nhỏ hiển thị cho khung video không?**

Đúng. Sử dụng [VideoFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/videoframe/) và đọc `picture_format.picture.image`. Điều này trích xuất ảnh bìa được lưu cùng với khung video, không phải một khung được tạo ra từ tệp video.

**Làm sao tôi có thể xác định các hình dạng nào sử dụng một ảnh cụ thể từ bộ sưu tập ảnh của bản trình bày?**

Aspose.Slides không lưu trữ liên kết ngược từ [PPImage](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ppimage/) tới các hình dạng. Xây dựng một bảng ánh xạ trong quá trình duyệt: mỗi khi gặp tham chiếu ảnh, ghi lại số slide, đường dẫn hình dạng và hàm băm ảnh hoặc mục trong bộ sưu tập.

**Tôi có thể trích xuất ảnh được nhúng trong đối tượng OLE, chẳng hạn như tài liệu đính kèm không?**

Bạn có thể trích xuất xem trước slide của đối tượng OLE từ thuộc tính `substitute_picture_format` của [OleObjectFrame](https://reference.aspose.com/slides/vi/python-net/aspose.slides/oleobjectframe/). Tuy nhiên, xem trước này không phải là tài liệu được nhúng. Để trích xuất ảnh từ bên trong tệp được nhúng, hãy lấy dữ liệu OLE và kiểm tra nó bằng các công cụ phù hợp với loại tệp đó.