---
title: دسترسی به اسلایدها در ارائه‌ها با پایتون
linktitle: دسترسی به اسلاید
type: docs
weight: 20
url: /fa/python-net/access-slide-in-presentation/
keywords:
  - دسترسی به اسلاید
  - اندیس اسلاید
  - شناسه اسلاید
  - موقعیت اسلاید
  - تغییر موقعیت
  - ویژگی‌های اسلاید
  - شماره اسلاید
  - PowerPoint
  - OpenDocument
  - ارائه
  - Python
  - Aspose.Slides
description: "یاد بگیرید چگونه اسلایدها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET دسترسی و مدیریت کنید. با مثال‌های کد، بهره‌وری را افزایش دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه می‌توانید اسلایدهای خاص یک ارائهٔ PowerPoint را با استفاده از Aspose.Slides برای Python دسترسی پیدا کنید. این مقاله نشان می‌دهد چگونه یک ارائه را باز کنید، اسلایدها را بر اساس اندیس یا شناسهٔ منحصر به فرد ارجاع دهید، و اطلاعات پایهٔ اسلاید را که برای ناوبری درون فایل لازم است بخوانید. با استفاده از این تکنیک‌ها، می‌توانید به طور قابل اطمینان اسلاید دقیق مورد نظر برای بررسی یا پردازش را پیدا کنید.

## **دسترسی به اسلاید بر اساس اندیس**

اسلایدهای یک ارائه بر اساس موقعیت‌شان ایندکس می‌شوند و شماره‌گذاری از 0 شروع می‌شود. اسلاید اول دارای ایندکس 0 است، اسلاید دوم ایندکس 1 دارد و به همین ترتیب.

کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) (که نمایانگر یک فایل ارائه است) اسلایدها را از طریق یک [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) از اشیاء [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) در دسترس قرار می‌دهد.

کد پایتون زیر نشان می‌دهد چگونه یک اسلاید را بر اساس ایندکس آن دسترسی پیدا کنید:

```python
import aspose.slides as slides

# ایجاد یک Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation("sample.pptx") as presentation:
    # دریافت یک اسلاید بر اساس ایندکس آن.
    slide = presentation.slides[0]
```

## **دسترسی به اسلاید بر اساس شناسه**

هر اسلاید در یک ارائه یک شناسهٔ منحصر به فرد دارد. می‌توانید از متد [get_slide_by_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_slide_by_id/) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) در دسترس است) برای هدف‌گذاری آن شناسه استفاده کنید.

کد پایتون زیر نشان می‌دهد چگونه یک شناسهٔ اسلاید معتبر ارائه دهید و از طریق متد [get_slide_by_id](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_slide_by_id/) به آن اسلاید دسترسی پیدا کنید:

```python
import aspose.slides as slides

# یک Presentation ایجاد کنید که نمایانگر فایل ارائه است.
with slides.Presentation("sample.pptx") as presentation:
    # دریافت شناسهٔ اسلاید.
    id = presentation.slides[0].slide_id
    # دسترسی به اسلاید بر اساس شناسهٔ آن.
    slide = presentation.get_slide_by_id(id)
```

## **تغییر موقعیت اسلاید**

Aspose.Slides به شما اجازه می‌دهد موقعیت یک اسلاید را تغییر دهید. به عنوان مثال، می‌توانید اسلاید اول را به اسلاید دوم تبدیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به اسلایدی که می‌خواهید موقعیت آن را بر اساس ایندکسش تغییر دهید، به دست آورید.
1. موقعیت جدید اسلاید را از طریق ویژگی [slide_number](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/slide_number/) تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

کد پایتون زیر اسلاید در موقعیت 1 را به موقعیت 2 انتقال می‌دهد:

```python
import aspose.slides as slides

# یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
with slides.Presentation("sample.pptx") as presentation:
    # اسلایدی را دریافت کنید که موقعیت آن تغییر خواهد کرد.
    slide = presentation.slides[0]
    # موقعیت جدید اسلاید را تنظیم کنید.
    slide.slide_number = 2
    # ارائهٔ تغییر یافته را ذخیره کنید.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

اسلاید اول به اسلاید دوم تبدیل می‌شود؛ اسلاید دوم به اسلاید اول. وقتی موقعیت یک اسلاید را تغییر می‌دهید، اسلایدهای دیگر به‌صورت خودکار تنظیم می‌شوند.

## **تنظیم شماره اسلاید**

با استفاده از ویژگی [first_slide_number](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/first_slide_number/) (که توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) در دسترس است)، می‌توانید شمارهٔ جدیدی برای اسلاید اول یک ارائه تعیین کنید. این عملیات باعث می‌شود شماره‌های دیگر اسلایدها بازمحاسبه شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. شمارهٔ اسلاید را تنظیم کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

کد پایتون زیر عملیاتی را نشان می‌دهد که در آن شمارهٔ اسلاید اول به 10 تنظیم شده است:

```python
import aspose.slides as slides

# یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است.
with slides.Presentation("sample.pptx") as presentation:
    # شماره اسلاید را تنظیم کنید.
    presentation.first_slide_number = 10
    # ارائهٔ تغییر یافته را ذخیره کنید.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

اگر ترجیح می‌دهید اسلاید اول را نادیده بگیرید، می‌توانید شماره‌گذاری را از اسلاید دوم شروع کنید (و شماره را در اسلاید اول مخفی کنید) به این صورت:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # شمارهٔ اولین اسلاید در ارائه را تنظیم کنید.
    presentation.first_slide_number = 0

    # نمایش شماره اسلایدها برای همه اسلایدها.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # پنهان کردن شماره اسلاید در اولین اسلاید.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # ارائهٔ تغییر یافته را ذخیره کنید.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا شمارهٔ اسلایدی که کاربر می‌بیند با ایندکس صفر-پایهٔ مجموعه مطابقت دارد؟**

شماره‌ای که بر روی اسلاید نشان داده می‌شود می‌تواند از مقدار دلخواهی (مثلاً 10) شروع شود و نیازی به مطابقت با ایندکس ندارد؛ این رابطه توسط تنظیمات [first slide number](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/first_slide_number/) ارائه کنترل می‌شود.

**آیا اسلایدهای مخفی بر ایندکس‌گذاری تأثیر می‌گذارند؟**

بله. یک اسلاید مخفی در مجموعه باقی می‌ماند و در ایندکس‌گذاری شمرده می‌شود؛ «مخفی» به نمایش اشاره دارد، نه به موقعیت آن در مجموعه.

**آیا ایندکس یک اسلاید هنگام افزودن یا حذف اسلایدهای دیگر تغییر می‌کند؟**

بله. ایندکس‌ها همیشه ترتیب فعلی اسلایدها را نشان می‌دهند و هنگام افزودن، حذف یا جابه‌جایی اسلایدها بازمحاسبه می‌شوند.