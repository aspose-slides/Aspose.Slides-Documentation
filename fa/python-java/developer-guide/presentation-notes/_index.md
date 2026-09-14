---
title: مدیریت یادداشت‌های ارائه در Python از طریق Java
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/python-java/presentation-notes/
keywords:
- یادداشت‌ها
- اسلاید یادداشت
- افزودن یادداشت
- حذف یادداشت
- سبک یادداشت
- یادداشت‌های اصلی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "سفارشی‌سازی یادداشت‌های ارائه با Aspose.Slides برای Python از طریق Java. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت را از یک ارائه فراهم می‌کند. این موضوع این ویژگی را معرفی می‌کند، از جمله نحوه حذف یادداشت‌ها و نحوه اعمال یک سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلاید حذف کنید و به یادداشت‌های موجود سبک بدهید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

## **حذف یادداشت‌ها از یک اسلاید**

یادداشت‌های یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند.
presentation = Presentation("presWithNotes.pptx")
try:
    # یادداشت‌ها را از اولین اسلاید حذف کنید.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # ارائه را در دیسک ذخیره کنید.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **حذف یادداشت‌ها از یک ارائه**

یادداشت‌های تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند.
presentation = Presentation("presWithNotes.pptx")
try:
    # یادداشت‌ها را از تمام اسلایدها حذف کنید.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # ارائه را در دیسک ذخیره کنید.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **افزودن سبک یادداشت‌ها**

متد [getNotesStyle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslide/#getNotesStyle) کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslide/) دسترسی به سبک متن یادداشت‌ها را فراهم می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# یک شیء Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # سبک متن اسلاید یادداشت اصلی را دریافت کنید.
        notes_style = notes_master.getNotesStyle()

        # گلوله‌های نمادیک را برای پاراگراف‌های سطح اول تنظیم کنید.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی می‌یابند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notesslidemanager/) و یک متد [getNotesSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notesslidemanager/#getNotesSlide) است که شیء یادداشت‌ها را برمی‌گرداند، یا `None` اگر هیچ یادداشتی وجود نداشته باشد.

**آیا تفاوت‌هایی در پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند وجود دارد؟**

کتابخانه هدف‌گذاری بر روی دامنه گسترده‌ای از فرمت‌های Microsoft PowerPoint (نسخه 97 به بعد) و ODP را دارد؛ یادداشت‌ها در این فرمت‌ها پشتیبانی می‌شوند بدون اینکه به نسخه نصب‌شده PowerPoint وابسته باشد.