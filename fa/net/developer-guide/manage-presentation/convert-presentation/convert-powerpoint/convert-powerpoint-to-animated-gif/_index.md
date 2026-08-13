---
title: تبدیل ارائه‌های PowerPoint به GIFهای متحرک در .NET
linktitle: PowerPoint به GIF
type: docs
weight: 65
url: /fa/net/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرک
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به GIF
- ارائه به GIF
- اسلاید به GIF
- PPT به GIF
- PPTX به GIF
- ذخیره PPT به عنوان GIF
- ذخیره PPTX به عنوان GIF
- صادرات PPT به عنوان GIF
- صادرات PPTX به عنوان GIF
- تنظیمات پیش‌فرض
- تنظیمات سفارشی
- .NET
- C#
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به GIFهای متحرک با Aspose.Slides برای .NET تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را با چند خط کد به فایل‌های GIF متحرک تبدیل کنید. این ویژگی زمانی مفید است که نیاز به اشتراک‌گذاری محتوای اسلایدها در قالبی سبک، قابل پشتیبانی گسترده و متحرک داشته باشید که بتوان آن را در صفحات وب، پیام‌رسان‌ها یا مستندات جاسازی کرد. این مقاله نحوه صادرات یک ارائه به GIF با تنظیمات پیش‌فرض و نحوه سفارشی‌سازی خروجی با پیکربندی گزینه‌هایی مانند اندازه فریم، تأخیر اسلاید و نرخ فریم انتقال را از طریق [GifOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/gifoptions/) توضیح می‌دهد.

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات پیش‌فرض**

این کد نمونه در C# نشان می‌دهد چگونه یک ارائه را با تنظیمات استاندارد به GIF متحرک تبدیل کنید:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

GIF متحرک با پارامترهای پیش‌فرض ایجاد خواهد شد. 

{{%  alert  title="TIP"  color="info"  %}} 
اگر می‌خواهید پارامترهای GIF را سفارشی کنید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/gifoptions) استفاده کنید. کد نمونه زیر را مشاهده کنید. 
{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را با تنظیمات سفارشی در C# به GIF متحرک تبدیل کنید:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // اندازه GIF تولید شده  
        DefaultDelay = 2000, // مدت زمان نمایش هر اسلاید تا زمان تغییر به اسلاید بعدی
        TransitionFps = 35 // افزایش FPS برای کیفیت بهتر انیمیشن انتقال
    });
}
```

{{% alert title="Info" color="info" %}}
می‌توانید یک مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) را که توسط Aspose توسعه یافته امتحان کنید. 
{{% /alert %}}

## **سوالات متداول**

### اگر فونت‌های استفاده شده در ارائه روی سیستم نصب نباشند چه شود؟

فونت‌های گمشده را نصب کنید یا [fallback fonts](/slides/fa/net/powerpoint-fonts/) را پیکربندی کنید. Aspose.Slides جایگزین می‌کند، اما ظاهر ممکن است متفاوت باشد. برای حفظ برندینگ، همیشه اطمینان حاصل کنید که قلم‌های مورد نیاز به وضوح در دسترس باشند.

### آیا می‌توانم یک واترمارک بر فریم‌های GIF قرار دهم؟

بله. می‌توانید یک شیء/لوگو نیمه شفاف را به اسلاید اصلی یا اسلایدهای جداگانه قبل از صادرات اضافه کنید — واترمارک در هر فریم ظاهر خواهد شد.