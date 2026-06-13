---
title: จัดการส่วนข้อความในงานนำเสนอโดยใช้ PHP
linktitle: ส่วนข้อความ
type: docs
weight: 70
url: /th/php-java/portion/
keywords:
- ส่วนข้อความ
- ส่วนของข้อความ
- พิกัดข้อความ
- ตำแหน่งข้อความ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการจัดการส่วนข้อความในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อเพิ่มประสิทธิภาพและการปรับแต่ง"
---
## **บทนำ**

ส่วนข้อความ (Portion) เป็นตัวแทนของส่วนย่อยเฉพาะของข้อความภายในย่อหน้าและช่วยให้คุณทำงานกับส่วนนั้นได้อย่างอิสระจากเนื้อหารอบข้าง ใน Aspose.Slides, Portion สามารถใช้ได้เมื่อคุณต้องการดึงตำแหน่งของส่วนข้อความ, ใช้การจัดรูปแบบกับเพียงบางส่วนของย่อหน้า, หรือควบคุมพฤติกรรมของข้อความในระดับที่ละเอียดมากขึ้น

## **รับพิกัดของส่วนข้อความ**
เมธอด [**getCoordinates()**](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/getcoordinates/) ถูกเพิ่มเข้าไปในคลาส [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) ซึ่งทำให้สามารถดึงพิกัดของจุดเริ่มต้นของ Portion ได้

```php
  # สร้างคลาส Presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # ปรับโครงสร้างบริบทของงานนำเสนอ
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถใส่ไฮเปอร์ลิงก์ให้กับเพียงส่วนหนึ่งของข้อความในย่อหน้าเดียวได้หรือไม่?**

ใช่, คุณสามารถ [กำหนดไฮเปอร์ลิงก์](/slides/th/php-java/manage-hyperlinks/) ให้กับ Portion เฉพาะส่วนหนึ่ง; เพียงส่วนนั้นเท่านั้นที่จะคลิกได้, ไม่ใช่ทั้งย่อหน้า

**การสืบทอดสไตล์ทำงานอย่างไร: Portion จะลบทับอะไร, และอะไรที่มาจาก Paragraph/TextFrame?**

คุณสมบัติระดับ Portion มีลำดับความสำคัญสูงสุด หากไม่ได้กำหนดคุณสมบัติกับ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/), เอนจินจะรับค่าจาก [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/); หากไม่ได้กำหนดที่นั่นเช่นกัน จะรับจาก [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) หรือสไตล์ของ [theme](https://reference.aspose.com/slides/th/php-java/aspose.slides/theme/)

**จะเกิดอะไรขึ้นหากฟอนต์ที่กำหนดสำหรับ Portion ขาดหายบนเครื่องหรือเซิร์ฟเวอร์เป้าหมาย?**

[กฎการแทนที่ฟอนต์](/slides/th/php-java/font-selection-sequence/) จะถูกนำมาใช้ ข้อความอาจทำการเรียงใหม่: เมตริกซ์, การแยกคำ, และความกว้างอาจเปลี่ยนแปลง ซึ่งมีผลต่อการตำแหน่งที่แม่นยำ

**ฉันสามารถตั้งค่าความโปร่งแสงหรือไล่สีของการเติมข้อความระดับ Portion แยกจากส่วนอื่นของย่อหน้าได้หรือไม่?**

ใช่, สีข้อความ, การเติมสี, และความโปร่งแสงที่ระดับ [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) สามารถแตกต่างจากส่วนที่อยู่ใกล้เคียงได้