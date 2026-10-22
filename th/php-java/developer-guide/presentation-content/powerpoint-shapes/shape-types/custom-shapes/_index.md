---
title: ปรับแต่งรูปทรงการนำเสนอใน PHP
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/php-java/custom-shape/
keywords:
- รูปทรงกำหนดเอง
- เพิ่มรูปทรง
- สร้างรูปทรง
- เปลี่ยนรูปทรง
- เรขาคณิตรูปทรง
- เส้นทางเรขาคณิต
- จุดเส้นทาง
- แก้ไขจุด
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างเชิงผสม."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปร่างของงานนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต แสดงวิธีการใช้ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่ ทำการแก้ไขเส้นทางพื้นฐาน เพิ่มหรือลบจุด และนำเรขาคณิตที่อัปเดตกลับไปยังรูปร่าง

นอกจากนี้ยังสาธิตวิธีการสร้างรูปร่างแบบกำหนดเองและแบบผสม สร้างรูปร่างที่มีมุมโค้ง ตรวจสอบว่ารูปร่างมีเรขาคณิตปิดหรือไม่ ตรวจสอบส่วนประกอบของรูปร่าง และแปลงเค้าโครงข้อความ Java AWT ให้เป็นเส้นทางเรขาคณิต

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

* ย้ายมุมเข้าด้านในหรือออกไปด้านนอก
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดช่วยให้คุณปรับเปลี่ยนโครงร่างของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นพื้นฐานสำหรับรูปร่างใหม่

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปร่างใน PowerPoint ให้คำนึงถึงแนวคิดต่อไปนี้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อกันด้วยเซกเมนต์
* เซกเมนต์อาจเป็นเส้นตรงหรือโค้ง จุดยึดและตัวจับควบคุมกำหนดรูปร่างของมัน
* จุดยึดมีรูปแบบเป็นจุดมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม เซกเมนต์ที่ต่อกันสามารถพบกันที่มุม
  * ที่จุดเรียบ ตัวจับควบคุมสองตัวจะอยู่ในแนวเดียวกันและห่างจากจุดยึดเท่ากัน
  * ที่จุดตรง ตัวจับควบคุมสองตัวอยู่ในแนวเดียวกันแต่สามารถอยู่ห่างจากจุดยึดต่างกัน
* การย้ายจุดยึดหรือปรับตัวจับของมันจะเปลี่ยนโครงร่างของรูปร่าง

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ให้ใช้

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) แทนเส้นทางเรขาคณิตของอ็อบเจกต์ [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) คุณสามารถใช้เมธอด [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths)
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ให้กับรูปร่าง คุณสามารถใช้เมธอดเหล่านี้: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) สำหรับรูปร่างที่มีเส้นทางเดียวและ [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มเซกเมนต์ คุณสามารถใช้เมธอดภายใต้ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)
* ด้วยเมธอด [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) และ [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต
* ด้วยเมธอด [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) เป็นอาร์เรย์ของเซกเมนต์เส้นทาง
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตของรูปร่างเพิ่มเติม คุณสามารถอ่าน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ผ่าน [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) แล้วทำซ้ำเซกเมนต์บน [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การโอเวอร์โหลดที่รับดัชนีจะใส่เซกเมนต์ที่ตำแหน่งนั้นในอาร์เรย์เซกเมนต์ของเส้นทาง

| การดำเนินการ | เมธอด |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบคิวบิกที่มีจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบควอดราติกที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| เพิ่มส่วนโค้งวงรีด้วยขนาดและมุมที่ระบุเป็นองศา | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| ปิดรูปภาพปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| กำหนดจุดเริ่มต้นของรูปภาพ | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| ลบเซกเมนต์ที่ตำแหน่งดัชนีเริ่มจากศูนย์ | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**

ตัวอย่างนี้แทรกสองจุดลงในรูปร่างสี่เหลี่ยมผืนผ้าโดยใช้ [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) และนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) พิกัดทั้งหมดเป็นพิกัดท้องถิ่นของรูปร่าง: ทั้งสองจุดใหม่อยู่ที่ศูนย์กลางของรูปร่าง ห่างจากด้านซ้าย 100 จุดและจากด้านบน 50 จุด ดัชนีเซกเมนต์ 1 และ 4 ทำให้จุดเหล่านั้นอยู่บนขอบบนและขอบล่าง ลากขอบเหล่านั้นเข้าด้านใน

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

## **ลบจุดจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยลบเซกเมนต์ที่ตำแหน่งดัชนีเริ่มจากศูนย์ 2 ด้วย [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) การนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) จะอัปเดตขอบของรูปร่าง

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

## **สร้างรูปร่างกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) รัศมีนอกและในสลับกันที่ 100 และ 50 จุดกำหนดจุดยอดและส่วนเว้า; ขั้นตอน 72 องศาจะเว้นระยะเท่ากันให้ดาวห้าแฉกเส้นทางจะปิดโดยใช้ [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) แล้วนำไปใช้กับรูปร่างสี่เหลี่ยมผืนผ้าด้วย [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) แทนที่โครงร่างเดิม

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

## **สร้างรูปร่างกำหนดเองแบบรวม**

ตัวอย่างนี้กำหนดสองอ็อบเจกต์ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ปิดสำหรับส่วนบนและส่วนล่างของรูปหนึ่ง การนำสองเส้นทางไปใช้พร้อมกันด้วย [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างผสมเดียวที่มีช่องว่างครอบครึ่งกลางของรูป

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

## **สร้างรูปร่างกำหนดเองที่มุมโค้ง**

ตัวอย่างนี้ผสมเซกเมนต์ตรงกับ [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) เพื่อสร้างรูปร่างที่มุมโค้งเข้าด้านใน แต่ละขนาดมุมกำหนดความกว้างและความสูงของส่วนโค้งเป็นหน่วยจุด และการสวีป -90 องศาจะวาดส่วนโค้งวงรีไตรมาสหนึ่งแบบทวนเข็มนาฬิกา เส้นทางที่เสร็จสมบูรณ์จะนำไปใช้ด้วย [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) แล้วบันทึกงานนำเสนอในรูปแบบ PPTX

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

## **ตรวจสอบว่ารูปร่างมีเรขาคณิตปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่าจบด้วยเซกเมนต์ปิดหรือไม่ มันจะอ่าน [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) แล้วเปรียบเทียบคำสั่งของเซกเมนต์สุดท้ายโดยใช้ [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) กับ [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) จะคืนค่า false เมื่อไม่มีเส้นทางที่ไม่ว่างเปล่า การตรวจสอบนี้มองคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบทุกรูปย่อยภายในเส้นทาง ตัวอย่างพิมพ์ค่า `true` สำหรับสี่เหลี่ยมผืนผ้า

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

## **ดึงและตรวจสอบส่วนประกอบของรูปร่าง**

ใช้เมธอด [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) เพื่อดูรูปร่างที่มีอยู่เป็นส่วนประกอบที่บรรจุตำแหน่งจุดเส้นทางและประเภทจุด ใช้แต่ละ [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) ที่คืนค่าเพื่อดึงอาร์เรย์จุดและอาร์เรย์ประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) และ [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) การแสดงผลนี้มีประโยชน์สำหรับการวิเคราะห์โครงร่างหรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง

ตัวอย่างเปิดไฟล์ input.pptx, ค้นหารูปร่างเรขาคณิตแรกบนสไลด์แรก และพิมพ์เซกเมนต์เส้นทางของมัน ใช้งานนำเสนอที่มีรูปร่างที่มีเซกเมนต์ตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท ไม่ได้ค้นหาภายในกลุ่ม

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
                $pointType = $types[$i] & 0x07; // เก็บประเภทเซกเมนต์, ไม่รวมแฟล็ก.
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

อาร์เรย์สอดคล้องกันตามดัชนี: `$points[$i]` คือจุดและ `$types[$i]` บรรยายบทบาทของมัน ประเภท `0` เริ่มรูปภาพ, ประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน เซกเมนต์ Bézier แบบคิวบิกเริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` ต่อเนื่องสามรายการ: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่ ลูปจะรับสามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดเพื่อดูว่าปิดหรือไม่

ประเภทจุดยังมีแฟล็กด้วย การทำแมสก์ด้วย `0x07` เพื่อระบุประเภทเซกเมนต์ และทดสอบ `0x80` อย่างแยกกันเพื่อตรวจจับเส้นทางย่อยที่ปิด ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดปลายเส้นที่ปิดเส้นทางย่อย, `131` (`0x83`) หมายถึงจุดปลาย Bézier ที่ปิดเส้นทาง การเชื่อมต่อ PHP/Java Bridge จะคืนค่าอาร์เรย์ไบต์เป็นสตริงไบนารี; การแตกข้อมูลด้วย `"C*"` จะสร้างค่าไบต์ไม่มีเครื่องหมายบวก การทำแมสก์จะคงค่าบิตที่ตั้งใจไว้ การเปรียบเทียบค่าดิบเพียง `1` หรือ `3` จะพลาดกรณีเหล่านี้ แฟล็กอื่น ๆ เช่น เส้นประ (`0x10`) หรือเครื่องหมาย (`0x20`) จะไม่เปลี่ยนประเภทเซกเมนต์พื้นฐาน

**พิกัดและการแปลง** จุดวัดเป็นจุด (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงด้านล่าง สำหรับรูปร่างที่ไม่ได้อยู่ในกลุ่ม พิกัดที่ดึงออกมาจะรวมตำแหน่งที่คืนจาก [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) และ [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) อยู่แล้วและสะท้อนความกว้างและความสูงปัจจุบันของมัน ตัวอย่าง สี่เหลี่ยมที่ไม่ได้หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบโครงร่าง `(100, 200)`–`(220, 280)` ไม่ต้องเพิ่มตำแหน่งของรูปร่างอีกครั้ง ให้ลบค่า X และ Y เพื่อนำพิกัดให้เป็นสัมพัทธ์ต่อกรอบที่ยังไม่หมุน

พิกัดที่ดึงออกมาจะไม่รวมการหมุนของรูปร่างที่คืนจาก [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) หรือการพลิกแนวนอนและแนวตั้ง เพื่อให้ได้โครงร่างที่แสดงผล ต้องนำการแปลงเหล่านั้นมาปรับรอบจุดศูนย์กลางของรูปร่าง สำหรับรูปร่างที่อยู่ในกลุ่ม ต้องคำนึงถึงการแมพพิกัดของกลุ่มและการแปลงด้วย; อย่าสมมติว่าพิกัดที่ดึงออกมาคือพิกัดสุดท้ายของสไลด์หรือทำการแปลงหรือสเกลซ้ำสองครั้งหากมันได้ถูกรวมไว้แล้วในกรอบลูก

**การตรวจสอบเทียบกับการแก้ไข** อาร์เรย์ที่ดึงออกมาจะอธิบายโครงร่างเท่านั้น; การเปลี่ยนแปลงอาร์เรย์เหล่านั้นจะไม่อัปเดตรูปร่างเดิม ให้ใช้วิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาร์เรย์จุด/ประเภท ใช้ [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปร่างหรืออยากแก้ไขเรขาคณิตนั้น ใช้การตั้งค่าเส้นทางที่แก้ไขผ่าน [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) หรือ [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)

## **แปลงรูปร่าง Java AWT เป็น GeometryPath**

ตัวอย่างนี้รวมโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต วิธี [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) ของโครงร่างจะปิดการเติมสี [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) สร้างเค้าโครงข้อความใน [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ตัว [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) จะให้เซกเมนต์การย้าย, เส้น, ควอดราติก, คิวบิกและการปิด ซึ่งตัวอย่างจะนำมาซ้ำบน [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)

ตัวอย่างใช้อาร์เรย์ float ของ Java เพื่อให้ PHP/Java Bridge เก็บพิกัดที่ iterator เขียนไว้ ข้อความใช้ฟอนต์ Arial ขนาด 40 จุด โครงร่างจะเลื่อนแนวนอน 20 จุดและวางตำแหน่งโดยให้ด้านบนของข้อความอยู่ 10 จุดต่ำกว่าแนวบนของรูปร่าง เส้นทางข้อความจะเติมสี ในขณะที่สี่เหลี่ยมเดิมยังคงเป็นโครงร่าง การนำทั้งสองเส้นทางไปใช้ด้วย [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างเดียวที่มีสี่เหลี่ยมและข้อความรวมกัน

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

## **คำถามที่พบบ่อย**

**อะไรจะเกิดขึ้นกับการเติมสีและเส้นขอบหลังจากเปลี่ยนเรขาคณิต?**

สไตล์จะยังคงอยู่กับรูปร่าง; เพียงแต่โครงร่างจะเปลี่ยน การเติมสีและเส้นขอบจะถูกประยุกต์อัตโนมัติบนเรขาคณิตใหม่

**ฉันจะทำการหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) ของรูปร่าง; เรขาคณิตจะหมุนตามรูปร่างเนื่องจากผูกกับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ "ล็อก" ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออก [สไลด์](/slides/th/php-java/convert-powerpoint-to-png/) ที่ต้องการหรือส่งออก [รูปร่าง](/slides/th/php-java/create-shape-thumbnails/) เองเป็นรูปแบบราสเตอร์; วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น