---
title: จัดการย่อหน้าข้อความ PowerPoint ใน PHP
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการสัญลักษณ์หัวข้อย่อย
- ย่อหน้าการเยื้อง
- การเยื้องลอย
- สัญลักษณ์หัวข้อย่อยของย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อย่อย
- คุณสมบัติของย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java — ปรับปรุงการจัดแนว, ระยะห่างและสไตล์ในงานนำเสนอ PPT, PPTX และ ODP"
---
## **บทนำ**

Aspose.Slides มีคลาสทั้งหมดที่คุณต้องการเพื่อทำงานกับข้อความ PowerPoint, ย่อหน้า และส่วน.

* Aspose.Slides มีคลาส [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่แสดงถึงย่อหน้า วัตถุ `TextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าถูกสร้างผ่านการขึ้นบรรทัดใหม่).
* Aspose.Slides มีคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่แสดงถึงส่วนย่อย วัตถุ `Paragraph` สามารถมีหนึ่งหรือหลายส่วนย่อย (คอลเลกชันของอ็อบเจ็กต์ส่วนย่อย).
* Aspose.Slides มีคลาส [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) เพื่อให้คุณเพิ่มอ็อบเจ็กต์ที่แสดงถึงข้อความและคุณสมบัติการจัดรูปแบบของมัน.

วัตถุ `Paragraph` สามารถจัดการกับข้อความที่มีคุณสมบัติการจัดรูปแบบต่าง ๆ ผ่านอ็อบเจ็กต์ `Portion` ที่อยู่ภายใน.

## **เพิ่มหลายย่อหน้าที่ประกอบด้วยหลายส่วนย่อย**

ขั้นตอนต่อไปนี้แสดงวิธีเพิ่ม TextFrame ที่มี 3 ย่อหน้าและแต่ละย่อหน้ามี 3 ส่วนย่อย:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยอ้างอิงผ่านดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์.
4. รับ ITextFrame ที่เชื่อมกับ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/).
5. สร้างอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) สองตัวและเพิ่มเข้าไปในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/).
6. สร้างอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) สามตัวสำหรับแต่ละ `Paragraph` ใหม่ (สองอ็อบเจ็กต์ Portion สำหรับ Paragraph เริ่มต้น) และเพิ่มแต่ละอ็อบเจ็กต์ `Portion` เข้าไปในคอลเลกชันส่วนย่อยของแต่ละ `Paragraph`.
7. กำหนดข้อความบางส่วนสำหรับแต่ละ Portion.
8. ใช้คุณลักษณะการจัดรูปแบบที่คุณต้องการกับแต่ละ Portion โดยใช้คุณสมบัติการจัดรูปแบบที่เปิดเผยโดยอ็อบเจ็กต์ `Portion`.
9. บันทึกการนำเสนอที่แก้ไขแล้ว.

```php
# สร้างคลาส Presentation ที่เป็นไฟล์ PPTX
$pres = new Presentation();
try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ประเภท Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # เข้าถึง TextFrame ของ AutoShape
    $tf = $ashp->getTextFrame();
    # สร้าง Paragraphs และ Portions ด้วยรูปแบบข้อความที่แตกต่างกัน
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # บันทึก PPTX ไปยังดิสก์
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **จัดการรายการหัวข้อย่อยของย่อหน้า**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและแสดงข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มีหัวข้อย่อยจะอ่านและเข้าใจได้ง่ายเสมอ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยอ้างอิงผ่านดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์ที่เลือก.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/).
7. ตั้งค่า `Type` ของหัวข้อย่อยสำหรับย่อหน้าเป็น `Symbol` และกำหนดอักขระหัวข้อย่อย.
8. กำหนด `Text` ของย่อหน้า.
9. ตั้งค่า `Indent` ของย่อหน้าสำหรับหัวข้อย่อย.
10. กำหนดสีสำหรับหัวข้อย่อย.
11. กำหนดความสูงของหัวข้อย่อย.
12. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าใน `TextFrame`.
13. เพิ่มย่อหน้าที่สองและทำซ้ำกระบวนการตามขั้นตอนที่ 7 ถึง 13.
14. บันทึกการนำเสนอ.

```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
$pres = new Presentation();
try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มและเข้าถึง Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # เข้าถึง TextFrame ของ Autoshape
    $txtFrm = $aShp->getTextFrame();
    # ลบย่อหน้าเริ่มต้น
    $txtFrm->getParagraphs()->removeAt(0);
    # สร้างย่อหน้า
    $para = new Paragraph();
    # ตั้งสไตล์และสัญลักษณ์หัวข้อย่อยของย่อหน้า
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # ตั้งข้อความของย่อหน้า
    $para->setText("Welcome to Aspose.Slides");
    # ตั้งการเยื้องหัวข้อย่อย
    $para->getParagraphFormat()->setIndent(25);
    # ตั้งสีหัวข้อย่อย
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ตั้ง IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของตนเอง

    # ตั้งความสูงของหัวข้อย่อย
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # เพิ่มย่อหน้าไปยัง TextFrame
    $txtFrm->getParagraphs()->add($para);
    # สร้างย่อหน้าที่สอง
    $para2 = new Paragraph();
    # ตั้งประเภทและสไตล์หัวข้อย่อยของย่อหน้า
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # เพิ่มข้อความย่อหน้า
    $para2->setText("This is numbered bullet");
    # ตั้งการเยื้องหัวข้อย่อย
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ตั้ง IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของตนเอง

    # ตั้งความสูงของหัวข้อย่อย
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # เพิ่มย่อหน้าไปยัง TextFrame
    $txtFrm->getParagraphs()->add($para2);
    # บันทึกการนำเสนอที่แก้ไขแล้ว
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **จัดการหัวข้อย่อยรูปภาพ**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและแสดงข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มีรูปภาพเป็นหัวข้อย่อยอ่านง่ายและเข้าใจได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยอ้างอิงผ่านดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/).
7. โหลดภาพใน [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/).
8. ตั้งค่าชนิดของหัวข้อย่อยเป็น [Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/#Picture) และกำหนดภาพ.
9. กำหนด `Text` ของ Paragraph.
10. ตั้งค่า `Indent` ของ Paragraph สำหรับหัวข้อย่อย.
11. กำหนดสีสำหรับหัวข้อย่อย.
12. กำหนดความสูงของหัวข้อย่อย.
13. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าใน `TextFrame`.
14. เพิ่มย่อหน้าที่สองและทำซ้ำกระบวนการตามขั้นตอนก่อนหน้า.
15. บันทึกการนำเสนอที่แก้ไขแล้ว.

```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
$presentation = new Presentation();
try {
    # เข้าถึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);
    # สร้างอินสแตนซ์ของรูปภาพสำหรับหัวข้อย่อย
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # เพิ่มและเข้าถึง Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # เข้าถึง TextFrame ของ Autoshape
    $textFrame = $autoShape->getTextFrame();
    # ลบย่อหน้าเริ่มต้น
    $textFrame->getParagraphs()->removeAt(0);
    # สร้างย่อหน้าใหม่
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # ตั้งสไตล์และรูปภาพหัวข้อย่อยของย่อหน้า
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # ตั้งความสูงของหัวข้อย่อย
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # เพิ่มย่อหน้าไปยัง TextFrame
    $textFrame->getParagraphs()->add($paragraph);
    # บันทึกการนำเสนอเป็นไฟล์ PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # บันทึกการนำเสนอเป็นไฟล์ PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **จัดการหัวข้อย่อยหลายระดับ**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและแสดงข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ หัวข้อย่อยหลายระดับอ่านง่ายและเข้าใจได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยอ้างอิงผ่านดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ในสไลด์ใหม่.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 0.
7. สร้างอินสแตนซ์ย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 1.
8. สร้างอินสแตนซ์ย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 2.
9. สร้างอินสแตนซ์ย่อหน้าที่สี่ผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 3.
10. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าใน `TextFrame`.
11. บันทึกการนำเสนอที่แก้ไขแล้ว.

```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
$pres = new Presentation();
try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มและเข้าถึง Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # เข้าถึง TextFrame ของ Autoshape ที่สร้าง
    $text = $aShp->addTextFrame("");
    # ลบย่อหน้าเริ่มต้น
    $text->getParagraphs()->clear();
    # เพิ่มย่อหน้าแรก
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ตั้งระดับหัวข้อย่อย
    $para1->getParagraphFormat()->setDepth(0);
    # เพิ่มย่อหน้าที่สอง
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ตั้งระดับหัวข้อย่อย
    $para2->getParagraphFormat()->setDepth(1);
    # เพิ่มย่อหน้าที่สาม
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ตั้งระดับหัวข้อย่อย
    $para3->getParagraphFormat()->setDepth(2);
    # เพิ่มย่อหน้าอันดับสี่
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ตั้งระดับหัวข้อย่อย
    $para4->getParagraphFormat()->setDepth(3);
    # เพิ่มย่อหน้าไปยังคอลเลกชัน
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # บันทึกการนำเสนอเป็นไฟล์ PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **จัดการย่อหน้าด้วยรายการลำดับเลขกำหนดเอง**

คลาส [BulletFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/) มีเมธอด [setNumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) และอื่น ๆ ที่ให้คุณจัดการย่อหน้าด้วยการกำหนดลำดับเลขหรือการจัดรูปแบบแบบกำหนดเอง.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่มีย่อหน้า.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) และตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เป็น 2.
7. สร้างอินสแตนซ์ย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 3.
8. สร้างอินสแตนซ์ย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 7.
9. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าใน `TextFrame`.
10. บันทึกการนำเสนอที่แก้ไขแล้ว.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # เข้าถึง TextFrame ของ Autoshape ที่สร้าง
    $textFrame = $shape->getTextFrame();
    # ลบย่อหน้าเริ่มต้นที่มีอยู่
    $textFrame->getParagraphs()->removeAt(0);
    # รายการแรก
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **กำหนดการเยื้องบรรทัดแรกสำหรับย่อหน้า**

ใช้เมธอด [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า เมธอดนี้ย้ายเฉพาะบรรทัดแรกเทียบกับระยะขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปด้านขวา ส่วนบรรทัดที่เหลือจะคงการจัดแนวกับเนื้อหาย่อหน้า.

ใช้ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก.

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่าการเยื้องที่แตกต่างกันเพื่อแสดงว่าการเยื้องบรรทัดแรกส่งผลต่อการจัดวางย่ออย่างไร.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ว่างลงในรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [Indent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) ให้กับแต่ละย่อหน้า.
6. เพิ่มย่อหน้าใน TextFrame.
7. บันทึกการนำเสนอที่แก้ไขแล้ว.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

## **กำหนดการเยื้องลอยสำหรับย่อหน้า**

การเยื้องลอยคือรูปแบบย่อหน้าซึ่งบรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยเมธอด [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/). ตั้งค่าเยื้องเป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อหาย่อหน้า.

โดยปฏิบัติการ, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า, และ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) กำหนดตำแหน่งของบรรทัดแรกเทียบกับขอบซ้ายนั้น. เพื่อสร้างการเยื้องลอย ให้ตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าลบ.

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, เอกสารอ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่บรรทัดที่ต่อเนื่องต้องจัดแนวใต้เนื้อหาย่อหน้าแทนที่ตัวอักษรแรกของบรรทัดแรก.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ว่างลงในรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าและตั้งค่า [MarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginleft/) ให้เป็นค่าบวกสำหรับแต่ละย่อหน้า.
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์การเยื้องลอย.
7. เพิ่มย่อหน้าใน TextFrame.
8. บันทึกการนำเสนอที่แก้ไขแล้ว.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

![การเยื้องลอยของย่อหน้า](hanging_indent.png)

## **จัดการคุณสมบัติ Run สิ้นสุดของย่อหน้า**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. รับอ้างอิงของสไลด์ที่มีย่อหน้าผ่านตำแหน่งของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงในสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ที่มีสองย่อหน้าเข้าไปในสี่เหลี่ยม.
5. ตั้งค่าความสูงของฟอนต์และประเภทฟอนต์สำหรับย่อหน้า.
6. ตั้งค่าคุณสมบัติ End สำหรับย่อหน้า.
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **นำเข้าข้อความ HTML ไปยังย่อหน้า**

Aspose.Slides มีการสนับสนุนที่พัฒนาขึ้นสำหรับการนำเข้าข้อความ HTML ไปยังย่อหน้า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยอ้างอิงผ่านดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ลงในสไลด์.
4. เพิ่มและเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. อ่านไฟล์ HTML ต้นฉบับด้วย TextReader.
7. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/).
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader เข้าไปใน [ParagraphCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/) ของ TextFrame.
9. บันทึกการนำเสนอที่แก้ไขแล้ว.

```php
# สร้างอินสแตนซ์ Presentation ว่าง
$pres = new Presentation();
try {
    # เข้าถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # เพิ่ม TextFrame ให้กับรูปร่าง
    $ashape->addTextFrame("");
    # ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่มเข้ามา
    $ashape->getTextFrame()->getParagraphs()->clear();
    # โหลดไฟล์ HTML ด้วย StreamReader
    $tr = new StreamReader("file.html");
    # เพิ่มข้อความจาก StreamReader ของ HTML ลงใน TextFrame
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # บันทึก Presentation
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **ส่งออกรายการข้อความย่อหน้าเป็น HTML**

Aspose.Slides มีการสนับสนุนที่พัฒนาขึ้นสำหรับการส่งออกข้อความ (ซึ่งอยู่ในย่อหน้า) เป็น HTML.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ.
2. เข้าถึงอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน.
3. เข้าถึงรูปร่างที่มีข้อความที่จะส่งออกเป็น HTML.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปร่าง.
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่.
6. กำหนดดัชนีเริ่มต้นให้กับ StreamWriter และส่งออกย่อหน้าที่คุณต้องการ.

```php
# โหลดไฟล์การนำเสนอ
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # เข้าถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # ดัชนีที่ต้องการ
    $index = 0;
    # เข้าถึงรูปร่างที่เพิ่มเข้ามา
    $ashape = $slide->getShapes()->get_Item($index);
    # สร้างไฟล์ HTML ผลลัพธ์
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # ดึงย่อหน้าแรกเป็น HTML
    # เขียนข้อมูลย่อหน้าไปยัง HTML โดยให้ดัชนีเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจสองตัวอย่างที่แสดงวิธีบันทึกย่อความข้อความที่เป็นอ็อบเจ็กต์ของคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) เป็นภาพ ตัวอย่างทั้งสองจะทำการดึงภาพของรูปร่างที่บรรจุย่อหน้าโดยใช้เมธอด `getImage` จากคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/), คำนวณขอบเขตของย่อหน้าในรูปร่าง, และส่งออกเป็นภาพบิตแมพ วิธีเหล่านี้ช่วยให้คุณสกัดส่วนเฉพาะของข้อความจากการนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจเป็นประโยชน์ต่อการใช้งานในหลายสถานการณ์.

สมมติว่าเรามีไฟล์การนำเสนอชื่อ sample.pptx มีหนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า.

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่างที่ 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ เพื่อทำเช่นนี้ เราจะดึงภาพของรูปร่างจากสไลด์แรกของการนำเสนอแล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่างนั้น จากนั้นย่อหน้าจะถูกวาดใหม่บนภาพบิตแมพใหม่และบันทึกเป็นรูปแบบ PNG วิธีนี้มีประโยชน์เมื่อคุณต้องการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงไว้ซึ่งมิตและการจัดรูปแบบของข้อความ.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // บันทึกรูปร่างไว้ในหน่วยความจำเป็นบิตแมพ.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // สร้างบิตแมพของรูปร่างจากหน่วยความจำ.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // คำนวณขอบเขตของย่อหน้าที่สอง.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // คำนวณพิกัดและขนาดสำหรับภาพผลลัพธ์ (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // ครอบตัดบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าทีเดียว.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

**ตัวอย่างที่ 2**

ในตัวอย่างนี้ เราขยายวิธีการก่อนหน้าโดยเพิ่มปัจจัยการสเกลให้กับภาพย่อหน้า รูปร่างถูกดึงออกจากการนำเสนอและบันทึกเป็นภาพด้วยปัจจัยสเกล `2` ซึ่งทำให้ได้ผลลัพธ์ความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า หลังจากนั้นขอบเขตของย่อหน้าจะถูกคำนวณโดยคำนึงถึงสเกล การสเกลเป็นประโยชน์เป็นพิเศษเมื่อต้องการภาพที่ละเอียดมากขึ้น เช่น สำหรับใช้ในสื่อพิมพ์คุณภาพสูง.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // บันทึกรูปร่างไว้ในหน่วยความจำเป็นบิตแมพพร้อมการสเกล.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // สร้างบิตแมพของรูปร่างจากหน่วยความจำ.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // คำนวณขอบเขตของย่อหน้าที่สอง.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // คำนวณพิกัดและขนาดสำหรับภาพผลลัพธ์ (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // ครอบตัดบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าทีเดียว.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายใน TextFrame ได้อย่างสมบูรณ์หรือไม่?**

ได้. ใช้การตั้งค่าการตัดบรรทัดของ TextFrame ([setWrapText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setwraptext/)) เพื่อปิดการตัดบรรทัด sehingga บรรทัดจะไม่ตัดที่ขอบของเฟรม.

**ฉันจะรับขอบเขตบนสไลด์ที่แม่นยำของย่อหน้าเฉพาะได้อย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบเขตของย่อหน้า (หรือแม้แต่ของ Portion เดียว) เพื่อรู้ตำแหน่งและขนาดที่แม่นยำบนสไลด์.

**การจัดแนวย่อหน้า (ซ้าย/ขวา/กลาง/เต็ม) ถูกควบคุมที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setalignment/) เป็นการตั้งค่าระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/); มันใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของ Portion แต่ละอัน.

**ฉันสามารถตั้งค่าภาษาเพื่อตรวจสอบการสะกดสำหรับส่วนหนึ่งของย่อหน้า (เช่น คำเดียว) ได้หรือไม่?**

ได้. ภาษาถูกตั้งค่าที่ระดับ Portion ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId)) ดังนั้นหลายภาษาอาจอยู่ร่วมกันในย่อหน้าเดียว.