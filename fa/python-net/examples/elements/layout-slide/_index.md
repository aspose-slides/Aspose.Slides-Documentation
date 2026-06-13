---
title: اسلاید طرح‌بندی
type: docs
weight: 20
url: /fa/python-net/examples/elements/layout-slide/
keywords:
- اسلاید طرح‌بندی
- افزودن اسلاید طرح‌بندی
- دسترسی به اسلاید طرح‌بندی
- حذف اسلاید طرح‌بندی
- اسلاید طرح‌بندی استفاده‌نشده
- کلون اسلاید طرح‌بندی
- نمونه‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "با استفاده از Python برای مدیریت اسلایدهای طرح‌بندی با Aspose.Slides: ایجاد، اعمال، کلون، تغییر نام و سفارشی‌سازی جای‌گیرها و تم‌ها در ارائه‌ها برای PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه با **Layout Slides** در Aspose.Slides برای Python از طریق .NET کار کنید. یک اسلاید طرح‌بندی، طراحی و قالب‌بندی را که اسلایدهای معمولی به ارث می‌برند، تعریف می‌کند. می‌توانید اسلایدهای طرح‌بندی را اضافه، دسترسی، کلون و حذف کنید و همچنین اسلایدهای استفاده نشده را پاک‌سازی کنید تا اندازه ارائه کاهش یابد.

## **افزودن یک اسلاید طرح‌بندی**

می‌توانید یک اسلاید طرح‌بندی سفارشی ایجاد کنید تا قالب‌بندی قابل استفاده مجدد را تعریف نمایید.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # یک اسلاید طرح‌بندی با نوع و نام مشخص شده ایجاد کنید.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **نکته ۱:** اسلایدهای طرح‌بندی به عنوان قالب برای اسلایدهای فردی عمل می‌کنند. می‌توانید عناصر مشترک را یک‌بار تعریف کنید و در اسلایدهای متعدد دوباره استفاده کنید.  
> 💡 **نکته ۲:** وقتی به یک اسلاید طرح‌بندی اشکال یا متن اضافه می‌کنید، تمام اسلایدهای مبتنی بر آن طرح، این محتوای مشترک را به‌صورت خودکار نمایش می‌دهند.  
> تصویر زیر دو اسلاید را نشان می‌دهد که هر کدام یک جعبه متن را از همان اسلاید طرح‌بندی به ارث می‌برند.

![اسلایدهای ارث‌بری محتوای طرح‌بندی](layout-slide-result.png)


## **دسترسی به یک اسلاید طرح‌بندی**

می‌توانید به اسلایدهای طرح‌بندی بر اساس شاخص یا نوع طرح (مثلاً `Blank`، `Title`، `SectionHeader` و غیره) دسترسی پیدا کنید.

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # دسترسی بر اساس شاخص.
        first_layout_slide = presentation.layout_slides[0]

        # دسترسی بر اساس نوع طرح‌بندی.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **حذف یک اسلاید طرح‌بندی**

اگر دیگر نیاز به یک اسلاید طرح‌بندی خاص ندارید، می‌توانید آن را حذف کنید.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # یک اسلایید طرح‌بندی را بر اساس نوع دریافت کرده و حذف کنید.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

برای کاهش اندازه ارائه، ممکن است بخواهید اسلایدهای طرح‌بندی را که توسط هیچ اسلاید معمولی استفاده نمی‌شوند، حذف کنید.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # به‌طور خودکار تمام اسلایدهای طرح‌بندی که توسط هیچ اسلایدی ارجاع نشده‌اند را حذف می‌کند.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **کلون کردن یک اسلاید طرح‌بندی**

می‌توانید یک اسلاید طرح‌بندی را با استفاده از متد `AddClone` تکثیر کنید.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # دریافت یک اسلاید طرح‌بندی موجود بر اساس نوع.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # کلون کردن اسلاید طرح‌بندی به انتهای مجموعه اسلایدهای طرح‌بندی.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **خلاصه:** اسلایدهای طرح‌بندی ابزارهای قدرتمندی برای مدیریت قالب‌بندی یکسان در بین اسلایدها هستند. Aspose.Slides کنترل کامل بر ایجاد، مدیریت و بهینه‌سازی اسلایدهای طرح‌بندی را فراهم می‌کند.