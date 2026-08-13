---
title: تغییر اندازه اشکال در اسلایدهای ارائه با .NET
type: docs
weight: 130
url: /fa/net/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای .NET—تنظیمات طرح اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **نمای کلی**

یکی از رایج‌ترین سوالات مشتریان Aspose.Slides برای .NET این است که چگونه شکل‌ها را تغییر اندازه دهند تا وقتی اندازه اسلاید تغییر می‌کند، داده‌ها قطع نشوند. این مقاله فنی کوتاه نشان می‌دهد چگونه این کار را انجام دهید.

## **تغییر اندازه شکل‌ها**

برای جلوگیری از عدم تراز شدن شکل‌ها هنگام تغییر اندازه اسلاید، موقعیت و ابعاد هر شکل را به‌روزرسانی کنید تا با طرح جدید اسلاید سازگار شوند.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// بارگذاری فایل ارائه.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // دریافت اندازه اصلی اسلاید.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // تغییر اندازه اسلاید بدون مقیاس‌بندی اشکال موجود.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // دریافت اندازه جدید اسلاید.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // تغییر اندازه و موقعیت اشکال در هر اسلاید.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // مقیاس‌بندی اندازه شکل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // مقیاس‌بندی موقعیت شکل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
اگر اسلاید حاوی جدول باشد، کد بالا به‌درستی کار نخواهد کرد. در این صورت، باید هر سلول جدول را تغییر اندازه داد.
{{% /alert %}}

از کد زیر در سمت خود برای تغییر اندازه اسلایدهایی که شامل جدول هستند استفاده کنید. برای جدول‌ها، به‌جای عرض و ارتفاع کلی شکل، ارتفاع ردیف‌ها و عرض ستون‌های جداگانه را مقیاس‌بندی کنید—اعمال هر دو باعث مقیاس‌بندی دوباره جدول و خارج شدن آن از اسلاید می‌شود.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // دریافت اندازه اصلی اسلاید.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // تغییر اندازه اسلاید بدون مقیاس‌بندی اشکال موجود.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // دریافت اندازه جدید اسلاید.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // مقیاس‌بندی اندازه شکل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // مقیاس‌بندی موقعیت شکل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // مقیاس‌بندی اندازه شکل.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // مقیاس‌بندی موقعیت شکل.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // مقیاس‌بندی اندازه جدول از طریق ردیف‌ها و ستون‌ها.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // مقیاس‌بندی اندازه شکل.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // مقیاس‌بندی موقعیت شکل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

### چرا شکل‌ها پس از تغییر اندازه اسلاید خراب یا قطع می‌شوند؟

هنگام تغییر اندازه اسلاید، شکل‌ها موقعیت و اندازه اولیه خود را حفظ می‌کنند مگر اینکه مقیاس به‌طور صریح تغییر کند. این می‌تواند منجر به برش محتوا یا عدم تراز شدن شکل‌ها شود.

### آیا کد ارائه شده برای همه انواع شکل‌ها کار می‌کند؟

مثال پایه برای اکثر انواع شکل‌ها (جعبه‌های متن، تصویرها، نمودارها و غیره) کار می‌کند. اما برای جدول‌ها، باید ردیف‌ها و ستون‌ها را جداگانه پردازش کنید، زیرا ارتفاع و عرض جدول توسط ابعاد سلول‌های جداگانه تعیین می‌شود.

### چگونه جدول‌ها را هنگام تغییر اندازه اسلاید تغییر اندازه دهم؟

باید بر تمام ردیف‌ها و ستون‌های جدول حلقه بزنید و ارتفاع و عرض آنها را به‌صورت تناسبی تغییر اندازه دهید، همان‌طور که در مثال دوم کد نشان داده شده است.

### آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای چیدمان کار می‌کند؟

بله، اما باید همچنین بر [مسترها](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/masters/) و [اسلایدهای‌چیدمان](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/layoutslides/) حلقه بزنید و همان منطق مقیاس‌بندی را بر شکل‌های آنها اعمال کنید تا سازگاری در تمام ارائه حفظ شود.

### آیا می‌توانم جهت اسلاید (پرتره/لنداسکپ) را همراه با تغییر اندازه تغییر دهم؟

بله. می‌توانید [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/orientation/) را تنظیم کنید تا جهت را تغییر دهید. مطمئن شوید که منطق مقیاس‌بندی را به‌طور مناسب تنظیم کنید تا طرح حفظ شود.

### آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟

Aspose.Slides از اندازه‌های سفارشی پشتیبانی می‌کند، اما اندازه‌های بسیار بزرگ ممکن است بر عملکرد یا سازگاری با برخی نسخه‌های PowerPoint تأثیر بگذارد.

### چگونه می‌توانم از خراب شدن شکل‌های با نسبت عرض–ارتفاع ثابت جلوگیری کنم؟

می‌توانید قبل از مقیاس‌بندی، ویژگی `AspectRatioLocked` شکل را بررسی کنید. اگر قفل باشد، به‌جای مقیاس‌بندی جداگانه، عرض یا ارتفاع را به‌صورت نسبی تنظیم کنید.