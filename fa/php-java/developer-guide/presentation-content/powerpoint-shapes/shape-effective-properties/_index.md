---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در PHP
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/php-java/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- برش شکل
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پرکننده
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه از Aspose.Slides برای PHP از طریق Java استفاده کنید تا قالب‌بندی محلی، ارثی و مؤثر اشکال را در ارائه‌های PowerPoint تشخیص دهید."
---
## **درک ویژگی‌های محلی، ارثی و مؤثر**

قالب‌بندی PowerPoint می‌تواند از چندین منبع حاصل شود. مقدار ذخیره‌شده مستقیم بر روی شی **مقدار محلی** نامیده می‌شود. اگر این مقدار تنظیم نشده باشد، PowerPoint به منابع قالب‌بندی والد مانند پیش‌فرض پاراگراف، سبک متن، لِیوت یا اسلاید اصلی، تم یا پیش‌فرض‌های سطح ارائه نگاه می‌کند. آن مقادیر **مقادیر ارثی** هستند. مقداری که پس از حل کامل سلسله‌مراتبی باقی می‌ماند **مقدار مؤثر** است— مقداری که برای رندر شی استفاده می‌شود.

به عنوان مثال، ممکن است بخشی از متن ارتفاع قلم خود را تعریف نکند. مقدار محلی آن [getFontHeight](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseportionformat/) سپس `NAN` است که به معنای «در اینجا تنظیم نشده» می‌باشد. این بخش می‌تواند ارتفاع را از پاراگراف، سبک متن پیش‌فرض ارائه یا منبع قابل اعمال دیگر به ارث ببرد. فراخوانی [getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/geteffective/) بر روی قالب بخش، ارتفاع نهایی حل‌شده را بر می‌گرداند.

از دو نوع داده قالب‌بندی برای اهداف مختلف استفاده کنید:

- برای خواندن یا تغییر شی قالب محلی، مانند [PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/)، زمانی که نیاز دارید درک کنید مقدار در کجا تعریف شده است.
- برای خواندن شی داده مؤثر، مانند [داده‌ای که توسط PortionFormat.getEffective برگردانده می‌شود](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/geteffective/)، زمانی که به نتیجه نهایی رندر شده نیاز دارید. داده‌های مؤثر فقط-خواندنی هستند.

قبل از اجرای مثال‌ها، [Aspose.Slides for PHP via Java را نصب کنید](/slides/fa/php-java/installation/).

## **مقایسه مقادیر محلی، ارثی و مؤثر**

مثال کامل زیر یک شکل ایجاد می‌کند و ارتفاع قلم را در سطوح ارائه، پاراگراف و بخش تنظیم می‌نماید. هر مرحله مقادیر تعریف‌شده در آن سطوح و مقدار مؤثر حاصل برای همان بخش متن را چاپ می‌کند. همچنین نشان می‌دهد چرا پس از تغییرات قالب‌بندی باید دوباره داده مؤثر خوانده شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // داده مؤثر را پس از تغییرات قبلی بخوانید.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // مقادیر ارثی را در دو سطح مختلف تعریف کنید.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // یک مقدار محلی در بخش، هر دو مقدار ارثی را نادیده می‌گیرد.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // تغییر یک مقدار ارثی مقدار محلی موجود را نادیده نمی‌گیرد.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // مقدار محلی را پاک کنید. بخش دوباره از پاراگراف ارث می‌برد.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // مقدار پاراگراف را پاک کنید. پیش‌فرض ارائه اکنون نتیجه را فراهم می‌کند.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اولویت در این مثال ابتدا قالب‌بندی محلی بخش، سپس قالب‌بندی پاراگراف، و در نهایت پیش‌فرض ارائه است. اشیای دیگر می‌توانند زنجیره ارث‌بری متفاوتی داشته باشند، اما اصل یکسان است: مقدار صریح خاص‌تر برتری دارد و [getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/geteffective/) نتیجه نهایی را بر می‌گرداند.

## **دریافت ویژگی‌های متن مؤثر**

قالب‌بندی متن در چند شی تقسیم می‌شود:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/geteffective/) خصوصیات قاب متن مانند حاشیه‌ها، تکیه‌گاه، خود‌سازگاری و جهت متن عمودی را حل می‌کند.
- [TextStyle.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textstyle/geteffective/) قالب‌بندی پاراگراف را برای هر سطح سبک متن حل می‌کند.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/paragraphformat/geteffective/) خصوصیات پاراگراف مانند تراز، تورفتگی و گلوله‌ها را حل می‌کند.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/geteffective/) خصوصیات کاراکتر مانند ارتفاع قلم، نوع قلم، رنگ، ضخیم و ایتالیک را حل می‌کند.

برای مثال بعدی، فایل `text-formatting.pptx` باید حداقل شامل یک اسلاید و یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) با فریم متنی غیرخالی باشد. AutoShape می‌تواند در هر موقعیتی از مجموعهٔ اشکال ظاهر شود؛ کد یک شی مناسب را جستجو می‌کند و قبل از استفاده آن را تأیید می‌نماید.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **دریافت ویژگی‌های سه‌بعدی مؤثر**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/geteffective/) یک شی داده مؤثر را بر می‌گرداند که تمام تنظیمات حل‌شدهٔ سه‌بعدی را گروه‌بندی می‌کند. متدهای [getCamera](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/geteffective/)، [getLightRig](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/geteffective/)، [getBevelTop](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/geteffective/) و [getBevelBottom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/geteffective/) داده‌های مؤثر متناظر را نشان می‌دهند. خواندن این تنظیمات مرتبط به‌صورت همراه فهم نهایی ظاهر سه‌بعدی یک شکل را آسان‌تر می‌سازد.

برای این مثال، فایل `shape-3d.pptx` باید حداقل شامل یک شکل در اسلاید اول باشد. اگر می‌خواهید خروجی شامل مقادیری غیر از پیش‌فرض باشد، تنظیمات دوربین، نور یا بریده‌گی سه‌بعدی را به آن شکل اعمال کنید.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **دریافت قالب‌بندی جدول مؤثر**

قالب‌بندی جدول می‌تواند از سبک جدول و یا قالب‌های اعمال‌شده بر کل جدول، یک ستون، یک ردیف یا یک سلول منفرد حاصل شود. در مواردی که پرکننده‌های صریح با هم درگیر شوند، اولویت به ترتیب سلول، ردیف، ستون و سپس کل جدول است. قالب مؤثر یک سلول، قالب نهایی است که برای رسم آن سلول استفاده می‌شود.

برای این مثال، فایل `table-formatting.pptx` باید حداقل شامل یک جدول در اسلاید اول باشد. جدول باید حداقل یک ردیف و یک ستون داشته باشد. کد به‌جای فرض اینکه `getShapes()->get_Item(0)` یک جدول است، به دنبال یک [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/) می‌گردد.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

اگر به رنگ نیاز دارید نه تنها به نوع پرکننده، ابتدا مقدار مؤثر [getFillType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/geteffective/) را بررسی کنید و سپس متد مربوط به آن نوع را بخوانید— برای مثال، [getSolidFillColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/geteffective/) برای پرکنندهٔ ثابت.

## **دوباره‌خواندن داده‌های مؤثر پس از تغییرات**

داده‌های مؤثر توصیف‌کنندهٔ سلسله‌مراتبی قالب‌بندی در زمان حل هستند. پس از تغییر هر چیزی که می‌تواند در آن سلسله‌مراتبی مشارکت داشته باشد، `getEffective` را دوباره فراخوانی کنید، از جمله:

- قالب‌بندی محلی شی؛
- پیش‌فرض‌های پاراگراف یا قاب متن؛
- قالب سبک جدول، جدول، ستون، ردیف یا سلول؛
- قالب‌بندی لِیوت یا اسلاید اصلی؛
- داده‌های تم یا پیش‌فرض‌های سطح ارائه؛
- لِیوت یا اسلاید اصلی اختصاص داده‌شده به اسلاید.

داده‌های مؤثر را به‌عنوان یک اسنپ‌شات دائمی نگه ندارید. Aspose.Slides ممکن است برخی داده‌های مؤثر را به‌صورت داخلی کش کند و فراخوانی بعدی `getEffective` می‌تواند آن داده‌ها را تازه‌سازی کند. اگر نیاز به مقایسه مقادیر قبل و بعد از تغییر دارید، مقادیر اسکالاری که نیاز دارید—مانند ارتفاع قلم، رنگ، تراز یا عرض بریده‌گی—را قبل از اعمال تغییر در متغیرهای خود کپی کنید.

برای تغییر یک مقدار، شی قالب محلی مناسب را به‌روزرسانی کنید و سپس `getEffective` را فراخوانی کنید تا نتیجه را تأیید کنید. اشیای داده مؤثر خود به‌تنهایی فقط‑خواندنی هستند.

## **سؤالات متداول**

**چگونه می‌توانم تشخیص دهم کدام سطح مقدار مؤثر را فراهم کرده است؟**

داده‌های مؤثر فقط مقدار نهایی را در خود دارند، منبع آن را نشان نمی‌دهند. باید اشیای محلی مربوطه را از سطح خاص‌ترین به سمت سطح عمومی‌تر بررسی کنید. برای متن این می‌تواند شامل بخش، پاراگراف، قاب متن، لِیوت، اسلاید اصلی، تم و پیش‌فرض‌های ارائه باشد. مقادیر تعریف‌نشده مانند `NAN` یا `null` نشان می‌دهند که جستجو به سطح دیگر ادامه دارد.

**اگر هیچ سطحی ویژگی‌ای را تعریف نکند چه می‌شود؟**

Aspose.Slides مقدار پیش‌فرض مناسب PowerPoint یا کتابخانه را حل می‌کند. آن مقدار حل‌شده در دادهٔ مؤثر ظاهر می‌شود حتی اگر هیچ شی محلی به صراحت آن را تعریف نکرده باشد.

**چرا گاهی مقدار مؤثر برابر مقدار محلی می‌شود؟**

مقدار محلی محاسبه ارث‌بری را برنده شده است. این وضعیت زمانی پیش می‌آید که ویژگی به‌صورت صریح بر روی شی تنظیم شده باشد و هیچ قانون خاص‌تری آن را بازنویسی نکرده باشد.

**چه زمانی باید به‌جای دادهٔ مؤثر از دادهٔ محلی استفاده کنم؟**

از دادهٔ محلی برای بررسی یا ویرایش یک سطح قالب‌بندی خاص استفاده کنید. از دادهٔ مؤثر زمانی استفاده کنید که به ظاهر نهایی پس از ارث‌بری، قوانین تم و سبک‌های قابل‌اعمال نیاز دارید. [مثال کامل مقایسه](#compare-local-inherited-and-effective-values) هر دو را در یک جریان کار نشان می‌دهد.