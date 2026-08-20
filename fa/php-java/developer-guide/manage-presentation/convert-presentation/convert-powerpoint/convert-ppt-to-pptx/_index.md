---
title: تبدیل PPT به PPTX در PHP
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/php-java/convert-ppt-to-pptx/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به عنوان PPTX
- صادرات PPT به PPTX
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "تبدیل فایل‌های PPT قدیمی به PPTX در PHP با Aspose.Slides. شامل مثال‌های PHP برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات دقت."
---
## **نمای کلی**

PPT یک فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت جدید Open XML می‌باشد. Aspose.Slides for PHP از طریق Java می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint آن را به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و توضیح می‌دهد پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید، سپس با استفاده از [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) و آرگومان [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/#Pptx) ذخیره کنید. بلوک `finally` ارائه را از بین می‌برد و منابع آن را آزاد می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// بارگذاری ارائه PPT قدیمی.
$presentation = new Presentation("presentation.ppt");
try {
    // ذخیره ارائه در قالب PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

پسوند فایل به تنهایی فرمت خروجی را تعیین نمی‌کند؛ آرگومان [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/#Pptx) این کار را انجام می‌دهد. اگر نیاز به حفظ فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق باعث متوقف شدن بقیه دسته نمی‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

برای بارهای کاری تولیدی، استثناء کامل را لاگ کنید، تصمیم بگیرید آیا یک فایل خروجی موجود می‌تواند بازنویسی شود، و نام فایل‌های ناموفق را به صف retry یا بازبینی بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با گذرواژه که بدون گذرواژه مورد نیاز باز می‌شوند، مسیرهای قابل دسترس نیستند و محتواهای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، به [Password-Protected Presentations](/php-java/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های ارثی**

تبدیل به طور معمول اسلایدها، ماسترها، طرح‌بندی‌ها، متن، شکل‌ها، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. با این حال، PPT و PPTX هر ویژگی را به‌طور دقیق یکسان نمایش نمی‌دهند. ویژگی قدیمی که معادل PPTX ندارد یا توسط کتابخانه پشتیبانی نمی‌شود، ممکن است نرمال‌سازی شود، حذف شود یا به شکل متفاوتی نمایش داده شود.

فایل تبدیل‌شده را زمانی که شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE جاسازی‌شده یا پیوندخورده، کنترل‌های ActiveX، رسانه‌های جاسازی‌شده، فونت‌های نامعمول یا ماکروهای VBA باشد، بررسی کنید. یک فایل PPTX ساده فرمت پشتیبانی‌کننده ماکرو نیست، بنابراین زمانی که VBA باید در دسترس باشد، از یک جریان کاری مناسب با ماکرو استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود هستند.

برای اسناد مهم، PPTX تولیدشده را به‌صورت برنامه‌نویسی مجدداً باز کنید و تعداد اسلایدهای کلیدی و محتوا را بررسی کنید، سپس ظاهر و رفتار نمایش اسلاید را در نمایشگر موردنظر مقایسه کنید. یک فراخوانی موفق [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) را به‌عنوان اثبات این که هر ویژگی ارثی دقیقاً در PPTX نمایان شده است درنظر نگیرید.

## **زمان استفاده از PPTX**

از PPTX استفاده کنید زمانی که ارائه در نسخه‌های فعلی PowerPoint ویرایش می‌شود، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند تبادل می‌شود، یا در فرمت‌ئی ذخیره می‌شود که بررسی و بازیابی آن نسبت به PPT باینری قدیمی آسان‌تر است. تا زمانی که ارائه تبدیل‌شده آزمون‌های دقت شما را پاس کند، نسخه اصلی PPT را به عنوان نسخه آرشیوی یا بازگشتی نگه دارید.

اگر به‌جای آن به PDF، HTML، تصاویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی مخصوص هر فرمت را در [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) استفاده کنید و فرض نکنید که همه هدف‌ها ویژگی‌های قابل ویرایش PowerPoint را نگه می‌دارند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسه سریع، می‌توانید از [online PPT to PPTX converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های تکراری، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API PHP استفاده کنید.

## **مقالات مرتبط**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Save Presentations in PHP](/php-java/save-presentation/)
- [Supported File Formats](/php-java/supported-file-formats/)
- [Open Presentations in PHP](/php-java/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides for PHP از طریق Java فایل‌های ارائه را بارگذاری و ذخیره می‌کند بدون نیاز به Microsoft PowerPoint.

**آیا تبدیل PPT به PPTX همه محتوا را دقیقاً حفظ می‌کند؟**

این تبدیل محتویات عمومی ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. هنگامیکه فایل حاوی ماکروها، اشیای OLE یا ActiveX، رسانه‌ها، انیمیشن‌های تخصصی یا فونت‌های نامعمول باشد، فایل تولیدشده را بررسی کنید.

**آیا می‌توانم فایل PPT محافظت‌شده با گذرواژه را تبدیل کنم؟**

بله، در صورتی که هنگام بارگذاری فایل گذرواژه صحیح را فراهم کنید. عدم وجود یا اشتباه بودن گذرواژه باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

فایل اصلی را تا زمانی که PPTX را در نمایشگرها و جریان‌های کاری که برای شما مهم است، تأیید کرده‌اید، نگه دارید. این کار یک نسخه بازگشتی فراهم می‌کند اگر یک ویژگی ارثی به‌صورت متفاوتی تبدیل شود.