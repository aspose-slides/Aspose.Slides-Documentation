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
description: "به سرعت اسلایدهای پاورپوینت را با Aspose.Slides برای پایتون از طریق .NET کلون یا تکثیر کنید. مثال‌های کد واضح و نکات ما را دنبال کنید تا ایجاد PPT را در ثانیه‌ها خودکار کنید، بهره‌وری را افزایش دهید و کارهای دستی را حذف کنید."
---
## **معرفی**

کلونینگ فرایند ساخت یک نسخهٔ دقیق یا مشابه از چیزی است. Aspose.Slides همچنین به شما امکان می‌دهد هر اسلایدی را کپی (کلون) کنید و سپس اسلاید کلون‌شده را در ارائهٔ فعلی یا هر ارائهٔ باز دیگری وارد کنید. کلونینگ اسلاید یک اسلاید جدید ایجاد می‌کند که توسعه‌دهندگان می‌توانند بدون تأثیر بر اسلاید اصلی آن را ویرایش کنند. چندین روش برای کلون کردن یک اسلاید وجود دارد:

- کلون در انتهای یک ارائه.
- کلون در موقعیت دیگری درون یک ارائه.
- کلون در انتهای یک ارائهٔ دیگر.
- کلون در موقعیت دیگری در یک ارائهٔ دیگر.
- کلون در موقعیت مشخصی در یک ارائهٔ دیگر.

در Aspose.Slides برای Python از طریق .NET، [کلکسیون اسلاید](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) که توسط شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) عرضه می‌شود، روش‌های `add_clone` و `insert_clone` را برای انجام این انواع کلونینگ اسلاید فراهم می‌کند.

## **نصب**

```bash
pip install aspose.slides
```

## **کلون در انتهای همان ارائه**

اگر می‌خواهید یک اسلاید را درون همان ارائه کلون کنید و آن را به انتهای اسلایدهای موجود اضافه نمایید، از متد `add_clone` استفاده کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. کلکسیون اسلاید را از شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید.
1. متد `add_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) صدا کنید و اسلاید مورد نظر برای کلون کردن را پاس بدهید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

در مثال زیر، اولین اسلاید (شاخص 0) کلون شده و به انتهای ارائه اضافه می‌شود.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای نمایاندن فایل ارائه.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # کلون اسلاید مورد نظر به انتهای مجموعه اسلایدها در همان ارائه.
    presentation.slides.add_clone(presentation.slides[0])
    # ارائهٔ اصلاح‌شده را بر روی دیسک ذخیره کنید.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در موقعیت خاص درون همان ارائه**

اگر می‌خواهید یک اسلاید را درون همان ارائه کلون کنید و آن را در موقعیتی متفاوت قرار دهید، از متد `insert_clone` استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. کلکسیون اسلاید را از شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید.
1. متد `insert_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) صدا کنید و اسلاید مورد نظر برای کلون کردن و شاخص هدف برای موقعیت جدید آن را پاس بدهید.
1. ارائهٔ اصلاح‌شده را ذخیره کنید.

در مثال زیر، اسلایدی با شاخص 1 (موقعیت 2) به شاخص 2 (موقعیت 3) درون همان ارائه کلون می‌شود.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای نمایاندن فایل ارائه.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # کلون اسلاید مورد نظر به موقعیت مشخص (اندیس) در همان ارائه.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # ارائهٔ اصلاح‌شده را بر روی دیسک ذخیره کنید.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در انتهای ارائهٔ دیگر**

اگر نیاز دارید اسلایدی را از یک ارائه کلون کرده و به انتهای ارائهٔ دیگری اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه منبع (آنکه اسلاید را در خود دارد) ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه مقصد (جایی که اسلاید به آن اضافه می‌شود) ایجاد کنید.
1. کلکسیون اسلاید را از ارائه مقصد دریافت کنید.
1. `add_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا کنید و اسلاید از ارائه منبع را پاس بدهید.
1. ارائه مقصد اصلاح‌شده را ذخیره کنید.

در مثال زیر، اسلایدی با شاخص 0 در ارائه منبع به انتهای ارائه مقصد کلون می‌شود.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای نمایاندن فایل ارائه منبع.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # نمونه‌سازی کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید کلون می‌شود).
    with slides.Presentation() as target_presentation:
        # کلون اسلاید مورد نظر از ارائه منبع به انتهای مجموعه اسلایدها در ارائه مقصد.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # ارائهٔ مقصد را بر روی دیسک ذخیره کنید.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در موقعیت خاص در یک ارائهٔ دیگر**

اگر نیاز دارید اسلایدی را از یک ارائه کلون کرده و آن را در موقعیت خاصی در ارائهٔ دیگری درج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه منبع (آنکه اسلاید را در خود دارد) ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه مقصد (جایی که اسلاید به آن اضافه می‌شود) ایجاد کنید.
1. کلکسیون اسلاید را از ارائه مقصد دریافت کنید.
1. متد `insert_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا کنید و اسلاید از ارائه منبع و شاخص هدف مورد نظر را پاس بدهید.
1. ارائه مقصد اصلاح‌شده را ذخیره کنید.

در مثال زیر، اسلایدی با شاخص 0 در ارائه منبع به شاخص 2 (موقعیت 3) در ارائه مقصد کلون می‌شود.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای نمایاندن فایل ارائه منبع.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # نمونه‌سازی کلاس Presentation برای فایل PPTX مقصد (جایی که اسلاید کلون می‌شود).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # درج یک کلون از اولین اسلاید منبع در اندیس 2 در ارائه مقصد.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # ارائهٔ مقصد را بر روی دیسک ذخیره کنید.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون یک اسلاید همراه با اسلاید اصلی آن به یک ارائهٔ دیگر**

اگر نیاز دارید یک اسلاید **با اسلاید اصلی خود** را از یک ارائه کلون کرده و در ارائه‌ای دیگر استفاده کنید، ابتدا اسلاید اصلی مورد نیاز را از ارائه منبع به ارائه مقصد کلون کنید. سپس هنگام کلون کردن اسلاید، از آن اسلاید اصلی مقصد استفاده کنید. متد `add_clone(Slide, MasterSlide)` یک **اسلاید اصلی از ارائه مقصد** را انتظار دارد، نه از منبع.

برای کلون یک اسلاید همراه با اسلاید اصلی، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه منبع ایجاد کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای ارائه مقصد ایجاد کنید.
1. به اسلاید منبعی که می‌خواهید کلون کنید و اسلاید اصلی آن دسترسی پیدا کنید.
1. [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) را از کلکسیون اسلایدهای اصلی ارائه مقصد دریافت کنید.
1. `add_clone` را بر روی [MasterSlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslidecollection/) مقصد صدا کنید و اسلاید اصلی منبع را برای کلون به مقصد پاس بدهید.
1. [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) را از کلکسیون اسلایدهای ارائه مقصد دریافت کنید.
1. `add_clone` را بر روی [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مقصد صدا کنید و اسلاید منبع و اسلاید اصلی کلون‌شده مقصد را پاس بدهید.
1. ارائه مقصد اصلاح‌شده را ذخیره کنید.

در مثال زیر، اسلایدی با شاخص 0 در ارائه منبع به انتهای ارائه مقصد کلون می‌شود به‌طوری که اسلاید اصلی کلون‌شده از منبع استفاده می‌شود.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation برای نمایاندن فایل ارائه منبع.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # نمونه‌سازی کلاس Presentation برای ارائه مقصد که اسلاید در آن کلون خواهد شد.
    with slides.Presentation() as target_presentation:
        # دریافت اولین اسلاید از ارائه منبع.
        source_slide = source_presentation.slides[0]
        # دریافت اسلاید اصلی که توسط اولین اسلاید استفاده می‌شود.
        source_master = source_slide.layout_slide.master_slide
        # کلون اسلاید اصلی به مجموعه اسلایدهای اصلی ارائه مقصد.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # کلون اسلاید از ارائه منبع به انتهای ارائه مقصد با استفاده از اسلاید اصلی کلون‌شده.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # ذخیرهٔ ارائه مقصد بر روی دیسک.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون در انتها در یک بخش مشخص**

با Aspose.Slides برای Python از طریق .NET، می‌توانید اسلایدی را از یک بخش از یک ارائه کلون کنید و آن را در بخش دیگری از همان ارائه وارد کنید. برای این کار، از متد `add_clone(Slide, Section)` کلاس [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) استفاده کنید.

مثال زیر در زبان Python نشان می‌دهد چگونه یک اسلاید را کلون کرده و کلون را در یک بخش مشخص وارد کنید:

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
    # بخشی به نام "Section2" ایجاد کنید که از slide2 شروع می‌شود.
    section = presentation.sections.add_section("Section2", slide2)
    # اسلاید قبلاً ایجادشده را به بخش "Section2" کلون کنید.
    presentation.slides.add_clone(slide, section)
    # ارائه را به‌صورت فایل PPTX ذخیره کنید.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **اطمینان از هماهنگی اندازه اسلاید**

هنگام کلون کردن اسلایدها به ارائه‌ای دیگر، مطمئن شوید که ارائه مقصد همان اندازه اسلاید را دارد که در منبع وجود دارد. اگر اندازه اسلایدها متفاوت باشد، Aspose.Slides به‌صورت خودکار شکل‌های کلون‌شده را مقیاس‌بندی نمی‌کند—مختصات و ابعاد اصلی آن‌ها حفظ می‌شود که ممکن است باعث شود محتوا نامرتب شود یا از مرزهای اسلاید فراتر رود.

می‌توانید قبل از کلون کردن اسلاید اصلی و اسلاید، اندازه اسلاید ارائه مقصد را برابر با منبع تنظیم کنید:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

این کار را پیش از کلون کردن اسلاید اصلی و اسلاید انجام دهید.

## **سوالات متداول**

### آیا یادداشت‌های گوینده و نظرات مرورگر کلون می‌شوند؟

بله. صفحهٔ یادداشت‌ها و نظرات مرورگر در کلون گنجانده می‌شوند. اگر نمی‌خواهید آنها، [حذف آن‌ها](/slides/fa/python-net/presentation-notes/) پس از درج کنید.

### نمودارها و منبع داده‌های آن‌ها چگونه مدیریت می‌شوند؟

شی نمودار، قالب‌بندی و داده‌های توکار کپی می‌شوند. اگر نمودار به منبع خارجی (برای مثال، یک کتاب‌کاری OLE‑embedded) متصل بود، این ارتباط به‌عنوان یک [شی OLE](/slides/fa/python-net/manage-ole/) حفظ می‌شود. پس از جابجایی بین فایل‌ها، در دسترس بودن داده‌ها و رفتار به‌روزرسانی را بررسی کنید.

### آیا می‌توانم موقعیت درج و بخش‌ها را برای کلون کنترل کنم؟

بله. می‌توانید کلون را در یک شاخص اسلاید خاص درج کنید و آن را در یک [بخش](/slides/fa/python-net/slide-section/) انتخابی قرار دهید. اگر بخش هدف وجود نداشته باشد، ابتدا آن را ایجاد کنید و سپس اسلاید را به آن منتقل کنید.
