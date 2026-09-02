---
title: تبدیل اسلایدهای ارائه به تصویر در PHP
linktitle: اسلاید به تصویر
type: docs
weight: 35
url: /fa/php-java/convert-slide/
keywords:
- تبدیل اسلاید
- صدور اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدها را از PPT، PPTX و ODP به تصویر تبدیل کنید با استفاده از Aspose.Slides برای PHP از طریق Java — رندر سریع و با کیفیت بالا با مثال‌های کد واضح."
---
## **مقدمه**

Aspose.Slides for PHP via Java به شما امکان می‌دهد تا اسلایدهای ارائه PowerPoint و OpenDocument را به راحتی به انواع فرمت‌های تصویری از جمله BMP، PNG، JPG (JPEG)، GIF و دیگران تبدیل کنید.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. تنظیمات مورد نظر تبدیل را تعریف کنید و اسلایدهایی که می‌خواهید استخراج کنید را با استفاده از:
    - کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) یا
    - کلاس [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/) انتخاب کنید.
2. تصویر اسلاید را با فراخوانی متد [getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) تولید کنید.

در Aspose.Slides for PHP via Java، کلاس [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) به شما اجازه می‌دهد تا با تصاویری که توسط داده‌های پیکسلی تعریف شده‌اند کار کنید. می‌توانید از این کلاس برای ذخیره‌سازی تصاویر در طیف وسیعی از فرمت‌ها (BMP، JPG، PNG و غیره) استفاده کنید.

## **تبدیل اسلایدها به بیت‌مپ و ذخیره تصاویر در PNG**

می‌توانید یک اسلاید را به یک شیء بیت‌مپ تبدیل کنید و مستقیم در برنامه خود استفاده کنید. به‌صورت جایگزین، می‌توانید اسلاید را به بیت‌مپ تبدیل کرده و سپس تصویر را در JPEG یا هر فرمت دلخواه دیگری ذخیره کنید.

این کد نشان می‌دهد چگونه اولین اسلاید یک ارائه را به شیء بیت‌مپ تبدیل کرده و سپس تصویر را در فرمت PNG ذخیره کنید:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // اسلاید اول ارائه را به بیت‌مپ تبدیل کنید.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // تصویر را در فرمت PNG ذخیره کنید.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

ممکن است نیاز داشته باشید تصویری با ابعاد خاص دریافت کنید. با استفاده از یک overload از متد [getImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getImage) می‌توانید اسلاید را به تصویری با عرض و ارتفاع مشخص تبدیل کنید.

این نمونه کد نحوه انجام این کار را نشان می‌دهد:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // اسلاید اول ارائه را به بیت‌مپ با اندازه مشخص تبدیل کنید.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // تصویر را در فرمت JPEG ذخیره کنید.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **تبدیل اسلایدهای حاوی یادداشت‌ها و نظرات به تصاویر**

برخی اسلایدها ممکن است شامل یادداشت‌ها و نظرات باشند.

Aspose.Slides دو کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) و [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/) را ارائه می‌دهد که به شما امکان کنترل رندر کردن اسلایدهای ارائه به تصویر را می‌دهند. هر دو کلاس شامل متد `setSlidesLayoutOptions` هستند که به شما اجازه می‌دهد رندر کردن یادداشت‌ها و نظرات روی اسلاید هنگام تبدیل به تصویر را پیکربندی کنید.

با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) می‌توانید موقعیت دلخواه خود برای یادداشت‌ها و نظرات در تصویر نهایی مشخص کنید.

این کد نحوه تبدیل اسلایدی با یادداشت‌ها و نظرات را نشان می‌دهد:

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

    // اسلاید اول ارائه را به تصویر تبدیل کنید.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // تصویر را در فرمت GIF ذخیره کنید.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
در هر فرایند تبدیل اسلاید به تصویر، متد [setNotesPosition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) نمی‌تواند مقدار `BottomFull` را اعمال کند (برای تعیین موقعیت یادداشت) زیرا متن یک یادداشت ممکن است بیش از حد بزرگ باشد و نتواند در اندازه تصویر مشخص شده جای بگیرد.
{{% /alert %}} 

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) کنترل بیشتری بر تصویر TIFF نهایی ارائه می‌دهد و به شما امکان می‌دهد پارامترهایی مانند اندازه، وضوح، پالت رنگ و موارد دیگر را مشخص کنید.

این کد یک فرایند تبدیل را نشان می‌دهد که در آن گزینه‌های TIFF برای خروجی تصویر سیاه‑سفید با وضوح 300 DPI و اندازه 2160 × 2800 استفاده می‌شود:

```php
// یک فایل ارائه را بارگذاری کنید.
$presentation = new Presentation("sample.pptx");
try {
    // اسلاید اول ارائه را دریافت کنید.
    $slide = $presentation->getSlides()->get_Item(0);

    // تنظیمات تصویر خروجی TIFF را پیکربندی کنید.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // اندازه تصویر را تنظیم کنید.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // فرمت پیکسل را تنظیم کنید (سیاه و سفید).
    $options->setDpiX(300);                                              // وضوح افقی را تنظیم کنید.
    $options->setDpiY(300);                                              // وضوح عمودی را تنظیم کنید.
    
    // اسلاید را با گزینه‌های مشخص به تصویر تبدیل کنید.
    $image = $slide->getImage($options);
    try {
        // تصویر را در فرمت TIFF ذخیره کنید.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 
پشتیبانی از TIFF در نسخه‌های قدیمی‌تر از JDK 9 تضمین نمی‌شود.
{{% /alert %}} 

## **تبدیل تمام اسلایدها به تصاویر**

Aspose.Slides به شما اجازه می‌دهد تمام اسلایدهای یک ارائه را به تصاویر تبدیل کنید و در واقع تمام ارائه را به مجموعه‌ای از تصاویر تبدیل کنید.

این نمونه کد نشان می‌دهد چگونه تمام اسلایدهای یک ارائه را در PHP به تصاویر تبدیل کنید:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // ارائه را به‌صورت اسلاید به اسلاید به تصاویر رندر کنید.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // کنترل اسلایدهای مخفی (اسلایدهای مخفی رندر نشوند).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // اسلاید را به تصویر تبدیل کنید.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // تصویر را در فرمت JPEG ذخیره کنید.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **رندر ایموجی‌های رنگی**

{{% alert title="Note" color="warning" %}} 
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، قلم‌های ایموجی استفاده‌شده در ارائه باید بر روی سیستمی که تبدیل را انجام می‌دهد نصب و در دسترس باشند. برای مثال، اگر ارائه از فونت **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به صورت تک‌رنگ در تصاویر خروجی نمایش داده شوند.
{{% /alert %}}

## **سؤالات متداول**

**آیا Aspose.Slides از رندر کردن اسلایدها با انیمیشن پشتیبانی می‌کند؟**  
خیر، متد `getImage` فقط تصویر ایستایی از اسلاید را ذخیره می‌کند و انیمیشن‌ها را شامل نمی‌شود.

**آیا می‌توان اسلایدهای پنهان را به عنوان تصویر صادر کرد؟**  
بله، اسلایدهای پنهان می‌توانند همانند اسلایدهای معمولی پردازش شوند. فقط مطمئن شوید که در حلقه پردازش گنجانده شوند.

**آیا می‌توان تصاویر را با سایه‌ها و اثرات ذخیره کرد؟**  
بله، Aspose.Slides رندر کردن سایه‌ها، شفافیت و سایر اثرات گرافیکی را هنگام ذخیره اسلایدها به عنوان تصویر پشتیبانی می‌کند.