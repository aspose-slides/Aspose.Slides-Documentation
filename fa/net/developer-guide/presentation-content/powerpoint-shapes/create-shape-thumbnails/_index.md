---
title: ایجاد تصاویر بندانگشتی اشکال ارائه در .NET
linktitle: تصاویر بندانگشتی اشکال
type: docs
weight: 70
url: /fa/net/create-shape-thumbnails/
keywords:
- تصویر بندانگشتی شکل
- تصویر شکل
- رندر شکل
- رندرینگ شکل
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تولید تصاویر بندانگشت با کیفیت بالا از اشکال اسلایدهای PowerPoint با Aspose.Slides برای .NET – به‌راحتی ایجاد و صادرات تصاویر بندانگشت ارائه."
---
## **مقدمه**

Aspose.Slides برای .NET برای ایجاد فایل‌های ارائه استفاده می‌شود که هر صفحه‌ای یک اسلاید است. این اسلایدها می‌توانند با باز کردن فایل‌های ارائه با Microsoft PowerPoint مشاهده شوند. اما گاهی اوقات، توسعه‌دهندگان ممکن است نیاز داشته باشند تصاویر اشکال را به‌صورت جداگانه در یک نمایشگر تصویر ببینند. در چنین مواردی، Aspose.Slides برای .NET به شما کمک می‌کند تا تصاویر بندانگشتی از اشکال اسلاید تولید کنید. نحوه استفاده از این ویژگی در این مقاله توضیح داده شده است.

این مقاله توضیح می‌دهد چگونه می‌توان تصاویر بندانگشتی اسلاید را به روش‌های مختلف تولید کرد:

- تولید تصویر بندانگشتی یک شکل داخل اسلاید.
- تولید تصویر بندانگشتی یک شکل اسلاید با ابعاد تعریف‌شده توسط کاربر.
- تولید تصویر بندانگشتی یک شکل در مرزهای ظاهر شکل.

## **تولید تصویر بندانگشتی یک شکل از یک اسلاید**
برای تولید تصویر بندانگشتی یک شکل از هر اسلاید با استفاده از Aspose.Slides برای .NET:

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن دریافت کنید.
1. تصویر بندانگشتی شکل اسلاید مرجع را با مقیاس پیش‌فرض دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر تصویر بندانگشتی شکل را تولید می‌کند.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **تولید تصویر بندانگشتی با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر**
برای تولید تصویر بندانگشتی شکل هر اسلاید با استفاده از Aspose.Slides برای .NET:

1. یک شیء از کلاس `Presentation` ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر یک تصویر بندانگشتی با عامل مقیاس‌گذاری تعریف‌شده توسط کاربر تولید می‌کند.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // مقیاس‌گذاری در محورهای X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **ایجاد تصویر بندانگشتی ظاهر شکل مبتنی بر مرزها**
این روش برای ایجاد تصاویر بندانگشتی از اشکال به توسعه‌دهندگان امکان می‌دهد تصویر بندانگشتی را در مرزهای ظاهر شکل تولید کنند. تمام افکت‌های شکل در نظر گرفته می‌شود. تصویر بندانگشتی تولید شده توسط مرزهای اسلاید محدود می‌شود. برای تولید تصویر بندانگشتی هر شکل اسلاید در مرز ظاهر آن، کد نمونه زیر را استفاده کنید:

1. یک شیء از کلاس `Presentation` ایجاد کنید.
1. مرجع هر اسلاید را با استفاده از شناسه یا اندیس آن دریافت کنید.
1. تصویر بندانگشتی اسلاید مرجع را با مرزهای شکل به‌عنوان ظاهر دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

مثال زیر یک تصویر بندانگشتی را ایجاد می‌کند.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // مقیاس‌گذاری در محورهای X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **پرسش‌های متداول**

**چه فرمت‌های تصویری می‌توان هنگام ذخیره‌سازی تصاویر بندانگشتی اشکال استفاده کرد؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/)، و سایر فرمت‌ها. اشکال همچنین می‌توانند به‌صورت [خروجی به‌صورت SVG برداری](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/writeassvg/) با ذخیره محتوای شکل به‌صورت SVG صادر شوند.

**تفاوت بین مرزهای Shape و Appearance هنگام رندر کردن تصویر بندانگشتی چیست؟**

`Shape` از هندسه شکل استفاده می‌کند؛ `Appearance` اثرات [visual effects](/slides/fa/net/shape-effect/) (سایه‌ها، درخشش‌ها و غیره) را در نظر می‌گیرد.

**اگر یک شکل به‌عنوان مخفی علامت‌گذاری شود چه اتفاقی می‌افتد؟ آیا هنوز به‌عنوان تصویر بندانگشتی رندر می‌شود؟**

یک شکل مخفی همچنان بخشی از مدل است و می‌تواند رندر شود؛ پرچم مخفی صرفاً نمایش اسلایدشو را تحت‌اثر قرار می‌دهد اما از تولید تصویر شکل جلوگیری نمی‌کند.

**آیا اشکال گروهی، نمودارها، SmartArt و سایر اشیای پیچیده پشتیبانی می‌شوند؟**

بله. هر شیئی که به‌عنوان [Shape](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/) نمایش داده شود (از جمله [GroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/)، و [SmartArt](https://reference.aspose.com/slides/fa/net/aspose.slides.smartart/smartart/)) می‌تواند به‌صورت تصویر بندانگشتی یا SVG ذخیره شود.

**آیا فونت‌های نصب‌شده در سیستم بر کیفیت تصاویر بندانگشتی اشکال متنی تأثیر می‌گذارند؟**

بله. باید [فونت‌های مورد نیاز را فراهم کنید](/slides/fa/net/custom-font/) (یا [جایگزینی فونت‌ها را پیکربندی کنید](/slides/fa/net/font-substitution/)) تا از بازگشت‌های ناخواسته و بازچیدمان متن جلوگیری شود.