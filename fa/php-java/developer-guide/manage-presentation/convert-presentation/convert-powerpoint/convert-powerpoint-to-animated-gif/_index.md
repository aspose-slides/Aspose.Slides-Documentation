---
title: تبدیل ارائه‌های PowerPoint به GIFهای انیمیشنی در PHP
linktitle: PowerPoint به GIF
type: docs
weight: 65
url: /fa/php-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF انیمیشنی
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
- صادرات PPT به GIF
- صادرات PPTX به GIF
- تنظیمات پیش‌فرض
- تنظیمات سفارشی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به GIFهای انیمیشنی با Aspose.Slides برای PHP از طریق Java تبدیل کنید. نتایج سریع و با کیفیت بالا.
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به فایل‌های GIF انیمیشنی تبدیل کنید تنها با چند خط کد. این قابلیت زمانی مفید است که بخواهید محتوی اسلایدها را در قالب انیمیشن سبک، با پشتیبانی گسترده و قابل درج در صفحات وب، پیام‌رسان‌ها یا مستندات به اشتراک بگذارید. این مقاله توضیح می‌دهد چگونه یک ارائه را به GIF با تنظیمات پیش‌فرض صادر کنید و چگونه خروجی را با پیکربندی گزینه‌هایی مانند اندازه فریم، تاخیر اسلاید و نرخ فریم انتقال سفارشی کنید از طریق [GifOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/gifoptions/).

## **تبدیل ارائه‌ها به GIF انیمیشنی با تنظیمات پیش‌فرض**

این کد نمونه نشان می‌دهد چگونه یک ارائه را به GIF انیمیشنی با تنظیمات استاندارد تبدیل کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

GIF انیمیشن با پارامترهای پیش‌فرض ایجاد خواهد شد.

{{% alert title="نکته" color="primary" %}} 

اگر مایل به سفارشی‌سازی پارامترهای GIF هستید، می‌توانید از کلاس [GifOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/GifOptions) استفاده کنید. نمونه کد زیر را ببینید.

{{% /alert %}} 

## **تبدیل ارائه‌ها به GIF انیمیشنی با تنظیمات سفارشی**
این کد نمونه نشان می‌دهد چگونه یک ارائه را به GIF انیمیشنی با تنظیمات سفارشی تبدیل کنید :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// اندازهٔ GIF تولید شده

    $gifOptions->setDefaultDelay(2000);// مدت زمانی که هر اسلاید نمایش داده می‌شود تا به اسلاید بعدی تغییر کند

    $gifOptions->setTransitionFps(35);// افزایش FPS برای بهبود کیفیت انیمیشن انتقال

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="اطلاعات" color="info" %}}

ممکن است بخواهید یک مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) که توسط Aspose توسعه یافته را بررسی کنید. 

{{% /alert %}}

## **سوالات متداول**

**اگر قلم‌های استفاده شده در ارائه روی سیستم نصب نشده باشند چه می‌شود؟**

قلم‌های گمشده را نصب کنید یا [پیکربندی قلم‌های جایگزین](/slides/fa/php-java/powerpoint-fonts/). Aspose.Slides جایگزین خواهد کرد، اما ظاهر ممکن است متفاوت باشد. برای برندینگ، همیشه اطمینان حاصل کنید که قلم‌های مورد نیاز به‌طور صریح در دسترس باشند.

**آیا می‌توانم یک واترمارک روی فریم‌های GIF اعمال کنم؟**

بله. برای افزودن یک شیء/لوگو نیمه‌شفاف به اسلاید اصلی یا به اسلایدهای جداگانه قبل از صادر کردن، [افزودن یک شیء/لوگو نیمه‌شفاف](/slides/fa/php-java/watermark/) را انجام دهید — واترمارک بر روی هر فریم ظاهر خواهد شد.