---
title: تغییر اندازه اشکال در اسلایدهای ارائه با .NET
type: docs
weight: 130
url: /fa/net/resizing-shapes-on-slide/
aliases:
  - /fa/net/re-sizing-shapes-on-slide/
  /net/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازهٔ شکل
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای .NET تغییر اندازه دهید—تنظیمات طرح‌بندی اسلایدها را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **مرور کلی**

هنگامی که اندازه اسلاید یک ارائه را تغییر می‌دهید، ممکن است نیاز داشته باشید شکل‌ها را باز اندازه‌گیری و مکان‌یابی کنید تا با ابعاد جدید منطبق شوند. این مقاله نشان می‌دهد چطور شکل‌ها را به صورت دستی مقیاس‌بندی کنید و چطور جدول‌ها را در اسلایدها، مسترها و طرح‌بندی‌ها مدیریت کنید.

## **تغییر اندازه اشکال**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع متناظر را بر مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول ارائه‌ای را بارگذاری می‌کند که اسلایدهای آن حاوی جدول نیستند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) همراه با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) استفاده می‌کند تا حلقهٔ بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد اشکال بر حسب نقاط اندازه‌گیری می‌شود. نسبت‌های متفاوت عرض و ارتفاع می‌توانند باعث تغییر شکل اشکال شوند، و تغییر ابعاد یک شکل اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// محاسبه ضریب‌های مقیاس افقی و عمودی مستقل.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
جدول‌ها نیاز به پردازش جداگانه دارند: عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید به جای اختصاص کل عرض و ارتفاع جدول. ارتفاع ردیف‌ها ممکن است بزرگتر از مقدار درخواست‌شده باقی بماند اگر محتویات سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جدول‌ها پشتیبانی می‌کند و شکل‌ها را در مسترها و طرح‌بندی‌ها و همچنین اسلایدهای جداگانه قبل از ذخیرهٔ ارائهٔ تغییر اندازه‌داده‌شده پردازش می‌کند. ابزار کمکی آن هر [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) را با مقیاس‌بندی [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) و [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی جداگانهٔ ابعاد کلی آن مقیاس می‌دهد.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// محاسبه ضریب‌های مقیاس افقی و عمودی مستقل.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// تغییر اندازه اشکال تعریف‌شده در مسترها و طرح‌بندی‌ها و همچنین اسلایدهای جداگانه.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // ابعاد جدول توسط عرض ستون‌ها و ارتفاع ردیف‌ها کنترل می‌شود.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **پرسش‌های متداول**

**چرا پس از تغییر اندازه اسلاید، شکل‌ها خراب یا بریده می‌شوند؟**

اگر بدون مقیاس‌بندی شکل‌ها اندازه اسلاید را تغییر دهید، موقعیت و ابعاد اصلی آن‌ها حفظ می‌شود و ممکن است از حدود اسلاید فراتر بروند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند باعث تغییر شکل شود.

**آیا کد ارائه‌شده برای تمام انواع شکل‌ها کار می‌کند؟**

مثال اول به‌ طور مستقیم مرزهای شکل را تغییر می‌دهد و برای اسلایدهای بدون جدول در نظر گرفته شده است. مثال دوم جدول‌ها را جداگانه مدیریت می‌کند. طرح‌بندی حاصل را به‌ خصوص متن و جدول‌ها بررسی کنید، زیرا این مثال‌ها اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازهٔ اسلاید، جدول‌ها را باز اندازه‌گیری کنم؟**

عرض ستون‌ها را با نسبت عرض و ارتفاع حداقل ردیف‌ها را با نسبت ارتفاع مقیاس‌بندی کنید، سپس موقعیت جدول را همانند مثال دوم مقیاس دهید.

**آیا این باز اندازه‌گیری برای اسلایدهای مستر و اسلایدهای طرح‌بندی نیز کار خواهد کرد؟**

بله. مثال دوم از طریق [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) و هر [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) از مسترها پیمایش می‌کند و همان منطق باز اندازه‌گیری را بر روی شکل‌های آن‌ها اعمال می‌نماید.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با باز اندازه‌گیری تغییر دهم؟**

بله. پس از تغییر اندازهٔ اسلاید و قبل از خواندن ابعاد هدف، [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) را تنظیم کنید تا عوامل مقیاس جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازهٔ اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد سفارشی اسلاید را با [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) مشخص کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود وابسته است.

**چگونه می‌توانم از مخدوش شدن شکل‌هایی با نسبت ثابت جلوگیری کنم؟**

از همان عامل مقیاس برای عرض و ارتفاع استفاده کنید. برای متناسب کردن طرح‌بندی اصلی با ابعاد جدید اسلاید، نسبت کوچک‌تر بین عرض و ارتفاع را برای هر دو بعد و موقعیت‌ها به‌ کار ببرید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است در یک سمت فضای استفاده‌نشده باقی بگذارد.