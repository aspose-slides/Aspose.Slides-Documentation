---
title: اسلاید اصلی
type: docs
weight: 30
url: /fa/python-java/examples/elements/master-slide/
keywords:
- مثال کد
- اسلاید اصلی
- افزودن اسلاید اصلی
- دسترسی به اسلاید اصلی
- حذف اسلاید اصلی
- اسلاید اصلی غیر استفاده‌شده
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "مدیریت اسلایدهای اصلی با Aspose.Slides برای Python از طریق Java: ایجاد، دسترسی، حذف و پاک‌سازی اسلایدهای اصلی در ارائه‌های PowerPoint و OpenDocument."
---
اسلایدهای اصلی بالاترین سطح سلسله مراتب وراثت اسلاید در PowerPoint را تشکیل می‌دهند. یک **اسلاید اصلی** عناصر طراحی مشترک مانند پس‌زمینه‌ها، لوگوها و قالب‌بندی متن را تعریف می‌کند. **اسلایدهای طرح‌بندی** از اسلایدهای اصلی به ارث می‌برند و **اسلایدهای عادی** از اسلایدهای طرح‌بندی به ارث می‌برند.

این مقاله نشان می‌دهد چگونه می‌توان اسلایدهای اصلی را با استفاده از **Aspose.Slides for Python via Java** ایجاد، اصلاح و مدیریت کرد.

بسته را مطابق توضیحات موجود در [Installation](/slides/fa/python-java/installation/) نصب کنید. هر مثال قبل از راه‌اندازی JVM، ماژول `asposeslides` را ایمپورت می‌کند و سپس پس از اجرای JVM، API را ایمپورت می‌نماید.

## **افزودن اسلاید اصلی**

این مثال نشان می‌دهد چگونه با کلون کردن اسلاید پیش‌فرض، یک اسلاید اصلی جدید ایجاد کنیم. سپس بنر نام شرکت را از طریق وراثت طرح‌بندی به تمام اسلایدها اضافه می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # کپی اسلاید اصلی پیش‌فرض.
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # یک بنر با نام شرکت به بالای اسلاید اصلی اضافه کنید.
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # اسلاید اصلی جدید را به یک اسلاید طرح‌بندی اختصاص دهید.
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # اسلاید طرح‌بندی را به اولین اسلاید در ارائه اختصاص دهید.
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
اسلایدهای اصلی روشی برای اعمال برندینگ یکسان یا عناصر طراحی مشترک در تمام اسلایدها فراهم می‌کنند. تغییرات اعمال‌شده بر روی یک اسلاید اصلی به‌صورت خودکار در اسلایدهای طرح‌بندی و عادی وابسته بازتاب می‌یابد.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
شکل‌ها و قالب‌بندی‌هایی که به یک اسلاید اصلی اضافه می‌شوند، توسط اسلایدهای طرح‌بندی و به نوبه خود توسط تمام اسلایدهای عادی که از آن طرح‌ها استفاده می‌کنند، به ارث می‌رسند. تصویر زیر نشان می‌دهد چگونه یک جعبه متن که به اسلاید اصلی اضافه شده است، به‌صورت خودکار در اسلید نهایی رندر می‌شود.
{{% /alert %}}

![مثال وراثت اسلاید اصلی](master-slide-banner.png)

## **دسترسی به اسلاید اصلی**

می‌توانید از طریق مجموعه اسلایدهای اصلی ارائه، به اسلایدهای اصلی دسترسی پیدا کنید. این مثال اولین اسلاید اصلی را بازیابی کرده و نوع پس‌زمینه آن را تغییر می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **حذف اسلاید اصلی**

یک اسلاید اصلی می‌تواند پس از عدم استفاده، با استفاده از اندیس یا مرجع حذف شود. این مثال یک اسلاید اصلی کلون‌شده را به ارائه اختصاص می‌دهد و سپس اسلاید اصلی اصلی را با استفاده از اندیس حذف می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpapi.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # حذف اسلاید اصلی اولیه بدون استفاده بر اساس اندیس.
    # به‌صورت جایگزین، حذف اسلاید اصلی بدون استفاده بر اساس مرجع:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **حذف اسلایدهای اصلی غیر استفاده‌شده**

برخی ارائه‌ها شامل اسلایدهای اصلی هستند که مورد استفاده قرار نمی‌گیرند. حذف این اسلایدها می‌تواند به کاهش اندازه فایل کمک کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # تمام اسلایدهای اصلی استفاده‌نشده را حذف کنید، از جمله آن‌هایی که به عنوان Preserve علامت‌دار هستند.
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```