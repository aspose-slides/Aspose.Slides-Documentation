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
- เยื้องย่อหน้า
- เยื้องแบบห้อย
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติย่อหน้า
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
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, Portion, สัญลักษณ์หัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้า ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java แสดงข้อความเป็นชั้นของ **TextFrame** , **Paragraph** และ **Portion**:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) เป็นตัวเก็บข้อความในรูปร่างและให้เข้าถึงคอลเลกชันของย่อหน้าต่าง ๆ
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) แสดงย่อหน้าเดียวใน TextFrame และให้เข้าถึง Portion ต่าง ๆ พร้อมการจัดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) เป็นการรันข้อความภายในย่อหน้า แต่ละ Portion สามารถมีการจัดรูปแบบข้อความและอักขระของตนเองได้

ดังนั้น ย่อหน้าจึงสามารถบรรจุข้อความที่มีฟอนต์ สี ขนาด และการจัดรูปแบบอื่น ๆ ต่างกันได้โดยใช้หลาย Portion

## **สร้างและจัดรูปแบบย่อหน้าต่าง ๆ**

สร้างย่อหน้าใน TextFrame ของรูปร่างและใช้ Portion เพื่อจัดรูปแบบรันข้อความแต่ละส่วน ส่วนนี้จะแสดงวิธีการรวมหลาย Portion ภายในแต่ละย่อหน้าและใส่สี ขนาดฟอนต์ และสไตล์ที่แตกต่างกัน

### **สร้างย่อหน้ากับหลาย Portion**

ตัวอย่าง PHP ด้านล่างสร้างย่อหน้า 3 ย่อหน้าซึ่งแต่ละย่อหน้ามี Portion 3 อันในคอลเลกชันที่คืนค่าจาก [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions) ตัวอย่างนี้ใช้ย่อหน้าและ Portion เปล่าเริ่มต้น แล้วเพิ่มย่อหน้าและ Portion ที่เหลือ การจัดรูปแบบทำผ่าน [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat) : Portion แรกของแต่ละย่อหน้ามีสีแดง, ตัวหนา, ขนาด 15 points ; Portion ที่สองเป็นสีน้ำเงิน, ตัวเอียง, ขนาด 18 points ; Portion ที่สามคงการจัดรูปแบบเริ่มต้นไว้:

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

## **สร้างรายการแบบหัวข้อและลำดับเลข**

จัดเรียงข้อความในย่อหน้าให้อยู่ในรายการด้วยสัญลักษณ์ ตัวเลข หรือภาพกำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบหัวข้อ รายการหลายระดับ และการกำหนดหมายเลขเริ่มต้นแบบกำหนดเอง

### **สร้างรายการหัวข้อหรือรายการลำดับเลข**

หัวข้อและการกำหนดลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/)

ตัวอย่าง PHP นี้เพิ่มหัวข้อสัญลักษณ์และรายการลำดับเลขใน TextFrame เดียวกัน [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) เลือกประเภทหัวข้อ ส่วน [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) กำหนดสัญลักษณ์ และ [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) เลือกสไตล์การลำดับ ทั้งสองรายการใช้หัวข้อสีดำ ความสูง 100 เปอร์เซ็นต์ และการเยื้องย่อหน้า 25 points:

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

### **ใช้หัวข้อภาพ**

หัวข้อภาพให้คุณใช้ภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข

ตัวอย่าง PHP นี้เพิ่มภาพลงในคอลเลกชันภาพของการพรีเซนต์เป็น [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) แล้วใช้เป็นหัวข้อย่อหน้า โดยเรียก [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) เพื่อใช้หัวข้อภาพและกำหนดภาพผ่าน [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) ส่วน [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) ตั้งเป็น 100 เปอร์เซ็นต์ เพื่อขนาดหัวข้อสัมพันธ์กับข้อความในย่อหน้า:

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

ตั้งค่า [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) เพื่อจัดย่อหน้าให้อยู่ในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

ตัวอย่าง PHP นี้กำหนดค่า [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) ตั้งแต่ 0 ถึง 3 ให้กับย่อหน้า 4 ย่อหน้า สร้างโครงสร้างชั้นใน TextFrame เดียวกัน ย่อหน้าแต่ละอันใช้หัวข้อสัญลักษณ์ โดยที่ [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) สลับระหว่างหัวข้อกลมและเครื่องหมายขีดเพื่อแยกระดับที่อยู่ติดกัน:

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

### **กำหนดค่าเริ่มต้นของรายการลำดับเลขแบบกำหนดเอง**

ใช้ [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เพื่อตั้งค่าตัวเลขเริ่มต้นของย่อหน้าลำดับเลข

ตัวอย่าง PHP นี้ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) ให้ใช้การลำดับเลขสำหรับย่อหน้า 3 ย่อหน้าและกำหนดค่า [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เป็น 2 , 3 และ 7 ค่าที่เริ่มต้นจะถูกกำหนดแยกตามย่อหน้า ทำให้ตัวเลขที่แสดงข้ามค่าได้:

```php
use aspose\slides\BulletType;
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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติจบย่อหน้า**

ปรับขอบเค้นและการเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดที่ต่อเนื่อง คุณสามารถจัดรูปแบบเครื่องหมายจบย่อหน้าแยกต่างหากจาก Portion ที่มองเห็นได้

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้เมธอด [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) เพื่อควบคุมเยื้องบรรทัดแรกของย่อหน้า การตั้งค่านี้จะขยับเฉพาะบรรทัดแรกเท่านั้นเมื่อเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะย้ายบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงตำแหน่งตามเนื้อหา

ใช้ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) เมื่อต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) เมื่อต้องการย้ายบรรทัดแรกเท่านั้น

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 ย่อหน้ามี [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) เท่ากับ 20 points และค่า [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) เป็น 0 , 20 และ 40 points ตามลำดับ บรรทัดแรกเริ่มที่ระยะห่างเพิ่มขึ้นเรื่อย ๆ ส่วนบรรทัดที่ต่อเนื่องคงขอบซ้ายเดียวกัน:

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

![เยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่าเยื้องแบบห้อย**

เยื้องแบบห้อยคือการจัดวางย่อหน้าโดยที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) ตั้งค่า `Indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปกติ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบซ้ายนั้น เพื่อสร้างเยื้องแบบห้อย ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม การอ้างอิง รายการอภิธานศัพท์ และย่อหน้าอื่น ๆ ที่บรรทัดต่อเนื่องต้องจัดชิดกับเนื้อหาย่อหน้า ไม่ใช่กับอักขระแรกของบรรทัดแรก

ตัวอย่าง PHP ด้านล่างจับคู่ค่า [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) เป็น 40 และ 60 points กับค่า [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) เป็น -20 และ -30 points ในแต่ละย่อหน้า บรรทัดแรกของย่อหน้าที่สองเริ่มอยู่ทางซ้ายของบรรทัดที่ต่อเนื่องมากกว่า:

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

![เยื้องแบบห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติจบย่อหน้า**

เมธอด [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) โดยตั้งค่า [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) เป็น 48 points และ [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) เป็น Times New Roman จากนั้นใส่รูปแบบนี้ให้กับเครื่องหมายจบของย่อหน้าที่ 2 โดยไม่กระทบ Portion ที่มองเห็นได้:

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

## **นับจำนวนบรรทัดที่เรนเดอร์**

สำหรับกฎย่อหน้าที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่จบบรรทัด ให้ดูที่ [Control Line Breaking](/slides/th/php-java/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/php-java/text-formatting/#control-hanging-punctuation)

ใช้ [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) เพื่อนับจำนวนบรรทัดที่ย่อหน้าครอบคลุมหลังจากการจัดวางข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ สิ่งนี้มีประโยชน์เมื่อทำการตรวจสอบความยาวข้อความและการจัดวางในเทมเพลตพรีเซนเทชัน

ย่อหน้าเป็นรายการหนึ่งใน [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) และอาจครอบคลุมหลายบรรทัดที่เรนเดอร์ การใส่การตัดบรรทัดโดยเฉพาะภายในย่อหน้าจะบังคับให้สร้างบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกอักขระการตัดบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระตัดบรรทัดไม่ให้จำนวนบรรทัดที่เรนเดอร์ได้

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ นับบรรทัดของมัน หดรูปทรงลงแล้วแทนที่ข้อความด้วยสตริงสั้นกว่า ตัวอย่างเปิดใช้งานการตัดบรรทัดด้วย [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) และปิดการปรับอัตโนมัติด้วย [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) เพื่อให้ความกว้างของรูปทรงควบคุมการตัดบรรทัดโดยไม่ย่อหรือปรับขนาดข้อความโดยอัตโนมัติ ทุกการวัดใช้ [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) มาตรการรูปทรงเป็น points สุดท้าย ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งอันและรวมจำนวนบรรทัดทั้งหมดของ TextFrame:

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

ด้วยข้อความและขนาดเหล่านี้ การหดรูปทรงทำให้จำนวนบรรทัดเพิ่มขึ้น ขณะที่การแทนที่ข้อความด้วยสตริงสั้นลดจำนวนบรรทัดลง จำนวนที่แน่นอนอาจแตกต่างตามฟอนต์ที่มีอยู่และการแทนที่ ขนาดฟอนต์ ขอบเค้น การเยื้อง การตัดบรรทัดและการตั้งค่า Autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่กำหนดไว้สำหรับสภาพแวดล้อมเป้าหมายเมื่อตรวจสอบเทมเพลต

จำนวนบรรทัดอย่างเดียวไม่บ่งบอกว่าข้อความล้นพื้นที่ของคอนเทนเนอร์หรือไม่ ความสูงที่ใช้ได้ ความสูงของบรรทัด ระยะห่างระหว่างย่อหน้าและบรรทัด รวมถึงพฤติกรรม Autofit ก็สำคัญเช่นกัน; แม้บรรทัดเดียวก็อาจเกินความกว้างที่ใช้ได้หากปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้าสู่พรีเซนเทชันหรือส่งออกย่อหน้าที่มีอยู่เพื่อใช้นอกพรีเซนเทชัน ส่วนนี้ยังแสดงวิธีการเรนเดอร์ย่อหน้าเป็นรูปภาพ รวมถึงย่อหน้าในเซลล์ตาราง

### **นำเข้า HTML ลงในย่อหน้า**

ใช้ [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) เพื่อแปลง markup HTML เป็นย่อหน้าและ Portion ใน TextFrame

ตัวอย่าง PHP นี้อ่าน HTML จากไฟล์และส่ง markup ไปยัง [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) มันลบย่อหน้าเริ่มต้นของ TextFrame เพื่อให้กรอบมีเฉพาะเนื้อหาที่นำเข้า รูปร่างสี่เหลี่ยมทิ้งระยะขอบ 10 points ทุกด้านของสไลด์:

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

ใช้ [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML เมื่อนำข้อความพรีเซนเทชันกลับไปใช้บนเว็บไซต์ คุณอาจต้องการรักษาการเน้นโดยไม่ต้องนำฟอนต์ ขนาด หรือสไตล์กล่องข้อความของพรีเซนเทชันไปด้วย ตั้งค่า [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) เพื่อควบคุมระดับที่เครื่องมือส่งออกจะสืบทอดการจัดรูปแบบ

ดาวน์โหลด [ตัวอย่างพรีเซนเทชัน](text-inheritance.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีรูปทรงข้อความหนึ่งรูปที่มีข้อความ “Inherited text; explicit red 18pt” ข้อมูลอินพุตใช้หลายระดับการจัดรูปแบบโดยเจตนา:

- สไตล์ข้อความเริ่มต้นของพรีเซนเทชันให้ฟอนต์ Calibri ขนาด 28 pt
- สไตล์ข้อความระดับแรกของ TextFrame ให้ข้อความสีน้ำเงินและตัวเอียง
- ย่อหน้ากำหนดข้อความตัวหนาอย่างชัดเจน
- Portion ที่สอง “explicit red 18pt” กำหนดสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างเต็มด้านล่างส่งออกย่อหน้าเดียวกันสามครั้ง โดยส่งผ่าน [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) ไปยังเมธอดส่งออกและบันทึกผลลัพธ์แต่ละไฟล์เป็น HTML‑UTF‑8 แยกไฟล์:

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
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

HTML ที่สร้างขึ้นมี CSS ต่อไปนี้สำหรับ Portion แรก “Inherited text; ” ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติที่สร้างอื่น ๆ ถูกละเว้นเพื่อความชัดเจน

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน ตัวหนา ตัวเอียง ขนาด 28 pt ใน Calibri หากฟอนต์นั้นมี |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน ตัวหนา ตัวเอียง; ฟอนต์และขนาดมาจากหน้าหรือเบราว์เซอร์ |
| `ParagraphOnly.html` | `font-weight:bold` | ตัวหนา; ฟอนต์ ขนาด สีและสไตล์เอียงมาจากหน้าหรือเบราว์เซอร์ |

Portion ที่สองคง `color:#ff0000`, `font-size:18pt` และ `font-weight:bold` ในผลลัพธ์ทั้ง 3 ไฟล์ โดยยังคงเอียงใน `All.html` และ `TextBox.html` แต่ไม่ใช่ใน `ParagraphOnly.html` การจำกัดการสืบทอดจึงไม่ลบการจัดรูปแบบที่กำหนดให้กับย่อหน้าหรือ Portion อย่างชัดเจน

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในสองโหมดที่จำกัด CSS ที่ไม่มีจะถูกเติมด้วยสไตล์ของหน้าเป้าหมายหรือค่าเริ่มต้นของเบราว์เซอร์ ดังนั้นลักษณะที่แสดงขึ้นจะขึ้นกับที่ใช้ HTML

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) คุณไม่จำเป็นต้องเรนเดอร์รูปร่างทั้งหมดหรือครอบตัดบิตแมพด้วยตนเอง

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่ ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนมาหลังการใช้งาน

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

ตัวอย่างใช้พรีเซนเทชันที่มีสไลด์ 1 สไลด์แรกมีรูปร่างข้อความที่มีย่อหน้า 3 ย่อหน้า

![รูปกล่องข้อความที่มีย่อหน้า 3 ย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่ 2 (ดัชนี 1) และเรียก [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) โดยไม่ระบุตัวแปรสเกล ตรวจสอบว่ารูปร่างมีย่อหน้าที่ต้องการและการเรนเดอร์คืนภาพก่อนเรียก [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) เพื่อบันทึกเป็น PNG บล็อก `finally` ทำลายภาพหลังการใช้

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

![รูปภาพย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมสเกล**

ใช้การโอเวอร์โหลดของ [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) ที่รับพารามิเตอร์ `$scaleX` และ `$scaleY` เพื่อกำหนดอัตราสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง เรนเดอร์ย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้นและบันทึกเป็น PNG

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

ค่าอัตราสเกล `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนให้ภาพที่กว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ผลลัพธ์คือสี่เท่าจำนวนพิกเซล ค่าที่มากกว่าจะให้ข้อความคมชัดมากขึ้นสำหรับการขยายหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าต่ำกว่า `1` จะให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ค่าอัตราเท่ากันเพื่อคงอัตราส่วนของย่อหน้า; ค่าแนวนอนและแนวตั้งต่างกันจะยืดรูปภาพตามแกนแต่ละแกน

การเรนเดอร์รูปร่างทั้งหมดด้วย [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องการแสดงการเติมสี เส้นขอบ หรือบริบทภาพอื่น ๆ สำหรับภาพเฉพาะย่อหน้า ให้ใช้ [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติภายใน TextFrame ได้หรือไม่?**

ใช่ ตั้งค่า [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) ให้ปิดการตัดบรรทัด เพื่อให้บรรทัดไม่ตัดที่ขอบของ TextFrame

**ฉันจะดึงขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) เพื่อรับสี่เหลี่ยมขอบของย่อหน้า [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) ให้ขอบของ Portion แยก ๆ

**การจัดแนวย่อหน้า (ซ้าย, ขวา, ศูนย์, จัดเต็ม) ควบคุมที่ไหน?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) เป็นการตั้งค่าระดับย่อหน้าและส่งผลต่อย่อหน้าเต็มโดยไม่คำนึงถึงการจัดรูปแบบ Portion รายบุคคล

เพื่อจัดแนวแนวดิ่งของ Portion ที่มีขนาดฟอนต์ต่างกันในแต่ละบรรทัด ดูที่ [Align Fonts Within a Line](/slides/th/php-java/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนของย่อหน้าได้หรือไม่?**

ได้ ตั้งค่า [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับ Portion แยกเพื่อให้ย่อหน้าหนึ่งมีข้อความหลายภาษา