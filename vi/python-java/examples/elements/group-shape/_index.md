---
title: Nhóm hình dạng
type: docs
weight: 170
url: /vi/python-java/examples/elements/group-shape/
keywords:
- ví dụ mã
- nhóm hình dạng
- thêm nhóm hình dạng
- truy cập nhóm hình dạng
- xóa nhóm hình dạng
- tách nhóm hình dạng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Quản lý các nhóm hình dạng trong bản trình chiếu bằng Aspose.Slides cho Python thông qua Java: thêm, truy cập, xóa và tách nhóm các hình dạng trong tệp PowerPoint và OpenDocument."
---
Bài viết này trình bày cách tạo nhóm các hình dạng, truy cập chúng, xóa chúng và tách nhóm nội dung của chúng bằng cách sử dụng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Thêm một hình dạng nhóm**

Tạo một nhóm chứa hai hình dạng cơ bản.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **Truy cập một hình dạng nhóm**

Lấy hình dạng nhóm đầu tiên từ một slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **Xóa một hình dạng nhóm**

Xóa một hình dạng nhóm khỏi slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **Tách nhóm các hình dạng**

Di chuyển một hình dạng ra khỏi container nhóm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # Di chuyển hình dạng ra khỏi nhóm.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```