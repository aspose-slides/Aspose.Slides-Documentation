---
title: مدیریت سرصفحه‌ها و پاورقی‌های ارائه در PHP
linktitle: سرصفحه و پاورقی
type: docs
weight: 140
url: /fa/php-java/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پاورقی
- متن پاورقی
- تنظیم سرصفحه
- تنظیم پاورقی
- برگه چاپ
- یادداشت‌ها
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای PHP از طریق Java، جایگزین‌های پاورقی، تاریخ-زمان، شماره اسلاید و سرصفحه را در اسلایدها، صفحات یادداشت و برگه‌های چاپ مدیریت کنید."
---
## **بررسی کلی**

PowerPoint بسته به نوع صفحه از جایگزین‌های سرصفحه و پاورقی متفاوتی استفاده می‌کند. Aspose.Slides for PHP via Java به شما امکان کنترل متن و قابلیت نمایش این جایگزین‌ها را از طریق کلاس‌های مدیر سرصفحه/پاورقی می‌دهد.

جایگزین‌های موجود بسته به دامنه متفاوت است:

| دامنه | سرصفحه | پاورقی | تاریخ/زمان | شماره اسلاید/صفحه |
|---|---|---|---|---|
| اسلاید عادی | خیر | بله | بله | بله |
| الگو یادداشت‌ها | بله | بله | بله | بله |
| اسلاید یادداشت | بله | بله | بله | بله |
| الگو چاپ | بله | بله | بله | بله |

یک اسلاید عادی در ارائه دارای جایگزین سرصفحه نیست. سرصفحه‌ها در صفحات یادداشت و برگه‌های چاپ موجود هستند. برای اسلایدهای عادی، به‌جای سرصفحه از جایگزین‌های پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید.

دامنهٔ تغییر بسته به مدیری که استفاده می‌کنید متفاوت است. کلاس [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideheaderfootermanager/) یک اسلاید عادی را کنترل می‌کند. کلاس [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notesslideheaderfootermanager/) یک اسلاید یادداشت را کنترل می‌کند. مدیران الگو و طرح‌بندی نیز می‌توانند تنظیمات را به اسلایدهای وابسته گسترش دهند، در حالی که کلاس [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) الگو برگهٔ چاپ را مدیریت می‌کند.

## **تنظیم پاورقی، تاریخ/زمان و شماره اسلاید در اسلایدهای عادی**

برای اسلایدهای عادی، گردش‌کار پایه این است که به مدیر سرصفحه/پاورقی هر اسلاید دسترسی پیدا کنید، متن پاورقی و تاریخ/زمان را تنظیم کنید، جایگزین‌های مورد نیاز را فعال کنید و ارائه را ذخیره کنید. شماره اسلایدها توسط ارائه تولید می‌شوند، بنابراین فقط کافی است قابلیت نمایش آن‌ها را کنترل کنید.

از [`setFooterText`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) و [`setDateTimeText`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) برای تنظیم متن استفاده کنید و از [`setFooterVisibility`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)، [`setDateTimeVisibility`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) و [`setSlideNumberVisibility`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) برای نمایش جایگزین‌های مربوطه بهره بگیرید.

مثال انتها‑به‑انتها زیر همان پاورقی، متن تاریخ/زمان و قابلیت نمایش شماره اسلاید را برای تمام اسلایدهای عادي اعمال می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اگر فقط می‌خواهید یک اسلاید را به‌روز کنید، به‌جای پیمایش کل مجموعه از متد [`getSlides`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/getslides/) برای دریافت اسلاید مورد نظر استفاده کنید.

## **تنظیم سرصفحه و پاورقی در الگو یادداشت‌ها**

الگو یادداشت‌ها قالب‌بندی مشترک و رفتار جایگزین‌های صفحات یادداشت را تعریف می‌کند. زمانی که فقط می‌خواهید الگو یادداشت‌ها را تغییر دهید، از کلاس [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/) استفاده کنید.

مثال زیر سرصفحه، پاورقی و متن تاریخ/زمان را در الگو یادداشت‌ها تنظیم می‌کند و تمام جایگزین‌های پشتیبانی‌شده در آن الگو را قابل مشاهده می‌سازد:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

متد [`getMasterNotesSlide`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) زمانی که ارائه‌تان حاوی الگو یادداشت‌ها نباشد مقدار `null` برمی‌گرداند.

## **اعمال تنظیمات الگو یادداشت‌ها به اسلایدهای فرزند**

یک الگو یادداشت‌ها می‌تواند تنظیمات سرصفحه و پاورقی را هم به خود و هم به تمام اسلایدهای یادداشت وابسته اعمال کند. برای این منظور از متدهای انتشار اختصاصی در کلاس [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/) استفاده کنید تا همان تنظیمات در سراسر سلسله‌مراتب یادداشت‌ها اعمال شود.

به‌عنوان مثال، متدهای [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) و [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) متن سرصفحه الگو یادداشت‌ها و تمام سرصفحه‌های فرزند را به‌روز می‌کنند. متدهای معادل برای پاورقی، تاریخ/زمان و شماره اسلاید نیز موجود است.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

متدهای انتشار استفاده‌شده در بالا عبارتند از [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)، [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)، [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)، [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) و [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **تنظیم سرصفحه و پاورقی در یک اسلاید یادداشت منفرد**

یک اسلاید یادداشت به اسلاید عادی خاصی تعلق دارد. زمانی که می‌خواهید فقط همان صفحهٔ یادداشت را سفارشی کنید، از کلاس [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notesslideheaderfootermanager/) استفاده کنید.

متد [`addNotesSlide`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notesslidemanager/addnotesslide/) اسلاید یادداشت مربوط به اسلاید جاری را برمی‌گرداند و در صورت عدم وجود، یک اسلاید جدید ایجاد می‌کند. مثال زیر صفحهٔ یادداشت مرتبط با اولین اسلاید ارائه را پیکربندی می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اگر ابتدا تنظیمات را از الگو یادداشت‌ها انتشار دهید و سپس یک اسلاید یادداشت تک‌به‌تک را تغییر دهید، تنظیمات پس‌از‑اسلاید به شما اجازه می‌دهد آن صفحهٔ یادداشت را به‌صورت مستقل سفارشی کنید.

## **تنظیم سرصفحه و پاورقی در الگو برگهٔ چاپ**

صفحات برگهٔ چاپ از الگو برگهٔ چاپ برای جایگزین‌های سرصفحه، پاورقی، تاریخ/زمان و شماره صفحه استفاده می‌کنند. برخلاف صفحات یادداشت، تنظیمات برگهٔ چاپ از طریق الگو برگهٔ چاپ مدیریت می‌شود نه از طریق اسلایدهای منفرد برگهٔ چاپ.

از متد [`getMasterHandoutSlide`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) برای دسترسی به الگو برگهٔ چاپ استفاده کنید. اگر موجود نباشد، با فراخوانی [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) الگو برگهٔ چاپ پیش‌فرض را ایجاد کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **درک دامنه و ارث‌بری**

مدیری را انتخاب کنید که با دامنه‌ای که می‌خواهید تغییر دهید منطبق باشد:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideheaderfootermanager/) تنظیمات پاورقی، تاریخ/زمان و شماره اسلاید را برای یک اسلاید عادی تغییر می‌دهد.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslideheaderfootermanager/) یک اسلاید طرح‌بندی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته انتشار دهد.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslideheaderfootermanager/) یک الگو اسلاید عادی را مدیریت می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته انتشار دهد.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslideheaderfootermanager/) الگو یادداشت‌ها را کنترل می‌کند و می‌تواند تنظیمات را به تمام اسلایدهای یادداشت وابسته انتشار دهد.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notesslideheaderfootermanager/) یک اسلاید یادداشت را تغییر می‌دهد و علاوه بر پاورقی، تاریخ/زمان و شماره اسلاید، یک جایگزین سرصفحه را نیز پشتیبانی می‌کند.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) الگو برگهٔ چاپ را تغییر می‌دهد و از تمام چهار نوع جایگزین پشتیبانی می‌کند.

از انتشار از یک الگو یا طرح‌بندی استفاده کنید زمانی که همان تنظیم باید در تمام سطوح سلسله‌مراتبی آن اعمال شود. از یک اسلاید یا مدیر اسلاید‑یادداشت منفرد استفاده کنید زمانی که به تنظیم محلی برای یک صفحه نیاز دارید.

## **سوالات متداول**

**آیا می‌توانم سرصفحه‌ای به اسلاید عادی اضافه کنم؟**

خیر. PowerPoint برای اسلایدهای عادی جایگزین سرصفحه تعریف نمی‌کند. برای اسلایدهای عادی از جایگزین‌های پاورقی، تاریخ/زمان و شماره اسلاید استفاده کنید. جایگزین سرصفحه در صفحات یادداشت و برگه‌های چاپ موجود است.

**اگر جایگزین پاورقی، تاریخ/زمان یا شماره اسلاید مشاهده نشود چه کاری باید انجام دهم؟**

از مدیر سرصفحه/پاورقی مربوطه برای بررسی قابلیت نمایش آن استفاده کنید و در صورت نیاز آن را فعال کنید. برای مثال، متد [`isFooterVisible`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) نشان می‌دهد آیا جایگزین پاورقی موجود است و متد [`setFooterVisibility`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) قابلیت نمایش آن را تغییر می‌دهد.

**چگونه می‌توانم شماره‌گذاری اسلایدها را از مقدار دیگری به جز 1 شروع کنم؟**

متد [`setFirstSlideNumber`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/setfirstslidenumber/) ارائه را فراخوانی کنید. پس از آن جایگزین‌های شماره اسلاید از دنباله شماره‌گذاری به‌روزشده استفاده می‌کنند.

**هنگام خروجی گرفتن به PDF، تصویر یا HTML، سرصفحه و پاورقی چه اتفاقی می‌افتد؟**

عناصر قابل مشاهدهٔ سرصفحه و پاورقی همراه با بقیهٔ محتوای ارائه در قالب خروجی رندر می‌شوند. ظاهر آن‌ها بستگی به نوع صفحه‌ای دارد که صادر می‌شود و تنظیمات قابلیت نمایش جایگزین مربوطه.