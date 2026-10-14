---
title: تبدیل اسلایدهای PowerPoint به PNG در Python
linktitle: PowerPoint به PNG
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
description: "ارائه‌های PowerPoint و OpenDocument را به سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید با Aspose.Slides برای Python از طریق .NET، به‌طوری که نتایج دقیق و خودکار به‌دست آید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه اسلایدهای ارائه را به تصاویر PNG تبدیل کنید با استفاده از Aspose.Slides برای Python از طریق .NET. می‌توانید ارائه‌ها را در قالب‌هایی مانند PPT، PPTX و ODP بارگذاری کنید، هر اسلاید را رندر کنید و به عنوان تصویر PNG جداگانه ذخیره کنید.

مثال‌های زیر نمایش می‌دهند که چگونه رندر کردن با مقیاس پیش‌فرض، افزایش مقیاس، تعیین ابعاد خروجی به پیکسل و انتخاب سبک رندر گرادیان.

## **تبدیل PowerPoint به PNG**

یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بارگذاری کنید و از طریق مجموعه [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) به اسلایدهای آن دسترسی پیدا کنید. مثال هر اسلاید را با استفاده از [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) بدون پارامتر برای ایجاد تصویر بندانگشتی رندر می‌کند. سپس با فراخوانی [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) همراه با [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) هر اسلاید رندر شده را به عنوان تصویر PNG ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
بارگذاری بدون پارامتر [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) با مقیاس 0.2 رندر می‌کند. به‌عنوان مثال، اسلایدی با اندازه 720 × 540 نقطه یک تصویر بندانگشتی 144 × 108 پیکسل تولید می‌کند. برای کنترل ابعاد خروجی، از بارگذاری‌های با عوامل مقیاس یا اندازه تصویر صریح که در زیر نشان داده شده استفاده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

عامل‌های مقیاس افقی و عمودی را به [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) پاس می‌دهید تا ابعاد رندر شده را کنترل کنید. در این مثال، هر دو عامل برابر ۲ هستند، بنابراین اسلایدی با اندازه 720 × 540 نقطه تصویر 1440 × 1080 پیکسل تولید می‌کند. عوامل مقیاس برابر نسبت تصویر اسلاید را حفظ می‌کنند. هر تصویر با استفاده از [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) در قالب PNG ذخیره می‌شود.
```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

برای تعیین ابعاد خروجی برحسب پیکسل، به جای عوامل مقیاس یک اندازه را به [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) پاس می‌دهید. این مثال هر اسلاید را در 960 × 720 پیکسل رندر می‌کند و نتیجه را با [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) ذخیره می‌نماید. ابعادی را انتخاب کنید که نسبت تصویر اسلاید را حفظ کنند تا از کشیده شدن تصویر جلوگیری شود.
```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **انتخاب سبک رندر گرادیان**

فرض کنید اسلایدی دارای پرکن‌های گرادیان باشد، اما انتقال‌ها در PNG استخراج شده روشن‌تر یا متفاوت از آنچه در PowerPoint می‌بینید است. می‌توانید از ویژگی [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) کلاس [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) برای انتخاب نحوه رندر کردن گرادیان‌ها استفاده کنید.

فایل [gradient-styles.pptx](gradient-styles.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اولین اسلاید آن شامل دو گرادیان خطی است: از فیروزه‌ای به نارنجی در بالا و از آبی به زرد در پایین. هر گرادیان دو توقف دارد، در 0٪ و 100٪.

مثال زیر این ارائه را بارگذاری می‌کند و همان اسلاید اول را در هر دو حالت با استفاده از [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) رندر می‌نماید.
```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

تصاویر زیر خروجی اسلاید یکسان را نشان می‌دهند، با هر دو گرادیان در هر تصویر:

| Default | PowerPointUI |
| --- | --- |
| ![گرادیان‌های فیروزه‌ای به نارنجی و آبی به زرد رندر شده با Default](gradient-Default.png) | ![همان گرادیان‌ها رندر شده با PowerPointUI](gradient-PowerPointUI.png) |

در این مثال، `DEFAULT` رنگ‌های میانی روشن‌تری تولید می‌کند، در حالی که `POWER_POINT_UI` رنگ‌های میانی تیره‌تری تولید می‌کند. تفاوت بستگی به رنگ‌ها و توقف‌ها در گرادیان دارد.

زمانی که خروجی استاندارد Aspose.Slides نیازهای شما را برآورده می‌کند، `DEFAULT` را انتخاب کنید. وقتی اولویت شما تطابق ظاهر در PowerPoint است، `POWER_POINT_UI` را امتحان کنید. هر دو خروجی را با نتیجه مورد نظر مقایسه کنید؛ هیچ‌یک از حالت‌ها به‌صورت کلی برتر نیستند.

## **پرسش‌های متداول**

**چگونه می‌توانم یک شکل خاص، مانند یک نمودار یا تصویر، به‌جای کل اسلاید صادر کنم؟**

Aspose.Slides از [تولید تصویر بندانگشتی برای اشکال فردی](/slides/fa/python-net/create-shape-thumbnails/) پشتیبانی می‌کند و به شما اجازه می‌دهد یک شکل را به‌عنوان تصویر PNG رندر کنید.

**آیا تبدیل موازی در سرور پشتیبانی می‌شود؟**

بله. برای هر رشته یا پردازش یک نمونه ارائه جداگانه استفاده کنید؛ [از به‌اشتراک‌گذاری یک نمونه بین رشته‌ها خودداری کنید](/slides/fa/python-net/multithreading/).

**محدودیت‌های حالت ارزیابی هنگام خروجی به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا اعمال یک لایسنس [محدودیت‌های دیگر](/slides/fa/python-net/licensing/) را اعمال می‌نماید.