---
title: شکل گروهی
type: docs
weight: 170
url: /fa/python-java/examples/elements/group-shape/
keywords:
- مثال کد
- شکل گروهی
- افزودن شکل گروهی
- دسترسی به شکل گروهی
- حذف شکل گروهی
- لغو گروه‌بندی اشکال
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "مدیریت اشکال گروهی در ارائه‌ها با Aspose.Slides برای Python از طریق Java: افزودن، دسترسی، حذف و لغو گروه‌بندی اشکال در فایل‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد چگونه گروه‌هایی از اشکال را ایجاد کنید، به آن‌ها دسترسی داشته باشید، آن‌ها را حذف کنید و محتویات آن‌ها را بدون گروه‌بندی کنید با استفاده از **Aspose.Slides for Python via Java**.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است، نصب کنید. هر مثال قبل از شروع JVM، `asposeslides` را ایمپورت می‌کند، سپس پس از اجرای JVM، API را ایمپورت می‌کند.

## **افزودن یک شکل گروهی**

یک گروه شامل دو شکل پایه ایجاد کنید.

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

## **دسترسی به یک شکل گروهی**

اولین شکل گروهی را از اسلاید بازیابی کنید.

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

## **حذف یک شکل گروهی**

یک شکل گروهی را از اسلاید حذف کنید.

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

## **لغو گروه‌بندی اشکال**

یک شکل را از داخل محفظه گروه خارج کنید.

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

    # شکل را از گروه خارج کنید.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```