---
title: "تخصيص أشكال العروض التقديمية في PHP"
linktitle: "شكل مخصص"
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
- نقاط التحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تحرير هندسة الشكل من خلال نقاط التحرير ومسارات الهندسة. تُظهر كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير مسار أساسية، وإضافة أو إزالة نقاط، وتطبيق الهندسة المحدثة مرة أخرى على الشكل.

كما تظهر كيفية إنشاء أشكال مخصصة ومركبة، وبناء أشكال بزوايا منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة، وفحص عناصر الشكل، وتحويل مخططات نص Java AWT إلى مسارات هندسية.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك زاوية إلى الداخل أو الخارج.
* تعديل الانحناء عند نقطة.
* إضافة نقاط جديدة.

تسمح لك تحرير النقاط بتعديل مخطط الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![overview_image](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة المفاهيم التالية:

* يمكن أن يكون الشكل (أو مساره) إما مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ارتكاز متصلة بمقاطع.
* يمكن أن يكون المقطع مستقيمًا أو منحنيًا. تحدد نقاط الارتكاز ومقابض التحكم شكله.
* توجد نقاط الارتكاز كنقاط زاوية، أو نقاط مستقيمة، أو نقاط سلسة:
  * في نقطة زاوية، يمكن للمقاطع المتاخمة أن تلتقي بزاوية.
  * في نقطة سلسة، يكون مقبضان التحكم متوازيين ويبعدان مسافة متساوية عن نقطة الارتكاز.
  * في نقطة مستقيمة، يكون مقبضان التحكم متوازيين ولكن قد يكونان على مسافات مختلفة عن نقطة الارتكاز.
* تحريك نقاط الارتكاز أو تعديل مقابضها يغير مخطط الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

* تمثل نسخة من [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) مسار هندسي لكائن [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/).
* لاسترداد [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) من نسخة [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) يمكنك استخدام طريقة [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) للأشكال ذات مسار واحد و[GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) للأشكال ذات مسارات متعددة.
* لإضافة مقاطع، يمكنك استخدام الطرق الموجودة تحت [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).
* باستخدام طرق [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) و[GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode)، يمكنك تعيين مظهر لمسار هندسي.
* باستخدام طريقة [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData)، يمكنك استرجاع مسار الهندسة لشكل [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) كمصفوفة من مقاطع المسار.
* للوصول إلى خيارات تخصيص هندسة الشكل الإضافية، يمكنك قراءة [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) عبر [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) وإعادة تشغيل المقاطع على [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

## **عمليات التحرير البسيطة**

استخدم الطرق التالية لتحرير مسار هندسي. التحميلات التي تقبل فهرسًا تُدرج مقطعًا في ذلك الموضع الصفري القائم في مصفوفة مقاطع المسار.

| العملية | الطريقة |
| --- | --- |
| إضافة أو إدراج خط مستقيم. | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| إضافة أو إدراج منحنى بيزييه مكعب بنقطتي تحكم ونقطة النهاية. | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| إضافة أو إدراج منحنى بيزييه تربيعي بنقطة تحكم واحدة ونقطة النهاية. | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| إضافة قوس بيضاوي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| إغلاق الشكل الحالي بربط نقطة النهاية بنقطة البداية. | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| تعيين نقطة البداية للشكل. | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| إزالة مقطع عند فهرس يبدأ من الصفر. | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **إضافة نقاط مخصصة إلى شكل**

هذا المثال يُدرج نقطتين في شكل مستطيل باستخدام [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) ويُطبق المسار المُعدَّل باستخدام [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath). الإحداثيات محلية إلى الشكل: النقطتان الجديدتان تقعان في مركزه، على مسافة 100 نقطة من اليسار و50 نقطة من الأعلى. تُضع مؤشرات المقاطع 1 و4 النقطتين على الحافتين العلوية والسفلية، مما يسحب هاتين الحافتين إلى الداخل.

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

## **إزالة نقاط من شكل**

هذا المثال يغيّر مخطط شكل على شكل قلب عبر إزالة المقطع عند الفهرس الصفري 2 باستخدام [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt). تطبيق المسار المعدَّل باستخدام [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) يُحدِّث محيط الشكل.

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

هذا المثال يبني نجمة خماسية باستخدام [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/). تُعرِّف نصفا القطر المتناوبين الخارجي والداخلي بـ 100 و50 نقطة لتحديد الحواف والفراغات؛ خطوة 72 درجة تُوزِّع الخمس رؤوس بانتظام. يُغلق المسار باستخدام [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) ويُطبق على شكل مستطيل باستخدام [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)، مستبدلًا مخططه.

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

## **إنشاء شكل مخصص مركب**

هذا المثال يُعرِّف مسارين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) للثلث العلوي والسفلي من الشكل. تطبيق كلا المسارين باستخدام [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) يُنشئ شكلًا مركبًا واحدًا به فجوة عبر الثلث الأوسط.

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

هذا المثال يجمع مقاطع مستقيمة مع [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) لإنشاء شكل بزوايا منحنية إلى الداخل. يحدد حجم كل زاوية عرض وارتفاع القوس بالنقاط، وتُرسم القطعة القوسية بزاوية –90 درجة لتشكيل ربع إهليلجي عكس اتجاه عقارب الساعة. يُطبق المسار المكتمل باستخدام [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)، ويتم حفظ العرض التقديمي بصيغة PPTX.

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

## **معرفة ما إذا كانت هندسة الشكل مغلقة**

المساعد التالي يتحقق مما إذا كان كل مسار هندسي غير فارغ ينتهي بمقطع إغلاق. يقرأ [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) ويقارن أمر المقطع النهائي [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) مع [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/). يُعيد false عندما لا تكون هناك مسارات غير فارغة. هذا يتحقق من الأمر النهائي لكل مسار؛ ولا يفحص كل شكل فرعي داخل المسار. المثال يُطبع `true` لمستطيل.

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

## **فحص أوامر مسار الهندسة**

حمّل [contour.pptx](contour.pptx) وضعه في دليل عمل التطبيق. الشكل الأول في الشريحة الأولى يحتوي على حافة علوية مستقيمة، ومنحنٍ بيزييه مكعب، وحافة إغلاق مستقيمة. استخدم [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) لقراءة مسارات الشكل و[ getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) لقراءة مقاطع كل مسار بترتيب الرسم. لكل مقطع، يحدد [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) الأمر ويُحدد كيفية تفسير القيم التي تُعيدها [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData).

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

الشكل يقع عند (200, 100) نقطة على الشريحة. الإحداثيات المبلَّغ عنها محلية إلى الشكل، بحيث يكون (0, 0) في الزاوية العليا اليسرى، وتزداد القيمة X إلى اليمين وتزداد القيمة Y إلى الأسفل. يُعيد المقطع الإغلاق إلى نقطة البداية دون إحداثيات إضافية.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **استخراج وفحص عناصر الشكل**

استخدم [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) لفحص شكل موجود كعناصر تحتوي على نقاط المسار وأنواع النقاط. استخدم كل [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) مسترجعة للحصول على مصفوفات النقاط والأنواع عبر طُرُق [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) و[getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes). هذا التمثيل مفيد لتحليل المخطط أو لتمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال input.pptx، يجد الشكل الهندسي الأول مباشرةً على الشريحة الأولى، ويطبع مقاطع مساره. استخدم عرضًا يحتوي على شكل به مقاطع مستقيمة ومنحنية لرؤية كلا النوعين من النتائج. لا يبحث داخل المجموعات.

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
                $pointType = $types[$i] & 0x07; // احتفظ بنوع المقطع، مع استثناء العلامات.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // استهلك نقطتي التحكم والنقطة النهائية.
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

المصفوفات تتطابق وفق الفهرس: `$points[$i]` هي نقطة و`$types[$i]` تصف دورها. النوع `0` يبدأ شكلًا، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ مقطع بيزييه مكعب عند نقطة النهاية السابقة ويستخدم ثلاث مدخلات من النوع `3` متتالية: نقطتا تحكم ثم نقطة النهاية الجديدة. الحلقة تستهلك هذه الثلاث مدخلات معًا وتتحقق من إغلاق نقطة النهاية.

أنواع النقاط تحتوي أيضًا على أعلام. استخدم القناع `0x07` لتحديد نوع المقطع، واختبر `0x80` بشكل منفصل لاكتشاف مسار فرعي مغلق. مثال ذلك، `129` (`0x81`) يعني نقطة نهاية خط تغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزييه تغلق واحدًا. يُعيد جسر PHP/Java مصفوفة البايت كسلسلة ثنائية؛ فكّها باستخدام `"C*"` يُنتج قيم بايت غير موقعة. القناع يحافظ على قيم البت المقصودة. مقارنة القيمة الخام فقط مع `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى، مثل الفاصل (`0x10`) والعلامة (`0x20`)، لا تغير نوع المقطع الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقاط (1/72 بوصة)، وتزداد X إلى اليمين وتزداد Y إلى الأسفل. بالنسبة لشكل غير مجموعة، تشمل الإحداثيات المستخرجة بالفعل الموضع المسترجع من [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) و[getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) وتعكس عرضه وارتفاعه الحاليين. على سبيل المثال، مستطيل غير مُدوَّر عند `(100, 200)` بحجم `120 × 80` له حدود مخطط `(100, 200)`–`(220, 280)`. لا تُضيف موضع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطار الشكل غير المُدوَّر.

النقاط المستخرجة لا تُطبق دوران الشكل المسترجع من [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) أو الانعكاسات الأفقية والعمودية. لإعادة إنتاج المخطط المعروض، طبّق هذه التحويلات حول مركز الشكل. بالنسبة للأشكال المجمَّعة، احسب أيضًا تحويلات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشريحة النهائية ولا تطبق ترجمة أو مقياسًا مرتين إذا كان مُعكسًا بالفعل في إطار الطفل.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة المخطط؛ تعديلها لا يُحدِّث الشكل الأصلي. اختر هذا النهج عندما تحتاج إلى مصفوفات نقطة/نوع لتحليل أو رسمك. استخدم [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) عندما تحتاج إلى أوامر هندسة في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبّق المسارات المُعدَّلة عبر [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) أو [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths).

## **تحويل شكل Java AWT إلى GeometryPath**

هذا المثال يجمع مخططًا مستطيليًا مع نص مُحوَّل إلى هندسة. تُعطِّل طريقة [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) للخط الخارجي ملئه. يُنشئ [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) مخطط النص في [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). يزوِّد [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) بحركات، خطوط، منحنيات تربيعية، مكعبة، ومقاطع إغلاق، والتي يعيد المثال تشغيلها على [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/).

يستخدم المثال مصفوفة عائمة Java بحيث يحتفظ جسر PHP/Java بالإحداثيات التي كتبها المُتِر. النص يستخدم خط Arial بحجم 40 نقطة. يُزيَّح المخطط أفقيًا 20 نقطة ويوضع بأعلى بصرية 10 نقاط تحت الحافة العليا للشكل. يُملأ مسار النص، بينما يبقى المستطيل الأصلي مخططًا فقط. تطبيق كلا المسارين باستخدام [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) ينتج شكلًا واحدًا يحتوي على المستطيل والنص.

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

## **FAQ**

**ماذا سيحدث للملء والمخطط بعد استبدال الهندسة؟**

يستمر النمط مع الشكل؛ يتغيَّر المخطط فقط. يتم تطبيق الملء والمخطط تلقائيًا على الهندسة الجديدة.

**كيف أقوم بتدوير شكل مخصص بشكل صحيح مع هندسته؟**

استخدم طريقة الشكل [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation)؛ الهندسة تدور مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل شكل مخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدِّر الـ[slide](/slides/ar/php-java/convert-powerpoint-to-png/) المطلوب أو الـ[shape](/slides/ar/php-java/create-shape-thumbnails/) نفسه إلى صيغة نقطية؛ فهذا يُبسِّط العمل اللاحق مع الهندسات المعقدة.