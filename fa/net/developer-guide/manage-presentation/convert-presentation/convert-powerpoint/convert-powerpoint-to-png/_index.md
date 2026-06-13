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
- صادرات PPT به PNG
- صادرات PPTX به PNG
- .NET
- C#
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به تصاویر PNG با کیفیت بالا به‌سرعت با Aspose.Slides برای .NET، تضمین نتایج دقیق و خودکار."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را به تصاویر PNG با استفاده از Aspose.Slides تبدیل کنیم. این مقاله نشان می‌دهد چگونه فایل‌های ارائه را در قالب‌های PPT, PPTX و ODP بارگذاری کرده، اسلایدها را به عنوان تصاویر رندر کنید و نتایج را در قالب PNG ذخیره کنید.

همچنین این مقاله نحوه سفارشی‌سازی تصاویر PNG تولید شده را با تنظیم مقادیر مقیاس یا تعیین عرض و ارتفاع موردنظر نشان می‌دهد.

## **تبدیل PowerPoint به PNG**

این مراحل را دنبال کنید:

1. یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. شی اسلاید را از مجموعه [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/properties/slides) تحت رابط [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide) دریافت کنید.
3. از متد [ISlide.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) برای دریافت تصویر کوچک هر اسلاید استفاده کنید.
4. از متد [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.ipresentation/save/methods/5) برای ذخیره تصویر کوچک اسلاید در قالب PNG استفاده کنید.

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را به PNG تبدیل کنید. شی Presentation می‌تواند فایل‌های PPT، PPTX، ODP و غیره را بارگذاری کند، سپس هر اسلاید در این شی به قالب PNG یا سایر قالب‌های تصویری تبدیل می‌شود.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

اگر می‌خواهید فایل‌های PNG را با مقیاس خاصی به‌دست آورید، می‌توانید مقادیر `desiredX` و `desiredY` را تنظیم کنید که ابعاد تصویر کوچک حاصل را تعیین می‌کنند.

این کد در C# عملیات توضیح داده‌شده را نشان می‌دهد:

```c#
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

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

اگر می‌خواهید فایل‌های PNG را با اندازه خاصی به‌دست آورید، می‌توانید آرگومان‌های `width` و `height` موردنظر خود را برای `imageSize` ارسال کنید.

این کد نشان می‌دهد چگونه یک PowerPoint را به PNG تبدیل کنید در حالی که اندازه تصاویر را مشخص می‌کنید:

```c#
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

## **سؤال‌های متداول**

**چگونه می‌توانم تنها یک شکل خاص (مانند نمودار یا تصویر) را به‌جای کل اسلاید صادر کنم؟**

Aspose.Slides از [تولید تصویر کوچک برای اشکال منفرد](/slides/fa/net/create-shape-thumbnails/) پشتیبانی می‌کند؛ می‌توانید یک شکل را به تصویر PNG رندر کنید.

**آیا تبدیل موازی بر روی سرور پشتیبانی می‌شود؟**

بله، اما [نشر نشدن](/slides/fa/net/multithreading/) یک نمونه Presentation بین چندین رشته مجاز نیست. برای هر رشته یا پردازش یک نمونه جداگانه استفاده کنید.

**محدودیت‌های نسخه آزمایشی هنگام صادر کردن به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا اعمال یک لایسنس [محدودیت‌های دیگر](/slides/fa/net/licensing/) را اعمال می‌کند.