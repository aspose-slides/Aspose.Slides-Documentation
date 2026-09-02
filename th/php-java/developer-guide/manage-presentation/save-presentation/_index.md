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
- รีเฟรชภาพตัวอย่าง
- บันทึกความคืบหน้า
- PHP
- Aspose.Slides
description: "ค้นพบวิธีบันทึกงานนำเสนอโดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java — ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมคงรักษาการจัดวางแบบอักษรและเอฟเฟกต์"
---
## **ภาพรวม**

[เปิดงานนำเสนอใน PHP](/slides/th/php-java/open-presentation/) อธิบายวิธีการใช้คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีการสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำตั้งแต่เริ่มหรือแก้ไขงานที่มีอยู่แล้ว คุณจะต้องบันทึกเมื่อทำเสร็จ ด้วย Aspose.Slides สำหรับ PHP คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** ได้ บทความนี้อธิบายวิธีการบันทึกงานนำเสนอในรูปแบบต่าง ๆ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอลงไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกให้เมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides

```php
// สสร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
$presentation = new Presentation();
try {
    // ทำงานบางอย่างที่นี่...

    // บันทึกงานนำเสนอลงไฟล์.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมโดยส่งสตรีมผลลัพธ์ให้กับเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) งานนำเสนอสามารถเขียนลงสตรีมหลายประเภท ในตัวอย่างด้านล่าง เราจะสร้างงานนำเสนอใหม่และบันทึกลงสตรีมไฟล์

```php
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
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

## **บันทึกงานนำเสนอโดยกำหนดประเภทมุมมองล่วงหน้า**

Aspose.Slides ให้คุณกำหนดมุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/) ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/#setLastView) พร้อมค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewtype/)

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

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/) และตั้งค่า property `conformance` เมื่อต้องการบันทึก หากตั้งค่าเป็น [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/php-java/aspose.slides/conformance/#Iso29500_2008_Strict) ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
$presentation = new Presentation();
try {
    // บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดที่ไม่บีบอัดของไฟล์ใดไฟล์หนึ่ง ขนาดบีบอัดของไฟล์ใดไฟล์หนึ่ง และขนาดรวมของไฟล์อาร์ไคฟ์เวอร์ รวมถึงจำกัดจำนวนไฟล์สูงสุดที่ 65 535 (2^16‑1) ไฟล์ ส่วนขยายรูปแบบ ZIP64 ขยายขีดจำกัดเหล่านี้เป็น 2^64

เมธอด [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setZip64Mode) ให้คุณเลือกใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML

เมธอดนี้สามารถใช้ได้กับโหมดต่อไปนี้:

- [IfNecessary](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#IfNecessary) ใช้ส่วนขยายรูปแบบ ZIP64 เฉพาะเมื่อการนำเสนอเกินขีดจำกัดข้างต้น นี้คือโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Never) ไม่เคยใช้ส่วนขยายรูปแบบ ZIP64
- [Always](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Always) ใช้ส่วนขยายรูปแบบ ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX พร้อมเปิดใช้งานส่วนขยายรูปแบบ ZIP64

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
เมื่อบันทึกด้วย [Zip64Mode.Never](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Never) จะเกิดข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxexception/) หากไม่สามารถบันทึกงานนำเสนอในรูปแบบ ZIP32 ได้
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

เมื่อทำงานกับงานนำเสนอขนาดใหญ่ คุณสามารถปรับระดับการบีบอัดเพื่อสมดุลระหว่างขนาดไฟล์และเวลาในการประมวลผล ขึ้นอยู่กับความต้องการของคุณ คุณอาจต้องการประมวลผลที่เร็วกว่า หรือไฟล์ผลลัพธ์ที่เล็กกว่า

Aspose.Slides มีเมธอด [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setCompressionLevel) ให้คุณระบุระดับการบีบอัดเมื่อบันทึกงานนำเสนอในรูปแบบ Office Open XML

ระดับการบีบอัดที่มีให้เลือก ได้แก่:

- [**None**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#None): ไม่บีบอัด ไฟล์จะถูกเก็บไว้ตามเดิม
- [**Level1**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level1): การบีบอัดที่เร็วที่สุดด้วยอัตราการบีบอัดต่ำที่สุด
- [**Level2**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level2): การบีบอัดที่เร็วกว่าโดยอัตราการบีบอัดดีกว่า **Level1** เล็กน้อย
- [**Level3**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level3): ให้การบีบอัดที่ดีกว่า **Level2** ด้วยผลกระทบต่อเวลาประมวลผลปานกลาง
- [**Level4**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level4): ให้การบีบอัดที่ดีกว่า **Level3**
- [**Level5**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level5): ปรับปรุงการบีบอัดเหนือ **Level4** โดยใช้เวลาประมวลผลเพิ่ม
- [**Level6**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level6): การบีบอัดมาตรฐานที่ให้สมดุลที่ดีระหว่างความเร็วและขนาดไฟล์ นี้คือ *ระดับการบีบอัดเริ่มต้น*
- [**Level7**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level7): ให้การบีบอัดที่ดีกว่า **Level6** แต่ประมวลผลช้ากว่า
- [**Level8**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level8): ให้การบีบอัดที่ดีกว่า **Level7**
- [**Level9**](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level9): การบีบอัดสูงสุด ให้ขนาดไฟล์ที่เล็กที่สุดแต่ใช้เวลาประมวลผลนานที่สุด

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX *โดยไม่มีการบีบอัด*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

ตัวอย่างนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX *ด้วยการบีบอัดสูงสุด*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **บันทึกงานนำเสนอโดยไม่รีเฟรชภาพตัวอย่าง**

เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ควบคุมการสร้างภาพตัวอย่างเมื่อบันทึกงานนำเสนอเป็น PPTX:

- หากตั้งค่าเป็น `true` ภาพตัวอย่างจะถูกรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น
- หากตั้งค่าเป็น `false` ภาพตัวอย่างปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีภาพตัวอย่าง จะไม่มีการสร้างภาพใหม่

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชภาพตัวอย่าง

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

## **บันทึกความคืบหน้าเป็นเปอร์เซ็นต์**

การรายงานความคืบหน้าในการบันทึกสามารถกำหนดค่าได้ผ่านเมธอด [setProgressCallback](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setProgressCallback) ของคลาส [SaveOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/) และคลาสย่อยของมัน ให้ Java proxy ที่ทำการ implements อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) ระหว่างการส่งออก คอลแบ็คจะได้รับการอัปเดตเปอร์เซ็นต์เป็นช่วง ๆ

โค้ดตัวอย่างต่อไปนี้แสดงวิธีใช้ `IProgressCallback`

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // ใช้ค่าร้อยละของความคืบหน้าในที่นี้.
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
Aspose ได้พัฒนาแอปพลิเคชัน [free PowerPoint Splitter app](https://products.aspose.app/slides/th/splitter) ด้วย API ของตนเอง แอปนี้ช่วยให้คุณแยกงานนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**“fast save” (การบันทึกแบบเพิ่ม) รองรับให้บันทึกเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่มี การบันทึกจะสร้างไฟล์เป้าหมายเต็มรูปแบบทุกครั้ง; การบันทึกแบบ “fast save” แบบเพิ่มไม่ได้รับการสนับสนุน

**การบันทึกอินสแตนซ์ Presentation เดียวจากหลายเธรดทำได้อย่างปลอดภัยหรือไม่?**

ไม่ได้ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) **ไม่ปลอดภัยต่อหลายเธรด** (/slides/th/php-java/multithreading/) ควรบันทึกจากเธรดเดียว

**ลิงก์ไฮเปอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกจะเกิดอะไรขึ้นเมื่อบันทึก?**

[Hyperlinks](/slides/th/php-java/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่ลิงก์ภายนอก (เช่นวิดีโอที่อ้างอิงด้วยเส้นทางสัมพัทธ์) จะไม่ถูกคัดลึกโดยอัตโนมัติ—ต้องตรวจสอบให้เส้นทางที่อ้างอิงยังเข้าถึงได้

**ฉันสามารถตั้งค่าหรือบันทึกเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ได้ คุณสมบัติเพิ่มเติมของเอกสารมาตรฐาน [/slides/th/php-java/presentation-properties/] จะได้รับการสนับสนุนและจะถูกเขียนลงในไฟล์เมื่อบันทึก