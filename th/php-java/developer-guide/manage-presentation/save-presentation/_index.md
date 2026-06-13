---
title: บันทึกงานนำเสนอใน PHP
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/php-java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- PHP
- Aspose.Slides
description: "ค้นหาวิธีบันทึกงานนำเสนอโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java — ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงรูปแบบการจัดวาง ฟอนต์และเอฟเฟกต์"
---
## **ภาพรวม**

[เปิดงานนำเสนอใน PHP](/slides/th/php-java/open-presentation/) อธิบายวิธีใช้คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำตั้งแต่ต้นหรือแก้ไขงานที่มีอยู่แล้ว คุณก็ต้องบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides for PHP คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/). ส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอดนั้น ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // ทำงานบางอย่างที่นี่...

    // บันทึกงานนำเสนอเป็นไฟล์.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมโดยส่งสตรีมผลลัพธ์ไปยังเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/). งานนำเสนอสามารถเขียนไปยังสตรีมหลายประเภท ในตัวอย่างด้านล่าง เราจะสร้างงานนำเสนอใหม่และบันทึกเป็นสตรีมไฟล์

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // บันทึกงานนำเสนอไปยังสตรีม.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **บันทึกงานนำเสนอด้วยมุมมองที่กำหนดล่วงหน้า**

Aspose.Slides ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/). ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/#setLastView) กับค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewtype/)

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML. ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/) และตั้งค่าคุณสมบัติ conformance เมื่อบันทึก. หากคุณตั้งค่า [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่ได้บีบอัด, ขนาดไฟล์ที่บีบอัด, และขนาดทั้งหมดของอาร์ไคฟ์เวอร์ รวมถึงจำกัดจำนวนไฟล์สูงสุดที่ 65 535 (2^16‑1) ไฟล์ ส่วนส่วนขยายรูปแบบ ZIP64 จะเพิ่มขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setZip64Mode) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML หรือไม่

เมธอดนี้สามารถใช้ได้กับโหมดต่อไปนี้

- [IfNecessary](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#IfNecessary) ใช้ส่วนขยายรูปแบบ ZIP64 เฉพาะเมื่องานนำเสนอเกินข้อจำกัดข้างต้น นี่คือโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Never) ไม่ใช้ส่วนขยายรูปแบบ ZIP64 เลย
- [Always](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Always) ใช้ส่วนขยายรูปแบบ ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็น PPTX พร้อมเปิดใช้งานส่วนขยายรูปแบบ ZIP64

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
เมื่อคุณบันทึกด้วย [Zip64Mode.Never](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Never) จะมีการโยน [PptxException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxexception/) หากงานนำเสนอไม่สามารถบันทึกในรูปแบบ ZIP32
{{% /alert %}}

## **บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ควบคุมการสร้างภาพย่อเมื่อบันทึกงานนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` ภาพย่อจะถูกรีเฟรชระหว่างบันทึก นี่คือค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีภาพย่อ จะไม่ได้สร้างภาพย่อขึ้นมา

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชภาพย่อของมัน

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
ตัวเลือกนี้ช่วยลดเวลาที่ใช้ในการบันทึกงานนำเสนอในรูปแบบ PPTX
{{% /alert %}}

## **บันทึกการอัปเดตความคืบหน้าเป็นเปอร์เซ็นต์**

การรายงานความคืบหน้าในการบันทึกกำหนดค่าผ่านเมธอด [setProgressCallback](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setProgressCallback) ของคลาส [SaveOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/) และคลาสย่อยของมัน ให้คุณส่งพร็อกซี Java ที่ 구현อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ; ระหว่างการส่งออก คอลแบ็กจะได้รับการอัปเดตเปอร์เซ็นต์เป็นระยะ

โค้ดสแนปเปิลต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // ใช้ค่าร้อยละของความคืบหน้าที่นี่.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอปฟรี PowerPoint Splitter ด้วย API ของตนเอง แอปนี้ช่วยให้คุณแยกงานนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับ "บันทึกอย่างเร็ว" (การบันทึกแบบเพิ่มส่วน) ที่เขียนเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่. การบันทึกจะสร้างไฟล์เป้าหมายเต็มทุกครั้ง; การบันทึกแบบเพิ่มส่วน “fast save” ไม่ได้รับการสนับสนุน

**สามารถบันทึกอินสแตนซ์ Presentation เดียวจากหลายเธรดได้อย่างปลอดภัยหรือไม่?**

ไม่. อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ไม่ปลอดภัยต่อการทำงานหลายเธรด; ควรบันทึกจากเธรดเดียว

**จะเกิดอะไรขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกเมื่อบันทึก?**

[ไฮเปอร์ลิงก์](/slides/th/php-java/manage-hyperlinks/) จะถูกคงไว้ ไฟล์ที่ลิงก์จากภายนอก (เช่นวิดีโอที่อ้างอิงด้วยเส้นทางสัมพัทธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ — ตรวจสอบให้แน่ใจว่าเส้นทางที่อ้างอิงยังสามารถเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึกเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ได้. [คุณสมบัติเอกสาร](/slides/th/php-java/presentation-properties/) มาตรฐานได้รับการสนับสนุนและจะถูกเขียนลงในไฟล์เมื่อบันทึก