---
title: กล่องข้อความ
type: docs
weight: 40
url: /th/php-java/examples/elements/text-box/
keywords:
- กล่องข้อความ
- เพิ่มกล่องข้อความ
- เข้าถึงกล่องข้อความ
- ลบกล่องข้อความ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและจัดรูปแบบกล่องข้อความใน PHP ด้วย Aspose.Slides: ตั้งค่าแบบอักษร, การจัดตำแหน่ง, การตัดบรรทัด, การปรับอัตโนมัติ, และลิงก์เพื่อปรับแต่งสไลด์สำหรับ PowerPoint และ OpenDocument."
---
ใน Aspose.Slides, **กล่องข้อความ** แทนด้วย `AutoShape`. เกือบทุกรูปร่างสามารถบรรจุตัวอักษรได้, แต่กล่องข้อความทั่วไปไม่มีการเติมสีหรือเส้นขอบและจะแสดงข้อความเท่านั้น.

คู่มือนี้อธิบายวิธีการเพิ่ม, เข้าถึง, และลบกล่องข้อความโดยใช้โค้ด.

## **เพิ่มกล่องข้อความ**

กล่องข้อความคือเพียง `AutoShape` ที่ไม่มีการเติมสีหรือเส้นขอบและมีข้อความที่จัดรูปแบบไว้. นี่คือวิธีสร้างหนึ่งอัน:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // สร้างรูปร่างสี่เหลี่ยม (ค่าเริ่มต้นคือเติมสีพร้อมขอบและไม่มีข้อความ).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // ลบการเติมสีและขอบเพื่อทำให้ดูเหมือนกล่องข้อความทั่วไป.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // ตั้งค่าการจัดรูปแบบข้อความ.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // กำหนดเนื้อหาข้อความจริง.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **หมายเหตุ:** `AutoShape` ใดก็ได้ที่มี `TextFrame` ไม่ว่างเปล่าสามารถทำหน้าที่เป็นกล่องข้อความได้.

## **เข้าถึงกล่องข้อความตามเนื้อหา**

เพื่อค้นหากล่องข้อความทั้งหมดที่มีคีย์เวิร์ดเฉพาะ (เช่น "Slide"), ให้วนลูปผ่านรูปร่างและตรวจสอบข้อความของพวกมัน:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // เข้าถึงกล่องข้อความแรกบนสไลด์.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // ทำบางอย่างกับกล่องข้อความที่ตรงกัน.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **ลบกล่องข้อความตามเนื้อหา**

ตัวอย่างนี้ค้นหาและลบกล่องข้อความทั้งหมดบนสไลด์แรกที่มีคีย์เวิร์ดเฉพาะ:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **เคล็ดลับ:** ควรสร้างสำเนาของคอลเลกชันรูปร่างก่อนทำการแก้ไขในระหว่างการวนลูปเพื่อหลีกเลี่ยงข้อผิดพลาดการแก้ไขคอลเลกชัน.