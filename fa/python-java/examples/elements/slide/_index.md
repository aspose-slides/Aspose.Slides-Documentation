---
title: اسلاید
type: docs
weight: 10
url: /fa/python-java/examples/elements/slide/
keywords:
- نمونه کد
- اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "اسلایدها را در Aspose.Slides برای Python via Java مدیریت کنید: افزودن، دسترسی، تکثیر، ترتیب‌گذاری مجدد و حذف اسلایدها با مثال‌های کد پایتون برای ارائه‌های پاورپوینت و OpenDocument."
---
این مقاله مثال‌هایی را ارائه می‌دهد که نشان می‌دهد چگونه می‌توان اسلایدها را با استفاده از **Aspose.Slides for Python via Java** اضافه، دسترسی، تکثیر، ترتیب‌گذاری مجدد و حذف کرد.

پکیج را همان‌طور که در [نصب](/slides/fa/python-java/installation/) توضیح داده شده است، نصب کنید. هر مثال قبل از شروع JVM `asposeslides` را وارد می‌کند، سپس پس از راه‌اندازی JVM API را وارد می‌نماید.

## **اضافه‌کردن اسلاید**

برای اضافه کردن اسلاید جدید، ابتدا یک چیدمان را انتخاب کنید. این مثال از یک چیدمان خالی استفاده می‌کند تا یک اسلاید خالی به ارائه اضافه شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="توجه" %}}
هر چیدمان اسلاید از یک اسلاید اصلی مشتق می‌شود که طراحی کلی و ساختار نگهدارنده‌ها را تعریف می‌کند. تصویر زیر نشان می‌دهد که اسلایدهای اصلی و چیدمان‌های وابسته به آن‌ها در PowerPoint چگونه سازماندهی می‌شوند.
{{% /alert %}}

![رابطه اسلاید اصلی و چیدمان](master-layout-slide.png)

## **دسترسی به اسلایدها بر اساس اندیس**

به اسلایدها با استفاده از اندیس صفر‑پایه دسترسی پیدا کنید یا اندیس یک اسلاید را براساس مرجع پیدا کنید. این کار برای تکرار یا اصلاح اسلایدهای خاص مفید است.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # یک اسلاید خالی دیگر اضافه کنید.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # دسترسی به اسلایدها بر اساس اندیس.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # اندیس یک اسلاید را از یک مرجع دریافت کنید، سپس با اندیس به آن دسترسی پیدا کنید.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **تکثیر اسلاید**

یک اسلاید موجود را تکثیر کنید. اسلاید تکثیر شده به‌صورت خودکار به انتهای مجموعه اسلایدها اضافه می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **تغییر ترتیب اسلایدها**

ترتیب اسلایدها را با جابجا کردن یک اسلاید به یک اندیس جدید تغییر دهید. این مثال اسلاید تکثیر شده را به اولین موقعیت می‌برد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **حذف اسلاید**

یک اسلاید را با پاس کردن مرجع آن به مجموعه اسلایدها حذف کنید. این مثال یک اسلاید دوم اضافه می‌کند و سپس اسلاید اصلی را حذف می‌کند، به‌طوری که فقط اسلاید جدید باقی می‌ماند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```