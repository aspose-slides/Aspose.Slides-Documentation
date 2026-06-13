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
- ذخیره PPT به صورت GIF
- ذخیره PPTX به صورت GIF
- صادرات PPT به صورت GIF
- صادرات PPTX به صورت GIF
- تنظیمات پیش‌فرض
- تنظیمات سفارشی
- .NET
- C#
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (PPT، PPTX) را به GIFهای متحرک با Aspose.Slides برای .NET تبدیل کنید. نتایج سریع و با کیفیت بالا."
---
## **بررسی کلی**

Aspose.Slides به شما امکان تبدیل ارائه‌های PowerPoint به فایل‌های GIF متحرک را با تنها چند خط کد می‌دهد. این برای زمانی مفید است که نیاز به به‌اشتراک‌گذاری محتوای اسلایدها در قالبی سبک، به‌طور گسترده پشتیبانی‌شده و متحرک دارید که می‌تواند در صفحات وب، پیام‌رسان‌ها یا مستندات جاسازی شود. این مقاله نحوه خروجی گرفتن ارائه به GIF با تنظیمات پیش‌فرض و چگونگی سفارشی‌سازی خروجی از طریق پیکربندی گزینه‌هایی مانند اندازه فریم، تاخیر اسلاید و نرخ فریم انتقال را از طریق [GifOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/gifoptions/) توضیح می‌دهد.

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات پیش‌فرض**

این نمونه کد در C# نشان می‌دهد چگونه یک ارائه را به GIF متحرک با تنظیمات استاندارد تبدیل کنید:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

GIF متحرک با پارامترهای پیش‌فرض ایجاد خواهد شد.

{{%  alert  title="TIP"  color="primary"  %}} 

اگر تمایل دارید پارامترهای GIF را سفارشی کنید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/gifoptions) استفاده کنید. نمونه کد زیر را ببینید. 

{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات سفارشی**

این نمونه کد نشان می‌دهد چگونه یک ارائه را به GIF متحرک با تنظیمات سفارشی در C# تبدیل کنید:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // اندازه GIF تولید شده  
        DefaultDelay = 2000, // مدت زمان نمایش هر اسلاید تا قبل از تغییر به اسلاید بعدی
        TransitionFps = 35 // FPS را افزایش دهید تا کیفیت انیمیشن انتقال بهتر شود
    });
}
```

{{% alert title="Info" color="info" %}}

شاید بخواهید یک مبدل رایگان [متن به GIF](https://products.aspose.app/slides/fa/text-to-gif) که توسط Aspose توسعه یافته است را بررسی کنید. 

{{% /alert %}}

## **سؤال‌های متداول**

**اگر قلم‌های استفاده‌شده در ارائه بر روی سیستم نصب نیستند چه می‌شود؟**

قلم‌های گمشده را نصب کنید یا [پیکربندی قلم‌های جایگزین](/slides/fa/net/powerpoint-fonts/). Aspose.Slides جایگزینی خواهد کرد، اما ظاهر ممکن است متفاوت باشد. برای برندسازی، همیشه اطمینان حاصل کنید که قلم‌های مورد نیاز به‌صورت صریح در دسترس باشند.

**آیا می‌توانم یک نشان‌نام بر روی فریم‌های GIF اضافه کنم؟**

بله. می‌توانید یک شیء/لوگو نیمه‌شفاف را به اسلاید اصلی یا به اسلایدهای فردی قبل از خروجی اضافه کنید — نشان‌نام در هر فریم ظاهر خواهد شد.