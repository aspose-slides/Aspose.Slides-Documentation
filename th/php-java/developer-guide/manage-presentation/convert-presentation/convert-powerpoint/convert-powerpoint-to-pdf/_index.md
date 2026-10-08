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
description: "แปลง PowerPoint PPT/PPTX เป็น PDF คุณภาพสูงที่ค้นหาได้ใน PHP ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดที่เร็วและตัวเลือกการแปลงขั้นสูง."
---
## **ภาพรวม**

การแปลงงานนำเสนอ PowerPoint (PPT, PPTX, ODP ฯลฯ) เป็นรูปแบบ PDF ใน PHP มีข้อดีหลายประการ รวมถึงความเข้ากันได้กับอุปกรณ์ต่างๆ และการรักษาเค้าโครงและการจัดรูปแบบของงานนำเสนอ คําแนะนํานี้สาธิตวิธีแปลงงานนำเสนอเป็นเอกสาร PDF ใช้ตัวเลือกต่างๆ เพื่อควบคุมคุณภาพภาพ รวมสไลด์ที่ซ่อนอยู่ ป้องกัน PDF ด้วยรหัสผ่าน ตรวจจับการแทนที่ฟอนต์ เลือกสไลด์เฉพาะสำหรับการแปลง และใช้มาตรฐานการปฏิบัติตามสำหรับเอกสารผลลัพธ์

## **การแปลง PowerPoint เป็น PDF**

โดยใช้ Aspose.Slides คุณสามารถแปลงงานนำเสนอในรูปแบบต่อไปนี้เป็น PDF:

* **PPT**
* **PPTX**
* **ODP**

เพื่อแปลงงานนำเสนอเป็น PDF ให้นำชื่อไฟล์เป็นอาร์กิวเมนต์ไปยังคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) แล้วบันทึกงานนำเสนอเป็น PDF โดยใช้เมธอด [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) คลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) เปิดเผยเมธอด [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) ซึ่งโดยปกติใช้เพื่อแปลงงานนำเสนอเป็น PDF

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java แทรกข้อมูล API และหมายเลขเวอร์ชันลงในเอกสารผลลัพธ์ ตัวอย่างเช่น เมื่อแปลงงานนำเสนอเป็น PDF Aspose.Slides จะเติมฟิลด์ Application ด้วย "*Aspose.Slides*" และฟิลด์ PDF Producer ด้วยค่ารูปแบบ "*Aspose.Slides v XX.XX*" **Note** ว่าคุณไม่สามารถสั่งให้ Aspose.Slides เปลี่ยนหรือเอาข้อมูลนี้ออกจากเอกสารผลลัพธ์ได้

{{% /alert %}}

Aspose.Slides อนุญาตให้คุณแปลง:

* งานนำเสนอทั้งหมดเป็น PDF
* สไลด์เฉพาะจากงานนำเสนอเป็น PDF

Aspose.Slides ส่งออกงานนำเสนอเป็น PDF โดยทำให้ PDF ที่ได้ตรงกับงานนำเสนอเดิมอย่างใกล้เคียง ส่วนประกอบและแอตทริบิวต์ต่างๆ จะถูกแสดงผลอย่างแม่นยำในการแปลง รวมถึง:

* รูปภาพ
* กล่องข้อความและรูปร่าง
* การจัดรูปแบบข้อความ
* การจัดรูปแบบย่อหน้า
* ไฮเปอร์ลิงก์
* ส่วนหัวและส่วนท้าย
* จุดหัวเรื่อง
* ตาราง

## **แปลง PowerPoint เป็น PDF**

กระบวนการแปลง PowerPoint‑to‑PDF มาตรฐานใช้ตัวเลือกเริ่มต้น ในกรณีนี้ Aspose.Slides จะพยายามแปลงงานนำเสนอที่ให้เป็น PDF ด้วยการตั้งค่าที่เหมาะสมที่สุดในระดับคุณภาพสูงสุด

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

Aspose มีตัวแปลงออนไลน์ฟรีที่ให้บริการ [**ตัวแปลง PowerPoint เป็น PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) เพื่อสาธิตกระบวนการแปลงจากงานนำเสนอเป็น PDF คุณสามารถทดสอบด้วยตัวแปลงนี้เพื่อดูการทำงานจริงของขั้นตอนที่อธิบายในที่นี้

{{% /alert %}}

## **แปลง PowerPoint เป็น PDF พร้อมตัวเลือก**

Aspose.Slides มีตัวเลือกแบบกำหนดเอง—คุณสมบัติภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—ที่ทำให้คุณปรับแต่ง PDF ที่ได้ ล็อก PDF ด้วยรหัสผ่าน หรือระบุวิธีที่กระบวนการแปลงควรดำเนินต่อไป

### **แปลง PowerPoint เป็น PDF พร้อมตัวเลือกที่กำหนดเอง**

โดยใช้ตัวเลือกการแปลงแบบกำหนดเอง คุณสามารถกำหนดการตั้งค่าคุณภาพที่ต้องการสำหรับภาพเรสเตอร์ ระบุวิธีการจัดการเมตาไฟล์ ตั้งค่าระดับการบีบอัดสำหรับข้อความ กำหนด DPI สำหรับภาพ และอื่นๆ

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF 1.5 โดยตั้งค่าคุณภาพ JPEG เป็น 90, ความละเอียดภาพเป็น 300 DPI, เมตาไฟล์บันทึกเป็น PNG, และบีบอัดข้อความด้วย Flate

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

### **รักษาไฟล์ OLE ที่ฝังอยู่เป็นไฟล์แนบ PDF**

หากงานนำเสนอมีเวิร์กบุ๊ก Excel ฝังอยู่ คุณอาจต้องการให้ผู้รับ PDF สามารถเข้าถึงข้อมูลของเวิร์กบุ๊กได้พร้อมกับดูสไลด์ เรียกเมธอด [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) ด้วยค่า `true` เพื่อรักษาไฟล์ OLE ที่ฝังเป็นไฟล์แนบใน PDF ที่ผลลัพธ์

ค่าเริ่มต้นคือ `false`: ภาพพรีวิวหรือไอคอนของออบเจ็กต์ OLE จะถูกแสดงบนหน้า PDF แต่ไฟล์ที่ฝังอยู่จะไม่รวมเป็นไฟล์แนบ การตั้งค่าเป็น `true` จะเพิ่มไฟล์ข้อมูลลงไปด้วย พรีวิวยังคงเป็นภาพแสดงผล ส่วนไฟล์แนบทำให้ผู้รับเปิดหรือบันทึกไฟล์ฝังแยกต่างหาก ออบเจ็กต์ OLE จะไม่กลายเป็นแผ่นงาน Excel ที่โต้ตอบได้บนหน้า PDF

ตัวอย่างต่อไปนี้โหลดงานนำเสนอที่มีเวิร์กบุ๊ก Excel ฝังอยู่แล้วและส่งออกเป็น PDF พร้อมแนบเวิร์กบุ๊ก

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

1. เปิด PDF ที่ส่งออกในโปรแกรมดูที่รองรับไฟล์แนบ เช่น Adobe Acrobat Reader
2. เปิดแผง **Attachments** ของโปรแกรมและค้นหาเวิร์กบุ๊กที่ฝังอยู่
3. บันทึกไฟล์แนบและเปิดใน Excel เพื่อตรวจสอบข้อมูล หรือเปิดโดยตรงหากโปรแกรมดูอนุญาต พรีวิวบนหน้า PDF จะอยู่แยกจากไฟล์แนบ

{{% alert color="info" title="Note" %}}

มาตรฐาน PDF/A กำหนดข้อจำกัดเกี่ยวกับไฟล์แนบ: PDF/A‑1 ห้ามมีไฟล์ฝัง, PDF/A‑2 อนุญาตเฉพาะไฟล์แนบ PDF/A, PDF/A‑3 อนุญาตไฟล์ประเภทอื่นรวมถึงเวิร์กบุ๊ก Excel สิ่งเหล่านี้เป็นความต้องการของมาตรฐาน ไม่ใช่ข้อจำกัดของ Aspose.Slides ตัวอย่างนี้ใช้การตั้งค่าการปฏิบัติตาม PDF เริ่มต้นและไม่ได้สาธิตการส่งออกเป็น PDF/A

{{% /alert %}}

### **แปลง PowerPoint เป็น PDF พร้อมสไลด์ที่ซ่อนอยู่**

หากงานนำมีสไลด์ที่ซ่อนอยู่ คุณสามารถใช้เมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) จากคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนเป็นหน้าต่าง PDF ที่ผลลัพธ์

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF พร้อมรวมสไลด์ที่ซ่อนทั้งหมด

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

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF ที่ต้องใช้รหัสผ่าน `password` เพื่อเปิด การอนุญาตการเข้าถึงให้สิทธิ์พิมพ์รวมถึงการพิมพ์คุณภาพสูง

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

Aspose.Slides มีเมธอด [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) ภายใต้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) ซึ่งช่วยให้คุณตรวจจับการแทนที่ฟอนต์ระหว่างกระบวนการแปลงงานนำเสนอเป็น PDF

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF และพิมพ์คำเตือนการแทนที่ฟอนต์ไปยังคอนโซล คำเตือนจะปรากฏเฉพาะเมื่อฟอนต์ที่ไม่มีอยู่ถูกแทนที่ระหว่างการส่งออก

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

### **จัดการฟอนต์ที่ไม่มีรูปแบบ Bold เฉพาะ**

งานนำเสนออาจใช้การจัดรูปแบบตัวหนาสำหรับข้อความแม้ว่าแบบอักษรของมันจะไม่มีรูปแบบ Bold แยก การแสดงผลอาจดูหนาเกินไปหรือแตกต่างจากที่ต้องการใน PDF ให้ลองเรียกเมธอด [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) ด้วยค่า `true` ตัวเลือกนี้จะเรสเตอร์ข้อความที่ได้รับผลกระทบเป็นบิตแมพในระหว่างการส่งออก PDF และอาจทำให้แสดงผลดียิ่งขึ้นสำหรับฟอนต์บางชนิด ค่าตั้งต้นคือ `false`

งานนำเสนอที่ใช้ตัวอย่างมีสองกล่องข้อความ: กล่องหนึ่งมีข้อความธรรมดา และอีกกล่องหนึ่งมีการจัดรูปแบบตัวหนาโดยใช้ฟอนต์เดียวกันที่ไม่มีรูปแบบ Bold ตัวอย่างต่อไปนี้โหลดงานนำเสนอ เปิดใช้งานการเรสเตอร์ฟอนต์ที่ไม่รองรับรูปแบบตัวหนา และส่งออกเป็น PDF:

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

ภาพตัวอย่างต่อไปนี้แสดงผลลัพธ์ที่ปิดและเปิด ตัวอย่างนี้เมื่อปิดตัวเลือก ข้อความตัวหนาจะมีเส้นหนักกว่าปกติ เมื่อเปิดตัวเลือก เส้นของข้อความตัวหนาจะบางลง; ข้อความปกติไม่มีการเปลี่ยนแปลง เปรียบเทียบผลก่อนเลือกการตั้งค่าสำหรับงานนำเสนอของคุณ

| ตัวเลือกปิด (`false`, ค่าเริ่มต้น) | ตัวเลือกเปิด (`true`) |
|---|---|
| ![PDF ที่มีการแรสเตอร์ฟอนต์สไตล์ที่ไม่รองรับถูกปิด](unsupported-bold-disabled.png) | ![PDF ที่มีการแรสเตอร์ฟอนต์สไตล์ที่ไม่รองรับถูกเปิด](unsupported-bold-enabled.png) |

ในตัวอย่างนี้ การเปิดตัวเลือกทำให้เฉพาะข้อความตัวหนาถูกแรสเตอร์เป็นบิตแมพ: ไม่สามารถเลือก คัดลอก หรือค้นหาเป็นข้อความได้โดยไม่มี OCR และเส้นขอบจะดูนุ่มขึ้นเมื่อซูม 800% ข้อความปกติยังคงค้นหาได้ เมื่อปิดตัวเลือก ทั้งสองสตริงจะยังคงเป็นข้อความ

ตัวเลือกนี้ทำการเรสเตอร์ข้อความที่จัดรูปแบบเป็นตัวหนาเมื่อฟอนต์ไม่มีรูปแบบ Bold แยก การ [การแทนที่ฟอนต์](/slides/th/php-java/font-substitution/) จะเลือกฟอนต์อื่นเมื่อฟอนต์ต้นทางไม่พร้อมใช้งาน

## **แปลงสไลด์ที่เลือกจาก PowerPoint เป็น PDF**

ตัวอย่างต่อไปนี้ส่งออกสไลด์ 1 และ 3 จากงานนำเสนอเป็น PDF ตัวเลขสไลด์ในอาร์เรย์นี้เริ่มจาก 1 และงานนำเสนอเข้า ต้องมีอย่างน้อยสามสไลด์

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

## **แปลง PowerPoint เป็น PDF ด้วยขนาดสไลด์ที่กำหนดเอง**

ตัวอย่างต่อไปนี้คัดลอกสไลด์แรกจากงานนำเสนอไปยังงานนำเสนอใหม่ที่มีขนาดสไลด์ 612 × 792 พอยต์ (8.5 × 11 นิ้ว) ปรับขนาดเนื้อหาสไลด์ให้พอดีและส่งออกสไลด์เดียวเป็น PDF

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

    // ลบสไลด์เปล่าที่สร้างขึ้นในงานนำเสนอใหม่
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **แปลง PowerPoint เป็น PDF ในมุมมองสไลด์บันทึกย่อ**

ตัวอย่างต่อไปนี้ส่งออกงานนำเสนอเป็น PDF โดยวางบันทึกย่อของแต่ละสไลด์ไว้ด้านล่างสไลด์ ใช้งานนำเสนอที่มีบันทึกย่อเพื่อดูผลลัพธ์

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

Aspose.Slides อนุญาตให้คุณใช้กระบวนการแปลงที่สอดคล้องกับ [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) คุณสามารถส่งออกเอกสาร PowerPoint ไปเป็น PDF ด้วยมาตรฐานการปฏิบัติตามใดต่อไปนี้: **PDF/A1a**, **PDF/A1b**, และ **PDF/UA**

โค้ดนี้สาธิตกระบวนการแปลง PowerPoint‑to‑PDF ที่สร้าง PDF หลายไฟล์ตามมาตรฐานการปฏิบัติตามที่แตกต่างกัน:

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

Aspose.Slides รองรับการแปลง PDF ไปยังรูปแบบไฟล์ยอดนิยม คุณสามารถทำการแปลง [PDF เป็น HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF เป็นภาพ](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF เป็น JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), และ [PDF เป็น PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) การแปลง PDF ไปยังรูปแบบเฉพาะอื่น ๆ เช่น [PDF เป็น SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF เป็น TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), และ [PDF เป็น XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) ก็ได้รับการสนับสนุนเช่นกัน

{{% /alert %}}

> **หมายเหตุ:** เมื่อส่งออกเป็น PDF/UA, Aspose.Slides จะถือกราฟิกที่ซับซ้อนเช่น SmartArt, แผนภูมิ, และสูตรเป็นรูปภาพเดียว องค์ประกอบเส้นทางแต่ละอันจะไม่ถูกเก็บเป็นเนื้อหาแยกและอาจถูกทำเครื่องหมายว่าเป็นอาร์ติแฟกต์; ข้อความอธิบายทางเลือกจะถูกให้เพียงสำหรับรูปภาพทั้งหมดเท่านั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงไฟล์ PowerPoint หลายไฟล์เป็น PDF พร้อมกันได้หรือไม่?**

ได้, Aspose.Slides รองรับการแปลงเป็นชุดของไฟล์ PPT หรือ PPTX หลายไฟล์เป็น PDF คุณสามารถวนลูปไฟล์ของคุณและประมวลผลการแปลงแบบโปรแกรมได้

**สามารถป้องกัน PDF ที่แปลงแล้วด้วยรหัสผ่านได้หรือไม่?**

ได้. ใช้คลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อตั้งรหัสผ่านและกำหนดสิทธิ์การเข้าถึงระหว่างกระบวนการแปลง

**ทำอย่างไรจึงจะรวมสไลด์ที่ซ่อนอยู่ใน PDF?**

เรียกเมธอด [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) ด้วยค่า `true` ในคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อรวมสไลด์ที่ซ่อนอยู่ใน PDF ที่ผลลัพธ์

**Aspose.Slides สามารถรักษาคุณภาพภาพสูงใน PDF ได้หรือไม่?**

ได้, คุณสามารถควบคุมคุณภาพภาพได้โดยใช้เมธอดเช่น [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) และ [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) ในคลาส [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) เพื่อให้ได้ภาพคุณภาพสูงใน PDF ของคุณ

**Aspose.Slides รองรับมาตรฐานการปฏิบัติตาม PDF/A หรือไม่?**

ได้, Aspose.Slides อนุญาตให้คุณส่งออก PDF ที่สอดคล้องกับ [มาตรฐานต่างๆ](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) รวมถึง PDF/A1a, PDF/A1b, และ PDF/UA เพื่อให้เอกสารของคุณตรงตามข้อกำหนดด้านการเข้าถึงและการเก็บรักษา

## **แหล่งข้อมูลเพิ่มเติม**

- [เอกสาร Aspose.Slides for PHP via Java](/slides/th/php-java/)
- [อ้างอิง API Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [Aspose ตัวแปลงออนไลน์ฟรี](https://products.aspose.app/slides/conversion)