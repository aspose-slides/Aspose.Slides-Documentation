---
title: SmartArt
type: docs
weight: 140
url: /fa/python-java/examples/elements/smart-art/
keywords:
- مثال کد
- SmartArt
- افزودن SmartArt
- دسترسی به SmartArt
- حذف SmartArt
- طرح‌بندی SmartArt
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "کار با SmartArt در Aspose.Slides برای Python از طریق Java: افزودن، دسترسی، حذف و تغییر طرح‌بندی‌های دیاگرامی در ارائه‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد که چگونه گرافیک‌های SmartArt را اضافه کنید، به آن‌ها دسترسی داشته باشید، حذف کنید و طرح‌بندی‌ها را با استفاده از **Aspose.Slides for Python via Java** تغییر دهید.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال قبل از راه‌اندازی JVM `asposeslides` را وارد می‌کند و سپس پس از اجرای JVM API را وارد می‌نماید.

## **افزودن SmartArt**

یک گرافیک SmartArt را با استفاده از یکی از طرح‌بندی‌های پیش‌ساخته درج کنید.

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

## **دسترسی به SmartArt**

اولین شیء SmartArt موجود در یک اسلاید را بازیابی کنید.

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

## **حذف SmartArt**

یک شکل SmartArt را از اسلاید حذف کنید.

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

## **تغییر طرح‌بندی SmartArt**

نوع طرح‌بندی یک گرافیک SmartArt موجود را به‌روزرسانی کنید.

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