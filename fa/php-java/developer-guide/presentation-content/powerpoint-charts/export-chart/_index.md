---
title: صدور نمودارهای ارائه در PHP
linktitle: صدور نمودار
type: docs
weight: 90
url: /fa/php-java/export-chart/
keywords:
- نمودار
- نمودار به تصویر
- نمودار به عنوان تصویر
- استخراج تصویر نمودار
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "چگونگی صدور نمودارهای ارائه با Aspose.Slides برای PHP از طریق Java را بیاموزید، از فرمت‌های PPT و PPTX پشتیبانی می‌کند و گزارش‌گیری را در هر گردش کاری ساده می‌سازد."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد یک نمودار را از یک ارائه به عنوان تصویر صادر کنید. این مقاله نشان می‌دهد چگونه یک تصویر از یک نمودار به دست آورده و آن را ذخیره کنید، که زمانی مفید است که نیاز به استفاده مجدد از نمودارها خارج از یک ارائه پاورپوینت داشته باشید.

## **دریافت تصویر نمودار**
Aspose.Slides برای PHP از طریق Java از استخراج تصویر یک نمودار خاص پشتیبانی می‌کند. مثال نمونه زیر آورده شده است.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**آیا می‌توانم یک نمودار را به‌جای تصویر رستری به‌صورت برداری (SVG) صادر کنم؟**

بله. یک نمودار یک شکل است و محتویات آن می‌تواند با استفاده از روش ذخیره‌سازی [shape-to-SVG saving method](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/writeassvg/) به SVG ذخیره شود.

**چگونه می‌توانم اندازه دقیق نمودار صادر شده را بر حسب پیکسل تنظیم کنم؟**

از overloadهای رندر تصویر استفاده کنید که به شما امکان مشخص کردن اندازه یا مقیاس را می‌دهند—کتابخانه رندر اشیاء با ابعاد/مقیاس داده‌شده را پشتیبانی می‌کند.

**اگر قلم‌ها در برچسب‌ها و فهرست توضیح پس از صادرات نادرست به‌نظر برسند چه کاری باید انجام دهم؟**

[بارگذاری قلم‌های مورد نیاز](/slides/fa/php-java/custom-font/) از طریق [FontsLoader](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/) تا رندر نمودار معیارها و ظاهر متن را حفظ کند.

**آیا صادرات تم، سبک‌ها و افکت‌های پاورپوینت را رعایت می‌کند؟**

بله. رندر Aspose.Slides قالب‌بندی ارائه (تم‌ها، سبک‌ها، پرکننده‌ها، افکت‌ها) را دنبال می‌کند، بنابراین ظاهر نمودار حفظ می‌شود.

**کجا می‌توانم قابلیت‌های رندر/صادر کردن موجود فراتر از تصاویر نمودار را پیدا کنم؟**

به [API](https://reference.aspose.com/slides/fa/php-java/aspose.slides/)/[مستندات](/slides/fa/php-java/convert-powerpoint/) برای مقاصد خروجی ([PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/fa/php-java/convert-powerpoint-to-xps/), [HTML](/slides/fa/php-java/convert-powerpoint-to-html/), etc.) و گزینه‌های رندر مرتبط مراجعه کنید.