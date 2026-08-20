---
title: إدارة أشكال العرض التقديمي في PHP
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/php-java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- البحث عن شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- انعكاس الشكل
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية التعرف على أشكال العرض التقديمي، استنساخها، إزالتها، إخفائها، إعادة ترتيبها، تصديرها، محاذاةها، وانعكاسها باستخدام Aspose.Slides for PHP عبر Java."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java تمثّل الأشكال على الشريحة كـ [ShapeCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/) مُرتّبة. تُعدّ هذه المجموعة المكان الذي تجد فيه وتُعدّل الأشكال ومصدر ترتيب طبقاتها: الفهرس `0` هو الشكل الأبعد في الخلفية، بينما الفهرس الأخير هو الشكل الأقرب إلى الأمام.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية التعرف على الشكل بشكل موثوق، ثم يوضّح كيفية استنساخ الشكل، حذفه، إخفائه وإعادة ترتيبه. تغطي الأقسام الأخيرة تنسيق المستوى التخطيطي، تصدير SVG، المحاذاة وإعدادات الانعكاس. كل مثال مستقل، بحيث يمكنك استخدام العملية التي يحتاجها سير العمل الخاص بك فقط.

## **التعرّف على الأشكال وإيجادها**

تُعتبر فهارس المجموعة مريحة عند معالجة ملف معروف، لكنها ليست معرّفات ثابتة. قد يغيّر إضافة أو حذف أو إعادة ترتيب شكل فهرسته. اختر معرّفًا وفقًا لطريقة إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getname/) مفيد للقوالب التي يتحكم فيها المطورون وسهل فحصه في لوحة التحديد في PowerPoint. يمكن تعديل الأسماء ولا يُضمن أنها فريدة، لذا يُستحسن وضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getalternativetext/) مفيد عندما تكون وصفية الوصول أو وسماً يحدده المؤلف قد عرّفت الشكل بالفعل. هو مرئي للمستخدمين، قد يُترجم أو يُعاد صياغته لسهولة الوصول، ولا يُضمن أنه فريد. لا تُعيد استعمال نص وصول ذي معنى كمعرّف قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getofficeinteropshapeid/) هو معرّف للقراءة فقط فريد داخل الشريحة ويتCorrespond إلى معرف الشكل المستخدم في PowerPoint interop. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا لبس فيه طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يُعطى معرّفًا مختلفًا.

طريقة [Shape::getUniqueId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getuniqueid/) ذات الصلة تُعيد معرفًا بنطاق العرض التقديمي، لكن هذا المعرف مخصص للإضافات ويمكن إعادة تعيينه. لا ينبغي اعتباره مفتاحًا خارجيًا دائمًا. إذا كانت هوية طويلة الأمد ضرورية، احتفظ بعملية الربط في بيانات التطبيق وتأكد من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن الاسم بمقارنة مطابقة ويُبلغ عن معرف interop بنطاق الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلًا من المتابعة مع الكائن الخطأ.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

عند كون العملية خاصة بنوع شكل معين، افحص الفئة في وقت التشغيل قبل استخدام الأعضاء الخاصة بالنوع. يُحدّث هذا المثال النص والنص البديل فقط إذا كان الكائن المُسمى من نوع [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **تعديل مجموعة الأشكال**

تُنفّذ طرق الإضافة، الاستنساخ، الحذف وإعادة الترتيب على المجموعة فورًا. إذا غيّرت عملية ما عدد أو ترتيب الأشكال، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addclone/) ينشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة المستهدفة. [ShapeCollection::insertClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/insertclone/) أيضًا ينشئ نسخة لكنه يضعها عند فهرس z-order محدد. تُعيد التحميلات التي تقبل إحداثيات نقل النسخة دون تغيير حجمها؛ والتحميلات التي تضم العرض والارتفاع يمكنها تغيير الحجم كذلك.

المثال ينشئ شريحة هدف، يستنسخ مستطيلًا مسمى إلى الأمام، ويُدرج استنساخًا ثانٍ إلى الخلف. لا تُغيّر التعديلات على أي من النسختين الشكل الأصلي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون هذه القيم فريدة. الموارد المستخدمة بواسطة الأشكال المعقّدة تُدار بواسطة العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة بمعرف شكل جديد.

### **إزالة الأشكال**

[ShapeCollection::remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند إزالة متعددة متطابقة أثناء تكرار مُرقم، انتقل من النهاية لضمان بقاء كل فهرس متبقٍ صالحًا.

هذا المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي، وليس عنصرًا ثابتًا في المجموعة، ولا يقوم بتحويل الشكل بلا ضرورة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تُعَدّ المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الموصلات، الحركات وغيرها من ميزات العرض التي قد تشير إلى الكائن المُزالة؛ حذف شكل مرئي يمكن أن يغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

ضبط [Shape::setHidden](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/sethidden/) إلى `true` يبقي الشكل في المجموعة لكن يمنعه من الظهور في عرض الشرائح العادي. يبقى فهرسه، تنسيقه ومحتواه متاحًا للكود، لذا فإن الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهاره مرة أخرى، ويظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z-Order**

الأشكال المتداخلة تُرسم بحسب ترتيب المجموعة. [ShapeCollection::reorder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `size() - 1` هو الأمام.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يُنشأ المستطيل أولًا ويقَع في البداية خلف الشكل البيضاوي. نقلّه إلى الفهرس النهائي يجعله في الأمام. احرص على ضبط ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن هذه العمليات تُضيف أو تُدرج عناصر جديدة في المجموعة وقد تُغيّر الترتيب المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، وشُرائح التخطيط، وشرائح القالب لها مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس هو نفسه الشكل المتموضع بالمثل على شريحة عادية. فحص أشكال التخطيط ضروري عندما تحتاج إلى فهم أو تعديل التنسيق المزوّد من قبل التخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getfillformat/) و[LineFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getlineformat/) للأشكال في التخطيط دون افتراض أن كل شكل هو `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

تحرير التخطيط قد يؤثّر على عدة شرائح تستخدمه. قبل تعديل شكل التخطيط، حدّد ما إذا كانت الشريحة العادية ترث الكائن أو تحتوي على تعديل محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/writeassvg/) يكتب محتوى شكل واحد مُرَسَم إلى تدفق. النتيجة تحتوي على الشكل فقط، لا خلفية الشريحة بأكملها أو الأشكال المجاورة.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

حافظ على فتح العرض التقديمي أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى المكوّن الكامل، صدّر الشريحة بدلاً من الشكل الفردي. المالك هو من يُحمّل التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

تُطابق التحميلات [SlideUtil::alignShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideutil/alignshapes/) إما جميع الأشكال أو فهارس المجموعة المختارة. يحدّد [ShapesAlignmentType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapesalignmenttype/) الحافة أو الخط المركزي أو وضعية التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ واضبطه إلى `false` لمحاذاة الأشكال المحددة بالنسبة لبعضها البعض.

هذا المثال يَمحِّز ثلاثة أشكال إلى الحافة العليا للشريحة. تُحوّل مراجع الأشكال المرجعة إلى فهارسها الحالية مباشرة قبل المحاذاة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المحاذاة تُغيّر المواقع، لا ترتيب Z. عادةً ما تتطلب المحاذاة النسبية شكلين على الأقل، بينما تحتاج التوزيعات الأفقية أو العمودية إلى عدد كافٍ من الأشكال لتحديد المسافات. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **انعكاس شكل**

تخزن فئة [ShapeFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapeframe/) الموقع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيم `getFlipH` و`getFlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/php-java/aspose.slides/nullablebool/): `True` يفعّل الانعكاس، `False` يوقفه، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مقلوب.

![The shape before flipping](shape_to_be_flipped.png)

المثال يحافظ على كل قيم الإطار الأخرى ويستبدل إعدادات الانعكاس فقط. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/setframe/) جديد يستبدل الإطار بالكامل.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الشكل المحفوظ مُنعكس أفقياً وعمودياً مع الحفاظ على موقعه وحجمه ودورانه.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**هل يجب استخدام فهرس المجموعة كمعرّف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يُفضَّل اعتماد `Name` أو `AlternativeText` حسب اتفاقية القالب، أو `OfficeInteropShapeId` للأعمال التي تعتمد على interop بنطاق الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يُضيف النسخة إلى نهاية المجموعة، وهي أمامية في ترتيب Z. استخدم `insertClone` لاختيار الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.