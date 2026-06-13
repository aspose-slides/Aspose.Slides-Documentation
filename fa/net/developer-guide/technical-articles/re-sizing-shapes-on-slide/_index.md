---
title: "تغییر اندازه اشکال در اسلایدهای ارائه در .NET"
type: docs
weight: 130
url: /fa/net/re-sizing-shapes-on-slide/
keywords:
- "تغییر اندازه شکل"
- "تغییر اندازهٔ شکل"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "به‌راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای .NET—تنظیمات چیدمان اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **مرور کلی**

یکی از رایج‌ترین سؤالات مشتریان Aspose.Slides برای .NET این است که چگونه اشکال را تغییر اندازه دهند به‌گونه‌ای که هنگام تغییر اندازه اسلاید، داده‌ها بریده نشوند. این مقاله فنی کوتاه نشان می‌دهد چگونه این کار را انجام دهید.

## **تغییر اندازه اشکال**

برای جلوگیری از مغشوش شدن اشکال هنگام تغییر اندازه اسلاید، موقعیت و ابعاد هر شکل را به‌روزرسانی کنید تا با طرح جدید اسلاید مطابقت داشته باشند.

```c#
// بارگذاری فایل ارائه.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // دریافت اندازه اسلاید اصلی.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // تغییر اندازه اسلاید بدون مقیاس‌گذاری اشکال موجود.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // دریافت اندازه جدید اسلاید.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // تغییر اندازه و موقعیت‌گذاری مجدد اشکال در هر اسلاید.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // مقیاس‌گذاری اندازه شکل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // مقیاس‌گذاری موقعیت شکل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
اگر یک اسلاید شامل جدول باشد، کد بالا به‌درستی کار نخواهد کرد. در این حالت باید اندازه هر سلول جدول به‌صورت جداگانه تنظیم شود.
{{% /alert %}}

از کد زیر در پروژه خود برای تغییر اندازه اسلایدهایی که شامل جداول هستند استفاده کنید. برای جداول، تنظیم عرض یا ارتفاع یک مورد خاص است: باید ارتفاع ردیف‌ها و عرض ستون‌ها را به‌صورت جداگانه تنظیم کنید تا اندازه کلی جدول تغییر کند.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // دریافت اندازهٔ اولیهٔ اسلاید.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // تغییر اندازه اسلاید بدون مقیاس‌گذاری اشکال موجود.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // دریافت اندازهٔ جدید اسلاید.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // مقیاس‌گذاری اندازهٔ شکل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // مقیاس‌گذاری موقعیت شکل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // مقیاس‌گذاری اندازهٔ شکل.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // مقیاس‌گذاری موقعیت شکل.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // مقیاس‌گذاری اندازهٔ شکل.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // مقیاس‌گذاری موقعیت شکل.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **پرسش‌های متداول**

**چرا پس از تغییر اندازه اسلاید، اشکال کشیده یا بریده می‌شوند؟**

هنگام تغییر اندازه اسلاید، اشکال موقعیت و اندازهٔ اولیهٔ خود را حفظ می‌کنند مگر اینکه مقیاس به‌صورت صریح تغییر داده شود. این می‌تواند منجر به برش محتوا یا ناهماهنگی اشکال شود.

**آیا کد ارائه‌شده برای تمام انواع اشکال کار می‌کند؟**

مثال پایه برای اکثر انواع اشکال (جعبه‌های متن، تصاویر، نمودارها و غیره) کار می‌کند. اما برای جداول، باید ردیف‌ها و ستون‌ها را به‌صورت جداگانه مدیریت کنید، زیرا ارتفاع و عرض جدول توسط ابعاد سلول‌های فردی تعیین می‌شود.

**چگونه هنگام تغییر اندازه اسلاید، جداول را تغییر اندازه دهم؟**

باید در تمام ردیف‌ها و ستون‌های جدول حلقه بزنید و ارتفاع و عرض آن‌ها را به‌صورت متناسب تنظیم کنید، همان‌طور که در مثال دوم کد نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای اصلی (Master) و اسلایدهای طرح‌بندی (Layout) نیز کار می‌کند؟**

بله، اما باید همچنین در [Masters](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/masters/) و [LayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/layoutslides/) حلقه بزنید و منطق مقیاس‌بندی را بر روی اشکال آن‌ها اعمال کنید تا سازگاری در تمام ارائه حفظ شود.

**آیا می‌توانم همراه با تغییر اندازه، جهت اسلاید (عمودی/افقی) را نیز تغییر دهم؟**

بله. می‌توانید با تنظیم [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/orientation/) جهت اسلاید را تغییر دهید. اطمینان حاصل کنید که منطق مقیاس‌بندی را به‌طور متناسب تنظیم کنید تا طرح حفظ شود.

**آیا محدودیتی برای اندازهٔ اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

Aspose.Slides از اندازه‌های سفارشی پشتیبانی می‌کند، اما اندازه‌های بسیار بزرگ ممکن است بر عملکرد یا سازگاری با برخی نسخه‌های PowerPoint تأثیر بگذارد.

**چگونه می‌توانم از کشیده شدن اشکال با نسبت ابعاد ثابت جلوگیری کنم؟**

قبل از مقیاس‌بندی می‌توانید ویژگی `AspectRatioLocked` شکل را بررسی کنید. اگر قفل شده باشد، به‌جای مقیاس‌بندی جداگانهٔ عرض و ارتفاع، آنها را به‌صورت متناسب تنظیم کنید.