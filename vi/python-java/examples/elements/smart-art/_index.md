---
title: SmartArt
type: docs
weight: 140
url: /vi/python-java/examples/elements/smart-art/
keywords:
- ví dụ mã
- SmartArt
- thêm SmartArt
- truy cập SmartArt
- xóa SmartArt
- bố cục SmartArt
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Làm việc với SmartArt trong Aspose.Slides cho Python qua Java: thêm, truy cập, xóa và thay đổi bố cục sơ đồ trong các bản trình bày PowerPoint và OpenDocument."
---
Bài viết này trình bày cách thêm đồ họa SmartArt, truy cập chúng, xóa chúng và thay đổi bố cục bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Cài đặt](/slides/vi/python-java/installation/). Mỗi ví dụ sẽ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Thêm SmartArt**

Chèn một đồ họa SmartArt bằng cách sử dụng một trong các bố cục tích hợp.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Truy cập SmartArt**

Lấy đối tượng SmartArt đầu tiên trên một slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Xóa SmartArt**

Xóa một hình dạng SmartArt khỏi slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Thay đổi Bố cục SmartArt**

Cập nhật loại bố cục của một đồ họa SmartArt hiện có.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```