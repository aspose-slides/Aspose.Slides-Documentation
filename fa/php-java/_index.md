---
title: Aspose.Slides برای PHP از طریق Java
second_title: Aspose.Slides برای PHP
type: docs
weight: 45
url: /fa/php-java/
keywords:
- مستندات
- پردازش ارائه
- تبدیل ارائه
- پاورپوینت
- OpenDocument
- PHP
- Aspose.Slides
description: "از اینجا شروع کنید: نصب Aspose.Slides برای PHP از طریق Java، ایجاد اولین ارائه، و یافتن راهنماها برای کارهای رایج، مرجع API و پشتیبانی."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides برای PHP از طریق Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides برای PHP از طریق Java یک کتابخانه کلاس برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های PHP است، بدون نیاز به Microsoft PowerPoint یا Office Automation.

این کتابخانه می‌تواند فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره کند، از جمله نسخه‌های دارای ماکرو و قالب، و به فرمت‌های PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر صادر کند.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/php-java/installation/">نصب</a></li>
<li><a href="/slides/fa/php-java/create-presentation/">ایجاد اولین ارائه‌ خود</a></li>
<li><a href="/slides/fa/php-java/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/php-java/supported-file-formats/">فرمت‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/php-java/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/php-java/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>کارهای رایج</p>
<ul>
<li><a href="/slides/fa/php-java/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/php-java/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/php-java/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/php-java/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/php-java/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان کارهای Slides</p>
<ul>
<li><a href="/slides/fa/php-java/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/php-java/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/php-java/manage-media-files/">صدا و ویدئو</a></li>
<li><a href="/slides/fa/php-java/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/php-java/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>مثال‌ها</p>
<ul>
<li><a href="/slides/fa/php-java/examples/">مثال‌ها بر اساس عنصر اسلاید</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/fa/php-java/">مستندات API</a></li>
<li><a href="https://releases.aspose.com/slides/fa/php-java/release-notes/">یادداشت‌های نسخه</a></li>
<li><a href="/slides/fa/php-java/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="https://releases.aspose.com/slides/fa/php-java/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/fa/11">تالار پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی تجاری</a></li>
</ul>
</div>
</div>

------

## **اولین ارائه شما**

Aspose.Slides برای PHP از طریق Java بر روی Java در داخل Apache Tomcat اجرا می‌شود و اسکریپت‌های PHP شما از طریق PHP/Java Bridge به آن دسترسی پیدا می‌کنند. [نصب](/slides/fa/php-java/installation/) PHP 8.3 یا نسخه‌های قبلی، Java، Tomcat و پل را تنظیم می‌کند و سپس بسته را از Packagist در پوشه پروژه نصب می‌نماید:

```bash
composer require aspose/slides
```

سپس فایل JAR بسته را در پل کپی کنید و Tomcat را مجدداً راه‌اندازی کنید، همان‌طور که در گام 4 از [نصب بر روی لینوکس](/slides/fa/php-java/installation/#install-on-linux) یا گام 6 از [نصب بر روی ویندوز](/slides/fa/php-java/installation/#install-on-windows) آمده است. با در حال اجرا بودن Tomcat، این اسکریپت را به نام *hello.php* در پوشه پروژه ذخیره کنید و `php hello.php` را اجرا کنید:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fa/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اسکریپت فایل *hello.pptx* را در کنار خود ذخیره می‌کند، با یک اسلاید که دارای یک جعبه متن است. بدون داشتن لایسنس، فایل ذخیره‌شده یک واترمارک ارزیابی دارد — برای جزئیات به [مجوزدهی](/slides/fa/php-java/licensing/) مراجعه کنید. برای روش‌های بیشتر برای ایجاد و پر کردن یک ارائه، به [ایجاد ارائه‌ها](/slides/fa/php-java/create-presentation/) نگاه کنید.