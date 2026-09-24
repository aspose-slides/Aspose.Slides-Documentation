---
title: จัดการย่อหน้าข้อความ PowerPoint ใน PHP
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการสัญลักษณ์หัวข้อ
- ระยะเยื้องย่อหน้า
- การเยื้องแบบลอย
- สัญลักษณ์หัวข้อย่อหน้า
- รายการแบบตัวเลข
- รายการแบบสัญลักษณ์หัวข้อ
- คุณสมบัติจัดย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, สัญลักษณ์หัวข้อ, รายการแบบตัวเลข, ระยะเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java แสดงข้อความเป็นลำดับขั้นของ TextFrame, Paragraph, และ Portion:

* [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ทำหน้าที่เป็นคอนเทนเนอร์ข้อความในรูปร่างและให้เข้าถึงคอลเลกชันของย่อหน้า
* [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) แทนย่อหน้าเดียวใน TextFrame และให้เข้าถึง Portion และการจัดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) แทนส่วนของข้อความภายในย่อหน้า แต่ละ Portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น ย่อหน้าจึงสามารถบรรจุข้อความที่มีฟอนต์ สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลาย Portion

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลาย Portion**

ขั้นตอนต่อไปนี้สร้าง TextFrame ที่มีสามย่อหน้า โดยแต่ละย่อหน้ามีสาม Portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) สี่เหลี่ยมผืนด้านบนสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงนั้น
5. ใช้ย่อหน้าเริ่มต้นและเพิ่ม [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) อีกสองรายการเข้าไปใน TextFrame
6. เพิ่ม [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) จำนวนเพียงพอให้แต่ละย่อหน้ามีสาม Portion ย่อหน้าเริ่มต้นมี Portion เปล่าอยู่แล้วหนึ่งรายการ
7. ตั้งค่าข้อความของแต่ละ Portion
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion::getPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getPortionFormat--)
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง PHP นี้อิมพลีเมนต์ขั้นตอนดังกล่าว:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **สร้างรายการแบบ Bulleted และ Numbered**

### **สร้างรายการแบบ Bulleted หรือ Numbered**

Bullets และการจัดเลขทำให้การสแกนรายการที่เกี่ยวข้องง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการถูกกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงนั้น
5. ลบย่อหน้าเริ่มต้นออกจาก TextFrame
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) สำหรับ bullet สัญลักษณ์
7. ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Symbol](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/) และระบุอักขระ bullet
8. ตั้งค่าข้อความย่อหน้า ระยะย่อหน้า สี bullet และความสูง bullet
9. เพิ่มย่อหน้าลงใน TextFrame
10. สร้างย่อหน้าที่สองและตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Numbered](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/)
11. กำหนดสไตล์ bullet แบ่งเลขและเพิ่มย่อหน้าไปยัง TextFrame
12. บันทึกงานนำเสนอ

ตัวอย่าง PHP นี้สร้าง bullet สัญลักษณ์และ bullet แบบเลข:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **ใช้ Picture Bullets**

Picture bullets ให้คุณใช้ภาพกำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของมัน
4. ลบย่อหน้าเริ่มต้นออกจาก TextFrame
5. โหลดภาพ bullet แล้วเพิ่มเข้าไปในคอลเลกชันภาพของงานนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) และตั้งค่าข้อความของมัน
7. ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/)
8. กำหนดภาพผ่าน [BulletFormat::getPicture](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#getPicture--) และตั้งค่าความสูง bullet
9. เพิ่มย่อหน้าลงใน TextFrame
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง PHP นี้สร้าง picture bullet:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **สร้าง Multilevel List**

ตั้งค่า [ParagraphFormat::setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDepth-short-) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึกเป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งรายการ
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แล้วลบย่อหน้าเริ่มต้นออกจาก TextFrame ของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์ bullet ให้แต่ละรายการ
4. ตั้งค่าค่า [ParagraphFormat::setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDepth-short-) ของพวกมันเป็น `0`, `1`, `2` และ `3`
5. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame แล้วบันทึกงานนำเสนอ

ตัวอย่าง PHP นี้สร้างรายการ bulleted สี่ระดับ:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **กำหนดค่าเริ่มต้นของรายการเลขให้เป็นค่าแบบกำหนดเอง**

ใช้ [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าแบบเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ไปยังสไลด์หนึ่งรายการ
2. ลบย่อหน้าเริ่มต้นออกจาก TextFrame ของรูปทรง
3. สร้างย่อหน้าเลขสามรายการ
4. ตั้งค่า [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) เป็น `2`, `3` และ `7` สำหรับย่อหน้าแต่ละรายการ
5. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame และบันทึกงานนำเสนอ

ตัวอย่าง PHP นี้กำหนดหมายเลขเริ่มต้นแบบกำหนดเองให้กับแต่ละย่อหน้า:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติก่อนหน้า/หลัง**

### **ตั้งค่า First-Line Indent**

ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายเฉพาะบรรทัดแรกเทียบกับระยะขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปขวา ส่วนบรรทัดที่เหลือคงอยู่ตรงกับเนื้อหาย่อหน้า

ใช้ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เมื่อต้องการย้ายเฉพาะบรรทัดแรกเท่านั้น

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ให้กับ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เพื่อแสดงให้เห็นว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) สี่เหลี่ยมผืนด้านบนสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและตั้งค่าค่า [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) ที่แตกต่างกันให้กับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีการตั้งค่าการเยื้องย่อหน้า:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่า Hanging Indent**

Hanging indent คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ซ้ายกว่าบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) โดยใส่ค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อหาย่อหน้า

โดยปกติ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) จะกำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกเทียบกับระยะขอบนั้น เพื่อสร้าง hanging indent ให้ใส่ค่าบวกกับ `setMarginLeft` แล้วใส่ค่าลบกับ `setIndent`

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอภิธานศัพท์ และย่อหน้าอื่น ๆ ที่บรรทัดต่อเนื่องต้องจัดชิดกับเนื้อหาย่อหน้าแทนที่จะชิดกับอักขระแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) สี่เหลี่ยมผืนด้านบนสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและใส่ค่าบวกให้กับ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) สำหรับแต่ละย่อหน้า
6. ใส่ค่าลบให้กับ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เพื่อสร้างเอฟเฟกต์ hanging indent
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีการตั้งค่า hanging indent ให้กับย่อหน้า:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![การเยื้องลบย่อหน้าของย่อหน้า](hanging_indent.png)

### **ตั้งค่า End Paragraph Run Properties**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่าง PHP ด้านล่างกำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายจบของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่งรายการ
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แล้วลบย่อหน้าเริ่มต้นของมัน
3. สร้างย่อหน้าสองรายการและเพิ่ม Portion ข้อความให้กับแต่ละย่อหน้า
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของย่อหน้าที่สอง
5. ตั้งค่า [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) และ [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-)
6. กำหนดรูปแบบด้วย [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) แล้วบันทึกงานนำเสนอ

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **นับจำนวนบรรทัดที่เรนเดอร์แล้ว**

ใช้ [Paragraph::getLinesCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getLinesCount--) เพื่อคีย์จำนวนบรรทัดที่ย่อหน้าครอบครองหลังจากการจัดวางข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ โดยข้อมูลนี้มีประโยชน์ในการตรวจสอบความยาวของข้อความและการจัดวางในแม่แบบงานนำเสนอ

ย่อหน้าเป็นรายการหนึ่งใน [TextFrame::getParagraphs](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParagraphs--) และอาจครอบคลุมหลายบรรทัดที่เรนเดอร์ การใส่การตัดบรรทัดโดยตรงภายในย่อหน้าจะบังคับให้ขึ้นบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่ใช้ได้โดยไม่ต้องแทรกอักขระตัดบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระตัดบรรทัดจึงไม่ได้ให้จำนวนบรรทัดที่เรนเดอร์ได้

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ นับบรรทัดของมัน แคบรูปทรง แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า การตัดบรรทัดเปิดใช้งานและการปรับอัตโนมัติปิดเพื่อให้ความกว้างของรูปทรงควบคุมการตัดบรรทัดโดยไม่ทำให้ข้อความหดหรือรูปทรงเปลี่ยนขนาด มิติของรูปทรงเป็นจุดสุดท้าย ตัวอย่างยังเพิ่มย่อหน้าอีกหนึ่งรายการและรวมจำนวนบรรทัดทั้งหมดใน TextFrame

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

ด้วยข้อความและมิตินี้ การแคบรูปทรงจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามฟอนต์ที่มีและการแทนที่ ขนาดฟอนต์ ระยะขอบ การเยื้อง การตัดบรรทัด และการตั้งค่า Autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบแม่แบบ

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นจากคอนเทนเนอร์หรือไม่ ความสูงที่ใช้ได้ ความสูงบรรทัด การเว้นระยะย่อหน้าและบรรทัด และพฤติกรรม Autofit ก็มีส่วนสำคัญด้วย แม้บรรทัดเดียวอาจเกินความกว้างที่ใช้ได้เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML Text ไปยังย่อหน้า**

ใช้ [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลงโครงสร้าง HTML ให้เป็นย่อหน้าและ Portion ใน TextFrame

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/)
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
4. อ่านไฟล์ HTML ต้นฉบับ
5. ส่งสตริง HTML ไปยัง [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง PHP นี้นำเข้า HTML ไปยัง TextFrame:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **ส่งออกข้อความย่อหน้าเป็น HTML**

ใช้ [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่มีข้อความ
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงนั้น
4. เรียก [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องส่งออก
5. เขียนสตริง HTML ที่ได้ลงไฟล์

ตัวอย่าง PHP นี้ส่งออกย่อหน้าทั้งหมดจากรูปทรงข้อความแรก:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/#save-java.lang.String-int-) ไม่จำเป็นต้องเรนเดอร์รูปทรงที่บรรจุหรือครอบตัดบิตแมปด้วยตนเอง

[Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--) อาจคืนค่า `null` หากย่อหน้าไม่พบในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

สมมติว่าเรามีไฟล์งานนำเสนอชื่อ sample.pptx ที่มีหนึ่งสไลด์ โดยรูปทรงแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่าง PHP ด้านล่างเรนเดอร์ย่อหน้าที่สองในรูปทรงข้อความปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้เป็น PNG บล็อก `finally` รับประกันว่าภาพจะถูกทำลายอย่างถูกต้อง

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมสเกล**

ใช้โอเวอร์โหลดของ [Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage-float-float-) ที่รับพารามิเตอร์ `$scaleX` และ `$scaleY` เพื่อกำหนดแฟกเตอร์สเกลแนวนอนและแนวตั้ง ตัวอย่าง PHP นี้สร้างตาราง เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงสองเท่าของค่าเริ่มต้น แล้วบันทึกผลเป็นภาพ PNG

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

ค่าฟีเจอร์สเกล `1` คงแกนนั้นไว้ที่ขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองค่า จะทำให้ภาพที่ได้มีความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น ส่งผลให้พิกเซลเพิ่มเป็นสี่เท่า สเกลที่ใหญ่กว่าส่วนใหญ่ให้ข้อความคมชัดสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ฟีเจอร์ที่ต่ำกว่า `1` จะให้ภาพขนาดเล็กลงและรายละเอียดน้อยลง ใช้สเกลเท่ากันเพื่อรักษาสัดส่วนของย่อหน้า; สเกลแนวนอนและแนวตั้งที่แตกต่างกันจะยืดผลลัพธ์แยกกัน

การเรนเดอร์รูปทรงทั้งหมดด้วย [Shape::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage--) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี ขอบ หรือบริบทภาพอื่นของรูปทรง สำหรับภาพที่มีแต่ย่อหน้าเท่านั้น ให้ใช้ [Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายใน TextFrame ได้อย่างสมบูรณ์หรือไม่?**

ได้. ตั้งค่า [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setWrapText-byte-) ให้ปิดการตัดบรรทัดเพื่อไม่ให้บรรทัดตัดที่ขอบของ TextFrame

**ฉันจะรับค่าขอบเขตบนสไลด์ของย่อหน้าที่กำหนดได้อย่างแม่นยำอย่างไร?**

ใช้ [Paragraph::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [Portion::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getRect--) ให้ขอบเขตของ Portion แต่ละอัน

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, กลาง หรือจัดชิด) ถูกควบคุมที่ไหน?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและนำไปใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของ Portion แต่ละส่วน

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) สำหรับ Portion แต่ละส่วน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาพร้อมกัน