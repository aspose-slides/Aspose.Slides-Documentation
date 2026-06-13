---
title: تصویر
type: docs
weight: 50
url: /fa/python-net/examples/elements/picture/
keywords:
- تصویر
- فریم تصویر
- افزودن تصویر
- دسترسی به تصویر
- مثال‌های کد
- پاورپوینت
- سند باز
- ارائه
- پایتون
- Aspose.Slides
description: "کار با تصاویر در پایتون با استفاده از Aspose.Slides: افزودن، جایگزینی، برش، فشرده‌سازی، تنظیم شفافیت و اثرات، پر کردن شکل‌ها و خروجی برای PPT، PPTX و ODP."
---
نحوه افزودن و دسترسی به تصاویر از تصاویر در حافظه را با استفاده از **Aspose.Slides for Python via .NET** نشان می‌دهد. مثال‌های زیر یک تصویر را در حافظه ایجاد می‌کنند، آن را بر روی اسلاید قرار می‌دهند و سپس بازیابی می‌کنند.

## **افزودن تصویر**

این کد یک تصویر را از فایل بارگذاری می‌کند و به عنوان یک فریم تصویر در اسلاید اول قرار می‌دهد.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # یک تصویر را از یک فایل بارگذاری کنید.
        with open("image.png", "rb") as image_stream:
            # تصویر را به منابع ارائه اضافه کنید.
            image = presentation.images.add_image(image_stream)

        # یک فریم تصویر که تصویر را در اسلاید اول نمایش می‌دهد، درج کنید.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **دسترسی به تصویر**

این مثال اطمینان می‌دهد که یک اسلاید حاوی فریم تصویر است و سپس اولین فریم یافت‌شده را دسترسی می‌یابد.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # دسترسی به اولین فریم تصویر در اسلاید
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```