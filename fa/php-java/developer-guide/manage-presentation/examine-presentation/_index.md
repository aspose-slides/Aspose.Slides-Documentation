---
title: دریافت و به‌روزرسانی اطلاعات ارائه در PHP
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/php-java/examine-presentation/
keywords:
- فرمت ارائه
- ویژگی‌های ارائه
- ویژگی‌های سند
- دریافت ویژگی‌ها
- خواندن ویژگی‌ها
- تغییر ویژگی‌ها
- اصلاح ویژگی‌ها
- به‌روزرسانی ویژگی‌ها
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "با استفاده از Aspose.Slides برای PHP، اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument بررسی کنید تا بینش‌های سریع‌تری به‌دست آورید و ارزیابی‌های محتوا هوشمندانه‌تری انجام دهید."
---
## **مروری**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این امر هنگامی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت یک فهرست یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه دارید.

این مقاله با استفاده از [PresentationFactory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/) بازرسی سبک وزن را نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند را از طریق [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/) ارائه می‌کند.

## **بررسی فرمت یک ارائه**

از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/) برای بازرسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) استفاده کنید. متد [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#getLoadFormat) فرمت شناسایی‌شده را گزارش می‌کند، مانند PPTX، PPT یا ODP.

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

## **ساخت فهرست سبک وزن ارائه‌ها**

هنگامی که فایل‌های بسیاری از ارائه‌ها را پردازش می‌کنید، ممکن است به یک فهرست فشرده برای اعتبارسنجی، ایندکس‌گذاری یا سامانه مدیریت اسناد نیاز داشته باشید. در این حالت، از [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/) برای دریافت یک شیء [PresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/) استفاده کنید و سپس متد [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties) را برای خواندن متادیتای سند فراخوانی کنید. این رویکرد هیچ نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه ندارد.

ویژگی‌های توسعه‌یافته‌ای که توسط [DocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/) فراهم می‌شود، مقادیر زیر را برای فهرست ارائه می‌دهد:

| متد | مقدار موجودی |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getSlides) | کل تعداد اسلایدها. |
| [getHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getHiddenSlides) | تعداد اسلایدهای پنهان. |
| [getNotes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getNotes) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [getParagraphs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getParagraphs) | کل تعداد پاراگراف‌ها، در صورتی که موجود باشد. |
| [getWords](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getWords) | کل تعداد کلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getMultimediaClips) | کل تعداد کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) می‌خواند و فهرست فشرده‌ای چاپ می‌کند. همچنین با ترکیب [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getHeadingPairs) و [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getTitlesOfParts) گروه‌های محتوایی مانند قلم‌ها، تم‌ها و عناوین اسلایدها را نمایش می‌دهد.

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

هر [HeadingPair](https://reference.aspose.com/slides/fa/php-java/aspose.slides/headingpair/) یک نام گروه و تعداد آیتم‌های آن گروه را فراهم می‌کند. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getTitlesOfParts) یک آرایه صاف و مرتب برمی‌گرداند، بنابراین تعداد عناوین متوالی که توسط هر جفت سرعنوان مشخص شده‌اند را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های فرمت**

ویژگی‌های فهرست بازگشتی توسط [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties) متادیتای موجود در سند منبع را بازتاب می‌دهند. Aspose.Slides مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را برای این فراخوانی دوباره محاسبه کند. ویژگی‌های گمشده با مقدارهای پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ شوند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این فرمت ویژگی‌های سند توسعه‌یافته‌ای برای شمارش اسلاید، یادداشت، اسلایدهای پنهان، پاراگراف، کلمه و چندرسانه‌ای، همراه با جفت‌های سرعنوان و عناوین بخش‌ها فراهم می‌کند. در دسترس بودن آن وابسته به این است که تولیدکننده سند کدام ویژگی‌ها را نوشت.
- **PPT:** فرمت باینری می‌تواند ویژگی‌های خلاصه‌سند متناظر را ذخیره کند. اگر ویژگی‌ای وجود نداشته باشد یا توسط تولیدکننده سند به‌روزرسانی نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند نه اینکه از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند شمارش صفحات، پاراگراف و کلمه را ارائه می‌دهد، اما این مقادیر با هر ویژگی توسعه‌یافته خاص PowerPoint مطابقت ندارند. متادیتای اسلایدهای پنهان، اسلایدهای یادداشت، چندرسانه‌ای، جفت‌های سرعنوان و عناوین بخش ممکن است در دسترس نباشد و ویژگی‌های فهرست ممکن است مقدار پیش‌فرض برگردانند. مقدار صفر یا آرایه خالی را به‌عنوان اثبات قطعی عدم وجود محتوای متناظر درنظر نگیرید.

از رویکرد متادیتای سبک وزن برای فهرست‌ها و بررسی‌های اولیه استفاده کنید. زمانی که نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زنده آن را بازرسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌های بازگشتی توسط [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties) را می‌توان بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) نیز تغییر داد. تغییرات را با [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) اعمال کنید و سپس ارائه‌ی متصل را با [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#writeBindedPresentation) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائه پاورپوینت را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائه پاورپوینت](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر می‌دهد و نتیجه را در فایلی جدید می‌نویسد:

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

تصویر زیر ویژگی‌های سند به‌روز شده را نشان می‌دهد.

![ویژگی‌های سند به‌روز شده ارائه پاورپوینت](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، مقالات زیر را ببینید:

- [Password-Protect Presentations](/slides/fa/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/php-java/write-protected-presentation/)

## **سؤال‌های متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation::getFontsManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getFontsManager) استفاده کنید. با فراخوانی [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) قلم‌های جاسازی‌شده را دریافت کنید و با [FontsManager::getFonts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/#getFonts) قلم‌های مورد استفاده در ارائه را به‌دست آورید. دو نتیجه را مقایسه کنید تا قلم‌هایی که برای رندر لازم هستند ولی جاسازی نشده‌اند، پیدا کنید.

**چگونه می‌توانم به‌سرعت تشخیص دهم که آیا فایل اسلایدهای پنهان دارد و چندتا؟**

هنگامی که متادیتای ذخیره‌شده سند کافی است، از [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/documentproperties/#getHiddenSlides) از طریق [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationfactory/) و [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentationinfo/#readDocumentProperties) استفاده کنید. این روش برای یک فهرست سبک وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد، متادیتای ذخیره‌شده ممکن است مفقود یا منسوخ باشد یا نیاز به تأیید مقادیر زنده داشته باشید؛ در این صورت به جای آن از [Presentation::getSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlides) پیمایش کنید و برای هر اسلاید متد [Slide::getHidden](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getHidden) را بررسی کنید.

**آیا می‌توانم تشخیص دهم که آیا اندازه و جهت اسلاید سفارشی استفاده می‌شود و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و متد [Presentation::getSlideSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlideSize) را فراخوانی کنید. از [SlideSize::getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/#getType)، [SlideSize::getSize](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/#getSize) و [SlideSize::getOrientation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/#getOrientation) برای مقایسه تنظیمات فعلی با پیش‌تنظیمات و ابعاد مورد انتظار استفاده کنید.

**آیا راه سریعی برای دیدن این وجود دارد که نمودارها به منابع داده خارجی ارجاع می‌دهند؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/) را پیدا کنید و متد [ChartData::getDataSourceType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#getDataSourceType) را فراخوانی کنید. برای یک کتاب کاری خارجی، متد [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chartdata/#getExternalWorkbookPath) را فراخوانی کنید. نوع منبع داده و مسیر، ارجاع خارجی را شناسایی می‌کند، اما بررسی در دسترس بودن هدف نیاز به یک چک منبع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند، ارزیابی کنم؟**

هیچ ویژگی تک‌سکی برای پیچیدگی وجود ندارد. [Presentation::getSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getSlides) و مجموعه [BaseSlide::getShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getShapes) هر اسلاید را پیمایش کنید. از تعداد اشکال و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای‌ها به‌عنوان سیگنال‌های غربالگری استفاده کنید و پیش از این که اسلاید را به‌عنوان گلوگاه عملکردی تأیید کنید، یک رندر یا خروجی نمایشی نمونه‌ای را اندازه‌گیری کنید.