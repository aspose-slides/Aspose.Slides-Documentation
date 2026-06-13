---
title: تبدیل اسلایدهای PowerPoint به PNG در Python
linktitle: اسلاید به PNG
type: docs
weight: 30
url: /fa/python-net/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint به PNG
- تبدیل ارائه به PNG
- تبدیل اسلاید به PNG
- تبدیل PPT به PNG
- تبدیل PPTX به PNG
- تبدیل ODP به PNG
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ODP به PNG
- Python
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر PNG با کیفیت بالا به‌سرعت با Aspose.Slides for Python via .NET، تضمین نتایج دقیق و خودکار."
---
## **مرور کلی**

Aspose.Slides for Python via .NET تبدیل ارائه‌های PowerPoint به PNG را به سادگی انجام می‌دهد. شما یک ارائه را بارگذاری می‌کنید، از اسلایدهای آن عبور می‌کنید، هر اسلاید را به تصویر راستری رندر می‌کنید و نتیجه را به‌صورت فایل‌های PNG ذخیره می‌کنید. این برای ایجاد پیش‌نمایش اسلایدها، قرار دادن اسلایدها در صفحات وب، یا تولید دارایی‌های ثابت برای پردازش‌های بعدی ایده‌آل است.

## **تبدیل اسلایدها به PNG**

این بخش ساده‌ترین مثال ممکن برای تبدیل یک ارائه PowerPoint به تصاویر PNG با استفاده از Aspose.Slides for Python via .NET را نشان می‌دهد.

مراحل زیر را دنبال کنید:

1. یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. `Presentation.slides` را از مجموعه دریافت کنید (کلاس [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) را ببینید).
1. از متد `Slide.get_image` برای ایجاد تصویر بندانگشتی اسلاید استفاده کنید.
1. از متد `Presentation.save` برای ذخیره تصویر بندانگشتی اسلاید در قالب PNG استفاده کنید.

این کد Python نشان می‌دهد چگونه یک ارائه PowerPoint را به PNG تبدیل کنیم:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **تبدیل اسلایدها به PNG با ابعاد سفارشی**

برای استخراج اسلایدها به PNG با مقیاس سفارشی، `Slide.get_image` را با فاکتورهای مقیاس افقی و عمودی فراخوانی کنید. این ضریبها خروجی را نسبت به ابعاد اصلی اسلاید تغییر اندازه می‌دهند—به‌عنوان مثال، `2.0` عرض و ارتفاع را دو برابر می‌کند. برای حفظ نسبت تصویر از مقادیر برابر برای `scale_x` و `scale_y` استفاده کنید.

این کد Python عملیات توضیح داده شده را نشان می‌دهد:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **تبدیل اسلایدها به PNG با اندازه سفارشی**

اگر می‌خواهید فایل‌های PNG را با اندازه مشخصی تولید کنید، مقادیر `width` و `height` دلخواه خود را پاس کنید. کد زیر نشان می‌دهد چگونه یک PowerPoint را به PNG تبدیل کرده و اندازه تصویر را مشخص کنید:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
ممکن است بخواهید مبدل‌های رایگان **PowerPoint-to-PNG** Aspose را امتحان کنید—[PPTX to PNG](https://products.aspose.app/slides/fa/conversion/pptx-to-png) و [PPT to PNG](https://products.aspose.app/slides/fa/conversion/ppt-to-png). این ابزارها پیاده‌سازی زنده‌ای از فرایند شرح داده شده در این صفحه را ارائه می‌دهند.
{{% /alert %}}

## **سوالات متداول**

**چگونه می‌توانم فقط یک شکل خاص (مانند نمودار یا تصویر) را به‌جای کل اسلاید صادر کنم؟**  
Aspose.Slides از [تولید تصویر بندانگشتی برای اشکال جداگانه](/slides/fa/python-net/create-shape-thumbnails/) پشتیبانی می‌کند؛ می‌توانید یک شکل را به تصویر PNG رندر کنید.

**آیا تبدیل موازی بر روی سرور پشتیبانی می‌شود؟**  
بله، اما [نهاده اشتراک‌گذاری](/slides/fa/python-net/multithreading/) یک نمونه ارائه در بین چند رشته توصیه نمی‌شود. برای هر رشته یا پردازش یک نمونه جداگانه استفاده کنید.

**محدودیت‌های نسخه آزمایشی هنگام صادرات به PNG چیست؟**  
حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا اعمال یک لایسنس، [محدودیت‌های دیگر](/slides/fa/python-net/licensing/) را اعمال می‌نماید.