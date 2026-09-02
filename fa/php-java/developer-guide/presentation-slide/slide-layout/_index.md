---
title: اعمال یا تغییر طرح‌های اسلاید در PHP
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/php-java/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- مکان‌گیر
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- قابلیت نمایش پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با توضیح
- تصویر با توضیح
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اعمال، ایجاد و اصلاح طرح‌های اسلاید در Aspose.Slides برای PHP از طریق Java، افزودن مکان‌گیرها، حذف طرح‌های استفاده‌نشده و کنترل نمایش پاورقی."
---
## **نمای کلی**

یک طرح اسلاید مکان‌ها و قالب‌بندی مکان‌گیرها مانند عنوان‌ها، متن، تصاویر، نمودارها و جداول را تعریف می‌کند. اعمال یک طرح به اسلایدها ساختاری یکسان می‌بخشد در حالی که به هر اسلاید اجازه می‌دهد محتوای خود را داشته باشد.

متداول‌ترین طرح‌ها شامل:

- **صفحه عنوان**: شامل مکان‌گیرهای عنوان و زیرعنوان است.
- **عنوان و محتوا**: شامل یک مکان‌گیر عنوان و یک مکان‌گیر محتوا با کاربرد عمومی است.
- **خالی**: حاوی هیچ مکان‌گیر محتوایی نیست و زمانی مفید است که هر شکل به صورت دستی موقعیت‌یابی شود.

## **درک ارث‌بری طرح**

یک ارائه دارای سه سطح مرتبط است:

1. یک [اسلاید اصلی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
1. یک [اسلاید طرح](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) به یک اسلاید اصلی تعلق دارد و چینش خاصی از مکان‌گیرها را تعریف می‌کند.
1. یک [اسلاید عادی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) از یک طرح استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌سازد.

یک اسلاید عادی تم و قالب‌بندی را از طرح خود به‌ارث می‌برد و طرح نیز از اسلاید اصلی ارث می‌برد. مقدار تنظیم‌شده مستقیم بر روی اسلاید عادی، مقدار به‌ارث‌برده در همان سطح را نادیده می‌گیرد. وقتی یک اسلاید عادی ساخته می‌شود، شکل‌های مکان‌گیر آن از طرح انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده به آن مکان‌گیرها متعلق به اسلاید عادی است.

پیش از ایجاد اسلایدها، مکان‌گیرهای موردنیاز را به یک طرح اضافه کنید. افزودن مکان‌گیر دیگر به یک طرح پس از آن، به‌صورت خودکار شکل مکان‌گیر متناظر را به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی به‌ارث‌برده یا هندسه مکان‌گیرهای موجود در یک طرح می‌تواند هر اسلایدی که به آن وابسته است را به‌روزرسانی کند. پیش از ویرایش طرحی که قبلاً استفاده شده، اسلایدهای وابسته را بررسی و ارائه نهایی را مرور کنید.
- طرحی که هنوز توسط اسلایدی استفاده می‌شود نمی‌تواند حذف شود. پیش از حذف، اسلایدهای وابسته را به طرح دیگری اختصاص دهید یا فقط طرح‌های بدون استفاده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالایی این سلسله‌مراتوب، به [اسلاید مستر](/slides/fa/php-java/slide-master/) مراجعه کنید.

## **انتخاب و اعمال یک طرح اسلاید**

هنگامی که ارائه با تعاریف استاندارد طرح‌های PowerPoint سازگار است، از نوع طرح استفاده کنید. نام‌های طرح توسط کاربر قابل ویرایش و قابل بومی‌سازی هستند، بنابراین انتخاب بر اساس نام کمتر قابل اعتماد است مگر اینکه قالب منبع را کنترل کنید.

مثال زیر به دنبال **عنوان و محتوا** در اولین اسلاید اصلی می‌گردد. اگر آن طرح در دسترس نباشد، عمداً به **خالی** بازمی‌گردد. بررسی null دوم ضروری است زیرا یک ارائه می‌تواند فقط شامل طرح‌های سفارشی باشد. طرح انتخاب‌شده سپس از طریق متد [Slide.setLayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#setLayoutSlide) به اولین اسلاید عادی اعمال می‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تغییر طرح یک اسلاید مکان‌گیرها، قالب‌بندی به‌ارث‌برده و تطبیق بین مکان‌گیرهای موجود و طرح جدید را تغییر نمی‌دهد، اما شکل‌های عادی اضافه‌شده مستقیم به اسلاید حذف نمی‌شوند. بنابراین هنگام جابه‌جایی بین طرح‌های متفاوت به‌طرز چشم‌گیر، خروجی را بررسی کنید.

## **افزودن یک اسلاید طرح**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک طرح موجود را انتخاب می‌کرد؛ آن را نمی‌ساخت. برای ساخت یک طرح، متد [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterlayoutslidecollection/#add) را بر روی مجموعهٔ طرح‌های اسلاید اصلی هدف فراخوانی کنید.

مثال زیر همیشه یک طرح جدید **عنوان و محتوا** به نام `Report Title and Content` اضافه می‌کند، سپس بر پایهٔ آن یک اسلاید عادی می‌سازد. نام‌های طرح باید درون مجموعه یکتا باشند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

طرح را فقط زمانی اضافه کنید که قالب واقعاً به ساختار قابل استفاده دیگری نیاز داشته باشد. اگر طرح مناسب از قبل وجود دارد، آن را انتخاب و مجدداً استفاده کنید به‌جای ایجاد یک نسخهٔ تکراری.

## **افزودن مکان‌گیرها به یک اسلاید طرح**

متد [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#getPlaceholderManager) یک [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/) برای افزودن شکل‌های مکان‌گیر به یک طرح فراهم می‌کند.

| مکان‌گیر PowerPoint | متد `LayoutPlaceholderManager` |
| ------------------- | ----------------------------- |
| ![محتوا](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![محتوا (عمودی)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![متن](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![متن (عمودی)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![تصویر](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![نمودار](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![جدول](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![رسانه](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![تصویر آنلاین](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

مثال زیر وجود طرح **خالی** را بررسی می‌کند، چهار مکان‌گیر به آن اضافه می‌سازد و سپس یک اسلاید عادی که از طرح اصلاح‌شده استفاده می‌کند می‌سازد. ترتیب به عمد است: ابتدا مکان‌گیرها اضافه می‌شوند سپس اسلاید عادی ساخته می‌شود تا Aspose.Slides بتواند شکل‌های مکان‌گیر متناظر را روی آن اسلاید تولید کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نتیجه:

![مکان‌گیرهای موجود بر روی اسلاید طرح](add_placeholders.png)

{{% alert color="warning" title="هشدار" %}}
تغییر قالب‌بندی به‌ارث‌برده یا هندسهٔ مکان‌گیرهای موجود در طرح می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک مکان‌گیر جدید به‌صورت خودکار در اسلایدهای عادی موجود پر نمی‌شود. تغییرات طرح را روی یک نسخهٔ کپی از ارائه آزمایش کنید و هر اسلاید وابسته را بررسی نمایید.
{{% /alert %}}

## **حذف اسلایدهای طرح بدون استفاده**

از متد [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) برای حذف طرح‌هایی که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد استفاده کنید. این متد طرح‌های هنوز مورد استفاده را دست‌نخورده می‌گذارد.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای حذف یک طرح خاص، ابتدا از متدهای [hasDependingSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#hasDependingSlides) یا [getDependingSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#getDependingSlides) آن استفاده کنید. پیش از فراخوانی [LayoutSlide.remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#remove) اسلایدهای وابسته را به‌جای دیگر اختصاص دهید. تلاش برای حذف طرحی که در حال استفاده است، باعث بروز [PptxEditException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پاورقی در یک اسلاید طرح**

یک طرح پاورقی، شمارهٔ اسلاید و مکان‌گیرهای تاریخ‑زمان خود را دارد. برای کنترل این مکان‌گیرها برای یک طرح، از متد [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) استفاده کنید. این کار وقتی مفید است که به‌عنوان مثال، طرح‌های محتوا باید پاورقی نشان دهند اما طرح‌های عنوان نباید.

مثال زیر یک طرح را به‌صورت ایمن انتخاب می‌کند و عناصر پاورقی آن را نمایانی می‌سازد:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **کنترل نمایش پاورقی در یک اسلاید اصلی و طرح‌های فرزند آن**

برای اعمال تنظیمات یکسان پاورقی در سرتاسر سلسله‌مراتوب اسلاید اصلی، از متد [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/#getHeaderFooterManager) استفاده کنید. متدهای انتقالی [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslideheaderfootermanager/) بر روی اسلاید اصلی و اسلایدهای طرح وابسته و اسلایدهای عادی آن عمل می‌کنند؛ نه فقط یک اسلاید عادی مشخص.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پرسش‌های متداول**

**تفاوت اسلاید اصلی و اسلاید طرح چیست؟**

اسلاید اصلی تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید طرح به اسلاید اصلی تعلق دارد و یک چینش قابل استفاده مجدد از مکان‌گیرها را تعیین می‌کند. اسلایدهای عادی از این طرح‌ها استفاده می‌کنند و محتوای خاص خود را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با استفاده از متد [addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/globallayoutslidecollection/#addClone) یک نسخه به مجموعهٔ مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و سایر منابع مورد استفادهٔ طرح منبع را نیز بررسی کنید.

**چه اتفاقی می‌افتد وقتی یک طرح که در حال استفاده است را اصلاح می‌کنم؟**

اسلایدهای وابسته تغییرات طرح را به‌ارث می‌برند مگر این‌که قالب‌بندی یا اشیای موردنظر را به‌صورت محلی نادیده بگیرند. بنابراین هندسهٔ مکان‌گیر و سبک‌های به‌ارث‌برده می‌تواند به‌طور همزمان در بسیاری از اسلایدها تغییر کند. پیش از ویرایش طرح، با استفاده از [getDependingSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#getDependingSlides) اسلایدهای تحت تأثیر را شناسایی کنید.

**اگر زهی یک طرح که هنوز استفاده می‌شود را حذف کنم چه می‌شود؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxeditexception/) می‌اندازد. ابتدا اسلایدهای وابسته را به طرح دیگری اختصاص دهید یا با استفاده از [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) فقط طرح‌های بدون ارجاع را حذف کنید.