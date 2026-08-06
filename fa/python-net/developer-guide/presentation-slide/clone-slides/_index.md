---
title: کلون‌کردن اسلایدهای PowerPoint در Python
linktitle: کلون اسلایدها
type: docs
weight: 40
url: /fa/python-net/clone-slides/
keywords:
- کلون اسلاید
- کپی اسلاید
- ذخیره اسلاید
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "اسلایدهای PowerPoint را به سرعت با Aspose.Slides برای Python via .NET کلون یا تکثیر کنید. نمونه‌های کد واضح و نکات ما را دنبال کنید تا ایجاد PPT را در ثانیه‌ها خودکار کنید، بهره‌وری را ارتقا دهید و کارهای دستی را حذف کنید."
---
## **مقدمه**

کلونینگ فرآیندی است که در آن نسخه دقیق یا تکثیری از شیئی ساخته می‌شود. Aspose.Slides همچنین امکان کپی (کلون) هر اسلاید را فراهم می‌کند و سپس اسلاید کلون‑شده را در ارائه جاری یا هر ارائه باز دیگری درج می‌نماید. کلون کردن اسلاید یک اسلاید جدید ایجاد می‌کند که توسعه‌دهندگان می‌توانند بدون تأثیر بر اسلاید اصلی آن را ویرایش کنند. روش‌های مختلفی برای کلون کردن اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری درون یک ارائه.
- کلون در انتهای یک ارائه دیگر.
- کلون در موقعیت دیگری در یک ارائه دیگر.
- کلون در موقعیت مشخصی در یک ارائه دیگر.

در Aspose.Slides برای Python via .NET، [مجموعه اسلایدها](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) ارائه‌شده توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) متدهای `add_clone` و `insert_clone` را برای انجام این انواع کلون کردن اسلاید فراهم می‌کند.

## **نصب**

```bash
pip install aspose.slides
```

## **کلون در انتهای همان ارائه**

اگر می‌خواهید اسلایدی را در همان ارائه کلون کنید و به انتهای اسلایدهای موجود اضافه کنید، از متد `add_clone` استفاده کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مجموعه اسلایدها را از شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید.
1. متد `add_clone` را روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) صدا بزنید و اسلایدی که باید کلون شود را به عنوان پارامتر پاس کنید.
1. ارائه‌ تغییر یافته را ذخیره کنید.

در مثال زیر، اسلاید اول (اندیس ۰) کلون شده و به انتهای ارائه اضافه می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند تا فایل ارائه را نمایندگی کند.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # اسلاید موردنظر را به انتهای مجموعه اسلایدها در همان ارائه کلون می‌کند.
    presentation.slides.add_clone(presentation.slides[0])
    # ارائه تغییر یافته را بر روی دیسک ذخیره می‌کند.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در موقعیت مشخصی درون همان ارائه**

اگر می‌خواهید اسلایدی را در همان ارائه کلون کنید و به موقعیتی دیگر قرار دهید، از متد `insert_clone` استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مجموعه اسلایدها را از شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید.
1. متد `insert_clone` را روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) صدا بزنید و اسلایدی که باید کلون شود و اندیس هدف برای موقعیت جدید آن را به عنوان پارامترها پاس کنید.
1. ارائه‌ تغییر یافته را ذخیره کنید.

در مثال زیر، اسلایدی که در اندیس ۱ (موقعیت ۲) قرار دارد به اندیس ۲ (موقعیت ۳) درون همان ارائه کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند تا فایل ارائه را نمایندگی کند.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # اسلاید موردنظر را به موقعیت (اندیس) مشخص‌شده در همان ارائه کلون می‌کند.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # ارائه تغییر یافته را بر روی دیسک ذخیره می‌کند.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در انتهای یک ارائه دیگر**

اگر نیاز دارید اسلایدی را از یک ارائه گرفته و به انتهای ارائه دیگری اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه منبع (که اسلاید مورد نظر در آن است) ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه مقصد (جایی که اسلاید به آن اضافه می‌شود) ایجاد کنید.
1. مجموعه اسلایدها را از ارائه مقصد دریافت کنید.
1. متد `add_clone` را روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید منبع را پاس کنید.
1. ارائه مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلایدی که در اندیس ۰ در ارائه منبع است به انتهای ارائه مقصد کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند تا فایل ارائه منبع را نمایندگی کند.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید کلون می‌شود) ایجاد می‌کند.
    with slides.Presentation() as target_presentation:
        # اسلاید موردنظر را از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد کلون می‌کند.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # ارائه مقصد را بر روی دیسک ذخیره می‌کند.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در موقعیت مشخصی در یک ارائه دیگر**

اگر نیاز دارید اسلایدی را از یک ارائه گرفته و در موقعیت خاصی از ارائه دیگری درج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه منبع ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه مقصد ایجاد کنید.
1. مجموعه اسلایدها را از ارائه مقصد دریافت کنید.
1. متد `insert_clone` را روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید منبع و اندیس هدف مورد نظر را پاس کنید.
1. ارائه مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلایدی که در اندیس ۰ در ارائه منبع است به اندیس ۲ (موقعیت ۳) در ارائه مقصد کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند تا فایل ارائه منبع را نمایندگی کند.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید کلون می‌شود) ایجاد می‌کند.
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # یک کلون از اولین اسلاید منبع را در اندیس ۲ در ارائه مقصد وارد می‌کند.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # ارائه مقصد را بر روی دیسک ذخیره می‌کند.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون یک اسلاید به همراه اسلاید اصلی‌اش در یک ارائه دیگر**

اگر نیاز دارید اسلایدی **به همراه اسلاید اصلی‌اش** را از یک ارائه گرفته و در ارائه دیگری استفاده کنید، ابتدا اسلاید اصلی مورد نیاز را از ارائه منبع به ارائه مقصد کلون کنید. سپس هنگام کلون کردن اسلاید، از اسلاید اصلی مقصد استفاده کنید. متد `add_clone(Slide, MasterSlide)` انتظار دارد **اسلاید اصلی از ارائه مقصد** باشد، نه از منبع.

برای کلون کردن اسلاید به همراه اسلاید اصلی، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه منبع ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه مقصد ایجاد کنید.
1. به اسلاید منبعی که می‌خواهید کلون کنید و اسلاید اصلی‌اش دسترسی پیدا کنید.
1. [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) را از مجموعه اسلایدهای اصلی ارائه مقصد دریافت کنید.
1. `add_clone` را روی [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) مقصد صدا بزنید و اسلاید اصلی منبع را برای کلون به مقصد پاس کنید.
1. [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) را از مجموعه اسلایدهای ارائه مقصد دریافت کنید.
1. `add_clone` را روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید منبع و اسلاید اصلی کلون‌شده مقصد را پاس کنید.
1. ارائه مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلایدی که در اندیس ۰ در ارائه منبع است به انتهای ارائه مقصد کلون می‌شود؛ اسلاید اصلی نیز از منبع به مقصد کلون شده است.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد می‌کند تا فایل ارائه منبع را نمایندگی کند.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای ارائه مقصد که اسلاید در آن کلون می‌شود ایجاد می‌کند.
    with slides.Presentation() as target_presentation:
        # اولین اسلاید را از ارائه منبع دریافت می‌کند.
        source_slide = source_presentation.slides[0]
        # اسلاید اصلی استفاده‌شده توسط اولین اسلاید را دریافت می‌کند.
        source_master = source_slide.layout_slide.master_slide
        # اسلاید اصلی را به مجموعه اسلایدهای اصلی ارائه مقصد کلون می‌کند.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # اسلاید را از ارائه منبع به انتهای ارائه مقصد کلون می‌کند؛ با استفاده از اسلاید اصلی کلون‌شده.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # ارائه مقصد را بر روی دیسک ذخیره می‌کند.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در انتها در یک بخش مشخص**

با Aspose.Slides برای Python via .NET می‌توانید اسلایدی را از یک بخش از ارائه گرفته و در بخش دیگری از همان ارائه درج کنید. برای این کار، از متد `add_clone(Slide, Section)` کلاس [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) استفاده کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه اسلایدی را کلون کرده و کلون را در بخشی مشخص درج کنید:

```py
import aspose.slides as slides

# یک ارائه خالی جدید ایجاد می‌کند.
with slides.Presentation() as presentation:
    # یک اسلاید خالی بر اساس قالب اولین اسلاید اضافه می‌کند.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # یک شکل بیضی به اسلاید جدید اضافه می‌کند؛ این اسلاید بعدها کلون خواهد شد.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # یک اسلاید خالی دیگر بر اساس قالب اولین اسلاید اضافه می‌کند.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # یک بخش به نام "Section2" ایجاد می‌کند که از slide2 شروع می‌شود.
    section = presentation.sections.add_section("Section2", slide2)
    # اسلاید ایجاد شده قبلی را در بخش "Section2" کلون می‌کند.
    presentation.slides.add_clone(slide, section)
    # ارائه را به عنوان فایل PPTX ذخیره می‌کند.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **سؤالات متداول**

### آیا یادداشت‌های سخنران و نظرات بازبینی نیز کلون می‌شوند؟

بله. صفحه یادداشت‌ها و نظرات بازبینی در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، پس از درج با [حذف آنها](/slides/fa/python-net/presentation-notes/) می‌توانید اقدام کنید.

### نمودارها و منابع داده‌ای آن‌ها چگونه مدیریت می‌شوند؟

شیء نمودار، قالب‌بندی و داده‌های درج‌شده کپی می‌شوند. اگر نمودار به یک منبع خارجی (مثلاً یک کتاب‌کار OLE) لینک شده باشد، آن لینک به‌صورت [شیء OLE](/slides/fa/python-net/manage-ole/) حفظ می‌شود. پس از جابه‌جایی بین فایل‌ها، در دسترس بودن داده‌ها و رفتار تازه‌سازی را بررسی کنید.

### آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟

بله. می‌توانید کلون را در اندیس اسلاید خاصی درج کنید و آن را به یک [بخش](/slides/fa/python-net/slide-section/) انتخابی منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.