---
title: ادغام کارآمد ارائه‌ها در PHP
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/php-java/merge-presentation/
keywords:
- ادغام PowerPoint
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- PHP
- Aspose.Slides
description: "بیاموزید چگونه در PHP ارائه‌های PowerPoint و OpenDocument را با تکثیر اسلایدها، کنترل مسترها و قالب‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها، و مدیریت فایل‌های محافظت‌شده یا بزرگ ادغام کنید."
---
## **بررسی کلی**

Aspose.Slides برای PHP از طریق Java ارائه‌ها را با تکثیر اسلایدها از یک [ارائه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) به دیگری ادغام می‌کند. عمل اصلی [SlideCollection::addClone()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید تکثیر شده را به یک مستر یا قالب در ارائه مقصد پیوست کند.

این مقاله رایج‌ترین روندهای ادغام را پوشش می‌دهد:

- ادغام تمام اسلایدها به‌طوری که قالب‌بندی منبع آن‌ها حفظ شود؛
- ادغام اسلایدهای انتخابی؛
- اعمال مستری از ارائه مقصد؛
- اعمال یک قالب خاص از ارائه مقصد؛
- نرمال‌سازی سایزهای مختلف اسلاید قبل از ادغام؛
- افزودن اسلایدهای تکثیر شده به یک بخش؛
- ادغام چندین ارائه در یک جریان کاری انتها به انتها؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، فونت‌ها، پسوردها، فایل‌های بزرگ و ملاحظات چندنخی.

## **چگونه تکثیر اسلاید بر مسترها و قالب‌ها تأثیر می‌گذارد**

یک اسلاید بخش عمده‌ای از ظاهر خود را از قالب و مسترش به ارث می‌برد. به همین دلیل، overload تکثیری که انتخاب می‌کنید تعیین می‌کند اسلاید ادغام شده چگونه در ارائه مقصد یکپارچه می‌شود.

از [SlideCollection::addClone()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) به یکی از روش‌های زیر استفاده کنید:

- `addClone(sourceSlide)` — حفظ قالب و قالب‌بندی اسلاید منبع. در صورت نیاز، مستر منبع می‌تواند به‌صورت خودکار به ارائه مقصد تکثیر شود. Aspose.Slides مسترهای تکثیر شده به‌صورت خودکار را ردیابی می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را چندین بار تکثیر نکنند.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — پیوست اسلاید تکثیر شده به یک [MasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) خاص در مقصد. Aspose.Slides به‌دنبال یک قالب منطبق زیر آن مستر بر اساس نوع یا نام قالب می‌گردد.
- `addClone(sourceSlide, destinationLayout)` — پیوست اسلاید تکثیر شده مستقیماً به یک [LayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) خاص در مقصد.

مستر یا قالبی که به overload `addClone` داده می‌شود باید متعلق به ارائه **مقصد** باشد، نه ارائه منبع.

## **ادغام کل ارائه‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین روش ادغام، کپی تمام اسلایدها از ارائه منبع به ارائه مقصد است. این گزینه زمانی مناسب است که اسلایدهای وارد شده باید تم، مستر و روابط قالب اصلی خود را حفظ کنند.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

ارائه حاصل ممکن است شامل چندین مستر باشد زمانی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار وقتی که قالب‌بندی منبع به‌صورت عمدی حفظ می‌شود، پیش‌بینی‌شده است.

## **ادغام اسلایدهای انتخابی**

نیازی به تکثیر تمام اسلایدها نیست. مثال زیر فقط ایندکس‌های اسلایدهای انتخابی را از ارائه منبع وارد می‌کند.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

قبل از تکثیر، ایندکس‌های اسلاید را هنگامی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ادغام اسلایدها با استفاده از مستر مقصد**

از overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) استفاده کنید وقتی که اسلایدهای وارد شده باید تحت یک مستر که قبلاً به ارائه مقصد تعلق دارد، باشند.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides یک قالب مناسب زیر مستر مشخص را بر اساس تطبیق نوع یا نام قالب منبع انتخاب می‌کند. اگر قالب مناسبی موجود نباشد و `allowCloneMissingLayout` برابر `true` باشد، قالب منبع تکثیر می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.

هنگامی که می‌خواهید ادغام با شکست مواجه شود به‌جای افزودن یک قالب جدید به مستر مقصد، از `false` استفاده کنید.

## **ادغام اسلایدها با استفاده از یک قالب خاص در مقصد**

از overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) استفاده کنید وقتی که دقیقاً می‌دانید کدام قالب مقصد باید توسط اسلایدهای وارد شده استفاده شود.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

اعمال یک قالب مقصد رابطهٔ وراثت قالب را تغییر می‌دهد؛ اما محتوای اسلاید منبع را بازطراحی نمی‌کند. اگر قالب‌های منبع و مقصد ساختار جای‌گزین‌های متفاوتی داشته باشند، نتیجه را بررسی کنید تا اطمینان حاصل کنید قالب‌بندی وراثت‌دار و رفتار جای‌گزین‌ها مناسب است.

## **ادغام ارائه‌ها با اندازه‌های اسلاید متفاوت**

ارائه‌هایی با ابعاد اسلاید متفاوت می‌توانند ادغام شوند، اما تکثیر یک اسلاید به ارائه‌ای با اندازه اسلاید دیگر به‌صورت خودکار محتوای آن را برای بوم جدید بازطراحی نمی‌کند. بنابراین اشکال ممکن است جابجا، به‌صورت غیرمنتظره مقیاس‌گذاری شوند یا خارج از ناحیه قابل مشاهده اسلاید ظاهر شوند.

یک روش عملی این است که قبل از تکثیر، اندازهٔ ارائه منبع را تغییر اندازه دهید. متد [SlideSize::setSize()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/setsize/) می‌تواند محتوا را مقیاس‌گذاری کند در حالی که ابعاد اسلاید را تغییر می‌دهد. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesizescaletype/) محتوا را برای جا شدن در اندازهٔ درخواست‌شده مقیاس می‌کند.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

تغییر اندازه، شیء ارائه منبع در حافظه را تغییر می‌دهد. اگر به نسخهٔ اصلی ارائه منبع برای عملیات دیگر نیاز دارید که بدون تغییر بماند، یک نمونهٔ جداگانه برای ادغام باز کنید.

## **ادغام اسلایدها در یک بخش ارائه**

حلقهٔ پایهٔ تکثیر اسلاید ساختار بخش‌های ارائه منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم‌اند، بخش‌ها را در ارائه مقصد ایجاد یا انتخاب کنید و اسلایدها را به‌طور صریح با [addClone(Slide, Section)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) به آن‌ها تکثیر کنید.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

اسلایدهای تکثیر شده به بخش مقصد تعیین‌شده اضافه می‌شوند. برای حفظ چندین بخش منبع، آن بخش‌ها را در مقصد بازسازی کنید و هر اسلاید منبع را به بخش مقصد مربوطه نگاشت کنید.

## **ادغام ایمن چندین ارائه**

مثال انتها به انتهای زیر از اولین ارائه به‌عنوان مقصد استفاده می‌کند، اندازهٔ اسلاید هر منبع اضافی را نرمال می‌سازی، هر منبع را تنها در حین کپی باز نگه می‌دارد و در پایان یک‌بار فایل نهایی را ذخیره می‌کند.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

این یک پایهٔ مفید برای حفظ قالب‌بندی منبع اسلایدهای وارد شده است. اگر خروجی شما باید از یک تم مقصد استفاده کند، فراخوانی سادهٔ `addClone($slide)` را با overload مناسب مستر مقصد یا قالب مقصد که پیش‌تر نشان داده شد، جایگزین کنید.

## **موارد عملیاتی**

### **مسترها، قالب‌ها و صحت قالب‌بندی**

تکثیر پیش‌فرض اسلاید می‌تواند مستر مورد نیاز منبع را به‌صورت خودکار به ارائه مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای تکثیر شده به‌صورت خودکار نگه می‌دارد تا از تکثیر مکرر همان مستر جلوگیری کند. مسترهای تکثیر شده به‌صورت دستی توسط آن رجیستری پیگیری نمی‌شوند، بنابراین از پیش‑تکثیر مسترها صرف نظر کنید مگر اینکه نیاز به کنترل صریح بر ساختار مستر داشته باشید.

فرض نکنید دو مستر یا قالب با نام یکسان از نظر بصری یکسان هستند. اگر یک الگوی شرکتی باید ظاهر نهایی را کنترل کند، مستر یا قالب مقصد را صریحاً انتخاب کنید و پس از ادغام نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلایدها با محتوای اسلاید مرتبط هستند و هنگام تکثیر اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [یادداشت‌های ارائه](https://docs.aspose.com/slides/fa/php-java/presentation-notes/) و [نظرات ارائه](https://docs.aspose.com/slides/fa/php-java/presentation-comments/) فراهم می‌کند.

اگر قالب‌بندی صفحه یادداشت مهم است، ارائهٔ ادغام‌شده را بررسی کنید زیرا مسترهای یادداشت‌های صفحه در سطح ارائه هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های کاری بازبینی، نویسندگان نظرات و نظرات زنجیره‌ای را پس از ترکیب فایل‌ها از نویسندگان یا الگوهای مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیای OLE و لینک‌های خارجی**

اسلایدها می‌توانند به منابع سطح ارائه مانند تصاویر، صداهای جاسازی‌شده، ویدئوهای جاسازی‌شده و داده‌های OLE ارجاع دهند. به‌جای کپی فقط شکل‌های قابل مشاهده، کل اسلاید را تکثیر کنید تا Aspose.Slides بتواند روابط اسلاید با منابعش را نگه دارد.

منابع جاسازی‌شده و لینک‌شده باید به‌صورت متفاوتی رفتار شوند. یک صدا، ویدئو، شیء OLE یا پیوند خارجی همچنان به هدف خارجی خود وابسته است؛ تکثیر اسلاید یک لینک خارجی را به محتوای جاسازی‌شده تبدیل نمی‌کند. مسیرها و URLهای منابع لینک‌شده را در محیطی که ارائهٔ ادغام‌شده باز خواهد شد، آزمایش کنید.

Aspose.Slides به‌صورت صریح مسترهای تکثیر شده به‌صورت خودکار را ردیابی می‌کند، اما این نباید به‌عنوان تضمین کلی برای حذف تکراری منابع باینری یکسان از ارائه‌های منبع نامرتبط تلقی شود. اگر اندازهٔ فایل خروجی مهم است، بستهٔ ادغام‌شده را بررسی کنید و نتیجه را اندازه‌گیری کنید به‌جای تکیه بر حذف تکراری ضمنی.

### **فونت‌های جاسازی‌شده و در دسترس بودن فونت‌ها**

فونت‌ها در سطح ارائه مدیریت می‌شوند. اگر نوشتار باید در تمام ماشین‌ها ثابت بماند، فرض نکنید تکثیر اسلایدها به‌تنهایی تضمین می‌کند هر فونت مورد نیاز در محیط مقصد موجود باشد. می‌توانید فونت‌های جاسازی‌شده را با [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getembeddedfonts/) بررسی کنید و جاسازی را به‌صورت صریح همان‌گونه که در [جاسازی فونت‌ها در ارائه‌ها](https://docs.aspose.com/slides/fa/php-java/embedded-font/) توضیح داده شده، مدیریت کنید.

همچنین اطمینان حاصل کنید که اجازهٔ جاسازی فونت‌های استفاده‌شده در فایل‌های منبع را دارید. مجوزهای فونت می‌توانند جاسازی را محدود کنند.

### **ارائه‌های محافظت‌شده با رمز عبور**

یک منبع محافظت‌شده با رمز عبور باید پیش از تکثیر اسلایدهای آن با موفقیت باز شود. رمز عبور را از طریق [LoadOptions::setPassword()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/setpassword/) فراهم کنید.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // با ارائه رمزگشایی‌شده کار کنید.
} finally {
    $source->dispose();
}
```

باز کردن منبع رمزنگاری‌شده به‌صورت خودکار همان حفاظت را به ارائهٔ مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را به‌صورت جداگانه پیکربندی کنید.

### **ارائه‌های بزرگ و مصرف حافظه**

ارائه‌های بزرگ شامل تصاویر با وضوح بالا، صدا، ویدئو یا سایر اشیای باینری بزرگ می‌توانند حافظهٔ قابل‌توجهی مصرف کنند. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) کنترل‌هایی برای مدیریت BLOB و استفاده از فایل‌های موقت فراهم می‌کند. برای مثال فایل بزرگ در PHP از طریق Java به [Open Presentations](https://docs.aspose.com/slides/fa/php-java/open-presentation/#open-large-presentations) مراجعه کنید.

برای فایل‌های بزرگ، در صورت امکان از بارگذاری از مسیرهای فایل استفاده کنید، هر ارائهٔ منبع را به‌محض ادغام آن نابود کنید و از ذخیره مکرر نتایج میانی خودداری کنید مگر اینکه جریان کاری نیاز به نقطه‌های کنترل داشته باشد.

### **ایمنی در چندنخی**

در چندین رشته به‌صورت همزمان [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را بارگذاری، تغییر، ذخیره یا تکثیر نکنید. این عملیات برای استفادهٔ چندنخی در PHP از طریق Java پشتیبانی نمی‌شوند. اگر به کارهای ادغام موازی نیاز دارید، آن‌ها را در پردازش‌های تک‌نخی جداگانه اجرا کنید؛ به‌طوری که هر پردازش از نمونه‌های ارائهٔ خود استفاده کند و راهنمایی‌های چندنخی Aspose.Slides را دنبال کنید.

## **پرسش‌های متداول**

**چگونه طراحی اصلی هر ارائهٔ منبع را حفظ کنم؟**

از [`addClone(sourceSlide)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) بدون ارائهٔ مستر یا قالب مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار زمانی که اسلاید وارد شده نیاز داشته باشد، تکثیر کند.

**چگونه اسلایدهای وارد شده از تم مقصد استفاده کنند؟**

از overloadی که مستر مقصد را می‌پذیرند استفاده کنید. مستری از ارائهٔ مقصد، نه از منبع، ارسال کنید. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک قالب مناسب زیر آن مستر نگاشت کند.

**چه زمانی باید به‌جای مستر مقصد، یک قالب مقصد خاص استفاده کنم؟**

وقتی هر اسلاید وارد شده باید از یک قالب شناخته‌شده استفاده کند، یک قالب خاص را استفاده کنید. وقتی می‌خواهید Aspose.Slides بین قالب‌های آن مستر براساس نوع یا نام قالب منبع انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان ارائه‌های با اندازه‌های اسلاید متفاوت را ادغام کرد؟**

بله، اما محتویات اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. وقتی به‌جایگذاری پیش‌بینی‌شده نیاز دارید، ابتدا اندازهٔ ارائه منبع را با مثال [SlideSize::setSize()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/setsize/) و [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesizescaletype/) تغییر اندازه دهید.

**آیا می‌توانم ارائه‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر ارائهٔ منبع را بارگذاری کنید، اسلایدهای مورد نیاز را به یک مقصد تکثیر کنید و مقصد را در قالب خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های ارائه دقیقاً مجموعهٔ ویژگی‌های یکسانی ندارند، پس از ادغام‌های میان‌فرمتی محتوای پیچیده را بررسی کنید. به [Supported File Formats](https://docs.aspose.com/slides/fa/php-java/supported-file-formats/) مراجعه کنید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه، حلقهٔ پایه‌ای که فقط اسلایدها را تکثیر می‌کند، بخش‌های منبع را حفظ نمی‌کند. بخش‌های مورد نیاز را در مقصد بازسازی کنید و هنگام نیاز به حفظ ساختار بخش‌ها، از overload بخش [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) استفاده کنید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

آن‌ها همراه با اسلاید تکثیر شده کپی می‌شوند. برای جریان‌های کاری که به قالب‌بندی مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های مرور زنجیره‌ای وابسته‌اند، نتیجهٔ ادغام را بررسی کنید چون این سناریوها شامل ساختارهای سطح ارائه و همچنین محتوای سطح اسلاید هستند.

**چه اتفاقی برای صدا، ویدئو، اشیای OLE و هایپرلینک‌ها می‌افتد؟**

محتوای جاسازی‌شده به‌عنوان بخشی از روابط منابع اسلاید تکثیر شده حمل می‌شود. لینک‌های خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف آن‌ها باید پس از ادغام در دسترس باشند.

**آیا فونت‌های جاسازی‌شده از هر منبع تضمین می‌شود در ارائهٔ ادغام‌شده موجود باشند؟**

به‌تنهایی به تکثیر اسلایدها برای استقرار فونت تکیه نکنید. فونت‌های جاسازی‌شدهٔ مقصد را بررسی کنید و هنگام اهمیت تایپوگرافی، جاسازی فونت یا در دسترس بودن فونت‌های خارجی را به‌صورت صریح مدیریت کنید.

**چگونه یک فایل محافظت‌شده با رمز عبور را ادغام کنم؟**

آن را با [LoadOptions::setPassword()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/setpassword/) صحیح باز کنید، سپس اسلایدهای آن را به‌طور معمول تکثیر کنید. حفاظت خروجی به‌صورت جداگانه پیکربندی می‌شود.

**چگونه باید با ارائه‌های بسیار بزرگ برخورد کنم؟**

هنگامی که اشیای باینری بزرگ مصرف حافظه را به‌سختی تحت‌الشعاع می‌گذارند، از مدیریت BLOB استفاده کنید، برای فایل‌های بسیار بزرگ ترجیحاً بارگذاری از مسیر فایل، منابع ارائهٔ منبع را بلافاصله پس از استفاده نابود کنید و نتیجهٔ نهایی را تنها زمانی که نیاز است ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین رشته ادغام کنم؟**

بارگذاری، ذخیره یا تکثیر ارائه‌ها در چندین رشته در PHP از طریق Java پشتیبانی نمی‌شود. برای کارهای موازی، از پردازش‌های تک‌نخی جداگانه استفاده کنید و نمونه‌های ارائه را در هر پردازش جداگانه ایزوله نگه دارید.