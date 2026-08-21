---
title: จัดรูปแบบรูปร่าง PowerPoint ใน PHP
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/php-java/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่ระดับสี
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมเทกซ์เจอร์
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การแสดงผลรูปร่างสีขาว-ดำ
- การแสดงผลรูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟกต์ขอบด้าน 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน PHP ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้. เนื่องจากรูปร่างประกอบด้วยเส้น คุณสามารถจัดรูปแบบโดยการปรับหรือนำเอฟเฟกต์ไปใช้กับเส้นขอบของมัน. นอกจากนี้ คุณสามารถจัดรูปแบบรูปร่างโดยระบุการตั้งค่าที่ควบคุมวิธีการเติมภายในของมัน.

![การจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java ให้คลาสและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint.

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถกำหนดสไตล์เส้นแบบกำหนดเองสำหรับรูปร่างได้. ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. ตั้งค่า [line style](https://reference.aspose.com/slides/th/php-java/aspose.slides/linestyle/) ของรูปร่าง.  
5. ตั้งค่าความกว้างของเส้น.  
6. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/php-java/aspose.slides/linedashstyle/) ของเส้น.  
7. ตั้งค่าสีเส้นสำหรับรูปร่าง.  
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด PHP ด้านล่างแสดงวิธีการจัดรูปแบบ `AutoShape` รูปสี่เหลี่ยม:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยม.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในการนำเสนอ](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/lineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/th/php-java/aspose.slides/sketchformat/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/th/php-java/aspose.slides/linesketchtype/).

โค้ด PHP ด้านล่างแสดงวิธีการใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/th/php-java/aspose.slides/linesketchtype/) , อ่านค่าที่กำหนดอย่างชัดเจน, และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/th/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // เข้าถึงรูปแบบเส้นของรูปร่างและรูปแบบสเก็ตช์ของมัน.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // ใช้เอฟเฟกต์สเก็ตช์.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // อ่านเอฟเฟกต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูปร่าง.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // ลบเอฟเฟกต์สเก็ตช์.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

ค่าที่ส่งกลับจาก [SketchFormat.getSketchType](https://reference.aspose.com/slides/th/php-java/aspose.slides/sketchformat/) แสดงถึงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, สไลด์แม่แบบ, หรือสไลด์เลย์เอาต์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/lineformat/), เข้าถึงเมธอด `getSketchFormat` ของอ็อบเจ็กต์ที่ส่งกลับ, และอ่านค่าของ `getSketchType` ค่าที่มีประสิทธิผลนี้สะท้อนการจัดรูปแบบที่ใช้งานจริงหลังจากการสืบทอดได้รับการแก้ไข:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:

* โค้ง  
* มิเธอร์  
* บีเวล  

โดยค่าเริ่มต้น เมื่อ PowerPoint เชื่อมสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) จะใช้การตั้งค่า **โค้ง** อย่างไรก็ตาม หากคุณวาดรูปร่างที่มีมุมคม คุณอาจต้องการตัวเลือก **มิเธอร์**.

![สไตล์การเชื่อมต่อในการนำเสนอ](join-style-powerpoint.png)

โค้ด PHP ด้านล่างแสดงวิธีที่สี่เหลี่ยมสามรูป (ตามรูปข้างบน) ถูกสร้างโดยใช้การตั้งค่าประเภทการเชื่อมต่อ Miter, Bevel, และ Round:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสามรายการประเภทสี่เหลี่ยม.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยมแต่ละอัน.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // ตั้งค่าความกว้างของเส้น.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยมแต่ละอัน.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // ตั้งค่าสไตล์การเชื่อมต่อ.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // เพิ่มข้อความให้กับสี่เหลี่ยมแต่ละอัน.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ไล่ระดับสี**

ใน PowerPoint, การไล่ระดับสีเป็นตัวเลือกการจัดรูปแบบที่ทำให้คุณสามารถเติมสีต่อเนื่องให้กับรูปร่างได้ ตัวอย่างเช่น คุณสามารถใช้สีสองสีหรือมากกว่าโดยสีหนึ่งค่อยๆ จางเข้าไปในอีกสีหนึ่ง

ต่อไปนี้เป็นวิธีการใช้ไล่ระดับสีกับรูปร่างโดยใช้ Aspose.Slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปร่างเป็น `Gradient`.  
5. เพิ่มสีสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `add` ของคอลเลกชัน gradient stop ที่เปิดให้ใช้งานโดยคลาส [GradientFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/gradientformat/).  
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภทวงรี.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // นำการจัดรูปแบบไล่ระดับสีไปใช้กับวงรี.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // ตั้งค่าทิศทางของไล่ระดับสี.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // เพิ่มจุดหยุดไล่ระดับสีสองจุด.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปวงรีที่มีไล่ระดับสี](gradient-fill.png)

## **เติมลวดลาย**

ใน PowerPoint, การเติมลวดลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใส่การออกแบบสองสี—เช่น จุด, แถบ, ลายตัดกัน หรือ การตรวจสอบ—ลงบนรูปร่าง คุณสามารถเลือกสีกำหนดเองสำหรับพื้นหน้าลวดลายและพื้นหลังได้.

Aspose.Slides มีสไตล์ลวดลายที่กำหนดไว้ล่วงหน้ากว่า 45 แบบที่คุณสามารถนำไปใช้กับรูปร่างเพื่อเพิ่มความน่าสนใจของการนำเสนอ แม้หลังจากเลือกลวดลายที่กำหนดไว้แล้ว คุณก็ยังสามารถกำหนดสีที่ต้องการให้ใช้ได้.

ต่อไปนี้เป็นวิธีการใช้การเติมลวดลายกับรูปร่างโดยใช้ Aspose.Slides:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปร่างเป็น `Pattern`.  
5. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า.  
6. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/patternformat/#getBackColor) ของลวดลาย.  
7. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/patternformat/#getForeColor) ของลวดลาย.  
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์การนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // ตั้งค่ารูปแบบลาย.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลาย.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่มีการเติมลวดลาย](pattern-fill.png)

## **เติมรูปภาพ**

ใน PowerPoint, การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกรูปภาพภายในรูปร่าง—โดยใช้รูปภาพเป็นพื้นหลังของรูปร่าง.

ต่อไปนี้เป็นวิธีการใช้ Aspose.Slides เพื่อเติมรูปภาพในรูปร่าง:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปร่างเป็น `Picture`.  
5. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ).  
6. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) จากรูปภาพที่คุณต้องการใช้.  
7. ส่งรูปภาพไปยังเมธอด `SlidesPicture.setImage`.  
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

สมมติว่าเรามีไฟล์ "lotus.png" ที่มีรูปภาพต่อไปนี้:

![รูป lotus](lotus.png)

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์การนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // ตั้งค่าชนิดการเติมเป็น Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // ตั้งค่าโหมดการเติมรูปภาพ.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของการนำเสนอ.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // ตั้งค่ารูปภาพ.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปร่างที่เติมรูปภาพ](picture-fill.png)

### **การทำภาพแบบกระเบื้องเป็นเทกซ์เจอร์**

หากคุณต้องการตั้งค่าภาพกระเบื้องเป็นเทกซ์เจอร์และกำหนดพฤติกรรมการกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งค่าโหมดการเติมรูปภาพ—either `Tile` หรือ `Stretch`.  
- [setTileAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุการจัดตำแหน่งของกระเบื้องภายในรูปร่าง.  
- [setTileFlip](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่ากระเบื้องจะถูกพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง.  
- [setTileOffsetX](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่าการเยื้องแนวนอนของกระเบื้อง (หน่วย points) จากจุดกำเนิดของรูปร่าง.  
- [setTileOffsetY](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่าการเยื้องแนวตั้งของกระเบื้อง (หน่วย points) จากจุดกำเนิดของรูปร่าง.  
- [setTileScaleX](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์.  
- [setTileScaleY](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์.

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์การนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปร่างเป็น Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของการนำเสนอ.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // กำหนดภาพให้กับรูปร่าง.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // ตั้งค่ารูปแบบการเติมรูปภาพและคุณสมบัติการกระเบื้อง.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ตัวเลือกการกระเบื้อง](tile-options.png)

## **เติมสีทึบ**

ใน PowerPoint, การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมสีเดียวที่สม่ำเสมอลงในรูปร่าง สีพื้นหลังเรียบนี้ถูกใช้โดยไม่มีการไล่ระดับ สีเทกซ์เจอร์ หรือ ลวดลาย.

เพื่อเติมสีทึบให้กับรูปร่างโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปร่างเป็น `Solid`.  
5. Assign your preferred fill color to the shape.  
6. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์การนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // ตั้งค่าสีเติม.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้การเติมสีทึบ, ไล่ระดับสี, รูปภาพ, หรือเทกซ์เจอร์บนรูปร่าง คุณสามารถกำหนดระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม ค่าความโปร่งใสที่สูงทำให้รูปร่างโปร่งแสงมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน.

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่าอัลฟาในสีที่ใช้สำหรับการเติม ต่อไปนี้เป็นวิธีทำ:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) เป็น `Solid`.  
5. Use `Color` to define a color with transparency (the `alpha` component controls transparency).  
6. Save the presentation.

```php
    // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์การนำเสนอ.
    $presentation = new Presentation();
    try {
        // ดึงสไลด์แรก.
        $slide = $presentation->getSlides()->get_Item(0);

        // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมแบบทึบ.
        $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

        // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งแสงเหนือรูปร่างทึบ.
        $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
        $transparentShape->getFillFormat()->setFillType(FillType::Solid);
        $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

        // บันทึกไฟล์ PPTX ไปยังดิสก์.
        $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
```

ผลลัพธ์:

![รูปร่างโปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปร่างในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อวางตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือความต้องการออกแบบที่เฉพาะเจาะจง.

เพื่อหมุนรูปร่างบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. Set the shape’s rotation property to the desired angle.  
5. Save the presentation.

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์การนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภทสี่เหลี่ยม.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // หมุนรูปร่างโดย 5 องศา.
    $shape->setRotation(5);

    // บันทึกไฟล์ PPTX ไปยังดิสก์.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ขอบด้าน 3 มิติ**

Aspose.Slides ช่วยให้คุณใช้เอฟเฟกต์ขอบด้าน 3 มิติบนรูปร่างโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์ขอบด้าน 3 มิติบนรูปร่าง ให้ทำตามขั้นตอนต่อไปนี้:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. Configure the shape’s [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/) to define bevel settings.  
5. Save the presentation.

```php
// สร้างอินสแตนซ์ของคลาส Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างลงในสไลด์.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปร่าง.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // บันทึกการนำเสนอเป็นไฟล์ PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์ขอบด้าน 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides ช่วยให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปร่างโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/)

เพื่อใช้การหมุน 3 มิติบนรูปร่าง:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) class.  
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์.  
4. Use the [setCameraType](https://reference.aspose.com/slides/th/php-java/aspose.slides/camera/#setCameraType) and [setLightType](https://reference.aspose.com/slides/th/php-java/aspose.slides/lightrig/#setLightType) to define the 3D rotation.  
5. Save the presentation.

```php
// สร้างอินสแตนซ์ของคลาส Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // บันทึกการนำเสนอเป็นไฟล์ PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการแสดงผลขาว-ดำสำหรับรูปร่าง**

เมธอด [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#setBlackWhiteMode) ระบุวิธีการแสดงผลของรูปร่างบุคคลเมื่อการนำเสนอถูกดูหรือประมวลผลในโหมดขาว-ดำ. มันไม่ได้เปิดใช้งานการแสดงผลขาว-ดำโดยอัตโนมัติและไม่เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่นของรูปร่างในโหมดสีปกติ.

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ. ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันแปลงสี, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับสีเดียว, `Color` รักษาสีปกติ, `Hidden` ลบรูปร่างในโหมดขาว-ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง.

โค้ด PHP ด้านล่างสร้างรูปร่างสีและทำให้มันแสดงเป็นสีเทาในโหมดแสดงผลขาว-ดำ:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // คงสีเติมส้มในโหมดสี, แต่เรนเดอร์รูปร่างด้วยสีเทาในโหมดขาว-ดำ.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ในโหมดสีปกติ สี่เหลี่ยมยังคงมีการเติมสีส้ม. ในเวิร์กโฟลว์แสดงผลขาว-ดำ มันใช้สีเทาเนื่องจากโหมดถูกตั้งค่าเป็น `Gray`. สิ่งนี้ช่วยให้คุณรักษาแผ่นสไลด์สีเต็มขณะกำหนดลักษณะเฉพาะสำหรับการพิมพ์, การแสดงตัวอย่าง, หรือเวิร์กโฟลว์อื่นที่เคารพการตั้งค่าแสดงผลขาว-ดำของการนำเสนอ.

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ด้านล่างแสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปร่างทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) ให้กลับไปเป็นค่าตั้งต้น:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // รีเซ็ตแต่ละรูปร่างบนสไลด์ที่มี placeholder บนเลย์เอาต์.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์การนำเสนอสุดท้ายหรือไม่?**

มีผลเพียงเล็กน้อยเท่านั้น. ภาพและสื่อที่ฝังไว้ใช้พื้นที่ส่วนใหญ่ของไฟล์ ส่วนพารามิเตอร์ของรูปร่างเช่นสี, เอฟเฟกต์, และไล่ระดับสีจะถูกเก็บเป็นเมทาดาต้าและแทบไม่มีขนาดเพิ่มเข้าไป.

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อให้สามารถจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ให้มองว่าสไตล์เป็นเดียวกันและจัดกลุ่มรูปร่างเหล่านั้นตามตรรกะ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น.

**ฉันสามารถบันทึกชุดสไตล์รูปร่างกำหนดเองในไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในชุดสไลด์ต้นแบบหรือไฟล์เทมเพลต .POTX. เมื่อสร้างงานนำเสนอใหม่ เปิดเทมเพลต, คัดลอกรูปร่างที่มีสไตล์ตามต้องการ, แล้วนำการจัดรูปแบบของมันไปใช้ใหม่ที่จำเป็น.