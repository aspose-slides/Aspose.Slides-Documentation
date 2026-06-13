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
- ذخیره PPT به JPG
- ذخیره PPTX به JPG
- استخراج PPT به JPG
- استخراج PPTX به JPG
- .NET
- C#
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint (PPT، PPTX) به تصاویر JPG با کیفیت بالا در C# با استفاده از Aspose.Slides برای .NET با مثال‌های کد سریع و قابل اعتماد."
---
## **معرفی**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و تعبیه محتوا در وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides for .NET به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر ارائه خود و ایجاد تصویر بند انگشتی برای هر اسلاید آسان می‌شود. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را از کپی شدن محافظت کنید یا ارائه را در حالت فقط خواندنی نمایش دهید. Aspose.Slides به شما امکان تبدیل کل ارائه یا یک اسلاید خاص به فرمت‌های تصویری را می‌دهد.

## **تبديل اسلایدهای ارائه به تصاویر JPG**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. شی اسلاید از نوع [ISlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide) را از مجموعه [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/properties/slides) دریافت کنید.
3. با استفاده از متد [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/#getimage_5) یک تصویر از اسلاید ایجاد کنید.
4. متد [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/save/#save_3) را بر روی شی تصویر فراخوانی کنید. نام فایل خروجی و فرمت تصویر را به عنوان آرگومان پاس دهید.

{{% alert color="primary" %}} 
**توجه:** تبدیل PPT، PPTX یا ODP به JPG در API Aspose.Slides .NET متفاوت از تبدیل به فرمت‌های دیگر است. برای سایر فرمت‌ها، معمولاً از متد [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/#save_5) استفاده می‌کنید. اما برای تبدیل به JPG، باید از متد [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/save/#save_3) استفاده کنید.
{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // یک تصویر اسلاید با مقیاس مشخص شده ایجاد کنید.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // تصویر را به صورت JPEG در دیسک ذخیره کنید.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **تبدیل اسلایدها به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصاویر JPG حاصل، می‌توانید اندازه تصویر را با پاس کردن آن به متد [ISlide.GetImage(Size)](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/#getimage_6) تنظیم کنید. این امکان را می‌دهد تا تصاویری با مقادیر خاص عرض و ارتفاع تولید کنید، به‌طوری که خروجی نیازهای شما برای وضوح و نسبت تصویر را برآورده سازد. این انعطاف‌پذیری به‌ویژه هنگام تولید تصاویر برای برنامه‌های وب، گزارش‌ها یا مستندات مفید است، جایی که ابعاد دقیق تصویر مورد نیاز است.

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // تصویری از اسلاید با اندازه مشخص شده ایجاد کنید.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // تصویر را به صورت JPEG در دیسک ذخیره کنید.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **رندر نظرات هنگام ذخیره اسلایدها به عنوان تصاویر**

Aspose.Slides for .NET ویژگی‌ای فراهم می‌کند که به شما امکان رندر نظرات بر روی اسلایدهای یک ارائه را هنگام تبدیل آن‌ها به تصاویر JPG می‌دهد. این قابلیت به‌ویژه برای حفظ حاشیه‌نگاری‌ها، بازخوردها یا بحث‌های اضافه شده توسط همکاران در ارائه‌های PowerPoint مفید است. با فعال‌سازی این گزینه، اطمینان حاصل می‌کنید که نظرات در تصاویر تولید شده قابل مشاهده هستند و بررسی و به‌اشتراک‌گذاری بازخوردها بدون نیاز به باز کردن فایل اصلی ارائه راحت‌تر می‌شود.

فرض کنید فایلی به نام "sample.pptx" داریم که یک اسلاید شامل نظرات دارد:

![اسلاید همراه با نظرات](slide_with_comments.png)

کد C# زیر اسلاید را به تصویر JPG تبدیل می‌کند و نظرات را حفظ می‌کند:

```c#
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

    // تبدیل اولین اسلاید به یک تصویر.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

نتیجه:

![تصویر JPG همراه با نظرات](image_with_comments.png)

## **موارد مرتبط**

سایر گزینه‌های تبدیل PPT، PPTX یا ODP به تصاویر را ببینید، مانند:

- [تبدیل PowerPoint به GIF](/slides/fa/net/convert-powerpoint-to-animated-gif/)
- [تبدیل PowerPoint به PNG](/slides/fa/net/convert-powerpoint-to-png/)
- [تبدیل PowerPoint به TIFF](/slides/fa/net/convert-powerpoint-to-tiff/)
- [تبدیل PowerPoint به SVG](/slides/fa/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
برای مشاهده نحوه‌ی تبدیل PowerPoint به تصاویر JPG توسط Aspose.Slides، این مبدل‌های آنلاین رایگان را امتحان کنید: PowerPoint [PPTX به JPG](https://products.aspose.app/slides/fa/conversion/pptx-to-jpg) و [PPT به JPG](https://products.aspose.app/slides/fa/conversion/ppt-to-jpg). 
{{% /alert %}} 

![مبدل آنلاین رایگان PPTX به JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose یک برنامه وب [برنامه وب Collage رایگان](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین، می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های تصویری](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره.

با استفاده از همان اصول شرح داده شده در این مقاله، می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر، این صفحات را مشاهده کنید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/net/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/net/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/net/conversion/jpg-to-png/); تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/net/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/net/conversion/png-to-svg/); تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/net/conversion/svg-to-png/).

{{% /alert %}}

## **سوالات متداول**

**آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟**

بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات فراهم می‌کند.

**آیا تبدیل از SmartArt، نمودارها و سایر اشیای پیچیده پشتیبانی می‌کند؟**

بله، Aspose.Slides تمام محتوا از جمله SmartArt، نمودارها، جدول‌ها، اشکال و موارد دیگر را رندر می‌کند. با این حال، دقت رندر ممکن است کمی نسبت به PowerPoint متفاوت باشد، به‌ویژه هنگام استفاده از قلم‌های سفارشی یا گمشده.

**آیا محدودیتی در تعداد اسلایدهای قابل پردازش وجود دارد؟**

Aspose.Slides خود محدودیت‌های سخت‌گیرانه‌ای بر تعداد اسلایدهایی که می‌توانید پردازش کنید اعمال نمی‌کند. با این حال، ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا با خطای کمبود حافظه مواجه شوید.