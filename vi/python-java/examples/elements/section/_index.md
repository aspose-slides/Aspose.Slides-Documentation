---
title: Phần
type: docs
weight: 90
url: /vi/python-java/examples/elements/section/
keywords:
- ví dụ mã
- phần
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Quản lý các phần của bản trình chiếu trong Aspose.Slides cho Python via Java: thêm, truy cập, xóa và đổi tên các phần bằng ví dụ mã Python."
---
Các ví dụ về việc quản lý các phần trong bản trình chiếu—thêm, truy cập, xóa và đổi tên chúng một cách lập trình bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ đều nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API sau khi JVM đã chạy.

## **Thêm một Phần**

Create a section that starts at a specific slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Chỉ định slide đánh dấu sự bắt đầu của phần.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Truy cập một Phần**

Read section information from a presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Truy cập một phần theo chỉ mục.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Xóa một Phần**

Delete a previously added section.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Xóa phần đầu tiên.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Đổi tên một Phần**

Change the name of an existing section.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```