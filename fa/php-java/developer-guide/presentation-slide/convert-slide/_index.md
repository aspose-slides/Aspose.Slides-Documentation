---
title: تبدیل اسلایدهای ارائه به تصاویر در PHP
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/php-java/convert-slide/
keywords:
- تبدیل اسلاید
- صادرات اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدها را از فرمت‌های PPT، PPTX و ODP به تصاویر تبدیل کنید با استفاده از Aspose.Slides برای PHP از طریق Java — رندر سریع، با کیفیت بالا و همراه با مثال‌های کد واضح."
---
## **معرفی**

Aspose.Slides for PHP via Java به شما امکان می‌دهد به سادگی اسلایدهای ارائه PowerPoint و OpenDocument را به فرمت‌های تصویری مختلفی مانند BMP، PNG، JPG (JPEG)، GIF و غیره تبدیل کنید.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات تبدیل مورد نظر را تعریف کنید و اسلایدهایی که می‌خواهید صادر کنید را با استفاده از:
    - کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) یا
    - کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/)  
2. تصویر اسلاید را با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) تولید کنید.

در Aspose.Slides for PHP via Java، IImage کلاسیاست که به شما امکان کار با تصاویری را می‌دهد که با داده‌های پیکسل تعریف شده‌اند. می‌توانید از این کلاس برای ذخیره تصاویر در طیف گسترده‌ای از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ‌ها و ذخیره تصاویر در قالب PNG**

شما می‌توانید یک اسلاید را به یک شی بیت‌مپ تبدیل کنید و مستقیماً در برنامه خود استفاده نمایید. به‌علاوه، می‌توانید اسلاید را به بیت‌مپ تبدیل کرده و سپس تصویر را در قالب JPEG یا هر فرمت دلخواه دیگری ذخیره کنید.

این کد نحوه تبدیل اولین اسلاید یک ارائه به شی بیت‌مپ و سپس ذخیره تصویر در قالب PNG را نشان می‌دهد:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // تبدیل اولین اسلاید در ارائه به یک بیت‌مپ.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // ذخیره تصویر در قالب PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویر با اندازه‌ای خاص دریافت کنید. با استفاده از overload متد [getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage)، می‌توانید اسلاید را به تصویری با ابعاد مشخص (عرض و ارتفاع) تبدیل کنید.

این کد نمونه نحوه انجام این کار را نمایش می‌دهد:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // تبدیل اولین اسلاید در ارائه به یک بیت‌مپ با اندازه مشخص.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // ذخیره تصویر در قالب JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصاویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) و [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/) را فراهم می‌کند که به شما امکان کنترل رندر کردن اسلایدهای ارائه به تصاویر را می‌دهد. هر دو کلاس شامل متد `setSlidesLayoutOptions` هستند که به شما اجازه می‌دهد رندر کردن یادداشت‌ها و نظرات بر روی اسلاید هنگام تبدیل به تصویر را تنظیم کنید.

با کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواهتان برای یادداشت‌ها و نظرات را در تصویر نهایی تعیین کنید.

این کد نحوه تبدیل اسلایدی که شامل یادداشت‌ها و نظرات است را نشان می‌دهد:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // موقعیت یادداشت‌ها را تنظیم کنید.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // موقعیت نظرات را تنظیم کنید.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // عرض ناحیه نظرات را تنظیم کنید.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // رنگ ناحیه نظرات را تنظیم کنید.

    // گزینه‌های رندرینگ را ایجاد کنید.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // اولین اسلاید ارائه را به تصویر تبدیل کنید.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // تصویر را در قالب GIF ذخیره کنید.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرآیند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) نمی‌تواند مقدار BottomFull را اعمال کند (برای تعیین موقعیت یادداشت‌ها) زیرا متن یک یادداشت ممکن است بیش از حد بزرگ باشد و نتواند در اندازه تصویر مشخص شده جا بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) کنترل بیشتری بر تصویر TIFF خروجی فراهم می‌کند و به شما امکان مشخص کردن پارامترهایی مانند اندازه، وضوح، پالت رنگ و غیره را می‌دهد.

این کد یک فرآیند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی تصویر سیاه و سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```php
// بارگذاری فایل ارائه.
$presentation = new Presentation("sample.pptx");
try {
    // دریافت اولین اسلاید از ارائه.
    $slide = $presentation->getSlides()->get_Item(0);

    // پیکربندی تنظیمات تصویر خروجی TIFF.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // تنظیم اندازه تصویر.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // تنظیم قالب پیکسل (سیاه و سفید).
    $options->setDpiX(300);                                              // تنظیم وضوح افقی.
    $options->setDpiY(300);                                              // تنظیم وضوح عمودی.
    
    // تبدیل اسلاید به تصویر با گزینه‌های مشخص شده.
    $image = $slide->getImage($options);
    try {
        // ذخیره تصویر در قالب TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
پشتیبانی از TIFF در نسخه‌های قبل از JDK 9 تضمین نشده است.
{{% /alert %}} 

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما امکان می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و به‌صورت مؤثری تمام ارائه را به مجموعه‌ای از تصاویر تبدیل نمایید.

این کد نمونه نشان می‌دهد که چگونه تمام اسلایدهای یک ارائه را در PHP به تصاویر تبدیل کنید:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // رندر کردن ارائه به تصاویر اسلاید به اسلاید.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نمی‌شوند).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // تبدیل اسلاید به تصویر.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // ذخیره تصویر در قالب JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا Aspose.Slides از رندر کردن اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر، متد `getImage` فقط یک تصویر ثابت از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر صادر کرد؟**

بله، اسلایدهای مخفی می‌توانند همانند اسلایدهای عادی پردازش شوند. فقط مطمئن شوید که در حلقه پردازش گنجانده شده‌اند.

**آیا می‌توان تصاویر را با سایه‌ها و افکت‌ها ذخیره کرد؟**

بله، Aspose.Slides رندر کردن سایه‌ها، شفافیت و سایر افکت‌های گرافیکی را هنگام ذخیره اسلایدها به عنوان تصویر پشتیبانی می‌کند.