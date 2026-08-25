---
title: ترکیب کارآمد پرزنتیشن‌ها در PHP
linktitle: ترکیب پرزنتیشن‌ها
type: docs
weight: 40
url: /fa/php-java/merge-presentation/
keywords:
- ترکیب PowerPoint
- ترکیب پرزنتیشن‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- ادغام PowerPoint
- ادغام پرزنتیشن‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- PHP
- Aspose.Slides
description: "با کلون کردن اسلایدها، کنترل مسترها و طرح‌بندی‌ها، تغییر اندازه محتوای اسلاید، حفظ بخش‌ها و مدیریت فایل‌های محافظت‌شده یا بزرگ، نحوه ترکیب پرزنتیشن‌های PowerPoint و OpenDocument در PHP را بیاموزید."
---
## **مرور کلی**

Aspose.Slides برای PHP از طریق Java پرزنتیشن‌ها را با کلون کردن اسلایدها از یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) به دیگری ترکیب می‌کند. عملیات اصلی [SlideCollection::addClone()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) است که می‌تواند قالب‌بندی اسلاید منبع را حفظ کند یا اسلاید کلون‌شده را به یک مستر یا طرح‌بندی در پرزنتیشن مقصد متصل کند.

این مقاله رایج‌ترین روش‌های ترکیب را پوشش می‌دهد:

- ترکیب تمام اسلایدها در حالی که قالب‌بندی منبع آن‌ها حفظ می‌شود؛
- ترکیب اسلایدهای انتخابی؛
- اعمال مستر از پرزنتیشن مقصد؛
- اعمال طرح‌بندی خاصی از پرزنتیشن مقصد؛
- نرمال‌سازی اندازه‌های مختلف اسلاید قبل از ترکیب؛
- افزودن اسلایدهای کلون‌شده به یک بخش؛
- ترکیب چندین پرزنتیشن در یک جریان کاری انتها‑به‑انتها؛
- مدیریت مسترها، منابع، یادداشت‌ها، نظرات، رسانه‌ها، فونت‌ها، پسوردها، فایل‌های بزرگ و ملاحظات چندنخی.

## **چگونگی تأثیر کلون کردن اسلاید بر مسترها و طرح‌بندی‌ها**

یک اسلاید بخش بزرگی از ظاهر خود را از طرح‌بندی و مستر خود به ارث می‌برد. به همین دلیل، overload انتخابی شما مشخص می‌کند که اسلاید ترکیب‌شده چگونه در پرزنتیشن مقصد ادغام می‌شود.

از [SlideCollection::addClone()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) به یکی از روش‌های زیر استفاده کنید:

- `addClone(sourceSlide)` — حفظ طرح‌بندی و قالب‌بندی اسلاید منبع. در صورت لزوم، مستر منبع می‌تواند به‌صورت خودکار به پرزنتیشن مقصد کلون شود. Aspose.Slides مسترهای کلون‌شده به‌صورت خودکار را ردیابی می‌کند تا اسلایدهای تکراری که از همان مستر منبع استفاده می‌کنند، مستر را چندین بار کلون نکنند.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — اتصال اسلاید کلون‌شده به یک [MasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) خاص در مقصد. Aspose.Slides برای آن مستر، طرح‌بندی مطابق با نوع یا نام طرح‌بندی منبع را جستجو می‌کند.
- `addClone(sourceSlide, destinationLayout)` — اتصال اسلاید کلون‌شده مستقیم به یک [LayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) خاص در مقصد.

مستر یا طرح‌بندی پاس داده‌شده به overload `addClone` باید متعلق به **پرزنتیشن مقصد** باشد، نه پرزنتیشن منبع.

## **ترکیب تمام پرزنتیشن‌ها و حفظ قالب‌بندی منبع**

ساده‌ترین ترکیب، کپی تمام اسلایدها از پرزنتیشن منبع به پرزنتیشن مقصد است. این گزینه وقتی مناسب است که اسلایدهای واردشده باید تم، مستر و روابط طرح‌بندی اصلی خود را حفظ کنند.

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

نتیجه ممکن است شامل چندین مستر باشد وقتی که منبع و مقصد از طرح‌های متفاوتی استفاده می‌کنند. این رفتار طبیعی است زیرا قالب‌بندی منبع عمداً حفظ می‌شود.

## **ترکیب اسلایدهای انتخابی**

لازم نیست همه اسلایدها را کلون کنید. مثال زیر فقط ایندکس‌های اسلاید انتخابی از پرزنتیشن منبع را وارد می‌کند.

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

قبل از کلون کردن، ایندکس‌های اسلاید را زمانی که از ورودی کاربر یا پیکربندی خارجی می‌آیند، اعتبارسنجی کنید.

## **ترکیب اسلایدها با استفاده از مستر مقصد**

وقتی اسلایدهای واردشده باید از یک مستر که قبلاً در پرزنتیشن مقصد وجود دارد پیروی کنند، overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) را به کار ببرید.

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

Aspose.Slides یک طرح‌بندی مناسب تحت مستر مشخص‌شده را با تطبیق نوع یا نام طرح‌بندی منبع انتخاب می‌کند. اگر طرح‌بندی مناسبی وجود نداشته باشد و `allowCloneMissingLayout` برابر `true` باشد، طرح‌بندی منبع کلون می‌شود تا اسلاید اضافه شود. اگر `false` باشد، یک [PptxEditException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.

زمانی که می‌خواهید ترکیب به‌جای افزودن یک طرح‌بندی جدید به مستر مقصد شکست بخورد، از `false` استفاده کنید.

## **ترکیب اسلایدها با استفاده از یک طرح‌بندی مقصد خاص**

وقتی دقیقاً می‌دانید که اسلایدهای واردشده باید از کدام طرح‌بندی مقصد استفاده کنند، overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) را به کار ببرید.

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

اعمال یک طرح‌بندی مقصد، رابطه وراثت طرح‌بندی را تغییر می‌دهد؛ محتوی اسلاید منبع بازطراحی نمی‌شود. اگر طرح‌بندی‌های منبع و مقصد ساختار placeholders متفاوتی داشته باشند، نتیجه را بررسی کنید تا مطمئن شوید قالب‌بندی وراثتی و رفتار placeholders مناسب است.

## **ترکیب پرزنتیشن‌ها با اندازه‌های اسلاید متفاوت**

پرزنتیشن‌هایی با ابعاد اسلاید متفاوت می‌توانند ترکیب شوند، اما کلون یک اسلاید در پرزنتیشن با اندازه اسلاید دیگر به‌صورت خودکار محتوی آن را برای بوم جدید بازطراحی نمی‌کند. به همین دلیل اشکال ممکن است جابجا، مقیاس‌دار یا خارج از ناحیه قابل مشاهده اسلاید ظاهر شوند.

یک روش عملی این است که قبل از کلون کردن، اندازه پرزنتیشن منبع را تغییر اندازه دهید. متد [SlideSize::setSize()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/setsize/) می‌تواند محتوی موجود را در حالی که ابعاد اسلاید را تغییر می‌دهد، مقیاس‌بندی کند. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesizescaletype/) محتوی را برای تناسب با اندازه درخواست‌شده مقیاس می‌کند.

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

تغییر اندازه، شی پرزنتیشن منبع را در حافظه تغییر می‌دهد. اگر به پرزنتیشن منبع اصلی برای عملیات دیگر نیاز دارید، یک نمونه جداگانه برای ترکیب باز کنید.

## **ترکیب اسلایدها در یک بخش پرزنتیشن**

حلقهٔ پایهٔ کلون اسلاید ساختار بخش‌های پرزنتیشن منبع را بازتولید نمی‌کند. اگر بخش‌ها در خروجی مهم هستند، در پرزنتیشن مقصد بخش‌ها را ایجاد یا انتخاب کنید و اسلایدها را صریحاً با [addClone(Slide, Section)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) به آن‌ها کلون کنید.

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

اسلایدهای کلون‌شده به بخش مقصد مشخص شده اضافه می‌شوند. برای حفظ چندین بخش منبع، [Presentation::getSections](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation/#getSections) را enumerate کنید، اسلایدهای فعلی هر بخش منبع را با [Section::getSlidesListOfSection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Section/#getSlidesListOfSection) دریافت کنید، بخش‌ها را در مقصد بازسازی کنید و هر اسلاید برگردانده‌شده را به بخش مقصد متناظر کلون کنید. برای مثال کامل دربارهٔ enumeration بخش‌ها، <https://slides/fa/php-java/slide-section/> را ببینید، شامل بخش‌های خالی و تغییرات ساختاری.

## **ترکیب چندین پرزنتیشن به‌صورت ایمن**

مثال انتها‑به‑انتها در زیر از اولین پرزنتیشن به‌عنوان مقصد استفاده می‌کند، اندازه اسلاید هر منبع اضافی را نرمال‌سازی می‌کند، هر منبع را فقط در زمانی که در حال کپی است باز می‌دارد و در نهایت فایل نهایی را ذخیره می‌کند.

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

این یک پایهٔ مفید برای حفظ قالب‌بندی اسلایدهای واردشده است. اگر خروجی شما باید از یک تم مقصد استفاده کند، فراخوانی سادهٔ `addClone($slide)` را با overload مستر یا طرح‌بندی مقصد مناسب که پیشتر نشان دادیم، جایگزین کنید.

## **ملاحظات عملی**

### **مسترها، طرح‌بندی‌ها و وفاداری قالب‌بندی**

کلون پیش‌فرض اسلاید می‌تواند مستر مورد نیاز منبع را به طور خودکار به پرزنتیشن مقصد بیاورد. Aspose.Slides یک رجیستری داخلی برای مسترهای کلون‌شده به‌صورت خودکار نگه می‌دارد تا از کلون مکرر یک مستر جلوگیری کند. مسترهای کلون‌شده دستی توسط آن رجیستری ردیابی نمی‌شوند، بنابراین از پیش‑کلون کردن مسترها فقط زمانی که به کنترل صریح ساختار مستر نیاز دارید، خودداری کنید.

فرض نکنید دو مستر یا دو طرح‌بندی با نام یکسان بصری یکسان هستند. اگر یک قالب سازمانی نهایی را کنترل می‌کند، مستر یا طرح‌بندی مقصد را صریحاً انتخاب کنید و پس از ترکیب نتیجه را بررسی کنید.

### **یادداشت‌ها و نظرات**

یادداشت‌های سخنران و نظرات اسلاید مرتبط با محتوی اسلاید هستند و هنگام کلون اسلاید کپی می‌شوند. Aspose.Slides همچنین APIهای اختصاصی برای [presentation notes](/slides/fa/php-java/presentation-notes/) و [presentation comments](/slides/fa/php-java/presentation-comments/) فراهم می‌کند.

اگر قالب‌بندی صفحهٔ یادداشت مهم است، پرزنتیشن ترکیب‌شده را بررسی کنید زیرا مسترهای یادداشت در سطح پرزنتیشن هستند و ممکن است بین فایل‌های منبع متفاوت باشند. برای جریان‌های بررسی، نویسندگان نظرات و نظرات زنجیربندی‌شده را پس از ترکیب فایل‌ها از نویسندگان یا قالب‌های مختلف نیز بررسی کنید.

### **تصاویر، صدا، ویدئو، اشیاء OLE و پیوندهای خارجی**

اسلایدها می‌توانند به منابع سطح پرزنتیشن مثل تصاویر، صداهای توکار، ویدئوهای توکار و داده‌های OLE ارجاع دهند. به جای کپی فقط شکل‌های قابل مشاهده، کلون خود اسلاید را انجام دهید تا Aspose.Slides روابط اسلاید با منابعش را حفظ کند.

منابع توکار و پیوندی باید به‌صورت متفاوتی مدیریت شوند. یک صدا، ویدئو، شی OLE یا پیوند خارجی همچنان به هدف خارجی خود وابسته می‌ماند؛ کلون اسلاید پیوند خارجی را به محتوی توکار تبدیل نمی‌کند. مسیرها و URLهای منابع پیوندی را در محیطی که پرزنتیشن ترکیب‌شده باز خواهد شد، آزمایش کنید.

Aspose.Slides به‌صورت خودکار مسترهای کلون‌شده را ردیابی می‌کند، اما این به‌معنای تضمین کلی برای حذف تکراری منابع باینری یکسان از پرزنتیشن‌های مختلف نیست. اگر حجم خروجی مهم است، بسته ترکیب‌شده را بررسی و اندازهٔ نهایی را اندازه‌گیری کنید، نه اینکه به حذف‌تکراری ضمنی متکی باشید.

### **فونت‌های توکار و در دسترس بودن فونت‌ها**

فونت‌ها در سطح پرزنتیشن مدیریت می‌شوند. اگر تایپوگرافی باید بین ماشین‌ها یکسان بماند، فرض نکنید کلون اسلایدها به‌تنهایی تضمین می‌کند همه فونت‌های مورد نیاز در محیط مقصد موجود باشند. می‌توانید فونت‌های توکار را با [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontsmanager/getembeddedfonts/) بررسی کنید و همانند راهنمای [Embed Fonts in Presentations](/slides/fa/php-java/embedded-font/) به‌صورت صریح توکار کنید.

هم‌چنین اطمینان حاصل کنید که اجازهٔ توکار کردن فونت‌های استفاده‌شده در فایل‌های منبع را دارید؛ مجوزهای فونت ممکن است توکار کردن را محدود کنند.

### **پرزنتیشن‌های دارای پسورد**

یک منبع محافظت‌شده با پسورد باید قبل از کلون اسلایدها با موفقیت باز شود. پسورد را از طریق [LoadOptions::setPassword()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/setpassword/) فراهم کنید.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // کار با ارائهٔ رمزگشایی‌شده.
} finally {
    $source->dispose();
}
```

باز کردن یک منبع رمزگذاری‌شده به‌صورت خودکار همان حفاظت را بر روی پرزنتیشن مقصد اعمال نمی‌کند. در صورت نیاز، حفاظت خروجی را جداگانه تنظیم کنید.

### **پرزنتیشن‌های بزرگ و مصرف حافظه**

پرزنتیشن‌های بزرگ شامل تصاویر با وضوح بالا، صدا، ویدئو یا دیگر اشیای باینری بزرگ می‌توانند حافظهٔ قابل توجهی مصرف کنند. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) کنترل‌های مدیریت BLOB و استفاده از فایل‌های موقت را فراهم می‌کند. برای مثال فایل‌های بزرگ در PHP via Java نگاه کنید به <https://slides/fa/php-java/open-presentation/#open-large-presentations>.

برای فایل‌های بزرگ، هنگام امکان از مسیرهای فایل برای بارگذاری استفاده کنید، هر پرزنتیشن منبع را بلافاصله پس از ترکیب آزاد کنید و از ذخیره مکرر نتایج میانی خودداری کنید مگر اینکه جریان کاری به نقطه‌ای بازگشت‌پذیر نیاز داشته باشد.

### **ایمنی در چندنخی**

در PHP via Java، بارگذاری، تغییر، ذخیره یا کلون نمونه‌های [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) در چندین نخ پشتیبانی نمی‌شود. اگر به کارهای ترکیب موازی نیاز دارید، آن‌ها را در فرآیندهای تک‌نخی جداگانه اجرا کنید؛ هر فرآیند نمونه‌های پرزنتیشن خود را داشته باشد و راهنمای <https://slides/fa/php-java/multithreading/> مربوط به Aspose.Slides را دنبال کنید.

## **سوالات متداول**

**چگونه می‌توانم طراحی اصلی هر پرزنتیشن منبع را حفظ کنم؟**

از [SlideCollection::addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) بدون ارائه مستر یا طرح‌بندی مقصد استفاده کنید. Aspose.Slides می‌تواند مستر منبع را به‌صورت خودکار کلون کند زمانی که اسلاید واردشده به آن نیاز داشته باشد.

**چگونه می‌توانم اسلایدهای واردشده را به تم مقصد بسط دهم؟**

overloadی را که مستر مقصد می‌پذیرد استفاده کنید. یک مستر از پرزنتیشن مقصد پاس دهید، نه از منبع. Aspose.Slides سعی می‌کند هر اسلاید منبع را به یک طرح‌بندی مناسب زیر آن مستر نگاشت کند.

**چه زمانی باید به‌جای مستر مقصد از یک طرح‌بندی مقصد خاص استفاده کنم؟**

وقتی هر اسلاید واردشده باید از یک طرح‌بندی شناخته‌شده استفاده کند، یک طرح‌بندی خاص را انتخاب کنید. وقتی می‌خواهید Aspose.Slides بین طرح‌بندی‌های مستر بر پایهٔ نوع یا نام طرح‌بندی منبع انتخاب کند، از مستر استفاده کنید.

**آیا می‌توان پرزنتیشن‌های با اندازه اسلاید متفاوت را ترکیب کرد؟**

بله، ولی محتوی اسلاید به‌صورت خودکار برای ابعاد مقصد بازطراحی نمی‌شود. برای داشتن مکان‌یابی پیش‌بینی‌شده، ابتدا منبع را با [SlideSize::setSize()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesize/setsize/) و [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidesizescaletype/) مقیاس‌بندی کنید.

**آیا می‌توانم فایل‌های PPT، PPTX و ODP را در یک فایل ترکیب کنم؟**

بله. هر پرزنتیشن منبع را بارگذاری کنید، اسلایدهای موردنیاز را به یک مقصد کلون کنید و مقصد را در یک فرمت خروجی پشتیبانی‌شده ذخیره کنید. چون فرمت‌های پرزنتیشن دقیقا همان مجموعه ویژگی‌ها را ندارند، پس از ترکیب فرمت‑متقاطع محتوی پیچیده را بررسی کنید. برای فرمت‌های پشتیبانی‌شده، <https://slides/fa/php-java/supported-file-formats/> را ببینید.

**آیا بخش‌های منبع به‌صورت خودکار حفظ می‌شوند؟**

نه، با یک حلقهٔ سادهٔ کلون فقط اسلایدها بخش‌ها حفظ نمی‌شوند. برای حفظ ساختار بخش‌ها، آن‌ها را در مقصد بازسازی کنید و از overload بخش‌دار [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/addclone/) استفاده کنید.

**آیا یادداشت‌های سخنران و نظرات حفظ می‌شوند؟**

آن‌ها همراه با اسلاید کلون‌شده کپی می‌شوند. برای جریان‌های کاری که به استایل مستر یادداشت‌ها، نویسندگان نظرات یا داده‌های مرور زنجیربندی‑شده وابسته‌اند، نتیجه ترکیب را بررسی کنید زیرا این سناریوها شامل ساختارهای سطح پرزنتیشن نیز می‌شوند.

**چه اتفاقی برای صدا، ویدئو، اشیاء OLE و پیوندها می‌افتد؟**

محتوی توکار به‌عنوان بخشی از روابط منابع کلون‌شده اسلاید انتقال می‌یابد. پیوندهای خارجی همچنان خارجی می‌مانند، بنابراین فایل‌ها یا URLهای هدف باید پس از ترکیب در دسترس باشند.

**آیا فونت‌های توکار هر منبع تضمین می‌شود در پرزنتیشن ترکیب‌شده موجود باشد؟**

به‌تنهایی کلون اسلاید برای انتشار فونت‌ها اتکا نکنید. فونت‌های توکار مقصد را بررسی کنید و توکار شدن یا در دسترس بودن فونت‌های خارجی را به‌صورت صریح مدیریت کنید وقتی تایپوگرافی مهم است.

**چگونه یک فایل محافظت‌شده با پسورد را ترکیب کنم؟**

با استفاده از [LoadOptions::setPassword()](https://reference.aspose.com/slides/fa/php-java/aspose.slides/loadoptions/setpassword/) به‌درستی آن را باز کنید، سپس اسلایدهایش را به‌صورت معمول کلون کنید. حفاظت خروجی به‌صورت جداگانه تنظیم می‌شود.

**چگونه با پرزنتیشن‌های خیلی بزرگ مقابله کنم؟**

از مدیریت BLOB استفاده کنید وقتی اشیای باینری بزرگ حافظه را اشغال می‌کنند، برای فایل‌های بسیار بزرگ بارگذاری از مسیرهای فایل را ترجیح دهید، پرزنتیشن‌های منبع را به‌محض ترکیب آزاد کنید و نتیجه نهایی را فقط زمانی که لازم است ذخیره کنید.

**آیا می‌توانم اسلایدها را از چندین نخ ترکیب کنم؟**

بارگذاری، ذخیره یا کلون [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) در چندین نخ در PHP via Java پشتیبانی نمی‌شود. برای کارهای ترکیب موازی، آن‌ها را در فرآیندهای تک‌نخی جداگانه اجرا کنید؛ هر فرآیند نمونه‌های پرزنتیشن خود را داشته باشد و راهنمای <https://slides/fa/php-java/multithreading/> مربوط به Aspose.Slides را دنبال کنید.