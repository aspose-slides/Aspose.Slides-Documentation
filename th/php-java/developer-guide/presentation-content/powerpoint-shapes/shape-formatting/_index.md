---
title: จัดรูปแบบรูปร่าง PowerPoint ใน PHP
linktitle: การจัดรูปแบบรูปทรง
type: docs
weight: 20
url: /th/php-java/shape-formatting/
keywords:
- จัดรูปแบบรูปทรง
- จัดรูปแบบเส้น
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่สี
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- เติมสีทึบ
- ความโปร่งใสของรูปทรง
- หมุนรูปทรง
- เอฟเฟกต์ bevel 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน PHP ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณสามารถจัดรูปแบบโดยการแก้ไขหรือใช้เอฟเฟกต์กับโครงของเส้น นอกจากนี้ยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมการเติมเนื้อภายในของรูปทรงได้

![รูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java มีคลาสและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปทรงด้วยตัวเลือกเดียวกับที่ใช้ใน PowerPoint

## **Format Lines**

ด้วย Aspose.Slides คุณสามารถกำหนดสไตล์เส้นแบบกำหนดเองสำหรับรูปทรงได้ รายการขั้นตอนต่อไปนี้อธิบายวิธีการทำ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/php-java/aspose.slides/linestyle/) ของรูปทรง
1. ตั้งค่าความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/php-java/aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีเส้นสำหรับรูปทรง
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด PHP ด้านล่างแสดงวิธีจัดรูปแบบ `AutoShape` สี่เหลี่ยมผืนผ้า:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape ประเภทสี่เหลี่ยมผืนผ้า.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปทรงสี่เหลี่ยมผืนผ้า.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // นำรูปแบบไปใช้กับเส้นของสี่เหลี่ยมผืนผ้า.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยมผืนผ้า.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

## **Format Join Styles**

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

โดยค่าเริ่มต้น PowerPoint จะใช้การตั้งค่า **Round** เมื่อต่อเส้นสองเส้นที่มุม (เช่น ที่มุมของรูปทรง) อย่างไรก็ตาม หากคุณวาดรูปทรงที่มีมุมคม คุณอาจต้องการตัวเลือก **Miter** มากกว่า

![รูปแบบการเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

โค้ด PHP ด้านล่างแสดงวิธีสร้างสี่เหลี่ยมผืนผ้าสามรูป (ตามภาพด้านบน) โดยใช้การตั้งค่า Join Type แบบ Miter, Bevel, และ Round:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape สามรูปแบบประเภทสี่เหลี่ยมผืนผ้า.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับแต่ละรูปทรงสี่เหลี่ยมผืนผ้า.
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

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยมผืนผ้า.
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

    // เพิ่มข้อความให้แต่ละสี่เหลี่ยมผืนผ้า.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gradient Fill**

ใน PowerPoint ฟีเจอร์ Gradient Fill ช่วยให้คุณสามารถใส่การไล่สีต่อเนื่องลงในรูปทรงได้ ตัวอย่างเช่น คุณสามารถใส่สองสีหรือมากกว่าที่สีหนึ่งค่อย ๆ ไล่ร่วงเข้าสู่สีอีกสีหนึ่ง

วิธีการใช้ Gradient Fill กับรูปทรงด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`
1. ใช้เมธอด `add` ของคอลเลกชัน GradientStop ในคลาส [GradientFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/gradientformat/) เพื่อเพิ่มสีที่ต้องการสองสีพร้อมระบุตำแหน่ง
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด PHP ด้านล่างแสดงวิธีใช้เอฟเฟกต์ Gradient Fill กับรูปวงรี:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape ประเภท Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบ Gradient กับ Ellipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // ตั้งค่าทิศทางของ Gradient.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // เพิ่มจุดหยุด Gradient สองจุด.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![วงรีที่ใช้ Gradient Fill](gradient-fill.png)

## **Pattern Fill**

ใน PowerPoint ฟีเจอร์ Pattern Fill ช่วยให้คุณสามารถใส่ลวดลายสองสี—เช่น จุด, แถบ, ลายกากบาท หรือ เช็ก—ลงในรูปทรงได้ คุณสามารถเลือกสีพื้นหน้าและพื้นหลังของลวดลายได้ตามต้องการ

Aspose.Slides มีรูปแบบลวดลายที่กำหนดไว้ล่วงหน้ากว่า 45 แบบที่คุณสามารถใช้กับรูปทรงเพื่อทำให้งานนำเสนอของคุณดูน่าสนใจยิ่งขึ้น แม้จะเลือกลวดลายที่กำหนดไว้แล้ว คุณยังสามารถระบุสีที่ต้องการใช้ได้อย่างแม่นยำ

วิธีการใช้ Pattern Fill กับรูปทรงด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`
1. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/patternformat/#getBackColor) ของลวดลาย
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/php-java/aspose.slides/patternformat/#getForeColor) ของลวดลาย
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด PHP ด้านล่างแสดงวิธีใช้ Pattern Fill กับสี่เหลี่ยมผืนผ้า:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ตั้งค่า Fill Type เป็น Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // ตั้งค่าสไตล์ของลวดลาย.
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

ผลลัพธ์:

![สี่เหลี่ยมผืนผ้าที่ใช้ Pattern Fill](pattern-fill.png)

## **Picture Fill**

ใน PowerPoint ฟีเจอร์ Picture Fill ช่วยให้คุณแทรกรูปภาพภายในรูปทรง—โดยใช้รูปภาพเป็นพื้นหลังของรูปทรงนั้น

วิธีการใช้ Aspose.Slides เพื่อใส่ Picture Fill ให้รูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปทรงเป็น `Picture`
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดอื่นตามที่ต้องการ)
1. สร้างออบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/) จากรูปภาพที่ต้องการใช้
1. ส่งภาพไปยังเมธอด `SlidesPicture.setImage`
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมติว่าเรามีไฟล์ "lotus.png" ที่แสดงรูปภาพต่อไปนี้:

![รูป lotus](lotus.png)

โค้ด PHP ด้านล่างแสดงวิธีเติมรูปทรงด้วยรูปภาพ:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // ตั้งค่า Fill Type เป็น Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // ตั้งค่าโหมดการเติมรูปภาพ.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของงานนำเสนอ.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // ตั้งค่ารูปภาพ.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปทรงที่ใช้ Picture Fill](picture-fill.png)

### **Tile Picture As Texture**

หากต้องการตั้งรูปภาพเป็นเทกเจอร์แบบลายกระเบื้องและปรับพฤติกรรมการกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setPictureFillMode): กำหนดโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุตำแหน่งการจัดแนวของกระเบื้องภายในรูปทรง
- [setTileFlip](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมการกลับกระเบื้องแนวนอน, แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่าการเลื่อนกระเบื้องในแนวนอน (points) จากจุดเริ่มของรูปทรง
- [setTileOffsetY](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่าการเลื่อนกระเบื้องในแนวตั้ง (points) จากจุดเริ่มของรูปทรง
- [setTileScaleX](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/th/php-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมผืนผ้าที่ใช้ Picture Fill แบบกระเบื้องและกำหนดตัวเลือกการกระเบื้อง:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape สี่เหลี่ยมผืนผ้า.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // ตั้งค่า Fill Type ของรูปทรงเป็น Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // โหลดภาพและเพิ่มเข้าไปในทรัพยากรของงานนำเสนอ.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // กำหนดภาพให้กับรูปทรง.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // ตั้งค่าโหมดการเติมรูปภาพและคุณสมบัติการกระเบื้อง.
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

ผลลัพธ์:

![ตัวเลือกการกระเบื้อง](tile-options.png)

## **Solid Color Fill**

ใน PowerPoint ฟีเจอร์ Solid Color Fill เติมสีเดียวสม่ำเสมอลงในรูปทรง พื้นหลังสีเรียบนี้จะไม่มีการไล่สี, เทกเจอร์ หรือ ลวดลายใด ๆ

วิธีการใช้ Solid Color Fill กับรูปทรงด้วย Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) ของรูปทรงเป็น `Solid`
1. กำหนดสีเติมที่ต้องการให้กับรูปทรง
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด PHP ด้านล่างแสดงวิธีใช้ Solid Color Fill กับสี่เหลี่ยมผืนผ้าในสไลด์ PowerPoint:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // ตั้งค่า Fill Type เป็น Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // ตั้งค่าสีเติม.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปทรงที่ใช้ Solid Color Fill](solid-color-fill.png)

## **Set Transparency**

ใน PowerPoint เมื่อคุณใช้สีทึบ, Gradient, Picture หรือ Texture Fill กับรูปทรง คุณสามารถตั้งค่าความโปร่งใสเพื่อควบคุมความทึบของการเติมได้ ค่าโปร่งใสที่สูงจะทำให้รูปทรงมองเห็นพื้นหลังหรือออบเจ็กต์ด้านล่างได้มากขึ้น

Aspose.Slides ให้คุณกำหนดระดับความโปร่งใสโดยปรับค่าอัลฟ่าในสีที่ใช้สำหรับเติม วิธีทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color` เพื่อตั้งค่าสีพร้อมความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
1. บันทึกงานนำเสนอ

โค้ด PHP ด้านล่างแสดงวิธีใช้สีเติมที่มีความโปร่งใสกับสี่เหลี่ยมผืนผ้า:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape สี่เหลี่ยมผืนผ้าแบบทึบ.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // เพิ่ม AutoShape สี่เหลี่ยมผืนผ้าพร้อมความโปร่งใสเหนือรูปทรงทึบ.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รูปทรงที่มีความโปร่งใส](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides สามารถหมุนรูปทรงในงานนำเสนอ PowerPoint ได้ ซึ่งมีประโยชน์เมื่อจัดตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือการออกแบบที่ต้องการ

ขั้นตอนการหมุนรูปทรงบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ
1. บันทึกงานนำเสนอ

โค้ด PHP ด้านล่างแสดงวิธีหมุนรูปทรง 5 องศา:

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ดึงสไลด์แรก.
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่ม AutoShape ประเภท Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรง 5 องศา.
    $shape->setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การหมุนรูปทรง](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides ให้คุณเพิ่มเอฟเฟกต์ 3D Bevel ให้กับรูปทรงโดยกำหนดค่าที่คลาส [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/) 

ขั้นตอนการเพิ่มเอฟเฟกต์ 3D Bevel ให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. กำหนดค่าที่คลาส [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/) เพื่อกำหนดการตั้งค่า bevel
1. บันทึกงานนำเสนอ

โค้ด PHP ด้านล่างแสดงวิธีใช้เอฟเฟกต์ 3D Bevel กับรูปทรง:

```php
// สร้างอินสแตนซ์ของคลาส Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // เพิ่มรูปทรงลงในสไลด์.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปทรง.
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

ผลลัพธ์:

![เอฟเฟกต์ 3D Bevel](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides ให้คุณเพิ่มเอฟเฟกต์การหมุน 3D ให้กับรูปทรงโดยกำหนดค่าที่คลาส [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/) 

ขั้นตอนการใช้การหมุน 3D กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนี
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
1. ใช้เมธอด [setCameraType](https://reference.aspose.com/slides/th/php-java/aspose.slides/camera/#setCameraType) และ [setLightType](https://reference.aspose.com/slides/th/php-java/aspose.slides/lightrig/#setLightType) เพื่อกำหนดการหมุน 3D
1. บันทึกงานนำเสนอ

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

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3D](3D-rotation-effect.png)

## **Reset Formatting**

โค้ด Java ด้านล่างแสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาด และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslide/) ให้เป็นค่าเริ่มต้น:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // รีเซ็ตรูปทรงแต่ละอันบนสไลด์ที่มี placeholder บน layout.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

ผลกระทบค่อนข้างน้อย รูปภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ของไฟล์ ส่วนพารามิเตอร์ของรูปทรงเช่น สี, เอฟเฟกต์ และ Gradient จะถูกจัดเก็บเป็นเมตาดาต้าและเพิ่มขนาดไฟล์แทบไม่มีเลย

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อรวมกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกัน ให้ถือว่ารูปทรงมีสไตล์เดียวกันและจัดกลุ่มตรรกะไว้ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงแบบกำหนดเองลงไฟล์แยกเพื่อใช้ใหม่ในงานนำเสนออื่นได้หรือไม่?**

ทำได้ ใช้รูปทรงตัวอย่างที่มีสไตล์ที่ต้องการบันทึกในเทมเพลตสไลด์หรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลตนั้น, คัดลอกรูปทรงที่สไตล์ต้องการแล้วนำไปใช้ใหม่ตามที่ต้องการ