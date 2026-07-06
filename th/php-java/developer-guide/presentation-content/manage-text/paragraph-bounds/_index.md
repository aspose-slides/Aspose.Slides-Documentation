---
title: รับขอบเขตย่อหน้าจากงานนำเสนอใน PHP
linktitle: ขอบเขตย่อหน้า
type: docs
weight: 43
url: /th/php-java/paragraph-bounds/
keywords:
- ขอบเขตย่อหน้า
- พิกัดย่อหน้า
- ขนาดย่อหน้า
- กรอบข้อความ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตย่อหน้าใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อเพิ่มประสิทธิภาพการจัดตำแหน่งข้อความในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับขอบเขต, ขนาด, และพิกัดของย่อหน้าใน Aspose.Slides. แสดงวิธีดึงสี่เหลี่ยมผืนผ้าย่อหน้าจาก [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/) ด้วยการใช้ [Paragraph::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/getrect/), วิธีการรับพิกัดย่อหน้าภายในกรอบข้อความของเซลล์ตาราง, และเน้นรายละเอียดสำคัญเช่น หน่วยวัด, ผลของการตัดบรรทัดต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าที่มีประสิทธิผล.

## **รับพิกัดสี่เหลี่ยมผืนผ้าของย่อหน้า**

ใช้ [Paragraph::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/getrect/) เพื่อรับสี่เหลี่ยมผืนผ้าขอบเขตของย่อหน้า。

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **รับขนาดของย่อหน้าภายในกรอบข้อความของเซลล์ตาราง**

เพื่อรับขนาดและพิกัดของ [Paragraph](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/) ในกรอบข้อความของเซลล์ตาราง, ให้ใช้ [Paragraph::getRect](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraph/getrect/). สี่เหลี่ยมที่คืนค่าจะเป็นค่าตามกรอบข้อความของเซลล์ตาราง, ดังนั้นจึงต้องบวกตำแหน่งของตารางและออฟเซ็ตของเซลล์เมื่อคุณต้องการพิกัดระดับสไลด์

ตัวอย่างต่อไปนี้รับขอบเขตของย่อหน้าภายในเซลล์ตารางและวาดสี่เหลี่ยมบนสไลด์เพื่อแสดงขอบเขตเหล่านั้น：

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**พิกัดของย่อหน้าถูกวัดเป็นหน่วยใด?**

พิกัดวัดเป็นหน่วยพอยท์, โดยที่ 1 นิ้วเท่ากับ 72 พอยท์. ค่านี้ใช้กับพิกัดและมิติทั้งหมดบนสไลด์.

**การตัดบรรทัดมีผลต่อขอบเขตของย่อหน้าหรือไม่?**

ใช่. หาก [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/setwraptext/) ถูกเปิดใช้งานสำหรับ [TextFrame](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframe/), ข้อความจะตัดบรรทัดให้พอดีกับความกว้างของพื้นที่, ซึ่งจะเปลี่ยนขอบเขตจริงของย่อหน้า.

**พิกัดของย่อหน้าสามารถแม็พไปยังพิกเซลในภาพที่ส่งออกได้อย่างน่าเชื่อถือหรือไม่?**

ได้. แปลงพอยท์เป็นพิกเซลโดยใช้สูตรนี้: pixels = points × (DPI / 72). ผลลัพธ์ขึ้นอยู่กับ DPI ที่เลือกสำหรับการเรนเดอร์หรือการส่งออก.

**จะดึงพารามิเตอร์การจัดรูปแบบย่อหน้าที่ “effective” โดยคำนึงถึงการสืบทอดสไตล์อย่างไร?**

ใช้ [effective paragraph formatting data structure](/slides/th/php-java/shape-effective-properties/); มันจะคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ระยะห่าง, การตัดบรรทัด, RTL, และอื่น ๆ.