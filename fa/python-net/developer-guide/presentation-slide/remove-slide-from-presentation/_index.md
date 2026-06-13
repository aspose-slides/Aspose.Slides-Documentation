---
title: حذف اسلایدها از ارائه‌ها در Python
linktitle: حذف اسلاید
type: docs
weight: 30
url: /fa/python-net/remove-slide-from-presentation/
keywords:
- حذف اسلاید
- پاک‌کردن اسلاید
- حذف اسلایدهای استفاده‌نشده
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "به راحتی اسلایدها را از ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET حذف کنید. مثال‌های کد واضح دریافت کنید و جریان کاری خود را بهبود ببخشید."
---
## **مقدمه**

اگر یک اسلاید (یا محتویات آن) دیگر مورد نیاز نیست، می‌توانید آن را حذف کنید. Aspose.Slides کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) را فراهم می‌کند که [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) را در خود دارد، مخزنی برای تمام اسلایدهای یک ارائه. با استفاده از یک اشاره‌گر یا شاخص به یک [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) شناخته‌شده، می‌توانید اسلاید هدف را حذف کنید.

## **حذف اسلاید بر اساس اشاره‌گر**

وقتی که قبلاً به یک [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) هدف اشاره دارید، می‌توانید آن را مستقیماً حذف کنید. این کار از جستجوی شاخص جلوگیری می‌کند و کد را کوتاه‌تر و واضح‌تر می‌سازد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. یک اشاره‌گر به اسلایدی که می‌خواهید حذف کنید، بر اساس شناسه یا شاخص آن دریافت کنید.
3. اسلاید اشاره‌شده را از ارائه حذف کنید.
4. ارائهٔ تغییر یافته را ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید تا یک فایل ارائه را باز کنید.
with slides.Presentation("sample.pptx") as presentation:
    # یک اسلاید را بر اساس شاخص آن در مجموعه اسلایدها دسترسی پیدا کنید.
    slide = presentation.slides[0]

    # اسلاید را بر اساس اشاره‌گر حذف کنید.
    presentation.slides.remove(slide)

    # ارائهٔ تغییر یافته را ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف اسلاید بر اساس شاخص**

اگر مکان اسلاید در مجموعه را می‌دانید، می‌توانید آن را بر اساس شاخص حذف کنید. این کار به‌ ویژه در حلقه‌ها یا عملیات‌های دسته‌ای که موقعیت‌ها از قبل مشخص هستند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید را بر اساس شاخص آن حذف کنید.
3. ارائهٔ تغییر یافته را ذخیره کنید.

```python
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید تا یک فایل ارائه را باز کنید.
with slides.Presentation("sample.pptx") as presentation:
    # اسلاید را بر اساس شاخص آن حذف کنید.
    presentation.slides.remove_at(0)

    # ارائهٔ تغییر یافته را ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف اسلاید چیدمان استفاده‌نشده**

Aspose.Slides متد `remove_unused_layout_slides` را در کلاس [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) فراهم می‌کند تا اسلایدهای چیدمان ناخواسته و استفاده‌نشده را حذف کند. مثال زیر به زبان پایتون نشان می‌دهد چگونه اسلایدهای چیدمان استفاده‌نشده را از یک ارائهٔ PowerPoint حذف کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف اسلاید اصلی استفاده‌نشده**

Aspose.Slides متد `remove_unused_master_slides` را در کلاس [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) فراهم می‌کند تا اسلایدهای اصلی ناخواسته و استفاده‌نشده را حذف کند. مثال زیر به زبان پایتون نشان می‌دهد چگونه اسلایدهای اصلی استفاده‌نشده را از یک ارائهٔ PowerPoint حذف کنید:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**بعد از حذف یک اسلاید، چه اتفاقی برای شاخص‌های اسلایدها می‌افتد؟**

پس از حذف، [collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) مجدداً ایندکس می‌شود: هر اسلاید بعدی یک موقعیت به سمت چپ جابجا می‌شود، بنابراین شماره‌های شاخص قبلی قدیمی می‌شوند. اگر به یک اشاره‌گر ثابت نیاز دارید، به‌جای شاخص، شناسهٔ دائم هر اسلاید را استفاده کنید.

**آیا شناسهٔ یک اسلاید با شاخص آن متفاوت است و آیا هنگام حذف اسلایدهای همسایه تغییر می‌کند؟**

بله. شاخص موقعیت اسلاید است و هنگام افزودن یا حذف اسلایدها تغییر می‌کند. شناسهٔ اسلاید یک شناسهٔ دائم است و وقتی اسلایدهای دیگر حذف شوند تغییر نمی‌کند.

**حذف یک اسلاید چگونه بر بخش‌های اسلاید تأثیر می‌گذارد؟**

اگر اسلاید به بخشی تعلق داشته باشد، آن بخش تنها یک اسلاید کمتر خواهد داشت. ساختار بخش حفظ می‌شود؛ اگر بخشی خالی شود، می‌توانید [بخش‌ها را حذف یا بازسازی کنید](/slides/fa/python-net/slide-section/) همان‌طور که لازم است.

**چه اتفاقی برای یادداشت‌ها و نظراتی که به یک اسلاید پیوست شده‌اند می‌افتد وقتی اسلاید حذف می‌شود؟**

[Notes](/slides/fa/python-net/presentation-notes/) و [comments](/slides/fa/python-net/presentation-comments/) به آن اسلاید خاص مرتبط هستند و همراه با آن حذف می‌شوند. محتوای اسلایدهای دیگر تحت تأثیر قرار نمی‌گیرد.

**حذف اسلایدها چه تفاوتی با پاکسازی چیدمان‌ها/اصلی‌های استفاده‌نشده دارد؟**

حذف، اسلایدهای عادی خاصی را از مجموعه حذف می‌کند. پاکسازی چیدمان‌ها/اصلی‌های استفاده‌نشده، اسلایدهای چیدمان یا اصلی را که هیچ‌کسی به آن‌ها ارجاع نمی‌دهد حذف می‌کند و اندازهٔ فایل را بدون تغییر محتوای اسلایدهای باقی‌مانده کاهش می‌دهد. این دو عمل تکمیلی هستند: معمولاً ابتدا حذف انجام می‌شود و سپس پاکسازی.