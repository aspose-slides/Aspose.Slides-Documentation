---
title: افزودن اسلایدها به ارائه‌ها با پایتون
linktitle: افزودن اسلاید
type: docs
weight: 10
url: /fa/python-net/add-slide-to-presentation/
keywords:
- افزودن اسلاید
- ایجاد اسلاید
- اسلاید خالی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "به راحتی اسلایدها را به ارائه‌های PowerPoint و OpenDocument خود با استفاده از Aspose.Slides برای Python از طریق .NET اضافه کنید—درج اسلاید بی‌دردسر و کارآمد در چند ثانیه."
---
## **بررسی کلی**

قبل از افزودن اسلایدها به یک ارائه، درک نحوهٔ سازماندهی اسلایدها در PowerPoint مفید است. هر ارائه شامل یک اسلاید اصلی، اسلایدهای طرح‌بندی اختیاری و یک یا چند اسلاید عادی است. هر اسلاید دارای یک شناسهٔ یکتا است و اسلایدهای عادی بر اساس یک شاخص صفر مبنا مرتب می‌شوند. این مقاله نشان می‌دهد چگونه از Aspose.Slides برای Python برای ایجاد اسلایدها و انتخاب طرح‌بندی‌های مناسب استفاده کنید.

## **افزودن اسلایدها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد اسلایدهای جدیدی را بر پایهٔ اسلایدهای طرح‌بندی موجود اضافه کنید. مثال زیر بر روی هر طرح‌بندی در ارائه تکرار می‌شود، اسلایدی که از آن طرح‌بندی استفاده می‌کند اضافه می‌گردد و سپس فایل ذخیره می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. به [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) دسترسی داشته باشید.
1. برای هر مورد در `presentation.layout_slides`، `add_empty_slide` را فراخوانی کنید تا اسلایدی که از آن طرح‌بندی استفاده می‌کند اضافه شود.
1. در صورت نیاز اسلایدهای تازه اضافه شده را اصلاح کنید.
1. ارائه را به عنوان یک فایل PPTX ذخیره کنید.

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    # دسترسی به مجموعه اسلایدها.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # یک اسلاید خالی به مجموعه اسلایدها اضافه کنید.
        slides.add_empty_slide(layout_slide)

    # کارهایی روی اسلایدهای تازه اضافه شده انجام دهید.

    # ارائه را روی دیسک ذخیره کنید.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا می‌توانم یک اسلاید جدید را در موقعیتی مشخص، نه فقط در انتها، وارد کنم؟**

بله. کتابخانه از مجموعهٔ اسلایدها و عملیات [insert](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/insert_clone/) پشتیبانی می‌کند، بنابراین می‌توانید اسلاید را در شاخص مورد نیاز اضافه کنید نه فقط در انتها.

**آیا تم/استایل‌ها هنگام افزودن اسلاید بر پایهٔ یک طرح‌بندی حفظ می‌شوند؟**

بله. یک طرح‌بندی قالب‌بندی خود را از اسلاید اصلی دریافت می‌کند و اسلاید جدید نیز از طرح‌بندی انتخاب شده و اسلاید اصلی مرتبط با آن ارث می‌برد.

**کدام اسلاید در یک ارائهٔ جدید «خالی» قبل از افزودن اسلایدها وجود دارد؟**

یک ارائهٔ تازه ایجاد شده از پیش شامل یک اسلاید خالی با شاخص صفر است. این نکته هنگام محاسبهٔ شاخص‌های درج مهم است.

**چگونه می‌توانم «طرح‌بندی» مناسب برای یک اسلاید جدید را انتخاب کنم اگر اسلاید اصلی گزینه‌های متعددی داشته باشد؟**

به‌طور کلی باید [LayoutSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) را انتخاب کنید که با ساختار مورد نیاز (مانند [Title and Content, Two Content, etc.](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidelayouttype/)) مطابقت داشته باشد. اگر چنین طرح‌بندی‌ای موجود نباشد، می‌توانید [add it to the master](/slides/fa/python-net/slide-layout/) کرده و سپس از آن استفاده کنید.