---
title: จัดการรูปร่างพรีเซนเทชันใน PHP
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/php-java/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างพรีเซนเทชัน
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- ทำสำเนารูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- ดึง ID รูปร่าง interop
- ข้อความแทนที่ของรูปร่าง
- รูปแบบเลย์เอาต์ของรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดตำแหน่งรูปร่าง
- พลิกรูปร่าง
- PowerPoint
- พรีเซนเทชัน
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ทำสำเนา, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดตำแหน่ง และพลิกรูปร่างพรีเซนเทชันด้วย Aspose.Slides for PHP via Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java แสดงรูปร่างบนสไลด์เป็น [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) ที่เรียงลำดับ. คอลเลกชันเป็นทั้งที่คุณค้นหาและแก้ไขรูปร่างและเป็นแหล่งที่มาของการจัดลำดับการซ้อน: ดัชนี `0` คือรูปร่างที่อยู่ด้านหลังสุด, ส่วนดัชนีสุดท้ายคือรูปร่างที่อยู่ด้านหน้าสุด.

บทความนี้ปฏิบัติตามโมเดลนั้น. มันอธิบายวิธีระบุรูปร่างอย่างแม่นยำก่อน, จากนั้นแสดงวิธีทำสำเนา, ลบ, ซ่อน, และจัดลำดับใหม่ของรูปร่าง. ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออกเป็น SVG, การจัดตำแหน่ง, และการตั้งค่าการพลิก. ตัวอย่างแต่ละอันเป็นอิสระ, ดังนั้นคุณสามารถใช้เฉพาะการทำงานที่ workflow ของคุณต้องการได้.

## **ระบุและค้นหารูปร่าง**

ดัชนีของคอลเลกชันสะดวกเมื่อต้องประมวลผลไฟล์ที่ทราบล่วงหน้า, แต่ไม่ได้เป็นตัวระบุที่คงที่. การเพิ่ม, การลบ, หรือการจัดลำดับใหม่ของรูปร่างอาจทำให้ดัชนีเปลี่ยนแปลง. เลือกตัวระบุตามวิธีการสร้างและการดูแลพรีเซนเทชัน:

- [Name](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getname/) มีประโยชน์สำหรับเทมเพลตที่นักพัฒนาควบคุมและตรวจสอบได้ง่ายใน Selection Pane ของ PowerPoint. ชื่อสามารถแก้ไขได้และไม่รับประกันว่าจะแตกต่างกัน, ดังนั้นควรกำหนดแนวปฏิบัติการตั้งชื่อหากโค้ดพึ่งพา.
- [AlternativeText](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getalternativetext/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุรูปร่าง. ข้อความนี้มองเห็นได้โดยผู้ใช้, สามารถแปลเป็นภาษาต่าง ๆ หรือเขียนใหม่เพื่อการเข้าถึง, และไม่รับประกันว่าจะเป็นเอกลักษณ์. อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่แจ้งให้ผู้ใช้ทราบ.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getofficeinteropshapeid/) เป็นตัวระบุแบบอ่านอย่างเดียวที่เป็นเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้. ใช้เมื่อต้องผสานกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ไม่คล ambiguous ตลอดอายุของรูปร่าง. รูปร่างที่ถูกทำสำเนาหรือสร้างใหม่เป็นรูปร่างที่แตกต่างและจะได้รับ ID ของตัวเอง.

วิธี [Shape::getUniqueId](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getuniqueid/) ที่เกี่ยวข้องคืนค่าตัวระบุที่มีขอบเขตระดับพรีเซนเทชัน, แต่ตัวระบุนี้ออกแบบมาสำหรับแอดอินและอาจถูกกำหนดใหม่. ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร. หากต้องการความเป็นเอกลักษณ์ระยะยาว, เก็บการแมปไว้ในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่หรือไม่.

ตัวอย่างต่อไปค้นหาตามชื่อด้วยการเปรียบเทียบแบบตรงและรายงาน interop ID ที่มีขอบเขตระดับสไลด์. เมื่อเทมเพลตไม่มีรูปร่างที่คาดไว้, โค้ดจะแจ้งผลนั้นแทนที่จะดำเนินต่อกับออบเจ็กต์ที่ผิดพลาด.

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

เมื่อการดำเนินการจำเพาะกับประเภทของรูปร่าง, ตรวจสอบคลาสใน runtime ก่อนใช้สมาชิกที่เฉพาะประเภท. ตัวอย่างนี้อัปเดตข้อความและข้อความแทนที่เพียงเมื่อออบเจ็กต์ที่มีชื่อเป็น [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/).

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

## **แก้ไขคอลเลกชันรูปร่าง**

เมธอดเพิ่ม, ทำสำเนา, ลบ, และจัดลำดับใหม่ทำงานบนคอลเลกชันทันที. หากการดำเนินการทำให้จำนวนหรือลำดับของรูปร่างเปลี่ยน, อย่าพึ่งพาดัชนีที่จับไว้ก่อนหน้าการดำเนินการนั้น.

### **ทำสำเนารูปร่าง**

[ShapeCollection::addClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/addclone/) สร้างสำเนาอิสระและเพิ่มต่อท้ายคอลเลกชันเป้าหมาย. [ShapeCollection::insertClone](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/insertclone/) ก็สร้างสำเนาเช่นกันแต่วางไว้ที่ดัชนี z‑order ที่ระบุ. overload ที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; overload ที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย.

ตัวอย่างนี้สร้างสไลด์ปลายทาง, ทำสำเนาสี่เหลี่ยมที่มีป้ายชื่อไปด้านหน้า, และแทรกสำเนาที่สองไว้ด้านหลัง. การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาหนึ่งจะไม่กระทบต่อรูปร่างต้นฉบับ.

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

การทำสำเนาจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปร่างรวมถึงชื่อและข้อความแทนที่. ให้กำหนดตัวระบุตรรกะใหม่ให้กับสำเนาเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์. แหล่งทรัพยากรที่ใช้โดยรูปร่างซับซ้อนจะถูกจัดการโดยพรีเซนเทชัน, แต่สำเนายังคงเป็นรายการคอลเลกชันใหม่ที่มีอัตลักษณ์รูปร่างใหม่.

### **ลบรูปร่าง**

[ShapeCollection::remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/remove/) ลบออบเจ็กต์รูปร่างที่ระบุจากคอลเลกชันของมัน. เมื่อทำการลบหลายรายการที่ตรงกันระหว่างการวนรอบตามดัชนี, ควรวนจากท้ายสุดเพื่อให้ดัชนีที่เหลือยังคงถูกต้อง.

ตัวอย่างนี้ลบทุกรูปร่างที่มีชื่อกำหนด. มันอ่านรูปร่างที่ดัชนีปัจจุบัน, ไม่ใช้ออบเจ็กต์คอลเลกชันที่คงที่, และไม่ทำการคาสท์รูปร่างโดยไม่จำเป็น.

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

หลังการลบ, จำนวนรูปร่างและดัชนีของรูปร่างที่ตามมาจะเปลี่ยน. การอ้างอิงไปยังรูปร่างที่ไม่ได้รับผลกระทบจะเชื่อถือได้กว่าดัชนีที่บันทึกไว้. ควรพิจารณา connector, animation, และคุณลักษณะอื่น ๆ ของพรีเซนเทชันที่อาจอ้างถึงออบเจ็กต์ที่ถูกลบ; การลบรูปร่างที่มองเห็นได้อาจเปลี่ยนสิ่งที่มากกว่าลักษณะการแสดงของสไลด์.

### **ซ่อนรูปร่าง**

การตั้งค่า [Shape::setHidden](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/sethidden/) เป็น `true` จะทำให้รูปร่างคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการแสดงสไลด์ปกติ. ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงพร้อมให้โค้ดเข้าถึง, ดังนั้นการซ่อนเหมาะสำหรับองค์ประกอบที่อาจถูกกู้คืนในภายหลัง.

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

การซ่อนไม่ได้หมายถึงการลบหรือความปลอดภัย. ออบเจ็กต์ยังคงถูกค้นพบและสามารถแสดงใหม่ได้โดยผู้ใช้หรือโดยโค้ด, และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน.

### **เปลี่ยนลำดับ Z‑Order**

รูปร่างที่ทับกันจะถูกวาดตามลำดับของคอลเลกชัน. [ShapeCollection::reorder](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/reorder/) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ทำสำเนา. ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า.

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

สี่เหลี่ยมถูกสร้างก่อนและตั้งต้นอยู่ด้านหลังวงรี. การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า. ควรสรุปลำดับ z‑order หลังจากเพิ่มหรือทำสำเนาทุกรูปร่างที่เกี่ยวข้อง, เพราะการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการคอลเลกชันใหม่และอาจเปลี่ยนสแต็คที่ต้องการ.

## **ตรวจสอบรูปร่างบนสไลด์เลย์เอาต์**

สไลด์ปกติ, สไลด์เลย์เอาต์, และมาสเตอร์สไลด์มีคอลเลกชันรูปร่างแยกกัน. รูปร่างในคอลเลกชันเลย์เอาต์ไม่ได้เป็นออบเจ็กต์เดียวกับรูปร่างที่อยู่ตำแหน่งเดียวกันบนสไลด์ปกติ. ตรวจสอบรูปร่างเลย์เอาต์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่มาจากเลย์เอาต์.

ตัวอย่างต่อไปอ่าน [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getfillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/getlineformat/) ของแต่ละรูปร่างในเลย์เอาต์โดยไม่สมมติว่าทุกรูปร่างเป็น `AutoShape`.

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

การแก้ไขเลย์เอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้เลย์เอาต์นั้น. ก่อนเปลี่ยนรูปร่างในเลย์เอาต์, ตรวจสอบว่าสไลด์ปกติสืบทอดออบเจ็กต์นั้นหรือมีการกำหนดค่าฉบับเฉพาะ, และทดสอบทุกสไลด์ที่ใช้เลย์เอาต์นั้น.

## **ส่งออกรูปร่างเป็น SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/writeassvg/) เขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งไปยังสตรีม. ผลลัพธ์จะมีเฉพาะรูปร่างนั้น, ไม่รวมพื้นหลังของสไลด์ทั้งหมดหรือรูปร่างที่อยู่ใกล้เคียง.

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

ควรเปิดพรีเซนเทชันอยู่ขณะทำการเรนเดอร์. ผลลัพธ์ขึ้นอยู่กับการจัดรูปแบบของรูปร่างและทรัพยากรเช่นฟอนต์และรูปภาพ. หากต้องการภาพรวมทั้งหมด, ควรส่งออกรูปสไลด์แทนที่จะเป็นรูปร่างแต่ละอัน. ผู้เรียกต้องเป็นเจ้าของสตรีมและต้องปิดสตรีมเมื่อใช้เสร็จ.

## **จัดตำแหน่งรูปร่าง**

เมธอด [SlideUtil::alignShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/alignshapes/) มี overload ที่จัดตำแหน่งทั้งชุดหรือดัชนีคอลเลกชันที่เลือก. [ShapesAlignmentType](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapesalignmenttype/) กำหนดขอบ, เส้นกลาง, หรือโหมดการกระจาย. ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดตำแหน่งรูปร่างที่เลือกสัมพันธ์กัน.

ตัวอย่างนี้จัดตำแหน่งสามรูปร่างให้ชิดขอบบนของสไลด์. การอ้างอิงรูปร่างที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนทำการจัดตำแหน่ง.

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

การจัดตำแหน่งเปลี่ยนตำแหน่ง, ไม่ใช่ลำดับ z‑order. การจัดตำแหน่งเชิงสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปร่าง, ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปร่างเพียงพอเพื่อกำหนดระยะห่าง. หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอด, ควรคำนวณดัชนีใหม่.

## **พลิกรูปร่าง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าการพลิกแนวนอนและแนวตั้ง, และการหมุน. ค่า `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/php-java/aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิดการพลิก, และ `NotDefined` คงสถานะที่ไม่ได้ระบุ/ค่าเริ่มต้น.

การนำเสนออินพุตด้านล่างมีรูปร่างหนึ่งอันที่ไม่ได้พลิก.

![รูปร่างก่อนการพลิก](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่าทุกฟรมอื่นไว้และเปลี่ยนเฉพาะการตั้งค่าการพลิกสองค่า. สิ่งนี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/setframe/) ใหม่จะทับฟรมทั้งหมด.

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

รูปร่างที่บันทึกจะถูกสะท้อนแนวนอนและแนวตั้งขณะคงตำแหน่ง, ขนาด, และการหมุนเดิม.

![รูปร่างหลังการพลิก](flipped_shape.png)

## **FAQ**

**ฉันควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปร่างหรือไม่?**

ใช้ได้เฉพาะในการประมวลผลระยะสั้นเมื่อคอลเลกชันจะไม่เปลี่ยนก่อนใช้ดัชนี. ควรใช้ `Name` หรือ `AlternativeText` ที่ตรวจสอบแล้วสำหรับเทมเพลตที่กำหนดเอง, หรือ `OfficeInteropShapeId` สำหรับงานที่ต้องอิง interop ระดับสไลด์.

**การซ่อนรูปร่างทำให้มันหายไปจาก z‑order หรือไม่?**

ไม่. รูปร่างที่ซ่อนยังคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน. สามารถค้นหา, เรียงลำดับใหม่, แก้ไข, หรือทำให้แสดงใหม่ได้.

**ทำไมรูปร่างที่ทำสำเนาถึงปรากฏอยู่หน้ารูปร่างอื่น?**

`addClone` จะเพิ่มสำเนาไปยังตำแหน่งสุดท้ายของคอลเลกชัน, ซึ่งเป็นด้านหน้าของ z‑order. ใช้ `insertClone` เพื่อเลือกดัชนีเริ่มต้นหรือใช้ `reorder` หลังจากเพิ่มรูปร่างทั้งหมดแล้ว.