---
title: تبدیل اسلایدهای PowerPoint به PNG در Python
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/python-java/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به صورت PNG
- ذخیره PPTX به صورت PNG
- صادرات PPT به PNG
- صادرات PPTX به PNG
- Python
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را در Python از طریق Java به تصاویر PNG تبدیل کنید. ارائه‌های PPT، PPTX و ODP را با مقیاس‌های سفارشی یا ابعاد دقیق تصویر صادر کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را به تصاویر PNG با استفاده از Aspose.Slides برای Python از طریق Java تبدیل کنید. می‌توانید فایل‌های PPT، PPTX و ODP را بارگذاری کنید، هر اسلاید را رندر کنید و به‌عنوان یک تصویر PNG جداگانه ذخیره کنید.

مثال‌ها همچنین نشان می‌دهند که چگونه می‌توان ابعاد خروجی را با استفاده از عوامل مقیاس یا یک عرض و ارتفاع دقیق کنترل کرد. هر مثال در صورت لزوم ماشین مجازی Java را راه‌اندازی می‌کند و پس از استفاده منابع ارائه و تصویر را آزاد می‌کند.

## **تبدیل PowerPoint به PNG**

1. فایل ورودی را با کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدها را با استفاده از [Presentation.getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) دریافت کنید.
3. هر اسلاید را با استفاده از [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) رندر کنید.
4. هر تصویر رندر شده را با [ImageFormat.Png](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imageformat/#Png) ذخیره کنید، سپس منابع آن را آزاد کنید.

مثال Python زیر تمام اسلایدها را با اندازه پیش‌فرضشان صادر می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **تبدیل PowerPoint به PNG با مقیاس سفارشی**

برای افزایش یا کاهش ابعاد خروجی، عوامل مقیاس افقی و عمودی را به [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) پاس دهید. برای مثال، اسلایدی با ابعاد 720 × 540 نقطه که با عامل مقیاس ۲ در هر دو محور رندر می‌شود، تصویر 1440 × 1080 پیکسل تولید می‌کند.

برای حفظ نسبت عرض به ارتفاع اسلاید از عوامل مقیاس برابر استفاده کنید. عوامل متفاوت اسلاید را به‌صورت افقی یا عمودی کشیده می‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

برای تعیین دقیق ابعاد پیکسل، یک شیء Java `Dimension` با عرض و ارتفاع موردنظر را به [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) پاس دهید. برای جلوگیری از اعوجاج، ابعادی را انتخاب کنید که نسبت عرض به ارتفاع همان اسلاید منبع داشته باشد.

مثال زیر هر اسلاید را به عنوان تصویر PNG با ابعاد 960 × 720 پیکسل ذخیره می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم یک شکل تک‌نفره مانند نمودار یا تصویر را به‌جای کل اسلاید صادر کنم؟**

بله. Aspose.Slides از [ایجاد تصویرهای بندانگشتی برای اشکال تک‌تکه](/slides/fa/python-java/create-shape-thumbnails/) پشتیبانی می‌کند که می‌توانید به‌عنوان تصاویر PNG ذخیره کنید.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی بر روی سرور تبدیل کنم؟**

برای هر نخ یا فرآیند یک نمونهٔ مجزا از Presentation استفاده کنید و مسیرهای خروجی منحصر به فرد برای جلوگیری از بازنویسی فایل‌ها بکار ببرید. بین نخ‌ها یک نمونهٔ Presentation را به‌اشتراک نگذارید. برای اطلاعات بیشتر به [Multithreading](/slides/fa/python-java/multithreading/) مراجعه کنید.

**محدودیت‌های نسخه آزمایشی هنگام صادرات به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و [محدودیت‌های دیگر](/slides/fa/python-java/licensing/) را اعمال می‌نماید. برای حذف این محدودیت‌ها یک لایسنس اعمال کنید.