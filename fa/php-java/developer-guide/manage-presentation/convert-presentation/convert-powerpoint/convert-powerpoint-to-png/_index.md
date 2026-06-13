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
- ذخیره PPT به صورت PNG
- ذخیره PPTX به صورت PNG
- صادرات PPT به PNG
- صادرات PPTX به PNG
- PHP
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به تصاویر PNG با کیفیت بالا به‌سرعت با Aspose.Slides برای PHP از طریق Java، تضمین‌کننده نتایج دقیق و خودکار."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به تصاویر PNG تبدیل کنید. نشان می‌دهد چگونه فایل‌های ارائه را در قالب‌های PPT، PPTX و ODP بارگذاری کنید، اسلایدها را به تصویر تبدیل کنید و نتایج را در قالب PNG ذخیره نمایید.

همچنین مقاله نشان می‌دهد چگونه می‌توانید با تنظیم مقادیر مقیاس یا تعیین عرض و ارتفاع دلخواه، تصاویر PNG تولید شده را سفارشی کنید.

## **تبدیل پاورپوینت به PNG**

این مراحل را دنبال کنید:

1. یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. شی اسلاید را از مجموعه [Presentation.getSlides()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlides) در زیر کلاس [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) دریافت کنید.
3. از متد [Slide.getImage()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) برای دریافت تصویر بندانگشتی هر اسلاید استفاده کنید.
4. از متد [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/#save) برای ذخیره تصویر بندانگشتی اسلاید در قالب PNG استفاده کنید.

این کد PHP نشان می‌دهد چگونه یک ارائه PowerPoint را به PNG تبدیل کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تبدیل پاورپوینت به PNG با ابعاد سفارشی**

اگر می‌خواهید فایل‌های PNG را با مقیاس خاصی دریافت کنید، می‌توانید مقادیر `desiredX` و `desiredY` را تنظیم کنید که ابعاد تصویر نهایی را تعیین می‌کند.

این کد عملیات توصیف‌شده را نشان می‌دهد:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تبدیل پاورپوینت به PNG با اندازه سفارشی**

اگر می‌خواهید فایل‌های PNG را با اندازه‌ای خاص به‌دست آورید، می‌توانید آرگومان‌های `width` و `height` دلخواه خود را برای `ImageSize` ارسال کنید.

این کد نشان می‌دهد چگونه یک PowerPoint را به PNG تبدیل کنید در حالی که اندازه تصاویر را مشخص می‌کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**چگونه می‌توانم فقط یک شکل خاص (مثلاً نمودار یا تصویر) را به‌جای کل اسلاید صادر کنم؟**

Aspose.Slides از [ایجاد تصویر بندانگشتی برای اشکال جداگانه](/slides/fa/php-java/create-shape-thumbnails/) پشتیبانی می‌کند؛ می‌توانید یک شکل را به تصویر PNG رندر کنید.

**آیا تبدیل همزمان در سرور پشتیبانی می‌شود؟**

بله، اما [به اشتراک‌گذاری](/slides/fa/php-java/multithreading/) یک شی ارائه واحد بین رشته‌ها را انجام ندهید. برای هر رشته یا فرآیند یک نمونه جداگانه استفاده کنید.

**محدودیت‌های نسخه آزمایشی هنگام صادر کردن به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا اعمال یک لایسنس، [محدودیت‌های دیگر](/slides/fa/php-java/licensing/) را اعمال می‌نماید.