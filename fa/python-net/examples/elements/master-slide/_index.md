---
title: اسلاید اصلی
type: docs
weight: 30
url: /fa/python-net/examples/elements/master-slide/
keywords:
- اسلاید اصلی
- افزودن اسلاید اصلی
- دسترسی به اسلاید اصلی
- حذف اسلاید اصلی
- اسلاید اصلی بلااستفاده
- مثال‌های کد
- پاورپوینت
- سند باز
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت اسلایدهای اصلی در پایتون با Aspose.Slides: ایجاد، ویرایش، تکثیر و قالب‌بندی تم‌ها، پس‌زمینه‌ها و فضاهای نگهدارنده برای یکنواخت‌سازی اسلایدها در پاورپوینت و سند باز."
---
Master slides form the top level of the slide inheritance hierarchy in PowerPoint. A **master slide** defines common design elements such as backgrounds, logos, and text formatting. **Layout slides** inherit from master slides, and **normal slides** inherit from layout slides.

این مقاله نشان می‌دهد چگونه اسلایدهای اصلی را با استفاده از Aspose.Slides برای Python از طریق .NET ایجاد، تغییر و مدیریت کنید.

## **افزودن اسلاید اصلی**

این مثال نشان می‌دهد چگونه یک اسلاید اصلی جدید را با تکثیر اسلاید پیش‌فرض ایجاد کنید.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # تکثیر اسلاید اصلی پیش‌فرض.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** اسلایدهای اصلی راهی برای اعمال برندینگ یکسان یا عناصر طراحی مشترک در تمام اسلایدها فراهم می‌کنند. هر تغییری که در اسلاید اصلی انجام شود، به‌طور خودکار در اسلایدهای layout وابسته و اسلایدهای normal بازتاب می‌یابد.

> 💡 **Tip 2:** هر شکل یا قالب‌بندی که به یک اسلاید اصلی اضافه شود، به اسلایدهای layout ارث می‌رسد و به نوبه خود به تمام اسلایدهای normal که از آن طرح‌ها استفاده می‌کنند.  
> تصویر زیر نشان می‌دهد چگونه یک جعبه متن که در یک اسلاید اصلی اضافه شده به‌صورت خودکار در اسلاید نهایی رندر می‌شود.

![مثال وراثت اسلاید اصلی](master-slide-banner.png)

## **دسترسی به اسلاید اصلی**

می‌توانید با استفاده از مجموعه `Presentation.masters` به اسلایدهای اصلی دسترسی پیدا کنید. در اینجا نحوه بازیابی و کار با آن‌ها آورده شده است:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # دسترسی به اولین اسلاید اصلی.
        first_master_slide = presentation.masters[0]
```

## **حذف اسلاید اصلی**

اسلایدهای اصلی می‌توانند با استفاده از ایندکس یا ارجاع حذف شوند.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # حذف بر اساس ایندکس.
        presentation.masters.remove_at(0)

        # یا حذف بر اساس ارجاع.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف اسلایدهای اصلی بلااستفاده**

برخی ارائه‌ها شامل اسلایدهای اصلی هستند که استفاده نمی‌شوند. حذف این اسلایدها می‌تواند به کاهش حجم فایل کمک کند.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # حذف تمام اسلایدهای اصلی بلااستفاده (حتی آن‌هایی که به عنوان Preserve علامت‌گذاری شده‌اند).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** از `remove_unused(True)` برای پاک‌سازی اسلایدهای اصلی بلااستفاده و بهینه‌سازی حجم ارائه استفاده کنید.