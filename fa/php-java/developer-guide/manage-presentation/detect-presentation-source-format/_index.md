---
title: تعیین فرمت اصلی ارائه در PHP
linktitle: فرمت منبع
type: docs
weight: 35
url: /fa/php-java/detect-presentation-source-format/
keywords:
- فرمت منبع
- تشخیص فرمت ارائه
- پاورپوینت
- OpenDocument
- ارائه
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "فرمت اصلی یک ارائه بارگذاری‌شده را در PHP با Aspose.Slides برای PHP از طریق Java بخوانید، APIهای تشخیص را مقایسه کنید و با فایل‌ها، جریان‌ها و فرمت‌های قدیمی کار کنید."
---
## **نمای کلی**

پس از بارگذاری یک ارائه، متد [Presentation::getSourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSourceFormat) را فراخوانی کنید تا فرمت اصلی آن را تعیین کنید. از این متد زمانی استفاده کنید که پردازش‌های بعدی به فرمی که نمونهٔ فعلی از آن بارگذاری شده وابسته باشد.

فرمت منبع با [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) انتخاب‑شده برای فایل خروجی متفاوت است. ذخیره به فرمت دیگر فرمت منبع نمونهٔ موجود را تغییر نمی‌دهد.

## **خواندن فرمت منبع یک فایل**

این مثال به یک فایل `sample.pptx` موجود نیاز دارد. فایل را بارگذاری می‌کند و به جای نام فایل، با استفاده از [Presentation::getSourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSourceFormat) سیاست پردازش برنامه را انتخاب می‌کند. مسیر ورودی را تغییر دهید تا فرمت‌های دیگر را امتحان کنید. مثال سیاست انتخاب‑شده را چاپ می‌کند؛ پیام‌ها را با منطق برنامهٔ خود جایگزین کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **شناخت مقادیر پشتیبانی‌شده**

کلاس [SourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sourceformat/) ثابت‌های عددی تعریف می‌کند که فرمت‌های ارائه زیر را متمایز می‌سازند. پسوندهای زیر پسوندهای متعارف هستند و بازسازی نام فایل اصلی نیستند.

| مقدار SourceFormat | پسوند | فرمت |
| --- | --- | --- |
| `Ppt` | `.ppt` | ارائهٔ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | ارائهٔ Office Open XML |
| `Pptm` | `.pptm` | ارائهٔ Office Open XML با ماکرو |
| `Pps` | `.pps` | نمایش اسلاید PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | نمایش اسلاید Office Open XML |
| `Ppsm` | `.ppsm` | نمایش اسلاید Office Open XML با ماکرو |
| `Pot` | `.pot` | الگوی PowerPoint 97–2003 |
| `Potx` | `.potx` | الگوی Office Open XML |
| `Potm` | `.potm` | الگوی Office Open XML با ماکرو |
| `Odp` | `.odp` | ارائهٔ OpenDocument |
| `Otp` | `.otp` | الگوی ارائهٔ OpenDocument |
| `Fodp` | `.fodp` | ارائهٔ Flat XML ODF |
| `Xml` | `.xml` | ارائهٔ PowerPoint XML |

## **خواندن فرمت منبع یک جریان**

این مثال به یک فایل `sample.pps` موجود نیاز دارد. خواندن بایت‌های آن در یک جریان حافظه، ورودی بدون نام فایل (مانند مقدار دیتابیس یا آرایهٔ بایتی بارگذاری‑شده) را شبیه‌سازی می‌کند. سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) فقط جریان را دریافت می‌کند.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT، PPS و POT از همان فرمت باینری زیرین استفاده می‌کنند. هنگام بارگذاری بر اساس مسیر فایل، پسوند می‌تواند به تشخیص نمایش اسلاید یا الگو کمک کند. بدون نام فایل، محتوای قدیمی PPS و POT ممکن است به صورت `SourceFormat::Ppt` گزارش شود؛ مثال PPS بالا مقدار عددی `SourceFormat::Ppt` را چاپ می‌کند.

اگر برنامهٔ شما باید این تمایز را حفظ کند، نام فایل اصلی یا فرادادهٔ زیرنوع را جداگانه نگه دارید. پسوند برای این زیرنوع‌های قدیمی یک نکته مفید است، اما نباید تنها معیار شناسایی محتویات ارائهٔ دلخواه باشد.

## **مقایسهٔ تشخیص قبل و بعد از بارگذاری**

هنگامی که نیاز به بررسی یک فایل قبل از بارگذاری کامل مدل شیء ارائه دارید، از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/#getPresentationInfo) و [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#getLoadFormat) استفاده کنید. وقتی نمونه بالفعل وجود دارد، از [Presentation::getSourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSourceFormat) استفاده کنید.

این مثال به `sample.pptx` نیاز دارد و مقادیر عددی `LoadFormat::Pptx` و `SourceFormat::Pptx` را به ترتیب چاپ می‌کند. در محیط تولید، API مناسب مرحلهٔ پردازش خود را انتخاب کنید؛ یک ارائهٔ بارگذاری‑شده نیازی به بازرسی دوم صرفاً برای به دست آوردن فرمت منبع ندارد.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

نتایج از ثابت‌های کلاس‌های مختلف استفاده می‌کند: [LoadFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sourceformat/). مقدار عددی آن‌ها را مقایسه نکنید و فرض نکنید هر فرمت نتایج تشخیص یکسانی دارد. PowerPoint XML ممکن است قبل از بارگذاری به عنوان `LoadFormat::Unknown` گزارش شود و پس از بارگذاری به عنوان `SourceFormat::Xml`.

## **نگه‌داشتن فرمت‌های منبع و خروجی جداگانه**

این مثال به `sample.pptx` نیاز دارد و `converted.odp` را می‌نویسد. مقدار عددی `SourceFormat::Pptx` را هم قبل و هم بعد از ذخیرهٔ نمونهٔ اصلی چاپ می‌کند. تنها نمونهٔ جدید بارگذاری‑شده از خروجی ODP گزارش `Odp` می‌دهد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

یک ارائهٔ ساخته‑شده از ابتدا با `new Presentation()` گزارش `SourceFormat::Pptx` می‌دهد. این نمونه فایل ورودی ندارد: این مقدار پیش‌فرض برای یک نمونهٔ تازه ایجادشده است و نشانگر این نیست که فایلی از نوع PPTX بارگذاری شده است. اگر تمایز بین ساخت و بارگذاری برای برنامهٔ شما مهم است، آن را به صورت جداگانه ردیابی کنید.

## **نگاشت یک فرمت منبع به پسوند**

مثال زیر به `sample.pptx` نیاز دارد. هر مقدار فعلاً پشتیبانی‌شدهٔ [SourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sourceformat/) را به یک پسوند متعارف نگاشت می‌کند، بدون تجزیهٔ نام فایل ورودی. اگر مقدار شناسایی نشد، پسوند اختصاصی به صورت خاموش انجام نمی‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

این نگاشت فایلی را تبدیل یا زیرنوع قدیمی PPS/POT که در هنگام بارگذاری جریان از دست رفته است، بازیابی نمی‌کند. برای ذخیرهٔ واقعی، یک [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) را به‌صورت صریح انتخاب کنید یا از تبدیل نشان‑داده‌شده در [Save Presentations in Their Original Format](/slides/fa/php-java/save-presentation/#save-presentations-in-their-original-format) استفاده کنید.

## **تایید فرمت‌ها با ذخیره و بازگشایی مجدد**

این مثال خود‑محاط یک ارائه ایجاد می‌کند و سه فایل را در پوشهٔ کاری می‌نویسد؛ فایل‌های هم‌نام بازنویسی می‌شوند. هر خروجی را هم بر‑اساس مسیر و هم از طریق یک جریان حافظه باز می‌کند. برای PPTX و ODP هر دو مسیر فرمت ذخیره‑شده را گزارش می‌دهند. برای PPS، بارگذاری بر‑اساس مسیر `Pps` را گزارش می‌کند، در حالی که بارگذاری همان بایت‌ها بدون نام فایل `Ppt` را گزارش می‌دهد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

جدول زیر شناسایی فرمت منبع برای ارائه‌های با پسوندهای مطابقت‌دهنده را خلاصه می‌کند. نام‌ها ثابت‌ها هستند؛ مثال‌های PHP مقدار عددی آن‌ها را چاپ می‌کنند:

| فرمت ذخیره‑شده | SourceFormat از مسیر فایل | SourceFormat از جریان بی‌نام |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` به ترتیب | مشابه مسیر فایل |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` به ترتیب | مشابه مسیر فایل |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` به ترتیب | مشابه مسیر فایل |
| ODP, OTP | `Odp`, `Otp` به ترتیب | مشابه مسیر فایل |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوای PPS/POT در جریان‌های بدون نام به عنوان `Ppt` شناسایی می‌شود. جدول فقط شناسایی فرمت را توصیف می‌کند، نه حفظ تمام ویژگی‌های ارائه در طول تبدیل.

## **سؤالات متداول**

**آیا ذخیره به ODP فرمت منبع ارائه‌ای که از PPTX بارگذاری شده را تغییر می‌دهد؟**

خیر. نمونهٔ موجود همچنان `Pptx` را گزارش می‌دهد. نمونه‌ای که از فایل ODP ذخیره‑شده بارگذاری می‌شود `Odp` را گزارش می‌کند.

**آیا یک جریان همیشه می‌تواند ارائهٔ قدیمی، نمایش اسلاید و الگو را متمایز کند؟**

خیر. PPT، PPS و POT فرمت باینری یکسانی دارند. هنگامی که این تمایز لازم است، نام فایل یا فرادادهٔ زیرنوع را جداگانه نگه دارید.

**کدام API را باید استفاده کنم اگر ارائه قبلاً بارگذاری شده باشد؟**

[Presentation::getSourceFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSourceFormat) را بخوانید. برای بازرسی قبل از بارگذاری از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/#getPresentationInfo) استفاده کنید.