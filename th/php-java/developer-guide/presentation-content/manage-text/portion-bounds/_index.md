---
title: รับขอบเขตส่วนข้อความจากงานนำเสนอใน PHP
linktitle: ขอบเขตส่วนข้อความ
type: docs
weight: 47
url: /th/php-java/portion-bounds/
keywords:
- ขอบเขตส่วนข้อความ
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตส่วนข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

ส่วนข้อความ (text portion) แสดงถึงส่วนย่อยเฉพาะของข้อความภายในย่อหน้าและให้คุณทำงานกับส่วนนั้นได้อย่างอิสระจากเนื้อหารอบข้าง ใน Aspose.Slides สามารถใช้ส่วนข้อความเมื่อคุณต้องการดึงขอบเขตของส่วนย่อยของข้อความ, ใช้การจัดรูปแบบกับเพียงบางส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดขึ้น

บทความนี้แสดงวิธีการรับสี่เหลี่ยมขอบเขตของส่วนข้อความโดยใช้ [Portion::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/getrect/) นอกจากนี้ยังแสดงวิธีการรับพิกัดของจุดเริ่มต้นของส่วนข้อความโดยใช้ [Portion::getCoordinates](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/getcoordinates/) อีกทั้งยังสรุปสถานการณ์ทั่วไปที่เกี่ยวกับส่วนข้อความ เช่น การใส่ลิงก์ไฮเปอร์ลิงก์ให้กับส่วนข้อความเดียว, การทำความเข้าใจว่าการจัดรูปแบบถูกสืบทอดผ่านส่วนข้อความ, ย่อหน้า, กรอบข้อความและธีมอย่างไร, และการจัดการกับกรณีที่ฟอนต์ที่ระบุไม่พร้อมใช้

## **รับขอบเขตของส่วนข้อความ**

ใช้ [Portion::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/getrect/) เพื่อดึงสี่เหลี่ยมขอบเขตของส่วนข้อความ:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **รับพิกัดของส่วนข้อความ**

ใช้ [Portion::getCoordinates](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/getcoordinates/) เพื่อดึงพิกัดของจุดเริ่มต้นของส่วนข้อความ:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ลิงก์ไฮเปอร์ลิงก์ให้กับส่วนของข้อความเพียงบางส่วนในย่อหน้าหนึ่งเดียวได้หรือไม่?**

ได้, คุณสามารถ [assign a hyperlink](/slides/th/php-java/manage-hyperlinks/) ให้กับส่วนข้อความแต่ละส่วน; เฉพาะส่วนนั้นจะเป็นลิงก์ที่คลิกได้, ไม่ใช่ทั้งย่อหน้า.

**การสืบทอดสไตล์ทำงานอย่างไร: ส่วนข้อความจะบังคับอะไรและอะไรถูกนำมาจากย่อหน้าหรือกรอบข้อความ?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงสุด หากคุณสมบัติไม่ได้ตั้งค่าใน [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/), Aspose.Slides จะดึงมาจาก [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/). หากไม่ได้ตั้งค่าในนั้นเช่นกัน, Aspose.Slides จะใช้สไตล์จาก [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) หรือ [theme](https://reference.aspose.com/slides/th/php-java/aspose.slides/theme/).

**จะเกิดอะไรขึ้นถ้าฟอนต์ที่ระบุสำหรับส่วนข้อความไม่มีในเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[Font substitution rules](/slides/th/php-java/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจมีการไหลใหม่: ตัวชี้วัด, การตัดคำ, และความกว้างอาจเปลี่ยนแปลง ซึ่งมีผลต่อการกำหนดตำแหน่งที่แม่นยำ.

**ฉันสามารถตั้งค่าความโปร่งแสงหรือการไล่สีของการเติมข้อความระดับ Portion แยกจากย่อหน้าที่เหลือได้หรือไม่?**

ได้, สีข้อความ, การเติมและความโปร่งแสงในระดับ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) สามารถแตกต่างจากส่วนใกล้เคียงได้.