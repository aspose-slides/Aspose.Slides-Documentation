---
title: ปรับแต่งรูปร่างการนำเสนอใน PHP
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/php-java/custom-shape/
keywords:
- รูปร่างกำหนดเอง
- เพิ่มรูปร่าง
- สร้างรูปร่าง
- เปลี่ยนรูปร่าง
- เรขาคณิตของรูปร่าง
- เส้นทางเรขาคณิต
- จุดของเส้นทาง
- จุดแก้ไข
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างเชิงประกอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งรูปร่างการนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต จะบอกวิธีทำงานกับ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่, ปฏิบัติการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัพเดตกลับไปใช้กับรูปร่าง

นอกจากนี้ยังสาธิตวิธีสร้างรูปร่างแบบกำหนดเองและแบบรวม, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปร่างเรขาคณิตเป็นปิดหรือไม่, ตรวจสอบองค์ประกอบของรูปร่าง, และแปลงโครงร่างข้อความจาก Java AWT เป็นเส้นทางเรขาคณิต

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยม:

* ย้ายมุมเข้าหรือออกจากศูนย์กลาง
* ปรับความโค้งที่จุดใดจุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดช่วยให้คุณปรับเปลี่ยนโครงร่างของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นพื้นฐานสำหรับรูปร่างใหม่

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปร่างใน PowerPoint ให้จำแนวคิดต่อไปนี้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อด้วยเซกเมนต์
* เซกเมนต์อาจเป็นเส้นตรงหรือโค้ง จุดยึดและจุดควบคุมกำหนดรูปร่างของเซกเมนต์
* จุดยึดมีสามประเภท: จุดมุม, จุดตรง, หรือจุดเรียบ
  * ที่จุดมุม เซกเมนต์ที่ต่อกันสามารถเจอที่มุมได้
  * ที่จุดเรียบ จุดควบคุมสองจุดจะเรียงกันและอยู่ห่างจากจุดยึดเท่ากัน
  * ที่จุดตรง จุดควบคุมสองจุดจะเรียงกันแต่ระยะห่างจากจุดยึดอาจแตกต่างกัน
* การย้ายจุดยึดหรือปรับจุดควบคุมจะทำให้โครงร่างของรูปร่างเปลี่ยนไป

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) แสดงเส้นทางเรขาคณิตของอ็อบเจกต์ [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/), สามารถใช้เมธอด [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths)
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ให้กับรูปร่าง, สามารถใช้เมธอดเหล่านี้: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) สำหรับรูปร่างที่มีเส้นทางเดียว และ [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มเซกเมนต์, สามารถใช้เมธอดภายใต้ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)
* ด้วยเมธอด [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) และ [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต
* ด้วยเมธอด [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) เป็นอาร์เรย์ของเซกเมนต์เส้นทาง
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตของรูปร่างเพิ่มเติม, คุณสามารถอ่านอ็อบเจกต์ [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ผ่าน [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) แล้วทำการเล่นซ้ำเซกเมนต์บน [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)

## **การดำเนินการแก้ไขแบบง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การโอเวอร์โหลดที่รับดัชนีจะเพิ่มเซกเมนต์ในตำแหน่งที่เป็นศูนย์ฐานในอาร์เรย์เซกเมนต์ของเส้นทาง

| การดำเนินการ | เมธอด |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| เพิ่มหรือแทรกโค้ง Bézier แบบ cubic ที่มีจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| เพิ่มหรือแทรกโค้ง Bézier แบบ quadratic ที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| เพิ่มส่วนโค้งวงรีโดยกำหนดขนาดและมุมเป็นองศา | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| ปิดรูปแบบปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| ตั้งค่าจุดเริ่มต้นของรูปแบบ | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| ลบเซกเมนต์ที่ตำแหน่งดัชนีศูนย์ฐาน | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**

ตัวอย่างนี้ใส่จุดสองจุดลงในรูปร่างสี่เหลี่ยมโดยใช้ [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) และนำเส้นทางที่แก้ไขไปใช้กับ [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) พิกัดเป็นพิกัดท้องถิ่นของรูปร่าง: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลางของรูปร่าง, ห่างจากด้านซ้าย 100 จุดและจากด้านบน 50 จุด ดัชนีเซกเมนต์ 1 และ 4 ทำให้จุดเหล่านั้นอยู่บนขอบบนและขอบล่าง, ดึงขอบเหล่านั้นเข้าหากัน

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

## **ลบจุดออกจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยลบเซกเมนต์ที่ตำแหน่งดัชนีศูนย์ฐาน 2 ด้วย [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) การนำเส้นทางที่แก้ไขไปใช้ด้วย [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) จะอัพเดตคอนทัวร์ของรูปร่าง

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

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) รัศมีนอกและรัศมีในสลับกันที่ 100 และ 50 จุดกำหนดปลายและรอยบอด; การก้าว 72 องศาให้ดาวห้าจุดกระจายอย่างสม่ำเสมอ เส้นทางถูกปิดด้วย [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) แล้วนำไปใช้กับรูปร่างสี่เหลี่ยมโดยใช้ [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) แทนโครงร่างเดิม

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

## **สร้างรูปร่างกำหนดเองเชิงประกอบ**

ตัวอย่างนี้กำหนดสองอ็อบเจกต์ [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) ปิดสำหรับส่วนบนและส่วนล่างของรูปร่าง การนำทั้งสองเส้นทางไปใช้ด้วย [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) จะสร้างรูปร่างเชิงประกอบเดียวที่มีช่องว่างครึ่งกลางของรูปร่าง

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

## **สร้างรูปร่างกำหนดเองที่มีมุมโค้ง**

ตัวอย่างนี้รวมเซกเมนต์ตรงกับ [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) เพื่อสร้างรูปร่างที่มุมโค้งเข้าด้านใน แต่ละขนาดมุมกำหนดความกว้างและความสูงของส่วนโค้งเป็นจุด และการสวิง -90 องศาจะวาดส่วนสี่เหลี่ยมวงรีแบบทวนเข็มนาฬิกา เส้นทางที่สมบูรณ์จะถูกนำไปใช้ด้วย [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) และบันทึกงานนำเสนอเป็นรูปแบบ PPTX

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

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าเส้นทางเรขาคณิตที่ไม่ว่างทั้งหมดลงท้ายด้วยเซกเมนต์ปิดหรือไม่ มันอ่านค่า [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) แล้วเปรียบเทียบคำสั่งของเซกเมนต์สุดท้ายโดยใช้ [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) กับ [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) จะคืนค่า false หากไม่มีเส้นทางที่ไม่ว่าง ตัวตรวจสอบพิจารณาคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ตรวจสอบทุกรูปย่อยภายในเส้นทาง ตัวอย่างพิมพ์ `true` สำหรับสี่เหลี่ยม

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

## **ตรวจสอบคำสั่งของเส้นทางเรขาคณิต**

ดาวน์โหลดไฟล์ [contour.pptx](contour.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน รูปแรกบนสไลด์แรกมีขอบบนเป็นเส้นตรง, โค้ง Bézier แบบ cubic, และขอบปิดเป็นเส้นตรง ใช้เมธอด [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) เพื่ออ่านเส้นทางของรูปร่างและ [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) เพื่ออ่านเซกเมนต์ของแต่ละเส้นทางตามลำดับการวาด สำหรับแต่ละเซกเมนต์, เมธอด [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) จะบ่งบอกคำสั่งและกำหนดวิธีตีความค่าที่คืนจากเมธอด [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData)

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

รูปอยู่ที่ตำแหน่ง (200, 100) จุดบนสไลด์ พิกัดที่รายงานเป็นพิกัดท้องถิ่นของรูปโดยจุด (0, 0) อยู่ที่มุมซ้ายบน, X เพิ่มไปทางขวา, Y เพิ่มลงล่าง เซกเมนต์ปิดจะกลับสู่จุดเริ่มต้นโดยไม่มีพิกัดเพิ่มเติม

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **แยกและตรวจสอบองค์ประกอบของรูปร่าง**

ใช้เมธอด [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) เพื่อตรวจสอบรูปร่างที่มีอยู่เป็นองค์ประกอบที่บรรจุจุดเส้นทางและประเภทจุด ใช้แต่ละ [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) ที่คืนค่าเพื่อดึงอาร์เรย์จุดและอาร์เรย์ประเภทผ่านเมธอด [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) และ [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) การแสดงผลนี้มีประโยชน์สำหรับการวิเคราะห์คอนทัวร์หรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง

ตัวอย่างเปิดไฟล์ input.pptx, ค้นหารูปร่างเรขาคณิตแรกที่อยู่บนสไลด์แรกโดยตรง, แล้วพิมพ์เซกเมนต์ของเส้นทาง ใช้การนำเสนอที่มีรูปร่างที่มีเซกเมนต์ตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท ไม่ได้ค้นหาในกลุ่ม

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
                $pointType = $types[$i] & 0x07; // เก็บประเภทเซกเมนต์ไว้, ไม่รวมแฟล็ก.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // ใช้จุดควบคุมทั้งสองและจุดสุดท้าย.
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

อาร์เรย์สอดคล้องกันตามดัชนี: `$points[$i]` คือจุดและ `$types[$i]` บรรยายบทบาทของมัน ประเภท `0` เริ่มรูป, ประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน เซกเมนต์ Bézier แบบ cubic เริ่มจากจุดปลายของเซกเมนต์ก่อนหน้าและใช้รายการประเภท `3` สามรายการต่อเนื่อง: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่ ลูปจะรับรายการทั้งสามนี้พร้อมกันและตรวจสอบจุดสิ้นสุดว่าปิดหรือไม่

ประเภทจุดยังมีแฟล็กด้วย การมาสก์ด้วย `0x07` จะบ่งบอกประเภทเซกเมนต์, และการตรวจสอบ `0x80` แยกต่างหากเพื่อระบุเส้นทางย่อยที่ปิด ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดปลายของเส้นที่ปิดเส้นทางย่อย, `131` (`0x83`) หมายถึงจุดปลายของ Bézier ที่ปิดเส้นทางย่อย PHP/Java Bridge คืนอาร์เรย์ไบต์เป็นสตริงไบนารี; การแตกข้อมูลด้วย `"C*"` จะได้ค่าไบต์แบบไม่มีเครื่องหมาย การมาสก์จะคงค่าบิตที่ต้องการ การเปรียบเทียบนับค่าดิบเพียง `1` หรือ `3` จะพลาดกรณีเหล่านี้ แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทฐานของเซกเมนต์

**พิกัดและการแปลง** จุดวัดเป็นจุด (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงล่าง สำหรับรูปร่างที่ไม่ได้อยู่ในกลุ่ม, พิกัดที่ดึงออกมามีตำแหน่งที่ได้จากเมธอด [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) และ [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) รวมถึงความกว้างและความสูงปัจจุบันของมัน ตัวอย่างเช่น สี่เหลี่ยมที่ไม่มีการหมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` จะมีขอบคอนทัวร์ `(100, 200)`–`(220, 280)` อย่าบวกตำแหน่งรูปร่างอีกครั้ง ให้ลบค่า X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่ได้หมุน

ค่าที่ดึงออกมาจะไม่รวมการหมุนของรูปร่างที่ได้จากเมธอด [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) หรือการพลิกตามแนวนอนและแนวตั้ง เพื่อให้ได้คอนทัวร์ที่แสดงผล, ต้องนำการแปลงเหล่านี้มาประยุกต์รอบศูนย์กลางของรูปร่าง สำหรับรูปร่างที่อยู่ในกลุ่ม, ต้องคำนึงถึงการแมปพิกัดของกลุ่มและการแปลง; อย่าอนุมานว่าจุดที่ดึงออกมาคือพิกัดสุดท้ายบนสไลด์หรือทำการแปลงหรือสเกลซ้ำหากมันได้ถูกสะท้อนแล้วในกรอบของบุตร

**การตรวจสอบเทียบกับการแก้ไข** อาร์เรย์ที่ดึงออกมาบรรยายคอนทัวร์; การแก้ไขอาร์เรย์เหล่านี้จะไม่อัพเดตรูปร่างต้นฉบับ เลือกวิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาร์เรย์จุด/ประเภท ใช้เมธอด [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปร่างหรือต้องการแก้ไขเรขาคณิตของมัน ใช้การนำเส้นทางที่แก้ไขผ่าน [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) หรือ [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)

## **แปลง Java AWT Shape เป็น GeometryPath**

ตัวอย่างนี้รวมโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต วิธี [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) ปิดการเติมของโครงร่าง [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) สร้างโครงร่างข้อความในอ็อบเจกต์ [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) ตัว [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) ส่งเซกเมนต์ move, line, quadratic, cubic, และ closing ซึ่งตัวอย่างทำการเล่นซ้ำบน [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)

ตัวอย่างใช้อาร์เรย์ float ของ Java เพื่อให้ PHP/Java Bridge เก็บพิกัดที่ iterator เขียนไว้ ข้อความใช้ฟอนต์ Arial ขนาด 40 จุด โครงร่างเลื่อนแนวนอน 20 จุดและวางตำแหน่งโดยให้ด้านบนของข้อความอยู่ 10 จุดต่ำกว่าขอบบนของรูปร่าง เส้นทางข้อความถูกเติม ในขณะที่สี่เหลี่ยมเดิมยังคงเป็นโครงร่าง การนำทั้งสองเส้นทางไปใช้ด้วย [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) จะได้รูปร่างเดียวที่ประกอบด้วยสี่เหลี่ยมและข้อความ

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

**อะไรจะเกิดขึ้นกับสีพื้นและโครงร่างหลังจากแทนที่เรขาคณิต?**

สไตล์ยังคงอยู่กับรูปร่าง; เพียงคอนทัวร์เท่านั้นที่เปลี่ยน สีพื้นและโครงร่างจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องอย่างไร?**

ใช้เมธอด [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) ของรูปร่าง; เรขาคณิตจะหมุนพร้อมกับรูปร่างเนื่องจากผูกกับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ "ล็อก" ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออก [slide](/slides/th/php-java/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/php-java/create-shape-thumbnails/) เองเป็นรูปแบบแรสเตอร์; วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น