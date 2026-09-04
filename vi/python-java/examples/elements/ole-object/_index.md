---
title: Đối tượng OLE
type: docs
weight: 210
url: /vi/python-java/examples/elements/ole-object/
keywords:
- ví dụ mã
- đối tượng OLE
- thêm đối tượng OLE
- truy cập đối tượng OLE
- xóa đối tượng OLE
- cập nhật đối tượng OLE
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho Python qua Java để thêm, truy cập, xóa và cập nhật các đối tượng OLE trong bản trình chiếu PowerPoint và OpenDocument."
---
Bài viết này minh họa cách chèn một tệp dưới dạng đối tượng OLE và cập nhật dữ liệu của nó bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Cài đặt](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ import `asposeslides` trước khi khởi động JVM, sau đó import API khi JVM đã chạy.

## **Thêm một đối tượng OLE**

Chèn một tệp PDF vào bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)
finally:
    presentation.dispose()
```

## **Truy cập một đối tượng OLE**

Lấy khung đối tượng OLE đầu tiên trên một slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    first_ole_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, OleObjectFrame):
            first_ole_frame = shape
            break

    if first_ole_frame is None:
        print("The slide contains no OLE object frames.")
finally:
    presentation.dispose()
```

## **Xóa một đối tượng OLE**

Xóa một đối tượng OLE đã được chèn khỏi slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    slide.getShapes().remove(ole_frame)
finally:
    presentation.dispose()
```

## **Cập nhật dữ liệu đối tượng OLE**

Thay thế dữ liệu được nhúng trong một đối tượng OLE hiện có.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.nio.file import Files, Paths
from asposeslides.api import OleEmbeddedDataInfo, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    pdf_data = Files.readAllBytes(Paths.get("doc.pdf"))
    data_info = OleEmbeddedDataInfo(pdf_data, "pdf")
    ole_frame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, data_info)

    new_data = Files.readAllBytes(Paths.get("Picture.png"))
    new_data_info = OleEmbeddedDataInfo(new_data, "png")
    ole_frame.setEmbeddedData(new_data_info)
finally:
    presentation.dispose()
```