---
title: تبدیل ارائه‌های PowerPoint به GIFهای متحرک در JavaScript
linktitle: PowerPoint به GIF
type: docs
weight: 65
url: /fa/nodejs-java/convert-powerpoint-to-animated-gif/
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
- ذخیره PPT به‌صورت GIF
- ذخیره PPTX به‌صورت GIF
- استخراج PPT به‌صورت GIF
- استخراج PPTX به‌صورت GIF
- تنظیمات پیش‌فرض
- تنظیمات سفارشی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (PPT، PPTX) را در JavaScript به GIFهای متحرک تبدیل کنید با Aspose.Slides برای Node.js از طریق Java. نتایج سریع و با کیفیت بالا."
---
## **مروری کلی**

Aspose.Slides به شما امکان تبدیل ارائه‌های PowerPoint به فایل‌های GIF متحرک را تنها با چند خط کد می‌دهد. این قابلیت زمانی مفید است که نیاز به اشتراک‌گذاری محتوای اسلایدها در قالبی سبک، با پشتیبانی گسترده و به صورت متحرک دارید که می‌توان آن را در صفحات وب، پیام‌رسان‌ها یا مستندات جاسازی کرد. این مقاله توضیح می‌دهد چگونه یک ارائه را به GIF خروجی بگیرید با تنظیمات پیش‌فرض و چگونه خروجی را با پیکربندی گزینه‌هایی همچون اندازه فریم، تاخیر اسلاید و نرخ فریم انتقال از طریق GifOptions شخصی‌سازی کنید.

## **تبدیل ارائه‌ها به GIF متحرک با استفاده از تنظیمات پیش‌فرض**

این کد نمونه در JavaScript نشان می‌دهد چگونه یک ارائه را به GIF متحرک تبدیل کنید با استفاده از تنظیمات استاندارد:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

GIF متحرک با پارامترهای پیش‌فرض ایجاد خواهد شد. 

{{%  alert  title="TIP"  color="primary"  %}} 
اگر ترجیح می‌دهید پارامترهای GIF را سفارشی کنید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/GifOptions) استفاده کنید. کد نمونه زیر را ببینید.
{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF متحرک با تنظیمات سفارشی**

این کد نمونه نشان می‌دهد چگونه یک ارائه را به GIF متحرک تبدیل کنید با استفاده از تنظیمات سفارشی در JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// اندازه GIF تولید شده
    gifOptions.setDefaultDelay(2000);// مدت زمانی که هر اسلاید نمایش داده می‌شود تا به اسلاید بعدی تغییر کند
    gifOptions.setTransitionFps(35);// افزایش FPS برای کیفیت بهتر انیمیشن انتقال
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
ممکن است بخواهید یک مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) توسط Aspose توسعه‌یافته را بررسی کنید. 
{{% /alert %}}

## **پرسش‌های متداول**

**اگر فونت‌های استفاده شده در ارائه روی سیستم نصب نباشند چه می‌شود؟**

فونت‌های گمشده را نصب کنید یا [fallback fonts را پیکربندی کنید](/slides/fa/nodejs-java/powerpoint-fonts/). Aspose.Slides جایگزین خواهد کرد، اما ظاهر ممکن است متفاوت باشد. برای برندسازی، همیشه اطمینان حاصل کنید که فونت‌های مورد نیاز به‌صورت صریح در دسترس باشند.

**آیا می‌توانم یک واترمارک بر فریم‌های GIF قرار دهم؟**

بله. می‌توانید یک شیء/آرم نیمه‌شفاف را با استفاده از [افزودن یک شیء/لوگو نیمه‌شفاف](/slides/fa/nodejs-java/watermark/) به اسلاید اصلی یا اسلایدهای فردی قبل از خروجی اضافه کنید — واترمارک در هر فریم ظاهر خواهد شد.