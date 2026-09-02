---
title: مدیریت راهنماهای رسم در ارائه‌ها در PHP
linktitle: راهنماهای رسم
type: docs
weight: 85
url: /fa/php-java/drawing-guides/
keywords:
- راهنمای رسم
- راهنمای افقی
- راهنمای عمودی
- راهنمای هم‌راستایی
- نمای اسلاید
- اسلاید مستر
- اسلاید طرح‌بندی
- مستر یادداشت
- مستر جزوه
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "افزودن، دسترسی و پاک‌سازی راهنماهای افقی و عمودی رسم در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای PHP از طریق Java."
---
## **بررسی کلی**

راهنماهای رسم خطوط قابل تنظیم افقی و عمودی هستند که به کاربران کمک می‌کنند تا اشکال را به‌صورت ثابت در حین ویرایش یک ارائه در PowerPoint هم‌راستا کنند. آنها به‌ویژه زمانی مفیدند که یک برنامه یک ارائه تولید می‌کند که بعداً به‌صورت دستی اصلاح خواهد شد: برنامه می‌تواند همان ابزارهای هم‌راستایی را ذخیره کند تا نویسندگان هنگام افزودن یا جابجایی محتوا از آنها پیروی کنند.

راهنماهای رسم ابزارهای ویرایشی هستند، نه محتوای اسلاید. آنها در نمایش اسلاید یا خروجی رندر شده ظاهر نمی‌شوند. Aspose.Slides برای PHP از طریق Java آن‌ها را از طریق کلاس [DrawingGuidesCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguidescollection/) در دسترس قرار می‌دهد. یک راهنما توسط [DrawingGuide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguide/) نشان داده می‌شود و دارای جهت، موقعیت و رنگ است.

موقعیت بر حسب نقطه از گوشهٔ بالا‑چپ اسلاید یا مستر مربوطه اندازه‌گیری می‌شود. یک راهنمای عمودی از یک مختصات افقی استفاده می‌کند که معمولاً بین صفر و عرض اسلاید قرار دارد. یک راهنمای افقی از یک مختصات عمودی استفاده می‌کند که معمولاً بین صفر و ارتفاع اسلید قرار دارد.

## **افزودن راهنماها به نمای اسلاید**

از [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) برای مدیریت راهنماهای نمایش داده شده هنگام ویرایش اسلایدهای عادی استفاده کنید. با یک مقدار [Orientation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/orientation/) و یک موقعیت بر حسب نقطه، [DrawingGuidesCollection::add](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguidescollection/#add) را فراخوانی کنید.

مثال زیر یک راهنمای عمودی در سمت راست مرکز اسلاید و یک راهنمای افقی زیر آن اضافه می‌کند:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دسترس به راهنماهای رسم**

متدهای [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguidescollection/#getCount) و [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguidescollection/#get_Item) دسترسی به راهنماهای موجود را فراهم می‌کنند. متدهای [DrawingGuide::getOrientation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguide/#getOrientation)، [DrawingGuide::getPosition](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguide/#getPosition) و [DrawingGuide::getColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguide/#getColor) مقادیری را برمی‌گردانند که می‌توانند از طریق متدهای setter مربوطه نیز تغییر یابند.

مثال زیر راهنماهای نمای اسلاید را از ارائه‌ای که در بالا ایجاد شد می‌خواند:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **افزودن راهنماها به اسلایدهای مستر و طرح‌بندی**

یک مستر اسلاید و هر یک از اسلایدهای طرح‌بندی آن می‌توانند مجموعه‌های راهنمای رسم مخصوص به خود را داشته باشند. برای یک اسلاید مستر از [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/#getDrawingGuides) و برای یک اسلاید طرح‌بندی از [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#getDrawingGuides) استفاده کنید.

مثال زیر یک راهنمای عمودی به اولین اسلاید مستر و یک راهنمای افقی به اولین اسلاید طرح‌بندی اضافه می‌کند:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **افزودن راهنماها به مسترهای یادداشت و جزوه**

مسترس‌های یادداشت و مسترس‌های جزوه نیز از راهنماهای رسم پشتیبانی می‌کنند. برای دسترسی به مجموعه‌های آن‌ها از [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masternotesslide/#getDrawingGuides) و [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) استفاده کنید. اگر ارائه‌ای شامل یکی از این مسترس‌ها نباشد، مدیر مناسب را با [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) یا [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager) دریافت کنید، سپس مستر پیش‌فرض را با `setDefaultMasterNotesSlide` یا `setDefaultMasterHandoutSlide` ایجاد کنید.

مثال زیر یک راهنمای افقی به یک مستر یادداشت و یک راهنمای عمودی به یک مستر جزوه اضافه می‌کند:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پاک‌سازی راهنماهای رسم**

برای حذف تمام راهنماها از یک مجموعه خاص، [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguidescollection/#clear) را فراخوانی کنید. پاک‌سازی یک مجموعه بر راهنماهای ذخیره‌شده در حوزهٔ دیگری تأثیر نمی‌گذارد.

مثال زیر راهنماهای نمای اسلاید و تمام راهنماهای موجود در مسترس‌های اسلاید، اسلایدهای طرح‌بندی، مستر یادداشت و مستر جزوه را بدون ایجاد مسترس‌های گمشده پاک می‌کند:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پرسش‌های متداول**

**آیا راهنماهای رسم در نمایش اسلاید یا تصاویر صادرشده ظاهر می‌شوند؟**  
خیر. راهنماهای رسم ابزارهای هم‌راستایی برای ویرایش هستند و به‌عنوان محتوای ارائه رندر نمی‌شوند.

**آیا می‌توان یک راهنمای رسم را مستقیماً به یک اسلاید عادی اضافه کرد؟**  
راهنماهای ویرایشی اسلایدهای عادی در ویژگی‌های نمای اسلاید ارائه ذخیره می‌شوند. مجموعه‌های راهنمای جداگانه‌ای برای مسترس‌های اسلاید، اسلایدهای طرح‌بندی، مسترس‌های یادداشت و مسترس‌های جزوه موجود است.

**کدام واحدها برای موقعیت‌های راهنما استفاده می‌شوند؟**  
موقعیت‌ها به‌واحد نقطه مشخص می‌شوند که ۷۲ نقطه برابر یک اینچ است. موقعیت‌های عمودی از لبهٔ چپ اندازه‌گیری می‌شوند و موقعیت‌های افقی از لبهٔ بالا.

**آیا پاک‌سازی راهنماهای رسم اشکال را حذف می‌کند یا محتوای اسلاید را تغییر می‌دهد؟**  
خیر. متد [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/drawingguidescollection/#clear) فقط راهنماهای موجود در مجموعهٔ انتخاب‌شده را حذف می‌کند. اشکال و سایر محتوای اسلاید بدون تغییر باقی می‌مانند.