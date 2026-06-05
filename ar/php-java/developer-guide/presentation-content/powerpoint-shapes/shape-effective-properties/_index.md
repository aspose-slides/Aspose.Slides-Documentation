---
title: الحصول على الخصائص الفعّالة للأشكال من العروض التقديمية في PHP
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/php-java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز الإضاءة
- شكل التقويس
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: اكتشف كيف تقوم Aspose.Slides لـ PHP عبر Java بحساب وتطبيق الخصائص الفعّالة للأشكال لتحقيق عرض PowerPoint بدقة.
---
## **نظرة عامة**

يشرح هذا الموضوع الفرق بين الخصائص **المحلية** والخصائص **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء في الشريحة.
1. أنماط نص الشكل النموذجي في تخطيط أو شريحة أساسية، عندما يحتوي شكل إطار نص الجزء على أحدها.
1. إعدادات النص العالمية في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها على أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما تم عرضه"، تقوم بحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها عن طريق استدعاء الطريقة `getEffective` على كائن التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مع إطار نص وعلى الأقل جزء واحد.

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
تمثل بيانات التنسيق الفعّال التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة التي تُعيدها طرق مثل [PortionFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/geteffective/) داخلياً. استدعاء `getEffective` مرة أخرى بعد تغيير التنسيق الأب أو الموروث يمكن أن يجدد البيانات المخزنة، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقاً الحالة السابقة. إذا كنت بحاجة إلى الحفاظ على القيم الفعّالة لإعادة استخدامها لاحقاً، انسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن بيانات خاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة للكاميرا. البيانات الفعّالة التي تُعيدها الطريقة [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/) تحتوي على الخصائص النهائية للكاميرا لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/).

المثال البرمجي التالي يوضح كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لجهاز إضاءة**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لجهاز الإضاءة. البيانات الفعّالة التي تُعيدها الطريقة [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/) تحتوي على الخصائص النهائية لجهاز الإضاءة لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/).

المثال البرمجي التالي يوضح كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لتقويس الشكل**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لتقويس الشكل. البيانات الفعّالة التي تُعيدها الطريقة [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/) تحتوي على الخصائص النهائية لتقويس الوجه لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/).

المثال البرمجي التالي يوضح كيفية الحصول على الخصائص الفعّالة لتقويس الجزء العلوي من الشكل. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. البيانات الفعّالة التي تُعيدها الطريقة [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/geteffective/) تحتوي على خصائص تنسيق إطار النص.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مع إطار نص.

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

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. البيانات الفعّالة التي تُعيدها الطريقة [TextStyle.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textstyle/geteffective/) تحتوي على خصائص نمط النص.

المثال البرمجي التالي يوضح كيفية الحصول على خصائص نمط النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مع إطار نص.

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

## **الحصول على قيمة ارتفاع الخط الفعّالة**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الكود التالي كيف يتغير ارتفاع الخط الفعّال للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة في بنية العرض التقديمي.

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

## **الحصول على تنسيق التعبئة الفعّال لجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. البيانات الفعّالة التي تُعيدها كائنات التنسيق تحتوي على خصائص [FillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/). تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بأكمله.

وبالتالي، تُستخدم خصائص [CellFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellformat/) الفعّالة لرسم خلية الجدول. يوضح المثال البرمجي التالي كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/).

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

## **الأسئلة المتكررة**

**هل تُعيد `getEffective` لقطة ثابتة؟**

ليس دائمًا. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعّالة قد تُخزن داخليًا. قد يُعيد استدعاء `getEffective` لاحقًا إعادة حساب التنسيق وتحديث البيانات المخزنة، لذا لا ينبغي اعتبار الكائن الذي تم الحصول عليه مسبقًا كلقطة دائمة.

**متى يجب قراءة الخصائص الفعّالة مرة أخرى؟**

استدعِ `getEffective` مرة أخرى بعد تغيير التنسيق المحلي، أو أنماط الوالد، أو تنسيق التخطيط، أو تنسيق القالب الأساسي، أو الإعدادات الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويُعيد النتيجة الفعّالة الحالية.

**هل يؤثر تعديل أو إزالة شريحة تخطيط/قالب أساسي على الخصائص الفعّالة التي تم استرجاعها بالفعل؟**

نعم، لكن التغيير ينعكس في الاستدعاء التالي لـ `getEffective`. إذا تغير مصدر تنسيق الوالد أو أُزيل، قد تصبح البيانات الفعّالة المسترجعة مسبقًا قديمة. بمجرد استدعاء `getEffective` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير القيم النهائية للخطوط أو الألوان أو الأحجام أو القيم الأخرى.

**هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالة؟**

لا. تُظهر كائنات البيانات الفعّالة القيم المحسوبة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم تُحدد خاصية ما على مستوى الشكل ولا في التخطيط/القالب ولا في الإعدادات العامة؟**

يتم تحديد القيمة الفعّالة عبر آلية القيم الافتراضية، التي تشمل القيم الافتراضية لـ PowerPoint وAspose.Slides. تصبح القيمة التي تم حلها جزءًا من البيانات الفعّالة الحالية.

**من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدم الحجم أو نوع الخط؟**

ليس مباشرة. تُعيد البيانات الفعّالة القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية على مستوى الجزء، الفقرة، إطار النص، وأنماط النص في التخطيط، القالب، ومستوى العرض التقديمي لمعرفة أول تعريف صريح يظهر.

**لماذا تبدو القيم الفعّالة أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية انتهت بها المطاف إلى أن تكون النهائية (لم تُستدعِ وراثة مستوى أعلى). في هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟**

استخدم البيانات الفعّالة عندما تحتاج إلى النتيجة "كما تم عرضها" بعد تطبيق جميع مستويات الوراثة، مثل محاذاة الألوان أو الهوامش أو الأحجام. إذا أردت الحفاظ على هذه القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائن خاص بك. إذا كنت تحتاج لتغيير التنسيق على مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالة مرة أخرى للتحقق من النتيجة.