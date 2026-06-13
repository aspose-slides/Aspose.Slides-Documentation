---
title: ژنراتور اسلاید چندزبانه مبتنی بر هوش مصنوعی
linktitle: ژنراتور مبتنی بر هوش مصنوعی
type: docs
weight: 40
url: /fa/python-net/ai/generator/
keywords:
- ارائه چندزبانه
- اسلاید چندزبانه
- ژنراتور ارائه مبتنی بر هوش مصنوعی
- ژنراتور اسلاید هوش مصنوعی
- ویژگی مبتنی بر هوش مصنوعی
- عامل هوش مصنوعی
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "اسلایدهای چندزبانه را از متن با Aspose.Slides برای Python تولید کنید. قالب خود را اعمال کرده و مجموعه‌های صیقلی را به PowerPoint و OpenDocument صادر کنید. بیشتر بدانید."
---
## **مقدمه**

Aspose.Slides یک ویژگی جدید مبتنی بر هوش مصنوعی به نام Presentation Generator معرفی می‌کند که به توسعه‌دهندگان امکان می‌دهد بطور خودکار ارائه‌های PowerPoint ساختارمند و با کیفیت را از ورودی‌های متنی ساده مانند توصیف موضوع، خلاصه‌ها، نقل‌قول‌ها یا نقطه‌های فهرست تولید کنند.

کاربران می‌توانند سطح جزئیات محتوا را تنظیم کرده و به‌صورت اختیاری یک قالب ارائه سفارشی را برای تعریف طراحی بصری اعمال کنند.

در حال حاضر، AI Presentation Generator محتوا را با استفاده از بلوک‌های متنی، فهرست‌های گلوله‌ای و جدول‌ها ساختار می‌دهد. تولید تصویر هنوز پشتیبانی نمی‌شود؛ با این حال، می‌توان تصاویر را پس از آن با ابزارهای Aspose.Slides یا به‌صورت دستی اضافه کرد.

خروجی یک ارائه کامل PowerPoint است که می‌تواند به‌همین شکل استفاده شود یا به هر فرمت پشتیبانی‌شده توسط API Aspose.Slides صادر شود. اگرچه این ژنراتور نتایج با کیفیتی تولید می‌کند، ممکن است برای برآورده کردن نیازهای خاص، کمی ویرایش پس‌از تولید لازم باشد.

## **نحوه کار**

Aspose.Slides مدل‌های هوش مصنوعی داخلی ندارد؛ در عوض، با خدمات هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این یکپارچه‌سازی توسط کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/slidesaiagent/) انجام می‌شود که از یک پیاده‌سازی کلاس [IAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/iaiwebclient/) برای ارتباط با مدل هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) پیش‌ساخته استفاده کنید که به API OpenAI وصل می‌شود، یا یک پیاده‌سازی سفارشی از [IAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/iaiwebclient/) برای کار با ارائه‌دهنده هوش مصنوعی یا مدل زبانی دیگری فراهم کنید. Aspose.Slides تمام ارتباطات با سرویس هوش مصنوعی را مدیریت کرده و پاسخ‌های هوش مصنوعی را پردازش می‌کند تا اسلایدها را تولید کند. توجه داشته باشید که API OpenAI یک سرویس پرداختی است و برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) نیاز به حساب کاربری و کلید API دارید.

## **بیایید کد بنویسیم**

### **مثال 1**

این مثال نشان می‌دهد چگونه می‌توان یک ارائه درباره موضوع Aspose.Slides با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) پیش‌ساخته تولید کرد.

```py
# یک نمونه از OpenAIWebClient ایجاد کنید، پیاده‌سازی پیش‌فرض مشتری وب OpenAI.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

    # یک نمونه از SlidesAIAgent ایجاد کنید که دسترسی به ویژگی‌های مبتنی بر هوش مصنوعی را فراهم می‌کند.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # دستورالعمل برای تولید ارائه را تعریف کنید.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # یک ارائه با مقدار محتوای متوسط بر اساس دستورالعمل تولید کنید.
    with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.MEDIUM) as presentation:

        # ارائه تولید شده را به‌عنوان فایل PowerPoint (.pptx) در دیسک محلی ذخیره کنید.
        presentation.save("Aspose.Slides.NET.pptx", slides.export.SaveFormat.PPTX)
```

### **مثال 2**

مثال زیر بارگذاری‌های متد [generate_presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/slidesaiagent/generate_presentation/#str-asposeslidesaipresentationcontentamounttype-asposeslidesipresentation) را نشان می‌دهد. در این حالت، «master presentation» کاربر استفاده می‌شود.

```py
# HttpClient را به سازنده OpenAIWebClient پاس بدهید.
with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId") as ai_web_client:

    # یک نمونه از SlidesAIAgent ایجاد کنید.
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

    # دستورالعمل برای تولید ارائه را تعریف کنید.
    instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors."

    # یک ارائه اصلی را از دیسک محلی بارگیری کنید تا به‌عنوان قالب طراحی استفاده شود.
    with slides.Presentation("masterPresentation.pptx") as masterPresentation:

        # یک ارائه دقیق با استفاده از دستورالعمل و قالب اصلی تولید کنید.
        with ai_agent.generate_presentation(instruction, slides.ai.PresentationContentAmountType.DETAILED, masterPresentation) as presentation:

            # ارائه تولید شده را به‌عنوان PDF ذخیره کنید.
            presentation.save("Aspose.Slides.NET.pdf", slides.export.SaveFormat.PDF)
```

## **مزایای کلیدی**

ژنراتور جدید AI Presentation Generator در Aspose.Slides روشی سریع و قابل انعطاف برای تولید مجموعه اسلایدهای ساختار یافته از دعوت‌نامه‌های متنی ساده فراهم می‌کند. با پشتیبانی از قالب‌های سفارشی، می‌توان آن را به‌صورت یکپارچه در انواع برنامه‌ها ادغام کرد.

موارد استفاده رایج شامل ایجاد ارائه‌های بازاریابی، مطالب آموزشی، گزارش‌های مشتری و اسلایدهای داخلی سازمان است. اگرچه تولید تصویر هنوز پشتیبانی نمی‌شود، این ابزار پایه‌ای قوی برای خودکارسازی ایجاد ارائه‌ها ارائه می‌دهد و انتظار می‌رود در آینده ارتقاهای بیشتری داشته باشد.