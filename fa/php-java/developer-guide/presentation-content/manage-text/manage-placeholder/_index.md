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
description: "بیاموزید چگونه جای‌دارهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و ارث‌بری جای‌دارها را با Aspose.Slides برای PHP از طریق Java درک نمایید."
---
## **مرور کلی**

یک جای‌دار (placeholder) یک شکل است که موقعیت را برای نوع خاصی از محتوا در قالب ارائه رزرو می‌کند. مثال‌های رایج شامل عنوان، بدنه، تصویر، نمودار و جای‌دارهای محتوای عمومی هستند. برخلاف یک شکل عادی، یک جای‌دار می‌تواند موقعیت، اندازه، فرمت‌بندی و تنظیمات دیگر خود را از اسلاید چیدمان یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات جای‌دار را از طریق متد [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) در دسترس قرار می‌دهد. این متد یک شیء [Placeholder](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/) یا `null` برای یک شکل عادی برمی‌گرداند. برای تعیین محتوایی که جای‌دار برای آن در نظر گرفته شده است، از [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) استفاده کنید.

کلاس شکل پس از آگاهی از نوع جای‌دار نیز مهم است:

- یک جای‌دار خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) نمایش داده می‌شود.
- یک جای‌دار تصویر پر شده می‌تواند توسط یک [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) نمایش داده شود.
- یک جای‌دار نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) نمایش داده شود.
- یک جای‌دار محتوا می‌تواند انواع مختلف محتوا را در خود داشته باشد. به جای این فرض که هر جای‌دار یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) است، هم [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) و هم کلاس زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/) نقش یک جای‌دار را توصیف می‌کند؛ اما تضمین نمی‌کند کلاس زمان اجرای شکل چه باشد. قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه‌ای، همیشه یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک ارث‌بری جای‌دار**

جای‌دارها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد را تعریف می‌کند و در برخی موارد، جای‌دارهای سطح اصلی را نیز شامل می‌شود.
2. یک اسلاید چیدمان (layout) ترتیب استفاده‌شده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از اسلاید اصلی ارث‌بری کند.
3. یک اسلاید عادی، جای‌دارهای خود را دارد و می‌تواند از چیدمان خود ارث‌بری کند.

برای حرکت یک سطح بالاتر در این سلسله‌مراتب، متد [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) را فراخوانی کنید. یک جای‌دار اسلاید عادی معمولاً جای‌دار چیدمان خود را برمی‌گرداند؛ یک جای‌دار چیدمان می‌تواند جای‌دار اصلی را برگرداند. این متد وقتی که شکل هیچ پایه‌ای نداشته باشد `null` برمی‌گرداند.

مثال زیر جای‌دارهای اسلاید اول را فهرست می‌کند و پایه آنها را گزارش می‌دهد:

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

ویرایش یک جای‌دار در اسلاید عادی، یک بازنویسی محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش چیدمان یا اسلاید اصلی مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند، تأثیر بگذارد. یک شکل عادی محلی پایه‌ای برای جای‌دار ندارد و به دلیل قرارگیری در همان مختصات، شروع به ارث‌بری نمی‌کند.

## **حذف وضعیت جای‌دار**

هنگام سازگار کردن یک قالب، از [Shape::removePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/removeplaceholder/) استفاده کنید تا یک شیء موجود را به شکل عادی تبدیل کنید. متد [getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) آن `null` برمی‌گرداند، اما شکل همچنان در مجموعه اسلاید باقی می‌ماند. در مقابل، متد [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) شکل را از آن مجموعه حذف می‌کند.

مثال زیر نیازمند فایلی به نام `template.pptx` که حداقل یک اسلاید و یک جای‌دار متن غیر خالی در اسلاید اول داشته باشد. برای مشاهده اثر حذف رابطه، از یک جای‌دار با فرمت‌بندی ارث‌بری‌شده از چیدمان یا اسلاید اصلی استفاده کنید. مثال بررسی می‌کند که همان شکل باقی می‌ماند، دوباره متد را بر روی شکل اکنون عادی فراخوانی می‌کند و خروجی را ذخیره می‌کند.

{{% alert color="warning" title="Warning" %}}
حذف وضعیت جای‌دار به‌طور خودکار تنظیمات ظاهر ارث‌بری‌شده را حفظ نمی‌کند. مثال زیر عمداً این تنظیمات را دست‌نخورده باقی می‌گذارد، بنابراین خروجی ممکن است متفاوت به‌نظر برسد. یک شکل که موقعیت و اندازه‌اش کاملاً ارث‌بری شده باشد، پس از فراخوانی می‌تواند مختصات و ابعاد صفر داشته باشد و حتی اگر در مجموعه باقی بماند، نامرئی شود.
{{% /alert %}}

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $found = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        $textFrame = $shape->getTextFrame();
        if (java_is_null($placeholder) || java_is_null($textFrame)) {
            continue;
        }

        $textValue = $textFrame->getText();
        if (java_is_null($textValue)) {
            continue;
        }
        $text = java_values($textValue);
        if ($text === "") {
            continue;
        }

        $shape->removePlaceholder();

        $placeholder = $shape->getPlaceholder();
        $retainedShape = $slide->getShapes()->get_Item($shapeIndex);
        $sameShapeValue = $shape->equals($retainedShape);
        $sameShape = java_values($sameShapeValue);
        $remainingCountValue = $slide->getShapes()->size();
        $remainingCount = java_values($remainingCountValue);
        echo "Placeholder removed: " . (java_is_null($placeholder) ? "true" : "false") . PHP_EOL;
        echo "Same shape retained: " . ($sameShape ? "true" : "false") . PHP_EOL;
        echo "Shape count unchanged: " . ($remainingCount === $shapeCount ? "true" : "false") . PHP_EOL;

        // فراخوانی متد روی یک شکل عادی هیچ تاثیری ندارد.
        $shape->removePlaceholder();
        $found = true;
        break;
    }

    if ($found) {
        $presentation->save("placeholder-status-removed.pptx", SaveFormat::Pptx);
    } else {
        echo "No nonempty text placeholder was found on the first slide." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

برای یک جای‌دار منطبق، هر سه بررسی `true` چاپ می‌شود. متن باقی می‌ماند، اما موقعیت، اندازه، چرخش، قلم، تراز پاراگراف، حاشیه‌های قاب متن، لنگر عمودی، پر‌کردن و تنظیمات خط می‌توانند هنگام حذف رابطه جای‌دار تغییر کنند. به عنوان مثال، فرمت‌بندی ارث‌بری‌شده عنوان ممکن است به فرمت‌بندی متن عادی بازگردد. برای جزئیات بیشتر درباره چیدمان‌ها، به [Slide Layout](/slides/fa/php-java/slide-layout/) مراجعه کنید.

برای حفظ ظاهر موردنظر، قبل از فراخوانی موقعیت، اندازه و چرخش حل‌شده را ثبت کنید و مقادیر فرمت‌بندی مؤثر موردنیاز را در متغیرهای جداگانه کپی کنید. این مقادیر را از طریق [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/)، [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/geteffective/)، [TextFrameFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/geteffective/)، [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/geteffective/)، و [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/geteffective/) به‌دست آورید. فقط به اشیای فرمت مؤثر اکتفا نکنید، زیرا مقادیر فرمت متن آن‌ها می‌تواند پس از حذف رابطه تغییر کند. مقادیر ثبت‌شده را به‌صورت صریح بر روی شکل عادی اعمال کنید، شامل خانواده قلم، اندازه، سبک، رنگ، تنظیمات پاراگراف، تنظیمات قاب متن، پر‌کردن و خط مورد استفاده در قالب شما.

هندسهٔ ارث‌بری‌شده شکل ممکن است نیاز به اختصاص صریح از طریق [GeometryShape::setShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setShapeType) داشته باشد. برای یک جای‌دار متن مستطیلی، این به معنای اختصاص [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) است؛ فقط بازگرداندن پر‌کردن و خط ممکن است مستطیل قابل مشاهده را بازنشر نکند. قالب‌های دارای افکت‌های اضافی یا فرمت‌بندی پیچیده‌تر نیز نیاز به پردازش این تنظیمات دارند.

## **تغییر متن در جای‌دار**

جای‌دارهای عنوان، عنوان‑مرکزی، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. پیش از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) برای یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) بررسی کنید.

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

این الگو از در نظر گرفتن تصویر، نمودار، جدول یا رسانه به‌عنوان اشیای [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) جلوگیری می‌کند و به‌جای آن جای‌دار را بر اساس هدف شناسایی می‌کند، نه بر اساس یک شاخص شکل ناپایدار.

## **تنظیم متن راهنما در چیدمان**

متن راهنما (Prompt text) دستورالعمل زمان طراحی است که در یک جای‌دار خالی نمایش داده می‌شود، مانند *Click to add title*. متن راهنمای سفارشی را بر روی جای‌دار چیدمان تنظیم کنید، نه از طریق مجموعهٔ اشکال اسلاید عادی. برای این کار، چیدمان را از طریق [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getLayoutSlide) به‌دست آورده و بر روی مجموعه‌ای که [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) برمی‌گرداند، پیمایش کنید.

مثال زیر متن راهنمای عنوان و زیرعنوان را در چیدمانی که توسط اسلاید اول استفاده می‌شود، تغییر می‌دهد:

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

متن راهنما محتوای اسلاید عادی نیست. این متن برای جای‌دارهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. وقتی کاربر یا برنامه محتوای واقعی را وارد کرد، راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما همچنین متن موجود در اسلایدهایی که از این چیدمان استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک جای‌دار تصویر**

دو حالت باید مدیریت شوند:

- اگر جای‌دار تصویر پیشاپیش پر شده باشد و توسط یک [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) نمایش داده می‌شود، تصویر را از طریق [PictureFillFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/getpicture/) و [Picture::setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/#setImage) جایگزین کنید.
- اگر هنوز یک جای‌دار خالی باشد، یک چارچوب تصویر را در مختصات جای‌دار با [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) اضافه کنید و جای‌دار خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌نماید:

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

جای‌گذاری ایجادشده برای یک جای‌دار خالی، یک چارچوب تصویر محلی است، نه یک جای‌دار جدید، زیرا [Shape::getPlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getplaceholder/) تنظیم‌گری (setter) ارائه نمی‌دهد. این چارچوب موقعیت رزروشده را حفظ می‌کند اما دیگر رفتار خاص جای‌دار را ارث نمی‌برد. اگر حفظ رابطه جای‌دار ضروری است، ابتدا جای‌دار را در PowerPoint آماده و پر کنید، سپس [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر افکت‌های خاص تصویر، به [Manage Picture Frames](/slides/fa/php-java/picture-frame/) مراجعه کنید. این عملیات‌ها به چارچوب تصویر یا پر‌کردن تصویر تعلق دارند، نه به متادیتای جای‌دار.

## **کار با جای‌دارهای نمودار و محتوا**

یک جای‌دار نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) نمایش داده شود. این مثال یک نمودار را هم بر اساس نوع جای‌دار و هم بر اساس کلاس زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

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

یک جای‌دار محتوای عمومی معمولاً دارای [PlaceholderType::Object](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) است. در PowerPoint این جای‌دار به‌عنوان یک راه‌انداز برای انواع محتواهای مختلف مانند نمودارها، جدول‌ها، دیاگرام‌ها، تصاویر و رسانه‌ها عمل می‌کند. پس از پر شدن، برای فهمیدن آنچه داخلش است، کلاس شکل واقعی را بررسی کنید. چیدمان‌های تخصصی می‌توانند همچنین [PlaceholderType::Chart](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)، [PlaceholderType::Table](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)، [PlaceholderType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/)، [PlaceholderType::Media](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) یا [PlaceholderType::Diagram](https://reference.aspose.com/slides/php-java/aspose.slides/placeholdertype/) را نشان دهند.

Aspose.Slides یک [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) خالی را به‌صورت خودکار به یک [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) تبدیل نمی‌کند فقط با تغییر [Placeholder::getType](https://reference.aspose.com/slides/php-java/aspose.slides/placeholder/gettype/); نوع را نمی‌توان از طریق کلاس تغییر داد. برای پر کردن برنامه‌ای یک ناحیهٔ نمودار یا محتوا خالی، شیء موردنیاز را در مختصات جای‌دار اضافه کنید و سپس جای‌دار خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

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

نمودار اضافه‌شده یک نمودار محلی عادی است. این نمودار فضای جای‌دار را اشغال می‌کند اما از چیدمان اصلی ارث نمی‌برد. هنگامی که نیاز به جایگزینی دسته‌بندی‌ها، سری‌ها یا داده‌های کتاب‌کار دارید، از مقالات اختصاصی [chart management articles](/slides/fa/php-java/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها‑به‑انتها زیر یک قالب را باز می‌کند، اسلاید اول را برای یافتن یک جای‌دار عنوان یا تصویر جستجو می‌کند، نوع جای‌دار و شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌نماید. این مثال عمداً از فرض وجود یک شاخص شکل یا بررسی همه جای‌دارها به‌عنوان یک کلاس یکسان خودداری می‌کند.

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

## **سوالات متداول**

**جای‌دار پایه چیست؟**

یک جای‌دار پایه، شکل متناظر در چیدمان یا اسلاید اصلی است که یک جای‌دار دیگر از آن ارث می‌برد. برای بازیابی آن از [Shape::getBasePlaceholder](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getbaseplaceholder/) استفاده کنید. یک شکل محلی عادی `null` برمی‌گرداند چون بخشی از سلسله‌مراتب جای‌دارها نیست.

**آیا می‌توان تمام عناوین اسلایدها را با ویرایش یک جای‌دار چیدمان تغییر داد؟**

شما می‌توانید فرمت‌بندی یا متن راهنمای ارث‌بری‌شده را از طریق یک چیدمان تغییر دهید، اما محتوای واقعی عنوان در اسلایدهای عادی ذخیره می‌شود. برای جایگزینی متن عنوان واقعی در یک ارائه، باید بر روی اسلایدها پیمایش کنید و هر جای‌دار عنوان را به‌روزرسانی نمایید.

**چگونه می‌توان جای‌دارهای تاریخ، شماره اسلاید، سرصفحه و پاورقی را مدیریت کرد؟**

از مدیرهای سرصفحه و پاورقی در سطح اسلاید، چیدمان، اسلاید اصلی، یادداشت‌ها یا جزوه استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/php-java/presentation-header-and-footer/) مراجعه کنید.