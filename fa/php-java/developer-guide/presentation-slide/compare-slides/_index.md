---
title: مقایسه اسلایدهای ارائه در PHP
linktitle: مقایسه اسلایدها
type: docs
weight: 50
url: /fa/php-java/compare-slides/
keywords:
- مقایسه اسلایدها
- مقایسه اسلاید
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "به‌صورت برنامه‌نویسی، ارائه‌های PowerPoint و OpenDocument را با Aspose.Slides برای PHP از طریق Java مقایسه کنید. اختلافات اسلایدها را به‌سرعت در کد شناسایی کنید."
---
## **Introduction**

Aspose.Slides به شما امکان می‌دهد اسلایدها، اسلایدهای قالب و اسلایدهای اصلی را با استفاده از متد `equals` ارائه‌شده توسط کلاس `BaseSlide` مقایسه کنید. این متد زمانی `true` برمی‌گرداند که اسلایدهای مقایسه‌شده از نظر ساختار و محتوای ثابت یکسان باشند.

## **Compare Two Slides**

متد Equals به کلاس [BaseSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/BaseSlide) اضافه شده است. این متد برای اسلایدهای قالب/لِی اوت و اسلایدهای اصلی که از نظر ساختار و محتوای ثابت یکسان هستند، `true` برمی‌گرداند.

دو اسلاید برابر هستند اگر تمام اشکال، سبک‌ها، متن‌ها، انیمیشن‌ها و سایر تنظیمات و غیره برابر باشند. مقایسه مقادیر شناسه‌های منحصر به فرد مانند SlideId و محتوای پویا مانند مقدار تاریخ فعلی در جای‌متن تاریخ را در نظر نمی‌گیرد.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **FAQ**

**آیا مخفی بودن یک اسلاید بر مقایسه خود اسلایدها تأثیر می‌گذارد؟**

[Hidden status](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/gethidden/) یک ویژگی در سطح ارائه/پخش است، نه محتوای تصویری. برابری دو اسلاید خاص بر اساس ساختار و محتوای ثابت آن‌ها تعیین می‌شود؛ صرفاً مخفی بودن یک اسلاید باعث متفاوت شدن اسلایدها نمی‌شود.

**آیا پیوندهای ابرمتنی و پارامترهای آن‌ها در نظر گرفته می‌شوند؟**

بله. پیوندها بخشی از محتوای ثابت اسلاید هستند. اگر URL یا عمل پیوند ابرمتنی متفاوت باشد، معمولاً به عنوان تفاوتی در محتوای ثابت در نظر گرفته می‌شود.

**اگر یک نمودار به یک فایل اکسل خارجی ارجاع دهد، آیا محتویات آن فایل در نظر گرفته می‌شود؟**

خیر. مقایسه بر پایهٔ خود اسلایدها انجام می‌شود. معمولاً منابع دادهٔ خارجی در زمان مقایسه خوانده نمی‌شوند؛ فقط آنچه در ساختار و وضعیت ثابت اسلاید موجود است در نظر گرفته می‌شود.