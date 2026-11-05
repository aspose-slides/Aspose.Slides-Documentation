---
title: مدیریت یادداشت‌های ارائه در پایتون
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/python-net/presentation-notes/
keywords:
- یادداشت‌ها
- اسلاید یادداشت
- افزودن یادداشت
- حذف یادداشت
- استایل یادداشت
- یادداشت‌های اصلی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای پایتون از طریق .NET سفارشی کنید. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **نمای کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت را از یک ارائه فراهم می‌کند. در این موضوع، این ویژگی را معرفی می‌کنیم، شامل نحوه حذف یادداشت‌ها و اعمال استایل به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلایدی حذف کنید و همچنین به یادداشت‌های موجود استایل بدهید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

برای خواندن یا تغییر ابعاد صفحه یادداشت‌ها، تغییر جهت، و بررسی رفتار خروجی، به [اندازه صفحه یادداشت‌ها](/slides/fa/python-net/notes-size/) مراجعه کنید.

## **حذف یادداشت‌ها از یک اسلاید**
یادداشت‌ها از یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده‌اند حذف شوند:

```py
import aspose.slides as slides

# یک شی Presentation ایجاد کنید که یک فایل ارائه را نشان می‌دهد 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # حذف یادداشت‌های اسلاید اول
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # ذخیره ارائه بر روی دیسک
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **حذف یادداشت‌ها از تمام اسلایدها**
یادداشت‌ها از تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده‌اند حذف شوند:

```py
import aspose.slides as slides

# یک شی Presentation ایجاد کنید که یک فایل ارائه را نمایندگی می‌کند 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # حذف یادداشت‌های تمام اسلایدها
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # ذخیره ارائه بر روی دیسک
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **اعمال استایل به یادداشت‌ها**
خاصیت [notes_style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslide/notes_style/) به کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslide/) اضافه شده است. این خاصیت استایل متن یادداشت‌ها را مشخص می‌کند. پیاده‌سازی آن در مثال زیر نشان داده شده است.

```py
import aspose.slides as slides

# یک شی Presentation ایجاد کنید که فایل ارائه را نمایندگی می‌کند
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # دریافت سبک متن MasterNotesSlide
        notesStyle = notesMaster.notes_style

        # تنظیم گلوله نماد برای پاراگراف‌های سطح اول
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # ذخیره فایل PPTX بر روی دیسک
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslidemanager/) و یک [خاصیت](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslidemanager/notes_slide/) است که شیء یادداشت را برمی‌گرداند، یا `None` اگر هیچ یادداشتی وجود نداشته باشد.

**آیا در پشتیبانی از یادداشت‌ها بین نسخه‌های مختلف PowerPoint که کتابخانه با آن‌ها کار می‌کند تفاوتی وجود دارد؟**

کتابخانه هدف‌گذاری بر روی دامنه گسترده‌ای از فرمت‌های Microsoft PowerPoint (97–جدیدتر) و ODP را دارد؛ یادداشت‌ها در این فرمت‌ها بدون وابستگی به یک نسخه نصب‌شدهٔ PowerPoint پشتیبانی می‌شوند.