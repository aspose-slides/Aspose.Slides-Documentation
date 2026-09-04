---
title: انیمیشن
type: docs
weight: 100
url: /fa/python-java/examples/elements/animation/
keywords:
- مثال کد
- انیمیشن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "نمونه‌های انیمیشن Aspose.Slides برای Python از طریق Java را بررسی کنید: افزودن، دسترسی، حذف و ترتیب اثرها در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه انیمیشن‌های ساده ایجاد کرده و توالی آن‌ها را با استفاده از **Aspose.Slides for Python via Java** مدیریت کنید.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را وارد می‌کند و پس از اجرای JVM، API را وارد می‌کند.

## **افزودن انیمیشن**

یک شکل مستطیلی ایجاد کنید و اثر محو شدن را که با کلیک فعال می‌شود اعمال کنید.

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

    # اعمال اثر محو شدن.
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```

## **دسترسی به یک انیمیشن**

اثر اولین انیمیشن را از جدول زمانی اسلاید استخراج کنید.

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
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # دسترسی به اولین اثر انیمیشن.
    effect = slide.getTimeline().getMainSequence().get_Item(0)
    print("Effect type:", effect.getType())
finally:
    presentation.dispose()
```

## **حذف یک انیمیشن**

یک اثر انیمیشن را از توالی حذف کنید.

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

    # حذف اثر.
    slide.getTimeline().getMainSequence().remove(effect)
finally:
    presentation.dispose()
```

## **توالی‌سازی انیمیشن‌ها**

چندین اثر را اضافه کنید و ترتیب وقوع انیمیشن‌ها را کنترل کنید.

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