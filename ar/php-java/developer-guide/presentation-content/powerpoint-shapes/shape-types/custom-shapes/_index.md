---
title: تخصيص أشكال العرض التقديمي في PHP
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/php-java/custom-shape/
keywords:
- شكل مخصص
- إضافة شكل
- إنشاء شكل
- تغيير شكل
- هندسة الشكل
- مسار الهندسة
- نقاط المسار
- نقاط تحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ PHP عبر Java: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العرض التقديمي في Aspose.Slides عن طريق تحرير هندسة الشكل من خلال نقاط التحرير ومسارات الهندسة. توضح كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير أساسية للمسار، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة مرة أخرى على الشكل.

كما توضح كيفية إنشاء أشكال مخصصة ومركبة، وبناء أشكال ذات زوايا منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة، وفحص عناصر الشكل، وتحويل خطوط مخططات نص Java AWT إلى مسارات هندسية.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* ضبط الانحناء عند نقطة.
* إضافة نقاط جديدة.

تسمح لك نقاط التحرير بتعديل حدود الشكل أو استخدام شكل موجود كأساس للحصول على شكل جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة المفاهيم التالية:

* يمكن أن يكون الشكل (أو مساره) مغلقًا أو مفتوحًا.
* يتكوّن مسار الشكل من نقاط ربط متصلة بقطاعات.
* يمكن أن تكون القطعة مستقيمة أو منحنية. تحدد نقاط الربط ومقابض التحكم شكلها.
* توجد نقاط الربط كزاوين، أو نقاط مستقيمة، أو نقاط ناعمة:
  * في نقطة الزاوية، يمكن للقطاعات المتجاورة أن تلتقي بزاوية.
  * في النقطة الناعمة، تكون مقبضا التحكم محاذيين وبعيدين مسافة متساوية عن نقطة الربط.
  * في النقطة المستقيمة، تكون مقبضا التحكم محاذيين لكن قد تكون المسافة عنهما مختلفة.
* تحريك نقاط الربط أو تعديل مقابضها يغيّر حدود الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* تمثّل نسخة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) مسار هندسي لكائن [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* لاسترجاع [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) من نسخة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)، يمكنك استخدام طريقة [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) لشكل، يمكنك استخدام الطريقتين: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) للأشكال ذات المسار الواحد و[GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) للأشكال ذات المسارات المتعددة.
* لإضافة قطاعات، يمكنك استخدام الطرائق المتوفرة تحت [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* باستخدام طريقتي [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) و[GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode)، يمكنك ضبط مظهر مسار الهندسة.
* باستخدام طريقة [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData)، يمكنك استرجاع مسار الهندسة لكائن [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) كمصفوفة من قطاعات المسار.
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك قراءة كائن [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) عبر [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) وإعادة تشغيل القطاعات على [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **عمليات تحرير بسيطة**

استخدم الطرق التالية لتحرير مسار هندسي. التحميلات التي تقبل فهرسًا تُدرج قطاعًا في الموضع الصفري‑المستند إلى الفهرس داخل مصفوفة قطاعات المسار.

| عملية | طريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| إلحاق أو إدراج منحنى بيزيه مكعب مع نقطتي تحكم ونقطة نهائية. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| إلحاق أو إدراج منحنى بيزيه تربيعي مع نقطة تحكم واحدة ونقطة نهائية. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| إلحاق قوس بيضاوي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| إغلاق الشكل الحالي بربط نقطته النهائية بنقطة البداية. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| تعيين نقطة البداية لشكل. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| إزالة قطاع عند فهرس صفري‑مستند إلى الفهرس. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **إضافة نقاط مخصصة إلى الشكل**

تُدرج هذه العينة نقطتين في شكل مستطيل باستخدام [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) وتطبيق المسار المعدل عبر [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). الإحداثيات محلية إلى الشكل: النقطتان الجديدتان في مركزه، 100 نقطة من اليسار و50 نقطة من الأعلى. تُوضع مؤشرات القطاعات 1 و4 على الحافتين العلوية والسفلية، مما يجذب هاتين الحافتين إلى الداخل.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **إزالة نقاط من الشكل**

تُغيّر هذه العينة مخطط القلب بإزالة القطاع عند الفهرس الصفري‑مستند إلى الفهرس 2 باستخدام [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). تطبيق المسار المعدل عبر [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) يُحدّث محيط الشكل.

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **إنشاء شكل مخصص**

تبني هذه العينة نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). تُعرّف الأنصاف القطرية المتناوبة للعينتين الخارجية والداخلية بـ 100 و50 نقطة لتحديد القمم والانحناءات؛ خطوة 72 درجة تُوزّع الخمس قمم بالتساوي. يُغلق المسار عبر [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) ويُطبق على شكل مستطيل باستخدام [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)، مستبدلًا مخططه.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **إنشاء شكل مدمج مخصص**

تحدّد هذه العينة كائنين [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) مغلقين للثلثين العلوي والسفلي من الشكل. يُنشئ تطبيق كلا المسارين عبر [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) شكلاً مركبًا واحدًا به فجوة عبر الثلث الأوسط.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

تمزج هذه العينة القطاعات المستقيمة مع [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) لإنشاء شكل بزوايا منحنية إلى الداخل. تحدد كل زاوية حجم القوس بالعرض والارتفاع بالنقاط، وتُرسم القطعة ذات القوس –90 درجة قوسًا إهليلجيًا ربعًا باتجاه عكس عقارب الساعة. يُطبق المسار المكتمل عبر [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)، وتُحفظ العرض التقديمي بصيغة PPTX.

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحقق مما إذا كانت هندسة الشكل مغلقة**

تتحقق الدالة المساعدة التالية ما إذا كان كل مسار هندسي غير فارغ ينتهي بقطاع إغلاق. تقرأ [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) وتقارن أمر القطاع النهائي عبر [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) مع [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). تُعيد false عندما لا توجد مسارات غير فارغة. تتحقق هذه الدالة من الأمر النهائي لكل مسار؛ لا تقوم بفحص كل شكل فرعي داخل المسار. تطبع العينة `true` لمستطيل.

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **استخراج وفحص عناصر الشكل**

استخدم [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. استخدم كل [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) مُرجع لاسترجاع مصفوفات النقاط والأنواع عبر طريقتي [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) و[getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). يُعدّ هذا التمثيل مفيدًا لتحليل الحدود أو لتمرير الهندسة إلى أدوات رسم مخصصة.

تفتح العينة ملف input.pptx، وتجد أول شكل هندسي مباشرة على الشريحة الأولى، وتطبع قطاعات مساره. استخدم عرضًا يحتوي على شكل بقطاعات مستقيمة ومنحنية لتُظهر كلا النوعين من الإخراج. لا تبحث داخل المجموعات.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // احتفظ بنوع القطعة، مع استبعاد العلامات.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // Consume both control points and the endpoint.
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

المصفوفات تتطابق بحسب الفهرس: `$points[$i]` هو نقطة و`$types[$i]` يصف دورها. النوع `0` يبدأ الشكل، والنوع `1` يرسم خطًا من النقطة السابقة إلى النقطة الحالية. يبدأ قطاع بيزيه مكعب من النقطة النهائية السابقة ويستخدم ثلاث إدخالات من النوع `3` متتالية: نقطتا تحكم ثم النقطة النهائية الجديدة. يستهلك الحلقة هذه الثلاث إدخالات معًا ويفحص النقطة النهائية للإغلاق.

تحتوي أنواع النقاط أيضًا على أعلام. قُم بالـ mask بـ `0x07` لتحديد نوع القطاع، واختبر `0x80` منفصلًا لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تُغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزيه تُغلق واحدًا. تُعيد جسر PHP/Java المصفوفة البايتية كسلسلة ثنائية؛ فكّها باستخدام `"C*"` لتنتج قيم بايت غير موقّعة. يحافظ الـ masking على القيم البتية المقصودة. مقارنة القيمة الخام فقط بـ `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى، مثل الواصل (`0x10`) والعلامة (`0x20`)، لا تغير نوع القطاع الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقاط (1/72 بوصة)، مع زيادة X إلى اليمين وزيادة Y إلى الأسفل. بالنسبة لشكل غير مجمع، تضم الإحداثيات المستخرجة بالفعل الموضع الذي تُرجعه [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) و[getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) وتعكس عرضه وارتفاعه الحالي. على سبيل المثال، مستطيل غير مدوَّر عند `(100, 200)` بالحجم `120 × 80` له حدود محيط `(100, 200)`–`(220, 280)`. لا تُضيف موضع الشكل مرة أخرى. اطرح قيم X وY للحصول على إحداثيات نسبية لإطار الشكل غير المدوَّر.

لا تطبق الإحداثيات المستخرجة دوران الشكل، الذي تُرجعه [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation)، أو الانعكاسات الأفقية والعمودية. لتكرار المخطط المعروض، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسب أيضًا تحويلات وإسقاطات إحداثيات المجموعة؛ لا تفترض أن الإحداثيات المستخرجة هي إحداثيات الشريحة النهائية أو تُطبق ترجمة أو مقياسًا مرتين إذا كان مُعكسًا بالفعل في إطار الطفل.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة المحيط؛ تعديلها لا يُحدّث الشكل الأصلي. اختر هذا الأسلوب عندما تحتاج إلى مصفوفات نقطة/نوع لتحليل أو رسمك. استخدم [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) عندما تحتاج إلى أوامر هندسية في نظام إحداثيات الشكل المحلي أو ترغب في تحرير هندسته. طبّق المسارات المعدلة عبر [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) أو [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **تحويل شكل Java AWT إلى GeometryPath**

تجمع هذه العينة مخططًا مستطیلیًا مع نص محوَّل إلى هندسة. تُعطّل طريقة [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) ملء المخطط. تُنشئ فئة [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) مخطط النص في كائن [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). يوفّر [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) تحركات، خطوط، منحنيات تربيعية، مكعبة، وقطاعات إغلاق، والتي يُعيد تنفيذها على [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

تستخدم العينة مصفوفة عائمة Java حتى يحتفظ جسر PHP/Java بالإحداثيات التي كتبها المتiter. يستخدم النص خطًا Arial بحجم 40 نقطة. يُزاح المخطط أفقياً 20 نقطة ويُوضَع بحيث أعلىه البصري 10 نقاط أسفل حافة أعلى الشكل. يُملأ مسار النص، بينما يبقى المستطيل الأصلي مخططًا فقط. يدمج تطبيق كلا المسارين عبر [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) شكلًا واحدًا يحتوي على المستطيل والنص.

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **الأسئلة المتكررة**

**ماذا سيحدث للملء والحدّ بعد استبدال الهندسة؟**

يبقى النمط مع الشكل؛ يتغيّر فقط المخطط. يُطبّق الملء والحدّ تلقائيًا على الهندسة الجديدة.

**كيف يمكنني تدوير شكل مخصص مع هندسته بشكل صحيح؟**

استخدم طريقة [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) الخاصة بالشكل؛ تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر منطقة [slide](/slides/ar/php-java/convert-powerpoint-to-png/) المطلوبة أو الـ [shape](/slides/ar/php-java/create-shape-thumbnails/) نفسها إلى صيغة نقطية؛ يُبسّط هذا العمل اللاحق مع الهندسات المعقّدة.