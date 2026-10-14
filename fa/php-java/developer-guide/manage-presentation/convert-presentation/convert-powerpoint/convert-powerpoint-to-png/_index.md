---
title: تبدیل اسلایدهای PowerPoint به PNG در PHP
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/php-java/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به عنوان PNG
- ذخیره PPTX به عنوان PNG
- صدور PPT به PNG
- صدور PPTX به PNG
- PHP
- Aspose.Slides
description: "ارائه‌های PowerPoint را به سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید با Aspose.Slides برای PHP از طریق Java، به‌طوری که نتایج دقیق و خودکار تضمین شوند."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه اسلایدهای ارائه را به تصاویر PNG تبدیل کنید با استفاده از Aspose.Slides برای PHP از طریق Java. می‌توانید ارائه‌ها را در قالب‌هایی مانند PPT، PPTX و ODP بارگذاری کنید، هر اسلاید را رندار کنید و به صورت یک تصویر PNG جداگانه ذخیره کنید.

مثال‌های زیر رندار کردن در مقیاس پیش‌فرض، افزایش مقیاس، تعیین ابعاد خروجی به پیکسل و انتخاب یک سبک رندری گرادیان را نشان می‌دهند.

## **تبدیل PowerPoint به PNG**

یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) بارگذاری کنید و از مجموعه [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) برای دسترسی به اسلایدهای آن استفاده کنید. مثال هر اسلاید را با [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) بدون پارامترها رندار می‌کند تا یک تصویر بندانگشتی ایجاد شود. سپس با [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) همراه با [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) هر اسلاید رندار شده را به عنوان تصویر PNG ذخیره می‌کند.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="تذکر" %}}
بارگذاری بدون پارامتر [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) در مقیاس 0.2 انجام می‌شود. به عنوان مثال، اسلایدی به اندازه 720 × 540 نقطه یک تصویر بندانگشتی 144 × 108 پیکسل تولید می‌کند. برای کنترل ابعاد خروجی، از بارگذاری‌های با عوامل مقیاس یا اندازه تصویر صریح زیر استفاده کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

عوامل مقیاس افقی و عمودی را به [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) پاس بدهید تا ابعاد رندار شده را کنترل کنید. در این مثال هر دو عامل 2 هستند، بنابراین اسلایدی به اندازه 720 Г— 540 نقطه تصویر 1440 Г— 1080 پیکسل تولید می‌کند. عوامل مقیاس مساوی نسبت ابعاد اسلاید را حفظ می‌کنند. هر تصویر با فرمت PNG توسط [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) ذخیره می‌شود.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

برای تعیین ابعاد خروجی به پیکسل، به جای عوامل مقیاس یک اندازه به [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) پاس بدهید. این مثال هر اسلاید را در 960 Г— 720 پیکسل رندار کرده و نتیجه را با [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) ذخیره می‌کند. ابعادی را انتخاب کنید که نسبت ابعاد اسلاید را حفظ کنند تا از کشیده شدن تصویر جلوگیری شود.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **انتخاب سبک رندری گرادیان**

فرض کنید اسلایدی دارای پرکننده‌های گرادیان باشد، اما انتقال‌ها در PNG صادر شده روشن‌تر یا متفاوت از آنچه در PowerPoint می‌بینید باشد. می‌توانید از متد [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) که توسط [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) به ارث برده شده است، برای انتخاب نحوه رندار کردن گرادیان‌ها استفاده کنید.

فایل [gradient-styles.pptx](gradient-styles.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اولین اسلاید آن دو گرادیان خطی دارد: از فیروزه‌ای به نارنجی در بالا و از آبی به زرد در پایین. هر گرادیان دو توقف دارد، در 0٪ و 100٪.

مثال زیر این ارائه را بارگذاری کرده و همان اسلاید اول را در هر دو حالت با [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) رندار می‌کند.

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

تصاویر زیر خروجی یکسان اسلاید را نشان می‌دهند، با هر دو گرادیان در هر تصویر:

| پیش‌فرض | PowerPointUI |
| --- | --- |
| ![گرادیان‌های سیا-نارنجی و آبی-زرد رندار شده با پیش‌فرض](gradient-Default.png) | ![همان گرادیان‌ها رندار شده با PowerPointUI](gradient-PowerPointUI.png) |

در این مثال، `Default` رنگ‌های میانی روشن‌تری تولید می‌کند، در حالی که `PowerPointUI` رنگ‌های میانی تیره‌تری تولید می‌کند. اختلاف به رنگ‌ها و توقف‌های گرادیان بستگی دارد.

`Default` را وقتی انتخاب کنید که خروجی استاندارد Aspose.Slides نیازهای شما را برآورده کند. زمانی که اولویت شما تطبیق ظاهر با PowerPoint است، `PowerPointUI` را امتحان کنید. هر دو خروجی را با نتیجه مورد نظرتان مقایسه کنید؛ هیچ‌یک به‌طور کلی ترجیح داده نمی‌شود.

## **سوالات متداول**

**چگونه می‌توانم یک شکل خاص، مانند نمودار یا تصویر، را به جای کل اسلاید صادر کنم؟**

Aspose.Slides از [تولید تصاویر بندانگشتی برای اشکال منفرد](/slides/fa/php-java/create-shape-thumbnails/) پشتیبانی می‌کند و به شما اجازه می‌دهد یک شکل را به عنوان تصویر PNG رندار کنید.

**آیا تبدیل موازی بر روی سرور پشتیبانی می‌شود؟**

بله. برای هر رشته یا فرآیند یک نمونهٔ جداگانه از ارائه استفاده کنید؛ [نکته: یک نمونهٔ واحد را بین رشته‌ها به اشتراک نگذارید](/slides/fa/php-java/multithreading/).

**محدودیت‌های حالت ارزیابی هنگام صادرات به PNG چیست؟**

حالت ارزیابی یک علامت آب‌نما به تصاویر خروجی اضافه می‌کند و تا زمانی که لایسنس اعمال شود، [محدودیت‌های دیگر](/slides/fa/php-java/licensing/) اعمال می‌شوند.