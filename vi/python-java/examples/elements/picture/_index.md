---
title: Hình ảnh
type: docs
weight: 50
url: /vi/python-java/examples/elements/picture/
keywords:
- ví dụ mã
- hình ảnh
- thêm hình ảnh
- truy cập hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Chèn và truy cập các hình ảnh được tạo trong bộ nhớ bằng Aspose.Slides cho Python qua Java, với các ví dụ cho các bài thuyết trình PowerPoint và OpenDocument."
---
Bài viết này trình bày cách chèn và truy cập hình ảnh từ các ảnh trong bộ nhớ bằng **Aspose.Slides for Python via Java**. Các ví dụ dưới đây tạo một hình ảnh trong bộ nhớ, đặt nó lên một slide và sau đó lấy khung hình ảnh.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API sau khi JVM đã chạy.

## **Add a Picture**

Mã này tạo một bitmap nhỏ, chuyển nó thành luồng và chèn nó dưới dạng khung hình ảnh trên slide đầu tiên.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tạo một hình ảnh đơn giản trong bộ nhớ.
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # Chuyển bitmap thành mảng byte.
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # Thêm hình ảnh vào bản trình bày.
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # Chèn khung hình ảnh hiển thị hình trên slide đầu tiên.
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access a Picture**

Ví dụ này đảm bảo slide chứa một khung hình ảnh và sau đó truy cập vào khung đầu tiên được tìm thấy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import PictureFrame, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bitmap = BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB)
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image)

    picture_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is None:
        print("The slide contains no picture frames.")
finally:
    presentation.dispose()
```