---
title: إدارة أشكال العرض التقديمي في PHP
linktitle: تعديل الشكل
type: docs
weight: 40
url: /ar/php-java/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- نص بديل للشكل
- نقطة ضبط الشكل
- ضبط الشكل المُعد مسبقًا
- هندسة الشكل
- صيغ تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- انعكاس الشكل
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية التعرف على أشكال العرض التقديمي وتعديلها واستنساخها وإزالتها وإخفائها وإعادة ترتيبها وتصديرها ومحاذاتها وعكسها باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يمثل الأشكال على الشريحة كـ [ShapeCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/) مرتب. المجموعة هي المكان الذي تجد فيه وتُعدل الأشكال ومصدر ترتيب تكدسها: الفهرس `0` هو الشكل الخلفي، بينما الفهرس الأخير هو الشكل الأمامي.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية تحديد الشكل بصورة موثوقة وتعديل نقاط ضبط الشكل المُعدة مسبقًا، ثم يوضح كيفية استنساخ، وإزالة، وإخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق مستوى التخطيط، وتصدير SVG، والمحاذاة، وإعدادات الانعكاس. كل مثال مستقل، بحيث يمكنك استخدام العمليات التي تحتاجها فقط في سير عملك.

## **تحديد وإيجاد الأشكال**

فهارس المجموعة مريحة أثناء معالجة ملف معروف، لكنها ليست معرّفات ثابتة. إضافة أو إزالة أو إعادة ترتيب شكل قد يغيّر فهرسه. اختر معرّفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getname/) مفيد للقوالب التي يتحكم فيها المطور ويسهل فحصه في لوحة الاختيار في PowerPoint. يمكن تعديل الأسماء ولا يضمن أنها فريدة، لذا ضع قاعدة تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getalternativetext/) مفيد عندما يكون وصف إمكانية الوصول أو علامة يحددها الكاتب قد حددت الشكل بالفعل. هو مرئي للمستخدمين، قد يُدار أو يُعاد صياغته لإمكانية الوصول، ولا يضمن أنه فريد. لا تُعيد استخدام نص إمكانية وصول ذو معنى كمفتاح قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getofficeinteropshapeid/) هو معرف للقراءة فقط فريد داخل الشريحة ويت对应 إلى معرف الشكل المستخدم في PowerPoint Interop. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى إشارة لا لبس فيها طوال عمر الشكل. الشكل المستنسخ أو المُعاد إنشاؤه هو شكل مختلف ويتلقى معرفًا خاصًا به.

طريقة [Shape::getUniqueId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getuniqueid/) المرتبطة تُرجع معرفًا بنطاق العرض التقديمي، لكن هذا المعرف مخصص للإضافات ويمكن إعادة تعيينه. لا ينبغي اعتباره مفتاحًا خارجيًا دائمًا. إذا كانت الهوية طويلة الأمد ضرورية، احتفظ بالتطابق في بيانات التطبيق وتحقّق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن الشكل بالاسم بمقارنة دقيقة ويُظهر معرف Interop نطاق الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُظهر الكود تلك النتيجة بدلاً من الاستمرار مع الكائن الخاطئ.

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

عند كون عملية ما محددة لنوع شكل معين، تحقق من فئة runtime قبل استخدام الأعضاء الخاصة بالنوع. يُحدّث هذا المثال النص والنص البديل فقط إذا كان الكائن المُسمّى هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/).

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

## **تحديد وتعديل ضبط الشكل المُعد مسبقًا**

الأشكال الهندسية المُعدة مسبقًا يمكن أن تكشف نقاط ضبط تتحكم في ميزات مثل حجم الزوايا، نسب السهم، أو زوايا القوس. يمكن الوصول إليها عبر مجموعة [GeometryShape::getAdjustments](https://reference.aspose.com/slides/ar/php-java/aspose.slides/geometryshape/#getAdjustments) للقراءة فقط. تُوفر الشكل المجموعة نفسها، لكن كل [AdjustValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/) يحتوي على قيمة يمكن تغييرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر الضبط وتفحص طريقة القراءة فقط [AdjustValue::getType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/#getType) التي تُعيد قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapeadjustmenttype/) توضح ما يتحكم فيه الضبط. طريقة القراءة فقط [AdjustValue::getName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/getname/) توفّر معلومات تعريف إضافية وتكون مفيدة خصوصًا عندما يحتوي الإعداد المسبق على أكثر من ضبط من نفس النوع الدلالي.

استخدم طريقة القيمة التي تتطابق مع معنى الضبط:

| نوع الضبط | الهدف | القيمة التي يجب تغييرها |
|---|---|---|
| `CornerSize` | حجم الزوايا الدائرية | [setRawValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | سمك ذيل السهم | `setRawValue` |
| `ArrowheadLength` | طول رأس السهم | `setRawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `setRawValue` |
| `StartAngle` | الزاوية الابتدائية لفطيرة أو قوس | [setAngleValue](https://reference.aspose.com/slides/ar/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | الزاوية النهائية لفطيرة أو قوس | `setAngleValue` |

`getType` و `getName` تُرجعان معلومات للقراءة فقط. `getRawValue` و `setRawValue` تعملان مع عدد صحيح بوحدات الهندسة الأصلية للإعداد، بينما `getAngleValue` و `setAngleValue` تعملان مع زاوية بالدرجات. عدد، ترتيب، معنى، والنطاق المسموح للضبط يعتمد على [GeometryShape::getShapeType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/geometryshape/#getShapeType) للإعداد. قد تكون قيمة صالحة لإعداد ما غير صالحة أو لها تأثير مختلف لإعداد آخر.

عندما تُرجع `getType` القيمة `ShapeAdjustmentType::Custom`، لا تتعرف الواجهة البرمجية على معنى دلالي قياسي. فحص `getName`، نوع الإعداد، والقيمة الحالية، واترك الضبط دون تغيير ما لم تعرف المعنى والنطاق المتوقعين. حتى للأنواع المعروفة، تحقق ما إذا كان نفس النوع يظهر أكثر من مرة قبل اختيار قيمة. تُظهر مقالة [Connector](/slides/ar/php-java/connector/) هذا الوضع مع ضبط انحناء الموصل.

المثال الكامل التالي يُنشئ إصدارات افتراضية ومُعدلة لثلاثة أشكال مُعدة مسبقًا. يكرّر عبر كل ضبط، يُظهر اسمه ونوعه، يغيّر القيم المتعلقة بالحجم عبر `setRawValue`، يغيّر الزوايا عبر `setAngleValue`، ويحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل الدائري المُعدل، السهم رباعي الاتجاهات، والفطيرة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة رؤوس لأعمدة الشكل الافتراضي والعمود المعدل.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

التفحص الدلالي للنوع قبل تغيير قيمة يجعل الكود واضحًا بشأن قصده ويتجنب افتراض أن فهرس مجموعة معين له نفس المعنى عبر أشكال مُعدة مسبقًا مختلفة.

## **تعديل مجموعة الأشكال**

طرق الإضافة، الاستنساخ، الإزالة، وإعادة الترتيب تعمل على المجموعة مباشرة. إذا غيّرت عملية ما عدد أو ترتيب الأشكال، لا تستمر بالاعتماد على الفهارس التي التُقطت قبل تلك العملية.

### **استنساخ شكل**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addclone/) يُنشئ نسخة مستقلة ويضيفها إلى مجموعة الوجهة. [ShapeCollection::insertClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/insertclone/) يُنشئ نسخة أيضًا لكنه يضعها عند فهرس z-order محدد. التحميلات التي تقبل إحداثيات تنقل الاستنساخ دون تغيير حجمه؛ التحميلات التي تقبل العرض والارتفاع يمكنها تغيير حجمه أيضًا.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلًا معنونًا إلى الأمام، ويُدرج استنساخًا ثانيًا إلى الخلف. التغييرات على أي استنساخ لا تُعدّل الشكل الأصلي.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرّفات منطقية جديدة للاستنساخ عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقدة تُدار بواسطة العرض التقديمي، لكن الاستنساخ يظل عنصرًا جديدًا في المجموعة بمعرف شكل جديد.

### **إزالة الأشكال**

[ShapeCollection::remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند إزالة مطابقة متعددة أثناء تكرار بالفهارس، عدّ من النهاية بحيث يظل كل فهرس متبقٍ صالحًا.

المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل عند الفهرس الحالي، وليس عنصر مجموعة ثابت، ولا يقوم بتحويل الشكل دون ضرورة.

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

بعد الإزالة، يتغير عدد الأشكال وفهارس الأشكال المتأخرة. المراجع إلى الأشكال غير المتأثرة تظل أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الموصلات، والرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ إزالة شكل مرئي قد تغير أكثر من مظهر الشريحة.

### **إخفاء شكل**

تعيين [Shape::setHidden](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/sethidden/) إلى `true` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في عرض الشرائح العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا يكون الإخفاء مناسبًا للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإلغاء إخفائه، وهو يظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم بترتيب المجموعة. [ShapeCollection::reorder](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `size() - 1` هو الأمام.

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

يُنشأ المستطيل أولاً ويقع في البداية خلف الشكل البيضاوي. نقله إلى الفهرس النهائي يضعه في المقدمة. أكّد ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدرج عناصر مجموعة جديدة وقد تُغيّر التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، شرائح التخطيط، والشرائح الرئيسية لها مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس نفس الكائن كما هو الشكل المماثل على شريحة عادية. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تعديل التنسيق المزوّد من قبل التخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getfillformat/) و [LineFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getlineformat/) لشكل التخطيط دون افتراض أن كل شكل هو `AutoShape`.

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

تحرير تخطيط يمكن أن يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل التخطيط، حدّد ما إذا كانت الشريحة العادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/writeassvg/) يكتب محتوى شكل مُرَسَم إلى تدفق. النتيجة تحتوي على الشكل فقط، لا خلفية الشريحة بالكامل ولا الأشكال المجاورة.

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

احتفظ بالعرض التقديمي مفتوحًا أثناء التصدير. يعتمد الناتج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت تحتاج إلى التركيبة الكاملة، صدّر الشريحة بدلاً من شكل منفرد. المتصل يمتلك التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

التحميلات [SlideUtil::alignShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideutil/alignshapes/) تُطابق إما جميع الأشكال أو الفهارس المحددة في المجموعة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapesalignmenttype/) يحدد الحافة، أو خط الوسط، أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المختارة بالنسبة لبعضها البعض.

المثال يطابق ثلاثة أشكال إلى الحافة العلوية للشريحة. تُحوَّل مراجع الأشكال المرجعة إلى فهارسها الحالية مباشرةً قبل المحاذاة.

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

المحاذاة تغيّر المواقع، لا ترتيب Z. المحاذاة النسبية عادةً تحتاج على الأقل إلى شكلين، بينما التوزيع الأفقي أو العمودي يحتاج إلى عدد كافٍ من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **انعكاس شكل**

الفئة [ShapeFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapeframe/) تخزن الموقع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيم `getFlipH` و `getFlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/php-java/aspose.slides/nullablebool/): `True` يُفعّل الانعكاس، `False` يُعطّل، و `NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير معكوس.

![الشكل قبل الانعكاس](shape_to_be_flipped.png)

المثال يحافظ على كل قيمة إطار أخرى ويستبدل إعدادات الانعكاس فقط. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/setframe/) جديد يستبدل الإطار بالكامل.

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

الشكل المُحفظ يصبح مرآة أفقياً وعمودياً مع الحفاظ على موقعه، حجمه، ودورانه.

![الشكل بعد الانعكاس](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يجب علي استخدام فهرس المجموعة كمعرّف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يفضَّل استخدام `Name` أو `AlternativeText` بعد التحقق من صحتها في القوالب المُنشأة، أو `OfficeInteropShapeId` لأعمال Interop بنطاق الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يظل الشكل المخفي في المجموعة بنفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`addClone` يضيف الاستنساخ إلى نهاية المجموعة، وهي الأمام في ترتيب Z. استخدم `insertClone` لتحديد الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل مُعد مسبقًا؟**

فقط بعد التحقق من الإعداد المسبق المحدد وتخطيط المجموعة. يفضَّل التكرار عبر `GeometryShape::getAdjustments` والتحقق من `AdjustValue::getType`؛ استخدم `AdjustValue::getName` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.