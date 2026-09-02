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
- จัดการจุด
- การเยื้องย่อหน้า
- การเยื้องล้อย
- จุดย่อหน้า
- รายการเลขลำดับ
- รายการมีจุด
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วน, จุด, รายการเลขลำดับ, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สำหรับ PHP ผ่าน Java แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ ย่อหน้า และส่วน:

* [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) เป็นตัวเก็บข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า.
* [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) เป็นย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนต่าง ๆ และการจัดรูปแบบระดับย่อหน้า.
* [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) เป็นการไหลของข้อความภายในย่อหน้า แต่ละส่วนสามารถมีข้อความของตนเองและการจัดรูปแบบระดับอักขระ.

ดังนั้น ย่อหน้าสามารถมีข้อความที่มีแบบอักษร สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วน.

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วน**

ขั้นตอนต่อไปนี้จะสร้างกรอบข้อความที่มีสามย่อหน้า แต่ละย่อหน้ามีสามส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แบบสี่เหลี่ยมผืนผ้าลงในสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปร่าง.
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มวัตถุ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) อีกสองรายการลงในกรอบข้อความ.
6. เพิ่มวัตถุ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) จำนวนเพียงพอสำหรับแต่ละย่อหน้าให้มีสามส่วน ย่อหน้าเริ่มต้นมีส่วนที่ว่างเปล่าอยู่แล้วหนึ่งส่วน.
7. กำหนดข้อความของแต่ละส่วน.
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion::getPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getPortionFormat--).
9. บันทึกการนำเสนอที่แก้ไข.

ตัวอย่าง PHP นี้ดำเนินการตามขั้นตอน:

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

## **สร้างรายการแบบมีจุดและลำดับเลข**

### **สร้างรายการแบบมีจุดหรือเลข**

จุดและการนับเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการจะกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/).

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์ที่เลือก.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปร่าง.
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ.
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) สำหรับจุดสัญลักษณ์.
7. ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Symbol](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/) และระบุอักขระของจุด.
8. ตั้งค่าข้อความของย่อหน้า การเยื้อง สีของจุด และความสูงของจุด.
9. เพิ่มย่อหน้าไปยังกรอบข้อความ.
10. สร้างย่อหน้าที่สองและตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Numbered](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/).
11. กำหนดสไตล์ของจุดเลขและเพิ่มย่อหน้าไปยังกรอบข้อความ.
12. บันทึกการนำเสนอ.

ตัวอย่าง PHP นี้สร้างจุดสัญลักษณ์และจุดเลข:

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

### **ใช้จุดรูปภาพ**

จุดรูปภาพทำให้คุณใช้ภาพที่กำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/).
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ.
5. โหลดภาพจุดและเพิ่มลงในคอลเลกชันภาพของการนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/).
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) และตั้งค่าข้อความของมัน.
7. ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/).
8. กำหนดภาพผ่าน [BulletFormat::getPicture](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#getPicture--) และตั้งค่าความสูงของจุด.
9. เพิ่มย่อหน้าไปยังกรอบข้อความ.
10. บันทึกการนำเสนอที่แก้ไข.

ตัวอย่าง PHP นี้สร้างจุดรูปภาพ:

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

### **สร้างรายการหลายระดับ**

ตั้งค่า [ParagraphFormat::setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDepth-short-) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึกเป็น `0`.

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และเข้าถึงสไลด์.
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นจากกรอบข้อความของมัน.
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์จุดของแต่ละย่อหน้า.
4. ตั้งค่าความลึกของพวกมันด้วย [ParagraphFormat::setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDepth-short-) เป็น `0`, `1`, `2` และ `3`.
5. เพิ่มย่อหน้าไปยังกรอบข้อความและบันทึกการนำเสนอ.

ตัวอย่าง PHP นี้สร้างรายการหัวข้อแบบมีจุดสี่ระดับ:

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

### **เริ่มรายการเลขที่ค่าที่กำหนดเอง**

ใช้ [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) เพื่อตั้งหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าแบบเลขลำดับ

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์.
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปร่าง.
3. สร้างย่อหน้าเลขสามรายการ.
4. ตั้งค่า [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) เป็น `2`, `3` และ `7` สำหรับแต่ละย่อหน้าตามลำดับ.
5. เพิ่มย่อหน้าไปยังกรอบข้อความและบันทึกการนำเสนอ.

ตัวอย่าง PHP นี้กำหนดหมายเลขเริ่มต้นที่กำหนดเองให้แต่ละย่อหน้า:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติสิ้นสุด**

### **ตั้งการเยื้องบรรทัดแรก**

ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้ย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตามตำแหน่งของเนื้อหาย่อหน้า

ใช้ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายทั้งย่อหน้า ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เมื่อต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เพื่อแสดงว่าการเยื้องบรรทัดแรกส่งผลต่อการจัดวางของย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แบบสี่เหลี่ยมผืนผ้าลงในสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) ให้กับแต่ละย่อหน้า.
6. เพิ่มย่อหน้าเหล่านั้นไปยังกรอบข้อความ.
7. บันทึกการนำเสนอที่แก้ไข.

โค้ด PHP นี้แสดงวิธีตั้งค่าการเยื้องของย่อหน้า:

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

### **ตั้งการเยื้องล้อย**

การเยื้องล้อยคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วย [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) ให้ค่าติดลบเพื่อย้ายบรรทัดแรกไปซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปฏิบัติ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบซ้ายนั้น หากต้องการเยื้องล้อย ให้ตั้งค่าบวกกับ `setMarginLeft` และค่าลบกับ `setIndent`

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม แหล่งอ้างอิง รายการอภิธานศัพท์ และย่อหน้าอื่น ๆ ที่บรรทัดหักต้องจัดตำแหน่งให้อยู่ใต้เนื้อหาย่อหน้าแทนที่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แบบสี่เหลี่ยมผืนผ้าลงในสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าและตั้งค่า `setMarginLeft` เป็นค่าเป็นบวกสำหรับแต่ละย่อหน้า.
6. ตั้งค่า `setIndent` เป็นค่าลบเพื่อสร้างเอฟเฟ็กต์เยื้องล้อย.
7. เพิ่มย่อหน้าไปยังกรอบข้อความ.
8. บันทึกการนำเสนอที่แก้ไข.

โค้ด PHP นี้แสดงวิธีตั้งค่าการเยื้องล้อยสำหรับย่อหน้า:

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

![การเยื้องล้อยของย่อหน้า](hanging_indent.png)

### **ตั้งคุณสมบัติรันของย่อหน้าสิ้นสุด**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่าง PHP ต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ละตินให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และเข้าถึงสไลด์.
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นของมัน.
3. สร้างย่อหน้าสองรายการและเพิ่มส่วนข้อความลงในแต่ละย่อหน้า.
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/) สำหรับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง.
5. ตั้งค่า [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) และ [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. กำหนดรูปแบบด้วย [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) แล้วบันทึกการนำเสนอ.

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

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้าข้อความ HTML เข้าในย่อหน้า**

ใช้ [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลง markup HTML ให้เป็นย่อหน้าและส่วนภายในกรอบข้อความ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/).
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปร่างและลบย่อหน้าเริ่มต้น.
4. อ่านไฟล์ HTML ต้นฉบับ.
5. ส่งสตริง HTML ไปยัง [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. บันทึกการนำเสนอที่แก้ไข.

ตัวอย่าง PHP นี้นำเข้า HTML ไปยังกรอบข้อความ:

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

ใช้ [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงย่อหน้าเลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ.
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่มีข้อความ.
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปร่าง.
4. เรียก [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก.
5. เขียนสตริง HTML ที่ได้ลงไฟล์.

ตัวอย่าง PHP นี้ส่งออกย่อหน้าทั้งหมดจากรูปข้อความแรก:

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

### **แสดงย่อหน้าเป็นภาพ**

[Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/). บันทึกผลลัพธ์ไปยังไฟล์หรือสตรีมด้วย [IImage::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/#save-java.lang.String-int-). คุณไม่จำเป็นต้องเรนเดอร์รูปร่างที่บรรจุหรือครอบตัดบิทแมปด้วยตนเอง

[Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่ ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้

#### **แสดงย่อหน้าที่สเกลเริ่มต้น**

สมมติว่าเรามีไฟล์ presentation ชื่อ sample.pptx มีสไลด์หนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![The text box with three paragraphs](paragraph_to_image_input.png)

ตัวอย่าง PHP ต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปข้อความปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้เป็น PNG บล็อก `finally` จะทำให้ภาพถูกทำลายอย่างถูกต้อง

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

![ภาพของย่อหน้า](paragraph_to_image_output.png)

#### **แสดงย่อหน้าในเซลล์ตารางพร้อมการปรับสเกล**

ใช้การโอเวอร์โหลดของ [Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage-float-float-) ที่รับพารามิเตอร์ `$scaleX` และ `$scaleY` เพื่อกำหนดปัจจัยสเกลแนวนอนและแนวตั้ง ตัวอย่าง PHP นี้สร้างตาราง เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าเริ่มต้นและบันทึกผลลัพธ์เป็นภาพ PNG

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

ค่าปัจจัยสเกล `1` จะคงแกนไว้ที่ขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองปัจจัยจะทำให้ภาพที่ได้มีความกว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ผลลัพธ์คือภาพที่มีพิกเซลสี่เท่า ปัจจัยที่ใหญ่กว่าโดยทั่วไปจะให้ข้อความที่คมชัดมากขึ้นสำหรับการซูมหรือการส่งออกความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยที่ต่ำกว่า `1` จะให้ภาพที่เล็กลงและรายละเอียดน้อยลง ใช้ปัจจัยเท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่ต่างกันจะยืดขยายผลลัพธ์แยกกัน

การเรนเดอร์รูปร่างทั้งหมดด้วย [Shape::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage--) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี ขอบ หรือบริบทภาพอื่นของรูปร่าง สำหรับภาพที่มีเพียงย่อหน้าเท่านั้น ให้ใช้ [Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--).

## **คำถามที่พบบ่อย**

**ฉันจะปิดการตัดบรรทัดในกรอบข้อความอย่างสมบูรณ์ได้หรือไม่?**

ได้. ตั้งค่า [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setWrapText-byte-) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ถูกตัดที่ขอบของกรอบข้อความ.

**ฉันจะรับขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างแม่นยำอย่างไร?**

ใช้ [Paragraph::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบเขตของย่อหน้า. [Portion::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getRect--) ให้ขอบเขตของส่วนเดี่ยว.

**ที่ไหนที่ควบคุมการจัดแนวของย่อหน้า (ซ้าย, ขวา, กลาง หรือจัดเต็ม)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและใช้กับทั้งย่อหน้าไม่ว่าการจัดรูปแบบของส่วนจะเป็นอย่างไร.

**ฉันสามารถตั้งค่าภาษาการตรวจสอบสำหรับบางส่วนของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) สำหรับส่วนแต่ละส่วน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษา.