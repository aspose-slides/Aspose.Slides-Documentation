---
title: จัดการฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย PHP
linktitle: ฟิลด์ข้อความ
type: docs
weight: 52
url: /th/php-java/text-fields/
keywords:
- ฟิลด์ข้อความ
- ข้อความอัตโนมัติ
- หมายเลขสไลด์
- วันและเวลา
- หัวเรื่อง
- ท้ายกระดาษ
- ส่วนข้อความ
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "สร้าง ตรวจสอบ แก้ไข และลบฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. คงการจัดรูปแบบและตรวจสอบไฟล์ PPTX และ PPT ที่บันทึกไว้."
---
## **ภาพรวม**

ย่อหน้าข้อความประกอบด้วยส่วนต่าง ๆ ส่วนธรรมดา [Portion](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/) มีข้อความตามตัวอักษร; ส่วนฟิลด์ยังมี [Field](https://reference.aspose.com/slides/th/php-java/aspose.slides/field/) ซึ่งประเภทของมันระบุค่าที่อัปเดตโดยอัตโนมัติ เช่น หมายเลขสไลด์หรือวันที่. ส่วนสองส่วนอาจแสดงอักขระเดียวกันในขณะที่มีเพียงส่วนเดียวที่เป็นฟิลด์.

ใช้ [Portion::getField](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getField) เพื่อตรวจแยก: ค่าจะเป็น `null` สำหรับข้อความธรรมดา. [Portion::addField](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#addField) แปลงส่วนที่มีอยู่ให้เป็นฟิลด์. เก็บป้ายกำกับและค่าที่เปลี่ยนแปลงได้ในส่วนแยกกันเพื่อให้การแปลงค่าจะไม่แทนที่ป้ายกำกับ.

เอกสารนี้ครอบคลุมฟิลด์ภายในข้อความ การจัดรูปแบบ และการบันทึกเป็น PPTX และ PPT. สำหรับกรอบข้อความและย่อหน้า ดูที่ [Manage Text](/slides/th/php-java/manage-text/).

## **สร้างฟิลด์หมายเลขสไลด์**

ตัวอย่างสมบูรณ์ต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับตามตัวอักษร `Slide ` ตามด้วยหมายเลขที่อัปเดตโดยอัตโนมัติ. ก่อนเพิ่มฟิลด์จะตั้งค่าขนาด น้ำหนัก และสีของหมายเลข, จากนั้นเปิดพรีเซนเทชันที่บันทึกแล้วและตรวจสอบประเภทฟิลด์, ข้อความ, และการจัดรูปแบบ. ไม่จำเป็นต้องมีไฟล์อินพุต.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

พรีเซนเทชันใหม่เริ่มต้นที่หมายเลขสไลด์ 1, ดังนั้นข้อความจะเป็น `Slide 1` และการตรวจสอบทั้งสองพิมพ์ `true`. หมายเลขคงเป็นฟิลด์หลังจากเปิดใหม่; ไม่ใช่ข้อความตามตัวอักษร `1`. ดัชนีในการตรวจสอบอ้างอิงถึง shape และ portion ที่สร้างโดยตัวอย่างนี้.

## **เลือกประเภทฟิลด์**

[FieldType](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/) มีวิธีต่อไปนี้เพื่อรับค่าที่กำหนดไว้ล่วงหน้า. ส่งค่าให้เหมาะกับ [addField](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#addField).

| วิธี | วัตถุประสงค์ |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getSlideNumber) | หมายเลขสไลด์ปัจจุบัน |
| [getDateTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getDateTime) | วันที่/เวลาในรูปแบบเริ่มต้นของแอปที่ทำการเรนเดอร์ |
| [getDateTime1](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getDateTime9) | รูปแบบวันที่หรือวันที่/เวลาที่กำหนดไว้ล่วงหน้า |
| [getDateTime10](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getDateTime13) | รูปแบบเวลาแบบกำหนดไว้ล่วงหน้า, มีตัวเลือกสำหรับวินาทีและนาฬิกา 12‑ชั่วโมง |
| [getHeader](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getHeader) | ฟิลด์หัวเรื่อง; ดูข้อจำกัดของตัวเก็บตำแหน่งและรูปแบบด้านล่าง |
| [getFooter](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getFooter) | ฟิลด์ท้ายกระดาษ |

ตัวอย่างเช่น [getDateTime3](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getDateTime3) แสดงวัน, ชื่อเดือนเต็ม, และปีในภาษาอังกฤษ. เหล่านี้เป็นรูปแบบฟิลด์ที่กำหนดไว้ล่วงหน้า, ไม่ใช่สตริงรูปแบบวันที่ของ PHP. ภาษาที่ตั้งด้วย [setLanguageId](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseportionformat/#setLanguageId) และแอปที่ประมวลผลพรีเซนเทชันอาจมีผลต่อผลลัพธ์ที่แสดง.

## **สร้างฟิลด์จากสตริงภายใน**

โอเวอร์โหลดที่รับสตริงของ [addField](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#addField) ยอมรับตัวระบุฟิลด์ภายใน. ใช้เมื่อคุณต้องการเก็บตัวระบุที่มาจากแอปอื่นซึ่งไม่มีค่าที่กำหนดไว้ล่วงหน้า. คุณยังสามารถสร้าง [FieldType](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#FieldType) จากตัวระบุนั้นได้. [FieldType::getInternalString](https://reference.aspose.com/slides/th/php-java/aspose.slides/fieldtype/#getInternalString) เปิดเผยตัวระบุเพื่อการตรวจสอบ.

ตัวอย่างนี้เก็บฟิลด์ `custom-report-id` ที่เฉพาะแอปพลิเคชันพร้อมข้อความสำรอง `Report-042`. ตัวระบุจะไม่ทำการคำนวณ: Aspose.Slides ไม่สร้างรหัสรายงานสำหรับประเภทที่ไม่รู้จัก. แอปที่เข้าใจตัวระบุต้องให้ความหมายและอัปเดตค่าด้วยตัวเอง.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

หลังจากรอบเดินทาง PPTX, ประเภทคือ `custom-report-id` และข้อความคือ `Report-042`. การส่งสตริงเช่น `Y-m-d` จะตั้งชื่อประเภทฟิลด์; ไม่ได้กำหนดรูปแบบวันที่แบบกำหนดเอง. หากต้องการวันที่คงที่ในรูปแบบใดรูปแบบหนึ่ง, ให้ใช้ข้อความธรรมดา.

## **ตรวจสอบ, แก้ไข และลบฟิลด์วันที่/เวลา**

เปลี่ยนฟิลด์ที่มีอยู่ผ่าน [Field::setType](https://reference.aspose.com/slides/th/php-java/aspose.slides/field/#setType). ตรวจสอบว่าฟิลด์มีอยู่ก่อนเข้าถึงประเภทของมัน. เพื่อหยุดการอัปเดตอัตโนมัติ, เรียก [Portion::removeField](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#removeField). วิธีนี้จะคงส่วนและข้อความปัจจุบันไว้ขณะลบการเชื่อมโยงฟิลด์. หากต้องการค่าคงที่เฉพาะ, ให้กำหนดข้อความนั้นหลังจากลบฟิลด์.

สำหรับการตั้งค่า API ที่เกี่ยวกับการประมวลผลฟิลด์วันที่/เวลา, ดูที่ [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#setCurrentDateTime). ตัวอย่างด้านล่างใช้วันที่อนุมัติอย่างชัดเจนเมื่อแปลงฟิลด์เป็นข้อความธรรมดา.

ดาวน์โหลด [sample.pptx](sample.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของ JavaBridge, หรือส่งพาธเต็มไปยังคอนสตรัคเตอร์พรีเซนเทชัน. ไฟล์นี้มี shape ข้อความที่ตั้งชื่อ `UpdatedAt` และ `ApprovedDate`, แต่ละอันมีฟิลด์วันที่/เวลา, พร้อมป้ายกำกับข้อความธรรมดา. ตัวอย่างต่อไปนี้เดินสำรวจ shape ข้อความระดับบนบนสไลด์ปกติ. จะเปลี่ยนฟิลด์วันที่/เวลาเป็นรูปแบบวันเต็มและทำเป็นตัวเอียง, พร้อมคงการจัดรูปแบบอื่นๆ. ฟิลด์ใน `ApprovedDate` เท่านั้นที่กลายเป็นข้อความคงที่.

ตัวอย่างนี้รู้จักตัวระบุภายในที่สร้างมาโดยอัตโนมัติ `datetime` ถึง `datetime13`. กลุ่ม, ตาราง, โน้ต, เลย์아웃, และมาสเตอร์ต้องทำการเดินสำรวจคอนเทนเนอร์ข้อความของตนเองและอยู่นอกขอบเขตของตัวอย่างนี้.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

หลังจากเปิดใหม่, `UpdatedAt` มีประเภท `datetime3` และยังคงเป็นแบบไดนามิก. `ApprovedDate` ไม่มีฟิลด์และมีข้อความ `05 April 2030`. ส่วนวันที่ทั้งสองเป็นตัวเอียง, และขนาดฟอนต์, การตั้งค่าหนา, สีเดิมยังคงอยู่. ป้ายกำกับข้อความธรรมดาไม่มีการเปลี่ยนแปลง. การตรวจสอบอ่าน portion แรกของ shape สองรูปที่รู้จักในตัวอย่างที่ให้มา.

## **รักษาการจัดรูปแบบข้อความ**

ทำงานกับ portion ที่มีอยู่เมื่อเพิ่มฟิลด์, เปลี่ยนประเภท, หรือทำการลบ. การดำเนินการเหล่านี้จะคงการจัดรูปแบบของ portion นั้นไว้. ใช้ [Portion::getPortionFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getPortionFormat) เพื่อเปลี่ยนคุณสมบัติที่ต้องการเท่านั้น, เช่นตัวอย่างที่ทำการเปลี่ยนสีหรือทำให้เป็นตัวเอียง.

หลีกเลี่ยงการสร้างกรอบข้อความใหม่ทั้งหมดเพียงเพื่ออัปเดตฟิลด์เดียว: การทำเช่นนั้นอาจทำให้สูญเสียขอบเขตของ portion ดั้งเดิมและการจัดรูปแบบแต่ละส่วน. แยกแยะการจัดรูปแบบที่ตั้งโดยตรงจากการจัดรูปแบบที่สืบทอดจากย่อหน้า, เลย์아웃, หรือธีม. ดูที่ [Text Formatting](/slides/th/php-java/text-formatting/) เพื่อพบตัวเลือกการจัดรูปแบบที่กว้างขึ้น.

## **ฟิลด์และตัวเก็บตำแหน่งหัวเรื่อง/ท้ายนั้น**

ฟิลด์เป็นส่วนหนึ่งของ portion ข้อความ. ตัวเก็บตำแหน่ง (placeholder) คือ shape ที่มีบทบาทในพรีเซนเทชัน, เช่น ท้ายนั้นหรือหมายเลขสไลด์. การเพิ่มฟิลด์ลงในกล่องข้อความธรรมดาจะไม่ทำให้ shape นั้นกลายเป็น placeholder.

ผู้จัดการหัวเรื่อง/ท้ายนั้นควบคุมข้อความ placeholder และการมองเห็นบนสไลด์, เลย์아웃, และมาสเตอร์, รวมถึงการแพร่กระจายไปยังสไลด์ที่ขึ้นกับมัน. ฟิลด์หมายเลขในกล่องข้อความกำหนดเองจึงอาจเป็นประโยชน์แม้คุณจะไม่ได้ใช้ placeholder หมายเลขสไลด์. ในทางกลับกัน, การเปลี่ยนการมองเห็นของ placeholder จะไม่ลบฟิลด์จากกล่องข้อความที่ไม่เกี่ยวข้อง.

ประเภทหัวเรื่องและท้ายนั้นที่กำหนดไว้ล่วงหน้าไม่ได้สร้าง placeholder ที่สอดคล้องหรือให้เนื้อหา. โดยเฉพาะ, สไลด์ PowerPoint ปกติไม่มี placeholder ของหัวเรื่อง; หัวเรื่องอยู่ในหน้าโน้ตและเอกสารแจก. อย่าสันนิษฐานว่าฟิลด์หัวเรื่องหรือท้ายนั้นใน shape ใด ๆ จะได้รับข้อความที่กำหนดผ่านผู้จัดการ placeholder โดยอัตโนมัติ. สำหรับกระบวนการนั้น, ดูที่ [Presentation Headers and Footers](/slides/th/php-java/presentation-header-and-footer/).

## **ข้อจำกัดของ PPTX และ PPT**

ตรวจสอบทั้งประเภทฟิลด์และข้อความที่ได้หลังจากบันทึกและเปิดใหม่. การเก็บตัวระบุไว้ไม่พิสูจน์ได้ว่าแอปพลิเคชันสามารถคำนวณหรือแสดงค่าดังกล่าวได้.

| รูปแบบ | พฤติกรรมของฟิลด์และข้อจำกัด |
|---|---|
| PPTX | เก็บตัวระบุฟิลด์ภายในพร้อมกับข้อความฟิลด์. ในการตรวจสอบรอบเดินทาง, ประเภทที่กำหนดล่วงหน้าและตัวระบุที่กำหนดเองในตัวอย่างข้างต้นยังคงอยู่หลังการบันทึกและเปิดใหม่. ตัวประเภทที่ไม่รู้จักคงข้อความสำรอง; ไม่ได้เพิ่มตรรกะการคำนวณอัตโนมัติ. แอปอื่นอาจจัดการตัวระบุที่ไม่สนับสนุนอย่างแตกต่างกัน |
| PPT | ใช้การแสดงฟิลด์แบบเก่าและมีความเข้ากันได้จำกัดมากกว่า. ในการตรวจสอบรอบเดินทาง, ฟิลด์หมายเลขสไลด์และฟิลด์วันที่/เวลาที่กำหนดล่วงหน้าคงอยู่หลังบันทึกและเปิดใหม่. ฟิลด์กำหนดเองในกล่องข้อความสไลด์ธรรมดาจะเปิดใหม่พร้อมตัวระบุแต่ข้อความเป็น `*`; ฟิลด์หัวเรื่องในบริบทเดียวกันก็เช่นกัน. อย่าพึ่งพาฟิลด์กำหนดเองหรือบริบทฟิลด์ที่ไม่สนับสนุนว่าจะคงข้อความที่มองเห็นได้ |

สำหรับผลลัพธ์ที่พกพาและคงที่, แปลงฟิลด์ที่ไม่สนับสนุนเป็นข้อความธรรมดาและกำหนดค่าที่ต้องการให้ชัดเจนก่อนบันทึก. วิธีนี้จะคงข้อความที่เลือกไว้แต่หยุดการอัปเดตอัตโนมัติอย่างตั้งใจ. ทดสอบแอปเป้าหมายด้วยเช่นกันเมื่อการคำนวณฟิลด์ของแอปนั้นเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ.

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าตัวเลขหรือวันที่ที่แสดงเป็นฟิลด์หรือไม่?**

ตรวจสอบ [Portion::getField](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#getField). ค่าที่ไม่เป็น `null` ระบุว่ามีฟิลด์; ข้อความที่แสดงอย่างเดียวไม่สามารถบอกได้.

**การลบฟิลด์จะลบข้อความหรือการจัดรูปแบบของมันหรือไม่?**

ไม่. [removeField](https://reference.aspose.com/slides/th/php-java/aspose.slides/portion/#removeField) แปลง portion ที่มีอยู่เป็นข้อความธรรมดา. หากต้องการค่าคงที่เฉพาะ, ให้กำหนดค่าดังกล่าวหลังจากลบฟิลด์.

**สตริงภายในสามารถกำหนดรูปแบบวันที่ใหม่หรือสูตรได้หรือไม่?**

ไม่ได้. สตริงภายในเพียงระบุประเภทฟิลด์. ตัวระบุที่ไม่รู้จักไม่ให้ตัวประเมินหรือรูปแบบวันที่ของ PHP. ใช้ประเภทที่สนับสนุนหรือรูปแบบค่าที่ต้องการเป็นข้อความธรรมดา.

**ทำไมต้องตรวจสอบพรีเซนเทชันอีกครั้งหลังจากบันทึก?**

ตัวระบุฟิลด์, ข้อความที่คำนวณ, และการจัดรูปแบบเป็นสิ่งที่ต้องตรวจสอบแยกกัน. การแปลงรูปแบบอาจเปลี่ยนผลลัพธ์ที่มองเห็นได้แม้ตัวระบุฟิลด์ยังคงอยู่.