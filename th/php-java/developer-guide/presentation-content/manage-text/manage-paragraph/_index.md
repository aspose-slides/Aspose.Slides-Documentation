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
  - จัดการหัวข้อประเด็น
  - การเยื้องย่อหน้า
  - ระยะขอบค้าง
  - หัวข้อประเด็นย่อหน้า
  - รายการลำดับเลข
  - รายการหัวข้อประเด็น
  - คุณสมบัติเยอร์หน้า
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
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า ส่วนต่าง ๆ, จุดหัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java แสดงข้อความเป็นโครงสร้างระดับชั้นของกรอบข้อความ, ย่อหน้า, และส่วน:

* [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) เป็นตัวแทนของคอนเทนเนอร์ข้อความในรูปทรงและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) เป็นตัวแทนของย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนต่าง ๆ และการจัดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) เป็นตัวแทนของส่วนของข้อความภายในย่อหน้า แต่ละส่วนสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้นย่อหน้าจึงสามารถบรรจุข้อความที่มีแบบอักษร, สี, ขนาด, และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วน

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วน**

ขั้นตอนต่อไปนี้สร้างกรอบข้อความที่มีสามย่อหน้า แต่ละย่อหน้ามีสามส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่มรูปทรงสี่เหลี่ยม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มอ็อบเจกต์ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) อีกสองรายการลงในกรอบข้อความ
6. เพิ่มอ็อบเจกต์ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) ทั้งพอสำหรับแต่ละย่อหน้าให้มีสามส่วน ย่อหน้าเริ่มต้นมีส่วนว่างหนึ่งส่วนอยู่แล้ว
7. ตั้งค่าข้อความของแต่ละส่วน
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion::getPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getPortionFormat--)
9. บันทึกการนำเสนอที่แก้ไขแล้ว

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

## **สร้างรายการแบบมีหัวข้อและลำดับเลข**

### **สร้างรายการแบบหัวข้อหรือเลขลำดับ**

หัวข้อและการลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการจะกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรง
5. กำจัดย่อหน้าเริ่มต้นออกจากกรอบข้อความ
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) สำหรับหัวข้อสัญลักษณ์
7. ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Symbol](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/) และกำหนดอักขระหัวข้อ
8. ตั้งค่าข้อความของย่อหน้า, ระยะเยื้อง, สีหัวข้อ, และความสูงหัวข้อ
9. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
10. สร้างย่อหน้าที่สองและตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Numbered](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/)
11. กำหนดสไตล์หัวข้อเลขลำดับและเพิ่มย่อหน้าเข้าไปในกรอบข้อความ
12. บันทึกการนำเสนอ

ตัวอย่าง PHP นี้สร้างหัวข้อสัญลักษณ์และหัวข้อเลขลำดับ:

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

### **ใช้รูปภาพเป็นหัวข้อ**

รูปภาพหัวข้อทำให้คุณใช้ภาพกำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของมัน
4. กำจัดย่อหน้าเริ่มต้นออกจากกรอบข้อความ
5. โหลดภาพหัวข้อและเพิ่มลงในคอลเลกชันภาพของการนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) และตั้งข้อความของมัน
7. ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setType-int-) เป็น [BulletType::Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/)
8. กำหนดภาพผ่าน [BulletFormat::getPicture](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#getPicture--) และตั้งความสูงหัวข้อ
9. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
10. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง PHP นี้สร้างหัวข้อรูปภาพ:

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

ตั้งค่า [ParagraphFormat::setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDepth-short-) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อของแต่ละย่อหน้า
4. ตั้งค่า [ParagraphFormat::setDepth](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setDepth-short-) ของพวกมันเป็น `0`, `1`, `2`, และ `3`
5. เพิ่มย่อหน้าเข้าไปในกรอบข้อความและบันทึกการนำเสนอ

ตัวอย่าง PHP นี้สร้างรายการหัวข้อสี่ระดับ:

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

### **เริ่มรายการลำดับเลขที่ค่าที่กำหนดเอง**

ใช้ [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) เพื่อกำหนดหมายเลขเริ่มต้นสำหรับย่อหน้าลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปทรง
3. สร้างย่อหน้าลำดับเลขสามรายการ
4. ตั้งค่า [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) เป็น `2`, `3`, และ `7` สำหรับย่อหน้าแต่ละรายการ
5. เพิ่มย่อหน้าเข้าไปในกรอบข้อความและบันทึกการนำเสนอ

ตัวอย่าง PHP นี้กำหนดหมายเลขเริ่มต้นที่กำหนดเองให้กับแต่ละย่อหน้า:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติส่วนสิ้นสุด**

### **ตั้งระยะขอบบรรทัดแรก**

ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เพื่อควบคุมระยะขอบบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวามือ ส่วนบรรทัดที่เหลือจะยังคงจัดชิดกับเนื้อหาย่อหน้า

ใช้ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายย่อหน้าเต็มบรรทัด ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรกเท่านั้น

ตัวอย่างด้านล่างสร้างย่อหน้าหลายรายการและกำหนดค่า [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) ที่ต่างกันเพื่อแสดงว่าระยะขอบบรรทัดแรกมีผลต่อการจัดวางย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่มรูปทรงสี่เหลี่ยม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้นออก
5. สร้างย่อหน้าหลายรายการและตั้งค่า [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) ที่ต่างกันสำหรับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
7. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีตั้งระยะขอบบรรทัดแรกของย่อหน้า:

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

![ระยะขอบบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งระยะขอบค้าง**

ระยะขอบค้างคือการจัดวางย่อหน้าโดยบรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) ให้ค่าเป็นลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อหาย่อหน้า

ในทางปฏิบัติ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกเทียบกับขอบนั้น เพื่อสร้างระยะขอบค้าง ให้กำหนดค่าเป็นบวกกับ `setMarginLeft` และค่าเป็นลบกับ `setIndent`

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่บรรทัดพับต้องจัดชิดกับเนื้อหาย่อหน้าแทนที่จะเป็นอักขระแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่มรูปทรงสี่เหลี่ยม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้นออก
5. สร้างย่อหน้าและกำหนดค่าเป็นบวกกับ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) สำหรับแต่ละย่อหน้า
6. กำหนดค่าเป็นลบกับ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setIndent-float-) เพื่อสร้างเอฟเฟกต์ระยะขอบค้าง
7. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
8. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีตั้งระยะขอบค้างสำหรับย่อหน้า:

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

![ระยะขอบค้างของย่อหน้า](hanging_indent.png)

### **ตั้งคุณสมบัติการทำงานของย่อหน้าสิ้นสุด**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่าง PHP ด้านล่างกำหนดขนาดฟอนต์และฟอนต์ลาตินให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) แล้วลบย่อหน้าเริ่มต้นออก
3. สร้างย่อหน้าสองรายการและเพิ่มส่วนข้อความเข้าไป
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/) สำหรับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง
5. ตั้งค่า [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) และ [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-)
6. ใช้ [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) เพื่อนำรูปแบบไปใช้และบันทึกการนำเสนอ

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

## **นับจำนวนบรรทัดที่แสดงผล**

สำหรับกฎของย่อหน้าที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่จบบรรทัด โปรดดู [Control Line Breaking](/slides/th/php-java/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/php-java/text-formatting/#control-hanging-punctuation)

ใช้ [Paragraph::getLinesCount](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getLinesCount--) เพื่อค้นหาจำนวนบรรทัดที่ย่อหน้าครอบคลุมหลังจากการจัดวางข้อความ ซึ่งรวมการตัดบรรทัดอัตโนมัติด้วย วิธีนี้มีประโยชน์เมื่อคุณต้องตรวจสอบความยาวและการจัดวางข้อความในแม่แบบการนำเสนอ

ย่อหน้าเป็นรายการหนึ่งใน [TextFrame::getParagraphs](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/#getParagraphs--) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การใส่การตัดบรรทัดอย่างชัดเจนภายในย่อหน้าจะบังคับให้สร้างบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกการตัดบรรทัดอย่างชัดเจนลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระตัดบรรทัดโดยตรงจะไม่ให้จำนวนบรรทัดที่แสดงผลที่แท้จริง

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับบรรทัด, ลดความกว้างของรูปทรง, แล้วแทนที่ข้อความด้วยสตริงสั้นลง การตัดบรรทัดเปิดใช้งานและการปรับอัตโนมัติปิดไว้เพื่อให้ความกว้างของรูปทรงควบคุมการตัดบรรทัดโดยไม่ย่อขนาดข้อความหรือเปลี่ยนขนาดรูปทรง มิติของรูปทรงใช้หน่วยจุด ในที่สุดตัวอย่างจะเพิ่มย่อหน้าอีกหนึ่งรายการและสรุปจำนวนบรรทัดทั้งหมดในกรอบข้อความ

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

ด้วยข้อความและมิตินี้ การทำให้รูปทรงแคบลงจะเพิ่มจำนวนบรรทัด ส่วนการแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างกันตามฟอนต์ที่มีและการแทนที่ ขนาดฟอนต์ ขอบเขต การเยื้อง การตัดบรรทัดและการตั้งค่า Autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่กำหนดไว้สำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบแม่แบบ

จำนวนบรรทัดโดยตัวมันเองไม่บอกว่าข้อความล้นคอนเทนเนอร์หรือไม่ ความสูงที่มีอยู่, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และการทำงานของ Autofit ก็มีผลเช่นกัน; แม้ว่าจะเป็นบรรทัดเดียวก็อาจเกินความกว้างที่มีอยู่เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML ข้อความไปยังย่อหน้า**

ใช้ [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลงมาร์คอัพ HTML ไปเป็นย่อหน้าและส่วนในกรอบข้อความ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/)
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้นออก
4. อ่านไฟล์ HTML ต้นฉบับ
5. ส่งสตริง HTML ไปยัง [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)
6. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง PHP นี้นำเข้า HTML ลงในกรอบข้อความ:

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

### **ส่งออกรายข้อความย่อหน้าเป็น HTML**

ใช้ [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่มีข้อความ
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปทรง
4. เรียก [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ลงไฟล์

ตัวอย่าง PHP นี้ส่งออกรายย่อหน้าทั้งหมดจากรูปทรงข้อความแรก:

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

[Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--) เรนเดอร์ย่อหน้าแต่ละรายการโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/)。คุณสามารถบันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/#save-java.lang.String-int-) ไม่จำเป็นต้องเรนเดอร์รูปทรงที่บรรจุหรือครอบตัดบิตแมปด้วยตนเอง

[Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

สมมติว่ามีไฟล์การนำเสนอชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปทรงแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่าง PHP ต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปทรงข้อความปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG บล็อก `finally` จะรับประกันว่าภาพถูกทำลายอย่างถูกต้อง

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

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage-float-float-) ที่รับพารามิเตอร์ `$scaleX` และ `$scaleY` เพื่อกำหนดปัจจัยสเกลในแนวนอนและแนวตั้ง ตัวอย่าง PHP นี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, และบันทึกผลลัพธ์เป็นภาพ PNG

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

ค่าปัจจัยสเกล `1` จะทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะทำให้ภาพที่ได้มีความกว้างและความสูงประมาณสองเท่าของขนาดเริ่มต้น ส่งผลให้มีพิกเซลสี่เท่า การใช้ค่าปัจจัยที่ใหญ่กว่าจะทำให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยที่ต่ำกว่า `1` จะให้ภาพขนาดเล็กลงและรายละเอียดน้อยลง ใช้ค่าปัจจัยที่เท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่แตกต่างกันจะทำให้ภาพยืดหรือหดแบบอิสระ

การเรนเดอร์รูปทรงทั้งหมดด้วย [Shape::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage--) ยังคงมีประโยชน์เมื่อเอาต์พุตต้องรวมการเติมสี, เส้นขอบ, หรือบริบทภาพอื่นของรูปทรง แต่สำหรับภาพเฉพาะย่อหน้าให้ใช้ [Paragraph::getImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getImage--) เท่านั้น

## **คำถามที่พบบ่อย**

**Can I completely disable line wrapping inside a text frame?**

ใช่. ตั้งค่า [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/#setWrapText-byte-) เพื่อปิดการตัดบรรทัดให้บรรทัดไม่แตกที่ขอบของกรอบข้อความ

**How can I get the exact on-slide bounds of a specific paragraph?**

ใช้ [Paragraph::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/#getRect--) เพื่อรับสี่เหลี่ยมขอบของย่อหน้า [Portion::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getRect--) ให้ขอบเขตของส่วนแต่ละส่วน

**Where is paragraph alignment (left, right, center, or justify) controlled?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและจะนำไปใช้กับย่อหน้าเต็มไม่ว่าจะแบ่งส่วนอย่างไร

**Can I set the proofing language for part of a paragraph?**

ได้. ตั้งค่า [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) สำหรับแต่ละส่วน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาต่างกันได้