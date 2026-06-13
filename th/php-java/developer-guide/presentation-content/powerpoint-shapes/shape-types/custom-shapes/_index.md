---
title: ปรับแต่งรูปร่างงานนำเสนอใน PHP
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
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างผสม"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งรูปร่างการนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต รวมถึงวิธีใช้ `GeometryPath` เพื่อแก้ไขรูปร่างที่มีอยู่, ทำการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือลบจุด, และนำเรขาคณิตที่อัปเดตกลับไปใช้กับรูปร่าง

บทความยังแสดงวิธีสร้างรูปร่างแบบกำหนดเองและแบบผสม, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่, และแปลงระหว่าง `GeometryPath` กับ `java.awt.Shape` เพื่อใช้ในสถานการณ์การปรับแต่งเรขาคณิตเพิ่มเติม

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**
ให้พิจารณาสี่เหลี่ยมจัตุรัส ใน PowerPoint คุณสามารถใช้ **จุดแก้ไข** เพื่อ

* ย้ายมุมของสี่เหลี่ยมเข้าไปหรือออกไป
* กำหนดความโค้งของมุมหรือจุด
* เพิ่มจุดใหม่ให้กับสี่เหลี่ยม
* จัดการกับจุดบนสี่เหลี่ยม ฯลฯ

โดยสรุป คุณสามารถทำงานที่อธิบายไว้กับรูปร่างใดก็ได้ การใช้จุดแก้ไขทำให้คุณสามารถเปลี่ยนรูปร่างหรือสร้างรูปร่างใหม่จากรูปร่างที่มีอยู่ได้

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

ก่อนที่คุณจะเริ่มแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข ควรพิจารณาจุดต่อไปนี้เกี่ยวกับรูปร่าง:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เมื่อรูปร่างเป็นแบบปิด จะไม่มีจุดเริ่มต้นหรือจุดสิ้นสุด ส่วนเมือเป็นแบบเปิด จะมีจุดเริ่มต้นและจุดสิ้นสุด
* รูปร่างทั้งหมดประกอบด้วยจุดยึดอย่างน้อย 2 จุดที่เชื่อมต่อกันด้วยเส้น
* เส้นสามารถเป็นเส้นตรงหรือโค้ง จุดยึดกำหนดลักษณะของเส้น
* จุดยึดมีอยู่เป็นจุดมุม, จุดตรง, หรือจุดเรียบ:
  * จุดมุมคือจุดที่เส้นตรงสองเส้นมาบรรจบกันที่มุม
  * จุดเรียบคือจุดที่มีแฮนด์สองตัวอยู่บนเส้นตรงและส่วนของเส้นเชื่อมต่อกันเป็นโค้งเรียบ ในกรณีนี้ แฮนด์ทั้งหมดจะห่างจากจุดยึดเท่าๆ กัน
  * จุดตรงคือจุดที่มีแฮนด์สองตัวอยู่บนเส้นตรงและส่วนของเส้นนั้นเชื่อมต่อกันเป็นโค้งเรียบ ในกรณีนี้ แฮนด์ไม่จำเป็นต้องห่างจากจุดยึดเท่าๆ กัน
* โดยการย้ายหรือแก้ไขจุดยึด (ซึ่งจะเปลี่ยนมุมของเส้น) คุณสามารถเปลี่ยนรูปลักษณ์ของรูปร่างได้

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข **Aspose.Slides** ให้บริการคลาส [**GeometryPath**](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryPath)

* อินสแตนซ์ของ[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryPath) แทนเส้นทางเรขาคณิตของอ็อบเจกต์[GeometryShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometryshape/) .
* เพื่อดึง`GeometryPath`จากอินสแตนซ์`GeometryShape`คุณสามารถใช้เมธอด[GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometryshape/#getGeometryPaths).
* เพื่อกำหนด`GeometryPath`ให้กับรูปร่าง คุณสามารถใช้เมธอดเหล่านี้: [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometryshape/#setGeometryPath) สำหรับ *solid shapes* และ [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometryshape/#setGeometryPaths) สำหรับ *composite shapes*.
* เพื่อเพิ่มเซกเมนต์ คุณสามารถใช้เมธอดภายใต้[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometrypath/).
* ด้วยเมธอด[GeometryPath::setStroke](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometrypath/setstroke/) และ [GeometryPath::setFillMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometrypath/setfillmode/) คุณสามารถตั้งค่าการแสดงผลของเส้นทางเรขาคณิตได้
* ด้วยเมธอด[GeometryPath::getPathData](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometrypath/getpathdata/) คุณสามารถดึงข้อมูลเส้นทางของ`GeometryShape`เป็นอาร์เรย์ของเซกเมนต์เส้นทาง
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตของรูปร่างเพิ่มเติม คุณสามารถแปลง[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometrypath/)เป็น[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* ใช้เมธอด[geometryPathToGraphicsPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) และ[graphicsPathToGeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) (จากคลาส[ShapeUtil](https://reference.aspose.com/slides/th/php-java/aspose.slides/ShapeUtil)) เพื่อแปลง[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometrypath/)เป็น[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) ไปกลับ

## **การดำเนินการแก้ไขอย่างง่าย**

โค้ด PHP นี้แสดงวิธี

**เพิ่มเส้น** to the end of a path

```php

```
**เพิ่มเส้น** to a specified position on a path:

```php

```
**เพิ่มเส้นโค้งคิวบิกเบเซียร์** at the end of a path:

```php

```
**เพิ่มเส้นโค้งคิวบิกเบเซียร์** to the specified position on a path:

```php

```
**เพิ่มเส้นโค้งควอดราติกเบเซียร์** at the end of a path:

```php

```
**เพิ่มเส้นโค้งควอดราติกเบเซียร์** to a specified position on a path:

```php

```
**ต่อส่วนโค้งที่กำหนด** to a path:

```php

```
**ปิดรูปทรงปัจจุบัน** of a path:

```php

```
**ตั้งค่าตำแหน่งสำหรับจุดถัดไป**:

```php

```
**ลบส่วนของเส้นทาง** at a given index:

```php

```

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**
1. สร้างอินสแตนซ์ของคลาส[GeometryShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryShape)และตั้งค่าประเภท[ShapeType::Rectangle](https://reference.aspose.com/slides/th/php-java/aspose.slides/ShapeType).
2. ดึงอินสแตนซ์ของคลาส[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryPath)จากรูปร่าง
3. เพิ่มจุดใหม่ระหว่างสองจุดบนสุดของเส้นทาง
4. เพิ่มจุดใหม่ระหว่างสองจุดล่างของเส้นทาง
5. นำเส้นทางไปใช้กับรูปร่าง

โค้ด PHP นี้แสดงวิธีเพิ่มจุดกำหนดเองให้กับรูปร่าง:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **ลบจุดจากรูปร่าง**

1. สร้างอินสแตนซ์ของคลาส[GeometryShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryShape)และตั้งค่าประเภท[ShapeType::Heart](https://reference.aspose.com/slides/th/php-java/aspose.slides/ShapeType).
2. ดึงอินสแตนซ์ของคลาส[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryPath)จากรูปร่าง
3. ลบเซกเมนต์ของเส้นทาง
4. นำเส้นทางไปใช้กับรูปร่าง

โค้ด PHP นี้แสดงวิธีลบจุดจากรูปร่าง:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

## **สร้างรูปร่างกำหนดเอง**

1. คำนวณจุดสำหรับรูปร่าง
2. สร้างอินสแตนซ์ของคลาส[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryPath)
3. เติมเส้นทางด้วยจุดต่างๆ
4. สร้างอินสแตนซ์ของคลาส[GeometryShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryShape)
5. นำเส้นทางไปใช้กับรูปร่าง

โค้ด Java นี้แสดงวิธีสร้างรูปร่างกำหนดเอง:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **สร้างรูปร่างผสมกำหนดเอง**

  1. สร้างอินสแตนซ์ของคลาส[GeometryShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryShape)
  2. สร้างอินสแตนซ์แรกของคลาส[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryPath)
  3. สร้างอินสแตนซ์ที่สองของคลาส[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryPath)
  4. นำเส้นทางไปใช้กับรูปร่าง

โค้ด PHP นี้แสดงวิธีสร้างรูปร่างผสมกำหนดเอง:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **สร้างรูปร่างกำหนดเองที่มีมุมโค้ง**

โค้ด PHP นี้แสดงวิธีสร้างรูปร่างกำหนดเองที่มีมุมโค้ง (ด้านใน):

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

รูปร่างแบบปิดหมายถึงรูปร่างที่ทุกด้านเชื่อมต่อกันเป็นเส้นรอบเดียวโดยไม่มีช่องว่าง รูปร่างนี้อาจเป็นรูปทรงเรขาคณิตง่ายหรือรูปร่างกำหนดเองที่ซับซ้อน ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **แปลง GeometryPath เป็น java.awt.Shape**

1. สร้างอินสแตนซ์ของคลาส[GeometryShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryShape)
2. สร้างอินสแตนซ์ของคลาส[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
3. แปลงอินสแตนซ์[java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)เป็นอินสแตนซ์[GeometryPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/GeometryPath)โดยใช้[ShapeUtil](https://reference.aspose.com/slides/th/php-java/aspose.slides/ShapeUtil)
4. นำเส้นทางไปใช้กับรูปร่าง

โค้ด PHP นี้—เป็นการนำขั้นตอนข้างต้นมาปฏิบัติ—แสดงกระบวนการแปลง **GeometryPath** ไปเป็น **GraphicsPath**:

```php
  $pres = new Presentation();
  try {
    # สร้างรูปร่างใหม่
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # ดึงเส้นทางเรขาคณิตของรูปร่าง
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # สร้าง graphics path ใหม่ด้วยข้อความ
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # แปลง graphics path เป็น geometry path
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # ตั้งค่าการรวมกันของ geometry path ใหม่และ geometry path ต้นฉบับให้กับรูปร่าง
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **FAQ**

**อะไรจะเกิดขึ้นกับสีเติมและเส้นขอบหลังจากเปลี่ยนเรขาคณิต?**

สไตล์จะคงอยู่กับรูปร่าง; เพียงแค่พิมรษะเปลี่ยนไป สีเติมและเส้นขอบจะถูกนำไปใช้กับเรขาคณิตใหม่โดยอัตโนมัติ

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตได้อย่างถูกต้องอย่างไร?**

ใช้เมธอด[shape::setRotation](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/setrotation/)ของรูปร่าง; เรขาคณิตจะหมุนตามรูปร่างเนื่องจากถูกผูกไว้กับระบบพิกัดของรูปร่างเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ “ล็อค” ผลลัพธ์ได้หรือไม่?**

ได้. สามารถส่งออก[slide](/slides/th/php-java/convert-powerpoint-to-png/) หรือ[shape](/slides/th/php-java/create-shape-thumbnails/) ที่ต้องการเป็นรูปแบบเรสเตอร์; วิธีนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนเป็นเรื่องง่ายกว่า