---
title: دریافت و به‌روزرسانی اطلاعات ارائه در PHP
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/php-java/examine-presentation/
keywords:
- فرمت ارائه
- خواص ارائه
- خواص سند
- دریافت خواص
- خواندن خواص
- تغییر خواص
- اصلاح خواص
- به‌روزرسانی خواص
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای PHP کاوش کنید تا بینش‌های سریع‌تر و بررسی‌های محتوا هوشمندانه‌تری داشته باشید."
---
## **نمای کلی**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت موجودی یا بررسی ویژگی‌ها پیش از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

این مقاله با استفاده از [PresentationFactory]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/}} و [PresentationInfo]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/}}، بازرسی سبک وزن را نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند از طریق [DocumentProperties]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/}} را به نمایش می‌گذارد.

## **بررسی فرمت یک ارائه**

اگر قبلاً یک ارائه بارگذاری‌شده دارید، برای تشخیص پس از بارگذاری و محدودیت‌های جریان‌های PPT، PPS و POT قدیمی به مقاله [Determine the Original Presentation Format](/slides/fa/php-java/detect-presentation-source-format/) مراجعه کنید.

از [PresentationFactory::getPresentationInfo]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/}} برای بازرسی یک فایل بدون ایجاد یک نمونه [Presentation]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/}} استفاده کنید. متد [PresentationInfo::getLoadFormat]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#getLoadFormat}} فرمت شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **ساخت موجودی سبک وزن برای ارائه‌ها**

هنگامی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به موجودی فشرده‌ای برای اعتبارسنجی، ایندکس‌سازی یا سیستم مدیریت اسناد نیاز داشته باشید. در این حالت، از [PresentationFactory::getPresentationInfo]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/}} برای دریافت یک شیء [PresentationInfo]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/}} استفاده کنید و سپس متد [PresentationInfo::readDocumentProperties]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties}} را برای خواندن متادیتای سند فراخوانی کنید. این روش هیچ نمونه‌ای از [Presentation]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/}} ایجاد نمی‌کند و نیازی به عبور از مدل شیء کامل ارائه ندارید.

ویژگی‌های توسعه‌یافته‌ای که توسط [DocumentProperties]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/}} ارائه می‌شوند، مقادیر موجودی زیر را فراهم می‌آورند:

| Method | مقدار موجودی |
| --- | --- |
| [getSlides]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getSlides}} | تعداد کل اسلایدها. |
| [getHiddenSlides]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getHiddenSlides}} | تعداد اسلایدهای مخفی. |
| [getNotes]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getNotes}} | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getParagraphs}} | تعداد کل پاراگراف‌ها، در صورت موجود بودن. |
| [getWords]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getWords}} | تعداد کل کلمات. |
| [getMultimediaClips]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getMultimediaClips}} | تعداد کل کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد شیء [Presentation]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/}} می‌خواند و موجودی فشرده‌ای را چاپ می‌کند. همچنین [DocumentProperties::getHeadingPairs]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getHeadingPairs}} را با [DocumentProperties::getTitlesOfParts]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getTitlesOfParts}} ترکیب می‌کند تا گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوین اسلاید را نمایش دهد.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

هر [HeadingPair]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/headingpair/}} یک نام گروه و تعداد موارد در آن گروه را فراهم می‌کند. [DocumentProperties::getTitlesOfParts]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getTitlesOfParts}} یک آرایه صاف و مرتب برمی‌گرداند، بنابراین عدد عناوین متوالی تعیین‌شده توسط هر جفت‌عنوان را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های فرمت**

خواص موجودی که توسط [PresentationInfo::readDocumentProperties]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties}} برگردانده می‌شوند، متادیتای موجود در سند منبع را منعکس می‌کنند. Aspose.Slides مدل شیء ارائه را برای محاسبه مجدد این مقادیر بارگذاری و عبور نمی‌کند. خواص گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است قدیمی باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، خواص سند را به‌روزرسانی نکرده باشد.

- **PPTX:** این فرمت خواص سند گسترش‌یافته برای شمارش اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و چندرسانه‌ای، همچنین جفت‌عناوین و عناوین بخش‌ها را فراهم می‌کند. در دسترس بودن آن بستگی به این دارد که کدام خواص توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** این فرمت باینری می‌تواند خواص خلاصه سند متناظر را ذخیره کند. اگر یک خاصیت غایب باشد یا توسط تولیدکننده سند به‌روزرسانی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند، نه این‌که از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند تعداد صفحات، پاراگراف و کلمه را ارائه می‌دهد، اما این مقادیر به هر خاصیت گسترش‌یافته مخصوص PowerPoint مطابقت نمی‌شوند. متادیتای اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت‌عنوان و عنوان بخش ممکن است در دسترس نباشد و خواص موجودی ممکن است مقادیر پیش‌فرض را برگردانند. صفر یا آرایه خالی را به‌عنوان مدرک قطعی عدم وجود محتوا در نظر نگیرند.

از روش متادیتای سبک وزن برای موجودی‌ها و بررسی‌های اولیه استفاده کنید. هنگامی که نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زنده آن را بازرسی کنید.

## **به‑روز‌رسانی خواص ارائه**

خواص برگردانده‌شده توسط [PresentationInfo::readDocumentProperties]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties}} را می‌توان بدون ایجاد یک نمونه [Presentation]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/}} نیز تغییر داد. تغییرات را با [PresentationInfo::updateDocumentProperties]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#updateDocumentProperties}} اعمال کنید و سپس ارائه باند شده را با [PresentationInfo::writeBindedPresentation]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#writeBindedPresentation}} بنویسید.

تصویر زیر خواص سند اصلی ارائه PowerPoint را نشان می‌دهد.

![خواص سند اصلی ارائه PowerPoint](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره را تغییر می‌دهد و نتیجه را در فایلی جدید می‌نویسد:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

تصویر زیر خواص سند به‌روزرسانی‌شده را نشان می‌دهد.

![خواص سند تغییر یافته ارائه PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، به مقالات زیر مراجعه کنید:

- [Password-Protect Presentations](/slides/fa/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/php-java/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و چه قلم‌هایی هستند؟**

ارائه را بارگذاری کنید و از [Presentation::getFontsManager]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getFontsManager}} استفاده کنید. با فراخوانی [FontsManager::getEmbeddedFonts]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts}} قلم‌های جاسازی‌شده و با [FontsManager::getFonts]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getFonts}} قلم‌های استفاده‌شده توسط ارائه را به‌دست آورید. دو نتیجه را با هم مقایسه کنید تا قلم‌هایی که برای رندر لازم هستند اما جاسازی نشده‌اند، شناسایی کنید.

**چگونه می‌توانم به‑سرعت تشخیص دهم که فایل اسلایدهای مخفی دارد و تعداد آن‌ها چقدر است؟**

زمانی که متادیتای ذخیره‌شده سند کافی باشد، [DocumentProperties::getHiddenSlides]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getHiddenSlides}} را از طریق [PresentationFactory::getPresentationInfo]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/}} و [PresentationInfo::readDocumentProperties]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties}} بخوانید. این روش برای موجودی سبک وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد، متادیتای ذخیره‌شده ممکن است مفقود یا قدیمی باشد یا بخواهید مقادیر زنده را تأیید کنید، به جای آن از [Presentation::getSlides]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlides}} عبور کنید و برای هر اسلاید متد [Slide::getHidden]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getHidden}} را بررسی کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت سفارشی اسلاید استفاده شده‌اند و آیا از پیش‌فرض‌ها متفاوت هستند؟**

بله. ارائه را بارگذاری کنید و متد [Presentation::getSlideSize]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlideSize}} را فراخوانی کنید. با استفاده از [SlideSize::getType]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/#getType}}، [SlideSize::getSize]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/#getSize}} و [SlideSize::getOrientation]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/#getOrientation}} تنظیمات فعلی را با پیش‌تنظیم‌ها و ابعاد مورد انتظار مقایسه کنید.

**آیا راه سریع برای دیدن این که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/}} را پیدا کنید و متد [ChartData::getDataSourceType]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#getDataSourceType}} را فراخوانی کنید. برای یک کتاب کار خارجی، متد [ChartData::getExternalWorkbookPath]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#getExternalWorkbookPath}} را فراخوانی کنید. نوع منبع داده و مسیر یک ارجاع خارجی را نشان می‌دهند، اما تأیید موجودیت هدف نیاز به بررسی منابع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ خاصیت تک‌دست برای پیچیدگی وجود ندارد. از [Presentation::getSlides]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlides}} عبور کنید و مجموعه [BaseSlide::getShapes]{{https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getShapes}} هر اسلاید را بررسی کنید. از شمارش شکل‌ها و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای به‌عنوان علائم غربالگری استفاده کنید و یک رندر یا خروجی نمایشی نمونه بگیرید تا قبل از اعتبارسنجی یک اسلاید به‌عنوان نقطه گلوگاه عملکردی، آن را تأیید کنید.