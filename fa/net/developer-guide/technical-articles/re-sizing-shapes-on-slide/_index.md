---
title: تغییر اندازه اشکال در اسلایدهای ارائه در .NET
type: docs
weight: 130
url: /fa/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /fa/net/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازهٔ شکل
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای .NET تغییر اندازه دهید—تنظیمات طرح اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **بررسی کلی**

هنگامی که اندازهٔ اسلاید یک ارائه را تغییر می‌دهید، ممکن است نیاز داشته باشید شکل‌ها را نیز برای سازگار شدن با ابعاد جدید تغییر اندازه و موقعیت‌دهی کنید. این مقاله نحوه مقیاس‌بندی دستی شکل‌ها و نحوهٔ مدیریت جداول در اسلایدها، ماسترها و طرح‌بندی‌ها را نشان می‌دهد.

## **تغییر اندازهٔ اشکال**

برای حفظ موقعیت و اندازهٔ نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع متناظر را بر روی مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول یک ارائه را بارگذاری می‌کند که اسلایدهای آن حاوی جدول نیستند، اندازهٔ اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) همراه با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) استفاده می‌کند تا حلقهٔ بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد اشکال بر حسب پوینت اندازه‌گیری می‌شود. نسبت‌های متفاوت عرض و ارتفاع می‌توانند شکل‌ها را مخدوش کنند و تغییر ابعاد یک شکل اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// محاسبهٔ عوامل مقیاس افقی و عمودی مستقل.
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
جداول نیاز به مدیریت جداگانه دارند: به‌جای تعیین عرض و ارتفاع کلی جدول، عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید. اگر محتوای سلول نیاز به فضای بیشتری داشته باشد، ارتفاع ردیف‌ها ممکن است بزرگ‌تر از مقدار درخواستی باقی بمانند.
{{% /alert %}}

مثال دوم از جداول پشتیبانی می‌کند و قبل از ذخیرهٔ ارائهٔ تغییر اندازه‌دار، اشکال را روی ماسترها، طرح‌بندی‌ها و اسلایدهای منفرد پردازش می‌کند. کمک‌کنندهٔ آن هر [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) را با مقیاس‌بندی [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) و [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی جداگانهٔ ابعاد کلی آن مقیاس می‌دهد.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// محاسبهٔ عوامل مقیاس افقی و عمودی مستقل.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// تغییر اندازهٔ اشکالی که روی ماست‌ها و طرح‌بندی‌ها و همچنین اسلایدهای جداگانه تعریف شده‌اند.
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

## **سوالات متداول**

**چرا پس از تغییر اندازه اسلاید، شکل‌ها مخدوش یا برش خورده می‌شوند؟**

اگر اندازهٔ اسلاید را بدون مقیاس‌بندی شکل‌ها تغییر دهید، آن‌ها موقعیت و ابعاد اصلی خود را حفظ می‌کنند و ممکن است خارج از حدود اسلاید گسترش یابند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند شکل‌ها را مخدوش کند.

**آیا کد ارائه‌شده برای تمام انواع شکل‌ها کار می‌کند؟**

مثال اول مرزهای شکل را مستقیماً تغییر می‌دهد و برای اسلایدهای بدون جدول در نظر گرفته شده است. مثال دوم جداول را به‌طور جداگانه مدیریت می‌کند. طرح‌بندی حاصل را، به‌خصوص متن و جداول، بررسی کنید، زیرا این مثال‌ها اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازه اسلاید، جداول را نیز تغییر اندازه دهم؟**

عرض ستون‌ها را با نسبت عرض مقیاس‌بندی کنید و ارتفاع حداقل ردیف‌ها را با نسبت ارتفاع، سپس موقعیت جدول را مقیاس‌بندی کنید، همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای ماستر و طرح‌بندی نیز اعمال می‌شود؟**

بله. مثال دوم از طریق [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) و [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) هر ماستر می‌گردد و همان منطق تغییر اندازه را بر روی شکل‌های آن‌ها اعمال می‌کند.

**آیا می‌توانم جهت اسلاید (پرتره/لندسکیپ) را همراه با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازهٔ اسلاید و پیش از خواندن ابعاد هدف، [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) را تنظیم کنید تا عوامل مقیاس‌گذاری جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

شما می‌توانید ابعاد سفارشی اسلاید را با استفاده از [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) مشخص کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که فایل را باز می‌کند بستگی دارد.

**چگونه می‌توانم از مخدوش شدن اشکالی که نسبت ابعاد ثابت دارند جلوگیری کنم؟**

از یک عامل مقیاس یکسان برای عرض و ارتفاع استفاده کنید. برای سازگاری طرح‌بندی اصلی با ابعاد جدید اسلاید، نسبت کوچکتر بین نسبت عرض و ارتفاع را برای هر دو بعد و موقعیت به کار ببرید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است فضایی نامستخدم در یک لبه باقی بماند.