---
title: "แก้ไขเอกสาร PDF ใน PHP"
linktitle: "แก้ไข PDF"
type: docs
weight: 65
url: /th/php-java/edit-pdf/
keywords:
- "แก้ไข PDF"
- "แทนที่ข้อความ PDF"
- "PDF เป็น PPTX"
- "PPTX เป็น PDF"
- PHP
- Aspose.Slides
description: "แก้ไขเอกสาร PDF ใน PHP โดยนำเข้าไปยัง Aspose.Slides, แทนที่ข้อความ, และบันทึกงานนำเสนอที่แก้ไขแล้วกลับเป็น PDF."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ให้คุณแก้ไขเนื้อหา PDF โดยการนำเข้าหน้าต่าง ๆ เป็นสไลด์, แก้ไขงานนำเสนอ, แล้วส่งออกกลับเป็น PDF. บทความนี้แสดงการแทนที่ข้อความอย่างง่าย. งานนำเสนอจะอยู่ในหน่วยความจำ, ดังนั้นการบันทึกไฟล์ PPTX ชั่วคราวเป็นเรื่องเลือกได้.

## **แทนที่ข้อความใน PDF**

ใช้ [SlideCollection::addFromPdf](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidecollection/#addFromPdf) เพื่อนำเข้าหน้า, [Presentation::replaceText](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#replaceText) เพื่ออัปเดตข้อความ, และ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) เพื่อส่งออกผลลัพธ์.

ตัวอย่างต่อไปนี้คาดว่า `input.pdf` มีคำว่า "Draft" เป็นข้อความที่แก้ไขได้หลังการนำเข้า. มันจะแทนที่คำนั้นด้วย "Final" และเขียนไฟล์ `edited.pdf`. การลบสไลด์เริ่มต้นก่อนการนำเข้าเลี่ยงการสร้างหน้าว่างเพิ่มในผลลัพธ์. การค้นหาแมตช์คำเต็มที่มีรูปแบบตัวอักษรเดียวกัน; `null` หมายถึงไม่ต้องใช้ callback ผลลัพธ์.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

สำหรับตัวเลือกเพิ่มเติม, ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/php-java/search-and-replace-text/) และ [แปลง PowerPoint เป็น PDF](/slides/th/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
การแทนที่ข้อความทำได้กับข้อความที่ถูกนำเข้า, ไม่ใช่ข้อความในภาพสแกน. การแปลงอาจส่งผลต่อเค้าโครงและรูปแบบ, ดังนั้นควรตรวจสอบผลลัพธ์โดยเฉพาะเมื่อข้อความที่แทนที่ยาวกว่าข้อความต้นฉบับ.
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันต้องบันทึกไฟล์ PPTX ก่อนส่งออกเป็น PDF หรือไม่?**

ไม่จำเป็น. คุณสามารถแก้ไขและส่งออกงานนำเสนอเดียวกันในหน่วยความจำได้. บันทึกสำเนา PPTX เฉพาะเมื่อคุณต้องการแก้ไขต่อใน PowerPoint; ดูที่ [บันทึกการนำเสนอ](/slides/th/php-java/save-presentation/).

**ทำไมข้อความบางส่วนยังคงไม่เปลี่ยน?**

ตัวอย่างนี้แมตช์คำเต็ม "Draft" โดยพิจารณาตัวพิมพ์ใหญ่‑เล็ก. ข้อความที่นำเข้ามาเป็นรูปภาพหรือแยกเป็นเฟรมข้อความหลายส่วนอาจไม่ตรงกับการค้นหา. ตรวจสอบเนื้อหาที่นำเข้าและปรับการค้นหาให้เหมาะกับเอกสารของคุณ.