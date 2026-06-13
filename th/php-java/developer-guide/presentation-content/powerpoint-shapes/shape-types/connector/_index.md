---
title: จัดการตัวเชื่อมต่อในงานนำเสนอด้วย PHP
linktitle: ตัวเชื่อมต่อ
type: docs
weight: 10
url: /th/php-java/connector/
keywords:
- ตัวเชื่อมต่อ
- ประเภทตัวเชื่อมต่อ
- จุดตัวเชื่อมต่อ
- เส้นตัวเชื่อมต่อ
- มุมตัวเชื่อมต่อ
- เชื่อมต่อรูปร่าง
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่มพลังให้แอป PHP ในการวาด, เชื่อมต่อและกำหนดเส้นอัตโนมัติในสไลด์ PowerPoint — ควบคุมอย่างเต็มที่เหนือตัวเชื่อมต่อแบบตรง, แบบศอก และแบบโค้งมน."
---
## **บทนำ**

ตัวเชื่อมต่อ PowerPoint คือเส้นพิเศษที่เชื่อมหรือเชื่อมโยงรูปสองรูปเข้าด้วยกันและยังคงแนบอยู่กับรูปแม้จะถูกย้ายหรือจัดตำแหน่งใหม่บนสไลด์ที่กำหนด  

ตัวเชื่อมต่อมักเชื่อมต่อกับ *จุดเชื่อมต่อ* (จุดสีเขียว) ซึ่งมีอยู่บนรูปทั้งหมดโดยค่าเริ่มต้น จุดเชื่อมต่อจะปรากฏเมื่อเคอร์เซอร์เข้าใกล้

*จุดปรับตำแหน่ง* (จุดสีส้ม) มีอยู่เฉพาะบนตัวเชื่อมต่อบางประเภทและใช้ในการปรับตำแหน่งและรูปร่างของตัวเชื่อมต่อ

## **ประเภทของตัวเชื่อมต่อ**

ใน PowerPoint คุณสามารถใช้ตัวเชื่อมต่อตรง, ตัวเชื่อมต่อแบบโค้ง (มุม) และตัวเชื่อมต่อแบบโค้งมน  

Aspose.Slides มีตัวเชื่อมต่อเหล่านี้:

| ตัวเชื่อมต่อ | รูปภาพ | จำนวนจุดปรับตำแหน่ง |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **เชื่อมรูปด้วยตัวเชื่อมต่อ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/AutoShape) สองรายการลงในสไลด์โดยใช้เมธอด `addAutoShape` ของออปเจกต์ `Shapes`  
1. เพิ่มตัวเชื่อมต่อโดยใช้เมธอด `addConnector` ของออปเจกต์ `Shapes` พร้อมกำหนดประเภทของตัวเชื่อมต่อ  
1. เชื่อมรูปด้วยตัวเชื่อมต่อ  
1. เรียกเมธอด `reroute` เพื่อใช้เส้นเชื่อมที่สั้นที่สุด  
1. บันทึกงานนำเสนอ  

โค้ด PHP ด้านล่างแสดงวิธีเพิ่มตัวเชื่อมต่อ (ตัวเชื่อมต่อแบบโค้ง) ระหว่างรูปสองรูป (วงรีและสี่เหลี่ยม):

```php
// สร้างอินสแตนซ์ของคลาสงานนำเสนอที่แสดงไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงคอลเลกชันของรูปร่างสำหรับสไลด์เฉพาะ
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # เพิ่มรูปร่างอัตโนมัติแบบวงรี
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # เพิ่มรูปร่างอัตโนมัติแบบสี่เหลี่ยม
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # เพิ่มรูปร่างตัวเชื่อมต่อไปยังคอลเลกชันรูปร่างของสไลด์
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อมต่อ
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # เรียกใช้ reroute เพื่อกำหนดเส้นทางสั้นที่สุดอัตโนมัติระหว่างรูปร่าง
    $connector->reroute();
    # บันทึกงานนำเสนอ
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

เมธอด `Connector.reroute` จะทำการปรับเส้นเชื่อมใหม่และบังคับให้เส้นเชื่อมใช้เส้นทางที่สั้นที่สุดระหว่างรูปสองรูป เพื่อให้บรรลุเป้าหมาย เมธอดอาจทำการเปลี่ยนจุด `setStartShapeConnectionSiteIndex` และ `setEndShapeConnectionSiteIndex` 

{{% /alert %}} 

## **ระบุจุดเชื่อมต่อ**

หากต้องการให้ตัวเชื่อมต่อเชื่อมสองรูปโดยใช้จุดเฉพาะบนรูป คุณต้องกำหนดจุดเชื่อมต่อที่ต้องการตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/AutoShape) สองรายการลงในสไลด์โดยใช้เมธอด `addAutoShape` ของออปเจกต์ `Shapes`  
1. เพิ่มตัวเชื่อมต่อโดยใช้เมธอด `addConnector` ของออปเจกต์ `Shapes` พร้อมกำหนดประเภทของตัวเชื่อมต่อ  
1. เชื่อมรูปด้วยตัวเชื่อมต่อ  
1. ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูป  
1. บันทึกงานนำเสนอ  

โค้ด PHP ด้านล่างแสดงการกำหนดจุดเชื่อมต่อที่ต้องการ:

```php
  # สร้างอินสแตนซ์ของคลาสงานนำเสนอที่แสดงไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงคอลเลกชันของรูปร่างสำหรับสไลด์เฉพาะ
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # เพิ่มรูปร่างอัตโนมัติแบบวงรี
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # เพิ่มรูปร่างอัตโนมัติแบบสี่เหลี่ยม
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # เพิ่มรูปร่างตัวเชื่อมต่อไปยังคอลเลกชันรูปร่างของสไลด์
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อมต่อ
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # ตั้งค่าดัชนีจุดเชื่อมต่อที่ต้องการบนรูปร่างวงรี
    $wantedIndex = 6;
    # ตรวจสอบว่าดัชนีที่ต้องการน้อยกว่าจำนวนดัชนีไซต์สูงสุดหรือไม่
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูปร่างอัตโนมัติวงรี
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # บันทึกงานนำเสนอ
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ปรับจุดของตัวเชื่อมต่อ**

คุณสามารถปรับตัวเชื่อมต่อที่มีอยู่ผ่านจุดปรับตำแหน่งได้ เพียงตัวเชื่อมต่อที่มีจุดปรับตำแหน่งเท่านั้นที่สามารถเปลี่ยนแปลงได้ ดูตารางใน **[Types of connectors.](/slides/th/php-java/connector/#types-of-connectors)**

### **กรณีง่าย**

พิจารณากรณีที่ตัวเชื่อมต่อระหว่างรูปสองรูป (A และ B) ผ่านรูปที่สาม (C):

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

เพื่อหลีกเลี่ยงหรือข้ามรูปที่สาม เราสามารถปรับตัวเชื่อมต่อโดยย้ายเส้นแนวดิ่งไปทางซ้ายดังนี้:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **กรณีซับซ้อน** 

เมื่อต้องทำการปรับแต่งที่ซับซ้อน คุณต้องคำนึงถึงสิ่งต่อไปนี้:

* จุดปรับของตัวเชื่อมต่อเชื่อมโยงกับสูตรที่คำนวณและกำหนดตำแหน่งของมัน ดังนั้นการเปลี่ยนตำแหน่งของจุดอาจทำให้รูปร่างของตัวเชื่อมต่อเปลี่ยนไป  
* จุดปรับของตัวเชื่อมต่อถูกกำหนดเป็นลำดับที่เข้มงวดในอาเรย์โดยเรียงจากจุดเริ่มต้นไปจุดสิ้นสุดของตัวเชื่อมต่อ  
* ค่าแต่ละจุดปรับแสดงเป็นเปอร์เซ็นต์ของความกว้าง/ความสูงของรูปร่างตัวเชื่อมต่อ  
  * รูปร่างถูกจำกัดโดยจุดเริ่มต้นและจุดสิ้นสุดของตัวเชื่อมต่อคูณด้วย 1000  
  * จุดแรก, จุดสอง, และจุดสาม แสดงเปอร์เซ็นต์จากความกว้าง, ความสูง, และความกว้าง (อีกครั้ง) ตามลำดับ  
* สำหรับการคำนวณพิกัดของจุดปรับของตัวเชื่อมต่อ คุณต้องคำนึงถึงการหมุนและการสะท้อนของตัวเชื่อมต่อ **หมายเหตุ** ว่ามุมการหมุนของตัวเชื่อมต่อทั้งหมดที่แสดงใน **[Types of connectors](/slides/th/php-java/connector/#types-of-connectors)** คือ 0

#### **กรณี 1**

พิจารณากรณีที่อ็อบเจกต์กรอบข้อความสองอันเชื่อมต่อกันผ่านตัวเชื่อมต่อ:

![connector-shape-complex](connector-shape-complex.png)

```php
  # สร้างอินสแตนซ์ของคลาสงานนำเสนอที่แสดงไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรกในงานนำเสนอ
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่มรูปร่างที่จะเชื่อมต่อด้วยตัวเชื่อมต่อ
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # เพิ่มตัวเชื่อมต่อ
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # ระบุทิศทางของตัวเชื่อมต่อ
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # ระบุสีของตัวเชื่อมต่อ
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # ระบุความหนาของเส้นตัวเชื่อมต่อ
    $connector->getLineFormat()->setWidth(3);
    # เชื่อมโยงรูปร่างเข้าด้วยกันด้วยตัวเชื่อมต่อ
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # ดึงจุดปรับของตัวเชื่อมต่อ
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**การปรับ**

เราสามารถเปลี่ยนค่าจุดปรับของตัวเชื่อมต่อได้โดยเพิ่มเปอร์เซ็นต์ความกว้างและความสูงที่สอดคล้องกันเป็น 20 % และ 200 % ตามลำดับ:

```php
  # เปลี่ยนค่าของจุดปรับ
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-1](connector-adjusted-1.png)

เพื่อกำหนดโมเดลที่ช่วยให้เราหาค่าพิกัดและรูปร่างของส่วนย่อยของตัวเชื่อมต่อ เราจะสร้างรูปร่างที่สอดคล้องกับส่วนแนวนอนของตัวเชื่อมต่อที่จุด `connector.getAdjustments().get_Item(0)`:

```php
  # วาดส่วนแนวตั้งของตัวเชื่อมต่อ
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

ผลลัพธ์:

![connector-adjusted-2](connector-adjusted-2.png)

#### **กรณี 2**

ใน **กรณี 1** เราได้สาธิตการปรับตัวเชื่อมต่อแบบง่ายโดยใช้หลักการพื้นฐาน ในสถานการณ์ทั่วไป คุณต้องคำนึงถึงการหมุนของตัวเชื่อมต่อและการแสดงผล (ซึ่งตั้งค่าโดย `connector.getRotation()`, `connector.getFrame().getFlipH()`, และ `connector.getFrame().getFlipV()`) เราจะสาธิตกระบวนการต่อไป

แรกเริ่ม ให้เพิ่มอ็อบเจกต์กรอบข้อความใหม่ (**To 1**) ลงในสไลด์ (เพื่อใช้เชื่อมต่อ) และสร้างตัวเชื่อมต่อสีเขียวใหม่ที่เชื่อมต่อกับอ็อบเจกต์ที่สร้างไว้แล้ว

```php
  # สร้างอ็อบเจกต์การผูกใหม่
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # สร้างตัวเชื่อมต่อใหม่
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # เชื่อมต่ออ็อบเจกต์โดยใช้ตัวเชื่อมต่อที่สร้างใหม่
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # ดึงจุดปรับของตัวเชื่อมต่อ
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # เปลี่ยนค่าของจุดปรับ
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-3](connector-adjusted-3.png)

ต่อมา ให้สร้างรูปร่างที่สอดคล้องกับส่วนแนวนอนของตัวเชื่อมต่อที่ผ่านจุดปรับของตัวเชื่อมต่อ `connector.getAdjustments().get_Item(0)` เราจะใช้ค่าจาก `connector.getRotation()`, `connector.getFrame().getFlipH()`, และ `connector.getFrame().getFlipV()` และใช้สูตรแปลงพิกัดเพื่อหมุนรอบจุด x0 ดังนี้

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;  

ในกรณีของเรา วัตถุหมุน 90 องศาและตัวเชื่อมต่อแสดงแบบแนวตั้ง ดังนั้นโค้ดที่สอดคล้องคือ:

```php
  # บันทึกพิกัดของตัวเชื่อมต่อ
  $x = $connector->getX();
  $y = $connector->getY();
  # แก้ไขพิกัดของตัวเชื่อมต่อในกรณีที่ปรากฏ
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # ใช้ค่าจุดปรับเป็นพิกัด
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # แปลงพิกัดเนื่องจาก Sin(90) = 1 และ Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # กำหนดความกว้างของส่วนแนวนอนโดยใช้ค่าจุดปรับที่สอง
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

ผลลัพธ์:

![connector-adjusted-4](connector-adjusted-4.png)

เราสาธิตการคำนวณที่เกี่ยวข้องกับการปรับง่ายและการปรับที่มีมุมหมุน การใช้ความรู้เหล่านี้ คุณสามารถพัฒนาโมเดลของตนเอง (หรือเขียนโค้ด) เพื่อรับอ็อบเจกต์ `GraphicsPath` หรือแม้แต่ตั้งค่าค่าแรงจูงใจของตัวเชื่อมต่อโดยอิงจากพิกัดบนสไลด์

## **หามุมของเส้นเชื่อมต่อ**

1. สร้างอินสแตนซ์ของคลาส  
1. เรียกอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เข้าถึงรูปร่างเส้นเชื่อมต่อ  
1. ใช้ความกว้าง, ความสูง, ความสูงของเฟรมรูปร่าง, และความกว้างของเฟรมรูปร่างเพื่อคำนวณมุม  

โค้ด PHP ด้านล่างแสดงการคำนวณมุมสำหรับรูปร่างเส้นเชื่อมต่อ:

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**ฉันจะตรวจสอบได้อย่างไรว่าตัวเชื่อมต่อสามารถ "ติดแน่น" กับรูปเฉพาะได้หรือไม่?**

ตรวจสอบว่ารูปร่างเปิดเผย [connection sites](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getconnectionsitecount/) หรือไม่ หากไม่มีหรือจำนวนเป็นศูนย์ การติดแน่นจะไม่พร้อมใช้งาน; ในกรณีนั้นใช้จุดสิ้นสุดแบบอิสระและจัดตำแหน่งด้วยตนเอง เป็นการดีที่จะตรวจสอบจำนวนไซต์ก่อนทำการแนบ

**ถ้าฉันลบรูปหนึ่งที่เชื่อมต่ออยู่ ตัวเชื่อมต่อจะเกิดอะไรขึ้น?**

ปลายทั้งสองจะถูกตัดออก; ตัวเชื่อมต่อจะคงอยู่บนสไลด์เป็นเส้นธรรมดาที่มีจุดเริ่มต้น/สิ้นสุดอิสระ คุณสามารถลบมันหรือกำหนดการเชื่อมต่อใหม่ได้ และหากต้องการ สามารถ [reroute](https://reference.aspose.com/slides/th/php-java/aspose.slides/connector/reroute/)  

**การผูกตัวเชื่อมต่อจะคงอยู่หรือไม่เมื่อคัดลอกสไลด์ไปยังงานนำเสนออื่น?**

โดยทั่วไปใช่ ตราบใดที่รูปเป้าหมายถูกคัดลอกด้วย หากสไลด์ถูกแทรกเข้าไฟล์อื่นโดยไม่มีรูปที่เชื่อมต่อ ปลายจะกลายเป็นอิสระและคุณต้องเชื่อมต่อใหม่.