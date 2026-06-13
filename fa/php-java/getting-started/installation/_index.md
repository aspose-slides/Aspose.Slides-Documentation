---
title: نصب
type: docs
weight: 70
url: /fa/php-java/installation/
keywords:
- نصب Aspose.Slides
- دانلود Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- لینوکس
- macOS
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "به سرعت Aspose.Slides for PHP via Java را نصب کنید. راهنمای گام به گام، پیش‌نیازهای سیستم و نمونه کدها — امروز با ارائه‌های پاورپوینت کار کنید!"
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه Aspose.Slides for PHP via Java را نصب و پیکربندی کنید. این مقاله به تنظیم محیط مورد نیاز، دانلود کتابخانه از طریق Packagist، پیکربندی Apache Tomcat با PHP/Java Bridge و اجرای یک مثال برای تأیید نصب می‌پردازد.

## **پیکربندی محیط**

1. PHP 7 را نصب کنید، مسیر PHP را به متغیر سیستم `PATH` اضافه کنید و مقدار `allow_url_include` را در فایل `php.ini` به `On` تنظیم کنید.
1. JRE 8 را نصب کنید. متغیر محیطی `JAVA_HOME` را به مسیر JRE نصب‌شده تنظیم کنید.
1. Apache Tomcat 8.0 را نصب کنید.

## **دانلود Aspose.Slides for PHP via Java**

`packagist` ساده‌ترین راه برای دانلود [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides) است.

برای نصب Aspose.Slides با استفاده از Packagist، این فرمان را اجرا کنید:
   ```bash
   composer require aspose/slides
   ```

## **پیکربندی Apache Tomcat**

1. PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) را از http://php-java-bridge.sourceforge.net/pjb/download.php دانلود کنید و فایل `JavaBridge.war` را به پوشه `webapps` تامکت استخراج کنید.
1. سرویس Apache Tomcat را راه‌اندازی کنید.
1. [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/fa/php-java) را دانلود کنید و در پوشه `aspose.slides` استخراج کنید. فایل `jar/aspose-slides-x.x-php.jar` را به پوشه `webapps\JavaBridge\WEB-INF\lib` کپی کنید. اگر از **PHP 8** استفاده می‌کنید، `Java.inc` اصلی از PHP-Java Bridge را با `Java.inc` موجود در `Java.inc.php8.zip` جایگزین کنید.
1. سرویس Apache Tomcat را دوباره راه‌اندازی کنید.
1. فایل `example.php` را در پوشه `aspose.slides` اجرا کنید تا مثال را با این فرمان اجرا کنید:
   ```bash
   php example.php
   ```

## **سوالات متداول**

**چگونه می‌توانم تأیید کنم که Aspose.Slides به‌درستی یکپارچه شده است؟**

پروژه خود را بسازید، یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) خالی ایجاد کنید و آن را با نام جدیدی ذخیره کنید. اگر فایل بدون بروز استثنا ایجاد شد، کتابخانه با موفقیت یکپارچه شده است.

**چگونه می‌توانم مصرف حافظه را هنگام پردازش ارائه‌های بزرگ محدود کنم؟**

محدودیت‌های حافظه JVM را تنها به اندازهٔ مورد نیاز افزایش دهید و هر نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را در یک بلاک `finally` بسته تا کش به سرعت آزاد شود. این کار جلوی خطاهای out‑of‑memory را می‌گیرد و مصرف کلی حافظه را در عملیات‌های دسته‌ای قابل پیش‌بینی نگه می‌دارد.

**آیا می‌توانم فرمت‌های خروجی ناخواسته را حذف کنم تا اندازهٔ نهایی JAR کاهش یابد؟**

نسخه‌های فعلی Aspose.Slides به صورت یک کتابخانهٔ تک‌تکه توزیع می‌شوند، بنابراین در زمان ساخت نمی‌توانید استخراج‌کننده‌های خاصی مانند PDF یا SVG را غیرفعال کنید.