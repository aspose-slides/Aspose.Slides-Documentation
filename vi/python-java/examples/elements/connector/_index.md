---
title: Kết nối
type: docs
weight: 190
url: /vi/python-java/examples/elements/connector/
keywords:
- ví dụ mã
- bộ kết nối
- thêm kết nối
- truy cập kết nối
- xóa kết nối
- kết lại các hình
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, truy cập, xóa và kết lại các hình bằng connector sử dụng Aspose.Slides cho Python qua Java trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách kết nối các hình dạng bằng các connector và thay đổi mục tiêu của chúng bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như đã mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ import `asposeslides` trước khi khởi động JVM, sau đó import API khi JVM đã chạy.

## **Thêm một Connector**

Chèn một hình connector giữa hai điểm trên slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **Truy cập một Connector**

Lấy hình connector đầu tiên được thêm vào slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # Truy cập connector đầu tiên trên slide.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Xóa một Connector**

Xóa một connector khỏi slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **Kết nối lại các Shapes**

Gắn một connector vào hai shapes bằng cách chỉ định mục tiêu bắt đầu và kết thúc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```