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
- سبک یادداشت
- یادداشت‌های اصلی
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای پایتون عبر .NET سفارشی کنید. به سادگی با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **مرور کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت از یک ارائه را پشتیبانی می‌کند. در این مقاله، این ویژگی را معرفی می‌کنیم، از جمله نحوه حذف یادداشت‌ها و نحوه اعمال یک سبک بر اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلایدی حذف کنید و همچنین به یادداشت‌های موجود استایل اعمال کنید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداد‌ها از تمام اسلایدهای یک ارائه.

## **حذف یادداشت‌ها از اسلاید**
یادداشت‌های یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```py
import aspose.slides as slides

# یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # حذف یادداشت‌های اسلاید اول
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # ذخیره ارائه در دیسک
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```


## **حذف یادداشت‌ها از تمام اسلایدها**
یادداشت‌های تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است حذف شوند:

```py
import aspose.slides as slides

# یک شی Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # حذف یادداشت‌های تمام اسلایدها
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # ذخیره ارائه در دیسک
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```


## **افزودن NotesStyle**
خصوصیت [notes_style](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslide/notes_style/) به کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masternotesslide/) اضافه شده است. این خصوصیت سبک متن یادداشت را مشخص می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```py
import aspose.slides as slides

# یک شی Presentation ایجاد می‌کند که نمایانگر فایل ارائه است
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # دریافت سبک متن MasterNotesSlide
        notesStyle = notesMaster.notes_style

        #Set نماد گلوله برای پاراگراف‌های سطح اول
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # ذخیره فایل PPTX در دیسک
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslidemanager/) و یک [property](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notesslidemanager/notes_slide/) است که شیء یادداشت را برمی‌گرداند یا `None` اگر یادداشتی وجود نداشته باشد.

**آیا در پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند تفاوتی وجود دارد؟**

این کتابخانه بر طیف گسترده‌ای از فرمت‌های Microsoft PowerPoint (97–newer) و ODP هدف‌گذاری شده است؛ یادداشت‌ها در این فرمت‌ها پشتیبانی می‌شوند بدون اینکه نیاز به نصب نسخه‌ای از PowerPoint داشته باشد.