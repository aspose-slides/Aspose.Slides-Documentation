---
title: จัดรูปแบบรูปร่าง PowerPoint ใน PHP
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/php-java/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟ็กต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่สี
- การเติมลวดลาย
- การเติมภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การเรนเดอร์รูปร่างสีขาว-ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟ็กต์ bevel 3 มิติ
- เอฟเฟ็กต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน PHP ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟ็กต์สำหรับไฟล์ PPT, PPTX, และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับขอบเส้นของมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปร่างโดยระบุการตั้งค่าที่ควบคุมการเติมสีภายในของรูปร่างได้

![รูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP ผ่าน Java ให้คลาสและเมธอดที่ช่วยให้คุณสามารถจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นที่กำหนดเองสำหรับรูปร่าง ขั้นตอนต่อไปนี้สรุปขั้นตอนการทำงาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. ตั้งค่า [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) ของรูปร่าง
5. ตั้งค่าความกว้างของเส้น
6. ตั้งค่า [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) ของเส้น
7. ตั้งค่าสีเส้นสำหรับรูปร่าง
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด PHP ด้านล่างแสดงวิธีจัดรูปแบบ `AutoShape` แบบสี่เหลี่ยมผืนผ้า:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปทรงอัตโนมัติประเภท Rectangle.
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

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)

โค้ด PHP ด้านล่างแสดงวิธีใช้เอฟเฟ็กต์ [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดเป็นพิเศษ, และลบเอฟเฟ็กต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

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

    // ลบเอฟเฟ็กต์สเก็ตช์.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

ค่าที่คืนจาก [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) แสดงถึงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลเอาท์สไลด์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), เข้าถึงเมธอด `getSketchFormat` ของอ็อบเจ็กต์ที่คืนมา, และอ่านค่าของ `getSketchType` ค่าที่มีประสิทธิผลจะสะท้อนการจัดรูปแบบที่ใช้จริงหลังจากสืบทอดถูกแก้ไข:

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

นี่คือตัวเลือกสามประเภทการเชื่อมต่อ:

* โค้ง
* มิตเตอร์
* บีเวล

โดยค่าเริ่มต้น เมื่อ PowerPoint เชื่อมเส้นสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) จะใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณวาดรูปร่างที่มีมุมคมคุณอาจเลือกใช้ตัวเลือก **Miter**

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

โค้ด PHP ด้านล่างแสดงวิธีที่สี่เหลี่ยมผืนผ้า 3 รูป (ตามภาพด้านบน) ถูกสร้างโดยใช้การตั้งค่าประเภทการเชื่อมต่อ Miter, Bevel, และ Round:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติ 3 รูปประเภท Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับแต่ละรูปร่างสี่เหลี่ยม.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // ตั้งค่าความกว้างเส้น.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // ตั้งค่าสไตล์การเชื่อมต่อ.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // เพิ่มข้อความลงในแต่ละสี่เหลี่ยม.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **การเติมไล่สี (Gradient Fill)**

ใน PowerPoint, Gradient Fill เป็นตัวเลือกการจัดรูปแบบที่ช่วยให้คุณสามารถใช้การไล่สีต่อเนื่องไปยังรูปร่างได้ ตัวอย่างเช่น คุณสามารถใช้สีสองสีหรือมากกว่าสีหนึ่งที่ค่อยๆ ผสานเข้าสู่สีอื่น

วิธีการใช้ Gradient Fill กับรูปร่างโดยใช้ Aspose.Slides มีดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) ของรูปร่างเป็น `Gradient`
5. เพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `add` ของคอลเลกชัน gradient stop ที่เปิดให้ใช้โดยคลาส [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/)
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่สีกับวงรี.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // ตั้งค่าทิศทางของไล่สี.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // เพิ่มจุดไล่สีสองจุด.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![วงรีที่มีการไล่สี](gradient-fill.png)

หากไล่สีแสดงผลต่างกันในภาพที่ส่งออกเมื่อเทียบกับใน PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการไล่สีที่จัดเก็บในงานนำเสนอ

## **การเติมลวดลาย (Pattern Fill)**

ใน PowerPoint, Pattern Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณใส่ลวดลายสองสี เช่น จุด, แถบ, ลายตาข่าย หรือ ลายสลับ ลงบนรูปร่าง คุณสามารถเลือกสีกำหนดเองสำหรับสีพื้นหน้าและพื้นหลังของลวดลายได้

Aspose.Slides มีลวดลายที่กำหนดไว้ล่วงหน้าให้เลือกมากกว่า 45 แบบที่คุณสามารถนำไปใช้กับรูปร่างเพื่อเพิ่มความสวยงามของงานนำเสนอ แม้หลังจากเลือกลวดลายที่กำหนดไว้แล้ว คุณยังสามารถระบุสีที่ต้องการให้ใช้ได้

วิธีการใช้ Pattern Fill กับรูปร่างโดยใช้ Aspose.Slides มีดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) ของรูปร่างเป็น `Pattern`
5. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า
6. ตั้งค่า [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) ของลวดลาย
7. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) ของลวดลาย
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // ตั้งค่าสไตล์ลวดลาย.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลวดลาย.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![สี่เหลี่ยมที่มีลวดลาย](pattern-fill.png)

## **การเติมภาพ (Picture Fill)**

ใน PowerPoint, Picture Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกภาพภายในรูปร่าง—โดยใช้ภาพเป็นพื้นหลังของรูปร่าง

วิธีใช้ Aspose.Slides เพื่อใส่ Picture Fill ลงในรูปร่างมีดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) ของรูปร่างเป็น `Picture`
5. ตั้งค่าโหมดการเติมภาพเป็น `Tile` (หรือโหมดอื่นตามต้องการ)
6. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) จากภาพที่ต้องการใช้
7. ส่งภาพไปยังเมธอด `SlidesPicture.setImage`
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

![รูปภาพลอตัส](lotus.png)

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // ตั้งค่าชนิดการเติมเป็น Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // ตั้งค่าโหมดการเติมภาพ.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของงานนำเสนอ.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // ตั้งค่าภาพ.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![รูปร่างที่มีการเติมภาพ](picture-fill.png)

### **ใช้รูปภาพแบบต่อกระเบื้องเป็นพื้นผิว**

หากคุณต้องการตั้งรูปภาพแบบต่อกระเบื้องเป็นเท็กซ์เจอร์และปรับแต่งการทำงานของการต่อกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): กำหนดโหมดการเติมภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุตำแหน่งการจัดเรียงของกระเบื้องภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่ากระเบื้องจะพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): กำหนดระยะชิดแนวนอนของกระเบื้อง (เป็นพอยต์) จากจุดเริ่มต้นของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): กำหนดระยะชิดแนวตั้งของกระเบื้อง (เป็นพอยต์) จากจุดเริ่มต้นของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมผืนผ้า.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปร่างเป็น Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของงานนำเสนอ.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // กำหนดภาพให้กับรูปร่าง.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // กำหนดค่าโหมดการเติมภาพและคุณสมบัติการต่อกระเบื้อง.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![ตัวเลือกการต่อกระเบื้อง](tile-options.png)

## **การเติมสีทึบ (Solid Color Fill)**

ใน PowerPoint, Solid Color Fill เป็นตัวเลือกการจัดรูปแบบที่เติมสีเดียวที่สม่ำเสมอบนรูปร่าง สีพื้นหลังเรียบง่ายนี้จะถูกใช้โดยไม่มีการไล่สี, เท็กซ์เจอร์ หรือ ลวดลาย

วิธีใช้ Solid Color Fill กับรูปร่างโดยใช้ Aspose.Slides มีขั้นตอนดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) ของรูปร่างเป็น `Solid`
5. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // ตั้งค่าสีเติม.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![รูปร่างที่มีการเติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้การเติมสีทึบ, ไล่สี, รูปภาพ หรือเท็กซ์เจอร์บนรูปร่าง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติมได้ ค่าความโปร่งใสที่สูงทำให้รูปร่างดูโปร่งแสงมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่า alpha ของสีที่ใช้สำหรับการเติม วิธีทำมีดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. ตั้งค่า [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) เป็น `Solid`
5. ใช้ `Color` เพื่อกำหนดสีพร้อมความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
6. บันทึกงานนำเสนอ

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมสีทึบ.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งใสเหนือรูปร่างสีทึบ.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปร่างในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อจัดตำแหน่งองค์ประกอบภาพด้วยการจัดแนวหรือตามความต้องการการออกแบบ

เพื่อหมุนรูปร่างบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. ตั้งค่าคุณสมบัติการหมุนของรูปร่างเป็นมุมที่ต้องการ
5. บันทึกงานนำเสนอ

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // รับสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // หมุนรูปร่าง 5 องศา.
    $shape->setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![การหมุนของรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์การขอบแบบ 3D (3D Bevel Effects)**

Aspose.Slides ให้คุณใช้เอฟเฟกต์ bevel 3D กับรูปร่างโดยการกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) 

เพื่อเพิ่มเอฟเฟกต์ bevel 3D ให้กับรูปร่าง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) ของรูปร่างเพื่อระบุการตั้งค่า bevel
5. บันทึกงานนำเสนอ

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

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![เอฟเฟกต์ bevel 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3D**

Aspose.Slides ให้คุณใช้เอฟเฟ็กต์การหมุน 3D กับรูปร่างโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) 

เพื่อใช้การหมุน 3D กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ไปยังสไลด์
4. ใช้ [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) และ [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) เพื่อกำหนดการหมุน 3 มิติ
5. บันทึกงานนำเสนอ

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

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์ขาว-ดำสำหรับรูปร่าง**

เมธอด [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) ระบุว่ารูปร่างแต่ละอันควรถูกเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดขาว-ดำ มันไม่ได้เปิดใช้งานการแสดงผลขาว-ดำเอง และไม่ได้เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับให้ใช้สีเดียว, `Color` รักษาสีปกติ, และ `Hidden` ไม่แสดงรูปร่างในโหมดขาว-ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

โค้ด PHP ด้านล่างสร้างรูปร่างสีและทำให้แสดงเป็นสีเทาในโหมดแสดงผลขาว-ดำ:

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

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ด้านล่างแสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) ไปยังค่าตั้งต้น:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // รีเซ็ตรูปร่างแต่ละอันบนสไลด์ที่มี placeholder บนเลย์เอาต์.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์ของงานนำเสนอสุดท้ายหรือไม่?**

เพียงเล็กน้อย เท่านั้น ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ของไฟล์ ส่วนพารามิเตอร์ของรูปร่างเช่นสี, เอฟเฟกต์, และไล่สีจะถูกเก็บเป็นเมตาดาทาและเพิ่มขนาดไฟล์แทบไม่มี

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบสำคัญของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทุกอย่างตรงกัน ให้ถือว่าสไตล์เดียวกันและจัดกลุ่มรูปร่างเหล่านั้น ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างที่กำหนดเองในไฟล์แยกเพื่อใช้งานซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ คุณสามารถเก็บรูปร่างตัวอย่างพร้อมสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต คัดลอกรูปร่างที่สไตล์ต้องการ แล้วนำไปใช้ใหม่ตามที่ต้องการ