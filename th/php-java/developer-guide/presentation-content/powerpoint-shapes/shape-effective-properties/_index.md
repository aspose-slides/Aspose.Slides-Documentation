---
title: รับคุณสมบัติรูปร่างที่มีประสิทธิภาพจากงานนำเสนอใน PHP
linktitle: คุณสมบัติ Effective
type: docs
weight: 50
url: /th/php-java/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปแบบ bevel
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงของฟอนต์
- รูปแบบการเติม
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อแยกแยะการจัดรูปแบบรูปร่างแบบ local, inherited และ effective ในงานนำเสนอ PowerPoint."
---
## **ทำความเข้าใจคุณสมบัติ Local, Inherited และ Effective**
PowerPoint การจัดรูปแบบสามารถมาจากหลายแหล่ง ค่าที่เก็บโดยตรงบนอ็อบเจ็กต์คือ **local value** หากค่านั้นไม่ได้ตั้งค่า PowerPoint จะมองหาแหล่งกำหนดรูปแบบของพาเรนท์ เช่น ค่าเริ่มต้นของย่อหน้า, สไตล์ข้อความ, เลย์เอาต์หรือสไลด์แม่, ธีม, หรือค่าเริ่มต้นระดับการนำเสนอ ค่าที่ได้จะเป็น **inherited values** ค่าที่เหลือหลังจากที่ลำดับชั้นทั้งหมดได้รับการแก้ไขคือ **effective value** —ค่าที่ใช้ในการแสดงอ็อบเจ็กต์

ตัวอย่างเช่น ส่วนของข้อความอาจไม่ได้กำหนดความสูงของฟอนต์ของตนเอง ค่าที่เป็น local [getFontHeight](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/) จะเป็น `NAN` ซึ่งหมายถึง "ไม่ได้ตั้งค่าสำหรับที่นี่" ส่วนนี้สามารถสืบทอดความสูงจากย่อหน้า, สไตล์ข้อความเริ่มต้นของการนำเสนอ, หรือแหล่งอื่นที่เกี่ยวข้องได้ การเรียก [getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/geteffective/) บนรูปแบบส่วนจะคืนค่าความสูงที่ได้รับการแก้ไขขั้นสุดท้าย

ใช้ข้อมูลการจัดรูปแบบสองประเภทสำหรับวัตถุประสงค์ที่แตกต่างกัน:

- อ่านหรือแก้ไขอ็อบเจ็กต์รูปแบบ local, เช่น [PortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/), เมื่อคุณต้องการควบคุมว่าค่าถูกกำหนดที่ใด
- อ่านอ็อบเจ็กต์ข้อมูล effective, เช่น [data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/geteffective/), เมื่อคุณต้องการผลลัพธ์ที่แสดงสุดท้าย ข้อมูล effective เป็นแบบอ่านอย่างเดียว

ก่อนรันตัวอย่าง, [ติดตั้ง Aspose.Slides สำหรับ PHP ผ่าน Java](/slides/th/php-java/installation/).

## **เปรียบเทียบค่า Local, Inherited และ Effective**
ตัวอย่างสมบัติดังต่อไปนี้สร้างรูปทรงและกำหนดความสูงของฟอนต์ในระดับการนำเสนอ, ย่อหน้า, และส่วนของข้อความ แต่ละขั้นตอนพิมพ์ค่าที่กำหนดในระดับนั้นและค่าที่ effective ที่ได้จากส่วนข้อความเดียวกัน นอกจากนี้ยังแสดงเหตุผลว่าทำไมต้องอ่านข้อมูล effective อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบ

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // อ่านข้อมูล effective หลังจากการเปลี่ยนแปลงก่อนหน้า
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // กำหนดค่าที่สืบทอดในสองระดับต่างกัน
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // ค่าท้องถิ่นบน portion จะทับค่าที่สืบทอดทั้งสองค่า
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // การเปลี่ยนค่าที่สืบทอดจะไม่ทับค่าท้องถิ่นที่มีอยู่
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // ลบค่าท้องถิ่นออก ตอนนี้ portion จะสืบทอดจากย่อหน้าอีกครั้ง
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // ลบค่าของย่อหน้าออก ค่าปริยายของการนำเสนอจะเป็นผลลัพธ์
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ลำดับความสำคัญในตัวอย่างนี้คือการจัดรูปแบบส่วนแบบ local ก่อน, จากนั้นการจัดรูปแบบย่อหน้า, แล้วจึงค่าเริ่มต้นของการนำเสนอ วัตถุอื่นอาจมีสายการสืบทอดที่ต่างกัน แต่หลักการเดียวกัน: ค่าที่ระบุอย่างชัดเจนและเฉพาะเจาะจงมากกว่าจะชนะ, และ [getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/geteffective/) จะคืนผลลัพธ์ขั้นสุดท้าย

## **รับคุณสมบัติข้อความ Effective**
การจัดรูปแบบข้อความถูกแยกออกเป็นหลายอ็อบเจ็กต์:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/textframeformat/geteffective/) แก้ไขคุณสมบัติของกรอบข้อความ เช่น ระยะขอบ, การยึด, autofit, และทิศทางข้อความแนวตั้ง
- [TextStyle.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/textstyle/geteffective/) แก้ไขการจัดรูปแบบย่อหน้าในแต่ละระดับของสไตล์ข้อความ
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/paragraphformat/geteffective/) แก้ไขคุณสมบ่าย่อหน้า เช่น การจัดแนว, การเยื้อง, และสัญลักษณ์หัวข้อ
- [PortionFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/portionformat/geteffective/) แก้ไขคุณสมบัติตัวอักษร เช่น ความสูงของฟอนต์, แบบอักษร, สี, ตัวหนา, และตัวเอียง

สำหรับตัวอย่างต่อไป, `text-formatting.pptx` ต้องมีอย่างน้อยหนึ่งสไลด์และหนึ่ง [AutoShape](https://reference.aspose.com/slides/th/php-java/aspose.slides/autoshape/) ที่มีกรอบข้อความไม่ว่างเปล่า AutoShape สามารถปรากฏในตำแหน่งใดก็ได้ในคอลเลกชันของรูปร่าง; โค้ดจะค้นหาอ็อบเจ็กต์ที่เหมาะสมและตรวจสอบความถูกต้องก่อนใช้งาน

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **รับคุณสมบัติ 3D Effective**
[ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/geteffective/) คืนอ็อบเจ็กต์ข้อมูล effective หนึ่งตัวที่รวมการตั้งค่า 3D ทั้งหมดที่ได้รับการแก้ไข วิธีการ [getCamera](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/geteffective/), และ [getBevelBottom](https://reference.aspose.com/slides/th/php-java/aspose.slides/threedformat/geteffective/) เปิดเผยข้อมูล effective ที่สอดคล้องกัน การอ่านการตั้งค่าเหล่านี้พร้อมกันทำให้เข้าใจลักษณะ 3D สุดท้ายของรูปทรงได้ง่ายขึ้น

สำหรับตัวอย่างนี้, `shape-3d.pptx` ต้องมีอย่างน้อยหนึ่งรูปทรงบนสไลด์แรก หากต้องการให้ผลลัพธ์มีค่าที่ไม่ใช่ค่าเริ่มต้นให้กำหนดกล้อง 3D, แสง, หรือการตั้งค่า bevel ให้กับรูปทรงนั้น

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **รับการจัดรูปแบบตาราง Effective**
การจัดรูปแบบตารางอาจมาจากสไตล์ตารางและจากการกำหนดรูปแบบที่ใช้กับตารางทั้งหมด, คอลัมน์, แถว, หรือเซลล์เดี่ยว สำหรับความขัดแย้งของการเติมสีที่กำหนดอย่างชัดเจน ลำดับความสำคัญคือเซลล์, แถว, คอลัมน์, แล้วจึงทั้งตาราง รูปแบบ effective ของเซลล์คือรูปแบบสุดท้ายที่ใช้วาดเซลล์นั้น

สำหรับตัวอย่างนี้, `table-formatting.pptx` ต้องมีอย่างน้อยหนึ่งตารางบนสไลด์แรก ตารางต้องมีอย่างน้อยหนึ่งแถวและหนึ่งคอลัมน์ โค้ดจะค้นหา [Table](https://reference.aspose.com/slides/th/php-java/aspose.slides/table/) แทนการสันนิษฐานว่า `getShapes()->get_Item(0)` คือ ตาราง

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

หากต้องการสีแทนประเภทการเติมเพียงอย่างเดียว ให้ตรวจสอบค่า effective ของ [getFillType](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/geteffective/) ก่อน แล้วจึงอ่านเมธอดที่สอดคล้องกับประเภทนั้น—for example, [getSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fillformat/geteffective/) สำหรับการเติมสีทึบ

## **อ่านข้อมูล Effective อีกครั้งหลังจากการเปลี่ยนแปลง**
ข้อมูล effective อธิบายลำดับชั้นการจัดรูปแบบในขณะที่ได้รับการแก้ไข เรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงสิ่งใดที่อาจมีส่วนร่วมในลำดับชั้นนั้น, รวมถึง:

- การจัดรูปแบบ local ของอ็อบเจ็กต์
- ค่าเริ่มต้นของย่อหน้าหรือกรอบข้อความ
- สไตล์ตาราง, ตาราง, คอลัมน์, แถว, หรือการจัดรูปแบบเซลล์
- การจัดรูปแบบเลย์เอาต์หรือสไลด์แม่
- ข้อมูลธีมหรือค่าเริ่มต้นระดับการนำเสนอ
- เลย์เอาต์หรือสไลด์แม่ที่กำหนดให้กับสไลด์

ไม่ควรเก็บอ็อบเจ็กต์ข้อมูล effective เป็นสแนปชอตถาวร Aspose.Slides อาจแคชข้อมูล effective บางส่วนภายในและการเรียก `getEffective` ครั้งต่อมาจะรีเฟรชข้อมูลนั้น หากต้องการเปรียบเทียบค่าก่อนและหลังการเปลี่ยนแปลง ให้คัดลอกค่าที่ต้องการ—เช่น ความสูงของฟอนต์, สี, การจัดแนว, หรือความกว้าง bevel—เข้าไปในตัวแปรของคุณก่อนทำการเปลี่ยนแปลง

เพื่อเปลี่ยนค่า ให้อัปเดตอ็อบเจ็กต์รูปแบบ local ที่เหมาะสมแล้วเรียก `getEffective` เพื่อตรวจสอบผลลัพธ์ อ็อบเจ็กต์ข้อมูล effective เองเป็นแบบอ่านอย่างเดียว

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าระดับใดให้ค่าที่ Effective?**  
ข้อมูล effective มีค่าที่สุดท้าย ไม่ได้บอกที่มาของค่า ตรวจสอบอ็อบเจ็กต์ local ที่เกี่ยวข้องจากระดับที่เฉพาะเจาะจงที่สุดออกไป สำหรับข้อความอาจรวมถึง portion, paragraph, text frame, layout, master, theme, และค่าเริ่มต้นของการนำเสนอ ค่าที่ไม่ได้กำหนดเช่น `NAN` หรือ `null` บ่งบอกว่าการค้นหายังดำเนินต่อไปยังระดับอื่น

**จะเกิดอะไรขึ้นเมื่อไม่มีระดับใดกำหนด property?**  
Aspose.Slides จะแก้ไขค่าเริ่มต้นของ PowerPoint หรือของไลบรารี ค่าที่แก้ไขแล้วจะปรากฏในข้อมูล effective แม้ว่าจะไม่มีอ็อบเจ็กต์ local ใดกำหนดค่าโดยตรงก็ตาม

**ทำไมค่าที่ Effective บางครั้งจึงเท่ากับค่า local?**  
ค่า local ชนะในการคำนวนการสืบทอด นี่เป็นผลที่คาดหวังเมื่อ property ถูกตั้งค่าโดยตรงบนอ็อบเจ็กต์และไม่มีกฎที่เฉพาะเจาะจงมากกว่าเข้ามาแทนที่

**ควรใช้ข้อมูล local เมื่อใดแทนข้อมูล effective?**  
ใช้ข้อมูล local เพื่อตรวจสอบหรือแก้ไขระดับการจัดรูปแบบเฉพาะ ใช้ข้อมูล effective เมื่อจำเป็นต้องได้ผลลัพธ์สุดท้ายหลังจากการสืบทอด, กฎธีม, และสไตล์ที่เกี่ยวข้องได้ถูกแก้ไขแล้ว [ตัวอย่างเปรียบเทียบแบบสมบูรณ์](#compare-local-inherited-and-effective-values) แสดงให้เห็นทั้งสองแบบในเวิร์กโฟลว์เดียวกัน.