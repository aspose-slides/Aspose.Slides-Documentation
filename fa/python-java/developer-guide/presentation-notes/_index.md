---
title: مدیریت یادداشت‌های ارائه در پایتون از طریق جاوا
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/python-java/presentation-notes/
keywords:
- یادداشت
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
description: "یادداشت‌های ارائه را با Aspose.Slides برای پایتون از طریق جاوا سفارشی کنید. به راحتی با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **بررسی کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت‌ها را از یک ارائه فراهم می‌کند. این موضوع این ویژگی را معرفی می‌کند، شامل نحوه حذف یادداشت‌ها و چگونگی اعمال سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلایدی حذف کنید و به یادداشت‌های موجود استایل بدهید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

برای خواندن یا تغییر اندازه صفحه یادداشت‌ها، تغییر جهت، و بررسی رفتار خروجی، به [Notes Page Size](/slides/fa/python-java/notes-size/) مراجعه کنید.

## **حذف یادداشت‌ها از اسلاید**

یادداشت‌ها از یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
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

یادداشت‌ها از تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
presentation = Presentation("presWithNotes.pptx")
try:
    # حذف یادداشت‌ها از تمام اسلایدها.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # ذخیره‌ی ارائه در دیسک.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **افزودن سبک به یادداشت‌ها**

متد [getNotesStyle](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslide/#getNotesStyle) کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslide/) دسترسی به سبک متن یادداشت‌ها را فراهم می‌کند. پیاده‌سازی آن در مثال زیر نمایش داده شده است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# یک شیء Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # دریافت سبک متن اسلاید یادداشت‌های اصلی.
        notes_style = notes_master.getNotesStyle()

        # تنظیم گلوله‌های نماد برای پاراگراف‌های سطح اول.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **پرسش‌های متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیریت‌کننده یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notesslidemanager/) و متد [getNotesSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notesslidemanager/#getNotesSlide) است که شیء یادداشت را برمی‌گرداند، یا `None` اگر هیچ یادداشتی وجود نداشته باشد.

**آیا پشتیبانی از یادداشت‌ها بین نسخه‌های مختلف PowerPoint که کتابخانه با آن‌ها کار می‌کند تفاوت دارد؟**

کتابخانه هدف‌گذاری بر روی طیف وسیعی از فرمت‌های Microsoft PowerPoint (نسخه 97 به بعد) و ODP را دارد؛ یادداشت‌ها در این فرمت‌ها بدون نیاز به نصب یک نسخه PowerPoint پشتیبانی می‌شوند.