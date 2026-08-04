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
- การเติมแบบไล่สี
- การเติมแบบลาย
- การเติมภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- หมุนรูปร่าง
- เอฟเฟกต์บิลฟ 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน PHP ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้น, และเอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงบนสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณจึงสามารถกำหนดรูปแบบของรูปทรงได้โดยการแก้ไขหรือใช้เอฟเฟกต์บนเส้นรอบรูป นอกจากนี้คุณยังสามารถกำหนดรูปแบบของรูปทรงได้โดยการระบุการตั้งค่าที่ควบคุมการเติมภายในของรูปทรง

![รูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java มีคลาสและเมธอดที่ช่วยให้คุณกำหนดรูปแบบของรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **กำหนดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปทรง ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/php-java/aspose.slides/linestyle/) ของรูปร่าง  
1. ตั้งความกว้างของเส้น  
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/php-java/aspose.slides/linedashstyle/) ของเส้น  
1. ตั้งค่าสีของเส้นสำหรับรูปร่าง  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP ด้านล่างแสดงวิธีกำหนดรูปแบบให้กับ `AutoShape` แบบสี่เหลี่ยม:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // กำหนดสีเติมสำหรับรูปร่างสี่เหลี่ยม
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // กำหนดสีสำหรับเส้นของสี่เหลี่ยม
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เส้นที่กำหนดรูปแบบในพรีเซนเทชัน](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปทรงดูเหมือนวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/lineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/th/php-java/aspose.slides/sketchformat/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/th/php-java/aspose.slides/linesketchtype/)

โค้ด PHP ด้านล่างแสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/th/php-java/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยเจตนา และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/th/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Access the shape's line format and its sketch format.
    // Apply a sketch effect.
    // Read the sketch effect assigned directly to the shape.
    // Remove the sketch effect.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Apply a sketch effect.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Read the sketch effect assigned directly to the shape.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Remove the sketch effect.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

ค่าที่คืนจาก [SketchFormat.getSketchType](https://reference.aspose.com/slides/th/php-java/aspose.slides/sketchformat/) แสดงการตั้งค่าที่กำหนดโดยตรงกับรูปทรง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลเอาท์สไลด์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/lineformat/), เข้าถึงเมธอด `getSketchFormat` ของออบเจกต์ที่คืนค่า และอ่านค่าของ `getSketchType` ค่าที่มีประสิทธิผลจะแสดงการจัดรูปแบบที่ใช้งานจริงหลังจากการสืบทอดถูกแก้ไข:

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

## **กำหนดรูปแบบการเชื่อมต่อเส้น**

ตัวเลือกประเภทการเชื่อมต่อสามประเภทมีดังนี้:

* โค้ง
* มิตเตอร์
* บีเวล

โดยค่าเริ่มต้นเมื่อ PowerPoint เชื่อมต่อสองเส้นที่มุม (เช่นที่มุมของรูปทรง) จะใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณวาดรูปทรงที่มุมแหลมอาจต้องการใช้ตัวเลือก **Miter** แทน

![สไตล์การเชื่อมต่อในพรีเซนเทชัน](join-style-powerpoint.png)

โค้ด PHP ด้านล่างแสดงวิธีสร้างสี่เหลี่ยมสามรูป (ตามภาพด้านบน) ด้วยการตั้งค่าประเภทการเชื่อมต่อ Miter, Bevel, และ Round:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสามรูปประเภท Rectangle
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // กำหนดสีเติมสำหรับแต่ละสี่เหลี่ยม
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // ตั้งค่าความกว้างของเส้น
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // กำหนดสีสำหรับเส้นของแต่ละสี่เหลี่ยม
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // ตั้งค่าสไตล์การเชื่อมต่อ
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // เพิ่มข้อความในแต่ละสี่เหลี่ยม
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **การเติมแบบไล่สี**

ใน PowerPoint การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ช่วยให้คุณใช้การผสมสีต่อเนื่องกับรูปทรง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือหลายสีโดยให้สีหนึ่งค่อย ๆ หายไปเป็นอีกสีหนึ่ง

วิธีการใช้การเติมแบบไล่สีกับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`  
1. ใช้เมธอด `add` ของคอลเลกชัน gradient stop ที่เปิดเผยโดยคลาส [GradientFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/gradientformat/) เพื่อเพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนด  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP ด้านล่างแสดงวิธีใช้เอฟเฟกต์การเติมแบบไล่สีกับวงรี:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Ellipse
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // ใช้รูปแบบการไล่สีกับวงรี
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // ตั้งค่าทิศทางของการไล่สี
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // เพิ่มจุดหยุดการไล่สีสองจุด
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![วงรีที่เติมแบบไล่สี](gradient-fill.png)

## **การเติมลาย**

ใน PowerPoint การเติมลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่น จุด, แถบ, ลายขวาง หรือเช็ก—กับรูปทรง คุณสามารถเลือกสีกำหนดเองสำหรับสีพื้นหน้าและพื้นหลังของลายได้

Aspose.Slides มีลายแบบที่กำหนดไว้ล่วงหน้าเกิน 45 แบบ ที่คุณสามารถใช้กับรูปทรงเพื่อเพิ่มความสวยงามให้กับพรีเซนเทชัน แม้คุณจะเลือกลายที่กำหนดไว้แล้วก็ยังสามารถระบุสีที่ต้องการให้ใช้ได้

วิธีการใช้การเติมลายกับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`  
1. เลือกลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า  
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/patternformat/#getBackColor) ของลาย  
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/patternformat/#getForeColor) ของลาย  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP ด้านล่างแสดงวิธีใช้การเติมลายกับสี่เหลี่ยม:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // ตั้งค่าสไตล์ลาย
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลาย
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมลาย](pattern-fill.png)

## **การเติมภาพ**

ใน PowerPoint การเติมภาพเป็นตัวเลือกการจัดรูปแบบที่ทำให้คุณแทรกรูปภาพภายในรูปทรง—โดยใช้รูปภาพเป็นพื้นหลังของรูปทรง

วิธีการใช้ Aspose.Slides เพื่อเติมภาพลงในรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปทรงเป็น `Picture`  
1. ตั้งค่าโหมดการเติมภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ)  
1. สร้างออบเจกต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) จากภาพที่ต้องการใช้  
1. ส่งภาพไปยังเมธอด `SlidesPicture.setImage`  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

สมมติว่ามีไฟล์ "lotus.png" ที่มีรูปภาพดังนี้:

![รูปภาพ lotus](lotus.png)

โค้ด PHP ด้านล่างแสดงวิธีเติมรูปภาพลงในรูปทรง:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // ตั้งค่าชนิดการเติมเป็น Picture
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // ตั้งค่าโหมดการเติมภาพ
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของพรีเซนเทชัน
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // ตั้งค่าภาพ
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปทรงที่เติมภาพ](picture-fill.png)

### **เรียงรูปภาพเป็นพื้นผิวแบบต่อกระเบื้อง**

หากต้องการตั้งค่ารูปภาพต่อกระเบื้องเป็นพื้นผิวและปรับแต่งพฤติกรรมของการต่อกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งค่าโหมดการเติมภาพ—`Tile` หรือ `Stretch`  
- [setTileAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileAlignment): กำหนดการจัดตำแหน่งของกระเบื้องภายในรูปทรง  
- [setTileFlip](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่ากระเบื้องจะพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่างหรือไม่  
- [setTileOffsetX](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่าออฟเซ็ตแนวนอนของกระเบื้อง (หน่วยเป็น points) จากจุดกำเนิดของรูปทรง  
- [setTileOffsetY](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่าออฟเซ็ตแนวตั้งของกระเบื้อง (หน่วยเป็น points) จากจุดกำเนิดของรูปทรง  
- [setTileScaleX](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์  
- [setTileScaleY](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์  

โค้ดตัวอย่างด้านล่างแสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมที่เติมภาพแบบต่อกระเบื้องและกำหนดตัวเลือกของกระเบื้อง:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปร่างเป็น Picture
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของพรีเซนเทชัน
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // กำหนดภาพให้กับรูปร่าง
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // ตั้งค่าผ่านโหมดการเติมภาพและคุณสมบัติการต่อกระเบื้อง
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ตัวเลือกการต่อกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมสีเดียวที่สม่ำเสมอบนรูปทรง สีพื้นหลังแบบเรียบนี้จะถูกนำไปใช้โดยไม่มีการไล่สี, พื้นผิว, หรือ ลายใด ๆ

วิธีการเติมสีทึบให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปทรงเป็น `Solid`  
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP ด้านล่างแสดงวิธีเติมสีทึบให้กับสี่เหลี่ยมในสไลด์ PowerPoint:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // ตั้งค่าสีเติม
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปทรงที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้สีทึบ, การไล่สี, ภาพหรือพื้นผิวเพื่อเติมรูปทรง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติมได้ ค่าโปร่งใสที่สูงทำให้รูปทรงดูใสมากขึ้นและทำให้พื้นหลังหรือวัตถุที่อยู่ภายใต้มองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่า alpha ในสีที่ใช้สำหรับการเติม วิธีทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) เป็น `Solid`  
1. ใช้ `Color` เพื่อกำหนดสีพร้อมความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)  
1. บันทึกพรีเซนเทชัน  

โค้ด PHP ด้านล่างแสดงวิธีเติมสีโปร่งใสให้กับสี่เหลี่ยม:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมสีทึบ
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งใสทับบนรูปร่างสีทึบ
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปทรงที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปทรงในพรีเซนเทชัน PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องการจัดตำแหน่งองค์ประกอบภาพตามแนวหรือการออกแบบที่ต้องการ

เพื่อหมุนรูปทรงบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ  
1. บันทึกพรีเซนเทชัน  

โค้ด PHP ด้านล่างแสดงวิธีหมุนรูปทรงด้วยมุม 5 องศา:

```php
// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติประเภท Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // หมุนรูปร่างด้วยมุม 5 องศา
    $shape->setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บิลฟ 3D**

Aspose.Slides ช่วยให้คุณใช้เอฟเฟกต์บิลฟ 3D กับรูปทรงได้โดยการกำหนดค่าคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์บิลฟ 3D ให้กับรูปทรง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/) ของรูปทรงเพื่อระบุการตั้งค่าบิลฟ  
1. บันทึกพรีเซนเทชัน  

โค้ด PHP ด้านล่างแสดงวิธีใช้เอฟเฟกต์บิลฟ 3D กับรูปทรง:

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

    // บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์บิลฟ 3D](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3D**

Aspose.Slides ให้คุณใช้เอฟเฟกต์การหมุน 3D กับรูปทรงโดยการกำหนดค่าคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/)

เพื่อใช้การหมุน 3D กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับออพเจกต์อ้างอิงของสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์  
1. ใช้ [setCameraType](https://reference.aspose.com/slides/th/php-java/aspose.slides/camera/#setCameraType) และ [setLightType](https://reference.aspose.com/slides/th/php-java/aspose.slides/lightrig/#setLightType) เพื่อกำหนดการหมุน 3D  
1. บันทึกพรีเซนเทชัน  

โค้ด PHP ด้านล่างแสดงวิธีใช้เอฟเฟกต์การหมุน 3D กับรูปทรง:

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

    // บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3D](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ด้านล่างแสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของทุกรูปทรงที่มีตัวร่างบน [LayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) ไปยังค่าตั้งต้น:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // รีเซ็ตรูปร่างแต่ละตัวบนสไลด์ที่มี placeholder บนเลเอาต์.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปทรงส่งผลต่อขนาดไฟล์พรีเซนเทชันสุดท้ายหรือไม่?**

ผลกระทบน้อยมาก ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ของไฟล์ ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์, และการไล่สีถูกเก็บเป็นเมตาดาต้าและไม่เพิ่มขนาดไฟล์อย่างมีนัยสำคัญ

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อจะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกัน ให้ถือว่าสไตล์ของพวกมันเหมือนกันและจัดกลุ่มรูปทรงเหล่านั้นเชิงตรรกะ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังเป็นเรื่องง่าย

**ฉันสามารถบันทึกชุดสไตล์รูปทรงที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในพรีเซนเทชันอื่นได้หรือไม่?**

ได้ เก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์เดกหรือไฟล์เทมเพลต .POTX เมื่อสร้างพรีเซนเทชันใหม่ เปิดเทมเพลต, คัดลอกรูปทรงที่สไตล์ไว้ตามต้องการ, แล้วนำการจัดรูปแบบของมันไปใช้ที่จุดที่ต้องการต่อไป