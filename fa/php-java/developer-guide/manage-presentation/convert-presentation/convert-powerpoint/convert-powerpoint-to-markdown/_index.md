---
title: تبدیل ارائه‌های PowerPoint به Markdown در PHP
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/php-java/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره PowerPoint به صورت Markdown
- ذخیره ارائه به صورت Markdown
- ذخیره اسلاید به صورت Markdown
- ذخیره PPT به صورت MD
- ذخیره PPTX به صورت MD
- صادرات PPT به MD
- صادرات PPTX به MD
- صادرات تصویر Markdown
- لینک‌های تصویر CDN
- پاورپوینت
- ارائه
- مارک‌داون
- PHP
- Aspose.Slides
description: "PPT و ارائه‌های PPTX را به Markdown در PHP تبدیل کنید و مکان ذخیره‌سازی و ارجاع تصاویر bitmap، metafile و SVG صادر شده را کنترل کنید."
---
## **بررسی کلی**

Aspose.Slides for PHP via Java می‌تواند ارائه‌های PPT و PPTX را به Markdown برای مستندات، سایت‌های ثابت، مهاجرت محتوا و گردش‌کارهای کنترل نسخه تبدیل کند. می‌توانید یک نوع Markdown را انتخاب کنید، رندر محتوی اسلایدها را کنترل کنید و محل ذخیره‌سازی تصاویر صادر شده و نحوه ارجاع آنها در Markdown تولید شده را تعیین کنید.

به طور پیش‌فرض، خروجی Markdown فقط متن است. برای خروجی محتوی تصویری، نوع خروجی را با متد [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) به مقدار `Sequential` یا `Visual` از شمارش‌گر [MarkdownExportType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownexporttype/) تنظیم کنید. `Sequential` موارد اسلاید را به طور جداگانه و به ترتیب رندر می‌کند، در حالی که `Visual` موارد گروه‌بندی شده را برای حفظ رابطه بصری آنها با هم نگه می‌دارد. مقدار `TextOnly` هیچ منبع تصویری تولید نمی‌کند، بنابراین فراخوانی‌های ذخیره‌سازی تصویر در این حالت اجرا نمی‌شوند.

## **تبدیل یک ارائه به Markdown**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید و سپس متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را با مقدار `Md` از شمارش‌گر [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) فراخوانی کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **انتخاب یک نوع Markdown**

متد [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) مشخص می‌کند که کدام مشخصات Markdown برای خروجی استفاده شود. شمارش‌گر [Flavor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/flavor/) شامل CommonMark، GitHub Flavored Markdown و دیگر واریانت‌های پشتیبانی‌شده است.

مثال زیر یک ارائه را به صورت CommonMark صادر می‌کند:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **صادرات تصاویر با رفتار پیش‌فرض ذخیره‌سازی محلی**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) دو متد برای پیکربندی ذخیره‌سازی محلی تصاویر فراهم می‌کند:

- [setBasePath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) مسیر پایه برای سند Markdown و منابع آن را تعیین می‌کند.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) زیرپوشه تصاویر را مشخص می‌کند. مقدار پیش‌فرض آن `Images` است.

مثال زیر محتوی تصویری را رندر می‌کند، تصاویر را در `output/assets` می‌نویسد و مراجع نسبی تصویر را در سند Markdown ایجاد می‌کند:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

این رفتار همچنین به‌عنوان بازگشت‌پذیری عمل می‌کند وقتی یک هندلر ذخیره‌سازی تصویر سفارشی مقدار `false` برمی‌گرداند.

## **سفارشی‌سازی ذخیره‌سازی تصویر و لینک‌های Markdown**

از متد [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) برای ثبت یک کال‌بک برای منابع bitmap و metafile غیر‑SVG که در طول صادرات Markdown ایجاد می‌شوند، استفاده کنید. کال‑بک `MarkdownImageSavingHandler` یک شیء [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/)، مقدار [ImageFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imageformat/) و لینک تولید شده Markdown را به صورت آرایه‌ای جاوا با یک عنصر دریافت می‌کند. تصویر را با فرمت ارائه شده ذخیره یا بارگذاری کنید و `$link[0]` را با مرجعی که باید در خروجی Markdown ظاهر شود، جایگزین کنید.

منابعی که در قالب SVG صادر می‌شوند به‌صورت جداگانه پردازش می‌شوند. یک کال‑بک با متد [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) ثبت کنید. کال‑بک `MarkdownSvgImageSavingHandler` یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/isvgimage/) و آرایه یک عنصری `$link` دریافت می‌کند. SVG هیچ آرگومان `ImageFormat` ندارد؛ داده‌های XML آن را از متد [ISvgImage::getSvgData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/isvgimage/) بنویسید یا بارگذاری کنید. بسته به حالت صادرات و گروه‌بندی بصری، یک SVG در ارائه منبع می‌تواند رستر شود یا با محتویات دیگر ترکیب شود؛ منبع غیر‑SVG حاصل سپس به کال‑بک ذخیره‌سازی تصویر پاس داده می‌شود. هر دو کال‑بک را زمانی که هر منبع بصری صادر شده نیاز به پردازش سفارشی دارد، ثبت کنید.

در PHP via Java، هر کال‑بک را در یک کلاس PHP پیاده‌سازی کنید و از `java_closure` برای نمایش آن شیء به عنوان اینترفیس مربوطه در جاوا استفاده کنید.

{{% alert color="info" title="Note" %}}
پیش از بارگذاری `Java.inc`، پل PHP/Java را با فعال‌سازی `JAVA_PREFER_VALUES` مقداردهی اولیه کنید. متد [Presentation::save](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) مقدار `void` برمی‌گرداند و حالت پیش‌فرض جریان پل نمی‌تواند یک کال‑بک PHP را در طول این فراخوانی صف‌گذاری شده اجرا کند. مثال کامل زیر شامل مقداردهی اولیه مورد نیاز است.
{{% /alert %}}

مقدار بازگشتی هندلر تعیین می‌کند که چه کسی تصویر را پردازش می‌کند:

- پس از ذخیره، بارگذاری، تبدیل یا هر پردازش دیگری تصویر و اختصاص یک مقدار معتبر به `$link[0]`، `true` بازگردانید. Aspose.Slides این مقدار را در سند Markdown می‌نویسد و ذخیره‌سازی محلی پیش‌فرض را انجام نمی‌دهد.
- `false` بازگردانید تا Aspose.Slides تصویر را به صورت محلی ذخیره کند و لینک آن را بر اساس مقادیری که با [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) و [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) تنظیم شده‌اند، تولید کند.

{{% alert color="warning" title="Important" %}}
یک هندلر که `true` برمی‌گرداند، مسئولیت تصویر را بر عهده می‌گیرد. اگر بدون اختصاص یک لینک معتبر و غیرخالی `true` برگرداند، صادرات با `InvalidOperationException` شکست می‌خورد.
{{% /alert %}}

### **ذخیره تصاویر در یک پوشه منبع CDN و استفاده از URLهای خارجی**

مثال زیر پوشه `cdn-origin/presentations/quarterly-report` را به‌عنوان یک پوشه منبع CDN سوار یا همگام‌سازی‌شده در نظر می‌گیرد. هر هندلر نام فایل تولید شده را استخراج می‌کند، تصویر را در آن پوشه سفارشی ذخیره می‌کند و مرجع محلی تولید شده را با یک URL عمومی CDN جایگزین می‌کند. خود نمونه هیچ آپلود شبکه‌ای انجام نمی‌دهد: URL فقط زمانی معتبر می‌شود که پوشه به‌عنوان منبع CDN سوار شود یا فایل‌های آن به CDN منتشر شوند. برای ذخیره‌سازی شیء، نوشتن به سیستم فایل را با عملیات بارگذاری SDK ذخیره‌سازی جایگزین کنید و `$link[0]` را فقط پس از موفقیت‌آمیز شدن بارگذاری اختصاص دهید.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

هندلر bitmap عمداً برای تصاویر کوچکتر از 128 × 128 پیکسل `false` برمی‌گرداند، بنابراین Aspose.Slides این تصاویر را در `output/fallback-images` با رفتار پیش‌فرض ذخیره می‌کند. منابع bitmap و metafile بزرگ‌تر، همراه با منابع SVG، توسط کد سفارشی پردازش می‌شوند. به‌عنوان مثال، مرجع محلی تولید شده‌ای مانند `fallback-images/image1.png` به `https://cdn.example.com/presentations/quarterly-report/image1.png` تبدیل می‌شود. هندلرها فقط هنگام نوشتن فایل‌ها از مسیرهای سیستم‌عامل استفاده می‌کنند؛ لینک‌های نوشته‌شده در Markdown از اسلش‌های جلو (`/`) و نام‌های فایل URL‑escaped استفاده می‌کنند. همان قاعده را هنگام ساخت لینک‌های نسبی اعمال کنید: از `/` استفاده کنید، نه جداکنندهٔ مخصوص پلتفرم.

## **سوالات متداول**

**آیا یک هندلر می‌تواند هم تصاویر رستر و هم تصاویر SVG را پردازش کند؟**

خیر. برای منابع bitmap و metafile صادر شده از [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) استفاده کنید و برای منابع صادرشده به‌صورت SVG از [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) استفاده کنید. اولی یک شیء [IImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/iimage/) و مقدار [ImageFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/imageformat/) را فراهم می‌کند؛ دومی یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/isvgimage/) که دادهٔ SVG آن را می‌توان با [ISvgImage::getSvgData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/isvgimage/) خواند. یک SVG منبع که در طول صادرات رستر می‌شود، به‌جای این، توسط کال‑بک ذخیره‌سازی تصویر پردازش می‌شود.

**وقتی یک هندلر ذخیره‌سازی تصویر `false` برمی‌گرداند چه اتفاقی می‌افتد؟**

Aspose.Slides از رفتار پیش‌فرض ذخیره‌سازی محلی خود استفاده می‌کند. مکان تصویر و مرجع تولید شده توسط مقادیری که با [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) و [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/markdownsaveoptions/) تنظیم شده‌اند، کنترل می‌شود.

**آیا یک هندلر می‌تواند بدون ذخیرهٔ تصویر به‌صورت محلی یک URL ارائه دهد؟**

بله. هندلر می‌تواند تصویر را به ذخیره‌سازی شیء بارگذاری کند یا به سرویس دیگری منتقل کند، URL حاصل را به `$link[0]` اختصاص دهد و `true` برگرداند. هندلر باید پردازش را به‌طور کامل خود انجام دهد؛ بازگرداندن `true` جلوگیری از ذخیره‌سازی محلی پیش‌فرض می‌کند.

**چرا صادرات Markdown یک `InvalidOperationException` از یک هندلر پرتاب می‌کند؟**

این استثنا زمانی رخ می‌دهد که هندلر `true` برگرداند اما لینک معتبری ارائه ندهد. قبل از برگرداندن `true` مسیر نسبی یا URL خارجی که باید در Markdown نوشته شود را به `$link[0]` اختصاص دهید.

**کدام جداکنندهٔ مسیر باید در لینک‌های تصویر استفاده شود؟**

در لینک‌های Markdown و URLها از اسلش‌های جلو (`/`) استفاده کنید. `DIRECTORY_SEPARATOR` فقط برای مسیرهای سیستم‌فایل به‌کار رود و سپس مرجع Markdown را به‌طور جداگانه ساخت یا نرمال کنید.

**آیا پیوندهای ابرمتن در طول صادرات Markdown حفظ می‌شوند؟**

بله. پیوندهای متنی [hyperlinks](/slides/fa/php-java/manage-hyperlinks/) به‌عنوان لینک‌های استاندارد Markdown حفظ می‌شوند. [transitions](/slides/fa/php-java/slide-transition/) اسلاید و [animations](/slides/fa/php-java/powerpoint-animation/) تبدیل نمی‌شوند.

**آیا می‌توان ارائه‌ها را به‌صورت هم‌زمان به Markdown تبدیل کرد؟**

می‌توانید فایل‌های ارائه مختلف را به‌صورت هم‌زمان پردازش کنید، اما نباید همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را بین رشته‌ها به اشتراک بگذارید. راهنمایی‌های [multithreading](/slides/fa/php-java/multithreading/) را دنبال کنید و برای هر فایل یک نمونهٔ جداگانه استفاده کنید.