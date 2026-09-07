---
title: انتقال اسلاید
type: docs
weight: 110
url: /fa/python-java/examples/elements/slide-transition/
keywords:
- نمونه کد
- انتقال اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "اعمال و حذف انتقال اسلاید و تنظیم زمان‌بندی پیشرفت خودکار اسلایدها با مثال‌های کد Aspose.Slides for Python via Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نحوه اعمال اثرات انتقال اسلاید و زمانبندی‌ها را با **Aspose.Slides for Python via Java** نشان می‌دهد.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را ایمپورت می‌کند و سپس پس از اجرای JVM، API را ایمپورت می‌کند.

## **افزودن انتقال اسلاید**

یک اثر انتقال محو (fade) را بر روی اولین اسلاید اعمال کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # یک انتقال محو اعمال کنید.
finally:
    presentation.dispose()
```

## **دستیابی به انتقال اسلاید**

نوع انتقال فعلی اختصاص داده شده به یک اسلاید را بخوانید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # دسترسی به نوع انتقال.
finally:
    presentation.dispose()
```

## **حذف انتقال اسلاید**

هر اثر انتقالی را پاک کنید. JPype ثابت جاوا با نام `None` را به عنوان `None_` نمایش می‌دهد زیرا `None` کلمه کلیدی رزرو شده‌ای در پایتون است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # حذف اثر انتقال.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **تنظیم مدت زمان انتقال**

مشخص کنید اسلاید چه مدت قبل از پیشرفت خودکار نمایش داده شود. این مثال پس از دو ثانیه پیش می‌رود و همچنین امکان پیشرفت با کلیک ماوس را فراهم می‌کند. این زمانبندی بر پیشرفت اسلاید تأثیر دارد، نه سرعت اثر انتقال.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # بر حسب میلی ثانیه.
finally:
    presentation.dispose()
```