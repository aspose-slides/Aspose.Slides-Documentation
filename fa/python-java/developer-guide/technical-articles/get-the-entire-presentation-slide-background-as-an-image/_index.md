---
title: دریافت تمام پس‌زمینهٔ اسلاید از یک ارائه به صورت تصویر
linktitle: تمام پس‌زمینه اسلاید
type: docs
weight: 95
url: /fa/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- پس‌زمینه اسلاید
- پس‌زمینه نهایی
- استخراج پس‌زمینه
- تمام پس‌زمینه
- پس‌زمینه به تصویر
- پس‌زمینه PPT
- پس‌زمینه PPTX
- پس‌زمینه ODP
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "استخراج تمام پس‌زمینه‌های اسلاید به صورت تصویر از ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python via Java، به‌منظور ساده‌سازی گردش کارهای تصویری."
---
## **مرور کلی**

در ارائه‌های پاورپوینت، پس‌زمینهٔ اسلاید می‌تواند از چندین عنصر شامل تصویر پس‌زمینهٔ اسلاید، تم ارائه، طرح رنگی و اشیائی که بر روی اسلاید مستر یا اسلاید طرح قرار داده شده‌اند، تشکیل شود.

این مقاله نشان می‌دهد چگونه می‌توان تمام پس‌زمینهٔ اسلاید را به عنوان تصویر استخراج کرد با استفاده از Aspose.Slides for Python via Java. از آنجا که روش واحدی برای این کار وجود ندارد، رویکرد شامل کلون کردن اسلاید منتخب به یک ارائه موقت، حذف اشکال اسلاید، و سپس تبدیل پس‌زمینهٔ اسلاید حاصل به تصویر می‌شود.

## **دریافت تمام پس‌زمینهٔ اسلاید**

Aspose.Slides for Python via Java روش ساده‌ای برای استخراج تمام پس‌زمینهٔ اسلاید ارائه به عنوان تصویر ارائه نمی‌دهد، اما می‌توانید با دنبال کردن مراحل زیر این کار را انجام دهید:

1. پرزنتیشن را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید.
1. اندازهٔ اسلاید را از پرزنتیشن دریافت کنید.
1. یک اسلاید را انتخاب کنید.
1. یک پرزنتیشن موقت ایجاد کنید.
1. سایز همان اسلاید را در پرزنتیشن موقت تنظیم کنید.
1. اسلاید انتخاب شده را به پرزنتیشن موقت کلون کنید.
1. اشکال را از اسلاید کلون‌شده حذف کنید.
1. اسلاید کلون‌شده را به تصویر تبدیل کنید.

کد زیر تمام پس‌زمینهٔ اسلاید ارائه را به عنوان تصویر استخراج می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**آیا گرادیانت‌ها، بافت‌ها یا پرکننده‌های تصویری پیچیده از اسلاید مستر در تصویر پس‌زمینهٔ حاصل حفظ می‌شوند؟**

بله. Aspose.Slides پرکننده‌های گرادیانت، تصویر و بافت تعریف‌شده بر روی اسلاید، طرح یا مستر را رندر می‌کند. اگر نیاز دارید ظاهر را از مسترهای به‌ارث‌برده جدا کنید، قبل از خروجی‌گیری روی اسلاید فعلی [یک پس‌زمینهٔ سفارشی تنظیم کنید](/slides/fa/python-java/presentation-background/).

**آیا می‌توانم پیش از ذخیرهٔ تصویر پس‌زمینهٔ حاصل، یک واترمارک به آن اضافه کنم؟**

بله. می‌توانید یک شکل یا تصویر [واترمارک اضافه کنید](/slides/fa/python-java/watermark/) بر روی یک [کپی کاری از اسلاید](/slides/fa/python-java/clone-slides/) (در پشت سایر محتوا قرار داده شود) و سپس خروجی بگیرید. این امکان را می‌دهد که تصویری پس‌زمینه‌ای با واترمارک تعبیه‌شده تولید کنید.

**آیا می‌توانم پس‌زمینهٔ یک طرح یا مستر خاص را بدون ارتباط با اسلاید موجود دریافت کنم؟**

بله. به مستر یا طرح مورد نظر دسترسی پیدا کنید، آن را بر روی یک [اسلاید موقت](/slides/fa/python-java/clone-slides/) با اندازهٔ مورد نیاز اعمال کنید و سپس آن اسلاید را خروجی بگیرید تا پس‌زمینهٔ استخراج‌شده از آن طرح یا مستر به‌دست آید.

**آیا محدودیت‌های مجوزی وجود دارد که بر خروجی تصویر تأثیر بگذارد؟**

قابلیت‌های رندر با داشتن یک [مجوز معتبر](/slides/fa/python-java/licensing/) به‌ طور کامل در دسترس هستند. در حالت ارزیابی، خروجی ممکن است شامل محدودیت‌هایی مانند واترمارک باشد. قبل از اجرای صادرات دسته‌ای، مجوز را یک بار برای هر فرایند فعال کنید.