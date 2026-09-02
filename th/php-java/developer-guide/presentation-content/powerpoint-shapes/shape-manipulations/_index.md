---
title: จัดการรูปทรงการพรีเซนเทชันใน PHP
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/php-java/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงการนำเสนอ
- รูปทรงบนสไลด์
- ค้นหารูปทรง
- ทำสำเนารูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ ID รูปทรง Interop
- ข้อความแทนรูปทรง
- จุดปรับรูปทรง
- การปรับรูปทรงที่กำหนดล่วงหน้า
- เรขาคณิตรูปทรง
- รูปแบบการจัดวางรูปทรง
- รูปทรงเป็น SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- กลับรูปทรง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ปรับ, ทำสำเนา, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดแนว, และกลับรูปทรงการนำเสนอด้วย Aspose.Slides for PHP via Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java แสดงรูปทรงบนสไลด์เป็น [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) ที่เรียงลำดับ คอลเลกชันเป็นทั้งที่คุณค้นหาและแก้ไขรูปทรงและเป็นแหล่งของลำดับการซ้อน: ดัชนี `0` คือรูปทรงที่อยู่ด้านหลังสุด, ส่วนดัชนีสุดท้ายคือรูปทรงที่อยู่ด้านหน้าสุด

บทความนี้ทำตามแบบนั้น อธิบายวิธีระบุรูปทรงอย่างแม่นยำและแก้ไขจุดปรับตั้งค่ารูปทรงที่กำหนดไว้ล่วงหน้า, จากนั้นแสดงวิธีทำสำเนา, ลบ, ซ่อน และจัดเรียงรูปทรงใหม่ ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออกเป็น SVG, การจัดแนว, และการตั้งค่าการกลับรูปทรง ตัวอย่างแต่ละอันเป็นอิสระ ดังนั้นคุณสามารถใช้เพียงการดำเนินการที่จำเป็นสำหรับ workflow ของคุณ

## **ระบุและค้นหารูปทรง**

ดัชนีของคอลเลกชันสะดวกเมื่อประมวลผลไฟล์ที่รู้จัก, แต่ไม่ได้เป็นตัวระบุตัวตนที่คงที่ การเพิ่ม, ลบ, หรือจัดเรียงรูปทรงใหม่อาจทำให้ดัชนีเปลี่ยน เลือกตัวระบุตามวิธีที่นำเสนอถูกสร้างและดูแล:

- [Name](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getname/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนา และตรวจสอบได้ง่ายในแผงการเลือกของ PowerPoint ชื่อสามารถแก้ไขได้และไม่ได้รับประกันว่าจะไม่ซ้ำกัน ดังนั้นควรกำหนดมาตรฐานการตั้งชื่อหากโค้ดพึ่งพา
- [AlternativeText](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getalternativetext/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุรูปทรง มันมองเห็นได้โดยผู้ใช้, อาจแปลหรือเขียนใหม่เพื่อการเข้าถึง, และไม่ได้รับประกันว่าจะไม่ซ้ำกัน อย่าแปลงข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลอย่างเงียบ ๆ
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getofficeinteropshapeid/) เป็นตัวระบุแบบอ่านอย่างเดียวที่ไม่ซ้ำกันภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้ ใช้เมื่อทำการเชื่อมต่อกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ชัดเจนตลอดอายุของรูปทรง รูปทรงที่ทำสำเนาหรือสร้างใหม่เป็นรูปทรงที่แตกต่างและจะได้รับ ID ของตนเอง

เมธอดที่เกี่ยวข้อง [Shape::getUniqueId](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getuniqueid/) คืนตัวระบุในระดับพรีเซนเทชัน, แต่ตัวระบุนี้มุ่งหมายสำหรับแอดอินและอาจถูกกำหนดใหม่ ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร หากต้องการอัตลักษณ์ระยะยาว ควรเก็บการแมพในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปทรงที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปนี้ค้นหาตามชื่อด้วยการเปรียบเทียบที่ตรงกันและรายงาน interop ID ที่มีขอบเขตสไลด์ เมื่อเทมเพลตไม่มีรูปทรงที่คาดหวัง โค้ดจะรายงานผลนั้นแทนที่จะดำเนินต่อด้วยอ็อบเจ็กต์ที่ผิด

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

เมื่อการดำเนินการเฉพาะกับชนิดรูปทรง, ตรวจสอบคลาส runtime ก่อนใช้สมาชิกที่เจาะจงตามชนิด ตัวอย่างนี้อัปเดตข้อความและข้อความแทนตามเฉพาะเมื่ออ็อบเจ็กต์ที่ชื่อเป็น [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/)

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

## **ระบุและแก้ไขการปรับตั้งค่ารูปทรงที่กำหนดไว้ล่วงหน้า**

รูปทรงเรขาคณิตที่กำหนดล่วงหน้าสามารถเปิดเผยจุดปรับที่ควบคุมคุณลักษณะเช่น ขนาดมุม, สัดส่วนลูกศร, หรือมุมโค้ง เข้าถึงได้ผ่านคอลเลกชันอ่านอย่างเดียว [GeometryShape::getAdjustments](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometryshape/#getAdjustments) คอลเลกชันเองจัดให้โดยรูปทรง, แต่ละ [AdjustValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/) มีค่าที่สามารถเปลี่ยนได้

ห้ามพึ่งพาเพียงดัชนีคอลเลกชันคงที่ ให้วนลูปผ่านการปรับและตรวจสอบเมธอดอ่านอย่างเดียว [AdjustValue::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/#getType) ที่คืนค่า [ShapeAdjustmentType](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeadjustmenttype/) เพื่อระบุว่าการปรับควบคุมอะไร เมธอดอ่านอย่างเดียว [AdjustValue::getName](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/getname/) ให้ข้อมูลระบุตัวเพิ่มและมีประโยชน์เมื่อพรีเซ็ตมีการปรับมากกว่าหนึ่งรายการที่มีชนิดเชิงปริมาณเดียวกัน

ใช้เมธอดค่าที่ตรงกับความหมายของการปรับ:

| ประเภทการปรับ | วัตถุประสงค์ | ค่าเพื่อเปลี่ยน |
|---|---|---|
| `CornerSize` | ขนาดของมุมที่ปัด | [setRawValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | ความหนาของหางลูกศร | `setRawValue` |
| `ArrowheadLength` | ความยาวของหัวลูกศร | `setRawValue` |
| `ArrowheadWidth` | ความกว้างของหัวลูกศร | `setRawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือโค้ง | [setAngleValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | มุมสุดท้ายของพายหรือโค้ง | `setAngleValue` |

`getType` และ `getName` คืนข้อมูลอ่านอย่างเดียว `getRawValue` และ `setRawValue` ทำงานกับจำนวนเต็มในหน่วยเรขาคณิตของพรีเซ็ต, ส่วน `getAngleValue` และ `setAngleValue` ทำงานกับมุมเป็นองศา จำนวน, ลำดับ, ความหมาย, และช่วงค่าอนุญาตของการปรับขึ้นอยู่กับพรีเซ็ตที่คืนค่าจาก [GeometryShape::getShapeType](https://reference.aspose.com/slides/th/php-java/aspose.slides/geometryshape/#getShapeType) ค่าที่ใช้ได้กับพรีเซ็ตหนึ่งอาจไม่ถูกต้องหรือให้ผลแตกต่างกับพรีเซ็ตอื่น

เมื่อ `getType` คืนค่า `ShapeAdjustmentType::Custom` API จะไม่รู้จักความหมายเชิงมาตรฐาน ตรวจสอบ `getName`, ชนิดพรีเซ็ต, และค่าปัจจุบัน, และอย่าเปลี่ยนการปรับหากไม่ได้รู้ความหมายและช่วงที่คาดหวัง แม้กับชนิดที่รับรู้แล้ว ก็ควรตรวจสอบว่าชนิดเดียวปรากฏมากกว่าหนึ่งครั้งหรือไม่ก่อนเลือกค่า บทความ [Connector](/slides/th/php-java/connector/) แสดงสถานการณ์นี้กับการปรับการโค้งของคอนเนคเตอร์

ตัวอย่างเต็มต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่แก้ไขของรูปทรงพรีเซ็ตสามแบบ วนลูปผ่านการปรับทุกรายการ, รายงานชื่อและประเภท, เปลี่ยนค่าที่เกี่ยวกับขนาดผ่าน `setRawValue`, เปลี่ยนมุมผ่าน `setAngleValue`, และบันทึกผล คอลัมน์ซ้ายเก็บเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมมุมมนที่ปรับ, ลูกศรสี่ทาง, และพาย

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มหัวเรื่องสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับค่า
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

การตรวจสอบชนิดเชิงปริมาณก่อนเปลี่ยนค่าทำให้โค้ดชัดเจนเกี่ยวกับเจตนาและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวมีความหมายเดียวกันในพรีเซ็ตต่าง ๆ

## **แก้ไขคอลเลกชันรูปทรง**

เมธอดเพิ่ม, ทำสำเนา, ลบ, และจัดเรียงทำงานกับคอลเลกชันโดยทันที หากการดำเนินการทำให้จำนวนหรือลำดับของรูปทรงเปลี่ยน, อย่าอ้างอิงดัชนีที่จับก่อนการดำเนินการนั้นต่อไป

### **ทำสำเนารูปทรง**

[ShapeCollection::addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addclone/) สร้างสำเนาอิสระและต่อท้ายคอลเลกชันเป้าหมาย [ShapeCollection::insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/insertclone/) ก็สร้างสำเนาเช่นกันแต่วางที่ดัชนี z‑order ที่ระบุ การโอเวอร์โหลดที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; การโอเวอร์โหลดที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างสร้างสไลด์ปลายทาง, ทำสำเนาสี่เหลี่ยมที่มีป้ายกำกับไปด้านหน้า, และแทรกสำเนาที่สองไปด้านหลัง การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาหนึ่งจะไม่กระทบรูปทรงต้นฉบับ

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

การทำสำเนาคัดลอกเนื้อหาและการจัดรูปแบบของรูปทรง รวมถึงชื่อและข้อความแทนตาม มอบหมายตัวระบุตรรกะใหม่ให้กับสำเนาหากค่าดังกล่าวต้องไม่ซ้ำกัน ทรัพยากรที่ใช้โดยรูปทรงซับซ้อนจัดการโดยพรีเซนเทชัน, แต่สำเนายังคงเป็นรายการคอลเลกชันใหม่พร้อมอัตลักษณ์รูปทรงใหม่

### **ลบรูปทรง**

[ShapeCollection::remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/remove/) ลบอ็อบเจ็กต์รูปทรงเฉพาะจากคอลเลกชันของมัน เมื่อทำการลบหลายรายการในระหว่างการวนลูปที่อ้างอิงดัชนี, ควรเดินจากจุดท้ายเพื่อให้ดัชนีที่เหลือยังคงถูกต้อง

ตัวอย่างนี้ลบรูปทรงทุกอันที่มีชื่อที่กำหนดไว้ มันอ่านรูปทรงที่ดัชนีปัจจุบัน, ไม่ใช่รายการคอลเลกชันคงที่, และไม่ได้ทำการคาสต์รูปทรงโดยไม่จำเป็น

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

หลังการลบ จำนวนรูปทรงและดัชนีของรูปทรงต่อมาจะเปลี่ยน การอ้างอิงรูปทรงที่ไม่ได้รับผลกระทบยังคงเชื่อถือได้มากกว่าการบันทึกดัชนี นอกจากนี้ควรพิจารณาคอนเนคเตอร์, แอนิเมชัน, และคุณลักษณะพรีเซนเทชันอื่น ๆ ที่อาจอ้างอิงอ็อบเจ็กต์ที่ลบ; การลบรูปทรงที่มองเห็นได้อาจเปลี่ยนมากกว่าลักษณะการแสดงของสไลด์

### **ซ่อนรูปทรง**

ตั้งค่า [Shape::setHidden](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/sethidden/) เป็น `true` จะทำให้รูปทรงคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการแสดงสไลด์ปกติ ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงสามารถเข้าถึงได้โดยโค้ด ดังนั้นการซ่อนเหมาะสำหรับองค์ประกอบเลือกที่อาจคืนค่าได้ภายหลัง

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

การซ่อนไม่ใช่การลบหรือความปลอดภัย อ็อบเจ็กต์ยังคงถูกค้นพบและเปิดเผยโดยผู้ใช้หรือโดยโค้ด, และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **เปลี่ยนลำดับ Z‑Order**

รูปทรงที่ทับซ้อนกันจะถูกวาดตามลำดับคอลเลกชัน [ShapeCollection::reorder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/reorder/) ย้ายรูปทรงที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ทำสำเนา ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า

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

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่หลังวงรี การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า ควรสรุปลำดับ Z‑order หลังจากเพิ่มหรือทำสำเนารูปทรงที่เกี่ยวข้องทั้งหมด เพราะการดำเนินการเหล่านั้นจะต่อท้ายหรือแทรกรายการคอลเลกชันใหม่และอาจเปลี่ยนสแตกที่ตั้งใจไว้

## **ตรวจสอบรูปทรงบนสไลด์เลย์เอาต์**

สไลด์ปกติ, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์มีคอลเลกชันรูปทรงแยกกัน รูปทรงในคอลเลกชันเลย์เอาต์ไม่ใช่อ็อบเจ็กต์เดียวกับรูปทรงที่วางตำแหน่งคล้ายกันบนสไลด์ปกติ ตรวจสอบรูปทรงเลย์เอาต์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่เลย์เอาต์กำหนด

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getfillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getlineformat/) ของแต่ละรูปทรงเลย์เอาต์โดยไม่สมมติว่าทุกรูปทรงเป็น `AutoShape`

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

การแก้ไขเลย์เอาต์อาจส่งผลต่อสไลด์หลายสไลด์ที่ใช้เลย์เอาต์นั้น ก่อนเปลี่ยนรูปทรงเลย์เอาต์ให้ตรวจสอบว่ามีสไลด์ปกติสืบทอดอ็อบเจ็กต์หรือมีการเขียนทับแบบโลคัลหรือไม่, และทดสอบสไลด์ทุกสไลด์ที่ใช้เลย์เอาต์นั้น

## **ส่งออกรูปทรงเป็น SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/writeassvg/) เขียนเนื้อหาที่เรนเดอร์ของรูปทรงหนึ่งไปยังสตรีม ผลลัพธ์จะมีเพียงรูปทรง ไม่ได้รวมพื้นหลังสไลด์ทั้งหมดหรือรูปทรงใกล้เคียง

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

ให้เปิดพรีเซนเทชันขณะทำการเรนเดอร์ เอาต์พุตขึ้นอยู่กับการจัดรูปแบบของรูปทรงและทรัพยากรเช่นฟอนต์และรูปภาพ หากต้องการองค์ประกอบทั้งหมดให้ส่งออกรายการสไลด์แทนการส่งออกรูปทรงเดี่ยว ผู้เรียกต้องเป็นเจ้าของสตรีมและต้องปิดสตรีมนั้นเอง

## **จัดแนวรูปทรง**

เมธอด [SlideUtil::alignShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/alignshapes/) มีหลายเวอร์ชันที่จัดแนวทั้งชุดรูปทรงหรือดัชนีคอลเลกชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นศูนย์กลาง, หรือโหมดการกระจาย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปทรงที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปทรงให้ตรงกับขอบบนของสไลด์ การอ้างอิงรูปทรงที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันก่อนการจัดแนว

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

การจัดแนวเปลี่ยนตำแหน่ง ไม่ใช่ลำดับ z‑order การจัดแนวเชิงสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปทรง, ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปทรงเพียงพอเพื่อกำหนดระยะห่าง หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอดให้คำนวณดัชนีใหม่

## **กลับรูปทรง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การกลับแนวนอนและแนวตั้ง, และการหมุน ค่า `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/php-java/aspose.slides/nullablebool/): `True` เปิดการกลับ, `False` ปิด, และ `NotDefined` คงสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น

พรีเซนเทชันอินพุตด้านล่างมีรูปทรงหนึ่งที่ไม่ได้ถูกกลับ

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่นทั้งหมดและแทนที่เฉพาะการตั้งค่าการกลับสองค่าเท่านั้น สิ่งนี้สำคัญเพราะการกำหนดค่าใหม่ให้กับ [Frame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/setframe/) จะเปลี่ยนกรอบทั้งหมด

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

รูปทรงที่บันทึกจะถูกสะท้อนแนวนอนและแนวตั้งในขณะที่คงตำแหน่ง, ขนาด, และการหมุนไว้

![The shape after flipping](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปทรงหรือไม่?**

ใช้ได้เฉพาะการประมวลผลระยะสั้นเมื่อคอลเลกชันจะไม่เปลี่ยนก่อนใช้ดัชนีนั้น แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ผ่านการตรวจสอบสำหรับเทมเพลตที่สร้างโดยผู้เขียน, หรือ `OfficeInteropShapeId` สำหรับงาน interop ระดับสไลด์

**การซ่อนรูปทรงทำให้มันหายจาก z‑order หรือไม่?**

ไม่ รูปทรงที่ซ่อนคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน สามารถค้นหา, จัดเรียงใหม่, แก้ไข, หรือทำให้มองเห็นได้อีกครั้ง

**ทำไมรูปทรงที่ทำสำเนาจึงปรากฏอยู่หน้ารูปทรางอื่น?**

`addClone` ต่อท้ายสำเนาที่ตำแหน่งสุดท้ายของคอลเลกชัน ซึ่งเป็นด้านหน้าของ z‑order ใช้ `insertClone` เพื่อเลือกดัชนีเริ่มต้นหรือใช้ `reorder` หลังจากเพิ่มรูปทรงทั้งหมดแล้ว

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับของพรีเซ็ตรูปทรงได้หรือไม่?**

ได้เฉพาะหลังจากตรวจสอบพรีเซ็ตและโครงสร้างคอลเลกชันอย่างแม่นยำ แนะนำให้วนลูปผ่าน `GeometryShape::getAdjustments` และตรวจสอบ `AdjustValue::getType`; ใช้ `AdjustValue::getName` เป็นข้อมูลเพิ่มเติมเมื่อชนิดเชิงปริมาณเดียวปรากฏหลายครั้ง