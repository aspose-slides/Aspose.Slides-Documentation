---
title: แปลง PPT และ PPTX เป็น PDF ใน PHP [รวมคุณลักษณะขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/php-java/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- PowerPoint เป็น PDF
- การนำเสนอเป็น PDF
- PPT เป็น PDF
- แปลง PPT เป็น PDF
- PPTX เป็น PDF
- แปลง PPTX เป็น PDF
- บันทึก PowerPoint เป็น PDF
- บันทึก PPT เป็น PDF
- บันทึก PPTX เป็น PDF
- ส่งออก PPT เป็น PDF
- ส่งออก PPTX เป็น PDF
- ไฟล์แนบ
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงและค้นหาได้ใน PHP โดยใช้ Aspose.Slides พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน PHP มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการคงรูปแบบการจัดวางและการฟอร์แมตของงานนำเสนอ คำแนะนำนี้แสดงวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF การใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพของภาพ การรวมสไลด์ที่ซ่อนอยู่ การตั้งรหัสผ่านให้ไฟล์ PDF การตรวจจับการเปลี่ยนฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามเพื่อเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้กับคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ที่มักใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าในรูปแบบ "*Aspose.Slides v XX.XX*" **Note** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ไฟล์ PDF ที่ได้ตรงกับงานนำเสนอเดิมมากที่สุด องค์ประกอบและแอตทริบิวต์จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* รายการหัวข้อย่อย
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint‑to‑PDF มาตรฐานใช้ตัวเลือกค่าเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดที่ระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าเริ่มต้นสำหรับการส่งออก

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose มีเครื่องมือแปลงออนไลน์ฟรี [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ที่แสดงกระบวนการแปลงงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยเครื่องมือนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายไว้ที่นี่

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides ให้ตัวเลือกปรับแต่ง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—ที่ช่วยให้คุณกำหนด PDF ผลลัพธ์, ล็อก PDF ด้วยรหัสผ่าน, หรือระบุวิธีการที่กระบวนการแปลงควรดำเนินต่อ

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่คุณต้องการสำหรับภาพเรสเตอร์, ระบุวิธีการจัดการเมทาฟายล์, ตั้งระดับการบีบอัดสำหรับข้อความ, กำหนด DPI สำหรับภาพ, และอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 โดยตั้งคุณภาพ JPEG เป็น 90, ความละเอียดภาพเป็น 300 DPI, เมทาฟายล์บันทึกเป็น PNG, และบีบอัดข้อความแบบ Flate

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **เลือกการบีบอัดภาพอัตโนมัติ**

เมื่องานนำเสนอมีรูปถ่ายหรือสกรีนช็อตจำนวนมาก การลดขนาด PDF ที่ส่งออกสามารถทำให้การอีเมลหรือดาวน์โหลดทำได้ง่ายขึ้น เรียกใช้เมธอด [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) ด้วยค่า `true` เพื่อให้ระบบเลือกอัลกอริธึมการบีบอัดที่เหมาะสมที่สุดสำหรับแต่ละภาพโดยอัตโนมัติในระหว่างการส่งออก PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีอยู่แล้ว, เปิดใช้งานการเลือกบีบอัดภาพอัตโนมัติ, แล้วบันทึกเป็นเอกสาร PDF การตั้งค่าอื่น ๆ ของการส่งออก PDF ยังคงค่าเริ่มต้น

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

ตัวเลือกนี้เลือกอัลกอริธึมการบีบอัดสำหรับแต่ละภาพ การลดค่าที่ส่งให้เมธอด [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) จะลดคุณภาพของภาพ JPEG ส่วนการลดค่าที่ส่งให้เมธอด [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) จะทำให้ภาพถูกลดความละเอียด ซึ่งอาจลดรายละเอียดได้ การเปิดใช้งานการเลือกบีบอัดอัตโนมัติเองไม่ทำให้ค่าทั้งสองนี้ลดลง

การเลือกอัลกอริธึมการบีบอัดภาพต้องใช้เวลาและหน่วยความจำเพิ่มเติม การลดขนาดขึ้นอยู่กับภาพในงานนำเสนอและการตั้งค่าการส่งออก; ไม่ได้รับประกันว่าการลดขนาดจะคงที่สำหรับทุกงานนำเสนอ

### **คงไฟล์ OLE ฝังเป็นแนบใน PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลในเวิร์กบุ๊กได้พร้อมกับดูสไลด์ เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) ด้วยค่า `true` เพื่อคงไฟล์ OLE ฝังเป็นแนบใน PDF ที่ได้

ค่าเริ่มต้นคือ `false`: รูปภาพพรีวิวหรือไอคอนของอ็อบเจ็กต์ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ฝังจะไม่รวมเป็นแนบ การตั้งค่าเป็น `true` จะเพิ่มข้อมูลไฟล์ด้วย พรีวิวยังคงเป็นภาพแสดงผล ส่วนไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ฝังแยกต่างหากได้ อ็อบเจ็กต์ OLE จะไม่กลายเป็นแผ่นงาน Excel แบบโต้ตอบบนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังแล้วส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

เพื่อดูผลลัพธ์:

1. เปิด PDF ที่ส่งออกในโปรแกรมที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมสนับสนุน พรีวิวบนหน้า PDF จะอยู่แยกต่างหากจากไฟล์แนบ

{{% alert color="info" title="Note" %}}

มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A‑1 ห้ามไฟล์ฝัง, PDF/A‑2 อนุญาตเฉพาะไฟล์แนบ PDF/A, และ PDF/A‑3 อนุญาตประเภทไฟล์อื่น ๆ รวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นข้อกำหนดของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออก PDF/A

{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำเสนอมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าต่าง PDF ที่ได้

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF รวมสไลด์ที่ซ่อนด้วย

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **แปลง PowerPoint เป็น PDF ที่มีรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพิ่อเปิด การอนุญาตการเข้าถึงรวมถึงการพิมพ์ รวมถึงการพิมพ์คุณภาพสูง

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **ตรวจจับการแทนที่ฟอนต์**

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) ที่ช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ลงคอนโซล คำเตือนจะถูกพิมพ์เมื่อฟอนต์ที่ไม่มีอยู่ถูกแทนที่ระหว่างการส่งออก

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ โปรดดูบทความ [Font Substitution](/slides/th/php-java/font-substitution/)

{{% /alert %}} 

### **จัดการฟอนต์ที่ไม่มีรูปแบบ Bold แยก**

งานนำเสนออาจใช้การจัดรูปแบบตัวหนาสำหรับข้อความแม้ว่าฟอนต์นั้นจะไม่มีรูปแบบ Bold แยก ข้อความอาจยังคงแสดงเป็นตัวหนาผ่านการทำให้หนาแบบสังเคราะห์ ซึ่งทำให้ glyph ปกติหนาขึ้น เมื่อข้อความดูหนาเกินไปหรือแตกต่างจากที่คาดหวังใน PDF ให้ลองเรียกเมธอด [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) ด้วยค่า `true` ตัวเลือกนี้จะเรนเดอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพระหว่างการส่งออก PDF และอาจช่วยปรับปรุงการแสดงผลสำหรับฟอนต์บางประเภท ค่าเริ่มต้นคือ `false`

งานนำเสนอที่ใช้ตัวอย่างมีสองกล่องข้อความ: หนึ่งข้อความปกติและอีกหนึ่งที่ใช้การจัดรูปแบบตัวหนาสำหรับฟอนต์เดียวกันที่ไม่มีรูปแบบ Bold แยก ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, เปิดใช้งานการเรนเดอร์รูปแบบฟอนต์ที่ไม่รองรับเป็นบิตแมพ, แล้วส่งออกเป็น PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

รูปตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดและเปิดใช้งาน ในตัวอย่างนี้ข้อความตัวหนามีเส้นหนากว่าเมื่อปิดตัวเลือก; เมื่อเปิดใช้งานเส้นจะบางลง; ข้อความปกติไม่เปลี่ยนแปลง เปรียบเทียบผลลัพธ์ก่อนตัดสินใจตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดใช้งานตัวเลือกทำให้ข้อความตัวหนาแปลงเป็นบิตแมพเท่านั้น: ไม่สามารถเลือก, คัดลอก, หรือค้นหาเป็นข้อความได้โดยไม่มี OCR และขอบจะดูนุ่มขึ้นที่การซูม 800% ข้อความปกติยังคงค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงยังคงเป็นข้อความ

ตัวเลือกนี้เรนเดอร์ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อฟอนต์ไม่มีรูปแบบ Bold แยก การ [Font substitution](/slides/th/php-java/font-substitution/) จะเลือกฟอนต์อื่นแทนเมื่อฟอนต์เดิมไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาร์เรย์นี้เริ่มจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **แปลง PowerPoint เป็น PDF พร้อมขนาดสไลด์กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสน้อมาสร้างงานใหม่โดยกำหนดขนาดสไลด์เป็น 612 × 792 จุด (8.5 × 11 นิ้ว) แล้วปรับสเกลเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // ลบสไลด์ว่างที่สร้างมาพร้อมงานนำเสนอใหม่.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองโน้ตสไลด์**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางโน้ตผู้พูดของแต่ละสไลด์ไว้ด้านล่างสไลด์ ใช้งานนำเสนอที่มีโน้ตผู้พูดเพื่อดูผลลัพธ์

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **มาตรฐานการเข้าถึงและการปฏิบัติตามสำหรับ PDF**

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ตามมาตรฐานการปฏิบัติตามเหล่านี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดต่อไปนี้แสดงกระบวนการแปลง PowerPoint‑to‑PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามต่าง ๆ:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบไฟล์ยอดนิยมอื่น ๆ คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) การแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปแบบเดียว ส่วนองค์ประกอบเส้นทางแยกจะไม่ได้รับการเก็บเป็นเนื้อหาแยกและอาจถูกระบุเป็น artefact; ข้อความแทนที่จะให้เฉพาะรูปภาพทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF พร้อมกันได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงหลายไฟล์ PPT หรือ PPTX เป็น PDF เป็นชุด คุณสามารถวนลูปไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยอัตโนมัติ

**ฉันสามารถตั้งรหัสผ่านให้ PDF ที่แปลงแล้วได้หรือไม่?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อกำหนดรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ฉันจะรวมสไลด์ที่ซ่อนอยู่ใน PDF ได้อย่างไร?**

เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) ด้วยค่า `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ได้

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) และ [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA, เพื่อให้เอกสารของคุณตรงกับข้อกำหนดด้านการเข้าถึงและการจัดเก็บระยะยาว

## **แหล่งข้อมูลเพิ่มเติม**

- [Aspose.Slides for PHP via Java Documentation](/slides/th/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)