---
title: รับคุณสมบัติรูปร่างที่มีผลจากงานนำเสนอใน PHP
linktitle: คุณสมบัติที่มีผล
type: docs
weight: 50
url: /th/php-java/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างบีเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงของฟอนต์
- รูปแบบการเติม
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบวิธีที่ Aspose.Slides สำหรับ PHP ผ่าน Java คำนวณและใช้คุณสมบัติรูปร่างที่มีผลเพื่อการแสดงผล PowerPoint อย่างแม่นยำ."
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** และ **effective** ค่า local คือค่าที่ตั้งโดยตรงที่ระดับการจัดรูปแบบเฉพาะ เช่น

1. คุณสมบัติ Portion บนสไลด์
1. สไตล์ข้อความของรูปร่างต้นแบบบนเลย์เอาต์หรือสไลด์มาสเตอร์ เมื่อรูปร่างกรอบข้อความของ Portion มีสไตล์นั้น
1. การตั้งค่าข้อความระดับทั่วโลกในงานนำเสนอ

ค่า local สามารถกำหนดหรือไม่กำหนดได้ที่ระดับใดก็ได้ เมื่อ Aspose.Slides ต้องการการจัดรูปแบบขั้นสุดท้าย “as rendered” มันจะแกะสานโซ่การสืบทอดและคืนค่า **effective** คุณสามารถรับค่าเหล่านั้นโดยเรียกเมธอด `getEffective` บนวัตถุ format ระดับ local

ตัวอย่างต่อไปนี้แสดงวิธีการรับค่า effective ค่า มันสมมติว่า รูปร่างแรกบนสไลด์แรกคือ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่มีกรอบข้อความและอย่างน้อยหนึ่ง Portion

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
ข้อมูลการจัดรูปแบบที่เป็น effective แสดงถึงการจัดรูปแบบที่คำนวณแล้วหลังจากที่ได้ทำการสืบทอดแล้ว ในการนำไปใช้ปัจจุบันบางวัตถุข้อมูลที่เป็น effective ที่ได้จากเมธอดเช่น [PortionFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/geteffective/) อาจถูกเก็บแคชภายใน การเรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบของพาเรนท์หรือที่สืบทอดมาจะทำให้ข้อมูลแคชถูกรีเฟรช และวัตถุที่ได้ก่อนหน้านั้นอาจไม่แสดงสถานะเดิมอีกต่อไป หากต้องการเก็บค่าที่เป็น effective ไว้ใช้ในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการ เช่น ความสูงของฟอนต์ สีเติม รูปแบบฟอนต์ หรือการจัดแนว ไปยังอ็อบเจ็กต์ข้อมูลของคุณเอง
{{% /alert %}}

## **รับคุณสมบัติที่มีผลของกล้อง**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติที่มีผลของกล้อง ข้อมูลที่เป็น effective ที่ได้จาก [ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/geteffective/) จะมีคุณสมบัติกล้องขั้นสุดท้ายสำหรับ [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติที่มีผลของกล้อง มันสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **รับคุณสมบัติที่มีผลของ Light Rig**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติที่มีผลของ Light Rig ข้อมูลที่เป็น effective ที่ได้จาก [ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/geteffective/) จะมีคุณสมบัติ Light Rig ขั้นสุดท้ายสำหรับ [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติที่มีผลของ Light Rig มันสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **รับคุณสมบัติที่มีผลของ Bevel Shape**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติที่มีผลของ bevel รูปร่าง ข้อมูลที่เป็น effective ที่ได้จาก [ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/geteffective/) จะมีคุณสมบัติ relief ของหน้าให้กับ [ThreeDFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติที่มีผลของ bevel ด้านบนของรูปร่าง มันสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **รับคุณสมบัติที่มีผลของ Text Frame**

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติที่มีผลของ Text Frame ข้อมูลที่เป็น effective ที่ได้จาก [TextFrameFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/geteffective/) จะมีคุณสมบัติการจัดรูปแบบของ Text Frame

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติการจัดรูปแบบ Text Frame ที่เป็น effective มันสมมติว่า รูปร่างแรกบนสไลด์แรกคือ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่มีกรอบข้อความ

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **รับคุณสมบัติที่มีผลของ Text Style**

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติที่มีผลของ Text Style ข้อมูลที่เป็น effective ที่ได้จาก [TextStyle.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/textstyle/geteffective/) จะมีคุณสมบัติของ Text Style

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติ Text Style ที่เป็น effective มันสมมติว่า รูปร่างแรกบนสไลด์แรกคือ [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่มีกรอบข้อความ

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **รับค่า Effective Font Height**

โดยใช้ Aspose.Slides คุณสามารถรับค่า font height ที่เป็น effective ตัวอย่างโค้ดต่อไปนี้แสดงว่าค่า font height ของ Portion ที่เป็น effective จะเปลี่ยนแปลงอย่างไรเมื่อมีการตั้งค่าค่า font height ระดับ local ที่ระดับโครงสร้างต่าง ๆ ของงานนำเสนอ

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **รับ Effective Fill Format สำหรับ Table**

โดยใช้ Aspose.Slides คุณสามารถรับการจัดรูปแบบการเติม (Fill) ที่เป็น effective สำหรับส่วนต่าง ๆ ของตาราง ข้อมูลที่เป็น effective ที่ได้จากอ็อบเจ็กต์ format จะมีคุณสมบัติของ [FillFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/) การจัดรูปแบบของ Cell มีลำดับความสำคัญสูงกว่าการจัดรูปแบบของ Row, Row สูงกว่าคอลัมน์, และคอลัมน์สูงกว่าการจัดรูปแบบของตารางทั้งหมด

ผลลัพธ์คือคุณสมบัติของ [CellFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/cellformat/) ที่เป็น effective จะถูกใช้ในการวาดเซลล์ของตาราง ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับ Fill Format ที่เป็น effective สำหรับส่วนต่าง ๆ ของตาราง มันสมมติว่า รูปร่างแรกบนสไลด์แรกคือ [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/)

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**`getEffective` คืนค่าภาพรวมหรือไม่?**

ไม่เสมอไป ข้อมูลที่เป็น effective แสดงการจัดรูปแบบที่คำนวณแล้วหลังจากสืบทอด แต่บางอ็อบเจ็กต์ข้อมูลที่เป็น effective อาจถูกเก็บแคชภายใน การเรียก `getEffective` ครั้งต่อมอาจคำนวณใหม่และรีเฟรชแคช ดังนั้นอ็อบเจ็กต์ที่ได้รับก่อนหน้านี้ไม่ควรถือเป็น snapshot ที่คงที่

**ควรอ่านคุณสมบัติที่เป็น effective อีกครั้งเมื่อไหร่?**

ให้เรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบระดับ local, สไตล์พาเรนท์, การจัดรูปแบบเลย์เอาต์, การจัดรูปแบบมาสเตอร์, หรือค่าเริ่มต้นระดับงานนำเสนอ การเรียกครั้งต่อไปจะประเมินลำดับการสืบทอดใหม่และคืนค่าผลลัพธ์ที่เป็น effective ปัจจุบัน

**การเปลี่ยนหรือเอาออกเลย์เอาต์/มาสเตอร์สไลด์ส่งผลต่อคุณสมบัติที่เป็น effective ที่ได้แล้วหรือไม่?**

ใช่ แต่การเปลี่ยนแปลงจะสะท้อนในการเรียก `getEffective` ครั้งต่อไป หากแหล่งข้อมูลการจัดรูปแบบของพาเรนท์ถูกเปลี่ยนหรือเอาออก ข้อมูลที่เป็น effective ที่ได้ก่อนหน้านั้นอาจล้าสมัย เมื่อเรียก `getEffective` อีกครั้ง Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และค่าฟอนต์ สี ขนาด หรือค่าอื่น ๆ ที่ได้อาจเปลี่ยนแปลง

**สามารถแก้ไขค่าโดยตรงผ่านอ็อบเจ็กต์ข้อมูลที่เป็น effective ได้หรือไม่?**

ไม่ได้ อ็อบเจ็กต์ข้อมูลที่เป็น effective เปิดเผยเฉพาะค่าที่คำนวณแล้ว ให้ทำการเปลี่ยนแปลงในอ็อบเจ็กต์การจัดรูปแบบระดับ local แล้วจึงดึงค่า effective อีกครั้ง

**ถ้าคุณสมบัติไม่ได้ตั้งค่าที่ระดับรูปร่าง ไม่ได้ตั้งในเลย์เอาต์/มาสเตอร์ และไม่ได้ตั้งค่าแบบทั่วโลก จะเกิดอะไรขึ้น?**

ค่าที่เป็น effective จะถูกกำหนดตามกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่ได้จะเป็นส่วนหนึ่งของข้อมูลที่เป็น effective ปัจจุบัน

**จากค่า font ที่เป็น effective ฉันจะทราบได้ว่ากลุ่มระดับใดให้ค่าขนาดหรือแบบอักษร?**

ไม่ได้โดยตรง ข้อมูลที่เป็น effective จะคืนค่าที่สุดท้าย หากต้องการหาต้นทาง ให้ตรวจสอบค่าที่เป็น local ที่ Portion, Paragraph, Text Frame, และ Text Styles ที่ระดับเลย์เอาต์, มาสเตอร์, และงานนำเสนอ เพื่อดูว่าการกำหนดที่ชัดเจนแรกปรากฏที่ไหน

**ทำไมค่าที่เป็น effective บางครั้งดูเหมือนกับค่าที่เป็น local?**

เพราะค่าที่เป็น local กลายเป็นค่าที่สุดท้าย (ไม่ต้องสืบทอดจากระดับที่สูงกว่า) ในกรณีดังกล่าวค่า effective จึงตรงกับค่า local

**ควรใช้คุณสมบัติที่เป็น effective เมื่อใด และควรใช้ค่า local เท่านั้นเมื่อใด?**

ใช้ข้อมูลที่เป็น effective เมื่อต้องการผลลัพธ์ “as rendered” หลังจากการสืบทอดทั้งหมด เช่น การจัดสี การเยื้อง หรือขนาด หากต้องการเก็บค่าดังกล่าวโดยไม่ให้เปลี่ยนแปลงจากการจัดรูปแบบต่อ ๆ ไป ให้คัดลอกคุณสมบัติที่ต้องการไปยังอ็อบเจ็กต์ของคุณเอง หากต้องการเปลี่ยนการจัดรูปแบบที่ระดับใดระดับหนึ่ง ให้ปรับค่า local แล้วหากจำเป็นให้ดึงข้อมูลที่เป็น effective อีกครั้งเพื่อยืนยันผลลัพธ์