---
title: Hoạt ảnh
type: docs
weight: 100
url: /vi/python-java/examples/elements/animation/
keywords:
- ví dụ mã
- hoạt ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Java
- Aspose.Slides
description: "Khám phá các ví dụ hoạt ảnh của Aspose.Slides cho Python thông qua Java: thêm, truy cập, xóa và sắp xếp các hiệu ứng trong các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách tạo các hoạt ảnh đơn giản và quản lý chuỗi của chúng bằng **Aspose.Slides for Python via Java**.

Cài đặt gói như mô tả trong [Installation](/slides/vi/python-java/installation/). Mỗi ví dụ nhập `asposeslides` trước khi khởi động JVM, sau đó nhập API khi JVM đã chạy.

## **Thêm hoạt ảnh**

Tạo một hình chữ nhật và áp dụng hiệu ứng mờ dần khi được kích hoạt bằng cú nhấp chuột.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)

    # Áp dụng hiệu ứng mờ dần.
finally:
    presentation.dispose()
```

## **Truy cập hoạt ảnh**

Lấy hiệu ứng hoạt ảnh đầu tiên từ dòng thời gian của slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # Truy cập hiệu ứng hoạt ảnh đầu tiên.
    effect = slide.getTimeline().getMainSequence().get_Item(0)
    print("Effect type:", effect.getType())
finally:
    presentation.dispose()
```

## **Xóa hoạt ảnh**

Xóa một hiệu ứng hoạt ảnh khỏi chuỗi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # Xóa hiệu ứng.
    slide.getTimeline().getMainSequence().remove(effect)
finally:
    presentation.dispose()
```

## **Chuỗi hoạt ảnh**

Thêm nhiều hiệu ứng và kiểm soát thứ tự mà các hoạt ảnh diễn ra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Ellipse, 200, 50, 100, 100)

    sequence = slide.getTimeline().getMainSequence()
    sequence.addEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
    sequence.addEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```