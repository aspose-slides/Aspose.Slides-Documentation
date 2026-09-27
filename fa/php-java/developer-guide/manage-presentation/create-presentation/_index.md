---
title: ایجاد ارائه‌ها در PHP
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/php-java/create-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- ایجاد PPT
- PPT جدید
- ایجاد PPTX
- PPTX جدید
- ایجاد ODP
- ODP جدید
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد ارائه‌ها با Aspose.Slides برای PHP از طریق Java — تولید فایل‌های PPT، PPTX و ODP و ذخیرهٔ برنامه‌نویسی‌شدهٔ آن‌ها برای نتایج قابل اعتماد."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه یک ارائه در Aspose.Slides ایجاد کنید، یک جعبه متن را به اولین اسلاید آن اضافه کنید و نتیجه را به عنوان یک فایل ذخیره کنید. همچنین نشان می‌دهد چگونه یک ارائه خالی ایجاد و ذخیره کنید و چگونه یک ارائه موجود را در قالب پشتیبانی‌شده باز کرده و در قالب دیگری ذخیره کنید. یک بخش پرسش‌های متداول کوتاه در انتها به سؤالات رایج درباره قالب‌ها، الگوها، اندازه اسلاید، واحدها، مصرف حافظه، نخ‌ها، مجوزها، امضای دیجیتال و پشتیبانی VBA می‌پردازد.

قبل از شروع، Aspose.Slides برای PHP از طریق Java را با Composer نصب کنید و PHP/Java Bridge را در Apache Tomcat اجرا کنید. برای تنظیم کامل، به [نصب](/slides/fa/php-java/installation/) مراجعه کنید. مثال‌های زیر انتظار دارند Tomcat روی `localhost:8080` در حال اجرا باشد و پوشه `vendor` Composer در کنار اسکریپت باشد.

## **ایجاد یک ارائه PowerPoint**

برای ایجاد یک ارائه و قرار دادن یک جعبه متن در اولین اسلاید آن، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید. یک ارائه جدید از پیش شامل یک اسلاید خالی است.
2. اسلاید را از مجموعه‌ای که توسط [Presentation::getSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getslides/) برگردانده می‌شود، با اندیس 0 دریافت کنید.
3. یک مستطیل با استفاده از متد [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addautoshape/) اضافه کنید و متن آن را با [TextFrame::setText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/settext/) تنظیم کنید.
4. ارائه را به عنوان یک فایل PPTX با متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/save/) ذخیره کنید.

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

دو خط `require_once`، کلاینت PHP/Java Bridge را از Tomcat و کلاس‌های Aspose.Slides را از بسته Composer بارگیری می‌کنند. گوشه سمت چپ‑بالای مستطیل ۵۰ پوینت از لبهٔ چپ و ۵۰ پوینت از لبهٔ بالا اسلاید فاصله دارد و مستطیل ۴۰۰ پوینت عرض و ۱۰۰ پوینت ارتفاع دارد. فایل ذخیره‌شده شامل یک اسلاید با آن مستطیل و متن آن است. بدون لایسنس، Aspose.Slides همچنین یک واترمارک ارزیابی را به هر اسلایدی که ذخیره می‌کند اضافه می‌کند؛ به [Licensing](/slides/fa/php-java/licensing/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides فایل‌ها را داخل Tomcat می‌خواند و می‌نویسد، نه در فرآیند PHP شما، بنابراین مسیر نسبی‌ای مثل `"hello.pptx"` نسبت به پوشه کاری Tomcat حل می‌شود. مثال‌های این صفحه مسیرهای مطلق را با `__DIR__` می‌سازند، بنابراین فایل‌ها از کنار اسکریپت خوانده و ذخیره می‌شوند.
{{% /alert %}}

## **ایجاد و ذخیره یک ارائه**

برای ایجاد یک ارائه خالی و ذخیره آن، یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید و آن را در هر قالبی از شمارش [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) ذخیره کنید. نتیجه یک ارائه با یک اسلاید خالی است.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fa/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **باز کردن و ذخیره یک ارائه**

برای تبدیل یک ارائه از یک قالب به قالب دیگر، آن را با عبور مسیر به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) باز کنید، سپس در قالب هدف ذخیره کنید. Aspose.Slides قالب ورودی را، مانند PPT، PPTX یا ODP، از خود فایل تشخیص می‌دهد.

مثال زیر انتظار دارد یک ارائهٔ OpenDocument به نام *Sample.odp* در کنار اسکریپت باشد و آن را به صورت PPTX ذخیره می‌کند.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fa/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پرسش‌های متداول**

### به چه قالب‌هایی می‌توانم یک ارائهٔ جدید را ذخیره کنم؟

می‌توانید به [PPTX, PPT و ODP](/slides/fa/php-java/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/php-java/convert-powerpoint-to-xps/)، [HTML](/slides/fa/php-java/convert-powerpoint-to-html/)، [SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/) و [images](/slides/fa/php-java/convert-powerpoint-to-png/) به‌علاوهٔ دیگر قالب‌ها خروجی بگیرید.

### آیا می‌توانم از یک الگو (POTX/POTM) شروع کنم و به‌عنوان PPTX معمولی ذخیره کنم؟

بله. قالب را بارگیری کنید و به قالب موردنظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و قالب‌های مشابه [پشتیبانی](/slides/fa/php-java/supported-file-formats/) می‌شوند.

### چگونه می‌توانم اندازه/نسبت ابعاد اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟

اندازهٔ اسلاید را از طریق [slide size](/slides/fa/php-java/slide-size/) (شامل پیش‌تنظیم‌های 4:3 و 16:9 یا ابعاد سفارشی) تنظیم کنید و تعیین کنید محتوا چگونه مقیاس‌بندی شود.

### سایزها و مختصات‌ها با چه واحدی اندازه‌گیری می‌شوند؟

در پوینت: ۱ اینچ برابر با ۷۲ واحد است.

### چگونه می‌توانم ارائه‌های بسیار بزرگ (با فایل‌های رسانه‌ای زیاد) را برای کاهش مصرف حافظه مدیریت کنم؟

از [BLOB management strategies](/slides/fa/php-java/manage-blob/) استفاده کنید، با استفاده از فایل‌های موقت ذخیره‌سازی در حافظه را محدود کنید و نسبت به جریان‌های صرفاً در‑حافظه، روی گردش کار مبتنی بر فایل ترجیح دهید.

### آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟

نمی‌توانید روی همان نمونهٔ [Presentation] از [multiple threads](/slides/fa/php-java/multithreading/) عملیات انجام دهید. برای هر نخ یا فرآیند یک نمونهٔ جداگانه و ایزوله اجرا کنید.

### چگونه می‌توانم واترمارک آزمایشی و محدودیت‌ها را حذف کنم؟

با [Apply a license](/slides/fa/php-java/licensing/) یک بار برای هر فرآیند اقدام کنید. فایل XML لایسنس باید بدون تغییر بماند و تنظیم لایسنس در صورت وجود چندین نخ باید همگام‌سازی شود.

### آیا می‌توانم PPTX ایجاد شده را به‌صورت دیجیتالی امضا کنم؟

بله. [Digital signatures](/slides/fa/php-java/digital-signature-in-powerpoint/) (اضافه کردن و تأیید) برای ارائه‌ها پشتیبانی می‌شوند.

### آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟

بله. می‌توانید [create/edit VBA projects](/slides/fa/php-java/presentation-via-vba/) را انجام دهید و فایل‌های فعال‌سازی ماکرو مانند PPTM/PPSM را ذخیره کنید.