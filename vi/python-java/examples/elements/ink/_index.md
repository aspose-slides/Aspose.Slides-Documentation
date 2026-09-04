---
title: Mực
type: docs
weight: 180
url: /vi/python-java/examples/elements/ink/
keywords:
- ví dụ mã
- mực
- truy cập mực
- xóa mực
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Truy cập và xóa các hình mực trong các bản thuyết trình Aspose.Slides cho Python qua Java, bao gồm các tệp PPT, PPTX và ODP."
---
Bài viết này cung cấp các ví dụ về cách truy cập các hình mực hiện có và xóa chúng bằng **Aspose.Slides for Python via Java**.

Cài đặt gói theo hướng dẫn trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

{{% alert color="info" title="Lưu ý" %}}
Các hình mực đại diện cho đầu vào của người dùng từ các thiết bị chuyên dụng. Aspose.Slides không thể tạo các nét mực mới theo chương trình, nhưng bạn có thể đọc và chỉnh sửa các nét mực hiện có.
{{% /alert %}}

## **Truy cập Mực**

Đọc các thẻ từ hình mực đầu tiên trên một slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Sử dụng tag_name khi cần.
finally:
    presentation.dispose()
```

## **Xóa Mực**

Xóa một hình mực khỏi slide nếu nó tồn tại.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```