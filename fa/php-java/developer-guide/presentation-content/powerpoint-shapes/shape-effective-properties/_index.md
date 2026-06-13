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
- شکل برجسته
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پر کردن
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "کشف کنید Aspose.Slides برای PHP از طریق Java چگونه ویژگی‌های مؤثر شکل را محاسبه و اعمال می‌کند تا رندر دقیق PowerPoint صورت گیرد."
---
## **مرور کلی**

این موضوع تفاوت بین ویژگی‌های **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی مقادیری هستند که مستقیماً در یک سطح خاص قالب‌بندی تنظیم می‌شوند، مثل:

1. ویژگی‌های قسمت در یک اسلاید.
2. سبک‌های متن شکل الگو در یک لایه یا اسلاید اصلی، هنگامی که شکل قاب متن قسمت یک مقدار دارد.
3. تنظیمات متن سراسری در یک ارائه.

مقادیر محلی می‌توانند در هر سطح تعریف یا حذف شوند. وقتی Aspose.Slides به قالب‌بندی نهایی «همان‌گونه که رندر شده» نیاز دارد، زنجیره وراثت را حل کرده و مقادیر **موثر** را برمی‌گرداند. می‌توانید با فراخوانی متد `getEffective` بر روی شیء قالب محلی، این مقادیر را دریافت کنید.

مثال زیر نشان می‌دهد چگونه مقادیر موثر را بدست آورید. فرض می‌شود اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) با قاب متن و حداقل یک قسمت باشد.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}

داده‌های قالب‌بندی موثر نمایانگر قالب‌بندی محاسبه‌شده فعلی پس از اعمال وراثت است. در پیاده‌سازی فعلی، برخی از اشیای داده موثر که توسط متدهایی مانند [PortionFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/geteffective/) برگردانده می‌شوند ممکن است به‌صورت داخلی کش شوند. فراخوانی دوباره `getEffective` پس از تغییر قالب‌بندی والد یا ارث‌بری می‌تواند داده‌های کش‌شده را تازه کند و شیء قبلاً دریافت‌شده ممکن است دیگر نمایانگر وضعیت قبلی نباشد. اگر نیاز دارید مقادیر موثر را برای استفاده مجدد در آینده حفظ کنید، ویژگی‌های مورد نیاز مانند ارتفاع قلم، رنگ پر، سبک قلم یا ترازبندی را در شیء داده خود کپی کنید.

{{% /alert %}}

## **دریافت ویژگی‌های موثر یک دوربین**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های موثر یک دوربین را دریافت کنید. داده‌های موثر برگردانده‌شده توسط [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/geteffective/) شامل ویژگی‌های نهایی دوربین برای یک [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) است.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های موثر دوربین را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **دریافت ویژگی‌های موثر یک نورپردازی**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های موثر یک نورپردازی را دریافت کنید. داده‌های موثر برگردانده‌شده توسط [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/geteffective/) شامل ویژگی‌های نهایی نورپردازی برای یک [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) است.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های موثر نورپردازی را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **دریافت ویژگی‌های موثر یک شکل برجسته**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های موثر برجستگی یک شکل را دریافت کنید. داده‌های موثر برگردانده‌شده توسط [ThreeDFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/geteffective/) شامل ویژگی‌های نهایی برجستگی برای یک [ThreeDFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/threedformat/) است.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های موثر برجستگی بالای یک شکل را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی سه‌بعدی باشد.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **دریافت ویژگی‌های موثر یک قاب متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های موثر یک قاب متن را دریافت کنید. داده‌های موثر برگردانده‌شده توسط [TextFrameFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/geteffective/) شامل ویژگی‌های قالب‌بندی قاب متن است.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های قالب‌بندی موثر قاب متن را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) با قاب متن باشد.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **دریافت ویژگی‌های موثر یک سبک متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های موثر یک سبک متن را دریافت کنید. داده‌های موثر برگردانده‌شده توسط [TextStyle.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textstyle/geteffective/) شامل ویژگی‌های سبک متن است.

کد نمونه زیر نشان می‌دهد چگونه ویژگی‌های موثر سبک متن را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) با قاب متن باشد.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **دریافت مقدار ارتفاع قلم موثر**

با استفاده از Aspose.Slides می‌توانید ارتفاع قلم موثر را دریافت کنید. کد زیر نشان می‌دهد چگونه ارتفاع قلم موثر یک قسمت پس از تنظیم مقادیر ارتفاع قلم محلی در سطوح مختلف ساختار ارائه تغییر می‌کند.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دریافت فرمت پر کردن موثر برای یک جدول**

با استفاده از Aspose.Slides می‌توانید قالب‌بندی پر کردن موثر برای بخش‌های مختلف جدول را دریافت کنید. داده‌های موثر برگردانده‌شده توسط اشیای قالب شامل ویژگی‌های [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) است. قالب‌بندی سلول نسبت به قالب‌بندی ردیف اولویت بالاتری دارد، قالب‌بندی ردیف نسبت به قالب‌بندی ستون اولویت بالاتری دارد و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول اولویت بالاتری دارد.

در نتیجه، ویژگی‌های موثر [CellFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/cellformat/) برای رسم سلول جدول استفاده می‌شوند. کد نمونه زیر نشان می‌دهد چگونه قالب‌بندی پر کردن موثر برای بخش‌های مختلف جدول را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [Table](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/) باشد.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **سؤال‌های متداول**

**آیا `getEffective` یک تصویر لحظه‌ای بر می‌گرداند؟**

همیشه نیست. داده‌های موثر نمایانگر قالب‌بندی محاسبه‌شده پس از اعمال وراثت هستند، اما بعضی از اشیای داده موثر ممکن است به‌صورت داخلی کش شوند. فراخوانی بعدی `getEffective` ممکن است قالب‌بندی را مجدداً محاسبه کند و داده‌های کش‌شده را تازه کند، بنابراین شیء قبلاً به‌دست آمده نباید به عنوان یک تصویر لحظه‌ای دائمی در نظر گرفته شود.

**چه زمانی باید ویژگی‌های موثر را دوباره خوانده شوند؟**

پس از تغییر قالب‌بندی محلی، سبک‌های والد، قالب‌بندی لایه، قالب‌بندی اصلی یا مقدارهای پیش‌فرض در سطح ارائه، `getEffective` را دوباره فراخوانی کنید. فراخوانی بعدی سلسله‌مراتب قالب‌بندی را دوباره ارزیابی می‌کند و نتیجهٔ موثر فعلی را برمی‌گرداند.

**آیا تغییر یا حذف یک لایه/اسلاید اصلی بر ویژگی‌های مؤثری که قبلاً دریافت شده‌اند تأثیر می‌گذارد؟**

بله، اما این تغییر در فراخوانی بعدی `getEffective` منعکس می‌شود. اگر منبع قالب‌بندی والد تغییر یا حذف شود، داده‌های موثر قبلی ممکن است منسوخ شوند. پس از فراخوانی دوباره `getEffective`، Aspose.Slides درخت قالب‌بندی را دوباره ارزیابی می‌کند و قلم‌ها، رنگ‌ها، اندازه‌ها یا مقادیر دیگر ممکن است تغییر کنند.

**آیا می‌توانم مقادیر را از طریق اشیای داده موثر تغییر دهم؟**

خیر. اشیای داده موثر فقط مقادیر محاسبه‌شده را نمایش می‌دهند. تغییرات را در اشیای قالب‌بندی محلی انجام دهید و سپس مقادیر موثر را دوباره بدست آورید.

**اگر یک ویژگی در سطح شکل، لایه/اسلاید اصلی یا تنظیمات سراسری تنظیم نشده باشد، چه می‌شود؟**

مقدار موثر توسط مکانیزم پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides است. آن مقدار حل‌شده بخشی از داده‌های موثر فعلی می‌شود.

**از یک مقدار قلم موثر، آیا می‌توانم تشخیص دهم که کدام سطح اندازه یا قلم را ارائه داده است؟**

به‌طور مستقیم نیست. داده‌های موثر فقط مقدار نهایی را برمی‌گردانند. برای یافتن منبع، مقادیر محلی را در قسمت، پاراگراف، قاب متن و سبک‌های متن در لایه، اسلاید اصلی و سطح ارائه بررسی کنید تا اولین تعریف صریح را بیابید.

**چرا گاهی مقادیر موثر شبیه مقادیر محلی به نظر می‌آیند؟**

زیرا مقدار محلی در نهایت نهایی شده است (نیازی به وراثت از سطح بالاتر نبوده). در این حالت، مقدار موثر همان مقدار محلی است.

**چه زمانی باید از ویژگی‌های موثر استفاده کنم و چه زمانی فقط با ویژگی‌های محلی کار کنم؟**

وقتی به نتیجهٔ «همان‌گونه که رندر شده» پس از تمام وراثت‌ها نیاز دارید، از داده‌های موثر استفاده کنید، مثلاً برای هماهنگ‌سازی رنگ‌ها، تورفتگی‌ها یا اندازه‌ها. اگر می‌خواهید این مقادیر را بدون درنظر گرفتن تغییرات بعدی قالب‌بندی حفظ کنید، ویژگی‌های مورد نیاز را در شیء خود کپی کنید. اگر می‌خواهید قالب‌بندی را در سطح خاصی تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس در صورت نیاز، داده‌های موثر را دوباره بخوانید تا نتیجه را تأیید کنید.