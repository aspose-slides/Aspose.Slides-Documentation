---
title: จัดการย่อความข้อความ PowerPoint ใน PHP
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/php-java/manage-paragraph/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการ bullet
- การเยื้องย่อหน้า
- การเยื้องห้อย
- bullet ย่อหน้า
- รายการลำดับเลข
- รายการ bullet
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java — ปรับปรุงการจัดแนว, ระยะห่าง & สไตล์ในงานนำเสนอ PPT, PPTX, และ ODP."
---
## **บทนำ**

Aspose.Slides มีคลาสทั้งหมดที่คุณต้องการเพื่อทำงานกับข้อความ PowerPoint, ย่อหน้า, และส่วน

* Aspose.Slides มีคลาส [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) เพื่อให้คุณสามารถเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของย่อหน้าได้ อ็อบเจ็กต์ `TextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าถูกสร้างผ่านการขึ้นบรรทัดใหม่)
* Aspose.Slides มีคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) เพื่อให้คุณสามารถเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของส่วนได้ อ็อบเจ็กต์ `Paragraph` สามารถมีหนึ่งหรือหลายส่วน (คอลเลกชันของอ็อบเจ็กต์ Portion)
* Aspose.Slides มีคลาส [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) เพื่อให้คุณสามารถเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของข้อความและคุณสมบัติการฟอร์แมตของมันได้

อ็อบเจ็กต์ `Paragraph` สามารถจัดการข้อความที่มีคุณสมบัติการฟอร์แมตต่าง ๆ ผ่านอ็อบเจ็กต์ `Portion` ภายใน

## **เพิ่มหลายย่อหน้าที่มีหลายส่วน**

ขั้นตอนต่อไปนี้แสดงวิธีเพิ่ม TextFrame ที่มี 3 ย่อหน้า และแต่ละย่อหน้ามี 3 ส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงอ้างอิงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมให้กับสไลด์
4. รับ ITextFrame ที่สัมพันธ์กับ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/)
5. สร้างอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) สองอันและเพิ่มลงในคอลเลกชันย่อหน้าของ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/)
6. สร้างอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) สามอันสำหรับแต่ละ `Paragraph` ใหม่ (สองอ็อบเจ็กต์ Portion สำหรับ Paragraph เริ่มต้น) และเพิ่มแต่ละอ็อบเจ็กต์ `Portion` ลงในคอลเลกชันส่วนของแต่ละ `Paragraph`
7. ตั้งค่าข้อความสำหรับแต่ละส่วน
8. ใช้คุณสมบัติการฟอร์แมตที่คุณต้องการกับแต่ละส่วนโดยใช้คุณสมบัติการฟอร์แมตของอ็อบเจ็กต์ `Portion`
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้เป็นการนำขั้นตอนเหล่านั้นไปใช้เพื่อเพิ่มย่อหน้าที่มีส่วน:

```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
$pres = new Presentation();
try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape ประเภทสี่เหลี่ยมผืนผ้า
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # เข้าถึง TextFrame ของ AutoShape
    $tf = $ashp->getTextFrame();
    # สร้าง Paragraphs และ Portions พร้อมรูปแบบข้อความที่แตกต่างกัน
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
    # บันทึก PPTX ลงดิสก์
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **จัดการ Bullet ของย่อหน้า**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าแบบ Bullet จะอ่านและเข้าใจได้ง่ายกว่าเสมอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงอ้างอิงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ให้กับสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าตัวแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/)
7. ตั้งค่า `Type` ของ Bullet ให้เป็น `Symbol` และกำหนดอักขระ Bullet
8. ตั้งค่า `Text` ของย่อหน้า
9. ตั้งค่า `Indent` ของย่อหน้าสำหรับ Bullet
10. ตั้งค่าสีสำหรับ Bullet
11. ตั้งค่าความสูงของ Bullet
12. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
13. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตั้งแต่ 7 ถึง 13
14. บันทึกงานนำเสนอ

โค้ด PHP นี้แสดงวิธีเพิ่ม Bullet ให้กับย่อหน้า:

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
    # ตั้งค่าสไตล์และสัญลักษณ์ bullet ของย่อหน้า
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # ตั้งข้อความของย่อหน้า
    $para->setText("Welcome to Aspose.Slides");
    # ตั้งการเยื้อง bullet
    $para->getParagraphFormat()->setIndent(25);
    # ตั้งค่าสี bullet
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ตั้ง IsBulletHardColor เป็น true เพื่อใช้สี bullet ของตนเอง

    # ตั้งความสูง Bullet
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # เพิ่มย่อหน้าไปยัง TextFrame
    $txtFrm->getParagraphs()->add($para);
    # สร้างย่อหน้าที่สอง
    $para2 = new Paragraph();
    # ตั้งประเภทและสไตล์ bullet ของย่อหน้า
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # เพิ่มข้อความย่อหน้า
    $para2->setText("This is numbered bullet");
    # ตั้งการเยื้อง bullet
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ตั้ง IsBulletHardColor เป็น true เพื่อใช้สี bullet ของตนเอง

    # ตั้งความสูง Bullet
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

## **จัดการ Picture Bullet**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าแบบรูปภาพอ่านและเข้าใจได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงอ้างอิงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ให้กับสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าตัวแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/)
7. โหลดรูปภาพใน [PPImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/ppimage/)
8. ตั้งค่า Bullet type เป็น [Picture](https://reference.aspose.com/slides/th/php-java/aspose.slides/bullettype/#Picture) แล้วกำหนดรูปภาพ
9. ตั้งค่า `Text` ของ Paragraph
10. ตั้งค่า `Indent` ของ Paragraph สำหรับ Bullet
11. ตั้งค่าสีสำหรับ Bullet
12. ตั้งค่าความสูงของ Bullet
13. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
14. เพิ่มย่อหน้าที่สองและทำซ้ำตามขั้นตอนก่อนหน้า
15. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีเพิ่มและจัดการ Picture Bullet:

```php
# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
$presentation = new Presentation();
try {
    # เข้าถึงสไลด์แรก
    $slide = $presentation->getSlides()->get_Item(0);
    # สร้างอินสแตนซ์ของรูปภาพสำหรับ bullet
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
    # ตั้งสไตล์ bullet ของย่อหน้าและรูปภาพ
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # ตั้งความสูง Bullet
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # เพิ่มย่อหน้าไปยัง TextFrame
    $textFrame->getParagraphs()->add($paragraph);
    # บันทึกงานนำเสนอเป็นไฟล์ PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # บันทึกงานนำเสนอเป็นไฟล์ PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **จัดการ Multilevel Bullet**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ Multilevel Bullet อ่านและเข้าใจได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงอ้างอิงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ในสไลด์ใหม่
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) แล้วตั้งค่า depth เป็น 0
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 1
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 2
9. สร้างย่อหน้าที่สี่ผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 3
10. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
11. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีเพิ่มและจัดการ Multilevel Bullet:

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
    # ตั้งระดับ bullet
    $para1->getParagraphFormat()->setDepth(0);
    # เพิ่มย่อหน้าที่สอง
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ตั้งระดับ bullet
    $para2->getParagraphFormat()->setDepth(1);
    # เพิ่มย่อหน้าที่สาม
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ตั้งระดับ bullet
    $para3->getParagraphFormat()->setDepth(2);
    # เพิ่มย่อหน้าที่สี่
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ตั้งระดับ bullet
    $para4->getParagraphFormat()->setDepth(3);
    # เพิ่มย่อหน้าเข้าสู่คอลเลกชัน
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # บันทึกงานนำเสนอเป็นไฟล์ PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **จัดการย่อหน้าด้วยรายการเลขกำหนดเอง**

คลาส [BulletFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/) มีเมธอด [setNumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) และอื่น ๆ ที่ช่วยให้คุณจัดการย่อหน้าด้วยการนับเลขหรือการฟอร์แมตแบบกำหนดเองได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่มีย่อหน้า
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ให้กับสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ AutoShape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) แล้วตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เป็น 2
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` แล้วตั้งค่า `NumberedBulletStartWith` เป็น 3
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` แล้วตั้งค่า `NumberedBulletStartWith` เป็น 7
9. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้แสดงวิธีเพิ่มและจัดการย่อหน้าด้วยการนับเลขหรือการฟอร์แมตแบบกำหนดเอง:

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

## **ตั้งค่า Indent บรรทัดแรกของย่อหน้า**

ใช้เมธอด [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะย้ายบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงที่

ใช้ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและตั้งค่าค่า Indent ต่าง ๆ เพื่อสาธิตว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางของย่อหน้าอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมให้กับสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ที่ว่างเปล่าให้กับรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและตั้งค่า [Indent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) ต่าง ๆ ให้กับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า Indent ของย่อหน้า:

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

## **ตั้งค่า Hanging Indent สำหรับย่อหน้า**

Hanging Indent คือการจัดย่อหน้าในรูปแบบที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วยเมธอด [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) ตั้งค่า Indent เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาของย่อหน้า

โดยปกติ [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setmarginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setindent/) กำหนดตำแหน่งของบรรทัดแรกเทียบกับ MarginLeft เพื่อสร้าง Hanging Indent ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การฟอร์แมตนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอภิศัพท์, และย่อหน้าอื่น ๆ ที่บรรทัดที่ต่อเนื่องต้องจัดตำแหน่งใต้เนื้อหาย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมให้กับสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ที่ว่างเปล่าให้กับรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและตั้งค่า `MarginLeft` (บวก) สำหรับแต่ละย่อหน้า
6. ตั้งค่า `Indent` (ลบ) เพื่อสร้างเอฟเฟ็กต์ Hanging Indent
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า Hanging Indent สำหรับย่อหน้า:

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

![การเยื้องแบบ Hanging ของย่อหน้า](hanging_indent.png)

## **จัดการ End Paragraph Run Properties**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
1. รับอ้างอิงสไลด์ที่มีย่อหน้าผ่านตำแหน่งของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมให้กับสไลด์
1. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ที่มีสองย่อหน้าให้กับสี่เหลี่ยม
1. ตั้งค่าความสูงของฟอนต์และประเภทฟอนต์สำหรับย่อหน้า
1. ตั้งค่า End properties สำหรับย่อหน้า
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด PHP นี้แสดงวิธีตั้งค่า End properties สำหรับย่อหน้าใน PowerPoint:

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

## **นำเข้า HTML Text เข้าในย่อหน้า**

Aspose.Slides มีการสนับสนุนการนำเข้า HTML Text เข้าในย่อหน้าอย่างเต็มรูปแบบ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)
2. เข้าถึงอ้างอิงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ให้กับสไลด์
4. เพิ่มและเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของ `AutoShape`
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. อ่านไฟล์ HTML ต้นฉบับด้วย TextReader
7. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/)
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader ลงใน [ParagraphCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphcollection/) ของ TextFrame
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด PHP นี้เป็นการดำเนินการตามขั้นตอนการนำเข้า HTML Text ในย่อหน้า:

```php
# สร้างอินสแตนซ์ของการนำเสนอเปล่า
$pres = new Presentation();
try {
    # เข้าถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # เพิ่ม TextFrame ให้กับรูปร่าง
    $ashape->addTextFrame("");
    # ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่มไว้
    $ashape->getTextFrame()->getParagraphs()->clear();
    # โหลดไฟล์ HTML ด้วย StreamReader
    $tr = new StreamReader("file.html");
    # เพิ่มข้อความจาก StreamReader ของ HTML ลงใน TextFrame
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # บันทึกการนำเสนอ
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides มีการสนับสนุนการส่งออกข้อความ (ที่อยู่ในย่อหน้า) ไปเป็น HTML อย่างเต็มรูปแบบ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงอ้างอิงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เข้าถึงรูปร่างที่มีข้อความที่จะส่งออกเป็น HTML
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ของรูปร่าง
5. สร้างอินสแตนซ์ของ `StreamWriter` แล้วเพิ่มไฟล์ HTML ใหม่
6. กำหนดดัชนีเริ่มต้นให้กับ StreamWriter แล้วส่งออกย่อหน้าที่ต้องการ

โค้ด PHP นี้แสดงวิธีส่งออกข้อความย่อหน้า PowerPoint ไปเป็น HTML:

```php
# โหลดไฟล์การนำเสนอ
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # เข้าถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # ดัชนีที่ต้องการ
    $index = 0;
    # เข้าถึงรูปร่างที่เพิ่มไว้
    $ashape = $slide->getShapes()->get_Item($index);
    # สร้างไฟล์ HTML output
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # ดึงย่อหน้าแรกเป็น HTML
    # เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุดัชนีเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
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

ในส่วนนี้ เราจะสำรวจสองตัวอย่างที่แสดงวิธีบันทึกย่อความข้อความที่แสดงโดยคลาส [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) เป็นภาพ ทั้งสองตัวอย่างใช้การเรียก `getImage` ของคลาส [Shape](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/) เพื่อรับภาพของรูปร่างที่มีย่อหน้า, คำนวณขอบเขตของย่อหน้าในรูปร่าง, และส่งออกเป็นภาพบิทแมพ วิธีเหล่านี้ช่วยให้คุณดึงส่วนข้อความเฉพาะจากงานนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจเป็นประโยชน์สำหรับการนำไปใช้ต่อในสถานการณ์ต่าง ๆ

สมมติว่าเรามีไฟล์งานนำเสนอชื่อ sample.pptx ที่มีหนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่าง 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้า ที่สองเป็นภาพ เราจะดึงภาพของรูปร่างจากสไลด์แรกของงานนำเสนอแล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่างนั้น จากนั้นวาดย่อหน้านั้นลงบนบิทแมพใหม่และบันทึกเป็นรูปแบบ PNG วิธีนี้มีประโยชน์เมื่อคุณต้องการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงขนาดและฟอร์แมตของข้อความไว้ครบถ้วน

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // บันทึกรูปทรงในหน่วยความจำเป็นบิตแมพ.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // สร้างบิตแมพของรูปทรงจากหน่วยความจำ.
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

    // ตัดบิตแมพของรูปทรงเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
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

**ตัวอย่าง 2**

ในตัวอย่างนี้ เราจะต่อยอดวิธีก่อนหน้าโดยเพิ่มปัจจัยการสเกลให้กับภาพย่อหน้า รูปร่างจะถูกดึงจากงานนำเสนอและบันทึกเป็นภาพด้วยปัจจัยสเกล `2` ซึ่งช่วยให้ได้ภาพความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าจะถูกคำนวณโดยคำนึงถึงสเกล การสเกลเป็นประโยชน์เมื่อต้องการภาพที่ละเอียดมากขึ้น เช่น การใช้ในวัสดุพิมพ์คุณภาพสูง

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // บันทึกรูปทรงในหน่วยความจำเป็นบิตแมพพร้อมการสเกล.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // สร้างบิตแมพของรูปทรงจากหน่วยความจำ.
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

    // ตัดบิตแมพของรูปทรงเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**ฉันสามารถปิดการเบรคบรรทัดใน TextFrame ได้หรือไม่?**

ได้ ใช้การตั้งค่าการห่อของ TextFrame ([setWrapText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setwraptext/)) เพื่อปิดการห่อบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของเฟรม

**ฉันจะได้ขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบของย่อหน้า (หรือแม้แต่ของ Portion เดียว) เพื่อทราบตำแหน่งและขนาดที่แม่นยำบนสไลด์

**การจัดแนวของย่อหน้า (ซ้าย/ขวา/ศูนย์/เต็ม) ควบคุมที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/setalignment/) เป็นการตั้งค่าระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/) ซึ่งส่งผลต่อทั้งย่อหน้า ไม่ว่าจะมีฟอร์แมตของ Portion แยกต่างหากก็ตาม

**ฉันสามารถตั้งค่าภาษาตรวจสอบการสะกดสำหรับส่วนของย่อหน้าเท่านั้น (เช่น คำเดียว) ได้หรือไม่?**

ได้ ภาษาได้รับการตั้งค่าที่ระดับ Portion ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId)) ทำให้สามารถใช้หลายภาษาในย่อหน้าเดียวได้