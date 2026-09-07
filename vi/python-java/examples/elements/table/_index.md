---
title: Bảng
type: docs
weight: 120
url: /vi/python-java/examples/elements/table/
keywords:
- ví dụ mã
- bảng
- thêm bảng
- truy cập bảng
- xóa bảng
- hợp nhất ô
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Làm việc với các bảng trong Aspose.Slides for Python via Java: thêm, truy cập, xóa và hợp nhất các ô trong bản trình chiếu PowerPoint và OpenDocument."
---
Các ví dụ về cách thêm bảng, truy cập chúng, xóa chúng và hợp nhất các ô sử dụng **Aspose.Slides for Python via Java**.

Cài đặt gói theo mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API sau khi JVM đã chạy.

## **Thêm bảng**

Tạo một bảng đơn giản với hai hàng và hai cột.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **Truy cập bảng**

Lấy hình dạng bảng đầu tiên trên slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Truy cập bảng đầu tiên trên slide.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **Xóa bảng**

Xóa một bảng khỏi slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **Hợp nhất các ô của bảng**

Hợp nhất các ô liền kề của một bảng thành một ô duy nhất.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Hợp nhất các ô.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```