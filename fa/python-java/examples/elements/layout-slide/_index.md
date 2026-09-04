---
title: اسلاید طرح‌بندی
type: docs
weight: 20
url: /fa/python-java/examples/elements/layout-slide/
keywords:
- مثال کد
- اسلاید طرح‌بندی
- افزودن اسلاید طرح‌بندی
- دسترسی به اسلاید طرح‌بندی
- حذف اسلاید طرح‌بندی
- اسلاید طرح‌بندی استفاده‌نشده
- تکثیر اسلاید طرح‌بندی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "مدیریت اسلایدهای طرح‌بندی با Aspose.Slides برای Python از طریق Java: افزودن، دسترسی، حذف، پاک‌سازی و تکثیر طرح‌بندی‌ها در ارائه‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد چطور با **layout slides** با استفاده از Aspose.Slides برای Python از طریق Java کار کنید. یک layout slide طراحی و قالب‌بندی‌ای را تعریف می‌کند که اسلایدهای معمولی به ارث می‌برند. می‌توانید layout slides را اضافه، دسترسی، تکثیر و حذف کنید و همچنین اسلایدهای استفاده‌نشده را پاک کنید تا اندازه ارائه کاهش یابد.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال قبل از شروع JVM `asposeslides` را وارد می‌کند، سپس پس از راه‌اندازی JVM API را وارد می‌نماید.

## **افزودن یک Layout Slide**

یک layout slide سفارشی ایجاد کنید تا قالب‌بندی قابل استفاده مجدد تعریف شود. مثال زیر یک جعبه متن را به یک layout جدید اضافه می‌کند و سپس دو اسلاید که از آن استفاده می‌کنند ایجاد می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # یک اسلاید طرح‌بندی با نوع طرح‌بندی خالی و نام سفارشی ایجاد کنید.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # یک جعبه متن به اسلاید طرح‌بندی اضافه کنید.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # دو اسلاید که متن را از طرح‌بندی به ارث می‌برند اضافه کنید.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **تذکر 1:** Layout slides به عنوان قالب برای اسلایدهای فردی عمل می‌کنند. می‌توانید عناصر مشترک را یک بار تعریف کنید و در اسلایدهای متعدد دوباره استفاده کنید.

> 💡 **تذکر 2:** وقتی اشکال یا متن را به یک layout slide اضافه می‌کنید، تمام اسلایدهای مبتنی بر آن layout به‌صورت خودکار محتویات مشترک را نمایش می‌دهند.
> تصویر زیر دو اسلایدی را نشان می‌دهد که یک جعبه متن را از همان layout slide به ارث می‌برند.

![اسلایدهای به ارث برده محتوای Layout](layout-slide-result.png)

## **دسترسی به یک Layout Slide**

layout slideها را می‌توان بر حسب شاخص یا نوع layout، مانند خالی، عنوان یا سربرگ بخش، دسترسی یافت.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # دسترسی به اسلاید طرح‌بندی بر حسب شاخص.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # دسترسی به اسلاید طرح‌بندی بر حسب نوع.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **حذف یک Layout Slide**

یک layout slide خاص را زمانی که دیگر مورد نیاز نیست حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **حذف Layout Slideهای استفاده‌نشده**

layout slideهایی که توسط هیچ اسلاید معمولی استفاده نشده‌اند را حذف کنید تا اندازه ارائه کاهش یابد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **کلون کردن یک Layout Slide**

یک layout slide را تکثیر کنید و کپی آن را به انتهای مجموعه layout slideها اضافه کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **خلاصه:** Layout slideها به حفظ قالب‌بندی سازگار در سراسر یک ارائه کمک می‌کنند. Aspose.Slides به شما امکان می‌دهد layoutها را ایجاد، مدیریت، دوباره استفاده و پاک‌سازی نمایید حسب نیاز.