---
title: จัดการรายการที่มีจุดหัวข้อและหมายเลขในงานนำเสนอโดยใช้ PHP
linktitle: จัดการรายการ
type: docs
weight: 60
url: /th/php-java/manage-lists/
keywords:
- จุดหัวข้อ
- รายการที่มีจุดหัวข้อ
- รายการที่มีหมายเลข
- จุดหัวข้อสัญลักษณ์
- จุดหัวข้อรูปภาพ
- จุดหัวข้อกำหนดเอง
- รายการหลายระดับ
- สร้างจุดหัวข้อ
- เพิ่มจุดหัวข้อ
- เพิ่มรายการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการที่มีจุดหัวข้อ, รูปภาพ, หลายระดับและหมายเลขในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides for PHP via Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ช่วยให้คุณสร้างและจัดรูปแบบรายการที่มีจุดหัวข้อและหมายเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการหนึ่งรายการคือย่อหน้าที่การตั้งค่าจุดหัวข้อถูกควบคุมผ่านรูปแบบย่อหน้า

ใช้เมธอด [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเริ่มต้นหลักคือ [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) ซึ่งจะคืนค่าอ็อบเจ็กต์ [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) ด้วยอ็อบเจ็กต์นี้คุณสามารถตั้งค่าชนิดจุดหัวข้อ สัญลักษณ์ รูปภาพ สี ขนาด รูปแบบการนับเลข และหมายเลขเริ่มต้นได้

บทความนี้แสดงวิธี:

- สร้างรายการที่มีจุดหัวข้อด้วยสัญลักษณ์กำหนดเอง
- สร้างจุดหัวข้อเป็นรูปภาพ
- สร้างรายการหลายระดับโดยตั้งค่าความลึกของย่อหน้า
- สร้างรายการที่มีหมายเลข
- ตรวจสอบและเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่
- อ่านค่าจุดหัวข้อและหมายเลขจริงพร้อมกับข้อความย่อหน้า

## **สร้างรายการที่มีจุดหัวข้อ**

เพื่อสร้างรายการที่มีจุดหัวข้อ ให้เพิ่มอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) ลงใน [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) และตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) เป็น [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) จากนั้นคุณสามารถตั้งค่า [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) และ [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) เพื่อควบคุมลักษณะของจุดหัวข้อได้

โค้ด PHP ตัวอย่างต่อไปนี้แสดงวิธีสร้างรายการที่มีจุดหัวข้อในสไลด์:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![สัญลักษณ์จุดหัวข้อ](symbol_bullets.png)

## **สร้างรายการที่มีหมายเลข**

ใช้รายการที่มีหมายเลขเมื่ออันดับของรายการมีความสำคัญ ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) เป็น [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered) คุณยังสามารถเลือกรูปแบบการนับเลขด้วย [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) หรือกำหนดค่าเริ่มต้นด้วย [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1

โค้ด PHP ตัวอย่างต่อไปนี้แสดงวิธีสร้างรายการที่มีหมายเลขในสไลด์:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![จุดหัวข้อแบบหมายเลข](numbered_bullets.png)

## **สร้างจุดหัวข้อเป็นรูปภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์จุดหัวข้อธรรมดาด้วยรูปภาพ จุดหัวข้อแบบภาพทำงานได้ดีที่สุดกับรูปภาพง่าย ๆ ที่ยังคงอ่านได้เมื่อมีขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG โปร่งใสขนาดเล็ก

{{% alert color="info" title="Note" %}}
โดยทั่วไป หากคุณต้องการแทนที่สัญลักษณ์จุดหัวข้อธรรมดาด้วยรูปภาพ ควรเลือกกราฟิกที่มีพื้นหลังโปร่งใส รูปภาพเช่นนี้ทำงานได้ดีเป็นสัญลักษณ์จุดหัวข้อกำหนดเอง

ควรจำไว้ว่า รูปร่างจะถูก缩小至ขนาดเล็กมาก ดังนั้นเราขอแนะนำให้เลือกภาพที่ยังคงชัดเจนและมีประสิทธิภาพในการแสดงเป็นจุดหัวข้อในรายการ
{{% /alert %}}

เพื่อสร้างจุดหัวข้อเป็นรูปภาพ ให้เพิ่มรูปภาพลงใน [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) และกำหนดอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) ที่คืนค่ามาให้กับ [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture) ตั้งค่า [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) เป็น [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) ก่อนทำการกำหนดรูปภาพ

สมมติว่ามีไฟล์ “image.png”:

![รูปภาพสำหรับจุดหัวข้อ](picture_for_bullets.png)

โค้ด PHP ตัวอย่างต่อไปนี้แสดงวิธีสร้างจุดหัวข้อเป็นรูปภาพในสไลด์:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![จุดหัวข้อรูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้เมธอด [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) เพื่อวางรายการในระดับต่าง ๆ ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ด้านในของระดับ 0 และต่อไป

โค้ด PHP ตัวอย่างต่อไปนี้แสดงวิธีสร้างรายการที่มีจุดหัวข้อหลายระดับ:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์:

![รายการหลายระดับ](multilevel_list.png)

## **เปลี่ยนรายการที่มีอยู่**

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) ของมัน คุณสามารถใช้คุณสมบัติเหมือนกับที่ใช้สร้างรายการเพื่อสแกนหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้

โค้ด PHP ตัวอย่างต่อไปนี้เปลี่ยนย่อหน้าแรกในกรอบข้อความให้ใช้สไตล์รายการที่มีหมายเลข:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **อ่านค่าจริงของจุดหัวข้อ**

เมื่อสกัดเนื้อหางานนำเสนอ ควรเก็บตัวบ่งชี้รายการควบคู่กับข้อความย่อหน้า เรียกใช้ [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) แล้วเข้าถึง [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) เพื่อรับรูปแบบจุดหัวข้อที่มีผลใช้ ตรวจสอบ [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) ก่อนอ่านค่า [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)

สำหรับรายการที่มีหมายเลข ให้แยกสามค่าดังต่อไปนี้:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) กำหนดรูปแบบ เช่น ตัวเลขอารบิกตามด้วยจุด หรืออักษรเล็กตามด้วยจุด
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) ระบุหมายเลขเริ่มต้นสำหรับกลุ่มย่อหน้าที่มีหมายเลข
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) คืนค่าตัวบ่งชี้ที่จัดรูปแบบสำหรับย่อหน้านั้น ตัวอย่างเช่น รายการที่เริ่มจาก 5 รายการที่สองจะคืนค่า `6.`

คงค่า [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) ไว้กับแต่ละย่อหน้าเพื่อรักษาระดับการซ้อนกัน ตัวบ่งชี้จริงไม่ได้เข้ารหัสโครงสร้างเต็ม: รายการย่อยอาจคืนค่า `c.` แทนที่จะเป็นป้ายรวมเช่น `6.c.`

ตัวอย่างแบบครบวงจรต่อไปนี้สร้างรายการ บันทึกเป็นงานนำเสนอ แล้วโหลดงานนำเสนอใหม่เพื่อรายงานข้อความของแต่ละย่อหน้า ความลึก ชนิดจุดหัวข้อ และค่าจริง ตัวบ่งชี้รูปภาพสีน้ำเงินขนาดเล็กถูกสร้างจาก SVG ภายในบรรทัด

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // สร้างตัวบ่งชี้รูปภาพโดยไม่มีไฟล์ภาพภายนอก.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

รายการต้นทางแสดงด้านล่าง

![รายการเริ่มที่ 5 รายการย่อยอักษรและตัวเลขโรมัน สัญลักษณ์จุดหัวข้อ ย่อหน้าไม่มีจุดหัวข้อ และตัวบ่งชี้รูปภาพสีน้ำเงิน](actual_bullet_values.png)

รายงานสอดคล้องกับตัวบ่งชี้ที่แสดงใน PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

สำหรับ [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) จะคืนค่า `null` ไม่ใช่สตริงเปล่า ต้องจัดการประเภทเหล่านี้แยกต่างหาก: ประเภทแรกไม่มีตัวบ่งชี้ ส่วนประเภทหลังต้องดึงรูปภาพจุดหัวข้อออกมาแยกต่างหาก จุดหัวข้อรูปภาพไม่สามารถสร้างได้โดยการสกัดตัวบ่งชี้ข้อความเพียงอย่างเดียว

## **คำถามที่พบบ่อย**

**สามารถส่งออกรายการที่มีจุดหัวข้อและหมายเลขเป็น PDF หรือรูปภาพได้หรือไม่?**

ใช่ Aspose.Slides รักษารูปแบบรายการเมื่อรูปแบบเป้าหมายสนับสนุนการจัดวางข้อความและคุณสมบัติจุดหัวข้อที่สอดคล้องกัน

**สามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ได้โหลดงานนำเสนอแล้วเข้าถึงย่อหน้าที่ต้องการ ตรวจสอบหรืออัปเดตการตั้งค่า [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) แล้วบันทึกงานนำเสนอ

**รายการสามารถมีข้อความที่ไม่ใช่ละตินได้หรือไม่?**

ได้ ข้อความรายการสามารถมีอักขระ Unicode ดังนั้นคุณสามารถสร้างรายการในงานนำเสนอหลายภาษาได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอรองรับอักขระที่คุณต้องการ