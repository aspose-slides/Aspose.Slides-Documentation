---
title: سفارشی‌سازی قلم‌های پاورپوینت در PHP
linktitle: قلم سفارشی
type: docs
weight: 20
url: /fa/php-java/custom-font/
keywords:
- قلم
- قلم سفارشی
- قلم خارجی
- بارگذاری قلم
- مدیریت قلم‌ها
- پوشه قلم
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "قلم‌ها را در اسلایدهای پاورپوینت با Aspose.Slides برای PHP از طریق جاوا سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار باشند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا در ارائه‌ها از قلم‌های سفارشی استفاده کنید بدون آن‌که نیاز به نصب آنها بر روی سیستم عامل داشته باشید. می‌توانید قلم‌ها را از پوشه‌های سفارشی بارگذاری کنید، قلم‌ها را برای یک ارائه خاص از طریق منبع‌های قلم در سطح سند فراهم کنید، یا قلم‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

قلم‌های بارگذاری شده هنگام رندر یا صادرات یک ارائه استفاده می‌شوند، برای مثال به PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده. این کار به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. مقاله همچنین توضیح می‌دهد چگونه می‌توانید پوشه‌های قلم مورد استفاده توسط Aspose.Slides را بررسی کرده و پس از کار با قلم‌های خارجی، کش قلم را پاک کنید.

ثبت قلم‌های سفارشی برای رندر کردن، جدا از جاسازی قلم‌ها در فایل PPTX است. اگر نیازی باشد که یک قلم داخل خود ارائه ذخیره شود، باید از ویژگی‌های جاسازی قلم به‌صورت صریح استفاده کنید.

یک تم ارائه می‌تواند خانواده‌های قلم مختلفی را برای سیستم‌های نوشتاری جداگانه ارجاع دهد. این نگاشت‌ها نام‌های قلم را ذخیره می‌کنند اما قلم‌ها را نصب یا بارگذاری نمی‌کنند. برای مدیریت این نگاشت‌ها، به [Script-Specific Theme Fonts](/slides/fa/php-java/script-specific-font-mappings/) مراجعه کنید و از گزینه‌های بارگذاری زیر استفاده کنید تا قلم‌های ارجاع‌شده برای رندر سازگار در دسترس باشند.

{{% alert color="info" title="Note" %}}
Aspose Slides به شما امکان می‌دهد این قلم‌ها را با استفاده از متد [loadExternalFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* قلم‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
* قلم‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.
{{% /alert %}}

## **بارگذاری قلم‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد قلم‌های استفاده‌شده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی—مانند PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد حاصل در محیط‌های مختلف سازگار به نظر برسند. قلم‌ها از پوشه‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه که شامل فایل‌های قلم هستند را مشخص کنید.
2. متد استاتیک [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را فراخوانی کنید تا قلم‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادرات کنید.
4. متد [FontsLoader::clearCache](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#clearCache--) را فراخوانی کنید تا کش قلم پاک شود.

مثال کد زیر فرآیند بارگذاری قلم را نشان می‌دهد:

```php
// پوشه‌هایی که شامل فایل‌های قلم سفارشی هستند را تعریف کنید.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// قلم‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // ارائه را رندر/صادر کنید (مثلاً به PDF، تصویرها یا فرمت‌های دیگر) با استفاده از قلم‌های بارگذاری‌شده.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // پس از اتمام کار کش قلم را پاک کنید.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافی به مسیرهای جستجوی قلم اضافه می‌کند، اما ترتیب اولیه‌سازی قلم را تغییر نمی‌دهد.
قلم‌ها به ترتیب زیر اولیه‌سازی می‌شوند:

1. مسیر پیش‌فرض قلم‌های سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/) بارگذاری شده‌اند.
{{%/alert %}}

## **دریافت پوشه‌های قلم سفارشی**

Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#getFontFolders--) را فراهم می‌کند تا به شما اجازه دهد پوشه‌های قلم را پیدا کنید. این متد پوشه‌های اضافه‌شده از طریق متد `LoadExternalFonts` و پوشه‌های قلم سیستم را برمی‌گرداند.

این کد PHP نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```php
# این خط پوشه‌هایی را که در آن‌ها فایل‌های قلم جستجو می‌شوند، خروجی می‌دهد.
# این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های قلم سیستم.
$fontFolders = FontsLoader::getFontFolders();
```

## **مشخص کردن قلم‌های سفارشی استفاده‌شده با یک ارائه**

Aspose.Slides متد [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را فراهم می‌کند تا بتوانید قلم‌های خارجی که با ارائه استفاده می‌شوند را مشخص کنید.

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
    # قلم‌های CustomFont1 و CustomFont2 و قلم‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **مدیریت قلم‌ها به‌صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را فراهم می‌کند تا بتوانید قلم‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد PHP فرآیند بارگذاری قلم از آرایه بایت را نشان می‌دهد:

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
        # قلم خارجی در طول عمر ارائه بارگذاری شده است
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

### آیا قلم‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF, PNG, SVG, HTML) تأثیر می‌گذارند؟

بله. قلم‌های متصل توسط رندرر در تمام فرمت‌های صادراتی استفاده می‌شوند.

### آیا قلم‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟

نه. ثبت یک قلم برای رندر کردن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید قلم داخل فایل ارائه باشد، باید از ویژگی‌های واضح [embedding features](/slides/fa/php-java/embedded-font/) استفاده کنید.

### آیا می‌توانم رفتار fallback را هنگام عدم وجود برخی گلیف‌ها در قلم سفارشی کنترل کنم؟

بله. می‌توانید [font substitution](/slides/fa/php-java/font-substitution/)، [replacement rules](/slides/fa/php-java/font-replacement/) و [fallback sets](/slides/fa/php-java/fallback-font/) را پیکربندی کنید تا دقیقاً مشخص کنید در صورت نبود گلیف درخواست‌شده از چه قلمی استفاده شود.

### آیا می‌توانم در کانتینرهای Linux/Docker بدون نصب سیستم‌عامل قلم‌ها استفاده کنم؟

بله. می‌توانید به پوشه‌های قلم خود اشاره کنید یا قلم‌ها را از آرایه‌های بایت بارگذاری کنید. این کار هرگونه وابستگی به مسیرهای قلم سیستم در تصویر کانتینر را حذف می‌کند.

### درباره مجوزها—آیا می‌توانم هر قلم سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت مجوزهای قلم هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همواره قبل از توزیع خروجی‌ها، قرارداد کاربری نهایی (EULA) قلم را مرور کنید.