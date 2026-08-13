---
title: تبدیل اسلایدهای PowerPoint به PNG در .NET
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/net/convert-powerpoint-to-png/
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
- ذخیره PPT به عنوان PNG
- ذخیره PPTX به عنوان PNG
- صادر کردن PPT به PNG
- صادر کردن PPTX به PNG
- .NET
- C#
- Aspose.Slides
description: "ارائه‌های PowerPoint را به سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید با Aspose.Slides برای .NET، تضمین‌کننده نتایج دقیق و خودکار."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های پاورپوینت را به تصاویر PNG با استفاده از Aspose.Slides تبدیل کنید. این مقاله نشان می‌دهد چگونه فایل‌های ارائه را در قالب‌های PPT، PPTX و ODP بارگذاری کنید، اسلایدها را به صورت تصویر رندر کنید و نتایج را در قالب PNG ذخیره کنید.

همچنین مقاله نشان می‌دهد چگونه می‌توانید تصاویر PNG تولید شده را با تنظیم مقادیر مقیاس یا تعیین عرض و ارتفاع موردنظر، سفارشی‌سازی کنید.

## **تبدیل پاورپوینت به PNG**

این مراحل را دنبال کنید:

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. شی اسلاید را از مجموعه [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/properties/slides) تحت رابط [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide) دریافت کنید. 
3. از روش [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) برای رندر هر اسلاید با مقیاس مورد نیاز استفاده کنید. 
4. از روش [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.ipresentation/save/methods/5) برای ذخیره تصویر کوچک اسلاید به قالب PNG استفاده کنید. 

این کد C# نشان می‌دهد چگونه یک ارائه پاورپوینت را به PNG تبدیل کنید. شیء Presentation می‌تواند فایل‌های PPT، PPTX، ODP و غیره را بارگذاری کند، سپس هر اسلاید در شیء Presentation به قالب PNG یا سایر قالب‌های تصویری تبدیل می‌شود.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**نکته:** آرگومان‌های مقیاس `1f, 1f` هر اسلاید را با اندازه کامل رندر می‌کنند، بنابراین یک اسلاید 720×540 pt تصویری 720×540 پیکسل تولید می‌کند. بارگذاری بدون پارامتر [GetImage()](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) یک تصویر کوچک پیش‌نمایش بسیار کوچکتر برمی‌گرداند.
{{% /alert %}} 

## **تبدیل پاورپوینت به PNG با ابعاد سفارشی**

اگر می‌خواهید فایل‌های PNG با مقیاس خاصی دریافت کنید، می‌توانید مقادیر `desiredX` و `desiredY` را تنظیم کنید، که ابعاد تصویر کوچک خروجی را تعیین می‌کنند. 

این کد در C# عملیات توضیح داده شده را نشان می‌دهد:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **تبدیل پاورپوینت به PNG با اندازه سفارشی**

اگر می‌خواهید فایل‌های PNG با اندازه خاصی دریافت کنید، می‌توانید آرگومان‌های `width` و `height` مورد نظر خود را برای `imageSize` ارسال کنید. 

این کد نشان می‌دهد چگونه یک پاورپوینت را به PNG تبدیل کنید در حالی که اندازه تصاویر را مشخص می‌کنید: 

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **سوالات متداول**

### چگونه می‌توانم فقط یک شکل خاص (مانند نمودار یا تصویر) را به‌جای کل اسلاید صادر کنم؟

Aspose.Slides از [ایجاد تصاویر کوچک برای شکل‌های منفرد](/slides/fa/net/create-shape-thumbnails/) پشتیبانی می‌کند؛ می‌توانید یک شکل را به تصویر PNG رندر کنید.

### آیا تبدیل موازی بر روی سرور پشتیبانی می‌شود؟

بله، اما [به‌اشتراک‌نگذارید](/slides/fa/net/multithreading/) یک شیء Presentation را بین رشته‌ها. برای هر رشته یا فرآیند از یک نمونه جداگانه استفاده کنید.

### محدودیت‌های نسخه آزمایشی هنگام خروجی به PNG چه هستند؟

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا اعمال کردن یک لایسنس، [محدودیت‌های دیگر](/slides/fa/net/licensing/) را اعمال می‌کند.