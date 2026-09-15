---
title: Tạo Trình Xem Bản Trình Chiếu trong Python qua Java
linktitle: Trình Xem Bản Trình Chiếu
type: docs
weight: 50
url: /vi/python-java/presentation-viewer/
keywords:
- xem bản trình chiếu
- trình xem bản trình chiếu
- tạo trình xem bản trình chiếu
- xem PPT
- xem PPTX
- xem ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tạo một trình xem bản trình chiếu tùy chỉnh trong Python qua Java sử dụng Aspose.Slides. Dễ dàng hiển thị các tệp PowerPoint và OpenDocument mà không cần Microsoft PowerPoint."
---
## **Giới thiệu**

Aspose.Slides cho Python thông qua Java được sử dụng để tạo tệp trình chiếu với các slide. Các slide này có thể được xem bằng cách mở trình chiếu trong Microsoft PowerPoint, chẳng hạn. Tuy nhiên, đôi khi các nhà phát triển có thể cần xem slide dưới dạng hình ảnh trong trình xem ảnh ưa thích của họ hoặc tạo trình xem trình chiếu riêng. Trong những trường hợp như vậy, Aspose.Slides cho phép bạn xuất một slide riêng lẻ thành hình ảnh. Bài viết này mô tả cách thực hiện.

## **Tạo hình ảnh SVG từ một Slide**

Để tạo hình ảnh SVG từ một slide trong bản trình chiếu bằng Aspose.Slides, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) class.
1. Lấy tham chiếu slide theo chỉ số của nó.
1. Mở một luồng byte.
1. Lưu slide thành hình ảnh SVG vào luồng và ghi nó vào tệp.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Tạo SVG với ID hình dạng tùy chỉnh**

Aspose.Slides có thể được sử dụng để tạo một [SVG](https://docs.fileformat.com/page-description-language/svg/) từ một slide với ID hình dạng tùy chỉnh. Để thực hiện điều này, sử dụng phương thức [SvgShape.setId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgshape/#setId) từ [SvgShape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` có thể được dùng để đặt ID hình dạng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Tạo hình ảnh thu nhỏ cho Slide**

Aspose.Slides giúp bạn tạo hình ảnh thu nhỏ của các slide. Để tạo thu nhỏ cho một slide bằng Aspose.Slides, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) class.
1. Lấy tham chiếu slide theo chỉ số của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với tỉ lệ đã xác định.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Tạo thu nhỏ slide với kích thước do người dùng xác định**

Để tạo hình ảnh thu nhỏ cho slide với kích thước do người dùng xác định, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) class.
1. Lấy tham chiếu slide theo chỉ số của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với các kích thước đã xác định.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Tạo thu nhỏ slide với ghi chú người nói**

Để tạo thu nhỏ cho một slide có ghi chú người nói bằng Aspose.Slides, vui lòng làm theo các bước sau:

1. Tạo một thể hiện của lớp [RenderingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/) class.
1. Sử dụng phương thức [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) để đặt vị trí của ghi chú người nói.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) class.
1. Lấy tham chiếu slide theo chỉ số của nó.
1. Lấy hình ảnh thu nhỏ của slide đã tham chiếu với các tùy chọn render.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Ví dụ trực tiếp**

Bạn có thể thử ứng dụng miễn phí [**Aspose.Slides Viewer**](https://products.aspose.app/slides/vi/viewer/) để xem những gì bạn có thể triển khai với API Aspose.Slides:

![Trình xem PowerPoint trực tuyến](online-PowerPoint-viewer.png)

## **Câu hỏi thường gặp**

**Tôi có thể nhúng trình xem bản trình chiếu vào một ứng dụng web không?**

Có. Bạn có thể sử dụng Aspose.Slides ở phía máy chủ để render các slide thành hình ảnh hoặc HTML và hiển thị chúng trong trình duyệt. Các tính năng điều hướng và thu phóng có thể được triển khai bằng JavaScript để mang lại trải nghiệm tương tác.

**Cách tốt nhất để hiển thị slide trong trình xem tùy chỉnh là gì?**

Cách tiếp cận đề xuất là render mỗi slide dưới dạng hình ảnh (ví dụ: PNG hoặc SVG) hoặc chuyển đổi nó sang HTML bằng Aspose.Slides, sau đó hiển thị kết quả trong một hộp hình ảnh (đối với desktop) hoặc trong một container HTML (đối với web).

**Làm thế nào để xử lý các bản trình chiếu lớn với nhiều slide?**

Đối với các bộ slide lớn, hãy cân nhắc tải lười (lazy-loading) hoặc render theo yêu cầu. Điều này có nghĩa là tạo nội dung của slide chỉ khi người dùng chuyển tới, giúp giảm bộ nhớ và thời gian tải.