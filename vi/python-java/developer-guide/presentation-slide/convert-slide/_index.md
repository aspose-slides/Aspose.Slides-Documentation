---
title: Chuyển đổi các Slide của Bản trình bày sang Ảnh trong Python
linktitle: Slide sang Ảnh
type: docs
weight: 35
url: /vi/python-java/convert-slide/
keywords:
- chuyển đổi slide
- xuất slide
- slide sang ảnh
- lưu slide dưới dạng ảnh
- slide sang EMF
- slide sang PNG
- slide sang JPEG
- slide sang bitmap
- slide sang TIFF
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Chuyển đổi các slide từ bản trình bày PPT, PPTX và ODP sang PNG, JPEG, GIF, TIFF, EMF và các định dạng ảnh khác trong Python với Aspose.Slides."
---
## **Giới thiệu**

Aspose.Slides for Python via Java có thể kết xuất các slide riêng lẻ từ các bản trình bày PowerPoint và OpenDocument dưới dạng PNG, JPEG, GIF, TIFF và các định dạng ảnh khác.

Để chuyển đổi một slide thành ảnh, hãy thực hiện các bước sau:

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Chọn slide mà bạn muốn kết xuất.
3. Nếu cần, cấu hình việc kết xuất bằng lớp [RenderingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/) hoặc [TiffOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/).
4. Gọi phương thức [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage). Nó trả về một đối tượng ảnh.
5. Lưu ảnh và chỉ định định dạng đầu ra bằng giá trị [ImageFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imageformat/).

## **Chuyển đổi một Slide thành ảnh PNG**

Cách chuyển đổi đơn giản nhất sử dụng cài đặt kết xuất mặc định. Đối tượng ảnh kết quả có thể được xử lý trong bộ nhớ hoặc lưu vào file.

Ví dụ Python sau đây kết xuất slide đầu tiên và lưu nó dưới dạng ảnh PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Chuyển đổi các Slide thành ảnh với kích thước tùy chỉnh**

Sử dụng phương thức tải quá tải [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) chấp nhận một giá trị [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) để kết xuất một slide với kích thước pixel chính xác.

Ví dụ sau tạo một ảnh JPEG kích thước 1820 × 1040:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Chuyển đổi các Slide có Ghi chú và Bình luận thành ảnh**

Mặc định, ảnh slide không bao gồm ghi chú hoặc bình luận. Truyền một đối tượng [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/) vào phương thức [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) để kiểm soát vị trí hiển thị ghi chú và bình luận.

Ví dụ sau đặt ghi chú đã cắt ngắn phía dưới slide và bình luận phía bên phải:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Đối với việc chuyển đổi slide sang ảnh, không truyền [BottomFull](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomFull) vào phương thức [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Ghi chú có thể chứa nhiều văn bản hơn kích thước ảnh cố định cho phép. Thay vào đó, hãy sử dụng [BottomTruncated](https://reference.aspose.com/slides/vi/python-java/aspose.slides/notespositions/#BottomTruncated).
{{% /alert %}}

## **Chuyển đổi các Slide thành ảnh sử dụng tùy chọn TIFF**

Lớp [TiffOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/tiffoptions/) cho phép bạn kiểm soát kích thước, độ phân giải và các thuộc tính khác của ảnh TIFF đã được kết xuất.

Ví dụ sau kết xuất slide đầu tiên dưới dạng ảnh TIFF kích thước 2160 × 2880 với độ phân giải 300 DPI:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Hỗ trợ TIFF không được đảm bảo trong các phiên bản Java trước JDK 9.
{{% /alert %}}

## **Chuyển đổi tất cả các Slide thành ảnh**

Duyệt qua bộ sưu tập slide để chuyển đổi toàn bộ bản trình bày thành một loạt các ảnh. Các slide ẩn sẽ được bao gồm trừ khi bạn bỏ qua chúng một cách rõ ràng.

Ví dụ sau kết xuất mỗi slide dưới dạng ảnh JPEG với hệ số phóng đại ngang và dọc là 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Tạo đầu ra Enhanced Metafile**

Enhanced Metafile (EMF) hữu ích khi cần trao đổi đồ họa dựa trên vector với Microsoft Office hoặc các ứng dụng Windows khác hỗ trợ metafile Windows. Không giống như ảnh dựa trên pixel, EMF có thể lưu giữ các thao tác vẽ vector mà không mất độ sắc nét khi phóng to. Tuy nhiên, EMF chủ yếu là định dạng tương thích cho các ứng dụng hỗ trợ metafile Windows, không phải là định dạng trao đổi chung. Ngoài ra, nội dung slide phức tạp, chẳng hạn như ảnh bitmap và một số hiệu ứng, có thể được lưu dưới dạng các phần tử raster trong container metafile vector.

### **Xuất một Slide sang EMF**

Phương thức [Slide.writeAsEmf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) ghi một [Slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) vào một luồng đích ở định dạng EMF. Ví dụ sau tải một bản trình bày, chọn slide đầu tiên và ghi nó vào luồng file EMF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

Người gọi chịu trách nhiệm sở hữu luồng được truyền vào [Slide.writeAsEmf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) và phải đóng luồng này, như đã trình bày ở trên.

### **Chuyển đổi ảnh SVG sang EMF và thêm vào bản trình bày**

Sử dụng [SvgImage.writeAsEmf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/) để chuyển đổi nội dung SVG sang EMF. Các byte kết quả có thể được thêm vào bản trình bày thông qua [ImageCollection.addImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/imagecollection/#addImage) và đặt trên một slide bằng [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addPictureFrame).

Ví dụ sau tạo một [SvgImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/) từ mã SVG, chuyển đổi nó thành EMF trong bộ nhớ, chèn metafile lên slide đầu tiên và lưu bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/vi/python-java/aspose.slides/svgimage/) không nhận quyền sở hữu luồng đích. Một [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) lưu trữ tất cả dữ liệu được tạo ra trong bộ nhớ, vì vậy không cần đặt lại vị trí trước khi gọi [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--). Mảng byte trả về vẫn hợp lệ sau khi luồng được đóng.

Việc tạo EMF khả dụng trên các hệ điều hành được hỗ trợ bởi Aspose.Slides for Python via Java và cấu hình JDK đã chọn, nhưng việc kết xuất có thể khác nhau giữa các nền tảng khi phông chữ hoặc phụ thuộc đồ họa không có. Cài đặt các phông chữ được sử dụng trong nội dung gốc hoặc cấu hình các thay thế phù hợp, tuân thủ [yêu cầu nền tảng](/slides/vi/python-java/system-requirements/) cho Aspose.Slides for Python via Java, và xác minh kết quả trong ứng dụng tiêu thụ EMF mục tiêu. Các ứng dụng trên Linux và macOS thường có hỗ trợ hạn chế hoặc không nhất quán cho việc hiển thị và chỉnh sửa metafile Windows.

## **Kết xuất Emoji màu**

{{% alert title="Note" color="info" %}}
Để kết xuất emoji màu đúng cách khi chuyển đổi slide trình chiếu sang ảnh, các phông chữ emoji được sử dụng trong bản trình bày phải được cài đặt và có sẵn trên hệ thống thực hiện quá trình chuyển đổi. Ví dụ, nếu bản trình bày sử dụng **Segoe UI Emoji** nhưng phông chữ này thiếu, emoji có thể hiển thị dưới dạng đơn sắc trong các ảnh đầu ra.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ kết xuất slide có hoạt hình không?**

Không. Phương thức [Slide.getImage](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) kết xuất một ảnh tĩnh của slide và không xuất hoạt hình.

**Có thể xuất các slide ẩn dưới dạng ảnh không?**

Có. Các slide ẩn có thể được kết xuất giống như các slide thông thường. Bao gồm chúng trong vòng lặp xử lý, như đã minh họa trong ví dụ ở trên.

**Các bóng và các hiệu ứng khác có được giữ lại trong ảnh slide không?**

Có. Aspose.Slides kết xuất các bóng, độ trong suốt và các hiệu ứng đồ họa được hỗ trợ khác trong ảnh slide.