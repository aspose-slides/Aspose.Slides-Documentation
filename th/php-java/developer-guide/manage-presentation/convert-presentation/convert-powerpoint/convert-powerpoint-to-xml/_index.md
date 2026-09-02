---
title: แปลงงานนำเสนอ PowerPoint เป็น XML ใน PHP
linktitle: PowerPoint เป็น XML
type: docs
weight: 145
url: /th/php-java/convert-powerpoint-to-xml/
keywords:
  - แปลง PowerPoint เป็น XML
  - แปลงงานนำเสนอเป็น XML
  - PPT เป็น XML
  - PPTX เป็น XML
  - ODP เป็น XML
  - PowerPoint XML Presentation
  - SaveFormat.Xml
  - บันทึกงานนำเสนอเป็น XML
  - ส่งออกงานนำเสนอเป็น XML
  - สตรีม XML
  - PHP
  - Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument ไปเป็นไฟล์หรือสตรีม PowerPoint XML ใน PHP ด้วย Aspose.Slides for PHP via Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java สามารถแปลงงานนำเสนอ PowerPoint ให้เป็นรูปแบบ PowerPoint XML Presentation ได้ ผลลัพธ์เป็น XML มีประโยชน์เมื่อคุณต้องการตัวแทนแบบข้อความสำหรับตรวจสอบโครงสร้างงานนำเสนอ การแก้ไขปัญหาเอกสารที่สร้างขึ้น การเปรียบเทียบผลลัพธ์ในการทดสอบอัตโนมัติ หรือการบูรณาการกับ workflow ที่รับ XML แทนแพคเกจงานนำเสนอ

ใช้เมธอด [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) กับค่า `Xml` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) คุณสามารถเขียนผลลัพธ์โดยตรงลงไฟล์หรือสตรีมได้

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` สร้าง PowerPoint XML Presentation มันไม่ได้สกัดส่วนย่อยของ Office Open XML ที่เก็บอยู่ภายในแพคเกจ PPTX หากคุณต้องการส่วนย่อยของแพคเกจ PPTX อย่างเช่น `ppt/presentation.xml` หรือไฟล์ XML ของสไลด์แต่ละไฟล์ ให้ตรวจสอบแพคเกจ PPTX เอง
{{% /alert %}}

## **แปลงงานนำเสนอเป็นไฟล์ XML**

โหลดงานนำเสนอแหล่งที่มาด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) จากนั้นส่งเส้นทางของไฟล์ผลลัพธ์และ `SaveFormat::Xml` ไปยัง [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แหล่งที่มาสามารถเป็นรูปแบบงานนำเสนอใด ๆ ที่รองรับการโหลด เช่น PPT, PPTX หรือ ODP

ตัวอย่างต่อไปนี้จะแปลงงานนำเสนอ PPTX เป็นไฟล์ XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **เขียนผลลัพธ์ XML ไปยังสตรีม**

ใช้ overload แบบสตรีมของ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เมื่อ XML ต้องคงอยู่ในหน่วยความจำหรือส่งต่อไปยังคอมโพเนนต์อื่น เช่น เว็บเซอร์วิส ผู้ให้บริการเก็บข้อมูล หรือพายป์ไลน์การประมวลผล XML ตัวอย่างต่อไปนี้เขียนผลลัพธ์ไปยัง [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) และรับ XML ที่สร้างขึ้นเป็นอาเรย์ไบต์:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // ส่ง $xmlBytes ไปยังคอมโพเนนต์ต่อไปในเวิร์กโฟลว์
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` จะเก็บข้อมูลที่สร้างทั้งหมดในหน่วยความจำ ดังนั้นจึงไม่จำเป็นต้องรีเซ็ตตำแหน่งก่อนเรียก `toByteArray`

## **เปรียบเทียบ XML กับรูปแบบงานนำเสนอและการส่งออก**

เลือกรูปแบบผลลัพธ์ตามวิธีการที่ผลลัพธ์จะถูกนำไปใช้:

| รูปแบบ | ผลลัพธ์ | การใช้งานทั่วไป |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | ตรวจสอบโครงสร้าง, แก้ไขปัญหา, เปรียบเทียบผลลัพธ์ที่สร้าง, และการบูรณาการแบบ XML |
| PPT (`.ppt`) | ไฟล์งานนำเสนอแบบไบนารีรุ่นเก่า | ความเข้ากันได้กับเวิร์กโฟลว์ PowerPoint รุ่นเก่า |
| PPTX (`.pptx`) | แพคเกจ Office Open XML ที่ประกอบด้วยหลายส่วน | การแก้ไข PowerPoint ปกติและการแลกเปลี่ยนงานนำเสนอ |
| PDF หรือ TIFF | หน้าแบบเลย์เอาต์คงที่หรือภาพหลายหน้า | การดู, การพิมพ์, และการเก็บรักษา |
| PNG, JPEG หรือ SVG | การแสดงผลของสไลด์เดียว | ภาพย่อ, ตัวอย่าง, และสินทรัพย์รูปภาพ |
| HTML หรือ HTML5 | ผลลัพธ์งานนำเสนอแบบเว็บ | การดูในเบราว์เซอร์และการเผยแพร่บนเว็บ |

ต่างจาก PPT และ PPTX, ผลลัพธ์ XML มุ่งเน้นเพื่อการตรวจสอบและเวิร์กโฟลว์เชิงข้อมูลเป็นหลัก ต่างจาก PDF, TIFF, HTML และรูปแบบภาพสไลด์, มันเป็นตัวแทนข้อมูลงานนำเสนอแทนการเรนเดอร์สไลด์เป็นหน้า หรือสินทรัพย์ภาพ ตาราง [รูปแบบไฟล์ที่รองรับ](/slides/th/php-java/supported-file-formats/) ระบุว่า PowerPoint XML Presentation เป็นรูปแบบที่บันทึกได้เท่านั้น ดังนั้นหากเวิร์กโฟลว์ต้องโหลดไฟล์ที่ส่งออกกลับเข้าสู่ Aspose.Slides เพื่อแก้ไขต่อ อย่าใช้รูปแบบนี้

## **คำถามที่พบบ่อย**

**`SaveFormat::Xml` เป็นเหมือนการบันทึกไฟล์ PPTX หรือไม่?**

ไม่. PPTX คือแพคเกจที่ประกอบด้วยหลายส่วนของ Office Open XML ในขณะที่ `SaveFormat::Xml` สร้างไฟล์ PowerPoint XML Presentation

**ฉันสามารถบันทึกผลลัพธ์ XML โดยไม่สร้างไฟล์บนดิสก์ได้หรือไม่?**

ได้. ส่งสตรีมที่สามารถเขียนได้ไปยัง [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/). ตัวอย่างเช่น ใช้ [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) เพื่อประมวลผลในหน่วยความจำ

**Aspose.Slides สามารถโหลดไฟล์ XML ที่ส่งออกได้อีกครั้งหรือไม่?**

ไม่. PowerPoint XML Presentation ปัจจุบันรองรับการบันทึกเท่านั้น ไม่รองรับการโหลด ใช้ PPTX หรือรูปแบบงานนำเสนอที่รองรับอื่นเมื่อจำเป็นต้องแก้ไขแบบวนกลับ

**การแปลงเป็น XML ทำให้แต่ละสไลด์แสดงเป็นหน้า หรือภาพหรือไม่?**

ไม่. การแปลงเป็น XML จะเขียนข้อมูลงานนำเสนอในรูปแบบโครงสร้าง ใช้ PDF หรือ TIFF สำหรับผลลัพธ์แบบหน้า หรือ PNG, JPEG และ SVG สำหรับภาพของสไลด์แต่ละอัน