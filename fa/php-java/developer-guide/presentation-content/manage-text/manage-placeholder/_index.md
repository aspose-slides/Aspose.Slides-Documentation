---
title: مدیریت جای‌دارهای ارائه در PHP
linktitle: مدیریت جای‌دارها
type: docs
weight: 10
url: /fa/php-java/manage-placeholder/
keywords:
- جای‌دار
- جای‌دار متن
- جای‌دار تصویر
- جای‌دار نمودار
- جای‌دار محتوا
- متن راهنما
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه جای‌دارهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و وراثت جای‌دارها را با Aspose.Slides برای PHP از طریق Java درک نمایید."
---
## **بررسی کلی**

یک جای‌دار (Placeholder) یک شکل است که موقعیتی را برای نوع خاصی از محتوا در قالب یک ارائه ذخیره می‌کند. نمونه‌های رایج شامل عنوان، بدنه، تصویر، نمودار و جای‌دارهای محتوای عمومی هستند. بر خلاف یک شکل معمولی، یک جای‌دار می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید چیدمان یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات جای‌دار را از طریق متد [Shape::getPlaceholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getplaceholder/) ارائه می‌دهد. این متد یک شیء [Placeholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholder/) یا `null` برای یک شکل عادی بر می‌گرداند. برای تعیین محتوایی که جای‌دار قرار است داشته باشد، از [Placeholder::getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholder/gettype/) استفاده کنید.

کلاس شکل همچنان پس از دانستن نوع جای‌دار مهم است:

- یک جای‌دار متنی، تصویری، نموداری یا محتوایی خالی معمولاً توسط یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) نمایش داده می‌شود.
- یک جای‌دار تصویر پر شده می‌تواند توسط یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) نشان داده شود.
- یک جای‌دار نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/) نمایش داده شود.
- یک جای‌دار محتوا می‌تواند شامل چندین نوع محتوا باشد. به جای فرض اینکه هر جای‌دار یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) است، هم [Placeholder::getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholder/gettype/) و هم کلاس شکل در زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholder/gettype/) نقش یک جای‌دار را توصیف می‌کند؛ این متد کلاس زمان اجرای شکل را تضمین نمی‌کند. همیشه قبل از دسترسی به اعضای متنی، تصویر، نمودار، جدول یا رسانه‌ای، بررسی نوع را انجام دهید.
{{% /alert %}}

## **درک وراثت جای‌دار**

جای‌دارها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد را تعریف می‌کند و در برخی موارد دارای جای‌دارهای سطح اصلی می‌شود.
2. یک اسلاید چیدمان (layout) چیدمان مورد استفاده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از اسلاید اصلی به ارث ببرد.
3. یک اسلاید عادی شامل جای‌دارهای آن اسلاید است و می‌تواند از چیدمان خود به ارث ببرد.

برای حرکت یک سطح بالاتر در این سلسله‌مراتب، متد [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getbaseplaceholder/) را فراخوانی کنید. یک جای‌دار اسلاید معمولاً جای‌دار چیدمان خود را بر می‌گرداند؛ یک جای‌دار چیدمان می‌تواند جای‌دار اصلی را برگرداند. این متد زمانی که شکل پایه‌ای نداشته باشد `null` بر می‌گرداند.

مثال زیر جای‌دارهای اسلاید اول را فهرست کرده و پایه آن‌ها را گزارش می‌دهد:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

ویرایش یک جای‌دار در یک اسلاید عادی، یک بازنویسی محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش چیدمان یا اسلاید اصلی مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را به ارث می‌برند تأثیر بگذارد. یک شکل عادی محلی پایه‌ای ندارد و صرفاً به دلیل قرار گرفتن در همان مختصات، وراثت آغاز نمی‌کند.

## **تغییر متن در یک جای‌دار**

جای‌دارهای عنوان، عنوان-وسط‌چین، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/gettextframe/) بررسی کنید که شکل یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) است.

این مثال اولین جای‌دار عنوان در اسلاید اول را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

این الگو از در نظر گرفتن جای‌دارهای تصویر، نمودار، جدول یا رسانه به‌عنوان اشیاء [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) جلوگیری می‌کند. همچنین جای‌دار را بر پایه هدفش شناسایی می‌کند نه بر پایه یک اندیس شکننده شکل.

## **تنظیم متن راهنما در یک چیدمان**

متن راهنما (Prompt text) دستور طراحی است که در یک جای‌دار خالی نمایش داده می‌شود، مثلاً *Click to add title*. متن راهنمای سفارشی را بر روی جای‌دار چیدمان تنظیم کنید نه سعی در دسترسی به آن از طریق مجموعه شکل‌های اسلاید عادی. با استفاده از [Slide::getLayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getLayoutSlide) به چیدمان دسترسی پیدا کنید و بر روی مجموعه‌ای که توسط [BaseSlide::getShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getShapes) برگردانده می‌شود، تکرار کنید.

مثال زیر متن راهنمای عنوان و زیرعنوان را در چیدمان استفاده‌شده توسط اسلاید اول تغییر می‌دهد:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

متن راهنما محتوای عادی اسلاید نیست. این متن برای جای‌دارهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. هنگامی که کاربر یا برنامه محتوای واقعی را فراهم می‌کند، متن راهنما دیگر نمایش داده نمی‌شود. تغییر متن راهنما همچنین متن موجود در اسلایدهای استفاده‌کننده از چیدمان را جایگزین نمی‌کند.

## **به‌روزرسانی یک جای‌دار تصویر**

دو وضعیت برای مدیریت وجود دارد:

- اگر جای‌دار تصویر قبلاً پر شده باشد و توسط یک [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) نمایش داده شود، تصویر را با استفاده از [PictureFillFormat::getPicture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturefillformat/getpicture/) و [SlidesPicture::setImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidespicture/setimage/) جایگزین کنید.
- اگر هنوز یک جای‌دار خالی باشد، با استفاده از [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addpictureframe/) یک فریم تصویر در مختصات جای‌دار اضافه کنید و جای‌دار خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی کرده و ارائه را ذخیره می‌کند:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

جای‌گزینی ایجاد شده برای یک جای‌دار خالی یک فریم تصویر محلی است، نه یک جای‌دار جدید، زیرا [Shape::getPlaceholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getplaceholder/) تنظیم‌کننده‌ای (setter) ندارد. این فریم موقعیت رزرو شده را حفظ می‌کند اما رفتار خاص جای‌دار را دیگر به ارث نمی‌برد. اگر حفظ رابطه جای‌دار حیاتی است، ابتدا جای‌دار را در PowerPoint آماده و پر کنید، سپس فریم تصویر حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و دیگر اثرات مخصوص تصویر، به مقاله [Manage Picture Frames](/slides/fa/php-java/picture-frame/) مراجعه کنید. این عملیات‌ها به فریم تصویر یا پرکن تصویر تعلق دارند، نه به متاداده جای‌دار.

## **کار با جای‌دارهای نمودار و محتوا**

یک جای‌دار نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/) نمایش داده شود. این مثال چنین نموداری را بر پایه نوع جای‌دار و کلاس زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

یک جای‌دار محتوای عمومی معمولاً دارای [PlaceholderType::Object](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholdertype/) است. در PowerPoint این جای‌دار به‌عنوان یک راه‌انداز برای انواع مختلف محتوا مانند نمودارها، جدول‌ها، دیاگرام‌ها، تصاویر و رسانه‌ها عمل می‌کند. پس از پر شدن، برای فهمیدن محتوا، کلاس شکل واقعی را بررسی کنید. چیدمان‌های تخصصی می‌توانند همچنین [PlaceholderType::Chart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholdertype/)، [PlaceholderType::Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholdertype/)، [PlaceholderType::Picture](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholdertype/)، [PlaceholderType::Media](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholdertype/)، یا [PlaceholderType::Diagram](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholdertype/) را نشان دهند.

Aspose.Slides یک جای‌دار خالی [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) را تنها با تغییر [Placeholder::getType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/placeholder/gettype/) به یک [Chart](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/) تبدیل نمی‌کند؛ نوع از طریق کلاس قابل تغییر نیست. برای پر کردن برنامه‌matically یک ناحیه خالی نمودار یا محتوا، شیء مورد نیاز را در مختصات جای‌دار اضافه کنید و سپس جای‌دار خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

نمودار افزوده‌شده یک نمودار محلی عادی است. این نمودار فضای جای‌دار را اشغال می‌کند اما از جای‌دار چیدمان به ارث نمی‌برد. هنگام نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های کتاب‌کار، از مقالات اختصاصی [chart management articles](/slides/fa/php-java/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال سراسری زیر یک قالب را باز می‌کند، اسلاید اول را برای یافتن یک جای‌دار عنوان یا تصویر جستجو می‌کند، نوع جای‌دار و شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌نماید. این مثال عمداً از فرض یک اندیس شکل یا برخورد همه جای‌دارها به یک کلاس خودداری می‌کند.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **پرسش‌های متداول**

**جای‌دار پایه چیست؟**

یک جای‌دار پایه شکلی است که در چیدمان یا اسلاید اصلی قرار دارد و جای‌دار دیگری از آن ارث می‌برد. برای بازیابی آن از [Shape::getBasePlaceholder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getbaseplaceholder/) استفاده کنید. یک شکل محلی عادی `null` برمی‌گرداند زیرا بخشی از سلسله‌مراتب جای‌دارها نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک جای‌دار چیدمان تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمای ارث‌بری را از طریق یک چیدمان تغییر دهید، اما محتوای عنوان موجود در اسلایدهای عادی ذخیره شده است. برای جایگزینی واقعی متن عنوان در سراسر ارائه، بر روی اسلایدها تکرار کنید و هر جای‌دار عنوان را به‌روزرسانی کنید.

**چگونه می‌توانم جای‌دارهای تاریخ، شماره اسلاید، سرصفحه و پاورقی را مدیریت کنم؟**

از مدیران سرصفحه و پاورقی در اسلاید، چیدمان، اسلاید اصلی، یادداشت‌ها یا توزیع‌های چاپی مربوطه استفاده کنید. برای مثال‌های کامل، به مقاله [Manage Presentation Header and Footer](/slides/fa/php-java/presentation-header-and-footer/) مراجعه کنید.