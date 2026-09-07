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
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Làm việc với hộp văn bản trong Aspose.Slides for Python via Java: thêm, định dạng, tìm và xóa văn bản trong các bản trình bày PowerPoint và OpenDocument."
---
Trong **Aspose.Slides for Python via Java**, một hộp văn bản là một hình dạng tự động chứa văn bản. Hầu hết mọi hình dạng đều có thể chứa văn bản, nhưng một hộp văn bản tiêu chuẩn không có màu nền hay viền và chỉ hiển thị văn bản.

Hướng dẫn này giải thích cách thêm, truy cập và xóa hộp văn bản một cách lập trình.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Add a Text Box**

Tạo một hình chữ nhật, xóa màu nền và viền của nó, và gán văn bản đã định dạng.

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

    # Tạo một hình chữ nhật.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Xóa màu nền và viền để chỉ hiển thị văn bản.
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

## **Access Text Boxes by Content**

Thêm một hộp văn bản mẫu, sau đó tìm các hình dạng có văn bản chứa từ khóa "Slide".

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

## **Remove Text Boxes by Content**

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

{{% alert color="success" title="Tip" %}}
Thu thập các hình dạng khớp vào một danh sách riêng trước khi xóa chúng để tránh việc sửa đổi bộ sưu tập hình dạng trong quá trình lặp.
{{% /alert %}}