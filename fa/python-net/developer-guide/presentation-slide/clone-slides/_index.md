---
title: "کلون اسلایدهای پاورپوینت در پایتون"
linktitle: "کلون اسلایدها"
type: docs
weight: 40
url: /fa/python-net/clone-slides/
keywords:
- "کلون اسلاید"
- "کپی اسلاید"
- "ذخیره اسلاید"
- "پاورپوینت"
- "ارائه"
- "پایتون"
- "Aspose.Slides"
description: "به سرعت اسلایدهای PowerPoint را با Aspose.Slides برای Python از طریق .NET کلون یا تکرار کنید. مثال‌های کد واضح و نکات ما را دنبال کنید تا ایجاد PPT را در ثانیه‌ها خودکار کنید، بهره‌وری را ارتقا دهید و کارهای دستی را حذف کنید."
---
## **مقدمه**

کلونینگ فرایند ایجاد یک کپی دقیق یا نسخه‌ای مشابه از چیزی است. Aspose.Slides همچنین به شما امکان می‌دهد هر اسلایدی را کپی (کلون) کنید و سپس اسلاید کلون‌شده را در ارائهٔ فعلی یا هر ارائهٔ باز دیگری وارد کنید. کلونینگ اسلاید یک اسلاید جدید ایجاد می‌کند که توسعه‌دهندگان می‌توانند بدون تأثیر بر اسلاید اصلی آن را تغییر دهند. روش‌های متعددی برای کلون کردن یک اسلاید وجود دارد:

- کلون کردن در انتهای یک ارائه.
- کلون کردن در موقعیت دیگری درون یک ارائه.
- کلون کردن در انتهای یک ارائهٔ دیگر.
- کلون کردن در موقعیت دیگری در یک ارائهٔ دیگر.
- کلون کردن در موقعیت خاصی در یک ارائهٔ دیگر.

در Aspose.Slides for Python via .NET، [slide collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ارائه می‌شود، متدهای `add_clone` و `insert_clone` را برای انجام این انواع کلون‌سازی اسلاید فراهم می‌کند.

## **کلون در انتهای همان ارائه**

اگر می‌خواهید یک اسلاید را در همان ارائه کلون کنید و آن را به انتهای اسلایدهای موجود اضافه کنید، از متد `add_clone` استفاده کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مجموعه اسلایدها را از شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید.
1. `add_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) صدا بزنید و اسلایدی که می‌خواهید کلون کنید را پاس بدهید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

در مثال زیر، اولین اسلاید (اندیس 0) کلون شده و به انتهای ارائه اضافه می‌شود.

```py
import aspose.slides as slides

# نمونه‌ای از کلاس Presentation برای نمایندگی فایل ارائه.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # اسلاید مورد نظر را به انتهای مجموعه اسلایدها در همان ارائه کلون کنید.
    presentation.slides.add_clone(presentation.slides[0])
    # ارائهٔ تغییر یافته را روی دیسک ذخیره کنید.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون به موقعیت خاصی در همان ارائه**

اگر می‌خواهید یک اسلاید را در همان ارائه کلون کنید و آن را در موقعیت متفاوتی قرار دهید، از متد `insert_clone` استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مجموعه اسلایدها را از شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید.
1. `insert_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) صدا بزنید و اسلایدی که می‌خواهید کلون کنید و ایندکس هدف برای موقعیت جدید آن را پاس بدهید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

در مثال زیر، اسلاید با اندیس 0 (موقعیت 1) به اندیس 1 (موقعیت 2) در همان ارائه کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائه ایجاد کنید.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # اسلاید موردنظر را به موقعیت (اندیس) مشخص شده در همان ارائه کلون کنید.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # ارائهٔ تغییر یافته را روی دیسک ذخیره کنید.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در انتهای یک ارائهٔ دیگر**

اگر نیاز دارید اسلایدی را از یک ارائه کلون کنید و به انتهای ارائهٔ دیگری اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ منبع (ارائه‌ای که اسلایدی برای کلون دارد) ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ مقصد (جایی که اسلاید اضافه خواهد شد) ایجاد کنید.
1. مجموعه اسلایدها را از ارائهٔ مقصد دریافت کنید.
1. `add_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید از ارائهٔ منبع را پاس بدهید.
1. ارائهٔ مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلاید با اندیس 0 در ارائهٔ منبع به انتهای ارائهٔ مقصد کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائهٔ منبع ایجاد کنید.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید کلون می‌شود) ایجاد کنید.
    with slides.Presentation() as target_presentation:
        # اسلاید موردنظر را از ارائهٔ منبع به انتهای مجموعه اسلایدها در ارائهٔ مقصد کلون کنید.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # ارائهٔ مقصد را روی دیسک ذخیره کنید.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون به موقعیت خاصی در یک ارائهٔ دیگر**

اگر نیاز دارید اسلایدی را از یک ارائه کلون کنید و در یک ارائهٔ دیگر در موقعیت خاصی وارد کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ منبع (ارائه‌ای که اسلایدی برای کلون دارد) ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ مقصد (جایی که اسلاید اضافه خواهد شد) ایجاد کنید.
1. مجموعه اسلایدها را از ارائهٔ مقصد دریافت کنید.
1. `insert_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید از ارائهٔ منبع و ایندکس هدف مورد نظر را پاس بدهید.
1. ارائهٔ مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلاید با اندیس 0 در ارائهٔ منبع به اندیس 1 (موقعیت 2) در ارائهٔ مقصد کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائهٔ منبع ایجاد کنید.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید کلون می‌شود) ایجاد کنید.
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # یک کلون از اولین اسلاید منبع را در ایندکس ۲ از ارائهٔ مقصد وارد کنید.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # ارائهٔ مقصد را روی دیسک ذخیره کنید.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون یک اسلاید همراه با اسلاید مستر آن در یک ارائهٔ دیگر**

اگر نیاز دارید یک اسلاید **همراه با مستر آن** را از یک ارائه کلون کنید و در ارائهٔ دیگری استفاده کنید، ابتدا اسلاید مستر مورد نیاز را از ارائهٔ منبع به ارائهٔ مقصد کلون کنید. سپس هنگام کلون کردن اسلاید، از مستر مقصد استفاده کنید. متد `add_clone(Slide, MasterSlide)` انتظار دارد **اسلاید مستر از ارائهٔ مقصد** باشد، نه از منبع.

برای کلون یک اسلاید همراه با مستر آن، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ منبع (ارائه‌ای که اسلایدی برای کلون دارد) ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ مقصد ایجاد کنید.
1. به اسلاید منبعی که می‌خواهید کلون کنید و مستر آن دسترسی پیدا کنید.
1. [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) را از مجموعه مسترهای ارائهٔ مقصد دریافت کنید.
1. `add_clone` را بر روی [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) مقصد صدا بزنید و مستر منبع را برای کلون به مقصد پاس بدهید.
1. [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) را از مجموعه اسلایدهای ارائهٔ مقصد دریافت کنید.
1. `add_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید منبع و مستر کلون‌شده مقصد را پاس بدهید.
1. ارائهٔ مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلاید با اندیس 0 در ارائهٔ منبع به انتهای ارائهٔ مقصد کلون می‌شود با استفاده از مستر کلون‌شده از منبع.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائهٔ منبع ایجاد کنید.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای ارائهٔ مقصد که اسلاید در آن کلون می‌شود ایجاد کنید.
    with slides.Presentation() as target_presentation:
        # اولین اسلاید را از ارائهٔ منبع دریافت کنید.
        source_slide = source_presentation.slides[0]
        # اسلاید مستر استفاده شده توسط اولین اسلاید را دریافت کنید.
        source_master = source_slide.layout_slide.master_slide
        # اسلاید مستر را به مجموعهٔ مسترهای ارائهٔ مقصد کلون کنید.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # اسلاید را از ارائهٔ منبع به انتهای ارائهٔ مقصد با استفاده از مستر کلون‌شده کلون کنید.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # ارائهٔ مقصد را روی دیسک ذخیره کنید.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در انتها در یک بخش مشخص**

با Aspose.Slides for Python via .NET، می‌توانید یک اسلاید را از یک بخش از ارائه کلون کنید و آن را به بخش دیگری در همان ارائه وارد کنید. برای این کار، از متد `add_clone(Slide, Section)` در کلاس [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) استفاده کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه یک اسلاید را کلون کنید و کلون را در یک بخش مشخص وارد کنید:

```py
import aspose.slides as slides

# یک ارائه خالی جدید ایجاد کنید.
with slides.Presentation() as presentation:
    # یک اسلاید خالی بر پایهٔ چیدمان اولین اسلاید اضافه کنید.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # یک شکل بیضی به اسلاید جدید اضافه کنید؛ این اسلاید بعدها کلون خواهد شد.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # یک اسلاید خالی دیگر بر پایهٔ چیدمان اولین اسلاید اضافه کنید.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # بخشی با نام "Section2" که از slide2 شروع می‌شود ایجاد کنید.
    section = presentation.sections.add_section("Section2", slide2)
    # اسلاید ایجاد شده قبلی را به بخش "Section2" کلون کنید.
    presentation.slides.add_clone(slide, section)
    # ارائه را به صورت فایل PPTX ذخیره کنید.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا یادداشت‌های سخنران و نظرات بازبینی‌کننده کلون می‌شوند؟**

بله. صفحه یادداشت‌ها و نظرات بازبینی در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، پس از درج، [آنها را حذف کنید](/slides/fa/python-net/presentation-notes/).

**چگونه نمودارها و منابع دادهٔ آنها مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های توکار کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کتاب‌کار توکار OLE) لینک شده بود، آن لینک به عنوان یک [OLE object](/slides/fa/python-net/manage-ole/) حفظ می‌شود. پس از جابجایی بین فایل‌ها، در دسترس بودن داده‌ها و رفتار به‌روزرسانی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در ایندکس اسلاید خاصی درج کنید و آن را در یک [section](/slides/fa/python-net/slide-section/) انتخابی قرار دهید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.