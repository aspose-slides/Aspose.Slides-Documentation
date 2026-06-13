---
title: سفارشی‌سازی فونت‌های PowerPoint در PHP
linktitle: فونت سفارشی
type: docs
weight: 20
url: /fa/php-java/custom-font/
keywords:
- فونت
- فونت سفارشی
- فونت خارجی
- بارگذاری فونت
- مدیریت فونت‌ها
- پوشه فونت
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "فونت‌ها را در اسلایدهای PowerPoint با Aspose.Slides برای PHP از طریق Java سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار باشند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های سفارشی را در ارائه‌ها بدون نصب آن‌ها بر روی سیستم عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع فونت در سطح سند فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگیری کنید.

فونت‌های بارگذاری شده هنگام رندر یا صادرات ارائه، مثلاً به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین نحوه بررسی پوشه‌های فونت مورد استفاده توسط Aspose.Slides و چگونگی پاک‌کردن کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندر کردن جدا از جاسازی فونت‌ها در فایل PPTX است. اگر لازم است فونت داخل خود ارائه ذخیره شود، از امکانات جاسازی فونت به‌صورت صریح استفاده کنید.

{{% alert color="primary" %}} 

Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از متد [loadExternalFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
* فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده‌شده در یک ارائه را بدون نصب آن‌ها بر روی سیستم بارگذاری کنید. این بر خروجی صادرات—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—تاثیر می‌گذارد، بنابراین اسناد حاصل در محیط‌های مختلف یکدست به‌نظر می‌رسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه که شامل فایل‌های فونت هستند را مشخص کنید.
2. متد استاتیک [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادر کنید.
4. برای پاک‌کردن کش فونت، متد [FontsLoader::clearCache](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#clearCache--) را فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```php
// Define folders that contain custom font files.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Load custom fonts from the specified folders.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Clear the font cache after the work is finished.
    FontsLoader::clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافی به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب مقداردهی اولیه فونت‌ها را تغییر نمی‌دهد.  
فونت‌ها به این ترتیب مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**
Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#getFontFolders--) را برای یافتن پوشه‌های فونت فراهم می‌کند. این متد پوشه‌هایی که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را باز می‌گرداند.

این کد PHP نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```php
# این خط پوشه‌هایی را که فایل‌های فونت در آن جستجو می‌شوند، خروجی می‌دهد.
# این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
$fontFolders = FontsLoader::getFontFolders();
```

## **مشخص کردن فونت‌های سفارشی مورد استفاده در یک ارائه**
Aspose.Slides متد [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را برای مشخص کردن فونت‌های خارجی که با ارائه استفاده خواهند شد، فراهم می‌کند.

این کد PHP نشان می‌دهد چگونه از متد [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) استفاده کنید:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # کار با ارائه
    # CustomFont1، CustomFont2 و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرفولدرهای آن‌ها برای ارائه در دسترس هستند
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **مدیریت فونت‌ها به‌صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را برای بارگذاری فونت‌های خارجی از داده‌های باینری فراهم می‌کند.

این کد PHP فرآیند بارگذاری فونت از آرایه بایت را نشان می‌دهد:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # فونت خارجی در طول مدت زمان ارائه بارگذاری شده است
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **پرسش‌های متداول**

**آیا فونت‌های سفارشی بر صادرات به همه قالب‌ها (PDF, PNG, SVG, HTML) تاثیر می‌گذارند؟**  
بله. فونت‌های متصل توسط رندرکننده در تمام قالب‌های خروجی استفاده می‌شوند.

**آیا فونت‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟**  
خیر. ثبت یک فونت برای رندر کردن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه نگهداری شود، باید از ویژگی‌های [جاسازی صریح](/slides/fa/php-java/embedded-font/) استفاده کنید.

**آیا می‌توانم رفتار fallback را وقتی یک فونت سفارشی گلیف‌های خاصی ندارد، کنترل کنم؟**  
بله. می‌توانید [جایگزینی فونت](/slides/fa/php-java/font-substitution/)، [قواعد جایگزینی](/slides/fa/php-java/font-replacement/) و [مجموعه‌های fallback](/slides/fa/php-java/fallback-font/) را پیکربندی کنید تا دقیقاً تعیین کنید در صورت نبود گلیف مورد نظر از چه فونتی استفاده شود.

**آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟**  
بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار وابستگی به پوشه‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

**در مورد لایسنس—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟**  
شما مسئول تبعیت از شرایط لایسنس فونت هستید. شرایط متفاوت است؛ برخی لایسنس‌ها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همیشه قبل از توزیع خروجی‌ها، توافق‌نامه کاربری نهایی (EULA) فونت را مرور کنید.