---
title: استخراج اشیای Flash از ارائه‌ها در PHP
linktitle: فلش
type: docs
weight: 10
url: /fa/php-java/flash/
keywords:
- استخراج فلش
- شیء فلش
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "نحوه استخراج اشیای Flash از اسلایدهای PowerPoint و OpenDocument را با Aspose.Slides برای PHP از طریق Java، به همراه نمونه‌های کامل کد و بهترین روش‌ها یاد بگیرید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان اشیای Flash را از ارائه‌ها با استفاده از Aspose.Slides استخراج کرد. این مقاله نشان می‌دهد چگونه یک کنترل Flash را بر اساس نام در مجموعهٔ کنترل‌های یک اسلاید پیدا کنید و با دادهٔ شیء SWF جاسازی‌شده کار کنید.

## **استخراج اشیای Flash از ارائه‌ها**

Aspose.Slides برای PHP از طریق Java امکاناتی برای استخراج اشیای flash از یک ارائه فراهم می‌کند. می‌توانید کنترل flash را بر اساس نام دسترسی پیدا کنید و آن را از ارائه استخراج کنید و دادهٔ شیء SWF را ذخیره کنید.

```php
  # نمونه‌سازی کلاس Presentation که نمایانگر PPTX است
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**چه قالب‌های ارائه‌ای هنگام استخراج محتوای Flash پشتیبانی می‌شوند؟**

[Aspose.Slides supports](/slides/fa/php-java/supported-file-formats/) قالب‌های اصلی PowerPoint مانند PPT و PPTX را، زیرا می‌تواند این کانتینرها را بارگذاری کرده و به کنترل‌های آن‌ها دسترسی پیدا کند، از جمله عناصر ActiveX مرتبط با Flash.

**آیا می‌توانم یک ارائه حاوی Flash را به HTML5 تبدیل کنم و تعاملات Flash را حفظ کنم؟**

خیر. Aspose.Slides محتوای SWF را اجرا نمی‌کند یا تعاملات آن را تبدیل نمی‌سازد. اگرچه خروجی به [HTML](/slides/fa/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/fa/php-java/export-to-html5/) پشتیبانی می‌شود، Flash در مرورگرهای مدرن به دلیل پایان پشتیبانی پخش نمی‌شود. مسیر پیشنهادی این است که قبل از خروجی، Flash را با جایگزین‌هایی مانند ویدئو یا انیمیشن‌های HTML5 جایگزین کنید.

**از منظر امنیتی، آیا Aspose.Slides هنگام خواندن یک ارائه فایل‌های SWF را اجرا می‌کند؟**

خیر. Aspose.Slides Flash را به عنوان دادهٔ باینری جاسازی‌شده در فایل در نظر می‌گیرد و در طول پردازش محتوای SWF را اجرا نمی‌کند.

**چگونه باید ارائه‌هایی را که Flash را همراه با سایر فایل‌های جاسازی‌شده از طریق OLE شامل می‌شوند، مدیریت کنم؟**

Aspose.Slides از [extracting embedded OLE objects](/slides/fa/php-java/manage-ole/) پشتیبانی می‌کند، بنابراین می‌توانید تمام محتوای جاسازی‌شدهٔ مرتبط را در یک مرحله پردازش کنید و کنترل‌های Flash و سایر اسناد جاسازی‌شدهٔ OLE را به‌طور همزمان مدیریت کنید.