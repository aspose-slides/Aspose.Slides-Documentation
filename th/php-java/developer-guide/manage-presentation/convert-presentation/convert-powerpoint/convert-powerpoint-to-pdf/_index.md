---
title: แปลง PPT และ PPTX เป็น PDF ใน PHP [รวมฟีเจอร์ขั้นสูง]
linktitle: PowerPoint เป็น PDF
type: docs
weight: 40
url: /th/php-java/convert-powerpoint-to-pdf/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- PowerPoint เป็น PDF
- งานนำเสนอเป็น PDF
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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF ที่มีคุณภาพสูงและสามารถค้นหาได้ใน PHP ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่รวดเร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ด้วย PHP มีข้อได้เปรียบหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่าง ๆ และการรักษาเค้าโครงและรูปแบบของงานนำเสนอ ไข่คู่มือนี้สาธิตวิธีการแปลงงานนำเสนอเป็นเอกสาร PDF การใช้ตัวเลือกต่าง ๆ เพื่อควบคุมคุณภาพภาพ การรวมสไลด์ที่ซ่อนไว้ การปกป้องไฟล์ PDF ด้วยรหัสผ่าน การตรวจจับการแทนที่ฟอนต์ การเลือกสไลด์เฉพาะสำหรับการแปลง และการใช้มาตรฐานการปฏิบัติตามกับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้ส่งชื่อไฟล์เป็นอาร์กิวเมนต์ให้คลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) จากนั้นบันทึกงานนำเสนอเป็น PDF ด้วยเมธอด [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) คลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) ที่โดยทั่วไปใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java จะใส่ข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF, Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่าที่มีรูปแบบ "*Aspose.Slides v XX.XX*" **Note** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้
{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:
* การนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากการนำเสนอเป็น PDF

Aspose.Slides ส่งออกการนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับการนำเสนอเดิมอย่างใกล้ชิด ส่วนประกอบและแอตทริบิวต์ต่าง ๆ จะถูกเรนเดอร์อย่างแม่นยำในการแปลง รวมถึง:
* รูปภาพ
* กล่องข้อความและรูปทรง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดสัญลักษณ์หัวข้อ
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint เป็น PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดและระดับคุณภาพสูงสุด

ตัวอย่างต่อไปนี้โหลดงานนำเสนอและบันทึกสไลด์ที่มองเห็นทั้งหมดเป็น PDF โดยใช้การตั้งค่าการส่งออกเริ่มต้น

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
Aspose มีตัวแปลง PowerPoint เป็น PDF ออนไลน์ฟรีที่สาธิตกระบวนการแปลงการนำเสนอเป็น PDF คุณสามารถทดสอบกับตัวแปลงนี้เพื่อดูการใช้งานจริงของขั้นตอนที่อธิบายในที่นี่: [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf)
{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—ที่ให้คุณปรับแต่ง PDF ที่ได้ ล็อค PDF ด้วยรหัสผ่าน หรือระบุวิธีการดำเนินการแปลง

### **แปลง PowerPoint เป็น PDF ด้วยตัวเลือกแบบกำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุการจัดการไฟล์เมตา กำหนดระดับการบีบอัดสำหรับข้อความ กำหนดค่า DPI สำหรับภาพ และอื่น ๆ

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

### **เก็บไฟล์ OLE ฝังเป็นเอกสารแนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊กได้พร้อมกับดูสไลด์ เรียกใช้เมธอด [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) ด้วยค่า `true` เพื่อเก็บไฟล์ OLE ฝังเป็นไฟล์แนบใน PDF ที่ได้

ค่าเริ่มต้นคือ `false`: ภาพตัวอย่างหรือไอคอนของวัตถุ OLE จะถูกเรนเดอร์บนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่ได้รวมเป็นไฟล์แนบ การตั้งค่าเป็น `true` จะเพิ่มข้อมูลไฟล์เข้าไปด้วย การแสดงภาพตัวอย่างยังคงเป็นเพียงการแสดงภาพทางสายตา; ไฟล์แนบทำให้ผู้รับสามารถเปิดหรือบันทึกไฟล์ที่ฝังแยกต่างหากได้ วัตถุ OLE จะไม่กลายเป็นแผ่นงาน Excel แบบโต้ตอบบนหน้า PDF

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

เพื่อตรวจสอบผลลัพธ์:
1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่สนับสนุนไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **ไฟล์แนบ** ของโปรแกรมดูและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต การแสดงตัวอย่างบนหน้า PDF แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}
มาตรฐาน PDF/A มีข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A-1 ไม่อนุญาตไฟล์ฝัง, PDF/A-2 อนุญาตไฟล์แนบ PDF/A เท่านั้น, และ PDF/A-3 อนุญาตประเภทไฟล์อื่น ๆ รวมถึงเวิร์กบุ๊ก Excel นี้เป็นข้อกำหนดของมาตรฐาน ไม่ได้เป็นข้อจำกัดเฉพาะของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออกเป็น PDF/A
{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อน**

หากงานนำมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) จากคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าบน PDF ที่ได้

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

### **แปลง PowerPoint เป็น PDF ที่มีการป้องกันด้วยรหัสผ่าน**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใส่รหัสผ่าน `password` จึงจะเปิดได้ สิทธิ์การเข้าถึงอนุญาตให้พิมพ์รวมถึงการพิมพ์คุณภาพสูง

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

Aspose.Slides ให้เมธอด [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงการนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ไปยังคอนโซล คำเตือนจะถูกพิมพ์เมื่อมีการแทนที่ฟอนต์ที่ไม่พร้อมใช้งานในระหว่างการส่งออกเท่านั้น

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
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับการแทนที่ฟอนต์ ดูบทความ [การแทนที่ฟอนต์](/slides/th/php-java/font-substitution/)
{{% /alert %}} 

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ที่ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาเรย์นี้เริ่มนับจาก 1 และงานนำเข้าต้องมีอย่างน้อยสามสไลด์

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

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเข้าสู่งานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 จุด (8.5 × 11 นิ้ว) มันปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดี่ยวเป็น PDF

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

    // ลบสไลด์ว่างที่สร้างขึ้นโดยการนำเสนอใหม่
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกย่อนักพูดของแต่ละสไลด์ไว้ด้านล่างสไลด์ ใช้งานนำเสนอที่มีบันทึกย่อเพื่อดูผลลัพธ์

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

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [แนวทางการเข้าถึงเนื้อหาเว็บ (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint เป็น PDF ด้วยมาตรฐานการปฏิบัติใด ๆ ต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

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
Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบไฟล์ยอดนิยม คุณสามารถทำการแปลง [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), และ [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) นอกจากนี้ยังสนับสนุนการแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), และ [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)
{{% /alert %}}

> **Note:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรคณิตศาสตร์เป็นรูปทรงเดียว ส่วนองค์ประกอบเส้นทางแยกไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายเป็น “artifacts”; คำอธิบายทางเลือกจะให้เฉพาะกับรูปทรงทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**Can I convert multiple PowerPoint files to PDF in bulk?**

ใช่, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปผ่านไฟล์ของคุณและเรียกใช้กระบวนการแปลงโดยโปรแกรมได้

**Is it possible to password-protect the converted PDF?**

ใช่. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงในระหว่างกระบวนการแปลง

**How do I include hidden slides in the PDF?**

เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) ด้วยค่า `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนใน PDF ที่ได้

**Can Aspose.Slides maintain high image quality in the PDF?**

ใช่, คุณสามารถควบคุมคุณภาพภาพโดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) และ [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) ในคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Does Aspose.Slides support PDF/A compliance standards?**

ใช่, Aspose.Slides ให้คุณส่งออก PDF ที่สอดคล้องกับ [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดการเข้าถึงและการเก็บถาวร

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides สำหรับ PHP ผ่าน Java](/slides/th/php-java/)
- [อ้างอิง API Aspose.Slides สำหรับ PHP ผ่าน Java](https://reference.aspose.com/slides/php-java/)
- [Aspose ตัวแปลงออนไลน์ฟรี](https://products.aspose.app/slides/conversion)