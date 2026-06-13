---
title: مدیریت جای‌گیرها در ارائه‌ها با پایتون
linktitle: مدیریت جای‌گیرها
type: docs
weight: 10
url: /fa/python-net/manage-placeholder/
keywords:
- جای‌گیر
- جای‌گیر متن
- جای‌گیر تصویر
- جای‌گیر نمودار
- متن راهنما
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "به‌سادگی جای‌گیرها را در Aspose.Slides برای پایتون از طریق .NET مدیریت کنید: متن را جایگزین کنید، راهنماها را سفارشی کنید و شفافیت تصویر را در PowerPoint و OpenDocument تنظیم نمایید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد متغیرهای نگهدارنده ارائه را به‌صورت برنامه‌نویسی مدیریت کنید. این مقاله توضیح می‌دهد چگونه متغیرهای نگهدارنده را در اسلایدها پیدا کنید و متن آن‌ها را تغییر دهید، متن راهنمای سفارشی برای طرح‌های جای‌گیر تنظیم کنید و شفافیت تصویری که به‌عنوان پس‌زمینه متغیر نگهدارنده استفاده می‌شود را تنظیم کنید. همچنین شامل یک بخش پرسش و پاسخ کوتاه است که تفاوت بین متغیرهای پایه و اشکال محلی را روشن می‌کند، نحوه اعمال تغییرات متغیرهای نگهدارنده از طریق طرح‌ها یا مسترها را شرح می‌دهد و به مدیریت متغیرهای سرصفحه و پاورپیرامید اشاره می‌کند.

## **تغییر متن در جای‌گیرها**

با استفاده از Aspose.Slides برای Python می‌توانید جای‌گیرها را در اسلایدهای یک ارائه پیدا کنید و آن‌ها را تغییر دهید. Aspose.Slides به شما امکان می‌دهد متن یک جای‌گیر را اصلاح کنید.

**پیش‌نیاز:** شما به ارائه‌ای نیاز دارید که شامل یک جای‌گیر باشد. می‌توانید چنین ارائه‌ای را در Microsoft PowerPoint ایجاد کنید.

این روش استفاده از Aspose.Slides برای جایگزینی متن در یک جای‌گیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه را به عنوان آرگومان پاس دهید.
1. با استفاده از ایندکس آن، به اسلاید مورد نظر دسترسی پیدا کنید.
1. در میان اشکال مرور کنید تا جای‌گیر را پیدا کنید.
1. متن را با استفاده از [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) تغییر دهید.
1. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه متن در یک جای‌گیر را تغییر دهید:

```python
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # دسترسی به اولین اسلاید.
    slide = presentation.slides[0]

    # مرور اشکال برای یافتن جای‌گیرها.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # تغییر متن در هر جای‌گیر.
            shape.text_frame.text = "This is Placeholder"

    # ذخیرهٔ ارائه در دیسک.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم متن راهنما برای یک جای‌گیر**

طرح‌های استاندارد و پیش‌ساخته شامل متن راهنمایی جای‌گیر مانند **Click to add a title** یا **Click to add a subtitle** هستند. با Aspose.Slides می‌توانید این راهنماها را با متن دلخواه خود در طرح‌های جای‌گیر جایگزین کنید.

مثال Python زیر نشان می‌دهد چگونه متن راهنمایی برای یک جای‌گیر تنظیم شود:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # مرور اشکال برای یافتن جای‌گیرها.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم شفافیت تصویر در یک جای‌گیر**

Aspose.Slides به شما امکان می‌دهد شفافیت تصویر پس‌زمینه در یک جای‌گیر متن را تنظیم کنید. با تنظیم شفافیت تصویر در همان فریم، می‌توانید متن یا تصویر را برجسته کنید، بسته به رنگ‌های آن‌ها.

مثال Python زیر نشان می‌دهد چگونه شفافیت پس‌زمینه تصویر داخل یک شکل تنظیم شود:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **سوالات متداول**

**متغیر پایه چیست و چگونه با یک شکل محلی در اسلاید متفاوت است؟**

متغیر پایه، شکل اصلی در یک طرح یا مستر است که شکل اسلاید از آن ویژگی‌ها—نوع، موقعیت و برخی قالب‌بندی‌ها—را به ارث می‌برد. شکل محلی مستقل است؛ اگر متغیر پایه‌ای وجود نداشته باشد، ارث‌بری اعمال نمی‌شود.

**چگونه می‌توان تمام عناوین یا توضیحات را در یک ارائه به‌روزرسانی کرد بدون اینکه بر هر اسلاید تکرار شود؟**

متغیر مربوطه را در طرح یا مستر ویرایش کنید. اسلایدهای مبتنی بر آن طرح/مستر به‌صورت خودکار تغییرات را به ارث می‌برند.

**چگونه می‌توان متغیرهای استاندارد سرصفحه/پاورپیرامید—تاریخ و زمان، شماره اسلاید و متن پاورپیرامید—را کنترل کرد؟**

از مدیرهای HeaderFooter در سطح مناسب (اسلایدهای عادی، طرح‌ها، مستر، یادداشت‌ها/پیشنویس‌ها) استفاده کنید تا این متغیرها را فعال یا غیرفعال کنید و محتوای آن‌ها را تنظیم نمایید.