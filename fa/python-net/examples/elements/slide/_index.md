---
title: اسلاید
type: docs
weight: 10
url: /fa/python-net/examples/elements/slide/
keywords:
- اسلاید
- افزودن اسلاید
- دسترسی به اسلاید
- ایندکس اسلاید
- تکثیر اسلاید
- باز ترتیب اسلایدها
- حذف اسلاید
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت اسلایدها در پایتون با Aspose.Slides: ایجاد، تکثیر، باز ترتیب، مخفی کردن، تنظیم پس‌زمینه و اندازه، اعمال انتقال‌ها و صادر کردن برای PowerPoint و OpenDocument."
---
این مقاله مجموعه‌ای از مثال‌ها را ارائه می‌دهد که نشان می‌دهد چگونه با اسلایدها با استفاده از **Aspose.Slides for Python via .NET** کار کنید. شما یاد می‌گیرید چگونه اسلایدها را اضافه، دسترسی، تکثیر، باز ترتیب و حذف کنید با استفاده از کلاس `Presentation`.

هر مثال در زیر شامل توضیح مختصری است که به دنبال آن یک قطعه کد پایتون قرار دارد.

## **اضافه کردن یک اسلاید**

برای اضافه کردن یک اسلاید جدید، ابتدا باید یک چیدمان انتخاب کنید. در این مثال، ما از چیدمان `Blank` استفاده می‌کنیم و یک اسلاید خالی به ارائه اضافه می‌کنیم.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # هر اسلاید بر پایه یک چیدمان است که خود نیز از یک اسلاید اصلی مشتق می‌شود.
        # از چیدمان Blank برای ایجاد یک اسلاید جدید استفاده کنید.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # یک اسلاید خالی جدید با استفاده از چیدمان انتخاب شده اضافه کنید.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **نکته:** هر چیدمان اسلاید از یک اسلاید اصلی مشتق می‌شود که طراحی کلی و ساختار نگهدارنده‌ها را تعریف می‌کند. تصویر زیر نشان می‌دهد چطور اسلایدهای اصلی و چیدمان‌های مرتبط با آن‌ها در PowerPoint سازماندهی شده‌اند.

![رابطه اسلاید اصلی و چیدمان](master-layout-slide.png)

## **دسترسی به اسلایدها بر اساس ایندکس**

شما می‌توانید با استفاده از ایندکس به اسلایدها دسترسی پیدا کنید. این برای تکرار یا ویرایش اسلایدهای خاص مفید است.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # دسترسی به یک اسلاید بر اساس ایندکس.
        first_slide = presentation.slides[0]
```

## **تکثیر یک اسلاید**

این مثال نشان می‌دهد چگونه یک اسلاید موجود را تکثیر کنید. اسلاید تکثیر شده به صورت خودکار به انتهای مجموعه اسلایدها اضافه می‌شود.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # تکثیر اسلاید؛ این اسلاید در انتهای ارائه اضافه خواهد شد.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **باز ترتیب اسلایدها**

شما می‌توانید ترتیب اسلایدها را با جابجایی یک اسلاید به ایندکس جدید تغییر دهید. در این حالت، یک اسلاید را به موقعیت اول منتقل می‌کنیم.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # جابه‌جایی اسلاید به موقعیت اول (سایر اسلایدها به پایین جابه‌جا می‌شوند).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف یک اسلاید**

برای حذف یک اسلاید، به سادگی به آن ارجاع دهید و متد `remove` را صدا بزنید. این مثال اسلاید اولین را حذف می‌کند.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # حذف اسلاید.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```