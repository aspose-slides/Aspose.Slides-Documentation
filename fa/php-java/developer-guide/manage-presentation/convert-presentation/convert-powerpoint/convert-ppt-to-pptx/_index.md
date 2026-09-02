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
- صدور PPT به PPTX
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "فایل‌های PPT قدیمی را در PHP با Aspose.Slides به PPTX تبدیل کنید. شامل مثال‌های PHP برای تبدیل تک‌فایلی و دسته‌ای، مدیریت خطا و نکات مربوط به دقت است."
---
## **مروری کلی**

PPT یک قالب باینری قدیمی PowerPoint است، در حالی که PPTX قالب جدید Open XML است. Aspose.Slides برای PHP از طریق Java می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint به‌صورت PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و توضیح می‌دهد پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل فایل PPT به PPTX**

فایل منبع را با کلاس [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید، سپس با [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) همراه با [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/#Pptx) فراخوانی کنید. بلوک `finally` ارائه را آزاد کرده و منابع آن را رها می‌کند.

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

پسوند فایل به تنهایی فرمت خروجی را انتخاب نمی‌کند؛ آرگومان [SaveFormat::Pptx](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/#Pptx) این کار را انجام می‌دهد. اگر نیاز به حفظ فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به‌صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق مانع از ادامه‌ی بقیه‌ی دسته نمی‌شود.

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

برای بارهای کاری تولیدی، استثنا کامل را ثبت کنید، تصمیم بگیرید آیا فایل خروجی موجود می‌تواند بازنویسی شود و نام فایل‌های ناموفق را به صف retry یا بررسی بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز عبور که بدون رمز مناسب باز می‌شوند، مسیرهای غیرقابل دسترس و محتویات پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، به صفحه [ارائه‌های محافظت‌شده با رمز عبور](/slides/fa/php-java/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های قدیمی**

تبدیل به‌طور معمول اسلایدها، مسترها، چیدمان‌ها، متن، اشکال، تصاویر، جدول‌ها و نمودارها را حفظ می‌کند. با این حال، PPT و PPTX هر ویژگی را به‌دقت یکسان نشان نمی‌دهند. ویژگی قدیمی که معادل PPTX نداشته باشد یا توسط کتابخانه پشتیبانی نشود، ممکن است نرمال‌سازی، حذف یا به‌صورت متفاوت نمایش داده شود.

فایل تبدیل‌شده را زمانی که شامل انیمیشن‌ها، انتقال‌ها، اشیای OLE جاسازی‌شده یا پیوندی، کنترل‌های ActiveX، رسانه‌های جاسازی‌شده، فونت‌های نادر یا ماکروهای VBA باشد، بررسی کنید. یک فایل PPTX ساده فرمت فعال‌سازی ماکرو نیست، بنابراین وقتی VBA باید در دسترس باشد، از روند کاری مناسب با ماکرو استفاده کنید. همچنین اطمینان حاصل کنید که فونت‌های مورد نیاز و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولیدشده را برنامه‌نویسی دوباره باز کنید و تعداد اسلایدها و محتوای کلیدی را بررسی کنید، سپس ظاهر و رفتار نمایش اسلایدها را در نمایشگر موردنظر مقایسه کنید. یک فراخوانی موفق [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#save) را به‌عنوان اثبات این‌که هر ویژگی قدیمی به‌دقت در PPTX نمایان شده است، درنظر نگیرید.

## **زمان استفاده از PPTX**

از PPTX استفاده کنید زمانی که ارائه در نسخه‌های کنونی PowerPoint ویرایش می‌شود، با سیستم‌هایی که بسته‌های Open XML را پشتیبانی می‌کنند تبادل می‌شود، یا در قالبی ذخیره می‌شود که بررسی و بازیابی آن نسبت به PPT باینری قدیمی آسان‌تر باشد. نسخه اصلی PPT را به‌عنوان نسخه آرشیوی یا بازگشتی نگه دارید تا زمانی که ارائه تبدیل‌شده آزمون‌های دقت شما را پاس کند.

اگر به‌جای آن به PDF، HTML، تصاویر، XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی‌های مربوط به فرمت را در صفحه [تبدیل ارائه‌ها به چندین قالب](/slides/fa/php-java/convert-presentation/) استفاده کنید، به‌جای این‌که فرض کنید همه‌ی مقصدها ویژگی‌های ویرایش‌پذیر PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌وبیگاه یا مقایسه سریع، می‌توانید از [مبدل آنلاین PPT به PPTX](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های قابل تکرار، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API PHP استفاده کنید.

## **مقالات مرتبط**

- [PPT در مقابل PPTX](/slides/fa/php-java/ppt-vs-pptx/)
- [ذخیره ارائه‌ها در PHP](/slides/fa/php-java/save-presentation/)
- [قالب‌های فایل پشتیبانی‌شده](/slides/fa/php-java/supported-file-formats/)
- [باز کردن ارائه‌ها در PHP](/slides/fa/php-java/open-presentation/)

## **سوالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides برای PHP از طریق Java فایل‌های ارائه را بارگذاری و ذخیره می‌کند بدون نیاز به Microsoft PowerPoint.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌دقت حفظ می‌کند؟**

این تبدیل محتوای رایج ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. فایل تولید شده را زمانی که شامل ماکروها، اشیای OLE یا ActiveX، رسانه، انیمیشن‌های تخصصی یا فونت‌های نادر باشد، بررسی کنید.

**آیا می‌توانم فایل PPT محافظت‌شده با رمز عبور را تبدیل کنم؟**

بله، اگر هنگام بارگذاری فایل رمز صحیح را ارائه کنید. عدم وجود یا اشتباه بودن رمز عبور باعث شکست عملیات بارگذاری می‌شود.

**آیا باید پس از تبدیل فایل PPT را حذف کنم؟**

تا زمانی که PPTX را در نمایشگرها و جریان‌های کاری مهم برای شما بررسی کنید، نسخه اصلی را نگه دارید. این کار یک نسخه بازگشتی در صورت متفاوت تبدیل ویژگی قدیمی فراهم می‌کند.