---
title: مدیریت بخش‌های متن در ارائه‌ها با استفاده از PHP
linktitle: بخش متن
type: docs
weight: 70
url: /fa/php-java/portion/
keywords:
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه بخش‌های متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای PHP از طریق Java مدیریت کنید و عملکرد و سفارشی‌سازی را افزایش دهید."
---
## **مقدمه**

یک بخش متن نمایانگر یک قطعه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد تا به طور مستقل نسبت به محتویات اطراف با آن قطعه کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز به دریافت موقعیت یک قطعه متن دارید، قالب‌بندی را فقط بر روی قسمتی از یک پاراگراف اعمال کنید، یا رفتار متن را در سطح جزئی‌تری کنترل کنید.

## **دریافت مختصات یک بخش متن**
متد [**getCoordinates()**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/getcoordinates/) به کلاس [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) اضافه شده است که امکان بازیابی مختصات ابتدای بخش را فراهم می‌کند.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
  $pres = new Presentation();
  try {
    # بازآرایی زمینه ارائه
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**آیا می‌توانم فقط به بخشی از متن داخل یک پاراگراف یک پیوند (hyperlink) اعمال کنم؟**

بله، می‌توانید [یک پیوند اختصاصی](/slides/fa/php-java/manage-hyperlinks/) به یک بخش جداگانه اختصاص دهید؛ فقط آن قطعه قابل کلیک خواهد بود، نه کل پاراگراف.

**نحوه کار ارث‌بری استایل چگونه است: یک Portion چه چیزی را بازنویسی می‌کند و چه چیزی از Paragraph/TextFrame گرفته می‌شود؟**

خواص در سطح Portion بالاترین اولویت را دارند. اگر یک خاصیت در [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) تنظیم نشده باشد، موتور آن را از [Paragraph](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraph/) می‌گیرد؛ اگر آنجا هم تنظیم نشده باشد، از سبک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) یا [theme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/theme/) گرفته می‌شود.

**اگر فونت مشخص‌شده برای یک Portion در ماشین/سرور هدف موجود نباشد چه می‌شود؟**

[قوانین جایگزینی فونت](/slides/fa/php-java/font-selection-sequence/) اعمال می‌شود. متن ممکن است دوباره جریان یابد: معیارها، تفکیک واژه و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت یا گرادیان پر متن مخصوص Portion را به‌صورت مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portion/) می‌تواند با قطعات مجاور متفاوت باشد.