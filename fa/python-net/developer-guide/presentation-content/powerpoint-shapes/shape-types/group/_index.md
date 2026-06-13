---
title: شکل‌های گروهی ارائه با پایتون
linktitle: گروه شکل
type: docs
weight: 40
url: /fa/python-net/group/
keywords:
- شکل گروهی
- گروه شکل
- افزودن گروه
- متن جایگزین
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در PowerPoint و مجموعه‌های OpenDocument با استفاده از Aspose.Slides برای Python گروه‌بندی و جداسازی کنید—راهنمای سریع گام‌به‌گام با کد رایگان."
---
## **نمای کلی**

این مقاله نحوه کار با اشکال گروهی در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه یک شکل گروهی به یک اسلاید اضافه کنید، اشکال را داخل آن قرار دهید و ارائه به‌روزشده را ذخیره کنید. همچنین نحوه دسترسی به اشکال ذخیره‌شده درون یک گروه و خواندن مقادیر `alternative_text` آن‌ها را نشان می‌دهد. علاوه بر این، مقاله به‌ طور خلاصه قابلیت‌های مرتبط با اشکال گروهی مانند گروه‌های تو در تو، ترتیب z، و گزینه‌های قفل‌گذاری را پوشش می‌دهد.

## **افزودن اشکال گروهی**

Aspose.Slides امکان کار با اشکال گروهی در یک اسلاید را فراهم می‌کند. این قابلیت به شما اجازه می‌دهد ارائه‌های غنی‌تری بسازید با این‌که چندین شکل را به عنوان یک شیء واحد در نظر بگیرید. می‌توانید اشکال گروهی جدید اضافه کنید، به اشکال موجود دسترسی پیدا کنید، آن‌ها را با اشکال فرزند پر کنید و هر یک از ویژگی‌هایشان را بخوانید یا تغییر دهید. برای افزودن یک شکل گروهی به اسلاید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بسازید.
2. یک ارجاع به اسلایدی بر اساس شاخص دریافت کنید.
3. یک [GroupShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/) به اسلاید اضافه کنید.
4. اشکال را به شکل گروهی جدید اضافه کنید.
5. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

مثال زیر نشان می‌دهد چگونه یک شکل گروهی به اسلاید اضافه شود.

```py
import aspose.slides as slides

# یک شیء از کلاس Presentation ایجاد کنید.
with slides.Presentation() as presentation:
    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    # یک شکل گروهی به اسلاید اضافه کنید.
    group_shape = slide.shapes.add_group_shape()

    # اشکال را داخل شکل گروهی اضافه کنید.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # فایل PPTX را بر روی دیسک ذخیره کنید.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به ویژگی Alt Text**

این بخش توضیح می‌دهد چگونه متن Alt متن اشکال موجود در یک شکل گروهی در یک اسلاید را با استفاده از Aspose.Slides بخوانید. برای دسترسی به متن Alt اشکال:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای نمایش فایل PPTX ایجاد کنید.
2. یک ارجاع به اسلاید با استفاده از شاخص آن به دست آورید.
3. به مجموعه اشکال اسلاید دسترسی پیدا کنید.
4. به [GroupShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/) دسترسی پیدا کنید.
5. ویژگی Alt Text را بخوانید.

مثال زیر متن Alt اشکال موجود در داخل اشکال گروهی را بازیابی می‌کند.

```py
import aspose.slides as slides

# یک شیء از کلاس Presentation را برای باز کردن فایل PPTX ایجاد کنید.
with slides.Presentation("group_shape.pptx") as presentation:
    # اسلاید اول را دریافت کنید.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # به شکل گروهی دسترسی پیدا کنید.
            for child_shape in shape.shapes:
                # به ویژگی Alt Text دسترسی پیدا کنید.
                print(child_shape.alternative_text)
```

## **FAQ**

**آیا گروه‌بندی تو در تو (یک گروه داخل یک گروه) پشتیبانی می‌شود؟**

بله. [GroupShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/) دارای ویژگی [parent_group](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/parent_group/) است که مستقیماً نشان‌دهنده پشتیبانی از سلسله‌مراتب است (یک گروه می‌تواند فرزند گروه دیگری باشد).

**چگونه ترتیب z گروه را نسبت به سایر اشیاء در اسلاید کنترل کنم؟**

از ویژگی [z_order_position](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/z_order_position/) موجود در [GroupShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/) استفاده کنید تا موقعیت آن را در پشته نمایش بررسی کنید.

**آیا می‌توانم از جابجایی/ویرایش/حذف گروه جلوگیری کنم؟**

بله. بخش قفل‌گذاری گروه از طریق [group_shape_lock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/group_shape_lock/) در دسترس است که به شما امکان می‌دهد عملیات بر روی شیء را محدود کنید.