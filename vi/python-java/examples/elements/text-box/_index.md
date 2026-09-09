---
title: Hộp văn bản
type: docs
weight: 40
url: /vi/python-java/examples/elements/text-box/
keywords:
- ví dụ mã
- hộp văn bản
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Làm việc với hộp văn bản trong Aspose.Slides cho Python thông qua Java: thêm, định dạng, tìm và xóa văn bản trong các bản trình chiếu PowerPoint và OpenDocument."
---
Trong **Aspose.Slides for Python via Java**, một hộp văn bản là một auto shape chứa văn bản. Hầu hết mọi shape đều có thể chứa văn bản, nhưng một hộp văn bản điển hình không có nền hay viền và chỉ hiển thị văn bản.

Hướng dẫn này mô tả cách thêm, truy cập và xóa hộp văn bản một cách lập trình.

Cài đặt gói theo mô tả trong [Cài đặt](/slides/vi/python-java/installation/). Mỗi ví dụ đều import `asposeslides` trước khi khởi động JVM, sau đó import API khi JVM đã chạy.

## **Thêm một hộp văn bản**

Tạo một hình chữ nhật, xóa nền và viền của nó, và gán văn bản đã định dạng.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Tạo một shape hình chữ nhật.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Xóa nền và viền để chỉ hiển thị văn bản.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Đặt định dạng văn bản mặc định.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Truy cập các hộp văn bản theo nội dung**

Thêm một hộp văn bản mẫu, sau đó tìm các shape có văn bản chứa từ khóa "Slide".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Sử dụng hộp văn bản phù hợp.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Xóa các hộp văn bản theo nội dung**

Tìm và xóa các hộp văn bản trên slide đầu tiên có chứa một từ khóa cụ thể.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Mẹo" %}}
Thu thập các shape phù hợp vào một danh sách riêng trước khi xóa chúng để tránh việc sửa đổi bộ sưu tập shape trong quá trình lặp.
{{% /alert %}}