---
title: "تغییر اندازه و جهت صفحهٔ یادداشت‌ها در PHP"
linktitle: "اندازه صفحهٔ یادداشت‌ها"
type: docs
weight: 10
url: /fa/php-java/notes-size/
keywords:
- "اندازه صفحه یادداشت"
- "جهت یادداشت‌ها"
- "یادداشت‌های افقی"
- "یادداشت‌های عمودی"
- "اندازه دستیّات"
- PowerPoint
- "ارائه"
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "ابعاد صفحهٔ یادداشت‌ها را در Aspose.Slides برای PHP از طریق Java بخوانید و تغییر دهید، جهت را تغییر دهید، اندازه‌های ذخیره‌شده را تأیید کنید و یادداشت‌ها یا دستیّات را به PDF و تصاویر صادر کنید."
---
## **نمای کلی**

از متد [Presentation::getNotesSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getnotessize/) برای دسترسی به تنظیمات صفحهٔ یادداشت‌ها استفاده کنید. این متد یک شیء [NotesSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notessize/) برمی‌گرداند که متد [setSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notessize/setsize/) آن ابعاد صفحه را تنظیم می‌کند. اگرچه شیء تنظیمات را نمی‌توان جایگزین کرد، می‌توانید ابعاد جدید را از طریق این متد اختصاص دهید.

عرض و ارتفاع بر حسب **نقطه** (point) مشخص می‌شود و ۷۲ نقطه معادل یک اینچ است. برای مثال، ۹۰۰ × ۶۰۰ نقطه برابر با ۱۲٫۵ × ۸⅓ اینچ است. این تنظیمات بر کل ارائه اعمال می‌شود، نه فقط بر صفحهٔ یادداشت‌های یک اسلاید منفرد.

| تنظیم | هدف |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getnotessize/) | کنترل ابعاد صفحهٔ یادداشت‌ها و ابعادی که برای خروجی دستیّات استفاده می‌شود. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getslidesize/) | کنترل ابعاد اسلایدهای معمولی ارائه از طریق [SlideSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/). |

تغییر هر یک از این تنظیمات به طور خودکار تنظیم دیگری را تغییر نمی‌دهد. تغییر جهت صفحهٔ یادداشت‌ها همچنین اسلایدهای معمولی را نمی‌چرخاند. برای تغییر اندازه اسلایدهای معمولی، به بخش [Slide Size](/slides/fa/php-java/slide-size/) مراجعه کنید.

مثال‌های زیر از فایل `sample.pptx` موجود استفاده می‌کنند. برای مثال‌های خروجی، از ارائه‌ای که حداقل یک اسلاید دارای یادداشت‌های سخنران باشد استفاده کنید. هر مثال می‌تواند پس از بارگذاری PHP/Java Bridge و بستهٔ بسته‌بندی Aspose.Slides برای PHP به‌صورت مستقل اجرا شود. مقادیر عددی که توسط جاوا برگردانده می‌شوند با استفاده از `java_values` به مقادیر PHP تبدیل می‌شوند تا قبل از مقایسه یا محاسبه استفاده شوند.

## **خواندن اندازه و جهت صفحهٔ یادداشت‌ها**

عرض و ارتفاع را بخوانید و برای تعیین جهت آن‌ها را با هم مقایسه کنید: صفحه‌ای که عرض بزرگتری داشته باشد، افقی (landscape) است؛ صفحه‌ای که ارتفاع بزرگتری داشته باشد، عمودی (portrait)؛ و ابعاد برابر توصیف کنندهٔ صفحهٔ مربع هستند. این مثال ابعاد واقعی را برحسب نقطه چاپ می‌کند، بدون در نظر گرفتن اندازهٔ استاندارد کاغذ.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **تغییر جهت به حالت افقی بدون تغییر اندازه کاغذ**

برای تغییر فقط جهت، عرض و ارتفاع موجود را جابجا کنید. این کار طول هر دو ضلع را حفظ می‌کند، از جمله اندازهٔ سفارشی کاغذ. شرط زیر از تغییر صفحه‌ای که از پیش افقی است به حالت عمودی جلوگیری می‌کند و صفحهٔ مربعی را بدون تغییر می‌گذارد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای جهت عمودی، همان انتساب را زمانی که `java_values($size->getWidth()) > java_values($size->getHeight())` انجام دهید. مگر اینکه بخواهید اندازهٔ کاغذ را نیز تغییر دهید، ابعاد A4 یا Letter را جایگزین نکنید.

## **تنظیم و تأیید اندازهٔ سفارشی صفحهٔ یادداشت‌ها**

هر دو ابعاد را به‌صورت هم‌زمان اختصاص دهید، سپس با استفاده از متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/save/) ارائه را ذخیره کنید. این مثال یک صفحهٔ افقی ۹۰۰ × ۶۰۰‑نقطه‌ای تنظیم می‌کند، آن را به‌صورت PPTX ذخیره می‌نماید و سپس فایل ذخیره‌شده را برای بررسی مقادیر حفظ‌شده دوباره باز می‌کند. برای مقادیر شناور، اختلاف حداکثر ۰٫۰۱‑نقطه پذیرفته می‌شود؛ این به معنای تضمین دقت برای هر قالب فایل نیست.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

نتیجهٔ مورد انتظار `900 x 600 points` و `Size preserved: true` است. بررسی ارائه‌ای که تازه باز شده است، فایل ذخیره‌شده را تأیید می‌کند، نه فقط تنظیمات حافظهٔ موقت.

## **خروجی یادداشت‌ها و دستیّات**

ابعاد صفحه ناحیهٔ موجود برای چیدمان یادداشت‌ها یا دستیّات را تعریف می‌کند. این ابعاد به تنهایی آن چیدمان‌ها را فعال نمی‌کند: گزینه‌های خروجی نیز باید تنظیم شوند. خروجی اسلایدهای معمولی همچنان از ابعاد اسلاید استفاده می‌کند.

### **خروجی یادداشت‌ها به PDF و PNG**

برای درج یادداشت‌ها در PDF، شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) را به متد [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) پاس دهید. این مثال همچنین اولین اسلاید دارای یادداشت را به PNG با استفاده از [Slide::getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) و [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/) رندر می‌کند.

حالت [BottomTruncated](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notespositions/) یادداشت‌ها را در یک صفحه نگه می‌دارد؛ یادداشت‌هایی که جا نمی‌شوند می‌توانند کوتاه شوند. PDF از صفحات ۹۰۰ × ۶۰۰‑نقطه‌ای استفاده می‌کند. با مقیاس تصویر ۱ × ۱ که در زیر به‌کار رفته، PNG به اندازهٔ ۹۰۰ × ۶۰۰ پیکسل خواهد بود. نقطه‌ها هندسهٔ صفحه را توصیف می‌کنند؛ پیکسل‌ها خروجی رستر را توصیف می‌کنند که ابعاد آن نیز به مقیاس رندر بستگی دارد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

برای خروجی PDF با یادداشت‌های طولانی، حالت [BottomFull](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notespositions/) صفحات بیشتری را در صورت نیاز اضافه می‌کند. این حالت را همراه با فراخوانی تصویر تک‌اسلایدی که در بالا استفاده شد به‌کار نبرید، زیرا آن فراخوانی از این حالت پشتیبانی نمی‌کند. پس از تغییر اندازه، خروجی را برای برش یادداشت‌ها و مکان‌گذاری اشیای موجود در notes‑master بررسی کنید؛ تغییر تنها ابعاد صفحه نباید به‌عنوان تضمین قرار گرفتن تمام محتوا در نظر گرفته شود. برای اطلاعات بیشتر دربارهٔ خروجی یادداشت‌ها، به صفحهٔ [Convert PowerPoint to PDF with Notes](/slides/fa/php-java/convert-powerpoint-to-pdf-with-notes/) مراجعه کنید.

### **خروجی دستیّات به PDF**

از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handoutlayoutingoptions/) برای نمایش چندین تصویر کوچک اسلاید در یک صفحه استفاده کنید. مثال زیر صفحه‌ای ۹۰۰ × ۶۰۰‑نقطه‌ای تنظیم می‌کند و از [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handouttype/) برای قرار دادن تا چهار اسلاید در هر صفحه بهره می‌برد. پیش‌نویس افقی ترتیب اسلایدها را کنترل می‌کند؛ جهت صفحه از عرض و ارتفاع آن به‌دست می‌آید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

تغییر اندازه صفحه ناحیهٔ موجود برای شبکهٔ دستیّات را بدون تغییر ابعاد اسلایدهای منبع تغییر می‌دهد. برای تصاویر دستیّات، به‌جای متد تصویر اسلاید منفرد، از [Presentation::getImages](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getimages/) همراه با چیدمان دستیّات استفاده کنید. در Aspose.Slides، رندرینگ دستیّات سطح ارائه از ابعاد صفحهٔ یادداشت‌ها استفاده می‌کند، در حالی که فراخوانی تصویر اسلاید منفرد صفحهٔ دستیّات را تولید نمی‌کند. گزینه‌های چیدمان را در صفحهٔ [Handout Mode](/slides/fa/php-java/convert-powerpoint-in-handout-mode/) مشاهده کنید.

## **اندازه صفحه در مرورگرها، خروجی و چاپ**

اندازهٔ ذخیره‌شدهٔ ارائه، اندازهٔ صفحهٔ خروجی و اندازهٔ کاغذ چاپی را جداگانه در نظر بگیرید:

- **نمایشگرهای ارائه:** یک نمایشگر می‌تواند یادداشت‌ها را با قوانین چیدمان خود نمایش یا چاپ کند. اگر برنامه‌ای دیگر فایل را ذخیره کند، آن را دوباره باز کنید و ابعاد را بررسی کنید؛ تبدیل فرمت آن برنامه ممکن است ابعاد را نرمال‌سازی کند.
- **قالب‌های خروجی:** مثال‌های PDF یادداشت‌ها و دستیّات بالا از ابعاد صفحهٔ پیکربندی‌شده استفاده می‌کنند. تصاویر رستر از ابعاد پیکسل صحیح و مقیاس رندر استفاده می‌کنند، بنابراین مقادیر نقطه‌ای کسری ممکن است در خروجی تصویر گرد شوند. خروجی اسلایدهای معمولی از اندازهٔ صفحهٔ یادداشت‌ها استفاده نمی‌کند.
- **درایورهای چاپگر:** انتخاب کاغذ، چرخش خودکار و تنظیمات «متناسب با صفحه» می‌توانند خروجی فیزیکی را بدون تغییر ابعاد ذخیره‌شده در ارائه یا PDF تغییر دهند. برای یک اندازهٔ کاغذ خاص، تنظیمات چاپگر را هماهنگ کنید و پیش‌نمایش چاپ را بررسی کنید.

## **سوالات متداول**

**آیا می‌توانم اندازهٔ یادداشت‌ها را فقط برای یک اسلاید تنظیم کنم؟**

اندازهٔ صفحهٔ یادداشت‌ها یک تنظیم در سطح ارائه است. اسلایدهای منفرد می‌توانند محتوای یادداشت متفاوت داشته باشند، اما این ویژگی اندازهٔ صفحهٔ جداگانه‌ای برای هر اسلاید فراهم نمی‌کند.

**چرا تغییر جهت یادداشت‌ها اسلایدهایم را تغییر نداد؟**

صفحات یادداشت و اسلایدهای معمولی ابعاد مستقلی دارند. برای تغییر اندازهٔ خود اسلایدها از تنظیمات اندازهٔ اسلاید استفاده کنید.

**چرا نتیجهٔ ذخیره‌شده یا چاپی من اندازهٔ متفاوتی دارد؟**

اولین بار ارائه ذخیره‌شده را باز کنید و ابعاد یادداشت‌های آن را مقایسه کنید. اگر این ابعاد تغییر کرده‌اند، بررسی کنید آیا ذخیره یا تبدیل فایل در برنامه‌ای دیگر تنظیمات صفحه را تغییر داده است یا خیر. اگر نه، چیدمان خروجی، مقیاس تصویر، تنظیمات نمایشگر و انتخاب کاغذ چاپگر را بررسی کنید.