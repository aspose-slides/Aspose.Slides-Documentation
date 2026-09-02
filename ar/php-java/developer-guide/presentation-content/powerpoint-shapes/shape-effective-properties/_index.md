---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية في PHP
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/php-java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام إضاءة
- شكل بيفل
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية استخدام Aspose.Slides for PHP عبر Java للتمييز بين تنسيق الشكل المحلي، الموروث، والفعّال في عروض PowerPoint التقديمية."
---
## **فهم الخصائص المحلية والوراثية والفعّالة**

يمكن أن يأتي تنسيق PowerPoint من عدة مصادر. القيمة المخزنة مباشرة على الكائن هي **القيمة المحلية**. إذا لم يتم تعيين هذه القيمة، فإن PowerPoint يبحث في مصادر التنسيق الأب، مثل الافتراضي للفقرة، نمط النص، تخطيط أو شريحة رئيسية، سمة، أو القيم الافتراضية على مستوى العرض. تلك القيم هي **القيم الموروثة**. القيمة التي تبقى بعد حل كامل الهرمية هي **القيمة الفعّالة** — القيمة المستخدمة لعرض الكائن.

على سبيل المثال، قد لا تحدد قطعة النص ارتفاع الخط الخاصة بها. تكون القيمة المحلية لـ [getFontHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/) هي `NAN`، مما يعني "لم يتم تعيينها هنا". يمكن للقطعة أن ترث ارتفاعًا من الفقرة، أو نمط النص الافتراضي للعرض، أو مصدر آخر مناسب. استدعاء [getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/geteffective/) على تنسيق القطعة يُعيد الارتفاع النهائي المحلول.

استخدم نوعي بيانات التنسيق لأغراض مختلفة:

- اقرأ أو غيّر كائن تنسيق محلي، مثل [PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/)، عندما تحتاج إلى التحكم في موقع تعريف القيمة.
- اقرأ كائن بيانات فعّالة، مثل [البيانات التي تُرجعها PortionFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/geteffective/)، عندما تحتاج إلى النتيجة النهائية المُرَسَمة. البيانات الفعّالة للقراءة فقط.

قبل تشغيل الأمثلة، [install Aspose.Slides for PHP via Java](/slides/ar/php-java/installation/).

## **مقارنة القيم المحلية والوراثية والفعّالة**

المثال الكامل التالي يُنشئ شكلًا ويُطبّق ارتفاعات الخط على مستويات العرض والفقرة والقطعة. كل خطوة تُطبع القيم المعرفة على تلك المستويات والقيمة الفعّالة الناتجة لنفس قطعة النص. كما يُظهر لماذا يجب قراءة البيانات الفعّالة مرة أخرى بعد تغييرات التنسيق.

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

    // قراءة البيانات الفعّالة بعد التغييرات السابقة.
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

    // تحديد القيم الوراثية على مستويين مختلفين.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // القيمة المحلية على القطعة تتجاوز القيمتين الموروثتين.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // تغيير قيمة وراثية لا يتجاوز القيمة المحلية الحالية.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // مسح القيمة المحلية. الآن القطعة ترث من الفقرة مرة أخرى.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // مسح قيمة الفقرة. الآن الافتراضي للعرض يزود بالنتيجة.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الأولوية في هذا المثال هي تنسيق القطعة المحلي، ثم تنسيق الفقرة، ثم الافتراضي للعرض. يمكن أن تكون للكائنات الأخرى سلاسل وراثة مختلفة، لكن المبدأ واحد: القيمة الصريحة الأكثر تحديدًا تفوز، و[getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/geteffective/) يُعيد النتيجة النهائية.

## **الحصول على خصائص النص الفعّالة**

تنقسم تنسيقات النص عبر عدة كائنات:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/geteffective/) يحل خصائص إطار النص مثل الهوامش، التثبيت، الملاءمة التلقائية، واتجاه النص العمودي.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textstyle/geteffective/) يحل تنسيق الفقرة لكل مستوى من مستويات نمط النص.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/geteffective/) يحل خواص الفقرة مثل المحاذاة، الإزاحة، والنقاط.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/geteffective/) يحل خصائص الأحرف مثل ارتفاع الخط، نوع الخط، اللون، الغامق، والمائل.

للمثال التالي، يجب أن يحتوي `text-formatting.pptx` على شريحة واحدة على الأقل وعلى [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) واحد به إطار نص غير فارغ. يمكن أن يظهر AutoShape في أي موضع داخل مجموعة الأشكال؛ يبحث الكود عن كائن مناسب ويتحقق منه قبل الاستخدام.

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

## **الحصول على خصائص 3D الفعّالة**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/) يُعيد كائن بيانات فعّال واحد يجمع كل إعدادات 3D المحلولة. طرقه [getCamera](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/)، [getLightRig](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/)، [getBevelTop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/)، و[getBevelBottom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/) تعرض البيانات الفعّالة المقابلة. قراءة هذه الإعدادات ذات الصلة معًا يجعل فهم المظهر النهائي ثلاثي الأبعاد للشكل أسهل.

لهذا المثال، يجب أن يحتوي `shape-3d.pptx` على شكل واحد على الأقل في شريحته الأولى. طبّق إعدادات كاميرا 3D أو إضاءة أو بيفل لهذا الشكل إذا أردت أن يحتوي الناتج على قيم غير القيم الافتراضية.

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

## **الحصول على تنسيق الجدول الفعّال**

يمكن أن يأتي تنسيق الجدول من نمط الجدول ومن التنسيقات المطبقة على كامل الجدول أو عمود أو صف أو خلية فردية. في حالات التعارض بين التعبئات المحددة صراحةً، الأولوية تكون للخلية، ثم الصف، ثم العمود، ثم الجدول بالكامل. التنسيق الفعّال للخلية هو التنسيق النهائي المستخدم لرسم تلك الخلية.

لهذا المثال، يجب أن يحتوي `table-formatting.pptx` على جدول واحد على الأقل في شريحته الأولى. يجب أن يحتوي الجدول على صف واحد على الأقل وعمود واحد على الأقل. يبحث الكود عن [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/) بدلاً من افتراض أن `getShapes()->get_Item(0)` هو جدول.

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

إذا كنت بحاجة إلى اللون بدلًا من نوع التعبئة فقط، تحقق أولًا من قيمة [getFillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/geteffective/) الفعّالة، ثم اقرأ الطريقة التي تنطبق على ذلك النوع — على سبيل المثال، [getSolidFillColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/geteffective/) لتعبئة صلبة.

## **إعادة قراءة البيانات الفعّالة بعد التغييرات**

البيانات الفعّالة تصف هرمية التنسيق في لحظة حلها. استدعِ `getEffective` مرة أخرى بعد تغيير أي شيء يمكن أن يشارك في تلك الهرمية، بما في ذلك:

- تنسيق الكائن المحلي؛
- الافتراضات للفقرة أو إطار النص؛
- نمط جدول أو جدول أو عمود أو صف أو تنسيق خلية؛
- تنسيق تخطيط أو شريحة رئيسية؛
- بيانات السمة أو الافتراضات على مستوى العرض؛
- التخطيط أو الشريحة الرئيسية المعيّن إلى شريحة.

لا تُحافظ على كائن بيانات فعّال كلقطة ثابتة. قد يُخزّن Aspose.Slides بعض البيانات الفعّالة داخليًا، ويمكن لاستدعاء `getEffective` لاحقًا تحديث تلك البيانات. إذا كنت تحتاج إلى مقارنة القيم قبل وبعد التغيير، انسخ القيم العددية التي تحتاجها — مثل ارتفاع الخط أو اللون أو المحاذاة أو عرض البيفل — إلى متغيراتك الخاصة قبل إجراء التغيير.

لتغيير قيمة، حدّث كائن التنسيق المحلي المناسب ثم استدعِ `getEffective` للتحقق من النتيجة. كائنات البيانات الفعّالة نفسها للقراءة فقط.

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أي مستوى قدم القيمة الفعّالة؟**

البيانات الفعّالة تحتوي على القيمة النهائية، لا مصدرها. افحص الكائنات المحلية القابلة للتطبيق ابتداءً من أكثر مستوى تحديدًا إلى الخارج. بالنسبة للنص، قد يشمل ذلك القطعة، الفقرة، إطار النص، التخطيط، الشريحة الرئيسية، السمة، وافتراضات العرض. القيم غير المعرفة مثل `NAN` أو `null` تشير إلى أن البحث يستمر إلى مستوى آخر.

**ماذا يحدث عندما لا يحدد أي مستوى خاصية؟**

يقوم Aspose.Slides بحل القيمة الافتراضية المناسبة لـ PowerPoint أو المكتبة. تظهر تلك القيمة المحلولة في البيانات الفعّالة رغم عدم تعريف أي كائن محلي لها صراحةً.

**لماذا تتساوى أحيانًا القيمة الفعّالة مع القيمة المحلية؟**

الفوز للقيمة المحلية في حساب الوراثة. هذا متوقع عندما يتم تعيين الخاصية صراحةً على الكائن ولا يتجاوزها قاعدة أكثر تحديدًا.

**متى ينبغي استخدام البيانات المحلية بدلًا من البيانات الفعّالة؟**

استخدم البيانات المحلية لتفحص أو تعديل مستوى تنسيق معين. استخدم البيانات الفعّالة عندما تحتاج إلى المظهر النهائي بعد حل الوراثة وقواعد السمة والأنماط المطبقة. يُظهر [complete comparison example](#compare-local-inherited-and-effective-values) كلاهما في نفس سير العمل.