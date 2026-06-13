---
title: ایجاد یک نمایشگر ارائه در پایتون
linktitle: نمایشگر ارائه
type: docs
weight: 50
url: /fa/python-net/presentation-viewer/
keywords: 
- مشاهده ارائه
- نمایشگر ارائه
- ایجاد نمایشگر ارائه
- مشاهده PPT
- مشاهده PPTX
- مشاهده ODP
- پاورپوینت
- اسناد باز
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه یک نمایشگر ارائهٔ سفارشی را در پایتون با استفاده از Aspose.Slides ایجاد کنید. به‌سادگی فایل‌های PowerPoint (PPTX، PPT) و OpenDocument (ODP) را بدون نیاز به Microsoft PowerPoint یا دیگر نرم‌افزارهای اداری نمایش دهید."
---
## **مقدمه**

Aspose.Slides برای Python برای ایجاد فایل‌های ارائه شامل اسلایدها استفاده می‌شود. این اسلایدها می‌توانند به‌عنوان مثال با باز کردن ارائه در Microsoft PowerPoint مشاهده شوند. با این حال، گاهی توسعه‌دهندگان نیاز دارند اسلایدها را به‌صورت تصویر در نمایشگر تصویر موردنظر خود ببینند یا در یک نمایشگر سفارشی استفاده کنند. در چنین مواردی، Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد را به‌عنوان تصویر صادر کنید. این مقاله نحوه انجام این کار را توضیح می‌دهد.

## **تولید تصویر SVG از یک اسلاید**

برای تولید تصویر SVG از یک اسلاید ارائه با Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. یک جریان فایل (file stream) باز کنید.
1. اسلاید را به‌عنوان تصویر SVG در جریان فایل ذخیره کنید.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **ایجاد تصویر بندانگشتی اسلاید**

Aspose.Slides به شما کمک می‌کند تا تصاویر بندانگشتی اسلایدها را تولید کنید. برای تولید یک بندانگشتی از اسلاید با استفاده از Aspose.Slides، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با مقیاس دلخواه ایجاد کنید.
1. تصویر بندانگشتی را در قالب تصویر موردنظرتان ذخیره کنید.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **ایجاد بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر**

برای ایجاد تصویر بندانگشتی اسلاید با ابعاد تعریف‌شده توسط کاربر، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با ابعاد مشخص‌شده تولید کنید.
1. تصویر بندانگشتی را در قالب تصویر موردنظرتان ذخیره کنید.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **ایجاد بندانگشتی اسلاید با یادداشت‌های سخنران**

برای تولید بندانگشتی اسلاید همراه با یادداشت‌های سخنران با استفاده از Aspose.Slides، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/) ایجاد کنید.
1. از ویژگی `RenderingOptions.slides_layout_options` برای تنظیم موقعیت یادداشت‌های سخنران استفاده کنید.
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را بر اساس ایندکس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با استفاده از گزینه‌های رندرینگ تولید کنید.
1. تصویر بندانگشتی را در قالب تصویر موردنظرتان ذخیره کنید.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **مثال زنده**

سعی کنید برنامهٔ رایگان [**Aspose.Slides Viewer**](https://products.aspose.app/slides/fa/viewer/) را امتحان کنید تا ببینید با API Aspose.Slides چه می‌توانید پیاده‌سازی کنید:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/fa/viewer/)

## **سوالات متداول**

**آیا می‌توانم یک نمایشگر ارائه را در برنامه وب ASP.NET جاسازی کنم؟**

بله. می‌توانید از Aspose.Slides در سمت سرور برای رندر اسلایدها به‌صورت [images](/slides/fa/python-net/convert-powerpoint-to-png/) یا [HTML](/slides/fa/python-net/convert-powerpoint-to-html/) استفاده کنید و آنها را در مرورگر نمایش دهید. ویژگی‌های ناوبری و زوم می‌توانند با JavaScript برای تجربهٔ تعاملی پیاده شوند.

**بهترین روش برای نمایش اسلایدها در یک نمایشگر سفارشی .NET چیست؟**

روش پیشنهادی این است که هر اسلاید را به‌صورت [image](/slides/fa/python-net/convert-powerpoint-to-png/) (مثلاً PNG یا SVG) رندر کنید یا با استفاده از Aspose.Slides به [HTML](/slides/fa/python-net/convert-powerpoint-to-html/) تبدیل کنید، سپس خروجی را داخل یک PictureBox (برای دسکتاپ) یا یک کانتینر HTML (برای وب) نمایش دهید.

**چگونه می‌توانم ارائه‌های بزرگ با تعداد زیادی اسلاید را مدیریت کنم؟**

برای مجموعه‌های بزرگ، بارگذاری تنبل (lazy‑loading) یا رندر در‑تقاضا (on‑demand) اسلایدها را در نظر بگیرید. این بدین معناست که محتویات اسلاید فقط زمانی تولید می‌شود که کاربر به آن سر می‌زند، که باعث کاهش مصرف حافظه و زمان بارگذاری می‌شود.