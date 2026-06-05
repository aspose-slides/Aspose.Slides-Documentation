---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية في PHP
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/php-java/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز إضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيف يقوم Aspose.Slides لـ PHP عبر Java بحساب وتطبيق الخصائص الفعّالة للشكل لتوفير عرض PowerPoint دقيق."
---
## **نظرة عامة**

هذه الفقرة تشرح الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء في شريحة.
1. أنماط نص الشكل النموذجي في تخطيط أو شريحة رئيسية، عندما يكون شكل إطار النص للجزء موجودًا.
1. إعدادات النص العامة في عرض تقديمي.

يمكن تعريف القيم المحلية أو حذفها في أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يُعرض"، فإنها تحل سلسلة الوراثة وتُرجع القيم **الفعّالة**. يمكنك الحصول عليها باستدعاء طريقة `getEffective` على كائن التنسيق المحلي.

يوضح المثال التالي كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

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
تمثل بيانات التنسيق الفعّالة التنسيق المُحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة التي تُرجعها طرق مثل [PortionFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/geteffective/) مؤقتًا داخل الذاكرة. يمكن أن يؤدي استدعاء `getEffective` مرةً أخرى بعد تعديل التنسيق الأب أو الوراثي إلى تحديث البيانات المخزنة، وقد لا يمثل الكائن الذي حصلت عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى حفظ القيم الفعّالة لاستخدامها لاحقًا، انسخ الخصائص المطلوبة مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

يسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة للكاميرا. البيانات الفعّالة التي تُرجعها [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/) تحتوي على الخصائص النهائية للكاميرا لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/).

يعرض نموذج الشيفرة التالي كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لجهاز الإضاءة**

يسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة لجهاز الإضاءة. البيانات الفعّالة التي تُرجعها [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/) تحتوي على الخصائص النهائية لجهاز الإضاءة لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/).

يعرض نموذج الشيفرة التالي كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لحافة الشكل**

يسمح لك Aspose.Slides بالحصول على الخصائص الفعّالة لحافة الشكل. البيانات الفعّالة التي تُرجعها [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/geteffective/) تحتوي على الخصائص النهائية للنقش الوجهى لـ [ThreeDFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/threedformat/).

يعرض نموذج الشيفرة التالي كيفية الحصول على الخصائص الفعّالة لحافة الشكل العلوية. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. البيانات الفعّالة التي تُرجعها [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/geteffective/) تحتوي على خصائص تنسيق إطار النص.

يعرض نموذج الشيفرة التالي كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) يحتوي على إطار نص.

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

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. البيانات الفعّالة التي تُرجعها [TextStyle.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textstyle/geteffective/) تحتوي على خصائص نمط النص.

يعرض نموذج الشيفرة التالي كيفية الحصول على خصائص نمط النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) يحتوي على إطار نص.

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

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الشيفرة التالية كيف يتغيّر ارتفاع الخط الفعّالي للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي.

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

## **الحصول على تنسيق التعبئة الفعّال للجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. البيانات الفعّالة التي تُرجعها كائنات التنسيق تحتوي على خصائص [FillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/). تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بأكمله.

نتيجةً لذلك، تُستخدم خصائص [CellFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cellformat/) الفعّالة لرسم خلية الجدول. يعرض نموذج الشيفرة التالي كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/).

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

ليس دائمًا. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعّالة قد تُخزن مؤقتًا داخليًا. قد يُعيد استدعاء `getEffective` لاحقًا حساب التنسيق وتحديث البيانات المخزنة، لذا لا ينبغي التعامل مع الكائن المستخلص مسبقًا كلقطة دائمة.

**متى يجب قراءة الخصائص الفعّالة مرةً أخرى؟**

استدعِ `getEffective` مرةً أخرى بعد تعديل التنسيق المحلي، أو أنماط الأب، أو تنسيق التخطيط، أو تنسيق القاعدة، أو القيم الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويُرجع النتيجة الفعّالة الحالية.

**هل يؤثر تعديل أو حذف شريحة تخطيط/قائمة رئيسية على الخصائص الفعّالة التي تم جلبها مسبقًا؟**

نعم، لكن التغيير ينعكس في الاستدعاء التالي لـ `getEffective`. إذا تم تعديل أو حذف مصدر تنسيق أب، قد تكون البيانات الفعّالة المستخرجة مسبقًا قديمة. بمجرد استدعاء `getEffective` مرةً أخرى، تُعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغيّر الخطوط، الألوان، الأحجام أو القيم الأخرى.

**هل يمكن تعديل القيم عبر كائنات البيانات الفعّالة؟**

لا. تُظهر كائنات البيانات الفعّالة القيم المحسوبة فقط. يُجرى التعديل في كائنات التنسيق المحلي، ثم يُستخرج القيم الفعّالة مرةً أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل ولا في التخطيط/القائمة ولا في الإعدادات العامة؟**

يُحدَّد القيمة الفعّالة عبر الآلية الافتراضية التي تشمل إعدادات PowerPoint و Aspose.Slides. تصبح القيمة المُستنتجة جزءًا من البيانات الفعّالة الحالية.

**من قيمة الخط الفعّالية، هل يمكن معرفة المستوى الذي وفّر الحجم أو الخط؟**

ليس مباشرة. تُعيد البيانات الفعّالة القيمة النهائية. لاكتشاف المصدر، تحقق من القيم المحلية على مستوى الجزء، الفقرة، إطار النص، وأنماط النص في التخطيط، القاعدة، ومستوى العرض التقديمي لتحديد أول تعريف صريح.

**لماذا تبدو القيم الفعّالية أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية كانت النهائية (لم يُستدعَ مستوى أعلى للوراثة). في هذه الحالة، تتطابق القيمة الفعّالة مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟**

استخدم البيانات الفعّالة عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق كل الوراثات، مثل محاذاة الألوان أو المسافات أو الأحجام. إذا أردت حفظ هذه القيم بغض النظر عن تغيّر التنسيق لاحقًا، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت تريد تعديل التنسيق على مستوى معين، غيّر الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالة مرةً أخرى للتحقق من النتيجة.