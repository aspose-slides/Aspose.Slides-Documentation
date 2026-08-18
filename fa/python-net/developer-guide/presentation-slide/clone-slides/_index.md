---
title: کلون اسلایدهای پاورپوینت در پایتون
linktitle: کلون اسلایدها
type: docs
weight: 40
url: /fa/python-net/clone-slides/
keywords:
- کلون اسلاید
- کپی اسلاید
- ذخیره اسلاید
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "به سرعت اسلایدهای پاورپوینت را با Aspose.Slides برای پایتون از طریق .NET کلون یا تکرار کنید. مثال‌های کد واضح و نکات ما را دنبال کنید تا به‌صورت خودکار در ثانیه‌ها ارائه PPT را ایجاد کنید، بهره‌وری را افزایش دهید و کار دستی را حذف کنید."
---
## **معرفی**

کلونینگ فرآیند ساخت یک کپی دقیق یا مشابه از چیزی است. Aspose.Slides همچنین به شما امکان می‌دهد هر اسلایدی را کپی (کلون) کنید و سپس اسلاید کلون شده را به ارائهٔ فعلی یا هر ارائهٔ باز دیگری وارد کنید. کلون کردن اسلاید یک اسلاید جدید ایجاد می‌کند که توسعه‌دهندگان می‌توانند آن را بدون تأثیر بر اسلاید اصلی تغییر دهند. چندین روش برای کلون کردن اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری داخل یک ارائه.
- کلون در انتهای یک ارائه دیگر.
- کلون در موقعیت دیگری در یک ارائه دیگر.
- کلون در موقعیت مشخصی در یک ارائه دیگر.

در Aspose.Slides برای Python از طریق .NET، [مجموعه اسلایدها](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) فراهم می‌شود، متدهای `add_clone` و `insert_clone` را برای انجام این انواع کلون اسلاید ارائه می‌دهد.

## **نصب**

```bash
pip install aspose.slides
```

## **کلون در انتهای همان ارائه**

اگر می‌خواهید یک اسلاید را در همان ارائه کلون کنید و آن را به انتهای اسلایدهای موجود اضافه کنید، از متد `add_clone` استفاده کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مجموعه اسلایدها را از شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید.
1. متد `add_clone` را روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) صدا بزنید و اسلایدی که باید کلون شود را به عنوان آرگومان پاس کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

در مثال زیر، اسلاید اول (اندیس 0) کلون شده و به انتهای ارائه اضافه می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائه ایجاد کنید.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # اسلاید موردنظر را به انتهای مجموعه اسلایدها در همان ارائه کلون کنید.
    presentation.slides.add_clone(presentation.slides[0])
    # ارائهٔ تغییر یافته را روی دیسک ذخیره کنید.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون به موقعیت مشخصی در همان ارائه**

اگر می‌خواهید یک اسلاید را در همان ارائه کلون کنید و آن را در موقعیتی دیگر قرار دهید، از متد `insert_clone` استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مجموعه اسلایدها را از شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید.
1. متد `insert_clone` را روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) صدا بزنید و اسلایدی که باید کلون شود و اندیس هدف برای موقعیت جدید آن را پاس کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

در مثال زیر، اسلایدی با اندیس 1 (موقعیت 2) به اندیس 2 (موقعیت 3) در همان ارائه کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائه ایجاد کنید.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # اسلاید موردنظر را به موقعیت مشخص‌شده (اندیس) در همان ارائه کلون کنید.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # ارائهٔ تغییر یافته را روی دیسک ذخیره کنید.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در انتهای ارائهٔ دیگر**

اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و به انتهای ارائهٔ دیگری اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ منبع (ارائه‌ای که اسلاید را در بر دارد) ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ مقصد (جایی که اسلاید افزوده می‌شود) ایجاد کنید.
1. مجموعه اسلایدها را از ارائهٔ مقصد دریافت کنید.
1. `add_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید را از ارائهٔ منبع پاس کنید.
1. ارائهٔ مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلایدی با اندیس 0 در ارائهٔ منبع به انتهای ارائهٔ مقصد کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائه منبع ایجاد کنید.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید کلون می‌شود) ایجاد کنید.
    with slides.Presentation() as target_presentation:
        # اسلاید موردنظر را از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد کلون کنید.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # ارائهٔ مقصد را روی دیسک ذخیره کنید.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون به موقعیت مشخصی در ارائهٔ دیگر**

اگر نیاز دارید یک اسلاید را از یک ارائه کلون کنید و آن را در موقعیت خاصی از ارائهٔ دیگری وارد کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ منبع ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ مقصد ایجاد کنید.
1. مجموعه اسلایدها را از ارائهٔ مقصد دریافت کنید.
1. متد `insert_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید را از ارائهٔ منبع همراه با اندیس هدف مورد نظر پاس کنید.
1. ارائهٔ مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلایدی با اندیس 0 در ارائهٔ منبع به اندیس 2 (موقعیت 3) در ارائهٔ مقصد کلون می‌شود.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائه منبع ایجاد کنید.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید کلون می‌شود) ایجاد کنید.
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # یک کلون از اولین اسلاید منبع را در اندیس 2 در ارائه مقصد وارد کنید.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # ارائهٔ مقصد را روی دیسک ذخیره کنید.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون یک اسلاید به همراه اسلاید مستر آن در ارائهٔ دیگر**

اگر نیاز دارید اسلایدی **به همراه مستر آن** را از یک ارائه کلون کنید و در ارائهٔ دیگری استفاده کنید، ابتدا مستر اسلاید مورد نیاز را از ارائهٔ منبع به ارائهٔ مقصد کلون کنید. سپس هنگام کلون اسلاید از آن مستر مقصد استفاده کنید. متد `add_clone(Slide, MasterSlide)` انتظار دارد **اسلاید مستر از ارائهٔ مقصد** باشد، نه از منبع.

برای کلون اسلاید به همراه مسترش، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ منبع ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائهٔ مقصد ایجاد کنید.
1. به اسلاید منبعی که می‌خواهید کلون کنید و مستر آن دسترسی پیدا کنید.
1. [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) را از مجموعهٔ مسترهای ارائهٔ مقصد دریافت کنید.
1. `add_clone` را بر روی [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) مقصد صدا بزنید و مستر منبع را برای کلون به مقصد پاس کنید.
1. [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) را از مجموعهٔ اسلایدهای ارائهٔ مقصد دریافت کنید.
1. `add_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا بزنید و اسلاید منبع را به همراه مستر کلون شدهٔ مقصد پاس کنید.
1. ارائهٔ مقصد تغییر یافته را ذخیره کنید.

در مثال زیر، اسلایدی با اندیس 0 در ارائهٔ منبع به انتهای ارائهٔ مقصد کلون می‌شود؛ مستر اسلاید نیز از منبع به مقصد کلون شده است.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation برای نمایندگی فایل ارائه منبع ایجاد کنید.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # یک نمونه از کلاس Presentation برای ارائه مقصد که اسلاید در آن کلون می‌شود ایجاد کنید.
    with slides.Presentation() as target_presentation:
        # اولین اسلاید را از ارائه منبع دریافت کنید.
        source_slide = source_presentation.slides[0]
        # مستر اسلایدی که توسط اولین اسلاید استفاده می‌شود را دریافت کنید.
        source_master = source_slide.layout_slide.master_slide
        # مستر اسلاید را به مجموعه مسترهای ارائه مقصد کلون کنید.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # اسلاید را از ارائه منبع به انتهای ارائه مقصد کلون کنید، با استفاده از مستر کلون شده.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # ارائهٔ مقصد را روی دیسک ذخیره کنید.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در انتها در یک بخش مشخص**

با Aspose.Slides برای Python از طریق .NET می‌توانید یک اسلاید را از یک بخش ارائه کلون کنید و آن را در بخش دیگری از همان ارائه وارد کنید. برای این کار، از متد `add_clone(Slide, Section)` کلاس [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) استفاده کنید.

مثال زیر در پایتون نشان می‌دهد چگونه یک اسلاید را کلون کرده و کلون را در بخش مشخصی وارد می‌کنید:

```py
import aspose.slides as slides

# یک ارائهٔ خالی جدید ایجاد کنید.
with slides.Presentation() as presentation:
    # یک اسلاید خالی بر اساس طرح‌بندی اولین اسلاید اضافه کنید.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # یک شکل بیضی به اسلاید جدید اضافه کنید؛ این اسلاید بعداً کلون خواهد شد.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # یک اسلاید خالی دیگر بر اساس طرح‌بندی اولین اسلاید اضافه کنید.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # یک بخش به نام "Section2" ایجاد کنید که از slide2 شروع می‌شود.
    section = presentation.sections.add_section("Section2", slide2)
    # اسلاید ایجاد شده قبلی را در بخش "Section2" کلون کنید.
    presentation.slides.add_clone(slide, section)
    # ارائه را به صورت فایل PPTX ذخیره کنید.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **اطمینان از سازگاری اندازه اسلاید**

هنگام کلون اسلایدها به ارائهٔ دیگر، مطمئن شوید اندازهٔ اسلاید ارائهٔ مقصد با ارائهٔ منبع یکسان باشد. اگر اندازه‌ها متفاوت باشند، Aspose.Slides به‌صورت خودکار مقیاس اشکال کلون شده را تغییر نمی‌دهد؛ مختصات و ابعاد اصلی حفظ می‌شوند که ممکن است محتوا به‌نظر ناهماهنگ برسد یا از مرزهای اسلاید فراتر رود.

می‌توانید قبل از کلون مستر و اسلاید، اندازهٔ اسلاید ارائهٔ مقصد را با منبع برابر کنید:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

این کار را پیش از کلون مستر و اسلاید انجام دهید.

## **سوالات متداول**

**آیا یادداشت‌های گوینده و نظرات مرورگر کلون می‌شوند؟**

بله. صفحهٔ یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها را داشته باشید، پس از درج [حذف آن‌ها](/slides/fa/python-net/presentation-notes/) کنید.

**چگونه نمودارها و منبع داده‌های آنها مدیریت می‌شوند؟**

شیء نمودار، قالب‌بندی و داده‌های توکار کپی می‌شوند. اگر نمودار به منبع خارجی (مثلاً یک کارپوشهٔ OLE-توکار) لینک داشت، آن لینک به عنوان یک [شیء OLE](/slides/fa/python-net/manage-ole/) حفظ می‌شود. پس از انتقال بین فایل‌ها، در دسترس بودن داده‌ها و رفتار تازه‌سازی را بررسی کنید.

**آیا می‌توانم موقعیت درج و بخش‌های کلون را کنترل کنم؟**

بله. می‌توانید کلون را در اندیس اسلاید خاصی درج کنید و آن را به یک [بخش](/slides/fa/python-net/slide-section/) انتخابی منتقل کنید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آنجا منتقل کنید.