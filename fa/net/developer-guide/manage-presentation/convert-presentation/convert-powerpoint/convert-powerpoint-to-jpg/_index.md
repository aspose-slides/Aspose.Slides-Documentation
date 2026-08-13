---
title: تبدیل PPT و PPTX به JPG در .NET
linktitle: PowerPoint به JPG
type: docs
weight: 60
url: /fa/net/convert-powerpoint-to-jpg/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به JPG
- ارائه به JPG
- اسلاید به JPG
- PPT به JPG
- PPTX به JPG
- ذخیره PowerPoint به صورت JPG
- ذخیره ارائه به صورت JPG
- ذخیره اسلاید به صورت JPG
- ذخیره PPT به صورت JPG
- ذخیره PPTX به صورت JPG
- صدور PPT به JPG
- صدور PPTX به JPG
- .NET
- C#
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint (PPT، PPTX) به تصاویر JPG با کیفیت بالا در C# با استفاده از Aspose.Slides برای .NET با مثال‌های کد سریع و قابل اعتماد."
---
## **معرفی**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و جاسازی محتوا در وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides برای .NET به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر سفارشی ارائه و ایجاد تصویر کوچک برای هر اسلاید آسان است. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را از کپی‌برداری محافظت کنید یا ارائه را در حالت فقط-خواندن نمایش دهید. Aspose.Slides به شما اجازه می‌دهد کل ارائه یا اسلاید خاصی را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل اسلایدهای ارائه به تصاویر JPG**

1. یک نمونه از کلاس [Presentation] ایجاد کنید.
2. شیء اسلاید از نوع [ISlide] را از مجموعه [Presentation.Slides] دریافت کنید.
3. تصویر اسلاید را با استفاده از متد [ISlide.GetImage(float, float)] ایجاد کنید.
4. متد [IImage.Save(string, ImageFormat)] را بر روی شی تصویر فراخوانی کنید. نام فایل خروجی و فرمت تصویر را به‌عنوان آرگومان پاس دهید.

{{% alert color="info" %}} 
**نکته:** تبدیل PPT، PPTX یا ODP به JPG با تبدیل به سایر فرمت‌ها در API Aspose.Slides .NET متفاوت است. برای سایر فرمت‌ها، معمولاً از متد [IPresentation.Save(String, SaveFormat, ISaveOptions)] استفاده می‌کنید. اما برای تبدیل به JPG، باید از متد [IImage.Save(string, ImageFormat)] استفاده کنید.
{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // ایجاد یک تصویر اسلاید با مقیاس مشخص.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // ذخیره تصویر در دیسک با فرمت JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **تبدیل اسلایدها به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصاویر JPG تولید شده، می‌توانید اندازه تصویر را با عبور آن به متد [ISlide.GetImage(Size)] تنظیم کنید. این امکان را به شما می‌دهد تا تصاویری با عرض و ارتفاع مشخص تولید کنید و خروجی با نیازهای شما برای وضوح و نسبت تصویر مطابقت داشته باشد. این انعطاف‌پذیری به‌ویژه هنگام تولید تصاویر برای برنامه‌های وب، گزارش‌ها یا مستندات مفید است، جایی که ابعاد دقیق تصویر لازم است.

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // ایجاد تصویر اسلاید با اندازه مشخص.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // ذخیره تصویر در دیسک با فرمت JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **رندر نظرات هنگام ذخیره اسلایدها به‌صورت تصویر**

Aspose.Slides برای .NET ویژگی‌ای ارائه می‌دهد که به شما امکان رندر نظرات بر اسلایدهای یک ارائه را هنگام تبدیل آن‌ها به تصاویر JPG می‌دهد. این قابلیت برای حفظ حاشیه‌نویسی‌ها، بازخوردها یا بحث‌های اضافه‌شده توسط همکاران در ارائه‌های PowerPoint بسیار مفید است. با فعال‌سازی این گزینه، اطمینان می‌یابید که نظرات در تصاویر تولید شده قابل مشاهده‌اند و بررسی و اشتراک‌گذاری بازخوردها بدون نیاز به باز کردن فایل ارائه اصلی آسان‌تر می‌شود.

فرض کنید فایلی به نام "sample.pptx" داریم که شامل اسلایدی با نظرات است:

![اسلاید با نظرات](slide_with_comments.png)

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // تنظیم گزینه‌ها برای نظرات اسلاید.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // تبدیل اولین اسلاید به تصویر.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

![تصویر JPG با نظرات](image_with_comments.png)

## **موارد مرتبط**

- [تبدیل PowerPoint به GIF](/slides/fa/net/convert-powerpoint-to-animated-gif/)
- [تبدیل PowerPoint به PNG](/slides/fa/net/convert-powerpoint-to-png/)
- [تبدیل PowerPoint به TIFF](/slides/fa/net/convert-powerpoint-to-tiff/)
- [تبدیل PowerPoint به SVG](/slides/fa/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
برای مشاهده نحوه تبدیل PowerPoint به تصاویر JPG توسط Aspose.Slides، این مبدل‌های آنلاین رایگان را امتحان کنید: PowerPoint [PPTX به JPG](https://products.aspose.app/slides/fa/conversion/pptx-to-jpg) و [PPT به JPG](https://products.aspose.app/slides/fa/conversion/ppt-to-jpg). 
{{% /alert %}} 

![مبدل آنلاین رایگان PPTX به JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}
Aspose برنامه وب رایگان [FREE Collage web app](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین، می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ادغام کنید، [girdهای عکس](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره.

با استفاده از همان اصول توضیح داده شده در این مقاله، می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر، این صفحات را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/net/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/net/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/net/conversion/jpg-to-png/), تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/net/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/net/conversion/png-to-svg/), تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/net/conversion/svg-to-png/).
{{% /alert %}}

## **پرسش‌های متداول**

### آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟

بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات فراهم می‌کند.

### آیا تبدیل از SmartArt، نمودارها و سایر اشیاء پیچیده پشتیبانی می‌کند؟

بله، Aspose.Slides تمام محتوا شامل SmartArt، نمودارها، جداول، اشکال و غیره را رندر می‌کند. با این حال، دقت رندر ممکن است کمی نسبت به PowerPoint متفاوت باشد، به‌ویژه هنگام استفاده از فونت‌های سفارشی یا گمشده.

### آیا محدودیتی در تعداد اسلایدهایی که می‌توان پردازش کرد وجود دارد؟

Aspose.Slides خود نیازی به محدودیت سخت‌گیرانه‌ای برای تعداد اسلایدهای قابل پردازش اعمال نمی‌کند. اما ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا با خطای کمبود حافظه مواجه شوید.